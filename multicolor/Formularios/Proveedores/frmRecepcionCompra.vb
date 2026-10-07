Public Class frmRecepcionCompra
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim bolError As Boolean
    Dim intNro As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        dtpFecha.Format = DateTimePickerFormat.Custom
        dtpFecha.CustomFormat = "dd/MM/yyyy"
        limpiar()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        txtCodigo.Text = ""
        txtProducto.Text = ""
        txtIdStock.Text = 0
        txtCantidad.Text = 1
        txtIdCompra.Text = 0
        txtProveedor.Text = ""
        txtFechaCompra.Text = ""
        txtFactura.Text = ""
        txtCantidadAnterior.Text = 0
        txtSaldo.Text = 0
        txtIdDev.Text = 0
        txtDsuc.Text = ""
        txtDcaja.Text = ""
        txtNroRemision.Text = ""

        sp_datosTabla.consulta_valor("delete from detRecepcionCompraTmp where idConfig=" & intGl_idConfigPc)
        listarDetalle()
    End Sub

    Public Sub listarDetalle()
        systemClass.SqlToLv_listarRecepcionCompra(lvDetalle, "sp_consultaDetRecepcionCompraTmp", intGl_idConfigPc & "," & txtIdDev.Text)
    End Sub

    Public Sub habilitarObjetos()
        '-- botones
        btnAgregar.Enabled = True
        btnBuscar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        '-- txt
        txtCantidad.ReadOnly = False
        txtCantidad.BackColor = Color.White
        txtDsuc.ReadOnly = False
        txtDsuc.BackColor = Color.White
        txtDcaja.ReadOnly = False
        txtDcaja.BackColor = Color.White
        txtNroRemision.ReadOnly = False
        txtNroRemision.BackColor = Color.White
    End Sub

    Private Sub deshabilitarObjetos()
        '-- botones
        btnAgregar.Enabled = False
        btnBuscar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        '-- txt
        txtCantidad.ReadOnly = True
        txtCantidad.BackColor = Color.LightBlue
        txtDsuc.ReadOnly = True
        txtDsuc.BackColor = Color.LightBlue
        txtDcaja.ReadOnly = True
        txtDcaja.BackColor = Color.LightBlue
        txtNroRemision.ReadOnly = True
        txtNroRemision.BackColor = Color.LightBlue
    End Sub

    Private Sub agregarDetalle()
        Try
            If (fun_guardarSp("sp_agregarDetRecepcionCompraTmp", intGl_idConfigPc & "," & txtIdStock.Text & "," & _
                              CDbl(sacarComa(txtCantidad.Text)) & "," & CDbl(sacarComa(txtCantidadAnterior.Text)), Me.Name)) = 0 Then
                MessageBox.Show("No se pudo agregar el detalle ...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                listarDetalle()
                txtIdStock.Text = 0
                txtCodigo.Text = ""
                txtProducto.Text = ""
                txtCantidad.Text = 0
                txtCantidadAnterior.Text = 0
                txtSaldo.Text = 0
                btnBuscar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub controlarCarga()
        '-- ingresar un codigo
        If txtCantidad.Text <= 0 Then
            MessageBox.Show("La cantidad no es válida...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtCantidad.Focus()
            Exit Sub
        End If
        '-- ingresar el stock de la base
        If txtIdStock.Text = 0 Then
            MessageBox.Show("Debe ingresar la mercaderia...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            btnBuscar.Focus()
            Exit Sub
        End If
        '-- controlar el saldo
        If txtSaldo.Text < 0 Then
            MessageBox.Show("La cantidad ingresada excede el saldo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtCantidad.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub controlarGuardar()
        '-- dsuc
        If txtDsuc.Text = "" Then
            MessageBox.Show("Nro de Remisión no es válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtDsuc.Focus()
            Exit Sub
        End If
        '-- dcaja
        If txtDcaja.Text = "" Then
            MessageBox.Show("Nro de Remisión no es válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtDcaja.Focus()
            Exit Sub
        End If
        '-- nroRemision
        If txtNroRemision.Text = "" Then
            MessageBox.Show("Nro de Remisión no es válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtNroRemision.Focus()
            Exit Sub
        End If
        ''-- verificar si ya existe nro de remision
        'If sp_datosTabla.consulta_valor("select idRecepcionCompra from cabRecepcionCompra where activo=1 and dsuc='" & txtDsuc.Text & _
        '                                "' and dcaja='" & txtDcaja.Text & "' and nroRemision='" & txtNroRemision.Text & "'") > 0 Then
        '    MessageBox.Show("Nro de Remisión ya está cargado en el sistema...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    bolError = True
        '    txtNroRemision.Focus()
        '    Exit Sub
        'End If

    End Sub

    Private Sub guardarRecepcion()
        Try
            If (fun_guardarSp("sp_guardarRecepcionCompra", intGl_idConfigPc & "," & txtIdDev.Text & ",'" & txtDsuc.Text & "','" & txtDcaja.Text & "','" & _
                              txtNroRemision.Text & "','" & dtpFecha.Text & "'," & intGl_idUsuario, Me.Name)) = 0 Then
                MessageBox.Show("No se pudo guardar la devolución...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                limpiar()
                deshabilitarObjetos()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        banGl_recepcionCompra = True

        Me.Enabled = False
        frmBucarCompraDevolucion.WindowState = FormWindowState.Normal
        frmBucarCompraDevolucion.Show()
        frmBucarCompraDevolucion.BringToFront()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click

        Me.Enabled = False
        frmProductoDevolucionCompra.listarProductoCompra(txtIdDev.Text)
        frmProductoDevolucionCompra.WindowState = FormWindowState.Normal
        frmProductoDevolucionCompra.Show()
        frmProductoDevolucionCompra.BringToFront()
        frmProductoDevolucionCompra.lvProducto.Focus()

    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        bolError = False
        controlarCarga()
        If bolError = False Then
            agregarDetalle()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from detRecepcionCompraTmp where idConfig=" & intGl_idConfigPc & " and nro=" & intNro)
        listarDetalle()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarGuardar()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar la recepcion..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarRecepcion()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
        deshabilitarObjetos()
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = txtNumerico(txtCantidad, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If txtCantidad.Text.Length = 0 Then
                txtCantidad.Text = 1
            End If
            txtCantidad.Text = Format(CDec(txtCantidad.Text), "#,##0.##")
            '-- el saldo
            txtSaldo.Text = CDbl(sacarComa(txtCantidadAnterior.Text)) - CDbl(sacarComa(txtCantidad.Text))
            txtSaldo.Text = Format(CDec(txtSaldo.Text), "#,##0.##")
            btnAgregar.Focus()
        End If
    End Sub

    Private Sub txtDsuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDcaja.Focus()
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNroRemision.Focus()
        End If
    End Sub

    Private Sub txtNroRemision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroRemision.KeyPress
        e.Handled = txtNumerico(txtNroRemision, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            dtpFecha.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetalle.SelectedIndexChanged
        For Each item As ListViewItem In lvDetalle.SelectedItems
            '-- nro
            intNro = CInt(item.SubItems(0).Text)
        Next
    End Sub

    Private Sub lvDetalle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetalle.GotFocus
        For Each item As ListViewItem In lvDetalle.SelectedItems
            '-- nro
            intNro = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '----------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmRecepcionCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.proveedorRecepcion.Enabled = True
        e.Cancel = False
    End Sub
End Class