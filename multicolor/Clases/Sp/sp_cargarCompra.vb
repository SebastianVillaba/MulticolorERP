Imports System.Data.SqlClient
Public Class sp_cargarCompra
    Private sp_auditoriaSistema As New sp_auditoriaSistema
    Public Sub agregarDetCompraTmp(ByVal v_idConfig As Integer, ByVal v_nro As Integer, ByVal v_idProducto As Integer, ByVal v_idDeposito As Integer, ByVal v_idForma As Integer, ByVal v_idImpuesto As Integer, ByVal v_lote As String, ByVal v_vence As String, ByVal v_cantidad As Double, ByVal v_cantfrac As Int16, ByVal v_bonificacion As Double, ByVal v_costo As Double, ByVal v_costodes As Double, ByVal v_costoMoneda As Double, ByVal v_precio As Double, ByVal v_subtotal As Double, ByVal v_porcentajeDescuento As Double, ByVal v_descuento As Double, ByVal v_porcentajeImpuesto As Double, ByVal v_factorImpuesto As Double, ByVal v_porcentajeComprometido As Double)
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
            cmd.CommandText = "sp_agregarDetCompraTmp"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idConfig", v_idConfig)
            cmd.Parameters.AddWithValue("@nro", v_nro)
            cmd.Parameters.AddWithValue("@idProducto", v_idProducto)
            cmd.Parameters.AddWithValue("@idDeposito", v_idDeposito)
            cmd.Parameters.AddWithValue("@idForma", v_idForma)
            cmd.Parameters.AddWithValue("@idImpuesto", v_idImpuesto)
            cmd.Parameters.AddWithValue("@lote", v_lote)
            cmd.Parameters.AddWithValue("@vence", v_vence)
            cmd.Parameters.AddWithValue("@cantidad", v_cantidad)
            cmd.Parameters.AddWithValue("@cantfrac", v_cantfrac)
            cmd.Parameters.AddWithValue("@bonificacion", v_bonificacion)
            cmd.Parameters.AddWithValue("@costo", v_costo)
            cmd.Parameters.AddWithValue("@costodes", v_costodes)
            cmd.Parameters.AddWithValue("@costoMoneda", v_costoMoneda)
            cmd.Parameters.AddWithValue("@precio", v_precio)
            cmd.Parameters.AddWithValue("@subtotal", v_subtotal)
            cmd.Parameters.AddWithValue("@porcentajeDescuento", v_porcentajeDescuento)
            cmd.Parameters.AddWithValue("@descuento", v_descuento)
            cmd.Parameters.AddWithValue("@porcentajeImpuesto", v_porcentajeImpuesto)
            cmd.Parameters.AddWithValue("@factorImpuesto", v_factorImpuesto)
            cmd.Parameters.AddWithValue("@porcentajeComprometido", v_porcentajeComprometido)

            rowCount = cmd.ExecuteNonQuery()

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

    Public Sub deleteDetCompraTmp(ByVal v_idConfig As Integer, ByVal v_nro As Integer, ByVal v_idProducto As Integer)
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
            cmd.CommandText = "sp_deleteDetalleCompraTmp"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idConfig", v_idConfig)
            cmd.Parameters.AddWithValue("@nro", v_nro)
            cmd.Parameters.AddWithValue("@idProducto", v_idProducto)

            rowCount = cmd.ExecuteNonQuery()

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

    Public Sub guardarCompra(ByVal v_idConfig As Integer, ByVal v_idSucursal As Integer, ByVal v_idPersonaJur As Integer, ByVal v_idProveedor As Integer, ByVal v_idPedido As Integer, ByVal v_idTipoCompra As Integer, ByVal v_idMoneda As Integer, ByVal v_dsuc As String, ByVal v_dcaja As String, ByVal v_factura As String, ByVal v_timbrado As String, ByVal v_responsable As String, ByVal v_fecha As Date, ByVal v_cotizacion As Double, ByVal v_vence As Date, ByVal v_total As Double, ByVal v_idUsuario As Integer)
        'guardarCompra(ByVal v_idConfig As Integer, ByVal v_idPersonaJur As Integer, ByVal v_idProveedor As Integer, ByVal v_idPedido As Integer, ByVal v_idTipoCompra As Integer, ByVal v_idMoneda As Integer, ByVal v_dsuc As String, ByVal v_dcaja As String, ByVal v_factura As String, ByVal v_timbrado As String, ByVal v_responsable As String, ByVal v_cotizacion As Double, ByVal v_total As Double, ByVal v_idUsuario As Integer)
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
            cmd.CommandText = "sp_guardarCompra"

            'Establecemos los parametros
            'Entrada
            'MsgBox("Valor de idConfig  " & v_idConfig)
            cmd.Parameters.AddWithValue("@idConfig", v_idConfig)
            'MsgBox("Valor de idPersonaJur  " & v_idPersonaJur)
            cmd.Parameters.AddWithValue("@idSucursal", v_idSucursal)
            cmd.Parameters.AddWithValue("@idPersonaJur", v_idPersonaJur)
            'MsgBox("Valor de idProveedor  " & v_idProveedor)
            cmd.Parameters.AddWithValue("@idProveedor", v_idProveedor)
            'MsgBox("Valor de idPedido  " & v_idPedido)
            cmd.Parameters.AddWithValue("@idPedido", v_idPedido)
            'MsgBox("Valor de idTipoCompra  " & v_idTipoCompra)
            cmd.Parameters.AddWithValue("@idTipoCompra", v_idTipoCompra)
            'MsgBox("Valor de idMoneda  " & v_idMoneda)
            cmd.Parameters.AddWithValue("@idMoneda", v_idMoneda)
            'MsgBox("Valor de dsuc  " & v_dsuc)
            cmd.Parameters.AddWithValue("@dsuc", v_dsuc)
            'MsgBox("Valor de dcaja  " & v_dcaja)
            cmd.Parameters.AddWithValue("@dcaja", v_dcaja)
            'MsgBox("Valor de factura  " & v_factura)
            cmd.Parameters.AddWithValue("@factura", v_factura)
            'MsgBox("Valor de timbrado  " & v_timbrado)
            cmd.Parameters.AddWithValue("@timbrado", v_timbrado)
            'MsgBox("Valor de responsable  " & v_responsable)
            cmd.Parameters.AddWithValue("@responsable", v_responsable)
            'MsgBox("Valor de fecha  " & v_fecha)
            cmd.Parameters.AddWithValue("@fecha", v_fecha)
            'MsgBox("Valor de cotizacion  " & v_cotizacion)
            cmd.Parameters.AddWithValue("@cotizacion", v_cotizacion)
            'MsgBox("Valor de vence  " & v_vence)
            cmd.Parameters.AddWithValue("@vence", v_vence)
            'MsgBox("Valor de total  " & v_total)
            cmd.Parameters.AddWithValue("@total", v_total)
            'MsgBox("Valor de idUsuarioAlta  " & v_idUsuario)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", v_idUsuario)

            ' MsgBox("Antes de ejecutar el procedimiento")
            rowCount = cmd.ExecuteNonQuery()

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
