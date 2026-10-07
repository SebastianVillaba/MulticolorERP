Public Class frmBuscaGastoNotaCredito
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarConsultaCompra(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvCompra, "select cg.idGasto,cg.dsuc,cg.dcaja,cg.factura,_vp.nombre as proveedor," & _
        " cg.total,cg.fecha from cabGasto cg inner join v_proveedor _vp on cg.idProveedor=_vp.idProveedor " & where)
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

    Private Sub rdFactura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdFactura.Click
        txtDsuc.Text = ""
        txtDcaja.Text = ""
        txtFactura.Text = ""
        txtDsuc.Focus()
    End Sub

    Private Sub rdProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdProveedor.Click
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
                    listarConsultaCompra(" Where cg.idGasto=" & txtBuscar.Text)
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
                listarConsultaCompra(" Where dsuc Like '" & txtDsuc.Text & "%' and dcaja Like '" & txtDcaja.Text & "%' and factura Like '" & txtFactura.Text & "%' ")
                lvCompra.Focus()
            End If
        End If
    End Sub

    Private Sub txtDsuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
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
            If txtIdGasto.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim intTmpIdCompra As Integer
            intTmpIdCompra = (CInt(txtIdGasto.Text))
            '---------------------------'
            '-- verificar los modulos --'
            '---------------------------'
            '-- controlar que no tenga nota de credito
            'frmBuscarProductoNtaCredito.txtSql.Text = "select activo from cabNotaCredito where activo=1 and idCompra=" & CInt(txtIdCompra.Text)
            If sp_datosTabla.consulta_valor("select idNotaCreditoGasto from cabNotaCreditoGasto where activo=1 and idGasto=" & CInt(txtIdGasto.Text)) = True Then
                MessageBox.Show("Este gasto ya cuenta con una Nota de Crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- controlar que esta compra no esté pagada
            If sp_datosTabla.consulta_valor("select pagado from cabGasto where activo=1 and idGasto=" & CInt(txtIdGasto.Text)) = True Then
                MessageBox.Show("Este gasto ya se encuentra pagado...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- que no esté anulada
            If sp_datosTabla.consulta_valor("select activo from cabGasto where idGasto=" & CInt(txtIdGasto.Text)) = False Then
                MessageBox.Show("Este Gasto se encuentra anulada...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-----------------------------------------
            '** nota de credito de gasto
            '-- el idGasto
            frmNotaCreditoGasto.txtIdGasto.Text = sp_datosTabla.consulta_valor("select idGasto from cabGasto where idGasto=" & CInt(txtIdGasto.Text))
            '-- el proveedor
            Dim intTmpIdProveedor As Integer
            intTmpIdProveedor = sp_datosTabla.consulta_valor("select idProveedor from cabGasto where idGasto=" & CInt(txtIdGasto.Text))
            frmNotaCreditoGasto.txtIDProveedor.Text = intTmpIdProveedor
            frmNotaCreditoGasto.txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from v_proveedor where idProveedor=" & intTmpIdProveedor)
            '-- la cotizaciones
            frmNotaCreditoGasto.txtCotizacion.Text = sp_datosTabla.consulta_valorDouble("select cotizacion from cabGasto where idGasto=" & CInt(txtIdGasto.Text))
            '-- la moneda
            Dim intTmpIdMoneda As Integer
            intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cabGasto where idGasto=" & CInt(txtIdGasto.Text))
            frmNotaCreditoGasto.txtMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIdMoneda)

            Me.Close()
            frmNotaCreditoGasto.Enabled = True
            frmNotaCreditoGasto.Show()
            frmNotaCreditoGasto.BringToFront()
            frmNotaCreditoGasto.txtMotivo.Focus()
        End If
    End Sub

    Private Sub lvCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompra.SelectedIndexChanged
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvCompra.SelectedItems
            txtIdGasto.Text = item.SubItems(0).Text
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarFacturaCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        frmNotaCreditoGasto.Enabled = True
        frmNotaCreditoGasto.Show()
        frmNotaCreditoGasto.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------
End Class