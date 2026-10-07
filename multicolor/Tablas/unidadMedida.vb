Public Class unidadMedida
    Dim sys As New SystemClass
    'Listar Cargos en ComboBox
    Public Sub ListarUnidadMedida(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idUnidadMedida,nombreUnidadMedida from unidadMedida Order by nombreUnidadMedida ", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
