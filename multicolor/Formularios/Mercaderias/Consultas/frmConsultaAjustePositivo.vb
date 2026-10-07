Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmConsultaAjustePositivo
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
        systemClass.SqlToLv_detalleAjusteMercaderia(lvProducto, "sp_consultaDetalleAjustePositivoMercaderia", v_idMov)
    End Sub

    Public Sub actualizarCabecera(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '******************'
            '-- LA RECEPCION --'
            '******************'
            '-- el idRecepcion
            txtIdAjuste.Text = v_idMov
            '-- el numero de factura y la fecha mas adelante
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabAjustepo", "idAjustepo", v_idMov)
            txtCargadoPor.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabAjustePo", "idAjustepo", v_idMov)
            '-- nombre de la pc
            txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & sp_datosTabla.consulta_valor _
            ("select idConfig from cabAjustepo where idAjustepo=" & v_idMov))
            '-- nombre de la sucursal donde se realizó la operación
            txtSucursal.Text = sp_datosTabla.consulta_valorString("select _vs.nombreFantasia from v_sucursal _vs where idSucursal=" & _
            sp_datosTabla.consulta_valor("select idSucursal from cabAjustepo where idAjustepo=" & v_idMov))
            '-- explicacion
            txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAjustepo where idAjustepo=" & v_idMov)
            '--------------------------'
            '-- datos del inventario --'
            '--------------------------'
            If sp_datosTabla.consulta_valor("select idAuditoria from cabAjustepo where idAjustepo=" & v_idMov) > 0 Then
                Dim intTmpIdInventario As Integer
                intTmpIdInventario = sp_datosTabla.consulta_valor("select idAuditoria from cabAjustepo where idAjustepo=" & v_idMov)
                txtIdInventario.Text = intTmpIdInventario
                '-- fecha apertura
                txtFechaApertura.Text = sp_datosTabla.consulta_valorString("select fechaAbierto from cabInventario where idInventario=" & intTmpIdInventario)
                '-- fecha cierre
                txtFechaCierre.Text = sp_datosTabla.consulta_valorString("select fechaCerrado from cabInventario where idInventario=" & intTmpIdInventario)
                '-- auditor
                intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabInventario where idInventario=" & intTmpIdInventario)
                txtAuditor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
                '-- el deposito
                Dim intTmpidDeposito As Integer
                intTmpidDeposito = sp_datosTabla.consulta_valor("select idDeposito from cabInventario where idInventario=" & intTmpIdInventario)
                txtDeposito.Text = sp_datosTabla.consulta_valorString("select nombreDeposito from deposito where idDeposito=" & intTmpidDeposito)
            Else
                txtIdInventario.Text = 0
                txtFechaApertura.Text = ""
                txtFechaCierre.Text = ""
                txtAuditor.Text = ""
                txtDeposito.Text = ""
            End If

            '--------------------------------------------------------------------------------------------------------------------

            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabAjustepo", "idAjustepo", v_idMov))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
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
        intTmpIdMov = sp_datosTabla.consulta_valor("select min(idAjustepo) from cabAjustepo")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select max(idAjustepo) from cabAjustepo")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdAjuste.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdAjuste.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idAjustepo", "cabAjustepo", "idAjustepo", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdAjuste.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idAjustepo) from cabAjustepo") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdAjuste.Text = sp_datosTabla.consulta_valor("select min(idAjustepo) from cabAjustepo")
            Else
                txtIdAjuste.Text = intTmpIdMov
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdAjuste.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdAjuste.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idAjustepo", "cabAjustepo", "idAjustepo", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdAjuste.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idAjustepo) from cabAjustepo") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdAjuste.Text = sp_datosTabla.consulta_valor("select max(idAjustepo) from cabAjustepo")
            Else
                btnAnterior.Enabled = True
                txtIdAjuste.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_consultaAjustePositivoMercaderia = True
        banGl_buscarAjustePositivoMercaderia = True
        Me.Enabled = False

        frmBuscarAjusteMercaderia.txtBuscar.Text = ""
        frmBuscarAjusteMercaderia.txtIdMov.Text = ""

        frmBuscarAjusteMercaderia.WindowState = FormWindowState.Normal
        frmBuscarAjusteMercaderia.Show()
        frmBuscarAjusteMercaderia.BringToFront()
        frmBuscarAjusteMercaderia.txtBuscar.Focus()

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idAjuste As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_ajustePositivoMercaderia
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idAjuste.Value = CInt(txtIdAjuste.Text)
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idAjuste)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idAjustepo").ApplyCurrentValues(pvParametros)
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
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaAjustePositivo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If banGl_buscarAjustePositivoMercaderia = False Then
            Dim intTmpIdMov As Integer = 0
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idAjustepo) from cabAjustepo")
            ultimoRegistro(intTmpIdMov)
            banGl_buscarRemision = False
        End If
    End Sub

    Private Sub frmConsultaAjustePositivo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiaConsultasAjustePositivo.Enabled = True
        banGl_buscarAjustePositivoMercaderia = False
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------

End Class