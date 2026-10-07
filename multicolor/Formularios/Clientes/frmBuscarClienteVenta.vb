Public Class frmBuscarClienteVenta
    '******************************'
    '-- VARIABLES DE TIPO OBJETO --'
    '******************************'
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdPersona As Integer

    '*************************'
    '-- VARIABLES ESCALARES --'
    '*************************'
    Dim strTmpRucCliente As String
    Dim strTmpNombreCliente As String
    Dim strTmpApellidoCliente As String
    Dim intTmpIdGrupoCliente As Integer
    Dim strTmpGrupoCliente As String
    Dim strTmpTelefonoCliente As String

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        'inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub inicializar()
        listar("")
        'valorde del combo
    End Sub
    '*******************'
    '-- PROCEDIMIENTO --'
    '*******************'
    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv_Clientes(lvCliente, "Select idCliente,ruc,nombre,apellido,nombreGrupoCliente,acreditar from v_cliente " & where)
        txtSql.Text = "Select idCliente,ruc,nombre,apellido,nombreGrupoCliente,acreditar from v_cliente " & where
    End Sub

    '----------------------------
    '--- CONTROLAR LOS MODULOS --
    '----------------------------
    Private Sub controlarModulo()
        If banGl_ventaFarmacia1 = True Then
            '-- venta de farmacia1
            ventaFarmacia1(intIdPersona)
        End If
        If banGl_historicoCliente = True Then
            '-- historico de cliente
            historicoCliente(CInt(txtIdCliente.Text))
        End If
        If banGl_cobroClienteNuevo = True Then
            cobroClienteNuevo(CInt(txtIdCliente.Text))
        End If
        If banGl_reporteProductoCliente = True Then
            '-- reporte de cliente por producto
            reporteClienteProducto(CInt(txtIdCliente.Text))
        End If
        If banGl_estadisticaCliente = True Then
            '-- estadistica de clientes
            estadisicaCliente(CInt(txtIdCliente.Text))
        End If
        If banGl_reporteSaldoCliente = True Then
            '-- reporte de saldo de cliente
            reporteSaldoCliente(CInt(txtIdCliente.Text))
        End If
        If banGl_reporteClienteVenta = True Then
            '-- reporte de ventas de clientes
            reporteVentaCliente(CInt(txtIdCliente.Text))
        End If
    End Sub

    '-- venta de farmacia
    Private Sub ventaFarmacia1(ByVal v_idPersona As Integer)
        intGl_vtaIdCliente = CInt(txtIdCliente.Text)
        frmVentaFarmacia1.txtCliente.Text = Trim(strTmpNombreCliente) & "," & Trim(strTmpApellidoCliente)
        frmVentaFarmacia1.txtIdCliente.Text = intGl_vtaIdCliente
        frmVentaFarmacia1.txtGrupoCliente.Text = strTmpGrupoCliente
        frmVentaFarmacia1.txtTelefonoCliente.Text = sp_datosTabla.consulta_valorString("SELECT [maxifarmasa].[dbo].[funTelefonoPersona] (" & v_idPersona & ")")

        If Trim(sp_datosTabla.consulta_valorString("select dv from v_cliente where idCliente=" & intGl_vtaIdCliente)) = "" Then
            '-- si no tiene el digito verificador
            'MsgBox("Paso 1")
            frmVentaFarmacia1.txtRucCliente.Text = Trim(strTmpRucCliente.Replace(",", "")) & "-" & Trim(getDV(strTmpRucCliente.Replace(",", "")))
        Else
            'MsgBox("Paso 2")
            frmVentaFarmacia1.txtRucCliente.Text = Trim(strTmpRucCliente.Replace(",", ""))
        End If

        'frmVentaFarmacia1.txtRucCliente.Text = strTmpRucCliente.Replace(",", "") & "-" & getDV(strTmpRucCliente.Replace(",", ""))
        frmVentaFarmacia1.txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from persona where idPersona=" & v_idPersona)
        '-- actualizar el detalle de la venta temporal
        If (fun_guardarSp("sp_updDetVentaFarmaciaTmpDelivery", intGl_idEntidad & "," & intGl_idConfigPc & "," & intGl_vtaIdCliente & "," & CInt(frmVentaFarmacia1.lblIdTipoVenta.Text) & "," & CInt(frmVentaFarmacia1.txtIdTipoventa.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        '--------------------------------------------
        frmVentaFarmacia1.sumarTotales()

        Me.Close()
    End Sub

    '-- historico cliente
    Private Sub historicoCliente(ByVal v_idCliente As Integer)
        frmHistoricoCliente.txtIdCliente.Text = v_idCliente
        frmHistoricoCliente.txtCliente.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cliente where idCliente=" & v_idCliente)
        frmHistoricoCliente.txtCel1.Text = sp_datosTabla.consulta_valorString("select celular1 from persona where idPersona=" & intIdPersona)
        frmHistoricoCliente.txtCel2.Text = sp_datosTabla.consulta_valorString("select celular2 from persona where idPersona=" & intIdPersona)
        frmHistoricoCliente.txtEmail.Text = sp_datosTabla.consulta_valorString("select email1 from persona where idPersona=" & intIdPersona)
        frmHistoricoCliente.txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from persona where idPersona=" & intIdPersona)
        frmHistoricoCliente.txtGrupo.Text = sp_datosTabla.consulta_valorString("select nombreGrupoCliente from v_cliente where idCliente=" & v_idCliente)
        '-- el procedimiento
        'sp_datosTabla.sp_string("sp_insTmpCuentaCliente", intGl_idConfigPc & "," & v_idCliente)
        'MsgBox("Paso 1")
        'sp_datosTabla.sp_string("sp_insTmpCuentaCliente_2", intGl_idConfigPc & "," & v_idCliente)
        'MsgBox("Paso 2")
        '---------------------------------------------------------------------------------------
        Me.Enabled = False
        frmHistoricoCliente.listarCabeceraPago(v_idCliente)
        Me.Enabled = True
        Me.Close()
    End Sub

    '-- cobranzas de clientes
    Private Sub cobroCliente(ByVal v_idCliente As Integer)
        '-- limpiar primero todos los objetosrr
        frmCobroCliente.limpiarObjetos()
        '---------------------------------------------------------------------------------------
        frmCobroCliente.txtIdCliente.Text = v_idCliente
        frmCobroCliente.txtCliente.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cliente where idCliente=" & v_idCliente)
        frmCobroCliente.txtCel1.Text = sp_datosTabla.consulta_valorString("select celular1 from persona where idPersona=" & intIdPersona)
        frmCobroCliente.txtCel2.Text = sp_datosTabla.consulta_valorString("select celular2 from persona where idPersona=" & intIdPersona)
        frmCobroCliente.txtEmail.Text = sp_datosTabla.consulta_valorString("select email1 from persona where idPersona=" & intIdPersona)
        frmCobroCliente.txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from persona where idPersona=" & intIdPersona)
        frmCobroCliente.txtGrupo.Text = sp_datosTabla.consulta_valorString("select nombreGrupoCliente from v_cliente where idCliente=" & v_idCliente)
        '-- el procedimiento
        'MsgBox("Paso 1")
        sp_datosTabla.sp_string("sp_insTmpCuentaCliente_2", intGl_idConfigPc & "," & v_idCliente)
        'MsgBox("Paso 2")
        '---------------------------------------------------------------------------------------
        frmCobroCliente.listarPagoPorCuota(intGl_idConfigPc)
        Me.Close()
    End Sub

    '-- reporte de cliente por producto
    Private Sub reporteClienteProducto(ByVal v_idCliente As Integer)
        '-- datos del cliente
        frmReporteClienteProducto.lblIdMov.Text = v_idCliente
        frmReporteClienteProducto.lblNombre.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cliente where idCliente=" & v_idCliente)

        Me.Close()
    End Sub


    '-- estadistica de clientes
    Private Sub estadisicaCliente(ByVal v_idCliente As Integer)
        frmEstadisticaClientes.lblIdCliente.Visible = True
        frmEstadisticaClientes.lblCliente.Visible = True
        frmEstadisticaClientes.lblRuc.Visible = True

        frmEstadisticaClientes.lblIdCliente.Text = v_idCliente
        ' MsgBox("valor " & v_idCliente)
        frmEstadisticaClientes.lblCliente.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cliente where idCliente=" & v_idCliente)
        frmEstadisticaClientes.lblRuc.Text = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & v_idCliente)

        Me.Close()
    End Sub

    '-- reporte de saldo de cliente
    Private Sub reporteSaldoCliente(ByVal v_idCliente As Integer)
        frmReporteSaldoCliente.lblIdGrupo.Text = v_idCliente
        frmReporteSaldoCliente.lblNombreGrupo.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cliente where idCliente=" & v_idCliente)

        Me.Close()
    End Sub

    '-- reporte de ventas de clientes
    Private Sub reporteVentaCliente(ByVal v_idCliente As Integer)
        intGl_idClienteReporteVenta = v_idCliente

        Me.Close()
    End Sub

    '-- cobranzas de clientes - nuevo
    Private Sub cobroClienteNuevo(ByVal v_idCliente As Integer)
        '-- limpiar primero todos los objetos
        frmCobroClienteNuevo.limpiarObjetos()
        '---------------------------------------------------------------------------------------
        frmCobroClienteNuevo.txtIdCliente.Text = v_idCliente
        frmCobroClienteNuevo.txtCliente.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cliente where idCliente=" & v_idCliente)
        frmCobroClienteNuevo.txtCel1.Text = sp_datosTabla.consulta_valorString("select celular1 from persona where idPersona=" & intIdPersona)
        frmCobroClienteNuevo.txtCel2.Text = sp_datosTabla.consulta_valorString("select celular2 from persona where idPersona=" & intIdPersona)
        frmCobroClienteNuevo.txtEmail.Text = sp_datosTabla.consulta_valorString("select email1 from persona where idPersona=" & intIdPersona)
        frmCobroClienteNuevo.txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from persona where idPersona=" & intIdPersona)
        frmCobroClienteNuevo.txtGrupo.Text = sp_datosTabla.consulta_valorString("select nombreGrupoCliente from v_cliente where idCliente=" & v_idCliente)
        '-- el procedimiento
        sp_datosTabla.sp_string("sp_cargarTmpCobroCliente", intGl_idConfigPc & "," & v_idCliente)
        '---------------------------------------------------------------------------------------
        frmCobroClienteNuevo.listarDetallePago(" where idConfig=" & intGl_idConfigPc)
        frmCobroClienteNuevo.sumarTotales()
        Me.Close()
    End Sub
    '------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(txtBuscar.Text) > 0 Then
                '-- solo si se ingresó algun dato para la busqueda
                '-- por idCliente
                If rdIdCliente.Checked = True Then
                    listar(" Where idCliente=" & txtBuscar.Text & "order by idCliente")
                End If
                '-- por nombre 
                If rdNombre.Checked = True Then
                    If IsNumeric(txtBuscar.Text) Then
                        '-- buscar por ruc
                        listar(" Where soloruc Like '" & txtBuscar.Text & "%' Or soloruc Like '" & txtBuscar.Text & "%' " & "order by ruc")
                    Else
                        '-- buscar por el nombre
                        listar(" Where nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & "order by nombre")
                    End If
                End If
                '-- por codigo del producto
                If rdApellido.Checked = True Then
                    If IsNumeric(txtBuscar.Text) Then
                        '-- buscar por ruc
                        listar(" Where soloruc Like '" & txtBuscar.Text & "%' Or soloruc Like '" & txtBuscar.Text & "%' " & "order by ruc")
                    Else
                        '-- buscar por el nombre
                        listar(" Where apellido Like '" & txtBuscar.Text & "%' Or apellido Like '" & txtBuscar.Text & "%' " & "order by apellido")
                    End If
                End If
            Else
                '-- si es en blanco listar todos los clientes
                listar("")
            End If
            lvCliente.Focus()
        End If
        '-- para volver al formulario de venta
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
        '------------------------------------------------------------------------------------------------------
    End Sub
    '------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCliente.SelectedIndexChanged
        For Each item As ListViewItem In lvCliente.SelectedItems
            '-- colocar el idCliente al objeto de texto
            txtIdCliente.Text = item.SubItems(0).Text
            '-- dar valor a las variables
            strTmpRucCliente = item.SubItems(1).Text
            strTmpNombreCliente = item.SubItems(2).Text
            strTmpApellidoCliente = item.SubItems(3).Text
            intTmpIdGrupoCliente = sp_datosTabla.un_dato_integer("idGrupoCliente", "v_cliente", "idCliente", CInt(txtIdCliente.Text))
            strTmpGrupoCliente = item.SubItems(4).Text
            strTmpTelefonoCliente = sp_datosTabla.un_dato_integer("idGrupoCliente", "v_cliente", "idCliente", CInt(txtIdCliente.Text))
        Next
    End Sub

    Private Sub lvCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si hay un cliente consultado
            If Len(txtIdCliente.Text) > 0 Then
                intIdPersona = sp_datosTabla.un_dato_integer("idPersona", "v_cliente", "idCliente", CInt(txtIdCliente.Text))
                '-- controlar los modulos
                controlarModulo()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarClienteVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_ventaFarmacia1 = True Then
            banGl_ventaFarmacia1 = False
            '-- venta farmacia
            frmVentaFarmacia1.WindowState = FormWindowState.Normal
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
            frmVentaFarmacia1.txtBuscar.Focus()
        End If
        If banGl_historicoCliente = True Then
            banGl_historicoCliente = False
            '-- historico de cliente
            frmHistoricoCliente.Enabled = True
            frmHistoricoCliente.Show()
            frmHistoricoCliente.BringToFront()
            frmHistoricoCliente.lvCabPago.Focus()
        End If
        If banGl_cobroCliente = True Then
            banGl_cobroCliente = False
            '-- cobro a clientes
            frmCobroCliente.Enabled = True
            frmCobroCliente.Show()
            frmCobroCliente.BringToFront()
            frmCobroCliente.dtgPago.Focus()
        End If
        If banGl_reporteProductoCliente = True Then
            banGl_reporteProductoCliente = False
            '-- reporte de cliente por producto
            frmReporteClienteProducto.Enabled = True
            frmReporteClienteProducto.Show()
            frmReporteClienteProducto.BringToFront()
            frmReporteClienteProducto.btnConsultar.Focus()
        End If
        If banGl_estadisticaCliente = True Then
            banGl_estadisticaCliente = False
            '-- estadistica de clientes
            frmEstadisticaClientes.Enabled = True
            frmEstadisticaClientes.Show()
            frmEstadisticaClientes.BringToFront()
            frmEstadisticaClientes.btnConsultar.Focus()
        End If
     
        If banGl_facturacionResto = True Then
            '-- venta heladeria
            banGl_facturacionResto = False

            'frmRestoHotel.Enabled = True
            'frmRestoHotel.Show()
            'frmRestoHotel.BringToFront()
        End If
        If banGl_reporteSaldoCliente = True Then
            '-- reporte de saldo de cliente
            banGl_reporteSaldoCliente = False

            frmReporteSaldoCliente.Enabled = True
            frmReporteSaldoCliente.Show()
            frmReporteSaldoCliente.BringToFront()
        End If
        If banGl_reporteClienteVenta = True Then
            '-- reporte de ventas de clientes
            banGl_reporteClienteVenta = False

            frmReporteVenta.Enabled = True
            frmReporteVenta.Show()
            frmReporteVenta.BringToFront()
        End If
        If banGl_cobroClienteNuevo = True Then
            banGl_cobroClienteNuevo = False
            '-- cobro a clientes - nuevo
            frmCobroClienteNuevo.Enabled = True
            frmCobroClienteNuevo.Show()
            frmCobroClienteNuevo.BringToFront()
            frmCobroClienteNuevo.txtMonto.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------
End Class