Public Class tipoCompra
    Dim sys As New SystemClass
    'Listar Cargos en ComboBox
    Public Sub tipoCompraCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select _vt.idTipoCompra, _vt.nombreTipo from v_tipoCompra _vt Order by _vt.nombreTipo", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
