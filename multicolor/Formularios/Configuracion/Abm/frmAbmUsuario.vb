Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmAbmUsuario
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim grupoUsuario As New grupoUsuario

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
        systemClass.SqlToLv(lvUsuario, "Select _vu.idUsuario,_vu.nick,_vu.nombre,_vu.apellido from v_usuarioT _vu" & where)
        ' dimensionar las columnas
        lvUsuario.Columns(0).Width = 50 'idUsuario
        lvUsuario.Columns(1).Width = 100 'nick
        lvUsuario.Columns(2).Width = 200 'nombre
        lvUsuario.Columns(3).Width = 200 'apellido
        lvUsuario.Scrollable = True
    End Sub

    'listar los personales que todavia no están como usuario
    Sub listarPersonal(ByVal sentencia As String)
        systemClass.SqlToLv(lvPersonal, "select _vp.idPersonal,_vp.nombre,_vp.apellido from v_personal _vp where _vp.idPersonal not in (select idPersonal from v_usuarioT)" & sentencia)
        'dimensionar las columnas
        lvPersonal.Columns(0).Width = 50    'idPersonal
        lvPersonal.Columns(1).Width = 200   'nombre
        lvPersonal.Columns(2).Width = 200   'apellido
        lvPersonal.Scrollable = True
    End Sub

    Private Sub habilitarObjetos()
        grBuscar.Visible = False
        grPersonal.Visible = True
        '-- los txt
        txtNick.Enabled = True
        txtNick.BackColor = Color.White
        '-- los combos
        cboGrupo.Enabled = True
        '-- los chk
        chkActivo.Enabled = True
        chkAdministrador.Enabled = True
        chkAnularCompra.Enabled = True
        chkAnularNotaCredito.Enabled = True
        chkAnularVenta.Enabled = True
        chkEmpresaContable.Enabled = True
        chkSoloTarjeta.Enabled = True
        chkDesarrollador.Enabled = True
        chkAnularDepositoBanco.Enabled = True
        chkAnularPedidoSucursal.Enabled = True
        chkAnularRemision.Enabled = True
        chkAnularPedidoProveedor.Enabled = True
        chkAnularGasto.Enabled = True
        chkAnularPago.Enabled = True
        chkAnularNcrCanje.Enabled = True
        chkAnularCheque.Enabled = True
        chkAnularCobranza.Enabled = True
        chkAnularVentaSucursal.Enabled = True
        chkAnularDescuentoCliente.Enabled = True
        chkAnularRecepcion.Enabled = True
        chkAnularDevolucion.Enabled = True
        chkAnularOrdenCheque.Enabled = True
        chkAnularCanje.Enabled = True
        chkAnularRemisionPendiente.Enabled = True
        chkAnularActividadRepartidor.Enabled = True
        chkAnularGastoVenta.Enabled = True

        '-- los botones
        btnCancelar.Enabled = True
        btnGenerarCodigoBarra.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        btnImprimirCodigoBarra.Enabled = False

    End Sub

    Private Sub deshabilitarObjetos()
        grBuscar.Visible = True
        grBuscar.Enabled = True
        grPersonal.Visible = False
        '-- los txt
        txtNick.Enabled = False
        txtNick.BackColor = Color.SkyBlue
        '-- los combos
        cboGrupo.Enabled = False
        '-- los chk
        chkActivo.Enabled = False
        chkAdministrador.Enabled = False
        chkAnularCompra.Enabled = False
        chkAnularNotaCredito.Enabled = False
        chkAnularVenta.Enabled = False
        chkEmpresaContable.Enabled = False
        chkSoloTarjeta.Enabled = False
        chkDesarrollador.Enabled = False
        chkAnularDepositoBanco.Enabled = False
        chkAnularPedidoSucursal.Enabled = False
        chkAnularRemision.Enabled = False
        chkAnularPedidoProveedor.Enabled = False
        chkAnularGasto.Enabled = False
        chkAnularPago.Enabled = False
        chkAnularNcrCanje.Enabled = False
        chkAnularCheque.Enabled = False
        chkAnularCobranza.Enabled = False
        chkAnularVentaSucursal.Enabled = False
        chkAnularDescuentoCliente.Enabled = False
        chkAnularRecepcion.Enabled = False
        chkAnularDevolucion.Enabled = False
        chkAnularOrdenCheque.Enabled = False
        chkAnularCanje.Enabled = False
        chkAnularRemisionPendiente.Enabled = False
        chkAnularActividadRepartidor.Enabled = False
        chkAnularGastoVenta.Enabled = False
        '-- los botones
        btnCancelar.Enabled = False
        btnGenerarCodigoBarra.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        btnImprimirCodigoBarra.Enabled = True
    End Sub

    Private Sub limpiarObjetos()
        '-- los txt
        txtIdUsuario.Text = 0
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtCodigoBarra.Text = ""
        txtNick.Text = ""
        '-- los chk
        chkActivo.Checked = False
        chkAdministrador.Checked = False
        chkAnularCompra.Checked = False
        chkAnularNotaCredito.Checked = False
        chkAnularVenta.Checked = False
        chkEmpresaContable.Checked = False
        chkSoloTarjeta.Checked = False
        chkDesarrollador.Checked = False
        chkAnularDepositoBanco.Checked = False
        chkAnularPedidoSucursal.Checked = False
        chkAnularRemision.Checked = False
        chkAnularPedidoProveedor.Checked = False
        chkAnularGasto.Checked = False
        chkAnularPago.Checked = False
        chkAnularNcrCanje.Checked = False
        chkAnularCheque.Checked = False
        chkAnularCobranza.Checked = False
        chkAnularVentaSucursal.Checked = False
        chkAnularDescuentoCliente.Checked = False
        chkAnularRecepcion.Checked = False
        chkAnularDevolucion.Checked = False
        chkAnularOrdenCheque.Checked = False
        chkAnularCanje.Checked = False
        chkAnularRemisionPendiente.Checked = False
        chkAnularActividadRepartidor.Checked = False
        chkAnularGastoVenta.Checked = False

    End Sub

    Private Sub guardarUsuario()
        '-- variables para los parametros
        Dim intTmpIdUsuario As Integer
        Dim intTmpIdPersonal As Integer
        Dim intTmpIdGrupoUsuario As Integer
        Dim strTmpNick As String
        Dim strTmpCodigoBarra As String
        Dim bolTmpActivo As Boolean
        Dim bolTmpAdministrador As Boolean
        Dim bolTmpAnularCompra As Boolean
        Dim bolTmpAnularVenta As Boolean
        Dim bolTmpAnularNotaCredito As Boolean
        Dim bolTmpHabilitarEmpresaContable As Boolean
        Dim bolTmpSoloTarjeta As Boolean
        Dim bolTmpDesarrollador As Boolean
        Dim bolTmpAnularDepositoBanco As Boolean
        Dim bolTmpAnularPedidoSucursal As Boolean
        Dim bolTmpAnularRemision As Boolean
        Dim bolTmpAnularPedidoProveedor As Boolean
        Dim bolTmpAnularGasto As Boolean
        Dim bolTmpAnularPago As Boolean
        Dim bolTmpAnularNcrCanje As Boolean
        Dim bolTmpAnularCheque As Boolean
        Dim bolTmpAnularCobranza As Boolean
        Dim bolTmpAnularVentaSucursal As Boolean
        Dim bolTmpAnularDescuentoCliente As Boolean
        Dim bolTmpAnularRecepcion As Boolean
        Dim bolTmpAnularDevolucion As Boolean
        Dim bolTmpAnularOrdenCheque As Boolean
        Dim bolTmpAnularCanje As Boolean
        Dim bolTmpAnularRemisionPendiente As Boolean
        Dim bolTmpAnularActividadRepartidor As Boolean
        Dim bolTmpAnularGastoVenta As Boolean

        '-- dar valor a las variables de parametro
        intTmpIdUsuario = CInt(txtIdUsuario.Text)
        intTmpIdGrupoUsuario = CInt(cboGrupo.SelectedValue)
        'MsgBox("Valor de idGrupo  " & intTmpIdGrupoUsuario)
        If txtNick.Text = "" Then
            strTmpNick = "''"
        Else
            strTmpNick = txtNick.Text
        End If
        If txtCodigoBarra.Text = "" Then
            strTmpCodigoBarra = "''"
        Else
            strTmpCodigoBarra = txtCodigoBarra.Text
        End If

        bolTmpActivo = chkActivo.Checked
        bolTmpAdministrador = chkAdministrador.Checked
        bolTmpAnularCompra = chkAnularCompra.Checked
        bolTmpAnularVenta = chkAnularVenta.Checked
        bolTmpAnularNotaCredito = chkAnularNotaCredito.Checked
        bolTmpHabilitarEmpresaContable = chkEmpresaContable.Checked
        bolTmpSoloTarjeta = chkSoloTarjeta.Checked
        bolTmpDesarrollador = chkDesarrollador.Checked
        bolTmpAnularDepositoBanco = chkAnularDepositoBanco.Checked
        bolTmpAnularPedidoSucursal = chkAnularPedidoSucursal.Checked
        bolTmpAnularRemision = chkAnularRemision.Checked
        bolTmpAnularPedidoProveedor = chkAnularPedidoSucursal.Checked
        bolTmpAnularGasto = chkAnularGasto.Checked
        bolTmpAnularPago = chkAnularPago.Checked
        bolTmpAnularNcrCanje = chkAnularNcrCanje.Checked
        bolTmpAnularCheque = chkAnularCheque.Checked
        bolTmpAnularCobranza = chkAnularCobranza.Checked
        bolTmpAnularVentaSucursal = chkAnularVentaSucursal.Checked
        bolTmpAnularDescuentoCliente = chkAnularDescuentoCliente.Checked
        bolTmpAnularRecepcion = chkAnularRecepcion.Checked
        bolTmpAnularDevolucion = chkAnularDevolucion.Checked
        bolTmpAnularOrdenCheque = chkAnularOrdenCheque.Checked
        bolTmpAnularCanje = chkAnularCanje.Checked
        bolTmpAnularRemisionPendiente = chkAnularRemisionPendiente.Checked
        bolTmpAnularActividadRepartidor = chkAnularActividadRepartidor.Checked
        bolTmpAnularGastoVenta = chkAnularGastoVenta.Checked

        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            '-- controlar que se ingresó un personal
            If Len(txtNombre.Text) = 0 Then
                MessageBox.Show("Debe Ingresar el Personal para colocarlo como Nuevo Usuario..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            intTmpIdPersonal = CInt(txtIdPersonal.Text)
            If (fun_guardarSp("sp_insUsuario", intTmpIdPersonal & "," & intTmpIdGrupoUsuario & "," & "'" & strTmpNick & "'" & "," & strTmpCodigoBarra & "," & bolTmpDesarrollador & "," & bolTmpAdministrador & "," & bolTmpAnularCompra & "," & bolTmpAnularVenta & "," & bolTmpAnularNotaCredito & "," & bolTmpAnularDepositoBanco & "," & bolTmpAnularPedidoSucursal & "," & bolTmpAnularRemision & "," & bolTmpAnularPedidoProveedor & "," & bolTmpAnularGasto & "," & bolTmpAnularPago & "," & bolTmpAnularNcrCanje & "," & bolTmpAnularCheque & "," & bolTmpAnularCobranza & "," & bolTmpAnularVentaSucursal & "," & bolTmpAnularDescuentoCliente & "," & bolTmpAnularRecepcion & "," & bolTmpAnularDevolucion & "," & bolTmpAnularOrdenCheque & "," & bolTmpAnularCanje & "," & bolTmpAnularRemisionPendiente & "," & bolTmpAnularActividadRepartidor & "," & bolTmpAnularGastoVenta & "," & bolTmpHabilitarEmpresaContable & "," & bolTmpSoloTarjeta & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
            intTmpIdPersonal = sp_datosTabla.un_dato_integer("idPersonal", "usuario", "idUsuario", intTmpIdUsuario)
            '-- si es una actualizacion
            '(fun_guardarSp("sp_updUsuario", intTmpIdUsuario & "," & intTmpIdPersonal & "," & intTmpIdGrupoUsuario & "," & "'" & strTmpNick & "'" & "," & "'" & strTmpCodigoBarra & "'" & "," & bolTmpDesarrollador & "," & bolTmpActivo & "," & bolTmpAdministrador & "," & bolTmpAnularCompra & "," & bolTmpAnularVenta & "," & bolTmpAnularNotaCredito & "," & bolTmpHabilitarEmpresaContable & "," & bolTmpSoloTarjeta & "," & intGl_idUsuario, Me.Name)) = 0 Then
            If (fun_guardarSp("sp_updUsuario", intTmpIdUsuario & "," & intTmpIdPersonal & "," & intTmpIdGrupoUsuario & "," & "'" & strTmpNick & "','" & _
                              strTmpCodigoBarra & "'," & bolTmpDesarrollador & "," & bolTmpActivo & "," & bolTmpAdministrador & "," & _
                              bolTmpAnularCompra & "," & bolTmpAnularVenta & "," & bolTmpAnularNotaCredito & "," & bolTmpAnularDepositoBanco & "," & _
                              bolTmpAnularPedidoSucursal & "," & bolTmpAnularRemision & "," & bolTmpAnularPedidoProveedor & "," & _
                              bolTmpAnularGasto & "," & bolTmpAnularPago & "," & bolTmpAnularNcrCanje & "," & bolTmpAnularCheque & "," & _
                              bolTmpAnularCobranza & "," & bolTmpAnularVentaSucursal & "," & bolTmpAnularDescuentoCliente & "," & _
                              bolTmpAnularRecepcion & "," & bolTmpAnularDevolucion & "," & bolTmpAnularOrdenCheque & "," & _
                              bolTmpAnularCanje & "," & bolTmpAnularRemisionPendiente & "," & bolTmpAnularActividadRepartidor & "," & _
                              bolTmpAnularGastoVenta & "," & bolTmpHabilitarEmpresaContable & "," & bolTmpSoloTarjeta & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        End If
    End Sub

    Private Sub resstablecerContra()
        Dim strRucUsuario As String
        strRucUsuario = sp_datosTabla.consulta_valorString("select ruc from v_usuario _vu inner join persona p on _vu.idPersona=p.idPersona where _vu.idUsuario=" & txtIdUsuario.Text)

        If (fun_guardarSp("sp_updRestaurarClaveUsuario", "'" & strRucUsuario & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            deshabilitarObjetos()
        End If
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
                    listar(" Where _vu.idUsuario Like '" & txtBuscar.Text & "%' Or _vu.idUsuario Like '" & txtBuscar.Text & "%' " & "order by _vu.idUsuario")
                Else
                    '-- buscar por nick
                    listar(" Where _vu.nick Like '" & txtBuscar.Text & "%' Or _vu.nick Like '" & txtBuscar.Text & "%' " & "order by _vu.nick")
                End If
            End If
            lvUsuario.Focus()
        End If
    End Sub

    Private Sub txtBuscarPersonal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarPersonal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- si solo se presiono enter
            If Len(txtBuscarPersonal.Text) = 0 Then
                '-- listar todo
                listarPersonal("")
            Else
                If IsNumeric(txtBuscarPersonal.Text) Then
                    '-- buscar por IdUsuario
                    listar(" and _vp.idPersonal Like '" & txtBuscarPersonal.Text & "%' Or _vp.idPersonal Like '" & txtBuscarPersonal.Text & "%' " & "order by _vp.idPersonal")
                Else
                    '-- buscar por nick
                    listar(" and _vp.nombre Like '" & txtBuscarPersonal.Text & "%' Or _vp.nombre Like '" & txtBuscarPersonal.Text & "%' " & "order by _vp.nombre")
                End If
            End If
            lvPersonal.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True

        listarPersonal("")

        habilitarObjetos()
        limpiarObjetos()
        grupoUsuario.listarGrupoUsuarioCbo(cboGrupo)
        chkActivo.Enabled = False
        chkActivo.Checked = True
        txtBuscarPersonal.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtIdUsuario.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        habilitarObjetos()
        grBuscar.Visible = True
        grBuscar.Enabled = False
        grPersonal.Visible = False
        txtNick.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        grBuscar.Enabled = True
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarUsuario()
    End Sub

    Private Sub btnGenerarCodigoBarra_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarCodigoBarra.Click
        If MessageBox.Show("Desea Volver a Generar el Codigo de Barras para este Usuario..!", strGl_nombreSistema, MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '-- variable de persona
            Dim intTmpIdPersona As Integer
            If bolTmpNuevo = False Then
                intTmpIdPersona = sp_datosTabla.un_dato_integer("idPersona", "v_usuarioT", "idUsuario", CInt(txtIdUsuario.Text))

            Else
                intTmpIdPersona = sp_datosTabla.un_dato_integer("idPersona", "v_personal", "idPersonal", CInt(txtIdPersonal.Text))
                '-- para un usuario nuevo
            End If
            'MsgBox("Valor de idPersona  " & intTmpIdPersona)
            txtCodigoBarra.Text = sp_datosTabla.sp_traerValor("sp_generarCodigoBarraUsuario", intTmpIdPersona, 0)
        End If
    End Sub

    Private Sub btnImprimirCodigoBarra_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirCodigoBarra.Click
        '-- solo si es seleccionado un usuario
        If Len(txtNombre.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Dim pvParametros As New ParameterValues()
        Dim rpt As New rpt_codigoBarraUsuario()
        Dim ofrm As New crv()
        '-- instaciar el parametro
        Dim v_idUsuario As New ParameterDiscreteValue()
        'asiganar el valor a los  parametros
        v_idUsuario.Value = CInt(txtIdUsuario.Text)
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idUsuario)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvParametros)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub

    Private Sub btnEstablecerPass_Click(sender As System.Object, e As System.EventArgs) Handles btnEstablecerPass.Click
        If MessageBox.Show("Desea volver a generar la contraseña del usuario..?", strGl_nombreSistema, MessageBoxButtons.YesNo) = DialogResult.Yes Then
            resstablecerContra()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------
    '******************'
    '-- EL LISTVIEW --'
    '******************'
    Private Sub lvUsuario_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvUsuario.SelectedIndexChanged
        Dim intTmpIdUsuario As Integer
        For Each item As ListViewItem In lvUsuario.SelectedItems
            '-- colocar en una variable el idUsuario
            intTmpIdUsuario = CInt(item.SubItems(0).Text)
            txtIdUsuario.Text = intTmpIdUsuario
            txtNick.Text = item.SubItems(1).Text
            txtNombre.Text = item.SubItems(2).Text
            txtApellido.Text = item.SubItems(3).Text
            txtCodigoBarra.Text = sp_datosTabla.un_datoString("codigoBarra", "v_usuarioT", "idUsuario", intTmpIdUsuario)
            '-- el grupo de usuario
            grupoUsuario.listarGrupoUsuarioCbo(cboGrupo)
            cboGrupo.SelectedValue = sp_datosTabla.un_datoString("idGrupoUsuario", "v_usuarioT", "idUsuario", intTmpIdUsuario)
            '-- los chk
            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "usuario", "idUsuario", intTmpIdUsuario)
            chkAdministrador.Checked = sp_datosTabla.un_dato_boleano("administrador", "usuario", "idUsuario", intTmpIdUsuario)
            chkAnularCompra.Checked = sp_datosTabla.un_dato_boleano("anularCompra", "usuario", "idUsuario", intTmpIdUsuario)
            chkAnularNotaCredito.Checked = sp_datosTabla.un_dato_boleano("anularNotaCredito", "usuario", "idUsuario", intTmpIdUsuario)
            chkAnularVenta.Checked = sp_datosTabla.un_dato_boleano("anularVenta", "usuario", "idUsuario", intTmpIdUsuario)
            chkAnularDepositoBanco.Checked = sp_datosTabla.consulta_valorBoolean("select anularDepositoBanco from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularPedidoSucursal.Checked = sp_datosTabla.consulta_valorBoolean("select anularPedidoSucursal from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularPedidoProveedor.Checked = sp_datosTabla.consulta_valorBoolean("select anularPedidoProveedor from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularRemision.Checked = sp_datosTabla.consulta_valorBoolean("select anularRemision from usuario where idUsuario=" & intTmpIdUsuario)
            chkEmpresaContable.Checked = sp_datosTabla.un_dato_boleano("habilitarEmpresaContable", "usuario", "idUsuario", intTmpIdUsuario)
            chkSoloTarjeta.Checked = sp_datosTabla.un_dato_boleano("soloCodigoBarra", "usuario", "idUsuario", intTmpIdUsuario)
            chkAnularGasto.Checked = sp_datosTabla.consulta_valorBoolean("select anularGastoProveedor from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularPago.Checked = sp_datosTabla.consulta_valorBoolean("select anularPagoProveedor from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularNcrCanje.Checked = sp_datosTabla.consulta_valorBoolean("select anularNcrCanje from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularCheque.Checked = sp_datosTabla.consulta_valorBoolean("select anularCheque from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularCobranza.Checked = sp_datosTabla.consulta_valorBoolean("select anularCobranza from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularVentaSucursal.Checked = sp_datosTabla.consulta_valorBoolean("select anularVentaSucursal from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularDescuentoCliente.Checked = sp_datosTabla.consulta_valorBoolean("select anularDescuentoCliente from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularDevolucion.Checked = sp_datosTabla.consulta_valorBoolean("select anularDevolucion from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularOrdenCheque.Checked = sp_datosTabla.consulta_valorBoolean("select anularOrdenCheque from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularCanje.Checked = sp_datosTabla.consulta_valorBoolean("select anularCanje from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularRemisionPendiente.Checked = sp_datosTabla.consulta_valorBoolean("select anularRemisionPendiente from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularActividadRepartidor.Checked = sp_datosTabla.consulta_valorBoolean("select anularActividadRepartidor from usuario where idUsuario=" & intTmpIdUsuario)
            chkAnularGastoVenta.Checked = sp_datosTabla.consulta_valorBoolean("select anularGastoVenta from usuario where idUsuario=" & intTmpIdUsuario)

            '-- desarrollador
            chkDesarrollador.Checked = sp_datosTabla.consulta_valorBoolean("select desarrollador from usuario where idUsuario=" & intTmpIdUsuario)
            '-- datos de la auditoria del usuario
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioAlta", "usuario", "idUsuario", intTmpIdUsuario)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioMod", "usuario", "idUsuario", intTmpIdUsuario)))
            txtFechaAlta.Text = sp_datosTabla.un_datoString("fechaAlta", "usuario", "idUsuario", intTmpIdUsuario)
            txtFechaMod.Text = sp_datosTabla.un_datoString("fechaMod", "usuario", "idUsuario", intTmpIdUsuario)
        Next
    End Sub

    Private Sub lvUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvPersonal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvPersonal.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscarPersonal.Focus()
        End If
    End Sub

    Private Sub lvPersonal_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvPersonal.SelectedIndexChanged
        Dim intTmpPersonal As Integer
        For Each item As ListViewItem In lvPersonal.SelectedItems
            intTmpPersonal = CInt(item.SubItems(0).Text)
            txtIdPersonal.Text = intTmpPersonal
            txtNombre.Text = item.SubItems(1).Text
            txtApellido.Text = item.SubItems(2).Text
        Next
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.configuracionAbmUsuario.Enabled = True
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------------------------------------

End Class