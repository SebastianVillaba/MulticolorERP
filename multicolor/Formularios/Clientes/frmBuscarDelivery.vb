Public Class frmBuscarDelivery
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdDelivery As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle()
        systemClass.SqlToLv_detalleDeliverySeleccion(lvDelivery, "sp_consultaDelivery", intGl_idConfigPc)
    End Sub

    Private Sub actualizarVenta()
        If (fun_guardarSp("sp_updDetVentaFarmaciaTmpDelivery_tabla", intGl_idEntidad & "," & intGl_idConfigPc & "," & CInt(frmVentaFarmacia1.txtIdCliente.Text) & "," & _
                          CInt(frmVentaFarmacia1.lblIdTipoVenta.Text) & "," & 1 & _
                          "," & intIdDelivery, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            '--------------------------------------------

            frmVentaFarmacia1.sumarTotales()
            frmVentaFarmacia1.txtIdTipoventa.Text = 1
            frmVentaFarmacia1.txtTipoventaNombre.Text = "VENTA DELIVERY"
            frmVentaFarmacia1.txtTipoventaNombre.BackColor = Color.Black

            Me.Close()
        End If

    End Sub
    '----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvDelivery_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDelivery.SelectedIndexChanged
        For Each item As ListViewItem In lvDelivery.SelectedItems
            intIdDelivery = CInt(item.SubItems(0).Text)
        Next
    End Sub

    Private Sub lvDelivery_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvDelivery.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If intIdDelivery = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            actualizarVenta()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarDivision_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        e.Cancel = False
        frmVentaFarmacia1.Enabled = True
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
        frmVentaFarmacia1.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------------

End Class