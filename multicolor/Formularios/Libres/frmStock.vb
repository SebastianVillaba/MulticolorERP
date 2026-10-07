Public Class frmStock
    '******************************'
    '-- VARIABLES DE TIPO OBJETO --'
    '******************************'
    Dim systemClass As New SystemClass
    Dim sp_stock As New sp_stock
    Dim sp_datosTabla As New sp_datosTabla
    Dim tipoProducto As New tipoProducto

    '*************************'
    '-- VARIABLES ESCALARES --'
    '*************************'
    '-- variables para cargar la venta
    Dim intNroVentaTmp As Integer
    Dim strCodigoTmp As String
    Dim strProductoTmp As String
    Dim strDescuentoTmp As String
    Dim intPorcentajeImpuestoTmp As Integer
    Dim strFormaTmp As String
    Dim strVencimientoTmp As String
    Dim intCantidadTmp As Integer
    Dim intPrecioTmp As Integer
    Dim intPrecioDescuentoTmp As Integer
    Dim intSubtotalTmp As Integer
    Dim intIdLoteTmp As Integer
    Dim intIdStockTmp As Integer
    Dim bolDescuentpTmp As Boolean
    '---------------------------------------------------------------------
    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        tipoProducto.ListarTipoVenta(cboTipoProducto)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '------------------------'
    '-- LOS PROCEDIMIENTOS --'
    '------------------------'
    Private Sub inicializar()
        lvStock.Columns(0).Width = 0
    End Sub

    Public Sub listar_busqueda(ByVal where As String)
        '-- ver si son vendedores de la heladeria
        Dim bolTmpVendedorHeladeria As Boolean = False
        systemClass.SqlToLv_producto_busqueda(lvStock, "select idProducto,codigo,mercaderia,presentacion,referencia,precio,nombreTipo,stock from v_stock" & intGl_idSucursal & " where " & where)
        txtSql.Text = "select idProducto,codigo,mercaderia,presentacion,referencia,precio,nombreTipo,stock from v_stock" & intGl_idSucursal & " where " & where

    End Sub

    Private Sub listar_productoRef(ByVal v_idProducto As Integer)
        systemClass.SqlToDg_productoRef(frmReferenciarMercaderias.dtgReferencia, "select row_number() over(order by p.codigo) as nro,p.codigo,(rtrim(p.nombreProducto)+','+ltrim(p.presentacion)) as Mercaderia,dp.cantidad,dp.imprimir,cp.idProductoRef from cabProductoRef cp inner join detProductoRef dp on cp.idProductoRef=dp.idProductoRef inner join producto p on p.idProducto=dp.idProducto where cp.idProducto=" & v_idProducto)
    End Sub

    '-- controlar los modulos
    Private Sub controlarModulo()
        '-- para venta de la farmacia
        '-- para venta de la farmacia1
        If banGl_ventaFarmacia1 = True Then
            ventaFarmacia1()
        End If
        '-- para compra
        If banGl_compra = True Then
            compraFarmacia()
        End If
        '-- para la referencia de mercaderia el producto
        If bolGl_refMercaderias = True Then
            referenciarMercaderiaProducto()
        End If
        '-- para la referencia del detalle de mercaderia
        If bolGl_refMercaderiasDetalle = True Then
            referenciarDetalleMercaderia()
        End If
        '-- para el seguimiento de stock
        If banGl_seguimientoStock = True Then
            seguimientoStock(CInt(txtIdProducto.Text))
        End If
        '-- para el modulo del stock inicial
        If banGl_stockInicial = True Then
            stockInicial()
        End If
        '-- para el modulo modificacion de precio de mercaderias enteras
        If banGl_precioEntero = True Then
            precioEntero(txtIdProducto.Text)
        End If
        '-- para el modulo modificacion de precio de mercaderias fraccionadas
        If banGl_precioFraccion = True Then
            precioFraccion(txtIdProducto.Text)
        End If
        '-- para el modulo de generacion de codigo de barras de mecaderia
        If banGl_generarCodigoBarraMercaderia = True Then
            generarCodigoBarraMercaderia(CInt(txtIdProducto.Text))
        End If
        '-- para el modulo de cargar ventas a credito de las sucursales
        If banGl_cargarVentaSucursal = True Then
            ventaCreditoSucursal(CInt(txtIdProducto.Text))
        End If
        '-- para el modulo de reportes de mercaderias en gral
        If banGl_reporteMercaderiaGral = True Then
            reporteMercaderiaGeneral(CInt(txtIdProducto.Text))
        End If
        '-- para el modulo de reportes de producto por cliente
        If banGl_reporteProductoCliente = True Then
            reporteProductoCliente(CInt(txtIdProducto.Text))
        End If
        '-- para el modulo de modificacion de vencimientos
        If banGl_modificaVence = True Then
            modificacionVencimiento(CInt(txtIdProducto.Text))
        End If
        '-- estadistica de proveedores
        If banGl_estadisticaProveedor = True Then
            estadisticaProveedor(CInt(txtIdProducto.Text))
        End If
        '-- fraccionar mercaderias
        If banGl_fraccionarMercaderia = True Then
            mercaderiasFraccionadas(CInt(txtIdProducto.Text))
        End If
        '-- modificar fraccionado
        If banGl_modificarFracionado = True Then
            modificarFraccionado(CInt(txtIdProducto.Text))
        End If
        '-- lote de mas en productos referenciados
        If banGl_masLoteReferencia = True Then
            masLoteReferencia(CInt(txtIdProducto.Text))
        End If
        '-- por la estadistica de clientes
        If banGl_estadisticaCliente = True Then
            estadisticaCliente(CInt(txtIdProducto.Text))
        End If
        '-- descuento especial
        If banGl_descuentoEspecial = True Then
            descuentoEspecial(CInt(txtIdProducto.Text))
        End If
        '-- descuento especial por grupo de cliente
        If banGl_descuentoEspecialGrupoCliente = True Then
            descuentoEspecialGrupoCliente(CInt(txtIdProducto.Text))
        End If
    End Sub

    '-- venta farmacia1
    Private Sub ventaFarmacia1()
        banGl_ventaFarmacia = False

        Dim intTmpIdProducto As Integer
        Dim intTmpIdDeposito As Integer

        '-- valorizar la variable idProducto
        intTmpIdProducto = CInt(txtIdProducto.Text)
        intTmpIdDeposito = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)

        '-- colocar los datos de la mercaderia
        '-- tipo de producto
        Dim intTmpIdTipoProducto As Integer
        intTmpIdTipoProducto = sp_datosTabla.consulta_valor("select idTipoProducto from producto where idProducto=" & intTmpIdProducto)
        frmVentaFarmacia1.txtTipoProducto.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoProducto where idTipoProducto=" & intTmpIdTipoProducto)
        '-- idProducto
        txtIdProducto.Text = intTmpIdProducto
        '-- laboratorio
        Dim intTmpIdLaboratorio As Integer
        intTmpIdLaboratorio = sp_datosTabla.consulta_valor("select idLaboratorio from producto where idProducto=" & intTmpIdProducto)
        frmVentaFarmacia1.txtLaboratorioProducto.Text = sp_datosTabla.consulta_valorString("select nombre from v_laboratorio where idLaboratorio=" & intTmpIdLaboratorio)
        '-- stock del producto
        frmVentaFarmacia1.txtStockProducto.Text = sp_datosTabla.consulta_valor("select sum(cantidad) from stock where idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito & " group by idProducto,idDeposito")
        '----------------------------------------------------------------------------------------------------------
        '-------------'
        '-- los lbl --'
        '-------------'
        '-- el codigo
        frmVentaFarmacia1.lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intTmpIdProducto)
        '-- la mercaderia   
        frmVentaFarmacia1.lblMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & intTmpIdProducto)
        '-- lblidProducto
        frmVentaFarmacia1.lblIdProducto.Text = intTmpIdProducto
        '-- la imagen
        frmVentaFarmacia1.picImagenMercaderia.Image = sp_datosTabla.consulta_valorImagen("select imagen from producto where idProducto=" & intTmpIdProducto)

        'frmVentaFarmacia1.picImagenMercaderia.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)

        '**************************************************************************************************************************

        '-- si el producto es de uso controlado
        If sp_datosTabla.consulta_valorBoolean("select controlado from producto where idProducto=" & intTmpIdProducto) = True Then
            MessageBox.Show("Mercadería de Uso Controlado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '-- controlar si es un producto fraccionado
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
            ' MsgBox("Es fraccionado..!")
            '-- producto fraccionado
            '-- activar la varibale global del fraccionado
            bolGl_vtaFraccionado = True

            Me.Close()
            banGl_ventaFarmacia1 = True

            frmFraccionado.txtIdForma.Text = 0
            frmFraccionado.listar_busqueda(intTmpIdProducto)
            frmFraccionado.Visible = True
            frmFraccionado.WindowState = FormWindowState.Normal
            frmFraccionado.Show()
            frmFraccionado.BringToFront()

        Else
            '-- datos del stock
            frmVentaFarmacia1.lblCantfrac.Text = 1
            frmVentaFarmacia1.lblForma.Text = "ENTERO"
            '----------------------------------------------------------

            'MsgBox("No es fraccionado2..!")
            bolGl_vtaFraccionado = False
            '----------------------------------
            '-- controlar si tiene varios lotes
            '----------------------------------
            If sp_datosTabla.sp_integer("sp_totalLoteStock", intTmpIdProducto & "," & intGl_idSucursal) > 1 Then
                '-- para varios lotes
                Me.Close()
                banGl_ventaFarmacia1 = True

                'MsgBox("Valor de idProducto  " & txtIdProducto.Text)

                frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", intTmpIdProducto)
                frmLote.listar_busqueda(intTmpIdProducto, intGl_idSucursal)
                frmLote.listar_stockVencimiento(intTmpIdProducto)
                '-- ocultar las columnas
                'frmFraccionado.lvFraccionado.Columns(5).Width = 0
                '---------------------------------
                frmLote.Visible = True
                frmLote.WindowState = FormWindowState.Normal
                frmLote.Show()
                frmLote.BringToFront()
            End If
            If sp_datosTabla.sp_integer("sp_totalLoteStock", intTmpIdProducto & "," & intGl_idSucursal) = 1 Then
                '-- volver a controlar si el deposito correspode al configurado para la venta
                '-- para un lote
                If intTmpIdDeposito = sp_datosTabla.un_dato_integer_consulta("idDeposito", "stock", "idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito) Then
                    '-- efectivamente tiene un solo lote en el stock
                    '-- traer el idlote
                    intIdLoteTmp = sp_datosTabla.consulta_valor("select idLote from stock where idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito)
                    'MsgBox("Valor de idDepososito  " & intIdDepositoTemp)
                    'MsgBox("Valor de idProducto  " & intGl_vtaIdProducto)
                    'MsgBox("Valor de idLote   " & intIdLoteTmp)
                    '-- traer el idStock
                    intIdStockTmp = sp_datosTabla.consulta_valor("select idStock from stock where idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito & " and idLote=" & intIdLoteTmp)
                    '---------------------'
                    '-- datos del stock --'
                    '---------------------'
                    frmVentaFarmacia1.lblIdStock.Text = intIdStockTmp
                    frmVentaFarmacia1.txtCantidad.Text = 1
                    Me.Close()
                    frmVentaFarmacia1.txtCantidad.Focus()
                    '-------------------------------------------------------------
                Else
                    '-- tiene en otro deposito el lote correspondiente
                    Me.Close()
                    banGl_ventaFarmacia1 = True

                    frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", intTmpIdProducto)
                    frmLote.listar_busqueda(intTmpIdProducto, intGl_idSucursal)
                    '-- ocultar las columnas
                    'frmFraccionado.lvFraccionado.Columns(5).Width = 0
                    '---------------------------------
                    frmLote.Visible = True
                    frmLote.WindowState = FormWindowState.Normal
                    frmLote.Show()
                    frmLote.BringToFront()
                End If
            End If
            If sp_datosTabla.sp_integer("sp_totalLoteStock", intTmpIdProducto & "," & intGl_idSucursal) = 0 Then
                '-- para ningun lote y stock
                intIdLoteTmp = 0
                intIdStockTmp = 0
                '---------------------'
                '-- datos del stock --'
                '---------------------'
                frmVentaFarmacia1.lblIdStock.Text = intIdStockTmp
                frmVentaFarmacia1.txtCantidad.Text = 1
                Me.Close()
                frmVentaFarmacia1.txtCantidad.Focus()
                '-------------------------------------------------------------
            End If
        End If

    End Sub

    '-- para colocar en venta directamente por el codigo de barra interno
    Private Sub colocarVenta(ByVal v_idLote As Integer, ByVal v_idProducto As Integer)
        MessageBox.Show("Debe realizar este procedimiento en el módulo de ventas..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    '-- compra de mercaderias
    Private Sub compraFarmacia()
        '-- procedimiento para buscar por el codigo del producto
        Dim strNombreProducto As String = ""
        '-- concertir a integer la variable del objeto
        Dim intTmpIdProducto As Integer = 0
        intTmpIdProducto = CInt(txtIdProducto.Text)
        strNombreProducto = sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", intTmpIdProducto)
        '-- verificar si existe el producto
        If strNombreProducto = "" Then
            MessageBox.Show("No existe el codigo ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            frmCompras.lblCodigoProducto.Text = ""
            frmCompras.lblNombreProducto.Text = ""
            frmCompras.txtLaboratorio.Text = ""
            frmCompras.lblPrecio.Text = ""
            frmCompras.lblUltCosto.Text = ""
            frmCompras.txtFraccion.Text = ""
            frmCompras.lblCantidad.Text = ""
            Exit Sub
        Else
            Dim intTmpIdTipoProducto As Integer
            '-- valor del producto
            frmCompras.lblCodigoProducto.Text = sp_datosTabla.un_dato_integer("codigo", "v_producto", "idProducto", intTmpIdProducto)
            frmCompras.lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", intTmpIdProducto)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", intTmpIdProducto))
            frmCompras.txtLaboratorio.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", intTmpIdProducto)))
            frmCompras.txtTipoProducto.Text = Trim(sp_datosTabla.un_datoString("nombreTipo", "v_tipoproducto", "idTipoProducto", sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", intTmpIdProducto)))
            '-- si el tipo de producto puede colocarse el porcentaje sobre costo
            intTmpIdTipoProducto = sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", intTmpIdProducto)
            If sp_datosTabla.consulta_valorBoolean("select porcentajeCompra from v_tipoProducto where idTipoProducto=" & intTmpIdTipoProducto) = True Then
                frmCompras.txtPorcentajeCosto.Enabled = True
                frmCompras.txtPorcentajeCosto.Text = 0
                frmCompras.txtPorcentajeCosto.BackColor = Color.White
            Else
                frmCompras.txtPorcentajeCosto.Enabled = False
                frmCompras.txtPorcentajeCosto.Text = 0
                frmCompras.txtPorcentajeCosto.BackColor = Color.LightBlue
            End If
            '-- la imagen de la mercaderia
            frmCompras.PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
            '-- ver si es un producto fraccionado
            If (sp_datosTabla.un_dato_boleano("fraccionado", "v_producto", "idProducto", intTmpIdProducto)) = True Then
                banGl_compra = blanquearBanderas("banGl_compra")
                '-- si es un producto fraccionad
                '-- activar la varibale global del fraccionado
                bolGl_vtaFraccionado = False
                bolGl_comFraccionado = True

                Me.Close()
                banGl_compra = True

                frmFraccionado.listar_busqueda(sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", intTmpIdProducto))
                frmFraccionado.txtIdProducto.Text = intTmpIdProducto
                frmFraccionado.Visible = True
                frmFraccionado.WindowState = FormWindowState.Normal
                frmFraccionado.Show()
                frmFraccionado.BringToFront()
            Else
                '*******************************************************************************************
                '-- verificar el pedido
                ' productoPedidoAProveedor(intTmpIdProducto, CInt(frmCompras.txtIDProveedor.Text))
                '*******************************************************************************************
                '-- si es un producto entero
                frmCompras.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", intTmpIdProducto)
                frmCompras.lblPrecio.Text = FormatNumber(frmCompras.lblPrecio.Text, "00,000,000.00")
                frmCompras.lblUltCosto.Text = sp_datosTabla.un_dato_double("ultimoCosto", "v_producto", "idProducto", intTmpIdProducto)
                frmCompras.lblUltCosto.Text = FormatNumber(frmCompras.lblUltCosto.Text, "00,000,000.00")
                frmCompras.txtFraccion.Text = "ENTERO"
                frmCompras.lblCantidad.Text = 1

                Me.Close()
                banGl_compra = True

                frmCompras.Enabled = True
                frmCompras.Show()
                frmCompras.BringToFront()

                If frmCompras.txtPorcentajeCosto.Enabled = False Then
                    frmCompras.txtCantidad.Focus()
                Else
                    frmCompras.txtPorcentajeCosto.Focus()
                End If

            End If
        End If
    End Sub

    '-- referencia de mercaderias
    Private Sub referenciarMercaderiaProducto()
        Dim intTmpIdProductoRef As Integer

        '-- verificar si existe el producto como cabecera
        If sp_datosTabla.consulta_valor("select idProducto from cabProductoRef where idProducto=" & CInt(txtIdProducto.Text)) Then
            MessageBox.Show("Esta Mercadería ha sido referenciado en la Cabecera de las Referencias..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '-- colocar el detalle del producto referenciado
            intTmpIdProductoRef = sp_datosTabla.consulta_valor("select idProductoRef from cabProductoRef where idProducto=" & CInt(txtIdProducto.Text))
            listar_productoRef(CInt(txtIdProducto.Text))
            '-- cargar en la tabla temporal
            For i As Integer = 0 To frmReferenciarMercaderias.dtgReferencia.Rows.Count - 1
                '-- si existen item cargados
                If frmReferenciarMercaderias.dtgReferencia.Rows(i).Cells(0).Value > 0 Then
                    '-- aumentar la variable global
                    intGl_nroReferenciarMercaderia = intGl_nroReferenciarMercaderia + 1
                    '-- idProducto
                    Dim intTmpIdProducto As Integer = 0
                    intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & frmReferenciarMercaderias.dtgReferencia.Rows(i).Cells(1).Value)
                    '-- procedimiento para cargar la tabla temporal
                    sp_datosTabla.sp_string("sp_agregarDetProductoRefTmp", intGl_idConfigPc & "," & intTmpIdProductoRef & "," & intTmpIdProducto & "," & frmReferenciarMercaderias.dtgReferencia.Rows(i).Cells(3).Value & "," & 0)
                End If
            Next
        End If
        '-- los datos de los producto
        frmReferenciarMercaderias.txtIdProducto.Text = txtIdProducto.Text
        frmReferenciarMercaderias.txtCodigo.Text = sp_datosTabla.un_datoString("codigo", "producto", "idProducto", txtIdProducto.Text)
        frmReferenciarMercaderias.txtNombreProducto.Text = sp_datosTabla.un_datoString("nombreProducto", "producto", "idProducto", txtIdProducto.Text)

        '-- habilitar los botones
        frmReferenciarMercaderias.btnAgregar.Enabled = True
        frmReferenciarMercaderias.btnCancelar.Enabled = True
        frmReferenciarMercaderias.btnEliminar.Enabled = True
        frmReferenciarMercaderias.btnGuardar.Enabled = True
        frmReferenciarMercaderias.btnNuevo.Enabled = False

        Me.Close()
        frmReferenciarMercaderias.Enabled = True
        frmReferenciarMercaderias.Show()
        frmReferenciarMercaderias.BringToFront()
        frmReferenciarMercaderias.btnAgregar.Focus()
    End Sub

    '-- referencia del detalle de mercaderia 
    Private Sub referenciarDetalleMercaderia()
        '-- verificar si existe el producto como cabecera
        If sp_datosTabla.consulta_valor("select idProducto from cabProductoRef where idProducto=" & CInt(txtIdProducto.Text)) Then
            MessageBox.Show("Esta Mercadería ha sido referenciado en la Cabecera de las Referencias..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- verificar si existe el producto como detalle del mismo producto
        Dim intTmpIdProductoRef As Integer
        intTmpIdProductoRef = sp_datosTabla.un_dato_integer("idProductoRef", "cabProductoRef", "idProducto", CInt(frmReferenciarMercaderias.txtIdProducto.Text))

        If (sp_datosTabla.consulta_valor("select idProductoRef from detProductoRef where idProductoRef=" & intTmpIdProductoRef & " and idProducto=" & CInt(txtIdProducto.Text))) Then
            MessageBox.Show("Esta Mercadería ha sido referenciado en el Detalle de las Referencias..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '-- agregar a la grilla referenciada 
        intGl_nroReferenciarMercaderia = intGl_nroReferenciarMercaderia + 1
        Dim strTmpCodigo As String
        strTmpCodigo = sp_datosTabla.un_datoString("codigo", "producto", "idProducto", CInt(txtIdProducto.Text))
        Dim strTmpNombreProducto As String
        strTmpNombreProducto = sp_datosTabla.un_datoString("nombreProducto", "producto", "idProducto", CInt(txtIdProducto.Text))
        '-- procedimiento para cargar la grilla
        FuncionesPublicas.cargarProductoReferenciado(intGl_nroReferenciarMercaderia, strTmpCodigo, strTmpNombreProducto, 0)
        '-- procedimiento para cargar la tabla temporal
        sp_datosTabla.sp_string("sp_agregarDetProductoRefTmp", intGl_idConfigPc & "," & 0 & "," & CInt(txtIdProducto.Text) & "," & 0 & "," & 0)

        Me.Close()
        frmReferenciarMercaderias.Enabled = True
        frmReferenciarMercaderias.Show()
        frmReferenciarMercaderias.BringToFront()
        frmReferenciarMercaderias.dtgReferencia.Focus()

    End Sub

    '-- seguimiento de stock
    Private Sub seguimientoStock(ByVal v_idProducto As Integer)
        '----------------------------------
        '-- controlar si tiene varios lotes
        '----------------------------------
        Dim intTmpIdSucursal As Integer
        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from deposito where idDeposito=" & frmSeguimientoStock.txtIdDeposito.Text)

        '-- blanquear el listview del seguimiento de stock
        sp_datosTabla.consulta_valor("delete from tmpSeguimientoStock where idConfig=" & intGl_idConfigPc)
        'frmSeguimientoStock.listarSeguimientoStock()
        If frmSeguimientoStock.rdVence.Checked = True Then
            '-- busqueda por lote
            'MsgBox("Valor de v_idProducto " & v_idProducto)
            'MsgBox("Valor de intTmpIdSucursal " & intTmpIdSucursal)

            If sp_datosTabla.sp_integer("sp_totalLote", v_idProducto & "," & intTmpIdSucursal) > 1 Then
                '-- para varios lotes
                frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", v_idProducto)
                frmLote.listar_busquedaTodosLotes(v_idProducto, CInt(frmSeguimientoStock.txtIdDeposito.Text))
                'frmLote.listar_busqueda(v_idProducto, intTmpIdSucursal)
                '---------------------------------
                '-- solo si el tipo de busqueda es por vencimiento
                If frmSeguimientoStock.rdVence.Checked = True Then
                    Me.Close()
                    banGl_seguimientoStock = True

                    '- por vencimiento
                    frmLote.WindowState = FormWindowState.Normal
                    frmLote.Show()
                    frmLote.BringToFront()
                    frmLote.lvStockSucursal.Focus()
                Else
                    '-- por producto
                    cargarSeguimientoStock(v_idProducto, intIdStockTmp)
                End If
                '----------------------------------------------

            End If
        Else
            '-- solo por producto
            Dim intIdDepositoTemp As Integer = 0
            intIdDepositoTemp = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
            '-- efectivamente tiene un solo lote en el stock
            '-- traer el idlote
            intIdLoteTmp = sp_datosTabla.un_dato_integer_consulta("idlote", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & intIdDepositoTemp)
            '-- traer el idStock
            intIdStockTmp = sp_datosTabla.un_dato_integer_consulta("idStock", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & intIdDepositoTemp)
            cargarSeguimientoStock(v_idProducto, intIdStockTmp)

        End If
        If sp_datosTabla.sp_integer("sp_totalLoteStock", v_idProducto & "," & intTmpIdSucursal) = 0 Then
            '-- para ningun lote y stock
            intIdLoteTmp = 0
            intIdStockTmp = 0
            '-- cargar la venta
            cargarSeguimientoStock(v_idProducto, intIdStockTmp)
        End If
    End Sub

    '-- cargar mercaderia en el seguimiento de stock
    Private Sub cargarSeguimientoStock(ByVal v_idproducto As Integer, ByVal v_idStock As Integer)
        '-- variable temporal
        Dim intTmpIdLote As Integer
        '-- dar valor a la variable global del modulo
        intGl_idProductoSeguimientoStock = v_idproducto
        intGl_idStockSeguimientoStock = v_idStock

        '-- cargar los datos del producto
        frmSeguimientoStock.txtCodigo.Text = sp_datosTabla.un_datoString("codigo", "producto", "idProducto", v_idproducto)
        intTmpIdLote = sp_datosTabla.un_dato_integer("idLote", "stock", "idStock", v_idStock)
        frmSeguimientoStock.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
        frmSeguimientoStock.txtMercaderia.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "producto", "idProducto", v_idproducto)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "producto", "idProducto", v_idproducto))
        frmSeguimientoStock.txtVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
        '---------------------------------
        Me.Visible = False
        frmSeguimientoStock.Enabled = True
        frmSeguimientoStock.WindowState = FormWindowState.Normal
        frmSeguimientoStock.Show()
        frmSeguimientoStock.BringToFront()
        frmSeguimientoStock.btnProcesar.Focus()
    End Sub

    '-- stock inicial
    Private Sub stockInicial()
        '-- varibles
        Dim intTmpIdProducto As Integer

        '-- colocar idProducto
        intTmpIdProducto = txtIdProducto.Text
        '-- colocar los datos de la mercaderia
        frmStockInicial.lblCodigoProducto.Text = sp_datosTabla.un_datoString("codigo", "v_producto", "idProducto", Str(intTmpIdProducto))
        frmStockInicial.lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", Str(intTmpIdProducto))) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", Str(intTmpIdProducto)))
        frmStockInicial.lblCosto.Text = sp_datosTabla.sp_integer("sp_ultimoCostoProducto", intTmpIdProducto)
        frmStockInicial.lblCosto.Text = Format(CDec(frmStockInicial.lblCosto.Text), "##,###,###.##")
        Dim intTmpIdLaboratorio As Integer
        intTmpIdLaboratorio = sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", intTmpIdProducto)
        frmStockInicial.txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", Str(intTmpIdLaboratorio))
        Dim intTmpidTipoProducto As Integer
        intTmpidTipoProducto = sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", intTmpIdProducto)
        frmStockInicial.txtTipoProducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", Str(intTmpIdProducto))
        frmStockInicial.txtOrigen.Text = sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", Str(intTmpIdProducto))
        '-- la imagen de la mercaderia
        frmStockInicial.PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
        '---------------------------------'
        '-- controlar si es fraccionado --'
        '---------------------------------'
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
            '-- la variable global del idProducto del modulo
            intGl_stockInicialIdProducto = intTmpIdProducto
            ' MsgBox("Es un Producto Fraccionado..!")
            '--- producto fraccionado
            Me.Close()

            banGl_stockInicial = True
            frmFraccionado.listar_busqueda(intTmpIdProducto)
            frmFraccionado.Visible = True
            frmFraccionado.WindowState = FormWindowState.Normal
            frmFraccionado.Show()
            frmFraccionado.BringToFront()
        Else
            ' MsgBox("No es un Producto Fraccionado..!")
            '---------------------'
            '-- producto entero --'
            '---------------------'
            '-- datos de la fraccion
            frmStockInicial.txtFraccion.Text = "ENTERO"
            frmStockInicial.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", intTmpIdProducto)
            frmStockInicial.lblPrecio.Text = Format(CDec(frmStockInicial.lblPrecio.Text), "##,###,###.##")

            Me.Close()
            frmStockInicial.txtCantidad.Focus()
        End If

    End Sub

    '-- modificar los precios de mercaderias enteras
    Private Sub precioEntero(ByVal v_idProducto As Integer)
        '-- valor del producto
        frmPrecioEntero.lblCodigoProducto.Text = sp_datosTabla.un_dato_integer("codigo", "v_producto", "idProducto", v_idProducto)
        frmPrecioEntero.lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", v_idProducto)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", v_idProducto))
        'lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", v_idProducto)
        frmPrecioEntero.lblIdProducto.Text = v_idProducto
        frmPrecioEntero.txtLaboratorio.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", v_idProducto)))
        frmPrecioEntero.txtDivision.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_Division", "idDivision", sp_datosTabla.un_dato_integer("idDivision", "v_producto", "idProducto", v_idProducto)))
        frmPrecioEntero.txtTipoProducto.Text = Trim(sp_datosTabla.un_datoString("nombreTipo", "v_tipoproducto", "idTipoProducto", sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", v_idProducto)))
        frmPrecioEntero.txtOrigen.Text = Trim(sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", v_idProducto))
        frmPrecioEntero.txtPrecioAnt.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", v_idProducto)
        frmPrecioEntero.txtPrecioAnt.Text = Format(CDec(frmPrecioEntero.txtPrecioAnt.Text), "###,###,###.00")
        '-- la imagen de la mercaderia
        PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", v_idProducto)
        '---------------------------------'
        '-- controlar si es fraccionado --'
        '---------------------------------'
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", v_idProducto)) = True Then
            MessageBox.Show("Esta mercaderia es Fraccionada..! No puede actualizar su precio en este Módulo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            frmPrecioEntero.btnAgregar.Enabled = False
            Exit Sub
        End If
        frmPrecioEntero.btnAgregar.Enabled = True

        Me.Close()
        frmPrecioEntero.Enabled = True
        frmPrecioEntero.Show()
        frmPrecioEntero.BringToFront()
        frmPrecioEntero.txtPrecio.Focus()
    End Sub

    '-- modificar los precios de mercaderias fraccionadas
    Private Sub precioFraccion(ByVal v_idProducto As Integer)
        '-- valor del producto
        frmPrecioFraccion.lblCodigoProducto.Text = sp_datosTabla.un_dato_integer("codigo", "v_producto", "idProducto", v_idProducto)
        frmPrecioFraccion.lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", v_idProducto)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", v_idProducto))
        'lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", v_idProducto)
        frmPrecioFraccion.lblIdProducto.Text = v_idProducto
        frmPrecioFraccion.txtLaboratorio.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", v_idProducto)))
        frmPrecioFraccion.txtDivision.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_Division", "idDivision", sp_datosTabla.un_dato_integer("idDivision", "v_producto", "idProducto", v_idProducto)))
        frmPrecioFraccion.txtTipoProducto.Text = Trim(sp_datosTabla.un_datoString("nombreTipo", "v_tipoproducto", "idTipoProducto", sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", v_idProducto)))
        frmPrecioFraccion.txtOrigen.Text = Trim(sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", v_idProducto))
        '-- la imagen de la mercaderia
        PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", v_idProducto)
        '---------------------------------'
        '-- controlar si es fraccionado --'
        '---------------------------------'
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", v_idProducto)) = False Then
            MessageBox.Show("Esta mercaderia no es Fraccionada..! No puede actualizar su precio en este Módulo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            frmPrecioFraccion.btnAgregar.Enabled = False
            Exit Sub
        End If
        frmPrecioFraccion.btnAgregar.Enabled = True
        frmFraccionado.txtIdProducto.Text = v_idProducto

        Me.Close()
        '--- producto fraccionado
        banGl_precioFraccion = True
        frmFraccionado.listar_busqueda(v_idProducto)
        frmFraccionado.Visible = True
        frmFraccionado.WindowState = FormWindowState.Normal
        frmFraccionado.Show()
        frmFraccionado.BringToFront()
    End Sub

    '-- generar codigo de barra de mercaderias
    Private Sub generarCodigoBarraMercaderia(ByVal v_idProducto As Integer)
        Try
            '----------------------------------
            '-- controlar si tiene varios lotes
            '----------------------------------

            '-- datos del producto
            Dim strTmpNombreMercaderia As String
            Dim strTmpCodigo As String
            Dim strTmpNombreDeposito As String
            Dim strTmpLote As String
            Dim strTmpVence As String = ""
            Dim intTmpIdDeposito As Integer

            strTmpCodigo = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
            strTmpNombreMercaderia = sp_datosTabla.consulta_valorString("select nombreProducto from producto where idProducto=" & v_idProducto)
            '-- el deposito configurado
            intTmpIdDeposito = sp_datosTabla.consulta_valor("select idDepositoRemision from configPc where idConfig=" & intGl_idConfigPc)

            'frmSeguimientoStock.listarSeguimientoStock()

            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intTmpIdDeposito, 1) = 99 Then
                '-- para mas de un lote
                Me.Close()
                banGl_generarCodigoBarraMercaderia = True


                frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", v_idProducto)
                frmLote.listar_busquedaTodosLotes(v_idProducto, intTmpIdDeposito)
                frmLote.Visible = True
                frmLote.WindowState = FormWindowState.Normal
                frmLote.Show()
                frmLote.BringToFront()
            End If

            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intTmpIdDeposito, 0) > 0 Then
                '-- para un lote
                Dim intIdDepositoTemp As Integer = 0
                intIdDepositoTemp = sp_datosTabla.consulta_valor("select idDepositoRemision from configPc where idConfig=" & intGl_idConfigPc)
                strTmpNombreDeposito = sp_datosTabla.consulta_valorString("select nombreDeposito from deposito where idDeposito=" & intIdDepositoTemp)

                intIdLoteTmp = sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intTmpIdDeposito, 0)
                strTmpLote = sp_datosTabla.consulta_valorString("select lote from lote where idLote=" & intIdLoteTmp)
                intIdStockTmp = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idProducto & " and idLote=" & intIdLoteTmp & " and idDeposito=" & intTmpIdDeposito)

                intGl_nroGenerarCodigoBarraMercaderia = intGl_nroGenerarCodigoBarraMercaderia + 1
                cargarGenerarCodigoBarraMercaderia(intGl_nroGenerarCodigoBarraMercaderia, v_idProducto, strTmpCodigo, strTmpNombreMercaderia, strTmpNombreDeposito, strTmpLote, strTmpVence, 1, intIdStockTmp)
                'MsgBox("Despues de cargar la grilla")
                Me.Close()
                frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Focus()
            End If
            If sp_datosTabla.sp_integer("sp_totalLoteStock", v_idProducto & "," & intGl_idSucursal) = 0 Then
                '-- para ningun lote y stock
                intIdLoteTmp = 0
                intIdStockTmp = 0

                MessageBox.Show("Esta mercadería no cuenta con stock..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '-- cargar ventas a credito de las sucursales
    Private Sub ventaCreditoSucursal(ByVal v_idProducto As Integer)
        '-- variables
        Dim strTmpCodigo As String
        Dim strTmpNombreMercaderia As String
        Dim intTmpIdImpuesto As Integer
        Dim douTmpPorcentajeImpuesto As Double
        '-- datos del producto
        strTmpCodigo = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        strTmpNombreMercaderia = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        intTmpIdImpuesto = sp_datosTabla.consulta_valor("select idImpuesto from producto where idProducto=" & v_idProducto)
        douTmpPorcentajeImpuesto = sp_datosTabla.consulta_valorDouble("select porcentajeImpuesto from impuesto where idImpuesto=" & intTmpIdImpuesto)
        '-- cargar la grilla
        'cargarVentaCreditoSucursal(strTmpCodigo, strTmpNombreMercaderia, douTmpPorcentajeImpuesto, v_idProducto)

        Me.Close()
    End Sub

    '-- reporte de mercaderias en gral
    Private Sub reporteMercaderiaGeneral(ByVal v_idProducto As Integer)
        '-- visualizar los objetos
        frmReporteMercaderiaGral.lblMercaderia.Visible = True
        frmReporteMercaderiaGral.lblCodigo.Visible = True
        frmReporteMercaderiaGral.lblIdProducto.Visible = True

        '-- datos del producto
        frmReporteMercaderiaGral.lblMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmReporteMercaderiaGral.lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        frmReporteMercaderiaGral.lblIdProducto.Text = v_idProducto

        Me.Close()
    End Sub

    '-- reporte de producto por cliente
    Private Sub reporteProductoCliente(ByVal v_idProducto As Integer)
        '-- datos del producto
        frmReporteClienteProducto.lblNombre.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmReporteClienteProducto.lblIdMov.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)

        Me.Close()
    End Sub

    '-- modificacion de vencimientos
    Private Sub modificacionVencimiento(ByVal v_idProducto As Integer)
        '-- variables
        Dim intTmpIdLote As Integer
        Dim intTmpIdStock As Integer
        Dim strTmpCodigo As String

        '-- datos del producto
        strTmpCodigo = sp_datosTabla.un_datoString("codigo", "producto", "idProducto", Str(v_idProducto))
        frmModificarVence.lblCodigoProducto.Text = strTmpCodigo
        frmModificarVence.lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", Str(v_idProducto))) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", Str(v_idProducto)))
        Dim intTmpIdLaboratorio As Integer
        intTmpIdLaboratorio = sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", v_idProducto)
        frmModificarVence.txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", Str(intTmpIdLaboratorio))
        Dim intTmpidDivision As Integer
        intTmpidDivision = sp_datosTabla.un_dato_integer("idDivision", "v_producto", "idProducto", v_idProducto)
        frmModificarVence.txtDivision.Text = sp_datosTabla.un_datoString("nombre", "v_division", "idDivision", Str(intTmpidDivision))
        frmModificarVence.txtTipoProducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", Str(v_idProducto))
        frmModificarVence.txtOrigen.Text = sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", Str(v_idProducto))
        '-- la imagen de la mercaderia
        frmModificarVence.PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", v_idProducto)

        '-- controlar si es un producto fraccionado
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", v_idProducto)) = True Then
            ' MsgBox("Es fraccionado..!")
            '-- producto fraccionado
            '-- activar la varibale global del fraccionado
            'MsgBox("Valor de la bandera  " & banGl_ajusteNegativoMercaderia)
            'Me.Close()

            MessageBox.Show("Producto Fraccionado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'frmModificarVence.habilitarObjetos()
            'frmModificarVence.txtCantidad.Text = 1
            'frmModificarVence.txtLote2.Focus()
        End If
        'MsgBox("No es fraccionado2..!")
        '----------------------------------
        '-- controlar si tiene varios lotes
        '----------------------------------
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & CInt(frmModificarVence.txtIdDeposito.Text), 1) = 99 Then
            '-- para varios lotes
            Me.Close()
            banGl_modificaVence = True

            frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", v_idProducto)
            frmLote.listar_busquedaTodosLotes(v_idProducto, CInt(frmModificarVence.txtIdDeposito.Text))
            frmLote.Show()
            frmLote.BringToFront()
            frmLote.lvStockSucursal.Focus()

        End If
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & CInt(frmModificarVence.txtIdDeposito.Text), 0) > 0 Then
            'MsgBox("Solo un lote")
            '-- para un lote
            '*******************'
            '- datos del stock -'
            '*******************'
            '-- efectivamente tiene un solo lote en el stock
            '-- traer el idlote
            intTmpIdLote = sp_datosTabla.un_dato_integer_consulta("idlote", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & CInt(frmModificarVence.txtIdDeposito.Text))
            '-- traer el idStock
            intTmpIdStock = sp_datosTabla.un_dato_integer_consulta("idStock", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & CInt(frmModificarVence.txtIdDeposito.Text))
            '-- datos del stock
            frmModificarVence.txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idStock=" & intTmpIdStock)
            frmModificarVence.txtLote1.Text = sp_datosTabla.consulta_valorString("select lote from lote where idlote=" & intTmpIdLote)
            frmModificarVence.maskVence1.Text = sp_datosTabla.consulta_valorString("select ([maxifarmasa].[dbo].[funFechaCorta](fecha)) from lote where idLote=" & intTmpIdLote)
            frmModificarVence.lblIdStock1.Text = sp_datosTabla.consulta_valor("select idStock from stock where idStock=" & intTmpIdStock)
            frmModificarVence.txtStock.Text = Format(CDbl(frmModificarVence.txtStock.Text), "##,##0.##")
            '-- volver al formulario de modificacion de vencimiento
            Me.Close()

            frmModificarVence.habilitarObjetos()
            frmModificarVence.txtCantidad.Text = 1
            frmModificarVence.txtLote2.Focus()
        End If
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & CInt(frmModificarVence.txtIdDeposito.Text), 1) = 0 Then
            ' MsgBox("Sin stock")
            '-- para ningun lote y stock
            MessageBox.Show("No cuenta con Stock Inicial esta mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '-- volver al formulario de la modificacion de vencimiento
            Me.Close()

            frmModificarVence.limpiarObjetos()
            frmModificarVence.deshabilitarObjetos()
            frmModificarVence.txtProducto.Focus()
        End If
    End Sub

    '-- estadistica de proveedores
    Private Sub estadisticaProveedor(ByVal v_idProducto As Integer)
        '-- procedimiento para cargar la grilla
        frmEstadisticaProveedor.lblIdLaboratorio.Text = 0
        frmEstadisticaProveedor.lblLaboratorio.Text = ""
        frmEstadisticaProveedor.lblProducto.Text = ""
        frmEstadisticaProveedor.lblIdProducto.Text = 0
        frmEstadisticaProveedor.lblCodigo.Text = 0


        frmEstadisticaProveedor.lblProducto.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmEstadisticaProveedor.lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        frmEstadisticaProveedor.lblIdProducto.Text = v_idProducto

        Me.Close()
    End Sub

    '-- fraccionar mercaderias
    Private Sub mercaderiasFraccionadas(ByVal v_idProducto As Integer)
        '-- verificar si es un fraccionado
        If sp_datosTabla.consulta_valor("select idProducto from detForma where idProducto=" & v_idProducto) > 0 Then
            MessageBox.Show("Esta mercadería ya está Fraccionada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        '-- datos del producto
        frmFraccionarMercaderia.lblIdProducto.Text = v_idProducto
        frmFraccionarMercaderia.lblMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmFraccionarMercaderia.lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        frmFraccionarMercaderia.lblPrecio.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)
        frmFraccionarMercaderia.lblPrecio.Text = Format(CDec(frmFraccionarMercaderia.lblPrecio.Text), "##,###,##0")
        Me.Close()

    End Sub

    '-- modificar fraccionados
    Private Sub modificarFraccionado(ByVal v_idProducto As Integer)
        Dim intTmpIdForma As Integer
        Dim intTmpCantidad As Integer
        Dim douTmpPrecio As Double

        '-- verificar si es un fraccionado
        If sp_datosTabla.consulta_valor("select idProducto from detForma where idProducto=" & v_idProducto) = 0 Then
            MessageBox.Show("Esta mercadería no está Fraccionada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        '-- datos del fraccionamiento
        intTmpIdForma = sp_datosTabla.consulta_valor("select idForma from detForma where idProducto=" & v_idProducto)
        intTmpCantidad = sp_datosTabla.consulta_valor("select cantidad from detForma where idProducto=" & v_idProducto)
        douTmpPrecio = sp_datosTabla.consulta_valorDouble("select precio from detForma where idProducto=" & v_idProducto)

        '-- datos del producto
        frmModificarFraccionado.lblIdProducto.Text = v_idProducto
        frmModificarFraccionado.lblMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmModificarFraccionado.lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        frmModificarFraccionado.lblPrecio.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)
        frmModificarFraccionado.lblPrecio.Text = Format(CDec(frmModificarFraccionado.lblPrecio.Text), "##,###,##0")
        '-- datos de la forma
        frmModificarFraccionado.lblForma.Text = sp_datosTabla.consulta_valorString("select nombreForma from cabForma where idForma=" & intTmpIdForma)
        frmModificarFraccionado.txtPrecio.Text = douTmpPrecio
        frmModificarFraccionado.txtPrecio.Text = Format(CDec(frmModificarFraccionado.txtPrecio.Text), "##,###,##0")
        '-- cargar la tabla temporal
        If (fun_guardarSp("sp_agregarDetFormaTmp2", intGl_idConfigPc & "," & intTmpIdForma & "," & v_idProducto & "," & intTmpCantidad & "," & douTmpPrecio, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar el Registro en el detalle del Fraccionamiento...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            frmModificarFraccionado.habilitarObjetos()
            frmModificarFraccionado.listarFraccionado()
            Close()
        End If

    End Sub

    '-- producto con mas de un lote en el detalle de las referencias
    Private Sub masLoteReferencia(ByVal v_idProducto As Integer)
        Dim intTmpIdProductoRef As Integer

        '-- verificar si es un fraccionado
        If sp_datosTabla.consulta_valor("select idProducto from cabProductoRef where idProducto=" & v_idProducto) = 0 Then
            MessageBox.Show("Esta mercadería no está referenciada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        '-- datos del producto
        frmMasLoteReferencia.txtCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        frmMasLoteReferencia.txtProductoRef.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        intTmpIdProductoRef = sp_datosTabla.consulta_valor("select idProductoRef from cabProductoRef where idProducto=" & v_idProducto)
        frmMasLoteReferencia.txtIdRef.Text = intTmpIdProductoRef
        '-- cargar el detalle
        frmMasLoteReferencia.listarDetalleProducto(intTmpIdProductoRef)
        Me.Close()
    End Sub

    '-- estadistica por clientes
    Private Sub estadisticaCliente(ByVal v_idProducto As Integer)
        '-- datos del producto  
        frmEstadisticaClientes.lblIdProd.Text = v_idProducto
        frmEstadisticaClientes.lblProducto.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)

        Me.Close()

    End Sub

    '-- descuento especial
    Private Sub descuentoEspecial(ByVal v_idProducto As Integer)
        '-- datos del producto  
        If sp_datosTabla.consulta_valor("select idProducto from descuentoEspecialTmp where idConfig=" & intGl_idConfigPc & " and idProducto=" & v_idProducto) > 0 Then
            MessageBox.Show("Este producto ya se encuentra en la lista del descuento...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- llamar al formulario para cargar los datos
        Me.Visible = False

        frmCargarDescuentoEspecial.txtNro.Text = 0
        frmCargarDescuentoEspecial.txtIdDet.Text = 0
        frmCargarDescuentoEspecial.txtCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        frmCargarDescuentoEspecial.txtProducto.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmCargarDescuentoEspecial.txtPrecio.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)
        frmCargarDescuentoEspecial.txtPrecio.Text = Format(CDec(frmCargarDescuentoEspecial.txtPrecio.Text), "##,###,##0")
        frmCargarDescuentoEspecial.txtPrecio1Con.Text = 0
        frmCargarDescuentoEspecial.txtPrecio1Cre.Text = 0
        frmCargarDescuentoEspecial.txtPrecio1Tar.Text = 0
        frmCargarDescuentoEspecial.txtPrecio1Debito.Text = 0

        frmCargarDescuentoEspecial.Show()
        frmCargarDescuentoEspecial.BringToFront()
        frmCargarDescuentoEspecial.txtPrecio1Con.Focus()
    End Sub

    '-- descuento especial por grupo de cliente
    Private Sub descuentoEspecialGrupoCliente(ByVal v_idProducto As Integer)
        Dim tmpDouPorceContado As Double = 0
        Dim tmpDouPorceCredito As Double = 0
        Dim tmpDouPrecio As Double = 0

        '-- datos del producto  
        If sp_datosTabla.consulta_valor("select idProducto from descuentoEspecialGrupoClienteTmp where idConfig=" & intGl_idConfigPc & " and idProducto=" & v_idProducto) > 0 Then
            MessageBox.Show("Este producto ya se encuentra en la lista del descuento...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- llamar al formulario para cargar los datos
        Me.Visible = False

        frmCargarDescuentoEspecialGrupoCliente.txtNro.Text = 0
        frmCargarDescuentoEspecialGrupoCliente.txtIdDet.Text = 0
        frmCargarDescuentoEspecialGrupoCliente.txtCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        frmCargarDescuentoEspecialGrupoCliente.txtProducto.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmCargarDescuentoEspecialGrupoCliente.txtPrecio.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)
        frmCargarDescuentoEspecialGrupoCliente.txtPrecio.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPrecio.Text), "##,###,##0")
        tmpDouPrecio = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)

        tmpDouPorceContado = sp_datosTabla.consulta_valorDouble("select  [dbo].[funPorcentajeDescuentoGrupo](3,1," & v_idProducto & ")/100") * 100
        tmpDouPorceCredito = sp_datosTabla.consulta_valorDouble("select  [dbo].[funPorcentajeDescuentoGrupo](3,2," & v_idProducto & ")/100") * 100

        frmCargarDescuentoEspecialGrupoCliente.txtPorceContado.Text = tmpDouPorceContado
        frmCargarDescuentoEspecialGrupoCliente.txtPorceContado.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPorceContado.Text), "##0.##")
        frmCargarDescuentoEspecialGrupoCliente.txtPorceCredito.Text = tmpDouPorceCredito
        frmCargarDescuentoEspecialGrupoCliente.txtPorceCredito.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPorceCredito.Text), "##0.##")
        frmCargarDescuentoEspecialGrupoCliente.txtContadoMayo.Text = tmpDouPorceContado
        frmCargarDescuentoEspecialGrupoCliente.txtContadoMayo.Text = tmpDouPrecio - (tmpDouPrecio * (tmpDouPorceContado / 100))
        frmCargarDescuentoEspecialGrupoCliente.txtContadoMayo.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtContadoMayo.Text), "##,###,##0")
        frmCargarDescuentoEspecialGrupoCliente.txtCreditoMayo.Text = tmpDouPrecio - (tmpDouPrecio * (tmpDouPorceCredito / 100))
        frmCargarDescuentoEspecialGrupoCliente.txtCreditoMayo.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtCreditoMayo.Text), "##,###,##0")
        frmCargarDescuentoEspecialGrupoCliente.txtPrecioContado.Text = 0
        frmCargarDescuentoEspecialGrupoCliente.txtPrecioCredito.Text = 0
        frmCargarDescuentoEspecialGrupoCliente.Show()
        frmCargarDescuentoEspecialGrupoCliente.BringToFront()
        frmCargarDescuentoEspecialGrupoCliente.txtPrecioContado.Focus()
    End Sub
    '----------------------------------------------------------------------------
    '------------------'
    '-- LOS LISTVIEW --'
    '------------------'
    Private Sub lvStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvStock.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            If IsNumeric(txtBuscar.Text) Then
                txtBuscar.Text = ""
            End If
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdProducto.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvStock_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStock.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvStock.SelectedItems
            intGl_vtaIdProducto = item.SubItems(0).Text
            txtIdProducto.Text = item.SubItems(0).Text
        Next
    End Sub

    Private Sub lvStock_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStock.GotFocus
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvStock.SelectedItems
            intGl_vtaIdProducto = item.SubItems(0).Text
            txtIdProducto.Text = item.SubItems(0).Text
        Next
    End Sub
    '----------------------------------------------
    '-------------'
    '-- LOS TXT --'
    '-------------'
    Private Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        txtIdProducto.Text = 0
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '- si se ingreso en blanco, volver a cargar el listview y ordenar por nombre
                If txtBuscar.Text.Length > 0 Then
                    '-- controlar la primera letra ingresada
                    If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                        '-- controlar la manera de buscar
                        If (Trim(txtBuscar.Text).Length) = 6 Then
                            ' ordenar por el codigo del producto
                            listar_busqueda(" (codigo Like '" & txtBuscar.Text & "%' )" & "order by codigo")
                        Else
                            Dim intTmpIdProducto As Integer
                            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where codigoBarra='" & Trim(txtBuscar.Text) & "'")
                            'MsgBox("Valor de intTmpIdProducto  " & intTmpIdProducto)
                            If intTmpIdProducto > 0 Then
                                listar_busqueda(" (codigoBarra Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%' )" & "order by codigoBarra")
                            Else
                                '-- codigo de barra del sistema
                                Dim intTmpIdlote As Integer
                                '-- codigo de barra interno
                                '-- solo si el primer digito es igual a 1
                                If txtBuscar.Text.Substring(0, 1) = 1 Then
                                    'MsgBox("Valor del primer digito  " & txtBuscar.Text.Substring(0, 1))
                                    If Len(Trim(txtBuscar.Text)) = 12 Then
                                        '-- para los de 12 digitos
                                        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where idProducto=" & txtBuscar.Text.Substring(6, 5))

                                        'MsgBox("Valor de intTmpIdProducto " & intTmpIdProducto)
                                    End If
                                    If Len(Trim(txtBuscar.Text)) = 13 Then
                                        '-- para los de 13 digitos
                                        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where idProducto=" & txtBuscar.Text.Substring(7, 5))
                                    End If
                                    intTmpIdlote = txtBuscar.Text.Substring(1, 5)
                                    '********************************'
                                    '-- ARMAR EL LOTE DEL PRODUCTO --'
                                    '********************************
                                    If intTmpIdProducto > 0 Then
                                        colocarVenta(intTmpIdlote, intTmpIdProducto)
                                    End If
                                End If
                            End If

                        End If
                    Else
                        '--- busqueda por nombre de mercaderia
                        If chkTipo.Checked = True Then
                            '-- todos lo tipos
                            listar_busqueda(" (mercaderia Like '" & txtBuscar.Text & "%')" & " order by 3")
                        Else
                            '-- buscar por tipo de producto
                            listar_busqueda(" (mercaderia Like '" & txtBuscar.Text & "%') and idTipoProducto=" & cboTipoProducto.SelectedValue & " order by 3")
                        End If


                    End If
                End If
                e.Handled = True
                SendKeys.Send("{tab}")
                'lvStock.Select()
            End If
        End If
    End Sub
    '----------------'
    '-- FORMULARIO --'
    '----------------'  
    Private Sub frmStock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- ver de donde fue llamado el formulario
        e.Cancel = False
        '-- para venta de la farmacia1
        If banGl_ventaFarmacia1 = True Then
            banGl_ventaFarmacia1 = False

            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
        '-- para compra
        If banGl_compra = True Then
            banGl_compra = False

            frmCompras.Enabled = True
            frmCompras.Show()
            frmCompras.BringToFront()
            frmCompras.txtCantidad.Focus()
        End If
        '-- para la referencia de mercaderia el producto
        If bolGl_refMercaderias = True Then
            bolGl_refMercaderias = False

            frmReferenciarMercaderias.Enabled = True
            frmReferenciarMercaderias.Show()
            frmReferenciarMercaderias.BringToFront()
            frmReferenciarMercaderias.btnAgregar.Focus()
        End If
        If bolGl_refMercaderiasDetalle = True Then
            bolGl_refMercaderiasDetalle = False

            frmReferenciarMercaderias.Enabled = True
            frmReferenciarMercaderias.Show()
            frmReferenciarMercaderias.BringToFront()
            frmReferenciarMercaderias.btnAgregar.Focus()
        End If
        If banGl_seguimientoStock = True Then
            banGl_seguimientoStock = False

            frmSeguimientoStock.Enabled = True
            frmSeguimientoStock.Show()
            frmSeguimientoStock.BringToFront()
        End If
        If banGl_stockInicial = True Then
            banGl_stockInicial = False

            frmStockInicial.Enabled = True
            frmStockInicial.Show()
            frmStockInicial.BringToFront()
        End If
        If banGl_precioEntero = True Then
            banGl_precioEntero = False

            frmPrecioEntero.Enabled = True
            frmPrecioEntero.Show()
            frmPrecioEntero.BringToFront()
        End If
        If banGl_precioFraccion = True Then
            banGl_precioFraccion = False

            frmPrecioFraccion.Enabled = True
            frmPrecioFraccion.Show()
            frmPrecioFraccion.BringToFront()
        End If
        If banGl_generarCodigoBarraMercaderia = True Then
            banGl_generarCodigoBarraMercaderia = False

            frmGenerarCodigoBarraMercaderia.Enabled = True
            frmGenerarCodigoBarraMercaderia.Show()
            frmGenerarCodigoBarraMercaderia.BringToFront()
        End If
        If banGl_reporteMercaderiaGral = True Then
            banGl_reporteMercaderiaGral = False
            '-- reporte de mercaderias en gral.
            frmReporteMercaderiaGral.Enabled = True
            frmReporteMercaderiaGral.Show()
            frmReporteMercaderiaGral.BringToFront()
            frmReporteMercaderiaGral.btnConsultar.Focus()
        End If
        If banGl_reporteProductoCliente = True Then
            banGl_reporteProductoCliente = False
            '-- reporte de producto por cliente
            frmReporteClienteProducto.Enabled = True
            frmReporteClienteProducto.Show()
            frmReporteClienteProducto.BringToFront()
            frmReporteClienteProducto.btnConsultar.Focus()
        End If
        If banGl_modificaVence = True Then
            banGl_modificaVence = False
            '-- modificacion de vencimiento
            frmModificarVence.Enabled = True
            frmModificarVence.Show()
            frmModificarVence.BringToFront()
            frmModificarVence.btnAgregar.Focus()
        End If
        If banGl_estadisticaProveedor = True Then
            banGl_estadisticaProveedor = False
            '-- estadistica de proveedor
            frmEstadisticaProveedor.Enabled = True
            frmEstadisticaProveedor.Show()
            frmEstadisticaProveedor.BringToFront()
        End If
        If banGl_fraccionarMercaderia = True Then
            banGl_fraccionarMercaderia = False
            '-- fraccionar mercaderia
            frmFraccionarMercaderia.Enabled = True
            frmFraccionarMercaderia.Show()
            frmFraccionarMercaderia.BringToFront()
            frmFraccionarMercaderia.txtCantidad.Focus()
        End If
        If banGl_modificarFracionado = True Then
            banGl_modificarFracionado = False
            '-- modificar fraccion
            frmModificarFraccionado.Enabled = True
            frmModificarFraccionado.Show()
            frmModificarFraccionado.BringToFront()
            frmModificarFraccionado.txtCantidad.Focus()
        End If
        If banGl_masLoteReferencia = True Then
            banGl_masLoteReferencia = False
            '-- mas de un lote en la referencia de producto
            frmMasLoteReferencia.Enabled = True
            frmMasLoteReferencia.Show()
            frmMasLoteReferencia.BringToFront()
        End If
        If banGl_estadisticaCliente = True Then
            banGl_estadisticaCliente = False
            '-- estadistica por cliente
            frmEstadisticaClientes.Enabled = True
            frmEstadisticaClientes.Show()
            frmEstadisticaClientes.BringToFront()
            frmEstadisticaClientes.btnConsultar.Focus()
        End If
        If banGl_descuentoEspecial = True Then
            banGl_descuentoEspecial = False
            '-- descuento especial
            frmDescuentoEspecial.Enabled = True
            frmDescuentoEspecial.Show()
            frmDescuentoEspecial.BringToFront()
        End If
        If banGl_descuentoEspecialGrupoCliente = True Then
            banGl_descuentoEspecialGrupoCliente = False
            '-- descuento especial por grupo de cliente
            frmDescuentoEspecialGrupoCliente.Enabled = True
            frmDescuentoEspecialGrupoCliente.Show()
            frmDescuentoEspecialGrupoCliente.BringToFront()
        End If
    End Sub
    '---------------------------------------------------------
End Class