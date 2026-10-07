Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPassUsuario
    '******************************'
    '-- VARIABLES DE TIPO OBJETO --'
    '******************************'
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '*************************'
    '-- VARIABLES ESCALERES --'
    '*************************'
    Dim bolTmpPass As Boolean = False
    Dim bolTmpCodBar As Boolean = False

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub Limpiar()
        btnCancelar.Enabled = False
        btnCodBar.Enabled = True
        btnGuardar.Enabled = False
        btnPass.Enabled = True

        txtPass1.Enabled = False
        txtPass1.BackColor = Color.SkyBlue
        txtPass2.Enabled = False
        txtPass2.BackColor = Color.SkyBlue
        txtPass2.Text = ""
        inicializar()
    End Sub

    '-- colocar los datos del actual usuario
    Private Sub inicializar()
        txtIdUsuario.Text = intGl_idUsuario
        txtNombre.Text = sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtApellido.Text = sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtNick.Text = sp_datosTabla.un_datoString("nick", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtGrupo.Text = sp_datosTabla.un_datoString("nombreGrupoUsuario", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtCodigoBarra.Text = sp_datosTabla.un_datoString("codigoBarra", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtCodigoBarraNro.Text = sp_datosTabla.un_datoString("codigoBarraNro", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtPass1.Text = sp_datosTabla.sp_traerValor("sp_obtenerClaveUsuario", intGl_idUsuario, 0)
        '-- usuario creador
        txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "usuario", "idUsuario", intGl_idUsuario)
        '-- usuario modificador
        txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", intGl_idUsuario)
        txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "usuario", "idUsuario", intGl_idUsuario)
    End Sub

    Private Sub habilitar()
        btnCancelar.Enabled = True
        btnCodBar.Enabled = False
        btnGuardar.Enabled = True
        btnPass.Enabled = False
    End Sub

    Private Sub guardarPass()
        '******************************'
        '-- PARA EL CODIGO DE BARRAS --'
        '******************************'
        If bolTmpCodBar = True Then
            '-- guardar el codigo de barras
            If (fun_guardarSp("sp_updUsuarioCodigoBarra", intGl_idUsuario & "," & "'" & txtCodigoBarra.Text & "'" & "," & "'" & txtCodigoBarraNro.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bolTmpCodBar = False
                bolTmpPass = False

                Limpiar()
            End If
        End If
        '************************'
        '-- PARA LA CONTRASEÑA --'
        '************************'
        If bolTmpPass = True Then
            '-- verificar si no hay algun error
            If Trim(txtPass1.Text) <> Trim(sp_datosTabla.sp_traerValor("sp_obtenerClaveUsuario", intGl_idUsuario, 0)) Then
                MessageBox.Show("La contraseña introducida no es la actual..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- guardar la contraseña actualizada
            If (fun_guardarSp("sp_updUsuarioClave", intGl_idUsuario & "," & "'" & txtPass2.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                bolTmpCodBar = False
                bolTmpPass = False

                Limpiar()
            End If
        End If

    End Sub

    '---------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnCodBar_Click(sender As System.Object, e As System.EventArgs) Handles btnCodBar.Click
        Dim intTmpIdPersona As Integer
        Dim strTmpCodigoBarraNro As String
        bolTmpCodBar = True
        bolTmpPass = False
        habilitar()
        btnCancelar.Enabled = True
        If MessageBox.Show("Desea Volver a Generar el Codigo de Barras para este Usuario..!", strGl_nombreSistema, MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '-- variable de persona
            intTmpIdPersona = sp_datosTabla.un_dato_integer("idPersona", "v_usuarioT", "idUsuario", intGl_idUsuario)
            '-- el nro del codigo de barra
            txtCodigoBarraNro.Text = sp_datosTabla.sp_traerValor("sp_generarNroCodigoBarraUsuario", intTmpIdPersona, 0)
            strTmpCodigoBarraNro = "'" & sp_datosTabla.sp_traerValor("sp_generarNroCodigoBarraUsuario", intTmpIdPersona, 0) & "'"
            'MsgBox("Elcodigo de barra nro   " & strTmpCodigoBarraNro)
            '-- para un usuario nuevo
            txtCodigoBarra.Text = sp_datosTabla.sp_traerValor("sp_generarCodigoBarraUsuario", strTmpCodigoBarraNro, 0)
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarPass()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()
    End Sub

    Private Sub btnImprimirCodigoBarra_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirCodigoBarra.Click
        Dim pvParametros As New ParameterValues()
        Dim rpt As New rpt_codigoBarraUsuario()
        Dim ofrm As New crv()
        '-- instaciar el parametro
        Dim v_idUsuario As New ParameterDiscreteValue()
        'asiganar el valor a los  parametros
        v_idUsuario.Value = intGl_idUsuario
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idUsuario)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvParametros)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub

    Private Sub btnPass_Click(sender As System.Object, e As System.EventArgs) Handles btnPass.Click
        bolTmpCodBar = False
        bolTmpPass = True

        habilitar()
        btnCancelar.Enabled = True
        txtPass1.Text = ""
        txtPass1.BackColor = Color.White
        txtPass1.Enabled = True
        txtPass2.BackColor = Color.White
        txtPass2.Enabled = True
        txtPass1.Focus()
    End Sub

    '-----------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtPass1_Validated(sender As Object, e As System.EventArgs) Handles txtPass1.Validated
        If Len(txtPass1.Text) > 1 Then
            '-- solo si se escribe una contraseña se procederá a comparar 
            'MsgBox("Valor de la contraseña introducida  " & txtPass1.Text)
            'MsgBox("Valor de la contraseña actual  " & sp_datosTabla.sp_traerValor("sp_obtenerClaveUsuario", intGl_idUsuario, 0))
            If Trim(txtPass1.Text) = Trim(sp_datosTabla.sp_traerValor("sp_obtenerClaveUsuario", intGl_idUsuario, 0)) Then
                'txtPass2.Focus()
            Else
                MessageBox.Show("La contraseña introducida no es la actual..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtPass1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtPass2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmPassUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.configuracionMantenimientoPass.Enabled = True
    End Sub

    '---------------------------------------------------------------------------------------------------------
End Class