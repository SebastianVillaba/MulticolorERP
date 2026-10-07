Public Class frmCompras
    Dim moneda As New moneda
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarCompra As New sp_cargarCompra
    Dim systemClass As New SystemClass

    Dim bolPedido As Boolean
    Dim bolError As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        '-- asignar al combo la moneda
        moneda.listarMonedaCombo(cboMoneda)
        '-- colocar en el combo la moneda pre determinada por el sistema
        cboMoneda.SelectedValue = sp_datosTabla.un_dato_integer("idMoneda", "moneda", "idmoneda", sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad))
        'listar_busqueda("")
        If sp_datosTabla.consulta_valor("select idConfig from detCompraTmp where idConfig=" & intGl_idConfigPc) > 0 Then
            '-- cargar toda la factura del ultimo
            listarCompra()
            txtPorcentajeCosto.Text = 0
            txtCantidad.Text = 1
            txtBoni.Text = 0
            txtGravada10.Text = 0
            txtGravada5.Text = 0
            txtExenta.Text = 0

            sumarTotal()
        Else
            '-- si no hay nada
            limpiarProducto()
            limpiar()
        End If

        'valorde del combo
    End Sub

    Public Sub limpiar()
        '-- inicializar los objetos
        txtNroPedido.Text = 0
        txtPedidopor.Text = ""
        txtProducto.Text = ""
        txtProveedor.Text = ""
        txtTipoProducto.Text = ""
        txtResponsable.Text = ""
        txtTotalFactura.Text = 0.0
        txtTotalIva.Text = 0.0
        maskVence.Text = ""
        txtLote.Text = ""
        txtLaboratorio.Text = ""
        txtIva5.Text = 0.0
        txtIVA10.Text = 0.0
        txtFraccion.Text = ""
        txtDsuc.Text = ""
        txtDcaja.Text = ""
        txtExenta.Text = 0
        txtGravada10.Text = 0
        txtGravada5.Text = 0
        txtCantidadPedido.Text = 0
        txtCantidad.Text = 0
        txtBoni.Text = 0
        lblNombreProducto.Text = ""
        lblCodigoProducto.Text = ""
        lblPrecio.Text = ""
        lblUltCosto.Text = ""
        lblCantidad.Text = ""
        lblNro.Text = 0
        lblIdProducto.Text = 0
        txtOrigen.Text = ""
        txtFactura.Text = ""
        txtIDProveedor.Text = 0
        txtPorcentajeCosto.Text = 0
        txtPorcentajeCosto.Enabled = False
        txtPorcentajeCosto.BackColor = Color.LightBlue
        txtTimbrado.Text = ""
        txtNota.Text = "N"
        '-- limpiar la grilla
        sp_datosTabla.consulta_valor("delete from detCompraTmp where idConfig=" & intGl_idConfigPc)
        listarCompra()

        intGl_nroCompra = 0
        '-- dar formato a los objetos
        txtExenta.Text = FormatNumber(txtExenta.Text, "00,000,000.00")
        txtIVA10.Text = FormatNumber(txtIVA10.Text, "00,000,000.00")
        txtIva5.Text = FormatNumber(txtIva5.Text, "00,000,000,00")
        txtNroPedido.Text = FormatNumber(txtNroPedido.Text, "000,000")
        txtTotalFactura.Text = FormatNumber(txtTotalFactura.Text, "00,000,000.00")
        txtTotalIva.Text = FormatNumber(txtTotalIva.Text, "00,000,000.00")
        txtCantidad.Text = FormatNumber(txtCantidad.Text, "00,000.00")
        txtCantidadPedido.Text = FormatNumber(txtCantidadPedido.Text, "00,000.00")
    End Sub

    Public Sub listarCompra()
        systemClass.SqlToLv_detalleCompraTmp(lvCompra, "sp_consultaDetalleCompraTmp", intGl_idConfigPc)
    End Sub

    Public Sub sumarTotal()
        '-- variables para los totales
        '-- asignar los totales
        txtTotalFactura.Text = sp_datosTabla.consulta_valorDouble("select sum(subtotal) from detCompraTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "#,###,##0.##")
        txtIVA10.Text = sp_datosTabla.consulta_valorDouble("select sum(iva10) from detCompraTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIVA10.Text = Format(CDec(txtIVA10.Text), "#,###,##0.##")
        txtIva5.Text = sp_datosTabla.consulta_valorDouble("select sum(iva5) from detCompraTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIva5.Text = Format(CDec(txtIva5.Text), "#,###,##0.##")
        txtTotalIva.Text = sp_datosTabla.consulta_valorDouble("select sum(iva10+iva5) from detCompraTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "#,###,##0.##")
    End Sub

    Private Sub controlarCargaProducto()
        Try
            '-- controlar los datos de la cabecera
            bolError = False
            controlarCabecera()

            If bolError = False Then
                '-- inicializar las variables
                Dim intTmpIdProducto As Integer
                Dim intTmpIdDeposito As Integer
                Dim intTmpIdForma As Integer
                Dim strTmpVence As String

                '-- dar valor a las variables
                intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & lblCodigoProducto.Text)
                'MsgBox("Valor del codigo del producto  " & lblCodigoProducto.Text)
                'MsgBox("Valor de idProducto  " & sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & lblCodigoProducto.Text))

                intTmpIdDeposito = sp_datosTabla.un_dato_integer("idDepositoCompra", "configEmpresa", "idEntidad", intGl_idEntidad)
                intTmpIdForma = sp_datosTabla.consulta_valor("select idForma from cabForma where nombreForma='" & txtFraccion.Text & "'")
                strTmpVence = maskVence.Text

                If (fun_guardarSp("sp_agregarDetCompraTmp", intGl_idConfigPc & "," & txtIDProveedor.Text & "," & intTmpIdProducto & "," & _
                    intTmpIdDeposito & "," & _
                    intTmpIdForma & "," & "'" & txtLote.Text & "'" & "," & "'" & strTmpVence & "'" & "," & _
                    sacarComa(txtCantidad.Text) & "," & lblCantidad.Text & "," & sacarComa(txtBoni.Text) & "," & _
                    sacarComa(txtExenta.Text) & "," & sacarComa(txtGravada5.Text) & "," & sacarComa(txtGravada10.Text) & "," & _
                    sacarComa(txtCotizacion.Text) & "," & txtPorcentajeCosto.Text & "," & "'" & txtNota.Text & "'" & "," & _
                    CDbl(sacarComa(lblPrecio.Text)), Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar el Registro en el detalle de la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '----------------------------------------
                    '-- se guardo los registros
                    '-----------------------------------------'
                    '-- procedimiento para cargar la grilla --'
                    '-----------------------------------------'
                    listarCompra()

                    limpiarProducto()
                    txtProducto.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub limpiarProducto()
        txtProducto.Text = ""
        txtCantidad.Text = 0
        txtBoni.Text = 0
        txtExenta.Text = 0
        txtGravada10.Text = 0
        txtGravada5.Text = 0
        txtFraccion.Text = ""
        txtLote.Text = ""
        maskVence.Text = ""
        lblCantidad.Text = ""
        lblCodigoProducto.Text = ""
        lblNombreProducto.Text = ""
        lblPrecio.Text = ""
        lblUltCosto.Text = ""
        txtCantidadPedido.Text = 0
        txtLaboratorio.Text = ""
        txtPedidopor.Text = ""
        txtFechaPedido.Text = ""
        txtNroPedido.Text = 0
        txtTipoProducto.Text = ""
        txtOrigen.Text = ""
        PictureBox1.ImageLocation = ""
        txtNota.Text = "N"
        '-- la parte del pedido
        PictureBox2.Visible = False
        lblControlPedido.Visible = False
        txtPedidopor.Text = ""
        txtCantidadPedido.Text = 0
        txtNroPedido.Text = 0
        txtFechaPedido.Text = ""
        '--------------------------------------------
    End Sub

    Private Sub buscarCodigoProducto(ByVal v_codigoProducto As Integer)
        '-- procedimiento para buscar por el codigo del producto
        Dim strNombreProducto As String = ""
        Dim intTmpIdProducto As Integer

        strNombreProducto = sp_datosTabla.un_datoString("nombreProducto", "v_producto", "codigo", v_codigoProducto)
        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where codigo='" & v_codigoProducto & "'")
        '-- verificar si existe el producto
        If strNombreProducto = "" Then
            MessageBox.Show("No existe el codigo ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblCodigoProducto.Text = ""
            lblNombreProducto.Text = ""
            txtLaboratorio.Text = ""
            lblPrecio.Text = ""
            lblUltCosto.Text = ""
            txtFraccion.Text = ""
            lblCantidad.Text = ""
            Exit Sub
        Else
            Dim intTmpIdTipoProducto As Integer
            '-- valor del producto
            lblCodigoProducto.Text = sp_datosTabla.un_dato_integer("codigo", "v_producto", "codigo", v_codigoProducto)
            lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "codigo", v_codigoProducto)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "codigo", v_codigoProducto))
            txtLaboratorio.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "codigo", v_codigoProducto)))
            txtTipoProducto.Text = Trim(sp_datosTabla.un_datoString("nombreTipo", "v_tipoproducto", "idTipoProducto", sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "codigo", lblCodigoProducto.Text)))
            txtOrigen.Text = Trim(sp_datosTabla.un_datoString("origen", "v_producto", "codigo", v_codigoProducto))
            lblUltCosto.Text = sp_datosTabla.sp_integer("sp_ultimoCostoProducto", sp_datosTabla.un_dato_integer("idProducto", "v_producto", "codigo", v_codigoProducto))
            lblUltCosto.Text = FormatNumber(lblUltCosto.Text, "00,000,000.00")
            '-- si el tipo de producto puede colocarse el porcentaje sobre costo
            intTmpIdTipoProducto = sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "codigo", v_codigoProducto)
            If sp_datosTabla.consulta_valorBoolean("select porcentajeCompra from v_tipoProducto where idTipoProducto=" & intTmpIdTipoProducto) = True Then
                txtPorcentajeCosto.Enabled = True
                txtPorcentajeCosto.Text = 0
                txtPorcentajeCosto.BackColor = Color.White
            Else
                txtPorcentajeCosto.Enabled = False
                txtPorcentajeCosto.Text = 0
                txtPorcentajeCosto.BackColor = Color.LightBlue
            End If
            '-- la imagen de la mercaderia
            PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "codigo", v_codigoProducto)
            '-- ver si es un producto fraccionado
            If (sp_datosTabla.un_dato_boleano("fraccionado", "v_producto", "codigo", v_codigoProducto)) = True Then
                banGl_compra = blanquearBanderas("banGl_compra")
                '-- si es un producto fraccionado
                '-- activar la varibale global del fraccionado
                bolGl_vtaFraccionado = False
                bolGl_comFraccionado = True

                Me.Enabled = False

                frmFraccionado.listar_busqueda(sp_datosTabla.un_dato_integer("idProducto", "v_producto", "codigo", v_codigoProducto))

                frmFraccionado.Visible = True
                frmFraccionado.WindowState = FormWindowState.Normal
                frmFraccionado.Show()
                frmFraccionado.BringToFront()
            Else
                '*******************************************************************************************
                '-- verificar el pedido
                productoPedidoAProveedor(intTmpIdProducto, CInt(txtIDProveedor.Text))
                '*******************************************************************************************
                '--
                '-- si es un producto entero
                lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "codigo", v_codigoProducto)
                lblPrecio.Text = FormatNumber(lblPrecio.Text, "00,000,000.00")
                txtFraccion.Text = "ENTERO"
                lblCantidad.Text = 1
                If txtPorcentajeCosto.Enabled = False Then
                    txtCantidad.Focus()
                Else
                    txtPorcentajeCosto.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub buscarCodigoBarraProducto(ByVal v_codigoBarra As String)
        Try
            '-- procedimiento para buscar por el codigo del producto
            Dim strNombreProducto As String = ""
            strNombreProducto = sp_datosTabla.un_datoString("nombreProducto", "v_producto", "codigoBarra", v_codigoBarra)
            '-- verificar si existe el producto
            If strNombreProducto = "" Then
                MessageBox.Show("No existe el codigo ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblCodigoProducto.Text = ""
                lblNombreProducto.Text = ""
                txtLaboratorio.Text = ""
                lblPrecio.Text = ""
                lblUltCosto.Text = ""
                txtFraccion.Text = ""
                lblCantidad.Text = ""
                Exit Sub
            Else
                Dim intTmpIdTipoProducto As Integer
                '-- traer el id del Producto
                Dim intTmpIdProducto As Integer = 0
                intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where codigoBarra=" & "'" & v_codigoBarra & "'")
                '-- valor del producto
                lblCodigoProducto.Text = sp_datosTabla.un_dato_integer("codigo", "v_producto", "idProducto", intTmpIdProducto)
                lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "codigoBarra", v_codigoBarra)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "codigoBarra", v_codigoBarra))
                txtLaboratorio.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", intTmpIdProducto)))
                txtTipoProducto.Text = Trim(sp_datosTabla.un_datoString("nombreTipo", "v_tipoproducto", "idTipoProducto", sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "codigo", lblCodigoProducto.Text)))
                txtOrigen.Text = Trim(sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", intTmpIdProducto))
                lblUltCosto.Text = sp_datosTabla.sp_double("sp_ultimoCostoProducto", intTmpIdProducto)
                lblUltCosto.Text = FormatNumber(lblUltCosto.Text, "00,000,000.00")
                'MsgBox("Valor del Ultimo Costo  " & sp_datosTabla.sp_double("sp_ultimoCostoProducto", intTmpIdProducto))
                '-- si el tipo de producto puede colocarse el porcentaje sobre costo
                'MsgBox("Valor de idProducto  " & sp_datosTabla.consulta_valor("select idTipoProducto from v_producto where codigoBarra=" & "'" & v_codigoBarra & "'"))
                intTmpIdTipoProducto = sp_datosTabla.consulta_valor("select idTipoProducto from v_producto where codigoBarra=" & "'" & v_codigoBarra & "'")
                If sp_datosTabla.consulta_valorBoolean("select porcentajeCompra from v_tipoProducto where idTipoProducto=" & intTmpIdTipoProducto) = True Then
                    txtPorcentajeCosto.Enabled = True
                    txtPorcentajeCosto.Text = 0
                    txtPorcentajeCosto.BackColor = Color.White
                Else
                    txtPorcentajeCosto.Enabled = False
                    txtPorcentajeCosto.Text = 0
                    txtPorcentajeCosto.BackColor = Color.LightBlue
                End If
                'MsgBox("Valor de intTmpIdProducto  " & intTmpIdProducto)
                '-- la imagen de la mercaderia
                PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
                '-- ver si es un producto fraccionado
                If (sp_datosTabla.un_dato_boleano("fraccionado", "v_producto", "idProducto", intTmpIdProducto)) = True Then
                    '-- si es un producto fraccionad
                    '-- activar la varibale global del fraccionado
                    Me.Enabled = False
                    banGl_compra = True

                    frmFraccionado.listar_busqueda(intTmpIdProducto)
                    frmFraccionado.txtIdProducto.Text = intTmpIdProducto
                    frmFraccionado.Visible = True
                    frmFraccionado.WindowState = FormWindowState.Normal
                    frmFraccionado.Show()
                    frmFraccionado.BringToFront()
                Else
                    '*******************************************************************************************
                    '-- verificar el pedido
                    productoPedidoAProveedor(intTmpIdProducto, CInt(txtIDProveedor.Text))
                    '*******************************************************************************************
                    'MsgBox("Paso aca")
                    '-- si es un producto entero
                    lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", intTmpIdProducto)
                    lblPrecio.Text = FormatNumber(lblPrecio.Text, "00,000,000.00")
                    txtFraccion.Text = "ENTERO"
                    lblCantidad.Text = 1

                    If txtPorcentajeCosto.Enabled = False Then
                        txtCantidad.Focus()
                    Else
                        txtPorcentajeCosto.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub controlarCabecera()
        '-- solo los numericos y de tres lugares
        If Not IsNumeric(txtDsuc.Text) Then
            MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDsuc.Focus()
            bolError = True
            Exit Sub
        End If
        If txtDsuc.Text.Length <> 3 Then
            MessageBox.Show("Debe introducir solo tres dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDsuc.Focus()
            bolError = True
            Exit Sub
        End If
        '-- solo los numericos y de tres lugares
        If Not IsNumeric(txtDcaja.Text) Then
            MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDcaja.Focus()
            bolError = True
            Exit Sub
        End If
        If txtDcaja.Text.Length <> 3 Then
            MessageBox.Show("Debe introducir solo tres dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtDcaja.Focus()
        End If
        '-- solo los numericos y de siete lugares
        If Not IsNumeric(txtFactura.Text) Then
            MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFactura.Focus()
            bolError = True
            Exit Sub
        End If
        If txtFactura.Text.Length <> 7 Then
            MessageBox.Show("Debe introducir solo siete dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFactura.Focus()
            bolError = True
            Exit Sub
        End If
        '-- solo que sea numerico el timbrado
        If Not IsNumeric(txtTimbrado.Text) Then
            MessageBox.Show("Debe introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTimbrado.Focus()
            bolError = True
            Exit Sub
        End If
        If txtResponsable.Text = "" Then
            MessageBox.Show("Debe introducir el Responsable..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtResponsable.Focus()
            bolError = True
            Exit Sub
        End If

        '--------------------------------------------------------------------------
        '-- que se ingrese la factura
        If txtDsuc.Text = "" Then
            MessageBox.Show("Debe Introducir el primer digito de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If
        If txtDcaja.Text = "" Then
            MessageBox.Show("Debe introducir el segundo digito de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If
        If txtFactura.Text = "" Then
            MessageBox.Show("Debe introducir el nro de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If

        '-- el proveedor
        If txtProveedor.Text = "" Then
            MessageBox.Show("Debe introducir el Proveedor..!", strGl_nombreSucursal, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If

        '-- el producto
        If Len(lblCodigoProducto.Text) = 0 Then
            MessageBox.Show("Debe introducir una Mercadería..!", strGl_nombreSucursal, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If

    End Sub

    '-- controlar la compra antes de guardar
    Private Sub controlarCompra()
        Try
            If (fun_guardarSp("sp_updDetCompraTmp", intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Actualizar los Lotes en el detalle de la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                guardarCompra()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- guardar las compras
    Private Sub guardarCompra()
        If MessageBox.Show("Desea Guardar la Compra..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '-- verificar la moneda para colocar la cotizacion
            'MsgBox("Valor de  la moneda  " & cboMoneda.SelectedValue.ToString)
            '-- nombre de la moneda elegida
            frmGuardarCompra.txtMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", cboMoneda.SelectedValue)
            frmGuardarCompra.txtCotizacion.Text = txtCotizacion.Text
            '-- procesimiento para guardar la compra
            Me.Enabled = False
            '--- colocar los datos

            frmGuardarCompra.txtDcaja.Text = txtDcaja.Text
            frmGuardarCompra.txtDsuc.Text = txtDsuc.Text
            frmGuardarCompra.txtFactura.Text = txtFactura.Text
            frmGuardarCompra.txtProveedor.Text = txtProveedor.Text
            frmGuardarCompra.txtTimbrado.Text = txtTimbrado.Text
            frmGuardarCompra.maskFecha.Text = ""
            frmGuardarCompra.maskVence.Text = ""
            frmGuardarCompra.chkCompra.Checked = False
            'MsgBox("Valor del idProveedor  " & txtIDProveedor.Text)

            frmGuardarCompra.Visible = True
            frmGuardarCompra.WindowState = FormWindowState.Normal
            frmGuardarCompra.Show()
            frmGuardarCompra.maskFecha.Focus()
        End If

    End Sub
    '----------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtDsuc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtResponsable.Focus()
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtTimbrado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        e.Handled = txtNumerico(txtTimbrado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDsuc.Focus()
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtResponsable_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtResponsable.KeyPress
        'e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtCotizacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCotizacion.KeyPress
        e.Handled = txtNumerico(txtCotizacion, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtExenta.Text) = 0 Then
                txtCotizacion.Text = 0
            End If
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtCotizacion.Text = Format(CDec(txtCotizacion.Text), "###,###.00")
            txtProducto.Focus()
        End If
    End Sub

    Private Sub txtExenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtExenta.KeyPress
        e.Handled = txtNumerico(txtExenta, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtExenta.Text) = 0 Then
                txtExenta.Text = 0
            End If
            '------------------------------------
            e.Handled = True
            txtGravada5.Focus()
            txtExenta.Text = Format(CDec(txtExenta.Text), "###,###,##0.##")
        End If
    End Sub

    Private Sub txtGravada5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGravada5.KeyPress
        e.Handled = txtNumerico(txtGravada5, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtGravada5.Text) = 0 Then
                txtGravada5.Text = 0
            End If
            e.Handled = True
            txtGravada10.Focus()
            txtGravada5.Text = Format(CDec(txtGravada5.Text), "###,###,##0.##")
        End If
    End Sub

    Private Sub txtGravada10_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGravada10.KeyPress
        e.Handled = txtNumerico(txtGravada10, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtGravada10.Text) = 0 Then
                txtGravada10.Text = 0
            End If
            '-- cambiar el precio de la mercaderia solo si tiene porcentaje sobre costo
            If CDbl(txtPorcentajeCosto.Text) > 0 Then
                Dim douTmpPrecio As Double
                Dim douTmpCosto As Double
                Dim douTmpCotizacion As Double
                Dim douTmpPorcentaje As Double
                Dim douTmpCantidad As Double
                Dim intTmpBoni As Integer
                '-- calculos
                '- dar valor
                douTmpPrecio = lblPrecio.Text
                douTmpCosto = CDbl(txtGravada10.Text) + CDbl(txtGravada5.Text) + CDbl(txtExenta.Text)
                douTmpCotizacion = CDbl(txtCotizacion.Text)
                douTmpPorcentaje = CDbl(txtPorcentajeCosto.Text)
                douTmpCantidad = CDbl(txtCantidad.Text)
                intTmpBoni = CInt(txtBoni.Text)

                '- aplicar el calculo
                douTmpPrecio = (((douTmpCosto / (douTmpCantidad + intTmpBoni)) * douTmpCotizacion) + _
                                (((douTmpCosto / (douTmpCantidad + intTmpBoni)) * douTmpCotizacion) * (douTmpPorcentaje / 100)))
                '------------------------------------------
                lblPrecio.Text = douTmpPrecio
                lblPrecio.Text = Format(CDec(lblPrecio.Text), "##,###,##0.##")
            End If
            '------------------------------------
            e.Handled = True
            txtLote.Focus()
            txtGravada10.Text = Format(CDec(txtGravada10.Text), "###,###,##0.##")
        End If
    End Sub

    Private Sub txtPorcentajeCosto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentajeCosto.KeyPress
        e.Handled = txtNumerico(txtPorcentajeCosto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtPorcentajeCosto.Text) = 0 Then
                txtPorcentajeCosto.Text = 0
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtPorcentajeCosto.Text = Format(CDec(txtPorcentajeCosto.Text), "###.00")
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = txtNumerico(txtCantidad, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtCantidad.Text) = 0 Then
                txtCantidad.Text = 0
            End If
            '-- controlar si existe un pedido
            'If CInt(txtNroPedido.Text) > 0 Then
            '    If txtCantidad.Text >
            'End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtCantidad.Text = Format(CDec(txtCantidad.Text), "#,###.00")
        End If
    End Sub

    Private Sub txtBoni_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoni.KeyPress
        e.Handled = txtNumerico(txtBoni, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtBoni.Text) = 0 Then
                txtBoni.Text = 0
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtBoni.Text = Format(CInt(txtBoni.Text), "#,##0")
        End If
    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLote.KeyPress
        'e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtNota_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNota.KeyPress
        'e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAgregar.Focus()
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- controlar que ingrese primero el proveedor
            If Len(txtProveedor.Text) = 0 Then
                MessageBox.Show("Debe Ingresar Primero el Proveedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '---------------------------------------------------------
            If Not IsNumeric(txtProducto.Text) Or txtProducto.Text = "" Then
                '-- si es espacio en blanco desplegar la lista de productos
                banGl_compra = True
                Me.Enabled = False
                frmStock.txtBuscar.Text = txtProducto.Text
                frmStock.txtIdProducto.Text = "0"

                If txtProducto.Text <> "" Then
                    '-- buscar en el stock
                    frmStock.listar_busqueda(" Where mercaderia Like '" & txtProducto.Text & "%' Or mercaderia Like '" & txtProducto.Text & "%' " & " order by 3")
                End If

                frmStock.Visible = True
                frmStock.WindowState = FormWindowState.Normal
                frmStock.Show()
                'frmStock.lvStock.Focus()
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '-- buscar por codigo el producto
    Private Sub txtProducto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.Validated
        '-- controlar que ingrese primero el proveedor
        If Len(txtProveedor.Text) = 0 Then
            MessageBox.Show("Debe Ingresar Primero el Proveedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '---------------------------------------------------------
        '-- solo si se ingresó al gun dato
        If txtProducto.Text.Length > 0 Then
            '-- verificar el metodo de busqueda
            If IsNumeric(txtProducto.Text.Substring(0, 1)) Then
                '-- si es numerico el primer digito ingresado
                If txtProducto.Text.Length = 6 Then
                    '-- si es buscado por el codigo interno
                    buscarCodigoProducto(CInt(txtProducto.Text))
                End If
                If txtProducto.Text.Length > 6 Then
                    '-- si es buscado por el codigo de barras del producto
                    buscarCodigoBarraProducto(Trim(txtProducto.Text))
                End If
            End If
        End If

    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        'banGl_compra = blanquearBanderas("banGl_compra")
        banGl_compra = True
        Me.Enabled = False

        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.Visible = True
        frmBuscarProveedor.WindowState = FormWindowState.Normal
        frmBuscarProveedor.Show()
        frmBuscarProveedor.txtBuscar.Focus()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            '-- eliminar el registro de la tabla temporal
            sp_datosTabla.consulta_valor("delete from detCompraTmp where nro=" & lblNro.Text & " and idConfig=" & intGl_idConfigPc)
            '-- renumerar
            If (fun_guardarSp("sp_renumerarDetCompraTmp", intGl_idConfigPc, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Actualizar el detalle de la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            'sp_datosTabla.consulta_valor("update detCompraTmp set nro=(row_number() over(order by dv.idConfig)) from detCompraTmp where
            listarCompra()
            '-- volver a sumar los totales
            sumarTotal()
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        controlarCompra()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        '-- controlar 
        controlarCargaProducto()
        sumarTotal()
    End Sub

    Private Sub btnReutilizar_Click(sender As System.Object, e As System.EventArgs) Handles btnReutilizar.Click
        Me.Enabled = False
        frmReutilizarCompra.txtIdCompra.Text = 0
        frmReutilizarCompra.txtCargadopor.Text = ""
        frmReutilizarCompra.txtFactura.Text = ""
        frmReutilizarCompra.txtFecha.Text = ""
        frmReutilizarCompra.txtFechaCarga.Text = ""
        frmReutilizarCompra.txtProveedor.Text = ""
        frmReutilizarCompra.txtTotal.Text = 0

        frmReutilizarCompra.Visible = True
        frmReutilizarCompra.Show()
        frmReutilizarCompra.BringToFront()
    End Sub

    Private Sub btnPorcentaje_Click(sender As System.Object, e As System.EventArgs) Handles btnPorcentaje.Click
        Me.Enabled = False
        frmPorcentajeCompra.txtMonto.Text = 0
        frmPorcentajeCompra.rdPorcentaje.Checked = True
        frmPorcentajeCompra.rdMonto.Checked = False
        frmPorcentajeCompra.Show()
        frmPorcentajeCompra.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------
    '******************'
    '-- LAS MASKARAS --'
    '******************'
    Private Sub maskVence_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles maskVence.KeyPress
        e.Handled = txtNumericoMask(maskVence, e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '***********'
    '-- COMBO --'
    '***********'
    Private Sub cboMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If txtCotizacion.Enabled = False Then
                txtProducto.Focus()
            Else
                txtCotizacion.Focus()
            End If

        End If
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboMoneda.SelectedIndexChanged
        '-- verificar si la moneda seleccionada corresponde a la moneda que opera el sistema
        If cboMoneda.SelectedValue = sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad) Then
            txtCotizacion.Enabled = False
            txtCotizacion.Text = 1
        Else
            txtCotizacion.Enabled = True
            txtCotizacion.Text = 0
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompra.SelectedIndexChanged
        For Each item As ListViewItem In lvCompra.SelectedItems
            lblNro.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub

    Private Sub lvCompra_GotFocus(sender As Object, e As System.EventArgs) Handles lvCompra.GotFocus
        For Each item As ListViewItem In lvCompra.SelectedItems
            lblNro.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCompras_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- ver si hay item cargados
        If sp_datosTabla.consulta_valor("select idConfig from detCompraTmp where idConfig=" & intGl_idConfigPc) > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                banGl_compra = 0
                frmMenuPrincipal.proveedorFacturaCompra.Enabled = True
                sp_datosTabla.consulta_valor("delete from detCompraTmp where idConfig=" & intGl_idConfigPc)
                e.Cancel = False
            Else
                e.Cancel = True

            End If ' Call me
        Else
            banGl_compra = 0
            frmMenuPrincipal.proveedorFacturaCompra.Enabled = True
            sp_datosTabla.consulta_valor("delete from detCompraTmp where idConfig=" & intGl_idConfigPc)
            e.Cancel = False

        End If
    End Sub

    Private Sub frmCompras_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        btnBuscarProveedor.Focus()
    End Sub


    Private Sub frmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- coloar el deposito / sucursal
        Dim intTmpIdDepositoCompra As Integer = 0
        intTmpIdDepositoCompra = sp_datosTabla.un_dato_integer("idDepositoCompra", "configEmpresa", "idEntidad", intGl_idEntidad)
        Dim intTmpIdSucursal As Integer = 0
        intTmpIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "deposito", "idDeposito", intTmpIdDepositoCompra)

        lblDeposito.Text = Trim(sp_datosTabla.un_datoString("nombreDeposito", "deposito", "idDeposito", intTmpIdDepositoCompra)) & "," & Trim(sp_datosTabla.un_datoString("nombreFantasia", "v_sucursal", "idSucursal", intTmpIdSucursal))
        'limpiar()
        'limpiarProducto()

    End Sub
    '----------------------------------------------------------------------------------------------------
End Class