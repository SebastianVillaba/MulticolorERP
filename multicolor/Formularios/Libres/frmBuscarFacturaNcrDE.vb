Public Class frmBuscarFacturaNcrDE
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'  
    Private Sub inicializar()
        listar(" where df.idFacturaDE=5 and df.idSucursal=" & intGl_abmIdSucursalConfig)
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvMoneda, "Select df.idDetFacturaDE,rtrim(df.dsuc)+'-'+rtrim(df.dcaja)+'-'+rtrim(df.nroFactura+1)  as Factura,t.nroTimbrado," & _
                            "_vs.nombreFantasia as sucursal from detFacturaDE df inner join v_sucursal _vs " & _
                            " on df.idSucursal=_vs.idSucursal inner join detFacturaDETimbrado dft on dft.idFacturaDE=df.idFacturaDE " & _
                            " inner join timbradoDE t on t.idTimbradoDE=dft.idTimbradoDE " & where)
        'txtSql.Text = "Select df.idDetFacturaDE,rtrim(df.dsuc)+'-'+rtrim(df.dcaja)+'-'+rtrim(df.nroFactura+1)  as Factura,t.nroTimbrado," & _
        '                    "_vs.nombreFantasia as sucursal from detFacturaDE df inner join v_sucursal _vs " & _
        '                    " on df.idSucursal=_vs.idSucursal inner join detFacturaDETimbrado dft on dft.idFacturaDE=df.idFacturaDE " & _
        '                    " inner join timbradoDE t on t.idTimbradoDE=dft.idTimbradoDE " & where
    End Sub

    Private Sub abmConfigPc(ByVal v_idDetFactura As Integer)
        '-- para el formulario de tabla de cotizacion
        frmAbmPc.txtIdNcrDE.Text = v_idDetFactura
        frmAbmPc.txtNcrDE.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(convert(varchar,nroFactura+1)) " & _
                                                                      " from detFacturaDE where idDetFacturaDE=" & v_idDetFactura)

        Me.Close()
    End Sub

    Private Sub verificarModulo()
        If banGl_abmConfigPc = True Then
            abmConfigPc(txtId.Text)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'MsgBox("Se presiono enter")
            If IsNumeric(txtBuscar.Text) = True Then
                '-- buscar por id Sucursal
                listar(" Where df.idSucursal=" & txtBuscar.Text & " and df.idFacturaDE=5 and df.idSucursal=" & intGl_abmIdSucursalConfig)
            Else
                '-- buscar por nombre de sucursal
                listar(" Where (_vs.nombreFantasia like '" & txtBuscar.Text & "%' or _vs.nombreFantasia like '" & txtBuscar.Text & "%') and df.idFacturaDE=5 and df.idSucursal=" & intGl_abmIdSucursalConfig)
            End If

            lvMoneda.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvMoneda.KeyPress
        If txtId.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtId.Text) = 0 Then
                    MessageBox.Show("Debe ingresar alguna Factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                verificarModulo()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvMoneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMoneda.SelectedIndexChanged
        For Each item As ListViewItem In lvMoneda.SelectedItems
            txtId.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarFacturaNcrDE_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_abmConfigPc = True Then
            banGl_abmConfigPc = False
            e.Cancel = False
            frmAbmPc.Enabled = True
            frmAbmPc.Show()
            frmAbmPc.BringToFront()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
End Class