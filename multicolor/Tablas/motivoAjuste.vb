Public Class motivoAjuste
    Dim sys As New SystemClass

    'Listar en un listview
    Public Sub listarMotivoAjuste(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idMotivo, rtrim(nombreMotivo) from motivoAjuste where activo=1 order by nombreMotivo ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar en ComboBox
    Public Sub comboMotivoAjuste(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idMotivo, rtrim(nombreMotivo) from motivoAjuste where activo=1 Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
