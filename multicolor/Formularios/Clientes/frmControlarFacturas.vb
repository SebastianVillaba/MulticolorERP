Public Class frmControlarFacturas
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        actualizarVenta()
        listarVenta(" where idConfig=" & intGl_idConfigPc)
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarVenta()
        '-- cargar la tabla temporal
        If (fun_guardarSp("sp_agregarTmpControlFacturaCredito", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Cargar la Tabla temporal de los controles de facturas|...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub listarVenta(ByVal v_where As String)
        '-- limpiar la grilla
        dtgFactura.Rows.Clear()

        systemClass.SqlToDg_controlarFacturaVenta(dtgFactura, "select row_number() over(order by idVenta),sucursal,idVenta,factura," & _
        "fecha,cliente,totalFactura,vendedor,controlado from tmpControlFacturaCredito " & v_where)

        txtSql.Text = "select row_number() over(order by idVenta),sucursal,idVenta,factura," & _
        "fecha,cliente,totalFactura,vendedor,controlado from tmpControlFacturaCredito " & v_where

    End Sub

    Private Sub guardarControlFactura()
        '-- recorrer la forma de venta
        For i As Integer = 0 To dtgFactura.Rows.Count - 1
            If CBool(dtgFactura.Rows(i).Cells(8).Value()) = True Then
                '-- actualizar el porcentaje adicional
                sp_datosTabla.consulta_valor("update tmpControlFacturaCredito set controlado=1 where idVenta=" & CInt(dtgFactura.Rows(i).Cells(2).Value()) & " and idConfig=" & intGl_idConfigPc)
            End If
        Next
        '-- procedimiento para guardar los controles
        If (fun_guardarSp("sp_guardarControlFactura", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los controles de la Factura...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            listarVenta(" where idConfig=" & intGl_idConfigPc)
        End If
    End Sub
    '--------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        If rdCliente.Checked = True Then
            If Len(txtBuscar.Text) > 0 Then
                '-- buscar por idVenta o cliente
                If IsNumeric(txtBuscar.Text) Then
                    '-- por idventa
                    listarVenta(" where idConfig=" & intGl_idConfigPc & " and idventa=" & txtBuscar.Text)
                Else
                    '-- por cliente
                    listarVenta(" Where (cliente Like '" & txtBuscar.Text & "%' Or cliente Like '" & txtBuscar.Text & "%') and idConfig=" & intGl_idConfigPc)
                End If
            Else
                '-- actualizar
                actualizarVenta()
                '-- listar todo
                listarVenta(" where idConfig=" & intGl_idConfigPc)
            End If
        End If
        If rdFactura.Checked Then
            '-- buscar por factura
            If Len(txtFactura.Text) > 0 Then
                listarVenta("where idConfig=" & intGl_idConfigPc & " and factura='" & Trim(txtDsuc.Text) & "-" & Trim(txtDcaja.Text) & "-" & Trim(txtFactura.Text) & "'")
            Else
                '-- listar todo
                listarVenta(" where idConfig=" & intGl_idConfigPc)
            End If
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        '-- listar todo
        listarVenta(" where idConfig=" & intGl_idConfigPc)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar las Facturas Controladas..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarControlFactura()
        End If
    End Sub
    '--------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdCliente.CheckedChanged
        If rdCliente.Checked = True Then
            txtDcaja.Visible = False
            txtDsuc.Visible = False
            txtFactura.Visible = False

            txtBuscar.Visible = True
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub rdFactura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdFactura.CheckedChanged
        If rdFactura.Checked = True Then
            txtDcaja.Visible = True
            txtDsuc.Visible = True
            txtFactura.Visible = True

            txtBuscar.Visible = False
            txtDsuc.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgFactura_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgFactura.CellFormatting
        '-- formato total factura
        If dtgFactura.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If
        '-- formato de la sucursal
        If dtgFactura.Columns(e.ColumnIndex).Name.Equals("Column7") Then
            'e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- formato del cliente
        If dtgFactura.Columns(e.ColumnIndex).Name.Equals("cotiza") Then
            'e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.LightSkyBlue
        End If
    End Sub

    Private Sub dtgFactura_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgFactura.CellContentClick
        If e.ColumnIndex = 12 Then
            If dtgFactura.Rows(e.RowIndex).Cells(0).Value > 0 Then
                If (Convert.ToBoolean(dtgFactura.Rows(e.RowIndex).Cells(8).Value)) Then

                    dtgFactura.Rows(e.RowIndex).Cells(8).Value = False
                    'dtgPago.Rows(e.RowIndex).Cells(8).Value = 0
                Else
                    dtgFactura.Rows(e.RowIndex).Cells(8).Value = True
                End If
            End If
        End If
    End Sub

    Private Sub dtgFactura_GotFocus(sender As Object, e As System.EventArgs) Handles dtgFactura.GotFocus
        For i As Integer = 0 To dtgFactura.Rows.Count - 1
            If dtgFactura.Rows(i).Cells(0).Value > 0 Then
                dtgFactura.Rows(i).Cells(8).ReadOnly = False
            Else
                dtgFactura.Rows(i).Cells(8).ReadOnly = True
            End If
        Next
    End Sub

    '-- colocar los puntos separadores
    Private Sub dtgFactura_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgFactura.SelectionChanged
        For i As Integer = 0 To dtgFactura.Rows.Count - 1
            '-- el total de la venta
            dtgFactura.Rows(i).Cells(6).Value = formatoNumerosDecimales(dtgFactura.Rows(i).Cells(6).Value)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------------
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
            btnBuscar.Focus()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmControlarFacturas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        '.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------
End Class