Public Class frmCantidadCoral
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarDetalle()
        If (fun_guardarSp("sp_actualizarDetOrdenCoralTmp", intGl_idConfigPc & "," & txtNro.Text & "," & sacarComa(txtOnza.Text) & "," & _
                           sacarComa(txtPulso.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            frmOrdenPreparadoCoral.listarDetalle()
            frmOrdenPreparadoCoral.sumarTotal()
            Me.Close()
        End If
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtOnza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOnza.KeyPress
        e.Handled = txtNumerico(txtOnza, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtOnza.Text = Format(CDec(txtOnza.Text), "##,##0.##")
            txtPulso.Focus()
        End If
    End Sub

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
    Private Sub frmCantidadCoral_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmOrdenPreparadoCoral.Enabled = True
        frmOrdenPreparadoCoral.Show()
        frmOrdenPreparadoCoral.BringToFront()
    End Sub
End Class