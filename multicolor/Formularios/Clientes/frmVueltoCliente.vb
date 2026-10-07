Public Class frmVueltoCliente
    Dim sp_datosTabla As New sp_datosTabla
    Dim douCotizacion As Double

    '*************'
    '-- TEXTBOX --'
    '*************'
    Private Sub txtMontoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoCliente.KeyPress
        e.Handled = txtNumerico(txtMontoCliente, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtMontoCliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoCliente.Validated
        txtMontoCliente.Text = Format(CDec(txtMontoCliente.Text), "##,###,##0.##")
        '-- realizar la diferencia
        txtVuelto.Text = txtMontoCliente.Text - txtTotalVenta.Text
        txtVuelto.Text = Format(CDec(txtVuelto.Text), "##,###,###.00")
    End Sub

    '**************'
    '-- COMBOBOX --'
    '**************'
    Private Sub cboMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtMontoCliente.Focus()
        End If
    End Sub

    Private Sub cboMoneda_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMoneda.Validated
        '-- sacar el idMoneda configurado
        Dim intTmpIdMoneda As Integer = 0
        intTmpIdMoneda = sp_datosTabla.consulta_valor("select idmoneda from configEmpresa where idEntidad=" & intGl_idEntidad)

        If banGl_ventaFarmacia1 = True Then
            '-- venta de farmacia
            '-- primero ver si se selecciono la moneda de origen
            If cboMoneda.SelectedValue <> intTmpIdMoneda Then
                douCotizacion = sp_datosTabla.consulta_valor("select dc.venta from cabCotiza cc inner join detCotiza dc on cc.idCotiza=dc.idCotiza inner join configEmpresa ce on ce.idmoneda=cc.idmoneda where ce.idEntidad=" & intGl_idEntidad & " and dc.idMoneda=" & cboMoneda.SelectedValue)
                txtTotalVenta.Text = frmVentaFarmacia1.txtTotalVenta.Text / douCotizacion
            Else
                douCotizacion = 1
                '-- convertir el total
                txtTotalVenta.Text = frmVentaFarmacia1.txtTotalVenta.Text * douCotizacion
            End If
        End If

        txtTotalVenta.Text = Format(CDec(txtTotalVenta.Text), "##,###,###.00")

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        '-- variable publica 
        bolGl_vtaVendedorFarmacia = True
        intGl_vtaCantidadCuota = 0

        If chkDeliveryExterno.Checked = True Then
            bolGl_vtaDeliveryExterno = True
        Else
            bolGl_vtaDeliveryExterno = False
        End If

        'Me.Visible = False
        '-- controlar si como etá configurado
        If sp_datosTabla.consulta_valor("select nickPass from configEmpresa where idEntidad=" & intGl_idEntidad) = True Then
            '-- nick y contraseña

        Else
            If banGl_ventaFarmacia1 = True Then
                '-- datos de la venta de farmacia
                frmPass.lblCliente.Text = frmVentaFarmacia1.txtCliente.Text
                frmPass.lblRuc.Text = frmVentaFarmacia1.txtRucCliente.Text
                frmPass.lblFormaVenta.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoVenta where idTipoVenta=" & frmVentaFarmacia1.lblIdTipoVenta.Text)
                frmPass.lblTipoVenta.Text = frmVentaFarmacia1.txtTipoventaNombre.Text
                frmPass.lblTotalVenta.Text = frmVentaFarmacia1.txtTotalVenta.Text
                frmPass.lblTotalVenta.Text = Format(CDbl(frmVentaFarmacia1.txtTotalVenta.Text), "##,###,###.##")
                frmPass.lblTotalDescuento.Text = frmVentaFarmacia1.txtTotalDescuento.Text
                frmPass.lblTotalDescuento.Text = Format(CDbl(frmVentaFarmacia1.txtTotalDescuento.Text), "##,###,###.##")
                frmPass.lblVuelto.Text = txtVuelto.Text
                frmPass.lblVuelto.Text = Format(CDbl(txtVuelto.Text), "##,###,###.##")

                '-- solo contraeña
                frmPass.txtPass.Text = ""
                frmPass.lblVendedor.Text = ""
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
        '-- verificar de que modulo vino la llamada
        If banGl_ventaFarmacia1 = True Then
            '-- venta de farmacia1
            banGl_ventaFarmacia1 = False
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmVueltoCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        '-- verificar                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           de que modulo vino la llamada
        If banGl_ventaFarmacia1 = True Then
            '-- venta de farmacia1
            banGl_ventaFarmacia1 = False
            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
        End If
    End Sub
End Class