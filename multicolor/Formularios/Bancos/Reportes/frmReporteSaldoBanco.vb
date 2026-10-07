Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteSaldoBanco
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdCuenta As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub imprimirMonedaActual()
        'Try
        If Len(txtNombreCuenta.Text) = 0 Then
            MessageBox.Show("Debe Ingresar alguna Cuenta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        intIdCuenta = CInt(txtIdCuenta.Text)
        '-------------
        '-- realizar el procedimiento para insertar los saldos bancarios
        sp_datosTabla.sp_string("sp_insSaldoBanco", intGl_idConfigPc & "," & intIdCuenta & "," & "'" & (dtpDesdeFecha.Text) & "'" & "," & "'" & (dtpHastaFecha.Text) & "'")
        '--------------------------------------------------------------
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        Dim pvIdDeposito As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        Dim v_idDeposito As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_saldoBancoGs
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
        'Catch ex As Exception
        '  MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '   strGl_mensajeError = "Error: " & ex.Message & Me.Name
        '    errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        'End Try
    End Sub

    Private Sub imprimirMoneda()
        'Try
        If Len(txtNombreCuenta.Text) = 0 Then
            MessageBox.Show("Debe Ingresar alguna Cuenta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        intIdCuenta = CInt(txtIdCuenta.Text)
        '-------------
        '-- realizar el procedimiento para insertar los saldos bancarios
        sp_datosTabla.sp_string("sp_insSaldoBanco", intGl_idConfigPc & "," & intIdCuenta & "," & "'" & (dtpDesdeFecha.Text) & "'" & "," & "'" & (dtpHastaFecha.Text) & "'")
        '--------------------------------------------------------------
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        Dim pvIdDeposito As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        Dim v_idDeposito As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_saldoBanco

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
        'Catch ex As Exception
        '  MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '   strGl_mensajeError = "Error: " & ex.Message & Me.Name
        '    errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        'End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        If Len(txtNombreCuenta.Text) = 0 Then
            MessageBox.Show("Debe Ingresar alguna Cuenta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        intIdCuenta = CInt(txtIdCuenta.Text)
        '-- ver de acuerdo a la configuracion
        Dim intTmpIdMoneda As Integer
        intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cuentaCorriente where idCuenta=" & intIdCuenta)
        'MsgBox("Valor de idmoneda de la cuenta corriente  " & intTmpIdMoneda)
        'MsgBox("Valor de idmoneda configurada  " & sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad))
        If intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad) Then
            '-- moneda configurada
            imprimirMonedaActual()
        Else
            '-- moneda extrangera
            imprimirMoneda()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Me.Enabled = False
        banGl_reporteSaldoBanco = True
        frmBuscarCuentaCorriente.txtIdCuenta.Text = 0
        frmBuscarCuentaCorriente.txtNombreBanco.Text = ""
        frmBuscarCuentaCorriente.txtBuscar.Text = ""
        frmBuscarCuentaCorriente.Show()
        frmBuscarCuentaCorriente.BringToFront()
        frmBuscarCuentaCorriente.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteSaldoBanco_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoReportesSaldoBanco.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------
End Class