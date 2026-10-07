Public Class frmAbmDeposito
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim sucursal As New Sucursal
    Dim tipoDeposito As New tipoDeposito

    Dim bolTmpNuevo As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select d.idDeposito, d.nombreDeposito, _vs.nombreFantasia from deposito d inner join " & _
                            " v_sucursal _vs on d.idSucursal=_vs.idSucursal " & where)
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80    'idDeposito
        lvBuscar.Columns(1).Width = 200  'Nombre del deposito
        lvBuscar.Columns(2).Width = 200  'Nombre de la sucursal
        lvBuscar.Scrollable = True
    End Sub

    Private Sub hablitarObjetos()
        '-- el grupo
        grBuscar.Enabled = False
        '-- los txt
        txtNombreDeposito.Enabled = True
        txtNombreDeposito.BackColor = Color.White
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        '-- el chk
        chkActivo.Enabled = True
        chkCanje.Enabled = True
        '-- el combo
        cboSucursal.Enabled = True
        cboTipoDeposito.Enabled = True

    End Sub

    Private Sub deshabilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = True
        '-- los txt
        txtNombreDeposito.Enabled = False
        txtNombreDeposito.BackColor = Color.SkyBlue
        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        '-- el chk
        chkActivo.Enabled = False
        chkCanje.Enabled = False
        '-- el combo
        cboSucursal.Enabled = False
        cboTipoDeposito.Enabled = False

        listar("")
    End Sub

    Private Sub limpiarObjeto()
        '--txt 
        txtIdDeposito.Text = 0
        txtNombreDeposito.Text = ""
    End Sub

    Private Sub guardar()
        '-- variables para los parametros
        Dim intTmpIdDeposito As Integer
        Dim strTmpNombreDeposito As String
        Dim bolTmpActivo As Boolean
        Dim bolTmpCanje As Boolean
        Dim intTmpIdSucursal As Integer
        '-- dar valor a las variables
        strTmpNombreDeposito = txtNombreDeposito.Text
        intTmpIdDeposito = CInt(txtIdDeposito.Text)
        bolTmpActivo = chkActivo.Checked
        bolTmpCanje = chkCanje.Checked
        intTmpIdSucursal = CInt(cboSucursal.SelectedValue)
        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insDeposito", cboTipoDeposito.SelectedValue & "," & intTmpIdSucursal & "," & "'" & strTmpNombreDeposito & "'" & "," & bolTmpCanje & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        Else
            '******************'
            '-- MODIFICACION --'
            '******************'
            If (fun_guardarSp("sp_updDeposito", intTmpIdDeposito & "," & cboTipoDeposito.SelectedValue & "," & intTmpIdSucursal & "," & "'" & strTmpNombreDeposito & "'" & "," & bolTmpActivo & "," & bolTmpCanje & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        End If

    End Sub
    '-------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True
        hablitarObjetos()
        limpiarObjeto()
        chkActivo.Checked = True
        chkActivo.Enabled = False
        sucursal.comboSucursal(cboSucursal)
        tipoDeposito.ListaTipoDepositoCb(cboTipoDeposito)

        cboSucursal.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtNombreDeposito.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        bolTmpNuevo = False
        hablitarObjetos()
        txtNombreDeposito.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub
    '--------------------------------------------------------------------------------------------------
    '***************'
    '-- LISTVIEW --'
    '***************'
    Private Sub lvBuscar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        Dim intTmpIdDeposito As Integer
        For Each item As ListViewItem In lvBuscar.SelectedItems
            intTmpIdDeposito = CInt(item.SubItems(0).Text)
            txtIdDeposito.Text = intTmpIdDeposito
            txtNombreDeposito.Text = item.SubItems(1).Text
            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "deposito", "idDeposito", intTmpIdDeposito)
            chkCanje.Checked = sp_datosTabla.un_dato_boleano("canje", "deposito", "idDeposito", intTmpIdDeposito)
            '-- la sucursal
            sucursal.comboSucursal(cboSucursal)
            cboSucursal.SelectedValue = sp_datosTabla.un_dato_integer("idSucursal", "deposito", "idDeposito", intTmpIdDeposito)
            '-- el tipo de deposito
            tipoDeposito.ListaTipoDepositoCb(cboTipoDeposito)
            cboTipoDeposito.SelectedValue = sp_datosTabla.consulta_valor("select idTipoDeposito from deposito where idDeposito=" & intTmpIdDeposito)
        Next
    End Sub

    Private Sub lvFormulario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- si solo se presiono enter
            If Len(txtBuscar.Text) = 0 Then
                '-- listar todo
                listar("")
            Else
                If IsNumeric(txtBuscar.Text) Then
                    '-- buscar por IdUsuario
                    listar(" where idDeposito Like '" & txtBuscar.Text & "%' Or idDeposito Like '" & txtBuscar.Text & "%' " & "order by idDeposito")
                Else
                    '-- buscar por nombre
                    listar(" where nombreDeposito Like '" & txtBuscar.Text & "%' Or nombreDeposito Like '" & txtBuscar.Text & "%' " & "order by nombreDeposito")
                End If
            End If
            lvBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmDeposito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.abmDeposito.Enabled = True
            e.Cancel = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub
    '---------------------------------------------------------------------------------------------------
End Class