Public Class frmCargarDescuentoEspecialGrupoCliente
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

        If (fun_guardarSp("sp_actualizarDescuentoEspecialGrupoClienteTmp", intGl_idConfigPc & "," & txtNro.Text & "," & intIdProducto & "," & _
                          sacarComa(txtPrecioContado.Text) & "," & sacarComa(txtPrecioCredito.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            frmDescuentoEspecialGrupoCliente.consultaDescuento()
            Me.Close()
        End If
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtPrecioContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioContado.KeyPress
        e.Handled = txtNumerico(txtPrecioContado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPrecioContado.Text = Format(CDec(txtPrecioContado.Text), "##,###,##0")
            txtPrecioCredito.Focus()
        End If
    End Sub

    Private Sub txtPrecioCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioCredito.KeyPress
        e.Handled = txtNumerico(txtPrecioCredito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPrecioCredito.Text = Format(CDec(txtPrecioCredito.Text), "##,###,##0")
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
        frmDescuentoEspecialGrupoCliente.Enabled = True
        frmDescuentoEspecialGrupoCliente.Show()
        frmDescuentoEspecialGrupoCliente.BringToFront()
    End Sub
End Class