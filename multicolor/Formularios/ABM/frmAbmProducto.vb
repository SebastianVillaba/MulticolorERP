Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class frmAbmProducto
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim impuesto As New impuesto
    Dim sp_producto As New sp_producto
    Dim banNuevo As Boolean = False
    Dim banError As Boolean = False
    Dim intIdLaboratorio As Integer = 0
    Dim intIdTipoProducto As Integer = 0
    Dim intIdProducto As Integer = 0
    '***********************************************************************
    ' variables temporales para guardar los campos de la tabla de producto '
    '***********************************************************************
    Dim intTmpIdProducto As Integer = 0
    Dim strTmpCodigo As String = ""
    Dim intTmpIdImpuesto As Integer = 0
    Dim strTmpCodigoBarra As String = ""
    Dim strTmpNombreProducto As String = ""
    Dim strTmpPresentacion As String = ""
    Dim strTmpOrigen As String = ""
    Dim bolTmpFueraLinea As Boolean = False
    Dim strTmpFotoProducto As String = ""
    Dim bolTmpActivo As Boolean = False
    Dim intTmpIdUsuario As Integer = 0
    Dim douTmpPrecio As Double = 0
    Dim douTmpUltimoPrecio As Double = 0
    Dim douTmpUltimoCosto As Double = 0
    Dim bolTmpStockInicial As Boolean = False
    Dim bolTmpUsoInterno As Boolean = False

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        'listar(" Where p.nombreProducto Like '" & "A" & "%' Or p.nombreProducto Like '" & "A" & "%' " & "order by p.nombreProducto")
        'listar(" ")
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        lvProducto.Clear()
        systemClass.SqlToLv_abmProducto(lvProducto, "Select idProducto,codigo,mercaderia,stock from v_stock1 " & where)
        lvProducto.Columns(0).Width = 55
        lvProducto.Columns(1).Width = 70
        lvProducto.Columns(2).Width = 400
        lvProducto.Columns(3).Width = 70

        lvProducto.Columns(0).Text = "ID Prod."
        lvProducto.Columns(1).Text = "Codigo"
        lvProducto.Columns(2).Text = "Nombre del Producto"
        lvProducto.Columns(3).Text = "Stock"
    End Sub

    Private Sub habilitarObjetos()
        '---------------'
        '-- HABILITAR --'
        '---------------'
        '-- los txt
        txtCodigo.Enabled = True
        txtCodigo.BackColor = Color.White
        txtCodigoBarra.Enabled = True
        txtCodigoBarra.BackColor = Color.White
        txtNombre.Enabled = True
        txtNombre.BackColor = Color.White
        txtPresentacion.Enabled = True
        txtPresentacion.BackColor = Color.White
        txtOrigen.Enabled = True
        txtOrigen.BackColor = Color.White
        txtPrecio.Enabled = True
        txtPrecio.BackColor = Color.White
        '-- los botones
        btnBuscarTipo.Enabled = True
        btnBuscarLabo.Enabled = True
        btnBuscarImagen.Enabled = True
        btnModificar.Enabled = True
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        '-- los combos
        cboImpuesto.Enabled = True
        cboImpuesto.BackColor = Color.White
        '-- los chk
        chkActivo.Enabled = True
        chkUsoInterno.Enabled = True
        chkFueraLinea.Enabled = True
        chkBasico.Enabled = True
        chkEnvase.Enabled = True
        '**************************************
        '------------------'
        '-- DESHABILITAR --'
        '------------------'
        '-- la busqueda
        grBuscar.Enabled = False
        '-- botones
        btnNuevo.Enabled = False

    End Sub

    Public Sub deshabilitarObjetos()
        '---------------'
        '-- DESHABILITAR --'
        '---------------'
        '-- los txt
        txtCodigo.Enabled = False
        txtCodigo.BackColor = Color.LightSkyBlue
        txtCodigoBarra.Enabled = False
        txtCodigoBarra.BackColor = Color.LightSkyBlue
        txtNombre.Enabled = False
        txtNombre.BackColor = Color.LightSkyBlue
        txtPresentacion.Enabled = False
        txtPresentacion.BackColor = Color.LightSkyBlue
        txtOrigen.Enabled = False
        txtOrigen.BackColor = Color.LightSkyBlue
        txtPrecio.Enabled = False
        txtPrecio.BackColor = Color.LightSkyBlue
        '-- los botones
        btnBuscarTipo.Enabled = False
        btnBuscarLabo.Enabled = False
        btnBuscarImagen.Enabled = False
        btnModificar.Enabled = True
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        '-- LOS COMBOS
        cboImpuesto.Enabled = False
        cboImpuesto.BackColor = Color.LightSkyBlue
        '-- los chk
        chkActivo.Enabled = False
        chkFueraLinea.Enabled = False
        chkUsoInterno.Enabled = False
        chkBasico.Enabled = False
        chkEnvase.Enabled = False
        '**************************************
        '---------------'
        '-- HABILITAR --'
        '---------------'
        '-- la busqueda
        grBuscar.Enabled = True
        '-- botones
        btnNuevo.Enabled = True
    End Sub

    Private Sub vaciarObjetos()
        txtCodigo.Text = ""
        txtCodigoBarra.Text = ""
        txtFechaAlta.Text = ""
        txtFechaMod.Text = ""
        txtIdProducto.Text = 0
        txtLaboratorio.Text = ""
        txtIdLaboratorio.Text = 0
        txtNombre.Text = ""
        txtOrigen.Text = ""
        txtPrecio.Text = 0
        txtPresentacion.Text = ""
        txtTipo.Text = ""
        txtUsuarioAlta.Text = ""
        txtUsuarioMod.Text = ""
        txtIdTipoProducto.Text = 0
        lblImagen.Text = ""
        txtStock.Text = 0
        '-- chk
        chkUsoInterno.Checked = False
        chkBasico.Checked = False
        chkEnvase.Checked = False
        '-- las variables
        intIdLaboratorio = 0
        intIdTipoProducto = 0

    End Sub

    '-- listar los costos
    Private Sub listarCostos(ByVal v_idProducto As Integer)
        systemClass.SqlToLv_costoProducto(lvCosto, "sp_consultaCostoProducto", v_idProducto)
    End Sub

    '-- controlar todos los datos ingresados
    Private Sub controlarProducto()
        '-- si se ingresó los datos del nombre del producto
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe completar el nombre de la mercadería..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            banError = True
            Exit Sub
        End If
        '-- si se ingresó un origen no válido
        If txtOrigen.Text = "" Or (txtOrigen.Text <> "I" And txtOrigen.Text <> "N") Then
            MessageBox.Show("El Origen ingresado no es válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            banError = True
            Exit Sub
        End If
        '-- si es una modificacion permitir que no ingrese el codigo en blanco
        If banNuevo = False Then
            If txtCodigo.Text = "" Then
                MessageBox.Show("Debe introducir el codigo del producto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                banError = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub modificarProducto()

        '-- codigo
        strTmpCodigo = sacarComa(txtCodigo.Text)
        '-- idLaboratorio
        intIdLaboratorio = CInt(txtIdLaboratorio.Text)
        '-- idTipoProducto
        intIdTipoProducto = CInt(txtIdTipoProducto.Text)
        '-- idImpuesto
        intTmpIdImpuesto = cboImpuesto.SelectedValue
        '-- codigo de barra
        strTmpCodigoBarra = "'" & Trim(txtCodigoBarra.Text) & "'"
        '-- nombre del producto
        strTmpNombreProducto = "'" & Trim(txtNombre.Text) & "'"
        '-- presentacion
        strTmpPresentacion = "'" & Trim(txtPresentacion.Text) & "'"
        '-- origen
        strTmpOrigen = "'" & txtOrigen.Text & "'"
        '-- fuera de linea
        bolTmpFueraLinea = chkFueraLinea.Checked
        '-- activo
        bolTmpActivo = chkActivo.Checked
        '-- uso interno
        bolTmpUsoInterno = chkUsoInterno.Checked
        '-- idusuario
        intTmpIdUsuario = intGl_idUsuario
        '-----------------------------------------------------
        '-- foto del producto
        '---------------------------------------------
        strTmpFotoProducto = "'" & Trim(lblImagen.Text) & "'"
        '***********************************************'
        '-- procedimiento para actualizar el producto --'
        '***********************************************'
        sp_producto.UpdProducto(intIdProducto, txtCodigo.Text, intIdLaboratorio, intIdTipoProducto, intTmpIdImpuesto, txtCodigoBarra.Text, _
                                txtNombre.Text, txtPresentacion.Text, txtOrigen.Text, bolTmpFueraLinea, bolTmpActivo, bolTmpUsoInterno,
                                sacarComa(txtPrecio.Text), chkBasico.Checked, chkEnvase.Checked)

    End Sub

    Private Sub guardarProducto()
        '-- codigo
        strTmpCodigo = "'" & systemClass.FormatoNumeroIngresoBD(txtCodigo.Text) & "'"
        '-- idLaboratorio
        intIdLaboratorio = CInt(txtIdLaboratorio.Text)
        '-- idTipoProducto
        intIdTipoProducto = CInt(txtIdTipoProducto.Text)
        '-- idImpuesto
        intTmpIdImpuesto = cboImpuesto.SelectedValue
        '-- codigo de barra
        strTmpCodigoBarra = "'" & Trim(txtCodigoBarra.Text) & "'"
        '-- nombre del producto
        strTmpNombreProducto = "'" & Trim(txtNombre.Text) & "'"
        '-- presentacion
        strTmpPresentacion = "'" & Trim(txtPresentacion.Text) & "'"
        '-- origen
        strTmpOrigen = "'" & txtOrigen.Text & "'"
        '-- fuera de linea
        bolTmpFueraLinea = chkFueraLinea.Checked
        '-- fotoproducto
        '-- foto del producto
        strTmpFotoProducto = "'" & Trim(lblImagen.Text) & "'"
        '-- uso interno
        bolTmpUsoInterno = chkUsoInterno.Checked
        '-- idusuario
        intTmpIdUsuario = intGl_idUsuario
        '***********************************************'
        '-- procedimiento para actualizar el producto --'
        '***********************************************'
        sp_producto.insProducto(txtCodigo.Text, intIdLaboratorio, intIdTipoProducto, cboImpuesto.SelectedValue, txtCodigoBarra.Text, txtNombre.Text,
                                txtPresentacion.Text, txtOrigen.Text, bolTmpFueraLinea, bolTmpUsoInterno, sacarComa(txtPrecio.Text), chkBasico.Checked, chkEnvase.Checked)

    End Sub

    Public Sub mostrarDetalle(ByVal v_idProducto As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '************************'
            '-- DATOS DEL PRODUCTO --'
            '************************'
            '-- el idCobranza
            txtIdProducto.Text = v_idProducto
            intIdProducto = v_idProducto
            '-- codigo
            txtCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
            '-- codigo de barra
            txtCodigoBarra.Text = sp_datosTabla.consulta_valorString("select codigoBarra from producto where idProducto=" & v_idProducto)
            '-- nombre
            txtNombre.Text = sp_datosTabla.consulta_valorString("select nombreProducto from producto where idProducto=" & v_idProducto)
            '-- presentacion
            txtPresentacion.Text = sp_datosTabla.consulta_valorString("select presentacion from producto where idProducto=" & v_idProducto)
            '-- tipo de producto
            Dim intTmpIdTipoProducto As Integer
            intTmpIdTipoProducto = sp_datosTabla.consulta_valor("select idTipoProducto from producto where idProducto=" & v_idProducto)
            txtIdTipoProducto.Text = intTmpIdTipoProducto
            txtTipo.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoProducto where idTipoProducto=" & intTmpIdTipoProducto)
            '-- laboratorio
            Dim intTmpIdLaboratorio As Integer
            intTmpIdLaboratorio = sp_datosTabla.consulta_valor("select idLaboratorio from producto where idProducto=" & v_idProducto)
            txtIdLaboratorio.Text = intTmpIdLaboratorio
            txtLaboratorio.Text = sp_datosTabla.consulta_valorString("select nombre from v_laboratorio where idLaboratorio=" & intTmpIdLaboratorio)
            '-- impuesto
            impuesto.ListarImpuesto(cboImpuesto)
            cboImpuesto.SelectedValue = sp_datosTabla.consulta_valor("select idImpuesto from producto where idProducto=" & v_idProducto)
            '-- origen
            txtOrigen.Text = sp_datosTabla.consulta_valorString("select origen from producto where idProducto=" & v_idProducto)
            '-- precio
            txtPrecio.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)
            '-- los costos 
            listarCostos(v_idProducto)

            '-- activo
            chkActivo.Checked = sp_datosTabla.consulta_valorBoolean("select activo from producto where idProducto=" & v_idProducto)
            '-- fuera de linea
            chkFueraLinea.Checked = sp_datosTabla.consulta_valorBoolean("select fueraLinea from producto where idProducto=" & v_idProducto)
            '-- si es de uso interno
            chkUsoInterno.Checked = sp_datosTabla.consulta_valorBoolean("select usoInterno from producto where idProducto=" & v_idProducto)

            '-- la imagen de la mercaderia
            'picImagen.Image = sp_datosTabla.consulta_valorImagen("select imagen from producto where idProducto=" & v_idProducto)
            picImagen.ImageLocation = strGl_rutaImagen + Trim(sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intIdProducto)) + ".jpg"
            '-- usuario creador
            Dim intTmpIdUsuario As Integer
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from producto where idProducto=" & v_idProducto)
            txtUsuarioAlta.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
            '-- fecha alta
            txtFechaAlta.Text = sp_datosTabla.consulta_valorString("select fechaAlta from producto where idProducto=" & v_idProducto)
            '-- usuario modificador
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioMod from producto where idProducto=" & v_idProducto)
            txtUsuarioMod.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
            '-- fecha modificado
            txtFechaMod.Text = sp_datosTabla.consulta_valorString("select fechaMod from producto where idProducto=" & v_idProducto)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub primerRegistro(ByVal v_idProducto As Integer)
        '-- el primer registro
        mostrarDetalle(v_idProducto)
        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub anteriorRegistro(ByVal v_idProducto As Integer)
        '-- el registro anterior
        mostrarDetalle(v_idProducto)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idProducto As Integer)
        '-- el registro anterior
        mostrarDetalle(v_idProducto)
    End Sub

    Private Sub ultimoRegistro(ByVal v_idProducto As Integer)
        '-- el ultimo registro
        mostrarDetalle(v_idProducto)
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub

    '-- la opcion del resumen por fecha
    Private Sub imprimirSeguimientoPrecio()
        Try

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idProducto As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_seguimientoPrecio
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idProducto.Value = CInt(txtIdProducto.Text)

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idProducto)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idProducto").ApplyCurrentValues(pvParametros1)

            '-- paramentros constantes
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
            ofrm.Show()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvProducto.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    '-- mostrar los datos en el desplasamiento por la lista
    Private Sub lvProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProducto.SelectedIndexChanged
        For Each item As ListViewItem In lvProducto.SelectedItems
            '-- colocar en una variable el codigo del producto
            intIdProducto = CInt(item.SubItems(0).Text)
            Dim intTmpCodigo As Integer
            intTmpCodigo = item.SubItems(1).Text
            '-- codigo
            txtCodigo.Text = item.SubItems(1).Text
            '-- idProducto
            txtIdProducto.Text = sp_datosTabla.consulta_valor("select idProducto from producto where idProducto=" & intIdProducto)
            '-- el codigo de barra
            txtCodigoBarra.Text = sp_datosTabla.consulta_valorString("select codigoBarra from producto where idProducto=" & intIdProducto)
            'MsgBox("Valor del codigo de barras  " & sp_datosTabla.un_datoString("codigoBarra", "producto", "codigo", intTmpCodigo))
            '-- nombre del producto
            txtNombre.Text = sp_datosTabla.consulta_valorString("select nombreProducto from producto where idProducto=" & intIdProducto)
            'MsgBox("Valor del nombre del producto  " & sp_datosTabla.un_datoString("nombreProducto", "producto", "codigo", intTmpCodigo))
            '-- presentacion
            txtPresentacion.Text = sp_datosTabla.consulta_valorString("select presentacion from producto where idProducto=" & intIdProducto)
            '-- el tipo del producto
            intIdTipoProducto = sp_datosTabla.consulta_valor("select idTipoProducto from producto where idProducto=" & intIdProducto)
            txtIdTipoProducto.Text = intIdTipoProducto
            txtTipo.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoProducto", "idTipoProducto", intIdTipoProducto)
            '-- el laboratorio
            intIdLaboratorio = sp_datosTabla.consulta_valor("select idLaboratorio from producto where idProducto=" & intIdProducto)
            txtIdLaboratorio.Text = intIdLaboratorio
            txtLaboratorio.Text = sp_datosTabla.un_datoString("nombre", "v_laboratorio", "idLaboratorio", intIdLaboratorio)
            '-- el impuesto
            impuesto.ListarImpuesto(cboImpuesto)
            cboImpuesto.SelectedValue = sp_datosTabla.consulta_valor("select idImpuesto from producto where idProducto=" & intIdProducto)
            '-- origen
            txtOrigen.Text = sp_datosTabla.consulta_valorString("select origen from producto where idProducto=" & intIdProducto)
            '-- precio
            txtPrecio.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & intIdProducto)
            txtPrecio.Text = Format(CDec(txtPrecio.Text), "##,###,##0")
            '-- stock
            txtStock.Text = sp_datosTabla.consulta_valorDouble("select stock from v_stock1 where idProducto=" & intIdProducto)
            txtStock.Text = Format(CDec(txtStock.Text), "##,###,##0.##")
            '-- los costos
            '  MsgBox("Valor de idProducto  " & intIdProducto)
            listarCostos(intIdProducto)
            '-- istar los descuentos
            '-- activo
            chkActivo.Checked = sp_datosTabla.consulta_valorBoolean("select activo from producto where idProducto=" & intIdProducto)
            '-- fuera de linea
            chkFueraLinea.Checked = sp_datosTabla.consulta_valorBoolean("select fueraLinea from producto where idProducto=" & intIdProducto)
            '-- uso interno
            chkUsoInterno.Checked = sp_datosTabla.consulta_valorBoolean("select usoInterno from producto where idProducto=" & intIdProducto)
            '-- base
            chkBasico.Checked = sp_datosTabla.consulta_valorBoolean("select basico from producto where idProducto=" & intIdProducto)
            '-- envase
            chkEnvase.Checked = sp_datosTabla.consulta_valorBoolean("select envase from producto where idProducto=" & intIdProducto)

            '-- usuario creador
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.consulta_valor("select idUsuarioAlta from producto where idProducto=" & intIdProducto)))
            '-- fecha alta
            txtFechaAlta.Text = sp_datosTabla.consulta_valorString("select fechaAlta from producto where idProducto=" & intIdProducto)
            '-- usuario modificador
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", sp_datosTabla.consulta_valor("select idUsuarioMod from producto where idProducto=" & intIdProducto))
            '-- fecha modificado
            txtFechaMod.Text = sp_datosTabla.consulta_valorString("select fechaMod from producto where idProducto=" & intIdProducto)
            '-- la imagen de la mercaderia
            'If (sp_datosTabla.consulta_valor("select imagen from producto where idProducto=" & intIdProducto)) Is DBNull.Value Then
            '    picImagen.Image = Nothing
            'Else
            'picImagen.Image = sp_datosTabla.consulta_valorImagen("select imagen from producto where idProducto=" & intIdProducto)
            'MsgBox("Valor  " & strGl_rutaImagen + Trim(sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intIdProducto)) + ".jpg")
            picImagen.ImageLocation = strGl_rutaImagen + Trim(sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intIdProducto)) + ".jpg"
            '-- la imagen de la mercaderia
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    '-- buscar productos
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If rdIdProducto.Checked = True Then
                If Trim(txtBuscar.Text).Length <= 6 Then
                    '-- idProducto
                    listar(" Where idProducto=" & txtBuscar.Text)
                Else
                    '--- codigo de barra
                    If Trim(txtBuscar.Text).Length > 6 Then
                        listar(" Where codigoBarra Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%' " & "order by codigoBarra")
                    End If
                End If
            End If
            If rdNombre.Checked = True Then
                If Not IsNumeric(txtBuscar.Text) Then
                    '-- por nombre de producto
                    listar(" Where mercaderia Like '" & txtBuscar.Text & "%' Or mercaderia Like '" & txtBuscar.Text & "%' " & "order by mercaderia")
                Else
                    '--- codigo de barra
                    If Trim(txtBuscar.Text).Length > 6 Then
                        listar(" Where codigoBarra Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%' " & "order by codigoBarra")
                    End If
                End If
            End If
            If rdCodigo.Checked = True Then
                If Trim(txtBuscar.Text).Length <= 6 Then
                    '-- por codigo del producto
                    listar(" Where codigo='" & txtBuscar.Text & "'")
                Else
                    '--- codigo de barra
                    If Trim(txtBuscar.Text).Length > 6 Then
                        listar(" Where codigoBarra Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%' " & "order by codigoBarra")
                    End If
                End If
            End If
            lvProducto.Focus()
        End If

    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        e.Handled = txtNumerico(txtCodigo, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtCodigoBarra.Focus()
        End If
    End Sub

    Private Sub txtCodigoBarra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoBarra.KeyPress
        e.Handled = txtNumerico(txtCodigoBarra, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtOrigen.Focus()
        End If
    End Sub

    Private Sub txtOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrigen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPrecio.Focus()
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        e.Handled = txtNumerico(txtPrecio, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtPrecio.Text = Format(CDec(txtPrecio.Text), "###,###,##0")
            txtNombre.Focus()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPresentacion.Focus()
        End If
    End Sub

    Private Sub txtPresentacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPresentacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscarTipo.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If txtCodigo.Text = "" Then
            MessageBox.Show("No existe ninguna Mercadería a Modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- solo si hay un producto consultado
        If CInt(txtIdProducto.Text > 0) Then
            banNuevo = False
            habilitarObjetos()
            txtCodigoBarra.Focus()
        Else
            MessageBox.Show("No existe ninguna Mercadería a Modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        banError = False
        controlarProducto()
        If banError = False Then
            If MessageBox.Show("Desea Guardar los nuevos datos de la Mercadería..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If banNuevo = True Then
                    '-- si es un nuevo registro
                    guardarProducto()
                Else
                    '-- si se modifica el registro
                    modificarProducto()
                End If
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        banNuevo = True
        habilitarObjetos()
        vaciarObjetos()
        btnModificar.Enabled = False
        '-- inicializar los combos con sus respectivos datos
        '-- el impuesto
        impuesto.ListarImpuesto(cboImpuesto)
        '-- imagen de fondo por defecto
        picImagen.ImageLocation = strGl_rutaImagen & "fondo-foto1.jpg"

        cboImpuesto.SelectedValue = 2
        txtCodigo.Focus()
    End Sub

    Private Sub btnBuscarLabo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarLabo.Click
        '-- dar valor a la variable global
        banGl_labAbmProducto = True

        Me.Enabled = False
        frmBuscarLaboratorio.Visible = True
        frmBuscarLaboratorio.WindowState = FormWindowState.Normal
        frmBuscarLaboratorio.BringToFront()
        frmBuscarLaboratorio.txtBuscar.Focus()
    End Sub

    Private Sub btnBuscarTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTipo.Click
        '-- dar valor a la variable global
        banGl_tipoProdAbmProducto = True
        Me.Enabled = False
        frmBuscarTipoProducto.Visible = True
        frmBuscarTipoProducto.WindowState = FormWindowState.Normal
        frmBuscarTipoProducto.BringToFront()
        frmBuscarTipoProducto.txtBuscar.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        vaciarObjetos()
    End Sub

    Private Sub btnBuscarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarImagen.Click
        OpenFileDialog1.Filter = "Imágenes JPG (*.jpg)|*.jpg|JEPG (*.jpeg)|*.jpeg|Mapas de bits (*.bmp)|*.bmp"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            picImagen.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnEliminarImagen_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarImagen.Click
        'picImagen.Image = Nothing
        '-- imagen de fondo por defecto
        picImagen.ImageLocation = "c:\Multicolor\fondo-foto1.jpg"
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdProducto As Integer = 0
        intTmpIdProducto = sp_datosTabla.consulta_valor("select min(idProducto) from producto")
        ultimoRegistro(intTmpIdProducto)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdProducto As Integer = 0
        intTmpIdProducto = sp_datosTabla.consulta_valor("select max(idProducto) from producto")
        ultimoRegistro(intTmpIdProducto)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdProducto.Text) Then
            Dim intTmpIdProducto As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdProducto = txtIdProducto.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdProducto = intTmpIdProducto - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idProducto", "producto", "idProducto", intTmpIdProducto)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdProducto = txtIdProducto.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdProducto <= sp_datosTabla.consulta_valor("select min(idProducto) from producto") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdProducto.Text = sp_datosTabla.consulta_valor("select min(idProducto) from producto")
            Else
                txtIdProducto.Text = intTmpIdProducto
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdProducto)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdProducto.Text) Then
            Dim intTmpIdProducto As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdProducto = txtIdProducto.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdProducto = intTmpIdProducto + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idProducto", "producto", "idProducto", intTmpIdProducto)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdProducto = txtIdProducto.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdProducto >= sp_datosTabla.consulta_valor("select max(idProducto) from producto") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdProducto.Text = sp_datosTabla.consulta_valor("select max(idProducto) from producto")
            Else
                btnAnterior.Enabled = True
                txtIdProducto.Text = intTmpIdProducto
            End If
            siguienteRegistro(intTmpIdProducto)
        End If
    End Sub

    Private Sub btnPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecio.Click
        Me.Enabled = False
        imprimirSeguimientoPrecio()
        Me.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmAbmProducto1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.abmMercaderiaProducto.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------
End Class