Public Class frmBuscarFactura
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
        listar("")
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvMoneda, "Select f.idFactura,rtrim(f.dsuc)+'-'+rtrim(f.dcaja)+'-'+rtrim(f.nroFacturaSgte+1)  as Factura,timbrado,_vs.nombreFantasia as sucursal from factura f inner join v_sucursal _vs " & _
                            " on f.idSucursal=_vs.idSucursal " & where)
        ' txtSql.Text = "Select f.idFactura,rtrim(f.dsuc)+'-'+rtrim(f.dcaja)+'-'+rtrim(f.nroFacturaSgte+1)  as Factura,timbrado,_vs.nombre as sucursal from factura f inner join v_sucursal _vs " & _
        '                    " on f.idSucursal=_vs.idSucursal " & where
    End Sub

    Private Sub facturaVenta(ByVal v_idMoneda As Integer)
        '-- para el formulario de tabla de cotizacion
        'frmAbmPc.txtIdFactura.Text = txtId.Text
        'frmAbmPc.txtFactura.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(convert(varchar,nroFacturaSgte+1))+' / '+convert(varchar,timbrado) +' / '+convert(varchar,fechaCaduca) from factura where idFactura=" & txtId.Text)

        Me.Close()
    End Sub

    Private Sub verificarModulo()
        If banGl_abmConfigPc = True Then
            facturaVenta(txtId.Text)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'MsgBox("Se presiono enter")
            If rdSuc.Checked = True Then
                '-- buscar por dsuc de la factura, el primer digito de 3
                listar(" Where (_vs.nombreFantasia like '" & txtBuscar.Text & "%' or _vs.nombreFantasia like '" & txtBuscar.Text & "%') and f.activo=1")
            End If

            If rdIdSucursal.Checked = True Then
                '-- buscar por id
                listar(" Where f.idSucursal='" & txtBuscar.Text & "' and f.activo=1")
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
    Private Sub frmBuscarLaboratorio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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