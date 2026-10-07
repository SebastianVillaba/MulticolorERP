Public Class tipoCobro
    Dim sys As New SystemClass
    'Listar Cargos en ComboBox
    Public Sub tipoCobroCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select _vt.idTipoCobro, _vt.nombreTipo from v_tipoCobro _vt", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
