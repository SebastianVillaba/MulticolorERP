Public Class formulario
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarSucursal(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idFormulario, rtrim(nombreFormulario) from formulario where activo=1 order by nombreFormulario ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar en ComboBox
    Public Sub comboFormulario(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idFormulario, rtrim(nombreFormulario) from formulario where activo=1 Order by nombreFormulario", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
