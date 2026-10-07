Public Class frmOrdenPreparadoSuvinil
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim envaseSuvinil As New envaseSuvinil
    Dim grupoSuvinil As New grupoSuvinil

    Dim bolError As Boolean
    Dim intNro As Integer = 0
    Dim intIdStock As Integer
    Dim strCodigo As String
    Dim strNombreProducto As String
    Dim douPrecio As Double
    Dim douGramo As Double
    Dim douPulso As Double

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- valor para los combos
        envaseSuvinil.listarEnvaseCombo(cboEnvase)
        grupoSuvinil.listarEnvaseCombo(cboGrupo)

        limpiar()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        txtCodigo.Text = ""
        txtNombreColor.Text = ""
        txtIdStock.Text = 0
        txtNombreBase.Text = ""
        txtBase.Text = ""
        txtTotalBase.Text = 0
        txtTotal.Text = 0
        txtCantidadLata.Text = 1

        sp_datosTabla.consulta_valor("delete from detOrdenSuvinilTmp where idConfig=" & intGl_idConfigPc)
        listarDetalle()
    End Sub

    Public Sub listarDetalle()
        systemClass.SqlToLv_listarOrdenPreparadoSuvinil(lvOrden, "sp_consultaDetOrdenSuvinilTmp", intGl_idConfigPc)
    End Sub

    Private Sub habilitarObjetos()
        '-- botones
        btnAgregar.Enabled = True
        btnBuscarBase.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        '-- txt
        txtCodigo.Enabled = True
        txtCodigo.BackColor = Color.White
        txtBase.Enabled = True
        txtBase.BackColor = Color.White
        txtCantidadLata.Enabled = True
        txtCantidadLata.BackColor = Color.White
        txtTotal.ReadOnly = False
        txtTotal.BackColor = Color.White
        '-- combobox
        cboEnvase.Enabled = True
        cboGrupo.Enabled = True
    End Sub

    Private Sub deshabilitarObjetos()
        '-- botones
        btnAgregar.Enabled = False
        btnBuscarBase.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        '-- txt
        txtCodigo.Enabled = False
        txtCodigo.BackColor = Color.LightBlue
        txtBase.Enabled = False
        txtBase.BackColor = Color.LightBlue
        txtCantidadLata.Enabled = False
        txtCantidadLata.BackColor = Color.LightBlue
        txtTotal.ReadOnly = True
        txtTotal.BackColor = Color.Lime
        '-- combobox
        cboEnvase.Enabled = False
        cboGrupo.Enabled = False
    End Sub

    Public Sub agregarDetalle(ByVal v_idStock As Integer)
        Try
            If (fun_guardarSp("sp_agregarDetOrdenSuvinilTmp", intGl_idConfigPc & "," & v_idStock, Me.Name)) = 0 Then
                MessageBox.Show("No se pudo agregar el detalle ...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                listarDetalle()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub controlarGuarda()
        '-- ingresar un codigo
        If txtCodigo.Text = "" Then
            MessageBox.Show("Debe ingresar el codigo del color...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtCodigo.Focus()
            Exit Sub
        End If
        '-- ingresar el stock de la base
        If txtIdStock.Text = 0 Then
            MessageBox.Show("Debe ingresar el stock de la base...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            btnBuscarBase.Focus()
            Exit Sub
        End If
        '-- ingresar la cantidad de lata
        If txtCantidadLata.Text <= 0 Then
            MessageBox.Show("Debe ingresar una cantidad válida de lata...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtCantidadLata.Focus()
            Exit Sub
        End If

    End Sub

    Public Sub sumarTotal()
        Dim douTmpTotal As Double
        If sp_datosTabla.consulta_valor("select idConfig from detOrdenSuvinilTmp where idConfig=" & intGl_idConfigPc) > 0 Then
            douTmpTotal = sp_datosTabla.consulta_valorDouble("select round(sum(precio*gramo),-3) from detOrdenSuvinilTmp where idConfig=" & intGl_idConfigPc)
            If douTmpTotal > 0 Then
                txtTotal.Text = douTmpTotal + CDbl(sacarComa(txtTotalBase.Text))
                txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,##0")
            Else
                txtTotal.Text = 0
            End If
        Else
            txtTotal.Text = 0
        End If

    End Sub

    Private Sub guardarOrden()
        Dim intTmpIdColor As Integer = 0
        Try
            intTmpIdColor = sp_datosTabla.consulta_valor("select idColorInmo from colorInmo where codigo='" & txtCodigo.Text & "'")

            If (fun_guardarSp("sp_guardarOrdenSuvinil", intGl_idConfigPc & "," & cboGrupo.SelectedValue & "," & intTmpIdColor & "," & txtIdStock.Text & ",'" & txtBase.Text & "'," & _
                              sacarComa(txtCantidadLata.Text) & "," & cboEnvase.SelectedValue & "," & sacarComa(txtTotal.Text) & "," & intGl_idUsuario, Me.Name)) = 0 Then
                MessageBox.Show("No se pudo guardar el preparado...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                limpiar()
                deshabilitarObjetos()
                sumarTotal()
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
        habilitarObjetos()
        cboGrupo.Focus()
    End Sub

    Private Sub btnBuscarBase_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarBase.Click
        banGl_ordenSuvinil = True

        Me.Enabled = False
        frmStockBasico.txtBuscar.Text = ""
        frmStockBasico.txtIdProducto.Text = "0"
        frmStockBasico.Visible = True
        frmStockBasico.WindowState = FormWindowState.Normal
        frmStockBasico.Show()
        frmStockBasico.listar_busqueda("")

        frmStockBasico.txtBuscar.Focus()
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        banGl_ordenSuvinil = True

        Me.Enabled = False
        frmStockColorante.txtBuscar.Text = ""
        frmStockColorante.txtIdProducto.Text = "0"
        frmStockColorante.Visible = True
        frmStockColorante.WindowState = FormWindowState.Normal
        frmStockColorante.Show()
        frmStockColorante.listar_busqueda("")

        frmStockColorante.txtBuscar.Focus()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from detOrdenSuvinilTmp where idConfig=" & intGl_idConfigPc & " and nro=" & intNro)
        sumarTotal()
        listarDetalle()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarGuarda()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar el Preparado..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarOrden()
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
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim intTmpIdColorInmo As Integer = 0

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If txtCodigo.Text <> "" Then
                intTmpIdColorInmo = sp_datosTabla.consulta_valor("select idColorInmo from colorInmo where codigo='" & txtCodigo.Text & "'")

                If intTmpIdColorInmo > 0 Then
                    txtNombreColor.Text = sp_datosTabla.consulta_valorString("select nombre from colorInmo where idColorInmo=" & intTmpIdColorInmo)
                Else
                    MessageBox.Show("No existe el codigo ingresado...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                btnBuscarBase.Focus()
            Else
                '-- buscar el color
                Me.Enabled = False

                banGl_ordenSuvinil = True
                frmBuscarColorInmo.Show()
                frmBuscarColorInmo.BringToFront()
                frmBuscarColorInmo.txtBuscar.Focus()
            End If

        End If
    End Sub

    Private Sub txtBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cboEnvase.Focus()
        End If
    End Sub

    Private Sub txtCantidadLata_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadLata.KeyPress
        e.Handled = txtNumerico(txtCantidadLata, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCantidadLata.Text = Format(CDec(txtCantidadLata.Text), "#,##0.##")
            txtTotal.Focus()
        End If
    End Sub

    Private Sub txtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        e.Handled = txtNumerico(txtTotal, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtTotal.Text = Format(CDec(txtTotal.Text), "##,###,##0")
            btnGuardar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- COMBOBOX --'
    '**************'
    Private Sub cboEnvase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEnvase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAgregar.Focus()
        End If
    End Sub

    Private Sub cboGrupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboGrupo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCodigo.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvOrden_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOrden.SelectedIndexChanged
        For Each item As ListViewItem In lvOrden.SelectedItems
            '-- nro
            intNro = CInt(item.SubItems(0).Text)

            strCodigo = item.SubItems(1).Text
            strNombreProducto = item.SubItems(2).Text
            douPrecio = CDbl(item.SubItems(3).Text)
            douGramo = CDbl(item.SubItems(4).Text)
            douPulso = CDbl(item.SubItems(5).Text)
        Next
    End Sub

    Private Sub lvOrden_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOrden.GotFocus
        For Each item As ListViewItem In lvOrden.SelectedItems
            '-- nro
            intNro = CInt(item.SubItems(0).Text)

            strCodigo = item.SubItems(1).Text
            strNombreProducto = item.SubItems(2).Text
            douPrecio = CDbl(item.SubItems(3).Text)
            douGramo = CDbl(item.SubItems(4).Text)
            douPulso = CDbl(item.SubItems(5).Text)
        Next
    End Sub

    Private Sub lvOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvOrden.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If intNro > 0 Then

                Me.Enabled = False
                '-- colocar los datos del registro
                frmCantidadSuvinil.txtNro.Text = intNro
                frmCantidadSuvinil.txtIdStock.Text = sp_datosTabla.consulta_valor("select idStock from detOrdenSuvinilTmp where idConfig=" & intGl_idConfigPc & " and nro=" & intNro)
                frmCantidadSuvinil.txtCodigo.Text = strCodigo
                frmCantidadSuvinil.txtMercaderia.Text = strNombreProducto
                frmCantidadSuvinil.txtPrecio.Text = douPrecio
                frmCantidadSuvinil.txtPrecio.Text = Format(CDec(frmCantidadSuvinil.txtPrecio.Text), "###,##0.##")
                frmCantidadSuvinil.txtGramo.Text = douGramo
                frmCantidadSuvinil.txtGramo.Text = Format(CDec(frmCantidadSuvinil.txtGramo.Text), "###,##0.##")
                frmCantidadSuvinil.txtPulso.Text = douPulso
                frmCantidadSuvinil.txtPulso.Text = Format(CDec(frmCantidadSuvinil.txtPulso.Text), "###,##0.##")

                frmCantidadSuvinil.Show()
                frmCantidadSuvinil.BringToFront()
                frmCantidadSuvinil.txtPulso.Focus()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmOrdenPreparadoCoral_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteOrdenPreparadoSuvinil.Enabled = True
        e.Cancel = False
    End Sub
End Class