Public Class tipoDocu
    Dim sys As New SystemClass

    'Listar 
    Public Sub comboTipoDocu(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTipoDocumento, rtrim(explica) from tipoDocumento Order by explica", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
