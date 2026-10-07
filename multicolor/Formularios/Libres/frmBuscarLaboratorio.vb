Public Class frmBuscarLaboratorio
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
        listar(" Where nombre Like '" & "A" & "%' Or nombre Like '" & "A" & "%' " & "order by nombre")
        'valorde del combo
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub verificarModulo()
        If banGl_labAbmProducto = True Then
            '-- para el formulario de abmProducto
            frmAbmProducto.txtIdLaboratorio.Text = CInt(txtIdLaboratorio.Text)
            '-- nombre del producto
            frmAbmProducto.txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", CInt(txtIdLaboratorio.Text))
            Me.Close()
        End If
        If banGl_estadisticaProveedor = True Then
            frmEstadisticaProveedor.lblProveedor.Text = ""
            frmEstadisticaProveedor.lblIdProveedor.Text = 0
            frmEstadisticaProveedor.lblProducto.Text = ""
            frmEstadisticaProveedor.lblIdProducto.Text = 0
            frmEstadisticaProveedor.lblCodigo.Text = 0

            frmEstadisticaProveedor.lblIdLaboratorio.Text = txtIdLaboratorio.Text
            frmEstadisticaProveedor.lblLaboratorio.Text = sp_datosTabla.consulta_valorString("select nombre from v_laboratorio where idLaboratorio=" & CInt(txtIdLaboratorio.Text))

            Me.Close()
        End If
        If banGl_estadisticaCliente = True Then
            frmEstadisticaClientes.lblIdLaboratorio.Text = txtIdLaboratorio.Text
            frmEstadisticaClientes.lblLaboratorio.Text = sp_datosTabla.consulta_valorString("select nombre from v_laboratorio where idLaboratorio=" & CInt(txtIdLaboratorio.Text))

            Me.Close()
        End If

    End Sub

    '-- listar
    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvLaboratorio, "Select idLaboratorio,ltrim(nombre) as Nombre from v_laboratorio  " & where)
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- TEXTBOX --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                listar(" Where nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & "order by nombre")
            Else
                '-- buscar por idLaboratorio
                listar(" Where idLaboratorio Like '" & txtBuscar.Text & "%' Or idLaboratorio Like '" & txtBuscar.Text & "%' " & "order by idLaboratorio")
            End If
            lvLaboratorio.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvLaboratorio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvLaboratorio.KeyPress
        If txtIdLaboratorio.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtIdLaboratorio.Text) = 0 Then
                    MessageBox.Show("Debe ingresar algún Laboratorio..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                verificarModulo()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvLaboratorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLaboratorio.SelectedIndexChanged
        For Each item As ListViewItem In lvLaboratorio.SelectedItems
            txtIdLaboratorio.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarLaboratorio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_labAbmProducto = True Then
            banGl_labAbmProducto = False
            e.Cancel = False
            frmAbmProducto.Enabled = True
            frmAbmProducto.Show()
            frmAbmProducto.BringToFront()
            frmAbmProducto.cboImpuesto.Focus()
        End If
        If banGl_estadisticaProveedor = True Then
            banGl_estadisticaProveedor = False
            e.Cancel = False
            frmEstadisticaProveedor.Enabled = True
            frmEstadisticaProveedor.Show()
            frmEstadisticaProveedor.BringToFront()
            frmEstadisticaProveedor.btnConsultar.Focus()
        End If
        If banGl_estadisticaCliente = True Then
            banGl_estadisticaCliente = False
            e.Cancel = False
            frmEstadisticaClientes.Enabled = True
            frmEstadisticaClientes.Show()
            frmEstadisticaClientes.BringToFront()
            frmEstadisticaClientes.btnConsultar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------
End Class