Public Class frmNotaCreditoGasto
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        '-- formato de la fecha
        dtpFecha.Format = DateTimePickerFormat.Custom
        dtpFecha.CustomFormat = "dd/MM/yyyy"
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        'listar_busqueda("")
        limpiar()
        'valorde del combo
    End Sub

    Public Sub limpiar()
        '-- inicializar los objetos
        txtProveedor.Text = ""
        txtResponsable.Text = ""
        txtTotalNcr.Text = 0.0
        txtDsuc.Text = ""
        txtDcaja.Text = ""
        txtIdGasto.Text = 0
        txtFactura.Text = ""
        txtIDProveedor.Text = 0
        txtTimbrado.Text = ""
        txtCotizacion.Text = 0
        txtMoneda.Text = ""
        lblConcepto.Text = ""
        '-- limpiar la tabla temporal
        sp_datosTabla.consulta_valor("delete from detNotaCreditoGastoTmp where idConfig=" & intGl_idConfigPc)
        '--  listar la tabla temporal
        listarDetalle()
    End Sub

    Public Sub listarDetalle()
        systemClass.SqlToLv_detalleGastoProveedor(lvDetalle, "sp_consultaDetNotaCreditoGastoTmp", intGl_idConfigPc)
        sumarTotal()
    End Sub

    Public Sub sumarTotal()
        Try
            '-- variables para los totales
            Dim douTmpTotal As Double
            douTmpTotal = sp_datosTabla.consulta_valorDouble("select sum(costo) from detNotaCreditoGastoTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
            'MsgBox("Total  " & douTmpTotal)

            txtTotalNcr.Text = douTmpTotal
            txtTotalNcr.Text = Format(CDec(txtTotalNcr.Text), "###,###,###")

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub guardarNotaCredito()
        '-- inicializar las variables
        Dim strTmpMotivo As String
        Dim intTmpIdGasto As Integer
        Dim strTmpDsuc As String
        Dim strTmpDcaja As String
        Dim strTmpFactura As String
        Dim strTmpTimbrado As String
        Dim strTmpResponsable As String
        Dim strTmpFecha As String
        Dim douTmpTotal As Double

        '-- dar valor a las variables
        strTmpMotivo = txtMotivo.Text
        intTmpIdGasto = CInt(txtIdGasto.Text)
        strTmpDsuc = txtDsuc.Text
        strTmpDcaja = txtDcaja.Text
        strTmpFactura = txtFactura.Text
        strTmpTimbrado = txtTimbrado.Text
        strTmpResponsable = txtResponsable.Text
        strTmpFecha = dtpFecha.Text
        douTmpTotal = txtTotalNcr.Text
        ''-----------------------------------------
        If (fun_guardarSp("sp_guardarNotaCreditoGasto", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idPersonaJur & "," & _
            intTmpIdGasto & "," & "'" & strTmpMotivo & "'" & "," & "'" & strTmpDsuc & "'" & "," & "'" & strTmpDcaja & "'" & "," & "'" & strTmpFactura & "'" & "," & _
            "'" & strTmpTimbrado & "'" & "," & "'" & strTmpResponsable & "'" & "," & "'" & strTmpFecha & "'" & "," & douTmpTotal & "," & intGl_idUsuario, Me.Name)) = 0 Then
            MessageBox.Show("No se pudo Actualizar la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
            'sp_datosTabla.sp_string("sp_updDetcompraTmp", intGl_idConfigPc & "," & dtgCompra.Rows(i).Cells(0).Value & "," & intTmpIdProducto & "," & strTmpLote & "," & strTmpFecha & "," & intGl_idUsuario & "," & "''")
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtDsuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtTimbrado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        e.Handled = txtNumerico(txtTimbrado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        e.Handled = txtNumerico(txtTimbrado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscarCompra.Focus()
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        'e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtResponsable.Focus()
        End If
    End Sub

    Private Sub txtResponsable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResponsable.KeyPress
        'e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAgregar.Focus()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscarCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCompra.Click
        Me.Enabled = False

        frmBuscaGastoNotaCredito.Visible = True
        frmBuscaGastoNotaCredito.Show()
        frmBuscaGastoNotaCredito.BringToFront()
        frmBuscaGastoNotaCredito.txtDsuc.Focus()

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Me.Enabled = False

        frmBuscarConceptoGasto.listarConcepto(CInt(txtIdGasto.Text))
        frmBuscarConceptoGasto.Visible = True
        frmBuscarConceptoGasto.Show()
        frmBuscarConceptoGasto.BringToFront()
        frmBuscarConceptoGasto.lvConcepto.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar la Nota de Crédito..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarNotaCredito()
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

    End Sub
    '----------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetalle.SelectedIndexChanged
        For Each item As ListViewItem In lvDetalle.SelectedItems
            lblConcepto.Text = item.SubItems(0).Text
        Next
    End Sub

    Private Sub lvDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvDetalle.KeyPress
        If Len(lblConcepto.Text) > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- modificar el costo
                '-- asignar los valores
                frmModificarCostoNotaCredito.txtConcepto.Text = lblConcepto.Text
                frmModificarCostoNotaCredito.txtPorcentajeIva.Text = sp_datosTabla.consulta_valorDouble("select porcentajeImpuesto from detNotaCreditoGastoTmp where idConfig=" & intGl_idConfigPc & " and concepto='" & lblConcepto.Text & "'")
                frmModificarCostoNotaCredito.txtCosto.Text = sp_datosTabla.consulta_valorDouble("select costo from detNotaCreditoGastoTmp where idConfig=" & intGl_idConfigPc & " and concepto='" & lblConcepto.Text & "'")
                frmModificarCostoNotaCredito.txtPorcentajeIva.Text = Format(CDec(frmModificarCostoNotaCredito.txtPorcentajeIva.Text), "##.#")
                frmModificarCostoNotaCredito.txtCosto.Text = Format(CDec(frmModificarCostoNotaCredito.txtCosto.Text), "###,###,###")
                frmModificarCostoNotaCredito.txtCostoNuevo.Text = 0

                Me.Enabled = False
                frmModificarCostoNotaCredito.Show()
                frmModificarCostoNotaCredito.Visible = True
                frmModificarCostoNotaCredito.BringToFront()
                '------------------------------------------------------------
            End If
        Else
            MessageBox.Show("Debe colocarse sobre algún concepto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCancelarCanje_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim intTmpConta As Integer = 0
        intTmpConta = sp_datosTabla.consulta_valor("select count(*) from detNotaCreditoGastoTmp where idConfig=" & intGl_idConfigPc)
        '-- ver si hay item cargados
        If intTmpConta > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                frmMenuPrincipal.proveedorNotaCreditoGasto.Enabled = True
                e.Cancel = False
                e.Cancel = False
            Else
                e.Cancel = True
            End If ' Call me
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.proveedorNotaCreditoGasto.Enabled = True
            e.Cancel = False
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------------
End Class