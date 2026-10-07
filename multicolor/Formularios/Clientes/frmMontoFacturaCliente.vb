Public Class frmMontoFacturaCliente
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '*******************'
    '-- PROCEDIMIENTO --'
    '*******************'
    Private Sub cargarMontoFacturaCliente(ByVal v_idMovimiento As Integer, ByVal v_monto As Double)
        If v_monto > 0 Then
            If (fun_guardarSp("sp_updCobroClientePorFactura", intGl_idConfigPc & "," & v_idMovimiento & "," & v_monto, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro del Cobro de Cliente...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                frmCobroClienteNuevo.listarDetallePago(" where idConfig=" & intGl_idConfigPc)
                frmCobroClienteNuevo.sumarTotales()
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtMonto.Text = Format(CDbl(txtMonto.Text), "###,###,##0.##")
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        '-- controlar la cantidad de facturas pagadas
        If frmCobroClienteNuevo.txtCantidadCobrada.Text = frmCobroClienteNuevo.txtMaximaCantidad.Text Then
            MessageBox.Show("La cantidad de facturas pagadas ya alcanzó el límite establecido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        '-- verificar si se introdujo algun numero
        If Not IsNumeric(txtMonto.Text) Then
            MessageBox.Show("Debe Introducir un Monto Válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- cargar la venta
        cargarMontoFacturaCliente(CInt(lblIdMov.Text), sacarComa(CDbl(txtMonto.Text)))
    End Sub
    '--------------------------------------------------
    '********************'
    '-- EL FORMAULARIO --'
    '********************'
    Private Sub frmCobroCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmCobroClienteNuevo.Enabled = True
        frmCobroClienteNuevo.Show()
        frmCobroClienteNuevo.BringToFront()
    End Sub

End Class