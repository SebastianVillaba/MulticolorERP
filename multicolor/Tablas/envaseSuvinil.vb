Public Class envaseSuvinil
    Dim sys As New SystemClass

    '--Listar en ComboBox
    Public Sub listarEnvaseCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idEnvaseSuvinil,rtrim(litro) from envaseSuvinil order by litro", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
