Imports System.Data.SqlClient
'Imports System.Net.Mail
Imports System.Net
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmDevolucionVenta
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarNotaCredito As New sp_cargarNotaCredito
    Dim systemClass As New SystemClass
    Dim sucursal As New Sucursal
    Dim tipoSucursal As New tipoSucursal

    Dim bolError As Boolean
    Dim intIdFacturaNcr As Integer = 0
    Dim intIdTimbrado As Integer = 0
    Dim intIdNotaDebito As Integer = 0
    Dim intIdConfig As Integer = 0
    Dim intIdDetFacturaDE As Integer = 0
    Dim intIdFacturaDE As Integer = 0

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        sucursal.comboSucursal(cboSucursal)
        tipoSucursal.comboTipoSucursal(cboTipoSucursal)
        dtpFecha.Format = DateTimePickerFormat.Custom
        dtpFecha.CustomFormat = "dd/MM/yyyy"
        limpiar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        txtDcaja.Text = ""
        txtDsuc.Text = ""
        txtFactura.Text = ""
        txtFechaFactura.Text = ""
        txtTimbrado.Text = 0
        txtFechaHora.Text = ""
        txtIdVenta.Text = 0
        txtIva10.Text = 0
        txtIva5.Text = 0
        txtCliente.Text = ""
        txtRuc.Text = ""
        txtVendedor.Text = ""
        txtTotalDescuento.Text = 0
        txtTotalFactura.Text = 0
        txtTotalIva.Text = 0
        txtExentaDet.Text = 0
        txtGra10Det.Text = 0
        txtGra5Det.Text = 0
        chkDescuento.Checked = False
        lblEmpresaContable.Text = ""
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnEliminar.Enabled = False
        btnNuevo.Enabled = True
        '-- limpiar la tabla temporal de la base de datos
        sp_datosTabla.consulta_valor("delete detNotaDebitoTmp where idConfig=" & intGl_idConfigPc)
        '-- limpiar la grilla
        listarNotaCredito()

        '-- la cabecera de la nota de credito
        txtIva10.Text = 0
        txtIva5.Text = 0
        txtTotalIva.Text = 0
        txtTotalNotaCredito.Text = 0

        '-- datos de la mercaderia a agregar
        txtCantidad.Text = 0
        lblIdStock.Text = 0
        lblCodigo.Text = ""
        lblMercaderia.Text = ""
        lblForma.Text = ""
        lblCantfrac.Text = 0
        txtCantidad.ReadOnly = True
        txtCantidad.BackColor = Color.LightSkyBlue
        btnCargar.Enabled = False

    End Sub

    Public Sub listarNotaCredito()
        systemClass.SqlToLv_detalleNotaDebitoTmp(lvNota, "sp_consultaDetalleNotaDebitoTmp", intGl_idConfigPc)
    End Sub

    Public Sub actualizarCabeceraVenta(ByVal v_idventa As Integer)
        '-- el idcompra
        txtIdVenta.Text = sp_datosTabla.un_dato_integer("idVenta", "cabVenta", "idVenta", v_idventa)
        '-- el cliente
        txtCliente.Text = sp_datosTabla.un_datoString("cliente", "cabVenta", "idVenta", v_idventa)
        '-- el ruc del cliente
        txtRuc.Text = sp_datosTabla.consulta_valorString("select ruc from cabVenta where idVenta=" & v_idventa)
        '-- dsuc
        txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabVenta", "idVenta", v_idventa)
        '-- dcaja
        txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabVenta", "idVenta", v_idventa)
        '-- factura
        txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabVenta", "idVenta", v_idventa)
        '-- fecha de la factura
        txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabVenta", "idVenta", v_idventa)
        '-- vendedor
        Dim intTmpIdVendedor As Integer = 0
        intTmpIdVendedor = sp_datosTabla.un_dato_integer("idVendedor", "cabVenta", "idVenta", v_idventa)
        txtVendedor.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_vendedorT", "idvendedor", intTmpIdVendedor)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_vendedorT", "idVendedor", intTmpIdVendedor))
        '-- fecha hora de carga
        txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabVenta", "idVenta", v_idventa)
        '-- total venta
        txtTotalFactura.Text = sp_datosTabla.un_dato_double("totalVenta", "cabVenta", "idVenta", v_idventa)
        txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
        '-- total descuento
        txtTotalDescuento.Text = sp_datosTabla.un_dato_double("totalDescuento", "cabVenta", "idVenta", v_idventa)
        If txtTotalDescuento.Text = "" Then
            txtTotalDescuento.Text = 0
        Else
            txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,###.00")
        End If
        '-- la moneda
        Dim intTmpIdCotiza As Integer = 0
        intTmpIdCotiza = sp_datosTabla.un_dato_integer("idCotiza", "cabVenta", "idVenta", v_idventa)
        lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cabCotiza", "idCotiza", intTmpIdCotiza))
        '-- la cotizacion
        lblCotiza.Text = sp_datosTabla.consulta_valorDouble("select cotizacion from cabVenta where idVenta=" & v_idventa)
        lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
        '-- tipo de venta
        lblTipoVenta.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoVenta", "idTipoVenta", sp_datosTabla.un_dato_integer("idTipoVenta", "cabVenta", "idVenta", v_idventa))
        '-- el nombre de la empresa contable
        lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabVenta", "idVenta", v_idventa))

        If sp_datosTabla.consulta_valor("select _vs.idSucursal from v_sucursal _vs inner join cabVenta cv on _vs.idSucursal=cv.idSucursal where cv.FE=1 " & _
                                        " and cv.idSucursal=" & intGl_idSucursal) > 0 Then
            intIdConfig = sp_datosTabla.consulta_valor("select idConfigPc from cabVenta where idVenta=" & v_idventa)

            intIdFacturaNcr = sp_datosTabla.consulta_valor("select idDetFacturaNcr from configPc where idConfig=" & intIdConfig)
            txtDsucN.Text = sp_datosTabla.consulta_valorString("select dsuc from detFacturaDE where idDetFacturaDE=" & intIdFacturaNcr)
            txtDcajaN.Text = sp_datosTabla.consulta_valorString("select dcaja from detFacturaDE where idDetFacturaDE=" & intIdFacturaNcr)
            txtFacturaN.Text = sp_datosTabla.consulta_valorString("select nroFactura+1 from detFacturaDE where idDetFacturaDE=" & intIdFacturaNcr)
            intIdTimbrado = sp_datosTabla.consulta_valor("select idTimbradoDE from detFacturaDETimbrado where idFacturaDE=" & sp_datosTabla.consulta_valor("select idFacturaDE from detFacturaDE where idDetFacturaDE=" & intIdFacturaNcr))
            'MsgBox("Valor de intIdTimbrado  " & intIdTimbrado)
            txtTimbrado.Text = sp_datosTabla.consulta_valor("select nroTimbrado from timbradoDE where idTimbradoDE=" & intIdTimbrado)
        End If

    End Sub

    Private Sub sumarTotal()
        '-- variables para los totales
        '-- asignar los totales
        txtTotalNotaCredito.Text = sp_datosTabla.consulta_valorDouble("select sum(subtotal) from detNotaDebitoTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalNotaCredito.Text = Format(CDec(txtTotalNotaCredito.Text), "#,###,##0.##")
        txtIva10.Text = sp_datosTabla.consulta_valorDouble("select sum(gravada10) from detNotaDebitoTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIva10.Text = Format(CDec(txtIva10.Text), "#,###,##0.##")
        txtIva5.Text = sp_datosTabla.consulta_valorDouble("select sum(gravada5) from detNotaDebitoTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIva5.Text = Format(CDec(txtIva5.Text), "#,###,##0.##")
        txtTotalIva.Text = sp_datosTabla.consulta_valorDouble("select sum(gravada10) from detNotaDebitoTmp where idConfig=" & intGl_idConfigPc & " group by idConfig") + sp_datosTabla.consulta_valorDouble("select sum(gravada5) from detNotaDebitoTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "#,###,##0.##")
    End Sub

    Private Sub controlarCargaProducto()
        Try
            '-- controlar los datos de la cabecera
            bolError = False

            If bolError = False Then
                If (fun_guardarSp("sp_agregarDetNotaDebitoTmp", intGl_idConfigPc & "," & txtIdVenta.Text & "," & lblIdStock.Text & "," & CDbl(txtCantidad.Text) & "," & _
                    lblCantfrac.Text & "," & "'" & lblForma.Text & "'", Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar el Registro en el detalle de la Nota de Debito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '----------------------------------------
                    '-- se guardo los registros
                    '-----------------------------------------'
                    '-- procedimiento para cargar la grilla --'
                    '-----------------------------------------'
                    listarNotaCredito()

                    limpiarProducto()
                    btnAgregar.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub limpiarProducto()
        '-- lbl
        lblIdStock.Text = 0
        lblCodigo.Text = ""
        lblMercaderia.Text = ""
        lblForma.Text = ""
        lblCantfrac.Text = 0
        '-- txt
        txtCantidad.Text = 0

    End Sub

    Private Sub controlarNotaCredito()
        If chkDescuento.Checked = True Then
            txtTotalNotaCredito.Text = txtGra10Det.Text
        End If
        '-- controlar que se ingrese un proveedor
        If txtCliente.Text = "" Then
            MessageBox.Show("Debe Ingresar un Cliente para realizar la Nota de Crédito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- que se ingrese un total
        If txtTotalNotaCredito.Text = "" Then
            MessageBox.Show("El Total de la Nota de Crédito no es válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim strTmpFecha As String = ""

        If Not IsNumeric(txtTimbrado.Text) Or txtTimbrado.Text = "" Then
            MessageBox.Show("Debe Introducir algún numero en el timbrado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTimbrado.Focus()
            Exit Sub
        End If

        '-- si no ingresa un nro de factura electronica valida
        If txtIdDetFacturaDE.Text = "" Or txtIdDetFacturaDE.Text = 0 Then
            MessageBox.Show("Debe ingresar una sucursal válida con factura electrónica habilitada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSucursal.Focus()
            Exit Sub
        End If

        '-- dsuc
        Dim strTmpDsuc As String
        Dim strTmpDcaja As String
        Dim strTmpFactura As String
        strTmpDsuc = "'" & txtDsucN.Text & "'"
        strTmpDcaja = "'" & txtDcajaN.Text & "'"
        strTmpFactura = "'" & txtFacturaN.Text & "'"

        '********************************'
        '-- guardar la nota de credito --'
        '********************************'
        '-- el id de la persona juridica
        Dim tmpIntIdPersonaJur As Integer
        tmpIntIdPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)

        If MessageBox.Show("Desea Guardar la Nota de Credito..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If (fun_guardarSp("sp_guardarNotaCreditoCliente", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idPersonaJur & "," & _
                              CInt(txtIdVenta.Text) & "," & txtTimbrado.Text & "," & strTmpDsuc & "," & strTmpDcaja & "," & strTmpFactura & ",'" & _
                              dtpFecha.Text & "'," & CDec(txtTotalNotaCredito.Text) & "," & intGl_idUsuario & "," & _
                              txtIdDetFacturaDE.Text & "," & chkDescuento.Checked & "," & CDbl(sacarComa(txtGra10Det.Text)), Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                If sp_datosTabla.consulta_valor("select idSucursal from v_sucursal where FE=1 and idSucursal=" & intGl_idSucursal) > 0 Then
                    '-- imprimir nota de credito electronica
                    intIdNotaDebito = sp_datosTabla.consulta_valor("select max(idNotaDebito) from cabNotaDebito where idSucursal=" & intGl_idSucursal)

                    Dim strCodigoQR As String
                    Dim intIdMov As Integer = 0

                    Try
                        '-- factura con Codigo QR
                        '-- verificar si cuenta con codigo QR
                        Dim client As New WebClient()
                        intIdMov = sp_datosTabla.consulta_valor("select idMov from tmpFactuDE_A where tipoTransa=5 and idTransa=" & intIdNotaDebito)
                        Dim response As String = client.DownloadString("http://192.168.100.236:9090/api/qr/get/" & intIdMov)
                        strCodigoQR = response
                    Catch ex As Exception
                        strCodigoQR = "http://ekuatia.set.gov.py/consultas/"
                    End Try

                    '-- insertar en la tabla temporal
                    If (fun_guardarSp("sp_actualizarCodigoQRDevolucion", intIdNotaDebito & ",'" & Trim(strCodigoQR) & "'", Me.Name)) = 0 Then
                    End If

                    Me.Enabled = False
                    '-- impresion
                    imprimirFacturaElectronicaNotaCredito(intIdNotaDebito)
                    'hojaImpresionSinQR.Print()
                    Me.Enabled = True
                End If
                limpiar()
            End If
        End If
    End Sub

    Private Sub hojaImpresionSinQR_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles hojaImpresionSinQR.PrintPage
        Dim tmpIntIdPersonaJur As Integer
        Dim tmpIntIdSucursal As Integer
        Dim tmpIntIdCliente As Integer
        Dim tmpIntIdVendedor As Integer
        Dim tmpIntIdTipoVenta As Integer
        Dim tmpStrTipoFactura As String
        Dim tmpDouTotalIVa10 As Double
        Dim tmpDouTotalIVa5 As Double
        Dim tmpDouTotalExenta As Double
        Dim tmpDouTotalGra10 As Double
        Dim tmpDouTotalGra5 As Double
        Dim tmpDouTotalVenta As Double
        Dim tmpStrVencimiento As String
        'Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpStrRuc As String
        Dim tmpStrCDC1 As String
        Dim tmpStrCDC2 As String
        Dim tmpStrSerial As String
        Dim tmpIntIdVenta As Integer
        Dim tmpStrFacturaVenta As String
        Dim tmpStrDocuAso1 As String
        Dim tmpStrDocuAso2 As String
        Dim tmpStrTipoDocuAso As String

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdVenta = sp_datosTabla.consulta_valor("select idVenta from cabNotaDebito where idNotaDebito=" & intIdNotaDebito)
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabNotaDebito where idNotaDebito=" & intIdNotaDebito)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabNotaDebito where idNotaDebito=" & intIdNotaDebito)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & tmpIntIdVenta)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & tmpIntIdVenta)
            tmpStrVencimiento = sp_datosTabla.consulta_valorString("select convert(varchar,fechaTimbrado,103) from detNotaDebitoDTE where idNotaDebito=" & intIdNotaDebito)
            tmpStrSerial = sp_datosTabla.consulta_valorString("select serial from detNotaDebitoDTE where idNotaDebito=" & intIdNotaDebito)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select total from cabNotaDebito where idNotaDebito=" & intIdNotaDebito)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)
            tmpStrCDC1 = sp_datosTabla.consulta_valorString("select substring(cdc,1,22) from detNotaDebitoDTE where idNotaDebito=" & intIdNotaDebito)
            tmpStrCDC2 = sp_datosTabla.consulta_valorString("select substring(cdc,23,44) from detNotaDebitoDTE where idNotaDebito=" & intIdNotaDebito)
            tmpStrFacturaVenta = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(factura) from cabVenta where idVenta=" & tmpIntIdVenta)
            tmpStrDocuAso1 = sp_datosTabla.consulta_valorString("select [dbo].[funCDCventa01](" & tmpIntIdVenta & ")")
            tmpStrDocuAso2 = sp_datosTabla.consulta_valorString("select [dbo].[funCDCventa02](" & tmpIntIdVenta & ")")
            tmpStrTipoDocuAso = sp_datosTabla.consulta_valorString("select [dbo].[funTipoDocuAso](" & tmpIntIdVenta & ")")


            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabVenta where idVenta=" & tmpIntIdVenta)
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
            e.Graphics.DrawString("COMERCIO AL POR MENOR DE PRODUCTOS", prFont, Brushes.Black, 1, 165)
            e.Graphics.DrawString("FARMACÉUTICOS DE USO HUMANO", prFont, Brushes.Black, 1, 180)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 255)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 270)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabNotaDebito where idNotaDebito=" & intIdNotaDebito), prFont, Brushes.Black, 1, 285)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrVencimiento, prFont, Brushes.Black, 1, 300)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Nota de Cred. Elect.:'+rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabNotaDebito where idNotaDebito=" & intIdNotaDebito), prFont, Brushes.Black, 1, 315)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 330)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabNotaDebito where idNotaDebito=" & intIdNotaDebito), prFont, Brushes.Black, 1, 345)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabVenta where idVenta=" & tmpIntIdVenta), prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_vendedor where idVendedor=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 450)
            e.Graphics.DrawString("Documento Asociado:", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString(tmpStrDocuAso1, prFont, Brushes.Black, 1, 480)
            e.Graphics.DrawString(tmpStrDocuAso2, prFont, Brushes.Black, 1, 495)
            e.Graphics.DrawString("Tipo Doc. Asociado:", prFont, Brushes.Black, 1, 510)
            e.Graphics.DrawString(tmpStrTipoDocuAso, prFont, Brushes.Black, 1, 525)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Mercaderia                   ", prFont, Brushes.Black, 1, 540)
            e.Graphics.DrawString("Cant   Precio  Prec.Des.     %IVA    Subtotal   ", prFont, Brushes.Black, 1, 555)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 570)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            '----------------'
            '-- EL DETALLE --'
            '----------------'
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "select dd.cantidad as cantidad,rtrim(p.nombreProducto)+','+ltrim(p.presentacion) " & _
                " as Mercaderia,p.codigo,dd.precio,dd.precio,dd.porcentajeImpuesto,dd.subtotal," & _
                "(case " & _
                    "when dd.porcentajeImpuesto=0 then 0 " & _
                    "else dd.subtotal " & _
                "end) as exenta," & _
             "(case " & _
                "when dd.porcentajeImpuesto=10 then (dd.subtotal-(dd.subtotal/dd.factorImpuesto)) " & _
                "else 0 " & _
            "end) as gravada10," & _
            "(case	" & _
                "when dd.porcentajeImpuesto=5 then (dd.subtotal-(dd.subtotal/dd.factorImpuesto)) " & _
                "else 0 " & _
            "end) as gravada5, " & _
            "(case " & _
                "when dd.porcentajeImpuesto=10 then dv.subtotal " & _
                "else 0 " & _
            "end) as IVA10," & _
            "(case	" & _
                "when dd.porcentajeImpuesto=5 then dv.subtotal " & _
                "else 0 " & _
            "end) as IVA5,dd.idStock " & _
            " from detNotaDebito dd inner join stock s on dv.idStock=s.idStock inner join producto p on p.idProducto=s.idProducto where dd.idNotaDebito=" & intIdNotaDebito

            'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
            'frmPedidoMercaderia.txtSql.Text = sql
            'frmPassRepartidor.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 585

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- sumar los impuestos
                        tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(8))
                        tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(9))
                        tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(7))

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(10))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(11))

                        e.Graphics.DrawString(Trim(reader.GetValue(2).ToString) + " " + reader.GetValue(1).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(0)), "##0").ToString + "   " + Format(CDec(reader.GetValue(3)), "###,##0").ToString + _
                                              "   " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + "    " + Format(CDec(reader.GetValue(5)), "##0").ToString + "%" + _
                                              "        " + Format(CDec(reader.GetValue(6)), "###,##0").ToString,
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
            e.Graphics.DrawString("-------------- Liquidación de IVA --------------", prFont, Brushes.Black, 1, tmpIntContador + 30)
            e.Graphics.DrawString("Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 45)
            e.Graphics.DrawString("Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 60)
            e.Graphics.DrawString("Exenta:" + Format(CDec(tmpDouTotalExenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 75)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 90)
            e.Graphics.DrawString("IVA 10%:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 105)
            e.Graphics.DrawString("IVA 5%:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 120)
            e.Graphics.DrawString("Total IVA:" + Format(CDec(tmpDouTotalGra10 + tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 135)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 150)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("DELIVERY: 071 205756 - 0985 830300", prFont, Brushes.Black, 1, tmpIntContador + 165)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            '-- esta parte corresponde a las especificaciones del manual tecnico de la SIFEN
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Consulte la validez de esta Factura Electrónica", prFont, Brushes.Black, 1, tmpIntContador + 180)
            e.Graphics.DrawString("con el número de CDC impreso abajo en : ", prFont, Brushes.Black, 1, tmpIntContador + 195)
            e.Graphics.DrawString(" https://ekuatia.set.gov/consultas/consultas ", prFont, Brushes.Black, 1, tmpIntContador + 205)
            prFont = New Font("Arial", 12, FontStyle.Bold)
            e.Graphics.DrawString(tmpStrCDC1, prFont, Brushes.Black, 1, tmpIntContador + 225)
            e.Graphics.DrawString(tmpStrCDC2, prFont, Brushes.Black, 1, tmpIntContador + 240)
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Este documento es una representación ", prFont, Brushes.Black, 1, tmpIntContador + 260)
            e.Graphics.DrawString("gráfica de un documento electrónico(xml)", prFont, Brushes.Black, 1, tmpIntContador + 275)
            e.Graphics.DrawString("Información de Interés del facturador ", prFont, Brushes.Black, 1, tmpIntContador + 290)
            e.Graphics.DrawString("electrónico emisor. ", prFont, Brushes.Black, 1, tmpIntContador + 305)
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

    Private Sub datosFactura(ByVal v_idSucursal As Integer)
        intIdDetFacturaDE = sp_datosTabla.consulta_valor("select idDetFacturaNcr from configPc where idConfig=" & v_idSucursal)
        intIdTimbrado = sp_datosTabla.consulta_valor("select idTimbradoDE from detFacturaDETimbrado where idFacturaDE=" & intIdFacturaDE)

        txtIdDetFacturaDE.Text = intIdDetFacturaDE
        txtTimbrado.Text = sp_datosTabla.consulta_valor("select nroTimbrado from timbradoDE where idTimbradoDE=" & intIdTimbrado)
        txtDsucN.Text = sp_datosTabla.consulta_valorString("select dsuc from detFacturaDE where idDetFacturaDE=" & intIdDetFacturaDE)
        txtDcajaN.Text = sp_datosTabla.consulta_valorString("select dcaja from detFacturaDE where idDetFacturaDE=" & intIdDetFacturaDE)
        txtFacturaN.Text = sp_datosTabla.consulta_valor("select nroFactura+1 from detFacturaDE where idDetFacturaDE=" & intIdDetFacturaDE)

    End Sub

    '-- impresion factura electronica de nota de credito
    Public Sub imprimirFacturaElectronicaNotaCredito(ByVal v_codigo As Integer)
        Dim pvParametros As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idRemi As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_ticketDevol
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idRemi.Value = v_codigo
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idRemi)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idNotaDebito").ApplyCurrentValues(pvParametros)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt

        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '--- PERSONALIZAR EL TAMAÑO
        '-----------------------------------------------------------------
        ''--- PERSONALIZAR EL TAMAÑO
        'Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        'rpt.PrintOptions.PrinterName = Trim(sp_datosTabla.consulta_valorString("select nombreImpresora from configPc where idConfig=" & intGl_idConfigPc))
        'doctoprint.PrinterSettings.PrinterName = "EPSON L3250 Series"

        'rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
        '-- imprimir directamente
        rpt.PrintToPrinter(1, False, 0, 0)

        '-- mostrar el reporte
        'ofrm.WindowState = FormWindowState.Maximized
        'ofrm.BringToFront()
        'ofrm.Show()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        banGl_notaDebito = True

        Me.Enabled = False
        frmBuscarFacturaVenta.Visible = True
        frmBuscarFacturaVenta.WindowState = FormWindowState.Normal
        frmBuscarFacturaVenta.Show()
        frmBuscarFacturaVenta.txtBuscar.Focus()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            '-- eliminar el registro de la tabla temporal
            sp_datosTabla.consulta_valor("delete from detNotaDebitoTmp where nro=" & lblNro.Text & " and idConfig=" & intGl_idConfigPc)
            '-- renumerar
            If (fun_guardarSp("sp_renumerarDetNotaDebitoTmp", intGl_idConfigPc, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Actualizar el detalle de la Nota de Débito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            'sp_datosTabla.consulta_valor("update detCompraTmp set nro=(row_number() over(order by dv.idConfig)) from detCompraTmp where
            listarNotaCredito()
            '-- volver a sumar los totales
            sumarTotal()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        controlarNotaCredito()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        '- idVenta
        frmBuscarProductoDevolucion.txtIdVenta.Text = txtIdVenta.Text
        '- el Cliente
        frmBuscarProductoDevolucion.txtCliente.Text = txtCliente.Text
        '-- dsuc
        frmBuscarProductoDevolucion.txtDsuc.Text = txtDsuc.Text
        '-- dcaja
        frmBuscarProductoDevolucion.txtDcaja.Text = txtDcaja.Text
        '-- factura
        frmBuscarProductoDevolucion.txtFactura.Text = txtFactura.Text
        '-- fecha de la factura
        frmBuscarProductoDevolucion.txtFechaFactura.Text = txtFechaFactura.Text
        '-- vendedor
        frmBuscarProductoDevolucion.txtVendedor.Text = txtVendedor.Text
        '-- fecha hora de carga
        frmBuscarProductoDevolucion.txtFechaHora.Text = txtFechaHora.Text
        '-- colocar la consulta
        frmBuscarProductoDevolucion.listarProductoVenta("where cv.idVenta=" & CInt(txtIdVenta.Text))
        Me.Enabled = False
        frmBuscarProductoDevolucion.Visible = True
        frmBuscarProductoDevolucion.Show()
        frmBuscarProductoDevolucion.BringToFront()
        frmBuscarProductoDevolucion.txtBuscar.Focus()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        '-- controlar 
        controlarCargaProducto()
        sumarTotal()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
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
            txtCantidad.Text = Format(CDec(txtCantidad.Text), "#,###.##")

            btnCargar.Focus()
        End If
    End Sub

    Private Sub maskFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub txtGra10Det_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGra10Det.KeyPress
        e.Handled = txtNumerico(txtGra10Det, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtGra10Det.Text = Format(CDec(txtGra10Det.Text), "###,###,##0")

            btnGuardar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvNota_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNota.SelectedIndexChanged
        For Each item As ListViewItem In lvNota.SelectedItems
            lblNro.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub

    Private Sub lvNota_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNota.GotFocus
        For Each item As ListViewItem In lvNota.SelectedItems
            lblNro.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------
    '***********'
    '-- COMBO --'
    '***********'
    Private Sub cboTipoSucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoSucursal.SelectedIndexChanged
        sucursal.comboSucursalTipo(cboSucursal, cboTipoSucursal.SelectedValue)
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        datosFactura(cboSucursal.SelectedValue)
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- CHECKBOX --'
    '**************'
    Private Sub chkDescuento_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkDescuento.CheckedChanged
        If chkDescuento.Checked = True Then
            '-- habilitar
            txtExentaDet.Text = 0
            txtGra10Det.Text = 0
            txtGra10Det.ReadOnly = False
            txtGra10Det.BackColor = Color.White
            txtGra5Det.Text = 0
            txtGra10Det.Focus()
        Else
            '-- deshabilitar
            txtExentaDet.Text = 0
            txtExentaDet.ReadOnly = True
            txtExentaDet.BackColor = Color.LightBlue
            txtGra10Det.Text = 0
            txtGra10Det.ReadOnly = True
            txtGra10Det.BackColor = Color.LightBlue
            txtGra5Det.Text = 0
            txtGra5Det.ReadOnly = True
            txtGra5Det.BackColor = Color.LightBlue
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmDevolucionVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        If intTmpConta > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                frmMenuPrincipal.clienteDevolucion.Enabled = True
                e.Cancel = False
            Else
                e.Cancel = True
            End If ' Call me
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            banGl_notacreditoCompra = 0
            frmMenuPrincipal.clienteDevolucion.Enabled = True
            e.Cancel = False
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------
End Class