Public Class frmBuscarDepositoBanco
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
        systemClass.SqlToLv(lvBuscar, "Select cd.idDepositoBanco,c.nombreBanco,c.nroCuenta,m.nombreMoneda,cd.total,cd.nroDoc,cd.fecha from cabDepositoBanco cd inner join cuentaCorriente c on cd.idCuenta=c.idCuenta inner join moneda m on m.idMoneda=c.idMoneda  " & where)
        'txtSql.Text = "Select cc.idCaja,cc.totalCaja,cc.totalSistema,ltrim(_vs.nombreFantasia) as Sucursal,cc.fechaAlta from cabCaja cc inner join v_sucursal _vs on cc.idSucursal=_vs.idSucursal  " & where
    End Sub
    '------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre del baco
                listar(" Where nombreBanco Like '" & txtBuscar.Text & "%' Or nombreBanco Like '" & txtBuscar.Text & "%' " & "order by nombreBanco")
            Else
                '-- buscar por idCaja
                listar(" Where idDepositoBanco=" & txtBuscar.Text & " order by idDepositoBanco")
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
                    frmConsultaDepositoBanco.listarDetalle(CInt(txtIdMov.Text))
                    '-- los datos
                    frmConsultaDepositoBanco.actualizarCabecera(CInt(txtIdMov.Text))
                    '------------------------------------------------------------
                    Me.Close()
                    frmConsultaDepositoBanco.Enabled = True
                    frmConsultaDepositoBanco.Show()
                    frmConsultaDepositoBanco.BringToFront()
                End If
            Else
                MessageBox.Show("Debe ingresar alguna Caja..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
    Private Sub frmBuscarBuscarDepositoBanco_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaDepositoBanco.Enabled = True
        frmConsultaDepositoBanco.Show()
        frmConsultaDepositoBanco.BringToFront()
    End Sub
End Class