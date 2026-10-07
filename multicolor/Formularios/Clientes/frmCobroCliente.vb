Public Class frmCobroCliente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim bolError As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub limpiarObjetos()
        '-- los txt
        txtIdCliente.Text = 0
        txtCliente.Text = ""
        txtCel1.Text = ""
        txtCel2.Text = ""
        txtDireccion.Text = ""
        txtEmail.Text = ""
        txtGrupo.Text = ""
        txtTotalMonto.Text = 0
        txtTotalPagado.Text = 0
        txtTotalSaldo.Text = 0
        txtMonto.Text = 0
        '-- los rd
        rdPorMonto.Checked = False
        grMonto.Visible = False
        rdPorFactura.Checked = True
        grCabPago.Visible = False
        grDetPago.Visible = False
        grPagoPorFactura.Visible = True
        '-- la grilla
        'listarCabeceraPago("0")
        dtgPago.Rows.Clear()
        'listarPagoPorCuota("0")
        dtgPagoCuota.Rows.Clear()
        '-- el listview
        listarDetallePago(" where idConfig=0")
        txtPagado.Text = 0
        txtTotalMonto.Text = 0
        txtTotalPagado.Text = 0
        txtTotalSaldo.Text = 0
    End Sub

    Public Sub sumarTotales()
       Try
            'MsgBox("Entro al proceso de sumar totales")
            Dim douTmpTotalMonto As Double
            Dim douTmpTotalPago As Double
            Dim douTmpTotalPagado As Double
            Dim douTmpTotalSaldo As Double
            For i As Integer = 0 To dtgPago.Rows.Count - 1
                If dtgPago.Rows(i).Cells(0).Value > 0 Then
                    '-- total monto
                    douTmpTotalMonto = douTmpTotalMonto + CDbl(dtgPago.Rows(i).Cells(4).Value)
                    'MsgBox("Valor del monto  " & douTmpTotalMonto)
                    '-- total pago
                    douTmpTotalPago = douTmpTotalPago + CDbl(dtgPago.Rows(i).Cells(5).Value)
                    'MsgBox("Valor del pago  " & douTmpTotalPago)
                    '-- total pagado
                    douTmpTotalPagado = douTmpTotalPagado + CDbl(dtgPago.Rows(i).Cells(6).Value)
                    'MsgBox("Valor de pagado  " & douTmpTotalPagado)
                    '-- total saldo
                    douTmpTotalSaldo = douTmpTotalSaldo + CDbl(dtgPago.Rows(i).Cells(7).Value)
                    'MsgBox("Valor del saldo  " & douTmpTotalSaldo)

                End If
            Next
            txtTotalMonto.Text = douTmpTotalMonto
            txtTotalMonto.Text = Format(CDbl(txtTotalMonto.Text), "###,###,##0.##")
            txtPagado.Text = douTmpTotalPago
            txtPagado.Text = Format(CDbl(txtPagado.Text), "###,###,##0.##")
            txtTotalPagado.Text = douTmpTotalPagado
            txtTotalPagado.Text = Format(CDbl(txtTotalPagado.Text), "###,###,##0.##")
            txtTotalSaldo.Text = douTmpTotalSaldo
            txtTotalSaldo.Text = Format(CDbl(txtTotalSaldo.Text), "###,###,##0.##")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub sumarTotalesPorCuota()
        Try
            'MsgBox("Entro al proceso de sumar totales")
            Dim douTmpTotalMonto As Double
            Dim douTmpTotalPago As Double
            Dim douTmpTotalPagado As Double
            Dim douTmpTotalSaldo As Double
            Dim douTmpTotalNotaCredito As Double

            For i As Integer = 0 To dtgPagoCuota.Rows.Count - 1
                If dtgPagoCuota.Rows(i).Cells(0).Value > 0 Then
                    '-- total monto
                    douTmpTotalMonto = douTmpTotalMonto + CDbl(dtgPagoCuota.Rows(i).Cells(6).Value)
                    'MsgBox("Valor del monto  " & douTmpTotalMonto)
                    '-- total nota de credito
                    douTmpTotalNotaCredito = douTmpTotalNotaCredito + CDbl(dtgPagoCuota.Rows(i).Cells(7).Value)
                    '-- total pago
                    douTmpTotalPago = douTmpTotalPago + CDbl(dtgPagoCuota.Rows(i).Cells(9).Value)
                    'MsgBox("Valor del pago  " & douTmpTotalPago)
                    '-- total pagado
                    douTmpTotalPagado = douTmpTotalPagado + CDbl(dtgPagoCuota.Rows(i).Cells(8).Value)
                    'MsgBox("Valor de pagado  " & douTmpTotalPagado)
                    '-- total saldo
                    douTmpTotalSaldo = douTmpTotalSaldo + CDbl(dtgPagoCuota.Rows(i).Cells(10).Value)
                    'MsgBox("Valor del saldo  " & douTmpTotalSaldo)

                End If
            Next
            txtTotalMonto.Text = douTmpTotalMonto
            txtTotalMonto.Text = Format(CDbl(txtTotalMonto.Text), "###,###,##0.##")
            txtPagado.Text = douTmpTotalPago
            txtPagado.Text = Format(CDbl(txtPagado.Text), "###,###,##0.##")
            txtTotalPagado.Text = douTmpTotalPagado
            txtTotalPagado.Text = Format(CDbl(txtTotalPagado.Text), "###,###,##0.##")
            txtTotalNotaCr.Text = douTmpTotalNotaCredito
            txtTotalNotaCr.Text = Format(CDbl(txtTotalNotaCr.Text), "###,###,##0.##")
            txtTotalSaldo.Text = douTmpTotalSaldo
            txtTotalSaldo.Text = Format(CDbl(txtTotalSaldo.Text), "###,###,##0.##")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub listarCabeceraPago(ByVal v_parametros As String)
        '-- la cabecera
        systemClass.SqlToDg_cobroCliente(dtgPago, "sp_consultarCabPagoCliente " & v_parametros)
        '-- el detalle
        listarDetallePago(" where idConfig=0")
    End Sub

    Private Sub listarDetallePago(ByVal where As String)
        '-- el detalle
        systemClass.SqlToLvDetalleCobroCliente(lvDetPago, "Select nroCuota,montoCuota,vence,pagado,pago,habPagado,vencido from tmpDetPagoCliente  " & where)
    End Sub

    Public Sub listarPagoPorCuota(ByVal v_parametros As String)
        systemClass.SqlToDg_cobroPorCuota(dtgPagoCuota, "sp_consultaCobroPorCuota " & v_parametros)
    End Sub

    Private Sub controlarCobro()
        '-- controlar si existe un total
        If IsNumeric(txtPagado.Text) Then
            If txtPagado.Text <= 0 Then
                MessageBox.Show("El Total no es el Correcto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bolError = True
                Exit Sub
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        banGl_cobroCliente = True

        frmBuscarClienteVenta.txtIdCliente.Text = ""
        frmBuscarClienteVenta.Show()
        frmBuscarClienteVenta.BringToFront()
        frmBuscarClienteVenta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarCobro()
        If bolError = False Then
            Me.Enabled = False
            '-- colocar los datos 
            frmGuardarCobro.txtIdCliente.Text = txtIdCliente.Text
            frmGuardarCobro.txtCliente.Text = txtCliente.Text
            frmGuardarCobro.txtDireccion.Text = txtDireccion.Text
            frmGuardarCobro.txtCel1.Text = txtCel1.Text
            frmGuardarCobro.txtCel2.Text = txtCel2.Text
            frmGuardarCobro.txtEmail.Text = txtEmail.Text
            frmGuardarCobro.txtGrupo.Text = txtGrupo.Text
            frmGuardarCobro.txtPagado.Text = txtPagado.Text
            frmGuardarCobro.txtPagado.Text = Format(CDbl(frmGuardarCobro.txtPagado.Text), "###,###,##0.##")

            frmGuardarCobro.txtDsuc.Text = ""
            frmGuardarCobro.txtDcaja.Text = ""
            frmGuardarCobro.txtRecibo.Text = ""
            frmGuardarCobro.txtDescuento.Text = 0
            '-- la empresa contable
            'MsgBox("Valor de idPersonaJur  " & intGl_idPersonaJur)
            frmGuardarCobro.lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresacontable where idPersonaJur=" & intGl_idPersonaJur)
            '--------------------------
            frmGuardarCobro.Show()
            frmGuardarCobro.BringToFront()
            frmGuardarCobro.txtDsuc.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*****************'
    '-- RADIOBUTTON --'
    '*****************'
    Private Sub rdPorFactura_Click(sender As Object, e As System.EventArgs) Handles rdPorFactura.Click
        If rdPorFactura.Checked = True Then
            grMonto.Visible = False
            grCabPago.Visible = False
            grDetPago.Visible = False
            grPagoPorFactura.Visible = True
            '-- generar las cuotas a cobrar
            If IsNumeric(txtIdCliente.Text) Then
                listarPagoPorCuota(intGl_idConfigPc)
                dtgPagoCuota.Focus()
            End If
        End If
    End Sub

    Private Sub rdPorMonto_Click(sender As Object, e As System.EventArgs) Handles rdPorMonto.Click
        'If rdPorMonto.Checked = True Then
        '    grPagoPorFactura.Visible = False
        '    grCabPago.Visible = True
        '    grDetPago.Visible = True
        '    grMonto.Visible = True
        '    txtMonto.Text = 0
        '    txtMonto.Focus()
        'End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgPago_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgPago.CellFormatting
        '-- formato total factura
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.PaleGreen
        End If
        '-- formato pago
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("pagado") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Aquamarine
        End If
        '-- formato total pagado
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("Column6") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Thistle
        End If
        '-- formato saldo
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("saldo") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub dtgPago_GotFocus(sender As Object, e As System.EventArgs) Handles dtgPago.GotFocus
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            '-- habilitar si es la opcion de pago por factura
            If rdPorFactura.Checked = True Then
                dtgPago.Rows(i).Cells(7).ReadOnly = False
            Else
                dtgPago.Rows(i).Cells(7).ReadOnly = True
            End If
        Next
    End Sub

    '-- colocar los puntos separadores
    Private Sub dtgPago_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgPago.SelectionChanged
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            '-- el total monto de factura
            dtgPago.Rows(i).Cells(4).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(4).Value)
            '-- lo pagado
            dtgPago.Rows(i).Cells(5).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(5).Value)
            '-- el total pagado
            dtgPago.Rows(i).Cells(6).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(6).Value)
            '-- el total del saldo
            dtgPago.Rows(i).Cells(7).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(7).Value)
        Next
        '-- sumar los totales
        sumarTotales()
    End Sub

    Private Sub dtgPago_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPago.RowEnter
        Dim row As DataGridViewRow = dtgPago.Rows(e.RowIndex)
        Dim intTmpIdMov As Integer
        intTmpIdMov = CStr(row.Cells(1).Value)
        '-- listar el detalle de la cuota
        listarDetallePago(" where idConfig=" & intGl_idConfigPc & " and idMov=" & intTmpIdMov)
    End Sub

    '-------------------------------'
    '-- GRILLA DEL PAGO POR CUOTA --'
    '-------------------------------'
    Private Sub dtgPagoCuota_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgPagoCuota.CellFormatting
        '-- formato nrocuota
        If dtgPagoCuota.Columns(e.ColumnIndex).Name.Equals("nroCuota") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        '-- formato monto cuota
        If dtgPagoCuota.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn4") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.PaleGreen
        End If
        '-- formato total pagado
        If dtgPagoCuota.Columns(e.ColumnIndex).Name.Equals("Column7") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Thistle
        End If
        '-- formato pago
        If dtgPagoCuota.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn5") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Aquamarine
        End If
        '-- formato saldo
        If dtgPagoCuota.Columns(e.ColumnIndex).Name.Equals("totalSaldo") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub dtgPagoCuota_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPagoCuota.CellContentClick
        '-- variables
        Dim douTmpTotalFactura As Double
        Dim douTmpTotalPago As Double
        Dim douTmpTotalSaldo As Double
        Dim douTmpTotalPagado As Double
        Dim douTmpTotalNotaCredito As Double

        If e.ColumnIndex = 11 Then
            'MsgBox("Paso por aca 1")
            If dtgPagoCuota.Rows(e.RowIndex).Cells(0).Value > 0 Then
                ' MsgBox("Paso por aca 2")
                If (Convert.ToBoolean(dtgPagoCuota.Rows(e.RowIndex).Cells(11).Value)) Then
                    'MsgBox("Paso por aca 3")
                    dtgPagoCuota.Rows(e.RowIndex).Cells(11).Value = False
                    dtgPagoCuota.Rows(e.RowIndex).Cells(9).Value = 0
                    '-- el saldo
                    dtgPagoCuota.Rows(e.RowIndex).Cells(10).Value = CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(6).Value)) - (CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(8).Value)) + CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(7).Value)))
                Else
                    If rdPorFactura.Checked = True Then
                        '-- pago por factura
                        'MsgBox("Paso por aca 4")
                        dtgPagoCuota.Rows(e.RowIndex).Cells(11).Value = True
                        '-- dar valor a las variables
                        douTmpTotalFactura = CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(6).Value))
                        douTmpTotalPago = CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(6).Value)) - (CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(8).Value)) + CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(7).Value)))
                        douTmpTotalPagado = CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(8).Value))
                        douTmpTotalNotaCredito = CDbl(sacarComa(dtgPagoCuota.Rows(e.RowIndex).Cells(7).Value))
                        douTmpTotalSaldo = douTmpTotalFactura - (douTmpTotalPagado + douTmpTotalPago + douTmpTotalNotaCredito)
                        '-- dar el valor a pagar
                        dtgPagoCuota.Rows(e.RowIndex).Cells(9).Value = douTmpTotalPago
                        dtgPagoCuota.Rows(e.RowIndex).Cells(10).Value = douTmpTotalSaldo

                        sumarTotalesPorCuota()
                    End If

                    If rdPorMonto.Checked = True Then
                        '-- pago de monto por factura
                        Me.Enabled = False
                        '-- datos del formulario
                        'frmMontoFacturaCliente.txtMonto.Text = 0
                        'frmMontoFacturaCliente.lblCliente.Text = txtCliente.Text
                        'frmMontoFacturaCliente.lblFactura.Text = dtgPagoCuota.Rows(e.RowIndex).Cells(3).Value
                        'frmMontoFacturaCliente.lblIdCuota.Text = dtgPagoCuota.Rows(e.RowIndex).Cells(2).Value
                        'frmMontoFacturaCliente.lblIdMov.Text = dtgPagoCuota.Rows(e.RowIndex).Cells(1).Value
                        'frmMontoFacturaCliente.lblMontoTotalFactura.Text = dtgPagoCuota.Rows(e.RowIndex).Cells(6).Value
                        'frmMontoFacturaCliente.lblNroCuota.Text = dtgPagoCuota.Rows(e.RowIndex).Cells(5).Value
                        frmMontoFacturaCliente.lblSaldo.Text = dtgPagoCuota.Rows(e.RowIndex).Cells(9).Value
                        '---------------------------------------------------------------------------------------------
                        frmMontoFacturaCliente.Show()
                        frmMontoFacturaCliente.BringToFront()
                        frmMontoFacturaCliente.txtMonto.Focus()
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub dtgPagoCuota_GotFocus(sender As Object, e As System.EventArgs) Handles dtgPagoCuota.GotFocus
        For i As Integer = 0 To dtgPagoCuota.Rows.Count - 1
            If dtgPagoCuota.Rows(i).Cells(0).Value > 0 Then
                dtgPagoCuota.Rows(i).Cells(11).ReadOnly = False
            Else
                dtgPagoCuota.Rows(i).Cells(11).ReadOnly = True
            End If
        Next
    End Sub

    '-- colocar los puntos separadores
    Private Sub dtgPagoCuota_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgPagoCuota.SelectionChanged
        For i As Integer = 0 To dtgPagoCuota.Rows.Count - 1
            '-- el total monto de factura
            dtgPagoCuota.Rows(i).Cells(6).Value = formatoNumerosDecimales(dtgPagoCuota.Rows(i).Cells(6).Value)
            '-- el total de la nota de credito
            dtgPagoCuota.Rows(i).Cells(7).Value = formatoNumerosDecimales(dtgPagoCuota.Rows(i).Cells(7).Value)
            '-- lo pagado
            dtgPagoCuota.Rows(i).Cells(8).Value = formatoNumerosDecimales(dtgPagoCuota.Rows(i).Cells(8).Value)
            '-- el total pagado
            dtgPagoCuota.Rows(i).Cells(9).Value = formatoNumerosDecimales(dtgPagoCuota.Rows(i).Cells(9).Value)
            '-- el total del saldo
            dtgPagoCuota.Rows(i).Cells(10).Value = formatoNumerosDecimales(dtgPagoCuota.Rows(i).Cells(10).Value)

        Next
        '-- sumar los totales
        sumarTotalesPorCuota()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCobroCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteCobro.Enabled = True

        e.Cancel = False
    End Sub
    '------------------------------------------------------------------------------
End Class