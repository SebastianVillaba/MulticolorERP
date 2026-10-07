Imports System.Data.SqlClient
Public Class sp_laboratorio
    Private sp_auditoriaSistema As New sp_auditoriaSistema
    Public Sub insLaboratorio(ByVal idPersonaJur As Integer, ByVal canjeable As Boolean, ByVal cantidadMEs As Integer, ByVal idUsuarioAlta As Integer)
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
            cmd.CommandText = "sp_InsLaboratorio"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idPersonaJur", idPersonaJur)
            cmd.Parameters.AddWithValue("@canjeable", canjeable)
            cmd.Parameters.AddWithValue("@cantidadMes", cantidadMEs)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", idUsuarioAlta)
            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            'Ejecutamos el sp y evaluamos la cantidad de filas insertadas

            rowCount = cmd.ExecuteNonQuery()

            If rowCount = 1 Then
                'MsgBox("Paso por el insert de cargo", MsgBoxStyle.Information)
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
                Dim strValorActual As String
                strValorActual = Trim(canjeable) & "," & Trim(cantidadMEs)
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "ABM LABORATORIO", True, False, intGl_idUsuario, "LABORATORIO", "", strValorActual, strNombreHost)
                'MsgBox((cmd.Parameters("@Mensaje").Value.ToString), MsgBoxStyle.Information)
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

    Public Sub UpdLaboratorio(ByVal idLaboratorio As Integer, ByVal canjeable As Boolean, ByVal cantidadMes As Integer, ByVal activo As Boolean, ByVal datosOriginales As String)
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
            cmd.CommandText = "sp_updLaboratorio"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idLaboratorio", idLaboratorio)
            cmd.Parameters.AddWithValue("@canjeable", canjeable)
            cmd.Parameters.AddWithValue("@cantidadMes", cantidadMes)
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.Parameters.AddWithValue("@idUsuarioMod", intGl_idUsuario)

            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 200)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            'Ejecutamos el sp y evaluamos la cantidad de filas insertadas

            rowCount = cmd.ExecuteNonQuery()

            If rowCount = 1 Then
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
                Dim strValorActual As String
                strValorActual = Trim(canjeable.ToString) & "," & "," & Trim(cantidadMes.ToString) & "," & Trim(activo.ToString) & intGl_idUsuario.ToString
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "ABM LABORATORIO", False, True, intGl_idUsuario, "LABORATORIO", datosOriginales, strValorActual, strNombreHost)
                'MsgBox((cmd.Parameters("@Mensaje").Value.ToString), MsgBoxStyle.Information)
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
