Public Class frmControlarCheques
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        actualizarcheque()
        listarCheque(" where idConfig=" & intGl_idConfigPc)
        listarDetalle(0, 0)
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarcheque()
        '-- cargar la tabla temporal
        If (fun_guardarSp("sp_cargarTmpControlCheque", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se existen cheques sin controlar u ocurrió algún error...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub listarCheque(ByVal v_where As String)
        '-- limpiar la grilla
        dtgCheque.Rows.Clear()

        systemClass.SqlToDg_controlCheque(dtgCheque, "select nro,idProveedor,nombreProveedor,cheque," & _
        "totalCheque,moneda,fechaCheque,idCheque,controlado from tmpControlCheque " & v_where)
    End Sub

    Private Sub listarDetalle(ByVal v_idCheque As Integer, ByVal v_cheque As Integer)
        'MsgBox("Valor de idCheque  " & v_idCheque)
        'MsgBox("Valor de cheque  " & v_cheque)
        systemClass.SqlToLv_detalleCompraGastoCheque(lvFacrura, "sp_consultaChequePagoProveedor", v_idCheque & "," & v_cheque)
    End Sub

    Private Sub guardarControlCheque()
        Try
            '-- recorrer la forma de venta
            For i As Integer = 0 To dtgCheque.Rows.Count - 1
                If CBool(dtgCheque.Rows(i).Cells(8).Value()) = True Then
                    '-- actualizar el porcentaje adicional
                    sp_datosTabla.consulta_valor("update tmpControlCheque set controlado=1 where cheque=" & CInt(dtgCheque.Rows(i).Cells(3).Value()) & " and idConfig=" & intGl_idConfigPc)
                End If
            Next
            'banGl_abmPersona = True

            'MsgBox("Antes de entrar al procedimiento de guardar")

            '-- procedimiento para guardar los controles
            If (fun_guardarSp("sp_guardarControlCheque", intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Control de Cheques...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                actualizarcheque()
                listarCheque(" where idConfig=" & intGl_idConfigPc)
                listarDetalle(0, 0)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub
    '--------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        '-- listar todo
        actualizarcheque()
        listarCheque(" where idConfig=" & intGl_idConfigPc)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar los Cheques Controlados..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarControlCheque()
        End If
    End Sub
    '--------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgCheque_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCheque.CellFormatting
        '-- formato total cheque
        If dtgCheque.Columns(e.ColumnIndex).Name.Equals("column9") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If

    End Sub

    Private Sub dtgCheque_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCheque.CellContentClick
        If e.ColumnIndex = 12 Then
            If dtgCheque.Rows(e.RowIndex).Cells(0).Value > 0 Then
                If (Convert.ToBoolean(dtgCheque.Rows(e.RowIndex).Cells(8).Value)) Then

                    dtgCheque.Rows(e.RowIndex).Cells(8).Value = False
                    'dtgCheque.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    'dtgPago.Rows(e.RowIndex).Cells(8).Value = 0
                Else
                    dtgCheque.Rows(e.RowIndex).Cells(8).Value = True
                    'dtgCheque.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
                End If
            End If
        End If
    End Sub

    Private Sub dtgCheque_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgCheque.GotFocus
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            If dtgCheque.Rows(i).Cells(0).Value > 0 Then
                dtgCheque.Rows(i).Cells(8).ReadOnly = False
            Else
                dtgCheque.Rows(i).Cells(8).ReadOnly = True
            End If
        Next
    End Sub

    '-- colocar los puntos separadores
    Private Sub dtgCheque_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgCheque.SelectionChanged
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            '-- el total del cheque
            dtgCheque.Rows(i).Cells(4).Value = formatoNumerosDecimales(dtgCheque.Rows(i).Cells(4).Value)
            If dtgCheque.Rows(i).Cells(8).Value = True Then
                dtgCheque.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow
            Else
                dtgCheque.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub dtgCheque_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCheque.RowEnter
        Dim row As DataGridViewRow = dtgCheque.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        '---- mostrar las compras y gastos
        listarDetalle(CInt(row.Cells(7).Value), CInt(row.Cells(3).Value))
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmControlarCheques_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoControlarCheque.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------

End Class