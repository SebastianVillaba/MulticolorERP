Public Class frmCargarCheques
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim cuentaCorriente As New cuentaCorriente

    '-- variables de tipo escalar
    Dim bolError As Boolean = False
    Dim strBanco As String
    Dim douTotal As Double
    Dim intIdChequera As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo de la cuenta corriente
        cuentaCorriente.cuentaCorrienteCombo(cboCuenta)
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiarObjetos()
        '-- txt
        txtCheque.Text = 0
        txtCotizacion.Text = 0
        txtIdProveedor.Text = 0
        txtMoneda.Text = ""
        txtMonto.Text = 0
        txtProveedor.Text = ""
        '-- mask
        maskFecha.Text = ""

    End Sub

    Private Sub controlarCargaCheque()
        '-- controlar que exista el proveedor
        If Len(txtProveedor.Text) = 0 Then
            MessageBox.Show("Debe ingresar el Proveedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
            Exit Sub
        End If
        '-- controlar que el nro de cheque sea válido
        If txtCheque.Text <= 0 Then
            MessageBox.Show("El Nro. de Cheque Ingresado no es Válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
            Exit Sub
        End If
        '-- que se ingrese una moneda
        If Len(txtMoneda.Text) = 0 Then
            MessageBox.Show("La moneda no es válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
            Exit Sub
        End If
        '-- que se ingrese la fecha del cheque
        If Not IsNumeric(maskFecha.Text.Substring(0, 1)) Then
            MessageBox.Show("Debe ingresar la Fecha del Cheque..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
            Exit Sub
        End If
        '-- el monto válido
        If txtMonto.Text <= 0 Then
            MessageBox.Show("El monto ingresado no es válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
            Exit Sub
        End If
        '-- dar valor a las variables
        strBanco = sp_datosTabla.consulta_valorString("select rtrim(nombreBanco)+'/'+ltrim(nroCuenta) from cuentaCorriente where idCuenta=" & cboCuenta.SelectedValue)
        douTotal = txtCotizacion.Text * txtMonto.Text

        '-- controlar si ya existe el cheque cargado en la base de datos
        Dim intTmpIdCuenta As Integer
        intTmpIdCuenta = cboCuenta.SelectedValue
        If sp_datosTabla.consulta_valor("select dc.idCheque from detCheque dc inner join chequera ch on dc.idChequera=ch.idChequera where dc.habilitado=1 and ch.idCuenta=" & intTmpIdCuenta & " and dc.cheque=" & txtCheque.Text) > 0 Then
            MessageBox.Show("Este cheque ya está cargado en la base de datos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            bolError = True
            Exit Sub
        End If
        '-- controlar que ya no esté cargado en la grilla
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            If dtgCheque.Rows(i).Cells(0).Value > 0 Then
                If dtgCheque.Rows(i).Cells(6).Value = txtCheque.Text And strBanco = dtgCheque.Rows(i).Cells(3).Value Then
                    MessageBox.Show("Este cheque ya está cargado en la Grilla..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bolError = True
                    Exit Sub
                End If
            End If
        Next
        '-- controlar que es un cheque de alguna chequera
        'txtSql.Text = "select idChequera from chequera where activo=1 and (" & txtCheque.Text & ">= chequeInicial and " & txtCheque.Text & " <= chequeFinal) and idCuenta=" & intTmpIdCuenta
        If (sp_datosTabla.consulta_valor("select idChequera from chequera where activo=1 and (" & txtCheque.Text & ">= chequeInicial and " & txtCheque.Text & " <= chequeFinal) and idCuenta=" & intTmpIdCuenta)) = 0 Then
            MessageBox.Show("Este cheque no cuenta con ninguna chequera cargada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            bolError = True
            Exit Sub
        Else
            intIdChequera = (sp_datosTabla.consulta_valor("select idChequera from chequera where activo=1 and (" & txtCheque.Text & ">= chequeInicial and " & txtCheque.Text & " <= chequeFinal) and idCuenta=" & intTmpIdCuenta))
        End If

    End Sub

    Private Sub cotizacion()
        Dim intTmpIdMoneda As Integer
        '-- ver el idMoneda de la cuenta corriente
        intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cuentacorriente where idCuenta=" & cboCuenta.SelectedValue)
        'MsgBox("Valor de idMoneda " & intTmpIdMoneda)
        txtMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIdMoneda)
        '-- si la moneda es la configurada y utilizada en el sistema
        If (sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad)) = intTmpIdMoneda Then
            '-- moneda configurada y utilizada en el sistema
            txtCotizacion.Text = 1
        Else
            '-- otra moneda
            txtCotizacion.Text = sp_datosTabla.un_dato_double("venta", "detCotiza", "idMoneda", intTmpIdMoneda)
        End If
        txtCotizacion.Text = Format(CDec(txtCotizacion.Text), "###,###,###.00")
    End Sub

    '-- controlar para guardar
    Private Sub controlarGuardar()
        '-- controlar que se ingrese algun item
        '-- si no existen item cargados
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            If dtgCheque.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
            End If
        Next

        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existem items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
            Exit Sub
        End If

        '-- eliminar todos los registros de la tabla temporal de eta sucursal y maquina
        sp_datosTabla.consulta_valor("delete from detChequeTmp where idConfig=" & intGl_idConfigPc)
        '-- declarar las variables para realizar la actualizacion de la tabla temporal
        Dim intTmpIdChequera As Integer
        Dim intTmpIdProveedor As Integer
        Dim intTmpCheque As Integer
        Dim strTmpFecha As String
        Dim douTmpMonto As Double
        Dim douTmpCotiza As Double

        '---------------------------------------
        '-- volver a pintar todos los items
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            If dtgCheque.Rows(i).Cells(0).Value > 0 Then
                dtgCheque.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

        '-- cargar en el detalle de la tabla temporal
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            If dtgCheque.Rows(i).Cells(0).Value > 0 Then
                intTmpIdChequera = dtgCheque.Rows(i).Cells(10).Value
                intTmpCheque = dtgCheque.Rows(i).Cells(6).Value
                strTmpFecha = dtgCheque.Rows(i).Cells(7).Value
                douTmpMonto = dtgCheque.Rows(i).Cells(8).Value
                douTmpCotiza = dtgCheque.Rows(i).Cells(4).Value
                intTmpIdProveedor = dtgCheque.Rows(i).Cells(1).Value

                '--- cargar los datos en la tabla temporal
                If (fun_guardarSp("sp_agregarDetChequeTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdChequera & "," & intTmpIdProveedor & "," & intTmpCheque & "," & douTmpCotiza & "," & "'" & strTmpFecha & "'" & "," & douTmpMonto, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("Problema con algún Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtgCheque.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    bolError = True
                    Exit Sub
                End If
            End If
        Next

    End Sub

    '-- guardar los cheques
    Private Sub guardarCheques()
        '--- cargar los datos en la tabla temporal
        If (fun_guardarSp("sp_guardarChequeProveedor", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            intGl_nroCargarCheque = 0
            limpiarObjetos()
            '-- la grilla
            dtgCheque.Rows.Clear()
            btnBuscarProveedor.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    '-- el cheque
    Private Sub txtCheque_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCheque.KeyPress
        e.Handled = txtNumerico(txtCheque, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '************'
    '-- COMBOS --'
    '************'
    Private Sub cboCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cotizacion()
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cboCuenta_Validated(sender As Object, e As System.EventArgs) Handles cboCuenta.Validated
        cotizacion()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
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
            SendKeys.Send("{tab}")
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
                    Dim datFechaServidor As Date
                    datFechaServidor = sp_datosTabla.sp_string("sp_fechaServer", "")
                    'MsgBox("Fecha del servidor  " & datFechaServidor.ToString)
                    If (userdate < datFechaServidor) Then
                        ToolTip1.ToolTipTitle = "Fecha no es Válida"
                        ToolTip1.Show("La fecha debe ser mayor o igual a la fecha actual del sistema.", maskFecha, 0, -20, 5000)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscarProveedor_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarProveedor.Click
        banGl_cargarCheque = True
        Me.Enabled = False

        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.Visible = True
        frmBuscarProveedor.WindowState = FormWindowState.Normal
        frmBuscarProveedor.Show()
        frmBuscarProveedor.txtBuscar.Focus()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgCheque.SelectedCells.Count > 0 Then
                '---------------------------------------------------------
                dtgCheque.Rows.Remove(dtgCheque.CurrentRow)
                '-- restar la variable publica de nro de item
                intGl_nroCargarCheque = intGl_nroCargarCheque - 1
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarGuardar()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar los Cheques..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarCheques()
            End If
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        bolError = False
        controlarCargaCheque()
        If bolError = False Then
            intGl_nroCargarCheque = intGl_nroCargarCheque + 1
            cargarChequeProveedor(intGl_nroCargarCheque, txtIdProveedor.Text, txtProveedor.Text, strBanco, txtCotizacion.Text, txtMoneda.Text, txtCheque.Text, maskFecha.Text, txtMonto.Text, douTotal, intIdChequera)
            limpiarObjetos()
            btnBuscarProveedor.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    Private Sub dtgCheque_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCheque.RowEnter
        Dim row As DataGridViewRow = dtgCheque.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
    End Sub

    '-- el formato de las celdas
    Private Sub dtgCheque_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCheque.CellFormatting
        '-- formato de la cotizacion
        If dtgCheque.Columns(e.ColumnIndex).Name.Equals("cotiza") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("#,###.##")
        End If
        '-- formato para la columna de monto
        If dtgCheque.Columns(e.ColumnIndex).Name.Equals("Column11") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("###,###,###.##")
        End If
        '-- formato para la columna del total
        If dtgCheque.Columns(e.ColumnIndex).Name.Equals("Column5") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.LightYellow
            e.CellStyle.Format = ("###,###,###.##")
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCargarCheques_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_cargarCheque = False

        frmMenuPrincipal.bancoCargarCheque.Enabled = True
        e.Cancel = False
    End Sub

    '----------------------------------------------------------------------------------------------------
End Class