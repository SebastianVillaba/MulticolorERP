Public Class frmBuscarMercaderiaProveedor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdStock As Integer = 0
    Dim intIdCompra As Integer = 0

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listar(ByVal where As String)
        systemClass.SqlToLv_consultaDetalleMercaderiaCompraProveedor(lvProducto, "select p.codigo,RTRIM(p.nombreProducto)+','+RTRIM(p.presentacion)+'-'+RTRIM(ma.nombreMarca),dc.costoMoneda," & _
                                           "cc.idCompra,RTRIM(cc.dsuc)+'-'+RTRIM(cc.dcaja)+'-'+RTRIM(cc.factura),cc.fecha,s.idStock" & _
                                           " from cabCompra cc inner join detCompra dc on cc.idCompra=dc.idCompra inner join producto p on p.idProducto=dc.idProducto" & _
                                           " inner join marca ma on ma.idMarca=p.idMarca inner join stock s on s.idProducto=dc.idProducto and s.idLote=dc.idLote" & _
                                           " and s.idDeposito=dc.idDeposito" & where)
        'txtSql.Text = "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,s.idstock,DC.IDCOMPRA,dc.porcentajeImpuesto,DC.FACTORIMPUESTO,DC.IDIMPUESTO FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO AND S.IDLOTE=DC.IDLOTE AND S.IDDEPOSITO=DC.IDDEPOSITO " & where & " UNION SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,s.idstock,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO,DC.IDIMPUESTO FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA inner join cabProductoRef cp on cp.idProducto=dc.idProducto inner join detProductoRef dp on dp.idProductoRef=cp.idProductoRef inner join stock s on s.idProducto=dp.idProducto and s.idLote=dc.idLote and s.idDeposito=dc.idDeposito " & where
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    '********-'
    '-- TXT --'
    '********-'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '-- ver el metodo de busqueda
                If IsNumeric(txtBuscar.Text) Then
                    '-- buscar por el codigo del producto
                    listar(" Where (p.codigo like '" & txtBuscar.Text & "%' and p.codigo like '" & txtBuscar.Text & "%') and cc.idProveedor=" & txtIdProveedor.Text)
                Else
                    '-- buscar por el nombre del producto
                    listar(" Where (p.nombreProducto like '" & txtBuscar.Text & "%' and p.nombreProducto like '" & txtBuscar.Text & "%') and cc.idProveedor=" & txtIdProveedor.Text & " order by p.nombreProducto")
                End If
            End If
            lvProducto.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If intIdCompra = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            '*************************************************************'
            '-- actualizar la cabecera de la factura de compra afectada --'
            '*************************************************************'
            Dim intTmpIdUsuario As Integer = 0
            Dim intTmpIdMoneda As Integer = 0
            Dim intTmpIdTipoCompra As Integer = 0

            frmNotaCreditoMontoProveedor.txtIdCompra.Text = 0
            frmNotaCreditoMontoProveedor.txtDsuc.Text = sp_datosTabla.consulta_valorString("select dsuc from cabCompra where idcompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.txtDcaja.Text = sp_datosTabla.consulta_valorString("select dcaja from cabCompra where idcompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.txtFactura.Text = sp_datosTabla.consulta_valorString("select factura from cabCompra where idcompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.txtFechaFactura.Text = sp_datosTabla.consulta_valorString("select fecha from cabCompra where idcompra=" & intIdCompra)
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabCompra where idCompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.txtResponsableCarga.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
            frmNotaCreditoMontoProveedor.txtFechaHora.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabCompra where idcompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.txtTotalFactura.Text = sp_datosTabla.consulta_valorDouble("select total from cabCompra where idcompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.txtTotalDescuento.Text = 0
            frmNotaCreditoMontoProveedor.txtTotalFactura.Text = Format(CDec(frmNotaCreditoMontoProveedor.txtTotalFactura.Text), "###,###,##0.##")
            intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cabCompra where idCompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.lblMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIdMoneda)
            frmNotaCreditoMontoProveedor.lblCotiza.Text = sp_datosTabla.consulta_valorDouble("select cotizacion from cabCompra where idcompra=" & intIdCompra)
            intTmpIdTipoCompra = sp_datosTabla.consulta_valor("select idTipoCompra from cabCompra where idCompra=" & intIdCompra)
            frmNotaCreditoMontoProveedor.lblTipoCompra.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoCompra where idTipoCompra=" & intTmpIdTipoCompra)

            '-- cargar la tabla temporal
            If (fun_guardarSp("sp_agregarDetNotaCreditoMontoTmp", intGl_idConfigPc & "," & intIdCompra & "," & intIdStock, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo cargar la mercadería...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                frmNotaCreditoMontoProveedor.listarDetalleNota()
                frmNotaCreditoMontoProveedor.sumarTotal()
                Me.Close()
            End If


        End If
    End Sub

    Private Sub lvProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProducto.SelectedIndexChanged
        '-- mostrar el id compra
        For Each item As ListViewItem In lvProducto.SelectedItems
            intIdCompra = item.SubItems(3).Text
            intIdStock = item.SubItems(6).Text
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarMercaderiaProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        frmNotaCreditoMontoProveedor.Enabled = True
        frmNotaCreditoMontoProveedor.Show()
        frmNotaCreditoMontoProveedor.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
End Class