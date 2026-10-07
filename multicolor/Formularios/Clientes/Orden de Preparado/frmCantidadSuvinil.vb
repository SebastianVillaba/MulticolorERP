Public Class frmCantidadSuvinil
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarDetalle()
        If (fun_guardarSp("sp_actualizarDetOrdenSuvinilTmp", intGl_idConfigPc & "," & txtNro.Text & "," & sacarComa(txtPulso.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            frmOrdenPreparadoSuvinil.listarDetalle()
            frmOrdenPreparadoSuvinil.sumarTotal()
            Me.Close()
        End If
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtPulso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPulso.KeyPress
        e.Handled = txtNumerico(txtPulso, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtPulso.Text = Format(CDec(txtPulso.Text), "##,##0.##")
            btnAgregar.Focus()
        End If
    End Sub
    '-----------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        actualizarDetalle()
    End Sub
    '-----------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCantidadSuvinil_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmOrdenPreparadoSuvinil.Enabled = True
        frmOrdenPreparadoSuvinil.Show()
        frmOrdenPreparadoSuvinil.BringToFront()
    End Sub
End Class