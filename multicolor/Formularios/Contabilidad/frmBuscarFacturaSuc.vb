Public Class frmBuscarFacturaSuc
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdFactura As Integer = 0

    Sub New()
        InitializeComponent()
    End Sub

    Public Sub listar(ByVal v_idSucursal As Integer)
        systemClass.SqlToLv_detalleFacturaAsignada(lvBuscar, "sp_consultaFacturaSucursal", v_idSucursal)
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS LISTVIEW --'
    '******************'
    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            intIdFactura = item.SubItems(0).Text
        Next
    End Sub

    Private Sub lvBuscar_GotFocus(sender As Object, e As System.EventArgs) Handles lvBuscar.GotFocus
        For Each item As ListViewItem In lvBuscar.SelectedItems
            intIdFactura = item.SubItems(0).Text
        Next
    End Sub

    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- buscar las facturas
            'frmOrganizarFacturas.actualizarFacturaPc(intIdFactura, lblIdFacturaAnt.Text)

            Me.Close()
        End If

    End Sub

    '-------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarFacturaSuc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        'frmOrganizarFacturas.Enabled = True
        'frmOrganizarFacturas.Show()
        'frmOrganizarFacturas.BringToFront()
    End Sub
    '-------------------------------------------------------------------------------------------
End Class