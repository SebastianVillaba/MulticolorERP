Public Class cajaSucursal
    Dim sys As New SystemClass

    'Listar las cajas de la factura electronica de acuerdo a la sucursal
    Public Sub comboCajaSucursal(ByVal cb As ComboBox, ByVal v_idSucursal As Integer)
        Try
            sys.SqlToCombo("Select idDetFacturaDE,dcaja from detFacturaDE where idFacturaDE=1 and idSucursal=" & v_idSucursal & " Order by dcaja", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
