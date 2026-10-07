Public Class ciudad
    Dim sys As New SystemClass

    'Listar las ciudades
    Public Sub comboCiudad(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idCiudad, rtrim(nombreCiudad) from ciudad Order by nombreCiudad", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar las ciudades de acuerdo al distrito
    Public Sub comboCiudadDistrito(ByVal cb As ComboBox, ByVal v_idDepartamento As Integer, ByVal v_idDistrito As Integer)
        Try
            sys.SqlToCombo("Select idCiudad, rtrim(nombreCiudad) from ciudad where idDepartamento=" & v_idDepartamento & " and idDistrito=" & _
                           v_idDistrito & " Order by nombreCiudad", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
