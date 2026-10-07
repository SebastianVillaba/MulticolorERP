Public Class calidad
    Dim sys As New SystemClass

    '--Listar en ComboBox
    Public Sub listarLineaCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idCalidad,rtrim(nombre) from calidad order by nombre", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
