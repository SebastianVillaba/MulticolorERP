Public Class frmTarjetaDebitoCaja
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        listar_busqueda("")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Sub listar_busqueda(ByVal where As String)
        systemClass.SqlToLv_tarjeta(lvTarjeta, "select t.idTarjetade,t.nombreTarjetaDebito from tarjetaDebito t order by t.nombreTarjetaDebito")
    End Sub

    Private Sub lvTarjeta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvTarjeta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtTarjeta.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar una tarjeta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '-- sumar la variable global de nro
            intGl_nroArqueoTarjetaDebito = intGl_nroArqueoTarjetaDebito + 1
            '-- cargar la grilla de la caja 
            cargarArqueoTarjetaDebito(intGl_nroArqueoTarjetaDebito, txtTarjeta.Text, 1)
            Me.Close()
            frmArqueoCaja.Enabled = True
            frmArqueoCaja.Show()
            frmArqueoCaja.BringToFront()
            frmArqueoCaja.dtgTarjetaDebito.Focus()
        End If
    End Sub

    Private Sub lvTarjeta_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvTarjeta.SelectedIndexChanged
        For Each item As ListViewItem In lvTarjeta.SelectedItems
            txtTarjeta.Text = item.SubItems(1).Text
        Next
    End Sub

    Private Sub frmTarjetaCreditoCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmArqueoCaja.Enabled = True
        frmArqueoCaja.Show()
        frmArqueoCaja.BringToFront()
    End Sub

End Class