Public Class frmConsultaOrdenCheque
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
        systemClass.SqlToLv_detalleConsultaOrdenCheque(lvCheque, "sp_consultaDetalleOrdenCheque", v_idMov)
    End Sub

    Public Sub actualizarCabecera(ByVal v_idMov As Integer)
        Try
            ' MsgBox("Valor de idCompra en la consulta  " & v_idnota)
            '******************'
            '-- LA COBRANZA --'
            '******************'
            '-- el idCobranza
            txtIdOrden.Text = v_idMov
            '-- el numero de factura y la fecha mas adelante
            '-- responsable de la carga
            Dim intTmpIdUsuario As Integer = 0
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabOrdenCheque", "idOrdenCheque", v_idMov)
            txtCargadoPor.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabOrdenCheque", "idOrdenCheque", v_idMov)
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cabOrdenCheque", "idOrdenCheque", v_idMov) = True Then
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
                '-- si ya está impreso
                If sp_datosTabla.consulta_valorBoolean("select impreso from cabOrdenCheque where idOrdenCheque=" & v_idMov) = True Then
                    '-- impresion del cheque
                    lblImpreso.Text = "CHEQUES IMPRESOS"
                    lblImpreso.ForeColor = Color.Blue
                    btnAnular.Enabled = False
                Else
                    '-- no impresion de los cheques
                    lblImpreso.Text = "CHEQUES NO IMPRESOS"
                    lblImpreso.ForeColor = Color.Red
                    btnAnular.Enabled = True
                End If
            Else
                '-- si está anulado
                btnAnular.Enabled = False
                lblEstado.Text = "ANULADO"
                btnAnular.Enabled = False
                lblEstado.ForeColor = Color.Red
                '--- datos de la anulacion
                Dim intTmpIdUsuarioAnulado As Integer
                intTmpIdUsuarioAnulado = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idMov & " and tipo='ORDENCH'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idMov & " and tipo='ORDENCH'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idMov & _
                                                                   " and tipo='ORDENCH'")
                '---------------------------------------------------------------------------------------------------------------------
                '-- si ya está impreso
                If sp_datosTabla.consulta_valorBoolean("select impreso from cabOrdenCheque where idOrdenCheque=" & v_idMov) = True Then
                    '-- impresion del cheque
                    lblImpreso.Text = "CHEQUES IMPRESOS"
                    lblImpreso.ForeColor = Color.Blue
                Else
                    '-- no impresion de los cheques
                    lblImpreso.Text = "CHEQUES NO IMPRESOS"
                    lblImpreso.ForeColor = Color.Red
                End If
            End If
            '-- nombre de la pc
            txtPc.Text = sp_datosTabla.consulta_valorString("select nombrePc from configPc where idConfig=" & sp_datosTabla.consulta_valor _
            ("select idConfig from cabOrdenCheque where idOrdenCheque=" & v_idMov))
            '-- el nombre de la cuenta corriente
            Dim intTmpIdCuenta As Integer
            intTmpIdCuenta = sp_datosTabla.consulta_valor("select idCuenta from cabOrdenCheque where idOrdenCheque=" & v_idMov)
            txtCuentaCorriente.Text = sp_datosTabla.consulta_valorString("select nroCuenta from cuentaCorriente where idCuenta=" & intTmpIdCuenta)
            '-- la moneda
            Dim intTmpIdMoneda As Integer
            intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cuentaCorriente where idCuenta=" & intTmpIdCuenta)
            txtMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIdMoneda)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
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
        intTmpIdMov = sp_datosTabla.consulta_valor("select min(idOrdenCheque) from cabOrdenCheque")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select max(idOrdenCheque) from cabOrdenCheque")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de siguiente
        btnUltimo.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        If IsNumeric(txtIdOrden.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdOrden.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov - 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idOrdenCheque", "cabOrdenCheque", "idOrdenCheque", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdOrden.Text
                End If
            End While
            ' MsgBox("Valor de intTmpIdCaja  " & intTmpIdCaja)

            '-------------------------------------------
            '-- si llega al primer registro inhabilitar
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idOrdenCheque) from cabOrdenCheque") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdOrden.Text = sp_datosTabla.consulta_valor("select min(idOrdenCheque) from cabOrdenCheque")
            Else
                txtIdOrden.Text = intTmpIdMov
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
            End If
            anteriorRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If IsNumeric(txtIdOrden.Text) Then
            Dim intTmpIdMov As Integer = 0
            Dim banTmpEncontro As Boolean = False
            Dim intTmpContador As Integer = 0
            intTmpIdMov = txtIdOrden.Text
            '-- un ciclo hasta que exista el idCaja
            While banTmpEncontro = False
                intTmpContador = intTmpContador + 1
                intTmpIdMov = intTmpIdMov + 1
                '-- buscar el numero de idPedido
                If (sp_datosTabla.un_dato_integer("idOrdenCheque", "cabOrdenCheque", "idOrdenCheque", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdOrden.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idOrdenCheque) from cabOrdenCheque") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdOrden.Text = sp_datosTabla.consulta_valor("select max(idOrdenCheque) from cabOrdenCheque")
            Else
                btnAnterior.Enabled = True
                txtIdOrden.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaOrdenCheque = True
        frmAnular.lblProcedimiento.Text = "ANULACION DE ORDEN DE CHEQUES"
        frmAnular.lblIdMov.Text = txtIdOrden.Text
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

        frmBuscarOrdenCheque.txtBuscar.Text = ""
        frmBuscarOrdenCheque.txtIdMov.Text = ""

        frmBuscarOrdenCheque.WindowState = FormWindowState.Normal
        frmBuscarOrdenCheque.Show()
        frmBuscarOrdenCheque.BringToFront()
        frmBuscarOrdenCheque.txtBuscar.Focus()

    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaOrdenCheque_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If banGl_buscarOrdenCheque = False Then
            Dim intTmpIdMov As Integer = 0
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idOrdenCheque) from cabOrdenCheque")
            ultimoRegistro(intTmpIdMov)
            banGl_buscarOrdenCheque = False
        End If
    End Sub

    Private Sub frmConsultaOrdenCheque_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoConsultasOrdenCheque.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------
End Class