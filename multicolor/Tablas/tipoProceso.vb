Public Class tipoProceso
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarTipoProceso(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idTipoProceso, rtrim(nombreProceso) from tipoProceso order by nombreProceso ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboTipoProceso(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTipoProceso, rtrim(nombreProceso) from tipoProceso Order by nombreProceso ", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
