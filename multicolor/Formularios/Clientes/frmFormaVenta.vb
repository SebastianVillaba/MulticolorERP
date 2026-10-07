Public Class frmFormaVenta
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim intIdTipoVenta As Integer

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        listar_busqueda()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub inicializar()
        '- colocar las columnas que seran visibles
        ' listar_busqueda("")
    End Sub

    Sub listar_busqueda()
        systemClass.SqlToLv_formaVenta(lvFormaVenta, "sp_consultaFormaVenta")
        'txtSql.Text = "exec sp_ProductoFraccionado " & v_idProducto
    End Sub

    Private Sub controlarModulo()
        If banGl_ventaFarmacia1 = True Then
            '-- venta farmacia
            formaVentaFarmacia1()
        End If
    End Sub

    '-- venta de farmacia1
    Private Sub formaVentaFarmacia1()
        '-------------------------------------------------------------'
        '-- controlar si esa forma de venta es permitida al cliente --'
        '-------------------------------------------------------------'
        If sp_datosTabla.sp_integer("sp_verificarFormaVentaCliente", frmVentaFarmacia1.txtIdCliente.Text & "," & intIdTipoVenta & "," & "0") = 0 Then
            MessageBox.Show("Este Cliente no está Habilitado para Realizar esta Operación....!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            banGl_ventaFarmacia1 = False
            frmVentaFarmacia1.lblIdTipoVenta.Text = intIdTipoVenta
            frmVentaFarmacia1.lblFormaVenta.Text = txtFormaVenta.Text
            'MsgBox("Valor de forma de venta  " & txtFormaVenta.Text)
            Me.Close()

            '-- actualizar el detalle de la venta temporal
            If (fun_guardarSp("sp_updDetVentaFarmaciaTmpDelivery", intGl_idEntidad & "," & intGl_idConfigPc & "," & CInt(frmVentaFarmacia1.txtIdCliente.Text) & "," & intIdTipoVenta & "," & CInt(frmVentaFarmacia1.txtIdTipoventa.Text), Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            '--------------------------------------------
            frmVentaFarmacia1.sumarTotales()

            frmVentaFarmacia1.Enabled = True
            frmVentaFarmacia1.Show()
            frmVentaFarmacia1.BringToFront()
            frmVentaFarmacia1.txtBuscar.Focus()
        End If
    End Sub


    Private Sub lvFormaVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvFormaVenta.KeyPress
        'If e.KeyChar = ChrW(Keys.Escape) Then
        '    Me.Close()
        'End If
        If Len(txtFormaVenta.Text) > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- insertar en la grilla los datos del producto
                controlarModulo()
            End If
        End If

    End Sub

    Private Sub lvFormaVenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFormaVenta.SelectedIndexChanged
        If lvFormaVenta.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In lvFormaVenta.SelectedItems
                txtFormaVenta.Text = Trim(item.SubItems(1).Text)
                intIdTipoVenta = item.SubItems(0).Text
            Next
        End If
    End Sub

End Class