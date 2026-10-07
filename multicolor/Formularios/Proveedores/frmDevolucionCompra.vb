Public Class frmDevolucionCompra
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
        txtFactura.Text = 1

        sp_datosTabla.consulta_valor("delete from detDevolucionCompraTmp where idConfig=" & intGl_idConfigPc)
        listarDetalle()
    End Sub

    Public Sub listarDetalle()
        systemClass.SqlToLv_listarDevolucionCompra(lvDetalle, "sp_consultaDetDevolucionCompraTmp", intGl_idConfigPc & "," & txtIdCompra.Text)
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
    End Sub

    Private Sub agregarDetalle()
        Try
            If (fun_guardarSp("sp_agregarDetDevolucionCompraTmp", intGl_idConfigPc & "," & txtIdStock.Text & "," & CDbl(sacarComa(txtCantidad.Text)), Me.Name)) = 0 Then
                MessageBox.Show("No se pudo agregar el detalle ...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                listarDetalle()
                txtIdStock.Text = 0
                txtCodigo.Text = ""
                txtProducto.Text = ""
                txtCantidad.Text = 0
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
    End Sub

    Private Sub guardarDevolucion()
        Try
            If (fun_guardarSp("sp_guardarDevolucionCompra", intGl_idConfigPc & "," & txtIdCompra.Text & ",'" & dtpFecha.Text & "'," & _
                              intGl_idUsuario, Me.Name)) = 0 Then
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
        banGl_devolucionCompra = True

        Me.Enabled = False
        frmBuscarFacturaCompra.WindowState = FormWindowState.Normal
        frmBuscarFacturaCompra.Show()
        frmBuscarFacturaCompra.BringToFront()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        banGl_devolucionCompra = True

        Me.Enabled = False
        frmProductoFacturaCompra.listarProductoCompra(txtIdCompra.Text)
        frmProductoFacturaCompra.WindowState = FormWindowState.Normal
        frmProductoFacturaCompra.Show()
        frmProductoFacturaCompra.BringToFront()
        frmProductoFacturaCompra.lvProducto.Focus()

    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        bolError = False
        controlarCarga()
        If bolError = False Then
            agregarDetalle()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from detDevolucionCompraTmp where idConfig=" & intGl_idConfigPc & " and nro=" & intNro)
        listarDetalle()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        'controlarGuarda()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar la devolución..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarDevolucion()
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
            btnAgregar.Focus()
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
    Private Sub frmDevolucionCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.proveedorDevolucion.Enabled = True
        e.Cancel = False
    End Sub
End Class