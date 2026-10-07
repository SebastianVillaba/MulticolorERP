Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmConsultaArqueo
    '***************************'
    '-- VARIABLES TIPO OBJETO --'
    '***************************'
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla


    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalleCaja(ByVal v_idCaja As Integer)
        '-- el detalle de los responsables de la caja
        systemClass.SqlToLv_detalleCompra(lvPersonal, "sp_consultaPersonalArqueo", v_idCaja)

    End Sub

    '-- actualizar los datos de la caja
    Public Sub actualizarDatosCaja(ByVal v_idCaja As Integer)
        ' MsgBox("Valor de idCaja en la consulta  " & v_idCaja)
        '-- el idCaja
        txtIdCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 0)
        '-- la sucursal
        Dim intTmpIdSucursal As Integer
        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabCaja where idcaja=" & v_idCaja)
        txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursalT where idSucursal=" & intTmpIdSucursal)
        '-- fecha y hora de carga
        txtFechaHora.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 3)
        '-- movimiento imp inicial
        txtIdMovIni1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 4)
        '- movimiento imp final
        txtIdMovFin1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 5)
        '-- movimiento noimp inicial
        txtIdMovIni2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 6)
        '-- movimiento noimp final
        txtIdMovFin2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 7)
        '-- fecha inicial y final imp
        If IsNumeric(txtIdMovIni1.Text) Then
            txtFechaIni1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & txtIdMovIni1.Text)
            txtFechaFin1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & txtIdMovFin1.Text)
        End If
        '-- fecha inicial y final noimp
        If IsNumeric(txtIdMovIni2.Text) Then
            txtFechaIni2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & txtIdMovIni2.Text)
            txtFechaFin2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & txtIdMovFin2.Text)
        End If
        '-- total guaranies
        'MsgBox("Valor de total guarani  " & sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 12))
        txtTotalGuarani.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 12)
        txtTotalGuarani.Text = Format(CDec(txtTotalGuarani.Text), "###,###,##0")
        '-- total monedas
        txtTotalMoneda.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 13)
        txtTotalMoneda.Text = Format(CDec(txtTotalMoneda.Text), "###,###,##0")
        '-- total de gastos
        txtTotalGasto.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 14)
        txtTotalGasto.Text = Format(CDec(txtTotalGasto.Text), "###,###,##0")
        '-- total credito
        txtTotalCredito.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 15)
        txtTotalCredito.Text = Format(CDec(txtTotalCredito.Text), "###,###,##0")
        '-- total de tarjeta de debito
        txtTotalTarjetaDeb.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 16)
        txtTotalTarjetaDeb.Text = Format(CDec(txtTotalTarjetaDeb.Text), "###,###,##0")
        '-- total de tareta de credito
        txtTotalTarjetaCr.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 17)
        txtTotalTarjetaCr.Text = Format(CDec(txtTotalTarjetaCr.Text), "###,###,##0")
        '-- total cheque
        txtTotalCheque.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 18)
        txtTotalCheque.Text = Format(CDec(txtTotalCheque.Text), "###,###,##0")

        If sp_datosTabla.consulta_valor("select idcaja from cajamas where idCaja=" & v_idCaja) > 0 Then
            '*******************************'
            '-- si existe ajuste positivo --'
            '*******************************'
            '-- total ajuste positivo
            txtTotalCajaPositivo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 19)
            txtTotalCajaPositivo.Text = Format(CDec(txtTotalCajaPositivo.Text), "###,###,##0")
            '-- responsable de ajuste positivo
            txtRespoPositivo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 20)
            '-- fecha y hora del ajuste positivo
            txtFechaPositivo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 21)
            '-- motivo del ajuste positivo
            txtMotivoPositivo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 22)
        Else
            txtTotalCajaPositivo.Text = 0
            txtTotalCajaPositivo.Text = 0
            txtRespoPositivo.Text = ""
            txtFechaPositivo.Text = ""
            txtMotivoPositivo.Text = ""
        End If
        If sp_datosTabla.consulta_valor("select idcaja from cajamenos where idCaja=" & v_idCaja) > 0 Then
            '*******************************'
            '-- si existe ajuste negativo --'
            '*******************************'
            '-- total ajuste negativo
            txtTotalCajaNegativo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 23)
            txtTotalCajaNegativo.Text = Format(CDec(txtTotalCajaNegativo.Text), "###,###,##0")
            '-- responsable de ajuste negativo
            txtRespoNegativo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 24)
            '-- fecha y hora del ajuste negativo
            txtFechaNegativo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 25)
            '-- motivo del ajute negativo
            txtMotivoNegativo.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 26)
        Else
            txtTotalCajaNegativo.Text = 0
            txtTotalCajaNegativo.Text = 0
            txtRespoNegativo.Text = ""
            txtFechaNegativo.Text = ""
            txtMotivoNegativo.Text = ""
        End If


        '---------------------
        ' totales generales
        '---------------------
        txtTotalCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 9)
        txtTotalCaja.Text = Format(CDec(txtTotalCaja.Text), "###,###,##0")
        txtTotalSistema.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 11)
        txtTotalSistema.Text = Format(CDec(txtTotalSistema.Text), "###,###,##0")
        txtTotalDevolucion.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 10)
        txtTotalDevolucion.Text = Format(CDec(txtTotalDevolucion.Text), "###,###,##0")
        '-- la diferencia
        txtTotalDiferencia.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 27)
        txtTotalDiferencia.Text = Format(CDec(txtTotalDiferencia.Text), "###,###,##0")
        '-- total del hotel
        txtTotalHotel.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 28)
        txtTotalHotel.Text = Format(CDec(txtTotalHotel.Text), "###,###,##0")
        '---------------------------------------------------
    End Sub

    '-- el ultimo registro
    Private Sub ultimoRegistro(ByVal v_idcaja As Integer)
        '-- listar los responsables
        listarDetalleCaja(v_idcaja)
        '-- los datos
        actualizarDatosCaja(v_idcaja)
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub

    '-- el primer registro
    Private Sub primerRegistro(ByVal v_idCaja As Integer)
        '-- listar los responsables de la caja
        listarDetalleCaja(v_idCaja)
        '-- los datos
        actualizarDatosCaja(v_idCaja)
        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    '-- el registro anterior
    Private Sub anteriorRegistro(ByVal v_idCaja As Integer)
        '-- el registro anterior
        listarDetalleCaja(v_idCaja)
        '-- la cabecera
        actualizarDatosCaja(v_idCaja)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idCaja As Integer)
        '-- el registro anterior
        listarDetalleCaja(v_idCaja)
        '-- la cabecera
        actualizarDatosCaja(v_idCaja)
    End Sub

    '-- impresion de la caja
    Private Sub imprimirCaja(ByVal codigoCaja As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idCaja As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_arqueo()
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idCaja.Value = codigoCaja
        v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idCaja)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCaja").ApplyCurrentValues(pvParametros)
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
    End Sub

    '-- impresion de la caja en el ticket
    Private Sub imprimirCajaTicket(ByVal codigoCaja As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idCaja As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_arqueoTicket
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idCaja.Value = codigoCaja
        v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idCaja)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCaja").ApplyCurrentValues(pvParametros)
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
    End Sub
    '------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click

        Me.Enabled = False
        '-- verificar el tipo de impresion de la sucursal
        If (sp_datosTabla.consulta_valor("select imprimirVtaHeladeria from sucursal where hoteleria=1 and idSucursal=" & intGl_idSucursal)) = True And (sp_datosTabla.consulta_valor("select casaMatriz from sucursal where idSucursal=" & intGl_idSucursal)) = False Then
            imprimirCajaTicket(CInt(txtIdCaja.Text))
        Else
            imprimirCaja(CInt(txtIdCaja.Text))
        End If
        '---------------------------------------------------------------------------------
        Me.Enabled = True

    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        banGl_consultaArqueo = True

        Me.Enabled = False
        frmBuscarArqueo.WindowState = FormWindowState.Normal
        frmBuscarArqueo.Show()
        frmBuscarArqueo.BringToFront()
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdCaja As Integer = 0
        intTmpIdCaja = sp_datosTabla.consulta_valor("select max(idCaja) from cabCaja")
        ultimoRegistro(intTmpIdCaja)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdCaja As Integer = 0
        intTmpIdCaja = sp_datosTabla.consulta_valor("select min(idCaja) from cabCaja")
        ultimoRegistro(intTmpIdCaja)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdCaja.Text) Then
            Dim intTmpIdCaja As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdCaja = txtIdCaja.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdCaja = intTmpIdCaja - 1
                '-- buscar el numero de idCaja
                If (sp_datosTabla.un_dato_integer("idCaja", "cabCaja", "idCaja", intTmpIdCaja)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdCaja = txtIdCaja.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdCaja <= sp_datosTabla.consulta_valor("select min(idCaja) from cabCaja") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdCaja.Text = sp_datosTabla.consulta_valor("select min(idCaja) from cabCaja")
            Else
                txtIdCaja.Text = intTmpIdCaja
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdCaja)
        End If

    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdCaja.Text) Then
            Dim intTmpIdCaja As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdCaja = txtIdCaja.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdCaja = intTmpIdCaja + 1
                '-- buscar el numero de idCaja
                If (sp_datosTabla.un_dato_integer("idCaja", "cabCaja", "idCaja", intTmpIdCaja)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdCaja = txtIdCaja.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdCaja >= sp_datosTabla.consulta_valor("select max(idCaja) from cabCaja") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdCaja.Text = sp_datosTabla.consulta_valor("select max(idCaja) from cabCaja")
            Else
                btnAnterior.Enabled = True
                txtIdCaja.Text = intTmpIdCaja
            End If
            siguienteRegistro(intTmpIdCaja)
        End If
    End Sub
    '------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaArqueo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim intTmpIdCaja As Integer = 0
        intTmpIdCaja = sp_datosTabla.consulta_valor("select max(idCaja) from cabCaja")
        ultimoRegistro(intTmpIdCaja)
    End Sub

    Private Sub frmConsultaArqueo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.finanzaConsultaArqueo.Enabled = True

        e.Cancel = False
    End Sub
    '------------------------------------------------------------------------------

End Class