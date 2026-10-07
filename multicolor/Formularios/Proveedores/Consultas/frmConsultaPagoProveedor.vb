Public Class frmConsultaPagoProveedor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle(ByVal v_idMov As Integer)
        '-- detalle de los movimientos
        systemClass.SqlToLv_detallePagoProveedorMov(lvDetalleMov, "sp_consultaDetallePagoProveedorMovimiento", v_idMov)
        '-- detalle de los efectivos
        systemClass.SqlToLv_detallePagoProveedorEfectivo(lvDetalleEfectivo, "sp_consultaDetallePagoProveedorEfectivo", v_idMov)
        '-- detalle de los cheques
        systemClass.SqlToLv_detallePagoProveedorCheque(lvDetalleCheque, "sp_consultaDetallePagoProveedorCheque", v_idMov)

    End Sub

    Public Sub actualizarCabecera(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '******************'
            '-- LA RECEPCION --'
            '******************'
            '-- el idRecepcion
            txtIdPago.Text = v_idMov
            '-- el numero de factura y la fecha mas adelante
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabPagoProveedor", "idPagoProveedor", v_idMov)
            txtCargadoPor.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabPagoProveedor", "idPagoProveedor", v_idMov)
            '-- nombre de la pc
            txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & sp_datosTabla.consulta_valor _
            ("select idConfig from cabPagoProveedor where idPagoProveedor=" & v_idMov))
            '-- nombre de la sucursal donde se realizó la operación
            txtSucursal.Text = sp_datosTabla.consulta_valorString("select _vs.nombreFantasia from v_sucursal _vs where idSucursal=" & _
            sp_datosTabla.consulta_valor("select idSucursal from cabPagoProveedor where idPagoProveedor=" & v_idMov))
            '-- el total
            txtTotal.Text = sp_datosTabla.consulta_valorDouble("select totalPagado from cabPagoProveedor where idPagoProveedor=" & v_idMov)
            txtTotal.Text = Format(CDec(txtTotal.Text), "##,###,###.##")
            '-- nro de recibo
            txtNroRecibo.Text = sp_datosTabla.consulta_valor("select nroRecibo from cabPagoProveedor where idPagoProveedor=" & v_idMov)
            txtFecha.Text = sp_datosTabla.consulta_valorString("select fecha from cabPagoProveedor where idPagoProveedor=" & v_idMov)
            '-- el proveedor
            Dim intTmpIdProveedor As Integer
            intTmpIdProveedor = sp_datosTabla.consulta_valor("select idProveedor from cabPagoProveedor where idPagoProveedor=" & v_idMov)
            txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from v_proveedor where idProveedor=" & intTmpIdProveedor)
            '-- la empresa contable
            Dim intTmpIdPersonaJur As Integer
            intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabPagoProveedor where idPagoProveedor=" & v_idMov)

            lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresacontable where idPersonaJur=" & intTmpIdPersonaJur)
            If sp_datosTabla.consulta_valorBoolean("select activo from cabPagoProveedor where idPagoProveedor=" & v_idMov) = True Then
                lblEstado.Text = "NORMAL"
                btnAnular.Enabled = True
                lblEstado.ForeColor = Color.Green
            Else
                lblEstado.Text = "ANULADO"
                btnAnular.Enabled = False
                lblEstado.ForeColor = Color.Red
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try


    End Sub

    Private Sub primerRegistro(ByVal v_idMov As Integer)
        '-- el primer registro
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub anteriorRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
    End Sub

    Private Sub ultimoRegistro(ByVal v_idMov As Integer)
        '-- el ultimo registro
        listarDetalle(v_idMov)
        '-- la cabecera
        actualizarCabecera(v_idMov)
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select min(idPagoProveedor) from cabPagoProveedor")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select max(idPagoProveedor) from cabPagoProveedor")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdPago.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdPago.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idPagoProveedor", "cabPagoProveedor", "idPagoProveedor", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdPago.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idPagoProveedor) from cabPagoProveedor") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdPago.Text = sp_datosTabla.consulta_valor("select min(idPagoProveedor) from cabPagoProveedor")
            Else
                txtIdPago.Text = intTmpIdMov
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdPago.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdPago.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idPagoProveedor", "cabPagoProveedor", "idPagoProveedor", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdPago.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idPagoProveedor) from cabPagoProveedor") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdPago.Text = sp_datosTabla.consulta_valor("select max(idPagoProveedor) from cabPagoProveedor")
            Else
                btnAnterior.Enabled = True
                txtIdPago.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_buscarPagoProveedor = True
        Me.Enabled = False

        frmBuscarPagoProveedor.txtBuscar.Text = ""
        frmBuscarPagoProveedor.txtIdMov.Text = ""

        frmBuscarPagoProveedor.WindowState = FormWindowState.Normal
        frmBuscarPagoProveedor.Show()
        frmBuscarPagoProveedor.BringToFront()
        frmBuscarPagoProveedor.txtBuscar.Focus()

    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaPagoProveedor = True
        frmAnular.lblProcedimiento.Text = "ANULACION DEL PAGO A PROVEEDOR"
        frmAnular.lblIdMov.Text = txtIdPago.Text
        frmAnular.txtPass.Text = ""
        frmAnular.txtUsuario.Text = ""
        '----------------------------
        Me.Enabled = False
        frmAnular.WindowState = FormWindowState.Normal
        frmAnular.Show()
        frmAnular.BringToFront()
        frmAnular.txtUsuario.Focus()
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaPagoProveedor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If banGl_buscarPagoProveedor = False Then
            Dim intTmpIdMov As Integer = 0
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idPagoProveedor) from cabPagoProveedor")
            ultimoRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub frmConsultaPagoProveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.proveedorConsultaPagoProveedor.Enabled = True
        banGl_buscarPagoProveedor = False
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------
End Class