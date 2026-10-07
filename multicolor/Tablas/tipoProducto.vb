Public Class tipoProducto
    Dim sys As New SystemClass
    'Listar Cargos en ComboBox
    Public Sub ListarTipoVenta(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select _vt.idTipoProducto, _vt.nombreTipo from v_tipoProducto _vt Order by _vt.nombreTipo", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
