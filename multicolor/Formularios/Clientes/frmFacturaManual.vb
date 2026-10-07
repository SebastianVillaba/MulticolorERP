Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmFacturaManual
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        InitializeComponent()
        txtTimbrado.Text = 0
    End Sub


    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub ImprimirReciboPromo(ByVal v_entrega As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idEntrega As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_reciboPromo
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idEntrega.Value = v_entrega
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idEntrega)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idVenta").ApplyCurrentValues(pvParametros)
        rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt

        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Show()
    End Sub

    Private Sub controlarFactura()
        '-- si el digito de la caja no tiene 3 digitos
        If Len(txtDcaja.Text) = 1 Or Len(txtDcaja.Text) = 2 Then
            MessageBox.Show("Los digitos de la caja deben ser 3..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- controlar el timbrado
        If Not IsNumeric(txtTimbrado.Text) And Len(txtFactura.Text) > 0 Then
            MessageBox.Show("El timbrado ingresado no es correcto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Len(txtFactura.Text) > 0 Then
            '-- controlar si existe ya una factura de sistema con el mismo numero
            Dim strTmpValorConsulta As String
            strTmpValorConsulta = sp_datosTabla.consulta_valor("select factura from cabVenta where activo=1 and dsuc=" & txtDsuc.Text & " and dcaja=" & txtDcaja.Text & " and factura=" & txtFactura.Text & " and timbrado=" & txtTimbrado.Text)
            'MsgBox("Valor de la variable  " & strTmpValorConsulta)
            If CInt(strTmpValorConsulta) > 0 Then
                MessageBox.Show("Ya existe una factura generada por el sistema con el mismo numero..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '-- controlar si existe ya una factura manual con el mismo numero
            strTmpValorConsulta = sp_datosTabla.consulta_valor("select factura from cabVenta where activo=1 and dsuc=" & txtDsuc.Text & " and dcaja=" & txtDcaja.Text & " and facturam=" & txtFactura.Text & " and timbrado=" & txtTimbrado.Text)
            If CInt(strTmpValorConsulta) > 0 Then
                MessageBox.Show("Ya existe una factura generada por el sistema con el mismo numero..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
        If banGl_ventaFarmacia1 = True Then
            '-- venta de la farmacia1
            '---- controlar si es una factura fiscal
            If Len(txtFactura.Text) = 0 Then
                '--- nfis
                bolGl_vtaFiscal = 0
            Else
                bolGl_vtaFiscal = 1
            End If
            '-- asignar todos los valores a la factura
            strGl_vtaDsuc = txtDsuc.Text
            strGl_vtaDcaja = txtDcaja.Text
            strGl_vtaFacturaManual = txtFactura.Text
            intGl_vtaTimbrado = txtTimbrado.Text

            'MsgBox("Valor de bolGl_vtaFiscal   " & bolGl_vtaFiscal)
            Me.Close()
            banGl_ventaFarmacia1 = True

            frmPass.guardarVentaFarmacia1()
            '------------------------------------------
        End If
    End Sub

    '-------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        controlarFactura()
    End Sub
    '------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtTimbrado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        e.Handled = txtSoloNumerico(txtTimbrado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDcaja.Focus()
            'SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtSoloNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send("{tab}")
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtSoloNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtFactura.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmFacturaManual_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_ventaFarmacia1 = True Then
            '-- para la venta de farmacia1
            banGl_ventaFarmacia1 = False

            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub
    '------------------------------------------------------------------------------------------
End Class
