Public Class frmBuscarDeposito
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim tipoSucursal As New tipoSucursal

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        tipoSucursal.comboTipoSucursal(cboTipoSucursal)
        listar("")
        inicioForm()
    End Sub

    Public Sub inicioForm()
        tipoSucursal.comboTipoSucursal(cboTipoSucursal)
        cboTipoSucursal.SelectedValue = 1

    End Sub

    Public Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select d.idDeposito,d.nombreDeposito,_vs.nombreFantasia as sucursal from deposito d " & _
                            " inner join v_sucursal _vs on d.idSucursal=_vs.idSucursal" & where)
        'MsgBox("Paso 1")
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80
        lvBuscar.Columns(1).Width = 250
        lvBuscar.Columns(2).Width = 250
        lvBuscar.Columns(0).Text = "ID Suc."
        lvBuscar.Columns(1).Text = "Nombre del Deposito"
        lvBuscar.Columns(2).Text = "Nombre de la Sucursal"
        lvBuscar.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_modificaVence = True Then
            '-- modificacion del vencimiento
            modificacionVencimiento()
        End If
        If banGl_OrdenPagoCheque = True Then
            '-- orden pago de cheques
            ordenCheque()
        End If
    End Sub

    '-- modificacion del vencimiento
    Private Sub modificacionVencimiento()
        '-- lbl
        frmModificarVence.lblIdDeposito.Text = txtId.Text
        frmModificarVence.lblDeposito.Text = txtNombre.Text
        '-- txt
        frmModificarVence.txtIdDeposito.Text = txtId.Text
        frmModificarVence.txtDeposito.Text = txtNombre.Text

        Me.Close()
    End Sub

    '-- orden de chques
    Private Sub ordenCheque()
        frmCargarOrdenPagoCheque.lblIdProveedor.Text = txtId.Text
        frmCargarOrdenPagoCheque.lblProveedor.Text = txtNombre.Text

        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idDeposito
                If banGl_remisionPendiente = True Then
                    '-- solo para la remision pendiente en donde solo los depositos habilitados pueden recibir
                    listar(" Where _vs.idTipoSucursal=" & cboTipoSucursal.SelectedValue & " and d.idDeposito=" & txtBuscar.Text)
                Else
                    listar(" Where d.idDeposito=" & txtBuscar.Text & " and _vs.idTipoSucursal=" & cboTipoSucursal.SelectedValue)
                End If

            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre del deposito
                If banGl_remisionPendiente = True Then
                    listar(" Where (d.nombreDeposito Like '" & txtBuscar.Text & "%' Or d.nombreDeposito Like '" & txtBuscar.Text & "%') and  _vs.idTipoSucursal=" & cboTipoSucursal.SelectedValue & " order by d.nombreDeposito")
                Else
                    listar(" Where (d.nombreDeposito Like '" & txtBuscar.Text & "%' Or d.nombreDeposito Like '" & txtBuscar.Text & "%') and _vs.idTipoSucursal=" & cboTipoSucursal.SelectedValue & " order by d.nombreDeposito")
                End If

            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If IsNumeric(txtId.Text) Then
                If txtId.Text = 0 Then
                    MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                controlarModulo()
            End If

        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtId.Text = item.SubItems(0).Text
            txtNombre.Text = item.SubItems(1).Text
        Next
    End Sub
    '--------------------------------------------------------------------------------------
    '*****************'
    '-- EL COMBOBOX --'
    '*****************'
    Private Sub cboTipoSucursal_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoSucursal.SelectedIndexChanged
        listar(" Where _vs.idTipoSucursal=" & cboTipoSucursal.SelectedValue)
    End Sub
    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarDeposito_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_modificaVence = True Then
            '-- modificacion de vencimientos
            banGl_modificaVence = False

            frmModificarVence.Enabled = True
            frmModificarVence.Show()
            frmModificarVence.BringToFront()
            frmModificarVence.txtProducto.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------


End Class