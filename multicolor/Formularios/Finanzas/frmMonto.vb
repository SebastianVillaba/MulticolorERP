Public Class frmMonto
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        listar_busqueda("")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Sub listar_busqueda(ByVal where As String)
        systemClass.SqlToLv_monto(lvMonto, "select * from monto order by monto")
    End Sub

    Private Sub lvMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtMonto.Text) Then
                '-- sumar la variable global de nro
                intGl_nroArqueoGuaranies = intGl_nroArqueoGuaranies + 1
                '-- cargar la grilla de la caja 
                cargarArqueoGuaranies(intGl_nroArqueoGuaranies, 1, "X", txtMonto.Text, (1 * CDec(txtMonto.Text)))
                Me.Close()
                frmArqueoCaja.Enabled = True
                frmArqueoCaja.Show()
                frmArqueoCaja.BringToFront()
                frmArqueoCaja.dtgGuaranies.Focus()
            End If
        End If
    End Sub

    Private Sub lvMonto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvMonto.SelectedIndexChanged
        For Each item As ListViewItem In lvMonto.SelectedItems
            txtMonto.Text = item.SubItems(1).Text
        Next
    End Sub

    Private Sub frmMonto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmArqueoCaja.Enabled = True
        frmArqueoCaja.Show()
        frmArqueoCaja.BringToFront()
    End Sub
End Class