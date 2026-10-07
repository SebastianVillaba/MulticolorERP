Public Class frmBuscarProductoDevolucion
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarNotaCredito As New sp_cargarNotaCredito
    Dim intCodigoProducto As Integer
    Dim datVence As Date
    Dim strLote As String
    Dim douCantidad As Double
    Dim intCantfrac As Integer
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

    Public Sub listarProductoVenta(ByVal where As String)
        systemClass.SqlToLv_consultaVenta(lvProducto, "select p.codigo,rtrim(p.nombreProducto)+'.'+ltrim(p.presentacion),l.vencimiento,l.lote,cf.nombreForma,(dv.subTotal/dv.cantidad) as precioDescuento,dv.cantidad, dv.subtotal, dv.idVenta,dv.porcentajeImpuesto,dv.factorImpuesto,dv.idStock,dv.idImpuesto,dv.precio,dv.cantfrac,dv.costo from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta inner join stock s on s.idStock=dv.idSTock inner join lote l on l.idlote=s.idlote inner join producto p on p.idProducto=s.idProducto inner join cabForma cf on cf.idForma=dv.idForma " & where)
        'txtSql.Text = "select p.codigo,rtrim(p.nombreProducto)+'.'+ltrim(p.presentacion),l.vencimiento,l.lote,cf.nombreForma,dv.precioDescuento,dv.cantidad, dv.subtotal, dv.idVenta,dv.porcentajeImpuesto,dv.factorImpuesto,dv.idStock,dv.idImpuesto,dv.precio from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta inner join stock s on s.idStock=dv.idSTock inner join lote l on l.idlote=s.idlote inner join producto p on p.idProducto=s.idProducto inner join cabForma cf on cf.idForma=dv.idForma " & where
    End Sub

    Private Sub listarConsulta(ByVal where As String)
        systemClass.SqlToLv_consultaVenta(lvProducto, "select p.codigo,rtrim(p.nombreProducto)+'.'+ltrim(p.presentacion),l.vencimiento,l.lote,cf.nombreForma,dv.precioDescuento,dv.cantidad, dv.subtotal, dv.idVenta,dv.porcentajeImpuesto,dv.factorImpuesto,dv.idStock,dv.idImpuesto,dv.precio,dv.cantfrac,dv.costo from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta inner join stock s on s.idStock=dv.idSTock inner join lote l on l.idlote=s.idlote inner join producto p on p.idProducto=s.idProducto inner join cabForma cf on cf.idForma=dv.idForma " & where)
        'txtSql.Text = "select p.codigo,rtrim(p.nombreProducto)+'.'+ltrim(p.presentacion),l.vencimiento,l.lote,cf.nombreForma,dv.precioDescuento,dv.cantidad, dv.subtotal, dv.idVenta,dv.porcentajeImpuesto,dv.factorImpuesto,dv.idStock,dv.idImpuesto,dv.precio from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta inner join stock s on s.idStock=dv.idSTock inner join lote l on l.idlote=s.idlote inner join producto p on p.idProducto=s.idProducto inner join cabForma cf on cf.idForma=dv.idForma " & where
    End Sub

    Private Sub lvProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim intTmpIdVenta As Integer
            Dim intTmpIdProducto As Integer

            intTmpIdVenta = (CInt(txtIdVenta.Text))
            '-- solo si se pocisiona sobre un registro
            If txtIdStock.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '-- controlar si ya está en la grilla
            If CInt(sp_datosTabla.consulta_valor("select dn.nro from detNotaDebitoTmp dn inner join stock s on dn.idStock=s.idStock where dn.idStock=" & intIdStock & _
                                                 " and idConfig=" & intGl_idConfigPc & " and cantfrac=" & intCantfrac)) > 0 Then
                MessageBox.Show("Ya cargó este producto en la Grilla de la Nota de Crédito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            '-- sumar la variable publica de nro de item
            ' intGl_nroNotaDebito = intGl_nroNotaDebito + 1

            '-- idForma
            Dim intTmpIdForma As Integer = 0
            intTmpIdForma = CInt(sp_datosTabla.un_datoString("idForma", "cabForma", "nombreForma", strForma))

            'frmNotaCreditoProveedor.txtSql.Text = "select idStock from stock where idLote=" & intTmpIdLote & " and idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito
            '*****************************************'
            '-- procedimiento para cargar la grilla --'
            '*****************************************'
            'cargarNotaDebito(intGl_nroNotaDebito, intCodigoProducto, strNombreProducto, strForma, strLote, datVence, douPrecio, douPorcentajeImpuesto, douCantidad)
            '*************************************************************'
            '-- actualizar la cabecera de la factura de compra afectada --'
            '*************************************************************'
            frmDevolucionVenta.actualizarCabeceraVenta(CInt(txtIdVenta.Text))

            '-----------------------------------------------'
            '--- CARGAR EL DETALLE DE LA NOTA DE CREDITO ---'
            '-----------------------------------------------'
            'MsgBox("Valor del porcentaje del impuesto  " & douPorcentajeImpuesto)
            'sp_cargarNotaCredito.agregarDetNotaCreditoTmp(intGl_idConfigPc, intGl_nroNotaCredito, intTmpIdStock, intTmpIdForma, intIdImpuesto, 0, intTmpCantfrac, douBonificacion, douCosto, douPrecio, douFactorImpuesto, douPorcentajeImpuesto)
            'sp_datosTabla.sp_string("sp_agregarDetNotaDebitoTmp", intGl_idConfigPc & "," & intGl_nroNotaDebito & "," & intIdStock & "," & intTmpIdForma & "," & intIdImpuesto & "," & douPorcentajeImpuesto & "," & douFactorImpuesto & "," & 0 & "," & intCantfrac & "," & douPrecio & "," & douCosto & "," & 0)
            '-- datos de la mercaderia
            frmDevolucionVenta.lblIdStock.Text = CInt(txtIdStock.Text)
            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from stock where idSTock=" & CInt(txtIdStock.Text))
            frmDevolucionVenta.lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intTmpIdProducto)
            frmDevolucionVenta.lblMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & intTmpIdProducto)
            frmDevolucionVenta.lblForma.Text = sp_datosTabla.consulta_valorString("select nombreForma from cabForma where idForma=" & intTmpIdForma)
            frmDevolucionVenta.lblCantfrac.Text = intCantfrac
            frmDevolucionVenta.txtCantidad.Text = douCantidad


            '-- habilitar los botones
            frmDevolucionVenta.btnAgregar.Enabled = True
            frmDevolucionVenta.btnCancelar.Enabled = True
            frmDevolucionVenta.btnGuardar.Enabled = True
            frmDevolucionVenta.btnNuevo.Enabled = False
            frmDevolucionVenta.btnEliminar.Enabled = True
            frmDevolucionVenta.btnCargar.Enabled = True
            frmDevolucionVenta.txtCantidad.ReadOnly = False
            frmDevolucionVenta.txtCantidad.BackColor = Color.White

            Me.Close()
            frmDevolucionVenta.Enabled = True
            frmDevolucionVenta.Show()
            frmDevolucionVenta.BringToFront()
            frmDevolucionVenta.txtCantidad.Focus()
        End If
    End Sub

    Private Sub lvProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProducto.SelectedIndexChanged
        '-- mostrar el id compra
        For Each item As ListViewItem In lvProducto.SelectedItems
            txtIdStock.Text = item.SubItems(11).Text

            intCodigoProducto = item.SubItems(0).Text
            datVence = item.SubItems(2).Text
            strLote = item.SubItems(3).Text
            strNombreProducto = item.SubItems(1).Text
            strForma = item.SubItems(4).Text
            douCantidad = item.SubItems(6).Text
            douPrecio = item.SubItems(5).Text
            douPorcentajeImpuesto = item.SubItems(9).Text
            'MsgBox("Valor del porcentaje de impuesto  " & item.SubItems(11).Text)
            douFactorImpuesto = item.SubItems(10).Text
            intIdStock = item.SubItems(11).Text
            intIdImpuesto = item.SubItems(12).Text
            intCantfrac = item.SubItems(14).Text
            douCosto = item.SubItems(15).Text
        Next
    End Sub

    Private Sub frmBuscarProductoDevolucion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmDevolucionVenta.Enabled = True
        frmDevolucionVenta.Show()
        frmDevolucionVenta.BringToFront()
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '-- ver el metodo de busqueda
                If IsNumeric(txtBuscar.Text) Then
                    '-- buscar por el codigo del producto
                    listarConsulta(" Where cv.idVenta=" & txtIdVenta.Text & " and p.codigo=" & txtBuscar.Text)
                Else
                    '-- buscar por el nombre del producto
                    ' Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%'
                    listarConsulta(" Where cv.idVenta=" & txtIdVenta.Text & " and  p.nombreProducto like '" & txtBuscar.Text & "%' and p.nombreProducto like '" & txtBuscar.Text & "%'")
                End If
            End If
            If txtBuscar.Text.Length = 0 Then
                '-- listar todo de vuelta si no se ingresó ningun dato
                listarConsulta(" Where cv.idVenta=" & txtIdVenta.Text)
            End If
            lvProducto.Focus()
        End If
    End Sub

End Class