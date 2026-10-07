Public Class frmAbmTipo
    Private sp_tipo As New sp_tipo
    Private sp_datosTabla As New sp_datosTabla
    Private sp_obtenerDatosUsuario As New sp_obtenerDatosUsuario
    Private persona As New persona
    Private grupoCliente As New grupoCliente
    Dim intIdcargo As Integer
    Dim blNuevo As Boolean
    Dim systemClass As New SystemClass
    Dim strDatosOriginales As String

    '-- variables para el ajuste del formulario
    Dim ancho As Integer
    Dim alto As Integer
    'Variable para la primera ejecución y que no utilice el resize 
    Dim primero As Boolean

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
        listar("")
        'valorde del combo
    End Sub

    Sub deshabilitarObjetos() 'colocar como está originalmente
        '-- los txt
        txtNombre.Enabled = False
        txtNombre.BackColor = Color.LightSkyBlue
        '-- chk
        chkActivo.Enabled = False
        chkContado.Enabled = False
        chkImprimir.Enabled = False
        chkNoComi.Enabled = False
        chkPrimero.Enabled = False
        chkSinDescuento.Enabled = False
        chkTarjetaCredito.Enabled = False
        chkTarjetaDebito.Enabled = False
        chkTipoProducto.Enabled = False
        chkTipoVenta.Enabled = False
        chkVence.Enabled = False
        chkVenta.Enabled = False

        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True

        '-- los grupos
        grTipoProducto.Enabled = False
        grTipoVenta.Enabled = False
        '-- la seccion de busqueda
        grBuscar.Enabled = True
        txtBuscar.BackColor = Color.White

    End Sub

    Sub habilitarObjetos() 'colocar como para agregar datos
        '-- los txt
        txtNombre.Enabled = True
        txtNombre.BackColor = Color.White
        '-- chk
        chkActivo.Enabled = True
        chkContado.Enabled = True
        chkImprimir.Enabled = True
        chkNoComi.Enabled = True
        chkPrimero.Enabled = True
        chkSinDescuento.Enabled = True
        chkTarjetaCredito.Enabled = True
        chkTarjetaDebito.Enabled = True
        chkTipoProducto.Enabled = True
        chkTipoVenta.Enabled = True
        chkVence.Enabled = True
        chkVenta.Enabled = True

        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False

        '-- la seccion de busqueda
        grBuscar.Enabled = False
        txtBuscar.BackColor = Color.LightSkyBlue


    End Sub
    'listar
    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvTipo, "Select t.idTipo,t.nombreTipo from tipo t " & where)

        ' dimensionar las columnas
        lvTipo.Columns(0).Width = 50 'idpersona
        lvTipo.Columns(1).Width = 200 'nombre
        lvTipo.Scrollable = True
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        chkActivo.Checked = True
        chkActivo.Enabled = False
        'balnquear los objetos
        txtIdTipo.Text = 0
        txtFechaAlta.Text = ""
        txtFechaMod.Text = ""
        txtUsuarioAlta.Text = ""
        txtUsuarioMod.Text = ""
        txtNombre.Text = ""
        chkTipoProducto.Checked = False
        chkTipoVenta.Checked = False
        chkContado.Checked = False
        chkImprimir.Checked = False
        chkNoComi.Checked = False
        chkPrimero.Checked = False
        chkSinDescuento.Checked = False
        chkTarjetaCredito.Checked = False
        chkTarjetaDebito.Checked = False
        chkTipoProducto.Checked = False
        chkTipoVenta.Checked = False
        chkVence.Checked = False
        chkVenta.Checked = False

        txtNombre.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtIdTipo.Text = 0
        txtNombre.Text = ""
        txtFechaAlta.Text = ""
        txtFechaMod.Text = ""
        txtUsuarioAlta.Text = ""
        txtUsuarioMod.Text = ""
        chkActivo.Checked = False
        lvTipo.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        ' la variable para los tipos de producto
        Dim int_tipoProducto As Integer = 0
        Dim int_tipoVenta As Integer = 0
        '- tipo de producto
        If chkTipoProducto.Checked = True Then
            int_tipoProducto = 1
        End If
        '- tipo de venta
        If chkTipoVenta.Checked = True Then
            int_tipoVenta = 1
        End If

        'controlar si existe algun error
        'controlar el nombre
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar algún Nombre para el Tipo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'MsgBox("Paso por aca", MsgBoxStyle.Information)
        'MsgBox("Valor de la mascara  " & strFechaAni, MsgBoxStyle.Information)
        If blNuevo = True Then
            ' ver si la fecha está en blanco
            ' si es nuevo
            sp_tipo.insTipo(txtNombre.Text, intGl_idUsuario, False, chkVence.Checked, chkNoComi.Checked, chkSinDescuento.Checked, chkAcreditar.Checked, chkPrimero.Checked, chkTarjetaCredito.Checked, chkImprimir.Checked, chkCheque.Checked, chkVenta.Checked, chkTarjetaDebito.Checked, chkContado.Checked, 0, 0, 0, 0, int_tipoProducto, int_tipoVenta)
        Else
            ' si es una modificacion
            sp_tipo.UpdTipo(CInt(txtIdTipo.Text), txtNombre.Text, chkActivo.Checked, intGl_idUsuario, strDatosOriginales)
        End If
        deshabilitarObjetos()
        inicializar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        '        Me.Close()
        If txtNombre.Text = "" Then
            MessageBox.Show("Se debe mostrar el dato a modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ' cargar en la variable los datos originales
        strDatosOriginales = Trim(txtNombre.Text) & "," & Trim(chkActivo.Checked.ToString) & "," & Trim(intGl_idUsuario.ToString)
        blNuevo = False
        habilitarObjetos()
        grTipoProducto.Enabled = False
        grTipoVenta.Enabled = False
        chkTipoProducto.Enabled = False
        chkTipoVenta.Enabled = False
        txtNombre.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvTipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvTipo.KeyPress, lvTipo.KeyPress, lvTipo.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTipo.SelectedIndexChanged, lvTipo.SelectedIndexChanged
        For Each item As ListViewItem In lvTipo.SelectedItems
            txtIdTipo.Text = item.SubItems(0).Text
            txtNombre.Text = item.SubItems(1).Text
            chkActivo.Checked = sp_datosTabla.un_dato("activo", "tipo", "idtipo", CInt(item.SubItems(0).Text))
            txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "tipo", "idtipo", CInt(item.SubItems(0).Text))
            txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "tipo", "idtipo", CInt(item.SubItems(0).Text))
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioAlta", "tipo", "idtipo", CInt(item.SubItems(0).Text)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioMod", "tipo", "idtipo", CInt(item.SubItems(0).Text)))
            '-- datos relacionados
            '- tipo de producto
            chkTipoProducto.Checked = sp_datosTabla.un_dato_boleano("activo", "tipoProducto", "idtipo", CInt(item.SubItems(0).Text))
            chkVence.Checked = sp_datosTabla.un_dato_boleano("vence", "tipoProducto", "idtipo", CInt(item.SubItems(0).Text))
            chkNoComi.Checked = sp_datosTabla.un_dato_boleano("comision", "tipoProducto", "idtipo", CInt(item.SubItems(0).Text))
            '- tipo de venta
            chkTipoVenta.Checked = sp_datosTabla.un_dato_boleano("activo", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkSinDescuento.Checked = sp_datosTabla.un_dato_boleano("noDescuento", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkAcreditar.Checked = sp_datosTabla.un_dato_boleano("acreditar", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkImprimir.Checked = sp_datosTabla.un_dato_boleano("imprimir", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkPrimero.Checked = sp_datosTabla.un_dato_boleano("primero", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkTarjetaCredito.Checked = sp_datosTabla.un_dato_boleano("tarjeta", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkCheque.Checked = sp_datosTabla.un_dato_boleano("cheque", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkVenta.Checked = sp_datosTabla.un_dato_boleano("venta", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkTarjetaDebito.Checked = sp_datosTabla.un_dato_boleano("debito", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
            chkContado.Checked = sp_datosTabla.un_dato_boleano("contado", "tipoVenta", "idtipo", CInt(item.SubItems(0).Text))
        Next
        ' txtUsuarioAlta.Text = sp_obtenerDatosUsuario.nombreUsuario(intIdusuarioAlta)
        'strNombreUsuario = sp_obtenerDatosUsuario.nombreUsuario(4)
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If rdIdTipo.Checked = True Then
                ' ordenar por idcargo
                listar(" Where t.idTipo Like '" & txtBuscar.Text & "%' Or t.idTipo Like '" & txtBuscar.Text & "%' " & "order by t.idTipo")
            End If
            If rdNombre.Checked = True Then
                ' ordenar por nombre de cargo
                listar(" Where t.nombreTipo Like '" & txtBuscar.Text & "%' Or t.nombreTipo Like '" & txtBuscar.Text & "%' " & "order by t.nombreTipo")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvCargo.Select()
            'lvCargo.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdIdTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIdTipo.Click, rdIdTipo.Click
        listar(" Where t.nombreTipo <> '' " & " order by t.idTipo")
        'txtBuscar.Focus()
    End Sub

    Private Sub rdNombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNombre.Click
        listar(" Where t.nombreTipo <> '' " & " order by t.nombreTipo")
        'txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- CHECKBOX -'
    '*************'
    Private Sub chkTipoProdcuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoProducto.Click, chkTipoProducto.Click
        If chkTipoProducto.Checked = True Then
            grTipoProducto.Enabled = True
        Else
            grTipoProducto.Enabled = False
        End If
    End Sub

    Private Sub chkTipoVenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoVenta.Click, chkTipoVenta.Click
        If chkTipoVenta.Checked = True Then
            grTipoVenta.Enabled = True
        Else
            grTipoVenta.Enabled = False
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'  
    Private Sub frmAbmTipo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.abmTipo.Enabled = True
            e.Cancel = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------------
End Class