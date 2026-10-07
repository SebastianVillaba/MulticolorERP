Public Class frmBucarCompraDevolucion
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdCompra As Integer = 0
    Dim intIdDevolucion As Integer = 0

    Sub New()
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarConsultaCompra(ByVal where As String)
        systemClass.SqlToLv_consultaCompraDevolucion(lvCompra, "select cc.idCompra,cd.idDevolucionCompra,cc.dsuc,cc.dcaja,cc.factura,_vp.nombre,cc.total," & _
        " CONVERT(varchar,cc.fecha,103)as fecha from cabCompra cc inner join cabDevolucionCompra cd on cc.idCompra=cd.idCompra " & _
        " inner join v_proveedor _vp on _vp.idProveedor=cc.idProveedor" & where)
    End Sub

    Private Sub recepcionCompra()
        frmRecepcionCompra.txtIdDev.Text = intIdDevolucion
        '-- el id
        frmRecepcionCompra.txtIdCompra.Text = intIdCompra
        '-- el proveedor
        frmRecepcionCompra.txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from cabcompra cc inner join v_proveedor _vp " & _
                                                " on cc.idProveedor=_vp.idProveedor where cc.idCompra=" & intIdCompra)
        '-- dsuc
        frmRecepcionCompra.txtFactura.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(factura) from " & _
                                                                                 " cabCompra where idCompra=" & intIdCompra)
        '-- fecha de la factura
        frmRecepcionCompra.txtFechaCompra.Text = sp_datosTabla.consulta_valorString("select convert(varchar,fecha,103) from cabCompra where idCompra=" & intIdCompra)

        frmRecepcionCompra.habilitarObjetos()
        frmRecepcionCompra.btnBuscar.Focus()
        Me.Close()
    End Sub
    '--------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdFactura.CheckedChanged
        txtDcaja.Visible = True
        txtDcaja.Text = ""
        txtDsuc.Visible = True
        txtDsuc.Text = ""
        txtFactura.Visible = True
        txtFactura.Text = ""
        txtBuscar.Visible = False
    End Sub

    Private Sub rdProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdProveedor.CheckedChanged
        txtDcaja.Visible = False
        txtDsuc.Visible = False
        txtFactura.Visible = False
        txtBuscar.Visible = True
        txtBuscar.Text = ""
    End Sub

    Private Sub rdFactura_Click(sender As Object, e As System.EventArgs) Handles rdFactura.Click
        txtDsuc.Text = ""
        txtDcaja.Text = ""
        txtFactura.Text = ""
        txtDsuc.Focus()
    End Sub

    Private Sub rdProveedor_Click(sender As Object, e As System.EventArgs) Handles rdProveedor.Click
        txtBuscar.Text = ""
        txtBuscar.Focus()
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '-- controlar la primera letra ingresada
                If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                    '-- ordenar por idCompra
                    listarConsultaCompra(" Where cc.idCompra Like '" & txtBuscar.Text & "%' Or cc.idCompra Like '" & txtBuscar.Text & "%' ")
                Else
                    ' ordenar por nombre del Proveedor
                    listarConsultaCompra(" Where _vp.nombre Like '" & txtBuscar.Text & "%' Or _vp.nombre Like '" & txtBuscar.Text & "%' ")
                End If
            End If
            lvCompra.Focus()
        End If

    End Sub

    Private Sub txtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtFactura.Text.Length > 0 Then
                '-- ordenar por factura
                listarConsultaCompra(" Where cc.dsuc Like '" & txtDsuc.Text & "%' and cc.dcaja Like '" & txtDcaja.Text & "%' and cc.factura Like '" & txtFactura.Text & "%' ")
                lvCompra.Focus()
            End If
        End If
    End Sub

    Private Sub txtDsuc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCompra.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then

            '-- solo si se pocisiona sobre un registro
            If txtIdCompra.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            intIdCompra = (CInt(txtIdCompra.Text))
            '---------------------------'
            '-- verificar los modulos --'
            '---------------------------'
            recepcionCompra()
        End If
    End Sub

    Private Sub lvCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompra.SelectedIndexChanged
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvCompra.SelectedItems
            txtIdCompra.Text = item.SubItems(0).Text
            intIdCompra = item.SubItems(0).Text
            intIdDevolucion = item.SubItems(1).Text
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarFacturaCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmRecepcionCompra.Enabled = True
        frmRecepcionCompra.Show()
        frmRecepcionCompra.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------
End Class