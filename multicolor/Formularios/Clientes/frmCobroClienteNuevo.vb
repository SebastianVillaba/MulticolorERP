Public Class frmCobroClienteNuevo
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim bolError As Boolean
    Dim intIdMov As Integer = 0
    Dim douSaldo As Double = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiarObjetos()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub limpiarObjetos()

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
        txtMonto.Text = 0
        txtIdMov.Text = 0
        '-- el listview
        listarDetallePago(" where idConfig=" & intGl_idConfigPc)
        txtTotalMonto.Text = 0
        txtTotalPagado.Text = 0
        txtTotalSaldo.Text = 0

        txtCantidadCobrada.Text = 0
        txtMaximaCantidad.Text = 10
    End Sub

    Public Sub sumarTotales()
        Try
            If sp_datosTabla.consulta_valorDouble("select idConfig from tmpCobroCliente where idConfig=" & intGl_idConfigPc) > 0 Then
                txtTotalMonto.Text = sp_datosTabla.consulta_valorDouble("select sum(montoCuota) from tmpCobroCliente where idConfig=" & intGl_idConfigPc)
                txtTotalMonto.Text = Format(CDbl(txtTotalMonto.Text), "###,###,##0.##")
                txtPagado.Text = sp_datosTabla.consulta_valorDouble("select sum(pago) from tmpCobroCliente where idConfig=" & intGl_idConfigPc)
                txtPagado.Text = Format(CDbl(txtPagado.Text), "###,###,##0.##")
                txtTotalPagado.Text = sp_datosTabla.consulta_valorDouble("select sum(pagado) from tmpCobroCliente where idConfig=" & intGl_idConfigPc)
                txtTotalPagado.Text = Format(CDbl(txtTotalPagado.Text), "###,###,##0.##")
                txtTotalSaldo.Text = sp_datosTabla.consulta_valorDouble("select sum(saldo) from tmpCobroCliente where idConfig=" & intGl_idConfigPc)
                txtTotalSaldo.Text = Format(CInt(txtTotalSaldo.Text), "###,###,##0")
                txtTotalRetencion.Text = sp_datosTabla.consulta_valorDouble("select sum(retencion) from tmpCobroCliente where idConfig=" & intGl_idConfigPc)
                txtTotalRetencion.Text = Format(CDbl(txtTotalRetencion.Text), "###,###,##0.##")

                '-- actualizar la cantidad de factura pagada
                txtCantidadCobrada.Text = sp_datosTabla.consulta_valor("select count(*) from tmpCobroCliente where habPago=1 and idConfig=" & intGl_idConfigPc)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Public Sub listarDetallePago(ByVal where As String)
        '-- el detalle
        systemClass.SqlToLvDetalleCobroCliente(lvCabPago, "Select nroFactura,idMovimiento,sucursal,vence,nroCuota,montoCuota,notaCredito," & _
                                               "retencion,pagado,pago,saldo,habPago,tipo from tmpCobroCliente  " & where)
    End Sub

    Private Sub controlarCobro()
        '-- controlar si existe un total
        If IsNumeric(txtPagado.Text) Then
            If txtPagado.Text <= 0 Then
                MessageBox.Show("El Total no es el Correcto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                bolError = True
                Exit Sub
            End If
        End If

        If CDbl(txtCantidadCobrada.Text) > CDbl(txtMaximaCantidad.Text) Then
            MessageBox.Show("La cantidad de factura cobrada supera la cantidad máxima..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If
    End Sub

    Private Sub cargarPago()
        If txtIdMov.Text = 0 Then
            '-- pago por orden
            If (fun_guardarSp("sp_updTmpCobroCliente", intGl_idConfigPc & "," & CDbl(sacarComa(txtMonto.Text)), Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros del Cobro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                listarDetallePago("where idConfig=" & intGl_idConfigPc)
                sumarTotales()
            End If
        Else
            '-- pago por movimiento
            If (fun_guardarSp("sp_updTmpCobroCliente_idMov", intGl_idConfigPc & "," & CDbl(sacarComa(txtIdMov.Text)) & "," & CDbl(sacarComa(txtMonto.Text)), Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo cargar el cobro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                listarDetallePago("where idConfig=" & intGl_idConfigPc)
                sumarTotales()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        banGl_cobroClienteNuevo = True

        frmBuscarClienteVenta.txtIdCliente.Text = ""
        frmBuscarClienteVenta.Show()
        frmBuscarClienteVenta.BringToFront()
        frmBuscarClienteVenta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpiarObjetos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarCobro()
        If bolError = False Then
            Me.Enabled = False
            '-- colocar los datos 
            frmGuardarCobro.txtIdCliente.Text = txtIdCliente.Text
            frmGuardarCobro.txtCliente.Text = txtCliente.Text
            frmGuardarCobro.txtDireccion.Text = txtDireccion.Text
            frmGuardarCobro.txtCel1.Text = txtCel1.Text
            frmGuardarCobro.txtCel2.Text = txtCel2.Text
            frmGuardarCobro.txtEmail.Text = txtEmail.Text
            frmGuardarCobro.txtGrupo.Text = txtGrupo.Text
            frmGuardarCobro.txtPagado.Text = txtPagado.Text
            frmGuardarCobro.txtPagado.Text = Format(CDbl(frmGuardarCobro.txtPagado.Text), "###,###,##0.##")

            frmGuardarCobro.txtDsuc.Text = ""
            frmGuardarCobro.txtDcaja.Text = ""
            frmGuardarCobro.txtRecibo.Text = ""
            frmGuardarCobro.txtDescuento.Text = 0
            frmGuardarCobro.txtPorceDescuento.Text = 0
            frmGuardarCobro.chkCombinado.Checked = False
            frmGuardarCobro.txtMontoCombinado.Text = 0
            '-- la empresa contable
            'MsgBox("Valor de idPersonaJur  " & intGl_idPersonaJur)
            frmGuardarCobro.lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresacontable where idPersonaJur=" & intGl_idPersonaJur)
            '--------------------------
            frmGuardarCobro.Show()
            frmGuardarCobro.BringToFront()
            frmGuardarCobro.txtDsuc.Focus()
        End If
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If CDbl(sacarComa(txtMonto.Text)) <= 0 Then
            MessageBox.Show("El monto ingresado no es válido...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If CDbl(sacarComa(txtMonto.Text)) > CDbl(sacarComa(txtTotalSaldo.Text)) Then
            MessageBox.Show("El monto no puede ser mayor al saldo actual...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If CDbl(sacarComa(txtPagado.Text)) > 0 Then
            MessageBox.Show("No puede volver a ingresar algún monto si ya lo realizó...! Cancele y vuelva a intentarlo", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        cargarPago()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtIdMov_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdMov.KeyPress
        e.Handled = txtNumerico(txtIdMov, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(Trim(txtIdMov.Text)) = 0 Then
                txtIdMov.Text = 0
            End If
            e.Handled = True
            txtIdMov.Text = Format(CDbl(txtIdMov.Text), "###,###,##0")
            txtMonto.Focus()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtMonto.Text = Format(CDbl(txtMonto.Text), "###,###,##0.##")
            btnProcesar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCabPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCabPago.SelectedIndexChanged
        For Each item As ListViewItem In lvCabPago.SelectedItems
            intIdMov = CInt(item.SubItems(1).Text)
            douSaldo = CDbl(item.SubItems(10).Text)
        Next
    End Sub

    Private Sub lvCabPago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCabPago.GotFocus
        For Each item As ListViewItem In lvCabPago.SelectedItems
            intIdMov = CInt(item.SubItems(1).Text)
            douSaldo = CDbl(item.SubItems(10).Text)
        Next
    End Sub

    Private Sub lvCabPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCabPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If intIdMov > 0 Then
                Me.Enabled = False

                frmMontoFacturaCliente.lblCliente.Text = txtCliente.Text
                frmMontoFacturaCliente.lblIdMov.Text = intIdMov
                frmMontoFacturaCliente.lblSaldo.Text = douSaldo
                frmMontoFacturaCliente.lblSaldo.Text = Format(CDbl(frmMontoFacturaCliente.lblSaldo.Text), "###,###,##0")
                frmMontoFacturaCliente.txtMonto.Text = douSaldo
                frmMontoFacturaCliente.txtMonto.Text = Format(CDbl(frmMontoFacturaCliente.txtMonto.Text), "###,###,##0")

                frmMontoFacturaCliente.Show()
                frmMontoFacturaCliente.BringToFront()
                frmMontoFacturaCliente.btnAceptar.Focus()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCobroClienteNuevo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteCobro.Enabled = True

        e.Cancel = False
    End Sub
    '------------------------------------------------------------------------------

End Class