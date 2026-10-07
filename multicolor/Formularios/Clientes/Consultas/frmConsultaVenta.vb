Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography
Imports ZXing
'Imports OC.Core.Crypto
Imports System.Net
'Imports System.Text.UTF8Encoding

'Imports System
'Imports System.Text
'Imports Bo

Public Class frmConsultaVenta
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Private printFont As Font
    Private streamToPrint As StreamReader

    Dim intIdVenta As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalle(ByVal v_idMov As Integer, ByVal v_tipo As Integer)
        systemClass.SqlToLv_detalleConsultaVenta(lvProducto, "sp_consultaDetalleVentaFull", v_idMov & "," & v_tipo)
    End Sub

    Public Sub actualizarCabecera(ByVal v_idMov As Integer, ByVal v_tipo As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '**************'
            '-- LA VENTA --'
            '**************'
            '-- el idVenta
            txtIdVenta.Text = v_idMov
            intIdVenta = v_idMov
            If v_tipo = 1 Then
                '*************'
                '-- IMPRESO --'
                '*************'
                datosVentaImp(v_idMov)
            Else
                '****************'
                '-- NO IMPRESO --'
                '****************'
                datosVentaNoImp(v_idMov)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try


    End Sub

    Private Sub primerRegistro(ByVal v_idMov As Integer)
        '-- la cabecera
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            actualizarCabecera(v_idMov, 2)
            '-- el primer registro
            listarDetalle(v_idMov, 2)
        Else
            '-- impreso
            actualizarCabecera(v_idMov, 1)
            '-- el primer registro
            listarDetalle(v_idMov, 1)
        End If
        '-- deshabilitar los botones
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        '-- habilitar los demas
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub anteriorRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        '-- la cabecera
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            actualizarCabecera(v_idMov, 2)
            listarDetalle(v_idMov, 2)
        Else
            '-- impreso
            actualizarCabecera(v_idMov, 1)
            listarDetalle(v_idMov, 1)
        End If
    End Sub

    Private Sub siguienteRegistro(ByVal v_idMov As Integer)
        '-- el registro anterior
        '-- la cabecera
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            actualizarCabecera(v_idMov, 2)
            listarDetalle(v_idMov, 2)
        Else
            '-- impreso
            actualizarCabecera(v_idMov, 1)
            listarDetalle(v_idMov, 1)
        End If
    End Sub

    Private Sub ultimoRegistro(ByVal v_idMov As Integer)
        '-- el ultimo registro
        '-- la cabecera
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            actualizarCabecera(v_idMov, 2)
            listarDetalle(v_idMov, 2)
        Else
            '-- impreso
            actualizarCabecera(v_idMov, 1)
            listarDetalle(v_idMov, 1)
        End If
        '-- deshablitar los botones
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        '-- habilitar los botones
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
    End Sub

    Private Sub datosVentaImp(ByVal v_idmov As Integer)
        Try
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabVenta where idVenta=" & v_idmov)
            '-- pc
            Dim intTmpIdConfig As Integer
            intTmpIdConfig = sp_datosTabla.consulta_valor("select idConfigPc from cabVenta where idVenta=" & v_idmov)
            txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & intTmpIdConfig)
            '-- sucursal
            Dim intTmpIdSucursal As Integer
            intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & v_idmov)
            txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursalT where idSucursal=" & intTmpIdSucursal)
            '-- vendedor
            Dim intTmpIdVendedor As Integer
            intTmpIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & v_idmov)
            txtVendedor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_vendedorT where idVendedor=" & intTmpIdVendedor)
            '-- total de la venta
            txtTotal.Text = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & v_idmov)
            txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,##0")
            '-- total descuento
            txtTotalDescuento.Text = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabVenta where idVenta=" & v_idmov)
            txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,##0")
            '-- estado
            If sp_datosTabla.consulta_valorBoolean("select activo from cabVenta where idVenta=" & v_idmov) = True Then
                lblEstado.Text = "NORMAL"
                lblEstado.ForeColor = Color.Green
                btnAnular.Enabled = True
                '-- datos de la anulacion
                txtAnuladoPor.Text = ""
                txtFechaAnulado.Text = ""
                txtExplica.Text = ""
                '---------------------------------------------------------------------------------------------------------------------
            Else
                lblEstado.Text = "ANULADO"
                lblEstado.ForeColor = Color.Red
                btnAnular.Enabled = False
                '--- datos de la anulacion
                Dim intTmpIdUsuarioAnulado As Integer
                intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='VENTA'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='VENTA'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idmov & _
                                                                   " and tipo='VENTA'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- si está cobrado
            If sp_datosTabla.consulta_valor("select cco.idCobro from cabCobro cco inner join detCobro dco on cco.idCobro=dco.idCobro " & _
                                " inner join detCuota dcu on dcu.idCuota=dco.idCuota and dcu.nroCuota=dco.nroCuota " & _
                                " inner join cabCuota ccu on ccu.idCuota=dcu.idCuota where ccu.idMovimiento=" & v_idmov & _
                                " and cco.activo=1 and ccu.tipo=1") > 0 Then
                lblCobrado.Visible = True
            Else
                lblCobrado.Visible = False
            End If
            '-- si está controlado
            If sp_datosTabla.consulta_valor("select idVenta from cabVenta where idVenta=" & v_idmov & " and controlado=1") > 0 Then
                lblControlado.Visible = True
            Else
                lblControlado.Visible = False
            End If
            '-- nombre de la obra
            txtObra.Text = sp_datosTabla.consulta_valorString("select nombreObra from cabVenta where idVenta=" & v_idmov)
            '-- tipo de venta
            If sp_datosTabla.consulta_valor("select idVenta from cabVenta where tipof=1 and idVenta=" & v_idmov) = 0 Then
                lblTipoVenta.Text = "VTA. MOSTRADOR"
                txtObra.Text = ""
            Else
                '-- datos del delivery
                lblTipoVenta.Text = "DELIVERY"
                Dim intTmpIdUsuarioDelivery As Integer
                intTmpIdUsuarioDelivery = sp_datosTabla.consulta_valor("select idRepartidor from cabVenta where idVenta=" & v_idmov)
            End If
            '-- factura
            txtDsuc.Text = sp_datosTabla.consulta_valorString("select dsuc from cabVenta where idVenta=" & v_idmov)
            txtDcaja.Text = sp_datosTabla.consulta_valorString("select dcaja from cabVenta where idVenta=" & v_idmov)
            txtFactura.Text = sp_datosTabla.consulta_valorString("select factura from cabVenta where idVenta=" & v_idmov)
            '-- forma de venta
            Dim intTmpIdTipoVenta As Integer
            intTmpIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoventa from cabVenta where idVenta=" & v_idmov)
            lblFormaventa.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoVenta where idTipoVenta=" & intTmpIdTipoVenta)
            '-- si tiene una devolucion
            If sp_datosTabla.consulta_valor("select idVenta from cabNotaDebito where idVenta=" & v_idmov) > 0 Then
                Dim intTmpIdNotaDebito As Integer
                intTmpIdNotaDebito = sp_datosTabla.consulta_valor("select idNotaDebito from cabNotaDebito where idVenta=" & v_idmov)
                '-- datos de la devolucion
                lblDevolucion.Visible = True
                txtDsucDev.Text = sp_datosTabla.consulta_valorString("select dsuc from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtDcajaDev.Text = sp_datosTabla.consulta_valorString("select dcaja from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtFacturaDev.Text = sp_datosTabla.consulta_valorString("select factura from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtTotalDev.Text = sp_datosTabla.consulta_valorDouble("select total from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtTotalDev.Text = Format(CDec(txtTotalDev.Text), "###,###,##0")
                Dim intTmpIdUsuarioDev As Integer
                intTmpIdUsuarioDev = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtResponsableDev.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                          "v_usuarioT where idUsuario=" & intTmpIdUsuarioDev)
            Else
                '-- sin devolucion
                lblDevolucion.Visible = False
                txtDsucDev.Text = ""
                txtDcajaDev.Text = ""
                txtFacturaDev.Text = ""
                txtTotalDev.Text = 0
                txtResponsableDev.Text = ""
            End If
            '-- idClienta
            txtIdCliente.Text = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & v_idmov)
            '-- cliente
            txtCliente.Text = sp_datosTabla.consulta_valorString("select cliente from cabVenta where idVenta=" & v_idmov)
            '-- ruc
            txtRuc.Text = sp_datosTabla.consulta_valorString("select ruc from cabVenta where idVenta=" & v_idmov)
            '-- correo
            txtCorreo.Text = sp_datosTabla.consulta_valorString("select p.email1 from cabVenta cv inner join v_cliente _vc on cv.idCliente=_vc.idCliente " & _
                                                                " inner join persona p on p.idPersona=_vc.idPersona where cv.idVenta=" & v_idmov)
            '-- grupo de cliente
            Dim intTmpIdGrupoCliente As Integer
            intTmpIdGrupoCliente = sp_datosTabla.consulta_valor("select idGrupoCliente from cliente where idCliente=" & CInt(txtIdCliente.Text))
            txtGrupoCliente.Text = sp_datosTabla.consulta_valorString("select nombreGrupoCliente from grupoCliente where idGrupoCliente=" & intTmpIdGrupoCliente)
            '-- empresa contable
            Dim intTmpIdPersonaJur As Integer
            intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & v_idmov)
            lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & intTmpIdPersonaJur)
            '-- el CDC
            txtCdc.Text = sp_datosTabla.consulta_valorString("select cdc from detVentaDTE where idventa=" & v_idmov)
            '-- aprobado por la sifen
            If sp_datosTabla.consulta_valor("select transaction_id from RCV_TRX_EB_BATCH_ITEMS r inner join tmpFactuDE_A tmp on r.transaction_id=tmp.idMov " & _
                                            " where r.result_status='Aprobado' and tmp.idTransa=" & v_idmov) > 0 Then
                '-- aprobado
                lblAprobadoSifen.Visible = True
            Else
                '-- no aprobado
                lblAprobadoSifen.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub datosVentaNoImp(ByVal v_idmov As Integer)
        Try
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cve where idVenta=" & v_idmov)
            '-- pc
            Dim intTmpIdConfig As Integer
            intTmpIdConfig = sp_datosTabla.consulta_valor("select idConfigPc from cve where idVenta=" & v_idmov)
            txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & intTmpIdConfig)
            '-- sucursal
            Dim intTmpIdSucursal As Integer
            intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cve where idVenta=" & v_idmov)
            txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursalT where idSucursal=" & intTmpIdSucursal)
            '-- vendedor
            Dim intTmpIdVendedor As Integer
            intTmpIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cve where idVenta=" & v_idmov)
            txtVendedor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_vendedorT where idVendedor=" & intTmpIdVendedor)
            '-- total de la venta
            txtTotal.Text = sp_datosTabla.consulta_valorDouble("select totalVenta from cve where idVenta=" & v_idmov)
            txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,##0")
            '-- total descuento
            txtTotalDescuento.Text = sp_datosTabla.consulta_valorDouble("select totalDescuento from cve where idVenta=" & v_idmov)
            txtTotalDescuento.Text = Format(CDec(txtTotalDescuento.Text), "###,###,##0")
            '-- estado
            If sp_datosTabla.consulta_valorBoolean("select activo from cve where idVenta=" & v_idmov) = True Then
                lblEstado.Text = "NORMAL"
                lblEstado.ForeColor = Color.Green
                btnAnular.Enabled = True
                txtAnuladoPor.Text = ""
                txtFechaAnulado.Text = ""
            Else
                lblEstado.Text = "ANULADO"
                lblEstado.ForeColor = Color.Red
                btnAnular.Enabled = False
                '--- datos de la anulacion
                Dim intTmpIdUsuarioAnulado As Integer
                intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='VENTA'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idmov & " and tipo='VENTA'")
            End If
            '-- tipo de venta
            If sp_datosTabla.consulta_valor("select tipo from cve where idVenta=" & v_idmov) = 1 Then
                lblTipoVenta.Text = "VTA. MOSTRADOR"
            Else
                '-- datos del delivery
                lblTipoVenta.Text = "DELIVERY"
                Dim intTmpIdUsuarioDelivery As Integer
                intTmpIdUsuarioDelivery = sp_datosTabla.consulta_valor("select idRepartidor from cve where idVenta=" & v_idmov)
            End If
            '-- factura
            txtDsuc.Text = sp_datosTabla.consulta_valorString("select dsuc from cve where idVenta=" & v_idmov)
            txtDcaja.Text = sp_datosTabla.consulta_valorString("select dcaja from cve where idVenta=" & v_idmov)
            txtFactura.Text = sp_datosTabla.consulta_valorString("select factura from cve where idVenta=" & v_idmov)
            '-- forma de venta
            Dim intTmpIdTipoVenta As Integer
            intTmpIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoventa from cve where idVenta=" & v_idmov)
            lblFormaventa.Text = sp_datosTabla.consulta_valorString("select nombreTipo from v_tipoVenta where idTipoVenta=" & intTmpIdTipoVenta)
            '-- si tiene una devolucion
            If sp_datosTabla.consulta_valor("select idVenta from cabNotaDebito where idVenta=" & v_idmov) > 0 Then
                Dim intTmpIdNotaDebito As Integer
                intTmpIdNotaDebito = sp_datosTabla.consulta_valor("select idNotaDebito from cabNotaDebito where idVenta=" & v_idmov)
                '-- datos de la devolucion
                lblDevolucion.Visible = True
                txtDsucDev.Text = sp_datosTabla.consulta_valorString("select dsuc from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtDcajaDev.Text = sp_datosTabla.consulta_valorString("select dcaja from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtFacturaDev.Text = sp_datosTabla.consulta_valorString("select factura from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtTotalDev.Text = sp_datosTabla.consulta_valorDouble("select total from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtTotalDev.Text = Format(CDec(txtTotalDev.Text), "###,###,###.00")
                Dim intTmpIdUsuarioDev As Integer
                intTmpIdUsuarioDev = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabNotaDebito where idNotaDebito=" & intTmpIdNotaDebito)
                txtResponsableDev.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                          "v_usuarioT where idUsuario=" & intTmpIdUsuarioDev)
            Else
                '-- sin devolucion
                lblDevolucion.Visible = False
                txtDsucDev.Text = ""
                txtDcajaDev.Text = ""
                txtFacturaDev.Text = ""
                txtTotalDev.Text = 0
                txtResponsableDev.Text = ""
            End If
            '-- idClienta
            txtIdCliente.Text = sp_datosTabla.consulta_valor("select idCliente from cve where idVenta=" & v_idmov)
            '-- cliente
            txtCliente.Text = sp_datosTabla.consulta_valorString("select cliente from cve where idVenta=" & v_idmov)
            '-- ruc
            txtRuc.Text = sp_datosTabla.consulta_valorString("select ruc from cve where idVenta=" & v_idmov)
            '-- grupo de cliente
            Dim intTmpIdGrupoCliente As Integer
            intTmpIdGrupoCliente = sp_datosTabla.consulta_valor("select idGrupoCliente from cliente where idCliente=" & CInt(txtIdCliente.Text))
            txtGrupoCliente.Text = sp_datosTabla.consulta_valorString("select nombreGrupoCliente from grupoCliente where idGrupoCliente=" & intTmpIdGrupoCliente)
            '-- empresa contable
            Dim intTmpIdPersonaJur As Integer
            intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cve where idVenta=" & v_idmov)
            lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & intTmpIdPersonaJur)
            '-- el CDC
            txtCdc.Text = ""
            '-- aprobado por la sifen
            lblAprobadoSifen.Visible = False

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- impresion de ticket de la heladeria
    Public Sub imprimirTicketHeladeria(ByVal codigoVenta As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()

        Dim rpt As New rpt_ticket
        Dim ofrm As New crv()
        '-- instanciar el parametro
        Dim v_idVenta As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        'asiganar el valor a los  parametros
        v_idVenta.Value = codigoVenta
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc

        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idVenta)

        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)

        'MsgBox("Valor de idPersonaJur " & v_idPersonaJur.Value)

        rpt.DataDefinition.ParameterFields("@idVenta").ApplyCurrentValues(pvParametros)

        rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- para imprimir directamente
        'rpt.PrintToPrinter(1, False, 0, 0)

        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub

    '-- impresion de ticket de la farmacia
    Private Sub imprimirVentaTicket(ByVal codigoVenta As Integer)
        Dim pvParametros As New ParameterValues()

        Dim rpt As New rpt_ticketFarmaciaCompartido
        Dim ofrm As New crv()
        '-- instanciar el parametro
        Dim v_idVenta As New ParameterDiscreteValue()
        'asiganar el valor a los  parametros
        v_idVenta.Value = codigoVenta

        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idVenta)

        'MsgBox("Valor de idPersonaJur " & v_idPersonaJur.Value)

        rpt.DataDefinition.ParameterFields("@idVenta").ApplyCurrentValues(pvParametros)

        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)

        '-----------------------------------------------------------------
        '--- PERSONALIZAR EL TAMAÑO
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        'rpt.PrintOptions.PrinterName = Trim(sp_datosTabla.consulta_valorString("select nombreImpresora from configPc where idConfig=" & intGl_idConfigPc))
        doctoprint.PrinterSettings.PrinterName = "EPSON TM-T20III Receipt"

        '-- para imprimir directamente
        rpt.PrintToPrinter(1, False, 0, 0)

        '-- mostrar el reporte
        'ofrm.WindowState = FormWindowState.Maximized
        'ofrm.Visible = True
        'ofrm.BringToFront()
        'ofrm.Show()
    End Sub

    Private Sub imprimirVentaTicketCompartido(ByVal codigoVenta As Integer)
        Dim pvParametros As New ParameterValues()

        Dim rpt As New rpt_ticketFarmacia
        Dim ofrm As New crv()
        '-- instanciar el parametro
        Dim v_idVenta As New ParameterDiscreteValue()
        'asiganar el valor a los  parametros
        v_idVenta.Value = codigoVenta

        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idVenta)

        'MsgBox("Valor de idPersonaJur " & v_idPersonaJur.Value)

        rpt.DataDefinition.ParameterFields("@idVenta").ApplyCurrentValues(pvParametros)

        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)

        '-----------------------------------------------------------------
        '--- PERSONALIZAR EL TAMAÑO
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        'rpt.PrintOptions.PrinterName = Trim(sp_datosTabla.consulta_valorString("select nombreImpresora from configPc where idConfig=" & intGl_idConfigPc))
        doctoprint.PrinterSettings.PrinterName = "EPSON TM-T20III Receipt"

        '-- para imprimir directamente
        rpt.PrintToPrinter(1, False, 0, 0)

        '-- mostrar el reporte
        'ofrm.WindowState = FormWindowState.Maximized
        'ofrm.Visible = True
        'ofrm.BringToFront()
        'ofrm.Show()
    End Sub

    '-- imprimir ticket txt
    Private Sub imprimirTicketTxt(ByVal codigoVenta As Integer)
        eliminarArchivoFacturaTicket()
        'Dim tmpDouTotalIVa10 As Double
        'Dim tmpDouTotalIVa5 As Double
        'Dim tmpDouTotalExenta As Double
        'Dim tmpDouTotalGra10 As Double
        'Dim tmpDouTotalGra5 As Double
        'Dim tmpIntTotalLinea As Integer = 0
        'Dim tmpIntResulLinea As Integer = 0

        'Dim v_totalLinea As String
        'Dim v_linea0 As String
        'Dim v_linea1 As String
        'Dim v_linea2 As String
        'Dim v_linea3 As String
        'Dim v_linea4 As String
        'Dim v_linea5 As String
        'Dim v_linea5_1 As String
        'Dim v_linea6 As String
        'Dim v_linea7 As String
        'Dim v_linea8 As String
        'Dim v_linea9 As String
        'Dim v_linea10 As String
        'Dim v_linea11 As String
        'Dim v_linea12 As String
        'Dim v_linea13 As String
        'Dim v_linea14 As String
        'Dim v_linea15 As String
        'Dim v_linea16 As String
        'Dim v_linea17 As String
        'Dim v_linea18 As String
        'Dim v_linea19 As String
        'Dim v_linea20 As String
        'Dim v_linea21 As String
        'Dim v_linea22 As String
        'Dim v_linea23 As String
        'Dim v_linea24 As String
        'Dim v_linea25 As String
        'Dim v_linea26 As String
        'Dim v_linea27 As String
        'Dim v_linea28 As String
        'Dim v_linea29 As String
        'Dim v_linea30 As String
        'Dim v_linea30_1 As String
        'Dim v_linea31 As String
        'Dim v_linea32 As String
        'Dim v_linea33 As String
        'Dim v_linea34 As String
        'Dim v_linea35 As String
        'Dim v_linea36 As String
        'Dim v_linea37 As String
        'Dim v_linea37_1 As String
        'Dim v_linea38 As String
        'Dim v_linea38_1 As String
        'Dim v_linea39 As String
        'Dim v_linea40 As String
        'Dim v_linea41 As String
        'Dim v_linea42 As String
        'Dim v_linea43 As String
        'Dim v_linea44 As String

        ''-----------------'
        ''-- LA CABECERA --'
        ''-----------------'
        'MsgBox("Paso 1")
        'v_linea0 = "--------------------------------------------"
        'v_linea1 = "--------------" + Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 0)) + "--------------"
        'v_linea2 = "--------------------------------------------"
        'MsgBox("Paso 2")
        'v_linea3 = sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 1)
        'v_linea4 = "RUC:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 2)
        ''-- verificar los caracteres
        'tmpIntTotalLinea = Len(Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 3)))
        'tmpIntResulLinea = tmpIntTotalLinea - 26
        'v_linea5 = "Direc.:" + Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 3)).ToString.Substring(0, 26)
        'v_linea5_1 = Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 3)).ToString.Substring(26, tmpIntResulLinea)

        'v_linea6 = "Timbrado:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 5)
        'v_linea7 = "Válido hasta:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 6)
        'v_linea8 = "Telef.:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 4)
        'v_linea9 = "--------------------------------------------"
        'v_linea10 = "FechaHora:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 10)
        'v_linea11 = "Cliente:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 21)
        'v_linea12 = "RUC:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 20)
        'v_linea13 = "Direc.:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 24)
        'v_linea14 = "Telef.:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 25)
        'v_linea15 = "Vendedor/a:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 18)
        'v_linea16 = "--------------------------------------------"
        'v_linea17 = "Forma de Venta:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 16)
        'v_linea18 = "Tipo de Factura:" + sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 26)
        'v_linea19 = "Factura:" + Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 13)) + "-" + _
        '    Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 14)) + "-" + _
        '    Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 15))
        'v_linea20 = "-------------------------------------------"
        'v_linea21 = "- Codigo         Mercaderia"
        'v_linea22 = "-Cant.Precio Pre.Desc. %IVA SubTotal"
        'v_linea23 = "-------------------------------------------"
        '----------------'
        '-- EL DETALLE --'
        '----------------'
        'limpiarDataset()
        ''Dim cmd1 As New SqlConnection
        'Dim conn As New SqlConnection(conexion)
        'Dim sql As String = "exec sp_reporteVentaTicketFarmacia" & " " & codigoVenta
        ''MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
        ''frmPedidoMercaderia.txtSql.Text = sql
        ''frmPassRepartidor.txtSql.Text = sql
        'Dim cmd As New SqlCommand(sql, conn)
        'Dim reader As SqlDataReader
        'Dim previousConnectionState As ConnectionState
        'previousConnectionState = conn.State
        'Dim line1 As String = ""
        'Dim line2 As String = ""

        'Try
        '    If conn.State = ConnectionState.Closed Then
        '        conn.Open()
        '    End If
        '    reader = cmd.ExecuteReader()
        '    line1 = ""
        '    line2 = ""
        '    Using reader
        '        While reader.Read
        '            'v_resultado = reader.GetValue(v_lugar).ToString
        '            Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString()
        '            '-- verificar los caracteres para la mercaderia
        '            tmpIntTotalLinea = Len(Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 32)))
        '            tmpIntResulLinea = tmpIntTotalLinea - 25
        '            line1 = line1 & Trim(reader.GetValue(31).ToString) + "-" + Trim(reader.GetValue(32).ToString).Substring(0, 25) & vbCrLf
        '            If tmpIntResulLinea > 0 Then
        '                line1 = line1 & Trim(reader.GetValue(32).ToString).Substring(25, tmpIntResulLinea) & vbCrLf
        '            End If

        '            line1 = line1 & Format(CDec(reader.GetValue(35)), "##0").ToString + " -- " + Format(CDec(reader.GetValue(36)), "###,##0").ToString + "  " + _
        '               Format(CDec(reader.GetValue(37)), "###,##0").ToString + "  " + Format(CDec(reader.GetValue(39)), "##0").ToString + "  " + _
        '               Format(CDec(reader.GetValue(38)), "#,###,##0").ToString & vbCrLf
        '            'line2 = line2 & reader.GetValue(35).ToString + " " + reader.GetValue(36).ToString + " " + reader.GetValue(39).ToString + " " + reader.GetValue(38).ToString & vbCrLf
        '            '-- sumar iva
        '            tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(41).ToString)
        '            tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(42).ToString)
        '            tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(40).ToString)

        '            tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(43).ToString)
        '            tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(44).ToString)
        '            'MsgBox("Nombre de la tabla  " & v_tabla)
        '            'MsgBox("Valor del Resultado  " & v_resultado)
        '        End While
        '    End Using

        'Catch ex As Exception

        '    MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    strGl_mensajeError = "Error: " & ex.Message & Me.ToString
        '    errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        'Finally

        '    If previousConnectionState = ConnectionState.Closed Then
        '        conn.Close()
        '    End If

        'End Try
        '-------------------'
        '-- PIE DE PAGINA --'
        '-------------------'
        'v_linea24 = "--------------------------------------------"
        'v_linea25 = "TOTAL GS.:" + Format(CDec(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 11)), "##,###,##0")
        ''-- verificar si tiene descuento
        'If sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 12) > 0 Then
        '    v_linea26 = "Su Descuento asciende a:" + Format(CDec(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 12)), "#,###,##0")
        'Else
        '    v_linea26 = ""
        'End If
        'v_linea27 = "--------------------------------------------"
        'v_linea28 = "   Liquidación de IVA "
        'v_linea29 = "Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString
        'v_linea30 = "Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString
        'v_linea30_1 = "Exenta:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString
        'v_linea31 = "---------------------------------------"
        'v_linea32 = "IVA10:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString
        'v_linea33 = "IVA5:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString
        'v_linea34 = "Total IVA:" + Format(CDec(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 45)), "#,###,##0")
        'v_linea35 = "--------------------------------------------"
        'v_linea36 = sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 48)
        'v_linea37 = "No se aceptan devoluciones pasadas"
        'v_linea37_1 = " las 48hs"

        'tmpIntTotalLinea = Len(Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 49)))
        'tmpIntResulLinea = tmpIntTotalLinea - 28
        'v_linea38 = Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 49)).ToString.Substring(0, 28)
        'v_linea38_1 = Trim(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 49)).ToString.Substring(28, tmpIntResulLinea)

        ''v_linea38 = sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 49)

        'v_linea39 = "ORIGINAL: CLIENTE"
        'v_linea40 = "DUPLICADO: ARCHIVO TRIBUTARIO"
        ''-- verificar si tiene puntaje
        'If sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 29) > 0 Then
        '    v_linea41 = "Total Puntaje:" + Format(CDec(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 29)), "#,##0")
        'Else
        '    v_linea41 = ""
        'End If
        ''-- verificar si es a credito
        'If sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 27) > 0 Then
        '    v_linea42 = "Firma: _______________"
        '    v_linea43 = "Aclaración: _______________"
        '    v_linea44 = "Can.Cuota:" + Format(CDec(sp_datosTabla.sp_traerValor("sp_reporteVentaTicketFarmacia", codigoVenta, 27)), "#,##0")
        'Else
        '    v_linea42 = ""
        '    v_linea43 = ""
        '    v_linea44 = ""
        'End If

        'v_totalLinea = v_linea0 & vbCrLf + Trim(v_linea1) & vbCrLf + Trim(v_linea2) & vbCrLf
        '+ Trim(v_linea3) & vbCrLf + Trim(v_linea4) & _
        '         vbCrLf + Trim(v_linea5) & vbCrLf + Trim(v_linea5_1) & vbCrLf + Trim(v_linea6) & vbCrLf + Trim(v_linea7) & vbCrLf + Trim(v_linea8) & vbCrLf + Trim(v_linea9) & _
        '        vbCrLf + Trim(v_linea10) & vbCrLf + Trim(v_linea11) & vbCrLf + Trim(v_linea12) & vbCrLf + Trim(v_linea13) & vbCrLf + Trim(v_linea14) & _
        '        vbCrLf + Trim(v_linea15) & vbCrLf + Trim(v_linea16) & vbCrLf + Trim(v_linea17) & vbCrLf + Trim(v_linea18) & vbCrLf + Trim(v_linea19) ' & _
        'vbCrLf + Trim(v_linea20) & vbCrLf + Trim(v_linea21) & vbCrLf + Trim(v_linea22) & vbCrLf + Trim(v_linea23) & vbCrLf + Trim(line1) & _
        'vbCrLf + Trim(v_linea24) & vbCrLf + Trim(v_linea25) & vbCrLf + Trim(v_linea26) & vbCrLf + Trim(v_linea27) & vbCrLf + Trim(v_linea28) & _
        'vbCrLf + Trim(v_linea29) & vbCrLf + Trim(v_linea30) & vbCrLf + Trim(v_linea30_1) & vbCrLf + Trim(v_linea31) & vbCrLf + Trim(v_linea32) & vbCrLf + Trim(v_linea33) & _
        'vbCrLf + Trim(v_linea34) & vbCrLf + Trim(v_linea35) & vbCrLf + Trim(v_linea36) & vbCrLf + Trim(v_linea37) & vbCrLf + Trim(v_linea37_1) & vbCrLf + Trim(v_linea38) & _
        'vbCrLf + Trim(v_linea38_1) & vbCrLf + Trim(v_linea39) & vbCrLf + Trim(v_linea40) & vbCrLf + Trim(v_linea41) & vbCrLf + Trim(v_linea42) & vbCrLf + Trim(v_linea43) & _
        'vbCrLf + Trim(v_linea44)

        'escribirFacturaTicket(v_totalLinea, "c:\Multicolor\txtTicket.txt")

        'Try
        '    streamToPrint = New StreamReader("c:\Multicolor\txtTicket.txt")
        '    Try
        '        printFont = New Font("MS Reference Sans Serif", 9)
        '        Dim pd As New PrintDocument()
        '        AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
        '        pd.Print()
        '    Finally
        '        streamToPrint.Close()
        '    End Try
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        'Dim leftMargin As Single = ev.MarginBounds.Left
        Dim leftMargin As Single = 0
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height /
        printFont.GetHeight(ev.Graphics)

        ' Print each line of the file.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            'yPos = 0
            ev.Graphics.DrawString(line, printFont, Brushes.Black,
            leftMargin, yPos, New StringFormat())

            count += 1
        End While

        ' If more lines exist, print another page.
        If Not (line Is Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub

    '-- imprimir directamente en el puerto de la imnpresora
    Private Sub hojaImpresion_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles hojaImpresion.PrintPage
        Dim tmpIntIdPersonaJur As Integer
        Dim tmpIntIdSucursal As Integer
        Dim tmpIntIdCliente As Integer
        Dim tmpIntIdVendedor As Integer
        Dim tmpIntIdTipoVenta As Integer
        Dim tmpIntIdFactura As Integer
        Dim tmpStrTipoFactura As String
        Dim tmpDouTotalIVa10 As Double
        Dim tmpDouTotalIVa5 As Double
        Dim tmpDouTotalExenta As Double
        Dim tmpDouTotalGra10 As Double
        Dim tmpDouTotalGra5 As Double
        Dim tmpDouTotalVenta As Double
        Dim tmpDouTotalDescuento As Double
        Dim tmpStrVencimiento As String
        Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpIntTotalPuntaje As Integer
        Dim tmpIntTotalNroCuota As Integer
        Dim tmpIntTipoF As Integer
        Dim tmpStrRuc As String

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdFactura = sp_datosTabla.consulta_valor("select idFactura from cabVenta where idVenta=" & intIdVenta)
            tmpStrVencimiento = sp_datosTabla.consulta_valorString("select convert(varchar,fechaCaduca,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpStrFechaInicio = sp_datosTabla.consulta_valorString("select convert(varchar,fechaInicio,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & intIdVenta)
            tmpDouTotalDescuento = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabVenta where idVenta=" & intIdVenta)
            tmpIntTotalPuntaje = sp_datosTabla.consulta_valor("select [dbo].[funTotalPuntajeCliente](cv.idCliente) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTotalNroCuota = sp_datosTabla.consulta_valor("select [dbo].[funTotalNroCuotaVenta](cv.idVenta) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTipoF = sp_datosTabla.consulta_valor("select tipoF from cabVenta where idVenta=" & intIdVenta)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)

            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabVenta where idVenta=" & intIdVenta)
            If sp_datosTabla.consulta_valorBoolean("select contado from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta) = True Then
                tmpStrTipoFactura = "CONTADO"
            Else
                tmpStrTipoFactura = "CREDITO"
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 1)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select rtrim(nombreFantasia) from v_sucursal where idSucursal=" & tmpIntIdSucursal)))
            'MsgBox("Total longitud sucursal " & tmpIntLen)
            tmpIntTotalLen = ((42 - tmpIntLen) / 2) / 2
            ' MsgBox("Resultaido " & tmpIntTotalLen)

            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select space(" & tmpIntTotalLen & ")+nombreFantasia from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 20)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 40)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Italic)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 30, 55)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'RUC:'+rtrim(ruc)+'-'+ltrim(dv) from v_personaJur where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 1, 75)
            e.Graphics.DrawString("Casa Matriz: Mcal. José ", prFont, Brushes.Black, 1, 90)
            e.Graphics.DrawString("Félix Estigarribia e/ Tomás", prFont, Brushes.Black, 1, 105)
            e.Graphics.DrawString("Romero Pereira", prFont, Brushes.Black, 1, 120)
            e.Graphics.DrawString("Teléfono:071 200604", prFont, Brushes.Black, 1, 135)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 150)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 165)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 180)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrFechaInicio, prFont, Brushes.Black, 1, 255)
            e.Graphics.DrawString("Fecha Fin Vigencia: " & tmpStrVencimiento, prFont, Brushes.Black, 1, 270)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Nro. Factura:'+rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 285)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 300)
            If tmpIntTipoF = 1 Then
                prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
                e.Graphics.DrawString("                 DELIVERY                 ", prFont, Brushes.Black, 1, 315)
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 330)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 345)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_vendedor where idVendedor=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 450)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Mercaderia                   ", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString("Cant   Precio  Prec.Des.     %IVA    Subtotal   ", prFont, Brushes.Black, 1, 480)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 495)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            '----------------'
            '-- EL DETALLE --'
            '----------------'
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "select [dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad) as cantidad,([dbo].[funNombreMercaderiaVenta](dv.idVenta,dv.idStock,dv.idProducto)) " & _
                " as Mercaderia,p.codigo,dv.precio,dv.precioDescuento,dv.porcentajeImpuesto,dv.subtotal," & _
                "(case " & _
                    "when (dv.covid=0 or dv.covid is null) then [dbo].[funExentaMercaderiaVenta](dv.idVenta,dv.idStock) " & _
                    "when dv.covid=1 then [dbo].[funExentaVentaCovid](dv.subtotal,dv.porcentajeImpuesto) " & _
                "end) as exenta," & _
             "(case " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=0  and (dv.covid=0 or dv.covid is null) then (dv.subtotal-(dv.subtotal/dv.factorImpuesto)) " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=1 then ((dv.subtotal/2)-((dv.subtotal/2)/dv.factorImpuesto)) " & _
                "when dv.idImpuesto=2 and dv.covid=1 then [dbo].[funIvaVentaCovid10](dv.subtotal) " & _
                "else 0 " & _
            "end) as gravada10," & _
            "(case	" & _
                "when dv.idImpuesto=3 and (dv.covid=0 or dv.covid is null) then (dv.subtotal-(dv.subtotal/dv.factorImpuesto)) " & _
                "when dv.idImpuesto=3 and (dv.covid=1) then [dbo].[funIvaVentaCovid](dv.subtotal) " & _
                "else 0 " & _
            "end) as gravada5, " & _
            "(case " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=0 and dv.covid=0  then dv.subtotal " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=1 and dv.covid=0 then dv.subtotal/2 " & _
                "when dv.idImpuesto=2 and dv.covid=1 then [dbo].[funGravadaVentaCovid10](dv.subtotal) " & _
                "else 0 " & _
            "end) as IVA10," & _
            "(case	" & _
                "when dv.idImpuesto=3 and p.impuestoEspecial=0 and (dv.covid=0 or dv.covid is null)  then dv.subtotal " & _
                "when dv.idImpuesto=3 and p.impuestoEspecial=1 and (dv.covid=0 or dv.covid is null) then dv.subtotal/2 " & _
                "when dv.idImpuesto=3 and dv.covid=1 then [dbo].[funGravadaVentaCovid5](dv.subtotal) " & _
                "else 0 " & _
            "end) as IVA5,dv.idStock " & _
            " from detVenta dv inner join stock s on dv.idStock=s.idStock inner join producto p on p.idProducto=s.idProducto where idVenta=" & intIdVenta & _
            " UNION " & _
            "select 1 as cantidad,dv.descripcion " & _
                " as Mercaderia,' ',dv.monto,dv.monto,10,dv.monto," & _
                " 0 as exenta," & _
             "(dv.monto-(dv.monto/dv.factorImpuesto))  as gravada10," & _
            " 0 as gravada5, " & _
            " dv.monto  as IVA10," & _
            " 0 as IVA5,1 as idStock " & _
            " from detVentaDelivery dv where dv.idVenta=" & intIdVenta & " Order by dv.idStock desc"


            'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
            'frmPedidoMercaderia.txtSql.Text = sql
            'frmPassRepartidor.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 510

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- sumar los impuestos
                        tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(8))
                        tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(9))
                        tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(7))

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(10))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(11))

                        e.Graphics.DrawString(Trim(reader.GetValue(2).ToString) + " " + reader.GetValue(1).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(0)), "##0").ToString + "   " + Format(CDec(reader.GetValue(3)), "###,##0").ToString + _
                                              "   " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + "    " + Format(CDec(reader.GetValue(5)), "##0").ToString + "%" + _
                                              "        " + Format(CDec(reader.GetValue(6)), "###,##0").ToString,
                                              prFont, Brushes.Black, 1, tmpIntContador)

                        tmpIntContador = tmpIntContador + 15
                    End While
                End Using

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & Me.ToString
                errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("TOTAL Gs.=" + Format(CDec(tmpDouTotalVenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 15)
            If tmpDouTotalDescuento > 0 Then
                prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
                e.Graphics.DrawString("Su descuento es:" & Format(CDec(tmpDouTotalDescuento), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 40)
            End If
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 55)
            If tmpDouTotalDescuento > 0 Then
                e.Graphics.DrawString("ESTA FACTURA CUENTA CON", prFont, Brushes.Black, 1, tmpIntContador + 70)
                e.Graphics.DrawString("MAXIDESCUENTO", prFont, Brushes.Black, 1, tmpIntContador + 85)

            End If
            e.Graphics.DrawString("-------------- Liquidación de IVA --------------", prFont, Brushes.Black, 1, tmpIntContador + 100)
            e.Graphics.DrawString("Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 115)
            e.Graphics.DrawString("Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 130)
            e.Graphics.DrawString("Exenta:" + Format(CDec(tmpDouTotalExenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 145)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 160)
            e.Graphics.DrawString("IVA 10%:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 175)
            e.Graphics.DrawString("IVA 5%:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 190)
            e.Graphics.DrawString("Total IVA:" + Format(CDec(tmpDouTotalGra10 + tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 210)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 230)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("DELIVERY: 071 205756 - 0985 830300", prFont, Brushes.Black, 1, tmpIntContador + 250)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("No se aceptan devoluciones pasadas las 48hs.", prFont, Brushes.Black, 1, tmpIntContador + 280)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Bold)
            e.Graphics.DrawString("ORIGINAL=CLIENTE", prFont, Brushes.Black, 1, tmpIntContador + 310)
            e.Graphics.DrawString("DUPLICADO=ARCHIVO TRIBUTARIO", prFont, Brushes.Black, 1, tmpIntContador + 325)
            e.Graphics.DrawString("TRIPLICADO=Contabilidad (No ", prFont, Brushes.Black, 1, tmpIntContador + 340)
            e.Graphics.DrawString("válido p/ crédito fiscal) ", prFont, Brushes.Black, 1, tmpIntContador + 355)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            If tmpIntTotalPuntaje > 0 Then
                '-- si tiene puntaje
                e.Graphics.DrawString("MaxiPunto:" + Format(CDec(tmpIntTotalPuntaje), "##,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 380)
            End If
            If tmpIntIdTipoVenta = 2 Then
                '-- factura a credito
                e.Graphics.DrawString("Firma:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 395)
                e.Graphics.DrawString("Aclaración:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 415)
                e.Graphics.DrawString("Cant.Cuo.:" + Format(CDec(tmpIntTotalNroCuota), "#0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 430)
            End If
            e.HasMorePages = False

            'Me.BringToFront()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- imprimir facturacion electronica sin codigo QR
    Private Sub hojaImpresionSinQR_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles hojaImpresionSinQR.PrintPage
        Dim tmpIntIdPersonaJur As Integer
        Dim tmpIntIdSucursal As Integer
        Dim tmpIntIdCliente As Integer
        Dim tmpIntIdVendedor As Integer
        Dim tmpIntIdTipoVenta As Integer
        Dim tmpIntIdFactura As Integer
        Dim tmpStrTipoFactura As String
        Dim tmpDouTotalIVa10 As Double
        Dim tmpDouTotalIVa5 As Double
        Dim tmpDouTotalExenta As Double
        Dim tmpDouTotalGra10 As Double
        Dim tmpDouTotalGra5 As Double
        Dim tmpDouTotalVenta As Double
        Dim tmpDouTotalDescuento As Double
        Dim tmpStrVencimiento As String
        'Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpIntTotalPuntaje As Integer
        Dim tmpIntTotalNroCuota As Integer
        Dim tmpIntTipoF As Integer
        Dim tmpStrRuc As String
        Dim tmpStrCDC1 As String
        Dim tmpStrCDC2 As String
        Dim tmpStrSerial As String

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdFactura = sp_datosTabla.consulta_valor("select idFactura from cabVenta where idVenta=" & intIdVenta)
            tmpStrVencimiento = sp_datosTabla.consulta_valorString("select convert(varchar,fechaTimbrado,103) from detVentaDTE where idVenta=" & intIdVenta)
            tmpStrSerial = sp_datosTabla.consulta_valorString("select serial from detVentaDTE where idVenta=" & intIdVenta)
            ' tmpStrFechaInicio = sp_datosTabla.consulta_valorString("select convert(varchar,fechaInicio,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & intIdVenta)
            tmpDouTotalDescuento = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabVenta where idVenta=" & intIdVenta)
            tmpIntTotalPuntaje = sp_datosTabla.consulta_valor("select [dbo].[funTotalPuntajeCliente](cv.idCliente) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTotalNroCuota = sp_datosTabla.consulta_valor("select [dbo].[funTotalNroCuotaVenta](cv.idVenta) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTipoF = sp_datosTabla.consulta_valor("select tipoF from cabVenta where idVenta=" & intIdVenta)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)
            tmpStrCDC1 = sp_datosTabla.consulta_valorString("select substring(cdc,1,22) from detVentaDTE where idVenta=" & intIdVenta)
            tmpStrCDC2 = sp_datosTabla.consulta_valorString("select substring(cdc,23,44) from detVentaDTE where idVenta=" & intIdVenta)

            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabVenta where idVenta=" & intIdVenta)
            If sp_datosTabla.consulta_valorBoolean("select contado from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta) = True Then
                tmpStrTipoFactura = "CONTADO"
            Else
                tmpStrTipoFactura = "CREDITO"
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 1)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select rtrim(nombreFantasia) from v_sucursal where idSucursal=" & tmpIntIdSucursal)))
            'MsgBox("Total longitud sucursal " & tmpIntLen)
            tmpIntTotalLen = ((42 - tmpIntLen) / 2) / 2
            ' MsgBox("Resultaido " & tmpIntTotalLen)

            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select space(" & tmpIntTotalLen & ")+nombreFantasia from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 20)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 40)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Italic)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 30, 55)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'RUC:'+rtrim(ruc)+'-'+ltrim(dv) from v_personaJur where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 1, 75)
            e.Graphics.DrawString("Casa Matriz: Mcal. José ", prFont, Brushes.Black, 1, 90)
            e.Graphics.DrawString("Félix Estigarribia e/ Tomás", prFont, Brushes.Black, 1, 105)
            e.Graphics.DrawString("Romero Pereira", prFont, Brushes.Black, 1, 120)
            e.Graphics.DrawString("Teléfono:071 200604", prFont, Brushes.Black, 1, 135)
            e.Graphics.DrawString("Actividad Económica:", prFont, Brushes.Black, 1, 150)
            prFont = New Font("MS Reference Sans Serif", 7, FontStyle.Regular)
            e.Graphics.DrawString("COMERCIO AL POR MENOR DE PRODUCTOS", prFont, Brushes.Black, 1, 165)
            e.Graphics.DrawString("FARMACÉUTICOS DE USO HUMANO", prFont, Brushes.Black, 1, 180)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 255)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 270)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 285)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrVencimiento, prFont, Brushes.Black, 1, 300)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("Nro. Factura Electronica:", prFont, Brushes.Black, 1, 315)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 330)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            'e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 330)
            If tmpIntTipoF = 1 Then
                prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
                e.Graphics.DrawString("                 DELIVERY                 ", prFont, Brushes.Black, 1, 345)
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_vendedor where idVendedor=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 450)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 480)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Mercaderia                   ", prFont, Brushes.Black, 1, 495)
            e.Graphics.DrawString("Cant   Precio  Prec.Des.     %IVA    Subtotal   ", prFont, Brushes.Black, 1, 510)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 525)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            '----------------'
            '-- EL DETALLE --'
            '----------------'
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "select [dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad) as cantidad,([dbo].[funNombreMercaderiaVenta](dv.idVenta,dv.idStock,dv.idProducto)) " & _
                " as Mercaderia,p.codigo,dv.precio,dv.precioDescuento,dv.porcentajeImpuesto,dv.subtotal," & _
                "(case " & _
                    "when (dv.covid=0 or dv.covid is null) then [dbo].[funExentaMercaderiaVenta](dv.idVenta,dv.idStock) " & _
                    "when dv.covid=1 then [dbo].[funExentaVentaCovid](dv.subtotal,dv.porcentajeImpuesto) " & _
                "end) as exenta," & _
             "(case " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=0  and (dv.covid=0 or dv.covid is null) then (dv.subtotal-(dv.subtotal/dv.factorImpuesto)) " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=1 then ((dv.subtotal/2)-((dv.subtotal/2)/dv.factorImpuesto)) " & _
                "when dv.idImpuesto=2 and dv.covid=1 then [dbo].[funIvaVentaCovid10](dv.subtotal) " & _
                "else 0 " & _
            "end) as gravada10," & _
            "(case	" & _
                "when dv.idImpuesto=3 and (dv.covid=0 or dv.covid is null) then (dv.subtotal-(dv.subtotal/dv.factorImpuesto)) " & _
                "when dv.idImpuesto=3 and (dv.covid=1) then [dbo].[funIvaVentaCovid](dv.subtotal) " & _
                "else 0 " & _
            "end) as gravada5, " & _
            "(case " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=0 and dv.covid=0  then dv.subtotal " & _
                "when dv.idImpuesto=2 and p.impuestoEspecial=1 and dv.covid=0 then dv.subtotal/2 " & _
                "when dv.idImpuesto=2 and dv.covid=1 then [dbo].[funGravadaVentaCovid10](dv.subtotal) " & _
                "else 0 " & _
            "end) as IVA10," & _
            "(case	" & _
                "when dv.idImpuesto=3 and p.impuestoEspecial=0 and (dv.covid=0 or dv.covid is null)  then dv.subtotal " & _
                "when dv.idImpuesto=3 and p.impuestoEspecial=1 and (dv.covid=0 or dv.covid is null) then dv.subtotal/2 " & _
                "when dv.idImpuesto=3 and dv.covid=1 then [dbo].[funGravadaVentaCovid5](dv.subtotal) " & _
                "else 0 " & _
            "end) as IVA5,dv.idStock " & _
            " from detVenta dv inner join stock s on dv.idStock=s.idStock inner join producto p on p.idProducto=s.idProducto where idVenta=" & intIdVenta & _
            " UNION " & _
            "select 1 as cantidad,dv.descripcion " & _
                " as Mercaderia,' ',dv.monto,dv.monto,10,dv.monto," & _
                " 0 as exenta," & _
             "(dv.monto-(dv.monto/dv.factorImpuesto))  as gravada10," & _
            " 0 as gravada5, " & _
            " dv.monto  as IVA10," & _
            " 0 as IVA5,1 as idStock " & _
            " from detVentaDelivery dv where dv.idVenta=" & intIdVenta & " Order by dv.idStock desc"


            'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
            'frmPedidoMercaderia.txtSql.Text = sql
            'frmPassRepartidor.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 540

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- sumar los impuestos
                        tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(8))
                        tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(9))
                        tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(7))

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(10))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(11))

                        e.Graphics.DrawString(Trim(reader.GetValue(2).ToString) + " " + reader.GetValue(1).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(0)), "##0").ToString + "   " + Format(CDec(reader.GetValue(3)), "###,##0").ToString + _
                                              "   " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + "    " + Format(CDec(reader.GetValue(5)), "##0").ToString + "%" + _
                                              "        " + Format(CDec(reader.GetValue(6)), "###,##0").ToString,
                                              prFont, Brushes.Black, 1, tmpIntContador)

                        tmpIntContador = tmpIntContador + 15
                    End While
                End Using

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & Me.ToString
                errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("TOTAL Gs.=" + Format(CDec(tmpDouTotalVenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 15)
            If tmpDouTotalDescuento > 0 Then
                prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
                e.Graphics.DrawString("Su descuento es:" & Format(CDec(tmpDouTotalDescuento), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 40)
            End If
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 55)
            If tmpDouTotalDescuento > 0 Then
                e.Graphics.DrawString("ESTA FACTURA CUENTA CON", prFont, Brushes.Black, 1, tmpIntContador + 70)
                e.Graphics.DrawString("MAXIDESCUENTO", prFont, Brushes.Black, 1, tmpIntContador + 85)

            End If
            e.Graphics.DrawString("-------------- Liquidación de IVA --------------", prFont, Brushes.Black, 1, tmpIntContador + 100)
            e.Graphics.DrawString("Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 115)
            e.Graphics.DrawString("Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 130)
            e.Graphics.DrawString("Exenta:" + Format(CDec(tmpDouTotalExenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 145)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 160)
            e.Graphics.DrawString("IVA 10%:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 175)
            e.Graphics.DrawString("IVA 5%:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 190)
            e.Graphics.DrawString("Total IVA:" + Format(CDec(tmpDouTotalGra10 + tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 210)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 230)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("DELIVERY: 071 205756 - 0985 830300", prFont, Brushes.Black, 1, tmpIntContador + 250)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("No se aceptan devoluciones pasadas las 48hs.", prFont, Brushes.Black, 1, tmpIntContador + 280)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            If tmpIntTotalPuntaje > 0 Then
                '-- si tiene puntaje
                e.Graphics.DrawString("MaxiPunto:" + Format(CDec(tmpIntTotalPuntaje), "##,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 295)
            End If
            If tmpIntIdTipoVenta = 2 Then
                '-- factura a credito
                e.Graphics.DrawString("Firma:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 310)
                e.Graphics.DrawString("Aclaración:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 325)
                e.Graphics.DrawString("Cant.Cuo.:" + Format(CDec(tmpIntTotalNroCuota), "#0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 340)
            End If

            '-- esta parte corresponde a las especificaciones del manual tecnico de la SIFEN
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Consulte la validez de esta Factura Electrónica", prFont, Brushes.Black, 1, tmpIntContador + 355)
            e.Graphics.DrawString("con el número de CDC impreso abajo en : ", prFont, Brushes.Black, 1, tmpIntContador + 370)
            e.Graphics.DrawString(" https://ekuatia.set.gov/consultas/consultas ", prFont, Brushes.Black, 1, tmpIntContador + 385)
            prFont = New Font("Arial", 12, FontStyle.Bold)
            e.Graphics.DrawString(tmpStrCDC1, prFont, Brushes.Black, 1, tmpIntContador + 405)
            e.Graphics.DrawString(tmpStrCDC2, prFont, Brushes.Black, 1, tmpIntContador + 420)
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Este documento es una representación ", prFont, Brushes.Black, 1, tmpIntContador + 440)
            e.Graphics.DrawString("gráfica de un documento electrónico(xml)", prFont, Brushes.Black, 1, tmpIntContador + 455)
            e.Graphics.DrawString("Información de Interés del facturador ", prFont, Brushes.Black, 1, tmpIntContador + 470)
            e.Graphics.DrawString("electrónico emisor. ", prFont, Brushes.Black, 1, tmpIntContador + 485)
            '--------------------------------------------------------------------------------

            e.HasMorePages = False

            'Me.BringToFront()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub hojaImpresionHeladeria_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim tmpIntIdPersonaJur As Integer
        Dim tmpIntIdSucursal As Integer
        Dim tmpIntIdCliente As Integer
        Dim tmpIntIdVendedor As Integer
        Dim tmpIntIdTipoVenta As Integer
        Dim tmpIntIdFactura As Integer
        Dim tmpStrTipoFactura As String
        Dim tmpDouTotalIVa10 As Double
        Dim tmpDouTotalIVa5 As Double
        Dim tmpDouTotalExenta As Double
        Dim tmpDouTotalGra10 As Double
        Dim tmpDouTotalGra5 As Double
        Dim tmpDouTotalVenta As Double
        Dim tmpDouTotalDescuento As Double
        Dim tmpStrVencimiento As String
        Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpIntTotalMaxiPunto As Integer
        Dim tmpIntTotalPuntaje As Integer
        Dim tmpIntTotalNroCuota As Integer
        Dim tmpIntTipoF As Integer
        Dim tmpStrRuc As String

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdFactura = sp_datosTabla.consulta_valor("select idFactura from cabVenta where idVenta=" & intIdVenta)
            tmpStrVencimiento = sp_datosTabla.consulta_valorString("select convert(varchar,fechaCaduca,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpStrFechaInicio = sp_datosTabla.consulta_valorString("select convert(varchar,fechaInicio,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & intIdVenta)
            tmpDouTotalDescuento = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabVenta where idVenta=" & intIdVenta)
            tmpIntTotalMaxiPunto = sp_datosTabla.consulta_valor("select sum(dv.precio) from detVenta dv where dv.maxipunto=1 and dv.precio > 0 and dv.idVenta=" & intIdVenta)
            tmpIntTotalPuntaje = sp_datosTabla.consulta_valor("select [dbo].[funTotalPuntajeCliente](cv.idCliente) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTotalNroCuota = sp_datosTabla.consulta_valor("select [dbo].[funTotalNroCuotaVenta](cv.idVenta) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTipoF = sp_datosTabla.consulta_valor("select tipoF from cabVenta where idVenta=" & intIdVenta)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)

            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabVenta where idVenta=" & intIdVenta)
            If sp_datosTabla.consulta_valorBoolean("select contado from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta) = True Then
                tmpStrTipoFactura = "CONTADO"
            Else
                tmpStrTipoFactura = "CREDITO"
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 1)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select rtrim(nombreFantasia) from v_sucursal where idSucursal=" & tmpIntIdSucursal)))
            'MsgBox("Total longitud sucursal " & tmpIntLen)
            tmpIntTotalLen = ((42 - tmpIntLen) / 2) / 2
            ' MsgBox("Resultaido " & tmpIntTotalLen)

            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select space(" & tmpIntTotalLen & ")+nombreFantasia from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 20)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 40)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Italic)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 30, 55)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'RUC:'+rtrim(ruc)+'-'+ltrim(dv) from v_personaJur where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 1, 75)
            e.Graphics.DrawString("Casa Matriz: Mcal. José ", prFont, Brushes.Black, 1, 90)
            e.Graphics.DrawString("Félix Estigarribia e/ Tomás", prFont, Brushes.Black, 1, 105)
            e.Graphics.DrawString("Romero Pereira", prFont, Brushes.Black, 1, 120)
            e.Graphics.DrawString("Teléfono:071 200604", prFont, Brushes.Black, 1, 135)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 150)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 165)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 180)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrFechaInicio, prFont, Brushes.Black, 1, 255)
            e.Graphics.DrawString("Fecha Fin Vigencia: " & tmpStrVencimiento, prFont, Brushes.Black, 1, 270)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Nro. Factura:'+rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 285)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 300)
            If tmpIntTipoF = 1 Then
                prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
                e.Graphics.DrawString("                 DELIVERY                 ", prFont, Brushes.Black, 1, 315)
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 330)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 345)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_vendedor where idVendedor=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 450)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Mercaderia                   ", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString("Cant     Precio      %IVA        Subtotal   ", prFont, Brushes.Black, 1, 480)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 495)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)

            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = ""

            ' MsgBox("Valor de Total Puntaje " & tmpIntTotalMaxiPunto)
            If tmpIntTotalMaxiPunto = 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL SIN MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,[dbo].[funNombreMercaderiaVenta](cv.idVenta,dv.idStock,dv.idProducto) as mercaderia, " & _
                        "([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        "dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        "(case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5 " & _
                        " from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta" & _
                        " inner join stock s on s.idStock=dv.idStock" & _
                        " inner join producto p on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " union " & _
                        " select 0,0,dv.concepto as Mercaderia,1 as cantidad,dv.monto,dv.monto,10 as porcentajeImpuesto," & _
                        " 0 as exenta,dv.monto as IVA10,0 as IVA5,	(dv.monto-(dv.monto/1.1)) as gravada10,	0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaComboEstudiante dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " union " & _
                        " select 0,0,'PROMO SAMSUNG CLUB 1/2 KG HELADO',1 as cantidad,0,0,10 as porcentajeImpuesto,0 as exenta,0 as IVA10," & _
                        " 0 as IVA5,0 as gravada10,0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaPromoSamsung dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " order by dv.idStock desc"
            End If

            If tmpIntTotalMaxiPunto > 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL CON MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as mercaderia," & _
                        " ([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        "(case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join stock s" & _
                        " on s.idStock=dv.idStock" & _
                        " inner join producto p" & _
                        " on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " and dv.maxipunto=0" & _
                        " union " & _
                        " select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as Mercaderia," & _
                        " sum([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " sum(dv.precioDescuento) as precioDescuento,sum(dv.precio) as subtotal," & _
                        " convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then 0" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " velse 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join producto p" & _
                        " on p.idProducto=dv.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and dv.precio > 0" & _
                        " and dv.maxipunto=1" & _
                        " group by dv.idStock, p.codigo,dv.idProducto, dv.precioDescuento, dv.precio,dv.idImpuesto, dv.maxipunto, dv.porcentajeImpuesto" & _
                        " union " & _
                        " select 0 as idStock,'0' as codigo,'DESCUENTOS CONCEDIDOS' as Mercaderia,1 as cantidad," & _
                        tmpIntTotalMaxiPunto & "as precioDescuento," & (tmpIntTotalMaxiPunto * -1) & "as subtotal," & _
                        " 10 as porcentajeImpuesto,0 as exenta,0 as IVA10,	0 as IVA5,0 as gravada10,0 as gravada5," & _
                        " from cabVenta cv " & _
                        " where cv.idVenta=" & intIdVenta & _
                        " order by tipoDet"
            End If

            'txtSql.Text = sql

            'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
            'frmPedidoMercaderia.txtSql.Text = sql
            'frmPassRepartidor.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 510

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- sumar los impuestos
                        tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(10))
                        tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(11))
                        tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(7))

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(8))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(9))

                        e.Graphics.DrawString(Trim(reader.GetValue(1).ToString) + " " + reader.GetValue(2).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(3)), "##0").ToString + "        " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + _
                                              "        " + Format(CDec(reader.GetValue(6)), "##0").ToString + "%" + _
                                              "        " + Format(CDec(reader.GetValue(5)), "###,##0").ToString,
                                              prFont, Brushes.Black, 1, tmpIntContador)

                        tmpIntContador = tmpIntContador + 15
                    End While
                End Using

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & Me.ToString
                errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("TOTAL Gs.=" + Format(CDec(tmpDouTotalVenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 15)
            If tmpDouTotalDescuento > 0 Then
                prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
                e.Graphics.DrawString("Su descuento es:" & Format(CDec(tmpDouTotalDescuento), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 40)
            End If
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 55)
            If tmpDouTotalDescuento > 0 Then
                e.Graphics.DrawString("ESTA FACTURA CUENTA CON", prFont, Brushes.Black, 1, tmpIntContador + 70)
                e.Graphics.DrawString("MAXIDESCUENTO", prFont, Brushes.Black, 1, tmpIntContador + 85)

            End If
            e.Graphics.DrawString("-------------- Liquidación de IVA --------------", prFont, Brushes.Black, 1, tmpIntContador + 100)
            e.Graphics.DrawString("Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 115)
            e.Graphics.DrawString("Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 130)
            e.Graphics.DrawString("Exenta:" + Format(CDec(tmpDouTotalExenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 145)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 160)
            e.Graphics.DrawString("IVA 10%:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 175)
            e.Graphics.DrawString("IVA 5%:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 190)
            e.Graphics.DrawString("Total IVA:" + Format(CDec(tmpDouTotalGra10 + tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 210)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 230)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("DELIVERY: 071 205756 - 0985 830300", prFont, Brushes.Black, 1, tmpIntContador + 250)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("No se aceptan devoluciones pasadas las 48hs.", prFont, Brushes.Black, 1, tmpIntContador + 280)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            If tmpIntTotalPuntaje > 0 Then
                '-- si tiene puntaje
                e.Graphics.DrawString("MaxiPunto:" + Format(CDec(tmpIntTotalPuntaje), "##,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 295)
            End If
            If tmpIntIdTipoVenta = 2 Then
                '-- factura a credito
                e.Graphics.DrawString("Firma:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 310)
                e.Graphics.DrawString("Aclaración:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 325)
                e.Graphics.DrawString("Cant.Cuo.:" + Format(CDec(tmpIntTotalNroCuota), "#0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 340)
            End If
            e.HasMorePages = False

            'Me.BringToFront()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub hojaImpresionSinQR_heladeria_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles hojaImpresionSinQR_heladeria.PrintPage
        Dim tmpIntIdPersonaJur As Integer
        Dim tmpIntIdSucursal As Integer
        Dim tmpIntIdCliente As Integer
        Dim tmpIntIdVendedor As Integer
        Dim tmpIntIdTipoVenta As Integer
        Dim tmpIntIdFactura As Integer
        Dim tmpStrTipoFactura As String
        Dim tmpDouTotalIVa10 As Double
        Dim tmpDouTotalIVa5 As Double
        Dim tmpDouTotalExenta As Double
        Dim tmpDouTotalGra10 As Double
        Dim tmpDouTotalGra5 As Double
        Dim tmpDouTotalVenta As Double
        Dim tmpDouTotalDescuento As Double
        Dim tmpStrVencimiento As String
        Dim tmpStrFechaInicio As String
        Dim tmpIntLen As Integer
        Dim tmpIntTotalLen As Integer
        Dim tmpIntTotalMaxiPunto As Integer
        Dim tmpIntTotalPuntaje As Integer
        Dim tmpIntTotalNroCuota As Integer
        Dim tmpIntTipoF As Integer
        Dim tmpStrRuc As String
        Dim tmpStrCDC1 As String
        Dim tmpStrCDC2 As String
        Dim tmpStrSerial As String

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 15, FontStyle.Bold)
            '-- las variables
            tmpIntIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from cabVenta where idVenta=" & intIdVenta)
            tmpIntIdFactura = sp_datosTabla.consulta_valor("select idFactura from cabVenta where idVenta=" & intIdVenta)
            tmpStrVencimiento = sp_datosTabla.consulta_valorString("select convert(varchar,fechaCaduca,103) from factura where idFactura=" & tmpIntIdFactura)
            tmpStrFechaInicio = sp_datosTabla.consulta_valorString("select convert(varchar,fechaTimbrado,103) from detVentaDTE where idVenta=" & intIdVenta)
            tmpDouTotalVenta = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & intIdVenta)
            tmpDouTotalDescuento = sp_datosTabla.consulta_valorDouble("select totalDescuento from cabVenta where idVenta=" & intIdVenta)
            tmpIntTotalMaxiPunto = sp_datosTabla.consulta_valor("select sum(dv.precio) from detVenta dv where dv.maxipunto=1 and dv.precio > 0 and dv.idVenta=" & intIdVenta)
            tmpIntTotalPuntaje = sp_datosTabla.consulta_valor("select [dbo].[funTotalPuntajeCliente](cv.idCliente) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTotalNroCuota = sp_datosTabla.consulta_valor("select [dbo].[funTotalNroCuotaVenta](cv.idVenta) from cabVenta cv where idVenta=" & intIdVenta)
            tmpIntTipoF = sp_datosTabla.consulta_valor("select tipoF from cabVenta where idVenta=" & intIdVenta)
            tmpStrRuc = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & tmpIntIdCliente)
            tmpStrCDC1 = sp_datosTabla.consulta_valorString("select substring(cdc,1,22) from detVentaDTE where idVenta=" & intIdVenta)
            tmpStrCDC2 = sp_datosTabla.consulta_valorString("select substring(cdc,23,44) from detVentaDTE where idVenta=" & intIdVenta)
            tmpIntIdTipoVenta = sp_datosTabla.consulta_valor("select idTipoVenta from cabVenta where idVenta=" & intIdVenta)
            tmpStrSerial = sp_datosTabla.consulta_valorString("select serial from detVentaDTE where idVenta=" & intIdVenta)

            If sp_datosTabla.consulta_valorBoolean("select contado from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta) = True Then
                tmpStrTipoFactura = "CONTADO"
            Else
                tmpStrTipoFactura = "CREDITO"
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 1)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)

            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select rtrim(nombreFantasia) from v_sucursal where idSucursal=" & tmpIntIdSucursal)))
            'MsgBox("Total longitud sucursal " & tmpIntLen)
            tmpIntTotalLen = ((42 - tmpIntLen) / 2) / 2
            ' MsgBox("Resultaido " & tmpIntTotalLen)

            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select space(" & tmpIntTotalLen & ")+nombreFantasia from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 20)

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 40)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Italic)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 30, 55)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'RUC:'+rtrim(ruc)+'-'+ltrim(dv) from v_personaJur where idPersonaJur=" & tmpIntIdPersonaJur), prFont, Brushes.Black, 1, 75)
            e.Graphics.DrawString("Casa Matriz: Mcal. José ", prFont, Brushes.Black, 1, 90)
            e.Graphics.DrawString("Félix Estigarribia e/ Tomás", prFont, Brushes.Black, 1, 105)
            e.Graphics.DrawString("Romero Pereira", prFont, Brushes.Black, 1, 120)
            e.Graphics.DrawString("Teléfono:071 200604", prFont, Brushes.Black, 1, 135)
            e.Graphics.DrawString("Actividad Económica:", prFont, Brushes.Black, 1, 150)
            prFont = New Font("MS Reference Sans Serif", 7, FontStyle.Regular)
            e.Graphics.DrawString("COMERCIO AL POR MENOR DE PRODUCTOS", prFont, Brushes.Black, 1, 165)
            e.Graphics.DrawString("DE PANADERÍA, CONFITERÍA Y PASTELERÍA", prFont, Brushes.Black, 1, 180)
            tmpIntLen = Len(Trim(sp_datosTabla.consulta_valorString("select direccion from v_sucursal where idSucursal=" & tmpIntIdSucursal))) + 10
            tmpIntTotalLen = tmpIntLen - 23
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 195)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Sucursal:'+rtrim(substring(direccion,1,23)) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 210)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select substring(direccion,24," & tmpIntTotalLen & ") from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 225)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef:'+rtrim(tele1) from v_sucursal where idSucursal=" & tmpIntIdSucursal), prFont, Brushes.Black, 1, 240)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 255)
            e.Graphics.DrawString("Tipo de Factura:" & tmpStrTipoFactura.ToString, prFont, Brushes.Black, 1, 270)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Timbrado:'+rtrim(timbrado) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 285)
            e.Graphics.DrawString("Fecha Inicio Vigencia: " & tmpStrFechaInicio, prFont, Brushes.Black, 1, 300)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("Nro. Factura Electronica:", prFont, Brushes.Black, 1, 315)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+" & _
                                                                     "[dbo].[funRellenarIzquierda](factura,'0',7-LEN(ltrim(factura))) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 330)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            'e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 300)
            If tmpIntTipoF = 1 Then
                prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
                e.Graphics.DrawString("                 DELIVERY                 ", prFont, Brushes.Black, 1, 345)
            End If

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 360)
            e.Graphics.DrawString("Fecha Hora:" + sp_datosTabla.consulta_valorString("select fechaAlta from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 375)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Cliente:'+rtrim(cliente) from cabVenta where idVenta=" & intIdVenta), prFont, Brushes.Black, 1, 390)
            e.Graphics.DrawString("RUC:" & tmpStrRuc, prFont, Brushes.Black, 1, 405)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Direc.:'+rtrim(direccion) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 420)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Telef.:'+rtrim([dbo].[funTelefonoPersona](idPersona)) from v_cliente where idCliente=" & tmpIntIdCliente), prFont, Brushes.Black, 1, 435)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Vendedor/a:'+rtrim(nombre) from v_vendedor where idVendedor=" & tmpIntIdVendedor), prFont, Brushes.Black, 1, 450)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 465)
            e.Graphics.DrawString(sp_datosTabla.consulta_valorString("select 'Forma de Venta:'+rtrim(nombreTipo) from v_tipoVenta where idTipoVenta=" & tmpIntIdTipoVenta), prFont, Brushes.Black, 1, 480)

            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("Codigo             Mercaderia                   ", prFont, Brushes.Black, 1, 495)
            e.Graphics.DrawString("Cant     Precio      %IVA        Subtotal   ", prFont, Brushes.Black, 1, 510)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, 525)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)

            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = ""

            ' MsgBox("Valor de Total Puntaje " & tmpIntTotalMaxiPunto)
            If tmpIntTotalMaxiPunto = 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL SIN MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,[dbo].[funNombreMercaderiaVenta](cv.idVenta,dv.idStock,dv.idProducto) as mercaderia, " & _
                        "([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        "dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        "(case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5 " & _
                        " from cabVenta cv inner join detVenta dv on cv.idVenta=dv.idVenta" & _
                        " inner join stock s on s.idStock=dv.idStock" & _
                        " inner join producto p on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " union " & _
                        " select 0,0,dv.concepto as Mercaderia,1 as cantidad,dv.monto,dv.monto,10 as porcentajeImpuesto," & _
                        " 0 as exenta,dv.monto as IVA10,0 as IVA5,	(dv.monto-(dv.monto/1.1)) as gravada10,	0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaComboEstudiante dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " union " & _
                        " select 0,0,'PROMO SAMSUNG CLUB 1/2 KG HELADO',1 as cantidad,0,0,10 as porcentajeImpuesto,0 as exenta,0 as IVA10," & _
                        " 0 as IVA5,0 as gravada10,0 as gravada5 " & _
                        " from cabVenta cv inner join detVentaPromoSamsung dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " order by dv.idStock desc"
            End If

            If tmpIntTotalMaxiPunto > 0 Then
                '---------------------------------------'
                '-- EL DETALLE NORMAL CON MAXI PUNTOS --'
                '---------------------------------------'
                sql = "select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as mercaderia," & _
                        " ([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " dv.precioDescuento,dv.subtotal,convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then dv.subtotal" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        "(case	" & _
                            " when dv.idImpuesto=3 then dv.subtotal" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then (dv.subtotal-(dv.subtotal/dv.factorImpuesto))" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join stock s" & _
                        " on s.idStock=dv.idStock" & _
                        " inner join producto p" & _
                        " on p.idProducto=s.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and (dv.subtotal > 0 or dv.subtotal < 0)" & _
                        " and dv.maxipunto=0" & _
                        " union " & _
                        " select dv.idStock,p.codigo,'PIZZAS Y PASTAS' as Mercaderia," & _
                        " sum([dbo].[funCantidadVenta](dv.idStock,dv.idProducto,dv.cantidad)) as cantidad," & _
                        " sum(dv.precioDescuento) as precioDescuento,sum(dv.precio) as subtotal," & _
                        " convert(int,dv.porcentajeImpuesto) as porcentajeImpuesto," & _
                        " (case " & _
                            " when dv.idImpuesto=1 then 0" & _
                            " else 0" & _
                        " end) as exenta," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " else 0" & _
                        " end) as IVA10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as IVA5," & _
                        " (case" & _
                            " when dv.idImpuesto=2 then 0" & _
                            " velse 0" & _
                        " end) as gravada10," & _
                        " (case	" & _
                            " when dv.idImpuesto=3 then 0" & _
                            " else 0" & _
                        " end) as gravada5" & _
                        " from cabVenta cv inner join detVenta dv" & _
                        " on cv.idVenta=dv.idVenta" & _
                        " inner join producto p" & _
                        " on p.idProducto=dv.idProducto" & _
                        " where cv.idVenta=" & intIdVenta & _
                        " and dv.precio > 0" & _
                        " and dv.maxipunto=1" & _
                        " group by dv.idStock, p.codigo,dv.idProducto, dv.precioDescuento, dv.precio,dv.idImpuesto, dv.maxipunto, dv.porcentajeImpuesto" & _
                        " union " & _
                        " select 0 as idStock,'0' as codigo,'DESCUENTOS CONCEDIDOS' as Mercaderia,1 as cantidad," & _
                        tmpIntTotalMaxiPunto & "as precioDescuento," & (tmpIntTotalMaxiPunto * -1) & "as subtotal," & _
                        " 10 as porcentajeImpuesto,0 as exenta,0 as IVA10,	0 as IVA5,0 as gravada10,0 as gravada5," & _
                        " from cabVenta cv " & _
                        " where cv.idVenta=" & intIdVenta & _
                        " order by tipoDet"
            End If

            'txtSql.Text = sql

            'MsgBox("Nombre y valor del SP  " & sql, MsgBoxStyle.Information)
            'frmPedidoMercaderia.txtSql.Text = sql
            'frmPassRepartidor.txtSql.Text = sql
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 540

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- sumar los impuestos
                        tmpDouTotalGra10 = tmpDouTotalGra10 + CDbl(reader.GetValue(10))
                        tmpDouTotalGra5 = tmpDouTotalGra5 + CDbl(reader.GetValue(11))
                        tmpDouTotalExenta = tmpDouTotalExenta + CDbl(reader.GetValue(7))

                        tmpDouTotalIVa10 = tmpDouTotalIVa10 + CDbl(reader.GetValue(8))
                        tmpDouTotalIVa5 = tmpDouTotalIVa5 + CDbl(reader.GetValue(9))

                        e.Graphics.DrawString(Trim(reader.GetValue(1).ToString) + " " + reader.GetValue(2).ToString, prFont, Brushes.Black, 1, tmpIntContador)
                        tmpIntContador = tmpIntContador + 15
                        e.Graphics.DrawString(Format(CDec(reader.GetValue(3)), "##0").ToString + "        " + Format(CDec(reader.GetValue(4)), "###,##0").ToString + _
                                              "        " + Format(CDec(reader.GetValue(6)), "##0").ToString + "%" + _
                                              "        " + Format(CDec(reader.GetValue(5)), "###,##0").ToString,
                                              prFont, Brushes.Black, 1, tmpIntContador)

                        tmpIntContador = tmpIntContador + 15
                    End While
                End Using

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & Me.ToString
                errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try

            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador)
            prFont = New Font("MS Reference Sans Serif", 10, FontStyle.Bold)
            e.Graphics.DrawString("TOTAL Gs.=" + Format(CDec(tmpDouTotalVenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 15)
            If tmpDouTotalDescuento > 0 Then
                prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
                e.Graphics.DrawString("Su descuento es:" & Format(CDec(tmpDouTotalDescuento), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 40)
            End If
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 55)
            If tmpDouTotalDescuento > 0 Then
                e.Graphics.DrawString("ESTA FACTURA CUENTA CON", prFont, Brushes.Black, 1, tmpIntContador + 70)
                e.Graphics.DrawString("MAXIDESCUENTO", prFont, Brushes.Black, 1, tmpIntContador + 85)

            End If
            e.Graphics.DrawString("-------------- Liquidación de IVA --------------", prFont, Brushes.Black, 1, tmpIntContador + 100)
            e.Graphics.DrawString("Gravada 10%:" + Format(CDec(tmpDouTotalIVa10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 115)
            e.Graphics.DrawString("Gravada 5%:" + Format(CDec(tmpDouTotalIVa5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 130)
            e.Graphics.DrawString("Exenta:" + Format(CDec(tmpDouTotalExenta), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 145)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 160)
            e.Graphics.DrawString("IVA 10%:" + Format(CDec(tmpDouTotalGra10), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 175)
            e.Graphics.DrawString("IVA 5%:" + Format(CDec(tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 190)
            e.Graphics.DrawString("Total IVA:" + Format(CDec(tmpDouTotalGra10 + tmpDouTotalGra5), "#,###,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 210)
            e.Graphics.DrawString("------------------------------------------------", prFont, Brushes.Black, 1, tmpIntContador + 225)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("DELIVERY: 071 205756 - 0985 830300", prFont, Brushes.Black, 1, tmpIntContador + 240)
            prFont = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            e.Graphics.DrawString("No se aceptan devoluciones pasadas las 48hs.", prFont, Brushes.Black, 1, tmpIntContador + 255)
            prFont = New Font("MS Reference Sans Serif", 9, FontStyle.Regular)
            If tmpIntTotalPuntaje > 0 Then
                '-- si tiene puntaje
                e.Graphics.DrawString("MaxiPunto:" + Format(CDec(tmpIntTotalPuntaje), "##,##0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 270)
            End If
            If tmpIntIdTipoVenta = 2 Then
                '-- factura a credito
                e.Graphics.DrawString("Firma:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 285)
                e.Graphics.DrawString("Aclaración:_____________________", prFont, Brushes.Black, 1, tmpIntContador + 300)
                e.Graphics.DrawString("Cant.Cuo.:" + Format(CDec(tmpIntTotalNroCuota), "#0").ToString, prFont, Brushes.Black, 1, tmpIntContador + 315)
            End If
            '-- esta parte corresponde a las especificaciones del manual tecnico de la SIFEN
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Consulte la validez de esta Factura Electrónica", prFont, Brushes.Black, 1, tmpIntContador + 355)
            e.Graphics.DrawString("con el número de CDC impreso abajo en : ", prFont, Brushes.Black, 1, tmpIntContador + 370)
            e.Graphics.DrawString(" https://ekuatia.set.gov/consultas/consultas ", prFont, Brushes.Black, 1, tmpIntContador + 385)
            prFont = New Font("Arial", 12, FontStyle.Bold)
            e.Graphics.DrawString(tmpStrCDC1, prFont, Brushes.Black, 1, tmpIntContador + 405)
            e.Graphics.DrawString(tmpStrCDC2, prFont, Brushes.Black, 1, tmpIntContador + 420)
            prFont = New Font("Arial", 9, FontStyle.Regular)
            e.Graphics.DrawString("Este documento es una representación ", prFont, Brushes.Black, 1, tmpIntContador + 440)
            e.Graphics.DrawString("gráfica de un documento electrónico(xml)", prFont, Brushes.Black, 1, tmpIntContador + 455)
            e.Graphics.DrawString("Información de Interés del facturador ", prFont, Brushes.Black, 1, tmpIntContador + 470)
            e.Graphics.DrawString("electrónico emisor. ", prFont, Brushes.Black, 1, tmpIntContador + 485)
            '--------------------------------------------------------------------------------

            e.HasMorePages = False

            'Me.BringToFront()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub imprimirTicketQR()
        Dim strCodigoQR As String
        Dim intIdMov As Integer = 0

        'Try
        '    '-- factura con Codigo QR
        '    '-- verificar si cuenta con codigo QR
        '    Dim client As New WebClient()
        '    intIdMov = sp_datosTabla.consulta_valor("select idMov from tmpFactuDE_A where tipoTransa=1 and idTransa=" & intIdVenta)
        '    Dim response As String = client.DownloadString("http://192.168.100.236:9090/api/qr/get/" & intIdMov)
        '    strCodigoQR = response
        'Catch ex As Exception
        '    'MsgBox("No entro")
        '    strCodigoQR = "http://ekuatia.set.gov.py/consultas/"
        'End Try

        ''-- insertar en la tabla temporal
        'If (fun_guardarSp("sp_actualizarCodigoQRVenta", intIdVenta & ",'" & Trim(strCodigoQR) & "'", Me.Name)) = 0 Then
        'End If
        crearQR()
        '-- la impresion
        imprimirVentaTicket(intIdVenta)

    End Sub

    Private Sub imprimirTicketQRCompartido()
        Dim strCodigoQR As String
        Dim intIdMov As Integer = 0

        'Try
        '    '-- factura con Codigo QR
        '    '-- verificar si cuenta con codigo QR
        '    Dim client As New WebClient()
        '    intIdMov = sp_datosTabla.consulta_valor("select idMov from tmpFactuDE_A where tipoTransa=1 and idTransa=" & intIdVenta)
        '    Dim response As String = client.DownloadString("http://192.168.100.236:9090/api/qr/get/" & intIdMov)
        '    strCodigoQR = response
        'Catch ex As Exception
        '    'MsgBox("No entro")
        '    strCodigoQR = "http://ekuatia.set.gov.py/consultas/"
        'End Try

        ''-- insertar en la tabla temporal
        'If (fun_guardarSp("sp_actualizarCodigoQRVenta", intIdVenta & ",'" & Trim(strCodigoQR) & "'", Me.Name)) = 0 Then
        'End If
        crearQR()
        '-- la impresion
        imprimirVentaTicketCompartido(intIdVenta)

    End Sub

    Private Sub crearQR()
        Dim datosQR As String = sp_datosTabla.consulta_valorString("select QR from detVentaDTE where idVenta=" & intIdVenta)
        Dim writer = New BarcodeWriter With {
            .Format = BarcodeFormat.QR_CODE,
            .Options = New ZXing.Common.EncodingOptions With {
                .Height = 200,
                .Width = 200
            }
        }
        Dim bitmap As Bitmap = writer.Write(datosQR)
        'bitmap.Save("codigoQR.png", ImageFormat.Png)
        bitmap.Save("c:\Multicolor\codigoQR.png", System.Drawing.Imaging.ImageFormat.Png)
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimero.Click
        Dim intTmpIdMov As Integer = 0
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            intTmpIdMov = sp_datosTabla.consulta_valor("select min(idVenta) from cve")
        Else
            '-- impreso
            intTmpIdMov = sp_datosTabla.consulta_valor("select min(idVenta) from cabVenta")
        End If

        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdMov As Integer = 0
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idVenta) from cve")
        Else
            '-- impreso
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idVenta) from cabVenta")
        End If
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdVenta.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdVenta.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de Venta
                If chkNoImpreso.Checked = True Then
                    '-- no impreso
                    If (sp_datosTabla.un_dato_integer("idventa", "cve", "idVenta", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                Else
                    '-- impreso
                    If (sp_datosTabla.un_dato_integer("idventa", "cabVenta", "idVenta", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdVenta.Text
                End If
            End While
            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If chkNoImpreso.Checked = True Then
                '-- no impreso
                If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idVenta) from cve") Then
                    'MsgBox("PAso por aca")
                    btnAnterior.Enabled = False
                    btnPrimero.Enabled = False
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                    txtIdVenta.Text = sp_datosTabla.consulta_valor("select min(idVenta) from cve")
                Else
                    txtIdVenta.Text = intTmpIdMov
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                End If
            Else
                '-- impreso
                If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idVenta) from cabVenta") Then
                    'MsgBox("PAso por aca")
                    btnAnterior.Enabled = False
                    btnPrimero.Enabled = False
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                    txtIdVenta.Text = sp_datosTabla.consulta_valor("select min(idVenta) from cabVenta")
                Else
                    txtIdVenta.Text = intTmpIdMov
                    btnSiguiente.Enabled = True
                    btnUltimo.Enabled = True
                End If
            End If
            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdVenta.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdVenta.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                '-- buscar el numero de Venta
                If chkNoImpreso.Checked = True Then
                    '-- no impreso
                    If (sp_datosTabla.un_dato_integer("idVenta", "cve", "idVenta", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                Else
                    '-- impreso
                    If (sp_datosTabla.un_dato_integer("idventa", "cabVenta", "idVenta", intTmpIdMov)) > 0 Then
                        banTmpEncontro = True
                    End If
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdVenta.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If chkNoImpreso.Checked = True Then
                '-- no impreso
                If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idVenta) from cve") Then
                    btnSiguiente.Enabled = False
                    btnUltimo.Enabled = False
                    btnAnterior.Enabled = True
                    btnPrimero.Enabled = True
                    txtIdVenta.Text = sp_datosTabla.consulta_valor("select max(idVenta) from cve")
                Else
                    btnAnterior.Enabled = True
                    txtIdVenta.Text = intTmpIdMov
                End If
            Else
                '-- impreso
                If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idVenta) from cabVenta") Then
                    btnSiguiente.Enabled = False
                    btnUltimo.Enabled = False
                    btnAnterior.Enabled = True
                    btnPrimero.Enabled = True
                    txtIdVenta.Text = sp_datosTabla.consulta_valor("select max(idventa) from cabVenta")
                Else
                    btnAnterior.Enabled = True
                    txtIdVenta.Text = intTmpIdMov
                End If
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If chkNoImpreso.Checked = True Then
            '-- n/impreso
            intGl_consultaVentaTipo = 2
        Else
            '-- impreso
            intGl_consultaVentaTipo = 1
        End If
        '-- inicializar las variables
        banGl_consultaVenta = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE VENTAS"
        frmAnular.lblIdMov.Text = txtIdVenta.Text
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
        Me.Enabled = False

        frmBuscarVenta.txtBuscar.Text = ""
        frmBuscarVenta.txtIdMov.Text = ""

        frmBuscarVenta.WindowState = FormWindowState.Normal
        frmBuscarVenta.Show()
        frmBuscarVenta.BringToFront()
        frmBuscarVenta.txtBuscar.Focus()

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim intTmpIdSucursal As Integer = 0
        Me.Enabled = False

        intIdVenta = CInt(txtIdVenta.Text)

        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intIdVenta)


        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabVenta where idVenta=" & intIdVenta)
        If sp_datosTabla.consulta_valor("select idSucursal from v_sucursal where FE=1 and idSucursal=" & intTmpIdSucursal) > 0 Then
            If sp_datosTabla.consulta_valor("select idConfig from configPc where codigoQR=1 and idConfig=" & intGl_idConfigPc) > 0 Then
                If sp_datosTabla.consulta_valor("select idConfig from configpc where impresoraCompartida=1 and idConfig=" & intGl_idConfigPc) > 0 Then
                    '-- impresion con codigo QR
                    imprimirTicketQRCompartido()
                Else
                    '-- impresion con codigo QR
                    imprimirTicketQR()
                End If
            Else
                '-- impresion sin codigo QR
                hojaImpresionSinQR.Print()
            End If
        End If

        Me.Enabled = True
    End Sub

    Private Sub btnCorreo_Click(sender As System.Object, e As System.EventArgs) Handles btnCorreo.Click
        '---------------------------------------'
        '----- buscar correo para enviar -------'
        '---------------------------------------'
        Dim strCorreo As String = ""
        intIdVenta = CInt(txtIdVenta.Text)
        strCorreo =sp_datosTabla.consulta_valorString("select p.email1 from cabVenta cv inner join v_cliente _vc " & _
                                                       " on cv.idCliente=_vc.idCliente inner join persona p " & _
                                                       " on p.idPersona=_vc.idPersona where cv.idVenta=" & intIdVenta)
        txtSql.Text = "select p.email1 from cabVenta cv inner join v_cliente _vc " & _
                                                       " on cv.idCliente=_vc.idCliente inner join persona p " & _
                                                       " on p.idPersona=_vc.idPersona where cv.idVenta=" & intIdVenta
        'strCorreo = "ninofer80@yahoo.com"
        If Len(Trim(strCorreo)) > 5 Then
            generarArchivoPdf(intIdVenta, Trim(strCorreo))
        Else
            MessageBox.Show("El cliente de la venta " & intIdVenta & " no tiene correo cargado.", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '***************'
    '-- CHECK BOX --'
    '***************'
    Private Sub chkNoImpreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoImpreso.CheckedChanged
        If chkNoImpreso.Checked = True Then
            lblNoImpreso.Visible = True
        Else
            lblNoImpreso.Visible = False
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaVenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intTmpIdMov As Integer = 0
        If chkNoImpreso.Checked = True Then
            '-- no impreso
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idVenta) from cve")
        Else
            '-- impreso
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idVenta) from cabVenta")
        End If
        ultimoRegistro(intTmpIdMov)
        banGl_buscarRemision = False

    End Sub

    Private Sub frmConsultaVenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteConsultaVentas.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------

End Class