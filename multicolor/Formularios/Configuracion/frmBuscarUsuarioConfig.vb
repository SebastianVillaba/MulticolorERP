Public Class frmBuscarUsuarioConfig
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
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
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lv, "select _vu.idUsuario,_vu.nombre,_vu.apellido,_vp.nombreCargo,p.email1  from v_usuario _vu " & _
        " inner join v_personal _vp on _vu.idPersonal=_vp.idPersonal inner join persona p on p.idPersona=_vu.idPersona  " & where)
        'txtSql.Text = "Select idDivision,ltrim(nombre) as Nombre from v_division  " & where
    End Sub

    Private Sub mostrarUsuario()
        '-- cargar la grilla
        If (fun_guardarSp("sp_agregarDetConfigEmailTmp", intGl_idConfigPc & "," & 0 & "," & CInt(txtId.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            Exit Sub
        Else
            frmConfigEmail.listarDetalle()
            '-- cargar los datos del usuario
            Me.Close()
            frmConfigEmail.Enabled = True
            frmConfigEmail.Show()
            frmConfigEmail.BringToFront()
            frmConfigEmail.btnAgregar.Focus()
        End If

    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                listar(" Where _vu.nombre Like '" & txtBuscar.Text & "%' Or _vu.nombre Like '" & txtBuscar.Text & "%'" & "order by _vu.nombre")
            Else
                '-- buscar por id
                listar(" Where _vu.idUsuario Like '" & txtBuscar.Text & "%' Or _vu.idUsuario Like '" & txtBuscar.Text & "%' " & " order by _vu.idUsuario")
            End If
            lv.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lv.KeyPress
        If txtId.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtId.Text) = 0 Then
                    MessageBox.Show("Debe ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                mostrarUsuario()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If

    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged
        For Each item As ListViewItem In lv.SelectedItems
            txtId.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarUsuarioConfig_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConfigEmail.Enabled = True
        frmConfigEmail.Show()
        frmConfigEmail.BringToFront()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
End Class