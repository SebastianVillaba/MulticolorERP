Public Class frmBuscarNotaCreditoProveedor
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intTipo As Integer
    Dim intIdNotaCredito As Integer
    Dim intIdMoneda As Integer
    Dim intIdProveedor As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv_ventaBusqueda(lvBuscar, "select cn.idNotaCredito,cn.dSuc,cn.dCaja,cn.factura,_vp.nombre as Proveedor," & _
                                          " [maxifarmasa].[dbo].[funTotalNotaCredito] (cn.idNotaCredito),cn.fechaAlta " & _
                                          " from cabNotaCredito cn inner join cabCompra cc" & _
                                          " on cn.idCompra=cc.idCompra inner join v_proveedor _vp" & _
                                          " on cc.idProveedor=_vp.idProveedor " & where)
        'txtSql.Text = "select cv.idVenta,cv.dSuc,cv.dCaja,cv.factura,cv.cliente,cv.totalVenta,cv.fechaAlta,1 as tipo " & _
        '                    " from cabventa cv " & where & " union " & _
        '                    " select cv.idVenta,cv.dSuc,cv.dCaja,cv.factura,cv.cliente,cv.totalVenta,cv.fechaAlta,2 as tipo" & _
        '                    " from cve cv " & where
    End Sub

    Private Sub controlarModulo()
        If banGl_buscarNotaCredito = True Then
            notaCredito()
        End If
    End Sub

    Private Sub notaCredito()
        '-- listar el detalle
        frmConsultaNotaCredito.listarDetalleNotaCredito(CInt(txtIdMov.Text))
        '-- los datos
        frmConsultaNotaCredito.actualizarCabeceraNota(CInt(txtIdMov.Text))
        '------------------------------------------------------------
        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- por proveedor
                listar(" Where _vp.nombre Like '" & txtBuscar.Text & "%' Or _vp.nombre Like '" & txtBuscar.Text & "%' ")
            Else
                '-- por opcion de busqueda
                '-- por idNotaCredito
                listar(" Where cn.idNotaCredito=" & txtBuscar.Text)
            End If
            lvBuscar.Focus()
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

    Private Sub txtFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- por factura
            listar(" Where cn.dsuc=" & txtDsuc.Text & " and cn.dcaja=" & txtDcaja.Text & " and cn.factura=" & txtFactura.Text)
            lvBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If IsNumeric(txtIdMov.Text) Then
            If txtIdMov.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    intIdNotaCredito = txtIdMov.Text

                    controlarModulo()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If e.KeyChar = ChrW(Keys.Escape) Then
                txtBuscar.Focus()
            End If
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtIdMov.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdIdNota_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdIdNota.CheckedChanged
        If rdIdNota.Checked = True Then
            '-- activar txtBuscar
            txtBuscar.Visible = True
            txtBuscar.Text = ""
            txtBuscar.Focus()
            '-- desactivar la factura
            txtDsuc.Visible = False
            txtDcaja.Visible = False
            txtFactura.Visible = False
        End If
    End Sub

    Private Sub rdFactura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdFactura.CheckedChanged
        If rdFactura.Checked = True Then
            '-- desactivar txtBuscar
            txtBuscar.Visible = False
            '-- activar la factura
            txtDsuc.Visible = True
            txtDcaja.Visible = True
            txtFactura.Visible = True
            txtDsuc.Text = ""
            txtDcaja.Text = ""
            txtFactura.Text = ""
            txtDsuc.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmBuscarBuscarVenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        If banGl_buscarNotaCredito = True Then
            banGl_buscarNotaCredito = False

            frmConsultaNotaCredito.Enabled = True
            frmConsultaNotaCredito.Show()
            frmConsultaNotaCredito.BringToFront()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
End Class