Public Class frmMoneda
    Dim systemClass As New SystemClass

    Dim douTmpCotizacion As Double
    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        listar_busqueda("")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Sub listar_busqueda(ByVal where As String)
        systemClass.SqlToLv_monto(lvMoneda, "select dc.idMoneda,dc.venta as cotizacion,m.nombreMoneda,m.abreviatura from cabCotiza cc inner join detCotiza dc on cc.idCotiza=dc.idCotiza inner join moneda m on m.idmoneda=dc.idmoneda inner join configEmpresa ce on ce.idMoneda=cc.idmoneda ")
    End Sub

    Private Sub lvMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtMoneda.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar una moneda...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '-- sumar la variable global de nro
            intGl_nroArqueoMoneda = intGl_nroArqueoMoneda + 1
            '-- cargar la grilla de la caja 
            cargarArqueoMoneda(intGl_nroArqueoMoneda, txtMoneda.Text, 1, 1, douTmpCotizacion)
            Me.Close()
            frmArqueoCaja.Enabled = True
            frmArqueoCaja.Show()
            frmArqueoCaja.BringToFront()
            frmArqueoCaja.dtgMoneda.Focus()
        End If
    End Sub

    Private Sub lvMoneda_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvMoneda.SelectedIndexChanged
        For Each item As ListViewItem In lvMoneda.SelectedItems
            txtMoneda.Text = item.SubItems(2).Text
            douTmpCotizacion = item.SubItems(1).Text
        Next
    End Sub

    Private Sub frmMoneda_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmArqueoCaja.Enabled = True
        frmArqueoCaja.Show()
        frmArqueoCaja.BringToFront()
    End Sub
End Class