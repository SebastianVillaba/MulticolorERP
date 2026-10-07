Public Class frmAbmSubLinea
    Private sp_cargo As New sp_cargo
    Private sp_obtenerDatosUsuario As New sp_obtenerDatosUsuario
    Private sp_datosTabla As New sp_datosTabla
    'Private sp_auditoriaSistema As New sp_auditoriaSistema
    Private cargo As New cargo
    Dim intIdusuarioAlta As Integer
    Dim intIdcargo As Integer
    Dim blNuevo As Boolean
    Dim systemClass As New SystemClass
    Dim strDatosOriginales As String

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
        txtNombreSubLinea.Enabled = False
        txtNombreSubLinea.BackColor = Color.LightSkyBlue
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
        txtNombreSubLinea.Enabled = True
        txtNombreSubLinea.BackColor = Color.White
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
        systemClass.SqlToLv(lvCargo, "Select idSubLinea,nombreSubLinea from subLinea" & where)
        ' dimensionar las columnas
        lvCargo.Columns(0).Width = 80
        lvCargo.Columns(1).Width = 250
        lvCargo.Columns(0).Text = "ID Subliea"
        lvCargo.Columns(1).Text = "Nombre de la SubLinea"
        lvCargo.Scrollable = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        txtIdSubLinea.Text = 0
        chkActivo.Checked = True
        txtNombreSubLinea.Text = ""
        txtNombreSubLinea.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtNombreSubLinea.Text = ""
        chkActivo.Checked = False
        lvCargo.Focus()
    End Sub

    'Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
    '    Me.Close()
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'controlar si existe algun error
        If txtNombreSubLinea.Text = "" Then
            MessageBox.Show("Debe ingresar algún Nombre para la SubLinea..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If blNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insSubLinea", "'" & txtNombreSubLinea.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
            If (fun_guardarSp("sp_updSubLinea", CInt(txtIdSubLinea.Text) & "," & "'" & txtNombreSubLinea.Text & "'" & "," & chkActivo.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
        '-- guardar en una variable todos los datos originales
        strDatosOriginales = Trim(txtNombreSubLinea.Text) & "," & chkActivo.Checked.ToString
        If txtNombreSubLinea.Text = "" Then
            MessageBox.Show("Se debe mostrar el dato a modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        blNuevo = False
        habilitarObjetos()
        txtNombreSubLinea.Focus()
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
            txtIdSubLinea.Text = item.SubItems(0).Text
            txtNombreSubLinea.Text = item.SubItems(1).Text
            chkActivo.Checked = sp_datosTabla.un_dato("activo", "subLinea", "idSubLinea", CInt(item.SubItems(0).Text))
            txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "subLinea", "idSubLinea", CInt(item.SubItems(0).Text))
            txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "subLinea", "idSubLinea", CInt(item.SubItems(0).Text))
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioAlta", "subLinea", "idSubLinea", CInt(item.SubItems(0).Text)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioMod", "subLinea", "idSubLinea", CInt(item.SubItems(0).Text)))
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
                ' ordenar por idLinea
                listar(" Where idSubLinea=" & txtBuscar.Text)
            Else
                ' ordenar por nombre de subLinea
                listar(" Where nombreSubLinea Like '" & txtBuscar.Text & "%' Or nombreSubLinea Like '" & txtBuscar.Text & "%' " & "order by nombreSubLinea")
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
    Private Sub frmAbmSublinea_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        'frmMenuPrincipal.abmMercaderiaSubLinea.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
End Class