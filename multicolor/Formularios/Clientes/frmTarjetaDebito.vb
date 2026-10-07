Public Class frmTarjetaDebito
    Dim sp_datosTabla As New sp_datosTabla

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        If banGl_ventaFarmacia1 Then
            '-- venta de farmacia
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub

    Private Sub cboTarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTarjeta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cboTarjeta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTarjeta.Validated
        '-- sacar el id en la variable publica
        intGl_vtaIdTarjetaDebito = cboTarjeta.SelectedValue
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        '-- variable publica 
        bolGl_vtaVendedorFarmacia = True
        intGl_vtaCantidadCuota = 0


        '-- controlar si como etá configurado
        If sp_datosTabla.consulta_valor("select nickPass from configEmpresa where idEntidad=" & intGl_idEntidad) = True Then
            '-- nick y contraseña

        Else
            If banGl_ventaFarmacia1 = True Then
                '-- datos de la venta de la farmacia
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
                frmPass.Visible = True
                frmPass.Show()
                frmPass.BringToFront()
                frmPass.txtPass.Focus()

            End If

        End If
    End Sub

End Class