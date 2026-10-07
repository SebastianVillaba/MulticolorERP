Imports System.Data.SqlClient
Public Class sp_obtenerDatosUsuario
    Private info As New info
    Public Function nombreUsuario(ByVal idUSuario As Integer) As String
        'Dim rowCount As String
        Dim cmd As New SqlCommand
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        'Dim reader As SqlDataReader
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            'MsgBox("Está en el principio del procedimiento", MsgBoxStyle.Exclamation)
            'Establecemos las propiedades preliminares
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_obtenerNombreUsuario"

            'Establecemos los parametros
            'Entrada
            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@idUSuario", SqlDbType.Int)
            cmd.Parameters("@IdUsuario").Direction = ParameterDirection.Output
            Dim strNombreUsuario As String = cmd.ExecuteScalar
            strNombreUsuario = CStr(cmd.Parameters("@idUsuario").Value)
            'MsgBox("Valor del procedimiento ", MsgBoxStyle.Exclamation, strNombreUsuario)
            Return strNombreUsuario
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return strNombreHost
        Finally
            If previousConnectionState = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function
End Class
