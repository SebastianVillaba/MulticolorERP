Imports System.Data.SqlClient
Public Class sp_cargarVenta
    Private sp_auditoriaSistema As New sp_auditoriaSistema

    Public Sub agregarDetVentaTmp(ByVal v_idUsuario As Integer, ByVal v_idConfig As Integer, ByVal v_idStock As Integer, ByVal v_idTipoProducto As Integer, ByVal v_idImpuesto As Integer, ByVal v_idForma As Integer, ByVal v_stocko As Boolean, ByVal v_ultimoStock As Double, ByVal v_cantidad As Double, ByVal v_cantiFrac As Integer, ByVal v_costo As Double, ByVal v_precio As Double, ByVal v_subtotal As Double, ByVal v_precioDescuento As Double, ByVal v_factorImpuesto As Double, ByVal v_porcentajeImpuesto As Double, ByVal v_porcentajeDescuento As Double, ByVal v_oferta As Boolean, ByVal v_promo As Boolean, ByVal v_maximo As Boolean, ByVal v_descuentoMaximo As Double, ByVal v_redondeo As Int32)
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
            cmd.CommandText = "sp_agregarDetVentaTmp"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idUsuario", v_idUsuario)
            cmd.Parameters.AddWithValue("@idConfig", v_idConfig)
            cmd.Parameters.AddWithValue("@idStock", v_idStock)
            cmd.Parameters.AddWithValue("@idTipoProducto", v_idTipoProducto)
            cmd.Parameters.AddWithValue("@idImpuesto", v_idImpuesto)
            cmd.Parameters.AddWithValue("@idForma", v_idForma)
            cmd.Parameters.AddWithValue("@stocko", v_stocko)
            cmd.Parameters.AddWithValue("@ultimoStock", v_ultimoStock)
            cmd.Parameters.AddWithValue("@cantidad", v_cantidad)
            cmd.Parameters.AddWithValue("@cantfrac", v_cantiFrac)
            cmd.Parameters.AddWithValue("@costo", v_costo)
            cmd.Parameters.AddWithValue("@precio", v_precio)
            cmd.Parameters.AddWithValue("@subtotal", v_subtotal)
            cmd.Parameters.AddWithValue("@precioDescuento", v_precioDescuento)
            cmd.Parameters.AddWithValue("@factorImpuesto", v_factorImpuesto)
            cmd.Parameters.AddWithValue("@porcentajeImpuesto", v_porcentajeImpuesto)
            cmd.Parameters.AddWithValue("@porcentajeDescuento", v_porcentajeDescuento)
            cmd.Parameters.AddWithValue("@oferta", v_oferta)
            cmd.Parameters.AddWithValue("@promo", v_promo)
            cmd.Parameters.AddWithValue("@maximo", v_maximo)
            cmd.Parameters.AddWithValue("@descuentoMaximo", v_descuentoMaximo)
            cmd.Parameters.AddWithValue("@redondeo", v_redondeo)

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

    Public Sub guardarVenta(ByVal v_codigoVenta As Integer, ByVal v_idconfig As Integer, ByVal v_idPersonaJur As Integer, ByVal v_idSucursal As Integer, ByVal v_idCliente As Integer, ByVal v_idTarjeta As Integer, ByVal v_idTarjetade As Integer, ByVal v_idVendedor As Integer, ByVal v_idRepartidor As Integer, ByVal v_idCotiza As Integer, ByVal v_cotizacion As Double, ByVal v_tipo As Integer, ByVal v_tipof As Integer, ByVal v_idTipoVenta As Integer, ByVal v_idFactura As Integer, ByVal v_ruc As String, ByVal v_cliente As String, ByVal v_puesto As String, ByVal v_vueltoCliente As Double, ByVal v_totalDescuento As Double, ByVal v_totalVenta As Double, ByVal v_idusuarioAlta As Integer, ByVal v_fecha As String, ByVal v_fechaDelivery As String)
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
            cmd.CommandText = "sp_guardarVenta"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@codigoVenta", v_codigoVenta)
            cmd.Parameters.AddWithValue("@idConfig", v_idconfig)
            cmd.Parameters.AddWithValue("@idPersonaJur", v_idPersonaJur)
            cmd.Parameters.AddWithValue("@idSucursal", v_idSucursal)
            cmd.Parameters.AddWithValue("@idCliente", v_idCliente)
            cmd.Parameters.AddWithValue("@idTarjeta", v_idTarjeta)
            cmd.Parameters.AddWithValue("@idTarjetade", v_idTarjetade)
            cmd.Parameters.AddWithValue("@idVendedor", v_idVendedor)
            cmd.Parameters.AddWithValue("@idRepartidor", v_idRepartidor)
            cmd.Parameters.AddWithValue("@idCotiza", v_idCotiza)
            cmd.Parameters.AddWithValue("@cotizacion", v_cotizacion)
            cmd.Parameters.AddWithValue("@tipo", v_tipo)
            cmd.Parameters.AddWithValue("@tipof", v_tipof)
            cmd.Parameters.AddWithValue("@idTipoVenta", v_idTipoVenta)
            cmd.Parameters.AddWithValue("@idFactura", v_idFactura)
            'cmd.Parameters.AddWithValue("@factura", v_idFactura)
            cmd.Parameters.AddWithValue("@ruc", v_ruc)
            cmd.Parameters.AddWithValue("@cliente", v_cliente)
            cmd.Parameters.AddWithValue("@fecha", v_fecha)
            cmd.Parameters.AddWithValue("@puesto", v_puesto)
            cmd.Parameters.AddWithValue("@fechaDelivery", v_fechaDelivery)
            cmd.Parameters.AddWithValue("@vueltoCliente", v_vueltoCliente)
            cmd.Parameters.AddWithValue("@totalDescuento", v_totalDescuento)
            cmd.Parameters.AddWithValue("@totalVenta", v_totalVenta)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", v_idusuarioAlta)

            'MsgBox("Eestá por hacer el proceso de guardar la venta", MsgBoxStyle.Information)
            'frmPass.txtSql.Text = cmd.ExecuteNonQuery

            rowCount = cmd.ExecuteNonQuery()
            'MsgBox((cmd.Parameters("@Mensaje").Value.ToString), MsgBoxStyle.Information)

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

