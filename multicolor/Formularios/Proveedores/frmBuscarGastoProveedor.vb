Public Class frmBuscarGastoProveedor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intTipo As Integer

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarConsultaCompra(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvCompra, "select cg.idGasto,cg.dsuc,cg.dcaja,cg.factura,_vp.nombre as proveedor," & _
        " cg.total,cg.fecha,0 as tipo from cabGasto cg inner join v_proveedor _vp on cg.idProveedor=_vp.idProveedor " & where & _
        " union " & _
        " select cg.idGasto,cg.dsuc,cg.dcaja,cg.factura,_vp.nombre as proveedor,cg.total,cg.fecha,1 as tipo " & _
        " from cga cg inner join v_proveedor _vp on cg.idProveedor=_vp.idProveedor" & where)
        txtSql.Text = "select cg.idGasto,cg.dsuc,cg.dcaja,cg.factura,_vp.nombre as proveedor," & _
        " cg.total,cg.fecha,0 as tipo from cabGasto cg inner join v_proveedor _vp on cg.idProveedor=_vp.idProveedor " & where & _
        " union " & _
        " select cg.idGasto,cg.dsuc,cg.dcaja,cg.factura,_vp.nombre as proveedor,cg.total,cg.fecha,1 as tipo " & _
        " from cga cg inner join v_proveedor _vp on cg.idProveedor=_vp.idProveedor" & where

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
                    listarConsultaCompra(" Where cg.idGasto Like '" & txtBuscar.Text & "%' Or cg.idGasto Like '" & txtBuscar.Text & "%' ")
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
            If txtIdGasto.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim intTmpIdGasto As Integer
            intTmpIdGasto = (CInt(txtIdGasto.Text))
            '---------------------------'
            '-- verificar los modulos --'
            '---------------------------'
            '*** compras
            banGl_buscarGastoProveedor = True
            '-- llevar a esa factura
            If intTipo = 0 Then
                '-- imp
                frmConsultaGasto.chkNoImpreso.Checked = False
                frmConsultaGasto.lblNoImpreso.Visible = False
            Else
                '-- noimp
                frmConsultaGasto.chkNoImpreso.Checked = True
                frmConsultaGasto.lblNoImpreso.Visible = True
            End If
            '-- la cabecera
            frmConsultaGasto.actualizarCabecera(CInt(txtIdGasto.Text))
            '-- el detalle
            frmConsultaGasto.listarDetalle(CInt(txtIdGasto.Text))
            'MsgBox("Valor de idCompra  " & (CInt(txtIdCompra.Text)))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    Private Sub lvCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompra.SelectedIndexChanged
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvCompra.SelectedItems
            txtIdGasto.Text = item.SubItems(0).Text
            intTipo = CInt(item.SubItems(7).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarGastoProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        banGl_consultaGastoProveedor = False

        frmConsultaGasto.Enabled = True
        frmConsultaGasto.Show()
        frmConsultaGasto.BringToFront()

    End Sub
    '--------------------------------------------------------------------------------------------------
End Class