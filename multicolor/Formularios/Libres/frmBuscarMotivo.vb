Public Class frmBuscarMotivo
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select idMotivo,nombreMotivo from motivoAjuste " & where)
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80
        lvBuscar.Columns(1).Width = 250
        lvBuscar.Columns(0).Text = "ID Motivo"
        lvBuscar.Columns(1).Text = "Nombre del Motivo"
        lvBuscar.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_reporteMercaderiaGral = True Then
            '--- reporte de mercaderia en gral
            reporteMercaderiaGral()
        End If
    End Sub


    Private Sub reporteMercaderiaGral()
        frmReporteMercaderiaGral.lblIdProducto.Text = txtId.Text
        frmReporteMercaderiaGral.lblMercaderia.Text = txtNombre.Text

        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                listar(" Where idMotivo=" & txtBuscar.Text)
            Else
                listar(" Where nombreMotivo Like '" & txtBuscar.Text & "%' Or nombreMotivo Like '" & txtBuscar.Text & "%' " & " order by nombreMotivo")
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
            If IsNumeric(txtId.Text) Then
                If txtId.Text = 0 Then
                    MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                controlarModulo()
            End If

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
    Private Sub frmBuscarDeposito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_reporteMercaderiaGral = True Then
            '-- reportes mercaderia en gral
            banGl_reporteMercaderiaGral = False

            frmReporteMercaderiaGral.Enabled = True
            frmReporteMercaderiaGral.Show()
            frmReporteMercaderiaGral.BringToFront()
            frmReporteMercaderiaGral.btnConsultar.Focus()
        End If

    End Sub
    '--------------------------------------------------------------------------------------
End Class