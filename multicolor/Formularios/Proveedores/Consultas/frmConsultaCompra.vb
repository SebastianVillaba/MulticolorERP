Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmConsultaCompra
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
    Public Sub listarDetalleCompra(ByVal v_idcompra As Integer)
        systemClass.SqlToLv_detalleCompra(lvDetalleCompra, "sp_consultaDetalleCompra", v_idcompra & "," & chkNoImpreso.Checked)
        systemClass.SqlToLv_detalleCompraNotaCreditoCanje(lvCompra, "sp_consultaCompraNotaCreditoCanje", v_idcompra)
    End Sub

    Public Sub actualizarCabeceraCompra(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '**************'
            '-- LA COMPRA --'
            '**************'
            '-- el idCompra
            txtIdCompra.Text = v_idMov
            If chkNoImpreso.Checked = False Then
                '*************'
                '-- IMPRESO --'
                '*************'
                detalleCompraImp(v_idMov)
            Else
                '****************'
                '-- NO IMPRESO --'
                '****************'
                detalleCompraNoImp(v_idMov)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub detalleCompraImp(ByVal v_idmov As Integer)
        Try
            '***************************'
            '-- COLOCAR LA COTIZACION --'
            '***************************'
            '-- la moneda
            lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cabCompra", "idCompra", v_idmov))
            '-- la cotizacion
            lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cabCompra", "idCompra", v_idmov)
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
            douCotiza = sp_datosTabla.un_dato_double("cotizacion", "cabCompra", "idCompra", v_idmov)
            '***********************************************************************************************
            ' MsgBox("Valor de idCompra en la consulta  " & v_idmov)
            '-- el idcompra
            txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", v_idmov)
            '-- el proveedor
            txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cabcompra", "idCompra", v_idmov))
            txtTimbrado.Text = sp_datosTabla.consulta_valorString("select timbrado from cabCompra where idCompra=" & v_idmov)
            '-- dsuc
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cabCompra", "idCompra", v_idmov)
            '-- dcaja
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cabCompra", "idCompra", v_idmov)
            '-- factura
            txtFactura.Text = sp_datosTabla.un_datoString("factura", "cabCompra", "idCompra", v_idmov)
            '-- fecha de la factura
            txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cabCompra", "idCompra", v_idmov)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabCompra", "idCompra", v_idmov)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabCompra", "idCompra", v_idmov)
            '-- tipo de empresa
            lblTipoEmpresa.Text = sp_datosTabla.consulta_valorString("select nombreTipoSucursal from tipoSucursal where idTipoSucursal=" & sp_datosTabla.consulta_valor("select idTipoSucursal from cabCompra where idCompra=" & v_idmov))
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cabCompra", "idCompra", v_idmov) = True Then
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
                                                                    v_idmov & " and tipo='COMPRA'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='COMPRA'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idmov & _
                                                                   " and tipo='COMPRA'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- total compra
            txtTotalFactura.Text = (sp_datosTabla.un_dato_double("total", "cabCompra", "idCompra", v_idmov)) '* douCotiza)
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
            '-- total descuento
            txtTotalDescuento.Text = (sp_datosTabla.sp_string("sp_totalDescuentoCompra", v_idmov)) ' * douCotiza)
            If txtTotalDescuento.Text = "" Then
                txtTotalDescuento.Text = 0
            Else
                txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,###.00")
            End If
            '-- si ya está pagado
            If sp_datosTabla.un_dato_boleano("pagado", "cabCompra", "idCompra", v_idmov) = True Then
                lblPagado.Visible = True
            Else
                lblPagado.Visible = False
            End If
            '-- tipo de compra
            lblTipoCompra.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoCompra", "idTipoCompra", sp_datosTabla.un_dato_integer("idTipoCompra", "cabCompra", "idCompra", v_idmov))
            '-- si está controlado
            'If sp_datosTabla.un_dato_boleano("controlado", "cabCompra", "idCompra", v_idmov) = True Then
            '    lblControlado.Visible = True
            'Else
            '    lblControlado.Visible = False
            'End If
            '-- total iva 10
            txtIva10.Text = (sp_datosTabla.sp_string("sp_totalIVA10Compra", v_idmov)) ' * douCotiza)
            If txtIva10.Text = "" Then
                txtIva10.Text = 0
            Else
                txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,###.00")
            End If
            '-- total iva 5
            txtIva5.Text = (sp_datosTabla.sp_string("sp_totalIVA5Compra", v_idmov)) '* douCotiza)
            If txtIva5.Text = "" Then
                txtIva5.Text = 0
            Else
                txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,###.00")
            End If

            '-- total iva
            txtTotalIva.Text = CDec(txtIva10.Text) + CDec(txtIva5.Text)
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,###.00")
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cabCompra", "idCompra", v_idmov))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub detalleCompraNoImp(ByVal v_idmov As Integer)
        Try
            '***************************'
            '-- COLOCAR LA COTIZACION --'
            '***************************'
            '-- la moneda
            lblMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", sp_datosTabla.un_dato_integer("idMoneda", "cco", "idCompra", v_idmov))
            '-- la cotizacion
            lblCotiza.Text = sp_datosTabla.un_dato_double("cotizacion", "cco", "idCompra", v_idmov)
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "##,###.00")
            douCotiza = sp_datosTabla.un_dato_double("cotizacion", "cco", "idCompra", v_idmov)
            '***********************************************************************************************
            ' MsgBox("Valor de idCompra en la consulta  " & v_idmov)
            '-- el idcompra
            txtIdCompra.Text = sp_datosTabla.un_dato_integer("idCompra", "cco", "idCompra", v_idmov)
            '-- el proveedor
            txtProveedor.Text = sp_datosTabla.un_datoString("nombre", "v_proveedor", "idProveedor", sp_datosTabla.un_dato_integer("idProveedor", "cco", "idCompra", v_idmov))
            txtTimbrado.Text = sp_datosTabla.consulta_valorString("select timbrado from cco where idCompra=" & v_idmov)
            '-- dsuc
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "cco", "idCompra", v_idmov)
            '-- dcaja
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "cco", "idCompra", v_idmov)
            '-- factura
            txtFactura.Text = sp_datosTabla.un_datoString("factura", "cco", "idCompra", v_idmov)
            '-- fecha de la factura
            txtFechaFactura.Text = sp_datosTabla.un_datoString("fecha", "cco", "idCompra", v_idmov)
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cco", "idCompra", v_idmov)
            txtResponsableCarga.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cco", "idCompra", v_idmov)
            '-- tipo de empresa
            lblTipoEmpresa.Text = sp_datosTabla.consulta_valorString("select nombreTipoSucursal from tipoSucursal where idTipoSucursal=" & sp_datosTabla.consulta_valor("select idTipoSucursal from cco where idCompra=" & v_idmov))
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cco", "idCompra", v_idmov) = True Then
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
                                                                    v_idmov & " and tipo='COMPRA'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='COMPRA'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idmov & _
                                                                   " and tipo='COMPRA'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- total compra
            txtTotalFactura.Text = (sp_datosTabla.un_dato_double("total", "cco", "idCompra", v_idmov)) '* douCotiza)
            txtTotalFactura.Text = Format(CDec(txtTotalFactura.Text), "###,###,###.00")
            '-- total descuento
            txtTotalDescuento.Text = (sp_datosTabla.sp_string("sp_totalDescuentoCompra", v_idmov)) ' * douCotiza)
            If txtTotalDescuento.Text = "" Then
                txtTotalDescuento.Text = 0
            Else
                txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,###.00")
            End If
            '-- si ya está pagado
            If sp_datosTabla.un_dato_boleano("pagado", "cco", "idCompra", v_idmov) = True Then
                lblPagado.Visible = True
            Else
                lblPagado.Visible = False
            End If
            '-- tipo de compra
            lblTipoCompra.Text = sp_datosTabla.un_datoString("nombreTipo", "v_tipoCompra", "idTipoCompra", sp_datosTabla.un_dato_integer("idTipoCompra", "cco", "idCompra", v_idmov))
            '-- si está controlado
            'If sp_datosTabla.un_dato_boleano("controlado", "cco", "idCompra", v_idmov) = True Then
            '    lblControlado.Visible = True
            'Else
            '    lblControlado.Visible = False
            'End If
            '-- total iva 10
            txtIva10.Text = (sp_datosTabla.sp_string("sp_totalIVA10Compra", v_idmov)) ' * douCotiza)
            If txtIva10.Text = "" Then
                txtIva10.Text = 0
            Else
                txtIva10.Text = Format(CDec(txtIva10.Text), "###,###,###.00")
            End If
            '-- total iva 5
            txtIva5.Text = (sp_datosTabla.sp_string("sp_totalIVA5Compra", v_idmov)) '* douCotiza)
            If txtIva5.Text = "" Then
                txtIva5.Text = 0
            Else
                txtIva5.Text = Format(CDec(txtIva5.Text), "###,###,###.00")
            End If

            '-- total iva
            txtTotalIva.Text = CDec(txtIva10.Text) + CDec(txtIva5.Text)
            txtTotalIva.Text = Format(CDec(txtTotalIva.Text), "###,###,###.00")
            '-- el nombre de la empresa contable
            lblEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_personaJur", "idPersonaJur", sp_datosTabla.un_dato_integer("idPersonaJur", "cco", "idCompra", v_idmov))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub primerRegistro(ByVal v_idMov As Integer)
        '-- el primer registro

        actualizarCabeceraCompra(v_idMov)

        listarDetalleCompra(v_idMov)

        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True

    End Sub

    Private Sub anteriorRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        actualizarCabeceraCompra(v_idMov)

        listarDetalleCompra(v_idMov)
    End Sub

    Private Sub siguienteRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        actualizarCabeceraCompra(v_idMov)
        listarDetalleCompra(v_idMov)

    End Sub

    Private Sub ultimoRegistro(ByVal v_idcompra As Integer)
        '-- el ultimo registro
        listarDetalleCompra(v_idcompra)
        '-- la cabecera
        actualizarCabeceraCompra(v_idcompra)
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
        Dim intTmpIdCompra As Integer = 0
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            intTmpIdCompra = sp_datosTabla.consulta_valor("select max(idCompra) from cco")
        Else
            '-- impreso
            intTmpIdCompra = sp_datosTabla.consulta_valor("select max(idCompra) from cabCompra")
        End If
        ultimoRegistro(intTmpIdCompra)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdCompra As Integer = 0
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            intTmpIdCompra = sp_datosTabla.consulta_valor("select min(idCompra) from cco")
        Else
            '-- impreso
            intTmpIdCompra = sp_datosTabla.consulta_valor("select min(idCompra) from cabCompra")
        End If

        primerRegistro(intTmpIdCompra)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdCompra.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdCompra.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If chkNoImpreso.Checked = True Then
                    '-- no impreso
                    If (sp_datosTabla.un_dato_integer("idCompra", "cco", "idCompra", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                Else
                    '-- impreso
                    If (sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                End If

                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdCompra.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If chkNoImpreso.Checked = True Then
                '-- no impreso
                If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idCompra) from cco") Then
                    'MsgBox("PAso por aca")
                    btnAnterior.Enabled = False
                    btnPrimero.Enabled = False
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                    txtIdCompra.Text = sp_datosTabla.consulta_valor("select min(idCompra) from cco")
                Else
                    txtIdCompra.Text = intTmpIdMov
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                End If
            Else
                '-- impreso
                If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idCompra) from cabCompra") Then
                    'MsgBox("PAso por aca")
                    btnAnterior.Enabled = False
                    btnPrimero.Enabled = False
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                    txtIdCompra.Text = sp_datosTabla.consulta_valor("select min(idCompra) from cabCompra")
                Else
                    txtIdCompra.Text = intTmpIdMov
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                End If
            End If

            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdCompra.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdCompra.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idCompra
                If chkNoImpreso.Checked = True Then
                    '-- no impreso
                    If (sp_datosTabla.un_dato_integer("idCompra", "cco", "idCompra", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                Else
                    '-- impreso
                    If (sp_datosTabla.un_dato_integer("idCompra", "cabCompra", "idCompra", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                End If

                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdCompra.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If chkNoImpreso.Checked = True Then
                '-- no impreso
                If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idCompra) from cco") Then
                    btnSiguiente.Enabled = False
                    btnUltimo.Enabled = False
                    btnAnterior.Enabled = True
                    btnPrimero.Enabled = True
                    txtIdCompra.Text = sp_datosTabla.consulta_valor("select max(idCompra) from cco")
                Else
                    btnAnterior.Enabled = True
                    txtIdCompra.Text = intTmpIdMov
                End If
            Else
                '-- impreso
                If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idCompra) from cabCompra") Then
                    btnSiguiente.Enabled = False
                    btnUltimo.Enabled = False
                    btnAnterior.Enabled = True
                    btnPrimero.Enabled = True
                    txtIdCompra.Text = sp_datosTabla.consulta_valor("select max(idCompra) from cabCompra")
                Else
                    btnAnterior.Enabled = True
                    txtIdCompra.Text = intTmpIdMov
                End If
            End If

            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_consultaCompra = True
        Me.Enabled = False
        frmBuscarFacturaCompra.WindowState = FormWindowState.Normal
        frmBuscarFacturaCompra.Show()
        frmBuscarFacturaCompra.BringToFront()
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_anularCompra = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE COMPRAS"
        frmAnular.lblIdMov.Text = txtIdCompra.Text
        frmAnular.txtPass.Text = ""
        frmAnular.txtUsuario.Text = ""
        '----------------------------
        Me.Enabled = False
        frmAnular.WindowState = FormWindowState.Normal
        frmAnular.Show()
        frmAnular.BringToFront()
        frmAnular.txtUsuario.Focus()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idcompra As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_compra()
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idcompra.Value = CInt(txtIdCompra.Text)
        v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idcompra)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCompra").ApplyCurrentValues(pvParametros)
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
    End Sub
    '-----------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_compra = 0
        frmMenuPrincipal.proveedorConsultaFacturaCompra.Enabled = True
        e.Cancel = False
    End Sub

    Private Sub frmConsultaCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If banGl_buscarFacturaCompra = False Then
            Dim intTmpIdCompra As Integer = 0
            intTmpIdCompra = sp_datosTabla.consulta_valor("select max(idCompra) from cabCompra")
            ultimoRegistro(intTmpIdCompra)
            banGl_buscarFacturaCompra = 0
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
End Class