Public Class frmNotaCreditoMontoProveedor
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdStock As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpFecha.Format = DateTimePickerFormat.Custom
        dtpFecha.CustomFormat = "dd/MM/yyyy"

        txtIdCompra.Text = 0
        sp_datosTabla.consulta_valor("delete from detNotacreditoMontoTmp where idConfig=" & intGl_idConfigPc)
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        txtIdProveedor.Text = 0
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
        txtObservacion.Text = ""
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnEliminar.Enabled = False
        btnNuevo.Enabled = True
        '-- limpiar la tabla temporal de la base de datos
        sp_datosTabla.consulta_valor("delete detNotacreditoMontoTmp where idConfig=" & intGl_idConfigPc)
        '-- limpiar la grilla
        listarDetalleNota()
        '-- la cabecera de la nota de credito
        chkPendiente.Checked = False
        chkAplicarMonto.Checked = False
        chkSoloMonto.Checked = False
        chkAplicarFactura.Checked = False

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
        txtIva10.Text = 0
        txtIva5.Text = 0
        txtTotalIva.Text = 0
        txtTotalNotaCredito.Text = 0

    End Sub

    Public Sub listarDetalleNota()
        systemClass.SqlToLv_detalleMercaderiaNotaCredito(lvCompra, "sp_consultaDetalleNotaCreditoMontoTmp", intGl_idConfigPc)
    End Sub

    Public Sub sumarTotal()
        Dim intTmpNroLinea As Integer = 0
        Dim douTmpSubTotal As Double = 0
        Dim douTmpIva5 As Double = 0
        Dim douTmpIva10 As Double = 0
        Dim douTmpTotalIva As Double = 0

        If chkAplicarMonto.Checked = True Then
            '-- por las mercaderias
            '-- total del iva
            douTmpIva5 = sp_datosTabla.consulta_valorDouble("select sum(iva5) from detNotacreditoMontoTmp where idConfig=" & intGl_idConfigPc)
            txtIva5.Text = douTmpIva5
            txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,##0.##")
            douTmpIva10 = sp_datosTabla.consulta_valorDouble("select sum(iva10) from detNotacreditoMontoTmp where idConfig=" & intGl_idConfigPc)
            txtIva10.Text = douTmpIva10
            txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,##0.##")
            douTmpTotalIva = douTmpIva10 + douTmpIva5
            txtTotalIva.Text = douTmpTotalIva
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,##0.##")
            '---- total de la nota de credito
            douTmpSubTotal = sp_datosTabla.consulta_valorDouble("select sum(descuento) from detNotacreditoMontoTmp where idConfig=" & intGl_idConfigPc)
            txtTotalNotaCredito.Text = douTmpSubTotal
            txtTotalNotaCredito.Text = Format(CDec(txtTotalNotaCredito.Text), "###,###,##0.##")
        End If

        If chkSoloMonto.Checked = True Then
            '-- por las mercaderias
            '-- total del iva
            douTmpIva5 = 0
            txtIva5.Text = douTmpIva5
            txtIva5.Text = 0
            douTmpIva10 = CDbl(sacarComa(txtMonto.Text)) / 11
            txtIva10.Text = douTmpIva10
            txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,##0.##")
            douTmpTotalIva = douTmpIva10 + douTmpIva5
            txtTotalIva.Text = douTmpTotalIva
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,##0.##")
            '---- total de la nota de credito
            douTmpSubTotal = CDbl(sacarComa(txtMonto.Text))
            txtTotalNotaCredito.Text = douTmpSubTotal
            txtTotalNotaCredito.Text = Format(CDec(txtTotalNotaCredito.Text), "###,###,##0.##")
        End If
    End Sub

    Private Sub controlarNotaCredito()
        '-- variables
        'Dim intTmpNro As Integer
        'Dim intTmpIdProducto As Integer
        'Dim intTmpIdProducto1 As Integer
        'Dim intTmpIdstock As Integer
        'Dim intTmpIdForma As Integer
        'Dim intTmpIdImpuesto As Integer
        'Dim douTmpCantidad As Double
        'Dim intTmpCantfrac As Integer
        'Dim intTmpBoni As Integer
        'Dim douTmpCosto As Double
        'Dim douTmpPrecio As Double
        'Dim douTmpFactorImpuesto As Double
        'Dim douTmpPorcentajeImpuesto As Double
        'Dim douTmpSubtotal As Double

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
        '-- si no se ingresa el responsable
        If txtResponsable.Text = "" Then
            MessageBox.Show("Debe ingresar el Responsable de la Nota de Crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- si no tiene una compra
        If txtIdCompra.Text = 0 Then
            MessageBox.Show("Debe Aplicar a una factura esta nota de crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            strTmpFecha = dtpFecha.Text
        Else
            strTmpFecha = "01/01/1900"
        End If


        '********************************'
        '-- guardar la nota de credito --'
        '********************************'
        If (fun_guardarSp("sp_guardarNotaCreditoMontoProveedor", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idPersonaJur & "," & _
                              CInt(txtIdProveedor.Text) & "," & CInt(txtIdCompra.Text) & "," & "'" & txtDsucN.Text & "'" & "," & "'" & txtDcajaN.Text & "'" & "," & "'" & txtFacturaN.Text & _
                              "'" & "," & "'" & txtTimbradoN.Text & "'" & "," & "'" & txtResponsable.Text & "'" & "," & CDbl(sacarComa(txtMonto.Text)) & _
                              "," & "'" & strTmpFecha & "'" & "," & chkPendiente.Checked & "," & "'" & Trim(txtObservacion.Text) & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        intGl_nroNotaCreditoMonto = 0
        banGl_notacreditoMonto = True

        Me.Enabled = False
        frmBuscarProveedor.Visible = True
        frmBuscarProveedor.WindowState = FormWindowState.Normal
        frmBuscarProveedor.Show()
        frmBuscarProveedor.txtBuscar.Focus()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then

            '-- volver a sumar los totales
            sumarTotal()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar la Nota de Crédito por Monto..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            controlarNotaCredito()
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        '- el proveedor
        frmBuscarMercaderiaProveedor.txtIdProveedor.Text = txtIdProveedor.Text
        frmBuscarMercaderiaProveedor.txtProveedor.Text = txtProveedor.Text

        Me.Enabled = False
        frmBuscarMercaderiaProveedor.Visible = True
        frmBuscarMercaderiaProveedor.Show()
        frmBuscarMercaderiaProveedor.BringToFront()
        frmBuscarMercaderiaProveedor.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCompra.SelectedIndexChanged
        '-- mostrar el id compra
        For Each item As ListViewItem In lvCompra.SelectedItems
            intIdStock = item.SubItems(9).Text
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- TEXTBOX --'
    '*************'
    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,##0.##")

            e.Handled = True
            txtResponsable.Focus()
        End If
    End Sub

    Private Sub txtResponsable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResponsable.KeyPress
        'e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,##0.##")

            e.Handled = True
            txtDsucN.Focus()
        End If
    End Sub

    Private Sub txtDsucN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsucN.KeyPress
        e.Handled = txtNumerico(txtDsucN, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,##0.##")

            e.Handled = True
            txtDcajaN.Focus()
        End If
    End Sub

    Private Sub txtDcajaN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcajaN.KeyPress
        e.Handled = txtNumerico(txtDcajaN, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,##0.##")

            e.Handled = True
            txtFacturaN.Focus()
        End If
    End Sub

    Private Sub txtTimbradoN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbradoN.KeyPress
        e.Handled = txtNumerico(txtTimbradoN, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,##0.##")

            e.Handled = True
            dtpFecha.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '**************'
    '-- CHECKBOX --'
    '**************'
    Private Sub chkPendiente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPendiente.CheckedChanged
        '-- habilitar solo si está pendiente
        If chkPendiente.Checked = True Then
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

    Private Sub chkAolicarMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarMonto.CheckedChanged
        If chkAplicarMonto.Checked = True Then
            '-- aplicar sobre el costo total
            If (fun_guardarSp("sp_updDetNotaCreditoMontoTmp", intGl_idConfigPc & "," & CDbl(sacarComa(txtMonto.Text)) & "," & chkAplicarMonto.Checked, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo actualizar los registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                listarDetalleNota()
                sumarTotal()
            End If
        Else
            '-- dejar con el costo actual
            If (fun_guardarSp("sp_updDetNotaCreditoMontoTmp", intGl_idConfigPc & "," & CDbl(sacarComa(txtMonto.Text)) & "," & chkAplicarMonto.Checked, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo actualizar los registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                listarDetalleNota()
                sumarTotal()
            End If
        End If
    End Sub

    Private Sub chkSoloMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloMonto.CheckedChanged
        If chkAplicarMonto.Checked = True Then
            listarDetalleNota()
            sumarTotal()
        Else
            sumarTotal()
        End If
    End Sub

    Private Sub chkAplicarFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarFactura.CheckedChanged
        If chkAplicarFactura.Checked = True Then
            banGl_notacreditoMonto = True

            'MsgBox("Valor de la bandera " & banGl_notacreditoMonto)

            Me.Enabled = False
            frmBuscarFacturaCompra.Visible = True
            frmBuscarFacturaCompra.WindowState = FormWindowState.Normal
            frmBuscarFacturaCompra.Show()
            frmBuscarFacturaCompra.txtBuscar.Focus()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmNotaCreditoMontoProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- ver si hay item cargados
        If intTmpConta > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo,MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                frmMenuPrincipal.proveedorNotaCreditoMonto.Enabled = True
                e.Cancel = False
            Else
                e.Cancel = True
            End If ' Call me
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.proveedorNotaCreditoMonto.Enabled = True
            e.Cancel = False
        End If
    End Sub

End Class