Public Class frmAbmPais
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

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
        txtNombrePais.Enabled = False
        txtNombrePais.BackColor = Color.LightSkyBlue
        txtNacionalidad.Enabled = False
        txtNacionalidad.BackColor = Color.LightSkyBlue
        txtCodigo.Enabled = False
        txtCodigo.BackColor = Color.LightSkyBlue

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
        txtNombrePais.Enabled = True
        txtNombrePais.BackColor = Color.White
        txtNacionalidad.Enabled = True
        txtNacionalidad.BackColor = Color.White
        txtCodigo.Enabled = True
        txtCodigo.BackColor = Color.White

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
        systemClass.SqlToLv(lvCargo, "Select idPais,nombre from pais" & where)
        ' dimensionar las columnas
        lvCargo.Columns(0).Width = 80
        lvCargo.Columns(1).Width = 250
        lvCargo.Columns(0).Text = "ID Pais"
        lvCargo.Columns(1).Text = "Nombre del Pais"
        lvCargo.Scrollable = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        txtIdPais.Text = 0
        chkActivo.Checked = True
        txtNombrePais.Text = ""
        txtNacionalidad.Text = ""
        txtNombrePais.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtNombrePais.Text = ""
        txtNacionalidad.Text = ""
        chkActivo.Checked = False
        lvCargo.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If blNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insPais", "'" & txtNombrePais.Text & "'" & "," & "'" & txtNacionalidad.Text & "'," & Trim(txtCodigo.Text) & "'," & intGl_idUsuario, Me.Name)) = 0 Then
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
            If (fun_guardarSp("sp_updPais", CInt(txtIdPais.Text) & "," & "'" & txtNombrePais.Text & "'" & "," & "'" & txtNacionalidad.Text & "','" & _
                              txtCodigo.Text & "'," & chkActivo.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
        If txtNombrePais.Text = "" Then
            MessageBox.Show("Se debe mostrar el dato a modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        blNuevo = False
        habilitarObjetos()
        txtNombrePais.Focus()
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
            txtIdPais.Text = item.SubItems(0).Text
            txtNombrePais.Text = item.SubItems(1).Text
            txtNacionalidad.Text = sp_datosTabla.consulta_valorString("select gentilicio from pais where idPais=" & item.SubItems(0).Text)
            txtCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from pais where idPais=" & item.SubItems(0).Text)

            chkActivo.Checked = sp_datosTabla.un_dato("activo", "pais", "idPais", CInt(item.SubItems(0).Text))
            txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "pais", "idPais", CInt(item.SubItems(0).Text))
            txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "pais", "idPais", CInt(item.SubItems(0).Text))
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioAlta", "pais", "idPais", CInt(item.SubItems(0).Text)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioMod", "pais", "idPais", CInt(item.SubItems(0).Text)))
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
                ' ordenar por idPais
                listar(" Where idPais=" & txtBuscar.Text)
            Else
                ' ordenar por nombre de pais
                listar(" Where nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & "order by nombre")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvCargo.Select()
            'lvCargo.Focus()
        End If
    End Sub

    Private Sub txtNombrePais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombrePais.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNacionalidad.Focus()
        End If
    End Sub

    Private Sub txtNacionalidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNacionalidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCodigo.Focus()
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCargo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.abmPais.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
End Class