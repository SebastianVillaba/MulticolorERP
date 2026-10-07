Imports System
Imports System.Net
Public Class frmIngresoNick
    Dim sp_IngresoSistema As New sp_IngresoSistema
    Dim info As New info
    Dim sp_datosTabla As New sp_datosTabla

    Dim bolTmpTarjeta As Boolean

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- procedimiento para controlar el ingreso en el sistema
    Private Sub ingresarSistema()
        '-- colocar el tipo de conexion en las variables
        If rdMiPc.Checked = True Then
            '-- mipc
            intGl_tipoConexion = 1
            '-- guardar la ruta de la imagen
            strGl_rutaImagen = "c:\Multicolor\Imagenes\"
        End If
        If rdLan.Checked = True Then
            '-- lan
            intGl_tipoConexion = 2
            '-- guardar la ruta de la imagen
            strGl_rutaImagen = "c:\Multicolor\Imagenes\"
        End If
        If rdVpn.Checked = True Then
            '-- vpn
            intGl_tipoConexion = 3
            '-- guardar la ruta de la imagen
            strGl_rutaImagen = "\\192.168.0.101\prueba\imagen\"
        End If
        If rdInternet.Checked = True Then
            '-- internet
            intGl_tipoConexion = 4
            '-- guardar la ruta de la imagen
            strGl_rutaImagen = "\\5.52.250.122\Imagenes\"
        End If

        '-- el nombre de la base de datos por defecto
        nombreBaseDatos()
        '------------------------------------------
        hayarConexion()
        '*************************************'
        '-- SOLO SI SE INGRESA ALGUNA CLAVE --'
        '*************************************'
        If Len(txtPass.Text) > 0 Then
            'descargarDatos()
            'MsgBox("Cantidad de caracteres ingresados en la contraseña   " & Len(txtPass.Text))
            '-- controlar primero si se ingreso el codigo de barras
            If Len(txtPass.Text) >= 12 Then
                '-- ingreso con la tarjeta
                bolTmpTarjeta = True
            Else
                bolTmpTarjeta = False
                'controlar que ingrese el usuario
                If txtUsuario.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar el Usuario..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtUsuario.Focus()
                    Exit Sub
                End If
            End If
            'controlar que ingrese alguna contraseña
            If txtPass.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe Ingresar la Contraseña..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtPass.Focus()
                Exit Sub
            End If
            'MsgBox("va a entrar a los procedimientos", MsgBoxStyle.Exclamation)
            'controlamos la valides del acceso
            Dim sp_IngresoSistema As New sp_IngresoSistema
            ' comprobar si los datos de la pc están registrados
            limpiarDataset()
            If sp_IngresoSistema.DatosIngreso = True Then
                'MsgBox("ingreso al proceso del Sistema!")
                'limpiarDataset()
                If bolTmpTarjeta = False Then
                    '***********************'
                    '-- NICK Y CONTRASEÑA --'
                    '***********************'
                    'MsgBox("Valor idUsuario  " & sp_datosTabla.consulta_valorString("select nombre from v_usuario where idUsuario=1"))
                    'If sp_datosTabla.sp_traerValor("sp_claveUsuarioNick", "'" & txtUsuario.Text & "'" & "," & "'" & txtPass.Text & "'" & "," & 0, 3) > 0 Then

                    'End If
                    If sp_IngresoSistema.acceso(txtUsuario.Text.Trim, txtPass.Text.Trim) = True Then
                        'MsgBox("Entro en el ingreso al Sistema!")
                        '-- controlar si está habilitado para ingresar con el nick
                        If (sp_datosTabla.un_dato_boleano("soloCodigoBarra", "v_usuario", "idUsuario", intGl_idUsuario)) = True Then
                            MessageBox.Show("Usted está habilitado solo para utilizar la tarjeta de Usuario..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        ' controlar si la entidad está activa
                        If sp_IngresoSistema.entidadActivo(txtUsuario.Text.Trim, txtPass.Text.Trim) = True Then
                            '-- eliminar el archivo de nick
                            eliminarArchivoNick()
                            '--- escribir en un archivo txt el nick de ingreso
                            escribirNick(sp_datosTabla.un_datoString("nick", "usuario", "idUsuario", intGl_idUsuario))
                            '****************************************************'
                            '-- CONTROLAR SI ES UNA TABLET PARA EL RESTAURANTE --'
                            '****************************************************'
                            '-- datos de la empresa contable
                            intGl_idPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configPc", "idConfig", intGl_idConfigPc)
                            strGl_empresaContable = sp_datosTabla.un_datoString("nombreFantasia", "v_empresaContable", "idPersonaJur", intGl_idPersonaJur)
                            If sp_datosTabla.consulta_valor("select idConfig from configPc where resto=1 and idConfig=" & intGl_idConfigPc) > 0 Then
                                sp_IngresoSistema.insIngresoSistema()
                                'procedimiento que trae la fecha y hora del servidor
                                sp_IngresoSistema.fechaHoraServer()

                                Me.Visible = False
                                'frmPedidoTablet.Show()
                                'frmPedidoTablet.BringToFront()
                                'frmPedidoTablet.WindowState = FormWindowState.Normal
                            Else
                                '***********************************************************'
                                '-- CONTROLAR SI ESTÁ HABILITADO PARA LA EMPRESA CONTABLE --'
                                '***********************************************************'
                                If (sp_datosTabla.un_dato_boleano("habilitarEmpresaContable", "usuario", "idUsuario", intGl_idUsuario)) = True Then
                                    ' MsgBox("Entro al formulario de empresa contable!")
                                    '-- formulario para elegir la empresa contable
                                    Me.Visible = False
                                    frmBuscarEmpresaContable.BringToFront()
                                    frmBuscarEmpresaContable.WindowState = FormWindowState.Normal
                                    frmBuscarEmpresaContable.Show()
                                Else
                                    '**************************************'
                                    '-- CONTROLAR SI ES UN DESARROLLADOR --'
                                    '**************************************'
                                    If sp_datosTabla.consulta_valorBoolean("select desarrollador from usuario where idusuario=" & intGl_idUsuario) Then
                                        Me.Visible = False
                                        frmBuscarBD.BringToFront()
                                        frmBuscarBD.WindowState = FormWindowState.Normal
                                        frmBuscarBD.Show()
                                    Else
                                        '-------------------------------------'
                                        '-------- ENTRO AL SISTEMA -----------'
                                        '-------------------------------------'
                                        '-- datos de la empresa contable
                                        intGl_idPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configPc", "idConfig", intGl_idConfigPc)
                                        strGl_empresaContable = sp_datosTabla.un_datoString("nombreFantasia", "v_empresaContable", "idPersonaJur", intGl_idPersonaJur)
                                        parametrosIngreso()
                                    End If
                                End If
                            End If
                        Else
                            MessageBox.Show("La Empresa cuenta con el Sistema Caducado..! Favor comuniquese con su Proveedor del Software", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else

                        MessageBox.Show("Usted no pertenece a ningún Usuario Registrado en el Sistema", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        txtPass.Text = ""
                        txtPass.Focus()
                        'MsgBox("Error")
                    End If
                Else
                    '*******************************'
                    '-- TARJETA DE IDENTIFICACION --'
                    '*******************************'
                    If sp_IngresoSistema.accesoTarjeta(txtPass.Text.Trim) = True Then
                        'MsgBox("Entro al procedimiento del acceso de tarjeta")
                        ' controlar si la entidad está activa
                        If sp_IngresoSistema.entidadTarjetaActivo(txtPass.Text.Trim) = True Then
                            'MsgBox("Entro en la entidad")
                            '-- eliminar el archivo de nick
                            eliminarArchivoNick()
                            '--- escribir en un archivo txt el nick de ingreso
                            escribirNick(sp_datosTabla.un_datoString("nick", "usuario", "idUsuario", intGl_idUsuario))
                            '***********************************************************'
                            '-- CONTROLAR SI ESTÁ HABILITADO PARA LA EMPRESA CONTABLE --'
                            '***********************************************************'
                            'MsgBox("Va a entrar al proceso de empresa contable")
                            If (sp_datosTabla.un_dato_boleano("habilitarEmpresaContable", "usuario", "idUsuario", intGl_idUsuario)) = True Then
                                '-- formulario para elegir la empresa contable
                                Me.Visible = False
                                frmBuscarEmpresaContable.BringToFront()
                                frmBuscarEmpresaContable.WindowState = FormWindowState.Normal
                                frmBuscarEmpresaContable.Show()
                            Else
                                '**************************************'
                                '-- CONTROLAR SI ES UN DESARROLLADOR --'
                                '**************************************'
                                If sp_datosTabla.consulta_valorBoolean("select desarrollador from usuario where idusuario=" & intGl_idUsuario) Then
                                    Me.Visible = False
                                    frmBuscarBD.BringToFront()
                                    frmBuscarBD.WindowState = FormWindowState.Normal
                                    frmBuscarBD.Show()
                                Else
                                    '-------------------------------------'
                                    '-------- ENTRO AL SISTEMA -----------'
                                    '-------------------------------------'
                                    '-- datos de la empresa contable
                                    intGl_idPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configPc", "idConfig", intGl_idConfigPc)
                                    strGl_empresaContable = sp_datosTabla.un_datoString("nombreFantasia", "v_empresaContable", "idPersonaJur", intGl_idPersonaJur)
                                    '--------------------------------
                                    parametrosIngreso()
                                End If
                            End If
                        Else
                            MessageBox.Show("La Empresa cuenta con el Sistema Caducado..! Favor comuniquese con su Proveedor del Software", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Usted no pertenece a ningún Usuario Registrado en el Sistema", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        txtPass.Text = ""
                        txtPass.Focus()
                    End If
                End If
                Else
                    MessageBox.Show("Este puesto no se encuentra habilitado para operar el Sistema..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
    End Sub

    '-- procedimiento para traer el nombde de la base de datos por defecto
    Private Sub nombreBaseDatos()
        strGl_nombreBaseDatos = Trim("multicolor")
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIngresar.Click
        '----------------------------------------------------------
        ingresarSistema()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    '------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    ' funcion que trae la idEntidad del Usuario Conectado
    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(txtPass.Text) > 0 Then
                'MsgBox("Paso por aca")
                e.Handled = True
                ingresarSistema()
                'SendKeys.Send("{tab}")
            End If
        End If
    End Sub

    Private Sub txtPass_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If Len(txtPass.Text) > 0 Then
            ingresarSistema()
        End If

    End Sub

    '-------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- EL FORM --'
    '*************'
    Private Sub frmIngresoNick_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- los parametros locales de la pc actual
        lblHost.Text = info.obtenerNombreHost
        lblIp.Text = info.ObtenerIdPc
        lblSerialHd.Text = info.obtenerSerialDisco1

        strGl_nombreConexion = leerArchivoEntradaConexion()

        '-- colocar el ultimo nick ingresado del archivo txt
        txtUsuario.Text = Trim(leerArchivoNick())
        '-- colocar el cheked de acuerdo a la configuracion del archivo
        rdInternet.Checked = False
        rdVpn.Checked = False
        rdLan.Checked = False
        ' MsgBox("Valor de la variable  " & strGl_nombreConexion)
        Select Case strGl_nombreConexion
            Case Is = "MIPC"
                '-- mi pc
                rdMiPc.Checked = True
                strGlNombreServer = leerArchivoNombreServidor()
                strGlClaveServer = leerArchivoClaveBd()

                If existeArchivoDatosPC("c:\Multicolor\" & lblHost.Text & ".txt") = False Then


                    '-- eliminar el archivo de datos de la pc que se encuentra en el servidor
                    eliminarArchivoDatos("c:\Multicolor\" & lblHost.Text & ".txt")
                    '-- escribir el nombre del archivo de los datos de la pc en el archivo dentro del servidor
                    escribirDatosPc(lblHost.Text, lblIp.Text, lblSerialHd.Text, "c:\Multicolor\" & lblHost.Text & ".txt")
                    'MsgBox("Paso por aca")
                End If
            Case Is = "LAN"
                '     MsgBox("Entro en LAN")
                '-- localmente
                rdLan.Checked = True
                If existeArchivoDatosPC("c:\Multicolor\" & lblHost.Text & ".txt") = False Then
                    '-- eliminar el archivo de datos de la pc que se encuentra en el servidor
                    eliminarArchivoDatos("c:\Multicolor\" & lblHost.Text & ".txt")
                    '-- escribir el nombre del archivo de los datos de la pc en el archivo dentro del servidor
                    escribirDatosPc(lblHost.Text, lblIp.Text, lblSerialHd.Text, "c:\Multicolor\" & lblHost.Text & ".txt")
                End If
            Case Is = "VPN"
                '-- LAN
                rdVpn.Checked = True
                If existeArchivoDatosPC("\\192.168.0.101\prueba\" & lblHost.Text & ".txt") = False Then
                    '-- eliminar el archivo de datos de la pc que se encuentra en el servidor
                    eliminarArchivoDatos("\\192.168.0.101\prueba\" & lblHost.Text & ".txt")
                    '-- escribir el nombre del archivo de los datos de la pc en el archivo dentro del servidor
                    escribirDatosPc(lblHost.Text, lblIp.Text, lblSerialHd.Text, "\\192.168.0.101\prueba\" & lblHost.Text & ".txt")
                End If
            Case Is = "INTERNET"
                '-- INTERNET    
                rdInternet.Checked = True
                If existeArchivoDatosPC("c:\Multicolor\" & lblHost.Text & ".txt") = False Then
                    '-- eliminar el archivo de datos de la pc que se encuentra en el servidor
                    eliminarArchivoDatos("c:\Multicolor\" & lblHost.Text & ".txt")
                    '-- escribir el nombre del archivo de los datos de la pc en el archivo dentro del servidor
                    escribirDatosPc(lblHost.Text, lblIp.Text, lblSerialHd.Text, "c:\Multicolor\" & lblHost.Text & ".txt")
                    '-- enviar por internet 
                    ' enviarCorreo("ninofer80@gmail.com", "ninofer80@yahoo.com", "Multicolor - Datos de la PC ", lblHost.Text & ";" & lblIp.Text & ";" & lblSerialHd.Text)
                End If

        End Select
        txtPass.Focus()
        Me.Refresh()
    End Sub

    '--- para no salir con Alt+f4
    Private Sub frmIngresoNick_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    Private Sub frmIngresoNick_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        txtPass.Focus()
    End Sub
    '-------------------------------------------------------------------------------------------
End Class
