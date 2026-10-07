Public Class frmPresentacion
    Dim contador As Byte = 4

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        'MsgBox("holaaaa")
    End Sub

    '***********'
    '-- TIMER --'
    '***********'
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Me.Opacity -= 0.07
            If Me.Opacity = 0.0 Then
                Me.Hide()
                frmIngresoNick.Show()
                frmIngresoNick.BringToFront()
                frmIngresoNick.TopMost = True
                ' MsgBox("Pasa")
                'frmIngresoNick.Show()
                'frmIngresoNick.BringToFront()
                frmIngresoNick.txtPass.Focus()
                Timer1.Enabled = False
            End If
        Else
            ProgressBar1.Value += 4
            If ProgressBar1.Value = contador Then
                Label1.Text = "Inicializando...........!"
            Else
                If ProgressBar1.Value = contador + 14 Then
                    Label1.Text = ""
                    contador += 20
                End If
                If ProgressBar1.Value = 28 Then
                    Label8.Text = "netJoin con todos los derechos registrados para Multicolor Pinturas..."
                End If
            End If
        End If
    End Sub
End Class