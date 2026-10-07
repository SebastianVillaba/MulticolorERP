Imports System.Data.SqlClient
Imports System.Data
Public Class cargarError
    '----------------------------'
    '-- INSERTAR EN EL DETALLE --'
    '----------------------------'
    Public Sub insertarError(ByVal v_mensaje As String, ByVal v_formulario As String)
        Dim v_consulta As String
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
            cmd.CommandText = "sp_insErrorSistema"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idConfig", intGl_idConfigPc)
            cmd.Parameters.AddWithValue("@idUsuario", intGl_idUsuario)
            cmd.Parameters.AddWithValue("@idSucursal", intGl_idSucursal)
            cmd.Parameters.AddWithValue("@mensaje", v_mensaje)
            cmd.Parameters.AddWithValue("@formulario", v_formulario)

            v_consulta = cmd.ExecuteNonQuery()
            If CInt(v_consulta) > 0 Then
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
            Else
                MessageBox.Show((cmd.Parameters("@Mensaje").Value.ToString), strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If previousConnectionState = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
End Class
