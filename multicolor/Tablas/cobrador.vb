Public Class cobrador
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarCobrador(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idCobrador, rtrim(nombre)+','+ltrim(apellido) from v_cobrador where activo=1 order by nombre ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboCobrador(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idCobrador, rtrim(nombre)+','+ltrim(apellido) from v_cobrador where activo=1 Order by nombre", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
