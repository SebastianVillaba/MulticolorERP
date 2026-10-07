Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class frmPermiso
    Dim sp_datosTabla As New sp_datosTabla
    Private sp_IngresoSistema As New sp_IngresoSistema

    Dim intIdUsuario As Integer
    Dim intIdRepartidor As Integer
    Dim bolError As Boolean
    Dim intIdFactura As Integer
    Dim intIdFacturaHotel As Integer

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMEINTOS --'
    '********************'
    '-- controlar los modulos
    Private Sub controlarModulo()
        If banGl_checkOut = True Then
            '            permisoCheckOut()
        End If
    End Sub

    '-- controlar el ingreso
    Private Sub controlarClave()
        If Len(txtPass.Text) > 0 Then
            '-- controlar primero si se ingreso el codigo de barras
            'controlar que ingrese alguna contraseña
            If txtPass.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe Ingresar la Contraseña..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtPass.Text = ""
                txtPass.Focus()
                Exit Sub
            End If
            '***********************'
            '-- NICK Y CONTRASEÑA --'
            '***********************'
            intIdUsuario = sp_datosTabla.sp_traerValorInteger("sp_claveUsuarioNick", "'" & txtUsuario.Text & "'" & "," & "'" & txtPass.Text & "'" & "," & 0, 3)
            'MsgBox("Valor de idUsuario  " & intIdUsuario)
            If intIdUsuario = 0 Then
                '-- no existe el usuario
                MessageBox.Show("No existe como Usuario dentro del Sistema..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bolError = True
                Exit Sub
            End If
            '--------------------------------------------------
        End If

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
        Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpIntTotalPuntaje As Integer
        Dim tmpIntTotalNroCuota As Integer
        Dim tmpStrRuc As String
        Dim tmpStrCDC1 As String
        Dim tmpStrCDC2 As String
        Dim tmpStrSerial As String

        'intIdFacturaHotel
        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select _vs.idPersonaJur from cabFacturaHotel cf inner join v_sucursal _vs " & _
                                                              " on cf.idSucursal=_vs.idSucursal where cf.idFacturaHotel=" & intIdFacturaHotel)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel)
            tmpIntIdFactura = sp_datosTabla.consulta_valor("select idFactura from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel)
            tmpStrFechaInicio = sp_datosTabla.consulta_valorString("select convert(varchar,fechaTimbrado,103) from detFacturaHotelDTE where idFacturaHotel=" & intIdFacturaHotel)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select totalVenta from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel)
            tmpDouTotalDescuento = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel)
            tmpIntTotalPuntaje = sp_datosTabla.consulta_valor("select [dbo].[funTotalPuntajeCliente](cv.idCliente) from cabFacturaHotel cv where idFacturaHotel=" & intIdFacturaHotel)
            tmpIntTotalNroCuota = sp_datosTabla.consulta_valor("select [dbo].[funTotalNroCuotaVenta](cv.idFacturaHotel) from cabFacturaHotel cv where idFacturaHotel=" & intIdFacturaHotel)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)
            tmpStrSerial = sp_datosTabla.consulta_valorString("select serial from detFacturaHotelDTE where idFacturaHotel=" & intIdFacturaHotel)
            tmpStrCDC1 = sp_datosTabla.consulta_valorString("select substring(cdc,1,22) from detFacturaHotelDTE where idFacturaHotel=" & intIdFacturaHotel)
            tmpStrCDC2 = sp_datosTabla.consulta_valorString("select substring(cdc,23,44) from detFacturaHotelDTE where idFacturaHotel=" & intIdFacturaHotel)
            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel)

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
            e.Graphics.DrawString("ACTIVIDADES DE ALOJAMIENTO EN HOTELES", prFont, Brushes.Black, 1, 165)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            'e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 150)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 180)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 210)
            'e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrFechaInicio, prFont, Brushes.Black, 1, 255)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("Nro. Factura Electronica:", prFont, Brushes.Black, 1, 270)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel), prFont, Brushes.Black, 1, 285)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 300)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 330)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel), prFont, Brushes.Black, 1, 345)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabFacturaHotel where idFacturaHotel=" & intIdFacturaHotel), prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_usuario where idUsuario=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 450)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Concepto                   ", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString("Cant       Precio      %IVA    Subtotal   ", prFont, Brushes.Black, 1, 480)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 495)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            '----------------'
            '-- EL DETALLE --'
            '----------------'
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "select '--',' ' as codigo,df.descripcion," & _
            " 1 as cantidad,df.precioDescuento,df.precioDescuento as subTotal,	" & _
            " convert(int,df.porcentajeImpuesto) as porcentajeImpuesto," & _
            "(case " & _
                " when df.idImpuesto=1 then df.precioDescuento" & _
                " else 0" & _
            " end) as exenta," & _
            " (case" & _
                " when df.idImpuesto=2 then df.precioDescuento" & _
                " else 0" & _
            " end) as IVA10," & _
            " (case	" & _
                " when df.idImpuesto=3 then df.precioDescuento" & _
                " else 0" & _
            " end) as IVA5," & _
            " (case" & _
                " when df.idImpuesto=2 then (df.precioDescuento-(df.precioDescuento/df.factorImpuesto))" & _
                " else 0" & _
            " end) as gravada10," & _
            " (case	" & _
                " when df.idImpuesto=3 then (df.precioDescuento-(df.precioDescuento/df.factorImpuesto))" & _
                " else 0" & _
            " end) as gravada5 " & _
            " from cabFacturaHotel cf inner join detFacturaHotelHospedaje df on cf.idFacturaHotel=df.idFacturaHotel" & _
            " where df.precioDescuento>0 and cf.idFacturaHotel=" & intIdFacturaHotel


            'txtSqlVenta.Text = sql

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

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(5))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(9))

                        e.Graphics.DrawString(Trim(reader.GetValue(1).ToString) + " " + reader.GetValue(2).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(3)), "##0").ToString + "       " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + _
                                              "      " + Format(CDec(reader.GetValue(6)), "##0").ToString + "%" + _
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
            e.Graphics.DrawString("Consulte la validez de esta Factura Electrónica", prFont, Brushes.Black, 1, tmpIntContador + 335)
            e.Graphics.DrawString("con el número de CDC impreso abajo en : ", prFont, Brushes.Black, 1, tmpIntContador + 350)
            e.Graphics.DrawString(" https://ekuatia.set.gov/consultas/consultas ", prFont, Brushes.Black, 1, tmpIntContador + 365)
            prFont = New Font("Arial", 12, FontStyle.Bold)
            e.Graphics.DrawString(tmpStrCDC1, prFont, Brushes.Black, 1, tmpIntContador + 385)
            e.Graphics.DrawString(tmpStrCDC2, prFont, Brushes.Black, 1, tmpIntContador + 400)
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Este documento es una representación ", prFont, Brushes.Black, 1, tmpIntContador + 420)
            e.Graphics.DrawString("gráfica de un documento electrónico(xml)", prFont, Brushes.Black, 1, tmpIntContador + 435)
            e.Graphics.DrawString("Información de Interés del facturador ", prFont, Brushes.Black, 1, tmpIntContador + 450)
            e.Graphics.DrawString("electrónico emisor. ", prFont, Brushes.Black, 1, tmpIntContador + 465)

            e.HasMorePages = False

            'Me.BringToFront()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '-----------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIngresar.Click
        '-- que ingrese alguna contraseña
        If txtPass.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar la Clave..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPass.Focus()
            Exit Sub
        End If
        bolError = False
        '-- controlar la clave
        controlarClave()
        '*******************************************************************
        If bolError = False Then
            controlarModulo()
        End If

    End Sub
    '-----------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '-----------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmPremiso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
    End Sub
    '-----------------------------------------------------------------


End Class