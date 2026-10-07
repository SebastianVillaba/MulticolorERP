Public Class frmCargarDescuentoEspecial
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdProducto As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarDetalle()
        intIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & txtCodigo.Text)

        If (fun_guardarSp("sp_actualizarDescuentoEspecialTmp", intGl_idConfigPc & "," & txtNro.Text & "," & intIdProducto & "," & _
                          sacarComa(txtPrecio1Con.Text) & "," & sacarComa(txtPrecio1Cre.Text) & "," & sacarComa(txtPrecio1Tar.Text) & "," & _
                          sacarComa(txtPrecio1Debito.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            frmDescuentoEspecial.consultaDescuento()
            Me.Close()
        End If
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtPrecio1Con_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio1Con.KeyPress
        e.Handled = txtNumerico(txtPrecio1Con, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPrecio1Con.Text = Format(CDec(txtPrecio1Con.Text), "##,###,##0")
            txtPrecio1Cre.Focus()
        End If
    End Sub

    Private Sub txtPrecio1Cre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio1Cre.KeyPress
        e.Handled = txtNumerico(txtPrecio1Cre, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPrecio1Cre.Text = Format(CDec(txtPrecio1Cre.Text), "##,###,##0")
            txtPrecio1Tar.Focus()
        End If
    End Sub

    Private Sub txtPrecio1Tar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio1Tar.KeyPress
        e.Handled = txtNumerico(txtPrecio1Tar, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPrecio1Tar.Text = Format(CDec(txtPrecio1Tar.Text), "##,###,##0")
            txtPrecio1Debito.Focus()
        End If
    End Sub

    Private Sub txtPrecio1Debito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio1Debito.KeyPress
        e.Handled = txtNumerico(txtPrecio1Debito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPrecio1Debito.Text = Format(CDec(txtPrecio1Debito.Text), "##,###,##0")
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
    Private Sub frmCargarDescuentoEspecial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmDescuentoEspecial.Enabled = True
        frmDescuentoEspecial.Show()
        frmDescuentoEspecial.BringToFront()
    End Sub
End Class