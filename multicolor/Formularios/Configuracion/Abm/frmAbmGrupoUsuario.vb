Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmAbmGrupoUsuario
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdusuarioAlta As Integer
    Dim intIdcargo As Integer
    Dim blNuevo As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub deshabilitarObjetos() 'colocar como está originalmente
        txtNombreGrupo.Enabled = False
        txtNombreGrupo.BackColor = Color.LightSkyBlue
        chkActivo.Enabled = False

        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True

        '-- la seccion de busqueda
        grBuscar.Enabled = True
        'txtBuscar.Enabled = True
        txtBuscar.BackColor = Color.White
        'grOrdenar.Enabled = True

        'lvCargo.Enabled = True

    End Sub

    Sub habilitarObjetos() 'colocar como para agregar datos
        txtNombreGrupo.Enabled = True
        txtNombreGrupo.BackColor = Color.White
        chkActivo.Enabled = True

        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False

        '-- la seccion de busqueda
        'txtBuscar.Enabled = False
        txtBuscar.BackColor = Color.LightSkyBlue
        'grOrdenar.Enabled = False
        grBuscar.Enabled = False
        'lvCargo.Enabled = False
    End Sub

    'listar
    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvCargo, "Select idGrupoUsuario,nombreGrupoUsuario from grupoUsuario" & where)
        ' dimensionar las columnas
        lvCargo.Columns(0).Width = 80
        lvCargo.Columns(1).Width = 250
        lvCargo.Columns(0).Text = "ID Grupo"
        lvCargo.Columns(1).Text = "Nombre del Grupo"
        lvCargo.Scrollable = True
    End Sub

    '---------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        txtIdGrupo.Text = 0
        chkActivo.Checked = True
        txtNombreGrupo.Text = ""
        txtNombreGrupo.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtNombreGrupo.Text = ""
        chkActivo.Checked = False
        lvCargo.Focus()
    End Sub

    'Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
    '    Me.Close()
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'controlar si existe algun error
        If txtNombreGrupo.Text = "" Then
            MessageBox.Show("Debe ingresar algún Nombre para el Cargo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If blNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insGrupoUsuario", "'" & txtNombreGrupo.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
                inicializar()
            End If
        Else
            '******************'
            '-- MODIFICACION --'
            '******************'
            If (fun_guardarSp("sp_updGrupoUsuario", CInt(txtIdGrupo.Text) & "," & "'" & txtNombreGrupo.Text & "'" & "," & chkActivo.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
                inicializar()
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        blNuevo = False
        habilitarObjetos()
        txtNombreGrupo.Focus()
    End Sub

    '---------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCargo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCargo.KeyPress, lvCargo.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCargo.SelectedIndexChanged
        For Each item As ListViewItem In lvCargo.SelectedItems
            txtIdGrupo.Text = item.SubItems(0).Text
            txtNombreGrupo.Text = item.SubItems(1).Text
            chkActivo.Checked = sp_datosTabla.un_dato("activo", "grupoUsuario", "idGrupoUsuario", CInt(item.SubItems(0).Text))
            txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "grupoUsuario", "idGrupoUsuario", CInt(item.SubItems(0).Text))
            txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "grupoUsuario", "idGrupoUsuario", CInt(item.SubItems(0).Text))
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioAlta", "grupoUsuario", "idGrupoUsuario", CInt(item.SubItems(0).Text)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioMod", "grupoUsuario", "idGrupoUsuario", CInt(item.SubItems(0).Text)))
        Next
        ' txtUsuarioAlta.Text = sp_obtenerDatosUsuario.nombreUsuario(intIdusuarioAlta)
        'strNombreUsuario = sp_obtenerDatosUsuario.nombreUsuario(4)
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idGrupo
                listar(" Where idGrupoUsuario=" & txtBuscar.Text)
            Else
                ' ordenar por nombre del grupo
                listar(" Where nombreGrupoUsuario Like '" & txtBuscar.Text & "%' Or nombreGrupoUsuario Like '" & txtBuscar.Text & "%' " & "order by nombreGrupoUsuario")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvCargo.Select()
            'lvCargo.Focus()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmAbmGrupoUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.configuracionAbmGrupoUsuario.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
End Class