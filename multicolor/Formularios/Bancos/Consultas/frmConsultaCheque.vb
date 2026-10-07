Public Class frmConsultaCheque
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim cuentaCorriente As New cuentaCorriente

    Dim intIdChequera As Integer
    Dim intIdCheque As Integer
    Dim intIdCuenta As Integer
    Dim intIdPagoProveedor As Integer
    Dim intIdProveedor As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiar()
        '-- inicializar el combo de la cuenta corriente
        cuentaCorriente.cuentaCorrienteCombo(cboCuentaCorriente)
        '-- colocar los primeros digitos de acuerdo a la configuracion
        txtNroCheque.Focus()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub limpiar()
        '-- datos del cheque
        txtProveedor.Text = ""
        txtIdChequera.Text = 0
        txtIdCheque.Text = 0
        txtNroCheque1.Text = 0
        txtFechaCheque.Text = ""
        txtCuenta.Text = ""
        txtTotalCheque.Text = 0
        txtMoneda.Text = ""
        txtUsuario.Text = ""
        txtFechaHora.Text = ""
        txtSucursal.Text = ""
        lblEmpresaContable.Text = ""
        lblEstado.Text = ""
        '-- datos del pago
        txtIdPago.Text = 0
        txtNroRecibo.Text = 0
        txtFechaPago.Text = ""
        txtFechaHoraPago.Text = ""
        txtCargadoPor.Text = ""
        '-- el detalle del pago
        listarDetallePago(0, 0, 0, 0)
        '-- botones
        btnAceptar.Enabled = True
        btnAnular.Enabled = True
    End Sub

    Private Sub listarDetallePago(ByVal v_idmov As Integer, ByVal v_idCheque As Integer, ByVal v_idChequera As Integer, ByVal v_nroCheque As Integer)
        '-- detalle de los movimientos
        systemClass.SqlToLv_detallePagoProveedorMov(lvDetalleMov, "sp_consultaDetallePagoProveedorMovimientoCheque", v_idmov & "," & v_idCheque & "," & v_idChequera & "," & v_nroCheque)
    End Sub

    Public Sub mostrarDatosCheque(ByVal v_idCheque As Integer, ByVal v_idchequera As Integer, ByVal v_idProveedor As Integer)
        Try
            '**********************'
            '-- DATOS DEL CHEQUE --'
            '**********************'
            '-- idcheque
            txtIdCheque.Text = v_idCheque
            '-- idChequera
            txtIdChequera.Text = v_idchequera
            '-- proveedor
            'MsgBox("Valor de idProveedor  " & v_idProveedor)
            txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from v_proveedor where idProveedor=" & v_idProveedor)
            '-- nro cheque
            txtNroCheque1.Text = txtNroCheque.Text
            '-- fecha del cheque
            txtFechaCheque.Text = sp_datosTabla.consulta_valorString("select fecha from detCheque where idCheque=" & v_idCheque & " and idChequera=" & v_idchequera & _
                                                            " and idProveedor=" & v_idProveedor)
            '-- cuenta del cheque
            txtCuenta.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreBanco)+'/'+ltrim(nroCuenta) from cuentaCorriente where idCuenta=" & intIdCuenta)
            '-- total
            txtTotalCheque.Text = sp_datosTabla.consulta_valorString("select monto from detCheque where idCheque=" & v_idCheque & " and idChequera=" & v_idchequera & _
                                                            " and cheque=" & CInt(txtNroCheque.Text))
            txtTotalCheque.Text = Format(CDec(txtTotalCheque.Text), "###,###,###.##")
            '-- moneda
            Dim intTmpIdMoneda As Integer
            intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cuentaCorriente where idCuenta=" & intIdCuenta)
            txtMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIdMoneda)
            '-- cargado por
            Dim intTmpIdUsuario As Integer
            intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabCheque where idCheque=" & v_idCheque)
            'MsgBox("Valor de idUsuario Alta de Cheque  " & intTmpIdUsuario)
            txtUsuario.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
            '-- fecha hora carga
            txtFechaHora.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabCheque where idCheque=" & v_idCheque)
            '-- sucursal
            Dim intTmpIdSucursal As Integer
            intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabCheque where idCheque=" & v_idCheque)
            txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursalT where idSucursal=" & intTmpIdSucursal)
            '********************'
            '-- DATOS DEL PAGO --'
            '********************'
            '-- verificar si está anulado
            If (sp_datosTabla.consulta_valorBoolean("select habilitado from detCheque where idCheque=" & v_idCheque & " and idChequera=" & v_idchequera & " and cheque=" & CInt(txtNroCheque.Text))) = False Then
                lblEstado.Text = "ANULADO"
                lblEstado.ForeColor = Color.Red
                btnAnular.Enabled = False
                btnModificar.Enabled = False
            Else
                lblEstado.Text = "NORMAL"
                lblEstado.ForeColor = Color.Green
                btnAnular.Enabled = True
                btnModificar.Enabled = True
            End If
            '-- idProveedor
            txtIdPago.Text = intIdPagoProveedor
            '-- si está pagado
            If intIdPagoProveedor > 0 Then
                'MsgBox("PAso 1")
                '*************************'
                '-- PAGO A PROVEEDORES --'
                '*************************'

                lblEstado.Text = "PAGADO"
                lblEstado.ForeColor = Color.Blue
                btnAnular.Enabled = False
                '-- nro recibo
                txtNroRecibo.Text = sp_datosTabla.consulta_valor("select nroRecibo from cabPagoProveedor where idPagoProveedor=" & intIdPagoProveedor)
                '-- fecha
                txtFechaPago.Text = sp_datosTabla.consulta_valorString("select fecha from cabPagoProveedor where idPagoProveedor=" & intIdPagoProveedor)
                '-- fecha hora pago
                txtFechaHoraPago.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabPagoProveedor where idPagoProveedor=" & intIdPagoProveedor)
                '-- cargado por
                intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabPagoProveedor where idPagoProveedor=" & intIdPagoProveedor)
                txtCargadoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
                '-- la empresa contable
                Dim intTmpIdPersonaJur As Integer
                intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabPagoProveedor where idPagoProveedor=" & intIdPagoProveedor)

                lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonajur=" & intTmpIdPersonaJur)
                btnModificar.Enabled = False

            Else
                '*************************'
                '-- PAGO A FUNCIONARIOS --'
                '*************************'
                'MsgBox("PAso 2")
                btnModificar.Enabled = True
                If sp_datosTabla.consulta_valor("select dch.idCheque from detcheque dch inner join v_proveedor _vp on dch.idProveedor=_vp.idProveedor " & _
                                                " inner join v_personalT _vpe on _vpe.idPersona=_vp.idPersona where dch.pagado=1 and dch.cheque=" & CInt(txtNroCheque1.Text)) > 0 Then

                    'MsgBox("PAso 3")
                    lblEstado.Text = "PAGADO"
                    lblEstado.ForeColor = Color.Blue
                    btnAnular.Enabled = False
                    '-- nro recibo
                    txtNroRecibo.Text = 0
                    '-- fecha
                    txtFechaPago.Text = ""
                    '-- fecha hora pago
                    txtFechaHoraPago.Text = ""
                    '-- cargado por
                    'intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabPagoProveedor where idPagoProveedor=" & intIdPagoProveedor)
                    'txtCargadoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from v_usuarioT where idUsuario=" & intTmpIdUsuario)
                    '-- la empresa contable
                    'Dim intTmpIdPersonaJur As Integer
                    'intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from cabPagoProveedor where idPagoProveedor=" & intIdPagoProveedor)

                    'lblEmpresaContable.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_empresaContable where idPersonajur=" & intTmpIdPersonaJur)
                    btnModificar.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '-------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            '-- dar valor a la variable
            intIdCuenta = cboCuentaCorriente.SelectedValue
            '-- verificar si existe el cheque ingresado
            'txtSql.Text = "select cheque from detCheque dch inner join chequera ch on ch.idChequera=dch.idchequera where dch.cheque=" & CInt(txtNroCheque.Text) & " and ch.idCuenta=" & intIdCuenta

            If sp_datosTabla.consulta_valor("select cheque from detCheque dch inner join chequera ch on ch.idChequera=dch.idchequera where dch.cheque=" & CInt(txtNroCheque.Text) & " and ch.idCuenta=" & intIdCuenta) = 0 Then
                MessageBox.Show("El Nro de Cheque Ingresado no Existe..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                limpiar()
                Exit Sub
            End If
            '-- listar si existe el pago
            '-- obtener el idCheque
            intIdCheque = sp_datosTabla.consulta_valor("select dch.idCheque from detCheque dch inner join chequera ch on dch.idChequera=ch.idChequera where dch.cheque=" & CInt(txtNroCheque.Text) & " and ch.idCuenta=" & intIdCuenta)
            '-- obtener el idChequera
            intIdChequera = sp_datosTabla.consulta_valor("select dch.idChequera from detCheque dch inner join chequera ch on dch.idChequera=ch.idChequera where dch.cheque=" & CInt(txtNroCheque.Text) & " and ch.idCuenta=" & intIdCuenta)
            '-- obtener el idPago
            intIdPagoProveedor = sp_datosTabla.consulta_valor("select dp.idPagoProveedor from detPagoProveedorCheque dp " & _
            " inner join cabPagoProveedor cp on dp.idPagoProveedor=cp.idPagoProveedor  where cp.activo=1 and idCheque=" & intIdCheque & " and idChequera=" & intIdChequera & " and cheque=" & CInt(txtNroCheque.Text))
            '-- obtener el idProveedor
            intIdProveedor = sp_datosTabla.consulta_valor("select idProveedor from detCheque where idChequera=" & intIdChequera & "and cheque=" & CInt(txtNroCheque.Text))
            '-- datos del cheque
            mostrarDatosCheque(intIdCheque, intIdChequera, intIdProveedor)
            '-- datos del pago por cheque
            listarDetallePago(intIdPagoProveedor, intIdCheque, intIdChequera, CInt(txtNroCheque.Text))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try


    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaCheque = True
        intGl_idChequeConsultaCheque = intIdCheque
        intGl_idChequeraConsultaCheque = intIdChequera
        intGl_nroChequeConsultaCheque = txtNroCheque.Text

        frmAnular.lblProcedimiento.Text = "ANULACION DE CHEQUES"
        frmAnular.lblIdMov.Text = txtNroCheque.Text
        frmAnular.txtPass.Text = ""
        frmAnular.txtUsuario.Text = ""
        '----------------------------
        Me.Enabled = False
        frmAnular.WindowState = FormWindowState.Normal
        frmAnular.Show()
        frmAnular.BringToFront()
        frmAnular.txtUsuario.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '--- si no hay cheque
        If txtNroCheque.Text = 0 Or Len(txtNroCheque.Text) = 0 Then
            MessageBox.Show("No se ingresó ningún cheque..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        '-- controlar que el usuario tenga permiso
        If sp_datosTabla.consulta_valor("select idUsuario from usuario where anularCheque=0 and idUsuario=" & intGl_idUsuario) > 0 Then
            MessageBox.Show("No tiene los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.Enabled = False
        frmModificarCheque.Visible = True
        frmModificarCheque.Show()
        frmModificarCheque.BringToFront()
        frmModificarCheque.txtIdChequera.Text = txtIdChequera.Text
        frmModificarCheque.txtIdCheque.Text = txtIdCheque.Text
        frmModificarCheque.txtProveedor.Text = txtProveedor.Text
        frmModificarCheque.txtProveedor2.Text = txtProveedor.Text
        frmModificarCheque.txtNroCheque1.Text = txtNroCheque1.Text
        frmModificarCheque.txtFechaCheque.Text = txtFechaCheque.Text
        frmModificarCheque.dtpFechaCheque.Text = txtFechaCheque.Text
        frmModificarCheque.txtCuenta.Text = txtCuenta.Text
        frmModificarCheque.txtTotalCheque.Text = txtTotalCheque.Text
        frmModificarCheque.txtMontoCheque.Text = txtTotalCheque.Text
        frmModificarCheque.txtMoneda.Text = txtMoneda.Text
        frmModificarCheque.txtUsuario.Text = txtUsuario.Text
        frmModificarCheque.txtFechaHora.Text = txtFechaHora.Text
        frmModificarCheque.txtSucursal.Text = txtSucursal.Text
        frmModificarCheque.lblEmpresaContable.Text = lblEmpresaContable.Text
        '--- el idProveedor
        frmModificarCheque.txtIdProveedor2.Text = sp_datosTabla.consulta_valor("select idProveedor from detCheque where cheque=" & txtNroCheque.Text)
        frmModificarCheque.btnBuscar.Focus()
    End Sub
    '-------------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtNroCheque_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCheque.KeyPress
        e.Handled = txtNumerico(txtNroCheque, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmConsultaCheque_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoConsultasCheques.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------------

End Class
