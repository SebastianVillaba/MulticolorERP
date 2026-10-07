Public Class frmCliente_Venta
    '******************************'
    '-- VARIABLES DE TIPO OBJETO --'
    '******************************'
    Private sp_persona As New sp_persona
    Private sp_cliente As New sp_cliente
    Private sp_personaFisica As New sp_PersonaFisica
    Dim ban_nuevo As Boolean = False
    Dim intTmpIdPersona As Integer
    Private sp_datosTabla As New sp_datosTabla
    Private grupoCliente As New grupoCliente
    Dim pais As New pais
    Dim departamento As New departamento
    Dim distrito As New distrito
    Dim ciudad As New ciudad
    Dim tipoDocu As New tipoDocu

    Dim banError As Boolean = False

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        pais.listarPaisCombo(cboPais)
        departamento.comboDepartamento(cboDepartamento)
        distrito.comboDistrito(cboDistrito)
        ciudad.comboCiudad(cboCiudad)
        tipoDocu.comboTipoDocu(cboTipoDocu)
        '-- por defecto a cedula paraguaya
        cboTipoDocu.SelectedValue = 1
        'inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub incializar()
        'listar("")
        'valorde del combo
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub volverVenta()
        If banGl_ventaFarmacia1 = True Then
            banGl_ventaFarmacia1 = False
            '-- para le venta de farmacia
            intGl_vtaIdCliente = sp_datosTabla.consulta_valor("select idCliente from v_cliente where soloruc=" & "'" & txtCedula.Text & "'")
            intTmpIdPersona = sp_datosTabla.consulta_valor("select idPersona from v_cliente where soloruc=" & "'" & txtCedula.Text & "'")
            frmVentaFarmacia1.txtCliente.Text = Trim(txtNombre.Text) & "," & Trim(txtApellido.Text)
            frmVentaFarmacia1.txtIdCliente.Text = intGl_vtaIdCliente
            frmVentaFarmacia1.txtGrupoCliente.Text = cboGrupoCliente.Text
            frmVentaFarmacia1.txtTelefonoCliente.Text = sp_datosTabla.consulta_valorString("select [dbo].[funTraerTelefono](" & intTmpIdPersona & " )")
            frmVentaFarmacia1.txtRucCliente.Text = Trim(txtCedula.Text) & "-" & txtDv.Text
            frmVentaFarmacia1.txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from v_cliente where soloruc='" & txtCedula.Text & "'")

            '-- actualizar el detalle de la venta temporal
            If (fun_guardarSp("sp_updDetVentaFarmaciaTmpDelivery", intGl_idEntidad & "," & intGl_idConfigPc & "," & intGl_vtaIdCliente & "," & CInt(frmVentaFarmacia1.lblIdTipoVenta.Text) & "," & CInt(frmVentaFarmacia1.txtIdTipoventa.Text), Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            '--------------------------------------------
            frmVentaFarmacia1.sumarTotales()
            '-- saldo del funcionario
            'frmVentaFarmacia1.saldoFuncionario(intGl_vtaIdCliente)

            Me.Close()
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
            frmVentaFarmacia1.txtBuscar.Focus()
        End If
    End Sub

    Private Sub controlarError()
        '-- veriricar si está con ruc en la tabal de RUCSET
        'If Len(Trim(txtDv.Text)) > 0 Then
        '    If sp_datosTabla.consulta_valor("select documento from rucSet where documento='" & txtCedula.Text & "'") = 0 Then
        '        MessageBox.Show("El dígito verificador ingresado no existe en la SET con este nro de RUC", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        banError = True
        '    End If
        '    '-- verificar si el dv coincide con el ruc de la SET
        '    If sp_datosTabla.consulta_valor("select documento from rucSet where documento='" & txtCedula.Text & "' and dv='" & txtDv.Text & "'") = 0 Then
        '        MessageBox.Show("El RUC ingresado no existe en la SET", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        banError = True
        '    End If
        'End If

        If Len(Trim(txtEmail.Text)) > 0 Then
            '-- si se agrega el email

            Try
                'Creamos nuestro objeto, el constructor recive la cadena como parametro
                Dim mail As New System.Net.Mail.MailAddress(txtEmail.Text)
                'Al crear nuestro objeto evalua la cadena, y si es correcta no se produce
                'ningun error
                'MessageBox.Show("Correo valido")
            Catch ex As Exception
                MessageBox.Show("El correo igresado no es válido", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                banError = True
            End Try
        End If

    End Sub
    '---------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        If banGl_ventaFarmacia1 = True Then
            banGl_ventaFarmacia1 = False
            '-- venta de farmacia
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim strFechaAni As String
        If Not IsNumeric(maskFechaAni.Text.Substring(0, 1)) Then
            strFechaAni = ""
        Else
            strFechaAni = maskFechaAni.Text
        End If

        banError = False
        controlarError()
        If banError = False Then
            '-- controlar si es nuevo el cliente
            If ban_nuevo = True Then
                ' MsgBox("Entro a nuevo")
                '-------------------'
                '-- NUEVO CLIENTE --'
                '-------------------'
                If (fun_guardarSp("sp_insPersonaCedula_DE_nuevo", intGl_idEntidad & "," & cboPais.SelectedValue & "," & "'" & txtNombre.Text & "'" & "," & "'" & _
                                  txtApellido.Text & "'" & "," & "'" & txtCedula.Text & "'" & "," & "'" & txtDv.Text & "'" & "," & "'" & _
                                  txtDireccion.Text & "'" & "," & "'" & maskFechaAni.Text & "'" & "," & "'" & txtCelular1.Text & "'" & "," & "'" & _
                                  txtTelefono1.Text & "'" & "," & "'" & Trim(txtEmail.Text) & "'" & "," & txtNroCasa.Text & "," & _
                                  cboDepartamento.SelectedValue & "," & cboDistrito.SelectedValue & "," & cboCiudad.SelectedValue & "," & intGl_idUsuario & "," & _
                                  cboGrupoCliente.SelectedValue & "," & cboTipoDocu.SelectedValue, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    volverVenta()
                End If
            Else
                'MsgBox("Entro a modificar")
                '-----------------------'
                '-- MODIFICAR CLIENTE --'
                '-----------------------'
                If (fun_guardarSp("sp_updPersonaCedula_DE_nuevo", intTmpIdPersona & "," & "'" & txtDv.Text & "'" & "," & cboPais.SelectedValue & "," & "'" & txtNombre.Text & "'" & "," & "'" & txtApellido.Text & "'" & "," & _
                                  "'" & txtDireccion.Text & "'" & "," & "'" & maskFechaAni.Text & "'" & "," & "'" & txtCelular1.Text & "'" & "," & "'" & txtTelefono1.Text & "'" & "," & "'" & _
                                  Trim(txtEmail.Text) & "'," & intGl_idUsuario & "," & 1 & "," & cboGrupoCliente.SelectedValue & "," & txtNroCasa.Text & _
                                  "," & cboDepartamento.SelectedValue & "," & cboDistrito.SelectedValue & "," & cboCiudad.SelectedValue & _
                                  "," & cboTipoDocu.SelectedValue, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    volverVenta()
                End If
            End If
        End If


    End Sub

    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtCedula_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCedula.KeyPress
        Try
            e.Handled = txtNumerico(txtCedula, e.KeyChar, True)
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- si está en blanco buscar de la lista de clientes
                If Len(txtCedula.Text) = 0 Then
                    If bolGl_vtaHeladeriaPromoSamsung = False Then
                        '-- lista de clientes existentes
                        If banGl_facturacionResto = False Then
                            If banGl_entregaEvento = True Then
                                Me.Visible = False
                            Else
                                If banGl_checkOut = True Then
                                    Me.Visible = False
                                Else
                                    If banGl_facturarEvento = True Then
                                        Me.Visible = False
                                    Else
                                        Me.Close()
                                    End If
                                End If
                            End If
                        Else
                            Me.Visible = False
                        End If

                        'banGl_ventaFarmacia1 = True
                        frmBuscarClienteVenta.txtIdCliente.Text = ""
                        frmBuscarClienteVenta.Show()
                        frmBuscarClienteVenta.BringToFront()
                    End If
                Else
                    '-- el procedimiento de busqueda 
                    'txtDv.Text = getDV(txtCedula.Text)
                    'MsgBox("Valor de getDV  " & getDV(txtCedula.Text))
                    '-- controlar si existe o no la cedula ingregsada
                    If (sp_datosTabla.consulta_valor("select idCliente from v_cliente where soloruc=" & "'" & txtCedula.Text & "'")) = 0 Then
                        If (sp_datosTabla.obtenerCedula("select cedula from clienteCedula where cedula=" & txtCedula.Text)) > 0 Then
                            '-- si existe en la tabla de cedula
                            'MsgBox("Paso 1")
                            If sp_datosTabla.sp_traerValor("sp_consultaRucSet", "'" & txtCedula.Text & "'", 1) = 1 Then
                                txtDv.Text = getDV(txtCedula.Text)
                            Else
                                txtDv.Text = ""
                            End If
                            txtNombre.Text = sp_datosTabla.consulta_valorString("select nombre from clienteCedula where cedula=" & txtCedula.Text)
                            txtApellido.Text = sp_datosTabla.consulta_valorString("select apellido from clienteCedula where cedula=" & txtCedula.Text)
                            txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from clienteCedula where cedula=" & txtCedula.Text)
                            maskFechaAni.Text = sp_datosTabla.consulta_valorString("select fechaani from clienteCedula where cedula=" & txtCedula.Text)
                            '-- nro de casa
                            txtNroCasa.Text = 0
                            '-- por defecto colocar la direccion en Encarnacion
                            cboDepartamento.SelectedValue = 8
                            cboDistrito.SelectedValue = 87
                            cboCiudad.SelectedValue = 2226
                            cboTipoDocu.SelectedValue = 1
                            '-- habilitar objetos
                            txtNombre.Enabled = True
                            txtNombre.BackColor = Color.White
                            txtApellido.Enabled = True
                            txtApellido.BackColor = Color.White
                            txtDireccion.Enabled = True
                            txtDireccion.BackColor = Color.White
                            maskFechaAni.Enabled = True
                            maskFechaAni.BackColor = Color.White
                            btnGuardar.Enabled = True
                            '----------------------------------------------------
                            btnGuardar.Enabled = True
                            grupoCliente.grupoClienteCombo(cboGrupoCliente)
                            cboGrupoCliente.SelectedValue = 1

                            txtDv.Focus()
                            ban_nuevo = True
                            'MsgBox("1")
                        Else
                            'MsgBox("Paso 2")
                            ban_nuevo = True
                            '-- dar el valor al dv
                            If sp_datosTabla.sp_traerValor("sp_consultaRucSet", "'" & txtCedula.Text & "'", 1) = 1 Then
                                txtDv.Text = getDV(txtCedula.Text)
                            Else
                                txtDv.Text = ""
                            End If
                            '-- si no existe nadie
                            txtNombre.Enabled = True
                            txtNombre.BackColor = Color.White
                            txtApellido.Enabled = True
                            txtApellido.BackColor = Color.White
                            txtDireccion.Enabled = True
                            txtDireccion.BackColor = Color.White
                            maskFechaAni.Enabled = True
                            maskFechaAni.BackColor = Color.White
                            btnGuardar.Enabled = True
                            '-- nro de casa
                            txtNroCasa.Text = 0
                            '-- por defecto colocar la direccion en Encarnacion
                            cboDepartamento.SelectedValue = 8
                            cboDistrito.SelectedValue = 87
                            cboCiudad.SelectedValue = 2226
                            cboTipoDocu.SelectedValue = 1
                            '-- rellenar con los datos
                            txtNombre.Text = sp_datosTabla.sp_traerValor("sp_consultaRucSet", "'" & txtCedula.Text & "'", 2)
                            txtApellido.Text = sp_datosTabla.sp_traerValor("sp_consultaRucSet", "'" & txtCedula.Text & "'", 3)

                            grupoCliente.grupoClienteCombo(cboGrupoCliente)
                            cboGrupoCliente.SelectedValue = 1
                            'MsgBox("2")
                        End If
                    Else
                        'MsgBox("Paso 3")
                        '-- si ya existe
                        If sp_datosTabla.consulta_valorString("select soloRuc from v_cliente where soloRuc='" & Trim(txtCedula.Text) & "'") <> "" Then
                            'MsgBox("Paso 1")
                            ban_nuevo = False

                            txtNombre.Text = sp_datosTabla.un_datoString("nombre", "persona", "ruc", txtCedula.Text)
                            txtDv.Text = sp_datosTabla.un_datoString("dv", "persona", "ruc", txtCedula.Text)
                            '-- la variable de la personal
                            'Dim intTmpIdPersona As Integer = 0
                            intTmpIdPersona = Int(sp_datosTabla.un_datoString("idPersona", "persona", "ruc", txtCedula.Text))
                            'MsgBox("Paso 2")
                            txtApellido.Text = sp_datosTabla.sp_string("sp_obtenerApellidoPersona", intTmpIdPersona)
                            'txtDv.Text = sp_datosTabla.un_datoString("dv", "persona", "ruc", txtCedula.Text)
                            txtDireccion.Text = sp_datosTabla.un_datoString("direccion", "persona", "ruc", txtCedula.Text)
                            maskFechaAni.Text = sp_datosTabla.un_datoString("fechaani", "persona", "ruc", txtCedula.Text)
                            grupoCliente.ListarGrupoCliente(cboGrupoCliente)
                            'MsgBox("Paso aca")
                            'MsgBox("Valor  " & sp_datosTabla.un_dato_integer("idGrupoCliente", "cliente", "idPersona", sp_datosTabla.un_datoString("idPersona", "persona", "ruc", (txtCedula.Text))))
                            cboGrupoCliente.SelectedValue = sp_datosTabla.un_dato_integer("idGrupoCliente", "cliente", "idPersona", sp_datosTabla.un_datoString("idPersona", "persona", "ruc", (txtCedula.Text)))

                            txtCelular1.Text = sp_datosTabla.consulta_valorString("select celular1 from persona where idPersona=" & intTmpIdPersona)
                            txtTelefono1.Text = sp_datosTabla.consulta_valorString("select tele1 from persona where idPersona=" & intTmpIdPersona)
                            txtEmail.Text = sp_datosTabla.consulta_valorString("select email1 from persona where idPersona=" & intTmpIdPersona)
                            '-- nro de casa
                            txtNroCasa.Text = sp_datosTabla.consulta_valor("select numeroCasa from persona where idPersona=" & intTmpIdPersona)
                            '-- por defecto colocar la direccion en Encarnacion
                            cboDepartamento.SelectedValue = sp_datosTabla.consulta_valor("select idDepartamento from persona where idPersona=" & intTmpIdPersona)
                            cboDistrito.SelectedValue = sp_datosTabla.consulta_valor("select idDistrito from persona where idPersona=" & intTmpIdPersona)
                            cboCiudad.SelectedValue = sp_datosTabla.consulta_valor("select idCiudad from persona where idPersona=" & intTmpIdPersona)
                            cboTipoDocu.SelectedValue = sp_datosTabla.consulta_valor("select idTipoDocumento from persona where idPersona=" & intTmpIdPersona)
                            'MsgBox("Paso 3")
                            '-- habilitar los objetos
                            txtNombre.Enabled = True
                            txtNombre.BackColor = Color.White
                            txtApellido.Enabled = True
                            txtApellido.BackColor = Color.White
                            txtDireccion.Enabled = True
                            txtDireccion.BackColor = Color.White
                            maskFechaAni.Enabled = True
                            maskFechaAni.BackColor = Color.White
                            'MsgBox("Paso 2")
                            '-- cargar las variables publicas de venta
                            intGl_vtaIdCliente = CInt(sp_datosTabla.un_datoString("idCliente", "v_cliente", "soloruc", txtCedula.Text))
                            'MsgBox("Paso 3")
                            'frmVentaFarmacia.txtCliente.Text = Trim(txtNombre.Text) & "," & Trim(txtApellido.Text)
                            'MsgBox("Paso 4")
                            'frmVentaFarmacia.txtIdCliente.Text = intGl_vtaIdCliente
                            'MsgBox("Paso 5")
                            'frmVentaFarmacia.txtGrupoCliente.Text = cboGrupoCliente.Text
                            'MsgBox("Paso 6")
                            'frmVentaHeladeria.txtTelefonoCliente.Text = sp_datosTabla.consulta_valorString("select [maxifarmasa].[dbo].[funTraerTelefono](" & intTmpIdPersona & " )")

                            'frmVentaFarmacia.txtRucCliente.Text = txtCedula.Text & "-" & txtDv.Text

                            btnGuardar.Enabled = True

                            'MsgBox("3")
                        Else
                            ' MsgBox("Paso 5")
                            ban_nuevo = True
                            '-- dar el valor al dv
                            If sp_datosTabla.sp_traerValor("sp_consultaRucSet", "'" & txtCedula.Text & "'", 1) = 1 Then
                                txtDv.Text = getDV(txtCedula.Text)
                            Else
                                txtDv.Text = ""
                            End If
                            '-- si no existe nadie
                            txtNombre.Enabled = True
                            txtNombre.BackColor = Color.White
                            txtApellido.Enabled = True
                            txtApellido.BackColor = Color.White
                            txtDireccion.Enabled = True
                            txtDireccion.BackColor = Color.White
                            maskFechaAni.Enabled = True
                            maskFechaAni.BackColor = Color.White
                            btnGuardar.Enabled = True
                            '-- nro de casa
                            txtNroCasa.Text = 0
                            '-- por defecto colocar la direccion en Encarnacion
                            cboDepartamento.SelectedValue = 8
                            cboDistrito.SelectedValue = 87
                            cboCiudad.SelectedValue = 2226
                            cboTipoDocu.SelectedValue = 1
                            '-- rellenar con los datos
                            txtNombre.Text = sp_datosTabla.sp_traerValor("sp_consultaRucSet", "'" & txtCedula.Text & "'", 2)
                            txtApellido.Text = sp_datosTabla.sp_traerValor("sp_consultaRucSet", "'" & txtCedula.Text & "'", 3)

                            grupoCliente.grupoClienteCombo(cboGrupoCliente)
                            cboGrupoCliente.SelectedValue = 1

                            'MsgBox("4")
                        End If
                        e.Handled = True
                        txtDv.Focus()
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDv.KeyPress
        e.Handled = txtNumerico(txtDv, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            cboPais.Focus()
        End If
    End Sub

    Private Sub txtTelefono1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono1.KeyPress
        e.Handled = txtNumerico(txtTelefono1, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtNroCasa.Focus()
        End If
    End Sub

    Private Sub txtNroCasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCasa.KeyPress
        e.Handled = txtNumerico(txtNroCasa, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            cboDepartamento.Focus()
        End If
    End Sub

    Private Sub txtCelular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelular1.KeyPress
        e.Handled = txtNumerico(txtCelular1, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtTelefono1.Focus()
        End If
    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGuardar.Focus()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------
    '****************'
    '-- LA MASCARA --'
    '****************'
    Private Sub maskFechaAni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskFechaAni.KeyDown
        ToolTip1.Hide(maskFechaAni)
    End Sub

    Private Sub maskFechaAni_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskFechaAni.TypeValidationCompleted
        Dim strPrueba As String = maskFechaAni.Text
        '-- solo hacer el procedimiento si la primera expresion es numerica
        If IsNumeric(strPrueba.Substring(0, 1)) Then
            If Len(maskFechaAni.Text) > 0 Then

                'strPrueba.su()
                'MsgBox("Valor de la mascara  " & strPrueba, MsgBoxStyle.Information)
                If (Not e.IsValidInput) Then
                    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    ToolTip1.Show("Debe introducir una fecha con formato .", maskFechaAni, 70, -70, 700)
                    e.Cancel = True
                Else
                    Dim userdate As DateTime = CDate(e.ReturnValue)
                    ' controlar que la fecha no sea superior a la fecha actual
                    If (userdate > DateTime.Now) Then
                        ToolTip1.ToolTipTitle = "Fecha no es Válida"
                        ToolTip1.Show("La fecha debe ser menor a la fecha actual del sistema.", maskFechaAni, 0, -20, 5000)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '***********'
    '-- COMBO --'
    '***********'
    Private Sub cboDepartamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.SelectedIndexChanged
        distrito.comboDistritoDepartamento(cboDistrito, cboDepartamento.SelectedValue)
    End Sub

    Private Sub cboDistrito_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDistrito.SelectedIndexChanged
        ciudad.comboCiudadDistrito(cboCiudad, cboDepartamento.SelectedValue, cboDistrito.SelectedValue)
    End Sub

    Private Sub cboTipoDocu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDocu.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtNombre.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCliente_Venta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_ventaFarmacia1 = True Then
            '-- venta farmacia1
            'banGl_ventaFarmacia1 = False

            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------


End Class