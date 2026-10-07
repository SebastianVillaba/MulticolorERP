Public Class tarjetaCredito
    Dim sys As New SystemClass

    Public Sub listarTarjetaCreditoCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select rtrim(idTarjeta),rtrim(nombreTarjeta) from tarjeta where activo=1 order by nombreTarjeta", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
