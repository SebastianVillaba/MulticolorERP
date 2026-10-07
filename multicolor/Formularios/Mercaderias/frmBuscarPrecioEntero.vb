Public Class frmBuscarPrecioEntero
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "select idPrecio,nroInformativo,fecha,fechaAlta" & _
                                        " from cabPrecioEntero " & where)

    End Sub

    '--------------------------------------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            '-- buscar por idPrecio
            listar(" Where idPrecio=" & txtBuscar.Text)

            lvBuscar.Focus()

        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If IsNumeric(txtIdMov.Text) Then
            If txtIdMov.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    '-- listar el detalle
                    frmConsultaPrecioEntero.listarDetalleResmision(txtIdMov.Text)
                    '-- los datos
                    frmConsultaPrecioEntero.actualizarCabeceraNota(CInt(txtIdMov.Text))
                    '------------------------------------------------------------
                    Me.Close()
                End If
            Else
                MessageBox.Show("Debe ingresar algun precio..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtIdMov.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmBuscarPrecioEntero_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaPrecioEntero.Enabled = True
        frmConsultaPrecioEntero.Show()
        frmConsultaPrecioEntero.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
End Class