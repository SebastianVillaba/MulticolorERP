Public Class frmCargarOrdenPagoCheque
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inhabilitarObjetos()
        listarCheque()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- inicializar objetos
    Private Sub inhabilitarObjetos()
        '-- txt
        txtMonto.Text = 0
        txtMonto.Enabled = False
        txtMonto.BackColor = Color.LightBlue
        '-- mask
        maskFecha.Text = ""
        maskFecha.Enabled = False
        maskFecha.BackColor = Color.LightBlue
        '-- lbl
        lblBanco.Text = ""
        lblCotiza.Text = 0
        lblCuenta.Text = ""
        lblIdCuenta.Text = 0
        lblIdProveedor.Text = 0
        lblMoneda.Text = ""
        lblProveedor.Text = 0
        lblIdProveedor1.Text = 0
        lblMonto.Text = 0
        '-- botones
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        btnProveedor.Enabled = False
        '-- limpiar la tabla temporal
        'sp_datosTabla.consulta_valor("delete from detOrdenChequeTmp where idConfig=" & intGl_idConfigPc)
    End Sub

    Public Sub habilitarObjetos()
        '-- txt
        txtMonto.Text = 0
        txtMonto.Enabled = True
        txtMonto.BackColor = Color.White
        '-- mask
        maskFecha.Text = ""
        maskFecha.Enabled = True
        maskFecha.BackColor = Color.White
        '-- lbl
        lblBanco.Text = ""
        lblCotiza.Text = 0
        lblCuenta.Text = ""
        lblIdCuenta.Text = 0
        lblIdProveedor.Text = 0
        lblMoneda.Text = ""
        lblProveedor.Text = 0
        '-- botones
        btnAgregar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        btnProveedor.Enabled = True
    End Sub

    Private Sub limpiar()
        '--- txt
        txtMonto.Text = 0
        maskFecha.Text = ""
        '-- lbl
        lblIdProveedor.Text = 0
        lblProveedor.Text = ""
    End Sub

    '-- listar los cheques cargados
    Private Sub listarCheque()
        systemClass.SqlToLv_detalleOrdenCheque(lvCheque, "sp_consultaDetalleOrdenChequeTmp", intGl_idConfigPc)
    End Sub

    Private Sub cargarCheque()
        Try
            '-- declarar las variables para realizar la actualizacion de la tabla temporal
            Dim intTmpIdProveedor As Integer
            Dim strTmpFecha As String
            Dim douTmpMonto As Double
            '-- dar valor a las variables
            intTmpIdProveedor = CInt(lblIdProveedor.Text)
            strTmpFecha = maskFecha.Text
            douTmpMonto = CDbl(sacarComa(txtMonto.Text))
            '---------------------------------
            '-- agregar a la tabla temporal --
            '---------------------------------
            If (fun_guardarSp("sp_agregarDetOrdenChequeTmp", intGl_idConfigPc & "," & intTmpIdProveedor & "," & "'" & strTmpFecha & "'" & "," & douTmpMonto, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Agregar los Registros al detalle de la Orden de Cheques...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            '-- listar la orden del cheque
            listarCheque()
            limpiar()
            btnProveedor.Focus()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub guardarOrdenCheque()
        '-- inicializar las variables
        If MessageBox.Show("Desea Guardar la Orden de Cheque..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If (fun_guardarSp("sp_guardarOrdenCheque", intGl_idConfigPc & "," & intGl_idSucursal & "," & CInt(lblIdCuenta.Text) & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar la Orden del Cheque...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- eliminar todos los registros de la tabla temporal
                sp_datosTabla.consulta_valor("delete from detOrdenChequeTmp where idConfig=" & intGl_idConfigPc)
                listarCheque()
                limpiar()
                inhabilitarObjetos()
                MessageBox.Show("Se guardaron con éxito todos los registros cargados en la Orden de los cheques..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        banGl_OrdenPagoCheque = True

        Me.Enabled = False
        frmBuscarCuentaCorriente.txtIdCuenta.Text = 0
        frmBuscarCuentaCorriente.txtNombreBanco.Text = ""
        frmBuscarCuentaCorriente.txtBuscar.Text = ""
        frmBuscarCuentaCorriente.Show()
        frmBuscarCuentaCorriente.BringToFront()
        frmBuscarCuentaCorriente.txtBuscar.Focus()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If IsNumeric(lblIdProveedor1.Text) Then
            '-- eliminar de la tabla temporal
            sp_datosTabla.consulta_valor("delete from detOrdenChequeTmp where idConfig=" & intGl_idConfigPc & " and idProveedor=" & lblIdProveedor1.Text & " and monto=" & sacarComa(lblMonto.Text))
            lblIdProveedor1.Text = 0
            lblMonto.Text = 0
            listarCheque()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        cargarCheque()
    End Sub

    Private Sub btnProveedor_Click(sender As System.Object, e As System.EventArgs) Handles btnProveedor.Click
        banGl_OrdenPagoCheque = True

        Me.Enabled = False
        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.Show()
        frmBuscarProveedor.BringToFront()
        frmBuscarProveedor.txtBuscar.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarOrdenCheque()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
        inhabilitarObjetos()
        sp_datosTabla.consulta_valor("delete from detOrdenChequeTmp where idConfig=" & intGl_idConfigPc)
        listarCheque()
    End Sub
    '-------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.##")
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '******************'
    '-- LAS MASKARAS --'
    '******************'
    '-- validar la mascara de vencimiento
    Private Sub maskFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ToolTip1.Hide(maskFecha)
    End Sub

    Private Sub maskFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles maskFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtMonto.Focus()
        End If
    End Sub

    Private Sub maskFecha_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskFecha.TypeValidationCompleted
        Dim strPrueba As String = maskFecha.Text
        '-- solo hacer el procedimiento si la primera expresion es numerica
        If IsNumeric(strPrueba.Substring(0, 1)) Then
            If Len(maskFecha.Text) > 0 Then

                'strPrueba.su()
                'MsgBox("Valor de la mascara  " & strPrueba, MsgBoxStyle.Information)
                If (Not e.IsValidInput) Then
                    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    ToolTip1.Show("Debe introducir una fecha con formato .", maskFecha, 70, -70, 700)
                    e.Cancel = True
                Else
                    Dim userdate As DateTime = CDate(e.ReturnValue)
                    ' controlar que la fecha no sea superior a la fecha del servidor
                    '-- colocar en una variable la fecha devuelta por el servidor
                    'Dim datFechaServidor As Date
                    'datFechaServidor = sp_datosTabla.sp_string("sp_fechaServer", "")
                    'MsgBox("Fecha del servidor  " & datFechaServidor.ToString)
                    'If (userdate < datFechaServidor) Then
                    '    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    '    ToolTip1.Show("La fecha debe ser mayor o igual a la fecha actual del sistema.", maskFecha, 0, -20, 5000)
                    '    e.Cancel = True
                    'End If
                End If
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCheque_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCheque.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvCheque.SelectedItems
            lblIdProveedor1.Text = item.SubItems(1).Text
            lblMonto.Text = item.SubItems(4).Text
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCargarOrdenPagoCheque_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- ver si hay item cargados
        If sp_datosTabla.consulta_valor("select idConfig from detOrdenChequeTmp where idConfig=" & intGl_idConfigPc) > 0 Then

            If MessageBox.Show("Desea Salir del Módulo? Hay items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- eliminar todos los registros de la tabla temporal
                sp_datosTabla.consulta_valor("delete from detOrdenChequeTmp where idConfig=" & intGl_idConfigPc)
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                frmMenuPrincipal.bancoOrdenCheque.Enabled = True
                e.Cancel = False
            Else
                e.Cancel = True
            End If ' Call me
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.bancoOrdenCheque.Enabled = True
            e.Cancel = False
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------

End Class