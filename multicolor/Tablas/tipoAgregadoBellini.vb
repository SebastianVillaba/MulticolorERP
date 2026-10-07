Public Class tipoAgregadoBellini
    Dim sys As New SystemClass
    'Listar Cargos en ComboBox
    Public Sub comboTipoAgregado(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTipoAgregadoBellini,rtrim(nombreTipoAgregadoBellini) from tipoAgregadoBellini Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
