Public Class frmAbmColor
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
        txtNombreColor.Enabled = False
        txtNombreColor.BackColor = Color.LightSkyBlue
        txtCodigo.Enabled = False
        txtCodigo.BackColor = Color.LightSkyBlue

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
        txtNombreColor.Enabled = True
        txtNombreColor.BackColor = Color.White
        txtCodigo.Enabled = True
        txtCodigo.BackColor = Color.White

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
        systemClass.SqlToLv(lvCargo, "Select top 20 idColorInmo,nombre,codigo from colorInmo" & where)
        ' dimensionar las columnas
        lvCargo.Columns(0).Width = 80
        lvCargo.Columns(1).Width = 250
        lvCargo.Columns(2).Width = 200
        lvCargo.Columns(0).Text = "ID Color"
        lvCargo.Columns(1).Text = "Nombre del Color"
        lvCargo.Columns(2).Text = "Codigo"
        lvCargo.Scrollable = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        txtIdColor.Text = 0
        txtNombreColor.Text = ""
        txtNombreColor.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtNombreColor.Text = ""
        lvCargo.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If blNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insColorInmo", "'" & Trim(txtNombreColor.Text) & "','" & Trim(txtCodigo.Text) & "'", Me.Name)) = 0 Then
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
            If (fun_guardarSp("sp_updColorInmo", sacarComa(txtIdColor.Text) & ",'" & Trim(txtNombreColor.Text) & "','" & Trim(txtCodigo.Text) & "'", Me.Name)) = 0 Then
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
        If txtNombreColor.Text = "" Then
            MessageBox.Show("Se debe mostrar el dato a modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        blNuevo = False
        habilitarObjetos()
        txtNombreColor.Focus()
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
            txtIdColor.Text = item.SubItems(0).Text
            txtNombreColor.Text = item.SubItems(1).Text
            txtCodigo.Text = item.SubItems(2).Text
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
                ' ordenar por idColor
                listar(" Where idColor=" & txtBuscar.Text)
            Else
                ' ordenar por nombre del color
                listar(" Where nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & "order by nombre")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvCargo.Select()
            'lvCargo.Focus()
        End If
    End Sub

    Private Sub txtNombreColor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreColor.KeyPress
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
    Private Sub frmAbmColor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.abmColor.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
End Class