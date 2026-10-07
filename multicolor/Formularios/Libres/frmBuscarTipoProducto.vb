Public Class frmBuscarTipoProducto
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub inicializar()
        listar(" Where nombreTipo Like '" & "A" & "%' Or nombreTipo Like '" & "A" & "%' " & "order by nombreTipo")
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lv, "Select idTipoProducto,ltrim(nombreTipo)from v_tipoProducto  " & where)
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                listar(" Where nombreTipo Like '" & txtBuscar.Text & "%' Or nombreTipo Like '" & txtBuscar.Text & "%' " & "order by nombreTipo")
            Else
                '-- buscar por idLaboratorio
                listar(" Where idTipoProducto Like '" & txtBuscar.Text & "%' Or idTipoProducto Like '" & txtBuscar.Text & "%' " & "order by idTipoProducto")
            End If
            lv.Focus()
        End If
    End Sub

    Private Sub lv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lv.KeyPress
        If txtId.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtId.Text) = 0 Then
                    MessageBox.Show("Debe ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                verificarVentana()
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

    Private Sub verificarVentana()
        If banGl_tipoProdAbmProducto = True Then
            '-- para el formulario de abmProducto
            frmAbmProducto.txtIdTipoProducto.Text = CInt(txtId.Text)
            '-- nombre del tipo de producto
            frmAbmProducto.txtTipo.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", CInt(txtId.Text))
            Me.Close()
            frmAbmProducto.Enabled = True
            frmAbmProducto.Show()
            frmAbmProducto.BringToFront()
            frmAbmProducto.btnBuscarLabo.Focus()
        End If

        If banGl_estadisticaCliente = True Then
            '-- para el formulario de estadistica de clientes

            frmEstadisticaClientes.lblIdTipoProducto.Text = CInt(txtId.Text)
            '-- nombre del tipo de producto
            frmEstadisticaClientes.lblTipoproducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", CInt(txtId.Text))
            Me.Close()
        End If
    End Sub

    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarTipoProducto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_tipoProdAbmProducto = True Then
            '-- abm tipo de producto
            banGl_tipoProdAbmProducto = False
            e.Cancel = False
            frmAbmProducto.Enabled = True
            frmAbmProducto.Show()
            frmAbmProducto.BringToFront()
            frmAbmProducto.btnBuscarLabo.Focus()
        End If
        If banGl_estadisticaCliente = True Then
            '-- estadistica de clientes
            banGl_estadisticaCliente = False
            e.Cancel = False
            frmEstadisticaClientes.Enabled = True
            frmEstadisticaClientes.Show()
            frmEstadisticaClientes.BringToFront()
            frmEstadisticaClientes.btnConsultar.Focus()
        End If
    End Sub

End Class