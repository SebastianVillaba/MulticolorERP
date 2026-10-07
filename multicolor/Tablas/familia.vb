Public Class familia
    Dim sys As New SystemClass

    'Listar Cargos en ComboBox
    Public Sub listarFamilia(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idFamilia, rtrim(nombreFamilia) from familiaProducto order by nombreFamilia")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboFamilia(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idFamilia, rtrim(nombreFamilia) from familiaProducto  Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
