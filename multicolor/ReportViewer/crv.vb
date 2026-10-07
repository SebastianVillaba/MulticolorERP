Public Class crv

    Private Sub crv_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        Return
    End Sub

    Private Sub crv_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Select Case intGl_tipoConexion
            Case Is = 1
                '-- localmente
                'CrystalReportViewer1.ReportSource = Microsoft.VisualBasic.Left(Application.StartupPath, _
                'Len(Application.StartupPath) - 3) & "crystalreport1.rpt"
            Case Is = 2
                '-- para la conexion LAN
                'CrystalReportViewer1.ReportSource = "c:\NetJoin\Reportes\rpt_remision.rpt"
            Case Is = 3
                '-- conexion vpn

            Case Is = 4
                '-- conexion de internet

        End Select
    End Sub
End Class