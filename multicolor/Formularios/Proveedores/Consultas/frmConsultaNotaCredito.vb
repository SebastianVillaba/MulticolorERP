Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmConsultaNotaCredito
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
    Public Sub listarDetalleNotaCredito(ByVal v_idnota As Integer)
        systemClass.SqlToLv_detalleNotaCredito(lvDetalleNotaCredito, "sp_consultaDetalleNotaCredito", v_idnota)
    End Sub

    Public Sub actualizarCabeceraNota(ByVal v_idnota As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '***************'
            '-- LA COMPRA --'
            '***************'
            '-- el idcompra
            txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cabNotaCredito", "idNotaCredito", v_idnota)
            '-- el proveedor
            '-- idcompra
            Dim intTmpIdCompra As Integer = 0
            intTmpIdCompra = sp_datosTabla.un_dato_integer("idCompra", "cabNotaCredito", "idNotaCredito", v_idnota)

            txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cabcompra", "idCompra", intTmpIdCompra))
            '-- dsuc
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabCompra", "idCompra", intTmpIdCompra)
            '-- dcaja
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabCompra", "idCompra", intTmpIdCompra)
            '-- factura
            txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabCompra", "idCompra", intTmpIdCompra)
            '-- fecha de la factura
            txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabCompra", "idCompra", intTmpIdCompra)
            '-- total de la compra
            txtTotalCompra.Text = sp_datosTabla.un_dato_double("total", "cabcompra", "idCompra", intTmpIdCompra)
            txtTotalCompra.Text = Format(CDec(txtTotalCompra.Text), "###,###,###.00")

            '**********************
            '-- NOTA DE CREDITO --'
            '**********************
            '-- idNotaCredito
            txtIdNota.Text = v_idnota
            '-- responsable de la nota de credito
            txtResponsable.Text = sp_datosTabla.un_datoString("responsable", "cabNotaCredito", "idNotaCredito", v_idnota)
            '-- nro de la factura
            txtDsucN.Text = sp_datosTabla.un_datoString("dsuc", "cabNotaCredito", "idNotaCredito", v_idnota)
            txtDcajaN.Text = sp_datosTabla.un_datoString("dcaja", "cabNotaCredito", "idNotaCredito", v_idnota)
            txtFacturaN.Text = sp_datosTabla.un_datoString("factura", "cabNotaCredito", "idNotaCredito", v_idnota)
            '-- fecha de la factura
            txtFechaN.Text = sp_datosTabla.un_datoString("fecha", "cabNotaCredito", "idNotaCredito", v_idnota)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabNotaCredito", "idNotaCredito", v_idnota)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabNotaCredito", "idNotaCredito", v_idnota)
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cabNotaCredito", "idNotaCredito", v_idnota) = True Then
                '-- si no está anulado
                btnAnular.Enabled = True
                lblEstado.Text = "NORMAL"
                lblEstado.ForeColor = Color.Green
                btnAnular.Enabled = True
                '-- datos de la anulacion
                txtAnuladoPor.Text = ""
                txtFechaAnulado.Text = ""
                txtExplica.Text = ""
                '---------------------------------------------------------------------------------------------------------------------
            Else
                '-- si está anulado
                btnAnular.Enabled = False
                lblEstado.Text = "ANULADO"
                lblEstado.ForeColor = Color.Red
                btnAnular.Enabled = False
                '--- datos de la anulacion
                Dim intTmpIdUsuarioAnulado As Integer
                intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idnota & " and tipo='NOTACR'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idnota & " and tipo='NOTACR'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idnota & _
                                                                   " and tipo='NOTACR'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- si está pndiente
            If sp_datosTabla.un_dato_boleano("pendiente", "cabNotaCredito", "idNotaCredito", v_idnota) = True Then
                lblPendiente.Visible = True
                lblPendiente.Text = "PENDIENTE"
                lblPendiente.ForeColor = Color.Red
                btnCancelar.Enabled = True
            Else
                lblPendiente.Visible = True
                lblPendiente.Text = "CANCELADO"
                lblPendiente.ForeColor = Color.Blue
                btnAnular.Enabled = False
                btnCancelar.Enabled = False
            End If
            '-- total de la nota de credito
            txtTotalFactura.Text = sp_datosTabla.consulta_valor("select sum(subtotal) from detNotaCredito where idNotaCredito=" & v_idnota)
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")

            '-- la moneda
            lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cabCompra", "idCompra", intTmpIdCompra))
            '-- la cotizacion
            lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cabCompra", "idCompra", intTmpIdCompra)
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
            '-- total iva 10
            txtIva10.Text = sp_datosTabla.sp_string("sp_totalIVA10NotaCredito", v_idnota)
            If txtIva10.Text = "" Then
                txtIva10.Text = 0
            Else
                txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,###.00")
            End If
            '-- total iva 5
            txtIva5.Text = sp_datosTabla.sp_string("sp_totalIVA5NotaCredito", v_idnota)
            If txtIva5.Text = "" Then
                txtIva5.Text = 0
            Else
                txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,###.00")
            End If

            '-- total iva
            txtTotalIva.Text = CDec(txtIva10.Text) + CDec(txtIva5.Text)
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,###.00")
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabCompra", "idCompra", intTmpIdCompra))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try


    End Sub

    Private Sub primerRegistro(ByVal v_idnota As Integer)
        '-- el detalle
        listarDetalleNotaCredito(v_idnota)
        '-- la cabecera
        actualizarCabeceraNota(v_idnota)

        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
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
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub
    '------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdNota As Integer = 0
        intTmpIdNota = sp_datosTabla.consulta_valor("select min(idNotaCredito) from cabNotaCredito")
        ultimoRegistro(intTmpIdNota)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnSiguiente.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdNota As Integer = 0
        intTmpIdNota = sp_datosTabla.consulta_valor("select max(idNotaCredito) from cabNotaCredito")
        ultimoRegistro(intTmpIdNota)
        '-- inhabilitar el boton de siguiente
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
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
                If (sp_datosTabla.un_dato_integer("idNotaCredito", "cabNotaCredito", "idNotaCredito", intTmpIdMov)) > 0 Then
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
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idNotaCredito) from cabNotaCredito") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdNota.Text = sp_datosTabla.consulta_valor("select min(idNotaCredito) from cabNotaCredito")
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
                If (sp_datosTabla.un_dato_integer("idNotaCredito", "cabNotaCredito", "idNotaCredito", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdNota.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idNotaCredito) from cabNotaCredito") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdNota.Text = sp_datosTabla.consulta_valor("select max(idNotaCredito) from cabNotaCredito")
            Else
                btnAnterior.Enabled = True
                txtIdNota.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_anularNotaCredito = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE NOTA DE CREDITO"
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
        banGl_buscarNotaCredito = True

        Me.Enabled = False
        frmBuscarNotaCreditoProveedor.txtBuscar.Text = ""
        frmBuscarNotaCreditoProveedor.txtIdMov.Text = 0
        frmBuscarNotaCreditoProveedor.txtDsuc.Text = ""
        frmBuscarNotaCreditoProveedor.txtDcaja.Text = ""
        frmBuscarNotaCreditoProveedor.txtFactura.Text = ""
        frmBuscarNotaCreditoProveedor.txtBuscar.Visible = True
        frmBuscarNotaCreditoProveedor.rdFactura.Checked = False
        frmBuscarNotaCreditoProveedor.rdIdNota.Checked = True

        frmBuscarNotaCreditoProveedor.Show()
        frmBuscarNotaCreditoProveedor.BringToFront()
        frmBuscarNotaCreditoProveedor.txtBuscar.Focus()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False

        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idNotaCredito As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_notaCredito()
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idNotaCredito.Value = txtIdNota.Text
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idNotaCredito)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idnotaCredito").ApplyCurrentValues(pvParametros)
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

        Me.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Enabled = False
        '-- valores al formulario de cancelacion
        frmCancelarNotaCredito.txtProveedor.Text = txtProveedor.Text
        frmCancelarNotaCredito.txtIdNota.Text = txtIdNota.Text
        frmCancelarNotaCredito.txtIdProveedor.Text = sp_datosTabla.consulta_valor("select idProveedor from cabCompra where idCompra=" & CInt(txtIdCompra.Text))
        '----------------------------------------------------------
        frmCancelarNotaCredito.Show()
        frmCancelarNotaCredito.BringToFront()
        frmCancelarNotaCredito.txtDsuc.Focus()
    End Sub
    '------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmConsultaNotaCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_consultaNotaCredito = 0
        banGl_buscarNotaCredito = False
        frmMenuPrincipal.proveedorConsultaNotaCredito.Enabled = True
        e.Cancel = False
    End Sub

    Private Sub frmConsultaNotaCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If banGl_buscarNotaCredito = False Then
            Dim intTmpIdNotaCredito As Integer = 0
            intTmpIdNotaCredito = sp_datosTabla.consulta_valor("select max(idNotaCredito) from cabNotaCredito")
            ultimoRegistro(intTmpIdNotaCredito)
            banGl_buscarNotaCredito = 0
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------

End Class