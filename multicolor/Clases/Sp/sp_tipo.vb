Imports System.Data.SqlClient
Public Class sp_tipo
    Private sp_auditoriaSistema As New sp_auditoriaSistema
    Public Sub insTipo(ByVal nombre As String, ByVal idUsuarioAlta As Integer, ByVal acreditarCompra As Boolean, ByVal vence As Boolean, ByVal noComisiona As Boolean, ByVal noDescuento As Boolean, ByVal acreditarVenta As Boolean, ByVal primero As Boolean, ByVal tarjeta As Boolean, ByVal imprimir As Boolean, ByVal cheque As Boolean, ByVal venta As Boolean, ByVal debito As Boolean, ByVal contado As Boolean, ByVal tipoCobro As Int16, ByVal tipoCompra As Int16, ByVal tipoCredito As Int16, ByVal tipoPago As Int16, ByVal tipoProducto As Int16, ByVal tipoVenta As Int16)
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
            cmd.CommandText = "sp_InsTipo"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@nombreTipo", nombre)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", idUsuarioAlta)
            cmd.Parameters.AddWithValue("@acreditarCompra", acreditarCompra)
            cmd.Parameters.AddWithValue("@vence", vence)
            cmd.Parameters.AddWithValue("@noComisiona", noComisiona)
            cmd.Parameters.AddWithValue("@noDescuento", noDescuento)
            cmd.Parameters.AddWithValue("@acreditarVenta", acreditarVenta)
            cmd.Parameters.AddWithValue("@primero", primero)
            cmd.Parameters.AddWithValue("@tarjeta", tarjeta)
            cmd.Parameters.AddWithValue("@imprimir", imprimir)
            cmd.Parameters.AddWithValue("@cheque", cheque)
            cmd.Parameters.AddWithValue("@venta", venta)
            cmd.Parameters.AddWithValue("@debito", debito)
            cmd.Parameters.AddWithValue("@contado", contado)
            cmd.Parameters.AddWithValue("@tipoCobro", tipoCobro)
            cmd.Parameters.AddWithValue("@tipoCompra", tipoCompra)
            cmd.Parameters.AddWithValue("@tipoCredito", tipoCredito)
            cmd.Parameters.AddWithValue("@tipoPago", tipoPago)
            cmd.Parameters.AddWithValue("@tipoProducto", tipoProducto)
            cmd.Parameters.AddWithValue("@tipoVenta", tipoVenta)
            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            'Ejecutamos el sp y evaluamos la cantidad de filas insertadas

            rowCount = cmd.ExecuteNonQuery()
            'MsgBox("Valor de rowCount  " + rowCount.ToString)
            If rowCount > 0 Then
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
                ' auditoria de persona
                Dim strValorActual As String
                strValorActual = Trim(nombre)
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "ABM TIPO", True, False, intGl_idUsuario, "TIPO", "", strValorActual, strNombreHost)
                'MsgBox("Realizando la auditoria de la persona", MsgBoxStyle.Information)
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

    Public Sub UpdTipo(ByVal idTipo As Integer, ByVal nombreTipo As String, ByVal activo As String, ByVal idUsuarioMod As Integer, ByVal datosOriginales As String)
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
            cmd.CommandText = "sp_updTipo"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idTipo", idTipo)
            cmd.Parameters.AddWithValue("@nombreTipo", nombreTipo)
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.Parameters.AddWithValue("@idUsuarioMod", idUsuarioMod)
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
                ' auditoria de persona
                Dim strValorActual As String
                strValorActual = Trim(nombreTipo) & "," & Trim(activo)
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "ABM TIPO", False, True, intGl_idUsuario, "TIPO", datosOriginales, strValorActual, strNombreHost)
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
