Public Class mozo
    Dim sys As New SystemClass

    'Listar Monedas en ComboBox
    Public Sub listarMozoCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idPersonal,rtrim(nombre) from v_personal where activo=1 and idCargo=23 order by nombre", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
