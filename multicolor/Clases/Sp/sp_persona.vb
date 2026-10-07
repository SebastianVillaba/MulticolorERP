Imports System.Data.SqlClient
Public Class sp_persona
    Private sp_auditoriaSistema As New sp_auditoriaSistema
    Public Sub insPersona(ByVal idEntidad As Integer, ByVal nombre As String, ByVal ruc As String, ByVal dv As String, ByVal direccion As String, ByVal barrio As String, ByVal ciudad As String, ByVal fechaani As String, ByVal tele1 As String, ByVal tele2 As String, ByVal celular1 As String, ByVal celular2 As String, ByVal email1 As String, ByVal email2 As String, ByVal web As String, ByVal fotoPersona As String, ByVal idUusuarioAlta As Integer, ByVal tipoPersonaJur As Boolean, ByVal nombreFantasia As String, ByVal tipoPersonaFis As Boolean, ByVal apellido As String, ByVal tipoCliente As Boolean, ByVal idGrupoCliente As Integer, ByVal acreditarVenta As Boolean, ByVal tipoProveedor As Boolean, ByVal nombreResponsable As String, ByVal timbrado As String)
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
            cmd.CommandText = "sp_InsPersona"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idEntidad", idEntidad)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@ruc", ruc)
            cmd.Parameters.AddWithValue("@dv", dv)
            cmd.Parameters.AddWithValue("@direccion", direccion)
            cmd.Parameters.AddWithValue("@barrio", barrio)
            cmd.Parameters.AddWithValue("@ciudad", ciudad)
            cmd.Parameters.AddWithValue("@fechaani", fechaani)
            cmd.Parameters.AddWithValue("@tele1", tele1)
            cmd.Parameters.AddWithValue("@tele2", tele2)
            cmd.Parameters.AddWithValue("@celular1", celular1)
            cmd.Parameters.AddWithValue("@celular2", celular2)
            cmd.Parameters.AddWithValue("@email1", email1)
            cmd.Parameters.AddWithValue("@email2", email2)
            cmd.Parameters.AddWithValue("@web", web)
            cmd.Parameters.AddWithValue("@fotoPersona", fotoPersona)
            cmd.Parameters.AddWithValue("@idUsuarioAlta", idUusuarioAlta)
            cmd.Parameters.AddWithValue("@nombreFantasia", nombreFantasia)
            cmd.Parameters.AddWithValue("@apellido", apellido)
            cmd.Parameters.AddWithValue("@idGrupoCliente", idGrupoCliente)
            cmd.Parameters.AddWithValue("@acreditarVenta", acreditarVenta)
            cmd.Parameters.AddWithValue("@tipoPersonaJur", tipoPersonaJur)
            cmd.Parameters.AddWithValue("@tipoProveedor", tipoProveedor)
            cmd.Parameters.AddWithValue("@responsableProveedor", nombreResponsable)
            cmd.Parameters.AddWithValue("@timbrado", timbrado)
            cmd.Parameters.AddWithValue("@tipoPersonaFis", tipoPersonaFis)
            cmd.Parameters.AddWithValue("@tipoPersonaCli", tipoCliente)
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
                strValorActual = Trim(nombre) & "," & Trim(ruc) & "," & Trim(dv) & "," & Trim(direccion) & "," & Trim(barrio) & "," & Trim(ciudad) & "," & Trim(fechaani) & "," & Trim(tele1) & "," & Trim(tele2) & "," & Trim(celular1) & "," & Trim(celular2) & "," & Trim(web) & "," & Trim(fotoPersona)
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "ABM PERSONA", True, False, intGl_idUsuario, "PERSONA", "", strValorActual, strNombreHost)
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

    Public Sub UpdPersona(ByVal idPersona As Integer, ByVal nombre As String, ByVal ruc As String, ByVal dv As String, ByVal direccion As String, ByVal barrio As String, ByVal ciudad As String, ByVal fechaani As String, ByVal tele1 As String, ByVal tele2 As String, ByVal celular1 As String, ByVal celular2 As String, ByVal email1 As String, ByVal email2 As String, ByVal web As String, ByVal fotoPersona As String, ByVal activo As Boolean, ByVal idUusuariomod As Integer, ByVal datosOriginales As String)
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
            cmd.CommandText = "sp_updPersona"

            'Establecemos los parametros
            'Entrada
            cmd.Parameters.AddWithValue("@idPersona", idPersona)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@ruc", ruc)
            cmd.Parameters.AddWithValue("@dv", dv)
            cmd.Parameters.AddWithValue("@direccion", direccion)
            cmd.Parameters.AddWithValue("@barrio", barrio)
            cmd.Parameters.AddWithValue("@ciudad", ciudad)
            cmd.Parameters.AddWithValue("@fechaani", fechaani)
            cmd.Parameters.AddWithValue("@tele1", tele1)
            cmd.Parameters.AddWithValue("@tele2", tele2)
            cmd.Parameters.AddWithValue("@celular1", celular1)
            cmd.Parameters.AddWithValue("@celular2", celular2)
            cmd.Parameters.AddWithValue("@email1", email1)
            cmd.Parameters.AddWithValue("@email2", email2)
            cmd.Parameters.AddWithValue("@web", web)
            cmd.Parameters.AddWithValue("@fotoPersona", fotoPersona)
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.Parameters.AddWithValue("@idUsuarioMod", idUusuariomod)
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
                strValorActual = Trim(nombre) & "," & Trim(ruc) & "," & Trim(dv) & "," & Trim(direccion) & "," & Trim(barrio) & "," & Trim(ciudad) & "," & Trim(fechaani) & "," & Trim(tele1) & "," & Trim(tele2) & "," & Trim(celular1) & "," & Trim(celular2) & "," & Trim(web) & "," & Trim(fotoPersona)
                sp_auditoriaSistema.insAuditoriaSistema(intGl_idConfigPc, intGl_idSucursal, "ABM PERSONA", False, True, intGl_idUsuario, "PERSONA", datosOriginales, strValorActual, strNombreHost)
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
