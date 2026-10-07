Public Class frmVentaHeladeria
    '****************************'
    '--  VARIABLES TIPO OBJETO --'
    '****************************'
    Dim monedaSistema As New moneda
    Dim systemClass As New SystemClass
    Dim sp_cliente As New sp_cliente
    Dim sp_datosTabla As New sp_datosTabla
    Dim tarjetaDebito As New tarjetaDebito
    Dim tarjetaCredito As New tarjetaCredito
    Dim tipoventa As New tipoVenta
    Dim sp_controlarTimbrado As New sp_controlarTimbrado
    Private grupoCliente As New grupoCliente
    '*************************'
    '-- VARIABLES ESCALARES --'
    '*************************'
    Dim strCodigoProducto As String
    Dim strMercaderia As String
    Dim strDescuento As String
    Dim intPorcentajeIva As Int16
    Dim strForma As String
    Dim dtVence As Date
    Dim douCantidad As Double
    Dim intPrecio As Integer
    Dim intPrecioDescuento As Integer
    Dim intSubtotal As Integer
    Dim douTotalDescuento As Double = 0
    Dim intNroItem As Integer = 0
    '-- variables para los valores de la tabla de cotizacion
    Dim douSubtotalMoneda As Double = 0
    Dim douDescuentoMoneda As Double = 0
    Dim douTotalMoneda As Double = 0
    '-- variables para el datagrid de la venta
    Dim douSubtotalGrilla As Double
    Dim intContadorRegistros As Integer
    '-- bandera de error de guardar
    Dim bolErrorGuardar As Boolean = False
    '--------------------------------------------------------------------------------------------------------------------
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub inicializar()
        '-- colocar el codigo de venta por puesto y actualizar
        'sp_datosTabla.sp_string("sp_updCodigoVenta", "''")
        'lblCodigoVenta.Text = sp_datosTabla.consulta_valor("select codigoVenta from codigoVenta")
        '-- colocar el idDeposito de la Venta
        txtIdDeposito.Text = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
        '-- colocar la sucursal y el deposito donde opera la pc
        txtNombreSucursal.Text = Trim(sp_datosTabla.un_datoString("nombreFantasia", "v_sucursal", "idSucursal", intGl_idSucursal)) & " / " & Trim(sp_datosTabla.un_datoString("nombreDeposito", "deposito", "idDeposito", txtIdDeposito.Text))
        'listar_busqueda("")
        limpiar()
        '-- habilitar el boton de agregar a cuenta si es un hotel
        If sp_datosTabla.consulta_valorBoolean("select hoteleria from v_sucursal where idSucursal=" & intGl_idSucursal) = True Then
            btnHabitacion.Enabled = True
        Else
            btnHabitacion.Enabled = False
        End If
        grPuntaje.Visible = False
        '-- eliminar la tabla temporal de promocion
        sp_datosTabla.consulta_valor("delete from detVentaPromoTmp where idConfig=" & intGl_idConfigPc)
        sp_datosTabla.consulta_valor("delete from detVentaPromoSamsungTmp where idConfig=" & intGl_idConfigPc)

        '-- SI TIENE ACTIVO LA PROMO DE SAMSUNG CLUB
        'btnSamsung.Enabled = sp_datosTabla.consulta_valorBoolean("select [dbo].[funPromoSamsungHabilitado](" & intGl_idSucursal & "," & cboTipoVenta.SelectedValue & ")")
        'valorde del combo
    End Sub

    Public Sub limpiar()
        '-- limpiar la tabla temporal de la venta
        'sp_datosTabla.sp_string("sp_limpiarDetventaTmp", "''")
        '--- datos del cliente configurado como primero en ventas
        txtIdCliente.Text = sp_cliente.cliente_primero(1)
        txtRucCliente.Text = sp_cliente.cliente_primero(2)
        txtCliente.Text = sp_cliente.cliente_primero(3)
        txtGrupoCliente.Text = sp_cliente.cliente_primero(4)

        '-- eliminar la tabla temporal de promocion
        sp_datosTabla.consulta_valor("delete from detVentaPromoTmp where idConfig=" & intGl_idConfigPc)
        'valorde del combo

        '-- el total acumulado del cliente
        puntajeClienteVenta(sp_cliente.cliente_primero(1))

        '-- cerear los txt de los totales y sus formatos
        txtTotalDescuento.Text = 0
        txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,###.00")
        txtTotalIva.Text = 0
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,###.00")
        txtTotalVenta.Text = 0
        txtTotalVenta.Text = Format(CDec(txtTotalVenta.Text), "###,###,###.00")
        txtIva10.Text = 0
        txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,###.00")
        txtIva5.Text = 0
        txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,###.00")
        txtConta.Text = 0

        '-- valor a la variable publica de nro
        intGl_nroVentaHeladeria = 0
        '-- limpiar la grilla
        dtgVenta.Rows.Clear()
        '-- borar la tabla temporal que corresponde a este puesto
        'sp_datosTabla.consulta_valor("delete detVentaTmp where idConfig=" & intGl_idConfigPc & " and codigoVenta=" & CInt(lblCodigoVenta.Text))
        '-- volver a sumer los totales
        sumarTotales()
        '-- la tabla de la cotizacion
        '-- los parametros
        douSubtotalMoneda = 0
        douDescuentoMoneda = douTotalDescuento
        douTotalMoneda = intGl_vtaHeladeriaTotalVenta

        'listar_tablaCotizacion()

        '-- colocar la cantidad predeterminada
        txtCantidad.Text = 1

        '-- datos sobre la forma de venta
        'grupoCliente.ListarGrupoCliente(cboGrupoCliente)
        tipoventa.ListarTipoVenta(cboTipoVenta)
        cboTipoVenta.SelectedValue = sp_datosTabla.un_dato_integer("idTipoVenta", "v_tipoVenta", "idTipoVenta", sp_datosTabla.un_dato_integer("idTipoVenta", "v_tipoventa", "primero", "1"))
        '-- los txt de los datos del producto
        txtStockProducto.Text = 0
        '-- tipo de venta
        txtIdTipoventa.Text = 0
        txtTipoventaNombre.Text = "VENTA NORMAL"
        txtTipoventaNombre.BackColor = Color.DodgerBlue
        '-- colocar el foco en buscar
        txtBuscar.Text = ""
        txtBuscar.Focus()
    End Sub

    '-- procedimiento para obtener el puntaje del cliente
    Public Sub puntajeClienteVenta(ByVal v_idCliente As Integer)
        lblPuntaje.Text = sp_datosTabla.sp_traerValorInteger("sp_totalPuntajeCliente", v_idCliente, 0)
        lblPuntaje.Text = Format(CDec(lblPuntaje.Text), "###,###,##0")

        '-- puntaje utilizado
        grPuntaje.Visible = True
        lblPuntajeAcumulado.Text = 0
        '-- listar los premios de cliente
        systemClass.SqlToLv_tablaPuntajeCliente(lvPremio, "sp_consultaPremioCliente", v_idCliente)
        '-- activar el teclado de entrega de premios
        If sp_datosTabla.sp_traerValorInteger("sp_consultaPremioClienteNuevo", v_idCliente & "," & intGl_idSucursal, 0) > 0 Then
            btnPremio.Enabled = True
        Else
            btnPremio.Enabled = False
        End If

    End Sub

    '-- actualizar los totales
    Public Sub sumarTotales()
        '-- variables
        Dim intTmpContador As Integer
        Dim douTmpTotalIVa5 As Double
        Dim douTmpTotalIva10 As Double
        Dim intTmpIdGrupoCliente As Integer
        Dim intTmpPrecioDescuento As Integer
        Dim douTmpPorcentajeDescuento As Double
        Dim intTmpPrecio As Integer

        '-- sumar los totales
        intGl_vtaHeladeriaTotalVenta = 0
        intGl_vtaHeladeriaTotalDescuento = 0
        douTotalDescuento = 0
        intTmpIdGrupoCliente = sp_datosTabla.consulta_valor("select idGrupoCliente from cliente where idCliente=" & txtIdCliente.Text)
        If dtgVenta.Rows.Count > 0 Then
            For i As Integer = 0 To dtgVenta.Rows.Count - 1
                '-- las variables 
                Dim intIdProductoTmp As Integer = 0
                '-- realizar los calculos solo si existem items cargados
                If dtgVenta.Rows(i).Cells(0).Value > 0 Then

                    '-- el contador
                    intTmpContador = intTmpContador + 1

                    'intGl_nroVenta = intGl_nroVenta + 1
                    'dtgVenta.Rows(intGl_nroVenta - 1).Cells(0).Value = intGl_nroVenta

                    '-- sacar el idProducto de cada registro
                    intIdProductoTmp = sp_datosTabla.consulta_valor("select idProducto from producto where codigo='" & dtgVenta.Rows(i).Cells(1).Value & "'")
                    '-- columna de descuento
                    '--------------------------'
                    '-- colocar el descuento --'
                    '--------------------------'
                    If sp_datosTabla.consulta_valor("select idProducto from producto where idTipoProducto=147 and idProducto=" & _
                                                    CInt(dtgVenta.Rows(i).Cells(10).Value)) > 0 And sp_datosTabla.consulta_valor("select idConfig from detVentaPromoTmp " & _
                                                                                                    " where idConfig=" & intGl_idConfigPc & " and idCliente=" & CInt(txtIdCliente.Text)) Then
                        '-----------------------'
                        '-- PROMOCION SAMSUNG --'
                        '-----------------------'
                        grPromo.Visible = True
                        lblNroSocio.Text = sp_datosTabla.consulta_valor("select nroSocio from detVentaPromoTmp where idConfig=" & intGl_idConfigPc)
                        lblIdCanje.Text = sp_datosTabla.consulta_valor("select idCanje from detVentaPromoTmp where idConfig=" & intGl_idConfigPc)

                        intTmpPrecio = CInt(dtgVenta.Rows(i).Cells(6).Value)
                        douTmpPorcentajeDescuento = 20
                        intTmpPrecioDescuento = intTmpPrecio - (intTmpPrecio * (douTmpPorcentajeDescuento / 100))
                        '-- con descuento
                        douTotalDescuento = douTotalDescuento + (intTmpPrecio - intTmpPrecioDescuento)
                    Else
                        grPromo.Visible = False

                        If sp_datosTabla.sp_traerValorInteger("sp_descuentoPrecioSucursal", intIdProductoTmp & "," & intGl_idSucursal, 0) = 0 Then
                            '---- sin precio de descuento por sucursal
                            If CBool(dtgVenta.Rows(i).Cells(12).Value) = False Then
                                '-- sumar si no es un premio
                                intTmpPrecio = CInt(dtgVenta.Rows(i).Cells(6).Value)
                                douTmpPorcentajeDescuento = sp_datosTabla.consulta_valorDouble("select [maxifarmasa].dbo.[funPorcentajeDescuentoVenta](" & intTmpIdGrupoCliente & _
                                                                                     "," & CInt(cboTipoVenta.SelectedValue) & "," & txtIdTipoventa.Text & _
                                                                                     "," & intIdProductoTmp & "," & 1 & "," & intGl_idConfigPc & "," & CInt(dtgVenta.Rows(i).Cells(9).Value) & ")")
                                intTmpPrecioDescuento = intTmpPrecio - (intTmpPrecio * (douTmpPorcentajeDescuento / 100))
                                '-- con descuento
                                douTotalDescuento = douTotalDescuento + (intTmpPrecio - intTmpPrecioDescuento)
                            End If
                        Else
                            '--- precio sucursal 
                            intTmpPrecio = sp_datosTabla.consulta_valor("select precio from producto where idProducto=" & intIdProductoTmp)
                            intTmpPrecioDescuento = sp_datosTabla.consulta_valor("select dp.precioDescuento from cabPrecioSucursal cp inner join detPrecioSucursal dp on cp.idPrecioSucursal=dp.idPrecioSucursal " & _
                                                                        " where cp.idSucursal=" & intGl_idSucursal & " and dp.idProducto=" & intIdProductoTmp)
                            '-- con descuento
                            douTotalDescuento = douTotalDescuento + (intTmpPrecio - intTmpPrecioDescuento)
                        End If
                    End If




                    '-----------------------------------------'
                    '--- remplazar los valores de la grilla --'
                    '-----------------------------------------'
                    dtgVenta.Rows(i).Cells(7).Value = intTmpPrecioDescuento
                    dtgVenta.Rows(i).Cells(8).Value = intTmpPrecioDescuento * dtgVenta.Rows(i).Cells(5).Value

                    If CBool(dtgVenta.Rows(i).Cells(12).Value) = False Then
                        '-- sumar si no es un premio
                        '-- sumar y dar valor al IVA
                        If dtgVenta.Rows(i).Cells(3).Value > 0 Then
                            If dtgVenta.Rows(i).Cells(3).Value = 5 Then
                                '-- IVA 5
                                douTmpTotalIVa5 = douTmpTotalIVa5 + (dtgVenta.Rows(i).Cells(8).Value / 21)
                            End If
                            If dtgVenta.Rows(i).Cells(3).Value = 10 Then
                                '-- IVA 10
                                douTmpTotalIva10 = douTmpTotalIva10 + (dtgVenta.Rows(i).Cells(8).Value / 11)
                            End If
                        End If
                        '-- columna de subtotal
                        intGl_vtaHeladeriaTotalVenta = intGl_vtaHeladeriaTotalVenta + dtgVenta.Rows(i).Cells(8).Value
                    End If
                End If
            Next
        End If
        txtTotalVenta.Text = intGl_vtaHeladeriaTotalVenta
        txtTotalVenta.Text = Format(CDec(txtTotalVenta.Text), "###,###,##0")
        txtTotalDescuento.Text = douTotalDescuento
        txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,##0")
        '-- el Impuesto
        txtIva10.Text = douTmpTotalIva10
        txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,##0")
        txtIva5.Text = douTmpTotalIVa5
        txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,##0")
        txtTotalIva.Text = douTmpTotalIva10 + douTmpTotalIVa5
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,##0")
        '-- actualizar la tabla de las cotizaciones
        douDescuentoMoneda = douTotalDescuento
        douTotalMoneda = intGl_vtaHeladeriaTotalVenta
        '-- colocar la cantidad por defecto a 1
        txtCantidad.Text = 1

        '-----------------------------------------'
        '-- CONTROLAR EL TIMBRADO DE LA FACTURA --'
        '-----------------------------------------'
        If sp_controlarTimbrado.controlar_timbrado(intGl_idSucursal) = True Then
            Dim intTmpIdFactura As Integer

            If sp_datosTabla.consulta_valor("select idSucursal from v_sucursal where FE=1 and idSucursal=" & intGl_idSucursal) > 0 Then
                '-- para las facturas electronicas
                intTmpIdFactura = sp_datosTabla.consulta_valor("select idDetFacturaFac from configPc where idConfig=" & intGl_idConfigPc)

                txtDcaja.Text = sp_datosTabla.consulta_valorString("select dcaja from detFacturaDE where idDetFacturaDE=" & intTmpIdFactura)
                txtDsuc.Text = sp_datosTabla.consulta_valorString("select dsuc from detFacturaDE where idDetFacturaDE=" & intTmpIdFactura)
                txtNroFacturaSgte.Text = sp_datosTabla.consulta_valor("select nroFactura+1 from detFacturaDE where idDetFacturaDE=" & intTmpIdFactura)
            Else
                '-- para las facturas comunes
                intTmpIdFactura = sp_datosTabla.consulta_valor("select idFactura from configPc where idConfig=" & intGl_idConfigPc)

                txtDcaja.Text = sp_datosTabla.consulta_valorString("select dcaja from factura where idFactura=" & intTmpIdFactura)
                txtDsuc.Text = sp_datosTabla.consulta_valorString("select dsuc from factura where idFactura=" & intTmpIdFactura)
                txtNroFacturaSgte.Text = sp_datosTabla.consulta_valor("select nroFacturaSgte+1 from factura where idFactura=" & intTmpIdFactura)
            End If


            '-- colocar los 0 antes de la factura
            Dim intTotalFactura As Integer = txtNroFacturaSgte.Text.Length
            '-- para 000000
            If intTotalFactura = 1 Then
                txtNroFacturaSgte.Text = "000000" & txtNroFacturaSgte.Text
            End If
            '-- para 00000
            If intTotalFactura = 2 Then
                txtNroFacturaSgte.Text = "00000" & txtNroFacturaSgte.Text
            End If
            '-- para 0000
            If intTotalFactura = 3 Then
                txtNroFacturaSgte.Text = "0000" & txtNroFacturaSgte.Text
            End If
            '-- para 000
            If intTotalFactura = 4 Then
                txtNroFacturaSgte.Text = "000" & txtNroFacturaSgte.Text
            End If
            '-- para 00
            If intTotalFactura = 5 Then
                txtNroFacturaSgte.Text = "00" & txtNroFacturaSgte.Text
            End If
            '-- para 0
            If intTotalFactura = 6 Then
                txtNroFacturaSgte.Text = "0" & txtNroFacturaSgte.Text
            End If
        Else
            txtDcaja.Text = ""
            txtDsuc.Text = ""
            txtNroFacturaSgte.Text = ""
        End If

        listar_tablaCotizacion()
    End Sub

    '-- actualizar la tabla de las cotizaciones
    Sub listar_tablaCotizacion()
        systemClass.SqlToLv_tablaCotizacion(lvMoneda, "sp_tablaCotizacion", intGl_idEntidad & "," & douSubtotalMoneda & "," & douDescuentoMoneda & "," & douTotalMoneda)
    End Sub

    '-- buscar el producto
    Private Sub buscarProducto(ByVal v_codigoIngresado As String)
        bolGl_comboEstudiante = False
        '-- buscar por el codigo del producto
        '-- varibles
        Dim intTmpIdProducto As Integer = 0
        Dim intTmpIdLote As Integer
        'Dim intTmpidSucursal As Integer
        Dim strTmpCodigoBarra As String
        Dim intTmpLongitudCodigo As Integer
        Dim intTmpIdStock As Integer
        Dim strTmpForma As String = "ENTERO"
        Dim intTmpCodigoCombo As Integer
        '-- activar la varibale global de este modulo
        'banGl_ventaHeladeria = True
        If Len(v_codigoIngresado) = 1 Then
            Exit Sub
        End If

        '-- solo si se ingresa un numero en el segundo caracter
        If IsNumeric(v_codigoIngresado.Substring(1, 1)) Then
            'MsgBox("Paso 1")
            If Not IsNumeric(v_codigoIngresado.Substring(0, 1)) Then
                'MsgBox("Paso por el no numerico")
                If v_codigoIngresado.Substring(0, 1) = "-" And Len(v_codigoIngresado) = 1 Then
                    'MsgBox("Pasa por eliminar todo")
                    txtBuscar.Text = ""
                    dtgVenta.Rows.Clear()
                    intGl_nroVentaHeladeria = 0
                    sumarTotales()
                    Exit Sub
                End If

                '*******************'
                '-- ELIMINAR ITEM --'
                '*******************'
                If v_codigoIngresado.Substring(0, 1) = "-" And Len(v_codigoIngresado.Substring(1, 1)) > 0 Then
                    'MsgBox("Pasa por -")
                    '-- eliminar todo
                    If v_codigoIngresado.Substring(1, 1) = 0 Then
                        limpiar()
                        Exit Sub
                    End If
                    '-- eliminar item
                    Dim intTmpValor As Integer
                    intTmpLongitudCodigo = Len(v_codigoIngresado)
                    intTmpValor = CInt(v_codigoIngresado.Substring(1, intTmpLongitudCodigo - 1))
                    'MsgBox("Valor de intTmpValor  " & intTmpValor)
                    intGl_nroVentaHeladeria = 0
                    'MsgBox("Valor de la fila del dataGrid  " & dtgVenta.SelectedCells.Count)
                    Dim bolTmpEncontro As Boolean = False
                    For i As Integer = 0 To dtgVenta.Rows.Count - 1
                        If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                            If dtgVenta.Rows(i).Cells(0).Value = (intTmpValor) Then

                                If CBool(dtgVenta.Rows(i).Cells(0).Value) = True Then
                                    '-- evitar eliminar item de los premios
                                    MessageBox.Show("No puede eliminar un item del Premio..! debe salir de venta y volver a ingresar y realizar de vuelta todo el procedimiento..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If

                                bolTmpEncontro = True
                            End If
                        End If
                    Next
                    If bolTmpEncontro = True Then
                        dtgVenta.Rows.RemoveAt(intTmpValor - 1)
                        sumarTotales()
                        For i As Integer = 0 To dtgVenta.Rows.Count - 1
                            If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                                intGl_nroVentaHeladeria = intGl_nroVentaHeladeria + 1
                                'MsgBox("Valor de intGl_nroVentaHeladeria  " & intGl_nroVentaHeladeria)
                                'If intGl_nroVentaHeladeria > 0 Then
                                dtgVenta.Rows(i).Cells(0).Value = intGl_nroVentaHeladeria
                                'End If
                            End If
                        Next
                        '-- limpiar el campo
                        txtBuscar.Text = ""
                        Exit Sub
                    Else
                        MessageBox.Show("El numero fila ingresado no existe en la Grilla..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtBuscar.Text = ""
                        Exit Sub
                    End If
                End If
                '*************************'
                '-- COLOCAR LA CANTIDAD --'
                '*************************'
                'MsgBox("Valor de primer digito  " & v_codigoIngresado.Substring(0, 1))
                'MsgBox("Valor de la longitud del segundo digito  " & Len(v_codigoIngresado.Substring(1, 1)))

                If v_codigoIngresado.Substring(0, 1) = "+" And Len(v_codigoIngresado.Substring(1, 1)) > 0 Then
                    ' MsgBox("Pasa por +")
                    Dim douTmpValor As Double
                    intTmpLongitudCodigo = Len(v_codigoIngresado)
                    douTmpValor = CDbl(v_codigoIngresado.Substring(1, intTmpLongitudCodigo - 1))
                    'MsgBox("Valor ingresado  " & douTmpValor)
                    txtCantidad.Text = douTmpValor
                    txtBuscar.Text = ""
                    Exit Sub
                End If

                '*********************************'
                '-- COLOCAR EL COMBO ESTUDIANTE --'
                '*********************************'
                If v_codigoIngresado.Substring(0, 1) = "/" And Len(v_codigoIngresado.Substring(1, 1)) > 0 Then
                    ' MsgBox("Pasa por +")
                    intTmpLongitudCodigo = Len(v_codigoIngresado)
                    intTmpCodigoCombo = CDbl(v_codigoIngresado.Substring(1, intTmpLongitudCodigo - 1))
                    '-- buscar si existe el codigo ingresado
                    intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from codigoComboEstudiante where codigoComboEstudiante=" & intTmpCodigoCombo)
                    If intTmpIdProducto = 0 Then
                        MessageBox.Show("El codigo ingresado del combo no existe..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    '-- verificar si ya fue entregado
                    If sp_datosTabla.consulta_valor("select idProducto from codigoComboEstudiante where entregado=1 and codigoComboEstudiante=" & intTmpCodigoCombo) > 0 Then
                        MessageBox.Show("El helado ya ha sido entregado con este codigo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    '-- verificar si la venta está anulada
                    If sp_datosTabla.consulta_valor("select idProducto from codigoComboEstudiante ce inner join cabVenta cv on ce.idVenta=cv.idVenta where cv.activo=0 and codigoComboEstudiante=" & intTmpCodigoCombo) > 0 Then
                        MessageBox.Show("La venta con este codigo ha sido anulada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    '-- activar la bandera de combo estudiante
                    bolGl_comboEstudiante = True

                End If

                '--------------------------- FIN DEL COMBO ESTUDIANTE ---------------------------------
                '*************************************'
                '-- BUSCAR POR EL PRODUCTO POR EL * --'
                '*************************************'
                'MsgBox("Valor v_codigoIngresado.Substring(0, 1)  " & v_codigoIngresado.Substring(0, 1))
                'MsgBox("Valor Len(v_codigoIngresado.Substring(1, 0))  " & Len(v_codigoIngresado.Substring(1, 0)))
                If v_codigoIngresado.Substring(0, 1) = "*" And Len(v_codigoIngresado) > 1 Then
                    '-- verificar si ya existe un premio en la grilla
                    If dtgVenta.Rows.Count > 0 Then
                        For i As Integer = 0 To dtgVenta.Rows.Count - 1
                            If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                                If dtgVenta.Rows(i).Cells(12).Value = True Then
                                    MessageBox.Show("Existe un Premio cargado en la Venta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If

                    'MsgBox("Paso por *")
                    '-- buscar por presentacion
                    intTmpLongitudCodigo = Len(v_codigoIngresado)
                    intTmpLongitudCodigo = Len(v_codigoIngresado.Substring(1, intTmpLongitudCodigo - 1))
                    'MsgBox("Entro por aca ..!")
                    intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where idFamilia <> 1 and presentacion=" & "'" & v_codigoIngresado.Substring(1, intTmpLongitudCodigo) & "'")
                    'intTmpIdProducto = CInt(sp_datosTabla.un_datoString("idProducto", "v_producto", "presentacion", v_codigoIngresado.Substring(1, intTmpLongitudCodigo)))
                End If
            Else
                'MsgBox("Paso 2")
                '-- verificar si ya existe un premio en la grilla
                If dtgVenta.Rows.Count > 0 Then
                    For i As Integer = 0 To dtgVenta.Rows.Count - 1
                        If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                            If dtgVenta.Rows(i).Cells(12).Value = True Then
                                MessageBox.Show("Existe un Premio cargado en la Venta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
                '****************************'
                '-- BUSCAR POR EL PRODUCTO --'
                '****************************'
                'MsgBox("Paso por el numerico")
                If Len(v_codigoIngresado) = 6 Then
                    '-- por codigo del producto
                    intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where idFamilia <> 1 and codigo=" & v_codigoIngresado)
                    'MsgBox("Paso 3")
                    'MsgBox("Valor de idProducto " & intTmpIdProducto)
                End If
                If Len(v_codigoIngresado) > 6 Then
                    'MsgBox("Paso por el segundo paso")
                    '-- por codigo de barras
                    strTmpCodigoBarra = sp_datosTabla.consulta_valorString("select codigoBarra from v_producto where idFamilia <> 1 and codigoBarra=" & "'" & v_codigoIngresado & "'")
                    'MsgBox("Valor de strTmpCodigoBarra  " & strTmpCodigoBarra)
                    If Len(strTmpCodigoBarra) = 0 Then
                        '-- por codigo de barras generado
                        If Len(v_codigoIngresado) = 12 Then
                            '-- para los de 12 digitos
                            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where idFamilia <> 1 and idProducto=" & v_codigoIngresado.Substring(6, 5))
                        End If
                        If Len(v_codigoIngresado) = 13 Then
                            '-- para los de 13 digitos
                            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where idFamilia <> 1 and idProducto=" & v_codigoIngresado.Substring(7, 5))
                        End If
                    Else
                        'banGl_ajusteNegativoMercaderia = True
                        ' MsgBox("Valor del codigo de barra  " & strTmpCodigoBarra)
                        'MsgBox("Valor de la consulta  " & (sp_datosTabla.un_datoString("idProducto", "producto", "codigoBarra", strTmpCodigoBarra)))

                        '-- se encontró el codigo de barras de la mercaderia
                        intTmpIdProducto = CInt(sp_datosTabla.consulta_valorString("select idProducto from v_producto where idFamilia <> 1 and codigoBarra=" & "'" & strTmpCodigoBarra & "'"))

                        'CInt(sp_datosTabla.un_datoString("idProducto", "producto", "codigoBarra", strTmpCodigoBarra))
                    End If
                End If
            End If
        End If

        '-- comparar si existe el codigo ingresado
        If intTmpIdProducto = 0 Then
            MessageBox.Show("No se encuentra el Codigo Ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'MsgBox("Valor de idProducto  " & intTmpIdProducto)
        '-- la imagen de la mercaderia
        picImagenMercaderia.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)


        '-- verificar si ya existe un premio en la grilla
        If dtgVenta.Rows.Count > 0 Then
            For i As Integer = 0 To dtgVenta.Rows.Count - 1
                If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                    If dtgVenta.Rows(i).Cells(11).Value = True Then
                        MessageBox.Show("Ya existe un Premio cargado en la Venta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
            Next
        End If

        '----------------------------------------'
        '-- ver si el producto es referenciado --'
        '----------------------------------------'
        If (sp_datosTabla.consulta_valor("select idProducto from cabProductoRef where idProducto=" & intTmpIdProducto)) > 0 Then
            'MsgBox("Valor de idProducto " & intTmpIdProducto)
            'MsgBox("Es referenciado")
            '---PRODUCTO REFERENCIADO
            '-- cargar la venta
            intGl_nroVentaHeladeria = intGl_nroVentaHeladeria + 1
            cargarVentaHeladeria(intGl_nroVentaHeladeria, intTmpIdProducto, 0, txtCantidad.Text, strTmpForma)

            '-- cargar de vuelta un regitro mas si es un combo estudiante
            If bolGl_comboEstudiante = True Then
                intGl_nroVentaHeladeria = intGl_nroVentaHeladeria + 1

                cargarPromoComboEstudiante(intGl_nroVentaHeladeria, 1, "ENTERO", intTmpCodigoCombo)
            End If
        Else
            '--PRODUCTO NORMALES
            'MsgBox("No Es referenciado")
            '---------------------------------'
            '-- controlar si es fraccionado --'
            '---------------------------------'
            If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
                ' MsgBox("Es un Producto Fraccionado..!")
                '--- producto fraccionado
                intGl_vtaHeladeriaIdProducto = intTmpIdProducto
                Me.Enabled = False
                banGl_ventaHeladeria = True

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
                '----------------------------------
                '-- controlar si tiene varios lotes
                '----------------------------------
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteConStock", intTmpIdProducto & "," & txtIdDeposito.Text, 0) > 0 Then
                    '-- incrementar el valor a la variable publica
                    intGl_nroVentaHeladeria = intGl_nroVentaHeladeria + 1

                    'MsgBox("Producto con un solo lote")
                    '-- para un lote
                    'lblCantidad.Text = 1
                    '-- para un lote
                    intTmpIdLote = sp_datosTabla.sp_traerValor("sp_obtenerIdLoteConStock", intTmpIdProducto & "," & txtIdDeposito.Text, 0)
                    '-- los datos
                    'MsgBox("idProducto  " & intTmpIdProducto)
                    'MsgBox("idLote  " & intTmpIdLote)
                    'MsgBox("IdDeposito  " & txtIdDeposito.Text)
                    '-- traer el idstock
                    intTmpIdStock = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & txtIdDeposito.Text)
                    '-- cargar la grilla
                    cargarVentaHeladeria(intGl_nroVentaHeladeria, intTmpIdProducto, intTmpIdStock, txtCantidad.Text, strTmpForma)
                End If
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteConStock", intTmpIdProducto & "," & txtIdDeposito.Text, 1) = 99 Then
                    '-- incrementar el valor a la variable publica
                    intGl_nroVentaHeladeria = intGl_nroVentaHeladeria + 1

                    strGl_vtaHeladeriaNombreFraccion = "ENTERO"
                    'MsgBox("Productos con varios Lotes")
                    '-- para mas de un lote
                    Me.Enabled = False
                    banGl_ventaHeladeria = True

                    frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", intTmpIdProducto)
                    frmLote.listar_busquedaDeposito(intTmpIdProducto, txtIdDeposito.Text)
                    frmLote.Visible = True
                    frmLote.WindowState = FormWindowState.Normal
                    frmLote.Show()
                    frmLote.BringToFront()
                End If
                '-- no tiene stock
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteConStock", intTmpIdProducto & "," & txtIdDeposito.Text, 1) = 0 Then
                    MessageBox.Show("Esta Mercadería no cuenta con Stock alguno..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'lblIdStock.Text = 0
                    'txtLote.Text = ""
                    'maskVence.Text = ""
                    'btnAgregar.Enabled = False
                End If
            End If
        End If



    End Sub

    '-- verificar el teclado precionado
    Private Sub controlarTeclado(ByVal v_teclado As Keys)
        Dim intTmpValor As Integer = 0

        Select Case v_teclado
            Case Keys.F3
                '-- delivery
                If txtIdTipoventa.Text = 0 Then
                    txtIdTipoventa.Text = 1
                    txtTipoventaNombre.Text = "VENTA DELIVERY"
                    txtTipoventaNombre.BackColor = Color.Black
                    '-- cargar el delivery
                    intGl_nroVentaHeladeria = intGl_nroVentaHeladeria + 1
                    cargarDeliveryVentaHeladeria(intGl_nroVentaHeladeria)
                Else
                    '-- eliminar el delivery
                    For i As Integer = 0 To dtgVenta.Rows.Count - 1
                        If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                            If dtgVenta.Rows(i).Cells(13).Value = True Then
                                intTmpValor = i
                            End If
                        End If
                    Next
                    dtgVenta.Rows.RemoveAt(intTmpValor)
                    intGl_nroVentaHeladeria = intGl_nroVentaHeladeria - 1

                    txtIdTipoventa.Text = 0
                    txtTipoventaNombre.Text = "VENTA NORMAL"
                    txtTipoventaNombre.BackColor = Color.DodgerBlue
                End If
                sumarTotales()
            Case Keys.F4
                '-- totalizar
                controlarGuardar()
                If bolErrorGuardar = False Then
                    If MessageBox.Show("Desea Guardar los Items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        opcionesVenta()
                    End If
                End If
            Case Keys.F5
                banGl_ventaHeladeria = True
                '-- forma de venta
                Me.Enabled = False
                frmFormaVenta.txtFormaVenta.Text = ""
                frmFormaVenta.Visible = True
                frmFormaVenta.WindowState = FormWindowState.Normal
                frmFormaVenta.Show()
                frmFormaVenta.lvFormaVenta.Focus()
            Case Keys.F8
                '-- seleccionar cliente
                banGl_ventaHeladeria = True
                frmCliente_Venta.Enabled = True
                frmCliente_Venta.txtNombre.BackColor = Color.LightSkyBlue
                frmCliente_Venta.txtApellido.Enabled = False
                frmCliente_Venta.txtApellido.BackColor = Color.LightSkyBlue
                frmCliente_Venta.txtDireccion.Enabled = False
                frmCliente_Venta.txtDireccion.BackColor = Color.LightSkyBlue
                frmCliente_Venta.maskFechaAni.Enabled = False
                frmCliente_Venta.maskFechaAni.BackColor = Color.LightSkyBlue
                frmCliente_Venta.btnGuardar.Enabled = False
                '-- limpiar los objetos
                frmCliente_Venta.txtCedula.Text = ""
                frmCliente_Venta.txtNombre.Text = ""
                frmCliente_Venta.txtApellido.Text = ""
                frmCliente_Venta.txtDireccion.Text = ""
                frmCliente_Venta.maskFechaAni.Text = ""
                Me.Enabled = False
                frmCliente_Venta.WindowState = FormWindowState.Normal
                frmCliente_Venta.Show()
                frmCliente_Venta.BringToFront()
            Case Keys.F9
                '-- salir del modulo
                Me.Close()
        End Select
    End Sub

    '-- controlar si hay problemas con algunos productos antes de guardar
    Private Sub controlarGuardar()
        Try
            bolErrorGuardar = False

            '-- eliminar todos los registros de la tabla temporal de eta sucursal y maquina
            sp_datosTabla.consulta_valor("delete from detVentaTmp where idConfig=" & intGl_idConfigPc)
            sp_datosTabla.consulta_valor("delete from detVentaComboEstudianteTmp where idConfig=" & intGl_idConfigPc)
            '----------------------------
            '-- si no existe item cargado
            '----------------------------
            Dim tmpIntContaFila As Integer = 0
            For i As Integer = 0 To dtgVenta.Rows.Count - 1
                '-- realizar los calculos solo si existem items cargados
                If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                    tmpIntContaFila = tmpIntContaFila + 1
                End If
            Next
            If tmpIntContaFila = 0 Then
                MessageBox.Show("No existe ningún item cargado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bolErrorGuardar = True
                Exit Sub
            End If
            '---------------------------------------
            '-- volver a pintar todos los items
            For i As Integer = 0 To dtgVenta.Rows.Count - 1
                If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                    dtgVenta.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
            '--------------------------------
            '----------------------------------------------------
            '-- verificar si el cliente puede comprar a credito
            '----------------------------------------------------
            If sp_datosTabla.un_dato_boleano("acreditar", "v_tipoventa", "idtipoventa", cboTipoVenta.SelectedValue) = True Then
                '-- si es una venta a credito
                If sp_datosTabla.un_dato_boleano("acreditar", "cliente", "idcliente", txtIdCliente.Text) = False Then
                    MessageBox.Show("Este Cliente no puede realizar su compra a Crédito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    bolErrorGuardar = True
                    Exit Sub
                End If
            End If
            '--------------------------------------------
            '-- recorrer la grilla en busca de errores 
            '--------------------------------------------
            Dim intTmpIdStock As Integer
            Dim intTmpIdProducto As Integer
            '- int
            Dim intTmpIdDeposito As Integer
            Dim intTmpIdForma As Integer
            Dim intTmpCantFrac As Integer
            Dim intTmpIdComboEstudiante As Integer = 0
            Dim intTmpCodigoComboEstudiante As Integer = 0

            '- bit
            Dim bolTmpStocko As Boolean
            Dim bolTmpOferta As Boolean
            Dim bolTmpPromo As Boolean
            Dim bolTmpComboEstudiante As Boolean = False

            '-- numerico
            Dim douTmpUltimoStock As Double
            Dim douTmpCantidad As Double
            Dim douTmpPrecio As Double
            Dim douTmpSubTotal As Double
            Dim douTmpPrecioDescuento As Double
            Dim douTmpPorcentajeDescuento As Double
            Dim douTmpRedondeo As Double
            Dim bolTmpPremio As Double
            Dim intTmpIdPuntaje As Integer

            '-- asignar sus respectivos valores a las variables
            For i As Integer = 0 To dtgVenta.Rows.Count - 1
                '-- realizar los calculos solo si existem items cargados
                If dtgVenta.Rows(i).Cells(0).Value > 0 And dtgVenta.Rows(i).Cells(13).Value = False And dtgVenta.Rows(i).Cells(1).Value <> "999999" Then
                    '------------------------'
                    '-- colocar el idStock --'
                    '------------------------'


                    intTmpIdProducto = dtgVenta.Rows(i).Cells(10).Value
                    'MsgBox("Valor de intTmpIdproducto  " & intTmpIdProducto)

                    '- controlar si es un producto referenciado
                    If (sp_datosTabla.consulta_valor("select idProducto from cabProductoRef where idProducto=" & intTmpIdProducto)) > 0 Then
                        ' MsgBox("Producto Referenciado")
                        '-- producto referenciado
                        bolTmpStocko = True
                        '-- controlar si tiene stock inicial
                        'MsgBox("Valor de sp_controlarStockProductoRef  " & sp_datosTabla.sp_traerValor("sp_controlarStockProductoRef", intTmpIdProducto & "," & txtIdDeposito.Text, 0))

                        'MsgBox("Valor de intTmpIdproducto  " & intTmpIdProducto)
                        'MsgBox("Valor de idDeposito  " & txtIdDeposito.Text)
                        'MsgBox("Paso 3")

                        If (sp_datosTabla.sp_traerValor("sp_controlarStockProductoRef", intTmpIdProducto & "," & txtIdDeposito.Text, 0)) = 0 Then
                            MessageBox.Show("Este Producto no cuenta con Stock inicial..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            bolErrorGuardar = True
                            '-- pintar en rojo los errores
                            dtgVenta.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            Exit Sub
                        End If

                    Else
                        '-- producto normal
                        intTmpIdStock = dtgVenta.Rows(i).Cells(9).Value
                        bolTmpStocko = False
                        '-- controlar si tiene stock inicial
                        If intTmpIdStock = 0 Then
                            MessageBox.Show("Este Producto no cuenta con Stock inicial..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            bolErrorGuardar = True
                            '-- pintar en rojo los errores
                            dtgVenta.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            Exit Sub
                        End If
                    End If
                    '-- cargar en la tabla temporal
                    '-- dar valor a las variables
                    intTmpIdDeposito = txtIdDeposito.Text
                    intTmpIdForma = sp_datosTabla.un_datoString("idForma", "cabForma", "nombreForma", dtgVenta.Rows(i).Cells(4).Value)
                    douTmpUltimoStock = 0
                    douTmpCantidad = dtgVenta.Rows(i).Cells(5).Value
                    intTmpCantFrac = sp_datosTabla.sp_string("sp_obtenerCantidadFraccion", intTmpIdProducto & "," & "'" & dtgVenta.Rows(i).Cells(4).Value & "'" & ",0")
                    douTmpPrecio = dtgVenta.Rows(i).Cells(6).Value
                    douTmpSubTotal = dtgVenta.Rows(i).Cells(8).Value
                    douTmpPrecioDescuento = dtgVenta.Rows(i).Cells(7).Value
                    douTmpPorcentajeDescuento = sp_datosTabla.sp_double("sp_descuentoGrupoCliente", sp_datosTabla.un_dato_integer("idGrupoCliente", "cliente", "idcliente", txtIdCliente.Text) & "," & cboTipoVenta.SelectedValue & "," & txtIdTipoventa.Text & "," & intTmpIdProducto)
                    bolTmpOferta = False
                    bolTmpPromo = False
                    douTmpRedondeo = sp_datosTabla.un_dato_integer("redondeo", "configEmpresa", "idEntidad", intGl_idEntidad)
                    bolTmpPremio = CBool(dtgVenta.Rows(i).Cells(12).Value)
                    intTmpIdPuntaje = CInt(dtgVenta.Rows(i).Cells(11).Value)

                    ' MsgBox("Valor de idStock " & intTmpIdStock)
                    ' MsgBox("Valor de idProducto " & intTmpIdProducto)
                    'MsgBox("Valor de idPuntaje " & intTmpIdPuntaje)

                    '------------------------------------------------------------------------------------------------------'
                    '--- buscar si el idProducto de producto está como producto dentro de la tabla codigoComboEstudiante --'
                    '------------------------------------------------------------------------------------------------------'
                    intTmpIdComboEstudiante = sp_datosTabla.consulta_valor("select idComboEstudiante from codigoComboEstudiante where idProducto=" & intTmpIdProducto)
                    If intTmpIdComboEstudiante > 0 Then
                        bolTmpComboEstudiante = True

                    End If
                    '---------------------------- FIN DE LA PROMOCION DE COMBO ESTUDIANTE --------------------------'

                    If (fun_guardarSp("sp_agregarDetVentaHeladeriaTmp", intGl_idUsuario & "," & intGl_idConfigPc & "," & intTmpIdStock & _
                        "," & intTmpIdProducto & "," & txtIdDeposito.Text & "," & intTmpIdForma & "," & bolTmpStocko & "," & _
                        douTmpUltimoStock & "," & douTmpCantidad & "," & intTmpCantFrac & "," & douTmpPrecio & "," & douTmpSubTotal & _
                        "," & douTmpPrecioDescuento & "," & douTmpPorcentajeDescuento & "," & bolTmpOferta & "," & bolTmpPromo & "," & _
                        douTmpRedondeo & "," & bolTmpPremio & "," & intTmpIdPuntaje, Me.Name)) = 0 Then
                        '-- no se guardo los registros
                        MessageBox.Show("No se puede agregar el detalle de la venta", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        bolErrorGuardar = True
                        '-- pintar en rojo los errores
                        dtgVenta.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                        Exit Sub
                    End If
                    'MsgBox("Paso 2")
                Else
                    '-- agregar a la tabla temporal el delivery
                    If dtgVenta.Rows(i).Cells(13).Value = True Then
                        If (fun_guardarSp("sp_agregarDeliveryVentaHeladeriaTmp", intGl_idConfigPc, Me.Name)) = 0 Then
                            '-- no se guardo los registros
                            MessageBox.Show("No se puede agregar el detalle del Delivery", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            bolErrorGuardar = True
                            '-- pintar en rojo los errores
                            dtgVenta.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            Exit Sub
                        End If
                    End If
                    If dtgVenta.Rows(i).Cells(1).Value = "999999" Then
                        '-----------------------------------------------'
                        '-- AGREGAR EL COMBO ESTUDIANTE EN EL DETALLE --'
                        '-----------------------------------------------'
                        intTmpCodigoComboEstudiante = sp_datosTabla.consulta_valor("select idComboEstudiante from codigoComboEstudiante where codigoComboEstudiante=" & CInt(dtgVenta.Rows(i).Cells(14).Value))
                        'MsgBox("Valor del codigo  " & dtgVenta.Rows(i).Cells(14).Value)
                        'MsgBox("Valor del idCombo  " & intTmpCodigoComboEstudiante)

                        If (fun_guardarSp("sp_agregarDetVentaHeladeriaTmpComboEstudiante", intGl_idConfigPc & "," & 5000 & "," & intTmpCodigoComboEstudiante, Me.Name)) = 0 Then
                            '-- no se guardo los registros
                            MessageBox.Show("No se puede agregar el detalle del codigo del combo de estudiante", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            bolErrorGuardar = True
                            '-- pintar en rojo los errores
                            dtgVenta.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            Exit Sub
                        End If
                    End If
                End If

                ' MsgBox("Paso 1")
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '-- actuvar la promocion
    Public Sub activarPromo()
        '-- de club samsung 19/01/2016
        For i As Integer = 0 To dtgVenta.Rows.Count - 1
            If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                dtgVenta.Rows(i).Cells(7).Value = sp_datosTabla.consulta_valorDouble("select [dbo].[funPrecioPromo](" & CInt(dtgVenta.Rows(i).Cells(10).Value) & ")")
            End If
        Next
        sumarTotales()
    End Sub
    '-- las opciones de venta
    Private Sub opcionesVenta()
        '-- la variable global
        banGl_ventaHeladeria = True
        '-- idCliente
        intGl_vtaIdCliente = CInt(txtIdCliente.Text)
        '-- controlar si el usuario es un vendedor 
        If sp_datosTabla.consulta_valor("select _vv.idVendedor from v_vendedor _vv inner join v_usuario _vu on _vv.idPersonal=_vu.idPersonal" & _
                                        " where _vu.idUsuario=" & intGl_idUsuario) = 0 Then
            MessageBox.Show("El Usuario Actual no está como Vendedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            intGl_vtaIdVendedor = sp_datosTabla.consulta_valor("select _vv.idVendedor from v_vendedor _vv inner join v_usuario _vu on _vv.idPersonal=_vu.idPersonal" & _
                                        " where _vu.idUsuario=" & intGl_idUsuario)
            'MsgBox("Valor de idVendedor  " & intGl_vtaIdVendedor)
        End If
        '****************************************************'
        '-- inicializar las variables publicas de la venta --'
        '****************************************************'
        intGl_vtaIdTarjetaCredito = 0
        intGl_vtaIdTarjetaDebito = 0
        intGl_vtaCantidadCuota = 0
        intGl_vtaNroOrden = 0

        bolGl_vtaDeliveryExterno = False
        strGl_vtaNombreBanco = ""
        intGl_vtaNroCheque = 0
        '-- inicializar la varibale global de nro de autorizacion si es una compra via web
        intGl_vtaNroAutoriza = 0

        '--- las diferentes formas de ventas aplicadas
        Dim tmpStrAbreviatura As String
        tmpStrAbreviatura = Trim(sp_datosTabla.un_datoString("abreviatura", "v_tipoventa", "idTipoventa", cboTipoVenta.SelectedValue))
        Select Case tmpStrAbreviatura
            Case "CON"
                '-- formulario de vuelto del cliente
                frmVueltoCliente.txtMontoCliente.Text = 0
                frmVueltoCliente.txtMontoCliente.Text = Format(CDec(frmVueltoCliente.txtMontoCliente.Text), "##,###,###.00")
                frmVueltoCliente.txtTotalVenta.Text = txtTotalVenta.Text
                frmVueltoCliente.txtTotalVenta.Text = Format(CDec(frmVueltoCliente.txtTotalVenta.Text), "##,###,###.00")
                frmVueltoCliente.txtVuelto.Text = 0
                frmVueltoCliente.txtVuelto.Text = Format(CDec(frmVueltoCliente.txtVuelto.Text), "##,###,###.00")
                '-- colocar la moneda que está por defecto
                '-- asignar al combo la moneda
                monedaSistema.listarMonedaCombo(frmVueltoCliente.cboMoneda)
                '-- colocar en el combo la moneda pre determinada por el sistema
                frmVueltoCliente.cboMoneda.SelectedValue = sp_datosTabla.un_dato_integer("idMoneda", "moneda", "idmoneda", sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad))

                frmVueltoCliente.btnAceptar.Enabled = True
                frmVueltoCliente.btnCancelar.Enabled = True
                '-- bandera publica que activa el vuelto para la venta de farmacia

                Me.Enabled = False
                frmVueltoCliente.Visible = True
                frmVueltoCliente.WindowState = FormWindowState.Normal
                frmVueltoCliente.BringToFront()
                frmVueltoCliente.Show()
                frmVueltoCliente.cboMoneda.Focus()

                'MsgBox("Tipo de venta CONTADO", MsgBoxStyle.Information)
            Case "CRE"
                'MsgBox("Tipo de venta CREDITO", MsgBoxStyle.Information)
                '-- colocar todos los datos del cliente en el formulario de credito de venta
                frmCreditoVenta.lblNroCuota.Text = 1
                frmCreditoVenta.actualizarCuota(CDbl(sacarComa(txtTotalVenta.Text)))

                frmCreditoVenta.txtNroOrden.Text = 0
                frmCreditoVenta.txtCliente.Text = txtCliente.Text
                frmCreditoVenta.txtGrupoCliente.Text = txtGrupoCliente.Text
                frmCreditoVenta.txtIdCliente.Text = txtIdCliente.Text
                frmCreditoVenta.txtRucCliente.Text = txtRucCliente.Text
                frmCreditoVenta.txtTelefonoCliente.Text = txtTelefonoCliente.Text
                frmCreditoVenta.txtTotalVenta.Text = txtTotalVenta.Text
                frmCreditoVenta.txtTotalVenta.Text = Format(CDec(frmCreditoVenta.txtTotalVenta.Text), "##,###,###.00")
                '-- el saldo del cliente
                frmCreditoVenta.txtSaldo.Text = sp_datosTabla.sp_traerValor("sp_saldoCliente", CInt(txtIdCliente.Text), 0)
                frmCreditoVenta.txtSaldo.Text = Format(CDec(frmCreditoVenta.txtSaldo.Text), "##,###,###.00")
                '-- realizar la diferencia
                frmCreditoVenta.txtDiferencia.Text = (CDec(frmCreditoVenta.txtSaldo.Text) + CDec(frmCreditoVenta.txtTotalVenta.Text))
                frmCreditoVenta.txtDiferencia.Text = Format(CDec(frmCreditoVenta.txtDiferencia.Text), "##,###,###.00")
                '-- activar los botones
                frmCreditoVenta.btnAceptar.Enabled = True
                frmCreditoVenta.btnCancelar.Enabled = True
                '-- el limite del cliente
                '- verificar que no sea nulo
                If Not IsDBNull(sp_datosTabla.consulta_valor("select habilitarLimite from cliente where idCliente=" & CInt(txtIdCliente.Text))) Then
                    '-- verificar si está habilitado
                    If (sp_datosTabla.consulta_valor("select habilitarLimite from cliente where idCliente=" & CInt(txtIdCliente.Text))) = True Then
                        frmCreditoVenta.txtLimite.Text = sp_datosTabla.consulta_valor("select limiteCredito from cliente where idCliente=" & CInt(txtIdCliente.Text))
                        frmCreditoVenta.txtLimite.Text = Format(CDec(frmCreditoVenta.txtLimite.Text), "##,###,###.00")
                        '-- controlar si el limite excede el total + el saldo
                        If CDec(frmCreditoVenta.txtDiferencia.Text) > CDec(frmCreditoVenta.txtLimite.Text) Then
                            MessageBox.Show("Este Cliente Excede en su Límite de Crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            frmCreditoVenta.btnAceptar.Enabled = False
                            frmCreditoVenta.lbllimite.Visible = True
                        End If
                    End If

                End If

                Me.Enabled = False
                frmCreditoVenta.Visible = True
                frmCreditoVenta.WindowState = FormWindowState.Normal
                frmCreditoVenta.BringToFront()
                frmCreditoVenta.Show()
                frmCreditoVenta.lvCuota.Focus()
                '-- de acuerdo a la configuracion

            Case "TCR"
                'MsgBox("Tipo de venta TARJETA DE CREDITO", MsgBoxStyle.Information)
                '-- asignar al combo la tarjeta debito
                tarjetaCredito.listarTarjetaCreditoCombo(frmTarjetaCredito.cboTarjeta)

                frmTarjetaCredito.btnAceptar.Enabled = True
                frmTarjetaCredito.btnCancelar.Enabled = True

                Me.Enabled = False
                frmTarjetaCredito.Visible = True
                frmTarjetaCredito.WindowState = FormWindowState.Normal
                frmTarjetaCredito.BringToFront()
                frmTarjetaCredito.Show()
                frmTarjetaCredito.cboTarjeta.Focus()
                '-- a
            Case "TDE"
                'MsgBox("Tipo de venta TARJETA DE DEBITO", MsgBoxStyle.Information)
                '-- asignar al combo la tarjeta debito
                tarjetaDebito.listarTarjetadebitoCombo(frmTarjetaDebito.cboTarjeta)

                frmTarjetaDebito.btnAceptar.Enabled = True
                frmTarjetaDebito.btnCancelar.Enabled = True

                Me.Enabled = False
                frmTarjetaDebito.Visible = True
                frmTarjetaDebito.WindowState = FormWindowState.Normal
                frmTarjetaDebito.BringToFront()
                frmTarjetaDebito.Show()
                frmTarjetaDebito.cboTarjeta.Focus()
            Case "CHE"
                'MsgBox("Tipo de venta CHEQUE", MsgBoxStyle.Information)
                '-- variable publica 
                bolGl_vtaVendedorFarmacia = True
                intGl_vtaCantidadCuota = 0
                Me.Enabled = False

                '-- controlar si como etá configurado
                If sp_datosTabla.consulta_valor("select nickPass from configEmpresa where idEntidad=" & intGl_idEntidad) = True Then
                    '-- nick y contraseña

                Else
                    '-- solo contraseña
                    frmPass.txtPass.Text = ""
                    frmPass.btnAceptar.Enabled = True
                    frmPass.btnCancelar.Enabled = True

                    frmPass.Visible = True
                    frmPass.Show()
                    frmPass.BringToFront()
                    frmPass.txtPass.Focus()
                End If
            Case "TPRO"
                '-- saber si en la sucursal se puede imprimir en la heladerua
                frmNickPass.lblCliente.Text = txtCliente.Text
                frmNickPass.lblRuc.Text = txtRucCliente.Text
                frmNickPass.lblFormaVenta.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoVenta where idTipoVenta=" & cboTipoVenta.SelectedValue)
                frmNickPass.lblTipoVenta.Text = txtTipoventaNombre.Text
                frmNickPass.lblTotalVenta.Text = txtTotalVenta.Text
                frmNickPass.lblTotalVenta.Text = Format(CDbl(txtTotalVenta.Text), "##,###,###.##")
                frmNickPass.lblTotalDescuento.Text = txtTotalDescuento.Text
                frmNickPass.lblTotalDescuento.Text = Format(CDbl(txtTotalDescuento.Text), "##,###,##0.##")
                frmNickPass.lblVuelto.Text = 0
                '-- el nick
                frmNickPass.txtUsuario.Text = Trim(leerArchivoNick())

                '-- la contraseña
                frmNickPass.txtPass.Text = ""
                frmNickPass.lblVendedor.Text = ""
                frmNickPass.btnAceptar.Enabled = True
                frmNickPass.btnCancelar.Enabled = True

                Me.Enabled = False
                banGl_ventaHeladeria = True
                frmNickPass.Visible = True
                frmNickPass.Show()
                frmNickPass.BringToFront()
                frmNickPass.txtUsuario.Focus()
        End Select

    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnPremio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPremio.Click
        Dim intTmpIdCliente As Integer
        Dim intTmpIdPersona As Integer

        Me.Enabled = False
        frmPremioClienteVenta.txtIdStock.Text = 0
        frmPremioClienteVenta.txtIdProducto.Text = 0

        '--- datos del cliente
        intTmpIdCliente = CInt(txtIdCliente.Text)
        intTmpIdPersona = sp_datosTabla.consulta_valor("select idPersona from v_cliente where idCliente=" & intTmpIdCliente)
        frmPremioClienteVenta.txtCedula.Text = sp_datosTabla.consulta_valorString("select soloruc from v_cliente where idCliente=" & intTmpIdCliente)
        frmPremioClienteVenta.txtDv.Text = sp_datosTabla.consulta_valorString("select dv from persona where idPersona=" & intTmpIdPersona)
        frmPremioClienteVenta.txtNombre.Text = sp_datosTabla.consulta_valorString("select nombre from v_cliente where idCliente=" & intTmpIdCliente)
        frmPremioClienteVenta.txtApellido.Text = sp_datosTabla.consulta_valorString("select apellido from v_cliente where idCliente=" & intTmpIdCliente)
        frmPremioClienteVenta.txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from v_cliente where idCliente=" & intTmpIdCliente)
        frmPremioClienteVenta.maskFechaAni.Text = sp_datosTabla.consulta_valorString("select fechaAni from persona where idPersona=" & intTmpIdPersona)
        grupoCliente.ListarGrupoCliente(frmPremioClienteVenta.cboGrupoCliente)
        frmPremioClienteVenta.cboGrupoCliente.SelectedValue = sp_datosTabla.consulta_valor("select idGrupoCliente from v_cliente where idCliente=" & intTmpIdCliente)
        frmPremioClienteVenta.txtCelular1.Text = sp_datosTabla.consulta_valorString("select celular1 from persona where idPersona=" & intTmpIdPersona)
        frmPremioClienteVenta.txtTelefono1.Text = sp_datosTabla.consulta_valorString("select tele1 from persona where idPersona=" & intTmpIdPersona)
        frmPremioClienteVenta.txtEmail.Text = sp_datosTabla.consulta_valorString("select email1 from persona where idPersona=" & intTmpIdPersona)
        frmPremioClienteVenta.txtFacebook.Text = sp_datosTabla.consulta_valorString("select facebook from persona where idPersona=" & intTmpIdPersona)
        frmPremioClienteVenta.lblIdStock1.Text = 0
        frmPremioClienteVenta.lblIdStock2.Text = 0
        frmPremioClienteVenta.lblIdStock3.Text = 0
        frmPremioClienteVenta.lblIdStock4.Text = 0
        frmPremioClienteVenta.lblIdProd1.Text = 0
        frmPremioClienteVenta.lblIdProd2.Text = 0
        frmPremioClienteVenta.lblIdProd3.Text = 0
        frmPremioClienteVenta.lblIdProd4.Text = 0
        frmPremioClienteVenta.btnGuardar.Enabled = False

        '-- limpiar los premios
        frmPremioClienteVenta.lblPremio1.Text = ""
        frmPremioClienteVenta.lblPremio2.Text = ""
        frmPremioClienteVenta.lblPremio3.Text = ""
        frmPremioClienteVenta.lblPremio4.Text = ""
        '-- cargar el stock de los premios cargados
        frmPremioClienteVenta.listarStockPremioCliente(intTmpIdCliente)
        '-------------------------------------------
        banGl_ventaHeladeria = True

        frmPremioClienteVenta.Show()
        frmPremioClienteVenta.BringToFront()
        frmPremioClienteVenta.txtDireccion.Focus()
    End Sub

    Private Sub btnHabitacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHabitacion.Click
        controlarGuardar()
        If bolErrorGuardar = False Then
            Me.Enabled = False
            frmVentaHabitacion.Show()
            frmVentaHabitacion.BringToFront()
            frmVentaHabitacion.txtTotal.Text = txtTotalVenta.Text
            frmVentaHabitacion.txtTotal.Text = Format(CDec(frmVentaHabitacion.txtTotal.Text), "##,###,##0")
            frmVentaHabitacion.lvHabitacion.Focus()
        End If
    End Sub

    Private Sub btnPromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPromo.Click
        frmPromoSamsung.Enabled = True
        frmPromoSamsung.txtNombre.BackColor = Color.LightSkyBlue
        frmPromoSamsung.txtApellido.Enabled = False
        frmPromoSamsung.txtApellido.BackColor = Color.LightSkyBlue
        frmPromoSamsung.txtDireccion.Enabled = False
        frmPromoSamsung.txtDireccion.BackColor = Color.LightSkyBlue
        frmPromoSamsung.maskFechaAni.Enabled = False
        frmPromoSamsung.maskFechaAni.BackColor = Color.LightSkyBlue
        frmPromoSamsung.btnGuardar.Enabled = False
        '-- limpiar los objetos
        frmPromoSamsung.txtCedula.Text = ""
        frmPromoSamsung.txtNroSocio.Text = 0
        frmPromoSamsung.txtIdCanje.Text = 0
        frmPromoSamsung.txtNombre.Text = ""
        frmPromoSamsung.txtApellido.Text = ""
        frmPromoSamsung.txtDireccion.Text = ""
        frmPromoSamsung.maskFechaAni.Text = ""
        Me.Enabled = False
        frmPromoSamsung.WindowState = FormWindowState.Normal
        frmPromoSamsung.Show()
        frmPromoSamsung.BringToFront()
    End Sub

    Private Sub btnSamsung_Click(sender As System.Object, e As System.EventArgs) Handles btnSamsung.Click
        banGl_ventaHeladeria = True
        Me.Enabled = False

        frmSamsungClubVenta.txtCodigo.Text = 0
        frmSamsungClubVenta.txtNroSocio.Text = 0
        frmSamsungClubVenta.Show()
        frmSamsungClubVenta.BringToFront()
        frmSamsungClubVenta.txtNroSocio.Focus()

    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- para buscar el producto
            If txtBuscar.Text = "" Then
                banGl_ventaHeladeria = True
                Me.Enabled = False
                frmStock.txtBuscar.Text = ""
                frmStock.txtIdProducto.Text = "0"
                frmStock.Visible = True
                frmStock.WindowState = FormWindowState.Normal
                frmStock.Show()
                frmStock.txtBuscar.Focus()
            Else
                '-- ver el metodo de busqueda
                buscarProducto(txtBuscar.Text)
                txtBuscar.Focus()
            End If
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
        controlarTeclado(e.KeyValue)
        e.Handled = True
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LAS GRILLAS --'
    '*****************'
    Private Sub dtgVenta_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgVenta.CellFormatting
        '-- formato de la columna de cantidad
        If dtgVenta.Columns(e.ColumnIndex).Name.Equals("Column7") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("###,##0.##")
        End If
        '-- formato para la columna de precio
        If dtgVenta.Columns(e.ColumnIndex).Name.Equals("Column8") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("###,##0")
        End If
        '-- formato para la columna de precio con descuento
        If dtgVenta.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("###,##0")
        End If
        '-- formato para la columna de subtotal
        If dtgVenta.Columns(e.ColumnIndex).Name.Equals("Column10") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##,###,##0")
            'e.CellStyle.Font.Size
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS COMBOS --'
    '****************'
    Private Sub cboTipoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoVenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            sumarTotales()
            cboTipoVenta.Enabled = False
            dtgVenta.Focus()
        End If
    End Sub

    Private Sub cboTipoVenta_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoVenta.SelectedValueChanged
        sumarTotales()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmVentaHeladeria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- ver si hay item cargados
        For i As Integer = 0 To dtgVenta.Rows.Count - 1
            If dtgVenta.Rows(i).Cells(0).Value > 0 Then
                intTmpConta = intTmpConta + 1
            End If
        Next
        If intTmpConta > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- borar la tabla temporal que corresponde a este puesto
                'sp_datosTabla.consulta_valor("delete detVentaTmp where idConfig=" & intGl_idConfigPc & " and codigoVenta=" & CInt(lblCodigoVenta.Text))
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                banGl_ventaHeladeria = 0
                frmMenuPrincipal.clienteFacturacionHeladeria.Enabled = True
                e.Cancel = False
            Else
                e.Cancel = True
            End If ' Call me
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            banGl_ventaHeladeria = 0
            frmMenuPrincipal.clienteFacturacionHeladeria.Enabled = True
            e.Cancel = False
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------


End Class