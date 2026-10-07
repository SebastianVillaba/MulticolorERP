Public Class frmConsultaRetencionProveedor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalleRetencion(ByVal v_idMov As Integer)
        systemClass.SqlToLv_detalleConsultaRetencionProveedor(lvRetencion, "sp_consultaDetRetencionProveedor", v_idMov)
    End Sub

    Private Sub primerRegistro(ByVal v_idMov As Integer)
        '-- el primer registro
        listarDetalleRetencion(v_idMov)
        '-- la cabecera
        actualizarCabeceraRetencion(v_idMov)
    End Sub

    Private Sub anteriorRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        listarDetalleRetencion(v_idMov)
        '-- la cabecera
        actualizarCabeceraRetencion(v_idMov)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        listarDetalleRetencion(v_idMov)
        '-- la cabecera
        actualizarCabeceraRetencion(v_idMov)
    End Sub

    Private Sub ultimoRegistro(ByVal v_idMov As Integer)
        '-- el ultimo registro
        listarDetalleRetencion(v_idMov)
        '-- la cabecera
        actualizarCabeceraRetencion(v_idMov)
    End Sub

    Public Sub actualizarCabeceraRetencion(ByVal v_idMov As Integer)
        ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
        '***********************'
        '-- RETENCION DE VENTA--'
        '***********************'
        '-- idNotaCredito
        txtIdRetencion.Text = v_idMov
        '-- nombre del proveedor
        txtCliente.Text = sp_datosTabla.consulta_valorString("select _vp.nombre from cabRetencionProveedor cr inner join v_proveedor _vp on " & _
                        " cr.idProveedor=_vp.idProveedor where cr.idRetencionProveedor=" & v_idMov)
        '-- ruc del cliente
        txtRuc.Text = sp_datosTabla.consulta_valorString("select _vp.ruc from cabRetencionProveedor cr inner join v_proveedor _vp on " & _
                        " cr.idProveedor=_vp.idProveedor where cr.idRetencionProveedor=" & v_idMov)
        '-- nro de la factura
        txtDsucN.Text = sp_datosTabla.un_datoString("dsuc", "cabRetencionProveedor", "idRetencionProveedor", v_idMov)
        txtDcajaN.Text = sp_datosTabla.un_datoString("dcaja", "cabRetencionProveedor", "idRetencionProveedor", v_idMov)
        txtFacturaN.Text = sp_datosTabla.un_datoString("factura", "cabRetencionProveedor", "idRetencionProveedor", v_idMov)
        '-- fecha de la factura
        txtFechaN.Text = sp_datosTabla.un_datoString("fecha", "cabRetencionProveedor", "idRetencionProveedor", v_idMov)
        '-- responsable de la carga
        Dim intTmpIdUsuario As Integer = 0
        intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabRetencionProveedor", "idRetencionProveedor", v_idMov)
        txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
        '-- fecha y hora de carga
        txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabRetencionProveedor", "idRetencionProveedor", v_idMov)
        '-- el estado
        If sp_datosTabla.un_dato_boleano("activo", "cabRetencionProveedor", "idRetencionProveedor", v_idMov) = True Then
            '-- si no está anulado
            btnAnular.Enabled = True
            lblEstado.Text = "NORMAL"
            btnAnular.Enabled = True
            lblEstado.ForeColor = Color.Green
            '-- datos de la anulacion
            txtAnuladoPor.Text = ""
            txtFechaAnulado.Text = ""
            txtExplica.Text = ""
            '---------------------------------------------------------------------------------------------------------------------
        Else
            '-- si está anulado
            btnAnular.Enabled = False
            lblEstado.Text = "ANULADO"
            btnAnular.Enabled = False
            lblEstado.ForeColor = Color.Red
            '--- datos de la anulacion
            Dim intTmpIdUsuarioAnulado As Integer
            intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                v_idMov & " and tipo='RETECOM'")
            txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                 "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
            txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                v_idMov & " and tipo='RETECOM'")
            txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idMov & _
                                                               " and tipo='RETECOM'")
            '---------------------------------------------------------------------------------------------------------------------
        End If
        '-- total de la retencion
        txtTotalFactura.Text = sp_datosTabla.consulta_valor("select total from cabRetencionProveedor where idRetencionProveedor=" & v_idMov)
        txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###")

        '-- el nombre de la empresa contable
        Dim intTmpIdPersonaJur As Integer
        intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabRetencionProveedor where idRetencionProveedor=" & v_idMov)
        lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & intTmpIdPersonaJur)

    End Sub
    '---------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdRetencion As Integer = 0
        intTmpIdRetencion = sp_datosTabla.consulta_valor("select min(idRetencionProveedor) from cabRetencionProveedor")
        ultimoRegistro(intTmpIdRetencion)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdRetencion As Integer = 0
        intTmpIdRetencion = sp_datosTabla.consulta_valor("select max(idRetencionProveedor) from cabRetencionProveedor")
        ultimoRegistro(intTmpIdRetencion)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdRetencion.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdRetencion.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idRetencionProveedor", "cabRetencionProveedor", "idRetencionProveedor", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdRetencion.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idRetencionProveedor) from cabRetencionProveedor") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdRetencion.Text = sp_datosTabla.consulta_valor("select min(idRetencionProveedor) from cabRetencionProveedor")
            Else
                txtIdRetencion.Text = intTmpIdMov
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdMov)
        End If

    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdRetencion.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdRetencion.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idRetencionProveedor", "cabRetencionProveedor", "idRetencionProveedor", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdRetencion.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idRetencionProveedor) from cabRetencionProveedor") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdRetencion.Text = sp_datosTabla.consulta_valor("select max(idRetencionProveedor) from cabRetencionProveedor")
            Else
                btnAnterior.Enabled = True
                txtIdRetencion.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaRetencionProveedor = True

        frmAnular.lblProcedimiento.Text = "ANULACION DE RETENCION DEL PROVEEDOR"
        frmAnular.lblIdMov.Text = txtIdRetencion.Text
        frmAnular.txtPass.Text = ""
        frmAnular.txtUsuario.Text = ""
        '----------------------------
        Me.Enabled = False
        frmAnular.WindowState = FormWindowState.Normal
        frmAnular.Show()
        frmAnular.BringToFront()
        frmAnular.txtUsuario.Focus()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_consultaRetencionProveedor = True
        Me.Enabled = False

        'MsgBox("Valor de la variable " & banGl_consultaRetencionVenta)

        frmBuscarRetencionProveedor.WindowState = FormWindowState.Normal
        frmBuscarRetencionProveedor.Show()
        frmBuscarRetencionProveedor.BringToFront()
    End Sub
    '---------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmConsultaRetencionCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.proveedorConsultaRetencion.Enabled = True
        e.Cancel = False
    End Sub

    Private Sub frmConsultaDevolucionVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If banGl_buscarRetencionProveedor = False Then
            Dim intTmpIdRetencion As Integer = 0
            intTmpIdRetencion = sp_datosTabla.consulta_valor("select max(idRetencionProveedor) from cabRetencionProveedor")
            ultimoRegistro(intTmpIdRetencion)
            banGl_buscarNotaCredito = 0
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------
End Class