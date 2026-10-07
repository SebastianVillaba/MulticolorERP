Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteVencimiento
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim laboratorio As New laboratorio

    Dim intIdDeposito As Integer
    Dim intIdLboratorio As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"
        '-- valor al combo
        laboratorio.ListarLaboratorio(cboLaboratorio)

    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub imprimir()
        Try
            If Len(txtDeposito.Text) = 0 Then
                MessageBox.Show("Debe ingresar el Deposito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            intIdDeposito = CInt(txtIdDeposito.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            Dim pvIdDeposito As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idDeposito As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_vencimientoMercaderia
            Dim ofrm As New crv()

            v_idDeposito.Value = intIdDeposito
            v_hasta.Value = dtpHastaFecha.Text

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idDeposito)
            pvParametros3.Add(v_hasta)
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
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
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

    Private Sub imprimirPorLaboratorio()
        Try

            intIdLboratorio = CInt(cboLaboratorio.SelectedValue)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            Dim pvIdDeposito As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idDeposito As New ParameterDiscreteValue()
            Dim v_idLaboratorio As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_vencimientoMercaderiaLabo
            Dim ofrm As New crv()

            v_idLaboratorio.Value = intIdLboratorio
            v_hasta.Value = dtpHastaFecha.Text

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros2.Add(v_idLaboratorio)
            pvParametros3.Add(v_hasta)


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
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros2)
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

    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Me.Enabled = False

        If rdPorSucursal.Checked = True Then
            imprimir()
        End If
        If rdPorLaboratorio.Checked = True Then
            imprimirPorLaboratorio()
        End If

        Me.Enabled = True

    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Me.Enabled = False
        banGl_reporteVencimientoMercaderia = True

        frmBuscarDepositoMercaderia.txtIdDeposito.Text = 0
        frmBuscarDepositoMercaderia.txtNombreDeposito.Text = ""
        frmBuscarDepositoMercaderia.txtNombreSucursal.Text = ""
        frmBuscarDepositoMercaderia.Show()
        frmBuscarDepositoMercaderia.BringToFront()
        frmBuscarDepositoMercaderia.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteVencimiento_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiasReportesVencimientos.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------

End Class