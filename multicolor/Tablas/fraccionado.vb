Public Class fraccionado
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarFraccionado(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select rtrim(cf.nombreForma),df.cantidad,df.precio from lineaProducto where activo=1 order by nombreLinea ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboLinea(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idLinea, rtrim(nombreLinea) from lineaProducto where activo Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
