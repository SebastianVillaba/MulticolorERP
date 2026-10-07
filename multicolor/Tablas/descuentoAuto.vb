Public Class descuentoAuto
    Dim sys As New SystemClass

    '--Listar en ComboBox
    Public Sub listarLineaCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idDescuentoAuto,porcentaje from descuentoAuto order by porcentaje", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
