Public Class frmBuscarCobranza
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
        systemClass.SqlToLv(lvBuscar, "select cc.idCobro,cc.recibo,rtrim(_vc.nombre)+','+ltrim(_vc.apellido) as Cliente," & _
                            " cc.fecha,cc.totalCobro from cabCobro cc inner join v_cliente _vc on cc.idCliente=_vc.idCliente " & where)
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- por nombre del cliente
                listar(" Where _vc.nombre Like '" & txtBuscar.Text & "%' Or _vc.nombre Like '" & txtBuscar.Text & "%' " & "order by _vc.nombre")
            Else
                '-- por opcion de busqueda
                If rdRecibo.Checked = True Then
                    '-- por nro de recibo
                    listar(" Where cc.recibo=" & txtBuscar.Text)
                End If
                If rdIdCobro.Checked = True Then
                    '-- buscar por idCobro
                    listar(" Where cc.idCobro=" & txtBuscar.Text)
                End If

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
                    frmConsultaCobro.listarDetalle(CInt(txtIdMov.Text))
                    '-- los datos
                    frmConsultaCobro.actualizarCabecera(CInt(txtIdMov.Text))
                    '------------------------------------------------------------
                    Me.Close()
                    frmConsultaCobro.Enabled = True
                    frmConsultaCobro.Show()
                    frmConsultaCobro.BringToFront()
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
    Private Sub frmBuscarBuscarRemision_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaCobro.Enabled = True
        frmConsultaCobro.Show()
        frmConsultaCobro.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
End Class