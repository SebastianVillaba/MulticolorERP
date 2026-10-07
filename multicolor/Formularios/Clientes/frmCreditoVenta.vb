Public Class frmCreditoVenta
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    Public Sub actualizarCuota(ByVal v_monto As Double)
        systemClass.SqlToLv_configuracionCuota(lvCuota, "sp_consultaConfiguracionCuota", v_monto)
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        '-- validar si la cantidad de cuota es valida
        If lblNroCuota.Text = 0 Then
            MessageBox.Show("La cantidad de cuota ingresada no es válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- verificar el nro de la orden de compra
        If Not IsNumeric(txtNroOrden.Text) Then
            MessageBox.Show("No es Válido el Nro de la Orden..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- variable publica 
        bolGl_vtaVendedorFarmacia = True
        intGl_vtaCantidadCuota = lblNroCuota.Text
        intGl_vtaHeladeriaCantidadCuota = lblNroCuota.Text
        intGl_vtaNroOrden = txtNroOrden.Text

        '-- controlar si como etá configurado
        If sp_datosTabla.consulta_valor("select nickPass from configEmpresa where idEntidad=" & intGl_idEntidad) = True Then
            '-- nick y contraseña

        Else
            If banGl_ventaFarmacia1 = True Then
                '-- datos de la venta de farmacia1
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

                Me.Close()
                banGl_ventaFarmacia1 = True

                frmPass.Visible = True
                frmPass.Show()
                frmPass.BringToFront()
                frmPass.txtPass.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'

    Private Sub txtNroOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroOrden.KeyPress
        e.Handled = txtNumerico(txtNroOrden, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCuota_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCuota.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvCuota.SelectedItems
            lblNroCuota.Text = item.SubItems(0).Text
        Next
    End Sub

    Private Sub lvCuota_GotFocus(sender As Object, e As System.EventArgs) Handles lvCuota.GotFocus
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvCuota.SelectedItems
            lblNroCuota.Text = item.SubItems(0).Text
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCreditoVenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        If banGl_ventaFarmacia1 = True Then
            banGl_ventaFarmacia1 = False

            '-- venta de farmacia1
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------
End Class