Public Class timbradoDE
    Dim sys As New SystemClass

    'Listar en ComboBox
    Public Sub comboTimbradoDE(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTimbradoDE,nroTimbrado from timbradoDE Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
