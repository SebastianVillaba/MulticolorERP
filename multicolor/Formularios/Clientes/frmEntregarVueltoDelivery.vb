Public Class frmEntregarVueltoDelivery
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listarVuelto(intGl_idSucursal)
        'valorde del combo
    End Sub

    Public Sub listarVuelto(ByVal v_idSucursal As Integer)
        systemClass.SqlToLv_detalleVueltoDelivery(lv, "sp_consultaVueltoDelivery", v_idSucursal)
    End Sub

    Private Sub guardarVueltoDelivery(ByVal v_idVenta As Integer)
        If (fun_guardarSp("sp_guardarVueltoDeliveryVenta", v_idVenta, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lv.KeyPress
        If txtId.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtId.Text) = 0 Then
                    MessageBox.Show("Debe ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                guardarVueltoDelivery(CInt(txtId.Text))
            End If
        End If
    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged
        For Each item As ListViewItem In lv.SelectedItems
            txtId.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarDivision_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        'frmDeliveryCliente.listarConsultaVenta(" where cv.tipof=1 and cv.idRepartidor=0 and cv.activo=1 and cv.idSucursal=" & intGl_idSucursal)
        'frmDeliveryCliente.listarConsultaDelivery("")
        'frmDeliveryCliente.Enabled = True
        'frmDeliveryCliente.Show()
        'frmDeliveryCliente.BringToFront()
        'frmDeliveryCliente.txtBuscar.Focus()
    End Sub
    '------------------------------------------------------------------------------------------------------------------
End Class