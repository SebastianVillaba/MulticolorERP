Public Class frmAnular
    Dim sp_datosTabla As New sp_datosTabla
    Private sp_IngresoSistema As New sp_IngresoSistema

    Dim intIdUsuario As Integer
    Dim bolTarjeta As Boolean
    Dim bolError As Boolean

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMEINTOS --'
    '********************'
    '-- controlar el ingreso
    Private Sub controlarClave()
        If Len(txtPass.Text) > 0 Then
            '-- controlar primero si se ingreso el codigo de barras
            If Len(txtPass.Text) >= 12 Then
                '-- ingreso con la tarjeta
                bolTarjeta = True
            Else
                bolTarjeta = False
                'controlar que ingrese el usuario
                If txtUsuario.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar el Usuario..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtUsuario.Focus()
                    Exit Sub
                End If
            End If
            'controlar que ingrese alguna contraseña
            If txtPass.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe Ingresar la Contraseña..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtPass.Text = ""
                txtPass.Focus()
                Exit Sub
            End If
            If bolTarjeta = False Then
                '***********************'
                '-- NICK Y CONTRASEÑA --'
                '***********************'
                intIdUsuario = sp_datosTabla.sp_traerValorInteger("sp_claveUsuarioNick", "'" & txtUsuario.Text & "'" & "," & "'" & txtPass.Text & "'" & "," & 0, 3)
                'MsgBox("Valor de idUsuario  " & intIdUsuario)
                If intIdUsuario = 0 Then
                    '-- no existe el usuario
                    MessageBox.Show("No existe como Usuario dentro del Sistema..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    bolError = True
                    Exit Sub
                End If
            Else
                '*******************************'
                '-- TARJETA DE IDENTIFICACION --'
                '*******************************'
                intIdUsuario = sp_datosTabla.sp_traerValorInteger("sp_tarjetaUsuario", "'" & txtPass.Text & "'" & "," & 0, 3)

                If intIdUsuario = 0 Then
                    '-- no existe el usuario
                    MessageBox.Show("No existe como Usuario dentro del Sistema..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    bolError = True
                    Exit Sub
                End If
            End If
        End If

    End Sub

    '-- controlar el modulo
    Private Sub controlarModulo()
        If banGl_anularCompra = True Then
            '-- anular compra
            anularCompra()
        End If
        If banGl_anularNotaCredito = True Then
            '-- anular nota de credito
            anularNotaCredito()
        End If
        If banGl_consultaDepositoBanco = True Then
            '-- anular deposito bancario
            anularDepositoBanco()
        End If
        If banGl_consultaVenta = True Then
            '-- anular venta por consulta
            anularConsultaVenta()
        End If
        If banGl_consultaGastoProveedor = True Then
            '-- anular gasto del proveedor
            anularGastoProveedor()
        End If
        If banGl_consultaPagoProveedor = True Then
            '-- anular pago a proveedor
            anularPagoProveedor()
        End If
        If banGl_consultaCheque = True Then
            '-- anular cheques
            anularCheque()
        End If
        If banGl_consultaCobroCliente = True Then
            '-- anular cobranza
            anularCobroCliente()
        End If
        If banGl_anularNotaDebito = True Then
            '-- anular las devoluciones
            anularDevolucionVenta()
        End If
        If banGl_consultaOrdenCheque = True Then
            '-- anular la orden de cheques
            anularOrdenCheque()
        End If
        If banGl_consultaRetencionProveedor = True Then
            '-- anular retencion del proveedor
            anularRetencionProveedor()
        End If
        If banGl_consultaPlanillaCaja = True Then
            '-- anular planilla de caja
            anularPlanillaCaja()
        End If
        If banGl_consultaOrdenCoral = True Then
            '-- anular orden coral
            anularOrdenCoral()
        End If
        If banGl_consultaOrdenSuvinil = True Then
            '-- anular orden suvinil
            anularOrdenSuvinil()
        End If
        If banGl_consultaOrdenAutomotive = True Then
            '-- anular orden automotive
            anularOrdenAutomotive()
        End If
    End Sub

    '--- anulacion de la compra
    Private Sub anularCompra()
        Dim bolTmpImp As Boolean
        If frmConsultaCompra.chkNoImpreso.Checked = True Then
            bolTmpImp = False
        Else
            bolTmpImp = True
        End If
        '-- controlar si tiene permiso
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "COMPRA") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '------------------------------------
        '-- procedimiento que anula la compra
        If (fun_guardarSp("sp_anularCompra", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & bolTmpImp & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaCompra.actualizarCabeceraCompra(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaCompra.listarDetalleCompra(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular nota de credito
    Private Sub anularNotaCredito()
        '-- controlar si tiene permiso
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "NOTACR") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '----------------------------------------------------------------
        '-- procedimiento que anula la venta
        If (fun_guardarSp("sp_anularNotaCredito", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaNotaCredito.actualizarCabeceraNota(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaNotaCredito.listarDetalleNotaCredito(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular el deposito bancario
    Private Sub anularDepositoBanco()
        '-- controlar si tiene permiso
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "DEPBANCO") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '------------------------------------------------------------------------------

        '-- procedimiento que anula el deposito bancario
        If (fun_guardarSp("sp_anularDepositoBanco", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaDepositoBanco.actualizarCabecera(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaDepositoBanco.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anulacion de la venta en la Consulta
    Private Sub anularConsultaVenta()
        '-- si tiene permiso para anular 
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "VENTA") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '--------------------------------------------------------
        '-- procedimiento que anula la remision
        If (fun_guardarSp("sp_anularVenta", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & intGl_consultaVentaTipo, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaVenta.actualizarCabecera(CInt(lblIdMov.Text), intGl_consultaVentaTipo)
            '-- el detalle
            frmConsultaVenta.listarDetalle(CInt(lblIdMov.Text), intGl_consultaVentaTipo)
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anulacion del gasto del proveedor
    Private Sub anularGastoProveedor()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "GASTOPROV") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-------------------------------------------------
        '-- procedimiento que anula la remision
        If (fun_guardarSp("sp_anularGastoProveedor", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaGasto.actualizarCabecera(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaGasto.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anulacion del pago a proveedor
    Private Sub anularPagoProveedor()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "PAGOPROV") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-------------------------------------------------
        '-- procedimiento que anula la remision
        If (fun_guardarSp("sp_anularPagoProveedor", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaPagoProveedor.actualizarCabecera(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaPagoProveedor.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anulacion de cheques
    Private Sub anularCheque()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "CHEQUE") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-------------------------------------------------
        'MsgBox("Valor idCheque  " & intGl_idChequeConsultaCheque)
        'MsgBox("Valor idchequera  " & intGl_idChequeraConsultaCheque)
        'MsgBox("Valor de nroCheque  " & intGl_nroChequeConsultaCheque)

        ''-- procedimiento que anula la remision
        If (fun_guardarSp("sp_anularCheque", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idChequeConsultaCheque & "," & intGl_idChequeraConsultaCheque & "," & intGl_nroChequeConsultaCheque & "," & intIdUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaCheque.limpiar()
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anulacion de cobros
    Private Sub anularCobroCliente()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "COBRO") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-------------------------------------------------
        '-- procedimiento que anula la remision
        If (fun_guardarSp("sp_anularCobranza", intGl_idConfigPc & "," & intGl_idSucursal & "," & lblIdMov.Text & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            '-- la cabecera
            frmConsultaCobro.actualizarCabecera(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaCobro.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular devolucion de ventas
    Private Sub anularDevolucionVenta()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "DEVOLUCION") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '------------------------------------------------------------------

        '-- procedimiento que anula la recepcion
        If (fun_guardarSp("sp_anularDevolucion", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaDevolucionVenta.actualizarCabeceraNota(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaDevolucionVenta.listarDetalleNotaCredito(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular orden de cheque
    Private Sub anularOrdenCheque()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "ORDENCH") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '------------------------------------------------------------------

        '-- procedimiento que anula el orden de cheque
        If (fun_guardarSp("sp_anularOrdenCheque", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaOrdenCheque.actualizarCabecera(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaOrdenCheque.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '    '-- anular la retencion del proveedor
    Private Sub anularRetencionProveedor()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "RETECOM") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '----------------------------------------------------------------------------

        '-- procedimiento que anula el pedido de la sucursal
        If (fun_guardarSp("sp_anularRetencionProveedor", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaRetencionProveedor.actualizarCabeceraRetencion(CInt(lblIdMov.Text))
            '-- el detalle
            frmConsultaRetencionProveedor.listarDetalleRetencion(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular planilla de caja
    Private Sub anularPlanillaCaja()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "VENTA") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '----------------------------------------------------------------------------

        '-- procedimiento que anula el pedido de la sucursal
        If (fun_guardarSp("sp_anularPlanillaCaja", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaPlanillaCaja.actualizarCabecera(CInt(lblIdMov.Text))
            frmConsultaPlanillaCaja.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular orden de preparado coral
    Private Sub anularOrdenCoral()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "VENTA") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '----------------------------------------------------------------------------

        '-- procedimiento que anula el pedido de la sucursal
        If (fun_guardarSp("sp_anularOrdenCoral", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaPreparadoCoral.actualizarCabecera(CInt(lblIdMov.Text))
            frmConsultaPreparadoCoral.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular orden de preparado suvinil
    Private Sub anularOrdenSuvinil()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "VENTA") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '----------------------------------------------------------------------------

        '-- procedimiento que anula el pedido de la sucursal
        If (fun_guardarSp("sp_anularOrdenSuvinil", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaPreparadoSuvinil.actualizarCabecera(CInt(lblIdMov.Text))
            frmConsultaPreparadoSuvinil.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub

    '-- anular orden de preparado automotive
    Private Sub anularOrdenAutomotive()
        '-- si tiene permiso para anular
        If sp_datosTabla.sp_string("sp_permisoAnular", intIdUsuario & "," & "VENTA") = "" Then
            MessageBox.Show("Usted no cuenta con los permisos para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '----------------------------------------------------------------------------

        '-- procedimiento que anula el pedido de la sucursal
        If (fun_guardarSp("sp_anularOrdenAutomotive", CInt(lblIdMov.Text) & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & intIdUsuario & "," & "'" & Trim(txtExplica.Text) & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- volver al formulario con la actualizacion hecha
            '-- la cabecera
            frmConsultaPreparadoAutomotive.actualizarCabecera(CInt(lblIdMov.Text))
            frmConsultaPreparadoAutomotive.listarDetalle(CInt(lblIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub
    '-----------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIngresar.Click
        bolError = False
        controlarClave()
        If bolError = False Then
            If MessageBox.Show("Desea Anular este Movimiento..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                controlarModulo()
            End If
        End If
    End Sub
    '-----------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-----------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAnular_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_anularCompra = True Then
            banGl_anularCompra = False
            '-- para la compra
            frmConsultaCompra.Enabled = True
            frmConsultaCompra.WindowState = FormWindowState.Normal
            frmConsultaCompra.Show()
        End If
        If banGl_anularNotaCredito = True Then
            banGl_anularNotaCredito = False
            '-- para la nota de credito
            frmConsultaNotaCredito.Enabled = True
            frmConsultaNotaCredito.Show()
            frmConsultaNotaCredito.BringToFront()
        End If
        If banGl_consultaDepositoBanco = True Then
            banGl_consultaDepositoBanco = False
            '-- para la consulta de deposito bancario
            frmConsultaDepositoBanco.Enabled = True
            frmConsultaDepositoBanco.Show()
            frmConsultaDepositoBanco.BringToFront()
        End If
        If banGl_consultaVenta = True Then
            banGl_consultaVenta = False
            '-- para la consulta de venta
            frmConsultaVenta.Enabled = True
            frmConsultaVenta.Show()
            frmConsultaVenta.BringToFront()
        End If
        If banGl_consultaGastoProveedor = True Then
            banGl_consultaGastoProveedor = False
            '-- consulta gasto proveedor
            frmConsultaGasto.Enabled = True
            frmConsultaGasto.Show()
            frmConsultaGasto.BringToFront()
        End If

        If banGl_consultaPagoProveedor = True Then
            banGl_consultaPagoProveedor = False
            '-- consulta pago proveedor
            frmConsultaPagoProveedor.Enabled = True
            frmConsultaPagoProveedor.Show()
            frmConsultaPagoProveedor.BringToFront()
        End If

        If banGl_consultaCheque = True Then
            banGl_consultaCheque = False
            '-- consulta cheques
            frmConsultaCheque.Enabled = True
            frmConsultaCheque.Show()
            frmConsultaCheque.BringToFront()
        End If
        If banGl_consultaCobroCliente = True Then
            banGl_consultaCobroCliente = False
            '--- consulta cobro de clientes
            frmConsultaCobro.Enabled = True
            frmConsultaCobro.Show()
            frmConsultaCobro.BringToFront()
        End If
        If banGl_anularNotaDebito = True Then
            banGl_anularNotaDebito = False
            '--- consulta de recepcion de meracederias
            frmConsultaDevolucionVenta.Enabled = True
            frmConsultaDevolucionVenta.Show()
            frmConsultaDevolucionVenta.BringToFront()
        End If
        If banGl_consultaOrdenCheque = True Then
            banGl_consultaOrdenCheque = False
            '--- consulta de orden de cheques
            frmConsultaOrdenCheque.Enabled = True
            frmConsultaOrdenCheque.Show()
            frmConsultaOrdenCheque.BringToFront()
        End If
        If banGl_consultaRetencionProveedor = True Then
            banGl_consultaRetencionProveedor = False
            '--- consulta retencion del proveedor
            frmConsultaRetencionProveedor.Enabled = True
            frmConsultaRetencionProveedor.Show()
            frmConsultaRetencionProveedor.BringToFront()
        End If
        If banGl_consultaPlanillaCaja = True Then
            banGl_consultaPlanillaCaja = False
            '--- consulta de planilla de caja
            frmConsultaPlanillaCaja.Enabled = True
            frmConsultaPlanillaCaja.Show()
            frmConsultaPlanillaCaja.BringToFront()
        End If
        If banGl_consultaOrdenCoral = True Then
            banGl_consultaOrdenCoral = False
            '--- consulta orden preparado coral
            frmConsultaPreparadoCoral.Enabled = True
            frmConsultaPreparadoCoral.Show()
            frmConsultaPreparadoCoral.BringToFront()
        End If
        If banGl_consultaOrdenSuvinil = True Then
            banGl_consultaOrdenSuvinil = False
            '--- consulta orden preparado suvinil
            frmConsultaPreparadoSuvinil.Enabled = True
            frmConsultaPreparadoSuvinil.Show()
            frmConsultaPreparadoSuvinil.BringToFront()
        End If
        If banGl_consultaOrdenAutomotive = True Then
            banGl_consultaOrdenAutomotive = False
            '--- consulta orden preparado automotive
            frmConsultaPreparadoAutomotive.Enabled = True
            frmConsultaPreparadoAutomotive.Show()
            frmConsultaPreparadoAutomotive.BringToFront()
        End If
    End Sub
    '-----------------------------------------------------------------
End Class
