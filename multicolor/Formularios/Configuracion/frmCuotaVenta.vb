Public Class frmCuotaVenta
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim banError As Boolean = False
    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        '-- inicializar la variable global
        intGl_nroconfiguracionCuota = 0

        '-- eliminar todos los datos de la tabla temporal
        sp_datosTabla.consulta_valor("delete from configuracionCuotaTmp where idConfig=" & intGl_idConfigPc)
        '-- limpiar la grilla
        dtgCuota.Rows.Clear()
        '-- inicializar la variable de los numeros
        intGl_nroTablaCotizacion = 0
        '-- listar el detalle de la grilla
        systemClass.SqlToDg_configuracionCuota(dtgCuota, "select idConfiguracionCuota,montoDesde,montoHasta,nroCuota from configuracionCuota")

        '-- descuento de bellini
        chkAplicarDescuentoBellini.Checked = sp_datosTabla.consulta_valorBoolean("select aplicarDescuentoBellini from configEmpresa")
        txtPorceContado.Text = sp_datosTabla.consulta_valorDouble("select porcentajeContado from configEmpresa")
        txtPorceCredito.Text = sp_datosTabla.consulta_valorDouble("select porcentajeCredito from configEmpresa")
        txtPorceTarjeta.Text = sp_datosTabla.consulta_valorDouble("select porcentajeTarjeta from configEmpresa")

    End Sub

    Private Sub guardarCuota()
        '-- variables para agregar en la tabla
        Dim intTmpIdConfiguracionCuota As Integer
        Dim douTmpMontoDesde As Double
        Dim douTmpMontoHasta As Double
        Dim intTmpNroCuota As Integer

        banError = False

        For i As Integer = 0 To dtgCuota.Rows.Count - 1
            '-- si existen item cargados
            If dtgCuota.Rows(i).Cells(3).Value > 0 Then
                '-- valor a las variables
                intTmpIdConfiguracionCuota = dtgCuota.Rows(i).Cells(0).Value
                douTmpMontoDesde = dtgCuota.Rows(i).Cells(1).Value
                douTmpMontoHasta = dtgCuota.Rows(i).Cells(2).Value
                intTmpNroCuota = dtgCuota.Rows(i).Cells(3).Value

                '-- si la compra es valida
                If (fun_guardarSp("sp_agregarConfiguracionCuotaTmp", intGl_idConfigPc & "," & intTmpIdConfiguracionCuota & "," & douTmpMontoDesde & "," & douTmpMontoHasta & "," & _
                                  intTmpNroCuota, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    banError = True
                End If



            End If
        Next

        '-- guardar si no hay error
        If banError = False Then
            If (fun_guardarSp("sp_guardarConfiguracionCuota", intGl_idConfigPc & "," & intGl_idUsuario & "," & chkAplicarDescuentoBellini.Checked & "," & txtPorceContado.Text & _
                              "," & txtPorceCredito.Text & "," & txtPorceTarjeta.Text, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardaron los registros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                inicializar()
            End If
        Else
            banError = False
        End If

    End Sub
    '--------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        '-- sumar la variable publica
        intGl_nroconfiguracionCuota = intGl_nroconfiguracionCuota + 1

        dtgCuota.AllowUserToAddRows = True
        dtgCuota.Rows.Add()
        dtgCuota.Rows(intGl_nroconfiguracionCuota - 1).Cells(0).Value = 0
        dtgCuota.Rows(intGl_nroconfiguracionCuota - 1).Cells(1).Value = 0
        dtgCuota.Rows(intGl_nroconfiguracionCuota - 1).Cells(2).Value = 0
        dtgCuota.Rows(intGl_nroconfiguracionCuota - 1).Cells(3).Value = intGl_nroconfiguracionCuota

        '-- foco en la columna de desde monto
        dtgCuota.CurrentCell = dtgCuota.Rows(intGl_nroconfiguracionCuota - 1).Cells(1)
        dtgCuota.Focus()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        'If IsNumeric(lblNro.Text) Then
        '    If dtgCuota.SelectedCells.Count > 0 Then
        '        '-- procedimiento para eliminar de la base de datos
        '        sp_datosTabla.sp_string("sp_deleteDetCotizaTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & CInt(lblNro.Text))
        '        '---------------------------------------------------------
        '        dtgCuota.Rows.Remove(dtgCuota.CurrentRow)
        '        'MsgBox("Paso por el borrado")
        '        '-- volver a renumerar
        '        intGl_nroTablaCotizacion = 0
        '        For i As Integer = 0 To dtgCuota.Rows.Count - 1
        '            If dtgCuota.Rows(i).Cells(0).Value > 0 Then
        '                intGl_nroTablaCotizacion = intGl_nroTablaCotizacion + 1
        '                dtgCuota.Rows(i).Cells(0).Value = intGl_nroTablaCotizacion
        '            End If
        '        Next
        '    End If
        'End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If banError = False Then
            If MessageBox.Show("Desea Guardar la Tabla de Cotizacion..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarCuota()
            End If
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------
    '*************'
    '-- TEXTBOX --'
    '*************'
    Private Sub txtPorceContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorceContado.KeyPress
        e.Handled = txtNumerico(txtPorceContado, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPorceCredito.Focus()
        End If
    End Sub

    Private Sub txtPorceCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorceCredito.KeyPress
        e.Handled = txtNumerico(txtPorceCredito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPorceTarjeta.Focus()
        End If
    End Sub

    Private Sub txtPorceTarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorceTarjeta.KeyPress
        e.Handled = txtNumerico(txtPorceTarjeta, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------
    '***************'
    '-- LA GRILLA --'
    '***************'
    Private Sub dtgCuota_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCuota.CellFormatting
        '-- formato de la columna desde
        If dtgCuota.Columns(e.ColumnIndex).Name.Equals("Column3") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- formato de la columna hasta
        If dtgCuota.Columns(e.ColumnIndex).Name.Equals("compra") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- formato de la columna nro de cuota
        If dtgCuota.Columns(e.ColumnIndex).Name.Equals("Column2") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If
        'Me.Refresh()
    End Sub

    Private Sub dtgCuota_GotFocus(sender As Object, e As System.EventArgs) Handles dtgCuota.GotFocus
        For i As Integer = 0 To dtgCuota.Rows.Count - 1
            If IsNumeric(dtgCuota.Rows(i).Cells(0).Value) Then
                dtgCuota.Rows(i).Cells(1).ReadOnly = False
                dtgCuota.Rows(i).Cells(2).ReadOnly = False
            Else
                dtgCuota.Rows(i).Cells(1).ReadOnly = True
                dtgCuota.Rows(i).Cells(2).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgCuota_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCuota.RowEnter
        Dim row As DataGridViewRow = dtgCuota.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(3).Value)
    End Sub

    Private Sub dtgCuota_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgCuota.SelectionChanged
        For i As Integer = 0 To dtgCuota.Rows.Count - 1
            '-- solo si es numerico el item ingresado
            If IsNumeric(dtgCuota.Rows(i).Cells(3).Value) Then
                If IsNumeric(dtgCuota.Rows(i).Cells(1).Value) Then
                    If dtgCuota.Rows(i).Cells(1).Value < 0 Then
                        '-- si el usuario coloca un monto desde
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCuota.Rows(i).Cells(1).Value = 0
                    Else
                        dtgCuota.Rows(i).Cells(1).Value = formatoNumerosDecimales(dtgCuota.Rows(i).Cells(1).Value)
                    End If
                Else
                    dtgCuota.Rows(i).Cells(1).Value = 0
                End If

                '-- si el usuario coloca un monto hasta
                If IsNumeric(dtgCuota.Rows(i).Cells(2).Value) Then
                    If dtgCuota.Rows(i).Cells(2).Value < 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCuota.Rows(i).Cells(2).Value = 0
                    Else
                        dtgCuota.Rows(i).Cells(2).Value = formatoNumerosDecimales((dtgCuota.Rows(i).Cells(2).Value))
                    End If
                Else
                    dtgCuota.Rows(i).Cells(2).Value = 0
                End If

            End If
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCuotaVenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.configuracionCuotaCredito.Enabled = True
    End Sub
    '--------------------------------------------------------------------------------------------------------
End Class