Public Class frmBuscarPersonaJur
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select _vp.idPersonaJur,_vp.nombre from v_personaJur _vp " & where)
        'txtSql.Text = "Select _vs.idSucursal,_vs.nombreFantasia from v_Sucursal _vs " & where
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80
        lvBuscar.Columns(1).Width = 250
        lvBuscar.Columns(0).Text = "ID Per."
        lvBuscar.Columns(1).Text = "Nombre de la Persona Juridica"
        lvBuscar.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_abmTimbradoDE = True Then
            '-- abm de timbrado DE
            abmTimbradoDE(CInt(txtId.Text))
        End If
    End Sub

    Private Sub abmTimbradoDE(ByVal v_idPersonaJur As Integer)
        frmAbmTimbradoDE.txtIdFirma.Text = v_idPersonaJur
        frmAbmTimbradoDE.txtFirma.Text = txtNombre.Text

        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por id
                listar(" Where _vp.idPersonaJur=" & txtBuscar.Text)
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre 
                listar(" Where _vp.nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & " order by nombre")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtId.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtId.Text = item.SubItems(0).Text
            txtNombre.Text = item.SubItems(1).Text
        Next
    End Sub
    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarPersonaJur_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_abmTimbradoDE = True Then
            '-- abm de timbrado DE
            banGl_abmTimbradoDE = False

            frmAbmTimbradoDE.Enabled = True
            frmAbmTimbradoDE.Show()
            frmAbmTimbradoDE.BringToFront()
            frmAbmTimbradoDE.txtIdTimbrado.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
End Class