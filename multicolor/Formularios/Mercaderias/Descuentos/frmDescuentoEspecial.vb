Public Class frmDescuentoEspecial
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdDescuento As Integer = 0
    Dim intOpcion As Integer
    Dim intNro As Integer
    Dim strProducto As String
    Dim strCodigo As String
    Dim douPrecio As Double
    Dim douPrecio1Con As Double
    Dim douPrecio1Cre As Double
    Dim douPrecio1Tar As Double
    Dim douPrecio1Deb As Double

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
        If (fun_guardarSp("sp_cargarDescuentoEspecialTmp", intGl_idConfigPc, Me.Name)) = 0 Then

        Else
            consultaDescuento()
        End If
    End Sub

    Public Sub consultaDescuento()
        systemClass.SqlToLv_descuentoEspecial(lvDes, "sp_consultaDescuentoEspecialTmp", intGl_idConfigPc)
    End Sub

    Private Sub listarBusqueda(ByVal v_where As String, ByVal v_opcion As Integer)
        systemClass.SqlToLv_descuentoEspecial(lvDes, "sp_consultaDescuentoEspecialTmp_busqueda", intGl_idConfigPc & ",'" & v_where & "'," & v_opcion)
    End Sub

    Private Sub guardarDescuento()
        If (fun_guardarSp("sp_guardarDescuentoEspecial", intGl_idConfigPc, Me.Name)) = 0 Then
            MessageBox.Show("No se pudo guardar los descuentos especiales...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

        banGl_descuentoEspecial = True
        frmStock.Show()
        frmStock.BringToFront()
        frmStock.txtBuscar.Focus()

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar el descuento especial..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarDescuento()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from descuentoEspecial where idDescuentoEspecial=" & intIdDescuento)
        cargarDescuento()
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
            douPrecio1Con = CDbl(item.SubItems(5).Text)
            douPrecio1Cre = CDbl(item.SubItems(6).Text)
            douPrecio1Tar = CDbl(item.SubItems(7).Text)
            douPrecio1Deb = CDbl(item.SubItems(8).Text)
        Next
    End Sub

    Private Sub lvDes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvDes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Me.Enabled = False
            '-- valores al formulario
            frmCargarDescuentoEspecial.txtNro.Text = intNro
            frmCargarDescuentoEspecial.txtIdDet.Text = intIdDescuento
            frmCargarDescuentoEspecial.txtCodigo.Text = strCodigo
            frmCargarDescuentoEspecial.txtProducto.Text = strProducto
            frmCargarDescuentoEspecial.txtPrecio.Text = douPrecio
            frmCargarDescuentoEspecial.txtPrecio.Text = Format(CDec(frmCargarDescuentoEspecial.txtPrecio.Text), "##,###,##0")
            frmCargarDescuentoEspecial.txtPrecio1Con.Text = douPrecio1Con
            frmCargarDescuentoEspecial.txtPrecio1Con.Text = Format(CDec(frmCargarDescuentoEspecial.txtPrecio1Con.Text), "##,###,##0")
            frmCargarDescuentoEspecial.txtPrecio1Cre.Text = douPrecio1Cre
            frmCargarDescuentoEspecial.txtPrecio1Cre.Text = Format(CDec(frmCargarDescuentoEspecial.txtPrecio1Cre.Text), "##,###,##0")
            frmCargarDescuentoEspecial.txtPrecio1Tar.Text = douPrecio1Tar
            frmCargarDescuentoEspecial.txtPrecio1Tar.Text = Format(CDec(frmCargarDescuentoEspecial.txtPrecio1Tar.Text), "##,###,##0")
            frmCargarDescuentoEspecial.txtPrecio1Debito.Text = douPrecio1Deb
            frmCargarDescuentoEspecial.txtPrecio1Debito.Text = Format(CDec(frmCargarDescuentoEspecial.txtPrecio1Debito.Text), "##,###,##0")
            '----------------------------------------------
            frmCargarDescuentoEspecial.Show()
            frmCargarDescuentoEspecial.BringToFront()

            frmCargarDescuentoEspecial.txtPrecio1Con.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmDescuentoEspecial_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.MercaderiaDescuentoEspecial.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------

End Class
