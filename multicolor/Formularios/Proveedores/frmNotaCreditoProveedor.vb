Public Class frmNotaCreditoProveedor
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarNotaCredito As New sp_cargarNotaCredito

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        sp_datosTabla.consulta_valor("delete from detNotaCreditoTmp where idConfig=" & intGl_idConfigPc)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        txtDcaja.Text = ""
        txtDsuc.Text = ""
        txtFactura.Text = ""
        txtFechaFactura.Text = ""
        txtFechaHora.Text = ""
        txtIdCompra.Text = 0
        txtIva10.Text = 0
        txtIva5.Text = 0
        txtProveedor.Text = ""
        txtResponsableCarga.Text = ""
        txtTotalDescuento.Text = 0
        txtTotalFactura.Text = 0
        txtTotalIva.Text = 0
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnEliminar.Enabled = False
        btnNuevo.Enabled = True
        '-- limpiar la tabla temporal de la base de datos
        sp_datosTabla.consulta_valor("delete detNotaCreditoTmp where idConfig=" & intGl_idConfigPc)
        '-- limpiar la grilla
        dtgNotaCredito.Rows.Clear()
        '-- la cabecera de la nota de credito
        chkPendiente.Checked = False
        txtDsucN.Enabled = True
        txtDsucN.BackColor = Color.White
        txtDsucN.Text = ""
        txtDcaja.Enabled = True
        txtDcajaN.BackColor = Color.White
        txtDcajaN.Text = ""
        txtFacturaN.Enabled = True
        txtFacturaN.BackColor = Color.White
        txtFacturaN.Text = ""
        txtTimbradoN.Enabled = True
        txtTimbradoN.BackColor = Color.White
        txtTimbradoN.Text = ""
        txtResponsable.Text = ""
        maskFecha.Text = ""
        txtIva10.Text = 0
        txtIva5.Text = 0
        txtTotalIva.Text = 0
        txtTotalNotaCredito.Text = 0

    End Sub

    Public Sub actualizarCabeceraCompra(ByVal v_idcompra As Integer, ByVal v_tipo As Integer)
        If v_tipo = 0 Then
            '-- imp
            chkImp.Checked = False
            '-- el idcompra
            txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", v_idcompra)
            '-- el proveedor
            txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cabcompra", "idCompra", v_idcompra))
            '-- dsuc
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabCompra", "idCompra", v_idcompra)
            '-- dcaja
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabCompra", "idCompra", v_idcompra)
            '-- factura
            txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabCompra", "idCompra", v_idcompra)
            '-- fecha de la factura
            txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabCompra", "idCompra", v_idcompra)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabCompra", "idCompra", v_idcompra)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabCompra", "idCompra", v_idcompra)
            '-- total compra
            txtTotalFactura.Text = sp_datosTabla.un_dato_double("total", "cabCompra", "idCompra", v_idcompra)
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
            '-- total descuento
            txtTotalDescuento.Text = sp_datosTabla.sp_string("sp_totalDescuentoCompra", v_idcompra)
            If txtTotalDescuento.Text = "" Then
                txtTotalDescuento.Text = 0
            Else
                txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,###.00")
            End If
            '-- la moneda
            lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cabCompra", "idCompra", v_idcompra))
            '-- la cotizacion
            lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cabCompra", "idCompra", v_idcompra)
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
            '-- tipo de compra
            lblTipoCompra.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoCompra", "idTipoCompra", sp_datosTabla.un_dato_integer("idTipoCompra", "cabCompra", "idCompra", v_idcompra))
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabCompra", "idCompra", v_idcompra))
        Else
            '-- no imp
            chkImp.Checked = True
            '-- el idcompra
            txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cco", "idCompra", v_idcompra)
            '-- el proveedor
            txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cco", "idCompra", v_idcompra))
            '-- dsuc
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cco", "idCompra", v_idcompra)
            '-- dcaja
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cco", "idCompra", v_idcompra)
            '-- factura
            txtFactura.Text = sp_datosTabla.un_datoString("factura", "cco", "idCompra", v_idcompra)
            '-- fecha de la factura
            txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cco", "idCompra", v_idcompra)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cco", "idCompra", v_idcompra)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cco", "idCompra", v_idcompra)
            '-- total compra
            txtTotalFactura.Text = sp_datosTabla.un_dato_double("total", "cco", "idCompra", v_idcompra)
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
            '-- total descuento
            txtTotalDescuento.Text = sp_datosTabla.sp_string("sp_totalDescuentoCompra", v_idcompra)
            If txtTotalDescuento.Text = "" Then
                txtTotalDescuento.Text = 0
            Else
                txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,##0.##")
            End If
            '-- la moneda
            lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cco", "idCompra", v_idcompra))
            '-- la cotizacion
            lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cco", "idCompra", v_idcompra)
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
            '-- tipo de compra
            lblTipoCompra.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoCompra", "idTipoCompra", sp_datosTabla.un_dato_integer("idTipoCompra", "cco", "idCompra", v_idcompra))
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cco", "idCompra", v_idcompra))
        End If


    End Sub

    Private Sub sumarTotal()
        Dim intTmpNroLinea As Integer = 0
        Dim douTmpSubTotal As Double = 0
        Dim douTmpIva5 As Double = 0
        Dim douTmpIva10 As Double = 0
        Dim douTmpTotalIva As Double = 0
        For i As Integer = 0 To dtgNotaCredito.Rows.Count - 1
            intTmpNroLinea = intTmpNroLinea + 1
            '-- realizar los calculos solo si existem items cargados
            If dtgNotaCredito.Rows(i).Cells(0).Value > 0 Then
                '-- el subtotal
                douTmpSubTotal = douTmpSubTotal + (dtgNotaCredito.Rows(i).Cells(4).Value * dtgNotaCredito.Rows(i).Cells(10).Value)
                '-- el factor
                Dim douTmpFactorImpuesto As Double = 0
                douTmpFactorImpuesto = sp_datosTabla.un_dato_double("factorImpuesto", "impuesto", "porcentajeImpuesto", (dtgNotaCredito.Rows(i).Cells(7).Value))

                '-- para el iva de 5%
                If CInt(dtgNotaCredito.Rows(i).Cells(7).Value) = 5 Then
                    douTmpIva5 = douTmpIva5 + ((dtgNotaCredito.Rows(i).Cells(4).Value * dtgNotaCredito.Rows(i).Cells(10).Value) / ((douTmpFactorImpuesto * 10) * 2))
                    douTmpTotalIva = douTmpTotalIva + douTmpIva5
                End If
                '-- para el iva de 10%
                If CInt(dtgNotaCredito.Rows(i).Cells(7).Value) = 10 Then
                    douTmpIva10 = douTmpIva10 + ((dtgNotaCredito.Rows(i).Cells(4).Value * dtgNotaCredito.Rows(i).Cells(10).Value) / ((douTmpFactorImpuesto * 10)))
                    douTmpTotalIva = douTmpTotalIva + douTmpIva10
                End If

            End If
        Next
        '-- total del iva
        txtIva5.Text = douTmpIva5
        txtIva5.Text = Format(CDec(txtIva5.Text), "#,###,###.00")
        txtIva10.Text = douTmpIva10
        txtIva10.Text = Format(CDec(txtIva10.Text), "#,###,###.00")
        txtTotalIva.Text = douTmpTotalIva
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "#,###,###.00")
        '---- total de la nota de credito
        txtTotalNotaCredito.Text = douTmpSubTotal
        txtTotalNotaCredito.Text = Format(CDec(txtTotalNotaCredito.Text), "#,###,###.00")
    End Sub

    Private Sub controlarNotaCredito()
        '-- variables
        Dim intTmpNro As Integer
        Dim intTmpIdProducto As Integer
        Dim intTmpIdProducto1 As Integer
        Dim intTmpIdstock As Integer
        Dim intTmpIdForma As Integer
        Dim intTmpIdImpuesto As Integer
        Dim douTmpCantidad As Double
        Dim intTmpCantfrac As Integer
        Dim intTmpBoni As Integer
        Dim douTmpCosto As Double
        Dim douTmpPrecio As Double
        Dim douTmpFactorImpuesto As Double
        Dim douTmpPorcentajeImpuesto As Double
        Dim douTmpSubtotal As Double

        '-- controlar que se ingrese un proveedor
        If txtProveedor.Text = "" Then
            MessageBox.Show("Debe Ingresar un Proveedor para realizar la Nota de Crédito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- que se ingrese un total
        If txtTotalNotaCredito.Text = "" Then
            MessageBox.Show("El Total de la Nota de Crédito no es válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- si no existen item cargados
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgNotaCredito.Rows.Count - 1
            If dtgNotaCredito.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
                '-- controlar la cantidad
                If (dtgNotaCredito.Rows(i).Cells(10).Value > dtgNotaCredito.Rows(i).Cells(8).Value) Or (dtgNotaCredito.Rows(i).Cells(10).Value <= 0) Then
                    MessageBox.Show("La cantidad ingresada no es válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- controlar la boinificacion
                If (dtgNotaCredito.Rows(i).Cells(11).Value > dtgNotaCredito.Rows(i).Cells(9).Value) Or (dtgNotaCredito.Rows(i).Cells(11).Value < 0) Then
                    MessageBox.Show("La bonificación ingresada no es válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        Next
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existen items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- si no se ingresa el responsable
        If txtResponsable.Text = "" Then
            MessageBox.Show("Debe ingresar el Responsable de la Nota de Crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Dim strTmpFecha As String = ""
        '-- si no es pendiente
        If chkPendiente.Checked = False Then
            '-- solo los numericos y de tres lugares
            If Not IsNumeric(txtDsucN.Text) Then
                MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtDsucN.Focus()
                Exit Sub
            End If
            If txtDsucN.Text.Length <> 3 Then
                MessageBox.Show("Debe introducir solo tres dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtDsucN.Focus()
                Exit Sub
            End If
            '-- solo los numericos y de tres lugares
            If Not IsNumeric(txtDcajaN.Text) Then
                MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtDcajaN.Focus()
                Exit Sub
            End If
            If txtDcajaN.Text.Length <> 3 Then
                MessageBox.Show("Debe introducir solo tres dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtDcajaN.Focus()
            End If
            '-- solo los numericos y de siete lugares
            If Not IsNumeric(txtFacturaN.Text) Then
                MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtFacturaN.Focus()
                Exit Sub
            End If
            If txtFacturaN.Text.Length <> 7 Then
                MessageBox.Show("Debe introducir solo siete dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtFacturaN.Focus()
                Exit Sub
            End If
            '-- que se ingrese la factura
            If txtDsucN.Text = "" Then
                MessageBox.Show("Debe Introducir el primer digito de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If txtDcajaN.Text = "" Then
                MessageBox.Show("Debe introducir el segundo digito de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If txtFacturaN.Text = "" Then
                MessageBox.Show("Debe introducir el nro de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '-- el timbrado
            If txtTimbradoN.Text = "" Then
                MessageBox.Show("Debe introducir el nro de timbardo de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtTimbradoN.Focus()
                Exit Sub
            End If
            If Not IsNumeric(txtTimbradoN.Text) Then
                MessageBox.Show("Debe Introducir solo numeros en el Timbrado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtTimbradoN.Focus()
                Exit Sub
            End If
            '-- la fecha de la nota de credito
            strTmpFecha = maskFecha.Text
        Else
            strTmpFecha = "01/01/1900"
        End If

        '-- pitar todos los registros en negro
        For i As Integer = 0 To dtgNotaCredito.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If dtgNotaCredito.Rows(i).Cells(0).Value > 0 Then
                dtgNotaCredito.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next


        '-- eliminar todos los anteriores registros de la tabla temporal
        sp_datosTabla.consulta_valor("delete from detNotaCreditoTmp where idConfig=" & intGl_idConfigPc)
        For i As Integer = 0 To dtgNotaCredito.Rows.Count - 1
            If dtgNotaCredito.Rows(i).Cells(0).Value > 0 Then
                '-----------------------------------------------'
                '--- CARGAR EL DETALLE DE LA NOTA DE CREDITO ---'
                '-----------------------------------------------'
                '-- dar valor a las variables
                intTmpNro = dtgNotaCredito.Rows(i).Cells(0).Value
                intTmpIdstock = dtgNotaCredito.Rows(i).Cells(12).Value
                intTmpIdForma = sp_datosTabla.consulta_valor("select idForma from cabForma where nombreForma='" & dtgNotaCredito.Rows(i).Cells(3).Value & "'")
                intTmpIdImpuesto = sp_datosTabla.consulta_valor("select idImpuesto from impuesto where porcentajeImpuesto=" & dtgNotaCredito.Rows(i).Cells(7).Value)
                douTmpCantidad = dtgNotaCredito.Rows(i).Cells(10).Value
                '-- idProducto original
                intTmpIdProducto1 = sp_datosTabla.consulta_valor("select idProducto from producto where codigo='" & dtgNotaCredito.Rows(i).Cells(1).Value & "'")

                intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from stock where idStock=" & intTmpIdstock)
                intTmpCantfrac = CInt(dtgNotaCredito.Rows(i).Cells(14).Value)


                intTmpBoni = dtgNotaCredito.Rows(i).Cells(11).Value
                douTmpCosto = dtgNotaCredito.Rows(i).Cells(4).Value
                douTmpPrecio = dtgNotaCredito.Rows(i).Cells(13).Value
                douTmpFactorImpuesto = sp_datosTabla.consulta_valor("select factorImpuesto from impuesto where idImpuesto=" & intTmpIdImpuesto)
                douTmpPorcentajeImpuesto = sp_datosTabla.consulta_valor("select porcentajeImpuesto from impuesto where idImpuesto=" & intTmpIdImpuesto)
                douTmpSubtotal = douTmpCantidad * douTmpCosto

                'MsgBox("Valor del porcentaje del impuesto  " & douPorcentajeImpuesto)
                'sp_cargarNotaCredito.agregarDetNotaCreditoTmp(intGl_idConfigPc, intGl_nroNotaCredito, intTmpIdStock, intTmpIdForma, intIdImpuesto, 0, intTmpCantfrac, douBonificacion, douCosto, douPrecio, douFactorImpuesto, douPorcentajeImpuesto)
                If (fun_guardarSp("sp_agregarDetNotaCreditoTmp", intGl_idConfigPc & "," & intTmpNro & "," & intTmpIdProducto1 & "," & intTmpIdstock & "," & intTmpIdForma & "," & _
                                  intTmpIdImpuesto & "," & douTmpCantidad & "," & intTmpCantfrac & "," & intTmpBoni & "," & douTmpCosto & "," & douTmpPrecio & "," & _
                                  douTmpFactorImpuesto & "," & douTmpPorcentajeImpuesto & "," & douTmpSubtotal, Me.Name)) = 0 Then
                    MessageBox.Show("No se pudo Guardar el detalle de la Nota de Credito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dtgNotaCredito.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Exit Sub
                End If
                'sp_datosTabla.sp_string("sp_updDetNotaCreditoTmp", intGl_idConfigPc & "," & dtgNotaCredito.Rows(i).Cells(0).Value & "," & CDec(dtgNotaCredito.Rows(i).Cells(10).Value) & "," & CDec(dtgNotaCredito.Rows(i).Cells(11).Value) & "," & (CDec(dtgNotaCredito.Rows(i).Cells(4).Value) * CDec(dtgNotaCredito.Rows(i).Cells(10).Value)))
            End If
        Next
        '********************************'
        '-- guardar la nota de credito --'
        '********************************'
        '-- el id de la persona juridica

        Dim tmpIntIdPersonaJur As Integer
        tmpIntIdPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)

        If MessageBox.Show("Desea Guardar la Nota de Credito..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If (fun_guardarSp("sp_guardarNotaCreditoProveedor", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idPersonaJur & "," & _
                              CInt(txtIdCompra.Text) & "," & "'" & txtDsucN.Text & "'" & "," & "'" & txtDcajaN.Text & "'" & "," & "'" & txtFacturaN.Text & _
                              "'" & "," & "'" & txtTimbradoN.Text & "'" & "," & "'" & txtResponsable.Text & "'" & "," & "'" & strTmpFecha & "'" & "," & _
                              chkPendiente.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        intGl_nroNotaCredito = 0
        banGl_notacreditoCompra = True

        Me.Enabled = False
        frmBuscarFacturaCompra.Visible = True
        frmBuscarFacturaCompra.WindowState = FormWindowState.Normal
        frmBuscarFacturaCompra.Show()
        frmBuscarFacturaCompra.txtBuscar.Focus()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgNotaCredito.SelectedCells.Count > 0 Then
                '-- procedimiento para eliminar de la base de datos
                sp_cargarNotaCredito.deleteDetNotaCreditoTmp(intGl_idConfigPc, lblNro.Text)
                '---------------------------------------------------------
                dtgNotaCredito.Rows.Remove(dtgNotaCredito.CurrentRow)
                '-- restar la variable publica de nro de item
                intGl_nroNotaCredito = intGl_nroNotaCredito - 1
            End If
            intGl_nroNotaCredito = 0
            '-- volver a sumar los totales
            sumarTotal()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        controlarNotaCredito()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        '- idCompra
        frmBuscarProductoNtaCredito.txtIdCompra.Text = txtIdCompra.Text
        '-- si es impreso o no
        frmBuscarProductoNtaCredito.chkImp.Checked = chkImp.Checked
        '- el proveedor
        frmBuscarProductoNtaCredito.txtProveedor.Text = txtProveedor.Text
        '-- dsuc
        frmBuscarProductoNtaCredito.txtDsuc.Text = txtDsuc.Text
        '-- dcaja
        frmBuscarProductoNtaCredito.txtDcaja.Text = txtDcaja.Text
        '-- factura
        frmBuscarProductoNtaCredito.txtFactura.Text = txtFactura.Text
        '-- fecha de la factura
        frmBuscarProductoNtaCredito.txtFechaFactura.Text = txtFechaFactura.Text
        '-- responsable de la carga
        frmBuscarProductoNtaCredito.txtResponsableCarga.Text = txtResponsableCarga.Text
        '-- fecha hora de carga
        frmBuscarProductoNtaCredito.txtFechaHora.Text = txtFechaHora.Text
        '-- colocar la consulta
        If chkImp.Checked = False Then
            '-- imp
            frmBuscarProductoNtaCredito.listarProductoCompra("where cc.idCompra=" & CInt(txtIdCompra.Text))
        Else
            '-- no imp
            frmBuscarProductoNtaCredito.listarProductoCompraNoImp("where cc.idCompra=" & CInt(txtIdCompra.Text))
        End If

        Me.Enabled = False
        frmBuscarProductoNtaCredito.Visible = True
        frmBuscarProductoNtaCredito.Show()
        frmBuscarProductoNtaCredito.BringToFront()
        frmBuscarProductoNtaCredito.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '************'
    '-- GRILLA --'
    '************'
    Private Sub dtgNotaCredito_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgNotaCredito.CellFormatting
        '-- formato del costo
        If dtgNotaCredito.Columns(e.ColumnIndex).Name.Equals("Column4") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##.###,###.##")
        End If
        '-- formato de la cantidad
        If dtgNotaCredito.Columns(e.ColumnIndex).Name.Equals("Column8") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##,###.##")
        End If
        '-- formato de la bonificacion
        If dtgNotaCredito.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("#,###")
        End If
        '-- formato de la cantidad ingresada
        If dtgNotaCredito.Columns(e.ColumnIndex).Name.Equals("Column10") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##,###.##")
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- formato de la bonificacion ingresada
        If dtgNotaCredito.Columns(e.ColumnIndex).Name.Equals("Column11") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("#,###")
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgNotaCredito_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgNotaCredito.RowEnter
        Dim row As DataGridViewRow = dtgNotaCredito.Rows(e.RowIndex)
        '-- el nro de la fila de la grilla
        lblNro.Text = CStr(row.Cells(0).Value)
    End Sub

    Private Sub dtgNotaCredito_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgNotaCredito.SelectionChanged
        Dim douSubtotal As Double = 0
        For i As Integer = 0 To dtgNotaCredito.Rows.Count - 1
            '-- solo si hay valores
            If dtgNotaCredito.Rows(i).Cells(0).Value > 0 Then
                'intNroItem = intNroItem + 1
                '("Valor de intNroItem  " & intNroItem.ToString)
                '-- colocar una cantidad validad no superior al actual
                If dtgNotaCredito.Rows(i).Cells(10).Value > dtgNotaCredito.Rows(i).Cells(8).Value Then
                    MessageBox.Show("El valor ingresado supera a la cantidad original", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dtgNotaCredito.Rows(i).Cells(10).Value = 1
                End If
                '-- colocar una bonificacion validad no superior al actual
                If dtgNotaCredito.Rows(i).Cells(11).Value > dtgNotaCredito.Rows(i).Cells(9).Value Then
                    MessageBox.Show("El valor ingresado supera a la bonificación original", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dtgNotaCredito.Rows(i).Cells(11).Value = 0
                End If
                '-- sumar los totales
                sumarTotal()
            End If
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '**************'
    '-- CHECKBOX --'
    '**************'
    Private Sub chkPendiente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPendiente.CheckedChanged
        '-- habilitar solo si está pendiente
        If chkPendiente.Checked = True Then
            maskFecha.Enabled = False
            maskFecha.BackColor = Color.LightBlue
            maskFecha.Text = ""
            txtDsucN.Text = ""
            txtDsucN.Enabled = False
            txtDsucN.BackColor = Color.LightBlue
            txtDcajaN.Text = ""
            txtDcajaN.Enabled = False
            txtDcajaN.BackColor = Color.LightBlue
            txtFacturaN.Text = ""
            txtFacturaN.Enabled = False
            txtFacturaN.BackColor = Color.LightBlue
            txtTimbradoN.Enabled = False
            txtTimbradoN.Text = ""
            txtTimbradoN.BackColor = Color.LightBlue
            txtDsucN.Focus()
        Else
            maskFecha.Enabled = True
            maskFecha.Text = ""
            maskFecha.BackColor = Color.White
            txtDsucN.Text = ""
            txtDsucN.Enabled = True
            txtDsucN.BackColor = Color.White
            txtDcajaN.Text = ""
            txtDcajaN.Enabled = True
            txtDcajaN.BackColor = Color.White
            txtFacturaN.Text = ""
            txtFacturaN.Enabled = True
            txtFacturaN.BackColor = Color.White
            txtTimbradoN.Enabled = True
            txtTimbradoN.Text = ""
            txtTimbradoN.BackColor = Color.White
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmNotaCreditoProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- ver si hay item cargados
        For i As Integer = 0 To dtgNotaCredito.Rows.Count - 1
            If dtgNotaCredito.Rows(i).Cells(0).Value > 0 Then
                intTmpConta = intTmpConta + 1
            End If
        Next
        If intTmpConta > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo) = DialogResult.Yes Then
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                frmMenuPrincipal.proveedorNotaCredito.Enabled = True
                e.Cancel = False
            Else
                e.Cancel = True
            End If ' Call me
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.proveedorNotaCredito.Enabled = True
            e.Cancel = False
        End If
    End Sub

    Private Sub frmNotaCreditoProveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '-- la fecha de la factura
        maskFecha.Mask = "00/00/0000"
        maskFecha.ValidatingType = GetType(System.DateTime)
        ToolTip1.IsBalloon = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
End Class