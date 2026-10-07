Public Class frmBuscarVenta
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intTipo As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listar(ByVal where As String)
        If Len(txtBuscar.Text) < 44 Then
            systemClass.SqlToLv_ventaBusqueda(lvBuscar, "select cv.idVenta,cv.dSuc,cv.dCaja,cv.factura,cv.cliente,cv.totalVenta,cv.fechaAlta,1 as tipo,nombreObra" & _
                                " from cabventa cv " & where & " union " & _
                                " select cv.idVenta,cv.dSuc,cv.dCaja,cv.factura,cv.cliente,cv.totalVenta,cv.fechaAlta,2 as tipo,''" & _
                                " from cve cv " & where)
            txtSql.Text = "select cv.idVenta,cv.dSuc,cv.dCaja,cv.factura,cv.cliente,cv.totalVenta,cv.fechaAlta,1 as tipo,nombreObra" & _
                                " from cabventa cv " & where & " union " & _
                                " select cv.idVenta,cv.dSuc,cv.dCaja,cv.factura,cv.cliente,cv.totalVenta,cv.fechaAlta,2 as tipo,''" & _
                                " from cve cv " & where
        Else
            '-- buscar por el cdc
            systemClass.SqlToLv_ventaBusqueda(lvBuscar, "select cv.idVenta,cv.dSuc,cv.dCaja,cv.factura,cv.cliente,cv.totalVenta,cv.fechaAlta,1 as tipo,cv.nombreObra " & _
                    " from cabventa cv inner join detVentaDTE dv on cv.idVenta=dv.idVenta" & where)

        End If

    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                If rdIdVenta.Checked Then
                    '-- por cliente
                    listar(" Where cv.cliente Like '" & txtBuscar.Text & "%' Or cv.cliente Like '" & txtBuscar.Text & "%' ")
                End If
                If rdObra.Checked Then
                    '-- por obra
                    listar(" Where cv.nombreObra Like '" & txtBuscar.Text & "%' Or cv.nombreObra Like '" & txtBuscar.Text & "%' ")
                End If

            Else
                '-- por opcion de busqueda
                If Len(txtBuscar.Text) < 44 Then
                    '-- por Venta
                    listar(" Where cv.idVenta=" & txtBuscar.Text)
                Else
                    '-- por cdc
                    listar(" Where dv.cdc='" & txtBuscar.Text & "'")
                End If

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
            listar(" Where cv.dsuc=" & txtDsuc.Text & " and cv.dcaja=" & txtDcaja.Text & " and cv.factura=" & txtFactura.Text)
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
                    '-- listar el detalle
                    frmConsultaVenta.listarDetalle(CInt(txtIdMov.Text), intTipo)
                    '-- los datos
                    frmConsultaVenta.actualizarCabecera(CInt(txtIdMov.Text), intTipo)
                    If intTipo = 1 Then
                        '-- imp
                        frmConsultaVenta.chkNoImpreso.Checked = False
                        frmConsultaVenta.lblNoImpreso.Visible = False
                    Else
                        '-- no imp
                        frmConsultaVenta.chkNoImpreso.Checked = True
                        frmConsultaVenta.lblNoImpreso.Visible = True
                    End If
                    '------------------------------------------------------------
                    Me.Close()
                    frmConsultaVenta.Enabled = True
                    frmConsultaVenta.Show()
                    frmConsultaVenta.BringToFront()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Pedido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtIdMov.Text = CInt(item.SubItems(0).Text)
            intTipo = CInt(item.SubItems(7).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdIdVenta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdIdVenta.CheckedChanged
        If rdIdVenta.Checked = True Then
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
        frmConsultaVenta.Enabled = True
        frmConsultaVenta.Show()
        frmConsultaVenta.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------

End Class