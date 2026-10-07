Public Class frmCancelarNotaCredito
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiar()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        txtDcaja.Text = ""
        txtDsuc.Text = ""
        txtFactura.Text = ""
        txtTimbrado.Text = ""
    End Sub
    Private Sub cancelarNotaCredito()
        '-- inicializar variables
        Dim intTmpIdNotaCredito As Integer
        Dim intTmpIdProveedor As Integer
        Dim strTmpDsuc As String
        Dim strTmpDcaja As String
        Dim strTmpFactura As String
        Dim strTmpTimbrado As String
        Dim strTmpFecha As String
        Dim strTmpResponsable As String

        '-- dar valor a las variables
        intTmpIdNotaCredito = CInt(txtIdNota.Text)
        intTmpIdProveedor = CInt(txtIdProveedor.Text)
        strTmpDsuc = txtDsuc.Text
        strTmpDcaja = txtDcaja.Text
        strTmpFactura = txtFactura.Text
        strTmpTimbrado = txtTimbrado.Text
        strTmpFecha = dtpFecha.Text
        strTmpResponsable = txtResponsable.Text

        If (fun_guardarSp("sp_cancelarNotaCreditoProveedor", intTmpIdNotaCredito & "," & intTmpIdProveedor & "," & "'" & strTmpDsuc & "'" & "," & "'" & strTmpDcaja & "'" & "," & "'" & strTmpFactura & "'" & "," & "'" & strTmpTimbrado & "'" & "," & "'" & strTmpFecha & "'" & "," & "'" & strTmpResponsable & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros del Pago...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
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
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtTimbrado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        e.Handled = txtNumerico(txtTimbrado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            'txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtResponsable_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtResponsable.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        cancelarNotaCredito()
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCancelarNotaCredito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmConsultaNotaCredito.Enabled = True
        frmConsultaNotaCredito.actualizarCabeceraNota(CInt(txtIdNota.Text))
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------
End Class