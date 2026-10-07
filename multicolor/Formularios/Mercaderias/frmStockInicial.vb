Public Class frmStockInicial
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim bolTmpError As Boolean
    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        'inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializaObjeto()
        '-- lbl
        lblNombreProducto.Text = ""
        lblCantidad.Text = 0
        lblCodigoProducto.Text = 0
        lblPrecio.Text = 0
        '-- txt
        txtLaboratorio.Text = ""
        txtDivision.Text = ""
        txtTipoProducto.Text = ""
        txtOrigen.Text = ""
        txtCantidad.Text = 0
        txtProducto.Text = ""
        txtCosto.Text = 0
        txtLote.Text = ""
        '-- mask
        maskVence.Text = ""
        '-- pic
        PictureBox1.ImageLocation = ""
    End Sub

    Private Sub limpiarObjetos()
        '-- datos de la sucursal
        txtIdDeposito.Text = 0
        lblDeposito.Text = ""
        '-- datos del ingreso
        '- txt
        txtProducto.Text = ""
        txtProducto.Enabled = False
        txtProducto.BackColor = Color.LightBlue
        txtCantidad.Text = 0
        txtCantidad.Enabled = False
        txtCantidad.BackColor = Color.LightBlue
        txtCosto.Text = 0
        txtCosto.Enabled = False
        txtCosto.BackColor = Color.LightBlue
        txtFraccion.Text = ""
        txtFraccion.Enabled = False
        txtFraccion.BackColor = Color.LightBlue
        txtLote.Text = ""
        txtLote.Enabled = False
        txtLote.BackColor = Color.LightBlue
        '- mask
        maskVence.Text = ""
        maskVence.Enabled = False
        maskVence.BackColor = Color.LightBlue
        '- lbl
        lblCodigoProducto.Text = 0
        lblNombreProducto.Text = ""
        lblCosto.Text = 0
        lblPrecio.Text = 0
        lblCantidad.Text = 0
        lblIdDeposito.Text = 0

        '-- datos del producto
        txtLaboratorio.Text = ""
        txtDivision.Text = ""
        txtTipoProducto.Text = ""
        txtOrigen.Text = ""

        '-- botones
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True

        '-- limpiar la grilla
        dtgStock.Rows.Clear()

    End Sub

    Private Sub controlarCargaProducto()
        Dim intTmpIdProducto As Integer
        Dim intTmpIdDeposito As Integer
        Dim intTmpIdLote As Integer

        Dim strTmpFechaVence As String

        Dim douTmpPrecio As Double
        Dim douTmpCosto As Double
        Dim douTmpCantidad As Double

        '-- si se ingreso el producto
        If lblCodigoProducto.Text = "" Then
            MessageBox.Show("No se ingresó ningún Producto...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProducto.Text = ""
            txtProducto.Focus()
            Exit Sub
        End If
        '-- si se ingresó una cantidad válida
        If IsNumeric(txtCantidad.Text) Then
            If txtCantidad.Text <= 0 Then
                MessageBox.Show("La cantidad ingresada no es válida...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCantidad.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("La cantidad ingresada no es válida...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Exit Sub
        End If

        '-- si no tiene precio
        If IsNumeric(lblPrecio.Text) Then
            If lblPrecio.Text <= 0 Then
                MessageBox.Show("Este producto no cuenta con un Precio definido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProducto.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("Este producto no cuenta con un Precio definido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProducto.Focus()
            Exit Sub
        End If

        '-- si no tiene costo
        If IsNumeric(txtCosto.Text) Then
            If txtCosto.Text <= 0 Then
                MessageBox.Show("El Costo definido no es Válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCosto.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("El Costo definido no es Válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCosto.Focus()
            Exit Sub
        End If

        '-- si es un tipo que necesita un vencimiento
        Dim intTmpIdTipoProducto As Integer = 0
        intTmpIdTipoProducto = sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "codigo", lblCodigoProducto.Text)
        If (sp_datosTabla.un_datoActivo("vence", "v_tipoproducto", "idTipoProducto", intTmpIdTipoProducto)) = True Then
            '-- controlar si se colocó un vencimiento
            If Not IsNumeric(maskVence.Text.Substring(0, 1)) Then
                MessageBox.Show("Esta mercadería necesita de un vencimiento...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                maskVence.Focus()
                Exit Sub
            End If
        End If
        '-- traer el idProducto
        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where codigo=" & lblCodigoProducto.Text)
        '-- traer el idDeposito
        intTmpIdDeposito = txtIdDeposito.Text
        '-- traer el idLote
        If Not IsNumeric(maskVence.Text.Substring(0, 1)) Then
            strTmpFechaVence = ""
        Else
            strTmpFechaVence = maskVence.Text
        End If
        'select idLote from lote where lote='0435' and vencimiento=convert(date,'01/04/2012',103)
        'txtSql.Text = "select idLote from lote where lote=" & "'" & txtLote.Text & "'" & " and vencimiento=convert(date," & "'" & strTmpFechaVence & "'" & ",103)"
        intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from lote where lote=" & "'" & txtLote.Text & "'" & " and vencimiento=convert(date," & "'" & strTmpFechaVence & "'" & ",103)")

        '-- controlar si tiene un stock inicial el producto
        'MsgBox("Valor de IdProducto  " & intTmpIdProducto)
        'MsgBox("Valor de idDeposito  " & intTmpIdDeposito)
        'MsgBox("Valor de IdLote  " & intTmpIdLote)

        If sp_datosTabla.consulta_valor("select idStock from stock where idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito & " and idLote=" & intTmpIdLote) > 0 Then
            MessageBox.Show("Esta mercadería ya tiene Stock Inicial...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            inicializaObjeto()
            txtProducto.Focus()
            Exit Sub
        End If
        '-- controlar si ya está cargado en la grilla
        For i As Integer = 0 To dtgStock.Rows.Count - 1
            If dtgStock.Rows(i).Cells(0).Value > 0 Then
                If dtgStock.Rows(i).Cells(1).Value = lblCodigoProducto.Text And dtgStock.Rows(i).Cells(4).Value = txtLote.Text And dtgStock.Rows(i).Cells(5).Value = maskVence.Text Then
                    MessageBox.Show("Esta mercadería ya está cargado en el Procedimiento Actual...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    inicializaObjeto()
                    txtProducto.Focus()
                    Exit Sub
                End If
            End If
        Next

        '*******************************************************
        '-- incrementar la variable publica de este modulo
        intGl_nroStockInicial = intGl_nroStockInicial + 1
        '-- cargar la grilla
        douTmpPrecio = CDbl(lblPrecio.Text)
        douTmpCosto = CDbl(txtCosto.Text)
        douTmpCantidad = CDbl(txtCantidad.Text)

        cargarStockInicial(intGl_nroStockInicial, intTmpIdProducto, txtFraccion.Text, douTmpPrecio, douTmpCosto, txtLote.Text, strTmpFechaVence, douTmpCantidad)

        inicializaObjeto()

        txtProducto.Focus()
    End Sub

    Public Sub buscarCodigoProducto(ByVal v_codigoIngresado As String)
        '-- varibles
        Dim intTmpIdProducto As Integer
        Dim strTmpCodigoBarra As String
        '-- la variable global del modulo
        banGl_stockInicial = True

        If Len(v_codigoIngresado) = 6 Then
            '-- por codigo del producto
            intTmpIdProducto = CInt(sp_datosTabla.un_datoString("idProducto", "v_producto", "codigo", v_codigoIngresado))
        End If
        If Len(v_codigoIngresado) > 6 Then
            '-- por codigo de barras
            strTmpCodigoBarra = sp_datosTabla.un_datoString("codigoBarra", "v_producto", "codigoBarra", v_codigoIngresado)
            If Len(strTmpCodigoBarra) = 0 Then
                intTmpIdProducto = 0
            Else
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
        lblCodigoProducto.Text = sp_datosTabla.un_datoString("codigo", "v_producto", "idProducto", Str(intTmpIdProducto))
        lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", Str(intTmpIdProducto))) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", Str(intTmpIdProducto)))
        lblCosto.Text = sp_datosTabla.sp_integer("sp_ultimoCostoProducto", intTmpIdProducto)
        lblCosto.Text = Format(CDec(lblCosto.Text), "##,###,###.##")
        Dim intTmpIdLaboratorio As Integer
        intTmpIdLaboratorio = sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", intTmpIdProducto)
        txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", Str(intTmpIdLaboratorio))
        Dim intTmpidTipoProducto As Integer
        intTmpidTipoProducto = sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", intTmpIdProducto)
        txtTipoProducto.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", Str(intTmpIdProducto))
        txtOrigen.Text = sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", Str(intTmpIdProducto))
        '-- la imagen de la mercaderia
        PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
        '---------------------------------'
        '-- controlar si es fraccionado --'
        '---------------------------------'
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
            ' MsgBox("Es un Producto Fraccionado..!")
            '-- la variable global del idProducto del modulo
            intGl_stockInicialIdProducto = intTmpIdProducto
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
            lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", intTmpIdProducto)
            lblPrecio.Text = Format(CDec(lblPrecio.Text), "##,###,###.##")
        End If
    End Sub

    Private Sub controlarGuardar()
        bolTmpError = False
        '-- controlar que se ingrese algun item
        '-- si no existen item cargados
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgStock.Rows.Count - 1
            If dtgStock.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
            End If
        Next
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existem items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolTmpError = True
            Exit Sub
        End If
        '---------------------------------------
        '-- volver a pintar todos los items
        For i As Integer = 0 To dtgStock.Rows.Count - 1
            If dtgStock.Rows(i).Cells(0).Value > 0 Then
                dtgStock.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
        '---------------------------------------
        '-- eliminar todos los registros de la tabla temporal de eta sucursal y maquina
        sp_datosTabla.consulta_valor("delete from detStockIniTmp where idConfig=" & intGl_idConfigPc)
        '-- declarar las variables para realizar la actualizacion de la tabla temporal
        Dim intTmpIdProducto As Integer
        Dim intTmpIdLote As Integer
        Dim intTmpIdDeposito As Integer
        Dim intTmpIdForma As Integer
        Dim douTmpCantidad As Double
        Dim intTmpCantfrac As Integer
        Dim douTmpCosto As Double
        '-- cargar en el detalle de la tabla temporal
        For i As Integer = 0 To dtgStock.Rows.Count - 1
            If dtgStock.Rows(i).Cells(0).Value > 0 Then
                intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_producto where codigo=" & dtgStock.Rows(i).Cells(1).Value)
                intTmpIdDeposito = txtIdDeposito.Text
                intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from lote where lote=" & "'" & dtgStock.Rows(i).Cells(4).Value & "'" & " and vencimiento=convert(date," & "'" & dtgStock.Rows(i).Cells(5).Value & "'" & ",103)")
                'txtSql.Text = "select idLote from lote where lote=" & "'" & dtgStock.Rows(i).Cells(4).Value & "'" & " and vencimiento=convert(date," & "'" & dtgStock.Rows(i).Cells(5).Value & "'" & ",103)"
                'MsgBox("Valor de intTmpIdLote  " & intTmpIdLote)
                intTmpIdForma = sp_datosTabla.un_datoString("idForma", "cabForma", "nombreForma", dtgStock.Rows(i).Cells(3).Value)
                douTmpCantidad = CDec(dtgStock.Rows(i).Cells(8).Value)
                '-- traer la cantidad fraccionada fraccionada
                intTmpCantfrac = sp_datosTabla.sp_string("sp_obtenerCantidadFraccion", intTmpIdProducto & "," & "'" & dtgStock.Rows(i).Cells(3).Value & "'" & ",0")
                'intTmpCantfrac = CInt(dtgStock.Rows(i).Cells(11).Value)
                '------------------------------------------------
                douTmpCosto = CDec(dtgStock.Rows(i).Cells(7).Value) * intTmpCantfrac
                '--- el procedimiento
                ' txtSql.Text = "sp_agregarDetStockIniTmp " & intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdProducto & "," & intTmpIdDeposito & "," & intTmpIdForma & "," & intTmpIdLote & "'" & dtgStock.Rows(i).Cells(4).Value & "'" & "," & "'" & dtgStock.Rows(i).Cells(5).Value & "'" & "," & douTmpCantidad & "," & intTmpCantfrac & "," & douTmpCosto & "," & intGl_idUsuario
                If (fun_guardarSp("sp_agregarDetStockIniTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdProducto & "," & intTmpIdDeposito & "," & intTmpIdForma & "," & intTmpIdLote & "," & "'" & dtgStock.Rows(i).Cells(4).Value & "'" & "," & "'" & dtgStock.Rows(i).Cells(5).Value & "'" & "," & douTmpCantidad & "," & intTmpCantfrac & "," & douTmpCosto & "," & intGl_idUsuario, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bolTmpError = True
                    dtgStock.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Exit Sub
                End If
                ' MsgBox("Realizó el procedimiento..!")
            End If
        Next
    End Sub

    '-- procedimiento para guardar el stock inicial
    Private Sub guardarStockInicial()
        'create PROCEDURE [dbo].[sp_guardarStockInicial]
        '-- variables para la cabecera de la venta
        '@idSucursal			int,
        '@idConfig			int,
        '@idUsuarioAlta		int
        If (fun_guardarSp("sp_guardarStockInicial", intGl_idSucursal & "," & intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardaron los registros con éxito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiarObjetos()
            intGl_nroStockInicial = 0
        End If
    End Sub
    '----------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        '-- activar la variable del modulo
        banGl_stockInicial = True
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
        controlarCargaProducto()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        controlarGuardar()
        If bolTmpError = False Then
            If MessageBox.Show("Desea Guardar el Stock Inicial de Mercaderias..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarStockInicial()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgStock.SelectedCells.Count > 0 Then
                dtgStock.Rows.Remove(dtgStock.CurrentRow)
                '-- restar la variable publica de nro de item
                intGl_nroStockInicial = intGl_nroStockInicial - 1

            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiarObjetos()
        intGl_nroStockInicial = 0
    End Sub
    '----------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtProducto.Text) Then
                buscarCodigoProducto(txtProducto.Text)
                e.Handled = True
                SendKeys.Send("{tab}")
            Else
                '-- buscar por nombre activando el formulario de busqueda
                banGl_stockInicial = True
                '-- si es espacio en blanco desplegar la lista de productos de los pedidos
                Me.Enabled = False
                '-- el procedimiento del formulario
                frmStock.txtBuscar.Text = ""
                frmStock.txtIdProducto.Text = 0
                frmStock.Visible = True
                frmStock.Show()
                frmStock.BringToFront()
                frmStock.txtBuscar.Focus()
            End If
        End If
    End Sub

    '-- solo numeros a la cantidad
    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = txtNumerico(txtCantidad, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
            If IsNumeric(txtCantidad.Text) Then
                txtCantidad.Text = Format(CDec(txtCantidad.Text), "##,###.##")
            End If
        End If
    End Sub

    '-- solo numeros en el costo
    Private Sub txtCosto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCosto.KeyPress
        e.Handled = txtNumerico(txtCosto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
            If IsNumeric(txtCosto.Text) Then
                txtCosto.Text = Format(CDec(txtCosto.Text), "##,###,###.##")
            End If
        End If
    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLote.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '----------------------------------------------------------------------------------------
    '***************'
    '-- LA GRILLA --'
    '***************'
    '-- formato dentro de la grilla
    Public Sub dtgStock_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        '-- formato del codigo
        If dtgStock.Columns(e.ColumnIndex).Name.Equals("Column1") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'e.CellStyle.ForeColor = Color.Blue
        End If
        '-- formato de forma
        If dtgStock.Columns(e.ColumnIndex).Name.Equals("Column3") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        '-- formato de cantidad
        If dtgStock.Columns(e.ColumnIndex).Name.Equals("Column11") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("###,###.##")
        End If
        '-- formato del precio
        If dtgStock.Columns(e.ColumnIndex).Name.Equals("Column12") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("#,###,###.##")
        End If
        '-- formato del costo
        If dtgStock.Columns(e.ColumnIndex).Name.Equals("Column5") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("##,###,###.##")
        End If
    End Sub

    Private Sub dtgStock_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgStock.RowEnter
        Dim row As DataGridViewRow = dtgStock.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
        '- asignar el id de producto al objeto
        lblIdProducto.Text = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "codigo", row.Cells(1).Value)
    End Sub
    '----------------------------------------------------------------------------------------------------
    '******************'
    '-- LAS MASKARAS --'
    '******************'
    '-- validar la mascara de vencimiento
    Private Sub maskVence_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskVence.KeyDown
        ToolTip1.Hide(maskVence)
    End Sub

    Private Sub maskVence_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles maskVence.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub maskVence_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskVence.TypeValidationCompleted
        Dim strPrueba As String = maskVence.Text
        '-- solo hacer el procedimiento si la primera expresion es numerica
        If IsNumeric(strPrueba.Substring(0, 1)) Then
            If Len(maskVence.Text) > 0 Then

                'strPrueba.su()
                'MsgBox("Valor de la mascara  " & strPrueba, MsgBoxStyle.Information)
                If (Not e.IsValidInput) Then
                    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    ToolTip1.Show("Debe introducir una fecha con formato .", maskVence, 70, -70, 700)
                    e.Cancel = True
                Else
                    Dim userdate As DateTime = CDate(e.ReturnValue)
                    ' controlar que la fecha no sea superior a la fecha del servidor
                    '-- colocar en una variable la fecha devuelta por el servidor
                    Dim datFechaServidor As Date
                    datFechaServidor = sp_datosTabla.sp_string("sp_fechaServer", "")
                    'MsgBox("Fecha del servidor  " & datFechaServidor.ToString)
                    If (userdate <= datFechaServidor) Then
                        ToolTip1.ToolTipTitle = "Fecha no es Válida"
                        ToolTip1.Show("La fecha debe ser mayor a la fecha actual del sistema.", maskVence, 0, -20, 5000)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmStockInicial_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        banGl_stockInicial = False

        frmMenuPrincipal.menuMercaderiaStockInicial.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------
End Class
