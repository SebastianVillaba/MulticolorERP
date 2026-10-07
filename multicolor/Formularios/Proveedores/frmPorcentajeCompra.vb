Public Class frmPorcentajeCompra
    Dim sp_datosTabla As New sp_datosTabla


    Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        rdMonto.Checked = False
        rdPorcentaje.Checked = True
        txtMonto.Text = 0
        txtMonto.Focus()
    End Sub

    '-- procesar por porcentaje el monto
    Private Sub procesarPorcentaje()
        Try
            '-- las variables
            Dim intTmpIdProveedor As Integer
            Dim douTmpCotizacion As Double
            Dim douTmpPorcentaje As Double

            '-- dar valor a las variables
            intTmpIdProveedor = frmCompras.txtIDProveedor.Text
            douTmpCotizacion = frmCompras.txtCotizacion.Text
            douTmpPorcentaje = txtMonto.Text

            If (fun_guardarSp("sp_porcentajeCompra", intGl_idConfigPc & "," & intTmpIdProveedor & "," & douTmpCotizacion & "," & douTmpPorcentaje, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Actualizar el detalle de la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            '-- sumar la compra
            frmCompras.sumarTotal()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- procesar por monto el descuento
    Private Sub procesarMonto()
        Try
            If (fun_guardarSp("sp_actualizarDetCompraTmpDescuentoMonto", intGl_idConfigPc & "," & CDbl(sacarComa(txtMonto.Text)), Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Actualizar el detalle de la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            '-- sumar la compra
            frmCompras.sumarTotal()
            frmCompras.listarCompra()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- colocar el costo original
    Private Sub colocarCostoOriginal()
        Try
            Dim douTmpCotizacion As Double
            '--- calcular el pocentaje que se colocó
            Dim douTmpPorcentajeCalculado As Double
            douTmpPorcentajeCalculado = txtMonto.Text / 100

            douTmpCotizacion = frmCompras.txtCotizacion.Text
            '-----------------------------------------------------------
            'For i As Integer = 0 To frmCompras.dtgCompra.Rows.Count - 1
            '    If frmCompras.dtgCompra.Rows(i).Cells(0).Value > 0 Then
            '        '-- sacar el idProducto
            '        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & "'" & frmCompras.dtgCompra.Rows(i).Cells(1).Value & "'")
            '        '-- sacar el idImpuesto
            '        intTmpIdImpuesto = sp_datosTabla.consulta_valor("select idImpuesto from producto where idProducto=" & intTmpIdProducto)
            '        '-- sacar el porcentaje del impuesto
            '        douTmpPorcentajeImpuesto = sp_datosTabla.consulta_valorDouble("select porcentajeImpuesto from impuesto where idImpuesto=" & intTmpIdImpuesto)
            '        '--sacar el factor del impuesto
            '        douTmpFactorImpuesto = sp_datosTabla.consulta_valorDouble("select factorImpuesto from impuesto where idImpuesto=" & intTmpIdImpuesto)
            '        '-- sacar el precio
            '        douTmpPrecio = frmCompras.dtgCompra.Rows(i).Cells(9).Value
            '        '-- sacar el costo
            '        'MsgBox("El costo sin el porcentaje  " & frmCompras.dtgCompra.Rows(i).Cells(8).Value)
            '        douTmpCosto = frmCompras.dtgCompra.Rows(i).Cells(14).Value
            '        'MsgBox("Valor del porcentaje  " & (frmCompras.dtgCompra.Rows(i).Cells(8).Value * douTmpPorcentajeCalculado))
            '        'MsgBox("El costo con el porcentaje  " & douTmpCosto)
            '        douTmpTotalPorcentaje = douTmpTotalPorcentaje + (frmCompras.dtgCompra.Rows(i).Cells(14).Value)
            '        'MsgBox("El costo aplicando el descuento  " & douTmpCosto)
            '        '-- sacar la cantidad mas la bonificacion
            '        douTmpCantidad = (frmCompras.dtgCompra.Rows(i).Cells(4).Value * frmCompras.dtgCompra.Rows(i).Cells(12).Value) + frmCompras.dtgCompra.Rows(i).Cells(5).Value
            '        '--------------------
            '        '-- calculos
            '        '--------------------
            '        '-- costo con el impuesto
            '        If douTmpPorcentajeImpuesto > 0 Then
            '            '-- solo los que tienen gravadas
            '            douTmpCostoImpuesto = ((douTmpCosto / douTmpCantidad) - ((douTmpCosto / douTmpCantidad) / douTmpFactorImpuesto)) * douTmpCantidad
            '        Else
            '            '-- para la exenta
            '            douTmpCostoImpuesto = 0
            '        End If
            '        '-- el costo con el descuento del impuesto
            '        douTmpCostoDescuento = douTmpCosto - douTmpCostoImpuesto

            '        '-- calcular el porcentaje
            '        If douTmpPorcentajeImpuesto > 0 Then
            '            douTmpPorcentaje = ((douTmpPrecio * douTmpCantidad) - ((douTmpCostoDescuento * douTmpCotizacion) + ((douTmpCostoDescuento * douTmpCotizacion) * (douTmpPorcentajeImpuesto / 100)))) * 100 / (douTmpPrecio * douTmpCantidad)
            '        Else
            '            '-- para la exenta
            '            douTmpPorcentaje = (((douTmpPrecio * douTmpCantidad) - ((douTmpCostoDescuento * douTmpCotizacion))) * 100) / (douTmpPrecio * douTmpCantidad)
            '        End If
            '        '-- sacar el porcentaje del descuento al costo calculado
            '        douTmpCostoDescuento = (douTmpCostoDescuento * douTmpCotizacion) - ((douTmpCostoDescuento * douTmpCotizacion))
            '        '----------------------------------------'
            '        '-- remplazar los valores de la grilla --'
            '        '----------------------------------------'
            '        '-- el costo
            '        frmCompras.dtgCompra.Rows(i).Cells(8).Value = douTmpCosto
            '        frmCompras.dtgCompra.Rows(i).Cells(11).Value = douTmpPorcentaje
            '        '-----------------------------------------------------------------------
            '    End If
            'Next
            'MsgBox("Valor del porcentaje total  " & douTmpTotalPorcentaje)
            '-- sumar la compra
            frmCompras.sumarTotal()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If rdMonto.Checked = True Then
            If txtMonto.Text = 0 Then
                colocarCostoOriginal()
            Else
                procesarMonto()
            End If

        End If
        If rdPorcentaje.Checked = True Then
            If txtMonto.Text = 0 Then
                colocarCostoOriginal()
            Else
                procesarPorcentaje()
            End If

        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtMonto.Text) = 0 Then
                txtMonto.Text = 0
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtMonto.Text = Format(CDbl(txtMonto.Text), "##,###,###.00")
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmPorcentajeCompra_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmCompras.Enabled = True
        frmCompras.Show()
        frmCompras.BringToFront()
    End Sub
    '-------------------------------------------------------------------------------------------------------


End Class