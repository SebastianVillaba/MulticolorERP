Public Class tipoFactura
    Dim sys As New SystemClass

    'Listar en ComboBox
    Public Sub comboTipoFactura(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idFacturaDE, rtrim(nombreFacturaDE) from cabFacturaDE Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
