Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPagoProveedor
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim tipoCompra As New tipoCompra

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo de la cuenta corriente
        tipoCompra.tipoCompraCombo(cboTipoCompra)
        '-- inicializar las fechas
        dtpDesde.Format = DateTimePickerFormat.Custom
        dtpHasta.CustomFormat = "dd/MM/yyyy"
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiarObjetos()
        '-- txt
        txtProveedor.Text = ""
        txtIdProveedor.Text = 0
        txtTotalCompra.Text = 0
        txtTotalGasto.Text = 0
        txtTotalNotaCredito.Text = 0
        txtTotalPagar.Text = 0
    End Sub

    Public Sub listar()
        '-- limpiar la grilla
        dtgPago.Rows.Clear()

        systemClass.SqlToDg_ordenPago(dtgPago, "sp_ordenPagoProveedor " & txtIdProveedor.Text & "," & cboTipoCompra.SelectedValue & "," & "'" & dtpDesde.Text & "'" & "," & "'" & dtpHasta.Text & "'")
        'txtSql.Text=
        'SysmteClass.formatofecha(DateTimePicker1)

    End Sub

    Private Sub sumarTotales()
        'MsgBox("Entro al proceso de sumar totales")
        Dim douTmpTotalCompra As Double
        Dim douTmpTotalNotaCredito As Double
        Dim douTmpTotalNotaCreditoCanje As Double
        Dim douTmpTotalGasto As Double
        Dim douTmpTotalPagado As Double
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            If dtgPago.Rows(i).Cells(0).Value > 0 Then
                If dtgPago.Rows(i).Cells(10).Value <> 3 Then
                    '-- total compra
                    douTmpTotalCompra = douTmpTotalCompra + CDbl(dtgPago.Rows(i).Cells(5).Value)
                End If
                If dtgPago.Rows(i).Cells(10).Value = 3 Then
                    '-- total gasto
                    douTmpTotalGasto = douTmpTotalGasto + CDbl(dtgPago.Rows(i).Cells(5).Value)
                End If
                '-- total nota de credito
                douTmpTotalNotaCredito = douTmpTotalNotaCredito + CDbl(dtgPago.Rows(i).Cells(6).Value)
                '-- total nota de credito de canje
                douTmpTotalNotaCreditoCanje = douTmpTotalNotaCreditoCanje + CDbl(dtgPago.Rows(i).Cells(7).Value)
                'MsgBox("Valor de la celda  " & dtgPago.Rows(i).Cells(10).Value)
                If dtgPago.Rows(i).Cells(12).Value = True Then
                    'MsgBox("PAso por aca en la suma del total pagado")
                    '-- total pagado
                    douTmpTotalPagado = douTmpTotalPagado + (CDbl(dtgPago.Rows(i).Cells(5).Value) - CDbl(dtgPago.Rows(i).Cells(6).Value) - CDbl(dtgPago.Rows(i).Cells(7).Value))
                End If
            End If
        Next
        txtTotalCompra.Text = douTmpTotalCompra
        txtTotalCompra.Text = Format(CDec(txtTotalCompra.Text), "###,###,###.##")
        txtTotalNotaCredito.Text = douTmpTotalNotaCredito
        txtTotalNotaCredito.Text = Format(CDec(txtTotalNotaCredito.Text), "###,###,###.##")
        txtTotalGasto.Text = douTmpTotalGasto
        txtTotalGasto.Text = Format(CDec(txtTotalGasto.Text), "###,###,###.##")
        txtTotalPagar.Text = douTmpTotalPagado
        txtTotalPagar.Text = Format(CDec(txtTotalPagar.Text), "###,###,###.##")
        txtTotalCanje.Text = douTmpTotalNotaCreditoCanje
        txtTotalCanje.Text = Format(CDec(txtTotalCanje.Text), "###,###,###.##")
    End Sub

    Private Sub imprimirPago()
        Try
            Dim intTmpIdConfig As Integer
            intTmpIdConfig = intGl_idConfigPc

            Dim pvParametros As New ParameterValues()
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            Dim pvIdDeposito As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idConfigCon As New ParameterDiscreteValue()
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_ordenPago
            Dim ofrm As New crv()

            v_idConfigCon.Value = intTmpIdConfig
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros.Add(v_idConfigCon)
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
            rpt.DataDefinition.ParameterFields("@idConfigCon").ApplyCurrentValues(pvParametros)
            '-- asignar los valores al objeto del reporte
            ofrm.CrystalReportViewer1.ReportSource = rpt
            '-- procedimiento para evitar el usuario y contraseña de la base de datos
            evitarPassDatabase(rpt)
            '-- mostrar el reporte
            ofrm.WindowState = FormWindowState.Maximized
            ofrm.Show()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '--------------------------------------------------------------------------------

    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        '-- solo si se intrduce un proveedor
        If Len(txtProveedor.Text) = 0 Then
            MessageBox.Show("Debe Ingresar el Proveedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        listar()
        sumarTotales()
        dtgPago.Focus()
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarProveedor.Click
        banGl_pagoProveedor = True
        Me.Enabled = False

        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.Visible = True
        frmBuscarProveedor.WindowState = FormWindowState.Normal
        frmBuscarProveedor.Show()
        frmBuscarProveedor.txtBuscar.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        '-- guardar la orden de pago 
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            If dtgPago.Rows(i).Cells(0).Value > 0 Then
                '-- guardar las compras
                If dtgPago.Rows(i).Cells(10).Value = 1 Then
                    '-- orden de pago activado
                    If dtgPago.Rows(i).Cells(11).Value = True Then
                        '-- activado
                        '-- imp
                        sp_datosTabla.consulta_valor("update cabCompra set ordenPago=1 where idCompra=" & dtgPago.Rows(i).Cells(1).Value)
                        '-- nimp
                        sp_datosTabla.consulta_valor("update cco set ordenPago=1 where idCompra=" & dtgPago.Rows(i).Cells(1).Value)
                    Else
                        '-- no activado
                        '-- imp
                        sp_datosTabla.consulta_valor("update cabCompra set ordenPago=0 where idCompra=" & dtgPago.Rows(i).Cells(1).Value)
                        '-- nimp
                        sp_datosTabla.consulta_valor("update cco set ordenPago=0 where idCompra=" & dtgPago.Rows(i).Cells(1).Value)
                    End If
                End If
                '-- guardar los gastos
                If dtgPago.Rows(i).Cells(10).Value = 2 Then
                    If dtgPago.Rows(i).Cells(11).Value = True Then
                        '-- activado
                        '-- imp
                        sp_datosTabla.consulta_valor("update cabGasto set ordenPago=1 where idGasto=" & dtgPago.Rows(i).Cells(1).Value)
                        '-- nimp
                        sp_datosTabla.consulta_valor("update cga set ordenPago=1 where idGasto=" & dtgPago.Rows(i).Cells(1).Value)
                    Else
                        '-- no activado
                        '-- imp
                        sp_datosTabla.consulta_valor("update cabGasto set ordenPago=0 where idGasto=" & dtgPago.Rows(i).Cells(1).Value)
                        '-- nimp
                        sp_datosTabla.consulta_valor("update cga set ordenPago=0 where idGasto=" & dtgPago.Rows(i).Cells(1).Value)
                    End If

                End If
            End If
        Next
        '-- verificar si es que hay algo para guardar
        If IsNumeric(txtTotalPagar.Text) Then
            If txtTotalPagar.Text > 0 Then
                '-- actualizar los objetos en el formulario de guardar pagos
                intGl_nroPagoProveedor = 0

                frmGuardarPagoProveedor.lblNro.Text = 0
                frmGuardarPagoProveedor.lblCheque.Text = 0
                frmGuardarPagoProveedor.lblIdChequera.Text = 0
                frmGuardarPagoProveedor.grEfectivo.Visible = False
                frmGuardarPagoProveedor.rdEfectivo.Checked = False
                frmGuardarPagoProveedor.rdCheque.Checked = True
                frmGuardarPagoProveedor.txtIdProveedor.Text = txtIdProveedor.Text
                frmGuardarPagoProveedor.txtProveedor.Text = txtProveedor.Text
                frmGuardarPagoProveedor.txtTotalPagar.Text = txtTotalPagar.Text
                frmGuardarPagoProveedor.txtTotalPagar.Text = Format(CDec(frmGuardarPagoProveedor.txtTotalPagar.Text), "###,###,###.##")
                '-- listar los cheques para el proveedor
                frmGuardarPagoProveedor.listarChequeProveedor(CInt(txtIdProveedor.Text))

                Me.Enabled = False
                frmGuardarPagoProveedor.Show()
                frmGuardarPagoProveedor.BringToFront()
                frmGuardarPagoProveedor.txtNroRecibo.Focus()
            Else
                MessageBox.Show("Debe marcar las facturas a pagar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            MessageBox.Show("Debe marcar las facturas a pagar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        '-- inicializar las variables
        Dim intTmpIdProveedor As Integer
        Dim strTmpProveedor As String
        Dim strTmpFactura As String
        Dim strTmpFecha As String
        Dim strTmpVence As String
        Dim douTmpTotalFactura As Double
        Dim douTmpTotalNotaCredito As Double
        Dim douTmpTotalCanje As Double
        Dim douTmpTotalPagar As Double
        Dim strTmpMoneda As String

        '-- pitar todos los registros en negro
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If dtgPago.Rows(i).Cells(0).Value > 0 Then
                dtgPago.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

        '-- eliminar todos los registros
        sp_datosTabla.consulta_valor("delete from tmpImprimirPago where idConfig=" & intGl_idConfigPc)
        '-- recorrer la grilla e imprimir solo los seleccionados
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If dtgPago.Rows(i).Cells(0).Value > 0 And dtgPago.Rows(i).Cells(12).Value = True Then
                '-- dar valor a las variables
                intTmpIdProveedor = CInt(txtIdProveedor.Text)
                strTmpProveedor = txtProveedor.Text
                strTmpFactura = dtgPago.Rows(i).Cells(2).Value
                strTmpFecha = dtgPago.Rows(i).Cells(3).Value
                strTmpVence = dtgPago.Rows(i).Cells(4).Value
                douTmpTotalFactura = dtgPago.Rows(i).Cells(5).Value
                douTmpTotalNotaCredito = dtgPago.Rows(i).Cells(6).Value
                douTmpTotalCanje = dtgPago.Rows(i).Cells(7).Value
                douTmpTotalPagar = dtgPago.Rows(i).Cells(8).Value
                strTmpMoneda = dtgPago.Rows(i).Cells(9).Value

                If (fun_guardarSp("sp_agregarTmpImprimirPago", intGl_idConfigPc & "," & "'" & dtpDesde.Text & "'" & "," & "'" & dtpHasta.Text & "'" & "," & intTmpIdProveedor & "," & "'" & strTmpProveedor & "'" & "," & "'" & strTmpFactura & "'" & "," & "'" & strTmpFecha & "'" & "," & "'" & strTmpVence & "'" & "," & douTmpTotalFactura & "," & douTmpTotalNotaCredito & "," & douTmpTotalCanje & "," & "'" & strTmpMoneda & "'", Me.Name)) = 0 Then
                    dtgPago.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Exit Sub
                Else
                    ' MessageBox.Show("total Factura  " & douTmpTotalFactura)
                End If
            End If
        Next

        imprimirPago()
    End Sub

    Private Sub btnSumar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSumar.Click
        sumarTotales()
    End Sub
    '--------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgPago_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgPago.CellFormatting
        '-- formato total factura
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If
        '-- formato total nota Credito
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("Column6") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- formato total pagado
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("Column7") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.LightSkyBlue
        End If
        '-- formato total canje
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("totalCanje") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MediumPurple
            e.CellStyle.ForeColor = Color.White
        End If
    End Sub

    Private Sub dtgPagp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPago.CellContentClick
        '-- variables
        Dim douTmpTotalFactura As Double
        Dim douTmpTotalNotaCredito As Double
        Dim douTmpTotalCanje As Double
        Dim douTmpTotalPagado As Double

        If e.ColumnIndex = 12 Then
            If dtgPago.Rows(e.RowIndex).Cells(0).Value > 0 Then
                If (Convert.ToBoolean(dtgPago.Rows(e.RowIndex).Cells(12).Value)) Then

                    dtgPago.Rows(e.RowIndex).Cells(12).Value = False
                    dtgPago.Rows(e.RowIndex).Cells(8).Value = 0
                Else
                    dtgPago.Rows(e.RowIndex).Cells(12).Value = True
                    '-- dar valor a las variables
                    douTmpTotalFactura = CDbl(sacarComa(dtgPago.Rows(e.RowIndex).Cells(5).Value))
                    douTmpTotalNotaCredito = CDbl(sacarComa(dtgPago.Rows(e.RowIndex).Cells(6).Value))
                    douTmpTotalCanje = CDbl(sacarComa(dtgPago.Rows(e.RowIndex).Cells(7).Value))
                    douTmpTotalPagado = douTmpTotalFactura - (douTmpTotalNotaCredito + douTmpTotalCanje)
                    '-- dar el valor a pagar
                    ' MsgBox("Total Factura  " & douTmpTotalFactura)
                    ' MsgBox("Total Nota Credito  " & douTmpTotalNotaCredito)
                    ' MsgBox("Total Nota Canje  " & douTmpTotalCanje)
                    ' MsgBox("Total a Pagar  " & douTmpTotalPagado)


                    dtgPago.Rows(e.RowIndex).Cells(8).Value = douTmpTotalPagado
                End If
                sumarTotales()
            End If
        End If
    End Sub

    Private Sub dtgPago_GotFocus(sender As Object, e As System.EventArgs) Handles dtgPago.GotFocus
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            If dtgPago.Rows(i).Cells(0).Value > 0 Then
                dtgPago.Rows(i).Cells(9).ReadOnly = False
            Else
                dtgPago.Rows(i).Cells(9).ReadOnly = True
            End If
        Next
    End Sub

    '-- colocar los puntos separadores
    Private Sub dtgPago_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgPago.SelectionChanged
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            '-- el total de la compra
            dtgPago.Rows(i).Cells(5).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(5).Value)

            'MsgBox("Valor de la celda5  " & (dtgPago.Rows(i).Cells(5).Value))
            'MsgBox("Valor del total  " & formatoNumerosDecimales(dtgPago.Rows(i).Cells(5).Value))
            '-- el total de la nota de credito
            dtgPago.Rows(i).Cells(6).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(6).Value)
            '-- el total canje
            dtgPago.Rows(i).Cells(7).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(7).Value)
            '-- el total a pagar
            dtgPago.Rows(i).Cells(8).Value = formatoNumerosDecimales(dtgPago.Rows(i).Cells(8).Value)
            '-- sumar los totales
            'sumarTotales()
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmPagoProveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.proveedorPagoProveedor.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------

End Class