Public Class subLinea
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarLinea(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idSubLinea, rtrim(nombreSubLinea) from subLinea where activo=1 order by nombreSubLinea ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboLinea(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idSubLinea, rtrim(nombreSubLinea) from subLinea where activo=1 Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
