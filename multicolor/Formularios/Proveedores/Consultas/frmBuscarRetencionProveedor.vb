Public Class frmBuscarRetencionProveedor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdRetencion As Integer

    Sub New()
        InitializeComponent()

        ' MsgBox("Valor de la variable " & banGl_consultaRetencionVenta)

    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarConsultaVenta(ByVal where As String)
        '-- para los impresos
        systemClass.SqlToLv_consultaCompra(lvVenta, "select cr.idRetencionProveedor,cr.dsuc,cr.dcaja,cr.factura,cr.timbrado,_vp.nombre,cr.total," & _
                                        "fecha from cabRetencionProveedor cr inner join v_proveedor _vp on cr.idProveedor=_vp.idProveedor " & where)
        'txtSql.Text = "select cr.idRetencionProveedor,cr.dsuc,cr.dcaja,cr.factura,cr.timbrado,_vp.nombre,cr.total," & _
        '                                "fecha,sucursal from cabRetencionProveedor cr inner join v_proveedor _vp on cr.idProveedor=_vp.idProveedor " & where

    End Sub

    Private Sub controlarModulo()
        'MsgBox("Valor de la variable " & banGl_consultaRetencionVenta)

        If banGl_consultaRetencionProveedor = True Then
            retencionProveedor()
        End If

    End Sub

    '-- retencion en Venta
    Private Sub retencionProveedor()
        '-----------------------------------------
        frmConsultaRetencionProveedor.actualizarCabeceraRetencion(intIdRetencion)
        frmConsultaRetencionProveedor.listarDetalleRetencion(intIdRetencion)
        Me.Close()

    End Sub

    '------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdFactura.CheckedChanged
        txtDcaja.Visible = True
        txtDcaja.Text = ""
        txtDsuc.Visible = True
        txtDsuc.Text = ""
        txtFactura.Visible = True
        txtFactura.Text = ""
        txtBuscar.Visible = False
        txtDsuc.Focus()
    End Sub

    Private Sub rdCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdCliente.CheckedChanged
        txtDcaja.Visible = False
        txtDsuc.Visible = False
        txtFactura.Visible = False
        txtBuscar.Visible = True
        txtBuscar.Text = ""
        txtBuscar.Focus()
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '-- controlar la primera letra ingresada
                If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                    '-- ordenar por idCompra
                    listarConsultaVenta(" Where idRetencionProveedor= " & txtBuscar.Text)
                Else
                    ' ordenar por nombre del proveedor
                    listarConsultaVenta(" Where _vp.nombre Like '" & txtBuscar.Text & "%' Or _vp.nombre Like '" & txtBuscar.Text & "%' " & "order by _vp.nombre")
                End If
            End If
            lvVenta.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Down) Then
            'MsgBox("Paso por aca")
        End If

    End Sub

    Private Sub txtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtFactura.Text.Length > 0 Then
                If rdFactura.Checked = True Then
                    '-- ordenar por factura
                    listarConsultaVenta(" Where cr.dsuc=" & txtDsuc.Text & " and cr.dcaja=" & txtDcaja.Text & " and cr.factura=" & txtFactura.Text)
                    lvVenta.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtDsuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDcaja.Focus()
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtFactura.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvVenta.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdRetencion.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            intIdRetencion = (CInt(txtIdRetencion.Text))

            ' MsgBox("Valor de la variable " & banGl_consultaRetencionVenta)

            controlarModulo()

        End If
    End Sub

    Private Sub lvVenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVenta.SelectedIndexChanged
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvVenta.SelectedItems
            txtIdRetencion.Text = item.SubItems(0).Text
        Next
    End Sub
    '------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarRetencionCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        If banGl_consultaRetencionProveedor = True Then
            '-- consulta de retencion de venta
            banGl_consultaRetencionProveedor = False

            frmConsultaRetencionProveedor.Enabled = True
            frmConsultaRetencionProveedor.Show()
            frmConsultaRetencionProveedor.BringToFront()
        End If


    End Sub
    '------------------------------------------------------------------------------------------------------------------
End Class