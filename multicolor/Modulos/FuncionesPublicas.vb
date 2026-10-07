Option Explicit On
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.Mail
'Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Text
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Module FuncionesPublicas
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim sp_IngresoSistema As New sp_IngresoSistema
    Dim sp_guardarVentaHeladeria As New sp_guardarVentaHeladeria
    Dim cargarError As New cargarError

    '*******************'
    '-- LAS FUNCIONES --'
    '*******************'
    '----------------'
    '-- CONEXIONES --'
    '----------------'
    'hayar la conexion
    Function hayarConexion() As Boolean
        ' MsgBox("Paso aca por la conexion")

        hayarConexion = False
        Dim valido As Boolean = False
        Dim connTest As New SqlConnection
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        ' MsgBox("Valor de la variable de conexion   " & intGl_tipoConexion)


        Try
            'conn.Close()
            ' conexion local
            'MsgBox("Valor intGl_tipoConexion  " & intGl_tipoConexion)
            If valido = False Then
                Select Case intGl_tipoConexion
                    Case Is = 1
                        '-- para la conexion en mi pc
                        conn.ConnectionString = "Server=" & strGlNombreServer & ";Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=" & strGlClaveServer
                        conexion = "Server=" & strGlNombreServer & ";Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=" & strGlClaveServer
                    Case Is = 2
                        '-- para la conexion LAN
                        conn.ConnectionString = "Server=192.168.100.236;Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=Sqlmulticolor12345"
                        conexion = "Server=192.168.100.236;Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=Sqlmulticolor12345"
                    Case Is = 3
                        '-- para la conexion en VPN
                        conn.ConnectionString = "Server=26.95.122.182;Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=Sqlmulticolor12345"
                        conexion = "Server=26.95.122.182;Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=Sqlmulticolor12345"

                        ' MsgBox("Valor conexion " & conexion)
                    Case Is = 4
                        '-- para la conxion en INTERNET
                        conn.ConnectionString = "Server=190.104.132.116;Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=Sqlmulticolor12345"
                        conexion = "Server=190.104.132.116;Database=" & strGl_nombreBaseDatos & ";User Id=sa;Password=Sqlmulticolor12345"
                End Select
                'MsgBox("la conexion  " & conn.ConnectionString)
                Try
                    If conn.State = ConnectionState.Closed Then
                        'MsgBox("Se abrió la conexion", MsgBoxStyle.Information)
                        conn.Open()
                    End If
                    hayarConexion = True
                    valido = True
                Catch
                    hayarConexion = False
                    MessageBox.Show("La conexión no es Válida..! Verifique por Favor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                Finally
                    If previousConnectionState = ConnectionState.Closed Then
                        conn.Close()
                    End If
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(hayarConexion.ToString & ", produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            Return False
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Function

    ' Establecer conexion
    Function establecerConexion() As Boolean
        Dim valido As Boolean = True
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        Try
            Select Case intGl_tipoConexion
                Case Is = 1
                    '-- para la conexion en mipc
                    conn.ConnectionString = "Data Source=" & strGlNombreServer & ";Initial Catalog=" & strGl_nombreBaseDatos & ";User ID=sa;" & strGlClaveServer

                Case Is = 2
                    '-- para la conexion en LAN
                    conn.ConnectionString = "Data Source=192.168.100.236;Initial Catalog=" & strGl_nombreBaseDatos & ";User ID=sa;Password=Sqlmulticolor12345"
                Case Is = 3
                    '-- para la conexion en VPN
                    conn.ConnectionString = "Data Source=26.95.122.182;Initial Catalog=" & strGl_nombreBaseDatos & ";User ID=sa;Password=Sqlmulticolor12345"
                    'MsgBox("Valor conexion establecida " & conn.ConnectionString)
                Case Is = 4
                    '-- para la conxion en INTERNET
                    conn.ConnectionString = "Data Source=190.104.132.116;Initial Catalog=" & strGl_nombreBaseDatos & ";User ID=sa;Password=Sqlmulticolor12345"
            End Select
            Return valido
            conexion = conn.ConnectionString
        Catch ex As Exception
            MessageBox.Show(hayarConexion.ToString & ", produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            Return False
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Function

    '-------------------------------------------------------------------------------------

    '-- obtern el dv del ruc
    Function getDV(ByVal RUC As String) As String
        getDV = calcular(RUC, 11)
        Return getDV
    End Function

    Function calcular(ByVal numero As String, ByVal basemax As Integer) As String
        Dim codigo As Long
        Dim numero_al As String = ""

        Dim i
        For i = 1 To Len(numero)
            Dim c
            c = Mid$(numero, i, 1)
            codigo = Asc(UCase(c))
            If Not (codigo >= 48 And codigo <= 57) Then
                numero_al = numero_al & codigo
            Else
                numero_al = numero_al & c
            End If
        Next

        Dim k : Dim total
        k = 2
        total = 0

        For i = Len(numero_al) To 1 Step -1
            If (k > basemax) Then k = 2
            Dim numero_aux
            numero_aux = Val(Mid(numero_al, i, 1))
            total = total + (numero_aux * k)
            k = k + 1
        Next


        Dim resto : Dim digito
        resto = total Mod 11
        If (resto > 1) Then
            digito = 11 - resto
        Else
            digito = 0
        End If
        calcular = digito
    End Function

    '-- funcion para colocar en un txt solo numeros
    Public Function txtSoloNumerico(ByVal txtControl As TextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = True Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If

    End Function

    Public Function blanquearBanderas(ByVal v_variable As String) As Boolean
        Dim v_resultadorBlanquearBanderas As Boolean = False
        Select Case v_variable
            Case Is = "banGl_ventaFarmacia"
                '-- aqui poner en falso todas las otras banderas
                banGl_compra = False
                v_resultadorBlanquearBanderas = True
                Return v_resultadorBlanquearBanderas
            Case Is = "banGl_compra"
                '-- aqui poner en falso todas las otras banderas
                banGl_ventaFarmacia = False
                v_resultadorBlanquearBanderas = True
                Return v_resultadorBlanquearBanderas
        End Select
        Return v_resultadorBlanquearBanderas
    End Function

    '-- formato para colocar los separadores de miles
    Public Function formatoNumerosDecimales(ByVal v_numero As Double)
        Dim strTmpResultadoNumero As String = ""
        Dim intTmpLongitudVarbale As Integer
        Dim v_intValor As Integer
        Dim v_douResultado As Integer
        Dim strTmpValor As String = "0"
        Dim intTmpLongitudEntero As Integer
        Dim intTmpLongitudDecimal As Integer
        Dim intTmpLongitudTotalVariable As Integer
        Dim strTmpValorNumero As String
        Dim v_decimal As String
        Dim strTmpValorDecimal As String = ""
        Dim strTmpValorEntero As String = ""
        Dim bolTmpPaso As Boolean = False


        v_intValor = Int(v_numero)
        'MsgBox("Valor numero  " & v_numero)

        If v_numero > 0 Then
            'MsgBox("Paso 1")

            v_douResultado = Int((v_numero - v_intValor) * 100)

            '-- sacar el tamaño de la varibale
            intTmpLongitudVarbale = Len(Trim(CStr(v_intValor)))
            '-- variable para guardar las partes de los numeros
            strTmpValorNumero = CStr(v_intValor)
            '-- sacar el valor decimal
            intTmpLongitudTotalVariable = Len(Trim(Str(v_numero)))
            intTmpLongitudEntero = Len(Trim(Str(Int(v_numero))))
            intTmpLongitudDecimal = intTmpLongitudTotalVariable - (intTmpLongitudEntero + 1)
            '-------------------------------------------------
            '-- recorrer la parte entera
            For i As Integer = 0 To intTmpLongitudVarbale - 1
                'MsgBox("Valor de i  " & i)
                '-- realizar los calculos solo si existem items cargados
                strTmpValorEntero = strTmpValorEntero & strTmpValorNumero.Substring(i, 1)

                Select Case intTmpLongitudVarbale
                    '-- para 9.999
                    Case Is = 4
                        'MsgBox("Opcion 4..!")
                        If i = 0 Then
                            ' MsgBox("Opcion 4.0 ..!")
                            strTmpValorEntero = strTmpValorEntero & ","
                            'MsgBox("Valor de del resultado  " & strTmpResultadoNumero)
                        End If
                        '-- para 99.999
                    Case Is = 5
                        'MsgBox("Opcion 5..!")
                        If i = 1 Then
                            '   MsgBox("Opcion 5.1  ..!")
                            strTmpValorEntero = strTmpValorEntero & ","
                        End If
                        '-- para 999.999
                    Case Is = 6
                        'MsgBox("Opcion 6..!")
                        If i = 2 Then
                            '   MsgBox("Opcion 6.2  ..!")
                            strTmpValorEntero = strTmpValorEntero & ","
                        End If
                        '-- para 9.999.999
                    Case Is = 7
                        'MsgBox("Opcion 7..!")
                        If i = 0 Then
                            '   MsgBox("Opcion 7.0  ..!")
                            strTmpValorEntero = strTmpValorEntero & ","
                        End If
                        If i = 3 Then
                            ' MsgBox("Opcion 7.3   ..!")
                            strTmpValorEntero = strTmpValorEntero & ","
                        End If
                        '-- para 99.999.999
                    Case Is = 8
                        'MsgBox("Opcion 8..!")
                        If i = 1 Then
                            '   MsgBox("Opcion 8.1  ..!")
                            strTmpValorEntero = strTmpValorEntero & ","
                        End If
                        If i = 4 Then
                            '  MsgBox("Opcion 8.4  ..!")
                            strTmpValorEntero = strTmpValorEntero & ","
                        End If
                End Select
            Next
        Else
            If v_numero = 0 Then
                ' MsgBox("Paso 1")

                v_douResultado = 0
                strTmpValorEntero = "0"
            Else
                Dim intTmpLugar As Integer
                'intTmpLugar = Len(Int(v_numero))
                intTmpLugar = Len(CStr(v_intValor))
                'Dim strTmp As String
                'MsgBox("Valor del lugar " & intTmpLugar)

                v_douResultado = v_numero
                'strTmpValorEntero = CStr(v_douResultado)
                'MsgBox("Valor del entero  " & v_intValor)
                'MsgBox("Valor  " & v_numero)
                'MsgBox("Valor de la len " & intTmpLugar)

                strTmpValorEntero = v_numero.ToString.Substring(0, intTmpLugar)
            End If
            'If v_numero = 1 Then
            '    v_douResultado = 0
            '    strTmpValorEntero = "1"
            'Else
            '    v_douResultado = 0
            '    strTmpValorEntero = "-1"
            'End If

        End If

        ' MsgBox("Valor del numero " & strTmpValorEntero)

        '-- armar la parte decimal
        v_decimal = CStr(v_numero)
        intTmpLongitudTotalVariable = Len(Trim(v_decimal))

        '-- recorrer la parte decimal
        For i As Integer = 0 To intTmpLongitudTotalVariable - 1
            strTmpValorNumero = v_decimal.Substring(i, 1)

            If bolTmpPaso = True Then
                strTmpValorDecimal = strTmpValorDecimal + strTmpValorNumero
            End If

            If strTmpValorNumero = "." Then
                bolTmpPaso = True
            End If
        Next

        '-- armar el decimal
        If Len(strTmpValorDecimal) > 0 Then
            strTmpResultadoNumero = strTmpValorEntero + "." + strTmpValorDecimal
            v_decimal = "00"
        Else
            strTmpResultadoNumero = strTmpValorEntero
        End If

        Return strTmpResultadoNumero
    End Function

    '-- convertir a decimal un numero con mascara de de separador de miles 9.999,99 a 9999.99
    Public Function convertirNumeroDecimal(ByVal v_numero As String)
        '-- mostrar el decimal
        Dim v_douValor As Double
        Dim v_strValor As String
        v_strValor = (v_numero.Replace(",", ""))
        'MsgBox("Valor entero  " & v_strValor)
        'v_strValor = v_strValor.Replace(",", ".")
        'MsgBox("Valor decimal  " & v_strValor)
        v_douValor = CDec(v_strValor)
        'MsgBox("Valor del total  " & v_douValor)
        Return v_douValor
    End Function

    '-- formato para la fecha de los separadores de fecha}
    Public Function formatoFecha_ochoLugares(ByVal v_fecha As String)
        '-- variable de resultado
        Dim strTmpFechaResultado As String = "99/99/9999"
        '-- varibale para guardar el valor ingresado
        Dim strTmpValor As String
        strTmpValor = v_fecha.Replace("/", "")
        '-- cantidad de valores ingresados
        Dim intTmpLongitudValor As Integer = 0
        intTmpLongitudValor = Len(strTmpValor)
        'MsgBox("Valor de la longitud  " & intTmpLongitudValor)
        Select Case intTmpLongitudValor
            Case Is = 1
                strTmpFechaResultado = strTmpValor & "9/99/999"
            Case Is = 2
                strTmpFechaResultado = strTmpValor & "/99/999"
            Case Is = 3
                strTmpFechaResultado = strTmpValor.Substring(0, 2) & "/" & strTmpValor.Substring(2, 1) & "9/9999"
            Case Is = 4
                strTmpFechaResultado = strTmpValor.Substring(0, 2) & "/" & strTmpValor.Substring(2, 2) & "/9999"
            Case Is = 5
                strTmpFechaResultado = strTmpValor.Substring(0, 2) & "/" & strTmpValor.Substring(2, 2) & "/" & strTmpValor.Substring(4, 1) & "999"
            Case Is = 6
                strTmpFechaResultado = strTmpValor.Substring(0, 2) & "/" & strTmpValor.Substring(2, 2) & "/" & strTmpValor.Substring(4, 2) & "99"
            Case Is = 7
                strTmpFechaResultado = strTmpValor.Substring(0, 2) & "/" & strTmpValor.Substring(2, 2) & "/" & strTmpValor.Substring(4, 3) & "9"
            Case Is = 8
                strTmpFechaResultado = strTmpValor.Substring(0, 2) & "/" & strTmpValor.Substring(2, 2) & "/" & strTmpValor.Substring(4, 4)
        End Select
        '-- verificar la fecha
        'strTmpFechaResultado = CDate(strTmpFechaResultado)

        'MsgBox("Resultado  " & strTmpFechaResultado)

        Return strTmpFechaResultado
    End Function

    'Retorna el formato de la fecha para consulta desde
    Public Function FormatoFechaSoloDatePicker(ByVal Fecha As DateTimePicker) As String
        Return ((Fecha.Value.Year & "-" & Fecha.Value.Month & "-" & Fecha.Value.Day))
    End Function

    Public Function controlarFecha_ochoLugares(ByVal v_fecha As String)
        '-- sacarle todo el / a la varibale
        Dim strTmpValor As String
        strTmpValor = v_fecha.Replace("/", "")
        '-- valor de la varibale de resultado
        Dim bolTmpResultado As Boolean = False
        '-- controlar si no son numericos las varibales
        If IsNumeric(strTmpValor) Then
            '-- varibale de dia
            Dim strTmpDiaFecha As Integer
            '-- variable de mes
            Dim strTmpMesFecha As Integer
            '-- variable de año
            Dim strTmpAnhoFecha As Integer

            '-- valor del dia
            strTmpDiaFecha = strTmpValor.Substring(0, 2)
            'MsgBox("Valor del dia  " & strTmpDiaFecha)
            '-- valor del mes
            strTmpMesFecha = strTmpValor.Substring(2, 2)
            'MsgBox("Valor del mes  " & strTmpMesFecha)
            '-- valor del año
            strTmpAnhoFecha = strTmpValor.Substring(4, 4)
            'MsgBox("Valor del año  " & strTmpAnhoFecha)

            '-- controlar el mes
            Select Case strTmpMesFecha
                Case "01"
                    'MsgBox("Enero")
                    '-- enero
                    If CInt(strTmpDiaFecha) > 31 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "02"
                    'MsgBox("febrero")
                    '-- febrero
                    If CInt(strTmpDiaFecha) > 28 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "03"
                    'MsgBox("marzo")
                    '-- marzo
                    If CInt(strTmpDiaFecha) > 31 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "04"
                    'MsgBox("Abril")
                    '-- abril
                    If CInt(strTmpDiaFecha) > 30 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "05"
                    'MsgBox("Mayo")
                    '-- mayo
                    If CInt(strTmpDiaFecha) > 31 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "06"
                    'MsgBox("Junio")
                    '-- junio
                    If CInt(strTmpDiaFecha) > 30 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "07"
                    'MsgBox("Julio")
                    '-- julio
                    If CInt(strTmpDiaFecha) > 31 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "08"
                    'MsgBox("Agosto")
                    '-- agosto
                    If CInt(strTmpDiaFecha) > 31 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "09"
                    'MsgBox("Setiembre")
                    '-- setiembre
                    If CInt(strTmpDiaFecha) > 30 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "10"
                    'MsgBox("Octubre")
                    '-- octubre
                    If CInt(strTmpDiaFecha) > 31 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "11"
                    'MsgBox("Noviembre")
                    '-- noviembre
                    If CInt(strTmpDiaFecha) > 30 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If
                Case "12"
                    'MsgBox("Diciembre")
                    '-- diciembre
                    If CInt(strTmpDiaFecha) > 31 Or CInt(strTmpDiaFecha) <= 0 Then
                        bolTmpResultado = False
                    Else
                        bolTmpResultado = True
                    End If

                Case Else
                    'MsgBox("Otro")
                    bolTmpResultado = False
            End Select
        Else
            bolTmpResultado = False
        End If

        Return bolTmpResultado

    End Function

    '-- funcion para guardar uno o mas tablas y retornar si se guardó o no todos los registros de las tablas
    Public Function fun_guardarSp(ByVal v_nombreSP As String, ByVal v_nombreParametro As String, ByVal v_nombreFormulario As String)
        'MsgBox("Entro a la funcion")
        limpiarDataset()
        Dim v_consulta As String
        Dim v_resultado As Integer
        Dim conn As New SqlConnection(conexion)
        '-- colocar el mensaje en español

        Dim sql As String = "exec " & v_nombreSP & " " & v_nombreParametro

        'frmAbmColor.txtSql.Text = sql

        Dim cmd As New SqlCommand(sql, conn)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try
            'MsgBox("paso3 exe")
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            'MsgBox("paso 4 exe")
            '-- colocar la propiedad de retardo en el tiempo del sql 
            cmd.CommandTimeout = 40 * 60 '7 minutos
            '---------------------------------------------
            '-- dar a la varibale de resultado las lineas devueltas por el procedimiento
            v_consulta = cmd.ExecuteNonQuery()

            If CInt(v_consulta) > 0 Then
                v_resultado = 1
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & v_nombreFormulario, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & v_nombreSP & " " & v_nombreFormulario
            'errorSistema(strGl_mensajeError, v_nombreFormulario, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Return v_resultado

        Finally

            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If

        End Try

        Return v_resultado
    End Function

    '-- funcion para guardar uno o mas tablas y retornar si se guardó o no todos los registros de las tablas con imagenes
    Public Function fun_guardarProductoConImagen(ByVal idProducto As Integer, ByVal codigo As String, ByVal idLaboratorio As Integer, _
                           ByVal idDivision As Integer, ByVal idTipoProducto As Integer, ByVal idImpuesto As Integer, _
                           ByVal idLinea As Integer, ByVal idFamilia As Integer, ByVal codigoBarra As String, _
                           ByVal nombreProducto As String, ByVal presentacion As String, ByVal origen As String, _
                           ByVal controlado As Boolean, ByVal maximo As Boolean, ByVal descuento As Double, _
                           ByVal fueraLinea As Boolean, ByVal refrigerado As Boolean, ByVal heladeria As Boolean, _
                           ByVal fotoProducto As String, ByVal activo As Boolean, ByVal idUsuarioMod As Integer, ByVal v_nombreFormulario As String)
        limpiarDataset()
        Dim v_consulta As String
        Dim v_resultado As Integer
        Dim parametro As New SqlClient.SqlParameter
        Dim conn As New SqlConnection(conexion)
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State

        Try
            conn.Open()
            Dim arrFilename() As String = Split(fotoProducto, "\")
            Array.Reverse(arrFilename)
            Dim ms As New MemoryStream
            frmAbmProducto.picImagen.Image.Save(ms, frmAbmProducto.picImagen.Image.RawFormat)

            Dim arrImage() As Byte = ms.GetBuffer
            Dim cmd As New SqlCommand("update producto set imagen=@imagen where idProducto=" & idProducto, conn)
            With cmd
                '.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.NVarChar, 10)).Value = Me.txtNombre.Text
                '.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NText, 10)).Value = Me.txtDescripcion.Text
                .Parameters.Add(New SqlParameter("@Imagen", SqlDbType.Image)).Value = arrImage
            End With
            MessageBox.Show("Registro Insertado Correctamente")
            v_consulta = cmd.ExecuteNonQuery()
            Return v_consulta
        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & sqlExc.Message & "fun_guardarProductoConImagen"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        Catch ex As Exception
            MsgBox(ex.Message)
            strGl_mensajeError = "Error: " & ex.Message & "fun_guardarProductoConImagen"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        Finally
            conn.Close()
        End Try

        Return v_resultado
    End Function

    '-- funcion para introducir en un textbox solo numeros
    Public Function txtNumerico(ByVal txtControl As TextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = True Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else
                    Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function

    '-- funcion para saber si el primer digito es un numero
    Public Function esNumero(ByVal v_cadena As String) As Boolean
        MsgBox("Valor  " & v_cadena.Substring(0, 1))
        If v_cadena.Substring(0, 1) = "0" Or v_cadena.Substring(0) = "1" Or v_cadena.Substring(0) = "2" Or v_cadena.Substring(0) = "3" Or v_cadena.Substring(0) = "4" Or v_cadena.Substring(0) = "5" Or v_cadena.Substring(0) = "6" Or v_cadena.Substring(0) = "7" Or v_cadena.Substring(0) = "8" Or v_cadena.Substring(0) = "9" Then
            Return True
        Else
            Return False
        End If
    End Function

    '-- funcion para introducir en un  maskara solo numeros
    Public Function txtNumericoMask(ByVal txtControl As MaskedTextBox, ByVal caracter As Char) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Then
            Return False
        Else
            Return True
        End If
    End Function

    'Consulta de Comportamientos
    Public Function ConsultarComportamiento(ByVal Menu As String) As Boolean

        '**********************'
        '-- DETALLE DEL MENU --'
        '**********************'
        '-- consultar el menu ingresado dentro de la vista
        Dim strTmpNombreMenu As String
        strTmpNombreMenu = sp_datosTabla.consulta_valorString("select nombreFormulario from v_menuPrincipal where idGrupoUsuario=" & intGl_idGrupoUsuario & " and nombreFormulario=" & "'" & Menu & "'" & " and habilitado=1")
        If strTmpNombreMenu = "" Then
            '-- no encontró
            Return False
        Else
            '-- encontró el menu
            Return True
        End If
        '--------------------------------------------------------------------
    End Function

    '-- para leer un archivo txt de tipo de conexion a la base de datos
    Public Function leerArchivoEntradaConexion()
        'tipoconexion.txt()
        Const fic As String = "c:\Multicolor\tipoconexion.txt"
        Dim strResultado As String
        Dim sr As New System.IO.StreamReader(fic)
        strResultado = sr.ReadToEnd()
        sr.Close()
        Console.WriteLine(strResultado)

        ' MsgBox("Valor de lo leido   " & strResultado)

        Return strResultado
    End Function

    '-- para leer un archivo txt que contiene el ultimo nick ingresado
    Public Function leerArchivoNick()
        'MsgBox("Entro al procedimiento ")
        Const fic As String = "c:\Multicolor\nick.txt"
        Dim strResultado As String
        Dim sr As New System.IO.StreamReader(fic)
        strResultado = sr.ReadToEnd()
        'MsgBox("Valor de lo leido   " & strResultado)
        sr.Close()
        Console.WriteLine(strResultado)


        Return strResultado
    End Function

    '-- saber si existe el archivo de datos de la pc
    Public Function existeArchivoDatosPC(ByVal v_nombreArchivo As String)
        Dim bolResultado As Boolean = False
        Try
            If File.Exists(v_nombreArchivo) Then
                '-- activar la variable global de que existe el archivo
                bolResultado = True
            Else
                '-- activar la variable global de que existe el archivo
                bolResultado = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "existeArchivoDatosPC"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

        Return bolResultado
    End Function

    '-- saber si existe el archivo de reporte pdf
    Public Function existeArchivoReportePdf(ByVal v_nombreArchivo As String)
        Dim bolResultado As Boolean = False
        Try
            If File.Exists(v_nombreArchivo) Then
                '-- activar la variable global de que existe el archivo
                bolResultado = True
            Else
                '-- activar la variable global de que existe el archivo
                bolResultado = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "existeArchivoDatosPC"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

        Return bolResultado
    End Function

    '-- funcion para saber datos del producto
    Public Function obtenerIdProducto(ByVal v_codigoProducto As String)
        Dim v_resultado As Integer
        If Len(v_codigoProducto) = 6 Then
            '-- por codigo de producto
            v_resultado = Int(sp_datosTabla.un_datoString("idProducto", "v_producto", "codigo", v_codigoProducto))
        End If
        If Len(v_codigoProducto) > 6 Then
            '-- por codigo de barra del producto
            v_resultado = sp_datosTabla.consulta_valor("select idProducto from producto where codigoBarra='" & v_codigoProducto & "'")
            '-- ver si el resultado no arroja nada
            If Len(v_resultado) = 0 Then
                '-- por codigo de barra interno
                If Len(v_codigoProducto) = 12 Then
                    '-- para 12 digitos
                    v_resultado = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoProducto.Substring(7, 5))
                End If
                If Len(v_codigoProducto) = 13 Then
                    '-- para 13 digitos
                    v_resultado = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoProducto.Substring(8, 5))
                End If
            Else
                v_resultado = Int(v_resultado)
            End If
        End If
        Return v_resultado
    End Function

    '-- funcion para saber si el producto corresponde a la remision ingresada
    Public Function productoEnRemision(ByVal v_idEnvio As Integer, ByVal v_idProducto As Integer)
        Dim v_resultado As Boolean
        '-- verificar el producto con el envio
        If (sp_datosTabla.consulta_valor("select de.idEnvio from cabEnvio ce inner join detEnvio de " & _
                                         " on ce.idEnvio=de.idEnvio inner join stock s on s.idStock=de.idStock " & _
                                         " where de.idEnvio=" & v_idEnvio & " and s.idProducto=" & v_idProducto)) > 0 Then
            v_resultado = True
        Else
            v_resultado = False
        End If


        Return v_resultado
    End Function

    '-- funcion para saber si el producto corresponde a la remision pendiente ingresada
    Public Function productoEnRemisionPendiente(ByVal v_idEnvioPendiente As Integer, ByVal v_idProducto As Integer)
        Dim v_resultado As Boolean
        '-- verificar el producto con el envio
        If (sp_datosTabla.consulta_valor("select de.idEnvioPendiente from cabEnvioPendiente ce inner join detEnvioPendiente de " & _
                                         " on ce.idEnvioPendiente=de.idEnvioPendiente inner join stock s on s.idStock=de.idStock " & _
                                         " where de.idEnvioPendiente=" & v_idEnvioPendiente & " and s.idProducto=" & v_idProducto)) > 0 Then
            v_resultado = True
        Else
            v_resultado = False
        End If


        Return v_resultado
    End Function

    Public Function DeImagen_a_Bytes(ByVal Imagen As Image) As Byte()

        'Crea un archivo temporal de cero bytes y nombre único en el disco y devuelve la ruta

        'de acceso completa a ese archivo.

        Dim ATemporal As String = IO.Path.GetTempFileName()

        'Inicializa una nueva instancia de la clase FileStream con el permiso de lectura/escritura,

        'el modo de creación y la ruta de acceso especificados.

        Dim filestream As New IO.FileStream(ATemporal, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)

        'Puede modificar el formato de la imagen a la hora de salvarla.

        Imagen.Save(filestream, System.Drawing.Imaging.ImageFormat.Bmp)

        filestream.Position = 0

        Dim imgLength As Integer = CInt(filestream.Length)

        Dim bytes(0 To imgLength - 1) As Byte

        filestream.Read(bytes, 0, imgLength)

        filestream.Close()

        Return bytes

    End Function

    Function ExtraerImagen(ByVal v_idProducto As Integer) As Byte()
        limpiarDataset()
        Dim conn As New SqlConnection(conexion)
        Dim SqlSelect As String = "Select imagen From producto Where idProducto = " & v_idProducto
        conn.Open()
        Dim Command As New SqlCommand(SqlSelect, conn)
        Dim MyPhoto() As Byte = CType(Command.ExecuteScalar(), Byte())
        conn.Close()
        Return MyPhoto
    End Function

    '-- sacar ' de una variable
    Public Function sacarComillaSimple(ByVal v_variable As String)
        '-- mostrar el entero
        Dim intTmpTotalLongitud As Integer
        Dim strTmpResultado As String = ""
        Dim strTmpValorLetra As String
        ' MsgBox("Total de longitud  " & intTmpLongitudVarbale)
        intTmpTotalLongitud = Len(v_variable)
        For i As Integer = 0 To intTmpTotalLongitud - 1
            'MsgBox("Valor de i  " & i)
            '-- sacar la letra de la variable
            strTmpValorLetra = v_variable.Substring(i, 1)
            '-- ver si no es comilla simple
            If strTmpValorLetra <> "'" Then
                strTmpResultado = strTmpResultado & strTmpValorLetra
            End If
        Next
        '-- armar el decimal
        Return strTmpResultado
    End Function

    '-- sacar . de una variable
    Public Function sacarComa(ByVal v_variable As String)
        'MsgBox("Valor del parametro ingresado  " & v_variable)
        '-- mostrar el entero
        Dim intTmpTotalLongitud As Integer
        Dim strTmpResultado As String = ""
        Dim strTmpValorLetra As String
        ' MsgBox("Total de longitud  " & intTmpLongitudVarbale)
        intTmpTotalLongitud = Len(v_variable)
        For i As Integer = 0 To intTmpTotalLongitud - 1
            'MsgBox("Valor de i  " & i)
            '-- sacar la letra de la variable
            strTmpValorLetra = v_variable.Substring(i, 1)
            '-- ver si no es comilla simple
            If strTmpValorLetra <> "," Then
                strTmpResultado = strTmpResultado & strTmpValorLetra
            End If
        Next
        'MsgBox("Valor  " & strTmpResultado)
        '-- armar el decimal
        Return strTmpResultado
    End Function

    '-- traer el idProducto a partir de un codigo
    Public Function traerIdProducto(ByVal v_codigo As String)
        Dim intResultado As Integer

        Dim strTmpCodigoBarra As String
        '---------------------------------------------------
        If Len(v_codigo) = 6 Then
            '-- por codigo del producto
            intResultado = CInt(sp_datosTabla.un_datoString("idProducto", "v_producto", "codigo", v_codigo))
        End If
        If Len(v_codigo) > 6 Then
            '-- por codigo de barras
            strTmpCodigoBarra = sp_datosTabla.un_datoString("codigoBarra", "v_producto", "codigoBarra", v_codigo)
            If Len(strTmpCodigoBarra) = 0 Then
                '-- por codigo de barras generado
                '-- solo si el primer digito el igual a 1
                If v_codigo.Substring(0, 1) = 1 Then
                    If Len(v_codigo) = 12 Then
                        '-- para los de 12 digitos
                        intResultado = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigo.Substring(6, 5))
                    End If
                    If Len(v_codigo) = 13 Then
                        '-- para los de 13 digitos
                        intResultado = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigo.Substring(7, 5))
                    End If
                End If
            Else
                'banGl_ajusteNegativoMercaderia = True
                ' MsgBox("Valor del codigo de barra  " & strTmpCodigoBarra)
                'MsgBox("Valor de la consulta  " & (sp_datosTabla.un_datoString("idProducto", "producto", "codigoBarra", strTmpCodigoBarra)))

                '-- se encontró el codigo de barras de la mercaderia
                intResultado = CInt(sp_datosTabla.un_datoString("idProducto", "producto", "codigoBarra", strTmpCodigoBarra))
            End If
        End If

        '-- el resultado
        Return intResultado
    End Function

    '-- funcion para generar el archivo txt para la contabilidad de las ventas 
    Public Sub crearArchivoTxt(ByVal v_consulta As String)
        Try
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = v_consulta
            If banGl_cancelarCanje = True Then
                'MsgBox("Valor de sql  " & sql)
            End If
            ' frmRemisionMercaderia.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            reader = cmd.ExecuteReader()
            'MsgBox("Valor de la sentencia  " & sql)
            Dim v_resultado As String = ""
            Dim intTmpContador As Integer = 0
            Using reader
                While reader.Read
                    intTmpContador = intTmpContador + 1
                    If intTmpContador = 1 Then
                        v_resultado = v_resultado & Trim(reader.GetValue(0)) & ";" & Trim(reader.GetValue(1)) & ";" & Trim(reader.GetValue(2)) & ";" & _
                        Trim(reader.GetValue(3)) & ";" & Trim(reader.GetValue(4)) & ";" & Trim(reader.GetValue(5)) & ";" & Trim(reader.GetValue(6)) & ";" & _
                        Trim(reader.GetValue(7)) & ";" & Trim(reader.GetValue(8)) & ";" & Trim(reader.GetValue(9)) & ";" & Trim(reader.GetValue(10)) & ";" & _
                        Trim(reader.GetValue(11)) & ";" & Trim(reader.GetValue(12)) & ";" & Trim(reader.GetValue(13)) & ";" & Trim(reader.GetValue(14)) & ";"
                        'reader.GetValue(15) & ";" & reader.GetValue(16) & ";" & reader.GetValue(17) & ";" & reader.GetValue(18) & ";" & _
                        'reader.GetValue(19) & ";" & reader.GetValue(20) & ";" & reader.GetValue(21) & ";" & reader.GetValue(22) & ";" & _
                        'reader.GetValue(23) & ";" & reader.GetValue(24) & ";" & reader.GetValue(25) & ";"

                    Else
                        v_resultado = v_resultado & Trim(reader.GetValue(0)) & ";" & Trim(reader.GetValue(1)) & ";" & Trim(reader.GetValue(2)) & ";" & _
                        Trim(reader.GetValue(3)) & ";" & Trim(reader.GetValue(4)) & ";" & Trim(reader.GetValue(5)) & ";" & Trim(reader.GetValue(6)) & ";" & _
                        Trim(reader.GetValue(7)) & ";" & Trim(reader.GetValue(8)) & ";" & Trim(reader.GetValue(9)) & ";" & Trim(reader.GetValue(10)) & ";" & _
                        Trim(reader.GetValue(11)) & ";" & Trim(reader.GetValue(12)) & ";" & Trim(reader.GetValue(13)) & ";" & Trim(reader.GetValue(14))
                        'reader.GetValue(15) & ";" & reader.GetValue(16) & ";" & reader.GetValue(17) & ";" & reader.GetValue(18) & ";" & _
                        'reader.GetValue(19) & ";" & reader.GetValue(20) & ";" & reader.GetValue(21) & ";" & reader.GetValue(22) & ";" & _
                        'reader.GetValue(23) & ";" & reader.GetValue(24) & ";" & reader.GetValue(25)
                    End If

                    'MsgBox("Valor del Resultado  " & v_resultado)
                End While
            End Using

            'Return v_resultado
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el archivo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Try
    End Sub
    '---------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS SUB --'
    '*************'
    'descargar datos desde base de datos
    Public Sub descargarDatos()
        'limpiamos todas las tablas del dataset
        limpiarDataset()
        'cargamos el dataset con las tablas

        'cargar la vista del usuario para obtener su id
        If cargarUsuario() = False Then
            MessageBox.Show("Intente cargar de Nuevo la Vista de los Usuarios", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            conn.Close()
        End If

    End Sub

    '-- blanquear las variables
    Public Sub blanquearVariables(ByVal v_tipo As Integer)
        If v_tipo = 1 Then
            '----------------------'
            '- VARIABLES DE VENTA -'
            '----------------------'
            '- variables enteras
            intGl_vtaIdCliente = 0
            intGl_vtaIdTipoVenta = 0
            intGl_vtaIdStock = 0
            intGl_vtaIdProducto = 0
            intGl_vtaTotalVenta = 0
            intGl_vtaTotalDescuento = 0

            '- variables caracteres
            strGl_vtaRucCliente = ""
            strGl_vtaCliente = ""
            intGl_nroVenta = 0
        End If
        If v_tipo = 2 Then
            '-----------------------'
            '- VARIABLES DE COMPRA -'
            '-----------------------'
            banGl_compra = 1

        End If
    End Sub

    '-- los aniversarios de los empleados
    Public Sub cumplePersonal()
        '  MsgBox("entro al cumple")
        systemClass.SqlToLv_cumplePersonal(frmMenuPrincipal.lvCumple, "sp_consultaPersonalAniversario")
    End Sub

    '-- cargar la grilla de la nota de credito
    Public Sub cargarNotaCredito(ByVal v_nro As Integer, ByVal v_codigo As Integer, ByVal v_producto As String, ByVal v_forma As String, ByVal v_costo As Double, ByVal v_lote As String, ByVal v_vence As String, ByVal v_porcentajeImpuesto As Double, ByVal v_cantidad As Double, ByVal v_boni As Double, ByVal v_idStock As Integer, ByVal v_precio As Double, ByVal v_cantfrac As Integer)
        frmNotaCreditoProveedor.dtgNotaCredito.Rows.Add()
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(0).Value = v_nro
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(1).Value = v_codigo
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(2).Value = v_producto
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(3).Value = v_forma
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(4).Value = v_costo
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(5).Value = v_lote
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(6).Value = v_vence
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(7).Value = v_porcentajeImpuesto
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(8).Value = v_cantidad
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(9).Value = v_boni
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(12).Value = v_idStock
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(13).Value = v_precio
        frmNotaCreditoProveedor.dtgNotaCredito.Rows(intGl_nroNotaCredito - 1).Cells(14).Value = v_cantfrac
    End Sub

    Public Sub cargarProductoReferenciado(ByVal v_nro As Integer, ByVal v_codigo As String, ByVal v_producto As String, ByVal v_cantidad As Double)
        frmReferenciarMercaderias.dtgReferencia.Rows.Add()
        frmReferenciarMercaderias.dtgReferencia.Rows(intGl_nroReferenciarMercaderia - 1).Cells(0).Value = v_nro
        frmReferenciarMercaderias.dtgReferencia.Rows(intGl_nroReferenciarMercaderia - 1).Cells(1).Value = v_codigo
        frmReferenciarMercaderias.dtgReferencia.Rows(intGl_nroReferenciarMercaderia - 1).Cells(2).Value = v_producto
        frmReferenciarMercaderias.dtgReferencia.Rows(intGl_nroReferenciarMercaderia - 1).Cells(3).Value = v_cantidad
    End Sub

    Public Sub cargarNotaDebito(ByVal v_nro As Integer, ByVal v_codigo As Integer, ByVal v_producto As String, ByVal v_forma As String, ByVal v_lote As String, ByVal v_vence As String, ByVal v_precio As Double, ByVal v_porcentajeImpuesto As Double, ByVal v_cantidad As Double)


    End Sub

    '-- cargar en el arqueo de caja montos en guaranies 
    Public Sub cargarArqueoGuaranies(ByVal v_nro As Integer, ByVal v_cantidad As Integer, ByVal v_x As String, ByVal v_monto As Double, ByVal v_total As Double)
        frmArqueoCaja.dtgGuaranies.Rows.Add()
        frmArqueoCaja.dtgGuaranies.Rows(intGl_nroArqueoGuaranies - 1).Cells(4).Value = v_nro
        frmArqueoCaja.dtgGuaranies.Rows(intGl_nroArqueoGuaranies - 1).Cells(0).Value = v_cantidad
        frmArqueoCaja.dtgGuaranies.Rows(intGl_nroArqueoGuaranies - 1).Cells(1).Value = v_x
        frmArqueoCaja.dtgGuaranies.Rows(intGl_nroArqueoGuaranies - 1).Cells(2).Value = v_monto
        frmArqueoCaja.dtgGuaranies.Rows(intGl_nroArqueoGuaranies - 1).Cells(3).Value = v_total
    End Sub

    '-- cargar en el arqueo de caja montos en monedas extrangeras
    Public Sub cargarArqueoMoneda(ByVal v_nro As Integer, ByVal v_moneda As String, ByVal v_monto As Double, ByVal v_total As Double, ByVal v_cotizacion As Double)
        frmArqueoCaja.dtgMoneda.Rows.Add()
        frmArqueoCaja.dtgMoneda.Rows(intGl_nroArqueoMoneda - 1).Cells(3).Value = v_nro
        frmArqueoCaja.dtgMoneda.Rows(intGl_nroArqueoMoneda - 1).Cells(1).Value = v_moneda
        frmArqueoCaja.dtgMoneda.Rows(intGl_nroArqueoMoneda - 1).Cells(0).Value = v_monto
        frmArqueoCaja.dtgMoneda.Rows(intGl_nroArqueoMoneda - 1).Cells(2).Value = v_total
        frmArqueoCaja.dtgMoneda.Rows(intGl_nroArqueoMoneda - 1).Cells(4).Value = v_cotizacion
    End Sub

    '-- cargar en el arqueo de caja los gastos 
    Public Sub cargarArqueoGasto(ByVal v_nro As Integer, ByVal v_factura As Integer, ByVal v_monto As Double, ByVal v_concepto As String)
        frmArqueoCaja.dtgGasto.Rows.Add()
        frmArqueoCaja.dtgGasto.Rows(intGl_nroArqueoGasto - 1).Cells(3).Value = v_nro
        frmArqueoCaja.dtgGasto.Rows(intGl_nroArqueoGasto - 1).Cells(0).Value = v_factura
        frmArqueoCaja.dtgGasto.Rows(intGl_nroArqueoGasto - 1).Cells(1).Value = v_monto
        frmArqueoCaja.dtgGasto.Rows(intGl_nroArqueoGasto - 1).Cells(2).Value = v_concepto
    End Sub

    '-- cargar en el arqueo de caja los creditos
    Public Sub cargarArqueoCredito(ByVal v_nro As Integer, ByVal v_factura As Integer, ByVal v_monto As Double)
        frmArqueoCaja.dtgCredito.Rows.Add()
        frmArqueoCaja.dtgCredito.Rows(intGl_nroArqueoCredito - 1).Cells(2).Value = v_nro
        frmArqueoCaja.dtgCredito.Rows(intGl_nroArqueoCredito - 1).Cells(0).Value = v_factura
        frmArqueoCaja.dtgCredito.Rows(intGl_nroArqueoCredito - 1).Cells(1).Value = v_monto
    End Sub

    '-- cargar en el arqueo de caja las compras web
    Public Sub cargarArqueoWeb(ByVal v_nro As Integer, ByVal v_nroAutoriza As Integer, ByVal v_monto As Double)
        frmArqueoCaja.dtgWeb.Rows.Add()
        frmArqueoCaja.dtgWeb.Rows(intGl_nroArqueoWeb - 1).Cells(2).Value = v_nro
        frmArqueoCaja.dtgWeb.Rows(intGl_nroArqueoWeb - 1).Cells(0).Value = v_nroAutoriza
        frmArqueoCaja.dtgWeb.Rows(intGl_nroArqueoWeb - 1).Cells(1).Value = v_monto
    End Sub

    '-- cargar en el arqueo de caja los cheques
    Public Sub cargarArqueoCheque(ByVal v_nro As Integer, ByVal v_nroCheque As Integer, ByVal v_monto As Double, ByVal v_fecha As String)
        frmArqueoCaja.dtgCheque.Rows.Add()
        frmArqueoCaja.dtgCheque.Rows(intGl_nroArqueoCheque - 1).Cells(3).Value = v_nro
        frmArqueoCaja.dtgCheque.Rows(intGl_nroArqueoCheque - 1).Cells(0).Value = v_nroCheque
        frmArqueoCaja.dtgCheque.Rows(intGl_nroArqueoCheque - 1).Cells(1).Value = v_monto
        frmArqueoCaja.dtgCheque.Rows(intGl_nroArqueoCheque - 1).Cells(2).Value = v_fecha
    End Sub

    '-- cargar en el arqueo de caja los tarjetas de creditos
    Public Sub cargarArqueoTarjetaCredito(ByVal v_nro As Integer, ByVal v_tarjeta As String, ByVal v_monto As Double)
        frmArqueoCaja.dtgTarjetaCredito.Rows.Add()
        frmArqueoCaja.dtgTarjetaCredito.Rows(intGl_nroArqueoTarjetaCredito - 1).Cells(2).Value = v_nro
        frmArqueoCaja.dtgTarjetaCredito.Rows(intGl_nroArqueoTarjetaCredito - 1).Cells(0).Value = v_tarjeta
        frmArqueoCaja.dtgTarjetaCredito.Rows(intGl_nroArqueoTarjetaCredito - 1).Cells(1).Value = v_monto
    End Sub

    '-- cargar en el arqueo de caja las tarjetas de debito
    Public Sub cargarArqueoTarjetaDebito(ByVal v_nro As Integer, ByVal v_tarjeta As String, ByVal v_monto As Double)
        frmArqueoCaja.dtgTarjetaDebito.Rows.Add()
        frmArqueoCaja.dtgTarjetaDebito.Rows(intGl_nroArqueoTarjetaDebito - 1).Cells(2).Value = v_nro
        frmArqueoCaja.dtgTarjetaDebito.Rows(intGl_nroArqueoTarjetaDebito - 1).Cells(0).Value = v_tarjeta
        frmArqueoCaja.dtgTarjetaDebito.Rows(intGl_nroArqueoTarjetaDebito - 1).Cells(1).Value = v_monto
    End Sub

    '-- cargar los ajustes positivos
    Public Sub cargarAjustePositivoMercaderia(ByVal v_nro As Integer, ByVal v_codigo As String, ByVal v_mercaderia As String, ByVal v_forma As String, ByVal v_lote As String, ByVal v_vence As String, ByVal v_precio As Double, ByVal v_stock As Double, ByVal v_cantidad As Double, ByVal v_idstock As Integer, ByVal v_cantfrac As Integer, ByVal v_motivo As String)
        frmAjustePositivoMercaderia.dtgAjuste.Rows.Add()
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(0).Value = v_nro
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(1).Value = v_codigo
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(2).Value = v_mercaderia
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(3).Value = v_forma
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(4).Value = v_lote
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(5).Value = v_vence
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(6).Value = v_motivo
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(7).Value = v_stock
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(8).Value = v_cantidad
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(9).Value = v_stock + (v_cantidad * v_cantfrac)
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(10).Value = v_idstock
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(11).Value = v_cantfrac
        frmAjustePositivoMercaderia.dtgAjuste.Rows(intGl_nroAjustePositivoMercaderia - 1).Cells(12).Value = v_precio
    End Sub

    '-- cargar los ajustes negativos
    Public Sub cargarAjusteNegativoMercaderia(ByVal v_nro As Integer, ByVal v_codigo As String, ByVal v_mercaderia As String, ByVal v_forma As String, ByVal v_lote As String, ByVal v_vence As String, ByVal v_precio As Double, ByVal v_stock As Double, ByVal v_cantidad As Double, ByVal v_idstock As Integer, ByVal v_cantfrac As Integer, ByVal v_motivo As String)
        frmAjusteNegativoMercaderia.dtgAjuste.Rows.Add()
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(0).Value = v_nro
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(1).Value = v_codigo
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(2).Value = v_mercaderia
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(3).Value = v_forma
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(4).Value = v_lote
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(5).Value = v_vence
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(6).Value = v_motivo
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(7).Value = v_stock
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(8).Value = v_cantidad
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(9).Value = v_stock - (v_cantidad * v_cantfrac)
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(10).Value = v_idstock
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(11).Value = v_cantfrac
        frmAjusteNegativoMercaderia.dtgAjuste.Rows(intGl_nroAjusteNegativoMercaderia - 1).Cells(12).Value = v_precio
    End Sub

    '-- cargar la tabla de cotizaciones
    Public Sub cargarTablaCotizacion(ByVal v_nro As Integer, ByVal v_idMoneda As Integer, ByVal v_moneda As String, ByVal v_compra As Double, ByVal v_venta As Double)
        frmTablaCotizacion.dtgCotiza.Rows.Add()
        frmTablaCotizacion.dtgCotiza.Rows(intGl_nroTablaCotizacion - 1).Cells(0).Value = v_nro
        frmTablaCotizacion.dtgCotiza.Rows(intGl_nroTablaCotizacion - 1).Cells(1).Value = v_idMoneda
        frmTablaCotizacion.dtgCotiza.Rows(intGl_nroTablaCotizacion - 1).Cells(2).Value = v_moneda
        frmTablaCotizacion.dtgCotiza.Rows(intGl_nroTablaCotizacion - 1).Cells(3).Value = v_compra
        frmTablaCotizacion.dtgCotiza.Rows(intGl_nroTablaCotizacion - 1).Cells(4).Value = v_venta
    End Sub

    Public Function hexadecimalString(ByVal Source As String) As String
        Dim b As Byte() = System.Text.Encoding.UTF8.GetBytes(Source)
        Return BitConverter.ToString(b).Replace("-", "")
    End Function

    Public Function BytesToHex(ByVal bytes As Byte()) As String
        Dim HEX_ARRAY As String = "0123456789abcdef"
        Dim hexChars As String = String.Empty
        For i As Integer = 0 To bytes.Length - 1
            Dim v As Byte = bytes(i) And &HFF
            hexChars &= HEX_ARRAY.Substring(v \ &H10, 1)
            hexChars &= HEX_ARRAY.Substring(v And &HF, 1)
        Next
        Return hexChars
    End Function

    '-- para leer un archivo txt 
    Public Function leerArchivoClaveBd()
        'tipoconexion.txt()
        Const fic As String = "c:\Multicolor\clBd.txt"
        Dim strResultado As String
        Dim sr As New System.IO.StreamReader(fic)
        strResultado = sr.ReadToEnd()
        sr.Close()
        Console.WriteLine(strResultado)

        ' MsgBox("Valor de lo leido   " & strResultado)

        Return strResultado
    End Function

    '-- cargar el stock inicial
    Public Sub cargarStockInicial(ByVal v_nro As Integer, ByVal v_idProducto As Integer, ByVal v_forma As String, ByVal v_precio As Double, ByVal v_costo As Double, ByVal v_lote As String, ByVal v_vence As String, ByVal v_cantidad As Double)
        '-- datos del producto
        Dim strTmpNombreProducto As String
        strTmpNombreProducto = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from v_producto where idProducto=" & v_idProducto)
        Dim strTmpCodigo As String
        strTmpCodigo = sp_datosTabla.consulta_valorString("select codigo from v_producto where idProducto=" & v_idProducto)
        '--------------------------------
        frmStockInicial.dtgStock.Rows.Add()
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(0).Value = v_nro
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(1).Value = strTmpCodigo
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(2).Value = strTmpNombreProducto
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(3).Value = v_forma
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(4).Value = v_lote
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(5).Value = v_vence
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(6).Value = v_precio
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(7).Value = v_costo
        frmStockInicial.dtgStock.Rows(intGl_nroStockInicial - 1).Cells(8).Value = v_cantidad

    End Sub

    '-- cargar los cheques para el proveedor
    Public Sub cargarChequeProveedor(ByVal v_nro As Integer, ByVal v_idProveedor As Integer, ByVal v_nombreProveedor As String, ByVal v_banco As String, ByVal v_cotiza As Double, ByVal v_moneda As String, ByVal v_cheque As Integer, ByVal v_fecha As String, ByVal v_monto As Double, ByVal v_total As Double, ByVal v_idChequera As Integer)
        frmCargarCheques.dtgCheque.Rows.Add()
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(0).Value = v_nro
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(1).Value = v_idProveedor
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(2).Value = v_nombreProveedor
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(3).Value = v_banco
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(4).Value = v_cotiza
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(5).Value = v_moneda
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(6).Value = v_cheque
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(7).Value = v_fecha
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(8).Value = v_monto
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(9).Value = v_total
        frmCargarCheques.dtgCheque.Rows(intGl_nroCargarCheque - 1).Cells(10).Value = v_idChequera
    End Sub

    '-- cargar los depositos bancarios
    Public Sub cargarDepositoBanco(ByVal v_nro As Integer, ByVal v_nroDeposito As String, ByVal v_importe As Double)
        frmCargarDepositoBanco.dtgDeposito.Rows.Add()
        frmCargarDepositoBanco.dtgDeposito.Rows(intGl_nroDepositoBanco - 1).Cells(0).Value = v_nro
        frmCargarDepositoBanco.dtgDeposito.Rows(intGl_nroDepositoBanco - 1).Cells(1).Value = v_nroDeposito
        frmCargarDepositoBanco.dtgDeposito.Rows(intGl_nroDepositoBanco - 1).Cells(2).Value = v_importe
    End Sub

    '-- cargar los nuevos precios de los productos enteros
    Public Sub cargarPrecioEntero(ByVal v_nro As Integer, ByVal v_codigo As String, ByVal v_mercaderia As String, ByVal v_porcentajeIVa As Double, ByVal v_precioAnterior As Double, ByVal v_precioActual As Double, ByVal v_idProducto As Integer)
        frmPrecioEntero.dtgPrecio.Rows.Add()
        frmPrecioEntero.dtgPrecio.Rows(intGl_nroPrecioEntero - 1).Cells(0).Value = v_nro
        frmPrecioEntero.dtgPrecio.Rows(intGl_nroPrecioEntero - 1).Cells(1).Value = v_codigo
        frmPrecioEntero.dtgPrecio.Rows(intGl_nroPrecioEntero - 1).Cells(2).Value = v_mercaderia
        frmPrecioEntero.dtgPrecio.Rows(intGl_nroPrecioEntero - 1).Cells(3).Value = v_porcentajeIVa
        frmPrecioEntero.dtgPrecio.Rows(intGl_nroPrecioEntero - 1).Cells(4).Value = v_precioAnterior
        frmPrecioEntero.dtgPrecio.Rows(intGl_nroPrecioEntero - 1).Cells(5).Value = v_precioActual
        frmPrecioEntero.dtgPrecio.Rows(intGl_nroPrecioEntero - 1).Cells(6).Value = v_idProducto
    End Sub

    '-- cargar los nuevos precios de los productos fraccionados
    Public Sub cargarPrecioFraccion(ByVal v_nro As Integer, ByVal v_codigo As String, ByVal v_mercaderia As String, ByVal v_porcentajeIVa As Double, ByVal v_forma As String, ByVal v_precioAnterior As Double, ByVal v_precioActual As Double, ByVal v_idProducto As Integer)
        frmPrecioFraccion.dtgPrecio.Rows.Add()
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(0).Value = v_nro
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(1).Value = v_codigo
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(2).Value = v_mercaderia
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(3).Value = v_porcentajeIVa
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(4).Value = v_forma
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(5).Value = v_precioAnterior
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(6).Value = v_precioActual
        frmPrecioFraccion.dtgPrecio.Rows(intGl_nroPrecioFraccion - 1).Cells(7).Value = v_idProducto
    End Sub

    '-- para leer un archivo txt del nombre del servidor para san andres
    Public Function leerArchivoNombreServidor()
        'tipoconexion.txt()
        Const fic As String = "c:\Multicolor\nserver.txt"
        Dim strResultado As String
        Dim sr As New System.IO.StreamReader(fic)
        strResultado = sr.ReadToEnd()
        sr.Close()
        Console.WriteLine(strResultado)

        'MsgBox("Valor de lo leido   " & strResultado)

        Return strResultado
    End Function

    '-- cargar la grilla de generacion de codigo de barra de mercaderia
    Public Sub cargarGenerarCodigoBarraMercaderia(ByVal v_nroGenera As Integer, ByVal v_idProducto As Integer, ByVal v_codigo As Integer, ByVal v_producto As String, ByVal v_deposito As String, ByVal v_lote As String, ByVal v_vence As String, ByVal v_cantidad As Double, ByVal v_idStock As Integer)
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows.Add()
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(0).Value = v_nroGenera
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(1).Value = v_idProducto
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(2).Value = v_codigo
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(3).Value = v_producto
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(4).Value = v_deposito
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(5).Value = v_lote
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(6).Value = v_vence
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(7).Value = v_cantidad
        frmGenerarCodigoBarraMercaderia.dtgCodigoBarra.Rows(intGl_nroGenerarCodigoBarraMercaderia - 1).Cells(8).Value = v_idStock
    End Sub
    '-- cargar los pagos al proveedor
    Public Sub cargarOrdenPagoProveedor(ByVal v_cuenta As String, ByVal v_banco As String, ByVal v_cheque As Integer, ByVal v_vence As String, ByVal v_importe As Double, ByVal v_efectivo As Boolean, ByVal v_idchequera As Integer, ByVal v_idCheque As Integer)
        '-- controlar que no esté cargado el mismo cheque
        For i As Integer = 0 To frmGuardarPagoProveedor.dtgPago.Rows.Count - 1
            If frmGuardarPagoProveedor.dtgPago.Rows(i).Cells(0).Value > 0 Then
                If frmGuardarPagoProveedor.dtgPago.Rows(i).Cells(3).Value = v_cheque Then
                    MessageBox.Show("Este Número de Cheque ya se encuentra cargado en la Grilla..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        Next
        '-- sumar la variable global del nro de proveedor
        intGl_nroPagoProveedor = intGl_nroPagoProveedor + 1
        '--------------------------------
        frmGuardarPagoProveedor.dtgPago.Rows.Add()
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(0).Value = intGl_nroPagoProveedor
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(1).Value = v_cuenta
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(2).Value = v_banco
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(3).Value = v_cheque
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(4).Value = v_vence
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(5).Value = v_importe
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(6).Value = sp_datosTabla.sp_string("sp_fechaNormalServer", "")
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(7).Value = v_efectivo
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(8).Value = v_idchequera
        frmGuardarPagoProveedor.dtgPago.Rows(intGl_nroPagoProveedor - 1).Cells(9).Value = v_idCheque
        '-- sumar lo cargado
        frmGuardarPagoProveedor.sumarTotalPagoProveedor()
    End Sub

    '-- cargar la grilla del gastos de proveedor
    Public Sub cargarGastoProveedor(ByVal v_nroGasto As Integer, ByVal v_concepto As String, ByVal v_porcentajeIva As Double, ByVal v_costo As Double, ByVal v_idImpuesto As Integer)
        frmGastoProveedor.dtgCompra.Rows.Add()
        frmGastoProveedor.dtgCompra.Rows(intGl_nroGastoProveedor - 1).Cells(0).Value = v_nroGasto
        frmGastoProveedor.dtgCompra.Rows(intGl_nroGastoProveedor - 1).Cells(1).Value = v_concepto
        frmGastoProveedor.dtgCompra.Rows(intGl_nroGastoProveedor - 1).Cells(2).Value = v_porcentajeIva
        frmGastoProveedor.dtgCompra.Rows(intGl_nroGastoProveedor - 1).Cells(3).Value = v_costo
        frmGastoProveedor.dtgCompra.Rows(intGl_nroGastoProveedor - 1).Cells(4).Value = v_idImpuesto
    End Sub

    '-- cargar las modificaciones de costos del stock
    Public Sub cargarModificacionCosto(ByVal v_nro As Integer, ByVal v_idStock As Integer, ByVal v_codigo As String, ByVal v_mercaderia As String, ByVal v_lote As String, ByVal v_vence As String, ByVal v_precio As Double, ByVal v_costo As Double)
        frmModificarCosto.dtgCosto.Rows.Add()
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(0).Value = v_nro
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(1).Value = v_idStock
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(2).Value = v_codigo
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(3).Value = v_mercaderia
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(4).Value = v_lote
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(5).Value = v_vence
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(6).Value = v_precio
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(7).Value = v_costo
        frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(8).Value = 0
    End Sub


    '-- procedimiento para cargar el detalle de la venta de farmacia
    Public Sub cargarDetVentaFarmacia(ByVal v_idCliente As Integer, ByVal v_idTipoVenta As Integer, ByVal v_tipoVenta As Integer, _
     ByVal v_idStock As Integer, ByVal v_idProducto As Integer, ByVal v_idForma As Integer _
      , ByVal v_cantidad As Double, ByVal v_cantFrac As Integer)

        If (fun_guardarSp("sp_agregarDetVentaTmpFarmacia", intGl_idUsuario & "," & intGl_idConfigPc & "," & _
            v_idCliente & "," & v_idTipoVenta & "," & v_idStock & "," & v_idProducto & "," & v_cantidad, "frmVenta")) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        '-- si existe un mensaje de error desplegar
        If sp_datosTabla.consulta_valorBoolean("select errorVenta from detVentaTmp where idConfig=" & intGl_idConfigPc & " and idProducto=" & v_idProducto & " and idStock=" & v_idStock & " and cantfrac=" & v_cantFrac) = True Then
            Dim strTmpMensaje As String
            strTmpMensaje = sp_datosTabla.consulta_valorString("select mensaje from detVentaTmp where idConfig=" & intGl_idConfigPc & " and idProducto=" & v_idProducto & " and idStock=" & v_idStock)
            MessageBox.Show(strTmpMensaje, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    '-- procedimiento para evitar que el informe pida el usuario y contraseña de la base de datos
    Public Sub evitarPassDatabase(ByVal v_reporte As Object)
        '-- para evitar que pida el usuario y la contraseña
        Dim crTable As CrystalDecisions.CrystalReports.Engine.Table
        Dim crTableLogonInfo As CrystalDecisions.Shared.TableLogOnInfo
        Dim cnConnInfo As New CrystalDecisions.Shared.ConnectionInfo()
        '----------------------------------
        ''-- establecer la base de datos

        With cnConnInfo

            Select Case intGl_tipoConexion
                Case Is = 1
                    '-- para la conexion en mi pc
                    .ServerName = strGlNombreServer
                    .DatabaseName = strGl_nombreBaseDatos
                    .IntegratedSecurity = False
                    .UserID = "sa"
                    .Password = strGlClaveServer
                Case Is = 2
                    '-- para la conexion LAN
                    .ServerName = "192.168.100.236"
                    .DatabaseName = strGl_nombreBaseDatos
                    .IntegratedSecurity = False
                    .UserID = "sa"
                    .Password = "Sqlmulticolor12345"
                Case Is = 3
                    '-- para la conexion en VPN
                    .ServerName = "26.95.122.182"
                    .DatabaseName = strGl_nombreBaseDatos
                    .IntegratedSecurity = False
                    .UserID = "sa"
                    .Password = "Sqlmulticolor12345"
                Case Is = 4
                    'MsgBox("conexion por internet")
                    '-- para la conxion en INTERNET
                    .ServerName = "190.104.132.116"
                    .DatabaseName = strGl_nombreBaseDatos
                    .IntegratedSecurity = False
                    .UserID = "sa"
                    .Password = "Sqlmulticolor12345"
            End Select

        End With
        For Each crTable In v_reporte.Database.Tables
            crTableLogonInfo = crTable.LogOnInfo
            crTableLogonInfo.ConnectionInfo = cnConnInfo
            crTable.ApplyLogOnInfo(crTableLogonInfo)
        Next
        '---------------------------------------
    End Sub

    '-- procedimiento para establecer los permisos en el menu principal
    Public Sub establecerMenuPrincipal(ByVal MSPrincipal As MenuStrip)
        Dim Menu As ToolStripMenuItem
        For Each Menu In MSPrincipal.Items
            RecorrerMenuItem(Menu)
        Next
    End Sub

    'Recorre el Menu
    Public Sub RecorrerMenuItem(ByVal MenuItem As ToolStripMenuItem)

        If MenuItem.IsOnDropDown = True Then
            ' MsgBox("Es verdadero el isOnDropDown")
            If ConsultarComportamiento(MenuItem.Name) = True Then
                MenuItem.Enabled = True
            Else
                MenuItem.Enabled = False
            End If

            For Each Item As ToolStripMenuItem In MenuItem.DropDownItems
                If Item.DropDownItems.Count > 0 Then
                    RecorrerMenuItem(Item)
                Else
                    If ConsultarComportamiento(Item.Name) = True Then
                        Item.Enabled = True
                    Else
                        Item.Enabled = False
                    End If
                End If
            Next
        Else
            ' MsgBox("Es falso el isOnDropDown")
            If ConsultarComportamiento(MenuItem.Name) = True Then
                MenuItem.Enabled = True
            Else
                MenuItem.Enabled = False
            End If

            For Each Item As ToolStripMenuItem In MenuItem.DropDownItems
                RecorrerMenuItem(Item)
            Next
        End If

    End Sub

    Public Sub parametrosIngreso()
        '-- el cumpleaños de los personales
        cumplePersonal()
        'descargarDatos()
        'procedimiento para insertar el usuario que ingreso al sistema
        sp_IngresoSistema.insIngresoSistema()
        'procedimiento que trae la fecha y hora del servidor
        sp_IngresoSistema.fechaHoraServer()
        '-- la variable del ip de la API QR
        strGl_direccionQR = sp_datosTabla.consulta_valorString("select ipServerQR from configEmpresa")
        'MsgBox("Valor de strGl_direccionQR  " & strGl_direccionQR)
        '-------------------------------
        ' rellanar los elementos del formulario del menu inicial
        frmMenuPrincipal.lblIdUsuario.Text = intGl_idUsuario
        frmMenuPrincipal.lblNombreUsuario.Text = strGl_nombreUsuario
        frmMenuPrincipal.lblGrupoUsuario.Text = strGl_nombreGrupoUsuario
        frmMenuPrincipal.lblSucursal.Text = strGl_nombreSucursal
        frmMenuPrincipal.lblNombreSucursal.Text = strGl_nombreSucursal
        frmMenuPrincipal.lblEntidad.Text = strGl_nombreEntidad

        'MsgBox("Valor de la ruta   " & strGl_rutaImagen)
        frmMenuPrincipal.picFotoUsuario.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoPersona", "v_usuario", "idusuario", intGl_idUsuario)
        frmMenuPrincipal.txtFechaHoraServer.Text = Trim(strGl_fechaHoraServer)
        frmMenuPrincipal.lblFechaServidor.Text = Trim(strGl_nombreDiaServer) & " " & Trim(strGl_diaAserver.ToString) & " de " & Trim(strGl_nombreMesServer) & " de " & Trim(strGl_anhoServer)
        frmMenuPrincipal.lblIdGrupoUsuario.Text = intGl_idGrupoUsuario
        '-- datos de la empresa contable
        frmMenuPrincipal.lblIdPersonaJur.Text = intGl_idPersonaJur
        frmMenuPrincipal.lblEmpresaContable.Text = strGl_empresaContable
        frmMenuPrincipal.lblBaseDatos.Text = strGl_nombreBaseDatos
        'frmMenuPrincipal.lblFechaHoraServer.Text = strGl_fechaHoraServer
        '--  valor a la variable publica de hoteleria 
        bolGl_hoteleria = sp_datosTabla.consulta_valorBoolean("select hoteleria from v_sucursal where idSucursal=" & intGl_idSucursal)
        '-- datosd de la pc
        frmMenuPrincipal.lblIdConfig.Text = intGl_idConfigPc
        frmMenuPrincipal.lblNombrePc.Text = sp_datosTabla.consulta_valorString("select nombrepc from configPc where idConfig=" & intGl_idConfigPc)
        '-----------------------------------------------------------------
        frmIngresoNick.Visible = False
        frmMenuPrincipal.Show()
        frmMenuPrincipal.BringToFront()
        frmMenuPrincipal.WindowState = FormWindowState.Normal
    End Sub

    Public Sub exportarDbf(ByVal v_idEnvio As Integer)
        Dim strComando As String
        Dim conexionDBF As New OleDbConnection( _
       "Provider=Microsoft.Jet.OLEDB.4.0;" & _
       "Data Source=C:\temp\tablas;" & _
        "Extended Properties='dBASE IV;'")
        '---------------------------------------------
        Try
            '************************'
            '-- CREACION DE TABLAS --'
            '************************'
            '-- lote
            strComando = "SELECT idlote,vencimiento as fecha,lote,activo,idusuarioAlta as ualta,fechaAlta as falta,idUsuarioMod as umod, " & _
            "fechaMod as fmod INTO [" & "lote" & Trim(Str(v_idEnvio)) & "] " & _
            "FROM [lote] " & _
            "IN ''[ODBC;DRIVER={SQL Server};" & _
            "Server=192.168.0.101;" & _
            "Database=maxifarmasa;" & _
            "UID=sa;" & _
            "PWD=Servidorsql12345]"
            Dim cmdLote As New OleDbCommand(strComando, conexionDBF)
            ' Abrimos la conexion
            conexionDBF.Open()
            ' Ejecutamos la consulta.
            cmdLote.ExecuteNonQuery()
            '-- cerramos la conexion
            conexionDBF.Close()
            'MsgBox("fin de lote")
            '-- producto
            strComando = "SELECT idproducto as idprod,codigo,idLaboratorio as idlab,idDivision as iddiv,idTipoProducto as idtipopr," & _
            "idImpuesto,idLinea,idFamilia," & _
            "codigoBarra as codbar,nombreProducto as nombre,presentacion as presen,origen,controlado as control,fraccionado as fracion," & _
            "auditado as audi,maximo,fueraLinea as flinea," & _
            "refrigerado as refrigera,heladeria as ventashelado,nroInformativo as nroinfo,fechaInformativo as ufprecio,precio," & _
            "ultimoPrecio as ultprecio,ultimoCosto as ultcosto,stockInicial as stock,fotoProducto as imagen," & _
            "activo,idUsuarioAlta as ualta,fechaAlta as falta,idUsuarioMod as umod,fechaMod as fmod" & _
            " INTO [" & "prod" & Trim(Str(v_idEnvio)) & "] " & _
            "FROM [producto] " & _
            "IN ''[ODBC;DRIVER={SQL Server};" & _
            "Server=192.168.0.101;" & _
            "Database=maxifarmasa;" & _
            "UID=sa;" & _
            "PWD=Servidorsql12345]"
            Dim cmdProducto As New OleDbCommand(strComando, conexionDBF)
            ' Abrimos la conexion
            conexionDBF.Open()
            ' Ejecutamos la consulta.
            cmdProducto.ExecuteNonQuery()
            '-- cerramos la conexion
            conexionDBF.Close()
            'MsgBox("Fin de Producto")
            '---------------------------------------------


            MessageBox.Show("Ya se enviaron todos los archivos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As OleDbException
            MessageBox.Show(ex.Errors(0).Message)
            strGl_mensajeError = "Error: " & ex.Message & "exportarDbf"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            strGl_mensajeError = "Error: " & ex.Message & "exportarDbf"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '-- funcion para crear un archivo dbf
    Private Function CreateDbf(ByVal dt As DataTable, _
                           ByVal tableName As String, _
                           ByVal cnn As OleDbConnection) As Integer

        ' Verifico los valores pasados.
        '
        'MsgBox("Entro a la funcion de creacion de tablas")
        If (dt Is Nothing) Then _
            Throw New ArgumentNullException("dt", _
                "El objeto no es válido")

        If (String.IsNullOrEmpty(tableName)) Then _
            Throw New ArgumentNullException("tableName", _
                "No se ha especificado el nombre de la tabla.")

        If (cnn Is Nothing) Then _
            Throw New ArgumentNullException("cnn", _
                "El objeto Connection no es válido.")

        Dim sql As New System.Text.StringBuilder(256)

        Try
            sql.Append("CREATE TABLE " & tableName & "(")

            'MsgBox("Entro al procedimiento para crear la tabla")
            'MsgBox("Valor de la columna  " & dt.Columns.ToString)
            For Each dc As DataColumn In dt.Columns
                ' obtenemos el tipo de dato de la columna
                'MsgBox("Valor del tipo de campo  " & dc.ToString)
                sql.Append(GetDataTypeSql(dc))
            Next

            ' Reemplazo la última coma por el cierre de paréntesis
            '
            sql.Replace(","c, ")"c, sql.Length - 1, 1)
            Using cnn

                Dim cmd As OleDbCommand = cnn.CreateCommand()
                cmd.CommandText = sql.ToString()

                cnn.Open()

                cmd.ExecuteNonQuery()

                cmd.CommandText = _
                    String.Format("SELECT * FROM [{0}]", tableName)

                Dim da As New OleDbDataAdapter(cmd)

                Dim cb As New OleDbCommandBuilder(da)

                cb.QuotePrefix = "["
                cb.QuoteSuffix = "]"

                da.InsertCommand = cb.GetInsertCommand()

                Return da.Update(dt)

            End Using

        Catch ex As Exception
            Throw
            strGl_mensajeError = "Error: " & ex.Message & "CreateDbf"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        Finally
            sql = Nothing

        End Try

    End Function

    '-- eliminar el archivo txt de la farctura para imprimir el ticket
    Public Sub eliminarArchivoFacturaTicket()
        Try
            Dim archivo As String = "c:\Multicolor\txtTicket.txt"

            'My.Computer.FileSystem.DeleteFile(archivo, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
            My.Computer.FileSystem.DeleteFile(archivo)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "eliminarArchivoFacturaTicket"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- funcion para obtener el tipo
    Private Function GetDataTypeSql(ByVal dc As DataColumn) As String

        Dim columnName As String = dc.ColumnName
        Dim dataType As String
        Dim maxLength As Int32

        'MsgBox("Valor del tipo de columno  " & dc.DataType.Name.ToString)
        Select Case dc.DataType.Name
            Case "Boolean"
                dataType = "bit"

            Case "Byte", "SByte"
                dataType = "tinyint"

            Case "Char"
                dataType = "nchar"
                maxLength = dc.MaxLength

            Case "DateTime"
                dataType = "datetime"

            Case "Decimal"
                dataType = "decimal (18, 2)"

            Case "Double"
                dataType = "real"

            Case "Int16", "UInt16"
                dataType = "smallint"

            Case "Int32", "UInt32"
                dataType = "int"

            Case "Int64", "UInt64"
                dataType = "bigint"

            Case "Object", "Byte[]"
                dataType = "image"

            Case "Single"
                dataType = "float"

            Case Else   ' String
                If (dc.MaxLength = 536870910) Then
                    dataType = "memo"

                Else
                    dataType = "nvarchar"
                    maxLength = dc.MaxLength

                End If

        End Select

        If (maxLength > 0) Then
            Return String.Format("[{0}] {1} ({2}),", columnName, dataType, maxLength)

        Else
            Return String.Format("[{0}] {1},", columnName, dataType)

        End If

    End Function

    '-- funcion para pasar parametros para una tabla dbf
    Public Sub dbf()
        Try
            Dim Adapter As New SqlDataAdapter("select * from cargo", conexion)
            Dim table As New DataTable
            Adapter.Fill(table)
            ' Configuramos un objeto Connection para conectarnos
            ' con el archivo de dBASE, el cual se creará en la
            ' carpeta C:\Mis documentos
            '
            Dim cnn As New OleDbConnection( _
                "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                "Data Source=C:\temp;" & _
                "Extended Properties='vfp8;'")
            '"Extended Properties='dBASE IV;'")

            Dim n As Integer = CreateDbf(table, _
                                        "prueba", _
                                         cnn)

            MessageBox.Show("Nº de registros añadidos:" & CStr(n))

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            strGl_mensajeError = "Error: " & ex.Message & "dbf"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '-- para escribir en un archivo txt para guardar el ultimo nick ingresado
    Public Sub escribirNick(ByVal v_nick As String)
        '-- primero limpiar y luego escribir
        Const fic As String = "c:\Multicolor\nick.txt"
        'Dim sw1 As New System.IO.StreamWriter(fic, True)
        'sw1.Write("")
        'sw1.Close()

        '-- escribirlo de vuelta
        Dim texto As String = v_nick
        Dim sw2 As New System.IO.StreamWriter(fic, True)
        sw2.WriteLine(texto)
        sw2.Close()

    End Sub

    '-- eliminar el archivo de nick
    Public Sub eliminarArchivoNick()
        Try
            Dim archivo As String = "c:\Multicolor\nick.txt"

            'My.Computer.FileSystem.DeleteFile(archivo, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
            My.Computer.FileSystem.DeleteFile(archivo)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "eliminarArchivoNick"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- eliminar el archivo de datos de la pc en el servidor
    Public Sub eliminarArchivoDatos(ByVal v_nombreArchivo As String)
        Try
            If File.Exists(v_nombreArchivo) Then
                Dim archivo As String = v_nombreArchivo
                My.Computer.FileSystem.DeleteFile(archivo)
            Else
                MessageBox.Show("No encontro el archivo", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "eliminarArchivoDatos"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- eliminar el archivo de reporte pdf
    Public Sub eliminarArchivoReportePdf(ByVal v_nombreArchivo As String)
        Try
            If File.Exists(v_nombreArchivo) Then
                Dim archivo As String = v_nombreArchivo
                My.Computer.FileSystem.DeleteFile(archivo)
            Else
                MessageBox.Show("No encontro el archivo", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "eliminarArchivoDatos"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- para escribir en un archivo txt de los datos de la pc actual 
    Public Sub escribirDatosPc(ByVal v_nombrePc As String, ByVal v_idPc As String, ByVal v_serialHd As String, ByVal v_direccion As String)
        '-- primero limpiar y luego escribir
        Dim fic As String = v_direccion
        '-- escribirlo de vuelta
        Dim texto As String = v_nombrePc & ";" & v_idPc & ";" & v_serialHd
        'MsgBox("El Texto  " & texto)
        Dim sw2 As New System.IO.StreamWriter(fic, True)
        sw2.WriteLine(texto)
        sw2.Close()

    End Sub

    '-- para escribir en un archivo txt datos de la factura para imprmir
    Public Sub escribirFacturaTicket(ByVal v_texto As String, ByVal v_direccion As String)
        '-- primero limpiar y luego escribir
        Dim fic As String = v_direccion
        '-- escribirlo de vuelta
        Dim texto As String = v_texto
        'MsgBox("El Texto  " & texto)
        Dim sw2 As New System.IO.StreamWriter(fic, True)
        sw2.WriteLine(texto)
        sw2.Close()

    End Sub

    '-- controlar si el producto ingresado está en el pedido del proveedor
    Public Sub productoPedidoAProveedor(ByVal v_idProdufcto As Integer, ByVal v_idProveedor As Integer)
        '---------------------------------------------------
        If sp_datosTabla.sp_traerValor("sp_productoPedidoProveedor", v_idProdufcto & "," & v_idProveedor, 0) <> "" Then
            '-- datos del pedido en las compras
            frmCompras.txtPedidopor.Text = sp_datosTabla.sp_traerValor("sp_productoPedidoProveedor", v_idProdufcto & "," & v_idProveedor, 3)
            frmCompras.txtNroPedido.Text = sp_datosTabla.sp_traerValor("sp_productoPedidoProveedor", v_idProdufcto & "," & v_idProveedor, 0)
            frmCompras.txtCantidadPedido.Text = sp_datosTabla.sp_traerValor("sp_productoPedidoProveedor", v_idProdufcto & "," & v_idProveedor, 2)
            frmCompras.txtCantidadPedido.Text = Format(CDec(frmCompras.txtCantidadPedido.Text), "#,###.##")
            frmCompras.txtFechaPedido.Text = sp_datosTabla.sp_traerValor("sp_productoPedidoProveedor", v_idProdufcto & "," & v_idProveedor, 4)
            frmCompras.PictureBox2.Visible = True
            frmCompras.lblControlPedido.Visible = True
        Else
            MessageBox.Show("Esta mercaderia no corresponde al Pedido del Proveedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmCompras.txtPedidopor.Text = ""
            frmCompras.txtNroPedido.Text = 0
            frmCompras.txtCantidadPedido.Text = 0
            frmCompras.txtFechaPedido.Text = ""
            frmCompras.PictureBox2.Visible = False
            frmCompras.lblControlPedido.Visible = False
        End If

    End Sub



    '-- para enviar un correo electronico
    Public Sub enviarCorreo(ByVal StrDe As String, ByVal StrPara As String, ByVal StrAsunto As String, ByVal StrMensaje As String, ByVal strArchivo As Attachment, ByVal v_idVenta As Integer)
        Try
            Dim strNroFactura As String
            Dim strVendedor As String
            Dim strFecha As String
            Dim strMonto As String


            '-- completar los datos de la factura
            strNroFactura = sp_datosTabla.consulta_valorString("select rtrim(cv.dsuc)+'-'+RTRIM(cv.dcaja)+'-'+[dbo].[funRellenarIzquierda](cv.factura,'0',7-LEN(ltrim(cv.factura))) from cabVenta cv where idVenta=" & v_idVenta)
            strVendedor = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from cabVenta cv inner join v_vendedor _vv on cv.idVendedor=_vv.idVendedor where cv.idVenta=" & v_idVenta)
            strFecha = sp_datosTabla.consulta_valorString("select convert(varchar,fechaAlta,103) from cabVenta where idVenta=" & v_idVenta)
            strMonto = sp_datosTabla.consulta_valorString("select [dbo].[funPuntoLetraMoneda](totalVenta) from cabVenta where idVenta=" & v_idVenta)


            Dim pieDePagina As String = "Este mensaje se generó de manera automática por el Sistema NetJoin - by CONESFER +595981134876 Encarnación - Py"
            Dim cuerpo As String = "<html>" &
                                "<body>" &
                                "<p>Estos datos estan dentro de su Factura Electrónica.</p>" &
                                "<hr>" &
                                "<p> Este mensaje se generó de manera automática por el Sistema de Gestión <b> NetJoin </b> <style> p {color:blue} </style> <p> by CONESFER  +595 981134876</p> </p>" &
                                "<div> <ul> " &
                                " <li> Nro de Factura: " & strNroFactura &
                                " <li> Vendedor: " & strVendedor &
                                " <li> Fecha de la Factura: " & strFecha &
                                " <li> Monto: " & strMonto &
                                "</ul> </div> " &
                                "</body>" &
                                "</html>"

            '--objeto tipo mensaje con parametros De: Para:
            Dim Msg As New MailMessage(New MailAddress(StrDe), New MailAddress(StrPara))
            '--asunto
            Msg.Subject = StrAsunto
            Msg.IsBodyHtml = True
            '--mensaje
            'Msg.Body = StrMensaje
            Msg.Body = cuerpo
            '--datos adjuntos
            Msg.Attachments.Add(strArchivo)

            'DATOS SMTP
            'Objeto SMTP
            Dim SMPT As New SmtpClient

            'Credenciales
            'SMPT.Credentials = New System.Net.NetworkCredential("multicolorpinturasenviofactura@hotmail.com", "Multi2468")
            'SMPT.Credentials = New System.Net.NetworkCredential("multicolorPinmturasSifen@gmail.com", "kadd dhzu kkyu lzpv")
            SMPT.Credentials = New System.Net.NetworkCredential("enviofactura@multicolorpinturas.com.py", "Master2025@$@")
            'SMPT.Host = "smtp-mail.outlook.com"
            'SMPT.Host = "smtp.gmail.com"
            SMPT.Host = "smtp.hostinger.com"

            'SMPT.Port = 465
            SMPT.Port = 587
            '--para hotmail SMPT.Port = 587
            SMPT.EnableSsl = True
            'SMPT.Timeout = 800

            ' Permite que el sistema elija entre TLS 1.2, 1.1 o 1.0 según disponibilidad
            Try
                System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType) Or
                                                                  DirectCast(768, System.Net.SecurityProtocolType) Or
                                                                  DirectCast(192, System.Net.SecurityProtocolType)
            Catch ex As Exception
                ' Si el Windows es muy viejo y no soporta la asignación, intentamos al menos TLS 1.0
                System.Net.ServicePointManager.SecurityProtocol = DirectCast(192, System.Net.SecurityProtocolType)
            End Try

            'Enviar
            SMPT.Send(Msg)

            'Me.Cursor = Cursors.Default

        Catch ex As Exception
            'Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "enviarCorreo"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- generar archivo txt
    Public Sub generarArchivoTxt(ByVal v_direccion As String, ByVal v_consulta As String)
        '-- primero limpiar y luego escribir
        Dim fic As String = v_direccion
        '-- escribirlo de vuelta
        Dim texto As String = v_consulta
        'MsgBox("El Texto  " & texto)
        Dim sw2 As New System.IO.StreamWriter(fic, True)
        sw2.WriteLine(texto)
        sw2.Close()

    End Sub

    '-- para guardar un template
    Public Sub guardarTemplate(ByVal v_id As Integer, ByVal v_template As System.IO.FileStream)
        ' MsgBox("Entro al proceso de guardar el template")
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
            cmd.CommandText = "sp_insPruebaTemplate"

            'Establecemos los parametros
            'Entrada
            'cmd.Parameters.AddWithValue("@id", 1)
            'cmd.Parameters.Add("@template", SqlDbType.VarBinary, 200, "template")
            'v_template = v_template.Serialize(v_template)
            cmd.Parameters.AddWithValue("@template", v_template)
            'MsgBox("Todavia no entro al execute")
            rowCount = cmd.ExecuteNonQuery()
            'MsgBox("Valor de rowCount  " & rowCount.ToString)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & "formulario".ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "guardarTemplate"
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        Finally
            If previousConnectionState = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        '-----------------------------------------------------------------------
    End Sub

    '-- mensaje de error y guardar en la base de datos
    Public Sub errorSistema(ByVal v_mensaje As String, ByVal v_nombreFormulario As String, ByVal v_idConfig As Integer, ByVal v_idUsuario As Integer, ByVal v_idsucursal As Integer)
        Try
            cargarError.insertarError(v_mensaje, v_nombreFormulario)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & "ERROR AL GUARDAR ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            MessageBox.Show("Error: " & "ERROR EN EL PROCEDIMIENTO", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    '-- para enviar un correo electronico 
    Public Sub enviarCorreo2(ByVal StrDe As String, ByVal v_consultaValor As String, ByVal v_tipo As Integer)
        Try
            Dim v_resultado As String = ""
            '-------------------------------------------------------'
            '--- ARMAR EL RESULTADO DE LA CONSULTA PARA EL MENSAJE--'
            '-------------------------------------------------------'
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = v_consultaValor
            'frmAjusteNegativoMercaderia.txtSql.Text = v_consultaValor
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
                Using reader
                    Dim intTmpConta As Integer
                    While reader.Read
                        intTmpConta = intTmpConta + 1
                        '-- cargar solo la primera vez la sucursal y el responsable
                        If intTmpConta = 1 Then
                            v_resultado = "Suc:" & sp_datosTabla.consulta_valorString("Select nombreFantasia from v_sucursal where idSucursal=" & _
                            intGl_idSucursal) & " Responsable:" & sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+" & _
                            "LTrim(apellido) from v_usuario where idUsuario=" & intGl_idUsuario) & "Detalle:" & reader.GetValue(0).ToString
                        Else
                            v_resultado = v_resultado + reader.GetValue(0).ToString
                        End If

                        'MsgBox("Valor del resltado  " & v_resultado)
                    End While
                End Using

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message & " " & "Colocar Mensaje", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & "colocar Mensaje"
                errorSistema(strGl_mensajeError, "Colocar Mensaje", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try
            '**************************************************************************************************************
            '----------------------------------------------------'
            '-- RECORRER LA TABLA DE LA CONSULTA DE LOS EMAILS --'
            '----------------------------------------------------'
            '-- las variables
            Dim message As New MailMessage
            Dim smtp As New SmtpClient
            Dim strTmpTituloCorreo As String = ""
            '---------------------------------
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn2 As New SqlConnection(conexion)
            Dim sql2 As String = "exec sp_enviarEmail " & Str(v_tipo)
            Dim cmd2 As New SqlCommand(sql2, conn2)
            Dim reader2 As SqlDataReader
            Dim previousConnectionState2 As ConnectionState
            previousConnectionState2 = conn2.State

            Try
                If conn2.State = ConnectionState.Closed Then
                    conn2.Open()
                End If
                reader2 = cmd2.ExecuteReader()
                Using reader2
                    While reader2.Read
                        '-- cargar los correos
                        message.To.Add(reader2.GetValue(0).ToString)
                        strTmpTituloCorreo = reader2.GetValue(1).ToString
                    End While
                End Using
                message.From = New MailAddress(StrDe)

                message.Body = v_resultado
                message.Subject = strGl_nombreSistema & "-" & strTmpTituloCorreo
                message.Priority = MailPriority.Normal
                smtp.EnableSsl = True
                smtp.Port = "587"
                smtp.Host = "smtp.gmail.com"
                smtp.Credentials = New Net.NetworkCredential("ninofer80@gmail.com", "ninino80")
                smtp.Send(message)
                '*******************************************************************
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message & " " & "enviarCorreo2", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & "enviarCorreo2"
                errorSistema(strGl_mensajeError, "enviarCorreo2", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState2 = ConnectionState.Closed Then
                    conn2.Close()
                End If

            End Try

        Catch ex As Exception
            'Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & "enviarCorreo"
            errorSistema(strGl_mensajeError, "enviarCorreo2 consultado SP", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Public Function ConvertirCertificadoACadena(ByVal certificado As X509Certificate2) As String
        Dim cadenaBuilder As New StringBuilder()

        ' Exportar el certificado en formato PEM
        Dim certificadoBytes As Byte() = certificado.Export(X509ContentType.Cert)
        Dim certificadoBase64 As String = Convert.ToBase64String(certificadoBytes)
        'cadenaBuilder.AppendLine("-----BEGIN CERTIFICATE-----")
        cadenaBuilder.AppendLine(certificadoBase64)
        'cadenaBuilder.AppendLine("-----END CERTIFICATE-----")

        Return cadenaBuilder.ToString()
    End Function

    Public Function DesencriptarArchivoPFX(ByVal rutaArchivo As String, ByVal contraseña As String) As X509Certificate2
        Dim certificado As New X509Certificate2(rutaArchivo, contraseña, X509KeyStorageFlags.Exportable)
        Return certificado
    End Function

    Public Sub escribirArchivo(ByVal v_texto As String, ByVal v_direccion As String)
        '-- primero limpiar y luego escribir
        Dim fic As String = v_direccion
        '-- escribirlo de vuelta
        Dim texto As String = v_texto
        'MsgBox("El Texto  " & texto)
        Dim sw2 As New System.IO.StreamWriter(fic, True)
        sw2.WriteLine(texto)
        sw2.Close()

    End Sub

    '-- generar archivo pdf
    Public Sub generarArchivoPdf(ByVal v_idMov As Integer, ByVal v_correo As String)
        Try
            Dim intIdVenta As Integer
            Dim report As New rpt_ticketFarmacia

            intIdVenta = v_idMov

            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            Dim CrExportOptions As ExportOptions

            Dim pvParametros As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idVenta As New ParameterDiscreteValue()

            Dim Ruta As String = "c:\Pdf\" + CStr(v_idMov) + ".pdf"
            'Dim Ruta2 As String = "c:\xml\rcv\" + CStr(v_idMov) + ".xml"
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            'MsgBox("Ruta  " & Ruta)
            'MsgBox("idVenta  " & intIdVenta)

            CrDiskFileDestinationOptions.DiskFileName = Ruta
            CrExportOptions = report.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            'asiganar el valor a los  parametros
            v_idVenta.Value = intIdVenta
            ' añadir el parámetro a la colección de parámetros
            pvParametros.Add(v_idVenta)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            report.DataDefinition.ParameterFields("@idVenta").ApplyCurrentValues(pvParametros)

            evitarPassDatabase(report)

            report.Export()

            Dim archivo As Net.Mail.Attachment = New Net.Mail.Attachment(Ruta)

            ' enviarCorreo("multicolorpinturasenviofactura@hotmail.com", v_correo, "Factura Electrónica Multicolor Pinturas", "Factura Electrónica emitida al cliente", archivo)
            enviarCorreo("enviofactura@multicolorpinturas.com.py", v_correo, "Factura Electrónica Multicolor Pinturas", "Factura Electrónica emitida al cliente", archivo, v_idMov)

            report.Close()
            CrExportOptions = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Module



