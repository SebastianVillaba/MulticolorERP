Public Class frmAbmTipoProducto
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim bolTmpNuevo As Boolean

    Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '*********************'
    '-- PROCEDIMIENTOS --'
    '*********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvTipoProducto, "Select _vtp.idTipoProducto,_vtp.nombreTipo,_vtp.idtipo from v_tipoProducto _vtp" & where)
        ' dimensionar las columnas
        lvTipoProducto.Columns(0).Width = 50 'idTipoProduco
        lvTipoProducto.Columns(1).Width = 200 'nombre
        lvTipoProducto.Columns(2).Width = 50 'idTipo
        lvTipoProducto.Scrollable = True
    End Sub

    'listar los tipos que no están como tipo de producto
    Sub listarTipo(ByVal sentencia As String)
        systemClass.SqlToLv(lvTipo, "select t.idtipo,t.nombreTipo from tipo t where t.idTipo " & _
                            " not in (select idTipo from tipoProducto)" & sentencia)
        'dimensionar las columnas
        lvTipo.Columns(0).Width = 50    'idTipo
        lvTipo.Columns(1).Width = 200   'nombre
        lvTipo.Scrollable = True
    End Sub

    Private Sub habilitarObjetos()
        grBuscar.Visible = False
        grTipo.Visible = True
        '-- los chk
        chkActivo.Enabled = True
        chkComision.Enabled = True
        chkPorcentajeCompra.Enabled = True
        chkVence.Enabled = True
        chkHabilitarDecimal.Enabled = True
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        btnImprimir.Enabled = False

    End Sub

    Private Sub deshabilitarObjetos()
        grBuscar.Visible = True
        grBuscar.Enabled = True
        grTipo.Visible = False
        '-- los chk
        chkActivo.Enabled = False
        chkComision.Enabled = False
        chkPorcentajeCompra.Enabled = False
        chkVence.Enabled = False
        chkHabilitarDecimal.Enabled = False
        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        btnImprimir.Enabled = True
    End Sub

    Private Sub limpiarObjetos()
        '-- los txt
        txtIdTipoProducto.Text = 0
        txtNombre.Text = ""
        '-- los chk
        chkActivo.Checked = False
        chkComision.Checked = False
        chkPorcentajeCompra.Checked = False
        chkVence.Checked = False
        chkHabilitarDecimal.Checked = False
    End Sub

    Private Sub guardarTipoProducto()
        Try
            '-- variables para los parametros
            Dim intTmpIdTipo As Integer
            Dim intTmpIdTipoProducto As Integer

            '-- dar valor a las variables de parametro
            intTmpIdTipoProducto = CInt(txtIdTipoProducto.Text)
            intTmpIdTipo = CInt(txtIdTipo.Text)
            If bolTmpNuevo = True Then
                '***********'
                '-- NUEVO --'
                '***********'
                If (fun_guardarSp("sp_insTipoProducto", intTmpIdTipo & "," & chkVence.Checked & "," & chkComision.Checked & "," & chkPorcentajeCompra.Checked & "," & chkHabilitarDecimal.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '-- se guardo los registros
                    MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    deshabilitarObjetos()
                End If
            Else
                '******************'
                '-- MODIFICACION --'
                '******************'
                '-- si es una actualizacion
                If (fun_guardarSp("sp_updTipoProducto", intTmpIdTipo & "," & intTmpIdTipoProducto & "," & chkVence.Checked & "," & chkComision.Checked & "," & chkPorcentajeCompra.Checked & "," & chkHabilitarDecimal.Checked & "," & chkActivo.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '-- se guardo los registros
                    MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    deshabilitarObjetos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub
    '-----------------------------------------------------------------------------------------------
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
                    listar(" Where _vtp.idTipoProducto Like '" & txtBuscar.Text & "%' Or _vtp.idTipoProducto Like '" & txtBuscar.Text & "%' " & "order by _vtp.idTipoProducto")
                Else
                    '-- buscar por nick
                    listar(" Where _vtp.nombreTipo Like '" & txtBuscar.Text & "%' Or _vtp.nombreTipo Like '" & txtBuscar.Text & "%' " & "order by _vtp.nombreTipo")
                End If
            End If
            lvTipoProducto.Focus()
        End If
    End Sub

    Private Sub txtBuscarTipo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarTipo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- si solo se presiono enter
            If Len(txtBuscarTipo.Text) = 0 Then
                '-- listar todo
                listarTipo("")
            Else
                If IsNumeric(txtBuscarTipo.Text) Then
                    '-- buscar por idTipo
                    listar(" and t.idTipo Like '" & txtBuscarTipo.Text & "%' Or t.idTipo Like '" & txtBuscarTipo.Text & "%' " & "order by t.idTipo")
                Else
                    '-- buscar por nombre de Tipo
                    listar(" and t.nombreTipo Like '" & txtBuscarTipo.Text & "%' Or t.nombreTipo Like '" & txtBuscarTipo.Text & "%' " & "order by t.nombreTipo")
                End If
            End If
            lvTipo.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True

        listarTipo("")

        habilitarObjetos()
        limpiarObjetos()
        chkActivo.Enabled = False
        chkActivo.Checked = True
        txtBuscarTipo.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtIdTipoProducto.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        habilitarObjetos()
        grBuscar.Visible = True
        grBuscar.Enabled = False
        grTipo.Visible = False
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        grBuscar.Enabled = True
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarTipoProducto()
    End Sub
    '-----------------------------------------------------------------------------------------------
    '******************'
    '-- EL LISTVIEW --'
    '******************'
    Private Sub lvTipoProducto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvTipoProducto.SelectedIndexChanged
        Dim intTmpIdTipoProducto As Integer
        For Each item As ListViewItem In lvTipoProducto.SelectedItems
            '-- colocar en una variable el idTipoProducto
            intTmpIdTipoProducto = CInt(item.SubItems(0).Text)
            txtIdTipoProducto.Text = intTmpIdTipoProducto
            txtNombre.Text = item.SubItems(1).Text
            txtIdTipo.Text = CInt(item.SubItems(2).Text)
            '-- los chk
            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)
            chkComision.Checked = sp_datosTabla.un_dato_boleano("comision", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)
            chkPorcentajeCompra.Checked = sp_datosTabla.un_dato_boleano("porcentajeCompra", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)
            chkVence.Checked = sp_datosTabla.un_dato_boleano("vence", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)
            chkHabilitarDecimal.Checked = sp_datosTabla.consulta_valorBoolean("select habilitarDecimal from tipoProducto where idTipoProducto=" & intTmpIdTipoProducto)
            '-- datos de la auditoria del usuario
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioAlta", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioMod", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)))
            txtFechaAlta.Text = sp_datosTabla.un_datoString("fechaAlta", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)
            txtFechaMod.Text = sp_datosTabla.un_datoString("fechaMod", "tipoProducto", "idTipoProducto", intTmpIdTipoProducto)
        Next
    End Sub

    Private Sub lvTipoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvTipoProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvTipo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvTipo.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscarTipo.Focus()
        End If
    End Sub

    Private Sub lvTipo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvTipo.SelectedIndexChanged
        Dim intTmpIdTipo As Integer
        For Each item As ListViewItem In lvTipo.SelectedItems
            intTmpIdTipo = CInt(item.SubItems(0).Text)
            txtNombre.Text = item.SubItems(1).Text
            txtIdTipo.Text = intTmpIdTipo
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmTipoProducto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.abmTipoProducto.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------------------

End Class