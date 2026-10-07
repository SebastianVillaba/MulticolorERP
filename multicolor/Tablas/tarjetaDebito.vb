Public Class tarjetaDebito
    Dim sys As New SystemClass
    Public Sub listarTarjetadebitoCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTarjetade,rtrim(nombreTarjetaDebito) from tarjetaDebito where activo=1", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
