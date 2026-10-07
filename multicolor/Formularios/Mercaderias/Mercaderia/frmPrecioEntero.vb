Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPrecioEntero
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

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
        '-- procedimiento para establecer del deposito en donde se va a sacar las mercaderias
        'lblIdDeposito.Text = txt
        Dim intIdDeposito = sp_datosTabla.un_dato_integer("idDepositoRemision", "configPc", "idConfig", intGl_idConfigPc)
        'MsgBox("Valor de intIdDeposito  " & intIdDeposito)
        lblDeposito.Text = sp_datosTabla.un_datoString("nombreDeposito", "deposito", "idDeposito", intIdDeposito)
    End Sub

    Private Sub limpiarObjetos()
        lblNombreProducto.Text = ""
        lblCodigoProducto.Text = 0
        lblIdProducto.Text = 0
        txtLaboratorio.Text = ""
        txtDivision.Text = ""
        txtTipoProducto.Text = ""
        txtOrigen.Text = ""
        txtProducto.Text = ""
        txtNroInformativo.Text = 0
        txtProducto.Enabled = False
        txtProducto.BackColor = Color.LightBlue
        txtNroInformativo.Enabled = False
        txtNroInformativo.BackColor = Color.LightBlue
        txtPrecio.Enabled = False
        txtPrecio.BackColor = Color.LightBlue
        PictureBox1.ImageLocation = ""
        txtPrecioAnt.Text = 0
        txtPrecioAnt.Text = 0
        dtpFecha.Enabled = False
        '-- los lbl
        lblCodigoProducto.Text = 0
        lblIdProducto.Text = 0
        lblNombreProducto.Text = ""
        lblNro.Text = 0
        '-- la imagen
        PictureBox1.ImageLocation = ""
    End Sub

    Private Sub inicializarObjetos()
        txtNroInformativo.Enabled = True
        txtNroInformativo.BackColor = Color.White
        txtProducto.Enabled = True
        txtProducto.BackColor = Color.White
        txtPrecio.Enabled = True
        txtPrecio.BackColor = Color.White
        dtpFecha.Enabled = True
    End Sub

    Private Sub habilitarObjetos()
        txtProducto.Text = ""
        txtPrecioAnt.Text = 0
        txtPrecio.Text = 0
        lblCodigoProducto.Text = 0
        lblNombreProducto.Text = 0
        lblIdProducto.Text = 0
        PictureBox1.ImageLocation = ""
    End Sub

    Public Sub buscarCodigoProducto(ByVal v_codigoIngresado As String)
        '-- varibles
        Dim intTmpIdProducto As Integer
        Dim strTmpCodigoBarra As String
        If Len(v_codigoIngresado) = 6 Then
            '-- por codigo del producto
            intTmpIdProducto = CInt(sp_datosTabla.un_datoString("idProducto", "v_producto", "codigo", v_codigoIngresado))
        End If
        If Len(v_codigoIngresado) > 6 Then
            '-- por codigo de barras
            strTmpCodigoBarra = sp_datosTabla.un_datoString("codigoBarra", "v_producto", "codigoBarra", v_codigoIngresado)
            If Len(strTmpCodigoBarra) = 0 Then
                '-- por codigo de barras generado
                If Len(v_codigoIngresado) = 12 Then
                    '-- para los de 12 digitos
                    intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(6, 5))
                End If
                If Len(v_codigoIngresado) = 13 Then
                    '-- para los de 13 digitos
                    intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(7, 5))
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
            MessageBox.Show("No se encuentra el Codigo Ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- comparar si existe el codigo ingresado
        If intTmpIdProducto = 0 Then
            MessageBox.Show("No se encuentra el Codigo Ingresado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- valor del producto
        lblCodigoProducto.Text = sp_datosTabla.un_dato_integer("codigo", "v_producto", "idProducto", intTmpIdProducto)
        lblNombreProducto.Text = Trim(sp_datosTabla.un_datoString("nombreProducto", "v_producto", "idProducto", intTmpIdProducto)) & "," & Trim(sp_datosTabla.un_datoString("presentacion", "v_producto", "idProducto", intTmpIdProducto))
        'lblPrecio.Text = sp_datosTabla.un_dato_double("precio", "producto", "idProducto", v_idProducto)
        lblIdProducto.Text = intTmpIdProducto
        txtLaboratorio.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", sp_datosTabla.un_dato_integer("idLaboratorio", "v_producto", "idProducto", intTmpIdProducto)))
        txtDivision.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_Division", "idDivision", sp_datosTabla.un_dato_integer("idDivision", "v_producto", "idProducto", intTmpIdProducto)))
        txtTipoProducto.Text = Trim(sp_datosTabla.un_datoString("nombreTipo", "v_tipoproducto", "idTipoProducto", sp_datosTabla.un_dato_integer("idTipoProducto", "v_producto", "idProducto", intTmpIdProducto)))
        txtOrigen.Text = Trim(sp_datosTabla.un_datoString("origen", "v_producto", "idProducto", intTmpIdProducto))
        txtPrecioAnt.Text = sp_datosTabla.un_dato_double("precio", "v_producto", "idProducto", intTmpIdProducto)
        txtPrecioAnt.Text = Format(CDec(txtPrecioAnt.Text), "###,###,###.00")
        '-- la imagen de la mercaderia
        PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
        '---------------------------------'
        '-- controlar si es fraccionado --'
        '---------------------------------'
        If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
            MessageBox.Show("Esta mercaderia es Fraccionada..! No puede actualizar su precio en este Módulo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            btnAgregar.Enabled = False
            Exit Sub
        End If
        btnAgregar.Enabled = True

    End Sub

    '-- controlar todo antes de cargar a la grilla
    Private Sub controlarCargaGrilla()
        Dim intTmpIdImpuesto As Integer
        Dim douTmpPorcentajeImpuesto As Double

        bolTmpError = False
        '-- controlar si se ingresó el producto
        If Len(lblNombreProducto.Text) = 0 Then
            MessageBox.Show("Debe ingresar el Nombre de la Mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolTmpError = True
            Exit Sub
        End If
        '-- controlar si se ingresó el precio
        If CDec(txtPrecio.Text) <= 0 Then
            MessageBox.Show("Debe ingresar el Precio nuevo para la Mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolTmpError = True
            Exit Sub
        End If
        '-- controlar si está cargado en la grilla
        For i As Integer = 0 To dtgPrecio.Rows.Count - 1
            If dtgPrecio.Rows(i).Cells(0).Value > 0 Then
                '-- controlar el idProducti
                If dtgPrecio.Rows(i).Cells(6).Value = lblIdProducto.Text Then
                    MessageBox.Show("Esta Mercadería ya está cargada en la Grilla..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bolTmpError = True
                    Exit Sub
                End If
            End If
        Next
        '-- sacar el porcentaje del impuesto
        intTmpIdImpuesto = sp_datosTabla.un_dato_integer("idImpuesto", "producto", "idProducto", lblIdProducto.Text)
        douTmpPorcentajeImpuesto = sp_datosTabla.un_dato_double("porcentajeImpuesto", "impuesto", "idImpuesto", intTmpIdImpuesto)
        '-- cargar en la grilla
        intGl_nroPrecioEntero = intGl_nroPrecioEntero + 1
        cargarPrecioEntero(intGl_nroPrecioEntero, lblCodigoProducto.Text, lblNombreProducto.Text, douTmpPorcentajeImpuesto, txtPrecioAnt.Text, txtPrecio.Text, lblIdProducto.Text)
        habilitarObjetos()
        txtProducto.Text = ""
        txtProducto.Focus()
    End Sub

    Private Sub controlarGuardar()
        '-- controlar que se ingrese algun item
        '-- si no existen item cargados
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgPrecio.Rows.Count - 1
            If dtgPrecio.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
            End If
        Next
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existem items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolTmpError = True
            Exit Sub
        End If
        '-- eliminar todos los registros de la tabla temporal de eta sucursal y maquina
        sp_datosTabla.consulta_valor("delete from detPrecioEnteroTmp where idConfig=" & intGl_idConfigPc)

        '---------------------------------------
        '-- volver a pintar todos los items
        For i As Integer = 0 To dtgPrecio.Rows.Count - 1
            If dtgPrecio.Rows(i).Cells(0).Value > 0 Then
                dtgPrecio.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
        '--------------------------------
        '-- declarar las variables para realizar la actualizacion de la tabla temporal
        Dim intTmpIdProducto As Integer
        Dim douTmpPrecioAnterior As Double
        Dim douTmpPrecioActual As Double
        '-- cargar en el detalle de la tabla temporal
        For i As Integer = 0 To dtgPrecio.Rows.Count - 1
            If dtgPrecio.Rows(i).Cells(0).Value > 0 Then
                intTmpIdProducto = CInt(dtgPrecio.Rows(i).Cells(6).Value)
                douTmpPrecioActual = CDec(dtgPrecio.Rows(i).Cells(5).Value)
                douTmpPrecioAnterior = CDec(dtgPrecio.Rows(i).Cells(4).Value)
                If (fun_guardarSp("sp_agregarDetPrecioEnteroTmp", intGl_idConfigPc & "," & intTmpIdProducto & "," & douTmpPrecioAnterior & "," & douTmpPrecioActual, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '-- pintar en rojo los errores
                    dtgPrecio.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If
        Next
    End Sub

    Private Sub guardarPrecio()

        If (fun_guardarSp("sp_guardarPrecioEntero", intGl_idConfigPc & "," & intGl_idSucursal & "," & txtNroInformativo.Text & "," & "'" & systemClass.formatofecha(dtpFecha) & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- imprmir los precios
            Dim intTmpIdPrecio As Integer
            intTmpIdPrecio = sp_datosTabla.consulta_valor("select max(idPrecio) from cabPrecioEntero")
            imprimir(intTmpIdPrecio)
            '----------------------
            limpiarObjetos()
            btnAgregar.Enabled = False
            btnCancelar.Enabled = False
            btnEliminar.Enabled = False
            btnGuardar.Enabled = False
            btnNuevo.Enabled = True
            '-- limpiar la grilla
            dtgPrecio.Rows.Clear()
            intGl_nroPrecioEntero = 0
        End If
    End Sub

    Private Sub imprimir(ByVal codigoPrecio As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idprecio As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_precioEntero
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idprecio.Value = codigoPrecio
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idprecio)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idPrecio").ApplyCurrentValues(pvParametros)
        rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub
    '------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtNroInformativo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroInformativo.KeyPress
        e.Handled = txtNumerico(txtNroInformativo, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'txtProducto.Focus()
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        e.Handled = txtNumerico(txtProducto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtProducto.Text = "" Then
                '-- si es espacio en blanco desplegar la lista de productos 
                banGl_precioEntero = True
                Me.Enabled = False
                frmStock.txtBuscar.Text = ""
                frmStock.txtIdProducto.Text = "0"
                frmStock.Visible = True
                frmStock.WindowState = FormWindowState.Normal
                frmStock.Show()
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtProducto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProducto.Validated
        '-- solo si se ingresó al gun dato
        If txtProducto.Text.Length > 0 Then
            '-- verificar el metodo de busqueda
            If IsNumeric(txtProducto.Text.Substring(0, 1)) Then
                '-- si es numerico el primer digito ingresado
                '-- si es buscado por el codigo de barras del producto
                buscarCodigoProducto(txtProducto.Text)
            End If
        End If

    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        e.Handled = txtNumerico(txtPrecio, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtPrecio.Text) = 0 Then
                txtPrecio.Text = 0
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            txtPrecio.Text = Format(CDec(txtPrecio.Text), "###,###,###.00")
        End If

    End Sub

    Private Sub dtgPrecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtgPrecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            MsgBox("Paso por aca")
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        limpiarObjetos()
        inicializarObjetos()
        intGl_nroPrecioEntero = 0
        '-- habilitar los txt y deshabilitarlo
        ' btnAgregar.Enabled = True
        btnNuevo.Enabled = False
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnEliminar.Enabled = True

        txtNroInformativo.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolTmpError = False
        controlarGuardar()
        If MessageBox.Show("Desea Guardar la Remisión de Mercaderias a la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarPrecio()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgPrecio.SelectedCells.Count > 0 Then
                '---------------------------------------------------------
                dtgPrecio.Rows.Remove(dtgPrecio.CurrentRow)
                '-- restar la variable publica de nro de item
                intGl_nroPrecioEntero = intGl_nroPrecioEntero - 1
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiarObjetos()
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        controlarCargaGrilla()
    End Sub
    '------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgPrecio_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgPrecio.CellFormatting
        '-- formato del precio anterior
        If dtgPrecio.Columns(e.ColumnIndex).Name.Equals("Column12") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("##,###,###.##")
        End If
        '-- formato del precio actual
        If dtgPrecio.Columns(e.ColumnIndex).Name.Equals("Column8") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.Format = ("##,###,###.##")
        End If
    End Sub

    Private Sub dtgPrecio_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPrecio.RowEnter
        Dim row As DataGridViewRow = dtgPrecio.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmPrecioEntero_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiaMercaderiasModificarPRecioEntero.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------
End Class
