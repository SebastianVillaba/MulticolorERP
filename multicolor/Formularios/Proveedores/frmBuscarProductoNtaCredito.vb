Public Class frmBuscarProductoNtaCredito
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarNotaCredito As New sp_cargarNotaCredito
    Dim intCodigoProducto As Integer
    Dim datVence As Date
    Dim strLote As String
    Dim douCantidad As Double
    Dim douBonificacion As Double
    Dim douCosto As Double
    Dim strForma As String
    Dim strNombreProducto As String
    Dim douPorcentajeImpuesto As Double
    Dim douFactorImpuesto As Double
    Dim intIdStock As Integer
    Dim intIdImpuesto As Integer
    Dim douPrecio As Double

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarProductoCompra(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvProducto, "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION)," & _
        "L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,(Dc.subtotal/dc.cantidad),DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO," & _
        "s.idstock,DC.IDIMPUESTO,dc.cantfrac FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON " & _
        "CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO " &
        "INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO AND S.IDLOTE=DC.IDLOTE " & _
        "AND S.IDDEPOSITO=DC.IDDEPOSITO " & where & _
        " union " & _
        "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,(Dc.subtotal/dc.cantidad),DC.PRECIO," & _
        "DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO,s.idstock,DC.IDIMPUESTO,dc.cantfrac " & _
        " FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA inner join cabProductoRef cp on cp.idProducto=dc.idProducto " & _
        " inner join detProductoRef dp on dp.idProductoRef=cp.idProductoRef INNER JOIN PRODUCTO P ON P.IDPRODUCTO=cp.IDPRODUCTO INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE " & _
        " INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=dp.IDPRODUCTO and s.idDeposito=dc.idDeposito " & where)

        txtSql.Text = "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION)," & _
        "L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,(Dc.subtotal/dc.cantidad),DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO," & _
        "s.idstock,DC.IDIMPUESTO,dc.cantfrac FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON " & _
        "CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO " &
        "INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO AND S.IDLOTE=DC.IDLOTE " & _
        "AND S.IDDEPOSITO=DC.IDDEPOSITO " & where & _
        " union " & _
        "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,(Dc.subtotal/dc.cantidad),DC.PRECIO," & _
        "DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO,s.idstock,DC.IDIMPUESTO,dc.cantfrac " & _
        " FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA inner join cabProductoRef cp on cp.idProducto=dc.idProducto " & _
        " inner join detProductoRef dp on dp.idProductoRef=cp.idProductoRef INNER JOIN PRODUCTO P ON P.IDPRODUCTO=cp.IDPRODUCTO INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE " & _
        " INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=dp.IDPRODUCTO and s.idDeposito=dc.idDeposito " & where

    End Sub

    Public Sub listarProductoCompraNoImp(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvProducto, "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD," & _
        "DC.BONIFICACION,dc.costodes,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO,s.idstock," & _
        "DC.IDIMPUESTO,dc.cantfrac FROM CCO CC INNER JOIN DCO DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE " & _
        "INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA " & _
        "inner join stock s on s.idProducto=dC.idProducto and s.idLote=dc.idLote and s.idDeposito=dc.idDeposito " & where)
        txtSql.Text = "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD," & _
        "DC.BONIFICACION,dc.costodes,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO,s.idstock," & _
        "DC.IDIMPUESTO,dc.cantfrac FROM CCO CC INNER JOIN DCO DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE " & _
        "INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA " & _
        "inner join stock s on s.idProducto=dC.idProducto and s.idLote=dc.idLote and s.idDeposito=dc.idDeposito " & where
    End Sub

    Private Sub listarConsulta(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvProducto, "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO," & _
        "L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.subtotal/dc.cantidad,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO," & _
        "S.IDSTOCK,DC.IDIMPUESTO,p.codigoBarra FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN " & _
        " LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON " & _
        " CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO AND S.IDLOTE=DC.IDLOTE AND S.IDDEPOSITO=DC.IDDEPOSITO " & where & " UNION SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,dc.porcentajeImpuesto,DC.FACTORIMPUESTO,0,DC.IDIMPUESTO,p.codigoBarra FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA WHERE DC.IDCOMPRA=47 AND CONVERT(VARCHAR,DC.IDPRODUCTO)+'-'+CONVERT(VARCHAR,DC.IDLOTE)+'-'+CONVERT(VARCHAR,DC.IDDEPOSITO) NOT IN (SELECT CONVERT(VARCHAR,S.IDPRODUCTO)+'-'+CONVERT(VARCHAR,S.IDLOTE)+'-'+CONVERT(VARCHAR,S.IDDEPOSITO) FROM STOCK S)")
        'txtSql.Text = "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO," & _
        '"L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,dc.porcentajeImpuesto," & _
        '"DC.FACTORIMPUESTO,S.IDSTOCK,DC.IDIMPUESTO,p.codigoBarra FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN " & _
        '" LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON " & _
        '" CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO AND S.IDLOTE=DC.IDLOTE AND S.IDDEPOSITO=DC.IDDEPOSITO " & where & " UNION SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,dc.porcentajeImpuesto,DC.FACTORIMPUESTO,0,DC.IDIMPUESTO FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA WHERE DC.IDCOMPRA=47 AND CONVERT(VARCHAR,DC.IDPRODUCTO)+'-'+CONVERT(VARCHAR,DC.IDLOTE)+'-'+CONVERT(VARCHAR,DC.IDDEPOSITO) NOT IN (SELECT CONVERT(VARCHAR,S.IDPRODUCTO)+'-'+CONVERT(VARCHAR,S.IDLOTE)+'-'+CONVERT(VARCHAR,S.IDDEPOSITO) FROM STOCK S)"
    End Sub

    Private Sub listarConsultaNoImp(ByVal where As String)
        systemClass.SqlToLv_consultaCompra(lvProducto, "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION," & _
                                           " DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,DC.PORCENTAJEIMPUESTO,DC.FACTORIMPUESTO,s.idStock,DC.IDIMPUESTO,p.codigoBarra FROM CCO CC " & _
                                           " INNER JOIN DCO DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P " & _
                                           " ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO " & _
                                           " AND S.IDLOTE=DC.IDLOTE AND S.IDDEPOSITO=DC.IDDEPOSITO " & where)
        txtSql.Text = "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION," & _
                                           " DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,dc.porcentajeImpuesto,DC.FACTORIMPUESTO,0,DC.IDIMPUESTO,p.codigoBarra FROM CCO CC " & _
                                           " INNER JOIN DCO DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P " & _
                                           " ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO " & _
                                           " AND S.IDLOTE=DC.IDLOTE AND S.IDDEPOSITO=DC.IDDEPOSITO " & where
        'txtSql.Text = "SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO," & _
        '"L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,dc.porcentajeImpuesto," & _
        '"DC.FACTORIMPUESTO,S.IDSTOCK,DC.IDIMPUESTO,p.codigoBarra FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN " & _
        '" LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON " & _
        '" CF.IDFORMA=DC.IDFORMA INNER JOIN STOCK S ON S.IDPRODUCTO=DC.IDPRODUCTO AND S.IDLOTE=DC.IDLOTE AND S.IDDEPOSITO=DC.IDDEPOSITO " & where & " UNION SELECT P.CODIGO,RTRIM(P.NOMBREPRODUCTO)+','+LTRIM(P.PRESENTACION),L.VENCIMIENTO,L.LOTE,CF.NOMBREFORMA,DC.CANTIDAD,DC.BONIFICACION,DC.COSTODES,DC.PRECIO,DC.SUBTOTAL,DC.IDCOMPRA,dc.porcentajeImpuesto,DC.FACTORIMPUESTO,0,DC.IDIMPUESTO FROM CABCOMPRA CC INNER JOIN DETCOMPRA DC ON CC.IDCOMPRA=DC.IDCOMPRA INNER JOIN LOTE L ON L.IDLOTE=DC.IDLOTE INNER JOIN PRODUCTO P ON P.IDPRODUCTO=DC.IDPRODUCTO INNER JOIN CABFORMA CF ON CF.IDFORMA=DC.IDFORMA WHERE DC.IDCOMPRA=47 AND CONVERT(VARCHAR,DC.IDPRODUCTO)+'-'+CONVERT(VARCHAR,DC.IDLOTE)+'-'+CONVERT(VARCHAR,DC.IDDEPOSITO) NOT IN (SELECT CONVERT(VARCHAR,S.IDPRODUCTO)+'-'+CONVERT(VARCHAR,S.IDLOTE)+'-'+CONVERT(VARCHAR,S.IDDEPOSITO) FROM STOCK S)"
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
                    Dim intTmpIdProducto As Integer
                    '-- buscar por el codigo del producto
                    'MsgBox("Valor de idProducto  " & intTmpIdProducto)
                    If chkImp.Checked = False Then
                        '-- IMP
                        intTmpIdProducto = sp_datosTabla.consulta_valor("select p.idProducto from detCompra dc inner join producto p on dc.idProducto=p.idProducto " & _
                                                                      " where dc.idCompra=" & txtIdCompra.Text & " and p.codigo='" & txtBuscar.Text & "'")
                        If intTmpIdProducto > 0 Then
                            '-- el codigo interno
                            listarConsulta(" Where cc.idCompra=" & txtIdCompra.Text & " and p.codigo=" & txtBuscar.Text)
                        Else
                            '-- el codigo de barra
                            intTmpIdProducto = sp_datosTabla.consulta_valor("select p.idProducto from detCompra dc inner join producto p on dc.idProducto=p.idProducto " & _
                                                                          " where dc.idCompra=" & txtIdCompra.Text & " and p.codigoBarra='" & txtBuscar.Text & "'")
                            'txtSql.Text = "select p.idProducto from detCompra dc inner join producto p on dc.idProducto=p.idProducto " & _
                            '                                             " where dc.idCompra=" & txtIdCompra.Text & " and p.codigoBarra='" & txtBuscar.Text & "'"

                            'MsgBox("Valor de idProducto  " & intTmpIdProducto)
                            listarConsulta(" Where cc.idCompra=" & txtIdCompra.Text & " and p.codigoBarra='" & txtBuscar.Text & "'")
                            If intTmpIdProducto = 0 Then
                                '-- si no encuentra el producto
                                listarConsulta(" Where cc.idCompra=" & txtIdCompra.Text & " and p.codigo=" & 0)
                            End If
                        End If
                    Else
                        '-- NO IMP
                        intTmpIdProducto = sp_datosTabla.consulta_valor("select p.idProducto from dco dc inner join producto p on dc.idProducto=p.idProducto " & _
                                                                      " where dc.idCompra=" & txtIdCompra.Text & " and p.codigo='" & txtBuscar.Text & "'")

                        If intTmpIdProducto > 0 Then
                            '-- el codigo interno
                            listarConsultaNoImp(" Where cc.idCompra=" & txtIdCompra.Text & " and p.codigo=" & txtBuscar.Text)
                        Else
                            '-- el codigo de barra
                            intTmpIdProducto = sp_datosTabla.consulta_valor("select p.idProducto from dco dc inner join producto p on dc.idProducto=p.idProducto " & _
                                                                          " where dc.idCompra=" & txtIdCompra.Text & " and p.codigoBarra='" & txtBuscar.Text & "'")
                            'txtSql.Text = "select p.idProducto from detCompra dc inner join producto p on dc.idProducto=p.idProducto " & _
                            '                                             " where dc.idCompra=" & txtIdCompra.Text & " and p.codigoBarra='" & txtBuscar.Text & "'"

                            'MsgBox("Valor de idProducto  " & intTmpIdProducto)
                            listarConsultaNoImp(" Where cc.idCompra=" & txtIdCompra.Text & " and p.codigoBarra='" & txtBuscar.Text & "'")
                            If intTmpIdProducto = 0 Then
                                '-- si no encuentra el producto
                                listarConsultaNoImp(" Where cc.idCompra=" & txtIdCompra.Text & " and p.codigo=" & 0)
                            End If
                        End If
                    End If


                Else
                    '-- buscar por el nombre del producto
                    ' Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%'
                    'mess("Valor del objeto  " & txtBuscar.Text)
                    If chkImp.Checked = False Then
                        '-- IMP
                        listarConsulta(" Where cc.idCompra=" & txtIdCompra.Text & " and  p.nombreProducto like '" & txtBuscar.Text & "%' and p.nombreProducto like '" & txtBuscar.Text & "%'")
                    Else
                        '-- NO IMP
                        listarConsultaNoImp(" Where cc.idCompra=" & txtIdCompra.Text & " and  p.nombreProducto like '" & txtBuscar.Text & "%' and p.nombreProducto like '" & txtBuscar.Text & "%'")
                    End If

                End If
            End If
            If txtBuscar.Text.Length = 0 Then
                '-- listar todo de vuelta si no se ingresó ningun dato
                If chkImp.Checked = False Then
                    '-- IMP
                    listarConsulta(" Where cc.idCompra=" & txtIdCompra.Text)
                Else
                    '-- NO IMP
                    listarConsultaNoImp(" Where cc.idCompra=" & txtIdCompra.Text)
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
            Dim intTmpIdCompra As Integer
            intTmpIdCompra = (CInt(txtIdCompra.Text))
            '-- solo si se pocisiona sobre un registro
            If txtIdProducto.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '-- controlar si ya está en la grilla
            If CInt(sp_datosTabla.consulta_valor("select dn.nro from detNotaCreditoTmp dn inner join stock s on dn.idStock=s.idStock where dn.idStock=" & intIdStock & " and idConfig=" & intGl_idConfigPc)) > 0 Then
                MessageBox.Show("Ya cargó este producto en la Grilla de la Nota de Crédito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Dim intTmpIdDeposito As Integer = 0
            Dim intTmpCantfrac As Integer = 0
            Dim intTmpIdLote As Integer = 0
            Dim intTmpIdProducto As Integer = 0
            Dim intTmpIdForma As Integer = 0

            '-- idProducto
            intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "producto", "codigo", intCodigoProducto)
            '-- idLote
            intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from lote where vencimiento=" & "'" & datVence & "'" & " and lote=" & "'" & strLote & "'")


            If chkImp.Checked = True Then
                '--- no impresa

                intTmpIdDeposito = sp_datosTabla.un_dato_integer("idDeposito", "dco", "idCompra", intTmpIdCompra)
                '-- cantfrac
                intTmpCantfrac = sp_datosTabla.consulta_valor("select cantfrac from dco where idLote=" & intTmpIdLote & " and idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito & " and idCompra=" & CInt(txtIdCompra.Text))
            Else
                '-- impresa

                intTmpIdDeposito = sp_datosTabla.un_dato_integer("idDeposito", "detCompra", "idCompra", intTmpIdCompra)
                '-- cantfrac
                intTmpCantfrac = sp_datosTabla.consulta_valor("select cantfrac from detCompra where idLote=" & intTmpIdLote & " and idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito & " and idCompra=" & CInt(txtIdCompra.Text))
            End If
            '-- sumar la variable publica de nro de item
            intGl_nroNotaCredito = intGl_nroNotaCredito + 1
            '-- idForma
            intTmpIdForma = CInt(sp_datosTabla.un_datoString("idForma", "cabForma", "nombreForma", strForma))

            frmNotaCreditoProveedor.txtSql.Text = "select idStock from stock where idLote=" & intTmpIdLote & " and idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito
            '*****************************************'
            '-- procedimiento para cargar la grilla --'
            '*****************************************'
            cargarNotaCredito(intGl_nroNotaCredito, intCodigoProducto, strNombreProducto, strForma, douCosto, strLote, datVence, douPorcentajeImpuesto, douCantidad, douBonificacion, intIdStock, douPrecio, intTmpCantfrac)
            '*************************************************************'
            '-- actualizar la cabecera de la factura de compra afectada --'
            '*************************************************************'
            Dim intTmpTipo As Integer
            If chkImp.Checked = True Then
                intTmpTipo = 1
            Else
                intTmpTipo = 0
            End If
            frmNotaCreditoProveedor.actualizarCabeceraCompra(CInt(txtIdCompra.Text), intTmpTipo)

            '-----------------------------------------------'
            '--- CARGAR EL DETALLE DE LA NOTA DE CREDITO ---'
            '-----------------------------------------------'
            'MsgBox("Valor del porcentaje del impuesto  " & douPorcentajeImpuesto)
            'sp_cargarNotaCredito.agregarDetNotaCreditoTmp(intGl_idConfigPc, intGl_nroNotaCredito, intTmpIdStock, intTmpIdForma, intIdImpuesto, 0, intTmpCantfrac, douBonificacion, douCosto, douPrecio, douFactorImpuesto, douPorcentajeImpuesto)


            '-- habilitar los botones
            frmNotaCreditoProveedor.btnAgregar.Enabled = True
            frmNotaCreditoProveedor.btnCancelar.Enabled = True
            frmNotaCreditoProveedor.btnGuardar.Enabled = True
            frmNotaCreditoProveedor.btnNuevo.Enabled = False
            frmNotaCreditoProveedor.btnEliminar.Enabled = True


            Me.Close()
            frmNotaCreditoProveedor.Enabled = True
            frmNotaCreditoProveedor.Show()
            frmNotaCreditoProveedor.BringToFront()
        End If
    End Sub

    Private Sub lvProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProducto.SelectedIndexChanged
        '-- mostrar el id compra
        For Each item As ListViewItem In lvProducto.SelectedItems
            intCodigoProducto = item.SubItems(0).Text
            datVence = item.SubItems(2).Text
            strLote = item.SubItems(3).Text
            strNombreProducto = item.SubItems(1).Text
            strForma = item.SubItems(4).Text
            douCantidad = item.SubItems(5).Text
            douBonificacion = item.SubItems(6).Text
            douCosto = item.SubItems(7).Text
            txtIdProducto.Text = item.SubItems(10).Text
            douPorcentajeImpuesto = item.SubItems(11).Text
            'MsgBox("Valor del porcentaje de impuesto  " & item.SubItems(11).Text)
            douFactorImpuesto = item.SubItems(12).Text
            intIdStock = item.SubItems(13).Text
            intIdImpuesto = item.SubItems(14).Text
            douPrecio = item.SubItems(8).Text

        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarProductoNtaCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmNotaCreditoProveedor.Enabled = True
        frmNotaCreditoProveedor.Show()
        frmNotaCreditoProveedor.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------

End Class