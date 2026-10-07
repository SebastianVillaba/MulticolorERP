Public Class frmGuardarPagoProveedor
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdCuenta As Integer
    Dim strNroCuenta As String
    Dim strNombreBanco As String
    Dim douImporteCheque As Double
    Dim strVenceCheque As String
    Dim intIdCheque As Integer
    Dim bolError As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarChequeProveedor(ByVal v_idproveedor As Integer)
        systemClass.SqlToLv_consultaChequePagoProveedor(lvCheque, " select dch.cheque,cu.nroCuenta,cu.nombreBanco,dch.fecha,dch.monto,dch.idChequera" & _
                                           " from detCheque dch inner join chequera ch on dch.idChequera=ch.idChequera " & _
                                           " inner join cuentaCorriente cu on cu.idCuenta=ch.idCuenta " & _
                                           " where dch.habilitado=1 and dch.pagado=0 and dch.idProveedor=" & v_idproveedor)
        txtSql.Text = " select dch.cheque,cu.nroCuenta,cu.nombreBanco,dch.fecha,dch.monto,dch.idChequera" & _
                                           " from detCheque dch inner join chequera ch on dch.idChequera=ch.idChequera " & _
                                           " inner join cuentaCorriente cu on cu.idCuenta=ch.idCuenta " & _
                                           " where dch.habilitado=1 and dch.pagado=0 and dch.idProveedor=" & v_idproveedor
    End Sub

    Public Sub sumarTotalPagoProveedor()
        '-- variables para la suma
        Dim douTmpTotal As Double = 0

        For i As Integer = 0 To dtgPago.Rows.Count - 1
            If dtgPago.Rows(i).Cells(0).Value > 0 Then
                douTmpTotal = douTmpTotal + dtgPago.Rows(i).Cells(5).Value
            End If
        Next
        '-- formato y valor al total a pagar
        txtTotalPagado.Text = douTmpTotal
        txtTotalPagado.Text = Format(CDec(txtTotalPagado.Text), "#,###,###.##")
    End Sub

    Private Sub controlarGuardar()
        '-- si no se ingresa el nro de recibo
        If IsNumeric(txtNroRecibo.Text) Then
            If txtNroRecibo.Text <= 0 Then
                MessageBox.Show("Debe Ingresar un Número de Recibo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bolError = True
                Exit Sub
            End If
        Else
            MessageBox.Show("Debe Ingresar un Número de Recibo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If
        '-- si el total pagado no coincide total a pagar
        If CDbl(txtTotalPagado.Text) <> CDbl(txtTotalPagar.Text) Then
            MessageBox.Show("El Total a Pagar no es Igual al Total Pagado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If
        '-- si no tiene detalle cargado
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            If dtgPago.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
            End If
        Next
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existen items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If

        '----------------------------------'
        '-- cargar las tablas temporales --'
        '----------------------------------'
        '-- eliminar todas las tablas
        sp_datosTabla.consulta_valor("delete detPagoProveedorMovTmp where idConfig=" & intGl_idConfigPc)
        sp_datosTabla.consulta_valor("delete detPagoProveedorEfectivoTmp where idConfig=" & intGl_idConfigPc)
        sp_datosTabla.consulta_valor("delete detPagoProveedorChequeTmp where idConfig=" & intGl_idConfigPc)

        '-- agregar los movimientos
        For i As Integer = 0 To frmPagoProveedor.dtgPago.Rows.Count - 1
            If frmPagoProveedor.dtgPago.Rows(i).Cells(0).Value > 0 Then
                If frmPagoProveedor.dtgPago.Rows(i).Cells(12).Value = True Then
                    If (fun_guardarSp("sp_agregarDetPagoProveedorMovTmp", intGl_idConfigPc & "," & frmPagoProveedor.dtgPago.Rows(i).Cells(1).Value & "," & frmPagoProveedor.dtgPago.Rows(i).Cells(10).Value, Me.Name)) = 0 Then
                        MessageBox.Show("Erorr al cargar el detalle de Pago de Movimientos...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        bolError = True
                        Exit Sub
                    End If
                End If
            End If
        Next
        '-- agregar los efectivos y cheques
        For i As Integer = 0 To dtgPago.Rows.Count - 1
            If dtgPago.Rows(i).Cells(0).Value > 0 Then
                If dtgPago.Rows(i).Cells(7).Value = True Then
                    '-- cargar efectivo
                    If (fun_guardarSp("sp_agregarDetPagoProveedorEfectivoTmp", intGl_idConfigPc & "," & dtgPago.Rows(i).Cells(5).Value, Me.Name)) = 0 Then
                        MessageBox.Show("Erorr al cargar el detalle de Pago de Efectivo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        bolError = True
                        Exit Sub
                    End If
                Else
                    '-- cargar cheques
                    If (fun_guardarSp("sp_agregarDetPagoProveedorChequeTmp", intGl_idConfigPc & "," & dtgPago.Rows(i).Cells(9).Value & "," & dtgPago.Rows(i).Cells(8).Value & "," & dtgPago.Rows(i).Cells(3).Value, Me.Name)) = 0 Then
                        MessageBox.Show("Erorr al cargar el detalle de Cheques...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        bolError = True
                        Exit Sub
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub guardarPago()
        '-- inicializar variables
        Dim intTmpIdProveedor As Integer
        Dim intTmpNroRecibo As Integer
        Dim strTmpFecha As String
        Dim douTmpTotalPagado As Double
        Dim douTmpAPagar As Double
        '-- dar valor a las variables
        intTmpIdProveedor = CInt(txtIdProveedor.Text)
        intTmpNroRecibo = txtNroRecibo.Text
        strTmpFecha = dtpFecha.Text
        douTmpTotalPagado = sacarComa(CDbl(txtTotalPagado.Text))
        douTmpAPagar = sacarComa(CDbl(txtTotalPagar.Text))
        '------------------------------------------------
        If (fun_guardarSp("sp_guardarPagoProveedor", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idPersonaJur & "," & intTmpIdProveedor & "," & intTmpNroRecibo & "," & "'" & strTmpFecha & "'" & "," & douTmpTotalPagado & "," & douTmpAPagar & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros del Pago...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- los txt
            txtTotalPagado.Text = 0
            txtNroRecibo.Text = 0
            '-- los lbl
            lblCheque.Text = 0
            lblIdChequera.Text = 0
            lblNro.Text = 0
            '-- la grilla
            dtgPago.Rows.Clear()
            '-- la variable global
            intGl_nroPagoProveedor = 0

            frmPagoProveedor.listar()
            Me.Close()

        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtNroRecibo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroRecibo.KeyPress
        e.Handled = txtNumerico(txtNroRecibo, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.##")

            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnCargarEfectivo_Click(sender As System.Object, e As System.EventArgs) Handles btnCargarEfectivo.Click
        If IsNumeric(txtMonto.Text) Then
            If txtMonto.Text > 0 Then
                '-- cargar la grilla
                cargarOrdenPagoProveedor("", "", 0, "", CDbl(sacarComa(txtMonto.Text)), True, 0, 0)
                txtMonto.Text = 0
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text > 0 Then
            If dtgPago.SelectedCells.Count > 0 Then
                dtgPago.Rows.Remove(dtgPago.CurrentRow)
                intGl_nroPagoProveedor = intGl_nroPagoProveedor - 1
            End If
            sumarTotalPagoProveedor()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        '-- los txt
        txtTotalPagado.Text = 0
        txtNroRecibo.Text = 0
        '-- los lbl
        lblCheque.Text = 0
        lblIdChequera.Text = 0
        lblNro.Text = 0
        '-- la grilla
        dtgPago.Rows.Clear()
        '-- la variable global
        intGl_nroPagoProveedor = 0
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarGuardar()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar el Pago..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarPago()
            End If
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- CHECKBOX --'
    '**************'
    Private Sub rdEfectivo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdEfectivo.CheckedChanged
        grEfectivo.Visible = True
        txtMonto.Text = 0
        txtMonto.Focus()
    End Sub

    Private Sub rdCheque_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdCheque.CheckedChanged
        grEfectivo.Visible = False
        lvCheque.Focus()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCheque_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvCheque.SelectedIndexChanged
        For Each item As ListViewItem In lvCheque.SelectedItems
            '-- idChequera
            lblIdChequera.Text = CInt(item.SubItems(5).Text)
            '-- nro de cheque
            lblCheque.Text = CInt(item.SubItems(0).Text)
            '-- cargar las variables
            intIdCuenta = sp_datosTabla.consulta_valor("select idCuenta from chequera where idChequera=" & CInt(item.SubItems(5).Text))

            intIdCheque = sp_datosTabla.consulta_valor("select idCheque from detCheque where idchequera=" & CInt(item.SubItems(5).Text) & _
                                                     " and idProveedor=" & CInt(txtIdProveedor.Text) & " and cheque=" & CInt(item.SubItems(0).Text))

            strNroCuenta = sp_datosTabla.consulta_valorString("select nroCuenta from cuentaCorriente where idCuenta=" & intIdCuenta)
            strNombreBanco = sp_datosTabla.consulta_valorString("select nombreBanco from cuentaCorriente where idCuenta=" & intIdCuenta)
            douImporteCheque = CDbl(item.SubItems(4).Text)
            strVenceCheque = item.SubItems(3).Text
        Next
    End Sub

    Private Sub lvCheque_GotFocus(sender As Object, e As System.EventArgs) Handles lvCheque.GotFocus
        ''-- idChequera
        'lblIdChequera.Text = CInt(item.SubItems(5).Text)
        ''-- nro de cheque
        'lblCheque.Text = CInt(item.SubItems(0).Text)
        ''-- cargar las variables
        'intIdCuenta = sp_datosTabla.consulta_valor("select idCuenta from chequera where idChequera=" & lblIdChequera.Text)
        'strNroCuenta = sp_datosTabla.consulta_valorString("select nroCuenta from cuentaCorriente where idCuenta=" & intIdCuenta)
        'strNombreBanco = sp_datosTabla.consulta_valorString("select nombreBanco from cuentaCorriente where idCuenta=" & intIdCuenta)
        'douImporteCheque = CDbl(item.SubItems(4).Text)
        'strVenceCheque = item.SubItems(3).Text
    End Sub

    Private Sub lvCheque_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvCheque.KeyPress
        If IsNumeric(lblIdChequera.Text) Then
            If lblIdChequera.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    '-- cargar las variables
                    cargarOrdenPagoProveedor(strNroCuenta, strNombreBanco, CInt(lblCheque.Text), strVenceCheque, douImporteCheque, False, lblIdChequera.Text, intIdCheque)
                End If
            End If
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '******************'
    '-- DATAGRIDVIEW --'
    '******************'
    Private Sub dtgPago_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgPago.CellFormatting
        '-- formato del importe
        If dtgPago.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.Format = ("###,###,###.##")
        End If
    End Sub

    Private Sub dtgPago_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPago.RowEnter
        Dim row As DataGridViewRow = dtgPago.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmGuardarPagoProveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmPagoProveedor.Enabled = True
        frmPagoProveedor.Show()
        frmPagoProveedor.BringToFront()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
End Class