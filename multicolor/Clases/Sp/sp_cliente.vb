Imports System.Data.SqlClient
Public Class sp_cliente
    Private sp_auditoriaSistema As New sp_auditoriaSistema

    Public Sub insCliente(ByVal idpersona As Integer, ByVal idGrupoCliente As Integer, ByVal idCobrador As Integer, ByVal habilitarLimite As Boolean, ByVal limiteCredito As Double, ByVal cheque As Boolean, ByVal acreditar As Boolean, ByVal primeroVenta As Boolean, ByVal idUsuarioAlta As Integer)
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
            cmd.CommandText = "sp_InsCliente"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idPersona", idpersona)
            cmd.Parameters.AddWithValue("@idGrupoCliente", idGrupoCliente)
            cmd.Parameters.AddWithValue("@idCobrador", idCobrador)
            cmd.Parameters.AddWithValue("@habilitarLimite", habilitarLimite)
            cmd.Parameters.AddWithValue("@limiteCredito", limiteCredito)
            cmd.Parameters.AddWithValue("@cheque", cheque)
            cmd.Parameters.AddWithValue("@acreditar", acreditar)
            cmd.Parameters.AddWithValue("@primeroVenta", primeroVenta)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", intGl_idUsuario)
            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            'Ejecutamos el sp y evaluamos la cantidad de filas insertadas

            rowCount = cmd.ExecuteNonQuery()

            If rowCount > 0 Then
                'MsgBox("Paso por el insert de cargo", MsgBoxStyle.Information)
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
                Dim strValorActual As String
                strValorActual = Trim(idpersona.ToString) & "," & Trim(idGrupoCliente.ToString) & "," & Trim(idCobrador.ToString) & "," & Trim(habilitarLimite.ToString) & "," & Trim(limiteCredito.ToString) & "," & Trim(cheque.ToString) & "," & Trim(acreditar.ToString) & "," & Trim(primeroVenta.ToString) & "," & Trim(idUsuarioAlta.ToString)
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "FRMCLIENTE_VENTA", True, False, intGl_idUsuario, "CLIENTE", "", strValorActual, strNombreHost)
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

    Public Sub UpdCliente(ByVal idCargo As Integer, ByVal nombreCargo As String, ByVal activo As Boolean, ByVal datosOriginales As String)
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
            cmd.CommandText = "sp_updCargo"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idCargo", idCargo)
            cmd.Parameters.AddWithValue("@nombreCargo", nombreCargo)
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.Parameters.AddWithValue("@idUsuarioMod", intGl_idUsuario)

            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            'Ejecutamos el sp y evaluamos la cantidad de filas insertadas

            rowCount = cmd.ExecuteNonQuery()

            If rowCount > 1 Then
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
                Dim strValorActual As String
                strValorActual = Trim(nombreCargo) & "," & intGl_idUsuario.ToString
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "ABM CARGO", False, True, intGl_idUsuario, "CARGO", datosOriginales, strValorActual, strNombreHost)
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

    Public Function cliente_primero(ByVal v_campo As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "exec sp_primerCliente"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        'Dim rowCount As Integer
        'Dim cmd As New SqlCommand
        'Dim conn As New SqlConnection(conexion)
        'Dim previousConnectionState As ConnectionState
        'previousConnectionState = conn.State

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    '-- (1) traer el idcliente
                    If v_campo = 1 Then
                        v_resultado = reader.GetValue(0).ToString
                        'MsgBox("Valor del Resultado  " & v_resultado)
                    End If
                    '-- (2) traer el ruc
                    If v_campo = 2 Then
                        v_resultado = reader.GetValue(1).ToString
                        'MsgBox("Valor del Resultado  " & v_resultado)
                    End If
                    '-- (3) traer el nombre
                    If v_campo = 3 Then
                        v_resultado = reader.GetValue(2).ToString
                        'MsgBox("Valor del Resultado  " & v_resultado)
                    End If
                    '-- (4) traer el grupo de cliente
                    If v_campo = 4 Then
                        v_resultado = reader.GetValue(3).ToString
                        'MsgBox("Valor del Resultado  " & v_resultado)
                    End If
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

End Class
