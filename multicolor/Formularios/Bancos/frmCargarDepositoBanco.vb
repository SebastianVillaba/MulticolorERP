Public Class frmCargarDepositoBanco
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    '-- variables de tipo escalar
    Dim bolError As Boolean = False

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        btnNuevo.Focus()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiarObjetos()
        '-- txt
        txtNombreCuenta.Text = ""
        txtIdCuenta.Text = 0
        txtMoneda.Text = ""
        txtCotizacion.Text = 0
        txtPersonal.Text = ""
        txtIdPersonal.Text = 0
        txtNroDoc.Text = ""
        txtNroDeposito.Text = 0
        txtMonto.Text = 0
        txtTotal.Text = 0
        '-- mask
        maskFecha.Text = ""
        '-- limpiar la grilla
        dtgDeposito.Rows.Clear()
        '-- botones
        btnAgregar.Enabled = False
        btnBuscarPersonal.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        '-- la variable publica de nro de este modulo
        intGl_nroDepositoBanco = 0
    End Sub

    Public Sub inicializarObjetos()
        txtNroDeposito.Text = 0
        txtMonto.Text = 0

        btnAgregar.Enabled = True
        btnBuscarPersonal.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    '-- sumar totales
    Private Sub sumarTotales()
        Dim douTmpTotal As Double = 0
        For i As Integer = 0 To dtgDeposito.Rows.Count - 1
            If dtgDeposito.Rows(i).Cells(0).Value > 0 Then
                douTmpTotal = douTmpTotal + dtgDeposito.Rows(i).Cells(2).Value
            End If
        Next
        txtTotal.Text = douTmpTotal
        txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,###.##")
    End Sub

    '-- controlar antes de cargar los depositos
    Private Sub controlarCargarDeposito()
        '-- controlar que exista la cuenta
        If Len(txtNombreCuenta.Text) = 0 Then
            MessageBox.Show("Debe ingresar la Cuenta Corriente..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If
        '-- controlar que existe el personal responsable
        If Len(txtPersonal.Text) = 0 Then
            MessageBox.Show("Debe ingresar el Responsable del Deposito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            btnBuscarPersonal.Focus()
            Exit Sub
        End If
        '-- controlar que el nro de cheque sea válido
        If txtNroDeposito.Text < 0 Then
            MessageBox.Show("El Nro. de Cheque Ingresado no es Válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtNroDeposito.Focus()
            Exit Sub
        End If
        '-- que se ingrese la fecha del cheque
        If Not IsNumeric(maskFecha.Text.Substring(0, 1)) Then
            MessageBox.Show("Debe ingresar la Fecha del Cheque..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            maskFecha.Focus()
            Exit Sub
        End If
        '-- el monto válido
        If txtMonto.Text <= 0 Then
            MessageBox.Show("El monto ingresado no es válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtMonto.Focus()
            Exit Sub
        End If
        '-- el nro de documento valido
        If Len(txtNroDoc.Text) = 0 Then
            MessageBox.Show("El Documento no es válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            txtNroDoc.Focus()
            Exit Sub
        End If
        '-- controlar si ya existe el nro de Documento cargado en la base de datos
        If sp_datosTabla.consulta_valor("select cd.idDepositoBanco from cabDepositoBanco cd where cd.activo=1 and cd.nroDoc=" & "'" & txtNroDoc.Text & "'" & " and idCuenta=" & txtIdCuenta.Text) > 0 Then
            MessageBox.Show("Este Deposito ya está cargado en la base de datos..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
            txtNroDoc.Focus()
            Exit Sub
        End If

    End Sub

    '-- controlar para guardar
    Private Sub controlarGuardar()
        '-- controlar que se ingrese algun item
        '-- si no existen item cargados
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgDeposito.Rows.Count - 1
            If dtgDeposito.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
            End If
        Next
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existem items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolError = True
            Exit Sub
        End If

        '-- eliminar todos los registros de la tabla temporal de eta sucursal y maquina
        sp_datosTabla.consulta_valor("delete from detDepositoBancoTmp where idConfig=" & intGl_idConfigPc)
        '-- declarar las variables para realizar la actualizacion de la tabla temporal
        Dim strTmpBanco As String
        Dim strTmpCheque As String
        Dim strTmpNroDeposito As String
        Dim douTmpMonto As Double

        '---------------------------------------
        '-- volver a pintar todos los items
        For i As Integer = 0 To dtgDeposito.Rows.Count - 1
            If dtgDeposito.Rows(i).Cells(0).Value > 0 Then
                dtgDeposito.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

        '-- cargar en el detalle de la tabla temporal
        For i As Integer = 0 To dtgDeposito.Rows.Count - 1
            If dtgDeposito.Rows(i).Cells(0).Value > 0 Then
                strTmpBanco = ""
                strTmpNroDeposito = dtgDeposito.Rows(i).Cells(1).Value
                strTmpCheque = ""
                douTmpMonto = dtgDeposito.Rows(i).Cells(2).Value
                '--- cargar los datos en la tabla temporal
                If (fun_guardarSp("sp_agregarDetDepositoBancoTmp", intGl_idConfigPc & "," & "'" & strTmpBanco & "'" & "," & "'" & strTmpCheque & "'" & "," & douTmpMonto & "," & strTmpNroDeposito, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("Problema con algún Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dtgDeposito.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    bolError = True
                    Exit Sub
                End If
            End If
        Next

    End Sub

    '-- guardar los depositos
    Private Sub guardarDeposito()
        Dim douTmpTotal As Double
        Dim douTmpCotiza As Double
        Dim strTmpTotal As String
        Dim strTmpCotiza As String
        '-- convertir el total para guardar
        strTmpTotal = CStr(txtTotal.Text)
        douTmpTotal = CDbl(strTmpTotal.Replace(",", ""))
        '-- convertir la cotizacion para guardar
        strTmpCotiza = CStr(txtCotizacion.Text)
        douTmpCotiza = CDbl(strTmpCotiza.Replace(",", ""))
        '--- cargar los datos en la base de datos
        If (fun_guardarSp("sp_guardarDepositoBanco", intGl_idPersonaJur & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & txtIdPersonal.Text & "," & txtIdCuenta.Text & "," & douTmpCotiza & "," & douTmpTotal & "," & "'" & maskFecha.Text & "'" & "," & "'" & txtNroDoc.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiarObjetos()
            btnNuevo.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    '-- el nro de doc
    Private Sub txtNroDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '-- el banco
    Private Sub txtBanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNroDeposito.Focus()
            'SendKeys.Send("{tab}")
        End If
    End Sub

    '-- el cheque
    Private Sub txtCheque_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDeposito.KeyPress
        e.Handled = txtNumerico(txtNroDeposito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '-- el monto
    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
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
            txtNroDeposito.Focus()
            'SendKeys.Send("{tab}")
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
                End If
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        banGl_depositoBanco = True

        Me.Enabled = False
        frmBuscarCuentaCorriente.txtBuscar.Text = ""
        frmBuscarCuentaCorriente.txtIdCuenta.Text = 0
        frmBuscarCuentaCorriente.txtNombreBanco.Text = ""
        frmBuscarCuentaCorriente.Visible = True
        frmBuscarCuentaCorriente.WindowState = FormWindowState.Normal
        frmBuscarCuentaCorriente.Show()

    End Sub

    Private Sub btnBuscarPersonal_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarPersonal.Click
        banGl_depositoBanco = True

        Me.Enabled = False
        frmBuscarPersonalEmpresa.txtBuscar.Text = ""
        frmBuscarPersonalEmpresa.txtIdPersonal.Text = 0
        frmBuscarPersonalEmpresa.txtNombrePersonal.Text = ""
        frmBuscarPersonalEmpresa.Visible = True
        frmBuscarPersonalEmpresa.WindowState = FormWindowState.Normal
        frmBuscarPersonalEmpresa.Show()
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        bolError = False
        controlarCargarDeposito()
        If bolError = False Then
            intGl_nroDepositoBanco = intGl_nroDepositoBanco + 1
            cargarDepositoBanco(intGl_nroDepositoBanco, txtNroDeposito.Text, txtMonto.Text)
            sumarTotales()
            inicializarObjetos()
            txtNroDeposito.Focus()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgDeposito.SelectedCells.Count > 0 Then
                '---------------------------------------------------------
                dtgDeposito.Rows.Remove(dtgDeposito.CurrentRow)
                '-- restar la variable publica de nro de item
                intGl_nroDepositoBanco = intGl_nroDepositoBanco - 1
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiarObjetos()
        btnNuevo.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarGuardar()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar los Depositos ..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarDeposito()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgDeposito_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgDeposito.CellFormatting
        '-- formato del monto
        If dtgDeposito.Columns(e.ColumnIndex).Name.Equals("Column3") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("##,###,###.##")
        End If
    End Sub

    Private Sub dtgDeposito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgDeposito.RowEnter
        Dim row As DataGridViewRow = dtgDeposito.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCargarDepositoBanco_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_depositoBanco = False
        frmMenuPrincipal.bancoCargarDeposito.Enabled = True

        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------
End Class