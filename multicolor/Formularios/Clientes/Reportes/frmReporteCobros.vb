Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteCobros
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim douPorcentaje As Double = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"

        lblIdCobrador.Text = 0
        lblCobrador.Text = ""
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub imprimirCobranza()
        Try
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteCobranzaResumen
            Dim ofrm As New crv()

            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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
    '--------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.Enabled = False

        If rdResumen.Checked = True Then
            '-- resumen de la cobranza
            imprimirCobranza()
        End If

        Me.Enabled = True
        'agregarRegistros()
    End Sub
    '---------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdComision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdComision.Click
        'banGl_reporteCobro = True

        'Me.Enabled = False

        'frmBuscarCobrador.txtId.Text = 0
        'frmBuscarCobrador.txtNombre.Text = ""
        'frmBuscarCobrador.txtBuscar.Text = ""
        'frmBuscarCobrador.Show()
        'frmBuscarCobrador.BringToFront()
        'frmBuscarCobrador.txtBuscar.Focus()

    End Sub
    '---------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReorteCobros_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteReportesClienteCobro.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------
End Class