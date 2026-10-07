Public Class frmProductoFacturaCompra
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdStock As Integer
    Dim strCodigo As String
    Dim strMercaderia As String
    Dim douCantidad As Double
    Dim douBoni As Double

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarProductoCompra(ByVal v_idCompra As Integer)
        systemClass.SqlToLv_listarProductoDevolucionCompra(lvProducto, "sp_consultaDetCompraProducto", v_idCompra)
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            frmDevolucionCompra.txtIdStock.Text = intIdStock
            frmDevolucionCompra.txtCodigo.Text = strCodigo
            frmDevolucionCompra.txtProducto.Text = strMercaderia
            frmDevolucionCompra.txtCantidad.Text = douCantidad + douBoni

            Me.Close()
        End If
    End Sub

    Private Sub lvProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProducto.SelectedIndexChanged
        '-- mostrar el id compra
        For Each item As ListViewItem In lvProducto.SelectedItems
            strCodigo = item.SubItems(0).Text
            strMercaderia = item.SubItems(1).Text
            intIdStock = item.SubItems(5).Text
            douCantidad = CDbl(item.SubItems(2).Text)
            douBoni = CDbl(item.SubItems(3).Text)
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmProductoFacturaCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmDevolucionCompra.Enabled = True
        frmDevolucionCompra.Show()
        frmDevolucionCompra.BringToFront()
        frmDevolucionCompra.txtCantidad.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
End Class