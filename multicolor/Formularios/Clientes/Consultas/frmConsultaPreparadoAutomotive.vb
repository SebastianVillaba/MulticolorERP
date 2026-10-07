Public Class frmConsultaPreparadoAutomotive
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
        systemClass.SqlToLv_listarOrdenPreparadoAutomotive(lvOrden, "sp_consultaDetOrdenAutomotive", v_idMov)
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
            intTmpIdUsuario = sp_datosTabla.un_dato_integer("idUsuarioAlta", "cabOrdenAutomotive", "idOrdenAutomotive", v_idMov)
            txtCargadoPor.Text = Trim(sp_datosTabla.un_datoString("nombre", "v_usuarioT", "idUsuario", intTmpIdUsuario)) & "," & Trim(sp_datosTabla.un_datoString("apellido", "v_usuarioT", "idUsuario", intTmpIdUsuario))
            '-- fecha y hora de carga
            txtFechaHora.Text = sp_datosTabla.un_datoString("fechaAlta", "cabOrdenAutomotive", "idOrdenAutomotive", v_idMov)
            '-- el estado
            If sp_datosTabla.un_dato_boleano("activo", "cabOrdenAutomotive", "idOrdenAutomotive", v_idMov) = True Then
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
                                                                    v_idMov & " and tipo='ORDENAUTO'")
                txtAnuladoPor.Text = sp_datosTabla.consulta_valorString("select rtrim(nombre)+','+ltrim(apellido) from " & _
                                                                     "v_usuarioT where idUsuario=" & intTmpIdUsuarioAnulado)
                txtFechaAnulado.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabAnulado where idMovimiento=" & _
                                                                    v_idMov & " and tipo='ORDENAUTO'")
                txtExplica.Text = sp_datosTabla.consulta_valorString("select explica from cabAnulado where idMovimiento=" & v_idMov & _
                                                                   " and tipo='ORDENAUTO'")
                '---------------------------------------------------------------------------------------------------------------------
            End If
            '-- total 
            txtTotal.Text = sp_datosTabla.consulta_valorDouble("select total from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,##0.##")
            '-- el color
            txtCodigo.Text = sp_datosTabla.consulta_valorString("select codigoOem from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            txtNombreColor.Text = sp_datosTabla.consulta_valorString("select nombreColor from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            '-- nombre de la marca
            Dim intTmpIdMarca As Integer
            intTmpIdMarca = sp_datosTabla.consulta_valor("select idMarca from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            txtNombreMarca.Text = sp_datosTabla.consulta_valorString("select nombreMarca from  marca where idMarca=" & intTmpIdMarca)
            '-- el año
            txtAnho.Text = sp_datosTabla.consulta_valor("select anho from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            txtAnho.Text = Format(CDec(txtAnho.Text), "#,##0")
            '-- total litro
            txtTotalLitro.Text = sp_datosTabla.consulta_valorString("select totalLitro from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            txtTotalLitro.Text = Format(CDec(txtTotalLitro.Text), "#,##0.#")
            '-- cantidad de latas
            txtCantidadLata.Text = sp_datosTabla.consulta_valor("select cantidad from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            '-- region
            txtRegion.Text = sp_datosTabla.consulta_valorString("select region from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)
            '-- alternativa
            txtAlternativa.Text = sp_datosTabla.consulta_valorString("select alternativa from cabOrdenAutomotive where idOrdenAutomotive=" & v_idMov)

            If sp_datosTabla.consulta_valor("select idOrden from v_ordenPreparadoFacturado where tipoOrden=1 and idOrden=" & v_idMov) > 0 Then
                '-- si tiene facturacion
                txtIdVenta.Text = sp_datosTabla.consulta_valor("select idVenta from v_ordenPreparadoFacturado where tipoOrden=1 and idOrden=" & v_idMov)
                txtCliente.Text = sp_datosTabla.consulta_valorString("select cliente from cabVenta where idVenta=" & txtIdVenta.Text)
                txtFactura.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(factura) from cabVenta where idVenta=" & txtIdVenta.Text)
                txtFormaVenta.Text = sp_datosTabla.consulta_valorString("select _vt.nombreTipo from cabVenta cv inner join v_tipoVenta _vt on " & _
                                                                        " _vt.idTipoVenta=cv.idTipoVenta where cv.idVenta=" & txtIdVenta.Text)
                txtTotalVenta.Text = sp_datosTabla.consulta_valorDouble("select totalVenta from cabVenta where idVenta=" & txtIdVenta.Text)
                txtTotalVenta.Text = Format(CDec(txtTotalVenta.Text), "###,###,##0")
            Else
                txtIdVenta.Text = 0
                txtCliente.Text = ""
                txtFactura.Text = ""
                txtFormaVenta.Text = ""
                txtTotalVenta.Text = 0
            End If
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
        intTmpIdMov = sp_datosTabla.consulta_valor("select min(idOrdenAutomotive) from cabOrdenAutomotive")
        ultimoRegistro(intTmpIdMov)
        '-- inhabilitar el boton de anterior
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim intTmpIdMov As Integer = 0
        intTmpIdMov = sp_datosTabla.consulta_valor("select max(idOrdenAutomotive) from cabOrdenAutomotive")
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
                If (sp_datosTabla.un_dato_integer("idOrdenAutomotive", "cabOrdenAutomotive", "idOrdenAutomotive", intTmpIdMov)) > 0 Then
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
            If intTmpIdMov <= sp_datosTabla.consulta_valor("select min(idOrdenAutomotive) from cabOrdenAutomotive") Then
                'MsgBox("PAso por aca")
                btnAnterior.Enabled = False
                btnPrimero.Enabled = False
                btnSiguiente.Enabled = True
                btnUltimo.Enabled = True
                txtIdOrden.Text = sp_datosTabla.consulta_valor("select min(idOrdenAutomotive) from cabOrdenAutomotive")
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
                If (sp_datosTabla.un_dato_integer("idOrdenAutomotive", "cabOrdenAutomotive", "idOrdenAutomotive", intTmpIdMov)) > 0 Then
                    banTmpEncontro = True
                End If
                If intTmpContador > 100 Then
                    banTmpEncontro = True
                    intTmpIdMov = txtIdOrden.Text
                End If
            End While
            '-- si llega al ultimo registro inhabilitar
            If intTmpIdMov >= sp_datosTabla.consulta_valor("select max(idOrdenAutomotive) from cabOrdenAutomotive") Then
                btnSiguiente.Enabled = False
                btnUltimo.Enabled = False
                btnAnterior.Enabled = True
                btnPrimero.Enabled = True
                txtIdOrden.Text = sp_datosTabla.consulta_valor("select max(idOrdenAutomotive) from cabOrdenAutomotive")
            Else
                btnAnterior.Enabled = True
                txtIdOrden.Text = intTmpIdMov
            End If
            siguienteRegistro(intTmpIdMov)
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        '-- inicializar las variables
        banGl_consultaOrdenAutomotive = True
        frmAnular.lblProcedimiento.Text = "ANULACION ORDEN AUTOMOTIVE"
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
        banGl_buscarOrdenAutomotive = True
        Me.Enabled = False

        frmBuscarOrdenAutomotive.txtBuscar.Text = ""
        frmBuscarOrdenAutomotive.txtIdMov.Text = ""

        frmBuscarOrdenAutomotive.WindowState = FormWindowState.Normal
        frmBuscarOrdenAutomotive.Show()
        frmBuscarOrdenAutomotive.BringToFront()
        frmBuscarOrdenAutomotive.txtBuscar.Focus()

    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaPreparadoCoral_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If banGl_buscarOrdenAutomotive = False Then
            Dim intTmpIdMov As Integer = 0
            intTmpIdMov = sp_datosTabla.consulta_valor("select max(idOrdenAutomotive) from cabOrdenAutomotive")
            ultimoRegistro(intTmpIdMov)
            banGl_buscarOrdenAutomotive = False
        End If
    End Sub

    Private Sub frmConsultaPreparadoAutomotive_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteConsultaOrdenAutomotive.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------
End Class