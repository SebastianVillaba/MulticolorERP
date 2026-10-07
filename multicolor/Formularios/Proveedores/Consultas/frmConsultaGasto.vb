Public Class frmConsultaGasto
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim douCotiza As Double

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle(ByVal v_idMov As Integer)
        systemClass.SqlToLv_detalleGastoProveedor(lvDetalleCompra, "sp_consultaDetalleGasto", v_idMov & "," & chkNoImpreso.Checked)
    End Sub

    Public Sub actualizarCabecera(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '**************'
            '-- LA COMPRA --'
            '**************'
            '-- el idCompra
            txtIdGasto.Text = v_idMov
            If chkNoImpreso.Checked = False Then
                '*************'
                '-- IMPRESO --'
                '*************'
                detalleImp(v_idMov)
            Else
                '****************'
                '-- NO IMPRESO --'
                '****************'
                detalleNoImp(v_idMov)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub detalleImp(ByVal v_idmov As Integer)
        Try
            '***************************'
            '-- COLOCAR LA COTIZACION --'
            '***************************'
            '-- la moneda
            lblMoneda.Text = Trim(sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cabGasto", "idGasto", v_idmov)))
            '-- la cotizacion
            lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cabGasto", "idGasto", v_idmov)
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
            douCotiza = sp_datosTabla.un_dato_double("cotizacion", "cabGasto", "idGasto", v_idmov)
            '***********************************************************************************************
            ' MsgBox("Valor de idGasto en la consulta  " & v_idmov)
            '-- el idGasto
            txtIdGasto.Text = sp_datosTabla.un_dato_integer("idGasto", "cabGasto", "idGasto", v_idmov)
            '-- el proveedor
            txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cabGasto", "idGasto", v_idmov))
            '-- dsuc
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabGasto", "idGasto", v_idmov)
            '-- dcaja
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabGasto", "idGasto", v_idmov)
            '-- factura
            txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabGasto", "idGasto", v_idmov)
            '-- fecha de la factura
            txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabGasto", "idGasto", v_idmov)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabGasto", "idGasto", v_idmov)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabGasto", "idGasto", v_idmov)
            '-- tipo de empresa
            lblTipoEmpresa.Text = sp_datosTabla.consulta_valorString("select nombreTipoSucursal from tipoSucursal where idTipoSucursal=" & sp_datosTabla.consulta_valor("select idTipoSucursal from cabGasto where idGasto=" & v_idmov))
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cabGasto", "idGasto", v_idmov) = True Then
                '-- si no está anulado
                btnAnular.Enabled = True
                lblEstado.Text = "NORMAL"
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
                lblEstado.ForeColor = Color.Red
                '--- datos de la anulacion
                Dim intTmpIdUsuarioAnulado As Integer
                intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='GASTOPROV'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='GASTOPROV'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idmov & _
                                                                   " and tipo='GASTOPROV'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- total compra
            txtTotalFactura.Text = (sp_datosTabla.un_dato_double("total", "cabGasto", "idGasto", v_idmov)) '* douCotiza)
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
            '-- si ya está pagado
            If sp_datosTabla.un_dato_boleano("pagado", "cabGasto", "idGasto", v_idmov) = True Then
                lblPagado.Visible = True
                btnAnular.Enabled = False
            Else
                lblPagado.Visible = False
                btnAnular.Enabled = True
            End If
            '-- tipo de compra
            lblTipoCompra.Text = Trim(sp_datosTabla.un_datoString("nombreTipo", "v_tipoCompra", "idTipoCompra", sp_datosTabla.un_dato_integer("idTipoCompra", "cabGasto", "idGasto", v_idmov)))
            '-- si está controlado
            If sp_datosTabla.un_dato_boleano("controlado", "cabGasto", "idGasto", v_idmov) = True Then
                lblControlado.Visible = True
            Else
                lblControlado.Visible = False
            End If
            '-- total iva 10
            txtIva10.Text = (sp_datosTabla.sp_string("sp_totalIVA10Gasto", v_idmov)) ' * douCotiza)
            If txtIva10.Text = "" Then
                txtIva10.Text = 0
            Else
                txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,###.00")
            End If
            '-- total iva 5
            txtIva5.Text = (sp_datosTabla.sp_string("sp_totalIVA5Gasto", v_idmov)) '* douCotiza)
            If txtIva5.Text = "" Then
                txtIva5.Text = 0
            Else
                txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,###.00")
            End If

            '-- total iva
            txtTotalIva.Text = CDec(txtIva10.Text) + CDec(txtIva5.Text)
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,###.00")
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabGasto", "idGasto", v_idmov))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub detalleNoImp(ByVal v_idmov As Integer)
        Try
            ' MsgBox("Paso por aca" & v_idmov)
            '***************************'
            '-- COLOCAR LA COTIZACION --'
            '***************************'
            '-- la moneda
            lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cga", "idGasto", v_idmov))
            '-- la cotizacion
            lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cga", "idGasto", v_idmov)
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
            douCotiza = sp_datosTabla.un_dato_double("cotizacion", "cga", "idGasto", v_idmov)
            '***********************************************************************************************
            ' MsgBox("Valor de idGasto en la consulta  " & v_idmov)
            '-- el idGasto
            txtIdGasto.Text = sp_datosTabla.un_dato_integer("idGasto", "cga", "idGasto", v_idmov)
            '-- el proveedor
            txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cga", "idGasto", v_idmov))
            '-- dsuc
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cga", "idGasto", v_idmov)
            '-- dcaja
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cga", "idGasto", v_idmov)
            '-- factura
            txtFactura.Text = sp_datosTabla.un_datoString("factura", "cga", "idGasto", v_idmov)
            '-- fecha de la factura
            txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cga", "idGasto", v_idmov)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cga", "idGasto", v_idmov)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cga", "idGasto", v_idmov)
            '-- tipo de empresa
            lblTipoEmpresa.Text = sp_datosTabla.consulta_valorString("select nombreTipoSucursal from tipoSucursal where idTipoSucursal=" & sp_datosTabla.consulta_valor("select idTipoSucursal from cga where idGasto=" & v_idmov))
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cga", "idGasto", v_idmov) = True Then
                '-- si no está anulado
                btnAnular.Enabled = True
                lblEstado.Text = "NORMAL"
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
                lblEstado.ForeColor = Color.Red
                '--- datos de la anulacion
                Dim intTmpIdUsuarioAnulado As Integer
                intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='GASTOPROV'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='GASTOPROV'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idmov & _
                                                                   " and tipo='GASTOPROV'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- total compra
            txtTotalFactura.Text = (sp_datosTabla.un_dato_double("total", "cga", "idGasto", v_idmov)) '* douCotiza)
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
            '-- si ya está pagado
            If sp_datosTabla.un_dato_boleano("pagado", "cga", "idGasto", v_idmov) = True Then
                lblPagado.Visible = True
            Else
                lblPagado.Visible = False
            End If
            '-- tipo de compra
            lblTipoCompra.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoCompra", "idTipoCompra", sp_datosTabla.un_dato_integer("idTipoCompra", "cga", "idGasto", v_idmov))
            '-- si está controlado
            If sp_datosTabla.un_dato_boleano("controlado", "cga", "idGasto", v_idmov) = True Then
                lblControlado.Visible = True
            Else
                lblControlado.Visible = False
            End If
            '-- total iva 10
            txtIva10.Text = (sp_datosTabla.sp_string("sp_totalIVA10Gasto", v_idmov)) ' * douCotiza)
            If txtIva10.Text = "" Then
                txtIva10.Text = 0
            Else
                txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,###.00")
            End If
            '-- total iva 5
            txtIva5.Text = (sp_datosTabla.sp_string("sp_totalIVA5Gasto", v_idmov)) '* douCotiza)
            If txtIva5.Text = "" Then
                txtIva5.Text = 0
            Else
                txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,###.00")
            End If

            '-- total iva
            txtTotalIva.Text = CDec(txtIva10.Text) + CDec(txtIva5.Text)
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,###.00")
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cga", "idGasto", v_idmov))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub primerRegistro(ByVal v_idMov As Integer)
        '-- el primer registro

        actualizarCabecera(v_idMov)

        listarDetalle(v_idMov)

        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True

    End Sub

    Private Sub anteriorRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        actualizarCabecera(v_idMov)

        listarDetalle(v_idMov)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        actualizarCabecera(v_idMov)
        listarDetalle(v_idMov)

    End Sub

    Private Sub ultimoRegistro(ByVal v_idcompra As Integer)
        '-- el ultimo registro
        listarDetalle(v_idcompra)
        '-- la cabecera
        actualizarCabecera(v_idcompra)
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub
    '-------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdGasto As Integer = 0
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            intTmpIdGasto = sp_datosTabla.consulta_valor("select max(idGasto) from cga")
        Else
            '-- impreso
            intTmpIdGasto = sp_datosTabla.consulta_valor("select max(idGasto) from cabGasto")
        End If
        'MsgBox("Valor de intTmpIdGasto   " & intTmpIdGasto)
        ultimoRegistro(intTmpIdGasto)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdGasto As Integer = 0
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            intTmpIdGasto = sp_datosTabla.consulta_valor("select min(idGasto) from cga")
        Else
            '-- impreso
            intTmpIdGasto = sp_datosTabla.consulta_valor("select min(idGasto) from cabGasto")
        End If

        primerRegistro(intTmpIdGasto)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdGasto.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdGasto.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If chkNoImpreso.Checked = True Then
                    '-- no impreso
                    If (sp_datosTabla.un_dato_integer("idGasto", "cga", "idGasto", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                Else
                    '-- impreso
                    If (sp_datosTabla.un_dato_integer("idGasto", "cabGasto", "idGasto", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                End If

                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdGasto.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If chkNoImpreso.Checked = True Then
                '-- no impreso
                If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idGasto) from cga") Then
                    'MsgBox("PAso por aca")
                    btnAnterior.Enabled = False
                    btnPrimero.Enabled = False
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                    txtIdGasto.Text = sp_datosTabla.consulta_valor("select min(idGasto) from cga")
                Else
                    txtIdGasto.Text = intTmpIdMov
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                End If
            Else
                '-- impreso
                If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idGasto) from cabGasto") Then
                    'MsgBox("Paso por aca")
                    btnAnterior.Enabled = False
                    btnPrimero.Enabled = False
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                    txtIdGasto.Text = sp_datosTabla.consulta_valor("select min(idGasto) from cabGasto")
                Else
                    txtIdGasto.Text = intTmpIdMov
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                End If
            End If

            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdGasto.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdGasto.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idCompra
                If chkNoImpreso.Checked = True Then
                    '-- no impreso
                    If (sp_datosTabla.un_dato_integer("idGasto", "cga", "idGasto", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                Else
                    '-- impreso
                    If (sp_datosTabla.un_dato_integer("idGasto", "cabGasto", "idGasto", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                End If

                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdGasto.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If chkNoImpreso.Checked = True Then
                '-- no impreso
                If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idGasto) from cga") Then
                    btnSiguiente.Enabled = False
                    btnUltimo.Enabled = False
                    btnAnterior.Enabled = True
                    btnPrimero.Enabled = True
                    txtIdGasto.Text = sp_datosTabla.consulta_valor("select max(idGasto) from cga")
                Else
                    btnAnterior.Enabled = True
                    txtIdGasto.Text = intTmpIdMov
                End If
            Else
                '-- impreso
                If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idGasto) from cabGasto") Then
                    btnSiguiente.Enabled = False
                    btnUltimo.Enabled = False
                    btnAnterior.Enabled = True
                    btnPrimero.Enabled = True
                    txtIdGasto.Text = sp_datosTabla.consulta_valor("select max(idGasto) from cabGasto")
                Else
                    btnAnterior.Enabled = True
                    txtIdGasto.Text = intTmpIdMov
                End If
            End If

            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_consultaGastoProveedor = True
        Me.Enabled = False
        frmBuscarGastoProveedor.WindowState = FormWindowState.Normal
        frmBuscarGastoProveedor.Show()
        frmBuscarGastoProveedor.BringToFront()
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaGastoProveedor = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE GASTOS"
        frmAnular.lblIdMov.Text = txtIdGasto.Text
        frmAnular.txtPass.Text = ""
        frmAnular.txtUsuario.Text = ""
        '----------------------------
        Me.Enabled = False
        frmAnular.WindowState = FormWindowState.Normal
        frmAnular.Show()
        frmAnular.BringToFront()
        frmAnular.txtUsuario.Focus()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    '-----------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaGasto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.proveedorConsultaGasto.Enabled = True
        e.Cancel = False
    End Sub

    Private Sub frmConsultaCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If banGl_buscarGastoProveedor = False Then
            Dim intTmpIdGasto As Integer = 0
            intTmpIdGasto = sp_datosTabla.consulta_valor("select max(idGasto) from cabGasto")
            ultimoRegistro(intTmpIdGasto)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
End Class