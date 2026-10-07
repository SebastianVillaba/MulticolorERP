Public Class frmBuscarRepartidor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select _vr.idRepartidor,_vr.nombre,_vr.apellido from v_repartidor _vr " & where)
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80
        lvBuscar.Columns(1).Width = 250
        lvBuscar.Columns(2).Width = 250
        lvBuscar.Columns(0).Text = "ID Rep."
        lvBuscar.Columns(1).Text = "Nombre"
        lvBuscar.Columns(2).Text = "Apellido"
        lvBuscar.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_reporteDelivery = True Then
            '-- reporte de Remision
            reporteDelivery()
        End If
    End Sub

    Private Sub reporteDelivery()
        '-- colocar los datos del proveedor
        frmReporteDelivery.lblRepartidor.Text = txtNombre.Text
        frmReporteDelivery.lblIdRepartidor.Text = CInt(txtId.Text)

        Me.Close()
    End Sub
    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idRepartidor
                listar(" Where _vr.idRepartidor=" & txtBuscar.Text & " order by _vr.idRepartidor")
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre
                listar(" Where _vr.nombre Like '" & txtBuscar.Text & "%' Or _vr.nombre Like '" & txtBuscar.Text & "%' " & " order by _vr.apellido")
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
            txtNombre.Text = Trim(item.SubItems(1).Text) & "," & Trim(item.SubItems(2).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarRepartidor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_reporteDelivery = True Then
            '-- reporte del delivery
            banGl_reporteDelivery = False

            frmReporteDelivery.Enabled = True
            frmReporteDelivery.Show()
            frmReporteDelivery.BringToFront()
            frmReporteDelivery.btnConsultar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
End Class