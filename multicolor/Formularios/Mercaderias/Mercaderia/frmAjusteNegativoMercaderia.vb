Public Class frmAjusteNegativoMercaderia
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim motivoAjuste As New motivoAjuste

    Dim intIdLoteTmp As Integer
    Dim intIdStockTmp As Integer
    Dim intIdDeposito As Integer
    Dim douTmpPorceimp As Double
    Dim intTmpIdImpuesto As Integer
    Dim bolTmpError As Boolean

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        '-- procedimiento para establecer la sucursal en la que se opera actualmente
        txtIdSucursal.Text = sp_datosTabla.un_dato_integer("idSucursal", "configPc", "idConfig", intGl_idConfigPc)
        txtSucursal.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_sucursal", "idSucursal", CInt(txtIdSucursal.Text))
        '-- habilitar los datos del combo
        motivoAjuste.comboMotivoAjuste(cboMotivo)
        'cboMotivo.SelectedValue = sp_datosTabla.un_dato_integer("idMotivo", "motivoAu", "codigo", intTmpCodigo)
    End Sub

    Public Sub buscarCodigoProducto(ByVal v_codigoIngresado As String)
        Try
            '-- varibles
            Dim intTmpIdProducto As Integer
            Dim intTmpidSucursal As Integer
            Dim strTmpCodigoBarra As String
            '-- activar la varibale global de este modulo
            banGl_ajusteNegativoMercaderia = True

            If Len(v_codigoIngresado) = 6 Then
                '-- por codigo del producto
                intTmpIdProducto = CInt(sp_datosTabla.un_datoString("idProducto", "v_producto", "codigo", v_codigoIngresado))
            End If
            If Len(v_codigoIngresado) > 6 Then
                '-- por codigo de barras
                strTmpCodigoBarra = sp_datosTabla.un_datoString("codigoBarra", "v_producto", "codigoBarra", v_codigoIngresado)
                If Len(strTmpCodigoBarra) = 0 Then
                    '-- por codigo de barras generado
                    '-- solo si tiene como primer digito el 1
                    If v_codigoIngresado.Substring(0, 1) = 1 Then
                        If Len(v_codigoIngresado) = 12 Then
                            '-- para los de 12 digitos
                            intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(6, 5))
                        End If
                        If Len(v_codigoIngresado) = 13 Then
                            '-- para los de 13 digitos
                            intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(7, 5))
                        End If
                    End If
                Else
                    'banGl_ajusteNegativoMercaderia = True
                    ' MsgBox("Valor del codigo de barra  " & strTmpCodigoBarra)
                    'MsgBox("Valor de la consulta  " & (sp_datosTabla.un_datoString("idProducto", "producto", "codigoBarra", strTmpCodigoBarra)))

                    '-- se encontró el codigo de barras de la mercaderia
                    intTmpIdProducto = CInt(sp_datosTabla.un_datoString("idProducto", "producto", "codigoBarra", strTmpCodigoBarra))
                End If
            End If
            '-- comparar si existe el codigo ingresado
            If intTmpIdProducto = 0 Then
                MessageBox.Show("No se encuentra el Codigo Ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- colocar los datos de la mercaderia
            lblIdProductoPedido.Text = intTmpIdProducto
            lblCodigoProducto.Text = sp_datosTabla.un_datoString("codigo", "v_producto", "idProducto", Str(intTmpIdProducto))
            lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", Str(intTmpIdProducto))) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", Str(intTmpIdProducto)))
            Dim intTmpIdLaboratorio As Integer
            intTmpIdLaboratorio = sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", intTmpIdProducto)
            txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", Str(intTmpIdLaboratorio))
            Dim intTmpidTipoProducto As Integer
            intTmpidTipoProducto = sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", intTmpIdProducto)
            txtTipoProducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", Str(intTmpIdProducto))
            txtOrigen.Text = sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", Str(intTmpIdProducto))
            '-- variable de idsucursal con respecto al deposito seleccionado
            intTmpidSucursal = sp_datosTabla.un_dato_integer("idSucursal", "deposito", "idDeposito", lblIdDeposito.Text)
            '-- la imagen de la mercaderia
            PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
            '---------------------------------'
            '-- controlar si es fraccionado --'
            '---------------------------------'
            '-- la variable publica de idproducto
            intGl_ajusteNegativoIdProducto = intTmpIdProducto

            If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
                ' MsgBox("Es un Producto Fraccionado..!")
                '--- producto fraccionado
                Me.Enabled = False
                frmFraccionado.listar_busqueda(intTmpIdProducto)
                frmFraccionado.Visible = True
                frmFraccionado.WindowState = FormWindowState.Normal
                frmFraccionado.Show()
                frmFraccionado.BringToFront()
            Else
                ' MsgBox("No es un Producto Fraccionado..!")
                '---------------------'
                '-- producto entero --'
                '---------------------'
                '-- datos de la fraccion
                txtFraccion.Text = "ENTERO"
                lblCantidad.Text = 1
                lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", intTmpIdProducto)
                '----------------------------------
                '-- controlar si tiene varios lotes
                '----------------------------------
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & lblIdDeposito.Text, 0) > 0 Then
                    '-- para un lote
                    lblCantidad.Text = 1
                    '-- para un lote
                    intIdLoteTmp = sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & lblIdDeposito.Text, 0)
                    '-- los datos
                    '-- traer el idstock
                    lblIdStock.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intIdLoteTmp & " and idDeposito=" & lblIdDeposito.Text)
                    '-- traer el stock
                    txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intIdLoteTmp & " and idDeposito=" & lblIdDeposito.Text))
                    txtStock.Text = Format(CDbl(txtStock.Text), "##,##0.##")
                    '-- traer 
                    txtLote.Text = sp_datosTabla.un_datoString("lote", "lote", "idLote", intIdLoteTmp)
                    maskVence.Text = sp_datosTabla.un_datoString("vencimiento", "lote", "idLote", intIdLoteTmp)
                    '-- el precio del producto
                    lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", intTmpIdProducto)
                    btnAgregar.Enabled = True
                    'txtCantidad.Focus()

                End If
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & lblIdDeposito.Text, 1) = 99 Then
                    '-- para mas de un lote
                    Me.Enabled = False

                    banGl_ajusteNegativoMercaderia = True
                    intGl_ajusteNegativoIdProducto = intTmpIdProducto

                    frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", intTmpIdProducto)
                    frmLote.listar_busquedaTodosLotes(intTmpIdProducto, intGl_ajusteNegativoIdDeposito)
                    frmLote.Visible = True
                    frmLote.WindowState = FormWindowState.Normal
                    frmLote.Show()
                    frmLote.BringToFront()
                End If
                '-- no tiene stock
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & lblIdDeposito.Text, 1) = 0 Then
                    MessageBox.Show("Esta Mercadería no cuenta con Stock alguno..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    lblIdStock.Text = 0
                    txtLote.Text = ""
                    maskVence.Text = ""
                    btnAgregar.Enabled = False
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub inicializaObjeto()
        lblNombreProducto.Text = ""
        lblCantidad.Text = 0
        lblCodigoProducto.Text = 0
        lblPrecio.Text = 0
        lblIdStock.Text = 0
        lblIdProductoPedido.Text = 0
        txtLaboratorio.Text = ""
        txtTipoProducto.Text = ""
        txtOrigen.Text = ""
        txtCantidad.Text = 0
        txtStock.Text = 0
        txtProducto.Text = ""
        maskVence.Text = ""
        txtLote.Text = ""
        PictureBox1.ImageLocation = ""
        txtProducto.Enabled = False
        txtProducto.BackColor = Color.PaleGreen
        txtCantidad.Enabled = False
        txtCantidad.BackColor = Color.PaleGreen
    End Sub

    Private Sub limpiarObjetos()
        lblNombreProducto.Text = ""
        lblCantidad.Text = 0
        lblCodigoProducto.Text = 0
        lblPrecio.Text = 0
        lblIdStock.Text = 0
        lblIdProductoPedido.Text = 0
        txtLaboratorio.Text = ""
        txtTipoProducto.Text = ""
        txtOrigen.Text = ""
        txtCantidad.Text = 0
        txtStock.Text = 0
        txtProducto.Text = ""
        maskVence.Text = ""
        txtLote.Text = ""
        cboMotivo.Enabled = False
        txtExplica.Text = ""
        txtExplica.ReadOnly = True
        txtExplica.BackColor = Color.PaleGreen
        PictureBox1.ImageLocation = ""
        txtProducto.Enabled = False
        txtProducto.BackColor = Color.PaleGreen
        txtCantidad.Enabled = False
        txtCantidad.BackColor = Color.PaleGreen
    End Sub

    Private Sub controlarGuardar()
        Me.Enabled = False

        Try
            '-- controlar que se ingrese algun item
            '-- si no existen item cargados
            Dim intTmpValorRegistros As Integer = 0
            For i As Integer = 0 To dtgAjuste.Rows.Count - 1
                If dtgAjuste.Rows(i).Cells(0).Value > 0 Then
                    intTmpValorRegistros = intTmpValorRegistros + 1
                End If
            Next
            If intTmpValorRegistros = 0 Then
                MessageBox.Show("No existem items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bolTmpError = True
                Exit Sub
            End If
            '-- eliminar todos los registros de la tabla temporal de eta sucursal y maquina
            sp_datosTabla.consulta_valor("delete from detAjusteneTmp where idConfig=" & intGl_idConfigPc)
            '-- declarar las variables para realizar la actualizacion de la tabla temporal
            Dim intTmpIdStock As Integer
            Dim intTmpIdForma As Integer
            Dim intTmpIdMotivo As Integer
            Dim douTmpCantidad As Double
            Dim intTmpCantfrac As Integer
            Dim douTmpStock As Double
            Dim douTmpPrecio As Double
            Dim douTmpCosto As Double
            '-- cargar en el detalle de la tabla temporal
            For i As Integer = 0 To dtgAjuste.Rows.Count - 1
                If dtgAjuste.Rows(i).Cells(0).Value > 0 Then
                    intTmpIdStock = CInt(dtgAjuste.Rows(i).Cells(10).Value)
                    'MsgBox("Valor   " & sp_datosTabla.un_datoString("idForma", "cabForma", "nombreForma", dtgRemision.Rows(i).Cells(3).Value))
                    intTmpIdForma = sp_datosTabla.un_datoString("idForma", "cabForma", "nombreForma", dtgAjuste.Rows(i).Cells(3).Value)
                    intTmpIdMotivo = sp_datosTabla.un_datoString("idMotivo", "motivoAjuste", "nombreMotivo", dtgAjuste.Rows(i).Cells(6).Value)
                    douTmpCantidad = CDec(dtgAjuste.Rows(i).Cells(8).Value)
                    intTmpCantfrac = CInt(dtgAjuste.Rows(i).Cells(11).Value)
                    douTmpStock = CDec(dtgAjuste.Rows(i).Cells(7).Value)
                    '-- sacar el costo del producto
                    douTmpCosto = (sp_datosTabla.un_dato_double("costo", "stock", "idStock", intTmpIdStock)) * intTmpCantfrac
                    douTmpPrecio = CDec(dtgAjuste.Rows(i).Cells(12).Value)
                    sp_datosTabla.sp_string("sp_agregarDetAjusteneTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdStock & "," & intTmpIdMotivo & "," & intTmpIdForma & "," & douTmpCantidad & "," & intTmpCantfrac & "," & douTmpStock & "," & douTmpPrecio & "," & douTmpCosto)
                    ' MsgBox("Realizó el procedimiento..!")
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
        Me.Enabled = True

    End Sub

    Private Sub guardarAjuste()
        Me.Enabled = False

        Try
            '-- el id de la persona juridica
            Dim tmpIntIdPersonaJur As Integer
            tmpIntIdPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
            If (fun_guardarSp("sp_guardarAjusteNegativo", intGl_idSucursal & "," & intGl_idConfigPc & "," & tmpIntIdPersonaJur & "," & intGl_idUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.Enabled = False
                '-- se guardo los registros
                MessageBox.Show("Se guardo los registros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Enabled = True
                limpiarObjetos()
                btnAgregar.Enabled = False
                btnCancelar.Enabled = False
                btnEliminar.Enabled = False
                btnGuardar.Enabled = False
                btnNuevo.Enabled = True
                txtSucursal.Text = ""
                txtIdSucursal.Text = 0
                '-- limpiar la grilla
                dtgAjuste.Rows.Clear()
                intGl_nroAjusteNegativoMercaderia = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        '-- activar la variable del modulo
        banGl_ajusteNegativoMercaderia = True
        frmBuscarDepositoMercaderia.txtBuscar.Text = ""
        frmBuscarDepositoMercaderia.txtIdDeposito.Text = 0
        frmBuscarDepositoMercaderia.txtNombreDeposito.Text = ""
        frmBuscarDepositoMercaderia.txtNombreSucursal.Text = ""
        Me.Enabled = False
        frmBuscarDepositoMercaderia.Visible = True
        frmBuscarDepositoMercaderia.Show()
        frmBuscarDepositoMercaderia.BringToFront()
        frmBuscarDepositoMercaderia.txtBuscar.Focus()
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        '-- controlar si se ingresó el producto
        If Len(lblNombreProducto.Text) = 0 Then
            MessageBox.Show("Debe ingresar el Nombre de la Mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- controlar si se ingresó la cantidad
        If Len(txtCantidad.Text) = 0 Then
            MessageBox.Show("Debe ingresar la cantidad a ingresar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            '--- solo si la cantidad es positiva
            If CDec(txtCantidad.Text) <= 0 Then
                MessageBox.Show("Debe ingresar una cantidad válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        '-- si no tiene stock
        If Len(lblIdStock.Text) = 0 Then
            MessageBox.Show("Esta mercadería no tiene un stock inicial..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- si ya está cargado el mismo producto
        For i As Integer = 0 To dtgAjuste.Rows.Count - 1
            If dtgAjuste.Rows(i).Cells(0).Value > 0 Then
                If lblIdStock.Text = CInt(dtgAjuste.Rows(i).Cells(10).Value) Then
                    MessageBox.Show("Esta mercadería ya está cargada..!. Elimine lo cargado y vuelva a intentarlo", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        Next
        '- sumar la varibale global
        intGl_nroAjusteNegativoMercaderia = intGl_nroAjusteNegativoMercaderia + 1
        '-- el id del Impuesto
        intTmpIdImpuesto = sp_datosTabla.un_dato_integer("idImpuesto", "producto", "idProducto", lblIdProductoPedido.Text)
        '-- el porcentaje del impuesto
        douTmpPorceimp = sp_datosTabla.un_dato_double("porcentajeImpuesto", "impuesto", "idImpuesto", intTmpIdImpuesto)
        '-- traer el stock de la mercaderia
        Dim douTmpStock As Double
        douTmpStock = CDbl(sacarComa(txtStock.Text))
        '-- traer el motivo del ajuste
        Dim intTmpIdAjuste As Integer
        intTmpIdAjuste = cboMotivo.SelectedValue
        Dim strTmpMotivoAjuste As String
        strTmpMotivoAjuste = sp_datosTabla.un_datoString("nombreMotivo", "motivoAjuste", "idMotivo", Str(intTmpIdAjuste))
        '-- procedimiento que carga la grilla
        cargarAjusteNegativoMercaderia(intGl_nroAjusteNegativoMercaderia, lblCodigoProducto.Text, Trim(lblNombreProducto.Text), txtFraccion.Text, txtLote.Text, maskVence.Text.ToString, CDec(lblPrecio.Text), douTmpStock, txtCantidad.Text, lblIdStock.Text, lblCantidad.Text, strTmpMotivoAjuste)
        'limpiarObjetos()
        inicializaObjeto()
        txtProducto.Enabled = True
        txtProducto.BackColor = Color.White
        txtCantidad.Enabled = True
        txtCantidad.BackColor = Color.White
        txtProducto.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiarObjetos()
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        '-- reiniciar la variable global
        intGl_nroAjusteNegativoMercaderia = 0
        '-- limpiar la grilla
        dtgAjuste.Rows.Clear()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgAjuste.SelectedCells.Count > 0 Then
                '---------------------------------------------------------
                dtgAjuste.Rows.Remove(dtgAjuste.CurrentRow)
                '-- restar la variable publica de nro de item
                intGl_nroAjusteNegativoMercaderia = intGl_nroAjusteNegativoMercaderia - 1
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolTmpError = False
        controlarGuardar()
        If MessageBox.Show("Desea Guardar el Ajuste Negativo de Mercaderias..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarAjuste()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            '-- si es por codigo del producto
            If txtProducto.Text = "" Then
                '-- la variable publica
                banGl_ajusteNegativoMercaderia = True
                '-- si es espacio en blanco desplegar la lista de productos de los pedidos
                Me.Enabled = False
                '-- el procedimiento del formulario
                frmBuscarProductoAjuste.txtBuscar.Text = ""
                frmBuscarProductoAjuste.txtIdProducto.Text = 0
                frmBuscarProductoAjuste.Visible = True
                frmBuscarProductoAjuste.Show()
                frmBuscarProductoAjuste.BringToFront()
                frmBuscarProductoAjuste.txtBuscar.Focus()
            Else
                '-- si la busqueda es por codigo
                buscarCodigoProducto(txtProducto.Text)
            End If
            'txtCantidad.Focus()
            'Me.Refresh()
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCantidad_Validated(sender As Object, e As System.EventArgs) Handles txtCantidad.Validated
        If Not IsNumeric(txtCantidad.Text) Then
            MessageBox.Show("Debe ingresar un numero válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Text = 0
            Exit Sub
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------
    '************'
    '-- COMBOS --'
    '************'
    Private Sub cboMotivo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    Private Sub dtgAjuste_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgAjuste.RowEnter
        Dim row As DataGridViewRow = dtgAjuste.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
        '- asignar el id de producto al objeto
        lblIdStockTmp.Text = CInt(row.Cells(10).Value)
    End Sub
    '-- el formato de las celdas
    Private Sub dtgAjuste_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgAjuste.CellFormatting
        '-- formato de la columna de cantidad ingresada
        If dtgAjuste.Columns(e.ColumnIndex).Name.Equals("Column11") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("###,###.##")
        End If
        '-- formato para la columna de precio
        If dtgAjuste.Columns(e.ColumnIndex).Name.Equals("Column12") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##,###,###")
        End If
        '-- formato para la columna del stock
        If dtgAjuste.Columns(e.ColumnIndex).Name.Equals("Column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("###,###.##")
        End If
        '-- formato para la columna del stock final
        If dtgAjuste.Columns(e.ColumnIndex).Name.Equals("Column5") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##,###.###")
            e.CellStyle.BackColor = Color.LightYellow
            'e.CellStyle.Font.Size
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAjusteNegativoMercaderia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_ajusteNegativoMercaderia = False
        frmMenuPrincipal.mercaderiaMercaderiasAjustesNegativo.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------

End Class