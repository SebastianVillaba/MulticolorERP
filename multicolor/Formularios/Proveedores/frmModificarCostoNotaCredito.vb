Public Class frmModificarCostoNotaCredito

    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarCosto()
        If (fun_guardarSp("sp_updDetNotaCreditoGastoTmp", intGl_idConfigPc & "," & "'" & Trim(txtConcepto.Text) & "'" & "," & CDbl(sacarComa(txtCostoNuevo.Text)), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle Temporal de la Nota de Crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        frmNotaCreditoGasto.listarDetalle()

        Me.Close()
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtCostoNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoNuevo.KeyPress
        e.Handled = txtNumerico(txtCostoNuevo, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCostoNuevo.Text = Format(CDec(txtCostoNuevo.Text), "###,###,###")
            btnAgregar.Focus()
        End If
    End Sub

    '-----------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        actualizarCosto()
    End Sub
    '-----------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmModificarCostoNotaCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmNotaCreditoGasto.Enabled = True
        frmNotaCreditoGasto.Show()
        frmNotaCreditoGasto.BringToFront()
    End Sub

    Private Sub frmModificarCostoNotaCredito_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtCostoNuevo.Focus()
    End Sub
    '-----------------------------------------------------
End Class