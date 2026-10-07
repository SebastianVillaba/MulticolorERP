Public Class frmFraccionarMercaderia
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        '-- txt
        txtCantidad.Text = 0
        txtCantidad.ReadOnly = True
        txtCantidad.BackColor = Color.LightSkyBlue
        txtPrecio.Text = 0
        txtPrecio.ReadOnly = True
        txtPrecio.BackColor = Color.LightSkyBlue

        txtUsuarioAlta.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuario where idUsuario=" & intGl_idUsuario)
        txtUsuarioMod.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuario where idUsuario=" & intGl_idUsuario)
        txtFechaAlta.Text = sp_datosTabla.consulta_valorString("select getdate() ")
        txtFechaMod.Text = sp_datosTabla.consulta_valorString("select getdate() ")
        '-- lbl
        lblIdProducto.Text = 0
        lblCodigo.Text = 0
        lblMercaderia.Text = ""
        lblidForma.Text = 0
        lblPrecio.Text = 0
        '-- botones
        btnNuevo.Enabled = True
        btnAgregar.Enabled = False
        btnCargar.Enabled = False
        btnGuardar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
        '-- blanquear la tabla temporal
        sp_datosTabla.consulta_valor("delete from detFormaTmp where idConfig=" & intGl_idConfigPc)
        '-- listar
        listarFraccionado()

    End Sub

    Public Sub habilitarObjetos()
        '-- txt
        txtCantidad.ReadOnly = False
        txtCantidad.BackColor = Color.White
        txtPrecio.ReadOnly = False
        txtPrecio.BackColor = Color.White

        '-- botones
        btnAgregar.Enabled = True
        btnCargar.Enabled = True
        btnEliminar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        btnCancelar.Enabled = True

    End Sub

    Private Sub inicializarObjetos()
        '-- txt
        txtPrecio.Text = 0
        txtCantidad.Text = 0
        '-- lbl
        lblCodigo.Text = ""
        lblForma.Text = ""
        lblidForma.Text = 0
        lblIdProducto.Text = 0
        lblMercaderia.Text = ""
        lblPrecio.Text = 0

    End Sub
    Public Sub cargarFraccionado(ByVal v_idProducto As Integer)
        If (fun_guardarSp("sp_cargarDetFormaTmp", intGl_idConfigPc & "," & v_idProducto, Me.Name)) = 0 Then
            '-- no se guardo los registros

        End If
        datosMercaderia(v_idProducto)
        listarFraccionado()
    End Sub

    Private Sub datosMercaderia(ByVal v_idProducto As Integer)
        lblIdProducto.Text = v_idProducto
        lblCodigo.Text = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & v_idProducto)
        lblMercaderia.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)


    End Sub

    Private Sub listarFraccionado()
        systemClass.SqlToLv_detalleFraccionadoDetalle(lvFraccionado, "sp_consultaDetFormaTmp", intGl_idConfigPc)
    End Sub

    Private Sub agregarFracionado()
        If (fun_guardarSp("sp_agregarDetFormaTmp", intGl_idConfigPc & "," & CInt(lblidForma.Text) & "," & CInt(lblIdProducto.Text) & "," & CInt(txtCantidad.Text) & "," & CDbl(sacarComa(txtPrecio.Text)), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar el Registro en el detalle del Fraccionamiento...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            listarFraccionado()
            inicializarObjetos()
            btnGuardar.Focus()
        End If

    End Sub

    Private Sub guardarFraccion()
        If (fun_guardarSp("sp_guardarMercaderiaFraccionada", intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar el registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardaron con éxito los registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            limpiar()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        banGl_fraccionarMercaderia = True

        frmBuscarForma.txtId.Text = 0
        frmBuscarForma.txtBuscar.Text = ""

        Me.Enabled = False
        frmBuscarForma.Visible = True
        frmBuscarForma.BringToFront()
        frmBuscarForma.Show()
        frmBuscarForma.txtBuscar.Focus()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblForma.Text <> 0 Then
            '-- eliminar el registro de la tabla temporal
            sp_datosTabla.consulta_valor("delete from detFormaTmp where idForma=" & lblidForma.Text & " and idConfig=" & intGl_idConfigPc)
            '-- eliminar de la tabla
            sp_datosTabla.consulta_valor("delete from detForma where idForma=" & lblidForma.Text & " and idProducto=" & CInt(lblIdProducto.Text))
            '-- listar
            listarFraccionado()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea la forma de Fraccionar de esta mercaderia..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarFraccion()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        banGl_fraccionarMercaderia = True

        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = 0
        frmStock.Show()
        frmStock.BringToFront()
        frmStock.lvStock.Focus()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        '-- cargar el fraccionado
        agregarFracionado()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = txtNumerico(txtCantidad, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtCantidad.Text) = 0 Then
                txtCantidad.Text = 0
            End If
            '-- controlar si existe un pedido
            'If CInt(txtNroPedido.Text) > 0 Then
            '    If txtCantidad.Text >
            'End If
            e.Handled = True
            txtCantidad.Text = Format(CDec(txtCantidad.Text), "#,##0")

            txtPrecio.Focus()
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        e.Handled = txtNumerico(txtPrecio, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            If Len(txtPrecio.Text) = 0 Then
                txtPrecio.Text = 0
            End If
            e.Handled = True
            txtPrecio.Text = Format(CDec(txtPrecio.Text), "##,###,##0")

            btnCargar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmFraccionarMercaderia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiaMercaderiasFraccionar.Enabled = True
        e.Cancel = False
    End Sub
    '-----------------------------------------------------------------------------------------------------------------
End Class