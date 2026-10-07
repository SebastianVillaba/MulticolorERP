Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmConsultaCobro
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle(ByVal v_idMov As Integer)
        systemClass.SqlToLv_detalleCobranza(lvProducto, "sp_consultaDetalleCobroCliente", v_idMov)
    End Sub

    Public Sub actualizarCabecera(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '******************'
            '-- LA COBRANZA --'
            '******************'
            '-- el idCobranza
            txtIdCobro.Text = v_idMov
            '-- el numero de factura y la fecha mas adelante
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabCobro", "idCobro", v_idMov)
            txtCargadoPor.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabCobro", "idCobro", v_idMov)
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cabCobro", "idCobro", v_idMov) = True Then
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
                                                                    v_idMov & " and tipo='COBRO'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idMov & " and tipo='COBRO'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idMov & _
                                                                   " and tipo='COBRO'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- total cobranza
            txtTotalCobrado.Text = sp_datosTabla.consulta_valorDouble("select totalCobro from cabCobro where idCobro=" & v_idMov)
            txtTotalCobrado.Text = Format(CDec(txtTotalCobrado.Text), "###,###,##0")
            '-- el nro de recibo
            txtDsuc.Text = sp_datosTabla.consulta_valorString("select dsuc from cabCobro where idCobro=" & v_idMov)
            txtDcaja.Text = sp_datosTabla.consulta_valorString("select dcaja from cabCobro where idCobro=" & v_idMov)
            txtRecibo.Text = sp_datosTabla.consulta_valorString("select recibo from cabCobro where idCobro=" & v_idMov)
            '-- la fecha de la cobranza
            txtFecha.Text = sp_datosTabla.consulta_valorString("select fecha from cabCobro where idCobro=" & v_idMov)
            '-- el cobrador
            Dim intTmpIdCobrador As Integer
            intTmpIdCobrador = sp_datosTabla.consulta_valor("select idCobrador from cabCobro where idCobro=" & v_idMov)
            txtCobrador.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cobradorT where idCobrador=" & intTmpIdCobrador)
            '-- el tipo de cobranza
            Dim intTmpidTipoCobro As Integer
            intTmpidTipoCobro = sp_datosTabla.consulta_valor("select idTipoCobro from cabCobro where idCobro=" & v_idMov)
            txtTipoCobro.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoCobro where idTipoCobro=" & intTmpidTipoCobro)
            '-- el cliente
            Dim intTmpIdCliente As Integer
            intTmpIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabCobro where idCobro=" & v_idMov)
            'MsgBox("Valor de idCliente  " & intTmpIdCliente)
            txtCliente.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_cliente where idCliente=" & intTmpIdCliente)
            '-- total descuento
            txtTotalDescuento.Text = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabCobro where idCobro=" & v_idMov)
            txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,##0")

            '-- nombre de la pc
            txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & sp_datosTabla.consulta_valor _
            ("select idConfigPc from cabCobro where idCobro=" & v_idMov))
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabCobro", "idCobro", v_idMov))
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
        intTmpIdMov = sp_datosTabla.consulta_valor("select min(idCobro) from cabCobro")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select max(idCobro) from cabCobro")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdCobro.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdCobro.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idCobro", "cabCobro", "idCobro", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdCobro.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idCobro) from cabCobro") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdCobro.Text = sp_datosTabla.consulta_valor("select min(idCobro) from cabCobro")
            Else
                txtIdCobro.Text = intTmpIdMov
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdCobro.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdCobro.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idCobro", "cabCobro", "idCobro", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdCobro.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idCobro) from cabCobro") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdCobro.Text = sp_datosTabla.consulta_valor("select max(idCobro) from cabCobro")
            Else
                btnAnterior.Enabled = True
                txtIdCobro.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaCobroCliente = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE COBRANZA"
        frmAnular.lblIdMov.Text = txtIdCobro.Text
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
        banGl_buscarCobroCliente = True
        Me.Enabled = False

        frmBuscarCobranza.txtBuscar.Text = ""
        frmBuscarCobranza.txtIdMov.Text = ""

        frmBuscarCobranza.WindowState = FormWindowState.Normal
        frmBuscarCobranza.Show()
        frmBuscarCobranza.BringToFront()
        frmBuscarCobranza.txtBuscar.Focus()

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False

        Dim pvParametros As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idCobro As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_reciboCobro
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idCobro.Value = CInt(txtIdCobro.Text)
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idCobro)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCobro").ApplyCurrentValues(pvParametros)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt

        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Show()

        Me.Enabled = True
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaRecepcion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If banGl_buscarCobroCliente = False Then
            Dim intTmpIdMov As Integer = 0
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idCobro) from cabCobro")
            ultimoRegistro(intTmpIdMov)
            banGl_buscarCobroCliente = False
        End If
    End Sub

    Private Sub frmConsultaCanje_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteConsultaCobranza.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------
End Class