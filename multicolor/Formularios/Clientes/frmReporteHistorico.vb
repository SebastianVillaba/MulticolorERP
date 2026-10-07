Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteHistorico
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim tipoHistorico As New tipoHistorico

    Dim intIdCliente As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"

        tipoHistorico.comboTipoHistorico(cboTipo)
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- la opcion del resumen de pago
    Private Sub imprimirVentaResumidoFecha()
        Try
            Me.Enabled = False

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idCliente As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_historicoResumen
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idCliente.Value = intIdCliente
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idCliente)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idCliente").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)

            '-- paramentros constantes
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

            Me.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- impresion de la cabecera de la deuda para el cliente
    Private Sub imprimirResumenCliente()
        Try
            Me.Enabled = False

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_idCliente As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_historicoResumenCli
            Dim ofrm As New crv()

            '-- los paramentros de entrada

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_idCliente.Value = CInt(lblIdCliente.Text)

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvParametros1.Add(v_idCliente)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            'rpt.Refresh()

            '-- parametros del procedimiento
            rpt.DataDefinition.ParameterFields("@idCliente").ApplyCurrentValues(pvParametros1)
            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
            'rpt.ReportOptions.EnableSaveDataWithReport = True


            '-- asignar los valores al objeto del reporte
            ofrm.CrystalReportViewer1.ReportSource = rpt
            '-- procedimiento para evitar el usuario y contraseña de la base de datos
            evitarPassDatabase(rpt)
            '-- mostrar el reporte
            ofrm.WindowState = FormWindowState.Maximized
            ofrm.Show()

            Me.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- reporte de pago por grupo de clientes
    Private Sub pagoGrupoCliente()
        Try

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()


            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_idGrupoCliente As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_historicoResumenTodos
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        '-- verificar si existe algun cliente para consultar
        If Not IsNumeric(frmHistoricoCliente.txtIdCliente.Text) Then
            MessageBox.Show("Debe Ingresar un Cliente para realizar la Consulta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        intIdCliente = CInt(frmHistoricoCliente.txtIdCliente.Text)
        If rdResumenPago.Checked = True Then

            '--------------------------------------------'
            '-- REPORTE DE PAGO PARA GRUPO DE CLIENTES --'
            '--------------------------------------------'
            If (fun_guardarSp("sp_cargarTmpClienteCobroConSaldoCliente", intGl_idConfigPc & "," & lblIdCliente.Text & ",'" & _
                              FormatoFechaSoloDatePicker(dtpDesdeFecha) & "','" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                'imprimirVentaResumidoFecha()
                pagoGrupoCliente()
            End If
            'imprimirVentaResumidoFecha()
            'imprimirResumenCliente()
        End If

    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdPorMovimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPorMovimiento.Click
        lblTipo.Visible = False
        cboTipo.Visible = False
    End Sub

    Private Sub rdResumenPago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdResumenPago.Click
        lblTipo.Visible = False
        cboTipo.Visible = False
    End Sub

    Private Sub rdTipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTipo.Click
        lblTipo.Visible = True
        cboTipo.Visible = True
    End Sub
    '--------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteHistorico_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmHistoricoCliente.Enabled = True
        frmHistoricoCliente.Show()
        frmHistoricoCliente.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------
End Class