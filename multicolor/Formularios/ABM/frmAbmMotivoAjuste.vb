Public Class frmAbmMotivoAjuste
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
        txtNombreMotivo.Enabled = False
        txtNombreMotivo.BackColor = Color.LightSkyBlue
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
        txtNombreMotivo.Enabled = True
        txtNombreMotivo.BackColor = Color.White
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
        systemClass.SqlToLv(lvMotivo, "Select idMotivo,nombreMotivo from motivoAjuste" & where)
        ' dimensionar las columnas
        lvMotivo.Columns(0).Width = 80
        lvMotivo.Columns(1).Width = 250
        lvMotivo.Columns(0).Text = "ID Motivo"
        lvMotivo.Columns(1).Text = "Nombre del Motivo"
        lvMotivo.Scrollable = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        txtIdMotivo.Text = 0
        chkActivo.Checked = True
        txtNombreMotivo.Text = ""
        txtNombreMotivo.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtNombreMotivo.Text = ""
        chkActivo.Checked = False
        lvMotivo.Focus()
    End Sub

    'Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
    '    Me.Close()
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'controlar si existe algun error
        If txtNombreMotivo.Text = "" Then
            MessageBox.Show("Debe ingresar algún Nombre para el Cargo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If blNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insMotivoAjuste", "'" & txtNombreMotivo.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
            If (fun_guardarSp("sp_updMotivoAjuste", CInt(txtIdMotivo.Text) & "," & "'" & txtNombreMotivo.Text & "'" & "," & chkActivo.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
        'strDatosOriginales = Trim(txtNombreCargo.Text) & "," & chkActivo.Checked.ToString
        If txtNombreMotivo.Text = "" Then
            MessageBox.Show("Se debe mostrar el dato a modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        blNuevo = False
        habilitarObjetos()
        txtNombreMotivo.Focus()
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvmotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMotivo.SelectedIndexChanged
        Dim intTmpIdMotivo As Integer
        Dim intTmpIdUsuario As Integer

        For Each item As ListViewItem In lvMotivo.SelectedItems
            intTmpIdMotivo = item.SubItems(0).Text
            txtIdMotivo.Text = item.SubItems(0).Text
            txtNombreMotivo.Text = item.SubItems(1).Text
            chkActivo.Checked = sp_datosTabla.consulta_valorBoolean("select activo from motivoAjuste where idMotivo=" & intTmpIdMotivo)
            txtFechaAlta.Text = sp_datosTabla.consulta_valorString("select fechaAlta from motivoAjuste where idMotivo=" & intTmpIdMotivo)
            txtFechaMod.Text = sp_datosTabla.consulta_valorString("select fechaMod from motivoAjuste where idMotivo=" & intTmpIdMotivo)
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from motivoAjuste where idMotivo=" & intTmpIdMotivo)
            txtUsuarioAlta.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioMod from motivoAjuste where idMotivo=" & intTmpIdMotivo)
            txtUsuarioMod.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
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
                ' ordenar por idMotivo
                listar(" Where idMotivo=" & txtBuscar.Text)
            Else
                ' ordenar por nombre de cargo
                listar(" Where nombreMotivo Like '" & txtBuscar.Text & "%' Or nombreMotivo Like '" & txtBuscar.Text & "%' " & "order by nombreMotivo")
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
    Private Sub frmAbmMotivoAjuste_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.abmMotivoAjuste.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
End Class