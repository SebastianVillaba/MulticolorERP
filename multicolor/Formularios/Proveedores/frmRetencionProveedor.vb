Public Class frmRetencionProveedor
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdProveedor As Integer

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub habilitarObjetos()
        '-- los botones
        btnAgregar.Enabled = True
        btnCancelar.Enabled = True
        btnCargar.Enabled = True
        btnEliminar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        '-- txt
        txtPorcentaje.ReadOnly = False
        txtPorcentaje.BackColor = Color.White
        txtPorcentaje.Text = 0

    End Sub

    Private Sub desHabilitarObjetos()
        '-- los botones
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnCargar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        '-- txt
        txtPorcentaje.ReadOnly = True
        txtPorcentaje.BackColor = Color.LightSkyBlue
        txtPorcentaje.Text = 0

    End Sub

    Private Sub limpiar()
        txtDcaja.Text = ""
        txtDsuc.Text = ""
        txtFactura.Text = ""
        txtFechaFactura.Text = ""
        txtTimbrado.Text = 0
        txtFechaHora.Text = ""
        txtIdCompra.Text = 0
        txtIva10.Text = 0
        txtIva5.Text = 0
        txtProveedor.Text = ""
        txtRuc.Text = ""
        txtTotalFactura.Text = 0
        txtTotalIva.Text = 0
        lblEmpresaContable.Text = ""
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnEliminar.Enabled = False
        btnNuevo.Enabled = True
        '-- limpiar la tabla temporal de la base de datos
        sp_datosTabla.consulta_valor("delete detRetencionProveedorTmp where idConfig=" & intGl_idConfigPc)
        '-- limpiar la grilla
        listarRetencion()

        '-- la cabecera de la nota de credito
        txtDsucN.Enabled = True
        txtDsucN.BackColor = Color.White
        txtDsucN.Text = ""
        txtDcajaN.Enabled = True
        txtDcajaN.BackColor = Color.White
        txtDcajaN.Text = ""
        txtFacturaN.Enabled = True
        txtFacturaN.BackColor = Color.White
        txtFacturaN.Text = ""
        txtIva10.Text = 0
        txtIva5.Text = 0
        txtTotalIva.Text = 0
        txtTotalRetencion.Text = 0
        '-- datos de la mercaderia a agregar
        txtPorcentaje.Text = 0
        lblIdCompra.Text = 0
        btnCargar.Enabled = False

        desHabilitarObjetos()
    End Sub

    Private Sub listarRetencion()
        systemClass.SqlToLv_detalleRetencionProveedor(lvRetencion, "sp_consultaDetRetencionProveedorTmp", intGl_idConfigPc)
    End Sub

    Public Sub actualizarCabeceraVenta(ByVal v_idCompra As Integer)
        '-- el idcompra
        txtIdCompra.Text = v_idCompra
        '-- el cliente
        txtProveedor.Text = sp_datosTabla.consulta_valorString("select _vp.nombre from cabCompra cc inner join v_proveedor _vp on cc.idCompra=_vc.idProveedor " & _
                                                               " where cc.idCompra=" & v_idCompra)
        '-- el ruc del proveedor
        txtRuc.Text = sp_datosTabla.consulta_valorString("select _vp.ruc from cabCompra cc inner join v_proveedor _vp on cc.idCompra=_vc.idProveedor " & _
                                                               " where cc.idCompra=" & v_idCompra)
        '-- dsuc
        txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabCompra", "idCompra", v_idCompra)
        '-- dcaja
        txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabCompra", "idCompra", v_idCompra)
        '-- factura
        txtFactura.Text = sp_datosTabla.consulta_valorString("select factura from cabCompra where idCompra=" & v_idCompra)
        '-- fecha de la factura
        txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabCompra", "idCompra", v_idCompra)
        '-- fecha hora de carga
        txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabCompra", "idCompra", v_idCompra)
        '-- total compra
        txtTotalFactura.Text = sp_datosTabla.un_dato_double("total", "cabCompra", "idCompra", v_idCompra)
        txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
        '-- la moneda
        '-- tipo de venta
        lblTipoCompra.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoCompra", "idTipoCompra", sp_datosTabla.un_dato_integer("idTipoCompra", "cabCompra", "idCompra", v_idCompra))
        '-- el nombre de la empresa contable
        lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabCompra", "idCompra", v_idCompra))

    End Sub

    Private Sub sumarTotal()
        '-- variables para los totales
        '-- asignar los totales
        txtTotalRetencion.Text = sp_datosTabla.consulta_valorDouble("select sum(subtotal) from detRetencionProveedorTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtTotalRetencion.Text = Format(CDec(txtTotalRetencion.Text), "#,###,###.##")
        txtIva10.Text = sp_datosTabla.consulta_valorDouble("select sum(iva10) from detRetencionProveedorTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIva10.Text = Format(CDec(txtIva10.Text), "#,###,###.00")
        txtIva5.Text = sp_datosTabla.consulta_valorDouble("select sum(iva5) from detRetencionProveedorTmp where idConfig=" & intGl_idConfigPc & " group by idConfig")
        txtIva5.Text = Format(CDec(txtIva5.Text), "#,###,###.00")
        txtTotalIva.Text = sp_datosTabla.consulta_valorDouble("select sum(iva5+iva10) from detRetencionProveedorTmp where idConfig=" & intGl_idConfigPc & _
                                                              " group by idConfig")
        txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "#,###,###.00")
    End Sub

    Private Sub cargarRetencion()
        intIdProveedor = sp_datosTabla.consulta_valor("select idProveedor from cabCompra where idCompra=" & txtIdCompra.Text)

        If (fun_guardarSp("sp_agregarDetRetencionProveedorTmp", intGl_idConfigPc & "," & txtIdCompra.Text & "," & CDbl(sacarComa(txtPorcentaje.Text)), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar el Registro en el detalle de la Retención...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            listarRetencion()
            'limpiarVenta()
            btnAgregar.Focus()
        End If
    End Sub

    Private Sub limpiarVenta()
        '-- txt de venta
        txtIdCompra.Text = 0
        txtProveedor.Text = ""
        txtRuc.Text = ""
        txtDsuc.Text = ""
        txtDcaja.Text = ""
        txtFactura.Text = ""
        txtFechaFactura.Text = ""
        txtFechaHora.Text = ""
        txtTotalFactura.Text = 0
        '-- lbl
        lblTipoCompra.Text = ""

    End Sub

    Private Sub guardarRetencionVenta()
        If (fun_guardarSp("sp_guardarRetencionProveedor", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idPersonaJur & "," & intIdProveedor & "," & txtTimbrado.Text & _
             "," & "'" & txtDsucN.Text & "'" & "," & "'" & txtDcajaN.Text & "'" & "," & "'" & txtFacturaN.Text & "'" & "," & "'" & dtpDesdeFecha.Text & "'" & _
             "," & CDbl(sacarComa(txtTotalRetencion.Text)) & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar el Registro en el detalle de la Retención...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        habilitarObjetos()
        btnAgregar.Focus()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblIdCompra.Text <> "" Then
            '-- eliminar el registro de la tabla temporal
            sp_datosTabla.consulta_valor("delete from detRetencionVentaTmp where idVenta=" & lblIdCompra.Text & " and idConfig=" & intGl_idConfigPc)
            listarRetencion()
            '-- volver a sumar los totales
            sumarTotal()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar la Retención de la venta..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarRetencionVenta()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        desHabilitarObjetos()
        limpiar()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        banGl_retencionProveedor = True

        Me.Enabled = False
        frmBuscarFacturaCompra.Visible = True
        frmBuscarFacturaCompra.WindowState = FormWindowState.Normal
        frmBuscarFacturaCompra.Show()
        frmBuscarFacturaCompra.txtBuscar.Focus()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        '-- cargr la retencion
        cargarRetencion()
        sumarTotal()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtPorcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        e.Handled = txtNumerico(txtPorcentaje, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtPorcentaje.Text) = 0 Then
                txtPorcentaje.Text = 30
            End If
            e.Handled = True
            txtPorcentaje.Text = Format(CDec(txtPorcentaje.Text), "###.##")

            btnCargar.Focus()
        End If
    End Sub

    Private Sub txtTmbrado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        e.Handled = txtNumerico(txtTimbrado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtTimbrado.Text) = 0 Then
                txtTimbrado.Text = 0
            End If
            txtDsucN.Focus()
        End If
    End Sub

    Private Sub txtDsucN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsucN.KeyPress
        e.Handled = txtNumerico(txtDsucN, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDcajaN.Focus()
        End If
    End Sub

    Private Sub txtDcajaN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcajaN.KeyPress
        e.Handled = txtNumerico(txtDcajaN, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtFacturaN.Focus()
        End If
    End Sub

    Private Sub txtFacturaN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFacturaN.KeyPress
        e.Handled = txtNumerico(txtFacturaN, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            dtpDesdeFecha.Focus()
        End If
    End Sub

    Private Sub dtpDesdeFeja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpDesdeFecha.KeyPress
        e.Handled = txtNumerico(txtFacturaN, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGuardar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmRetencionProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_notacreditoCompra = 0
        frmMenuPrincipal.proveedorRetencion.Enabled = True
        e.Cancel = False
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
End Class