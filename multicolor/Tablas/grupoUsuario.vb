Public Class grupoUsuario
    Dim sys As New SystemClass

    'Listar grupo de Usuarios en un ListView
    Public Sub listarGrupoUsuarioLv(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idGrupoUsuario, rtrim(nombreGrupoUsuario) from grupoUsuario order by nombreGrupoUsuario")
            'Escondemos la columnna
            lv.Columns(2).Width = 0
            lv.Columns(3).Width = 0
            lv.Columns(4).Width = 0
            lv.Columns(5).Width = 0
            lv.Columns(6).Width = 0
            If lv.Items.Count < 7 Then
                lv.Columns(1).Width = lv.Width
            Else
                lv.Columns(1).Width = lv.Width - 20
            End If

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Grupo de Usuario en un ComboBox
    Public Sub listarGrupoUsuarioCbo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idGrupoUsuario, rtrim(nombreGrupoUsuario) from grupoUsuario Order by nombreGrupoUsuario", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
