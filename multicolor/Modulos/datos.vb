Imports System.Data.SqlClient
Module datos
    'data set datos
    Public dsDatos As New DataSet
    'elimina todas las tablas del dataset
    Public Sub limpiarDataset()
        Try
            dsDatos.Tables.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "datos"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '---------------------------------------------------'
    '--------------- abrir las tablas ------------------'
    '---------------------------------------------------'
    Public Function cargarUsuario() As Boolean
        Dim cmd As New SqlCommand
        Dim previousConnectionState As ConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            ' vista de usuarios
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from v_usuario"
            Dim dataAdapter As New SqlDataAdapter(cmd)
            dataAdapter.Fill(dsDatos, "v_usuario")

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "cargarUsuario"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
        If previousConnectionState = ConnectionState.Closed Then
            conn.Close()
        End If
    End Function
    '-- la vista del menu principal
    Public Function cargarMenuPrincipal() As Boolean
        Dim cmd As New SqlCommand
        Dim previousConnectionState As ConnectionState = conn.State
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            ' vista de usuarios
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from v_menuPrincipal"
            Dim dataAdapter As New SqlDataAdapter(cmd)
            dataAdapter.Fill(dsDatos, "v_menuPrincipal")

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "cargarMenuPrincipal"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
        If previousConnectionState = ConnectionState.Closed Then
            conn.Close()
        End If
    End Function
End Module
