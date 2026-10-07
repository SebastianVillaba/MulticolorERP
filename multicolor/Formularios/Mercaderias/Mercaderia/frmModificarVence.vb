Public Class frmModificarVence
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim bolError As Boolean = False

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- verificar si el usuario es un vendedor
        If sp_datosTabla.consulta_valor("select idVendedor from v_usuario _vu inner join v_vendedor _vv on _vu.idPersonal=_vv.idPersonal " & _
                                        " where _vu.administrador=0 and _vu.idUsuario=" & intGl_idUsuario) > 0 Then
            Dim intTmpIdDeposito As Integer
            intTmpIdDeposito = sp_datosTabla.consulta_valor("select idDepositoVenta from configPc where idConfig=" & intGl_idConfigPc)
            txtIdDeposito.Text = intTmpIdDeposito
            txtDeposito.Text = sp_datosTabla.consulta_valorString("select nombreDeposito from deposito where idDeposito=" & intTmpIdDeposito)

            btnBuscarProveedor.Enabled = False
        End If
        '-----------------------------------------------------
        lblNro.Text = 0
        listarModiVence()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- limpiar todo el formulario
    Public Sub limpiarObjetos()
        '- txt
        txtCantidad.Text = 0
        txtDivision.Text = ""
        txtLaboratorio.Text = ""
        txtLote1.Text = ""
        txtLote2.Text = ""
        txtOrigen.Text = ""
        txtProducto.Text = ""
        txtStock.Text = 0
        txtTipoProducto.Text = ""
        '-- lbl
        lblCodigoProducto.Text = ""
        lblIdStock1.Text = 0
        lblNombreProducto.Text = ""
        lblNro.Text = 0
        '-- las maskaras
        maskVence1.Text = ""
        maskVence2.Text = ""
        '-- la imagen
        PictureBox1.ImageLocation = ""
        '-- el listview 
        'listarInventario(False)
    End Sub

    '-- habilitar objetos
    Public Sub habilitarObjetos()
        txtLote2.ReadOnly = False
        txtLote2.BackColor = Color.White
        maskVence2.ReadOnly = False
        maskVence2.BackColor = Color.White
        txtCantidad.ReadOnly = False
        txtCantidad.BackColor = Color.White
    End Sub

    '-- deshabilitar objetos
    Public Sub deshabilitarObjetos()
        txtLote2.ReadOnly = True
        txtLote2.BackColor = Color.LightBlue
        maskVence2.ReadOnly = True
        maskVence2.BackColor = Color.LightBlue
        txtCantidad.ReadOnly = True
        txtCantidad.BackColor = Color.LightBlue
    End Sub

    Public Sub listarModiVence()
        systemClass.SqlToLv_detalleModiVence(lvModiVence, "sp_consultaDetalleModiVenceTmp", intGl_idConfigPc)
    End Sub

    Public Sub buscarCodigoProducto(ByVal v_codigoIngresado As String)
        Try
            '-- varibles
            Dim intTmpIdLote As Integer
            Dim intTmpIdProducto As Integer
            Dim strTmpCodigoBarra As String
            Dim bolTmpCodigoBarraInterno As Boolean = False

            '-- verificar el tipo de busqueda
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
                            bolTmpCodigoBarraInterno = True
                            '-----------------------------
                            '-- para los de 12 digitos
                            '-----------------------------
                            '-- idProducto
                            intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(6, 5))
                            '-- idLote
                            intTmpIdLote = v_codigoIngresado.Substring(1, 5)

                        End If
                        If Len(v_codigoIngresado) = 13 Then
                            bolTmpCodigoBarraInterno = True
                            '-- para los de 13 digitos
                            intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "v_producto", "idProducto", v_codigoIngresado.Substring(7, 5))
                            '-- idLote
                            intTmpIdLote = v_codigoIngresado.Substring(2, 5)
                        End If
                    End If
                Else
                    bolTmpCodigoBarraInterno = False
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
            lblCodigoProducto.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intTmpIdProducto)
            lblNombreProducto.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & intTmpIdProducto)
            Dim intTmpIdLaboratorio As Integer
            intTmpIdLaboratorio = sp_datosTabla.consulta_valor("select idLaboratorio from producto where idProducto=" & intTmpIdProducto)
            txtLaboratorio.Text = sp_datosTabla.consulta_valorString("select nombre from v_laboratorio where idLaboratorio=" & intTmpIdLaboratorio)
            PictureBox1.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", intTmpIdProducto)
            Dim intTmpIdDivision As Integer
            intTmpIdDivision = sp_datosTabla.consulta_valor("select idDivision from producto where idProducto=" & intTmpIdProducto)
            txtDivision.Text = sp_datosTabla.consulta_valorString("select nombre from v_division where idDivision=" & intTmpIdDivision)
            Dim intTmpIdTipoProducto As Integer
            intTmpIdTipoProducto = sp_datosTabla.consulta_valor("select idTipoProducto from producto where idProducto=" & intTmpIdProducto)
            txtTipoProducto.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoProducto where idTipoProducto=" & intTmpIdTipoProducto)
            txtOrigen.Text = sp_datosTabla.consulta_valorString("select origen from producto where idProducto=" & intTmpIdProducto)
            '---------------------------------'
            '-- controlar si es fraccionado --'
            '---------------------------------'
            If (sp_datosTabla.un_dato_boleano("fraccionado", "producto", "idProducto", intTmpIdProducto)) = True Then
                '--- producto fraccionado
                MessageBox.Show("Producto Fraccionado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information)
                habilitarObjetos()
                txtCantidad.Text = 1
                txtLote2.Focus()

            End If
            '---------------------'
            '-- producto entero --'
            '---------------------'
            If bolTmpCodigoBarraInterno = False Then
                '----------------------------------
                '-- controlar si tiene varios lotes
                '----------------------------------
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & txtIdDeposito.Text, 0) > 0 Then
                    '-- para un lote
                    intTmpIdLote = sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & txtIdDeposito.Text, 0)
                    '-- los datos
                    '-- traer el idstock
                    lblIdStock1.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & txtIdDeposito.Text)
                    '-- traer el stock
                    txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & txtIdDeposito.Text))
                    txtStock.Text = Format(CDbl(txtStock.Text), "##,##0.##")

                    habilitarObjetos()
                    '-- por defecto 1 a la cantidad
                    txtCantidad.Text = 1
                    txtLote2.Focus()
                End If
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & txtIdDeposito.Text, 1) = 99 Then
                    '-- para mas de un lote
                    Me.Enabled = False
                    banGl_modificaVence = True

                    frmLote.txtProducto.Text = sp_datosTabla.dos_datos("nombreProducto,presentacion", "producto", "idproducto", intTmpIdProducto)
                    frmLote.listar_busquedaTodosLotes(intTmpIdProducto, CInt(txtIdDeposito.Text))
                    frmLote.Show()
                    frmLote.BringToFront()
                    frmLote.lvStockSucursal.Focus()
                End If
                '-- no tiene stock
                If sp_datosTabla.sp_traerValor("sp_obtenerIdLoteStock", intTmpIdProducto & "," & txtIdDeposito.Text, 1) = 0 Then
                    MessageBox.Show("Esta Mercadería no cuenta con Stock alguno..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    limpiarObjetos()
                    deshabilitarObjetos()
                    txtProducto.Focus()
                End If
            Else
                '-- el stock del producto
                '-- traer el idstock
                lblIdStock1.Text = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & txtIdDeposito.Text)
                '-- traer el stock
                txtStock.Text = sp_datosTabla.consulta_valorDouble("select cantidad from stock where idstock=" & sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & intTmpIdProducto & " and idLote=" & intTmpIdLote & " and idDeposito=" & txtIdDeposito.Text))
                txtStock.Text = Format(CDbl(txtStock.Text), "##,##0.##")
                '-- por defecto 1 a la cantidad
                habilitarObjetos()
                txtCantidad.Text = 1
                txtLote2.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub guardarModificacionVence()

        If (fun_guardarSp("sp_guardarModificacionVencimiento", intGl_idPersonaJur & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardó con Exito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiarObjetos()
            txtDeposito.Text = ""
            txtIdDeposito.Text = 0
            '-- colocar en 0 la variable publica
            intGl_nroModiVence = 0
            lblNro.Text = 0
            sp_datosTabla.consulta_valor("delete from detModiVenceTmp where idConfig=" & intGl_idConfigPc)
            listarModiVence()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------'
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    '-- eliminar de la grilla de pedido
    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text.Length > 0 Then
            '-- eliminar de la tabla temporal
            sp_datosTabla.consulta_valor("delete from detModiVenceTmp where idConfig=" & intGl_idConfigPc & " and idstock1=" & CInt(lblNro.Text))
            listarModiVence()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar Las Modificaciones de Vencimientos..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarModificacionVence()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        '-- variables
        Dim intTmpIdStock1 As Integer
        Dim douTmpCantidad1 As Double
        Dim douTmpCantidad2 As Double
        Dim strTmpLote As String
        Dim strTmpVence As String

        '-- asignar valores a las variables
        intTmpIdStock1 = CInt(lblIdStock1.Text)
        douTmpCantidad1 = CDbl(txtStock.Text)
        douTmpCantidad2 = CDbl(txtCantidad.Text)
        strTmpLote = txtLote2.Text
        strTmpVence = Trim(maskVence2.Text)

        'MsgBox("Valor de strTmpVence   " & strTmpVence)
        '-- agregar a la tabla temporal
        If (fun_guardarSp("sp_agregarDetModiVenceTmp", intGl_idConfigPc & "," & intTmpIdStock1 & "," & "'" & strTmpLote & "'" & "," & "'" & strTmpVence & "'" & "," & douTmpCantidad1 & "," & douTmpCantidad2, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            listarModiVence()
            limpiarObjetos()
            deshabilitarObjetos()
            txtProducto.Focus()
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarProveedor.Click
        banGl_modificaVence = True

        Me.Enabled = False
        frmBuscarDeposito.inicioForm()
        frmBuscarDeposito.listar("")
        frmBuscarDeposito.txtId.Text = 0
        frmBuscarDeposito.txtNombre.Text = ""
        frmBuscarDeposito.txtId.Text = ""
        frmBuscarDeposito.Show()
        frmBuscarDeposito.BringToFront()
        frmBuscarDeposito.txtBuscar.Focus()
    End Sub
    '--------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            '-- solo si se ingresa el deposito
            If Len(txtIdDeposito.Text) = 0 Or Not IsNumeric(txtIdDeposito.Text) Then
                MessageBox.Show("Debe Ingresar el Deposito para consultar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- si es por codigo del producto
            If txtProducto.Text = "" Or Not IsNumeric(txtProducto.Text) Then
                '-- si es espacio en blanco desplegar la lista de productos de los pedidos
                Me.Enabled = False
                banGl_modificaVence = True

                '-- el procedimiento del formulario
                If txtProducto.Text <> "" Then
                    frmStock.listar_busqueda(Trim(txtProducto.Text) & "%")
                End If
                '--------------------------------------------------------------------------
                frmStock.txtBuscar.Text = ""
                frmStock.txtIdProducto.Text = 0
                frmStock.Show()
                frmStock.BringToFront()
                frmStock.txtBuscar.Focus()
            Else
                '-- si la busqueda es por codigo
                buscarCodigoProducto(Trim(txtProducto.Text))
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = txtNumerico(txtCantidad, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtCantidad.Text) Then
                '-- el formato
                txtCantidad.Text = Format(CDec(txtCantidad.Text), "##,##0.##")
                '-- controlar la cantidad
                If txtCantidad.Text < 0 Then
                    MessageBox.Show("La cantidad ingresada no es válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCantidad.Text = 0
                    txtCantidad.Focus()
                    Exit Sub
                End If
                e.Handled = True
                'SendKeys.Send("{tab}")
                btnAgregar.Focus()
            Else
                MessageBox.Show("Debe Ingresar una cantidad válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtLote2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLote2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub maskVence2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles maskVence2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvModiVence_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvModiVence.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvModiVence.SelectedItems
            lblNro.Text = item.SubItems(5).Text
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmModificarVence_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- ver si hay item cargados
        If sp_datosTabla.consulta_valor("select idConfig from detModiVenceTmp where idConfig=" & intGl_idConfigPc) > 0 Then
            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- eliminar todos los registros de la tabla temporal
                sp_datosTabla.consulta_valor("delete from detModiVenceTmp where idConfig=" & intGl_idConfigPc)
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                frmMenuPrincipal.mercaderiaMercaderiasModificarVencimiento.Enabled = True

                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.mercaderiaMercaderiasModificarVencimiento.Enabled = True

            e.Cancel = False
        End If
    End Sub
    '--------------------------------------------------------------------------------------------
End Class