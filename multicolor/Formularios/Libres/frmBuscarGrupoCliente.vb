Public Class frmBuscarGrupoCliente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select idGrupoCliente,nombreGrupoCliente from grupoCliente " & where)
        'txtSql.Text = "Select _vs.idSucursal,_vs.nombreFantasia from v_Sucursal _vs " & where
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80
        lvBuscar.Columns(1).Width = 250
        lvBuscar.Columns(0).Text = "ID Grupo"
        lvBuscar.Columns(1).Text = "Nombre del Grupo"
        lvBuscar.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_reporteSaldoCliente = True Then
            '-- reporte de Remision
            reporteSaldoCliente()
        End If
    End Sub

    Private Sub reporteSaldoCliente()
        '-- colocar los datos del proveedor
        frmReporteSaldoCliente.lblNombreGrupo.Text = txtNombre.Text
        frmReporteSaldoCliente.lblIdGrupo.Text = CInt(txtId.Text)

        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idGrupo
                listar(" Where idGrupoCliente=" & txtBuscar.Text)
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre del grupo
                listar(" Where nombreGrupoCliente Like '" & txtBuscar.Text & "%' Or nombreGrupoCliente Like '" & txtBuscar.Text & "%' " & " order by nombreGrupoCliente")
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
    Private Sub frmBuscarSucursal_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_reporteSaldoCliente = True Then
            '-- reporte saldo de cliente
            banGl_reporteSaldoCliente = False

            frmReporteSaldoCliente.Enabled = True
            frmReporteSaldoCliente.Show()
            frmReporteSaldoCliente.BringToFront()
            frmReporteSaldoCliente.btnConsultar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
End Class