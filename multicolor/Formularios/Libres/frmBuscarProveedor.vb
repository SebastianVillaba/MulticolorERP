Public Class frmBuscarProveedor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdProveedor As Integer

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
        ' If rdIdCargo.Checked = True Then
        ' MsgBox("PAso por aca", MsgBoxStyle.Information)
        'cargo.ListarCargo(lvCargo, txtBuscar.Text, 1)
        'End If
        'If rdNombreCargo.Checked = True Then
        ' cargo.ListarCargo(lvCargo, txtBuscar.Text, 2)
        ' End If
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLvProveedor(lvProveedor, "Select _vp.idProveedor,_vp.ruc,_vp.dv,_vp.nombre,_vp.apellido,_vp.nombreFantasia from v_proveedor _vp " & where)
        ' dimensionar las columnas
        lvProveedor.Columns(0).Width = 40
        lvProveedor.Columns(1).Width = 100
        lvProveedor.Columns(2).Width = 40
        lvProveedor.Columns(3).Width = 200
        lvProveedor.Columns(4).Width = 200
        lvProveedor.Columns(5).Width = 250
        lvProveedor.Columns(0).Text = "ID Prov."
        lvProveedor.Columns(1).Text = "RUC"
        lvProveedor.Columns(2).Text = "DV"
        lvProveedor.Columns(3).Text = "Nombre del Proveedor"
        lvProveedor.Columns(4).Text = "Apellido del Proveedor"
        lvProveedor.Columns(5).Text = "Nombre de Fantasia"
        lvProveedor.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_compra = True Then
            '-- compra de mercaderias
            compraMercaderia()
        End If
        If banGl_cargarCheque = True Then
            '-- cargar cheques
            cargarCheques()
        End If
        If banGl_pagoProveedor = True Then
            '-- pago a proveedor
            pagoProveedor()
        End If
        If banGl_gastoProveedor = True Then
            '-- gasto de proveedor
            gastoProveedor()
        End If
        If banGl_reporteChequePendiente = True Then
            '-- reporte de cheques pendientes
            reporteChequePendientes()
        End If
        If banGl_OrdenPagoCheque = True Then
            '-- orden pago de cheques
            ordenCheque()
        End If
        If banGl_reporteProveedor = True Then
            '-- reporte de saldo de proveedor
            reporteSaldoProveedor()
        End If
        If banGl_estadisticaProveedor = True Then
            '-- estadistica por proveedores
            estadisticaProveedores()
        End If
        If banGl_modificacionCheque = True Then
            '-- modificacion de cheques
            modificaCheque()
        End If
        If banGl_reporteCompraGasto = True Then
            '-- reporte de compra y gasto de proveedor
            compraGastoProveedor()
        End If
        If banGl_notacreditoMonto = True Then
            '-- nota de credito a proveedor por monto
            notaCreditoMontoProveedor()
        End If
    End Sub

    Private Sub compraMercaderia()
        '-- colocar los datos del proveedor
        frmCompras.txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", intGl_comIdProveedor)
        frmCompras.txtIDProveedor.Text = intGl_comIdProveedor
        '-- el timbrado
        If Len(Trim(frmCompras.txtTimbrado.Text)) = 0 Then
            frmCompras.txtTimbrado.Text = sp_datosTabla.consulta_valorString("select timbrado from v_proveedor where idProveedor=" & intGl_comIdProveedor)
        End If
        '-- el responsable
        frmCompras.txtResponsable.Text = sp_datosTabla.consulta_valorString("select responsable from v_proveedor where idProveedor=" & intGl_comIdProveedor)

        Me.Close()
        frmCompras.Enabled = True
        frmCompras.Show()
        frmCompras.BringToFront()
        frmCompras.txtTimbrado.Focus()
    End Sub

    Private Sub cargarCheques()
        '-- colocar los datos del proveedor
        frmCargarCheques.txtProveedor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_proveedor where idProveedor=" & intIdProveedor)
        frmCargarCheques.txtIdProveedor.Text = intIdProveedor
        frmCargarCheques.txtCheque.Text = 0
        frmCargarCheques.txtMonto.Text = 0
        frmCargarCheques.txtCotizacion.Text = 0

        Me.Close()
        frmCargarCheques.Enabled = True
        frmCargarCheques.Show()
        frmCargarCheques.BringToFront()
        frmCargarCheques.txtCheque.Focus()
    End Sub

    Private Sub pagoProveedor()
        '-- colocar los datos del proveedor
        frmPagoProveedor.txtProveedor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_proveedor where idProveedor=" & intIdProveedor)
        frmPagoProveedor.txtIdProveedor.Text = intIdProveedor

        Me.Close()
        frmPagoProveedor.Enabled = True
        frmPagoProveedor.Show()
        frmPagoProveedor.BringToFront()
        frmPagoProveedor.dtpDesde.Focus()
    End Sub

    Private Sub gastoProveedor()
        '-- colocar los datos del proveedor
        frmGastoProveedor.txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", CInt(txtIdProveedor.Text))
        frmGastoProveedor.txtIDProveedor.Text = CInt(txtIdProveedor.Text)

        Me.Close()
    End Sub

    Private Sub reporteChequePendientes()
        frmReporteChequePendientes.lblProveedor.Visible = True
        frmReporteChequePendientes.lblIdProveedor.Visible = True
        '-- colocar los datos del proveedor
        frmReporteChequePendientes.lblProveedor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_proveedor where idProveedor=" & intIdProveedor)
        frmReporteChequePendientes.lblIdProveedor.Text = CInt(txtIdProveedor.Text)

        Me.Close()
    End Sub

    Private Sub reporteSaldoProveedor()
        frmReporteSaldoProveedor.lblProveedor.Visible = True
        frmReporteSaldoProveedor.lblIdProveedor.Visible = True
        '-- colocar los datos del proveedor
        frmReporteSaldoProveedor.lblProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", CInt(txtIdProveedor.Text))
        frmReporteSaldoProveedor.lblIdProveedor.Text = CInt(txtIdProveedor.Text)

        Me.Close()
    End Sub

    '-- orden de cheques
    Private Sub ordenCheque()
        '-- avisar que ya está cargado el mismo proveedor
        If sp_datosTabla.consulta_valor("select idProveedor from detOrdenChequeTmp where idConfig=" & intGl_idConfigPc & " and idProveedor=" & CInt(txtIdProveedor.Text)) > 0 Then
            MessageBox.Show("Ya existe este proveedor en la Grilla de la Orden..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        frmCargarOrdenPagoCheque.lblIdProveedor.Text = txtIdProveedor.Text
        frmCargarOrdenPagoCheque.lblProveedor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_proveedor where idProveedor=" & intIdProveedor)

        Me.Close()
    End Sub

    '-- estadistica por proveedores
    Private Sub estadisticaProveedores()
        frmEstadisticaProveedor.lblIdLaboratorio.Text = 0
        frmEstadisticaProveedor.lblLaboratorio.Text = ""
        frmEstadisticaProveedor.lblIdProducto.Text = 0
        frmEstadisticaProveedor.lblCodigo.Text = 0
        frmEstadisticaProveedor.lblProducto.Text = ""

        frmEstadisticaProveedor.lblProveedor.Visible = True
        frmEstadisticaProveedor.lblIdProveedor.Visible = True
        '-- colocar los datos del proveedor
        frmEstadisticaProveedor.lblProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", CInt(txtIdProveedor.Text))
        frmEstadisticaProveedor.lblIdProveedor.Text = CInt(txtIdProveedor.Text)

        Me.Close()
    End Sub

    '-- modificacion de cheques
    Private Sub modificaCheque()
        frmModificarCheque.txtProveedor2.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", CInt(txtIdProveedor.Text))
        frmModificarCheque.txtIdProveedor2.Text = CInt(txtIdProveedor.Text)

        Me.Close()
    End Sub

    '-- reporte de compra y gasto del proveedor
    Private Sub compraGastoProveedor()
        frmReporteCompraGasto.lblIdProveedor.Text = CInt(txtIdProveedor.Text)
        frmReporteCompraGasto.lblNombreProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", CInt(txtIdProveedor.Text))

        Me.Close()
    End Sub

    '-- nota de credito a proveedor por monto
    Private Sub notaCreditoMontoProveedor()
        '-- colocar los datos del proveedor
        frmNotaCreditoMontoProveedor.txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", CInt(txtIdProveedor.Text))
        frmNotaCreditoMontoProveedor.txtIdProveedor.Text = CInt(txtIdProveedor.Text)

        '-- habilitar los botones
        frmNotaCreditoMontoProveedor.btnAgregar.Enabled = True
        frmNotaCreditoMontoProveedor.btnCancelar.Enabled = True
        frmNotaCreditoMontoProveedor.btnGuardar.Enabled = True
        frmNotaCreditoMontoProveedor.btnNuevo.Enabled = False
        frmNotaCreditoMontoProveedor.btnEliminar.Enabled = True

        Me.Close()
    End Sub
    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If rdId.Checked = True Then
                '-- buscar por ID
                listar(" Where _vp.idProveedor=" & txtBuscar.Text)
            End If

            If rdNombre.Checked = True Then
                '-- buscar por NOMBRE
                If IsNumeric(txtBuscar.Text) Then
                    listar(" Where _vp.ruc='" & txtBuscar.Text & "'")
                End If
                If Not IsNumeric(txtBuscar.Text) Then
                    ' ordenar por nombre del proveedor
                    listar(" Where _vp.nombre Like '" & txtBuscar.Text & "%' Or _vp.nombre Like '" & txtBuscar.Text & "%' " & " order by _vp.nombre")
                End If
            End If

            If rdFantasia.Checked = True Then
                '-- buscar por NOMBRE
                If IsNumeric(txtBuscar.Text) Then
                    listar(" Where _vp.ruc='" & txtBuscar.Text & "'")
                End If
                If Not IsNumeric(txtBuscar.Text) Then
                    ' ordenar por nombre del proveedor
                    listar(" Where _vp.nombreFantasia Like '" & txtBuscar.Text & "%' Or _vp.nombreFantasia Like '" & txtBuscar.Text & "%' " & " order by _vp.nombreFantasia")
                End If
            End If

            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdIdProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdId.Click
        txtBuscar.Focus()
    End Sub

    Private Sub rdFantasia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdFantasia.Click
        txtBuscar.Focus()
    End Sub

    Private Sub rdNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNombre.Click
        txtBuscar.Focus()
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If intIdProveedor = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProveedor.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvProveedor.SelectedItems
            intIdProveedor = item.SubItems(0).Text
            intGl_comIdProveedor = item.SubItems(0).Text
            txtIdProveedor.Text = item.SubItems(0).Text
            txtNombreProveedor.Text = item.SubItems(3).Text
        Next
    End Sub
    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarProveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_compra = True Then
            '-- compra de mercaderia
            banGl_compra = False

            frmCompras.Enabled = True
            frmCompras.Show()
            frmCompras.BringToFront()
            frmCompras.txtTimbrado.Focus()
        End If
        If banGl_cargarCheque = True Then
            '-- cargar cheques
            banGl_cargarCheque = False

            frmCargarCheques.Enabled = True
            frmCargarCheques.Show()
            frmCargarCheques.BringToFront()
            frmCargarCheques.txtCheque.Focus()
        End If
        If banGl_pagoProveedor = True Then
            '-- pago de proveedor
            banGl_pagoProveedor = False

            frmPagoProveedor.Enabled = True
            frmPagoProveedor.Show()
            frmPagoProveedor.BringToFront()
        End If
        If banGl_gastoProveedor = True Then
            '-- gasto del proveedor
            banGl_gastoProveedor = False

            frmGastoProveedor.Enabled = True
            frmGastoProveedor.Show()
            frmGastoProveedor.BringToFront()
            frmGastoProveedor.cboSucursal.Focus()
        End If
        If banGl_reporteChequePendiente = True Then
            '-- reporte de cheques pendientes
            banGl_reporteChequePendiente = False
            frmReporteChequePendientes.Enabled = True
            frmReporteChequePendientes.Show()
            frmReporteChequePendientes.BringToFront()
            frmReporteChequePendientes.dtpDesdeFecha.Focus()
        End If
        If banGl_OrdenPagoCheque = True Then
            '-- cargar orden de cheque
            banGl_OrdenPagoCheque = False
            frmCargarOrdenPagoCheque.Enabled = True
            frmCargarOrdenPagoCheque.Show()
            frmCargarOrdenPagoCheque.BringToFront()
            frmCargarOrdenPagoCheque.maskFecha.Focus()
        End If
        If banGl_reporteProveedor = True Then
            '-- cargar orden de cheque
            banGl_reporteProveedor = False
            frmReporteSaldoProveedor.Enabled = True
            frmReporteSaldoProveedor.Show()
            frmReporteSaldoProveedor.BringToFront()
            frmReporteSaldoProveedor.btnConsultar.Focus()
        End If
        If banGl_estadisticaProveedor = True Then
            '-- estadistica por proveedor
            banGl_estadisticaProveedor = False
            frmEstadisticaProveedor.Enabled = True
            frmEstadisticaProveedor.Show()
            frmEstadisticaProveedor.BringToFront()
            frmEstadisticaProveedor.btnConsultar.Focus()
        End If
        If banGl_modificacionCheque = True Then
            '-- modidicar cheques
            banGl_modificacionCheque = False
            frmModificarCheque.Enabled = True
            frmModificarCheque.Show()
            frmModificarCheque.BringToFront()
        End If
        If banGl_reporteCompraGasto = True Then
            '-- reporte de compra y gasto
            banGl_reporteCompraGasto = False
            frmReporteCompraGasto.Enabled = True
            frmReporteCompraGasto.Show()
            frmReporteCompraGasto.BringToFront()
        End If
        If banGl_notacreditoMonto = True Then
            '-- nota de credito a proveedor por monto
            banGl_notacreditoMonto = False
            frmNotaCreditoMontoProveedor.Enabled = True
            frmNotaCreditoMontoProveedor.Show()
            frmNotaCreditoMontoProveedor.BringToFront()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
End Class