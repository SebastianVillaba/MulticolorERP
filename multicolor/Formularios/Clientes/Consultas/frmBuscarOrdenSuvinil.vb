Public Class frmBuscarOrdenSuvinil
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
        systemClass.SqlToLv(lvBuscar, "select idOrdenSuvinil,nombreColor,cliente,nombreBase,total,fechaAlta" & _
                            " from v_ordenSuvinilVenta " & where)
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                If rdNombreColor.Checked = True Then
                    '-- por nombre del color
                    listar(" Where nombreColor Like '%" & txtBuscar.Text & "%'" & "order by nombreColor")
                End If
                If rdCliente.Checked = True Then
                    '-- por cliente
                    listar(" Where cliente Like '%" & txtBuscar.Text & "%'" & "order by cliente")
                End If
                If rdBase.Checked = True Then
                    '-- por base
                    listar(" Where nombreBase Like '%" & txtBuscar.Text & "%'" & "order by nombreBase")
                End If
            Else
                '-- por idOrden
                '-- por nro de recibo
                listar(" Where idOrdenSuvinil=" & txtBuscar.Text)

            End If
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
                    frmConsultaPreparadoSuvinil.listarDetalle(CInt(txtIdMov.Text))
                    '-- los datos
                    frmConsultaPreparadoSuvinil.actualizarCabecera(CInt(txtIdMov.Text))
                    '------------------------------------------------------------
                    Me.Close()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    Private Sub frmBuscarOrdenSuvinil_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaPreparadoSuvinil.Enabled = True
        frmConsultaPreparadoSuvinil.Show()
        frmConsultaPreparadoSuvinil.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
End Class