Public Class frmDescuentoEspecialGrupoCliente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdDescuento As Integer = 0
    Dim intOpcion As Integer
    Dim intNro As Integer
    Dim strProducto As String
    Dim strCodigo As String
    Dim douPrecio As Double
    Dim douPorceContado As Double
    Dim douContadoMayo As Double
    Dim douPorceCredito As Double
    Dim douCreditoMayo As Double
    Dim douPrecioContado As Double
    Dim douPrecioCredito As Double

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '************************'
    '-- LOS PROCEDIMIENTOS --'
    '************************'
    Private Sub inicializar()
        cargarDescuento()
    End Sub

    Private Sub cargarDescuento()
        If (fun_guardarSp("sp_cargarDescuentoEspecialGrupoClienteTmp", intGl_idConfigPc, Me.Name)) = 0 Then

        Else
            consultaDescuento()
        End If
    End Sub

    Public Sub consultaDescuento()
        systemClass.SqlToLv_descuentoEspecialGrupoCliente(lvDes, "sp_consultaDescuentoEspecialGrupoClienteTmp", intGl_idConfigPc)
    End Sub

    Private Sub listarBusqueda(ByVal v_where As String, ByVal v_opcion As Integer)
        systemClass.SqlToLv_descuentoEspecialGrupoCliente(lvDes, "sp_consultaDescuentoEspecialGrupoClienteTmp_busqueda", intGl_idConfigPc & ",'" & v_where & "'," & v_opcion)
    End Sub

    Private Sub guardarDescuento()
        If (fun_guardarSp("sp_guardarDescuentoEspecialGrupoCliente", intGl_idConfigPc, Me.Name)) = 0 Then
            MessageBox.Show("No se pudo guardar los descuentos de mayoristas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            inicializar()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- COMMANDBUTTOM --'
    '*******************'
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Me.Enabled = False

        banGl_descuentoEspecialGrupoCliente = True
        frmStock.Show()
        frmStock.BringToFront()
        frmStock.txtBuscar.Focus()

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar el descuento de mayorista..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarDescuento()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from descuentoEspecialGrupoCliente where idDescuentoEspecialGrupoCliente=" & intIdDescuento)
        sp_datosTabla.consulta_valor("delete from descuentoEspecialGrupoClienteTmp where nro=" & intNro & " and idConfig=" & intGl_idConfigPc)

        consultaDescuento()
        lvDes.Items(intNro - 1).Focused = True
        lvDes.Items(intNro - 1).Selected = True
        lvDes.Focus()
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- por nombre 
                intOpcion = 2
                listarBusqueda(txtBuscar.Text, intOpcion)
            Else
                '-- por codigo
                intOpcion = 1
                listarBusqueda(txtBuscar.Text, intOpcion)
            End If
            lvDes.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS LISTVIEW --'
    '******************'
    Private Sub lvDes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDes.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvDes.SelectedItems
            intIdDescuento = CInt(item.SubItems(1).Text)

            intNro = CInt(item.SubItems(0).Text)
            strCodigo = item.SubItems(2).Text
            strProducto = item.SubItems(3).Text
            douPrecio = CDbl(item.SubItems(4).Text)
            douPorceContado = CDbl(item.SubItems(5).Text)
            douContadoMayo = CDbl(item.SubItems(6).Text)
            douPorceCredito = CDbl(item.SubItems(7).Text)
            douCreditoMayo = CDbl(item.SubItems(8).Text)
            douPrecioContado = CDbl(item.SubItems(9).Text)
            douPrecioCredito = CDbl(item.SubItems(10).Text)
        Next
    End Sub

    Private Sub lvDes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvDes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Me.Enabled = False
            '-- valores al formulario
            frmCargarDescuentoEspecialGrupoCliente.txtNro.Text = intNro
            frmCargarDescuentoEspecialGrupoCliente.txtIdDet.Text = intIdDescuento
            frmCargarDescuentoEspecialGrupoCliente.txtCodigo.Text = strCodigo
            frmCargarDescuentoEspecialGrupoCliente.txtProducto.Text = strProducto
            frmCargarDescuentoEspecialGrupoCliente.txtPrecio.Text = douPrecio
            frmCargarDescuentoEspecialGrupoCliente.txtPrecio.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPrecio.Text), "##,###,##0")
            frmCargarDescuentoEspecialGrupoCliente.txtPorceContado.Text = douPorceContado
            frmCargarDescuentoEspecialGrupoCliente.txtPorceContado.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPorceContado.Text), "##0.##")
            frmCargarDescuentoEspecialGrupoCliente.txtContadoMayo.Text = douContadoMayo
            frmCargarDescuentoEspecialGrupoCliente.txtContadoMayo.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtContadoMayo.Text), "##,###,##0")
            frmCargarDescuentoEspecialGrupoCliente.txtPorceCredito.Text = douPorceCredito
            frmCargarDescuentoEspecialGrupoCliente.txtPorceCredito.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPorceCredito.Text), "##0.##")
            frmCargarDescuentoEspecialGrupoCliente.txtCreditoMayo.Text = douCreditoMayo
            frmCargarDescuentoEspecialGrupoCliente.txtCreditoMayo.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtCreditoMayo.Text), "##,###,##0")
            frmCargarDescuentoEspecialGrupoCliente.txtPrecioContado.Text = douPrecioContado
            frmCargarDescuentoEspecialGrupoCliente.txtPrecioContado.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPrecioContado.Text), "##,###,##0")
            frmCargarDescuentoEspecialGrupoCliente.txtPrecioCredito.Text = douPrecioCredito
            frmCargarDescuentoEspecialGrupoCliente.txtPrecioCredito.Text = Format(CDec(frmCargarDescuentoEspecialGrupoCliente.txtPrecioCredito.Text), "##,###,##0")

            '----------------------------------------------
            frmCargarDescuentoEspecialGrupoCliente.Show()
            frmCargarDescuentoEspecialGrupoCliente.BringToFront()

            frmCargarDescuentoEspecialGrupoCliente.txtPrecioContado.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmDescuentoEspecialGrupoCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.MercaderiaDescuentoProductoMayo.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------
End Class