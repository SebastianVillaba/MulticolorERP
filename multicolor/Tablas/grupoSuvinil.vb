Public Class grupoSuvinil
    Dim sys As New SystemClass

    '--Listar en ComboBox
    Public Sub listarEnvaseCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idGrupoSuvinil,rtrim(nombre) from grupoSuvinil order by nombre", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
