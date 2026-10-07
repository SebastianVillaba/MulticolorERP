Public Class departamento
    Dim sys As New SystemClass

    'Listar los departamentos en ComboBox
    Public Sub comboDepartamento(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idDepartamento, rtrim(nombreDepartamento) from departamento Order by nombreDepartamento", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
