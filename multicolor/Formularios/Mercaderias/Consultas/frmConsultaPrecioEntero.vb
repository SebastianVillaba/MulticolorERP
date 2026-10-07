Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmConsultaPrecioEntero
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalleResmision(ByVal v_idenvio As Integer)
        systemClass.SqlToLv_detalleModificaPrecioEnteroConsulta(lvProducto, "sp_consultaDetallePrecioEntero", v_idenvio)
    End Sub

    Public Sub actualizarCabeceraNota(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '*****************'
            '-- LA REMISION --'
            '*****************'
            '-- el idRemision
            txtIdPrecio.Text = v_idMov
            '-- el numero de factura y la fecha mas adelante
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabPrecioEntero", "idPrecio", v_idMov)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabPrecioEntero", "idPrecio", v_idMov)
            '-- nro de informativo
            txtNroInfo.Text = sp_datosTabla.consulta_valor("select nroInformativo from cabPrecioEntero where idPrecio=" & v_idMov)
            '-- fecha de informativo
            txtFecha.Text = sp_datosTabla.consulta_valorString("select fecha from cabPrecioEntero where idPrecio=" & v_idMov)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub primerRegistro(ByVal v_idenvio As Integer)
        '-- el primer registro
        listarDetalleResmision(v_idenvio)
        '-- la cabecera
        actualizarCabeceraNota(v_idenvio)
        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub anteriorRegistro(ByVal v_idenvio As Integer)
        '-- el registro anterior
        listarDetalleResmision(v_idenvio)
        '-- la cabecera
        actualizarCabeceraNota(v_idenvio)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idEnvio As Integer)
        '-- el registro anterior
        listarDetalleResmision(v_idEnvio)
        '-- la cabecera
        actualizarCabeceraNota(v_idEnvio)
    End Sub

    Private Sub ultimoRegistro(ByVal v_idEnvio As Integer)
        '-- el ultimo registro
        listarDetalleResmision(v_idEnvio)
        '-- la cabecera
        actualizarCabeceraNota(v_idEnvio)
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
        Dim intTmpIdEnvio As Integer = 0
        intTmpIdEnvio = sp_datosTabla.consulta_valor("select min(idPrecio) from cabPrecioEntero")
        ultimoRegistro(intTmpIdEnvio)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdEnvio As Integer = 0
        intTmpIdEnvio = sp_datosTabla.consulta_valor("select max(idPrecio) from cabPrecioEntero")
        ultimoRegistro(intTmpIdEnvio)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdPrecio.Text) Then
            Dim intTmpIdEnvio As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdEnvio = txtIdPrecio.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdEnvio = intTmpIdEnvio - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idPrecio", "cabPrecioEntero", "idPrecio", intTmpIdEnvio)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdEnvio = txtIdPrecio.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdEnvio <= sp_datosTabla.consulta_valor("select min(idPrecio) from cabPrecioEntero") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdPrecio.Text = sp_datosTabla.consulta_valor("select min(idPrecio) from cabPrecioEntero")
            Else
                txtIdPrecio.Text = intTmpIdEnvio
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdEnvio)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdPrecio.Text) Then
            Dim intTmpIdEnvio As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdEnvio = txtIdPrecio.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdEnvio = intTmpIdEnvio + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idPrecio", "cabPrecioEntero", "idPrecio", intTmpIdEnvio)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdEnvio = txtIdPrecio.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdEnvio >= sp_datosTabla.consulta_valor("select max(idPrecio) from cabPrecioEntero") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdPrecio.Text = sp_datosTabla.consulta_valor("select max(idPrecio) from cabPrecioEntero")
            Else
                btnAnterior.Enabled = True
                txtIdPrecio.Text = intTmpIdEnvio
            End If
            siguienteRegistro(intTmpIdEnvio)
        End If
    End Sub

    'Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
    '    '-- inicializar las variables
    '    banGl_consultaModificaPrecioEntero = True
    '    frmAnular.lblProcedimiento.Text = "ANULACION DE LA MODIFICACION DE PRECIOS"
    '    frmAnular.lblIdMov.Text = txtIdPrecio.Text
    '    frmAnular.txtPass.Text = ""
    '    frmAnular.txtUsuario.Text = ""
    '    '----------------------------
    '    Me.Enabled = False
    '    frmAnular.WindowState = FormWindowState.Normal
    '    frmAnular.Show()
    '    frmAnular.BringToFront()
    '    frmAnular.txtUsuario.Focus()
    'End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_consultaModificaPrecioEntero = True
        Me.Enabled = False

        frmBuscarPrecioEntero.txtBuscar.Text = ""
        frmBuscarPrecioEntero.txtIdMov.Text = ""

        frmBuscarPrecioEntero.WindowState = FormWindowState.Normal
        frmBuscarPrecioEntero.Show()
        frmBuscarPrecioEntero.BringToFront()
        frmBuscarPrecioEntero.txtBuscar.Focus()

    End Sub
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False
        imprimir(CInt(txtIdPrecio.Text))
        Me.Enabled = True
    End Sub

    Private Sub imprimir(ByVal codigoPrecio As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idprecio As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_precioEntero
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idprecio.Value = codigoPrecio
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idprecio)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idPrecio").ApplyCurrentValues(pvParametros)
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
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaPrecioEntero_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If banGl_buscarModificaPrecioEntero = False Then
            Dim intTmpIdEnvio As Integer = 0
            intTmpIdEnvio = sp_datosTabla.consulta_valor("select max(idPrecio) from cabPrecioEntero")
            ultimoRegistro(intTmpIdEnvio)
            banGl_buscarModificaPrecioEntero = False
        End If
    End Sub

    Private Sub frmConsultaPrecioEntero_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiaConsultasModificaPrecioEntero.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------

End Class