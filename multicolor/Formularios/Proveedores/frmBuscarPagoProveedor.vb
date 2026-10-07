Public Class frmBuscarPagoProveedor
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
        systemClass.SqlToLv(lvBuscar, "select cp.idPagoProveedor,_vp.nombre as Proveedor," & _
                                        "([dbo].[funTraerUsuario](cp.idUsuarioAlta)) as responsable,cp.fechaAlta " & _
                                        "from cabPagoProveedor cp inner join v_proveedor _vp " & _
                                        "on cp.idProveedor=_vp.idProveedor " & where)
        'txtSql.Text = "select cp.idPedidoProveedor,_vp.nombre as Proveedor," & _
        '                                "([maxifarmasa].[dbo].[funTraerUsuario](cp.idUsuarioAlta)) as responsable,cp.fechaAlta " & _
        '                                "from cabPagoProveedor cp inner join v_proveedor _vp " & _
        '                                "on cp.idProveedor=_vp.idProveedor " & where
    End Sub
    '------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre del proveedor
                listar(" Where _vp.nombre Like '" & txtBuscar.Text & "%' Or _vp.nombre Like '" & txtBuscar.Text & "%' " & "order by _vp.nombre")
            Else
                '-- buscar por idPedido
                listar(" Where cp.idPagoProveedor=" & txtBuscar.Text & " order by cp.idPagoProveedor")
            End If
            lvBuscar.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If IsNumeric(txtIdMov.Text) Then
            If txtIdMov.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    '-- listar el detalle
                    frmConsultaPagoProveedor.listarDetalle(CInt(txtIdMov.Text))
                    '-- los datos
                    frmConsultaPagoProveedor.actualizarCabecera(CInt(txtIdMov.Text))
                    '------------------------------------------------------------
                    Me.Close()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Pago..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
    '------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmBuscarBuscarPedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaPagoProveedor.Enabled = True
        frmConsultaPagoProveedor.Show()
        frmConsultaPagoProveedor.BringToFront()
    End Sub
    '------------------------------------------------------------------------------------
End Class