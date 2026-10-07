Public Class frmConfigEmail
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

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
        limpiarObjetos()
    End Sub

    Public Sub cargarDetalle(ByVal v_idConfigEmail As Integer)
        '-- consultar el detalle del email
        sp_datosTabla.sp_string("sp_cargarDetalleConfigEmail", intGl_idConfigPc & "," & v_idConfigEmail)
    End Sub

    Sub listar(ByVal where As String)
        Try
            systemClass.SqlToLv(lvBuscar, "select c.idConfigEmail,t.nombreProceso   from cabConfigEmail c inner join tipoProceso t " & _
                                " on c.idTipoProceso=t.idTipoProceso " & where)
            txtSql.Text = "select c.idConfigEmail,t.nombreProceso   from cabConfigEmail c inner join tipoProceso t " & _
                                " on c.idTipoProceso=t.idTipoProceso " & where

            ' dimensionar las columnas
            lvBuscar.Columns(0).Width = 80    'idConfigEmail
            lvBuscar.Columns(1).Width = 200  'Nombre del tipo de proceso
            lvBuscar.Scrollable = True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub listarDetalle()
        Try
            '-- cargar en la grilla
            systemClass.SqlToLv(lvDetCorreo, "select (row_number() over(order by usuario)) as Nro," & _
            "idConfigEmail,idUsuario,usuario,correo from detConfigEmailTmp  where idConfig=" & intGl_idConfigPc & _
            " order by usuario")
            txtSql.Text = "select (row_number() over(order by usuario)) as Nro," & _
            "idConfigEmail,idUsuario,usuario,correo from detConfigEmailTmp  where idConfig=" & intGl_idConfigPc & _
            " order by usuario"

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub habilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = False
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        btnAgregar.Enabled = True
        btnEliminar.Enabled = True
        '-- valor a los labels
        lblNro.Text = 0
        lblIdUsuario.Text = 0
    End Sub

    Private Sub deshabilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = True
        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        listar("")
    End Sub

    Public Sub limpiarObjetos()
        lblIdTipoProceso.Text = 0
        lblIdUsuario.Text = 0
        lblNro.Text = 0
        lblIdConfigEmail.Text = 0
        lblNombreProceso.Text = ""
    End Sub

    Private Sub guardar()
        '-- variables para los parametros
        Dim intTmpIdTipoProceso As Integer
        intTmpIdTipoProceso = CInt(lblIdTipoProceso.Text)

        If MessageBox.Show("Desea Guardar la Configuración..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If (fun_guardarSp("sp_guardarConfigEmail", intGl_idConfigPc & "," & intTmpIdTipoProceso & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
                limpiarObjetos()
            End If
        End If

    End Sub
    '-------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        '-- eliminar todo lo de la tabla temporal
        sp_datosTabla.consulta_valor("delete from detConfigEmailTmp where idConfig=" & intGl_idConfigPc)
        listarDetalle()
        '---------------------------
        banGl_configEmail = True
        Me.Enabled = False
        frmBuscarTipoProceso.txtBuscar.Text = ""
        frmBuscarTipoProceso.txtIdMoneda.Text = 0
        frmBuscarTipoProceso.Show()
        frmBuscarTipoProceso.BringToFront()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If lblIdTipoProceso.Text = 0 Then
            MessageBox.Show("Debe elegir algun Tipo de Proceso para modificarlo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            habilitarObjetos()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Me.Enabled = False

        frmBuscarUsuarioConfig.txtBuscar.Text = ""
        frmBuscarUsuarioConfig.txtId.Text = 0
        frmBuscarUsuarioConfig.Visible = True
        frmBuscarUsuarioConfig.Show()
        frmBuscarUsuarioConfig.BringToFront()
        frmBuscarUsuarioConfig.txtBuscar.Focus()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If IsNumeric(lblNro.Text) Then
            If lblNro.Text > 0 Then
                '-- eliminar el registro de la tabla temporal
                sp_datosTabla.consulta_valor("delete from detConfigEmailTmp where idConfig=" & intGl_idConfigPc & " and idusuario=" & lblIdUsuario.Text)
                '-- eliminar el registro de la tabla
                sp_datosTabla.consulta_valor("delete from detConfigEmail where idConfigEmail=" & CInt(lblIdConfigEmail.Text) & " and idUsuario=" & lblIdUsuario.Text)
                '---------------------------------------------------------
                listarDetalle()
            End If

        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '***************'
    '-- LISTVIEW --'
    '***************'
    Private Sub lvBuscar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        Dim intTmpIdConfigEmail As Integer
        For Each item As ListViewItem In lvBuscar.SelectedItems
            intTmpIdConfigEmail = CInt(item.SubItems(0).Text)
            lblIdConfigEmail.Text = intTmpIdConfigEmail
            lblIdTipoProceso.Text = sp_datosTabla.consulta_valor("select idTipoProceso from cabConfigEmail where idConfigEmail=" & intTmpIdConfigEmail)
            lblNombreProceso.Text = item.SubItems(1).Text
            '-- cargar el detalle del email
            cargarDetalle(intTmpIdConfigEmail)
            listarDetalle()
        Next
    End Sub

    Private Sub lvDetCorreo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvDetCorreo.SelectedIndexChanged
        For Each item As ListViewItem In lvDetCorreo.SelectedItems
            lblNro.Text = CInt(item.SubItems(0).Text)
            lblIdUsuario.Text = CInt(item.SubItems(2).Text)
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
                    '-- buscar por idConfigEmail
                    listar(" where c.idConfigEmail Like '" & txtBuscar.Text & "%' Or c.idConfigEmail Like '" & txtBuscar.Text & "%' " & "order by idConfigEmail")
                Else
                    '-- buscar por nombre
                    listar(" where  Like '" & txtBuscar.Text & "%' Or t.nombreProceso Like '" & txtBuscar.Text & "%' " & "order by t.nombreProceso")
                End If
            End If
            lvBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConfigEmail_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.configuracionEmail.Enabled = True
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------
End Class