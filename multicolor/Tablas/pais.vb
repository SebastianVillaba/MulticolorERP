Public Class pais
    Dim sys As New SystemClass

    'Listar Monedas en ComboBox
    Public Sub listarPaisCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idPais,rtrim(nombre) from pais where activo=1", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
