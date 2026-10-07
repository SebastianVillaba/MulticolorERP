Public Class tipoSucursal
    Dim sys As New SystemClass

    'Listar Cargos en ComboBox
    Public Sub listarTipoSucursal(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idTipoSucursal, rtrim(nombreTipoSucursal) from tipoSucursal order by nombreTipoSucursal")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboTipoSucursal(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTipoSucursal,rtrim(nombreTipoSucursal) from tipoSucursal Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
