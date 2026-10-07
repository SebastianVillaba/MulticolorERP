Public Class frmHistoricoCliente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiarObjetos()
        '-- los txt
        txtIdCliente.Text = 0
        txtCliente.Text = ""
        txtCel1.Text = ""
        txtCel2.Text = ""
        txtDireccion.Text = ""
        txtEmail.Text = ""
        txtGrupo.Text = ""
        txtTotalMonto.Text = 0
        txtTotalPagado.Text = 0
        txtTotalSaldo.Text = 0
        txtTotalNotaCredito.Text = 0
        '-- los chk
        chkPendiente.Checked = False
        '-- los listview
        listarCabeceraPago(" where idconfig=0")
    End Sub

    Public Sub listarCabeceraPago(ByVal v_idClente As Integer)
        '-- la cabecera
        'systemClass.SqlToLvCabeceraPagoHistoricoCliente(lvCabPago, "Select factura,sucursal,fecha,monto,notaCredito,pagado,saldo,cuoTotal,cuoPagado,tipo,idMov from tmpCabPagoCliente  " & where)
        systemClass.SqlToLv_cabeceraHistoricoCliente(lvCabPago, "sp_consultaCabeceraHistoricoCliente", v_idClente)
        '-- sumar los totales
        'txtTotalMonto.Text = sp_datosTabla.consulta_valorDouble("select sum(monto) from tmpCabPagoCliente " & where & " group by idConfig")
        'txtTotalMonto.Text = Format(CDec(txtTotalMonto.Text), "##,###,###")
        'txtTotalPagado.Text = sp_datosTabla.consulta_valorDouble("select sum(pagado) from tmpCabPagoCliente " & where & " group by idConfig")
        'txtTotalPagado.Text = Format(CDec(txtTotalPagado.Text), "##,###,###")
        'txtTotalSaldo.Text = sp_datosTabla.consulta_valorDouble("select sum(saldo) from tmpCabPagoCliente " & where & " group by idConfig")
        'txtTotalSaldo.Text = Format(CDec(txtTotalSaldo.Text), "##,###,###")
        'txtTotalNotaCredito.Text = sp_datosTabla.consulta_valorDouble("select sum(notaCredito) from tmpCabPagoCliente " & where & " group by idConfig")
        'txtTotalNotaCredito.Text = Format(CDec(txtTotalNotaCredito.Text), "##,###,###")
        '-- el detalle
        'listarDetallePago(" where idConfig=0")
        '-- la mercaderia
        listarDetalleMercaderia(0, 0)
    End Sub

    Public Sub listarCabeceraPagoConsulta(ByVal v_idClente As Integer)
        '-- la cabecera
        systemClass.SqlToLv_cabeceraHistoricoCliente(lvCabPago, "sp_consultaCabeceraHistoricoClienteConsulta", v_idClente & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & _
                                                     dtpHastaFecha.Text & "'" & "," & chkPendiente.Checked)
        '-- el detalle
        listarDetallePago(0, 0)
        '-- la mercaderia
        listarDetalleMercaderia(0, 0)
    End Sub

    Private Sub listarDetallePago(ByVal v_idMov As Integer, ByVal v_tipo As Integer)
        '-- el detalle
        'systemClass.SqlToLvDetallePagoHistoricoCliente(lvDetPago, "Select nroCuota,montoCuota,pagado,saldo,nroRecibo,fechaPago,vence,dia,cobrador,vencido from tmpDetPagoCliente  " & where)
        systemClass.SqlToLv_detalleHistoricoCliente(lvDetPago, "sp_consultaDetalleHistoricoCliente", txtIdCliente.Text & "," & v_idMov & "," & v_tipo)
    End Sub

    Private Sub listarDetalleMercaderia(ByVal v_idMov As Integer, ByVal v_tipo As Integer)
        systemClass.SqlToLv_detalleMercaderiaHistorico(lvDetalleFactura, "sp_mostrarMercaderiasVenta", v_idMov & "," & v_tipo)
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        banGl_historicoCliente = True

        frmBuscarClienteVenta.txtIdCliente.Text = ""
        frmBuscarClienteVenta.Show()
        frmBuscarClienteVenta.BringToFront()
        frmBuscarClienteVenta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Me.Enabled = False
        frmReporteHistorico.lblIdCliente.Text = txtIdCliente.Text
        frmReporteHistorico.lblIdCuota.Text = lblIdCuota.Text
        frmReporteHistorico.Show()
        frmReporteHistorico.BringToFront()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If IsNumeric(txtIdCliente.Text) Then
            If txtIdCliente.Text > 0 Then
                '-- relizar de vuelta la consulta
                Me.Enabled = False

                ''-- el procedimiento
                'sp_datosTabla.sp_string("sp_insTmpCuentaCliente", intGl_idConfigPc & "," & CInt(txtIdCliente.Text))

                ''-- eliminar todos los que ya se pagaron
                'sp_datosTabla.sp_string("sp_actualizarHistoricoCliente", intGl_idConfigPc & "," & chkPendiente.Checked & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'")

                listarCabeceraPagoConsulta(txtIdCliente.Text)
            End If
            Me.Enabled = True
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCabPago_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvCabPago.SelectedIndexChanged
        '-- inicializar variables temporales
        Dim intTmpIdMov As Integer
        Dim intTmpTipo As Integer
        Dim intTmpIdCuota As Integer

        For Each item As ListViewItem In lvCabPago.SelectedItems
            '-- dar valor a las variables
            intTmpIdMov = item.SubItems(10).Text
            intTmpTipo = item.SubItems(9).Text
            '-- listar el detalle del producto
            listarDetalleMercaderia(intTmpIdMov, intTmpTipo)
            '-- listar el detalle de las cuota
            listarDetallePago(intTmpIdMov, intTmpTipo)
            '-- idCuota
            intTmpIdCuota = sp_datosTabla.consulta_valor("select idCuota from cabCuota where idMovimiento=" & intTmpIdMov & " and tipo=" & intTmpTipo)
            lblIdCuota.Text = intTmpIdCuota
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmHistoricoCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteConsultaHistorico.Enabled = True

        e.Cancel = False
    End Sub
    '------------------------------------------------------------------------------
End Class