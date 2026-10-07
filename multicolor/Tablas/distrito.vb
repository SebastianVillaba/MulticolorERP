Public Class distrito
    Dim sys As New SystemClass

    'Listar los distritos 
    Public Sub comboDistrito(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idDistrito, rtrim(nombreDistrito) from distrito Order by nombreDistrito", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar los distritos de acuerdo al departamento
    Public Sub comboDistritoDepartamento(ByVal cb As ComboBox, ByVal v_idDepartamento As Integer)
        Try
            sys.SqlToCombo("Select idDistrito, rtrim(nombreDistrito) from distrito where idDepartamento=" & v_idDepartamento & " Order by nombreDistrito", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
