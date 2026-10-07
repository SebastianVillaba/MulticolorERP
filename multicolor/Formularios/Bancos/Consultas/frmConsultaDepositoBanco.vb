Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmConsultaDepositoBanco
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle(ByVal v_idDeposito As Integer)
        systemClass.SqlToLv_detalleDepositoBanco(lvDetalle, "sp_consultaDetalleDeposito", v_idDeposito)
    End Sub

    Public Sub actualizarCabecera(ByVal v_idDeposito As Integer)
        Dim intTmpIdCuenta As Integer
        intTmpIdCuenta = sp_datosTabla.un_dato_integer("idCuenta", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)
        Dim intTmpIdMoneda As Integer
        intTmpIdMoneda = sp_datosTabla.un_dato_integer("idMoneda", "cuentaCorriente", "idCuenta", intTmpIdCuenta)
        '-- la moneda
        lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", intTmpIdMoneda)
        '-- la cotizacion
        If (sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad)) = intTmpIdMoneda Then
            '-- moneda configurada y utilizada en el sistema
            lblCotiza.Text = 1
        Else
            '-- otra moneda
            lblCotiza.Text = sp_datosTabla.un_dato_double("venta", "detCotiza", "idMoneda", intTmpIdMoneda)
        End If
        lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.##")
        '-- el idDepositoBanco
        txtIdDeposito.Text = v_idDeposito
        '-- la cuenta
        txtCuenta.Text = Trim(sp_datosTabla.un_datoString("nombreBanco", "cuentaCorriente", "idCuenta", intTmpIdCuenta)) & "/" & Trim(sp_datosTabla.un_datoString("nroCuenta", "cuentaCorriente", "idCuenta", intTmpIdCuenta))
        '-- nroDoc
        txtNroDoc.Text = sp_datosTabla.un_datoString("nroDoc", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)
        '-- fecha de deposito 
        txtFechaDeposito.Text = sp_datosTabla.un_datoString("fecha", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)

        '-- el personal que realizó el deposito
        Dim intTmpIdPersonal As Integer
        intTmpIdPersonal = sp_datosTabla.un_dato_integer("idPersonal", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)
        txtPersonal.Text = sp_datosTabla.consulta_valorString("select ltrim(_vp.nombre)+','+rtrim(_vp.apellido) from v_personalT _vp where idPersonal=" & intTmpIdPersonal)
        '-- fecha de la factura
        '-- responsable de la carga
        Dim intTmpIdUsuario As Integer = 0
        intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)
        txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
        '-- fecha hora de carga
        txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)
        '-- el estado
        If sp_datosTabla.un_dato_boleano("activo", "cabDepositoBanco", "idDepositoBanco", v_idDeposito) = True Then
            '-- si no está anulado
            btnAnular.Enabled = True
            lblEstado.Text = "NORMAL"
        Else
            '-- si está anulado
            btnAnular.Enabled = False
            lblEstado.Text = "ANULADO"
        End If
        '-- total del deposito
        txtTotalFactura.Text = (sp_datosTabla.un_dato_double("total", "cabDepositoBanco", "idDepositoBanco", v_idDeposito))
        txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
        '-- pc
        Dim intTmpIdConfig As Integer
        intTmpIdConfig = sp_datosTabla.un_dato_integer("idConfig", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)
        txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & intTmpIdConfig)
        Dim intTmpIdSucursal As Integer
        intTmpIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "cabDepositoBanco", "idDepositoBanco", v_idDeposito)
        txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursalT where idSucursal=" & intTmpIdSucursal)
        '-- el nombre de la empresa contable
        lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombre", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabDepositoBanco", "idDepositoBanco", v_idDeposito))

    End Sub

    '-- el primer registro
    Private Sub primerRegistro(ByVal v_idDeposito As Integer)
        '-- listar los responsables de la caja
        listarDetalle(v_idDeposito)
        '-- los datos
        actualizarCabecera(v_idDeposito)
        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    '-- el registro anterior
    Private Sub anteriorRegistro(ByVal v_idDeposito As Integer)
        listarDetalle(v_idDeposito)
        '-- la cabecera
        actualizarCabecera(v_idDeposito)
    End Sub

    '-- el registro siguiente
    Private Sub siguienteRegistro(ByVal v_idDeposito As Integer)
        listarDetalle(v_idDeposito)
        '-- la cabecera
        actualizarCabecera(v_idDeposito)
    End Sub

    '-- el ultimo registro
    Private Sub ultimoRegistro(ByVal v_idDeposito As Integer)
        listarDetalle(v_idDeposito)
        '-- los datos
        actualizarCabecera(v_idDeposito)
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub
    '-------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Dim pvParametros As New ParameterValues()
        'Dim pvIdPersonaJur As New ParameterValues()
        'Dim pvIdSucursal As New ParameterValues()
        'Dim pvIdUsuario As New ParameterValues()
        'Dim pvIdConfig As New ParameterValues()
        ''-- instaciar el parametro
        'Dim v_idCaja As New ParameterDiscreteValue()
        'Dim v_idPersonaJur As New ParameterDiscreteValue()
        'Dim v_idSucursal As New ParameterDiscreteValue()
        'Dim v_idUsuario As New ParameterDiscreteValue()
        'Dim v_idConfig As New ParameterDiscreteValue()
        ''------------------------------------
        ''-- el reporte del deposito bancario
        'Dim rpt As New rpt_arqueo()
        'Dim ofrm As New crv()
        ''asiganar el valor a los  parametros
        'v_idCaja.Value = CInt(txtIdDeposito.Text)
        'v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
        'v_idSucursal.Value = intGl_idSucursal
        'v_idUsuario.Value = intGl_idUsuario
        'v_idConfig.Value = intGl_idConfigPc
        '' añadir el parámetro a la colección de parámetros
        'pvParametros.Add(v_idCaja)
        'pvIdPersonaJur.Add(v_idPersonaJur)
        'pvIdSucursal.Add(v_idSucursal)
        'pvIdUsuario.Add(v_idUsuario)
        'pvIdConfig.Add(v_idConfig)
        '' tomar del informe, el parámetro que necesitemos,
        '' a través de su colección de campos de parámetros,
        '' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        'rpt.DataDefinition.ParameterFields("@idCaja").ApplyCurrentValues(pvParametros)
        'rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        'rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        'rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        'rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
        ''-- asignar los valores al objeto del reporte
        'ofrm.CrystalReportViewer1.ReportSource = rpt
        ''-- procedimiento para evitar el usuario y contraseña de la base de datos
        'evitarPassDatabase(rpt)
        ''-- mostrar el reporte
        'ofrm.WindowState = FormWindowState.Maximized
        'ofrm.Show()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Me.Enabled = False
        frmBuscarDepositoBanco.txtIdMov.Text = 0
        frmBuscarDepositoBanco.txtBuscar.Text = ""
        frmBuscarDepositoBanco.WindowState = FormWindowState.Normal
        frmBuscarDepositoBanco.Show()
        frmBuscarDepositoBanco.BringToFront()
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdDeposito As Integer = 0
        intTmpIdDeposito = sp_datosTabla.consulta_valor("select max(idDepositoBanco) from cabDepositoBanco")
        ultimoRegistro(intTmpIdDeposito)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdDeposito As Integer = 0
        intTmpIdDeposito = sp_datosTabla.consulta_valor("select min(idDepositoBanco) from cabDepositoBanco")
        ultimoRegistro(intTmpIdDeposito)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdDeposito.Text) Then
            Dim intTmpIdDeposito As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdDeposito = txtIdDeposito.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdDeposito = intTmpIdDeposito - 1
                '-- buscar el numero de idCaja
                If (sp_datosTabla.un_dato_integer("idDepositoBanco", "cabDepositoBanco", "idDepositoBanco", intTmpIdDeposito)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdDeposito = txtIdDeposito.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdDeposito <= sp_datosTabla.consulta_valor("select min(idDepositoBanco) from cabDepositoBanco") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdDeposito.Text = sp_datosTabla.consulta_valor("select min(idDepositoBanco) from cabDepositoBanco")
            Else
                txtIdDeposito.Text = intTmpIdDeposito
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdDeposito)
        End If

    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdDeposito.Text) Then
            Dim intTmpIdDeposito As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdDeposito = txtIdDeposito.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdDeposito = intTmpIdDeposito + 1
                '-- buscar el numero de idCaja
                If (sp_datosTabla.un_dato_integer("idDepositoBanco", "cabDepositoBanco", "idDepositoBanco", intTmpIdDeposito)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdDeposito = txtIdDeposito.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdDeposito >= sp_datosTabla.consulta_valor("select max(idDepositoBanco) from cabDepositoBanco") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdDeposito.Text = sp_datosTabla.consulta_valor("select max(idDepositoBanco) from cabDepositoBanco")
            Else
                btnAnterior.Enabled = True
                txtIdDeposito.Text = intTmpIdDeposito
            End If
            siguienteRegistro(intTmpIdDeposito)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaDepositoBanco = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE DEPOSITO BANCARIO"
        frmAnular.lblIdMov.Text = txtIdDeposito.Text
        frmAnular.txtPass.Text = ""
        frmAnular.txtUsuario.Text = ""
        '----------------------------
        Me.Enabled = False
        frmAnular.WindowState = FormWindowState.Normal
        frmAnular.Show()
        frmAnular.BringToFront()
        frmAnular.txtUsuario.Focus()
    End Sub
    '------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaDepositoBanco_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim intTmpIdDeposito As Integer = 0
        intTmpIdDeposito = sp_datosTabla.consulta_valor("select max(idDepositoBanco) from cabDepositoBanco")
        ultimoRegistro(intTmpIdDeposito)
    End Sub

    Private Sub frmConsultaDepositoBanco_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoConsultasDepositoBancario.Enabled = True

        e.Cancel = False
    End Sub
    '------------------------------------------------------------------------------


End Class