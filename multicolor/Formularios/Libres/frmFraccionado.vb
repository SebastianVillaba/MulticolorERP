Public Class frmFraccionado
    '***************'
    '-- VARIABLES --'
    '***************'
    Dim systemClass As New SystemClass
    Dim sp_stock As New sp_stock
    Dim sp_datosTabla As New sp_datosTabla
    Dim strNombreFraccion As String
    Dim douPrecioFraccion As Double
    '-- variables para cargar la venta
    Dim intNroVentaTmp As Integer
    Dim strCodigoTmp As String
    Dim strProductoTmp As String
    Dim strDescuentoTmp As String
    Dim intPorcentajeImpuestoTmp As Integer
    Dim strFormaTmp As String
    Dim strVencimientoTmp As String
    Dim intCantidadTmp As Integer
    Dim douPrecioTmp As Double
    Dim intPrecioDescuentoTmp As Integer
    Dim intSubtotalTmp As Integer
    Dim intIdLoteTmp As Integer
    Dim intIdStockTmp As Integer
    Dim bolDescuento As Boolean
    Dim douUltimoCosto As Double
    Dim intCantidad As Integer = 0


    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- inicializa
    Private Sub inicializar()
        txtRemi.Text = banGl_remisionSucursal
        txtIdForma.Text = 0
    End Sub

    '-- listar el fraccionamiento
    Public Sub listar_busqueda(ByVal v_idProducto As Integer)
        systemClass.SqlToLv(lvFraccionado, "exec sp_ProductoFraccionado " & v_idProducto)
        txtProducto.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        txtIdProducto.Text = v_idProducto
        txtRemi.Text = banGl_remisionSucursal

        lvFraccionado.Columns(0).Width = 0
        lvFraccionado.Columns(1).Width = 50
        lvFraccionado.Columns(2).Width = 80
        lvFraccionado.Columns(3).Width = 80
        lvFraccionado.Columns(4).Width = 0
        lvFraccionado.Columns(5).Width = 0
        lvFraccionado.Columns(6).Width = 0
        lvFraccionado.Columns(7).Width = 0

        lvFraccionado.Columns(1).Text = "Cant."
        lvFraccionado.Columns(2).Text = "Nombre Forma"
        lvFraccionado.Columns(3).Text = "Precio"
        lvFraccionado.Scrollable = True
    End Sub

    '-- controlar de que modulo viene la instruccion
    Private Sub controlarModulo()
        If banGl_ventaFarmacia1 = True Then
            '-- venta farmacia
            If banGl_ventaFarmacia1LoteStock = True Then
                'MsgBox("Entro a la venta con lote y stock")
                '-- sin pasar por el lote
                Dim intIdDepositoTemp As Integer = 0
                intIdDepositoTemp = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
                intIdLoteTmp = intGl_vtaIdLote
                '-- traer el idStock
                'MsgBox("Valor de idDeposito  " & intIdDepositoTemp)
                'MsgBox("Valor de idProducto  " & CInt(txtIdProducto.Text))
                'MsgBox("Valor de idLote  " & intIdLoteTmp)

                intIdStockTmp = sp_datosTabla.consulta_valor("select idStock from stock where iddeposito=" & intIdDepositoTemp & _
                " and idProducto=" & CInt(txtIdProducto.Text) & " and idLote=" & intIdLoteTmp)

                'MsgBox("Valor de idStock  " & intIdStockTmp)
                '-- cargar la venta
                '-- valores en la venta
                frmVentaFarmacia1.lblIdStock.Text = intIdStockTmp
                frmVentaFarmacia1.lblForma.Text = strNombreFraccion
                frmVentaFarmacia1.lblCantfrac.Text = intCantidad
                frmVentaFarmacia1.txtCantidad.Text = 1
                '----------------------------------------------------------------------
                Me.Close()
                banGl_ventaFarmacia1 = False
                frmVentaFarmacia1.Enabled = True
                frmVentaFarmacia1.Show()
                frmVentaFarmacia1.BringToFront()
                '-- foco en la cantidad
                frmVentaFarmacia1.txtCantidad.Focus()
            Else
                'MsgBox("Entro a la venta normal")
                '-- normal
                fraccionVentaFarmacia1()
            End If
        End If
        '---------------------------------------------------
        '---------------------------------------------------------
        If banGl_compra = True Then
            '-- compra
            fraccionCompraFarmacia()
        End If
        If banGl_ajustePositivoMercaderia = True Then
            '-- ajuste positivo de mercaderia
            ajustePositivoMercaderia(intGl_ajustePositivoIdProducto)
        End If
        If banGl_ajusteNegativoMercaderia = True Then
            '-- ajuste negativo de mercaderia
            ajusteNegativoMercaderia(intGl_ajusteNegativoIdProducto)
        End If
        If banGl_stockInicial = True Then
            '-- stock inicial
            stockInicial()
        End If
        If banGl_precioFraccion = True Then
            '-- precio fraccionado
            precioFraccion()
        End If
    End Sub

    '-- procedimiento para la venta de farmacia1
    Private Sub fraccionVentaFarmacia1()
        Dim intTmpIdProducto As Integer
        intTmpIdProducto = CInt(txtIdProducto.Text)
        '----------------------------------
        '-- controlar si tiene varios lotes
        '----------------------------------
        If sp_datosTabla.sp_integer("sp_totalLoteStock", CInt(txtIdProducto.Text) & "," & intGl_idSucursal) > 1 Then
            '-- para varios lotes
            Me.Close()
            banGl_ventaFarmacia1 = True

            '-- valores en la venta
            frmVentaFarmacia1.lblForma.Text = strNombreFraccion
            frmVentaFarmacia1.lblCantfrac.Text = intCantidad
            frmVentaFarmacia1.txtCantidad.Text = 1
            '----------------------------------------------------------------------
            frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", intTmpIdProducto)
            frmLote.listar_stockVencimiento(intGl_vtaIdProducto)
            frmLote.listar_busqueda(intTmpIdProducto, intGl_idSucursal)
            '-- ocultar las columnas
            'frmFraccionado.lvFraccionado.Columns(5).Width = 0
            frmLote.Visible = True
            frmLote.WindowState = FormWindowState.Normal
            frmLote.Show()
            frmLote.BringToFront()
        End If
        If sp_datosTabla.sp_integer("sp_totalLoteStock", intTmpIdProducto & "," & intGl_idSucursal) = 1 Then
            'MsgBox("Entro al procedimiento de igual a 1")
            '-- para un lote
            Dim intIdDepositoTemp As Integer = 0
            intIdDepositoTemp = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
            '-- traer el idlote
            intIdLoteTmp = sp_datosTabla.un_dato_integer_consulta("idlote", "stock", "idProducto= " & intTmpIdProducto & " and idDeposito=" & intIdDepositoTemp)
            '-- traer el idStock
            intIdStockTmp = sp_datosTabla.consulta_valor("select idStock from stock where idProducto=" & intTmpIdProducto & " and idDeposito=" & intIdDepositoTemp & " and cantidad > 0")
            '-- valores en la venta
            frmVentaFarmacia1.lblIdStock.Text = intIdStockTmp
            frmVentaFarmacia1.lblForma.Text = strNombreFraccion
            frmVentaFarmacia1.lblCantfrac.Text = intCantidad
            frmVentaFarmacia1.txtCantidad.Text = 1
            '----------------------------------------------------------------------
            Me.Close()
            banGl_ventaFarmacia1 = False
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
            '-- foco en la cantidad
            frmVentaFarmacia1.txtCantidad.Focus()
        End If
        If sp_datosTabla.sp_integer("sp_totalLoteStock", intTmpIdProducto & "," & intGl_idSucursal) = 0 Then
            MessageBox.Show("Esta mercaderia no cuenta con Stock Inicial", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '-- para ningun lote y stock
            intIdLoteTmp = 0
            intIdStockTmp = 0
            '-- valores en la venta
            frmVentaFarmacia1.lblIdStock.Text = 0
            frmVentaFarmacia1.lblForma.Text = strNombreFraccion
            frmVentaFarmacia1.lblCantfrac.Text = intCantidad
            '----------------------------------------------------------------------

            Me.Close()
            banGl_ventaFarmacia1 = False
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
            '-- foco en la cantidad
            frmVentaFarmacia1.txtCantidad.Focus()
        End If
    End Sub

    '-- procedimiento para el modulo de la compra
    Private Sub fraccionCompraFarmacia()
        ' bolGl_remisionSucursal = False
        '-- valores del fraccionamiento elegido
        frmCompras.txtFraccion.Text = strNombreFraccion
        frmCompras.lblPrecio.Text = douPrecioFraccion
        frmCompras.lblPrecio.Text = FormatNumber(frmCompras.lblPrecio.Text, "00,000,000.00")
        frmCompras.lblCantidad.Text = intCantidad
        '*******************************************************************************************
        '-- verificar el pedido
        productoPedidoAProveedor(CInt(txtIdProducto.Text), CInt(frmCompras.txtIDProveedor.Text))
        '*******************************************************************************************
        Me.Close()
        banGl_compra = False

        frmCompras.Enabled = True
        frmCompras.Show()
        frmCompras.BringToFront()
        If frmCompras.txtPorcentajeCosto.Enabled = False Then
            frmCompras.txtCantidad.Focus()
        Else
            frmCompras.txtPorcentajeCosto.Focus()
        End If
    End Sub

    '-- procedimiento para el modulo del ajuste positivo de mercaderias
    Private Sub ajustePositivoMercaderia(ByVal v_idproducto As Integer)
        '-- variables
        Dim intTmpIdLote As Integer
        Dim intTmpIdStock As Integer
        '-- los datos de la fraccion
        frmAjustePositivoMercaderia.txtFraccion.Text = strNombreFraccion
        frmAjustePositivoMercaderia.lblCantidad.Text = intCantidad
        frmAjustePositivoMercaderia.lblPrecio.Text = douPrecioFraccion
        'MsgBox("Valor de idProducto  " & v_idproducto)
        'MsgBox("Valor de idDeposito en el ajuste  " & frmAjustePositivoMercaderia.lblIdDeposito.Text)
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idproducto & "," & frmAjustePositivoMercaderia.lblIdDeposito.Text, 1) = 99 Then
            '-- para varios lotes
            Me.Close()
            banGl_ajustePositivoMercaderia = True

            frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", v_idproducto)
            frmLote.listar_busquedaTodosLotes(v_idproducto, intGl_ajustePositivoIdDeposito)
            '---------------------------------
            frmLote.Show()
            frmLote.BringToFront()
        End If
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idproducto & "," & frmAjustePositivoMercaderia.lblIdDeposito.Text, 0) > 0 Then
            '-- para un lote
            '*******************'
            '- datos del stock -'
            '*******************'
            '-- efectivamente tiene un solo lote en el stock
            '-- traer el idlote
            intTmpIdLote = sp_datosTabla.un_dato_integer_consulta("idlote", "stock", "idProducto=" & v_idproducto & " and idDeposito=" & frmAjustePositivoMercaderia.lblIdDeposito.Text)
            '-- traer el idStock
            intTmpIdStock = sp_datosTabla.un_dato_integer_consulta("idStock", "stock", "idProducto=" & v_idproducto & " and idDeposito=" & frmAjustePositivoMercaderia.lblIdDeposito.Text)
            '-- traer el idstock
            frmAjustePositivoMercaderia.lblIdStock.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idproducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & frmAjustePositivoMercaderia.lblIdDeposito.Text)
            '-- traer el stock
            frmAjustePositivoMercaderia.txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idproducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & frmAjustePositivoMercaderia.lblIdDeposito.Text))
            frmAjustePositivoMercaderia.txtStock.Text = Format(CDbl(frmAjustePositivoMercaderia.txtStock.Text), "##,##0.###")
            '-- traer 
            frmAjustePositivoMercaderia.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
            frmAjustePositivoMercaderia.maskVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
            '-- el precio del producto
            frmAjustePositivoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", v_idproducto)
            '-------------------------------------------------------------
            frmAjustePositivoMercaderia.btnAgregar.Enabled = True
            frmAjustePositivoMercaderia.txtCantidad.Focus()

            '-- volver al formulario del ajuste
            Me.Close()
            banGl_ajustePositivoMercaderia = False

            frmAjustePositivoMercaderia.Enabled = True
            frmAjustePositivoMercaderia.Show()
            frmAjustePositivoMercaderia.BringToFront()
            frmAjustePositivoMercaderia.txtCantidad.Focus()
        End If

        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idproducto & "," & frmAjustePositivoMercaderia.lblIdDeposito.Text, 1) = 0 Then
            '-- para ningun lote y stock
            MessageBox.Show("No cuenta con Stock Inicial esta mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '-- traer el idstock
            frmAjustePositivoMercaderia.lblIdStock.Text = 0
            '-- traer 
            frmAjustePositivoMercaderia.txtLote.Text = ""
            frmAjustePositivoMercaderia.maskVence.Text = ""
            '-- el precio del producto
            frmAjustePositivoMercaderia.lblPrecio.Text = 0
            '-------------------------------------------------------------
            frmAjustePositivoMercaderia.btnAgregar.Enabled = False
            frmAjustePositivoMercaderia.txtProducto.Focus()
            '-- volver al formulario del ajuste
            Me.Close()
            banGl_ajustePositivoMercaderia = False

            frmAjustePositivoMercaderia.Enabled = True
            frmAjustePositivoMercaderia.Show()
            frmAjustePositivoMercaderia.BringToFront()
            frmAjustePositivoMercaderia.txtCantidad.Focus()
        End If
    End Sub

    '-- procedimiento para el modulo del ajuste negativo de mercaderias
    Private Sub ajusteNegativoMercaderia(ByVal v_idproducto As Integer)
        '-- variables
        Dim intTmpIdLote As Integer
        Dim intTmpIdStock As Integer
        '-- los datos de la fraccion
        frmAjusteNegativoMercaderia.txtFraccion.Text = strNombreFraccion
        frmAjusteNegativoMercaderia.lblCantidad.Text = intCantidad
        frmAjusteNegativoMercaderia.lblPrecio.Text = douPrecioFraccion
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idproducto & "," & frmAjusteNegativoMercaderia.lblIdDeposito.Text, 1) = 99 Then
            '-- para varios lotes
            Me.Close()
            banGl_ajusteNegativoMercaderia = True

            frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", v_idproducto)
            frmLote.listar_busquedaTodosLotes(v_idproducto, intGl_ajusteNegativoIdDeposito)
            '-- ocultar las columnas
            'frmFraccionado.lvFraccionado.Columns(5).Width = 0
            '---------------------------------
            frmLote.Visible = True
            frmLote.WindowState = FormWindowState.Normal
            frmLote.Show()
            frmLote.BringToFront()
        End If
        'If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idproducto & "," & frmAjustePositivoMercaderia.lblIdDeposito.Text, 0) > 0 Then
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idproducto & "," & frmAjusteNegativoMercaderia.lblIdDeposito.Text, 0) > 0 Then
            '-- para un lote
            '*******************'
            '- datos del stock -'
            '*******************'
            '-- efectivamente tiene un solo lote en el stock
            '-- traer el idlote
            intTmpIdLote = sp_datosTabla.un_dato_integer_consulta("idlote", "stock", "idProducto=" & v_idproducto & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text)
            '-- traer el idStock
            intTmpIdStock = sp_datosTabla.un_dato_integer_consulta("idStock", "stock", "idProducto=" & v_idproducto & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text)
            'cargarAjusteNegativoMercaderia(intGl_nroAjusteNegativoMercaderia,
            '-- traer el idstock
            frmAjusteNegativoMercaderia.lblIdStock.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idproducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text)
            '-- traer el stock
            frmAjusteNegativoMercaderia.txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idproducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text))
            frmAjusteNegativoMercaderia.txtStock.Text = Format(CDbl(frmAjusteNegativoMercaderia.txtStock.Text), "##,##0.###")
            '-- traer 
            frmAjusteNegativoMercaderia.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
            frmAjusteNegativoMercaderia.maskVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
            '-- el precio del producto
            frmAjusteNegativoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", v_idproducto)
            '-------------------------------------------------------------
            frmAjusteNegativoMercaderia.btnAgregar.Enabled = True
            frmAjusteNegativoMercaderia.txtCantidad.Focus()


            '-- volver al formulario del ajuste
            Me.Close()
            banGl_ajusteNegativoMercaderia = False

            frmAjusteNegativoMercaderia.Enabled = True
            frmAjusteNegativoMercaderia.Show()
            frmAjusteNegativoMercaderia.BringToFront()
            frmAjusteNegativoMercaderia.txtCantidad.Focus()
        End If
        If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idproducto & "," & frmAjusteNegativoMercaderia.lblIdDeposito.Text, 1) = 0 Then
            '-- para ningun lote y stock
            MessageBox.Show("No cuenta con Stock Inicial esta mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '-- traer el idstock
            frmAjusteNegativoMercaderia.lblIdStock.Text = 0
            '-- traer 
            frmAjusteNegativoMercaderia.txtLote.Text = ""
            frmAjusteNegativoMercaderia.maskVence.Text = ""
            '-- el precio del producto
            frmAjusteNegativoMercaderia.lblPrecio.Text = 0
            '-------------------------------------------------------------
            frmAjusteNegativoMercaderia.btnAgregar.Enabled = False
            frmAjusteNegativoMercaderia.txtProducto.Focus()
            '-- volver al formulario del ajuste

            Me.Close()
            banGl_ajusteNegativoMercaderia = False

            frmAjusteNegativoMercaderia.Enabled = True
            frmAjusteNegativoMercaderia.Show()
            frmAjusteNegativoMercaderia.BringToFront()
            frmAjusteNegativoMercaderia.txtCantidad.Focus()
        End If
    End Sub

    '-- stock inicial
    Private Sub stockInicial()
        '-- los datos
        frmStockInicial.txtFraccion.Text = strNombreFraccion
        frmStockInicial.lblPrecio.Text = douPrecioFraccion
        '-------------------------
        Me.Close()
        banGl_stockInicial = False

        frmStockInicial.Enabled = True
        frmStockInicial.WindowState = FormWindowState.Normal
        frmStockInicial.Show()
        frmStockInicial.BringToFront()
        frmStockInicial.txtCantidad.Focus()
    End Sub

    '-- modificacion del precio del fraccionado
    Private Sub precioFraccion()
        '-- debe seleccionar la cantidad de entero
        frmPrecioFraccion.txtPrecioAnt.Text = douPrecioFraccion
        frmPrecioFraccion.txtPrecioAnt.Text = Format(CDec(frmPrecioFraccion.txtPrecioAnt.Text), "###,###,###.00")
        frmPrecioFraccion.lblCantidad.Text = intCantidad
        frmPrecioFraccion.lblForma.Text = strNombreFraccion

        Me.Close()
        banGl_precioFraccion = False

        frmPrecioFraccion.Enabled = True
        frmPrecioFraccion.Show()
        frmPrecioFraccion.BringToFront()
        frmPrecioFraccion.txtPrecio.Focus()
    End Sub

    '-------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvFraccionado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvFraccionado.KeyPress
        txtRemi.Text = banGl_remisionSucursal
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
            '-- las compras
            If banGl_compra = True Then
                ' MsgBox("Entro en la compra")
                banGl_compra = False
                frmCompras.Enabled = True
                frmCompras.Show()
                frmCompras.BringToFront()
            End If
            '-- precio fraccionado
            If banGl_precioFraccion = True Then
                'MsgBox("Entro en la remision a sucursales")
                banGl_precioFraccion = False
                frmPrecioFraccion.Enabled = True
                frmPrecioFraccion.Show()
                frmPrecioFraccion.BringToFront()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            If CInt(txtIdForma.Text) = 0 Then
                MessageBox.Show("Debe colocarse sobre el Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- insertar en la grilla los datos del producto}
            'MsgBox("Se presciono enter..!" & banGl_remisionSucursal, MsgBoxStyle.Information)
            controlarModulo()
        End If
    End Sub

    Private Sub lvFraccionado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFraccionado.SelectedIndexChanged
        If lvFraccionado.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In lvFraccionado.SelectedItems
                txtIdForma.Text = item.SubItems(0).Text

                ' bolGl_remisionSucursal = True

                strNombreFraccion = item.SubItems(2).Text
                douPrecioFraccion = CDbl(item.SubItems(3).Text)
                'MsgBox("Valor del precio  " & item.SubItems(3).Text)
                intCantidad = item.SubItems(1).Text
                'MsgBox("Valor de intCantidad  " & intCantidad)
                ' MsgBox("Valor de la bandera del modulo  " & bolGl_remisionSucursal, MsgBoxStyle.Information)
                '--------------------------------------------------'
                '- asignar variables de acuerdo al modulo llamado -'
                '--------------------------------------------------'
                If banGl_ventaFarmacia = True Then
                    bolDescuento = item.SubItems(6).Text
                    bolGl_vtaDescuento = item.SubItems(6).Text
                    '-- asignar a la variable global el precio de la fraccion
                    douGl_vtaPrecioProducto = item.SubItems(3).Text
                    strGl_vtaNombreFraccion = item.SubItems(2).Text
                End If
            Next
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------
End Class