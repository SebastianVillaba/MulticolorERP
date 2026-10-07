Public Class mesaBellini
    Dim sys As New SystemClass

    Public Sub ListarMesaBellini(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select nroMesa from mesaBellini Order by nroMesa", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
