Public Class tipoHistorico
    Dim sys As New SystemClass

    'Listar en ComboBox
    Public Sub comboTipoHistorico(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select tipo,nombreTipo from tipoHistorico order by nombreTipo", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
