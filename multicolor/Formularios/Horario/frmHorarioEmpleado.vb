Public Class frmHorarioEmpleado
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_IngresoSistema As New sp_IngresoSistema

    Dim strFechaHoraServer As String
    Dim bolTmpTarjeta As Boolean
    Dim intIdUsuario As Integer
    Dim bolDatosUsuarios As Boolean = False
    Dim strExisteUsuario As String

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub mostrarHorario()
        'MsgBox("Paso por aca")
        '-- el parametro de la hora del servidor
        strFechaHoraServer = sp_datosTabla.sp_sinParametroString("sp_fechaHoraServer")
        '-- el nombre de la fecha del servidor
        'lblFecha.Text = sp_datosTabla.sp_sinParametroString("sp_nombreFechaServer")
        lblFecha.Text = Trim(strGl_nombreDiaServer) & " " & Trim(strGl_diaAserver.ToString) & " de " & Trim(strGl_nombreMesServer) & " de " & Trim(strGl_anhoServer)
        'MsgBox("valor de fecha  " & sp_datosTabla.sp_sinParametroString("sp_nombreFechaServer"))
        '-- al hora del servidor
        txtHora.Text = sp_datosTabla.sp_sinParametroString("sp_horaServer")
    End Sub

    Private Sub controlarAcceso()
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
            ' comprobar si los datos de la pc están registrados

            If bolTmpTarjeta = False Then
                '***********************'
                '-- NICK Y CONTRASEÑA --'
                '***********************'
                strExisteUsuario = sp_datosTabla.sp_traerValor("sp_claveUsuarioNick", "'" & txtUsuario.Text & "'" & "," & "'" & txtPass.Text & "'" & "," & 0, 0)
                If Len(strExisteUsuario) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("Clave Ingresada no es Válida...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '-- el id del Usuario
                    intIdUsuario = CInt(sp_datosTabla.sp_traerValor("sp_claveUsuarioNick", "'" & txtUsuario.Text & "'" & "," & "'" & txtPass.Text & "'" & "," & 0, 3))
                    'MsgBox("Valor de idusuario  " & intIdUsuario)
                    '------------------------------------'
                    '-------- DATOS CORRECTOS -----------'
                    '------------------------------------'
                    guardarHorario()
                End If
            Else
                '*******************************'
                '-- TARJETA DE IDENTIFICACION --'
                '*******************************'
                'MsgBox("Valor " & sp_datosTabla.sp_traerValorInteger("sp_tarjetaUsuario", "'" & txtPass.Text & "'" & "," & 0, 3))

                intIdUsuario = sp_datosTabla.sp_traerValorInteger("sp_tarjetaUsuario", "'" & txtPass.Text & "'" & "," & 0, 3)

                Dim strTmpClave As String
                strTmpClave = sp_datosTabla.sp_traerValor("sp_tarjetaUsuario", "'" & txtPass.Text & "'" & "," & 0, 0)
                'MsgBox("Valor de la consulta  " & strTmpClave)
                If strTmpClave = "" Then
                    '-- no se guardo los registros
                    MessageBox.Show("Clave Ingresada no es Válida...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '------------------------------------'
                    '-------- DATOS CORRECTOS -----------'
                    '------------------------------------'
                    guardarHorario()
                End If
            End If
        Else
            MessageBox.Show("Debe Ingresar alguna clave..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub mostrarDatosUsuario()
        '--- los datos del usuario
        txtPersnal.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", intIdUsuario)
        '-- el idPersonal
        Dim intTmpIdPersonal As Integer
        intTmpIdPersonal = sp_datosTabla.un_dato_integer("idPersonal", "v_usuario", "idUsuario", intIdUsuario)
        txtCargo.Text = sp_datosTabla.un_datoString("nombreCargo", "v_personal", "idPersonal", intTmpIdPersonal)
        '-- la hora marcada
        txtHoraMarcada.Text = sp_datosTabla.sp_sinParametroString("sp_horaServer")
    End Sub

    Private Sub inicializarObjetos()
        '-- los txt
        txtCargo.Text = ""
        txtHoraMarcada.Text = ""
        txtPass.Text = ""
        txtPersnal.Text = ""
        txtUsuario.Text = ""
        txtUsuario.BackColor = Color.White
        txtPass.BackColor = Color.White
        txtUsuario.Enabled = True
        txtPass.Enabled = True
        '-- el formulario
        Me.Enabled = True
    End Sub

    Private Sub guardarHorario()
        '-- saber si es un horario de entrada o de salida
        If rdEntrada.Checked = True Then
            '-- ENTRADA
            'MsgBox("Valor de idUsuario  " & intIdUsuario)
            If (fun_guardarSp("sp_insHorarioEntrada", intIdUsuario & "," & intGl_idConfigPc & "," & intGl_idSucursal, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                '-- se guardo los registros
                Timer2.Enabled = True
                txtUsuario.BackColor = Color.LightSkyBlue
                txtPass.BackColor = Color.LightSkyBlue
                txtUsuario.Enabled = False
                txtPass.Enabled = False
                mostrarDatosUsuario()
            End If
        End If
        If rdSalida.Checked = True Then
            '-- SALIDA
            If (fun_guardarSp("sp_insHorarioSalida", intIdUsuario & "," & intGl_idConfigPc & "," & intGl_idSucursal, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                '-- se guardo los registros
                Timer2.Enabled = True
                txtUsuario.BackColor = Color.LightSkyBlue
                txtPass.BackColor = Color.LightSkyBlue
                txtUsuario.Enabled = False
                txtPass.Enabled = False
                mostrarDatosUsuario()
            End If
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    '-- para cuando comience a cargar el formulario
    Private Sub frmHorarioEmpleado_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        mostrarHorario()
    End Sub

    Private Sub frmHorarioEmpleado_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
    End Sub
    '------------------------------------------------------------------------------------------------------
    '***********'
    '-- TIMER --'
    '***********'
    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        mostrarHorario()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As System.EventArgs) Handles Timer2.Tick
        'MsgBox("Entro al timer..!")
        'mostrarDatosUsuario()
        bolDatosUsuarios = False
        Timer2.Enabled = False
        inicializarObjetos()
        txtUsuario.Focus()
        Refresh()
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtPass_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'e.Handled = True
            'SendKeys.Send("{tab}")
            controlarAcceso()
        End If
    End Sub

    'Private Sub txtPass_Validated(sender As Object, e As System.EventArgs) Handles txtPass.Validated
    '   controlarAcceso()
    ' End Sub

    '-------------------------------------------------------------------------------------------------------


End Class