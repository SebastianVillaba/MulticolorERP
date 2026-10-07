Public Class tipoCredito
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarTipoCredito(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idTipoCredito, rtrim(nombreTipo) from v_tipoCredito order by nombreTipo ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboTipoCredito(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTipoCredito, rtrim(nombreTipo) from v_tipoCredito Order by nombreTipo ", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
