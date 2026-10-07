Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net

Public Class frmConsultaDevolucionVenta
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdNotaDebito As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalleNotaCredito(ByVal v_idnota As Integer)
        systemClass.SqlToLv_detalleNotaDebito(lvProducto, "sp_consultaDetalleNotaDebito", v_idnota)
    End Sub

    Private Sub primerRegistro(ByVal v_idnota As Integer)
        '-- el primer registro
        listarDetalleNotaCredito(v_idnota)
        '-- la cabecera
        actualizarCabeceraNota(v_idnota)
    End Sub

    Private Sub anteriorRegistro(ByVal v_idnota As Integer)
        '-- el registro anterior
        listarDetalleNotaCredito(v_idnota)
        '-- la cabecera
        actualizarCabeceraNota(v_idnota)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idnota As Integer)
        '-- el registro anterior
        listarDetalleNotaCredito(v_idnota)
        '-- la cabecera
        actualizarCabeceraNota(v_idnota)
    End Sub

    Private Sub ultimoRegistro(ByVal v_idnota As Integer)
        '-- el ultimo registro
        listarDetalleNotaCredito(v_idnota)
        '-- la cabecera
        actualizarCabeceraNota(v_idnota)
    End Sub

    Public Sub actualizarCabeceraNota(ByVal v_idnota As Integer)
        ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
        '**************'
        '-- LA VENTA --'
        '**************'
        '-- el idVenta
        txtIdVenta.Text = sp_datosTabla.un_dato_integer("idVenta", "cabNotaDebito", "idNotaDebito", v_idnota)
        '-- la obra
        txtObra.Text = sp_datosTabla.consulta_valorString("select nombreObra from cabventa where idVenta=" & txtIdVenta.Text)
        '-- el idVenta
        Dim intTmpIdVenta As Integer = 0
        intTmpIdVenta = sp_datosTabla.un_dato_integer("idVenta", "cabNotaDebito", "idNotaDebito", v_idnota)
        '-- el cliente
        txtCliente.Text = sp_datosTabla.un_datoString("cliente", "cabVenta", "idVenta", CInt(txtIdVenta.Text))
        '-- el ruc
        txtRuc.Text = sp_datosTabla.consulta_valorString("select ruc from cabVenta where idVenta=" & CInt(txtIdVenta.Text))
        '-- dsuc
        txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabVenta", "idVenta", intTmpIdVenta)
        '-- dcaja
        txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabVenta", "idVenta", intTmpIdVenta)
        '-- factura
        txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabVenta", "idVenta", intTmpIdVenta)
        '-- fecha de la factura
        txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabVenta", "idVenta", intTmpIdVenta)
        '-- total de la compra
        txtTotalCompra.Text = sp_datosTabla.un_dato_double("totalVenta", "cabVenta", "idVenta", intTmpIdVenta)
        txtTotalCompra.Text = Format(CDec(txtTotalCompra.Text), "###,###,###.00")

        '**********************
        '-- NOTA DE CREDITO --'
        '**********************
        '-- idNotaCredito
        txtIdNota.Text = v_idnota
        '-- nro de la factura
        txtDsucN.Text = sp_datosTabla.un_datoString("dsuc", "cabNotaDebito", "idNotaDebito", v_idnota)
        txtDcajaN.Text = sp_datosTabla.un_datoString("dcaja", "cabNotaDebito", "idNotaDebito", v_idnota)
        txtFacturaN.Text = sp_datosTabla.un_datoString("factura", "cabNotaDebito", "idNotaDebito", v_idnota)
        '-- fecha de la factura
        txtFechaN.Text = sp_datosTabla.un_datoString("fecha", "cabNotaDebito", "idNotaDebito", v_idnota)
        '-- responsable de la carga
        Dim intTmpIdUsuario As Integer = 0
        intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabNotaDebito", "idNotaDebito", v_idnota)
        txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
        '-- fecha y hora de carga
        txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabNotaDebito", "idNotaDebito", v_idnota)
        '-- el estado
        If sp_datosTabla.un_dato_boleano("activo", "cabNotaDebito", "idNotaDebito", v_idnota) = True Then
            '-- si no está anulado
            btnAnular.Enabled = True
            lblEstado.Text = "NORMAL"
            btnAnular.Enabled = True
            lblEstado.ForeColor = Color.Green
            '-- datos de la anulacion
            txtAnuladoPor.Text = ""
            txtFechaAnulado.Text = ""
            txtExplica.Text = ""
            '---------------------------------------------------------------------------------------------------------------------
        Else
            '-- si está anulado
            btnAnular.Enabled = False
            lblEstado.Text = "ANULADO"
            btnAnular.Enabled = False
            lblEstado.ForeColor = Color.Red
            '--- datos de la anulacion
            Dim intTmpIdUsuarioAnulado As Integer
            intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                v_idnota & " and tipo='NOTADEV'")
            txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                 "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
            txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                v_idnota & " and tipo='NOTADEV'")
            txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idnota & _
                                                               " and tipo='NOTADEV'")
            '---------------------------------------------------------------------------------------------------------------------
        End If
        '-- total de la nota de credito
        txtTotalFactura.Text = sp_datosTabla.consulta_valor("select total from cabNotaDebito where idNotaDebito=" & v_idnota)
        txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,##0")

        '-- la moneda
        Dim intTmpIdCotiza As Integer
        intTmpIdCotiza = sp_datosTabla.consulta_valor("select idCotiza from cabVenta where idVenta=" & intTmpIdVenta)
        Dim intTmpIdMoneda As Integer
        intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cabCotiza where idCotiza=" & intTmpIdCotiza)
        lblMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idmoneda=" & intTmpIdMoneda)
        '-- la cotizacion
        lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cabVenta", "idVenta", intTmpIdVenta)
        lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,##0")
        '-- total iva 10
        txtIva10.Text = sp_datosTabla.sp_string("sp_totalIVA10NotaDebito", v_idnota)
        If txtIva10.Text = "" Then
            txtIva10.Text = 0
        Else
            txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,##0")
        End If
        '-- total iva 5
        txtIva5.Text = sp_datosTabla.sp_string("sp_totalIVA5NotaDebito", v_idnota)
        If txtIva5.Text = "" Then
            txtIva5.Text = 0
        Else
            txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,##0")
        End If

        '-- total iva
        txtTotalIva.Text = CDec(txtIva10.Text) + CDec(txtIva5.Text)
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,##0")
        '-- el nombre de la empresa contable
        Dim intTmpIdPersonaJur As Integer
        intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & intTmpIdVenta)
        lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & intTmpIdPersonaJur)
        '-- el cdc
        txtCdc.Text = sp_datosTabla.consulta_valorString("select cdc from detNotaDebitoDTE where idNotaDebito=" & v_idnota)
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
        'rpt.PrintToPrinter(1, False, 0, 0)

        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.BringToFront()
        ofrm.Show()
    End Sub
    '---------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdNota As Integer = 0
        intTmpIdNota = sp_datosTabla.consulta_valor("select min(idNotaDebito) from cabNotaDebito")
        ultimoRegistro(intTmpIdNota)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdNota As Integer = 0
        intTmpIdNota = sp_datosTabla.consulta_valor("select max(idNotaDebito) from cabNotaDebito")
        ultimoRegistro(intTmpIdNota)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdNota.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdNota.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idNotaDebito", "cabNotaDebito", "idNotaDebito", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdNota.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idNotaDebito) from cabNotaDebito") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdNota.Text = sp_datosTabla.consulta_valor("select min(idNotaDebito) from cabNotaDebito")
            Else
                txtIdNota.Text = intTmpIdMov
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdMov)
        End If

    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdNota.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdNota.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idNotaDebito", "cabNotaDebito", "idNotaDebito", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdNota.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idNotaDebito) from cabNotaDebito") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdNota.Text = sp_datosTabla.consulta_valor("select max(idNotaDebito) from cabNotaDebito")
            Else
                btnAnterior.Enabled = True
                txtIdNota.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_anularNotaDebito = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE NOTA DE DEBITO"
        frmAnular.lblIdMov.Text = txtIdNota.Text
        frmAnular.txtPass.Text = ""
        frmAnular.txtUsuario.Text = ""
        '----------------------------
        Me.Enabled = False
        frmAnular.WindowState = FormWindowState.Normal
        frmAnular.Show()
        frmAnular.BringToFront()
        frmAnular.txtUsuario.Focus()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_buscarNotaDebito = True
        Me.Enabled = False
        frmBuscarDevolucion.WindowState = FormWindowState.Normal
        frmBuscarDevolucion.Show()
        frmBuscarDevolucion.BringToFront()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False
        '-- actualizar el qr
        Dim strCodigoQR As String
        Dim intIdMov As Integer = 0
        Try
            '-- factura con Codigo QR
            '-- verificar si cuenta con codigo QR
            Dim client As New WebClient()
            intIdMov = sp_datosTabla.consulta_valor("select idMov from tmpFactuDE_A where tipoTransa=5 and idTransa=" & sacarComa(txtIdNota.Text))
            Dim response As String = client.DownloadString("http://192.168.100.236:9090/api/qr/get/" & intIdMov)
            strCodigoQR = response
        Catch ex As Exception
            strCodigoQR = "http://ekuatia.set.gov.py/consultas/"
        End Try

        '-- insertar en la tabla temporal
        If (fun_guardarSp("sp_actualizarCodigoQRDevolucion", sacarComa(txtIdNota.Text) & ",'" & Trim(strCodigoQR) & "'", Me.Name)) = 0 Then
        End If

        imprimirFacturaElectronicaNotaCredito(CInt(sacarComa(txtIdNota.Text)))

        Me.Enabled = True


    End Sub
    '---------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmConsultaDevolucionVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteConsultaNotaCredito.Enabled = True
        e.Cancel = False
    End Sub

    Private Sub frmConsultaDevolucionVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If banGl_buscarNotaDebito = False Then
            Dim intTmpIdNotaDebito As Integer = 0
            intTmpIdNotaDebito = sp_datosTabla.consulta_valor("select max(idNotaDebito) from cabNotaDebito")
            ultimoRegistro(intTmpIdNotaDebito)
            banGl_buscarNotaCredito = 0
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------
End Class