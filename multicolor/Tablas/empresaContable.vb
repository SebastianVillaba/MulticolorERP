Public Class empresaContable
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarEmpresaContable(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idPersonaJur, rtrim(nombreFantasia) from v_empresaContable where activo=1 order by nombreFantasia ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboEmpresaContable(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idEmpresaContable, rtrim(nombreFantasia) from v_empresaContable where activo=1 Order by nombreFantasia", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
