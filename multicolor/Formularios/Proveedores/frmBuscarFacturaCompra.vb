Public Class frmBuscarFacturaCompra
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intTipo As Integer
    Dim intIdCompra As Integer
    Dim intIdMoneda As Integer
    Dim intIdProveedor As Integer

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarConsultaCompra(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvCompra, "select cc.idCompra,cc.dsuc,cc.dcaja,cc.factura,_vp.nombre as proveedor," & _
        " cc.total,cc.fecha,0 as tipo from cabcompra cc inner join v_proveedorT _vp on cc.idProveedor=_vp.idProveedor " & where & _
        " union " & _
        " select cc.idCompra,cc.dsuc,cc.dcaja,cc.factura,_vp.nombre as proveedor,cc.total,cc.fecha,1 as tipo " & _
        " from cco cc inner join v_proveedorT _vp on cc.idProveedor=_vp.idProveedor" & where)
        txtSql.Text = "select cc.idCompra,cc.dsuc,cc.dcaja,cc.factura,_vp.nombre as proveedor," & _
        " cc.total,cc.fecha,0 as tipo from cabcompra cc inner join v_proveedor _vp on cc.idProveedor=_vp.idProveedor " & where & _
        " union " & _
        " select cc.idCompra,cc.dsuc,cc.dcaja,cc.factura,_vp.nombre as proveedor,cc.total,cc.fecha,1 as tipo " & _
        " from cco cc inner join v_proveedor _vp on cc.idProveedor=_vp.idProveedor" & where

    End Sub

    Private Sub controlarModulo()
        If banGl_consultaCompra = True Then
            '*** compras
            consultaCompra()
        End If

        If banGl_notacreditoCompra = True Then
            '-- nota de credito
            notaCredito()
        End If
        If banGl_retencionProveedor = True Then
            '-- retencion del proveedor
            retencionProveedor()
        End If
        If banGl_devolucionCompra = True Then
            '-- devolucion de compra
            devolucionCompra()
        End If
        If banGl_notacreditoMonto = True Then
            '-- nota de credito por monto
            notaCreditoMonto()
        End If

    End Sub

    Private Sub consultaCompra()
        banGl_buscarFacturaCompra = True
        '-- llevar a esa factura
        If intTipo = 0 Then
            '-- imp
            frmConsultaCompra.chkNoImpreso.Checked = False
            frmConsultaCompra.lblNoImpreso.Visible = False
        Else
            '-- noimp
            frmConsultaCompra.chkNoImpreso.Checked = True
            frmConsultaCompra.lblNoImpreso.Visible = True
        End If
        '-- la cabecera
        frmConsultaCompra.actualizarCabeceraCompra(CInt(txtIdCompra.Text))
        '-- el detalle
        frmConsultaCompra.listarDetalleCompra(CInt(txtIdCompra.Text))
        'MsgBox("Valor de idCompra  " & (CInt(txtIdCompra.Text)))
        '------------------------------------------------------------
        Me.Close()
    End Sub

    Private Sub notaCredito()
        'frmBuscarProductoNtaCredito.txtSql.Text = "select activo from cabNotaCredito where activo=1 and idCompra=" & CInt(txtIdCompra.Text)
        If sp_datosTabla.consulta_valor("select activo from cabNotaCredito where activo=1 and idCompra=" & CInt(txtIdCompra.Text)) And (intTipo = 0) = True Then
            MessageBox.Show("Esta compra ya cuenta con una Nota de Crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- controlar que esta compra no esté pagada
        '-- fis
        If sp_datosTabla.consulta_valor("select pagado from cabCompra where activo=1 and idCompra=" & CInt(txtIdCompra.Text)) And (intTipo = 0) = True Then
            MessageBox.Show("Esta compra ya se encuentra pagada...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- nfis
        If sp_datosTabla.consulta_valor("select pagado from cco where activo=1 and idCompra=" & CInt(txtIdCompra.Text)) And (intTipo = 1) = True Then
            MessageBox.Show("Esta compra ya se encuentra pagada...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- que no esté anulada
        If sp_datosTabla.consulta_valor("select activo from cabCompra where idCompra=" & CInt(txtIdCompra.Text)) And (intTipo = 0) = False Then
            MessageBox.Show("Esta Compra se encuentra anulada...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-----------------------------------------
        '** nota de credito

        '-- colocar la consulta
        'MsgBox("Valor de intTipo " & intTipo)
        If intTipo = 0 Then
            '-- el idcompra
            frmBuscarProductoNtaCredito.txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", intIdCompra)
            '-- el proveedor
            frmBuscarProductoNtaCredito.txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cabcompra", "idCompra", intIdCompra))
            '-- dsuc
            frmBuscarProductoNtaCredito.txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabCompra", "idCompra", intIdCompra)
            '-- dcaja
            frmBuscarProductoNtaCredito.txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabCompra", "idCompra", intIdCompra)
            '-- factura
            frmBuscarProductoNtaCredito.txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabCompra", "idCompra", intIdCompra)
            '-- fecha de la factura
            frmBuscarProductoNtaCredito.txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabCompra", "idCompra", intIdCompra)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabCompra", "idCompra", intIdCompra)
            frmBuscarProductoNtaCredito.txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            frmBuscarProductoNtaCredito.txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabCompra", "idCompra", intIdCompra)
            frmBuscarProductoNtaCredito.chkImp.Checked = False
            frmBuscarProductoNtaCredito.listarProductoCompra("where cc.idCompra=" & intIdCompra)
        Else
            '-- no imp
            '-- el idcompra
            frmBuscarProductoNtaCredito.txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cco", "idCompra", intIdCompra)
            '-- el proveedor
            frmBuscarProductoNtaCredito.txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cco", "idCompra", intIdCompra))
            '-- dsuc
            frmBuscarProductoNtaCredito.txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cco", "idCompra", intIdCompra)
            '-- dcaja
            frmBuscarProductoNtaCredito.txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cco", "idCompra", intIdCompra)
            '-- factura
            frmBuscarProductoNtaCredito.txtFactura.Text = sp_datosTabla.un_datoString("factura", "cco", "idCompra", intIdCompra)
            '-- fecha de la factura
            frmBuscarProductoNtaCredito.txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cco", "idCompra", intIdCompra)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cco", "idCompra", intIdCompra)
            frmBuscarProductoNtaCredito.txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            frmBuscarProductoNtaCredito.txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cco", "idCompra", intIdCompra)
            frmBuscarProductoNtaCredito.chkImp.Checked = True
            frmBuscarProductoNtaCredito.listarProductoCompraNoImp("where cc.idCompra=" & intIdCompra)
        End If


        Me.Close()
        frmBuscarProductoNtaCredito.Visible = True
        frmBuscarProductoNtaCredito.Show()
        frmBuscarProductoNtaCredito.BringToFront()
        frmBuscarProductoNtaCredito.txtBuscar.Focus()
    End Sub

    Private Sub retencionProveedor()
        '-- el id
        frmRetencionProveedor.txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", intIdCompra)
        '-- el cliente
        frmRetencionProveedor.txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from cabcompra cc inner join v_proveedor _vp " & _
                                                " on cc.idProveedor=_vp.idProveedor where cc.idCompra=" & intIdCompra)
        '-- dsuc
        frmRetencionProveedor.txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabCompra", "idCompra", intIdCompra)
        '-- dcaja
        frmRetencionProveedor.txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabCompra", "idCompra", intIdCompra)
        '-- factura
        frmRetencionProveedor.txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabCompra", "idCompra", intIdCompra)
        '-- fecha de la factura
        frmRetencionProveedor.txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabCompra", "idCompra", intIdCompra)
        '-- fecha hora de carga
        frmRetencionProveedor.txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabVenta", "idVenta", intIdCompra)
        '-- el tipo de compra
        frmRetencionProveedor.lblTipoCompra.Text = sp_datosTabla.consulta_valorString("select _vt.nombreTipo from cabCompra cc inner join v_tipoCompra _vt " & _
                                                " on cc.idTipoCompra=_vt.idTipoCompra where cc.idCompra=" & intIdCompra)

        Me.Close()
    End Sub

    Private Sub devolucionCompra()
        '-- el id
        frmDevolucionCompra.txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", intIdCompra)
        '-- el proveedor
        frmDevolucionCompra.txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from cabcompra cc inner join v_proveedor _vp " & _
                                                " on cc.idProveedor=_vp.idProveedor where cc.idCompra=" & intIdCompra)
        '-- dsuc
        frmDevolucionCompra.txtFactura.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(factura) from " & _
                                                                                 " cabCompra where idCompra=" & intIdCompra)
        '-- fecha de la factura
        frmDevolucionCompra.txtFechaCompra.Text = sp_datosTabla.consulta_valorString("select convert(varchar,fecha,103) from cabCompra where idCompra=" & intIdCompra)

        frmDevolucionCompra.habilitarObjetos()
        frmDevolucionCompra.btnBuscar.Focus()
        Me.Close()
    End Sub

    Private Sub notaCreditoMonto()
        '-- el id
        frmNotaCreditoMontoProveedor.txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", intIdCompra)
        '-- el proveedor
        frmNotaCreditoMontoProveedor.txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from cabcompra cc inner join v_proveedor _vp " & _
                                                " on cc.idProveedor=_vp.idProveedor where cc.idCompra=" & intIdCompra)
        '-- dsuc
        frmNotaCreditoMontoProveedor.txtFactura.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(factura) from " & _
                                                                                 " cabCompra where idCompra=" & intIdCompra)
        '-- fecha de la factura
        frmNotaCreditoMontoProveedor.txtFechaFactura.Text = sp_datosTabla.consulta_valorString("select convert(varchar,fecha,103) from cabCompra where idCompra=" & intIdCompra)

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
                    listarConsultaCompra(" Where idCompra Like '" & txtBuscar.Text & "%' Or idCompra Like '" & txtBuscar.Text & "%' ")
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
            If txtIdCompra.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            intIdCompra = (CInt(txtIdCompra.Text))
            '---------------------------'
            '-- verificar los modulos --'
            '---------------------------'
            controlarModulo()
        End If
    End Sub

    Private Sub lvCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompra.SelectedIndexChanged
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvCompra.SelectedItems
            txtIdCompra.Text = item.SubItems(0).Text
            intTipo = CInt(item.SubItems(7).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarFacturaCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_consultaCompra = True Then
            banGl_consultaCompra = False

            frmConsultaCompra.Enabled = True
            frmConsultaCompra.Show()
            frmConsultaCompra.BringToFront()
        End If
        If banGl_notacreditoCompra = True Then
            banGl_notacreditoCompra = False

            frmNotaCreditoProveedor.Enabled = True
            frmNotaCreditoProveedor.Show()
            frmNotaCreditoProveedor.BringToFront()
        End If
        If banGl_retencionProveedor = True Then
            banGl_retencionProveedor = False

            frmRetencionProveedor.Enabled = True
            frmRetencionProveedor.Show()
            frmRetencionProveedor.BringToFront()
            frmRetencionProveedor.txtPorcentaje.Focus()
        End If
        If banGl_devolucionCompra = True Then
            banGl_devolucionCompra = False

            frmDevolucionCompra.Enabled = True
            frmDevolucionCompra.Show()
            frmDevolucionCompra.BringToFront()
        End If
        If banGl_notacreditoMonto = True Then
            banGl_notacreditoMonto = False

            frmNotaCreditoMontoProveedor.Enabled = True
            frmNotaCreditoMontoProveedor.Show()
            frmNotaCreditoMontoProveedor.BringToFront()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
End Class