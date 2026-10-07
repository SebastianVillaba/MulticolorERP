Public Class frmAbmTipoProcesoEmail
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim sucursal As New Sucursal

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
        systemClass.SqlToLv(lvBuscar, "Select idTipoProceso, nombreProceso from tipoProceso " & where)
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80    'idTipoProceso
        lvBuscar.Columns(1).Width = 200  'Nombre del tipo de Proceso
        lvBuscar.Scrollable = True
    End Sub

    Private Sub hablitarObjetos()
        '-- el grupo
        grBuscar.Enabled = False
        '-- los txt
        txtNombre.Enabled = True
        txtNombre.BackColor = Color.White
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
    End Sub

    Private Sub deshabilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = True
        '-- los txt
        txtNombre.Enabled = False
        txtNombre.BackColor = Color.SkyBlue
        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True

        listar("")
    End Sub

    Private Sub limpiarObjeto()
        '--txt 
        txtIdTipoProceso.Text = 0
        txtNombre.Text = ""
    End Sub

    Private Sub guardar()
        '-- variables para los parametros
        Dim strTmpNombre As String
        Dim intTmpIdTipoProceso As Integer
        '-- dar valor a las variables
        strTmpNombre = txtNombre.Text
        intTmpIdTipoProceso = sacarComa(txtIdTipoProceso.Text)
        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insTipoProcesoEmail", "'" & strTmpNombre & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
            If (fun_guardarSp("sp_updTipoProcesoEmail", intTmpIdTipoProceso & "," & "'" & strTmpNombre & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
        txtNombre.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If IsNumeric(txtIdTipoProceso.Text) Then
            If txtIdTipoProceso.Text > 0 Then
                bolTmpNuevo = False
                hablitarObjetos()
                txtNombre.Focus()
            Else
                MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

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
        Dim intTmpIdTipoProceso As Integer
        Dim intTmpIdUsuario As Integer
        For Each item As ListViewItem In lvBuscar.SelectedItems
            intTmpIdTipoProceso = CInt(item.SubItems(0).Text)
            txtIdTipoProceso.Text = intTmpIdTipoProceso
            txtNombre.Text = item.SubItems(1).Text
            '-- usuario alta
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from tipoProceso where idTipoProceso=" & intTmpIdTipoProceso)
            txtUsuarioAlta.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
            txtFechaAlta.Text = sp_datosTabla.consulta_valorString("select fechaAlta from tipoProceso where idTipoProceso=" & intTmpIdTipoProceso)
            '-- usuario modificado
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioMod from tipoProceso where idTipoProceso=" & intTmpIdTipoProceso)
            txtUsuarioMod.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
            txtFechaMod.Text = sp_datosTabla.consulta_valorString("select fechaAlta from tipoProceso where idTipoProceso=" & intTmpIdTipoProceso)
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
                    '-- buscar por IdTipoProceso
                    listar(" where idTipoProceso= " & txtBuscar.Text)
                Else
                    '-- buscar por nombre
                    listar(" where nombreProceso Like '" & txtBuscar.Text & "%' Or nombreProceso Like '" & txtBuscar.Text & "%' " & "order by nombreProceso")
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
            frmMenuPrincipal.configuracionTipoProceso.Enabled = True
            e.Cancel = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub
    '---------------------------------------------------------------------------------------------------
End Class