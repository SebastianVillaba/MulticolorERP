Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmGuardarCobro
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim cobrador As New cobrador
    Dim tipoCobro As New tipoCobro


    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar el cobrador y el tipo de cobro
        cobrador.comboCobrador(cboCobrador)
        tipoCobro.tipoCobroCombo(cboTipoCobro)
        tipoCobro.tipoCobroCombo(cboFormaVentaCombinado)

        dtpFecha.Format = DateTimePickerFormat.Custom
        dtpFecha.CustomFormat = "dd/MM/yyyy"
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub guardarCobro()
        '-- actualizar el detalle
        '-- inicializa la variable
        'Dim intTmpIdCuota As Integer
        'Dim intTmpNroCuota As Integer
        'Dim douTmpMonto As Double
        ''-- eliminar todos los registros temporales anteriores
        'sp_datosTabla.consulta_valorString("delete from detCobroTmp where idConfig=" & intGl_idConfigPc)
        ''-- recorrer la grilla y cargarlo
        'For i As Integer = 0 To frmCobroCliente.dtgPagoCuota.Rows.Count - 1
        '    If frmCobroCliente.dtgPagoCuota.Rows(i).Cells(0).Value > 0 And frmCobroCliente.dtgPagoCuota.Rows(i).Cells(12).Value = True Then
        '        '-- dar valor a las variables
        '        intTmpIdCuota = frmCobroCliente.dtgPagoCuota.Rows(i).Cells(2).Value
        '        intTmpNroCuota = frmCobroCliente.dtgPagoCuota.Rows(i).Cells(5).Value
        '        douTmpMonto = (CDbl(sacarComa(frmCobroCliente.dtgPagoCuota.Rows(i).Cells(10).Value))) + _
        '            (CDbl(sacarComa(frmCobroCliente.dtgPagoCuota.Rows(i).Cells(7).Value))) + _
        '            (CDbl(sacarComa(frmCobroCliente.dtgPagoCuota.Rows(i).Cells(8).Value))) + _
        '            (CDbl(sacarComa(frmCobroCliente.dtgPagoCuota.Rows(i).Cells(9).Value)))
        '        If (fun_guardarSp("sp_agregarDetCobroTmp", intGl_idConfigPc & "," & intTmpIdCuota & "," & intTmpNroCuota & "," & douTmpMonto, Me.Name)) = 0 Then
        '            Exit Sub
        '        End If
        '    End If
        'Next

        '-- inicializar las variables
        Dim intTmpIdCliente As Integer
        Dim intTmpIdCobrador As Integer
        Dim intTmpIdTipoCobro As Integer
        Dim strTmpDsuc As String
        Dim strTmpDcaja As String
        Dim strTmpRecibo As String
        Dim strTmpFecha As String
        Dim douTmpTotalCobro As Double
        Dim douTmpTotalDescuento As Double

        '-- dar valor a las variables
        intTmpIdCliente = CInt(txtIdCliente.Text)
        intTmpIdCobrador = cboCobrador.SelectedValue
        intTmpIdTipoCobro = cboTipoCobro.SelectedValue
        strTmpDsuc = txtDsuc.Text
        strTmpDcaja = txtDcaja.Text
        strTmpRecibo = txtRecibo.Text
        strTmpFecha = dtpFecha.Text
        douTmpTotalCobro = CDbl(sacarComa(txtPagado.Text))
        douTmpTotalDescuento = CDbl(sacarComa(txtDescuento.Text))

        If (fun_guardarSp("sp_guardarCobroCliente", intGl_idConfigPc & "," & intGl_idPersonaJur & "," & intTmpIdCliente & "," & intTmpIdCobrador & _
                          "," & intTmpIdTipoCobro & "," & "'" & strTmpDsuc & "'" & "," & "'" & strTmpDcaja & "'" & "," & "'" & strTmpRecibo & "'" & _
                          "," & "'" & strTmpFecha & "'" & "," & douTmpTotalCobro & "," & douTmpTotalDescuento & "," & intGl_idUsuario & "," & _
                          "'" & txtNombreBanco.Text & "'," & chkCombinado.Checked & "," & cboFormaVentaCombinado.SelectedValue & "," & _
                          CDbl(sacarComa(txtMontoCombinado.Text)), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros del Cobro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- ver si se imprimime el recibo
            If strTmpRecibo = "0" Or strTmpRecibo = "" Then
                Me.Enabled = False
                ImprimirRecibo()
                Me.Enabled = True
            End If
            '-- los txt
            frmCobroClienteNuevo.limpiarObjetos()
            Me.Close()

        End If
    End Sub

    Private Sub ImprimirRecibo()
        Dim pvParametros As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idCobro As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_reciboCobro
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idCobro.Value = sp_datosTabla.consulta_valor("select max(idCobro) from cabCobro")
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idCobro)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCobro").ApplyCurrentValues(pvParametros)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt

        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Show()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If chkCombinado.Checked = True Then
            If CDbl(sacarComa(txtMontoCombinado.Text)) >= CDbl(sacarComa(txtPagado.Text)) Then
                MessageBox.Show("El monto combinado no puede ser igual o mayor al total cobrado...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If

        If MessageBox.Show("Desea Guardar la Cobranza.!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarCobro()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------
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

    Private Sub txtRecibo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecibo.KeyPress
        e.Handled = txtNumerico(txtRecibo, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPorceDescuento.Focus()
        End If
    End Sub

    Private Sub txtPorceDescuento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorceDescuento.KeyPress
        e.Handled = txtNumerico(txtPorceDescuento, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtPorceDescuento.Text) = 0 Then
                txtPorceDescuento.Text = 0
            End If
            e.Handled = True
            '-- calcular el monto del descuento
            If txtPorceDescuento.Text > 0 Then
                'MessageBox.Show("Paso 1")
                txtDescuento.Text = (CDbl(sacarComa(frmCobroClienteNuevo.txtPagado.Text)) * (CDbl(sacarComa(txtPorceDescuento.Text)) / 100))

            End If
            txtDescuento.Text = Format(CDec(txtDescuento.Text), "##,###,##0.##")
            txtDescuento.Focus()

        End If
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento.KeyPress
        e.Handled = txtNumerico(txtDescuento, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtDescuento.Text) = 0 Then
                txtDescuento.Text = 0
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtDescuento.Text = Format(CDec(txtDescuento.Text), "##,###,##0.##")
        End If
    End Sub

    Private Sub txtMontoCombinado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoCombinado.KeyPress
        e.Handled = txtNumerico(txtMontoCombinado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtMontoCombinado.Text) = 0 Then
                txtDescuento.Text = 0
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtMontoCombinado.Text = Format(CDec(txtMontoCombinado.Text), "##,###,##0")
        End If
    End Sub

    Private Sub txtNombreBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreBanco.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cboCobrador.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- CHECKBOX --'
    '**************'
    Private Sub chkCombinado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCombinado.CheckedChanged
        If chkCombinado.Checked = True Then
            cboFormaVentaCombinado.Enabled = True
            txtMontoCombinado.ReadOnly = False
            txtMontoCombinado.BackColor = Color.White
        Else
            cboFormaVentaCombinado.Enabled = False
            txtMontoCombinado.ReadOnly = True
            txtMontoCombinado.BackColor = Color.Yellow
            txtMontoCombinado.Text = 0
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmGuardarCobro_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmCobroClienteNuevo.Enabled = True
        frmCobroClienteNuevo.Show()
        frmCobroClienteNuevo.BringToFront()
    End Sub
    '------------------------------------------------------------------------------------------------------------------------------
End Class