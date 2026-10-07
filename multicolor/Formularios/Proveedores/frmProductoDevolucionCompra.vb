Public Class frmProductoDevolucionCompra
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdStock As Integer
    Dim strCodigo As String
    Dim strMercaderia As String
    Dim douCantidad As Double
    Dim douSaldo As Double

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarProductoCompra(ByVal v_idDev As Integer)
        systemClass.SqlToLv_listarProductoRecepcionCompra(lvProducto, "sp_consultaDetDevolucionProducto", v_idDev)
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            frmRecepcionCompra.txtIdStock.Text = intIdStock
            frmRecepcionCompra.txtCodigo.Text = strCodigo
            frmRecepcionCompra.txtProducto.Text = strMercaderia
            frmRecepcionCompra.txtCantidad.Text = douSaldo
            frmRecepcionCompra.txtSaldo.Text = douSaldo
            frmRecepcionCompra.txtCantidadAnterior.Text = douSaldo

            Me.Close()
        End If
    End Sub

    Private Sub lvProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProducto.SelectedIndexChanged
        '-- mostrar el id compra
        For Each item As ListViewItem In lvProducto.SelectedItems
            strCodigo = item.SubItems(0).Text
            strMercaderia = item.SubItems(1).Text
            intIdStock = item.SubItems(4).Text
            douCantidad = CDbl(item.SubItems(2).Text)
            douSaldo = CDbl(item.SubItems(3).Text)
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmProductoDevolucionCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmRecepcionCompra.Enabled = True
        frmRecepcionCompra.Show()
        frmRecepcionCompra.BringToFront()
        frmRecepcionCompra.txtCantidad.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
End Class