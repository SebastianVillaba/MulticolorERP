Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Public Class sp_producto
    Dim _foto As Byte()

    '---------------------------------------------'
    '-- armar el tipo de variable para insertar --'
    '---------------------------------------------'
    '--- para la imagen
    Public Property foto As Byte()
        Get
            Return _foto
        End Get
        Set(value As Byte())
            _foto = value
        End Set
    End Property


    '-----------------------'
    '-- INSERTAR PRODUCTO --'
    '-----------------------'
    Public Sub insProducto(ByVal v_codigo As String, ByVal v_idLaboratorio As Integer, ByVal v_idTipoProducto As Integer, ByVal v_idImpuesto As Integer,
                           ByVal v_codigoBarra As String, ByVal v_nombreProducto As String, ByVal v_presentacion As String, ByVal v_origen As String,
                           ByVal v_fueraLinea As Boolean, ByVal v_usoInterno As Boolean, ByVal v_precio As Double, ByVal v_basico As Boolean,
                           ByVal v_envase As Boolean)

        'Dim rowCount As Integer
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
            cmd.CommandText = "sp_insProducto"

            'Establecemos los parametros
            cmd.Parameters.AddWithValue("@codigo", v_codigo)
            cmd.Parameters.AddWithValue("@idLaboratorio", v_idLaboratorio)
            cmd.Parameters.AddWithValue("@idTipoProducto", v_idTipoProducto)
            cmd.Parameters.AddWithValue("@idImpuesto", v_idImpuesto)
            cmd.Parameters.AddWithValue("@codigoBarra", v_codigoBarra)
            cmd.Parameters.AddWithValue("@nombreProducto", v_nombreProducto)
            cmd.Parameters.AddWithValue("@presentacion", v_presentacion)
            cmd.Parameters.AddWithValue("@origen", v_origen)
            cmd.Parameters.AddWithValue("@fueraLinea", v_fueraLinea)
            cmd.Parameters.AddWithValue("@usoInterno", v_usoInterno)
            cmd.Parameters.AddWithValue("@precio", v_precio)
            cmd.Parameters.AddWithValue("@basico", v_basico)
            cmd.Parameters.AddWithValue("@envase", v_envase)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", intGl_idUsuario)

            v_consulta = cmd.ExecuteNonQuery()
            'MsgBox("Valor  " & cmd.ExecuteNonQuery())
            If CInt(v_consulta) > 0 Then
                '----------------------------------
                '-- auditoria del sistema insert --
                '----------------------------------
                MessageBox.Show("Se insertó el registro con éxito..! ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                frmAbmProducto.deshabilitarObjetos()
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

    '-------------------------'
    '-- ACTUALIZAR PRODUCTO --'
    '-------------------------'
    Public Sub UpdProducto(ByVal idProducto As Integer, ByVal codigo As String, ByVal idLaboratorio As Integer,
                           ByVal idTipoProducto As Integer, ByVal idImpuesto As Integer, ByVal codigoBarra As String,
                           ByVal nombreProducto As String, ByVal presentacion As String, ByVal origen As String, ByVal v_fueraLinea As Boolean,
                           ByVal activo As Boolean, ByVal usoInterno As Boolean, ByVal v_precio As Double, ByVal v_basico As Boolean, ByVal v_envase As Boolean)
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
            cmd.CommandText = "sp_updProducto"

            '------------------------------'
            '-- el metodo para la imagen --'
            '------------------------------'
            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idProducto", idProducto)
            cmd.Parameters.AddWithValue("@codigo", codigo)
            cmd.Parameters.AddWithValue("@idLaboratorio", idLaboratorio)
            cmd.Parameters.AddWithValue("@idTipoProducto", idTipoProducto)
            cmd.Parameters.AddWithValue("@idImpuesto", idImpuesto)
            cmd.Parameters.AddWithValue("@codigoBarra", codigoBarra)
            cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto)
            cmd.Parameters.AddWithValue("@presentacion", presentacion)
            cmd.Parameters.AddWithValue("@origen", origen)
            cmd.Parameters.AddWithValue("@fueraLinea", v_fueraLinea)
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.Parameters.AddWithValue("@usoInterno", usoInterno)
            cmd.Parameters.AddWithValue("@precio", v_precio)
            cmd.Parameters.AddWithValue("@basico", v_basico)
            cmd.Parameters.AddWithValue("@envase", v_envase)
            cmd.Parameters.AddWithValue("@idUsuarioMod", intGl_idUsuario)

            rowCount = cmd.ExecuteNonQuery()

            If rowCount > 0 Then
                MessageBox.Show("Se actualizó el registro con éxito..! ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                frmAbmProducto.deshabilitarObjetos()
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

    '----------------------------------'
    '-- ACTUALIZAR FOTO DEL PRODUCTO --'
    '----------------------------------'
    Public Sub UpdProductoFoto(ByVal idProducto As Integer)
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
            cmd.CommandText = "sp_updProductoFoto"

            '------------------------------'
            '-- el metodo para la imagen --'
            '------------------------------'
            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idProducto", idProducto)
            '------------------------------'
            '-- el metodo para la imagen --'
            '------------------------------'
            '--- la parte de imagen
            Dim ms As New MemoryStream
            '.picImagen2.Image.Save(ms, frmFotoMercaderia.picImagen2.Image.RawFormat)
            _foto = ms.GetBuffer
            Dim p As New SqlParameter("@imagen", SqlDbType.Image)
            p.Value = _foto
            cmd.Parameters.Add(p)
            cmd.Parameters.AddWithValue("@idUsuarioMod", intGl_idUsuario)

            rowCount = cmd.ExecuteNonQuery()

            If rowCount > 0 Then
                MessageBox.Show("Se actualizó el registro con éxito..! ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'frmAbmProducto.deshabilitarObjetos()
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
