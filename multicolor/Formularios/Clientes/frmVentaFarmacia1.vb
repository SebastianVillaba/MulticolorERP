Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmVentaFarmacia1
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
    Dim sp_cargarVenta As New sp_cargarVenta
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
    Dim bolOrden As Boolean = False
    '-- variables para los valores de la tabla de cotizacion
    Dim douSubtotalMoneda As Double = 0
    Dim douDescuentoMoneda As Double = 0
    Dim douTotalMoneda As Double = 0
    '-- variables para el datagrid de la venta
    Dim douSubtotalGrilla As Double
    Dim intContadorRegistros As Integer
    '-- bandera de error de guardar
    Dim bolErrorGuardar As Boolean
    '-- variable para verificar si enxisten mercaderias controladas en la grilla
    Dim bolMercaderiaControlado As Boolean = False

    '--------------------------------------------------------------------------------------------------------------------
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        Me.Refresh()
        txtBuscar.Focus()
        actualizarDetVenta()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub inicializar()
        limpiar()
    End Sub

    Public Sub limpiar()
        Try
            '-- limpiar la tabla temporal de la venta
            sp_datosTabla.consulta_valor("delete from detVentaTmp where idConfig=" & intGl_idConfigPc)
            sp_datosTabla.consulta_valor("delete from detVentaDeliveryTmp where idConfig=" & intGl_idConfigPc)
            sp_datosTabla.consulta_valor("delete from detVentaTarjetaPromoTmp where idConfig=" & intGl_idConfigPc)

            '--- datos del cliente configurado como primero en ventas
            txtIdCliente.Text = sp_cliente.cliente_primero(1)
            txtRucCliente.Text = sp_cliente.cliente_primero(2)
            txtCliente.Text = sp_cliente.cliente_primero(3)
            txtGrupoCliente.Text = sp_cliente.cliente_primero(4)
            txtDireccion.Text = ""
            ' MsgBox("Valor 1")
            'MsgBox("Valor 2")
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

            '-- la tabla de la cotizacion
            '-- los parametros
            douSubtotalMoneda = 0
            douDescuentoMoneda = douTotalDescuento
            douTotalMoneda = intGl_vtaTotalVenta

            'MsgBox("Valor 3")
            listar_tablaCotizacion()
            'MsgBox("Valor 4")
            '-- datos sobre la forma de venta
            lblIdTipoVenta.Text = sp_datosTabla.consulta_valor("select idTipoVenta from v_tipoventa where primero=1")
            lblFormaVenta.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoventa where primero=1")

            '-- los txt de los datos del producto
            txtTipoProducto.Text = ""
            txtLaboratorioProducto.Text = ""
            txtFechaUltimaCompraCliente.Text = ""
            txtStockProducto.Text = 0
            txtIdProducto.Text = 0
            txtIdStock.Text = 0

            lblForma.Text = ""
            lblCodigo.Text = ""
            lblMercaderia.Text = ""
            lblIdStock.Text = 0
            lblIdProducto.Text = 0
            txtBuscar.Text = ""
            txtObra.Text = ""
            txtCantidad.Text = 0
            lblCantfrac.Text = 0
            '-- tipo de venta
            txtIdTipoventa.Text = 0
            txtTipoventaNombre.Text = "VENTA NORMAL"
            txtTipoventaNombre.BackColor = Color.DodgerBlue
            '-- colocar el foco en buscar
            '-- las imagenes
            picImagenMercaderia.ImageLocation = ""
            '-- la variable de los controlados
            bolMercaderiaControlado = False

            '---------------------'
            '-- LA ULTIMA VENTA --'
            '---------------------'
            ' MsgBox("Valor 5")
            '-- verificar si la pc tiene venta
            If (sp_datosTabla.consulta_valor("select idConfigPc from cabVenta where idConfigPc=" & intGl_idConfigPc)) > 0 Then
                'MsgBox("Valor 6")
                lblUltimaFecha.Text = sp_datosTabla.sp_traerValor("sp_consultaUltimaVenta", intGl_idConfigPc, 1)
                'MsgBox("Valor 7")
                lblUltimaFormaVenta.Text = sp_datosTabla.sp_traerValor("sp_consultaUltimaVenta", intGl_idConfigPc, 3)
                'MsgBox("Valor 8")
                lblUltimoCliente.Text = sp_datosTabla.sp_traerValor("sp_consultaUltimaVenta", intGl_idConfigPc, 0)
                'MsgBox("Valor 9")
                lblUltimoMonto.Text = sp_datosTabla.sp_traerValor("sp_consultaUltimaVenta", intGl_idConfigPc, 2)
                'MsgBox("Valor 10")
                lblUltimoMonto.Text = Format(CDec(lblUltimoMonto.Text), "##,###,###.##")
                lblUltimoTipoVenta.Text = sp_datosTabla.sp_traerValor("sp_consultaUltimaVenta", intGl_idConfigPc, 4)
                'MsgBox("Valor 11")
                lblUltimoVendedor.Text = sp_datosTabla.sp_traerValor("sp_consultaUltimaVenta", intGl_idConfigPc, 5)
                'MsgBox("Valor 12")
                '-- listar los ultimos productos vendidos
                listarUltimosProductosVendidos()
            End If
            '-- el convenio
            intGl_vtaIdConvenio = 0

            'MsgBox("Valor 3")
            '-- volver a sumer los totales
            sumarTotales()
            'MsgBox("Valor 14")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Sub listar_tablaCotizacion()
        systemClass.SqlToLv_tablaCotizacion(lvMoneda, "sp_tablaCotizacion", intGl_idEntidad & "," & douSubtotalMoneda & "," & douDescuentoMoneda & "," & douTotalMoneda)
        'txtSql.Text = "select * from v_stock" & intGl_idSucursal & where
    End Sub

    '-- listar el detalle de la venta
    Public Sub actualizarDetVenta()
        systemClass.SqlToLv_detalleVentaFarmacia(lvVenta, "sp_consultaDetalleVentaTmpNuevo", intGl_idConfigPc & "," & CInt(txtIdCliente.Text) & "," & CInt(lblIdTipoVenta.Text) & "," & CInt(txtIdTipoventa.Text))
    End Sub

    '-- actualizar los totales
    Public Sub sumarTotales()
        '-- sumar los totales
        douTotalDescuento = 0
        '--- variables para el iva  
        Dim douTmpTotal As Double = 0
        Dim intTmpIdImpuesto As Integer = 0

        '-- el total de la factura
        txtTotalVenta.Text = sp_datosTabla.consulta_valorDouble("select sum(subtotal) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalDescuento.Text = sp_datosTabla.consulta_valorDouble("select sum(subtotalDescuento) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIva10.Text = sp_datosTabla.consulta_valorDouble("select sum(iva10) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIva5.Text = sp_datosTabla.consulta_valorDouble("select sum(iva5) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalIva.Text = sp_datosTabla.consulta_valorDouble("select sum(iva5+iva10) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        '----------------------------------------------------------------------------------------------------------------------------
        txtTotalVenta.Text = Format(CDec(txtTotalVenta.Text), "###,###,##0")
        txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,##0")
        '-- actualizar la tabla de las cotizaciones
        douDescuentoMoneda = sp_datosTabla.consulta_valorDouble("select sum(subtotalDescuento) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        douTotalMoneda = sp_datosTabla.consulta_valorDouble("select sum(subtotal) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        '--------- LOS TOTALES DEL IVA -----------------------
        '-- asignar los totales
        txtTotalIva.Text = sp_datosTabla.consulta_valorDouble("select sum(iva5+iva10) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "#,###,##0")
        'txtIva10.Text = douTmpIva10
        txtIva10.Text = Format(CDec(txtIva10.Text), "#,###,##0")
        'txtIva5.Text = douTmpIva5
        txtIva5.Text = Format(CDec(txtIva5.Text), "#,###,##0")
        '-----------------------------------------------------------------------
        '-----------------------------------------'
        '-- CONTROLAR EL TIMBRADO DE LA FACTURA --'
        '-----------------------------------------'
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
        '-- reactivar la bandera publica de la reutilizacion de la venta
        banGl_reutilizarVenta = False

        listar_tablaCotizacion()

        '-- actualizar el detalle de la venta
        actualizarDetVenta()
    End Sub

    '-- controlar la venta
    Private Sub controlarErrorVenta()
        bolErrorGuardar = False
        '------------------ FIN ---------------------------
        '----------------------------------------------------
        '-- verificar si el cliente puede comprar a credito
        '----------------------------------------------------
        If sp_datosTabla.un_dato_boleano("acreditar", "v_tipoventa", "idtipoventa", CInt(lblIdTipoVenta.Text)) = True Then
            '-- si es una venta a credito
            If sp_datosTabla.un_dato_boleano("acreditar", "cliente", "idcliente", txtIdCliente.Text) = False Then
                MessageBox.Show("Este Cliente no puede realizar su compra a Crédito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bolErrorGuardar = True
                Exit Sub
            End If
        End If
        '-- verificar si hay errores
        If sp_datosTabla.sp_traerValor("sp_problemaVentaFarmacia", intGl_idConfigPc & "," & intGl_idEntidad, 0) <> "" Then
            '-- desplegar el mensaje
            MessageBox.Show(sp_datosTabla.sp_traerValor("sp_problemaVentaFarmacia", intGl_idConfigPc & "," & intGl_idEntidad, 0), strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '-- pintar los errores
            actualizarDetVenta()

            bolErrorGuardar = True
            Exit Sub
        End If
        '-- verificar si existen mercaderias contrladas
        bolMercaderiaControlado = False
        If sp_datosTabla.consulta_valor("select tmp.idStock from detVentaTmp tmp inner join stock s on tmp.idStock=s.idStock " & _
                                        "inner join producto p on p.idProducto=s.idProducto where p.controlado=1 and tmp.idConfig=" & intGl_idConfigPc) > 0 Then
            bolMercaderiaControlado = True
        End If
        '--------------------------------------------------------------------------------------------------------------------------

    End Sub

    Public Sub opcionesVenta()
        '-- controlar si existen mercaderias controladas y no se ingresó alguna receta
        If bolMercaderiaControlado = True Then
            If sp_datosTabla.consulta_valor("select idMedico from tmpMedicoVenta where idConfig=" & intGl_idConfigPc) = 0 Then
                MessageBox.Show("Debe Ingresar las Matriculas de Médicos para Guardar Mercaderias de Uso Controlado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        '-- inicializar la varibale global de nro de autorizacion si es una compra via web
        intGl_vtaNroAutoriza = 0

        '--- las diferentes formas de ventas aplicadas
        Dim tmpStrAbreviatura As String
        tmpStrAbreviatura = Trim(sp_datosTabla.un_datoString("abreviatura", "v_tipoventa", "idTipoventa", lblIdTipoVenta.Text))

        banGl_ventaFarmacia1 = True
        bolGl_vtaDeliveryExterno = False
        strGl_vtaNombreBanco = ""
        intGl_vtaNroCheque = 0

        Select Case tmpStrAbreviatura
            Case "CON"

                If txtIdTipoventa.Text = 1 Then
                    '-- venta por delivery
                    frmVueltoCliente.grDelivery.Visible = True
                    frmVueltoCliente.chkDeliveryExterno.Checked = False
                Else
                    frmVueltoCliente.grDelivery.Visible = False
                    frmVueltoCliente.chkDeliveryExterno.Checked = False
                End If

                '-- formulario de vuelto del cliente
                frmVueltoCliente.txtMontoCliente.Text = 0
                frmVueltoCliente.txtMontoCliente.Text = Format(CDec(frmVueltoCliente.txtMontoCliente.Text), "##,###,##0.##")
                frmVueltoCliente.txtTotalVenta.Text = txtTotalVenta.Text
                frmVueltoCliente.txtTotalVenta.Text = Format(CDec(frmVueltoCliente.txtTotalVenta.Text), "##,###,##0.##")
                frmVueltoCliente.txtVuelto.Text = 0
                frmVueltoCliente.txtVuelto.Text = Format(CDec(frmVueltoCliente.txtVuelto.Text), "##,###,##0.##")
                '-- colocar la moneda que está por defecto
                '-- asignar al combo la moneda
                monedaSistema.listarMonedaCombo(frmVueltoCliente.cboMoneda)
                '-- colocar en el combo la moneda pre determinada por el sistema
                frmVueltoCliente.cboMoneda.SelectedValue = sp_datosTabla.un_dato_integer("idMoneda", "moneda", "idmoneda", sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad))

                frmVueltoCliente.btnAceptar.Enabled = True
                frmVueltoCliente.btnCancelar.Enabled = True
                '-- bandera publica que activa el vuelto para la venta de farmacia
                bolGl_vtaFarmaciaVuelto = True

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

                frmCreditoVenta.txtCliente.Text = txtCliente.Text
                frmCreditoVenta.txtGrupoCliente.Text = txtGrupoCliente.Text
                frmCreditoVenta.txtIdCliente.Text = txtIdCliente.Text
                frmCreditoVenta.txtRucCliente.Text = txtRucCliente.Text
                frmCreditoVenta.txtTelefonoCliente.Text = txtTelefonoCliente.Text
                frmCreditoVenta.txtTotalVenta.Text = txtTotalVenta.Text
                frmCreditoVenta.txtTotalVenta.Text = Format(CDec(frmCreditoVenta.txtTotalVenta.Text), "##,###,##0.##")
                frmCreditoVenta.txtNroOrden.Text = 0
                '-- el saldo del cliente
                frmCreditoVenta.txtSaldo.Text = sp_datosTabla.sp_traerValor("sp_saldoCliente", CInt(txtIdCliente.Text), 0)
                frmCreditoVenta.txtSaldo.Text = Format(CDec(frmCreditoVenta.txtSaldo.Text), "##,###,##0.##")
                '-- realizar la diferencia
                frmCreditoVenta.txtDiferencia.Text = (CDec(frmCreditoVenta.txtSaldo.Text) + CDec(frmCreditoVenta.txtTotalVenta.Text))
                frmCreditoVenta.txtDiferencia.Text = Format(CDec(frmCreditoVenta.txtDiferencia.Text), "##,###,##0.##")
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

                frmChequeVenta.Show()
                frmChequeVenta.BringToFront()
                frmChequeVenta.txtNombreBanco.Text = ""
                frmChequeVenta.txtNroCheque.Text = 0
                frmChequeVenta.txtNombreBanco.Focus()

            Case "TPRO"
                frmPass.lblCliente.Text = txtCliente.Text
                frmPass.lblRuc.Text = txtRucCliente.Text
                frmPass.lblFormaVenta.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoVenta where idTipoVenta=" & lblIdTipoVenta.Text)
                frmPass.lblTipoVenta.Text = txtTipoventaNombre.Text
                frmPass.lblTotalVenta.Text = txtTotalVenta.Text
                frmPass.lblTotalVenta.Text = Format(CDbl(txtTotalVenta.Text), "##,###,###.##")
                frmPass.lblTotalDescuento.Text = txtTotalDescuento.Text
                frmPass.lblTotalDescuento.Text = Format(CDbl(txtTotalDescuento.Text), "##,###,###.##")
                frmPass.lblVuelto.Text = 0

                '-- solo contraeña
                frmPass.txtPass.Text = ""
                frmPass.lblVendedor.Text = ""
                frmPass.btnAceptar.Enabled = True
                frmPass.btnCancelar.Enabled = True

                Me.Enabled = False

                banGl_ventaFarmacia1 = True
                frmPass.Visible = True
                frmPass.Show()
                frmPass.BringToFront()
                frmPass.txtPass.Focus()
            Case "WEB"

                Me.Enabled = False

                'banGl_ventaFarmacia1 = True
                'frmAutorizacionWeb.Visible = True
                'frmAutorizacionWeb.Show()
                'frmAutorizacionWeb.BringToFront()
                'frmAutorizacionWeb.txtNroAutoriza.Focus()
        End Select

    End Sub

    Private Sub mostrarDetalleVenta(ByVal xidproducto As Integer, ByVal xidStock As Integer)
        '-- mostrar el detalle de la grilla de la venta
        '-- tipo de producto
        Dim intIdTipoProducto As Integer = 0
        intIdTipoProducto = sp_datosTabla.un_dato_integer("idTipoProducto", "producto", "idProducto", xidproducto)
        txtTipoProducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", intIdTipoProducto)
        '-- laboratorio
        Dim intIdLaboratorio As Integer = 0
        intIdLaboratorio = sp_datosTabla.un_dato_integer("idLaboratorio", "producto", "idProducto", xidproducto)
        txtLaboratorioProducto.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", intIdLaboratorio)
        '-- el stock del producto
        Dim tmpintIddeposito As Integer = 0
        tmpintIddeposito = sp_datosTabla.un_dato_integer("idDeposito", "stock", "idStock", xidStock)
        txtStockProducto.Text = sp_datosTabla.sp_string("sp_stockProductoDeposito", xidproducto & "," & tmpintIddeposito & ",0")
        '-- idstock
        txtIdStock.Text = xidStock
        '-- idproducto
        txtIdProducto.Text = xidproducto
        '-- la imagen de la mercaderia
        'picImagenMercaderia.Image = sp_datosTabla.consulta_valorImagen("select imagen from producto where idProducto=" & xidproducto)
        picImagenMercaderia.ImageLocation = strGl_rutaImagen + Trim(sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & xidproducto)) + ".jpg"

        'picImagenMercaderia.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", xidproducto)
        'MsgBox("Ruta de imagen  " & strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", xidproducto))
        '---------------------------------------'
        '-- totales de la tabla de cotizacion --'
        '---------------------------------------'
        '-- los parametros
        douSubtotalMoneda = sp_datosTabla.consulta_valorDouble("select subTotal from detVentaTmp where idConfig=" & intGl_idConfigPc & " and idProducto=" & xidproducto & " and idStock=" & xidStock)
        douDescuentoMoneda = sp_datosTabla.consulta_valorDouble("select sum(subtotalDescuento) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        douTotalMoneda = sp_datosTabla.consulta_valorDouble("select sum(subtotal) from detVentaTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")

        'systemClass.SqlToLv_tablaCotizacion(lvMoneda, "sp_tablaCotizacion", intGl_idEntidad & "," & douSubtotalMoneda & "," & douDescuentoMoneda & "," & douTotalMoneda)

        listar_tablaCotizacion()

        Me.Refresh()
    End Sub

    '-- verificar el teclado precionado
    Private Sub controlarTeclado(ByVal v_teclado As Keys)
        Select Case v_teclado
            Case Keys.F3

            Case Keys.F4
                '-- totalizar

            Case Keys.F5

            Case Keys.F8

            Case Keys.F9
                '-- delivery
                If txtIdTipoventa.Text = 0 Then
                    txtIdTipoventa.Text = 1
                    txtTipoventaNombre.Text = "VENTA DELIVERY"
                    txtTipoventaNombre.BackColor = Color.Black
                Else
                    txtIdTipoventa.Text = 0
                    txtTipoventaNombre.Text = "VENTA NORMAL"
                    txtTipoventaNombre.BackColor = Color.DodgerBlue
                End If
                sumarTotales()
            Case Keys.Down
                ' MsgBox("Paso por la tecla de abajo")
        End Select
    End Sub

    Private Sub listarUltimosProductosVendidos()
        systemClass.SqlToLv_detalleUltimosProductosVendidos(lvUltimoProducto, "sp_consultaUltimoProductosVendidos", intGl_idConfigPc)
    End Sub

    '- buscar por el codigo ingresado
    Public Sub buscarCodigoProducto(ByVal v_codigoIngresado As String)
        Try
            '-- varibles
            Dim intTmpIdLote As Integer
            Dim intTmpIdProducto As Integer
            Dim strTmpCodigoBarra As String
            Dim bolTmpCodigoBarraInterno As Boolean = False
            Dim intTmpIdDeposito As Integer

            '-- colocar el idDeposito de la venta
            intTmpIdDeposito = sp_datosTabla.consulta_valor("select idDepositoVenta from configPc where idConfig=" & intGl_idConfigPc)

            '-- verificar el tipo de busqueda
            If Len(v_codigoIngresado) = 6 Then
                '-- por codigo del producto
                intTmpIdProducto = CInt(sp_datosTabla.un_datoString("idProducto", "v_producto", "codigo", v_codigoIngresado))
                '-- activar la variable de que es un codigo de barra interno
                banGl_ventaFarmacia1LoteStock = False
            End If
            If Len(v_codigoIngresado) > 6 Then
                '-- por codigo de barras
                strTmpCodigoBarra = sp_datosTabla.un_datoString("codigoBarra", "v_producto", "codigoBarra", v_codigoIngresado)
                If Len(strTmpCodigoBarra) = 0 Then
                    '-- por codigo de barras generado
                    '-- solo si tiene como primer digito el 1
                    If v_codigoIngresado.Substring(0, 1) = 1 Or v_codigoIngresado.Substring(0, 1) = 3 Then
                        If Len(v_codigoIngresado) = 12 Then
                            bolTmpCodigoBarraInterno = True
                            '-----------------------------
                            '-- para los de 12 digitos
                            '-----------------------------
                            '-- idProducto
                            intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(6, 5))
                            '-- idLote
                            intTmpIdLote = v_codigoIngresado.Substring(1, 5)
                            intGl_vtaIdLote = intTmpIdLote
                            '-- activar la variable de que es un codigo de barra interno
                            banGl_ventaFarmacia1LoteStock = True
                        End If
                        If Len(v_codigoIngresado) = 13 Then
                            bolTmpCodigoBarraInterno = True
                            '-- para los de 13 digitos
                            intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(7, 5))
                            '-- idLote
                            intTmpIdLote = v_codigoIngresado.Substring(2, 5)
                            intGl_vtaIdLote = intTmpIdLote
                            '-- activar la variable de que es un codigo de barra interno
                            banGl_ventaFarmacia1LoteStock = True
                        End If
                    End If
                Else
                    bolTmpCodigoBarraInterno = False
                    '-- se encontró el codigo de barras de la mercaderia
                    intTmpIdProducto = CInt(sp_datosTabla.un_datoString("idProducto", "producto", "codigoBarra", strTmpCodigoBarra))
                    '-- activar la variable de que es un codigo de barra interno
                    banGl_ventaFarmacia1LoteStock = False
                End If
            End If
            '-- comparar si existe el codigo ingresado
            If intTmpIdProducto = 0 Then
                MessageBox.Show("No se encuentra el Codigo Ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- colocar los datos de la mercaderia
            '-- tipo de producto
            Dim intTmpIdTipoProducto As Integer
            intTmpIdTipoProducto = sp_datosTabla.consulta_valor("select idTipoProducto from producto where idProducto=" & intTmpIdProducto)
            txtTipoProducto.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoProducto where idTipoProducto=" & intTmpIdTipoProducto)
            '-- idProducto
            txtIdProducto.Text = intTmpIdProducto
            '-- laboratorio
            Dim intTmpIdLaboratorio As Integer
            intTmpIdLaboratorio = sp_datosTabla.consulta_valor("select idLaboratorio from producto where idProducto=" & intTmpIdProducto)
            txtLaboratorioProducto.Text = sp_datosTabla.consulta_valorString("select nombre from v_laboratorio where idLaboratorio=" & intTmpIdLaboratorio)
            '-- stock del producto
            txtStockProducto.Text = sp_datosTabla.consulta_valor("select sum(cantidad) from stock where idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito & " group by idProducto,idDeposito")
            '----------------------------------------------------------------------------------------------------------
            '-------------'
            '-- los lbl --'
            '-------------'
            '-- el codigo
            lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intTmpIdProducto)
            '-- la mercaderia   
            lblMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & intTmpIdProducto)
            '-- lblidProducto
            lblIdProducto.Text = intTmpIdProducto
            '-- la imagen
            'picImagenMercaderia.Image = sp_datosTabla.consulta_valorImagen("select imagen from producto where idProducto=" & intTmpIdProducto)
            picImagenMercaderia.ImageLocation = strGl_rutaImagen + Trim(sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intTmpIdProducto)) + ".jpg"

            'picImagenMercaderia.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
            'MsgBox("Valor de la ruta " & strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto))
            '----------------------------------------------------------------------------------------------------------
            '---------------------------------'
            '-- controlar si es fraccionado --'
            '---------------------------------'
            If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
                '--- producto fraccionado
                Me.Enabled = False
                banGl_ventaFarmacia1 = True

                frmFraccionado.txtIdForma.Text = 0
                frmFraccionado.listar_busqueda(intTmpIdProducto)
                frmFraccionado.Visible = True
                frmFraccionado.WindowState = FormWindowState.Normal
                frmFraccionado.Show()
                frmFraccionado.BringToFront()
            Else
                '---------------------'
                '-- producto entero --'
                '---------------------'
                If bolTmpCodigoBarraInterno = False Then
                    '----------------------------------
                    '-- controlar si tiene varios lotes
                    '----------------------------------
                    If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & intTmpIdDeposito, 0) > 0 Then
                        '-- para un lote
                        intTmpIdLote = sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & intTmpIdDeposito, 0)
                        '-- los datos
                        '----------------------'
                        '-- traer el idstock --'
                        '----------------------'
                        lblIdStock.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & intTmpIdDeposito)
                        lblForma.Text = "ENTERO"
                        lblCantfrac.Text = 1
                        '-----------------------------------------------------------------------------------
                        '-- por defecto 1 a la cantidad
                        txtCantidad.Text = 1
                        txtCantidad.Focus()
                    End If
                    If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & intTmpIdDeposito, 1) = 99 Then
                        '-- para mas de un lote
                        Me.Enabled = False
                        banGl_ventaFarmacia1 = True

                        '----------------------'
                        '-- traer el idstock --'
                        '----------------------'
                        lblForma.Text = "ENTERO"
                        lblCantfrac.Text = 1
                        '-----------------------------------------------------------------------------------
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
                    '-- no tiene stock
                    If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & intTmpIdDeposito, 1) = 0 Then
                        MessageBox.Show("Esta Mercadería no cuenta con Stock alguno..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '----------------------'
                        '-- traer el idstock --'
                        '----------------------'
                        lblIdStock.Text = 0
                        lblForma.Text = "ENTERO"
                        lblCantfrac.Text = 1
                        '-----------------------------------------------------------------------------------
                        txtCantidad.Focus()
                    End If
                Else
                    '----------------------'
                    '-- traer el idstock --'
                    '----------------------'
                    lblIdStock.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & intTmpIdDeposito)
                    lblForma.Text = "ENTERO"
                    lblCantfrac.Text = 1
                    '-----------------------------------------------------------------------------------
                    txtCantidad.Focus()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub inicializarObjetos()
        '-- txt
        txtTipoProducto.Text = ""
        txtIdProducto.Text = 0
        txtLaboratorioProducto.Text = ""
        txtIdStock.Text = 0
        txtStockProducto.Text = 0
        txtConta.Text = 0

        txtBuscar.Text = ""
        txtCantidad.Text = 1
        '-- lbl
        lblCodigo.Text = ""
        lblMercaderia.Text = ""
        lblIdStock.Text = 0
        lblIdProducto.Text = 0
        lblForma.Text = ""
        lblCantfrac.Text = 0
        '-- la imagen
        picImagenMercaderia.ImageLocation = ""

    End Sub

    '-- impresion del presupuesto
    Private Sub imprimirPresupuesto(ByVal v_idPresupuesto As Integer)
        Try
            Me.Enabled = False

            Dim pvParametros As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim rpt As New rpt_presupuesto
            Dim ofrm As New crv()
            '-- instanciar el parametro
            Dim v_idPresu As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            'asiganar el valor a los  parametros
            v_idPresu.Value = v_idPresupuesto
            v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros.Add(v_idPresu)

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            'MsgBox("Valor de idPersonaJur " & v_idPersonaJur.Value)

            rpt.DataDefinition.ParameterFields("@idPresupuesto").ApplyCurrentValues(pvParametros)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            '-- asignar los valores al objeto del reporte
            ofrm.CrystalReportViewer1.ReportSource = rpt
            '-- procedimiento para evitar el usuario y contraseña de la base de datos
            evitarPassDatabase(rpt)
            '-----------------------------------------------------------------
            '-- mostrar el reporte
            ofrm.WindowState = FormWindowState.Maximized
            ofrm.Visible = True
            ofrm.BringToFront()
            ofrm.Show()

            Me.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & "Impresion de Factura", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "Impresion de Factura"
            errorSistema(strGl_mensajeError, "Impresion de Factura", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Me.Enabled = False
        banGl_ventaFarmacia1 = True

        frmCliente_Venta.Show()
        frmCliente_Venta.BringToFront()

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
        frmCliente_Venta.WindowState = FormWindowState.Normal
        frmCliente_Venta.Show()
        frmCliente_Venta.BringToFront()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        '-- verificar si ya está en el límite la cantidad de linea
        Dim intTmpCantidadLinea As Integer

        If sp_datosTabla.consulta_valor("select cantidadLinea from factura where idSucursal=" & intGl_idSucursal & " and cantidadLinea > 0") > 0 Then
            intTmpCantidadLinea = sp_datosTabla.consulta_valor("select cantidadLinea from factura where idSucursal=" & intGl_idSucursal & " and cantidadLinea > 0")
            If intTmpCantidadLinea = sp_datosTabla.consulta_valor("select count(*) from detVentaTmp where idConfig=" & intGl_idConfigPc) Then
                MessageBox.Show("La Cantidad de linea permitida ya es superada..! Imprima la Factura o elimine un item", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        banGl_ventaFarmacia1 = True
        banGl_ventaFarmacia1LoteStock = False

        Me.Enabled = False
        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = "0"
        frmStock.Visible = True
        frmStock.WindowState = FormWindowState.Normal
        frmStock.Show()
        frmStock.txtBuscar.Focus()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If IsNumeric(txtConta.Text) Then
            If txtConta.Text > 0 Then
                '- eliminar el registro seleccionado de la tabla temporal
                sp_datosTabla.consulta_valor("delete from detVentaTmp where idConfig=" & intGl_idConfigPc & " and nro=" & txtConta.Text)
                '-- volver a sumar los totales
                sumarTotales()
            End If
        End If
    End Sub

    Private Sub btnFormaVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormaVenta.Click
        banGl_ventaFarmacia1 = True
        Me.Enabled = False
        frmFormaVenta.txtFormaVenta.Text = ""
        frmFormaVenta.Visible = True
        frmFormaVenta.WindowState = FormWindowState.Normal
        frmFormaVenta.Show()
        frmFormaVenta.lvFormaVenta.Focus()

    End Sub

    Private Sub btnTotalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTotalizar.Click
        controlarErrorVenta()
        If bolErrorGuardar = False Then
            '-- eliminar todos los registros de la tabla temporal de los medicos con receta en la venta
            sp_datosTabla.consulta_valor("delete from tmpMedicoVenta where idConfig=" & intGl_idConfigPc)
            '---------------------------------------------------------------------------------------------
            If bolMercaderiaControlado = True Then
                'controlarMercaderiaControlada()
            Else
                opcionesVenta()
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub btnPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPresupuesto.Click
        Dim intTmpIdPersona As Integer
        Dim intTmpIdVendedor As Integer

        intTmpIdPersona = sp_datosTabla.consulta_valor("select idPersona from v_usuario where idUsuario=" & intGl_idUsuario)
        intTmpIdVendedor = sp_datosTabla.consulta_valor("select idvendedor from v_vendedor where idPersona=" & intTmpIdPersona)

        If MessageBox.Show("Desea Agregar a un Presupuesto estas Mercaderías..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '-- actualizar el detalle de la venta temporal
            If (fun_guardarSp("sp_guardarPresupuesto", intGl_idConfigPc & "," & intGl_idSucursal & "," & CInt(lblIdTipoVenta.Text) & "," & CInt(txtIdCliente.Text) & "," & intTmpIdVendedor & "," & CDbl(sacarComa(txtTotalVenta.Text)) & "," & CDbl(sacarComa(txtTotalDescuento.Text)), Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Agregar al Detalle del Presupuesto...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Se guardaron con éxito todas las mercaderias en el presupuesto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                '-- imprimir el presupuesto
                Dim intTmpIdPresupuesto As Integer
                intTmpIdPresupuesto = sp_datosTabla.consulta_valor("select max(idPresupuesto) from cabPresupuesto where idconfig=" & intGl_idConfigPc & " and idSucursal=" & intGl_idSucursal)
                Me.Enabled = False

                imprimirPresupuesto(intTmpIdPresupuesto)

                Me.Enabled = True
            End If
            '--------------------------------------------
        End If
    End Sub

    Private Sub btnUtilPresu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUtilPresu.Click
        Me.Enabled = False
        frmBuscarPresupuesto.txtNombre.Text = ""
        frmBuscarPresupuesto.txtId.Text = 0
        frmBuscarPresupuesto.txtBuscar.Text = ""
        frmBuscarPresupuesto.Show()
        frmBuscarPresupuesto.BringToFront()
        frmBuscarPresupuesto.txtBuscar.Focus()

    End Sub

    Private Sub btnPreparado_Click(sender As System.Object, e As System.EventArgs) Handles btnPreparado.Click
        Me.Enabled = False

        frmOrdenPreparado.listar("")

        frmOrdenPreparado.Show()
        frmOrdenPreparado.BringToFront()
        frmOrdenPreparado.lvBuscar.Focus()

    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send("{tab}")
            If txtBuscar.Text = "" Then
                lvVenta.Focus()
            Else
                If Not IsNumeric(txtBuscar.Text.Substring(0, 1)) And txtBuscar.Text <> "" Then
                    'MsgBox("Paso 1")
                    '-- si es espacio en blanco desplegar la lista de productos de los pedidos
                    Me.Enabled = False
                    banGl_ventaFarmacia1 = True

                    'MsgBox("Paso 1.1")
                    '-- el procedimiento del formulario
                    If txtBuscar.Text <> "" Then
                        frmStock.listar_busqueda(" mercaderia like '" & Trim(txtBuscar.Text) & "%' " & " order by 3")
                    End If
                    'MsgBox("Paso 1.2")
                    '--------------------------------------------------------------------------
                    frmStock.txtBuscar.Text = ""
                    frmStock.txtIdProducto.Text = 0
                    frmStock.Show()
                    frmStock.BringToFront()
                    frmStock.lvStock.Focus()
                Else
                    'MsgBox("Paso 2")
                    If IsNumeric(txtBuscar.Text.Substring(0, 1)) = True Then
                        'MsgBox("Paso 3")
                        '-- si la busqueda es por codigo
                        buscarCodigoProducto(Trim(txtBuscar.Text))
                        txtCantidad.Focus()
                    End If
                End If
            End If



            ''-- si es por codigo del producto
            'If Not IsNumeric(txtBuscar.Text) And txtBuscar.Text <> "" Then
            '    '-- si es espacio en blanco desplegar la lista de productos de los pedidos
            '    Me.Enabled = False
            '    banGl_ventaFarmacia1 = True

            '    '-- el procedimiento del formulario
            '    If txtBuscar.Text <> "" Then
            '        frmStock.listar_busqueda(" mercaderia like '" & Trim(txtBuscar.Text) & "%' or mercaderia like '" & Trim(txtBuscar.Text) & "%'" & " order by 3")
            '    End If
            '    '--------------------------------------------------------------------------
            '    frmStock.txtBuscar.Text = ""
            '    frmStock.txtIdProducto.Text = 0
            '    frmStock.Show()
            '    frmStock.BringToFront()
            '    frmStock.lvStock.Focus()
            'End If
            'If IsNumeric(txtBuscar.Text) Then
            '    '-- si la busqueda es por codigo
            '    buscarCodigoProducto(Trim(txtBuscar.Text))
            '    txtCantidad.Focus()
            'End If
        End If
    End Sub

    Private Sub txtBuscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.LostFocus
        txtBuscar.BackColor = Color.SkyBlue
    End Sub

    Private Sub txtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        txtBuscar.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = txtNumerico(txtCantidad, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtCantidad.Text) Then
                '-- el formato
                txtCantidad.Text = Format(CDec(txtCantidad.Text), "##,##0.##")
                '-- controlar la cantidad
                If txtCantidad.Text <= 0 Then
                    MessageBox.Show("La cantidad ingresada no es válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCantidad.Text = 1
                    txtCantidad.Focus()
                    Exit Sub
                End If
                '-----------------------------------'
                '-- cargar el detalle de la venta --'
                '-----------------------------------'
                '-- colocar el idForma
                Dim intTmpIdForma As Integer
                intTmpIdForma = sp_datosTabla.consulta_valor("select idForma from cabForma where nombreForma='" & lblForma.Text & "'")
                cargarDetVentaFarmacia(CInt(txtIdCliente.Text), CInt(lblIdTipoVenta.Text), CInt(txtIdTipoventa.Text), CInt(lblIdStock.Text), CInt(lblIdProducto.Text), intTmpIdForma, CInt(txtCantidad.Text), CInt(lblCantfrac.Text))
                actualizarDetVenta()
                sumarTotales()
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                e.Handled = True
                '-- limpiar todos los objetos
                inicializarObjetos()
                txtBuscar.Focus()
                'SendKeys.Send("{tab}")
            Else
                MessageBox.Show("Debe Ingresar una cantidad válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.LostFocus
        txtCantidad.BackColor = Color.SkyBlue
    End Sub

    Private Sub txtCantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.GotFocus
        txtCantidad.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtObra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtBuscar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvVenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVenta.SelectedIndexChanged
        Dim intTmpIdProducto As Integer
        Dim intTmpIdStock As Integer
        For Each item As ListViewItem In lvVenta.SelectedItems
            If item.SubItems(1).Text <> "" Then
                txtConta.Text = CInt(item.SubItems(0).Text)
                bolOrden = sp_datosTabla.consulta_valorBoolean("select orden from detVentaTmp where idConfig=" & intGl_idConfigPc & " and nro=" & item.SubItems(0).Text)
                If bolOrden = False Then
                    intTmpIdStock = CInt(item.SubItems(10).Text)

                    intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & item.SubItems(1).Text)
                    '-- mostrar los datos
                    mostrarDetalleVenta(intTmpIdProducto, intTmpIdStock)
                End If

            Else
                txtConta.Text = 0
            End If

        Next
    End Sub

    Private Sub lvVenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVenta.GotFocus
        Dim intTmpIdProducto As Integer
        Dim intTmpIdStock As Integer
        For Each item As ListViewItem In lvVenta.SelectedItems
            If item.SubItems(1).Text <> "" Then
                txtConta.Text = CInt(item.SubItems(0).Text)
                bolOrden = sp_datosTabla.consulta_valorBoolean("select orden from detVentaTmp where idConfig=" & intGl_idConfigPc & " and nro=" & item.SubItems(0).Text)
                If bolOrden = False Then
                    '-- mostrar los datos
                    intTmpIdStock = CInt(item.SubItems(10).Text)
                    intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & item.SubItems(1).Text)
                    mostrarDetalleVenta(intTmpIdProducto, intTmpIdStock)
                End If
            Else
                txtConta.Text = 0
            End If

        Next
    End Sub

    Private Sub lvVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvVenta.KeyPress
        If IsNumeric(txtConta.Text) And txtConta.Text > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                If bolOrden = False Then
                    '-- para modificar la cantidad
                    Me.Enabled = False
                    '-- colocar los datos del registro
                    frmCantidadVenta.txtNro.Text = txtConta.Text
                    frmCantidadVenta.txtCodigo.Text = sp_datosTabla.consulta_valor("select codigo from producto where idproducto=" & txtIdProducto.Text)
                    frmCantidadVenta.txtMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idproducto=" & txtIdProducto.Text)
                    Dim intTmpidForma As Integer
                    intTmpidForma = sp_datosTabla.consulta_valor("select idForma from detVentaTmp where idConfig=" & intGl_idConfigPc & " and nro=" & txtConta.Text)
                    frmCantidadVenta.txtForma.Text = sp_datosTabla.consulta_valorString("select nombreForma from cabForma where idForma=" & intTmpidForma)
                    frmCantidadVenta.txtPrecio.Text = sp_datosTabla.consulta_valorDouble("select precioDescuento from detVentaTmp where idConfig=" & intGl_idConfigPc & " and nro=" & txtConta.Text)
                    frmCantidadVenta.txtPrecio.Text = Format(CDec(frmCantidadVenta.txtPrecio.Text), "##,###,##0")
                    frmCantidadVenta.txtCantidad.Text = sp_datosTabla.consulta_valorDouble("select cantidad from detVentaTmp where idConfig=" & intGl_idConfigPc & " and nro=" & txtConta.Text)
                    frmCantidadVenta.txtCantidadNueva.Text = sp_datosTabla.consulta_valorDouble("select cantidad from detVentaTmp where idConfig=" & intGl_idConfigPc & " and nro=" & txtConta.Text)
                    '-- verificar si tiene descuento especial
                    If sp_datosTabla.consulta_valorBoolean("select [dbo].[funTieneDescuentoEspecial](" & txtIdProducto.Text & "," & lblIdTipoVenta.Text & ")") = True Then
                        frmCantidadVenta.grDescuento.Enabled = True
                        frmCantidadVenta.txtUsuario.Text = ""
                        frmCantidadVenta.txtContra.Text = ""

                    Else
                        frmCantidadVenta.grDescuento.Enabled = False
                    End If

                    frmCantidadVenta.Show()
                    frmCantidadVenta.BringToFront()
                End If
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            inicializarObjetos()
            txtBuscar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '***************'
    '-- PICIMAGEN --'
    '***************'
    Private Sub picImagenMercaderia_Click(sender As System.Object, e As System.EventArgs) Handles picImagenMercaderia.Click
        Me.Enabled = False
        frmImagen.picImagenMercaderia.Image = picImagenMercaderia.Image
        frmImagen.Show()
        frmImagen.BringToFront()
    End Sub
    '-------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmVentaFarmacia1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtBuscar.Focus()
    End Sub

    Private Sub frmVentaFarmacia1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_ventaFarmacia1 = 0
        frmMenuPrincipal.clienteFacturacionFarmacia1.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------


End Class