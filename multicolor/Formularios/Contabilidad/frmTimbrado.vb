Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmTimbrado
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim strTimbrado As String = "0"

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle(ByVal v_timbrado As String)
        systemClass.SqlToLv_timbradoContabilidad(lvTimbrado, "sp_consultaTimbradoFactura", "'" & v_timbrado & "'")
    End Sub

    Public Sub actualizarTimbradoSucursal(ByVal v_timbrado As String)
        'ProgressBar1(100)
        systemClass.SqlToLv_detalleTimbradoSucursales(lvSuc, "sp_consultaTimbradoSucursal", "'" & v_timbrado & "'")
    End Sub

    '-- reporte del timbrado
    Private Sub imprimirTimbrado()
        Try

            Dim pvParametros1 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvTimbrado As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_timbrado As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_timbradoSucursal
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_timbrado.Value = strTimbrado
            ' añadir el parámetro a la colección de parámetros
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvTimbrado.Add(v_timbrado)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@timbrado").ApplyCurrentValues(pvTimbrado)
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
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        e.Handled = txtNumerico(txtBuscar, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            listarDetalle(txtBuscar.Text)
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnProcesar_Click(sender As System.Object, e As System.EventArgs) Handles btnProcesar.Click
        Me.Enabled = False
        grSincronizando.Visible = True
        actualizarTimbradoSucursal(strTimbrado)
        grSincronizando.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False
        imprimirTimbrado()
        Me.Enabled = True
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvTimbrado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTimbrado.SelectedIndexChanged
        For Each item As ListViewItem In lvTimbrado.SelectedItems
            strTimbrado = item.SubItems(0).Text
            actualizarTimbradoSucursal(strTimbrado)
        Next
    End Sub

    Private Sub lvTimbrado_GotFocus(sender As Object, e As System.EventArgs) Handles lvTimbrado.GotFocus
        For Each item As ListViewItem In lvTimbrado.SelectedItems
            strTimbrado = item.SubItems(0).Text
            actualizarTimbradoSucursal(strTimbrado)
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmTimbrado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmReporteLibroIVA.Enabled = True
    End Sub

End Class