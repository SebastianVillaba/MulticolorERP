Public Class frmModificaPorceDescuento
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarDetalle()
        If (fun_guardarSp("sp_actualizarDetDescuentoGrupoClienteTipoVentaTmp", intGl_idConfigPc & "," & txtNro.Text & "," & _
                          sacarComa(txtContado.Text) & "," & sacarComa(txtCredito.Text) & "," & sacarComa(txtTarjeta.Text) & "," & _
                          sacarComa(txtDebito.Text) & "," & sacarComa(txtChequeDife.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            frmDescuentoGrupoCliente.consultarLaboratorioDesc()
            Me.Close()
        End If
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContado.KeyPress
        e.Handled = txtNumerico(txtContado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtContado.Text = Format(CDec(txtContado.Text), "##0.##")
            txtCredito.Focus()
        End If
    End Sub

    Private Sub txtCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCredito.KeyPress
        e.Handled = txtNumerico(txtCredito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtCredito.Text = Format(CDec(txtCredito.Text), "##0.##")
            txtTarjeta.Focus()
        End If
    End Sub

    Private Sub txtTarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTarjeta.KeyPress
        e.Handled = txtNumerico(txtTarjeta, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtTarjeta.Text = Format(CDec(txtTarjeta.Text), "##0.##")
            txtDebito.Focus()
        End If
    End Sub

    Private Sub txtDebito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDebito.KeyPress
        e.Handled = txtNumerico(txtTarjeta, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtDebito.Text = Format(CDec(txtDebito.Text), "##0.##")
            txtChequeDife.Focus()
        End If
    End Sub

    Private Sub txtChequeDife_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChequeDife.KeyPress
        e.Handled = txtNumerico(txtChequeDife, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtChequeDife.Text = Format(CDec(txtChequeDife.Text), "##0.##")
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
    Private Sub frmModificaPorceDescuento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmDescuentoGrupoCliente.Enabled = True
        frmDescuentoGrupoCliente.Show()
        frmDescuentoGrupoCliente.BringToFront()
    End Sub
End Class