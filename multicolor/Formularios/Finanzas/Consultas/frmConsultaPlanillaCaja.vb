Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.Mail

Public Class frmConsultaPlanillaCaja
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim report As New rpt_planillaCaja

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle(ByVal v_idMov As Integer)
        systemClass.SqlToLv_detalleCajaCargada(lvDetalleCaja, "sp_consultaDetallePlanillaCaja", v_idMov)
    End Sub

    Public Sub actualizarCabecera(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            txtIdPlanilla.Text = v_idMov
            '-- el numero de factura y la fecha mas adelante
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabControlCaja", "idControlCaja", v_idMov)
            txtCargadoPor.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabControlCaja", "idControlCaja", v_idMov)
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cabControlCaja", "idControlCaja", v_idMov) = True Then
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
                                                                    v_idMov & " and tipo='PLANI'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idMov & " and tipo='PLANI'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idMov & _
                                                                   " and tipo='PLANI'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- total de la planilla
            txtTotalCobrado.Text = sp_datosTabla.consulta_valorDouble("select sum(totalIngreso) from detControlCaja where idControlCaja=" & v_idMov)
            txtTotalCobrado.Text = Format(CDec(txtTotalCobrado.Text), "###,###,###.##")
            '-- nombre de la pc
            txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & sp_datosTabla.consulta_valor _
            ("select idConfig from cabControlCaja where idControlCaja=" & v_idMov))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try


    End Sub

    Private Sub primerRegistro(ByVal v_idMov As Integer)
        '-- el primer registro
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub anteriorRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
    End Sub

    Private Sub ultimoRegistro(ByVal v_idMov As Integer)
        '-- el ultimo registro
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select min(idControlCaja) from cabControlCaja")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select max(idControlCaja) from cabControlCaja")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdPlanilla.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdPlanilla.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idControlCaja", "cabControlCaja", "idControlCaja", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdPlanilla.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idControlCaja) from cabControlCaja") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdPlanilla.Text = sp_datosTabla.consulta_valor("select min(idControlCaja) from cabControlCaja")
            Else
                txtIdPlanilla.Text = intTmpIdMov
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdPlanilla.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdPlanilla.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idControlCaja", "cabControlCaja", "idControlCaja", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdPlanilla.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idControlCaja) from cabControlCaja") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdPlanilla.Text = sp_datosTabla.consulta_valor("select max(idControlCaja) from cabControlCaja")
            Else
                btnAnterior.Enabled = True
                txtIdPlanilla.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaPlanillaCaja = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE PLANILLA DE CAJAS"
        frmAnular.lblIdMov.Text = txtIdPlanilla.Text
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
        banGl_consultaPlanillaCaja = True
        Me.Enabled = False

        frmBuscarPlanillaCaja.txtBuscar.Text = ""
        frmBuscarPlanillaCaja.txtIdMov.Text = ""

        frmBuscarPlanillaCaja.WindowState = FormWindowState.Normal
        frmBuscarPlanillaCaja.Show()
        frmBuscarPlanillaCaja.BringToFront()
        frmBuscarPlanillaCaja.txtBuscar.Focus()

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False

        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idPlanilla As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_planillaCaja
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idPlanilla.Value = CInt(txtIdPlanilla.Text)
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idPlanilla)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idControlCaja").ApplyCurrentValues(pvParametros)
        rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt

        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Show()

        generarArchivoPdf("planilla")

        Me.Enabled = True
    End Sub

    '-- generar archivo pdf
    Private Sub generarArchivoPdf(ByVal v_nombre As String)

        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
        Dim CrExportOptions As ExportOptions

        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idPlanilla As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()

        Dim Ruta As String = "c:\Temp\report.pdf"
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()


        CrDiskFileDestinationOptions.DiskFileName = Ruta
        CrExportOptions = report.ExportOptions

        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        'asiganar el valor a los  parametros
        v_idPlanilla.Value = CInt(txtIdPlanilla.Text)
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idPlanilla)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        report.DataDefinition.ParameterFields("@idControlCaja").ApplyCurrentValues(pvParametros)
        report.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        report.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        report.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        report.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

        evitarPassDatabase(report)

        If existeArchivoReportePdf(Ruta) = True Then
            '-- eliminar el archivo de datos de la pc que se encuentra en el servidor
            eliminarArchivoReportePdf(Ruta)
            '-- escribir el nombre del archivo de los datos de la pc en el archivo dentro del servidor
            'escribirDatosPc(lblHost.Text, lblIp.Text, lblSerialHd.Text, "c:\SanJuan\" & lblHost.Text & ".txt")
            'MsgBox("Paso por aca 2" & "c:\SanJuan\" & lblHost.Text & ".txt")
        End If


        report.Export()

        Dim archivo As Net.Mail.Attachment = New Net.Mail.Attachment(Ruta)
        'enviarCorreo("info@sanjuanelectrodomesticos.com.py", "ninofer80@yahoo.com", "NetJoin - Planilla de Caja ", "Planilla de Caja", archivo)
        'enviarCorreo("info@sanjuanelectrodomesticos.com.py", "ninofer80@yahoo.com", "NetJoin - Planilla de Caja ", "Planilla de Caja")

        report.Close()
        CrExportOptions = Nothing
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaPlanillaCaja_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If banGl_buscarPlanillaCaja = False Then
            Dim intTmpIdMov As Integer = 0
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idControlCaja) from cabControlCaja")
            ultimoRegistro(intTmpIdMov)
            banGl_buscarPlanillaCaja = False
        End If
    End Sub

    Private Sub frmConsultaPlanillaCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.finanzaConsultaPlanillaCaja.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------
End Class