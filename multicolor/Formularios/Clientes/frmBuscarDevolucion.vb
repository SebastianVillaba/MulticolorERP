Public Class frmBuscarDevolucion
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        InitializeComponent()
    End Sub

    '--------------------'
    '-- PROCEDIMIENTOS --'
    '--------------------'
    Private Sub listarConsultaDevolucion(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvDevolucion, "select cn.idNotaDebito,cn.dsuc,cn.dcaja,cn.factura,cv.cliente,cn.total,cn.fecha from cabNotaDebito cn inner join cabVenta cv on cv.idVenta=cn.idVenta " & where)
    End Sub
    '----------------------------------------------------------------------------------------------
    '-----------------'
    '-- RADIOBUTTON --'
    '-----------------'
    Private Sub rdFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdFactura.CheckedChanged
        txtDcaja.Visible = True
        txtDcaja.Text = ""
        txtDsuc.Visible = True
        txtDsuc.Text = ""
        txtFactura.Visible = True
        txtFactura.Text = ""
        txtBuscar.Visible = False
    End Sub

    Private Sub rdCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdCliente.CheckedChanged
        txtDcaja.Visible = False
        txtDsuc.Visible = False
        txtFactura.Visible = False
        txtBuscar.Visible = True
        txtBuscar.Text = ""
    End Sub
    '----------------------------------------------------------------------------------------------
    '--------------'
    '-- TEXTBOX  --'
    '--------------'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '-- controlar la primera letra ingresada
                If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                    '-- ordenar por idCompra
                    listarConsultaDevolucion(" Where cn.activo=1 and idNotaDebito Like '" & txtBuscar.Text & "%' Or idNotaDebito Like '" & txtBuscar.Text & "%' " & "order by idNotaDebito")
                Else
                    ' ordenar por nombre del cliente
                    listarConsultaDevolucion(" Where cn.activo=1 and cv.cliente Like '" & txtBuscar.Text & "%' Or cv.cliente Like '" & txtBuscar.Text & "%' " & " order by cv.cliente")
                End If
            End If
            lvDevolucion.Focus()
        End If

    End Sub

    Private Sub txtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtFactura.Text.Length > 0 Then
                '-- ordenar por factura
                listarConsultaDevolucion(" Where cn.activo=1 and cn.dsuc Like '" & txtDsuc.Text & "%' and cn.dcaja Like '" & txtDcaja.Text & "%' and cn.factura Like '" & txtFactura.Text & "%' " & "order by cn.idNotaDebito")
                lvDevolucion.Focus()
            End If
        End If
    End Sub

    Private Sub txtDsuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDcaja.Focus()
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtFactura.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------
    '---------------'
    '-- LISTVIEW  --'
    '---------------'
    Private Sub lvDevolucion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvDevolucion.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then

            '-- solo si se pocisiona sobre un registro
            If txtIdNota.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            Dim intTmpIdNota As Integer
            intTmpIdNota = (CInt(txtIdNota.Text))
            '---------------------------'
            '-- verificar los modulos --'
            '---------------------------'
            If banGl_buscarNotaDebito = True Then
                'MsgBox("paso por la consulta", MsgBoxStyle.Information)
                '*** nota de credito
                banGl_buscarNotaDebito = False
                '-- llevar a esa factura
                '-- la cabecera
                frmConsultaDevolucionVenta.actualizarCabeceraNota(CInt(txtIdNota.Text))
                '-- el detalle
                frmConsultaDevolucionVenta.listarDetalleNotaCredito(CInt(txtIdNota.Text))
                'MsgBox("Valor de idCompra  " & (CInt(txtIdCompra.Text)))
                '------------------------------------------------------------
                Me.Close()
                frmConsultaDevolucionVenta.Enabled = True
                frmConsultaDevolucionVenta.Show()
                frmConsultaDevolucionVenta.BringToFront()
            End If
        End If
    End Sub

    Private Sub lvDevolucion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDevolucion.SelectedIndexChanged
        '-- mostrar el id de la nota de debito
        For Each item As ListViewItem In lvDevolucion.SelectedItems
            txtIdNota.Text = item.SubItems(0).Text
        Next
    End Sub
    '----------------------------------------------------------------------------------------------
    '-----------------'
    '-- FORMULARIO  --'
    '-----------------'
    Private Sub frmBuscarDevolucion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaDevolucionVenta.Enabled = True
        frmConsultaDevolucionVenta.Show()
        frmConsultaDevolucionVenta.BringToFront()
    End Sub

End Class