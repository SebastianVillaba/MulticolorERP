Public Class frmChequeVenta
    Private sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'

    '--------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtNombreBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreBanco.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNroCheque.Focus()
        End If
    End Sub

    Private Sub txtNroCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCheque.KeyPress
        e.Handled = txtNumerico(txtNroCheque, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        '-- colocar los datos en la variable global
        strGl_vtaNombreBanco = Trim(txtNombreBanco.Text)
        intGl_vtaNroCheque = txtNroCheque.Text

        '-- datos de la venta
        frmPass.lblCliente.Text = frmVentaFarmacia1.txtCliente.Text
        frmPass.lblRuc.Text = frmVentaFarmacia1.txtRucCliente.Text
        frmPass.lblFormaVenta.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoVenta where idTipoVenta=" & frmVentaFarmacia1.lblIdTipoVenta.Text)
        frmPass.lblTipoVenta.Text = frmVentaFarmacia1.txtTipoventaNombre.Text
        frmPass.lblTotalVenta.Text = frmVentaFarmacia1.txtTotalVenta.Text
        frmPass.lblTotalVenta.Text = Format(CDbl(frmVentaFarmacia1.txtTotalVenta.Text), "##,###,###.##")
        frmPass.lblTotalDescuento.Text = frmVentaFarmacia1.txtTotalDescuento.Text
        frmPass.lblTotalDescuento.Text = Format(CDbl(frmVentaFarmacia1.txtTotalDescuento.Text), "##,###,###.##")
        frmPass.lblVuelto.Text = 0
        '-- solo contraseña
        frmPass.txtPass.Text = ""
        frmPass.btnAceptar.Enabled = True
        frmPass.btnCancelar.Enabled = True

        frmPass.Visible = True
        frmPass.Show()
        frmPass.BringToFront()
        frmPass.txtPass.Focus()
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmChequeVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        '-- para la venta de farmacia1
        frmVentaFarmacia1.Enabled = True
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
    End Sub
End Class