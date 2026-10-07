Public Class frmDescuentoGrupoCliente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdLaboratorio As Integer = 0
    Dim intNro As Integer = 0
    Dim intIdGrupoCliente As Integer = 0
    Dim intIdDescuento As Integer = 0
    Dim intIdDet As Integer = 0
    Dim strLaboratorio As String = ""
    Dim douContado As Double = 0
    Dim douCredito As Double = 0
    Dim douTarjeta As Double = 0
    Dim douDebito As Double = 0
    Dim douChequeDife As Double = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '************************'
    '-- LOS PROCEDIMIENTOS --'
    '************************'
    Private Sub inicializar()
        consultaGrupoClienteDescuento()
        txtContado.Text = 0
        txtCredito.Text = 0
        txtTarjeta.Text = 0
        lblLaboratorio.Text = ""
    End Sub

    Private Sub habilitarObjetos()
        btnAplicar.Enabled = True
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False

        grGrupoCliente.Enabled = False
    End Sub

    Private Sub deshabilitarObjetos()
        btnAplicar.Enabled = False
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True

        grGrupoCliente.Enabled = True
    End Sub

    Private Sub cargarDetalleDescuento(ByVal v_idDescuento As Integer)
        If (fun_guardarSp("sp_cargarDetDescuentoGrupoClienteTipoVentaTmp", intGl_idConfigPc & "," & v_idDescuento, Me.Name)) = 0 Then

        Else
            consultarLaboratorioDesc()
        End If
    End Sub

    Public Sub consultarLaboratorioDesc()
        systemClass.SqlToLv_descuentoLaboratorioGrupoCliente(lvLaboratorio, "sp_consultaDetDescuentoGrupoClienteTipoVentaTmp", intGl_idConfigPc)
    End Sub

    Private Sub consultaGrupoClienteDescuento()
        systemClass.SqlToLv_detalleGrupoClienteDescuento(lvGrupo, "sp_consultaGrupoClienteDescuento", intGl_idConfigPc)
    End Sub

    Private Sub aplicarDescuento()
        If (fun_guardarSp("sp_aplicarTodosDetDescuentoGrupoClienteTipoVentaTmp", intGl_idConfigPc & "," & sacarComa(txtContado.Text) & "," & _
                          sacarComa(txtCredito.Text) & "," & sacarComa(txtTarjeta.Text), Me.Name)) = 0 Then

        Else
            consultarLaboratorioDesc()
        End If
    End Sub

    Private Sub guardarDescuento()
        If (fun_guardarSp("sp_guardarDescuentoGrupoCliente", intGl_idConfigPc & "," & intIdDescuento & "," & intGl_idUsuario, Me.Name)) = 0 Then
            MessageBox.Show("No se pudo guardar los descuentos...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            deshabilitarObjetos()
            inicializar()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- COMMANDBUTTOM --'
    '*******************'
    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        If intIdDescuento = 0 Then
            MessageBox.Show("Debe colocarse sobre un grupo de cliente...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        habilitarObjetos()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar el descuento..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarDescuento()
        End If
    End Sub

    Private Sub btnAplicar_Click(sender As System.Object, e As System.EventArgs) Handles btnAplicar.Click
        If MessageBox.Show("Desea aplicar este descuento a todos los Elaboradores..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            aplicarDescuento()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS LISTVIEW --'
    '******************'
    Private Sub lvGrupo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvGrupo.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvGrupo.SelectedItems
            cargarDetalleDescuento(CInt(item.SubItems(1).Text))
            intIdDescuento = CInt(item.SubItems(1).Text)
        Next
    End Sub

    Private Sub lvLaboratorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLaboratorio.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvLaboratorio.SelectedItems
            intNro = CInt(item.SubItems(0).Text)
            intIdDet = CInt(item.SubItems(1).Text)
            intIdLaboratorio = CInt(item.SubItems(2).Text)
            strLaboratorio = item.SubItems(3).Text
            douContado = CDbl(item.SubItems(4).Text)
            douCredito = CDbl(item.SubItems(5).Text)
            douTarjeta = CDbl(item.SubItems(6).Text)
            douDebito = CDbl(item.SubItems(7).Text)
            douChequeDife = CDbl(item.SubItems(8).Text)

            lblLaboratorio.Text = strLaboratorio
        Next
    End Sub

    Private Sub lvLaboratorio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvLaboratorio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Me.Enabled = False
            '-- valores al formulario
            frmModificaPorceDescuento.txtNro.Text = intNro
            frmModificaPorceDescuento.txtIdDet.Text = intIdDet
            frmModificaPorceDescuento.txtIdLab.Text = intIdLaboratorio
            frmModificaPorceDescuento.txtLaboratorio.Text = strLaboratorio
            frmModificaPorceDescuento.txtContado.Text = douContado
            frmModificaPorceDescuento.txtContado.Text = Format(CDec(frmModificaPorceDescuento.txtContado.Text), "##0.##")
            frmModificaPorceDescuento.txtCredito.Text = douCredito
            frmModificaPorceDescuento.txtCredito.Text = Format(CDec(frmModificaPorceDescuento.txtCredito.Text), "##0.##")
            frmModificaPorceDescuento.txtTarjeta.Text = douTarjeta
            frmModificaPorceDescuento.txtTarjeta.Text = Format(CDec(frmModificaPorceDescuento.txtTarjeta.Text), "##0.##")
            frmModificaPorceDescuento.txtDebito.Text = douDebito
            frmModificaPorceDescuento.txtDebito.Text = Format(CDec(frmModificaPorceDescuento.txtDebito.Text), "##0.##")
            frmModificaPorceDescuento.txtChequeDife.Text = douChequeDife
            frmModificaPorceDescuento.txtChequeDife.Text = Format(CDec(frmModificaPorceDescuento.txtChequeDife.Text), "##0.##")
            '----------------------------------------------
            frmModificaPorceDescuento.Show()
            frmModificaPorceDescuento.BringToFront()

            frmModificaPorceDescuento.txtContado.Focus()
        End If
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContado.KeyPress
        e.Handled = txtNumerico(txtContado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtContado.Text = Format(CDec(txtContado.Text), "##0.##")
            txtCredito.Focus()
        End If
    End Sub

    Private Sub txtCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCredito.KeyPress
        e.Handled = txtNumerico(txtCredito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtCredito.Text = Format(CDec(txtCredito.Text), "##0.##")
            txtTarjeta.Focus()
        End If
    End Sub

    Private Sub txtTarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTarjeta.KeyPress
        e.Handled = txtNumerico(txtTarjeta, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtTarjeta.Text = Format(CDec(txtTarjeta.Text), "##0.##")
            txtDebito.Focus()
        End If
    End Sub

    Private Sub txtDebito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDebito.KeyPress
        e.Handled = txtNumerico(txtDebito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtDebito.Text = Format(CDec(txtDebito.Text), "##0.##")
            txtChequeDife.Focus()
        End If
    End Sub

    Private Sub txtChequeDife_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChequeDife.KeyPress
        e.Handled = txtNumerico(txtChequeDife, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            txtChequeDife.Text = Format(CDec(txtChequeDife.Text), "##0.##")
            btnAplicar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmDescuentoGrupoCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.MercaderiaDescuentoGrupoCliente.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------

End Class