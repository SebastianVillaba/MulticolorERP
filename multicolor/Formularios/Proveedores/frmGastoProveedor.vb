Public Class frmGastoProveedor
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarCompra As New sp_cargarCompra
    Dim moneda As New moneda
    Dim impuesto As New impuesto
    Dim sucursal As New Sucursal
    Dim tipoSucursal As New tipoSucursal

    Dim bolError As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        sucursal.comboSucursal(cboSucursal)
        tipoSucursal.comboTipoSucursal(cboTipoSucursal)
        inicializar()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        limpiar()
    End Sub

    Public Sub limpiar()
        '-- inicializar los objetos
        '- txt
        txtProveedor.Text = ""
        txtTotalFactura.Text = 0.0
        txtTotalIva.Text = 0.0
        txtIva5.Text = 0.0
        txtIVA10.Text = 0.0
        txtDsuc.Text = ""
        txtDcaja.Text = ""
        txtCosto.Text = 0.0
        txtFactura.Text = ""
        txtIDProveedor.Text = 0
        txtTimbrado.Text = ""
        txtConcepto.Text = ""
        '- lbl
        lblNro.Text = 0
        '- chk
        chkCredito.Checked = False
        chkHabilitarGasto.Checked = False
        '-- asignar al combo la moneda
        moneda.listarMonedaCombo(cboMoneda)
        cboTipoSucursal.SelectedValue = 1
        '-- colocar en el combo la moneda pre determinada por el sistema
        cboMoneda.SelectedValue = sp_datosTabla.un_dato_integer("idMoneda", "moneda", "idmoneda", sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad))
        '-- colocar el impuesto
        impuesto.ListarImpuesto(cboImpuesto)
        '-- limpiar la grilla
        dtgCompra.Rows.Clear()
        sp_datosTabla.consulta_valor("delete from detGastoTmp where idConfig=" & intGl_idConfigPc)

        intGl_nroGastoProveedor = 0
    End Sub

    Public Sub limpiarItem()
        txtConcepto.Text = ""
        txtCosto.Text = 0
    End Sub

    Private Sub cargarItem()
        Try
            '-- inicializar las variables
            Dim douTmpPorcentajeImpuesto As Double

            '-- controlar que ingrese un item
            If Len(txtConcepto.Text) = 0 Then
                MessageBox.Show("Debe Ingresar el Concepto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- controlar que ingrese un costo
            If txtCosto.Text <= 0 Then
                MessageBox.Show("Debe Un Costo Válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- aumentar a la variable publica
            intGl_nroGastoProveedor = intGl_nroGastoProveedor + 1
            '-- dar valor a las variables
            douTmpPorcentajeImpuesto = sp_datosTabla.consulta_valorDouble("select porcentajeImpuesto from impuesto where idImpuesto=" & cboImpuesto.SelectedValue)
            '-- cargar la grilla
            cargarGastoProveedor(intGl_nroGastoProveedor, txtConcepto.Text, douTmpPorcentajeImpuesto, CDbl(txtCosto.Text), cboImpuesto.SelectedValue)

            limpiarItem()
            txtConcepto.Focus()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub sumarTotal()
        Try
            '-- variables para los totales
            Dim douTmpTotal As Double = 0
            Dim douTmpIva5 As Double = 0
            Dim douTmpIva10 As Double = 0
            Dim douTmpTotalIva As Double = 0
            Dim intTmpNroLinea As Integer = 0
            Dim intTmpIdImpuesto As Integer = 0
            For i As Integer = 0 To dtgCompra.Rows.Count - 1
                intTmpNroLinea = intTmpNroLinea + 1
                'intGl_nroCompra = intTmpNroLinea
                '-- realizar los calculos solo si existem items cargados
                If dtgCompra.Rows(i).Cells(0).Value > 0 Then
                    douTmpTotal = douTmpTotal + dtgCompra.Rows(intTmpNroLinea - 1).Cells(3).Value
                    '-- sacar el idimpuesto
                    intTmpIdImpuesto = dtgCompra.Rows(i).Cells(4).Value
                    '-- porcentaje del impuesto
                    Dim douTmpPorcentajeImpuesto As Double = 0.0
                    douTmpPorcentajeImpuesto = dtgCompra.Rows(i).Cells(2).Value
                    '-- el factor del impuesto
                    Dim douTmpFactorImpuesto As Double = 0.0
                    douTmpFactorImpuesto = sp_datosTabla.un_dato_double("factorImpuesto", "impuesto", "idImpuesto", intTmpIdImpuesto)
                    '-- iva 5%
                    If CInt(sp_datosTabla.un_dato_double("porcentajeImpuesto", "impuesto", "idImpuesto", intTmpIdImpuesto)) = 5 Then
                        douTmpIva5 = douTmpIva5 + (dtgCompra.Rows(intTmpNroLinea - 1).Cells(3).Value) / (((douTmpFactorImpuesto) * 10) * 2)
                        'MsgBox("Valor de IVA 5%  " & douTmpIva5)
                    End If

                    '-- iva 10%
                    If CInt(sp_datosTabla.un_dato_double("porcentajeImpuesto", "impuesto", "idImpuesto", intTmpIdImpuesto)) = 10 Then
                        douTmpIva10 = douTmpIva10 + (dtgCompra.Rows(intTmpNroLinea - 1).Cells(3).Value) / ((douTmpFactorImpuesto) * 10)
                    End If
                End If
            Next
            douTmpTotalIva = douTmpIva10 + douTmpIva5
            '-- asignar los totales
            txtTotalFactura.Text = douTmpTotal
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "#,###,###.00")
            txtTotalIva.Text = douTmpTotalIva
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "#,###,###.00")
            txtIVA10.Text = douTmpIva10
            txtIVA10.Text = Format(CDec(txtIVA10.Text), "#,###,###.00")
            txtIva5.Text = douTmpIva5
            txtIva5.Text = Format(CDec(txtIva5.Text), "#,###,###.00")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub controlarGuardar()
        '-- inicializar las variables
        Dim strTmpConcepto As String
        Dim intTmpIdImpuesto As Integer
        Dim douTmpPorcentajeImpuesto As Double
        Dim douTmpFactorImpuesto As Double
        Dim douTmpCosto As Double

        '-- si los primeros digitos de la factura son validos
        '-- solo los numericos y de tres lugares
        If Not IsNumeric(txtDsuc.Text) Then
            MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDsuc.Focus()
            Exit Sub
        End If
        If txtDsuc.Text.Length <> 3 Then
            MessageBox.Show("Debe introducir solo tres dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDsuc.Focus()
            Exit Sub
        End If
        '-- solo los numericos y de tres lugares
        If Not IsNumeric(txtDcaja.Text) Then
            MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDcaja.Focus()
            Exit Sub
        End If
        If txtDcaja.Text.Length <> 3 Then
            MessageBox.Show("Debe introducir solo tres dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDcaja.Focus()
        End If
        '-- solo los numericos y de siete lugares
        If Not IsNumeric(txtFactura.Text) Then
            MessageBox.Show("Debe Introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFactura.Focus()
            Exit Sub
        End If
        If txtFactura.Text.Length <> 7 Then
            MessageBox.Show("Debe introducir solo siete dígitos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFactura.Focus()
            Exit Sub
        End If
        '-- solo que sea numerico el timbrado
        If Not IsNumeric(txtTimbrado.Text) Then
            MessageBox.Show("Debe introducir solo numeros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTimbrado.Focus()
            Exit Sub
        End If

        '--------------------------------------------------------------------------
        '-- que se ingrese la factura
        If txtDsuc.Text = "" Then
            MessageBox.Show("Debe Introducir el primer digito de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtDcaja.Text = "" Then
            MessageBox.Show("Debe introducir el segundo digito de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtFactura.Text = "" Then
            MessageBox.Show("Debe introducir el nro de la factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '-- el proveedor
        If txtProveedor.Text = "" Then
            MessageBox.Show("Debe introducir el Proveedor..!", strGl_nombreSucursal, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- si no tiene total
        If CInt(txtTotalFactura.Text) <= 0 Then
            MessageBox.Show("El Total de la Factura no es Válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- si no existen item cargados
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgCompra.Rows.Count - 1
            If dtgCompra.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
            End If
        Next
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existen items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        '-- eliminar los registros de la tabla temporal
        sp_datosTabla.consulta_valor("delete from detGastoTmp where idConfig=" & intGl_idConfigPc)
        '-- recorrer la grilla y cargarlo
        For i As Integer = 0 To dtgCompra.Rows.Count - 1
            If dtgCompra.Rows(i).Cells(0).Value > 0 Then
                '-- dar valor a las variables
                strTmpConcepto = dtgCompra.Rows(i).Cells(1).Value
                intTmpIdImpuesto = dtgCompra.Rows(i).Cells(4).Value
                douTmpPorcentajeImpuesto = dtgCompra.Rows(i).Cells(2).Value
                douTmpFactorImpuesto = sp_datosTabla.consulta_valorDouble("select factorImpuesto from impuesto where idImpuesto=" & intTmpIdImpuesto)
                douTmpCosto = dtgCompra.Rows(i).Cells(3).Value
                If (fun_guardarSp("sp_agregarDetGastoTmp", intGl_idConfigPc & "," & "'" & strTmpConcepto & "'" & "," & intTmpIdImpuesto & "," & douTmpPorcentajeImpuesto & "," & douTmpFactorImpuesto & "," & douTmpCosto, Me.Name)) = 0 Then
                    bolError = True
                    Exit Sub
                End If
            End If
        Next

    End Sub

    Private Sub guardarGasto()
        '-- inicializar variables
        Dim intTmpIdProveedor As Integer
        Dim intTmpIdTipoCompra As Integer
        Dim intTmpIdMoneda As Integer
        Dim strTmpDsuc As String
        Dim strTmpDcaja As String
        Dim strTmpFactura As String
        Dim strTmpTimbrado As String
        Dim strTmpFecha As String
        Dim douTmpCotizacion As Double
        Dim strTmpVence As String
        Dim douTmpTotal As Double
        Dim bolTmpHabilitarGasto As Boolean

        '-- dar valor a las variables
        intTmpIdProveedor = CInt(txtIDProveedor.Text)
        If chkCredito.Checked = True Then
            intTmpIdTipoCompra = sp_datosTabla.consulta_valor("select idTipoCompra from v_tipoCompra where acreditar=1")
        Else
            intTmpIdTipoCompra = sp_datosTabla.consulta_valor("select idTipoCompra from v_tipoCompra where acreditar=0")
        End If
        intTmpIdMoneda = cboMoneda.SelectedValue
        strTmpDsuc = txtDsuc.Text
        strTmpDcaja = txtDcaja.Text
        strTmpFactura = txtFactura.Text
        strTmpTimbrado = txtTimbrado.Text
        strTmpFecha = dtpFecha.Text
        If chkCredito.Checked = False Then
            strTmpVence = ""
        Else
            strTmpVence = dtpFechaCredito.Text
        End If
        douTmpCotizacion = CDbl(txtCotizacion.Text)
        douTmpTotal = CDbl(sacarComa(txtTotalFactura.Text))
        bolTmpHabilitarGasto = chkHabilitarGasto.Checked

        If (fun_guardarSp("sp_guardarGasto", intGl_idConfigPc & "," & cboTipoSucursal.SelectedValue & "," & chkDeducibles.Checked & "," & chkEfectivo.Checked & "," & cboSucursal.SelectedValue & "," & _
                          intGl_idPersonaJur & "," & intTmpIdProveedor & "," & intTmpIdTipoCompra & "," & intTmpIdMoneda & "," & "'" & strTmpDsuc & "'" & _
                          "," & "'" & strTmpDcaja & "'" & "," & "'" & _
                          strTmpFactura & "'" & "," & "'" & strTmpTimbrado & "'" & "," & "'" & strTmpFecha & "'" & "," & douTmpCotizacion & "," & _
                          "'" & strTmpVence & "'" & "," & douTmpTotal & "," & bolTmpHabilitarGasto & "," & intGl_idUsuario, Me.Name)) = 0 Then
            MessageBox.Show("No se pudo Actualizar el Gasto...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        End If


    End Sub
    '----------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
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

    Private Sub txtFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTimbrado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        e.Handled = txtNumerico(txtTimbrado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCotizacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCotizacion.KeyPress
        e.Handled = txtNumerico(txtCotizacion, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtCosto.Text) = 0 Then
                txtCotizacion.Text = 0
            End If
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtCotizacion.Text = Format(CDec(txtCotizacion.Text), "###,###.00")
            txtConcepto.Focus()
        End If
    End Sub

    Private Sub txtCosto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCosto.KeyPress
        e.Handled = txtNumerico(txtCosto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtCosto.Text) = 0 Then
                txtCosto.Text = 0
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtCosto.Text = Format(CDec(txtCosto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '**************'
    '-- CHECKBOX --'
    '**************'
    Private Sub chkCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCredito.Click
        If chkCredito.Checked = True Then
            chkEfectivo.Checked = False
        End If
        If chkCredito.Checked = False Then
            chkEfectivo.Checked = True
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        'banGl_compra = blanquearBanderas("banGl_compra")
        banGl_gastoProveedor = True
        Me.Enabled = False

        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.Visible = True
        frmBuscarProveedor.WindowState = FormWindowState.Normal
        frmBuscarProveedor.Show()
        frmBuscarProveedor.txtBuscar.Focus()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgCompra.SelectedCells.Count > 0 Then
                dtgCompra.Rows.Remove(dtgCompra.CurrentRow)
                '-- restar la variable publica de nro de item
                intGl_nroGastoProveedor = intGl_nroGastoProveedor - 1

            End If
            '-- volver a sumar los totales
            sumarTotal()
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarGuardar()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar el Gasto..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarGasto()
            End If
        End If

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        '-- controlar 
        cargarItem()
        sumarTotal()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub
    '----------------------------------------------------------------------------------------------------
    '***********'
    '-- COMBO --'
    '***********'
    Private Sub cboMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If txtCotizacion.Enabled = False Then
                txtConcepto.Focus()
            Else
                txtCotizacion.Focus()
            End If

        End If
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboMoneda.SelectedIndexChanged
        '-- verificar si la moneda seleccionada corresponde a la moneda que opera el sistema
        If cboMoneda.SelectedValue = sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad) Then
            txtCotizacion.Enabled = False
            txtCotizacion.BackColor = Color.LightSkyBlue
            txtCotizacion.Text = 1
        Else
            txtCotizacion.Enabled = True
            txtCotizacion.BackColor = Color.White
            txtCotizacion.Text = 0
        End If
    End Sub

    Private Sub cboSucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSucursal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cboMoneda.Focus()
        End If
    End Sub

    Private Sub cboImpuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboImpuesto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------
    '***************'
    '-- LA GRILLA --'
    '***************'
    '-- formato dentro de la grilla
    Public Sub dtgCompra_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCompra.CellFormatting
        '-- formato de costo
        If dtgCompra.Columns(e.ColumnIndex).Name.Equals("Column8") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##,###,###.##")
        End If
        '-- formato del porcentaje de iva
        If dtgCompra.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("###")
        End If
    End Sub

    Private Sub dtgCompra_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCompra.RowEnter
        Dim row As DataGridViewRow = dtgCompra.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmGastoProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- ver si hay item cargados
        For i As Integer = 0 To dtgCompra.Rows.Count - 1
            If dtgCompra.Rows(i).Cells(0).Value > 0 Then
                intTmpConta = intTmpConta + 1
            End If
        Next
        If intTmpConta > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                banGl_gastoProveedor = 0
                frmMenuPrincipal.proveedorGasto.Enabled = True
                e.Cancel = False
                e.Cancel = False
            Else
                e.Cancel = True
            End If ' Call me
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            banGl_divAbmProducto = 0
            frmMenuPrincipal.proveedorGasto.Enabled = True
            e.Cancel = False
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
End Class