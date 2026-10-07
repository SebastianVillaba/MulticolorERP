Imports System.Data.SqlClient
Public Class sp_auditoriaSistema
    Public Sub insAuditoriaSistema(ByVal idConfig As Integer, ByVal idSucursal As Integer, ByVal formaulario As String, ByVal insertar As Boolean, ByVal actualizar As Boolean, ByVal idUsuario As Integer, ByVal tabla As String, ByVal valorAnterior As String, ByVal valorActual As String, ByVal nombrePc As String)
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
            cmd.CommandText = "sp_insAuditoriaSistema"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idConfig", idConfig)
            cmd.Parameters.AddWithValue("@idSucursal", idSucursal)
            cmd.Parameters.AddWithValue("@formulario", formaulario)
            cmd.Parameters.AddWithValue("@insertar", insertar)
            cmd.Parameters.AddWithValue("@actualizar", actualizar)
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmd.Parameters.AddWithValue("@tabla", tabla)
            cmd.Parameters.AddWithValue("@valorAnterior", valorAnterior)
            cmd.Parameters.AddWithValue("@valorActual", valorActual)
            cmd.Parameters.AddWithValue("@nombrepc", nombrePc)
            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 200)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            'Ejecutamos el sp y evaluamos la cantidad de filas insertadas

            rowCount = cmd.ExecuteNonQuery()

            If rowCount = 1 Then
                MessageBox.Show((cmd.Parameters("@Mensaje").Value.ToString), strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show((cmd.Parameters("@Mensaje").Value.ToString), strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        Finally
            If previousConnectionState = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

End Class
