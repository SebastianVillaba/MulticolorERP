Public Class frmBuscarProductoAjuste
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarProductos(ByVal v_parametro As String)
        If banGl_ajustePositivoMercaderia = True Then
            systemClass.SqlToLv_producto_busqueda(lvAjuste, "select * from v_stock" & intGl_ajustePositivoIdSucursal & v_parametro)
        End If
        If banGl_ajusteNegativoMercaderia = True Then
            systemClass.SqlToLv_producto_busqueda(lvAjuste, "select * from v_stock" & intGl_ajusteNegativoIdSucursal & v_parametro)
        End If

        ' txtSql.Text = "select * from v_stock" & intGl_ajustePositivoIdSucursal & v_parametro
    End Sub

    Private Sub controlarModulo()
        If banGl_ajustePositivoMercaderia = True Then
            '-- ajuste positivo
            ajustePositivoMercaderia(CInt(txtIdProducto.Text))
        End If
        If banGl_ajusteNegativoMercaderia = True Then
            '-- ajuste negativo
            ajusteNegativoMercaderia(CInt(txtIdProducto.Text))
        End If
    End Sub

    Private Sub ajustePositivoMercaderia(ByVal v_idProducto As Integer)
        '-- variables
        Dim intTmpIdLote As Integer
        Dim intTmpIdStock As Integer
        Dim strTmpCodigo As String
        '-- la variable publica del idproducto
        intGl_ajustePositivoIdProducto = v_idProducto
        '-- datos del producto
        strTmpCodigo = sp_datosTabla.un_datoString("codigo", "producto", "idProducto", Str(v_idProducto))
        frmAjustePositivoMercaderia.lblCodigoProducto.Text = strTmpCodigo
        frmAjustePositivoMercaderia.lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", Str(v_idProducto))) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", Str(v_idProducto)))
        frmAjustePositivoMercaderia.lblIdProductoPedido.Text = v_idProducto
        Dim intTmpIdLaboratorio As Integer
        intTmpIdLaboratorio = sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", v_idProducto)
        frmAjustePositivoMercaderia.txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", Str(intTmpIdLaboratorio))
        frmAjustePositivoMercaderia.txtTipoProducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", Str(v_idProducto))
        frmAjustePositivoMercaderia.txtOrigen.Text = sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", Str(v_idProducto))
        '-- la imagen de la mercaderia
        frmAjustePositivoMercaderia.PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", v_idProducto)

        '-- controlar si es un producto fraccionado
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", v_idProducto)) = True Then
            ' MsgBox("Es fraccionado..!")
            '-- producto fraccionado
            '-- activar la varibale global del fraccionado
            'MsgBox("Valor de la bandera  " & banGl_ajusteNegativoMercaderia)
            Me.Close()

            banGl_ajustePositivoMercaderia = True
            frmFraccionado.listar_busqueda(v_idProducto)
            frmFraccionado.Visible = True
            frmFraccionado.WindowState = FormWindowState.Normal
            frmFraccionado.Show()
            frmFraccionado.BringToFront()

        Else
            'MsgBox("No es fraccionado2..!")
            '----------------------------------
            '-- controlar si tiene varios lotes
            '----------------------------------
            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intGl_ajustePositivoIdDeposito, 1) = 99 Then
                'MsgBox("Entro al modulo de lote")
                '-- datos de la fraccion
                frmAjustePositivoMercaderia.txtFraccion.Text = "ENTERO"
                frmAjustePositivoMercaderia.lblCantidad.Text = 1
                frmAjustePositivoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", v_idProducto)
                '-- para varios lotes
                Me.Close()
                banGl_ajustePositivoMercaderia = True

                intGl_ajustePositivoIdProducto = v_idProducto
                frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", v_idProducto)
                frmLote.listar_busquedaTodosLotes(v_idProducto, intGl_ajustePositivoIdDeposito)
                '-- ocultar las columnas
                'frmFraccionado.lvFraccionado.Columns(5).Width = 0
                '---------------------------------
                frmLote.Visible = True
                frmLote.WindowState = FormWindowState.Normal
                frmLote.Show()
                frmLote.BringToFront()
            End If
            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intGl_ajustePositivoIdDeposito, 0) > 0 Then
                'MsgBox("Solo un lote")
                '-- para un lote
                '*******************'
                '- datos del stock -'
                '*******************'
                '-- datos de la fraccion
                frmAjustePositivoMercaderia.txtFraccion.Text = "ENTERO"
                frmAjustePositivoMercaderia.lblCantidad.Text = 1
                frmAjustePositivoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", v_idProducto)
                '-- efectivamente tiene un solo lote en el stock
                '-- traer el idlote
                intTmpIdLote = sp_datosTabla.un_dato_integer_consulta("idlote", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & frmAjustePositivoMercaderia.lblIdDeposito.Text)
                '-- traer el idStock
                intTmpIdStock = sp_datosTabla.un_dato_integer_consulta("idStock", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & frmAjustePositivoMercaderia.lblIdDeposito.Text)
                '-- traer el idstock
                frmAjustePositivoMercaderia.lblIdStock.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & frmAjustePositivoMercaderia.lblIdDeposito.Text)
                '-- traer 
                frmAjustePositivoMercaderia.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
                frmAjustePositivoMercaderia.maskVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
                '-- el precio del producto
                frmAjustePositivoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", v_idProducto)
                '-- el total del stock
                frmAjustePositivoMercaderia.txtStock.Text = sp_datosTabla.un_dato_double("cantidad", "stock", "idStock", intTmpIdStock)
                'frmAjustePositivoMercaderia.txtStock.Text = FormatNumber(frmAjustePositivoMercaderia.txtStock.Text, "##,##0.##")
                '-------------------------------------------------------------
                frmAjustePositivoMercaderia.btnAgregar.Enabled = True
                frmAjustePositivoMercaderia.txtCantidad.Focus()
                '-- volver al formulario del ajuste
                Me.Close()
                frmAjustePositivoMercaderia.Enabled = True
                frmAjustePositivoMercaderia.Show()
                frmAjustePositivoMercaderia.BringToFront()
                frmAjustePositivoMercaderia.txtCantidad.Focus()
            End If
            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intGl_ajustePositivoIdDeposito, 1) = 0 Then
                ' MsgBox("Sin stock")
                '-- para ningun lote y stock
                MessageBox.Show("No cuenta con Stock Inicial esta mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '-- datos de la fraccion
                frmAjustePositivoMercaderia.txtFraccion.Text = ""
                frmAjustePositivoMercaderia.lblCantidad.Text = 0
                frmAjustePositivoMercaderia.lblPrecio.Text = 0
                '-- traer el idstock
                frmAjustePositivoMercaderia.lblIdStock.Text = 0
                '-- traer 
                frmAjustePositivoMercaderia.txtLote.Text = ""
                frmAjustePositivoMercaderia.maskVence.Text = ""
                '-- el precio del producto
                frmAjustePositivoMercaderia.lblPrecio.Text = 0
                '-------------------------------------------------------------
                frmAjustePositivoMercaderia.btnAgregar.Enabled = False
                frmAjustePositivoMercaderia.txtProducto.Focus()
                '-- volver al formulario del ajuste
                banGl_ajustePositivoMercaderia = False
                Me.Close()
                frmAjustePositivoMercaderia.Enabled = True
                frmAjustePositivoMercaderia.Show()
                frmAjustePositivoMercaderia.BringToFront()
                frmAjustePositivoMercaderia.txtCantidad.Focus()
            End If
        End If
    End Sub

    Private Sub ajusteNegativoMercaderia(ByVal v_idProducto As Integer)
        '-- variables
        Dim intTmpIdLote As Integer
        Dim intTmpIdStock As Integer
        Dim strTmpCodigo As String
        '-- la variable publica del idproducto
        intGl_ajusteNegativoIdProducto = v_idProducto
        '-- datos del producto
        strTmpCodigo = sp_datosTabla.un_datoString("codigo", "producto", "idProducto", Str(v_idProducto))
        frmAjusteNegativoMercaderia.lblCodigoProducto.Text = strTmpCodigo
        frmAjusteNegativoMercaderia.lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", Str(v_idProducto))) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", Str(v_idProducto)))
        frmAjusteNegativoMercaderia.lblIdProductoPedido.Text = v_idProducto
        Dim intTmpIdLaboratorio As Integer
        intTmpIdLaboratorio = sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", v_idProducto)
        frmAjusteNegativoMercaderia.txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", Str(intTmpIdLaboratorio))
        frmAjusteNegativoMercaderia.txtTipoProducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", Str(v_idProducto))
        frmAjusteNegativoMercaderia.txtOrigen.Text = sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", Str(v_idProducto))
        '-- la imagen de la mercaderia
        frmAjusteNegativoMercaderia.PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", v_idProducto)
        '-- controlar si es un producto fraccionado
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", v_idProducto)) = True Then
            ' MsgBox("Es fraccionado..!")
            '-- producto fraccionado
            '-- activar la varibale global del fraccionado
            ' MsgBox("Valor de la bandera  " & banGl_ajusteNegativoMercaderia)
            Me.Close()
            banGl_ajusteNegativoMercaderia = True
            frmFraccionado.listar_busqueda(v_idProducto)
            frmFraccionado.Visible = True
            frmFraccionado.WindowState = FormWindowState.Normal
            frmFraccionado.Show()
            frmFraccionado.BringToFront()

        Else
            'MsgBox("No es fraccionado2..!")
            '----------------------------------
            '-- controlar si tiene varios lotes
            '----------------------------------
            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intGl_ajusteNegativoIdDeposito, 1) = 99 Then
                'MsgBox("Entro al modulo de lote")
                '-- datos de la fraccion
                frmAjusteNegativoMercaderia.txtFraccion.Text = "ENTERO"
                frmAjusteNegativoMercaderia.lblCantidad.Text = 1
                frmAjusteNegativoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", v_idProducto)
                '-- para varios lotes
                Me.Close()
                banGl_ajusteNegativoMercaderia = True

                frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", v_idProducto)
                frmLote.listar_busquedaDeposito(v_idProducto, intGl_ajusteNegativoIdDeposito)
                '-- ocultar las columnas
                'frmFraccionado.lvFraccionado.Columns(5).Width = 0
                '---------------------------------
                frmLote.Visible = True
                frmLote.WindowState = FormWindowState.Normal
                frmLote.Show()
                frmLote.BringToFront()
            End If
            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intGl_ajusteNegativoIdDeposito, 0) > 0 Then
                '-- para un lote
                '*******************'
                '- datos del stock -'
                '*******************'
                '-- datos de la fraccion
                frmAjusteNegativoMercaderia.txtFraccion.Text = "ENTERO"
                frmAjusteNegativoMercaderia.lblCantidad.Text = 1
                frmAjusteNegativoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", v_idProducto)
                '-- efectivamente tiene un solo lote en el stock
                '-- traer el idlote
                intTmpIdLote = sp_datosTabla.un_dato_integer_consulta("idlote", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text)
                '-- traer el idStock
                intTmpIdStock = sp_datosTabla.un_dato_integer_consulta("idStock", "stock", "idProducto=" & v_idProducto & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text)
                'cargarAjusteNegativoMercaderia(intGl_nroAjusteNegativoMercaderia,
                '-- traer el idstock
                frmAjusteNegativoMercaderia.lblIdStock.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text)
                '-- traer el stock
                frmAjusteNegativoMercaderia.txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & frmAjusteNegativoMercaderia.lblIdDeposito.Text))
                frmAjusteNegativoMercaderia.txtStock.Text = Format(CDbl(frmAjusteNegativoMercaderia.txtStock.Text), "##,##0.##")
                '-- traer 
                frmAjusteNegativoMercaderia.txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intTmpIdLote)
                frmAjusteNegativoMercaderia.maskVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intTmpIdLote)
                '-- el precio del producto
                frmAjusteNegativoMercaderia.lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", v_idProducto)
                '-------------------------------------------------------------
                frmAjusteNegativoMercaderia.btnAgregar.Enabled = True
                frmAjusteNegativoMercaderia.txtCantidad.Focus()
                '-- volver al formulario del ajuste
                banGl_ajusteNegativoMercaderia = False
                Me.Close()
                frmAjusteNegativoMercaderia.Enabled = True
                frmAjusteNegativoMercaderia.Show()
                frmAjusteNegativoMercaderia.BringToFront()
                frmAjusteNegativoMercaderia.txtCantidad.Focus()
            End If
            If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", v_idProducto & "," & intGl_ajusteNegativoIdDeposito, 1) = 0 Then
                ' MsgBox("Sin stock")
                '-- para ningun lote y stock
                MessageBox.Show("No cuenta con Stock Inicial esta mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '-- datos de la fraccion
                frmAjusteNegativoMercaderia.txtFraccion.Text = ""
                frmAjusteNegativoMercaderia.lblCantidad.Text = 0
                frmAjusteNegativoMercaderia.lblPrecio.Text = 0
                '-- traer el idstock
                frmAjusteNegativoMercaderia.lblIdStock.Text = 0
                '-- traer 
                frmAjusteNegativoMercaderia.txtLote.Text = ""
                frmAjusteNegativoMercaderia.maskVence.Text = ""
                '-- el precio del producto
                frmAjusteNegativoMercaderia.lblPrecio.Text = 0
                '-------------------------------------------------------------
                frmAjusteNegativoMercaderia.btnAgregar.Enabled = False
                frmAjusteNegativoMercaderia.txtProducto.Focus()
                '-- volver al formulario del ajuste
                banGl_ajusteNegativoMercaderia = False
                Me.Close()
                frmAjusteNegativoMercaderia.Enabled = True
                frmAjusteNegativoMercaderia.Show()
                frmAjusteNegativoMercaderia.BringToFront()
                frmAjusteNegativoMercaderia.txtCantidad.Focus()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------
    '------------------'
    '-- LOS LISTVIEW --'
    '------------------'
    Private Sub lvAjuste_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvAjuste.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdProducto.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvAjuste_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAjuste.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvAjuste.SelectedItems
            txtIdProducto.Text = item.SubItems(0).Text
        Next
    End Sub
    '----------------------------------------------------------------------------
    '-------------'
    '-- LOS TXT --'
    '-------------'
    Private Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        txtIdProducto.Text = 0
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '- si se ingreso en blanco, volver a cargar el listview y ordenar por nombre
                If txtBuscar.Text.Length > 0 Then
                    '-- controlar la primera letra ingresada
                    If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                        '-- controlar la manera de buscar
                        If (txtBuscar.Text.Length) = 6 Then
                            ' ordenar por el codigo del producto
                            listarProductos(" Where codigo Like '" & txtBuscar.Text & "%' Or codigo Like '" & txtBuscar.Text & "%' " & "order by codigo")
                        Else
                            '-- ordenar por codigo de barra
                            listarProductos(" Where codigoBarra Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%' " & "order by codigoBarra")
                        End If

                    Else
                        ' ordenar por nombre del producto
                        listarProductos(" Where mercaderia Like '" & txtBuscar.Text & "%' Or mercaderia Like '" & txtBuscar.Text & "%' " & " order by 3")
                        'listar(" Where mercaderia Like '" & txtBuscar.Text & "%' Or mercaderia Like '" & txtBuscar.Text & "%' " & " order by 3")
                    End If
                Else
                    ' ordenar por nombre del producto
                    listarProductos(" Where mercaderia Like '" & txtBuscar.Text & "%' Or mercaderia Like '" & txtBuscar.Text & "%' " & " order by 3")
                End If
                e.Handled = True
                SendKeys.Send("{tab}")
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------
    '----------------'
    '-- FORMULARIO --'
    '----------------'  
    Private Sub frmBuscarProductoAjuste_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- ver de donde fue llamado el formulario
        e.Cancel = False
        '-- para el ajuste positivo
        If banGl_ajustePositivoMercaderia = True Then
            banGl_ajustePositivoMercaderia = False
            frmAjustePositivoMercaderia.Enabled = True
            frmAjustePositivoMercaderia.Show()
            frmAjustePositivoMercaderia.BringToFront()
        End If
        '-- para el ajuste negativo
        If banGl_ajusteNegativoMercaderia = True Then
            banGl_ajusteNegativoMercaderia = False
            frmAjusteNegativoMercaderia.Enabled = True
            frmAjusteNegativoMercaderia.Show()
            frmAjusteNegativoMercaderia.BringToFront()
        End If
    End Sub
    '----------------------------------------------------------------------------
End Class