Imports System.Data.SqlClient
Public Class sp_cargarNotaCredito
    Private sp_auditoriaSistema As New sp_auditoriaSistema

    Public Sub agregarDetNotaCreditoTmp(ByVal v_idConfig As Integer, ByVal v_nro As Integer, ByVal v_idStock As Integer, ByVal v_idForma As Integer, ByVal v_idImpuesto As Integer, ByVal v_cantidad As Double, ByVal v_cantfrac As Double, ByVal v_bonificacion As Double, ByVal v_costo As Double, ByVal v_precio As Double, ByVal v_factorImpuesto As Double, ByVal v_porcentajeImpuesto As Double)
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
            cmd.CommandText = "sp_agregarDetNotaCreditoTmp"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idConfig", v_idConfig)
            cmd.Parameters.AddWithValue("@nro", v_nro)
            cmd.Parameters.AddWithValue("@idStock", v_idStock)
            cmd.Parameters.AddWithValue("@idForma", v_idForma)
            cmd.Parameters.AddWithValue("@idImpuesto", v_idImpuesto)
            cmd.Parameters.AddWithValue("@cantidad", v_cantidad)
            cmd.Parameters.AddWithValue("@cantfrac", v_cantfrac)
            cmd.Parameters.AddWithValue("@bonificacion", v_bonificacion)
            cmd.Parameters.AddWithValue("@costo", v_costo)
            cmd.Parameters.AddWithValue("@precio", v_precio)
            cmd.Parameters.AddWithValue("@factorImpuesto", v_factorImpuesto)
            cmd.Parameters.AddWithValue("@porcentajeImpuesto", v_porcentajeImpuesto)

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

    Public Sub deleteDetNotaCreditoTmp(ByVal v_idConfig As Integer, ByVal v_nro As Integer)
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
            cmd.CommandText = "sp_deleteDetalleNotaCreditoTmp"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idConfig", v_idConfig)
            cmd.Parameters.AddWithValue("@nro", v_nro)

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

    Public Sub guardarNotaCredito(ByVal v_idConfig As Integer, ByVal v_idPersonaJur As Integer, ByVal v_idCompra As Integer, ByVal v_dsuc As String, ByVal v_dcaja As String, ByVal v_factura As String, ByVal v_timbrado As String, ByVal v_responsable As String, ByVal v_fecha As String, ByVal v_pendiente As Boolean, ByVal v_idUsuario As Integer)
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
            cmd.CommandText = "sp_guardarNotaCreditoProveedor"

            cmd.Parameters.AddWithValue("@idConfig", v_idConfig)
            cmd.Parameters.AddWithValue("@idPersonaJur", v_idPersonaJur)
            cmd.Parameters.AddWithValue("@idCompra", v_idCompra)
            cmd.Parameters.AddWithValue("@dsuc", v_dsuc)
            cmd.Parameters.AddWithValue("@dcaja", v_dcaja)
            cmd.Parameters.AddWithValue("@factura", v_factura)
            cmd.Parameters.AddWithValue("@timbrado", v_timbrado)
            cmd.Parameters.AddWithValue("@responsable", v_responsable)
            cmd.Parameters.AddWithValue("@fecha", v_fecha)
            cmd.Parameters.AddWithValue("@pendiente", v_pendiente)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", v_idUsuario)

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
