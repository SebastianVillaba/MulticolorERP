Public Class frmAbmFormulario
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim tipoMenuPrincipal As New tipoMenuPrincipal

    Dim bolTmpNuevo As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvFormulario, "Select idFormulario, nombreFormulario from formulario" & where)
        ' dimensionar las columnas
        lvFormulario.Columns(0).Width = 80    'IDMenu
        lvFormulario.Columns(1).Width = 250  'Nombre del formulario
        lvFormulario.Scrollable = True
    End Sub

    Private Sub hablitarObjetos()
        '-- el grupo
        grBuscar.Enabled = False
        '-- los txt
        txtNombreMenu.Enabled = True
        txtNombreMenu.BackColor = Color.White
        txtNombreForm.Enabled = True
        txtNombreForm.BackColor = Color.White
        txtExplica.Enabled = True
        txtExplica.BackColor = Color.White
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        '-- el chk
        chkActivo.Enabled = True
        '-- el combo
        cboTipoMenu.Enabled = True

    End Sub

    Private Sub deshabilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = True
        '-- los txt
        txtNombreMenu.Enabled = False
        txtNombreMenu.BackColor = Color.LightSkyBlue
        txtNombreForm.Enabled = False
        txtNombreForm.BackColor = Color.LightSkyBlue
        txtExplica.Enabled = False
        txtExplica.BackColor = Color.LightSkyBlue
        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        '-- el chk
        chkActivo.Enabled = False
        '-- el combo
        cboTipoMenu.Enabled = False

        listar("")
    End Sub

    Private Sub limpiarObjeto()
        '--txt 
        txtIdFormulario.Text = 0
        txtNombreMenu.Text = ""
        txtExplica.Text = ""
        txtNombreForm.Text = ""
    End Sub

    Private Sub guardarFormulario()
        '-- variables para los parametros
        Dim intTmpIdFormulario As Integer
        Dim strTmpNombreFormulario As String
        Dim strTmpNombreForm As String
        Dim strTmpExplicaForm As String
        Dim bolTmpActivo As Boolean
        Dim intTmpIdTipoMenu As Integer
        '-- dar valor a las variables
        If txtNombreMenu.Text = "" Then
            strTmpNombreFormulario = "''"
        Else
            strTmpNombreFormulario = txtNombreMenu.Text
        End If
        intTmpIdFormulario = CInt(txtIdFormulario.Text)
        strTmpExplicaForm = txtExplica.Text
        strTmpNombreForm = txtNombreForm.Text
        bolTmpActivo = chkActivo.Checked
        intTmpIdTipoMenu = CInt(cboTipoMenu.SelectedValue)
        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insFormulario", intTmpIdTipoMenu & "," & "'" & strTmpNombreFormulario & "'" & "," & "'" & strTmpNombreForm & "'" & "," & "'" & strTmpExplicaForm & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        Else
            '******************'
            '-- MODIFICACION --'
            '******************'
            If (fun_guardarSp("sp_updFormulario", intTmpIdFormulario & "," & intTmpIdTipoMenu & "," & "'" & strTmpNombreFormulario & "'" & "," & "'" & strTmpNombreForm & "'" & "," & "'" & strTmpExplicaForm & "'" & "," & bolTmpActivo & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        End If

    End Sub
    '-------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True
        hablitarObjetos()
        limpiarObjeto()
        chkActivo.Checked = True
        chkActivo.Enabled = False
        tipoMenuPrincipal.listarTipoMenuPrincipalCbo(cboTipoMenu)
        txtNombreMenu.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtNombreMenu.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        bolTmpNuevo = False
        hablitarObjetos()
        txtNombreMenu.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarFormulario()
    End Sub

    '--------------------------------------------------------------------------------------------------
    '***************'
    '-- LISTVIEW --'
    '***************'
    Private Sub lvFormulario_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvFormulario.SelectedIndexChanged
        Dim intTmpIdformulario As Integer
        For Each item As ListViewItem In lvFormulario.SelectedItems
            intTmpIdformulario = CInt(item.SubItems(0).Text)
            txtIdFormulario.Text = intTmpIdformulario
            txtNombreMenu.Text = item.SubItems(1).Text
            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "formulario", "idFormulario", intTmpIdformulario)
            txtNombreForm.Text = sp_datosTabla.consulta_valorString("select nombreForm from formulario where idformulario=" & intTmpIdformulario)
            txtExplica.Text = sp_datosTabla.consulta_valorString("select explicaForm from formulario where idFormulario=" & intTmpIdformulario)
            '-- el tipo de menu
            tipoMenuPrincipal.listarTipoMenuPrincipalCbo(cboTipoMenu)
            cboTipoMenu.SelectedValue = sp_datosTabla.un_dato_integer("idTipoMenu", "formulario", "idFormulario", intTmpIdformulario)
        Next
    End Sub

    Private Sub lvFormulario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvFormulario.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- si solo se presiono enter
            If Len(txtBuscar.Text) = 0 Then
                '-- listar todo
                listar("")
            Else
                If IsNumeric(txtBuscar.Text) Then
                    '-- buscar por IdUsuario
                    listar(" where idformulario Like '" & txtBuscar.Text & "%' Or idFormulario Like '" & txtBuscar.Text & "%' " & "order by idFormulario")
                Else
                    '-- buscar por nick
                    listar(" where nombreFormulario Like '" & txtBuscar.Text & "%' Or nombreFormulario Like '" & txtBuscar.Text & "%' " & "order by nombreFormulario")
                End If
            End If
            lvFormulario.Focus()
        End If
    End Sub

    Private Sub txtNombreMenu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreMenu.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtNombreForm_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreForm.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmFormulario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.configuracionAbmFormularios.Enabled = True
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------

End Class