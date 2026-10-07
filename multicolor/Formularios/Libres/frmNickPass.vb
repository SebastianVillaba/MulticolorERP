Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Drawing.Printing
Imports System.Data.SqlClient
Public Class frmNickPass
    '*******************************'
    '-- VARIABLES DE TIPO OBJETO  --'
    '*******************************'
    Dim sp_ingresoSistema As New sp_IngresoSistema
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarVenta As New sp_cargarVenta
    '*************************'
    '-- VARIABLES ESCALARES --'
    '*************************'
    Dim intIdVenta As Integer
    '************************'
    '-- LOS PROCEDIMIENTOS --'
    '************************'
    Private Sub controlarModulo()
        If banGl_ventaFarmacia = True Then
            '-- para la farmacia
            'ventaFarmacia()
        End If
        If banGl_ventaFarmacia1 = True Then
            '-- para la farmacia1
            'ventaFarmacia1()
        End If
    End Sub

    '-- imprimir directamente en el puerto de la imnpresora
    Public Sub hojaImpresion_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles hojaImpresion.PrintPage
        Dim tmpIntIdPersonaJur As Integer
        Dim tmpIntIdSucursal As Integer
        Dim tmpIntIdCliente As Integer
        Dim tmpIntIdVendedor As Integer
        Dim tmpIntIdTipoVenta As Integer
        Dim tmpIntIdFactura As Integer
        Dim tmpStrTipoFactura As String
        Dim tmpDouTotalIVa10 As Double
        Dim tmpDouTotalIVa5 As Double
        Dim tmpDouTotalExenta As Double
        Dim tmpDouTotalGra10 As Double
        Dim tmpDouTotalGra5 As Double
        Dim tmpDouTotalVenta As Double
        Dim tmpDouTotalDescuento As Double
        Dim tmpStrVencimiento As String
        Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpIntTotalMaxiPunto As Integer
        Dim tmpIntTotalPuntaje As Integer
        Dim tmpIntTotalNroCuota As Integer
        Dim tmpIntTipoF As Integer
        Dim tmpStrRuc As String

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntIdFactura = sp_datosTabla.consulta_valor("select idFactura from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpStrVencimiento = sp_datosTabla.consulta_valorString("select convert(varchar,fechaCaduca,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpStrFechaInicio = sp_datosTabla.consulta_valorString("select convert(varchar,fechaInicio,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpDouTotalDescuento = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntTotalMaxiPunto = sp_datosTabla.consulta_valor("select sum(dv.precio) from detVenta dv where dv.maxipunto=1 and dv.precio > 0 and dv.idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntTotalPuntaje = sp_datosTabla.consulta_valor("select [dbo].[funTotalPuntajeCliente](cv.idCliente) from cabVenta cv where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntTotalNroCuota = sp_datosTabla.consulta_valor("select [dbo].[funTotalNroCuotaVenta](cv.idVenta) from cabVenta cv where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpIntTipoF = sp_datosTabla.consulta_valor("select tipoF from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)

            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta)
            If sp_datosTabla.consulta_valorBoolean("select contado from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta) = True Then
                tmpStrTipoFactura = "CONTADO"
            Else
                tmpStrTipoFactura = "CREDITO"
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 1)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select rtrim(nombreFantasia) from v_sucursal where idSucursal=" & tmpIntIdSucursal)))
            'MsgBox("Total longitud sucursal " & tmpIntLen)
            tmpIntTotalLen = ((42 - tmpIntLen) / 2) / 2
            ' MsgBox("Resultaido " & tmpIntTotalLen)

            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select space(" & tmpIntTotalLen & ")+nombreFantasia from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 20)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 40)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Italic)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 30, 55)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'RUC:'+rtrim(ruc)+'-'+ltrim(dv) from v_personaJur where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 1, 75)
            e.Graphics.DrawString("Casa Matriz: Mcal. José ", prFont, Brushes.Black, 1, 90)
            e.Graphics.DrawString("Félix Estigarribia e/ Tomás", prFont, Brushes.Black, 1, 105)
            e.Graphics.DrawString("Romero Pereira", prFont, Brushes.Black, 1, 120)
            e.Graphics.DrawString("Teléfono:071 200604", prFont, Brushes.Black, 1, 135)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 150)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 165)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 180)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrFechaInicio, prFont, Brushes.Black, 1, 255)
            e.Graphics.DrawString("Fecha Fin Vigencia: " & tmpStrVencimiento, prFont, Brushes.Black, 1, 270)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Nro. Factura:'+rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta), prFont, Brushes.Black, 1, 285)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 300)
            If tmpIntTipoF = 1 Then
                prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
                e.Graphics.DrawString("                 DELIVERY                 ", prFont, Brushes.Black, 1, 315)
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 330)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta), prFont, Brushes.Black, 1, 345)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabVenta where idVenta=" & intGl_vtaHeladeriaIdVenta), prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_vendedor where idVendedor=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 450)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Mercaderia                   ", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString("Cant     Precio      %IVA        Subtotal   ", prFont, Brushes.Black, 1, 480)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 495)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)

            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = ""

            ' MsgBox("Valor de Total Puntaje " & tmpIntTotalMaxiPunto)
            If tmpIntTotalMaxiPunto = 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL SIN MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,[dbo].[funNombreMercaderiaVenta](cv.idVenta,dv.idStock,dv.idProducto) as mercaderia, " & _
                        "([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        "dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        "(case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5 " & _
                        " from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta" & _
                        " inner join stock s on s.idStock=dv.idStock" & _
                        " inner join producto p on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intGl_vtaHeladeriaIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " union " & _
                        " select 0,0,dv.concepto as Mercaderia,1 as cantidad,dv.monto,dv.monto,10 as porcentajeImpuesto," & _
                        " 0 as exenta,dv.monto as IVA10,0 as IVA5,	(dv.monto-(dv.monto/1.1)) as gravada10,	0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaComboEstudiante dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intGl_vtaHeladeriaIdVenta & _
                        " union " & _
                        " select 0,0,'PROMO SAMSUNG CLUB 1/2 KG HELADO',1 as cantidad,0,0,10 as porcentajeImpuesto,0 as exenta,0 as IVA10," & _
                        " 0 as IVA5,0 as gravada10,0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaPromoSamsung dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intGl_vtaHeladeriaIdVenta & _
                        " order by dv.idStock desc"
            End If

            If tmpIntTotalMaxiPunto > 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL CON MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as mercaderia," & _
                        " ([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        "(case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join stock s" & _
                        " on s.idStock=dv.idStock" & _
                        " inner join producto p" & _
                        " on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intGl_vtaHeladeriaIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " and dv.maxipunto=0" & _
                        " union " & _
                        " select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as Mercaderia," & _
                        " sum([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " sum(dv.precioDescuento) as precioDescuento,sum(dv.precio) as subtotal," & _
                        " convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then 0" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " velse 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join producto p" & _
                        " on p.idProducto=dv.idProducto" & _
                        " where cv.idVenta=" & intGl_vtaHeladeriaIdVenta & _
                        " and dv.precio > 0" & _
                        " and dv.maxipunto=1" & _
                        " group by dv.idStock, p.codigo,dv.idProducto, dv.precioDescuento, dv.precio,dv.idImpuesto, dv.maxipunto, dv.porcentajeImpuesto" & _
                        " union " & _
                        " select 0 as idStock,'0' as codigo,'DESCUENTOS CONCEDIDOS' as Mercaderia,1 as cantidad," & _
                        tmpIntTotalMaxiPunto & "as precioDescuento," & (tmpIntTotalMaxiPunto * -1) & "as subtotal," & _
                        " 10 as porcentajeImpuesto,0 as exenta,0 as IVA10,	0 as IVA5,0 as gravada10,0 as gravada5," & _
                        " from cabVenta cv " & _
                        " where cv.idVenta=" & intGl_vtaHeladeriaIdVenta & _
                        " order by tipoDet"
            End If

            'txtSql.Text = sql

            'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
            'frmPedidoMercaderia.txtSql.Text = sql
            'frmPassRepartidor.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 510

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- sumar los impuestos
                        tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(10))
                        tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(11))
                        tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(7))

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(8))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(9))

                        e.Graphics.DrawString(Trim(reader.GetValue(1).ToString) + " " + reader.GetValue(2).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(3)), "##0").ToString + "        " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + _
                                              "        " + Format(CDec(reader.GetValue(6)), "##0").ToString + "%" + _
                                              "        " + Format(CDec(reader.GetValue(5)), "###,##0").ToString,
                                              prFont, Brushes.Black, 1, tmpIntContador)

                        tmpIntContador = tmpIntContador + 15
                    End While
                End Using

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & Me.ToString
                errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("TOTAL Gs.=" + Format(CDec(tmpDouTotalVenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 15)
            If tmpDouTotalDescuento > 0 Then
                prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
                e.Graphics.DrawString("Su descuento es:" & Format(CDec(tmpDouTotalDescuento), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 40)
            End If
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 55)
            If tmpDouTotalDescuento > 0 Then
                e.Graphics.DrawString("ESTA FACTURA CUENTA CON", prFont, Brushes.Black, 1, tmpIntContador + 70)
                e.Graphics.DrawString("MAXIDESCUENTO", prFont, Brushes.Black, 1, tmpIntContador + 85)

            End If
            e.Graphics.DrawString("-------------- Liquidación de IVA --------------", prFont, Brushes.Black, 1, tmpIntContador + 100)
            e.Graphics.DrawString("Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 115)
            e.Graphics.DrawString("Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 130)
            e.Graphics.DrawString("Exenta:" + Format(CDec(tmpDouTotalExenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 145)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 160)
            e.Graphics.DrawString("IVA 10%:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 175)
            e.Graphics.DrawString("IVA 5%:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 190)
            e.Graphics.DrawString("Total IVA:" + Format(CDec(tmpDouTotalGra10 + tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 210)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 230)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("DELIVERY: 071 205756 - 0985 830300", prFont, Brushes.Black, 1, tmpIntContador + 250)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("No se aceptan devoluciones pasadas las 48hs.", prFont, Brushes.Black, 1, tmpIntContador + 280)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Bold)
            e.Graphics.DrawString("ORIGINAL=CLIENTE", prFont, Brushes.Black, 1, tmpIntContador + 310)
            e.Graphics.DrawString("DUPLICADO=ARCHIVO TRIBUTARIO", prFont, Brushes.Black, 1, tmpIntContador + 325)
            e.Graphics.DrawString("TRIPLICADO=Contabilidad (No ", prFont, Brushes.Black, 1, tmpIntContador + 340)
            e.Graphics.DrawString("válido p/ crédito fiscal) ", prFont, Brushes.Black, 1, tmpIntContador + 355)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            If tmpIntTotalPuntaje > 0 Then
                '-- si tiene puntaje
                e.Graphics.DrawString("MaxiPunto:" + Format(CDec(tmpIntTotalPuntaje), "##,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 380)
            End If
            If tmpIntIdTipoVenta = 2 Then
                '-- factura a credito
                e.Graphics.DrawString("Firma:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 395)
                e.Graphics.DrawString("Aclaración:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 415)
                e.Graphics.DrawString("Cant.Cuo.:" + Format(CDec(tmpIntTotalNroCuota), "#0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 430)
            End If
            e.HasMorePages = False

            'Me.BringToFront()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub hojaImpresionSinQR_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles hojaImpresionSinQR.PrintPage
        Dim tmpIntIdPersonaJur As Integer
        Dim tmpIntIdSucursal As Integer
        Dim tmpIntIdCliente As Integer
        Dim tmpIntIdVendedor As Integer
        Dim tmpIntIdTipoVenta As Integer
        Dim tmpIntIdFactura As Integer
        Dim tmpStrTipoFactura As String
        Dim tmpDouTotalIVa10 As Double
        Dim tmpDouTotalIVa5 As Double
        Dim tmpDouTotalExenta As Double
        Dim tmpDouTotalGra10 As Double
        Dim tmpDouTotalGra5 As Double
        Dim tmpDouTotalVenta As Double
        Dim tmpDouTotalDescuento As Double
        Dim tmpStrVencimiento As String
        Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpIntTotalMaxiPunto As Integer
        Dim tmpIntTotalPuntaje As Integer
        Dim tmpIntTotalNroCuota As Integer
        Dim tmpIntTipoF As Integer
        Dim tmpStrRuc As String
        Dim tmpStrCDC1 As String
        Dim tmpStrCDC2 As String
        Dim tmpStrSerial As String

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdFactura = sp_datosTabla.consulta_valor("select idFactura from cabVenta where idVenta=" & intIdVenta)
            tmpStrVencimiento = sp_datosTabla.consulta_valorString("select convert(varchar,fechaCaduca,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpStrFechaInicio = sp_datosTabla.consulta_valorString("select convert(varchar,fechaTimbrado,103) from detVentaDTE where idVenta=" & intIdVenta)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & intIdVenta)
            tmpDouTotalDescuento = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabVenta where idVenta=" & intIdVenta)
            tmpIntTotalMaxiPunto = sp_datosTabla.consulta_valor("select sum(dv.precio) from detVenta dv where dv.maxipunto=1 and dv.precio > 0 and dv.idVenta=" & intIdVenta)
            tmpIntTotalPuntaje = sp_datosTabla.consulta_valor("select [dbo].[funTotalPuntajeCliente](cv.idCliente) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTotalNroCuota = sp_datosTabla.consulta_valor("select [dbo].[funTotalNroCuotaVenta](cv.idVenta) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTipoF = sp_datosTabla.consulta_valor("select tipoF from cabVenta where idVenta=" & intIdVenta)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)
            tmpStrCDC1 = sp_datosTabla.consulta_valorString("select substring(cdc,1,22) from detVentaDTE where idVenta=" & intIdVenta)
            tmpStrCDC2 = sp_datosTabla.consulta_valorString("select substring(cdc,23,44) from detVentaDTE where idVenta=" & intIdVenta)
            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabVenta where idVenta=" & intIdVenta)
            tmpStrSerial = sp_datosTabla.consulta_valorString("select serial from detVentaDTE where idVenta=" & intIdVenta)

            If sp_datosTabla.consulta_valorBoolean("select contado from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta) = True Then
                tmpStrTipoFactura = "CONTADO"
            Else
                tmpStrTipoFactura = "CREDITO"
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 1)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select rtrim(nombreFantasia) from v_sucursal where idSucursal=" & tmpIntIdSucursal)))
            'MsgBox("Total longitud sucursal " & tmpIntLen)
            tmpIntTotalLen = ((42 - tmpIntLen) / 2) / 2
            ' MsgBox("Resultaido " & tmpIntTotalLen)

            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select space(" & tmpIntTotalLen & ")+nombreFantasia from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 20)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 40)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Italic)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 30, 55)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'RUC:'+rtrim(ruc)+'-'+ltrim(dv) from v_personaJur where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 1, 75)
            e.Graphics.DrawString("Casa Matriz: Mcal. José ", prFont, Brushes.Black, 1, 90)
            e.Graphics.DrawString("Félix Estigarribia e/ Tomás", prFont, Brushes.Black, 1, 105)
            e.Graphics.DrawString("Romero Pereira", prFont, Brushes.Black, 1, 120)
            e.Graphics.DrawString("Teléfono:071 200604", prFont, Brushes.Black, 1, 135)
            e.Graphics.DrawString("Actividad Económica:", prFont, Brushes.Black, 1, 150)
            prFont = New Font("MS Reference Sans Serif", 7, FontStyle.Regular)
            e.Graphics.DrawString("COMERCIO AL POR MENOR DE PRODUCTOS", prFont, Brushes.Black, 1, 165)
            e.Graphics.DrawString("DE PANADERÍA, CONFITERÍA Y PASTELERÍA", prFont, Brushes.Black, 1, 180)
            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 255)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 270)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 285)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrFechaInicio, prFont, Brushes.Black, 1, 300)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("Nro. Factura Electronica:", prFont, Brushes.Black, 1, 315)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 330)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            'e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 300)
            If tmpIntTipoF = 1 Then
                prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
                e.Graphics.DrawString("                 DELIVERY                 ", prFont, Brushes.Black, 1, 345)
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_vendedor where idVendedor=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 450)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 480)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Mercaderia                   ", prFont, Brushes.Black, 1, 495)
            e.Graphics.DrawString("Cant     Precio      %IVA        Subtotal   ", prFont, Brushes.Black, 1, 510)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 525)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)

            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = ""

            ' MsgBox("Valor de Total Puntaje " & tmpIntTotalMaxiPunto)
            If tmpIntTotalMaxiPunto = 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL SIN MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,[dbo].[funNombreMercaderiaVenta](cv.idVenta,dv.idStock,dv.idProducto) as mercaderia, " & _
                        "([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        "dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        "(case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5 " & _
                        " from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta" & _
                        " inner join stock s on s.idStock=dv.idStock" & _
                        " inner join producto p on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " union " & _
                        " select 0,0,dv.concepto as Mercaderia,1 as cantidad,dv.monto,dv.monto,10 as porcentajeImpuesto," & _
                        " 0 as exenta,dv.monto as IVA10,0 as IVA5,	(dv.monto-(dv.monto/1.1)) as gravada10,	0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaComboEstudiante dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " union " & _
                        " select 0,0,'PROMO SAMSUNG CLUB 1/2 KG HELADO',1 as cantidad,0,0,10 as porcentajeImpuesto,0 as exenta,0 as IVA10," & _
                        " 0 as IVA5,0 as gravada10,0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaPromoSamsung dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " order by dv.idStock desc"
            End If

            If tmpIntTotalMaxiPunto > 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL CON MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as mercaderia," & _
                        " ([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        "(case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join stock s" & _
                        " on s.idStock=dv.idStock" & _
                        " inner join producto p" & _
                        " on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " and dv.maxipunto=0" & _
                        " union " & _
                        " select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as Mercaderia," & _
                        " sum([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " sum(dv.precioDescuento) as precioDescuento,sum(dv.precio) as subtotal," & _
                        " convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then 0" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " velse 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join producto p" & _
                        " on p.idProducto=dv.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and dv.precio > 0" & _
                        " and dv.maxipunto=1" & _
                        " group by dv.idStock, p.codigo,dv.idProducto, dv.precioDescuento, dv.precio,dv.idImpuesto, dv.maxipunto, dv.porcentajeImpuesto" & _
                        " union " & _
                        " select 0 as idStock,'0' as codigo,'DESCUENTOS CONCEDIDOS' as Mercaderia,1 as cantidad," & _
                        tmpIntTotalMaxiPunto & "as precioDescuento," & (tmpIntTotalMaxiPunto * -1) & "as subtotal," & _
                        " 10 as porcentajeImpuesto,0 as exenta,0 as IVA10,	0 as IVA5,0 as gravada10,0 as gravada5," & _
                        " from cabVenta cv " & _
                        " where cv.idVenta=" & intIdVenta & _
                        " order by tipoDet"
            End If

            'txtSql.Text = sql

            'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
            'frmPedidoMercaderia.txtSql.Text = sql
            'frmPassRepartidor.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 540

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- sumar los impuestos
                        tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(10))
                        tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(11))
                        tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(7))

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(8))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(9))

                        e.Graphics.DrawString(Trim(reader.GetValue(1).ToString) + " " + reader.GetValue(2).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(3)), "##0").ToString + "        " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + _
                                              "        " + Format(CDec(reader.GetValue(6)), "##0").ToString + "%" + _
                                              "        " + Format(CDec(reader.GetValue(5)), "###,##0").ToString,
                                              prFont, Brushes.Black, 1, tmpIntContador)

                        tmpIntContador = tmpIntContador + 15
                    End While
                End Using

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & Me.ToString
                errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("TOTAL Gs.=" + Format(CDec(tmpDouTotalVenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 15)
            If tmpDouTotalDescuento > 0 Then
                prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
                e.Graphics.DrawString("Su descuento es:" & Format(CDec(tmpDouTotalDescuento), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 40)
            End If
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 55)
            If tmpDouTotalDescuento > 0 Then
                e.Graphics.DrawString("ESTA FACTURA CUENTA CON", prFont, Brushes.Black, 1, tmpIntContador + 70)
                e.Graphics.DrawString("MAXIDESCUENTO", prFont, Brushes.Black, 1, tmpIntContador + 85)

            End If
            e.Graphics.DrawString("-------------- Liquidación de IVA --------------", prFont, Brushes.Black, 1, tmpIntContador + 100)
            e.Graphics.DrawString("Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 115)
            e.Graphics.DrawString("Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 130)
            e.Graphics.DrawString("Exenta:" + Format(CDec(tmpDouTotalExenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 145)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 160)
            e.Graphics.DrawString("IVA 10%:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 175)
            e.Graphics.DrawString("IVA 5%:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 190)
            e.Graphics.DrawString("Total IVA:" + Format(CDec(tmpDouTotalGra10 + tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 210)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 225)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("DELIVERY: 071 205756 - 0985 830300", prFont, Brushes.Black, 1, tmpIntContador + 240)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("No se aceptan devoluciones pasadas las 48hs.", prFont, Brushes.Black, 1, tmpIntContador + 255)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            If tmpIntTotalPuntaje > 0 Then
                '-- si tiene puntaje
                e.Graphics.DrawString("MaxiPunto:" + Format(CDec(tmpIntTotalPuntaje), "##,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 270)
            End If
            If tmpIntIdTipoVenta = 2 Then
                '-- factura a credito
                e.Graphics.DrawString("Firma:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 285)
                e.Graphics.DrawString("Aclaración:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 300)
                e.Graphics.DrawString("Cant.Cuo.:" + Format(CDec(tmpIntTotalNroCuota), "#0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 315)
            End If
            '-- esta parte corresponde a las especificaciones del manual tecnico de la SIFEN
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Consulte la validez de esta Factura Electrónica", prFont, Brushes.Black, 1, tmpIntContador + 355)
            e.Graphics.DrawString("con el número de CDC impreso abajo en : ", prFont, Brushes.Black, 1, tmpIntContador + 370)
            e.Graphics.DrawString(" https://ekuatia.set.gov/consultas/consultas ", prFont, Brushes.Black, 1, tmpIntContador + 385)
            prFont = New Font("Arial", 12, FontStyle.Bold)
            e.Graphics.DrawString(tmpStrCDC1, prFont, Brushes.Black, 1, tmpIntContador + 405)
            e.Graphics.DrawString(tmpStrCDC2, prFont, Brushes.Black, 1, tmpIntContador + 420)
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Este documento es una representación ", prFont, Brushes.Black, 1, tmpIntContador + 440)
            e.Graphics.DrawString("gráfica de un documento electrónico(xml)", prFont, Brushes.Black, 1, tmpIntContador + 455)
            e.Graphics.DrawString("Información de Interés del facturador ", prFont, Brushes.Black, 1, tmpIntContador + 470)
            e.Graphics.DrawString("electrónico emisor. ", prFont, Brushes.Black, 1, tmpIntContador + 485)
            '--------------------------------------------------------------------------------

            e.HasMorePages = False

            'Me.BringToFront()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim intTmpIdUsuario As Integer
            Dim intTmpIdUsuario1 As Integer
            Dim strTmpNick As String
            Dim strTmpClave As String
            Dim strTmpVendedor As String
            '-- comprobar el acceso
            '-- comprobar si es un ingreso por clave o por tarjeta
            If Len(txtPass.Text) = 12 Then
                '*************'
                ' POR TARJETA '
                '*************'
                intTmpIdUsuario = sp_datosTabla.sp_traerValorInteger("sp_tarjetaUsuario", "'" & txtPass.Text & "'" & "," & 0, 3)
            Else
                '***********'
                ' POR CLAVE '
                '***********'
                intTmpIdUsuario1 = sp_datosTabla.sp_traerValorInteger("sp_claveUsuario", "'" & txtPass.Text & "'", 3)
                strTmpNick = sp_datosTabla.consulta_valorString("select nick from v_usuario where idUsuario=" & intTmpIdUsuario1)
                strTmpClave = sp_datosTabla.sp_traerValor("sp_obtenerClaveUsuario", intTmpIdUsuario1, 0)

                intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuario from v_usuario where nick='" & strTmpNick & "'" & " and idUsuario=" & intTmpIdUsuario1)
                'intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuario from v_usuario where 
            End If
            'MsgBox("Valor de idUsuario  " & intTmpIdUsuario)

            If intTmpIdUsuario = 0 Then
                MessageBox.Show("No se encuentra como Usuario del Sistema..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If



            strTmpVendedor = sp_datosTabla.sp_traerValor("sp_vendedorUsuario", intTmpIdUsuario, 1)
            If banGl_ventaFarmacia = True Or banGl_ventaFarmacia1 = True Then
                '-- venta de farmacia
                intGl_vtaIdVendedor = CInt(sp_datosTabla.sp_traerValor("sp_vendedorUsuario", intTmpIdUsuario, 0))
                If intGl_vtaIdVendedor > 0 Then
                    '-- nombre del vendedor
                    lblVendedor.Text = strTmpVendedor
                    controlarModulo()
                Else
                    MessageBox.Show("Usted no está habilitado/a como Vendedor/a en el Sistema..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    lblVendedor.Text = ""
                    Exit Sub
                End If
            End If

            If banGl_ventaHeladeria = True Then
                'MsgBox("Valor de intTmpIdUsuario  " & intTmpIdUsuario)
                '-- venta de farmacia
                intGl_vtaHeladeriaIdVendedor = (sp_datosTabla.sp_traerValorInteger("sp_vendedorUsuario", intTmpIdUsuario, 0))
                intGl_vtaIdVendedor = CInt(sp_datosTabla.sp_traerValor("sp_vendedorUsuario", intTmpIdUsuario, 0))
                If intGl_vtaHeladeriaIdVendedor > 0 Then
                    '-- nombre del vendedor
                    lblVendedor.Text = strTmpVendedor
                    Me.Enabled = False

                    controlarModulo()

                    Me.Enabled = True
                Else
                    MessageBox.Show("Usted no está habilitado/a como Vendedor/a en el Sistema..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    lblVendedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, "controlarGuardar", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(txtUsuario.Text) = 0 Then
                MessageBox.Show("Debe ingresar un Usuario..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            e.Handled = True
            txtPass.Focus()
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(txtUsuario.Text) = 0 Then
                MessageBox.Show("Debe ingresar una Clave..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            e.Handled = True
            btnAceptar_Click(sender, e)
            'SendKeys.Send("{tab}")
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmNickPass_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        '-- verificar desde que modulo fue llamado
        If banGl_ventaFarmacia1 = True Then
            '-- para la venta de farmacia1
            banGl_ventaFarmacia1 = False
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub

End Class