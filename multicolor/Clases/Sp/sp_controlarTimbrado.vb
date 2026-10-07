Imports System.Data.SqlClient
Public Class sp_controlarTimbrado
    Public Function controlar_timbrado(ByVal idSucursal As Integer) As Boolean
        Dim rowCount As Integer
        Dim cmd As New SqlCommand
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            'Establecemos las propiedades preliminares
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_controlarTimbrado"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idSucursal", idSucursal)
            'salida
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            rowCount = cmd.ExecuteNonQuery()

            If rowCount > 0 Then
                'MsgBox("Paso por el insert de cargo", MsgBoxStyle.Information)
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
                MessageBox.Show((cmd.Parameters("@Mensaje").Value.ToString), strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                'MsgBox((cmd.Parameters("@Mensaje").Value.ToString), MsgBoxStyle.Information)
                Return True
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return False
        Finally
            If previousConnectionState = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

End Class
