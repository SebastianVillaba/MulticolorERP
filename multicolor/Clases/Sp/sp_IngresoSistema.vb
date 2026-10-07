Imports System.Data.SqlClient
Public Class sp_IngresoSistema
    Dim info As New info

    'funcion para saber el nick y la contraseña de acceso al sistema
    Public Function acceso(ByVal Usuario As String, ByVal pass As String) As Boolean
        'Dim cmd1 As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sqldad = New SqlDataAdapter(cmd)
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        Dim valor As Boolean = True
        previousConnectionState = conn.State

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                ' MsgBox("Se conecto ala base de datos")
            End If

            'Establecemos las propiedades preliminares
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_claveUsuarioNick"

            'MsgBox("En el Inicio del procedimiento de Acceso", MsgBoxStyle.Exclamation)

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@nick", Usuario)
            cmd.Parameters.AddWithValue("@pass", pass)

            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int)
            cmd.Parameters("@idUsuario").Direction = ParameterDirection.Output
            'MsgBox("Ya paso por aca")
            sqldad.Fill(dsDatos, "v_usuario")

            '-- para agregar en la variable publica el idusuario
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            'MsgBox("Valor de t  " + cmd.ExecuteScalar())
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    'v_resultado = reader.GetValue(v_lugar).ToString
                    intGl_idUsuario = reader.GetValue(3)
                    strGl_nombreUsuario = Trim(reader.GetValue(7).ToString) & "," & Trim(reader.GetValue(8).ToString)
                    strGl_nombreGrupoUsuario = reader.GetValue(14).ToString
                    strGl_nombreEntidad = reader.GetValue(6).ToString
                    intGl_idEntidad = reader.GetValue(5).ToString
                    strGl_RutaFoto = reader.GetValue(15).ToString
                    intGl_idGrupoUsuario = reader.GetValue(4).ToString
                    Return True
                End While
            End Using

            'If t <> 0 Then
            '    ' MsgBox("Paso por aca")
            '    intGl_idUsuario = dsDatos.Tables(0).Rows(0).Item("idUsuario").ToString
            '    strGl_nombreUsuario = Trim(dsDatos.Tables(0).Rows(0).Item("nombre").ToString) & "," & Trim(dsDatos.Tables(0).Rows(0).Item("apellido").ToString)
            '    strGl_nombreGrupoUsuario = Trim(dsDatos.Tables(0).Rows(0).Item("nombreGrupoUsuario").ToString)
            '    strGl_nombreEntidad = Trim(dsDatos.Tables(0).Rows(0).Item("empresa").ToString)
            '    intGl_idEntidad = dsDatos.Tables(0).Rows(0).Item("idEntidad").ToString
            '    strGl_RutaFoto = Trim(dsDatos.Tables(0).Rows(0).Item("fotoPersona").ToString)
            '    intGl_idGrupoUsuario = dsDatos.Tables(0).Rows(0).Item("idGrupoUsuario").ToString
            '    ' Else
            '    '    intGl_idUsuario = dsDatos.Tables(0).Rows(0).Item("idUsuario").ToString
            '    '   MsgBox("Valor de idusuario" + intGl_idUsuario)
            'End If
            'MsgBox("El procedimiento de Acceso", MsgBoxStyle.Exclamation)
            '-------------------------------------
            '-- validacion si existe el usuario
            '-------------------------------------
            't = CInt(cmd.ExecuteScalar())
            'If t = 0 Then
            '    Return False
            'Else
            '    Return True
            'End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            valor = False

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

        Return valor
    End Function

    'funcion para saber si la clave coincide con la tarjeta
    Public Function accesoTarjeta(ByVal pass As String) As Boolean
        'Dim cmd1 As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sqldad = New SqlDataAdapter(cmd)
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Dim valor As Boolean = True

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                ' MsgBox("Se conecto ala base de datos")
            End If

            'Establecemos las propiedades preliminares
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarjetaUsuario"

            'MsgBox("En el Inicio del procedimiento de Acceso", MsgBoxStyle.Exclamation)

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@pass", pass)

            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int)
            cmd.Parameters("@idUsuario").Direction = ParameterDirection.Output
            sqldad.Fill(dsDatos, "v_usuario")

            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            Using reader
                While reader.Read
                    'v_resultado = reader.GetValue(v_lugar).ToString
                    intGl_idUsuario = reader.GetValue(3)
                    strGl_nombreUsuario = Trim(reader.GetValue(7).ToString) & "," & Trim(reader.GetValue(8).ToString)
                    strGl_nombreGrupoUsuario = reader.GetValue(14).ToString
                    strGl_nombreEntidad = reader.GetValue(6).ToString
                    intGl_idEntidad = reader.GetValue(5).ToString
                    strGl_RutaFoto = reader.GetValue(15).ToString
                    intGl_idGrupoUsuario = reader.GetValue(4).ToString
                    Return True
                End While
            End Using

            '-- para agregar en la variable publica el idusuario
            'Dim t As Integer = CInt(cmd.ExecuteScalar())
            'If t <> 0 Then
            '    'MsgBox("Paso por aca")
            '    intGl_idUsuario = dsDatos.Tables(0).Rows(0).Item("idUsuario").ToString
            '    'MsgBox("Valor del idUsuario  " & dsDatos.Tables(0).Rows(0).Item("idUsuario").ToString)
            '    strGl_nombreUsuario = Trim(dsDatos.Tables(0).Rows(0).Item("nombre").ToString) & "," & Trim(dsDatos.Tables(0).Rows(0).Item("apellido").ToString)
            '    strGl_nombreGrupoUsuario = Trim(dsDatos.Tables(0).Rows(0).Item("nombreGrupoUsuario").ToString)
            '    strGl_nombreEntidad = Trim(dsDatos.Tables(0).Rows(0).Item("empresa").ToString)
            '    intGl_idEntidad = dsDatos.Tables(0).Rows(0).Item("idEntidad").ToString
            '    strGl_RutaFoto = Trim(dsDatos.Tables(0).Rows(0).Item("fotoPersona").ToString)
            '    intGl_idGrupoUsuario = dsDatos.Tables(0).Rows(0).Item("idGrupoUsuario").ToString
            '    ' Else
            '    '    intGl_idUsuario = dsDatos.Tables(0).Rows(0).Item("idUsuario").ToString
            '    'MsgBox("Valor de idusuario" + intGl_idUsuario)
            'End If
            'MsgBox("El procedimiento de Acceso", MsgBoxStyle.Exclamation)
            '-------------------------------------
            '-- validacion si existe el usuario
            ''-------------------------------------
            't = CInt(cmd.ExecuteScalar())
            'If t = 0 Then
            '    Return False
            'Else
            '    Return True
            'End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            valor = False
            Return valor

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

        Return valor
    End Function

    ' funcion para saber solo el nick del usuario
    Public Function accesoClave(ByVal pass As String) As Boolean
        'Dim cmd1 As New SqlConnection
        Dim rowCount As Integer
        Dim cmd As New SqlCommand
        Dim sqldad = New SqlDataAdapter(cmd)
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                ' MsgBox("Se conecto ala base de datos")
            End If

            ' MsgBox("Va a realizar el procedimiento..!")
            'Establecemos las propiedades preliminares
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_claveUsuario"

            cmd.Parameters.AddWithValue("@pass", pass)

            rowCount = cmd.ExecuteNonQuery()
            'MsgBox("Valor de rowCount  " & rowCount)
            If rowCount <> 0 Then
                ' MsgBox("Verdadero..!")
                Return True
            Else
                'MsgBox("Falso...!")
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return False

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    ' funcion para saber si está habilitado la entidad por usuario y contraseña
    Public Function entidadActivo(ByVal Usuario As String, ByVal pass As String) As Boolean
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
            cmd.CommandText = "sp_usuarioEntidadActivo"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@nick", Usuario)
            cmd.Parameters.AddWithValue("@pass", pass)

            Dim t As Integer = CInt(cmd.ExecuteScalar())
            If t = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return False

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    ' funcion para saber si está habilitado la entidad por usuario con tarjeta
    Public Function entidadTarjetaActivo(ByVal pass As String) As Boolean
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
            cmd.CommandText = "sp_usuarioTarjetaEntidadActivo"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@pass", pass)

            Dim t As Integer = CInt(cmd.ExecuteScalar())
            If t = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return False

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    ' funcion para saber los datos de la pc si están cargados en el sistema
    Public Function DatosIngreso() As Boolean

        Dim cmd As New SqlCommand
        Dim sqldad = New SqlDataAdapter(cmd)
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Dim valor As Boolean = True
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            'Establecemos las propiedades preliminares
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_datosPc"

            'Establecemos los parametros
            'Entrada
            'obtener la serial del disco
            'MsgBox("Valor del serial del disco  " & info.obtenerSerialDisco)

            cmd.Parameters.AddWithValue("@serialhd", info.obtenerSerialDisco1)
            'otener el nombre de la pc
            cmd.Parameters.AddWithValue("@nombrepc", info.obtenerNombreHost)
            'otener la id de la pc
            cmd.Parameters.AddWithValue("@idpc", info.ObtenerIdPc)

            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'cmd.Parameters.Add("@idConfigpc", SqlDbType.Int)
            'cmd.Parameters("@idUsuario").Direction = ParameterDirection.Output
            sqldad.Fill(dsDatos, "v_configpc")

            '-- para agregar en la variable publica el idusuario
            Dim t As Integer = CInt(cmd.ExecuteScalar())

            'MsgBox("Valor de t  " & t)
            'cmd.ExecuteNonQuery()
            If t <> 0 Then
                'MsgBox("Valor verdaderos")
                intGl_idConfigPc = dsDatos.Tables(0).Rows(0).Item("idConfig").ToString
                intGl_idSucursal = dsDatos.Tables(0).Rows(0).Item("idsucursal").ToString
                strGl_nombreSucursal = dsDatos.Tables(0).Rows(0).Item("nombreFantasia").ToString
                Return valor
            Else
                conn.Close()
                Return valor
            End If

        Catch ex As Exception
            conn.Close()
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            valor = False
            Return valor
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If
        End Try

    End Function

    ' funcion para registrar el ingreso al sistema
    Public Sub insIngresoSistema()
        Dim rowCount As Integer
        Dim cmd As New SqlCommand
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            'MsgBox("Está en el principio del procedimiento", MsgBoxStyle.Exclamation)
            'Establecemos las propiedades preliminares
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_insIngresoSistema"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idUsuario", intGl_idUsuario)
            cmd.Parameters.AddWithValue("@idConfig", intGl_idConfigPc)
            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 200)
            cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            'Ejecutamos el sp y evaluamos la cantidad de filas insertadas
            'MsgBox("Está en el procedimiento", MsgBoxStyle.Exclamation)
            rowCount = cmd.ExecuteNonQuery()

            If rowCount = 1 Then
                'colocar la fecjha 
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

    ' funcion para saber la fecha y hora del servidor
    Public Sub fechaHoraServer()
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
            cmd.CommandText = "sp_fechaHoraServer"

            'Establecemos los parametros
            'Entrada
            'Salida
            'Declaramos de que tipo de datos es el parametro y despues le decimos que es de salida
            'Sucursal
            'cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100)
            'cmd.Parameters("@Mensaje").Direction = ParameterDirection.Output
            '-----------------------------------------
            '----- la fecha por parte del servidor ---
            '-----------------------------------------
            strGl_fechaHoraServer = cmd.ExecuteScalar
            cmd.CommandText = "sp_nombreDiaServer"
            strGl_nombreDiaServer = cmd.ExecuteScalar
            cmd.CommandText = "sp_nombreMesServer"
            strGl_nombreMesServer = cmd.ExecuteScalar
            cmd.CommandText = "sp_anhoServer"
            strGl_anhoServer = cmd.ExecuteScalar.ToString
            cmd.CommandText = "sp_diaServer"
            strGl_diaAserver = cmd.ExecuteScalar.ToString
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
