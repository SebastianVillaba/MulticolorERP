Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class sp_datosTabla
    Private info As New info

    Public Function un_dato(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            'MsgBox("Entro al error catch ")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_dato", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function un_datoString(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As String)
        limpiarDataset()
        'MsgBox("paso por aca")
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & "'" & v_busqueda & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        ' MsgBox("Valor de la Consulta  " & sql)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    If IsDBNull(reader.GetValue(0)) Then
                        v_resultado = ""
                    Else
                        v_resultado = reader.GetValue(0)
                    End If

                    ' MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            'MsgBox("Entro al error catch ")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_datoString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function un_datoActivo(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda & " and activo=1"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0).ToString
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_datoActivo", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function dos_datos(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    'MsgBox("Valor del Resultado  " & v_resultado)
                    v_resultado = Trim(reader.GetValue(0).ToString) & "," & Trim(reader.GetValue(1).ToString)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "dos_datos", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function un_dato_boleano(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda
        'MsgBox("Valor de la consulta  " & sql)
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As Boolean = False
            Using reader
                While reader.Read
                    'MsgBox("Valor del Resultado  " & v_resultado)

                    If IsDBNull(reader.GetValue(0)) Then ' DBNull.Equals = v_resultado Then
                        v_resultado = False
                    Else
                        v_resultado = reader.GetValue(0)
                    End If

                End While
            End Using
            Return v_resultado

        Catch ex As Exception
            ' MsgBox("Entro al error de la consulta")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_dato_boleano", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function un_dato_integer(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        'MsgBox("Valor del SP  " & sql)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        '5MsgBox(" " & sql, MsgBoxStyle.Information)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_dato_integer", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function un_dato_double(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As Double = 0.0
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_dato_double", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- un sp de tipo string
    Public Function sp_traerValor(ByVal v_nombreSp As String, ByVal v_parametro As String, ByVal v_lugar As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "exec " & v_nombreSp & " " & v_parametro
        'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
        'frmPedidoMercaderia.txtSql.Text = sql
        'frmPassRepartidor.txtSql.Text = sql
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(v_lugar).ToString
                    'MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function


    '-- un sp de tipo integer
    Public Function sp_traerValorInteger(ByVal v_nombreSp As String, ByVal v_parametro As String, ByVal v_lugar As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "exec " & v_nombreSp & " " & v_parametro
        'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    v_resultado = CInt(reader.GetValue(v_lugar))
                    'MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValorInteger", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- para un procedimiento que devuelve un valor de tipo string
    Public Function sp_string(ByVal v_nombreSp As String, ByVal v_parametro As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "exec " & v_nombreSp & " " & v_parametro

        'MsgBox("Nombre y valor del SP  " & sql)
        'If banGl_ventaFarmacia = True Then
        ' frmVentaFarmacia.txtSql.Text = sql
        ' End If

        'frmPedidoProveedor.txtSql.Text = sql

        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            '-- colocar la propiedad de retardo en el tiempo del sql 
            cmd.CommandTimeout = 20 * 60 '20 minutos
            '---------------------------------------------
            'MsgBox("Antes de entrar")
            reader = cmd.ExecuteReader()
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0).ToString
                    ' MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_string", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- para un procedimiento que devuelve un valor de tipo string
    Public Function sp_buscarProductosFotos(ByVal v_nombreSp As String, ByVal v_parametro As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "exec " & v_nombreSp & " " & v_parametro
        Dim v_contador As Integer = 0
        'MsgBox("Nombre y valor del SP  " & sql)
        'If banGl_ventaFarmacia = True Then
        ' frmVentaFarmacia.txtSql.Text = sql
        ' End If

        'frmPedidoProveedor.txtSql.Text = sql

        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' consulta_valor("update producto set sinFoto=0")

            '-- colocar la propiedad de retardo en el tiempo del sql 
            cmd.CommandTimeout = 20 * 60 '20 minutos
            '---------------------------------------------
            'MsgBox("Antes de entrar")
            reader = cmd.ExecuteReader()
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    v_contador = v_contador + 1
                    v_resultado = reader.GetValue(0).ToString
                    frmReporteMercaderiaGral.txtContador.Text = v_contador
                    '--- buscar el archivo
                    If existeArchivoDatosPC(strGl_rutaImagen + Trim(v_resultado) + ".jpg") = False Then
                        consulta_valor("update producto set sinFoto=1 where codigo='" & v_resultado & "'")

                    End If
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_string", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function sp_integer(ByVal v_nombreSp As String, ByVal v_parametro As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "exec " & v_nombreSp & " " & v_parametro
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_integer", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function sp_double(ByVal v_nombreSp As String, ByVal v_parametro As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "exec " & v_nombreSp & " " & v_parametro
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        'MsgBox("Valor de la consulta  " & sql)
        'frmIngresoNick.txtSql.Text = sql
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            '-- colocar la propiedad de retardo en el tiempo del sql 
            cmd.CommandTimeout = 6 * 60 '3 minutos
            '---------------------------------------------
            reader = cmd.ExecuteReader()
            Dim v_resultado As Double = 0
            Using reader

                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While

            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_double", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- para un procedimiento que devuelve un string pero sin parametros de entradas
    Public Function sp_sinParametroString(ByVal v_nombreSp As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "exec " & v_nombreSp
        'MsgBox("Nombre y valor del SP  " & sql)
        ' frmPass.txtSql.Text = sql
        'frmAbmProducto.txtSql.Text = sql
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0).ToString
                    ' MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_sinParametroString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function un_dato_integerActivo(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda & " and activo=1"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Nombre de la tabla  " & v_tabla)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_dato_integerActivo", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function cantidad_registros(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String, ByVal v_busqueda As Integer)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select count(*)," & v_campo & " from " & v_tabla & " where " & v_clave & "=" & v_busqueda & "group by " & v_campo & " having count(*)>1  "
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            ' MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            'MsgBox("Entro al error catch ")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "cantidad_registros", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Function un_dato_integer_consulta(ByVal v_campo As String, ByVal v_tabla As String, ByVal v_clave As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & "select " & v_campo & " from " & v_tabla & " where " & v_clave
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            ' MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            'MsgBox("Entro al error catch ")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "un_dato_integer_consulta", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- consulta de sql para un valor entero
    Public Function consulta_valor(ByVal v_consulta As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = v_consulta
        'If banGl_puntajeCliente = True Then
        ' frmPuntajeCliente.txtSql.Text = sql
        ' End If
        'frmNickPass.txtSql.Text = sql
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                'MsgBox("Abierto")
                conn.Open()
            Else
                'MsgBox("Cerrado")
            End If
            reader = cmd.ExecuteReader()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    If Not IsDBNull(reader.GetValue(0)) Then
                        v_resultado = reader.GetValue(0)
                    End If
                    'v_resultado = reader.GetValue(0)
                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            'MsgBox("Entro al error catch ")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- consulta de sql para un valor entero
    Public Function consulta_valorBoolean(ByVal v_consulta As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = v_consulta
        'MsgBox("Valor de sql  " & sql)
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()

            'reader.Read()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As Boolean = False
            Using reader
                While reader.Read
                    If reader.GetValue(0) Is DBNull.Value Then
                        v_resultado = False
                    Else
                        v_resultado = reader.GetValue(0)
                    End If

                    'MsgBox("Valor del Resultado  " & v_resultado.ToString)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            'MsgBox("Entro al error catch ")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorBoolean", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- consulta de sql para un valor string
    Public Function consulta_valorString(ByVal v_consulta As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & v_consulta
        'MsgBox("Valor de sql  " & sql)
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As String = ""
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0).ToString
                    ' MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            Return ""
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    Public Sub cargarImagen()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor 'Con esto el puntero del ratón da vueltas mientras carga la imagen
        Try
            'Buscamos y cargamos la imagen
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create("https://www.soyvisual.org/fotos/pelota-de-playa")
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As System.IO.Stream = response.GetResponseStream()
            'Asignamos la imagen a un Bitmap
            Dim bmp As New Bitmap(responseStream)
            'Asignamos la imagen al PictureBox
            frmAbmProducto.picImagen.Image = bmp

        Catch
            'Aquí se pondría la imagen que se desea, si el recurso no está disponible
            Dim value As New String("error.jpg") 'La cargamos por ruta
            Dim bmp2 As New Bitmap(value)  'La asignamos al bmp
            ' Return bmp2 'La asignamos al picturebox
        End Try

        'Refrescamos imagen
        'Panel1.AutoScrollMinSize = frmAbmProducto.picImagen.Image.Size
        'Panel1.AutoScroll = True
    End Sub

    '-- consulta de sql para un valor tipo imagen
    Public Function consulta_valorImagen(ByVal v_consulta As String) As Image
        limpiarDataset()
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = "set language español " & v_consulta
        Dim cmd As New SqlCommand(sql, conn)
        conn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader
        reader.Read()
        If reader.GetValue(0) Is DBNull.Value Then
            Return Nothing
        Else
            Dim bitPic() As Byte = CType(reader.GetValue(0), Byte())

            conn.Close()
            Dim mStream As MemoryStream = New MemoryStream(bitPic)
            Dim img As Image = Image.FromStream(mStream)

            Return img
        End If
    End Function


    '-- consulta de sql para un valor double como la monedas o kilos
    Public Function consulta_valorDouble(ByVal v_consulta As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = v_consulta
        'frmVentaFarmacia1.txtSql.Text = sql
        'MsgBox("Valor de sql  " & sql)
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As Double = 0.0
            Using reader
                While reader.Read
                    v_resultado = CDbl(reader.GetValue(0).ToString)
                    ' MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorDouble", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function

    '-- consulta de sql para un valor entero
    Public Function obtenerCedula(ByVal v_consulta As String)
        limpiarDataset()
        'Dim cmd1 As New SqlConnection
        Dim conn As New SqlConnection(conexion)
        Dim sql As String = v_consulta
        'MsgBox("Valor de sql  " & sql)
        ' frmRemisionMercaderia.txtSql.Text = sql
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As Integer = 0
            Using reader
                While reader.Read
                    v_resultado = reader.GetValue(0)
                    ' MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using
            Return v_resultado
        Catch ex As Exception
            'MsgBox("Entro al error catch ")
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            'errorSistema(strGl_mensajeError, "consulta_valor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return ""

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

    End Function
End Class

