Public Class frmLote
    '***************'
    '-- VARIABLES --'
    '***************'
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
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
    Dim bolDescuentoTmp As Boolean


    Dim intIdDeposito As Integer
    Dim datVencimiento As Date
    Dim intIdProducto As Integer
    '************************'
    '-- LOS PROCEDIMIENTOS --'
    '************************'
    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '- inicializar el formulario
    Private Sub inicializar()
        'lvStockSucursal.Columns(0).Width = 0
        '- colocar las columnas que seran visibles
        ' listar_busqueda("")
        ' MsgBox("Valor de la bandera del modulo  " & banGl_ventaHeladeria)
    End Sub

    '-- listar los lotes del producto por sucursal
    Public Sub listar_busqueda(ByVal v_idProducto As Integer, ByVal v_idSucursal As Integer)
        Try
            '-- valor a la variable
            intIdProducto = v_idProducto
            '-- la variable del deposito configurado para la venta
            Dim intIdDepositoVenta As Integer
            intIdDepositoVenta = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
            systemClass.SqlToLv_loteStock(lvStockSucursal, "sp_loteStockNuevo", v_idProducto & "," & v_idSucursal, intIdDepositoVenta)
            ' MsgBox("Paso por aca")
            'txtSql.Text = "exec sp_ProductoFraccionado " & v_idProducto
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '-- listar los lotes del producto por sucursal
    Public Sub listar_busquedaRemision(ByVal v_idProducto As Integer, ByVal v_idSucursal As Integer, ByVal v_idDeposito As Integer)
        Try
            '-- valor a la variable
            intIdProducto = v_idProducto
            '-- la variable del deposito configurado para la venta
            Dim intIdDepositoVenta As Integer
            intIdDepositoVenta = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
            systemClass.SqlToLv_loteStock(lvStockSucursal, "sp_loteStockNuevo ", v_idProducto & "," & v_idSucursal, v_idDeposito)
            'txtSql.Text = "exec sp_ProductoFraccionado " & v_idProducto
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub listar_stockVencimiento(ByVal v_idProducto As Integer)
        systemClass.SqlToLv_productoVencimientoSucursal(lvVenceSucursal, "sp_stockVencimientoSucursalConFechaCorta", v_idProducto)
    End Sub

    '-- listar por deposito
    Sub listar_busquedaDeposito(ByVal v_idProducto As Integer, ByVal v_idDeposito As Integer)
        '-- la variable del deposito configurado para la venta
        systemClass.SqlToLv_loteStock(lvStockSucursal, "sp_loteStockDepositoNuevo ", v_idProducto & "," & v_idDeposito, v_idDeposito)

    End Sub

    '-- listar todos los lotes
    Sub listar_busquedaTodosLotes(ByVal v_idProducto As Integer, ByVal v_idDeposito As Integer)
        '-- la variable del deposito configurado para la venta
        systemClass.SqlToLv_loteStock(lvStockSucursal, "sp_loteStockDepositoAjusteNuevo ", v_idProducto & "," & v_idDeposito, v_idDeposito)

    End Sub

    '-- listar todos los lotes que existen para ese producto
    Public Sub listar_todoLoteProducto(ByVal v_idProducto As Integer)
        '-- la variable del deposito configurado para la venta
        systemClass.SqlToLv_loteProductoGral(lvStockSucursal, "sp_loteStockGral ", v_idProducto)
    End Sub

    '-- controlar de que modulo fue llamada la instruccion
    Private Sub controlarModulo()
        'MsgBox("Valor de la bandera de seguimiento de stock  " & banGl_seguimientoStock)
        If banGl_ventaFarmacia1 = True Then
            '-- para la venta farmacia1
            loteVentaFarmacia1()
        End If
        '-----------------------------
        If banGl_seguimientoStock = True Then
            '-- para el seguimiento de stock
            seguimientoStock()
        End If
        If banGl_ajusteNegativoMercaderia = True Then
            '-- ajuste Negativo de mercaderias
            ajusteNegativoMercaderia(intGl_ajusteNegativoIdProducto)
        End If
        If banGl_ajustePositivoMercaderia = True Then
            '-- ajuste positivo de mercaderias
            ajustePositivoMercaderia(intGl_ajustePositivoIdProducto)
        End If
        If banGl_generarCodigoBarraMercaderia = True Then
            '-- generar codigo de barra para mercaderias
            generarCodigoBarraMercaderia()
        End If
        If banGl_modificaVence = True Then
            '-- modificacion de vencimientos
            modificacionVencimiento(intIdProducto)
        End If
    End Sub

    '-- venta de farmacia1
    Private Sub loteVentaFarmacia1()
        '-- valores en la venta
        frmVentaFarmacia1.lblIdStock.Text = intIdStockTmp

        '----------------------------------------------------------------------

        Me.Close()
        banGl_ventaFarmacia1 = False
        frmVentaFarmacia1.Enabled = True
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
        '-- foco en la columna de cantidad
        frmVentaFarmacia1.txtCantidad.Text = 1

        frmVentaFarmacia1.txtCantidad.Focus()
    End Sub

    '-- procedimiento para la remision de mercaderias a sucursales
    Private Sub lotePedidoMercaderiaSucursal()

    End Sub

    '-- para el seguimiento de stock
    Private Sub seguimientoStock()
        '-- las variables
        Dim intTmpIdLote As Integer
        Dim intTmpIdProducto As Integer
        intTmpIdLote = sp_datosTabla.un_dato_integer("idLote", "stock", "idStock", intIdStockTmp)
        '--------------------------'
        '-- datos de la cabecera --'
        '--------------------------'
        frmSeguimientoStock.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idlote", intTmpIdLote)
        frmSeguimientoStock.txtVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
        intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "stock", "idStock", intIdStockTmp)
        frmSeguimientoStock.txtCodigo.Text = sp_datosTabla.un_datoString("codigo", "producto", "idProducto", intTmpIdProducto)
        frmSeguimientoStock.txtMercaderia.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "producto", "idProducto", intTmpIdProducto)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "producto", "idProducto", intTmpIdProducto))

        '-- dar valor a la variable global del modulo
        intGl_idProductoSeguimientoStock = intTmpIdProducto
        intGl_idStockSeguimientoStock = intIdStockTmp

        ' frmRemisionMercaderia2.btnAgregar.Enabled = True
        Me.Close()
        frmSeguimientoStock.Enabled = True
        frmSeguimientoStock.Show()
        frmSeguimientoStock.BringToFront()
        frmSeguimientoStock.btnProcesar.Focus()
    End Sub

    '-- ajuste positivo de mercaderias
    Private Sub ajustePositivoMercaderia(ByVal v_idProducto As Integer)
        '-- traer el idlote
        Dim intTmpIdLote As Integer
        intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idstock=" & intIdStockTmp)
        'cargarAjusteNegativoMercaderia(intGl_nroAjusteNegativoMercaderia,
        '-- traer el idstock
        frmAjustePositivoMercaderia.lblIdStock.Text = intIdStockTmp
        '-- traer el stock
        frmAjustePositivoMercaderia.txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & intIdStockTmp)
        frmAjustePositivoMercaderia.txtStock.Text = Format(CDbl(frmAjustePositivoMercaderia.txtStock.Text), "##,##0.###")

        '-- traer 
        frmAjustePositivoMercaderia.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
        frmAjustePositivoMercaderia.maskVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
        '-- el precio del producto
        frmAjustePositivoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", v_idProducto)
        '-------------------------------------------------------------
        frmAjustePositivoMercaderia.btnAgregar.Enabled = True
        frmAjustePositivoMercaderia.txtCantidad.Focus()
        '-- volver al formulario del ajuste
        banGl_ajustePositivoMercaderia = False
        Me.Close()
        frmAjustePositivoMercaderia.Enabled = True
        frmAjustePositivoMercaderia.Show()
        frmAjustePositivoMercaderia.BringToFront()
        frmAjustePositivoMercaderia.txtCantidad.Focus()
    End Sub

    '-- ajuste negativo de mercaderias
    Private Sub ajusteNegativoMercaderia(ByVal v_idProducto As Integer)
        '-- traer el idlote
        Dim intTmpIdLote As Integer
        intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idstock=" & intIdStockTmp)
        'cargarAjusteNegativoMercaderia(intGl_nroAjusteNegativoMercaderia,
        '-- traer el idstock
        frmAjusteNegativoMercaderia.lblIdStock.Text = intIdStockTmp
        '-- traer el stock
        frmAjusteNegativoMercaderia.txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & intIdStockTmp)
        frmAjusteNegativoMercaderia.txtStock.Text = Format(CDbl(frmAjusteNegativoMercaderia.txtStock.Text), "##,##0.###")
        '-- traer 
        frmAjusteNegativoMercaderia.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
        frmAjusteNegativoMercaderia.maskVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
        '-- el precio del producto
        frmAjusteNegativoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", v_idProducto)
        '-------------------------------------------------------------
        frmAjusteNegativoMercaderia.btnAgregar.Enabled = True
        frmAjusteNegativoMercaderia.txtCantidad.Focus()
        '-- volver al formulario del ajuste
        banGl_ajusteNegativoMercaderia = False
        Me.Close()
        frmAjusteNegativoMercaderia.Enabled = True
        frmAjusteNegativoMercaderia.Show()
        frmAjusteNegativoMercaderia.BringToFront()
        frmAjusteNegativoMercaderia.txtCantidad.Focus()
    End Sub

    '-- generar codigo de barra mercaderidas
    Private Sub generarCodigoBarraMercaderia()
        '-- las variables
        Dim intTmpIdProducto As Integer
        Dim intTmpIdDeposito As Integer
        Dim intTmpIdLote As Integer

        Dim strTmpNombreMercaderia As String
        Dim strTmpCodigo As String
        Dim strTmpNombreDeposito As String
        Dim strTmpLote As String
        Dim strTmpVence As String

        '-- cargar las variables
        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from stock where idStock=" & intIdStockTmp)
        strTmpCodigo = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intTmpIdProducto)
        strTmpNombreMercaderia = sp_datosTabla.consulta_valorString("select nombreProducto from producto where idProducto=" & intTmpIdProducto)
        intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idStock=" & intIdStockTmp)
        strTmpLote = sp_datosTabla.consulta_valorString("select lote from lote where idLote=" & intTmpIdLote)
        strTmpVence = sp_datosTabla.consulta_valorString("select vencimiento from lote where idLote=" & intTmpIdLote)
        intTmpIdDeposito = sp_datosTabla.consulta_valor("select idDeposito from stock where idStock=" & intIdStockTmp)
        strTmpNombreDeposito = sp_datosTabla.consulta_valorString("select nombreDeposito from deposito where idDeposito=" & intTmpIdDeposito)
        '---- cargar la grilla
        intGl_nroGenerarCodigoBarraMercaderia = intGl_nroGenerarCodigoBarraMercaderia + 1
        cargarGenerarCodigoBarraMercaderia(intGl_nroGenerarCodigoBarraMercaderia, intTmpIdProducto, strTmpCodigo, strTmpNombreMercaderia, strTmpNombreDeposito, strTmpLote, strTmpVence, 1, intIdStockTmp)
        Me.Close()
        frmGenerarCodigoBarraMercaderia.Enabled = True
        frmGenerarCodigoBarraMercaderia.Show()
        frmGenerarCodigoBarraMercaderia.BringToFront()

        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Focus()
    End Sub

    '-- modificacion de vencimiento
    Private Sub modificacionVencimiento(ByVal v_idProducto As Integer)
        '-- traer el idlote
        Dim intTmpIdLote As Integer
        intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idstock=" & intIdStockTmp)
        'MsgBox("Valor de idStock  " & intIdStockTmp)
        'MsgBox("Valor de idLote  " & intTmpIdLote)
        'cargarAjusteNegativoMercaderia(intGl_nroAjusteNegativoMercaderia,
        '-- traer el idstock
        frmModificarVence.lblIdStock1.Text = intIdStockTmp
        '-- traer el stock
        frmModificarVence.txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & intIdStockTmp)
        frmModificarVence.txtStock.Text = Format(CDbl(frmModificarVence.txtStock.Text), "##,##0.##")
        '-- traer 
        frmModificarVence.txtLote1.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
        frmModificarVence.maskVence1.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)

        '-------------------------------------------------------------
        frmModificarVence.habilitarObjetos()
        frmModificarVence.txtCantidad.Text = 1

        banGl_modificaVence = False
        Me.Close()
        frmModificarVence.Enabled = True
        frmModificarVence.Show()
        frmModificarVence.BringToFront()
        frmModificarVence.txtLote2.Focus()
    End Sub

    '-------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS LISTVIEW --'
    '******************'
    Private Sub lvStockSucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvStockSucursal.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            'salir del sistema

        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- para la remision de mercaderia controlar que sea del deposito adecuado
            If banGl_remisionSucursal = True Then
                'MsgBox("Valor de idDeposito  " & intIdDeposito)
                If intIdDeposito <> (sp_datosTabla.consulta_valor("Select idDepositoRemision from configPc where idConfig=" & intGl_idConfigPc)) Then
                    MessageBox.Show("Este Deposito no está configurado para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvStockSucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStockSucursal.SelectedIndexChanged
        For Each item As ListViewItem In lvStockSucursal.SelectedItems
            strVencimientoTmp = item.SubItems(1).Text
            datVencimiento = item.SubItems(1).Text
            intIdStockTmp = CInt(item.SubItems(5).Text)
            intIdDeposito = CInt(item.SubItems(6).Text)
            If banGl_descuentoFechaCorta = True Then
                intIdProducto = CInt(item.SubItems(6).Text)
            Else
                intIdProducto = sp_datosTabla.consulta_valor("select idProducto from stock where idStock=" & intIdStockTmp)
            End If

            'MsgBox("Valor de vencimiento " & datVencimiento)
            'MsgBox("Valor del indice   " & item.SubItems(1).Text)
        Next
    End Sub

    Private Sub lvStockSucursal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStockSucursal.GotFocus
        'Try
        '    strVencimientoTmp = lvStockSucursal.Items(1).Text
        '    intIdStockTmp = CInt(lvStockSucursal.Items(4).Text)
        'Catch ex As Exception
        '    System.Console.WriteLine(ex.Message.ToString)
        '    MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        'System.Console.ReadLine()
        'MsgBox("Valor de lvStockSucursal.Items(0).Text)  " & lvStockSucursal.Items(0).Text)
        'MsgBox("Valor de lvStockSucursal.Items(1).Text)  " & lvStockSucursal.Items(1).Text)
        'MsgBox("Valor de lvStockSucursal.Items(2).Text)  " & lvStockSucursal.Items(2).Text)
        'MsgBox("Valor de lvStockSucursal.Items(3).Text)  " & lvStockSucursal.Items(3).Text)
        'MsgBox("Valor de lvStockSucursal.Items(4).Text)  " & lvStockSucursal.Items(4).Text)
    End Sub
    '-------------------------------------------------------------------------------------------------------
End Class