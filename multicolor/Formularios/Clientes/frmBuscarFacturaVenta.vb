Public Class frmBuscarFacturaVenta
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarConsultaVenta(ByVal where As String)
        If rdImpreso.Checked = True Then
            '-- para los impresos
            systemClass.SqlToLv_consultaVentaFactura(lvVenta, "select cv.idVenta,cv.dsuc,cv.dcaja,cv.factura,cv.cliente,cv.totalVenta as total," & _
                                            "cv.fecha,_vs.nombreFantasia as sucursal from cabVenta cv inner join v_sucursalT _vs" & _
                                            " on cv.idSucursal=_vs.idSucursal" & where)
            txtSql.Text = "select cv.idVenta,cv.dsuc,cv.dcaja,cv.factura,cv.cliente,cv.totalVenta as total," & _
                                                        "cv.fecha,_vs.nombreFantasia as sucursal from cabVenta cv inner join v_sucursalT _vs" & _
                                                        " on cv.idSucursal=_vs.idSucursal" & where

        End If
        If rdNoImpreso.Checked = True Then
            '-- para los no impresos
            systemClass.SqlToLv_consultaVentaFactura(lvVenta, "select cv.idVenta,cv.dsuc,cv.dcaja,cv.factura,cv.cliente,cv.totalVenta as total," & _
                                            "cv.fecha,_vs.nombreFantasia as sucursal from cve cv inner join v_sucursalT _vs" & _
                                            " on cv.idSucursal=_vs.idSucursal" & where)
        End If

        'txtSql.Text = "select cv.idVenta,cv.dsuc,cv.dcaja,cv.factura,cv.cliente,cv.totalVenta as total,cv.fecha from cabVenta cv " & where
    End Sub

    '------------------------------------------------------------------------------------------------------------------
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
        txtDsuc.Focus()
    End Sub

    Private Sub rdCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdCliente.CheckedChanged
        txtDcaja.Visible = False
        txtDsuc.Visible = False
        txtFactura.Visible = False
        txtBuscar.Visible = True
        txtBuscar.Text = ""
        txtBuscar.Focus()
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '-- controlar la primera letra ingresada
                If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                    '-- ordenar por idVenta
                    listarConsultaVenta(" Where cv.idVenta=" & txtBuscar.Text)
                Else
                    If rdCliente.Checked = True Then
                        ' ordenar por nombre del cliente
                        listarConsultaVenta(" Where (cv.cliente Like '" & txtBuscar.Text & "%' Or cv.cliente Like '" & txtBuscar.Text & "%')")
                    End If
                    If rdObra.Checked = True Then
                        ' ordenar por obra
                        listarConsultaVenta(" Where (cv.nombreObra Like '" & txtBuscar.Text & "%' Or cv.nombreObra Like '" & txtBuscar.Text & "%') order by cv.nombreObra")
                    End If

                End If
            End If
            lvVenta.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Down) Then
            'MsgBox("Paso por aca")
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

    Private Sub txtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtFactura.Text.Length > 0 Then
                '-- ordenar por factura
                listarConsultaVenta(" Where cv.activo=1 and cv.dsuc Like '" & txtDsuc.Text & "%' and cv.dcaja Like '" & txtDcaja.Text & "%' and cv.factura Like '" & txtFactura.Text & "%' " & "order by cv.idVenta")
                lvVenta.Focus()
            End If
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvVenta.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdVenta.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            Dim intTmpIdVenta As Integer
            intTmpIdVenta = (CInt(txtIdVenta.Text))

            If banGl_notaDebito = True Then
                '-- verificar si la factura está anulada
                If sp_datosTabla.consulta_valorBoolean("select activo from cabVenta where idVenta=" & intTmpIdVenta) = False Then
                    MessageBox.Show("Esta Venta se encuentra anulada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                '-- controlar que no tenga nota de credito
                'frmBuscarProductoNtaCredito.txtSql.Text = "select activo from cabNotaCredito where activo=1 and idCompra=" & CInt(txtIdCompra.Text)
                If sp_datosTabla.consulta_valor("select activo from cabNotaDebito where activo=1 and idVenta=" & CInt(txtIdVenta.Text)) = True Then
                    MessageBox.Show("Esta Venta ya cuenta con una Nota de Crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- controlar que la devolucion se haga en la sucursal
                'Dim intTmpIdSucursalPc As Integer
                'intTmpIdSucursalPc = sp_datosTabla.consulta_valor("select _vs.idSucursal from configPc cp inner join deposito d " & _
                '" on cp.idDepositoVenta=d.idDeposito inner join v_sucursal _vs on _vs.idSucursal=d.idSucursal where cp.idConfig=" & intGl_idConfigPc)
                'If intTmpIdSucursalPc <> sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intTmpIdVenta) Then
                '    MessageBox.Show("Su PC no está configurada para esta Sucursal y no Corresponde..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
                '-----------------------------------------
                '** nota de credito
                '-- el idventa
                frmBuscarProductoDevolucion.txtIdVenta.Text = sp_datosTabla.un_dato_integer("idVenta", "cabVenta", "idVenta", intTmpIdVenta)
                '-- el cliente
                frmBuscarProductoDevolucion.txtCliente.Text = sp_datosTabla.un_datoString("cliente", "cabVenta", "idVenta", intTmpIdVenta)
                '-- dsuc
                frmBuscarProductoDevolucion.txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabVenta", "idVenta", intTmpIdVenta)
                '-- dcaja
                frmBuscarProductoDevolucion.txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabVenta", "idVenta", intTmpIdVenta)
                '-- factura
                frmBuscarProductoDevolucion.txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabVenta", "idVenta", intTmpIdVenta)
                '-- fecha de la factura
                frmBuscarProductoDevolucion.txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabVenta", "idVenta", intTmpIdVenta)
                '-- vendedor
                Dim intTmpIdVendedor As Integer = 0
                intTmpIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & intTmpIdVenta)
                'MsgBox("Valor de intTmpIdVendedor  " & intTmpIdVendedor)
                frmBuscarProductoDevolucion.txtVendedor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_vendedorT where idVendedor=" & intTmpIdVendedor)
                '-- fecha hora de carga
                frmBuscarProductoDevolucion.txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabVenta", "idVenta", intTmpIdVenta)

                '-- colocar la consulta
                frmBuscarProductoDevolucion.listarProductoVenta("where cv.idVenta=" & intTmpIdVenta)

                Me.Close()
                frmBuscarProductoDevolucion.Visible = True
                frmBuscarProductoDevolucion.Show()
                frmBuscarProductoDevolucion.BringToFront()
                frmBuscarProductoDevolucion.txtBuscar.Focus()
            End If
        End If
    End Sub

    Private Sub lvVenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVenta.SelectedIndexChanged
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvVenta.SelectedItems
            txtIdVenta.Text = item.SubItems(0).Text
        Next
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarFacturaVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_notaDebito = True Then
            frmDevolucionVenta.Enabled = True
            frmDevolucionVenta.Show()
            frmDevolucionVenta.BringToFront()
        End If
        'If banGl_notacreditoCompra = True Then
        ' e.Cancel = False
        ' frmNotaCreditoProveedor.Enabled = True
        ' frmNotaCreditoProveedor.Show()
        ' frmNotaCreditoProveedor.BringToFront()
        ' End If
    End Sub
    '------------------------------------------------------------------------------------------------------------------
End Class