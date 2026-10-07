Public Class frmCantidadVenta
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdProducto As Integer
    Dim intIdUsuario As Integer
    Dim douPrecio As Double
    Dim intIdDescuento As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub cargarVentaFarmacia()
        If (fun_guardarSp("sp_updDetVentaFarmaciaTmp", intGl_idEntidad & "," & intGl_idConfigPc & "," & txtNro.Text & "," & _
                          txtCantidadNueva.Text & "," & sacarComa(txtPrecio.Text) & "," & intIdDescuento, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        frmVentaFarmacia1.actualizarDetVenta()
        frmVentaFarmacia1.sumarTotales()

        Me.Close()
        frmVentaFarmacia1.Enabled = True
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
        'frmRemisionMercaderia.txtProducto.Focus()
    End Sub

    '-- listar los precios del descuento especial
    Private Sub listarPrecios()
        Dim intIdProducto As Integer = 0

        intIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & txtCodigo.Text)

        systemClass.SqlToLv_descuentoEspecialVenta(lvPrecio, "sp_consultaPrecioDescuentoEspecial", intGl_idConfigPc & "," & intIdProducto & "," & frmVentaFarmacia1.lblIdTipoVenta.Text)
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtCantidadNueva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadNueva.KeyPress
        e.Handled = txtNumerico(txtCantidadNueva, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAgregar.Focus()
        End If
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(txtUsuario.Text) = 0 Then
                MessageBox.Show("Debe ingresar un Usuario..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            e.Handled = True
            txtContra.Focus()
        End If
    End Sub

    Private Sub txtContra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(txtUsuario.Text) = 0 Then
                MessageBox.Show("Debe ingresar una Clave..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            e.Handled = True
            intIdUsuario = sp_datosTabla.sp_traerValorInteger("sp_claveUsuario", "'" & txtContra.Text & "'", 3)
            'MsgBox("Valor de idUsuario " & intIdUsuario)
            If sp_datosTabla.consulta_valor("select idUsuario from usuario where administrador=1 and idUsuario=" & intIdUsuario) > 0 Then
                '-- abrir la consulta de los precios
                listarPrecios()

                lvPrecio.Focus()
            Else
                MessageBox.Show("Usted no cuenta con los permisos necesarios..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
    End Sub
    '-----------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        '-- controlar que la cantidad no sea cero
        If txtCantidadNueva.Text <= 0 Then
            MessageBox.Show("La cantidad Ingresada no es Válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        cargarVentaFarmacia()

    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS LISTVIEW --'
    '******************'
    Private Sub lvPrecio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPrecio.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvPrecio.SelectedItems
            douPrecio = CDbl(item.SubItems(0).Text)
            intIdDescuento = CInt(item.SubItems(1).Text)
        Next
    End Sub

    Private Sub lvPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPrecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPrecio.Text = douPrecio
            txtPrecio.Text = Format(CDec(txtPrecio.Text), "##,###,##0")

            txtCantidadNueva.Focus()
        End If
    End Sub
    '-----------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCantidadVenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmVentaFarmacia1.Enabled = True
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
        'frmRemisionMercaderia.txtProducto.Focus()
    End Sub

    Private Sub frmCantidadVenta_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        txtCantidadNueva.Focus()
    End Sub
    '-----------------------------------------------------
End Class