Public Class frmOrdenPreparadoAutomotive
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim lineaSuvinil As New lineaSuvinil
    Dim calidad As New calidad
    Dim descuentoAuto As New descuentoAuto

    Dim bolError As Boolean
    Dim intNro As Integer = 0

    Dim intIdStock As Integer
    Dim strComponentes As String
    Dim douPrecio As Double
    Dim douPrecioOr As Double
    Dim douGramo As Double
    Dim douAcumulado As Double

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiar()

        '-- valor para los combos
        lineaSuvinil.listarLineaCombo(cboLinea)
        calidad.listarLineaCombo(cboCalidad)
        descuentoAuto.listarLineaCombo(cboDescuento)
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        txtCodigo.Text = ""
        txtNombreColor.Text = ""
        txtAlternativa.Text = ""
        txtIdEnsambladora.Text = 0
        txtEnsambladora.Text = ""
        txtAnho.Text = 0
        txtTotal.Text = 0
        txtRegion.Text = ""
        txtValueShade.Text = ""
        txtCantidadLata.Text = 1
        txtTotalDescuento.Text = 0
        txtTotalCosto.Text = 0
        txtTotalGramo.Text = 0
        txtTotalLitro.Text = 0
        '-- los litros
        rdDosLitros.Checked = False
        rdMedioLitro.Checked = False
        rdOtro.Checked = False
        rdTresLitros.Checked = False
        rdUnLitro.Checked = False

        sp_datosTabla.consulta_valor("delete from detOrdenAutomotiveTmp where idConfig=" & intGl_idConfigPc)
        cboDescuento.SelectedValue = 1
        listarDetalle()
    End Sub

    Public Sub listarDetalle()
        systemClass.SqlToLv_listarOrdenPreparadoAutomotive(lvOrden, "sp_consultaDetOrdenAutomotiveTmp", intGl_idConfigPc)
    End Sub

    Private Sub habilitarObjetos()
        '-- botones
        btnAgregar.Enabled = True
        btnBuscarEnsambladora.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        '-- txt
        txtCodigo.Enabled = True
        txtCodigo.BackColor = Color.White
        txtNombreColor.Enabled = True
        txtNombreColor.BackColor = Color.White
        txtAlternativa.Enabled = True
        txtAlternativa.BackColor = Color.White
        txtCantidadLata.Enabled = True
        txtCantidadLata.BackColor = Color.White
        txtTotal.ReadOnly = False
        txtTotal.BackColor = Color.White
        txtAnho.Enabled = True
        txtAnho.BackColor = Color.White
        txtRegion.Enabled = True
        txtRegion.BackColor = Color.White
        txtValueShade.Enabled = True
        txtValueShade.BackColor = Color.White

        '-- combobox
        cboLinea.Enabled = True
        cboCalidad.Enabled = True
        cboDescuento.Enabled = True
    End Sub

    Private Sub deshabilitarObjetos()
        '-- botones
        btnAgregar.Enabled = False
        btnBuscarEnsambladora.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        '-- txt
        txtCodigo.Enabled = False
        txtCodigo.BackColor = Color.LightBlue
        txtNombreColor.Enabled = False
        txtNombreColor.BackColor = Color.LightBlue
        txtAlternativa.Enabled = False
        txtAlternativa.BackColor = Color.LightBlue
        txtCantidadLata.Enabled = False
        txtCantidadLata.BackColor = Color.LightBlue
        txtTotal.ReadOnly = True
        txtTotal.BackColor = Color.Lime
        txtAnho.Enabled = False
        txtAnho.BackColor = Color.LightBlue
        txtRegion.Enabled = False
        txtRegion.BackColor = Color.LightBlue
        txtValueShade.Enabled = False
        txtValueShade.BackColor = Color.LightBlue

        '-- combobox
        cboLinea.Enabled = False
        cboCalidad.Enabled = False
        cboDescuento.Enabled = False
    End Sub

    Public Sub agregarDetalle(ByVal v_idStock As Integer)
        Try
            If (fun_guardarSp("sp_agregarDetOrdenAutomotiveTmp", intGl_idConfigPc & "," & v_idStock, Me.Name)) = 0 Then
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
        '-- ingresar la ensambladora
        If txtIdEnsambladora.Text = 0 Then
            MessageBox.Show("Debe ingresar la ensambladora...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            btnBuscarEnsambladora.Focus()
            Exit Sub
        End If
        '-- ingresar la cantidad de lata
        If txtCantidadLata.Text <= 0 Then
            MessageBox.Show("Debe ingresar una cantidad válida de lata...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtCantidadLata.Focus()
            Exit Sub
        End If
        '-- ingresar el año
        If txtAnho.Text <= 0 Then
            MessageBox.Show("Debe ingresar el año...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtAnho.Focus()
            Exit Sub
        End If
        '-- total de litros
        If txtTotalLitro.Text <= 0 Then
            MessageBox.Show("Debe ingresar el total de litro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtAnho.Focus()
            Exit Sub
        End If
        '-- total 
        If txtTotal.Text <= 0 Then
            MessageBox.Show("El total no es válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtAnho.Focus()
            Exit Sub
        End If

    End Sub

    Public Sub sumarTotal()
        Dim douTmpTotal As Double
        Dim douTmpTotalGramo As Double

        If sp_datosTabla.consulta_valor("select idConfig from detOrdenAutomotiveTmp where idConfig=" & intGl_idConfigPc) > 0 Then
            douTmpTotal = sp_datosTabla.consulta_valorDouble("select round(sum(precio*cantidad),-3) from detOrdenAutomotiveTmp where idConfig=" & intGl_idConfigPc)
            douTmpTotalGramo = sp_datosTabla.consulta_valorDouble("select sum(cantidad) from detOrdenAutomotiveTmp where idConfig=" & intGl_idConfigPc)

            If douTmpTotal > 0 Then
                txtTotal.Text = douTmpTotal
                txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,##0")
                txtTotalGramo.Text = douTmpTotalGramo
                txtTotalGramo.Text = Format(CDec(txtTotalGramo.Text), "###,###,##0")
            Else
                txtTotal.Text = 0
                txtTotalGramo.Text = 0
            End If
        Else
            txtTotal.Text = 0
        End If
    End Sub

    Private Sub guardarOrden()
        Dim tmpDouPorce As Double = 0
        Try
            tmpDouPorce = sp_datosTabla.consulta_valorDouble("select porcentaje from descuentoAuto where idDescuentoAuto=" & cboDescuento.SelectedValue)

            If (fun_guardarSp("sp_guardarAutomotive", intGl_idConfigPc & "," & cboLinea.SelectedValue & "," & cboCalidad.SelectedValue & ",'" & txtCodigo.Text & "'," & _
                              sacarComa(txtCantidadLata.Text) & ",'" & txtRegion.Text & "','" & Trim(txtNombreColor.Text) & "','" & txtAlternativa.Text & "'," & _
                              txtIdEnsambladora.Text & "," & sacarComa(txtAnho.Text) & "," & sacarComa(txtTotalGramo.Text) & "," & sacarComa(txtTotalLitro.Text) & "," & _
                              sacarComa(txtTotal.Text) & "," & tmpDouPorce & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
        txtCodigo.Focus()
    End Sub

    Private Sub btnBuscarEnsambladora_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarEnsambladora.Click
        banGl_ordenAutomotive = True

        Me.Enabled = False
        frmBuscarMarcaProducto.txtBuscar.Text = ""
        frmBuscarMarcaProducto.txtId.Text = "0"
        frmBuscarMarcaProducto.Visible = True
        frmBuscarMarcaProducto.WindowState = FormWindowState.Normal
        frmBuscarMarcaProducto.Show()

        frmStockBasico.txtBuscar.Focus()
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        banGl_ordenAutomotive = True

        Me.Enabled = False
        frmStockBasico.txtBuscar.Text = ""
        frmStockBasico.txtIdProducto.Text = "0"
        frmStockBasico.Visible = True
        frmStockBasico.WindowState = FormWindowState.Normal
        frmStockBasico.Show()
        frmStockBasico.listar_busqueda("")

        frmStockBasico.txtBuscar.Focus()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from detOrdenAutomotiveTmp where idConfig=" & intGl_idConfigPc & " and nro=" & intNro)
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
                txtNombreColor.Focus()
            Else
                '-- buscar el color
                Me.Enabled = False

                banGl_ordenAutomotive = True
                frmBuscarColorInmo.Show()
                frmBuscarColorInmo.BringToFront()
                frmBuscarColorInmo.txtBuscar.Focus()
            End If

        End If
    End Sub

    Private Sub txtNombreColor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreColor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cboLinea.Focus()
        End If
    End Sub

    Private Sub txtAlternativa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlternativa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscarEnsambladora.Focus()
        End If
    End Sub

    Private Sub txtAnho_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnho.KeyPress
        e.Handled = txtNumerico(txtAnho, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtAnho.Text = Format(CDec(txtAnho.Text), "##,##0")
            txtRegion.Focus()
        End If
    End Sub

    Private Sub txtRegion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtValueShade.Focus()
        End If
    End Sub

    Private Sub txtValueShade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValueShade.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAgregar.Focus()
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
    Private Sub cboLinea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLinea.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cboCalidad.Focus()
        End If
    End Sub

    Private Sub cboCalidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCalidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtAlternativa.Focus()
        End If
    End Sub

    Private Sub cboDescuento_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboDescuento.SelectedIndexChanged
        Dim tmpDouDescuento As Double = 0
        If sacarComa(txtTotal.Text) > 0 Then
            'sumarTotal()

            tmpDouDescuento = sp_datosTabla.consulta_valorDouble("select porcentaje from descuentoAuto where idDescuentoAuto=" & cboDescuento.SelectedValue)
            txtTotal.Text = sacarComa(txtTotal.Text) - sacarComa(txtTotal.Text) * (tmpDouDescuento / 100)
            txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,##0")
            txtTotalDescuento.Text = sacarComa(txtTotal.Text) * (tmpDouDescuento / 100)
            txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,##0")
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

            strComponentes = item.SubItems(1).Text
            douGramo = CDbl(item.SubItems(2).Text)
            douPrecio = CDbl(item.SubItems(4).Text)
        Next
    End Sub

    Private Sub lvOrden_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOrden.GotFocus
        For Each item As ListViewItem In lvOrden.SelectedItems
            '-- nro
            intNro = CInt(item.SubItems(0).Text)

            strComponentes = item.SubItems(1).Text
            douGramo = CDbl(item.SubItems(2).Text)
            douPrecio = CDbl(item.SubItems(4).Text)
        Next
    End Sub

    Private Sub lvOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvOrden.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If intNro > 0 Then

                Me.Enabled = False
                '-- colocar los datos del registro
                frmCantidadAutomotive.txtNro.Text = intNro
                frmCantidadAutomotive.txtIdStock.Text = sp_datosTabla.consulta_valor("select idStock from detOrdenAutomotiveTmp where idConfig=" & intGl_idConfigPc & " and nro=" & intNro)
                frmCantidadAutomotive.txtCodigo.Text = ""
                frmCantidadAutomotive.txtMercaderia.Text = strComponentes
                frmCantidadAutomotive.txtPrecio.Text = douPrecio
                frmCantidadAutomotive.txtPrecio.Text = Format(CDec(frmCantidadAutomotive.txtPrecio.Text), "###,##0.##")
                frmCantidadAutomotive.txtGramo.Text = douGramo
                frmCantidadAutomotive.txtGramo.Text = Format(CDec(frmCantidadAutomotive.txtGramo.Text), "###,##0.##")

                frmCantidadAutomotive.Show()
                frmCantidadAutomotive.BringToFront()
                frmCantidadAutomotive.txtGramo.Focus()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTOM --'
    '****************'
    Private Sub rdDosLitros_Click(sender As Object, e As System.EventArgs) Handles rdDosLitros.Click
        If rdDosLitros.Checked = True Then
            txtTotalLitro.Text = 2
            txtTotalLitro.ReadOnly = True
        End If
    End Sub

    Private Sub rdMedioLitro_Click(sender As Object, e As System.EventArgs) Handles rdMedioLitro.Click
        If rdMedioLitro.Checked = True Then
            txtTotalLitro.Text = 0.5
            txtTotalLitro.ReadOnly = True
        End If
    End Sub

    Private Sub rdOtro_Click(sender As Object, e As System.EventArgs) Handles rdOtro.Click
        If rdOtro.Checked = True Then
            txtTotalLitro.ReadOnly = False
            txtTotalLitro.Text = 0
            txtTotalLitro.Focus()
        End If
    End Sub

    Private Sub rdTresLitros_Click(sender As Object, e As System.EventArgs) Handles rdTresLitros.Click
        If rdTresLitros.Checked = True Then
            txtTotalLitro.Text = 3.6
            txtTotalLitro.ReadOnly = True
        End If
    End Sub

    Private Sub rdUnLitro_Click(sender As Object, e As System.EventArgs) Handles rdUnLitro.Click
        If rdUnLitro.Checked = True Then
            txtTotalLitro.Text = 1
            txtTotalLitro.ReadOnly = True
        End If
    End Sub
    '----------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmOrdenPreparadoAutomotive_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteOrdenPreparadoAutomotive.Enabled = True
        e.Cancel = False
    End Sub

End Class