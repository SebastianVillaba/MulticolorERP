Public Class frmTablaCotizacion
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
        '-- eliminar todos los datos de la tabla temporal
        sp_datosTabla.consulta_valor("delete from detCotizaTmp where idConfig=" & intGl_idConfigPc)
        Dim intTmpIdMoneda As Integer
        '-- limpiar la grilla
        dtgCotiza.Rows.Clear()
        '-- colocar el idMoneda que está configurado
        intTmpIdMoneda = sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad)
        txtIdMoneda.Text = intTmpIdMoneda
        txtMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", intTmpIdMoneda)
        txtAbrevia.Text = sp_datosTabla.un_datoString("abreviatura", "moneda", "idMoneda", intTmpIdMoneda)
        '-- datos del usuario que creo y modifico
        txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "cabCotiza", "idMoneda", txtIdMoneda.Text)
        txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "cabCotiza", "idMoneda", txtIdMoneda.Text)
        txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", sp_datosTabla.un_dato("idUsuarioAlta", "cabCotiza", "idMoneda", txtIdMoneda.Text))
        txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", sp_datosTabla.un_dato("idUsuarioMod", "cabCotiza", "idMoneda", txtIdMoneda.Text))
        '-- inicializar la variable de los numeros
        intGl_nroTablaCotizacion = 0
        '-- listar el detalle de la grilla
        systemClass.SqlToDg_tablaCotiza(dtgCotiza, "select row_number() over(order by dc.idmoneda) as nro,dc.idMoneda,(m.nombreMoneda) as Moneda,dc.compra,dc.venta from detCotiza dc inner join moneda m on dc.idMoneda=m.idMoneda")
        '-- agregar a la tabla temporal los que existe
        For i As Integer = 0 To dtgCotiza.Rows.Count - 1
            'MsgBox("Valor  " & i)
            '-- si existen item cargados
            If dtgCotiza.Rows(i).Cells(0).Value > 0 Then
                '-- procedimiento para cargar la tabla temporal
                sp_datosTabla.sp_string("sp_agregarDetCotizaTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & 0 & "," & dtgCotiza.Rows(i).Cells(1).Value)
            End If
        Next
    End Sub

    Private Sub controlarTablaCotizacion()
        '-- ver que se ingresó un producto como cabecera
        '-- ver si hay error dentro de la grilla
        Dim intTmpValorRegistros As Integer = 0
        Dim intTmpIdMoneda As Integer = 0
        Dim strTmpCompra As Double = 0
        Dim strTmpVenta As String = ""

        For i As Integer = 0 To dtgCotiza.Rows.Count - 1
            '-- si existen item cargados
            If dtgCotiza.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
                '-- si la compra es valida
                If dtgCotiza.Rows(i).Cells(3).Value < 0 Then
                    MessageBox.Show("Existen Compras no Válidas..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    banError = True
                    Exit Sub
                End If
                '-- si la venta es válida
                If dtgCotiza.Rows(i).Cells(4).Value < 0 Then
                    MessageBox.Show("Existen Ventas no Válidas..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    banError = True
                    Exit Sub
                End If
                '-- actualizar el detalle temporal
                intTmpIdMoneda = dtgCotiza.Rows(i).Cells(1).Value
                strTmpCompra = CStr(convertirNumeroDecimal(dtgCotiza.Rows(i).Cells(3).Value.ToString))
                strTmpVenta = CStr(convertirNumeroDecimal(dtgCotiza.Rows(i).Cells(4).Value.ToString))
                'MsgBox("Valor de strTmpVenta  " & strTmpVenta)
                'strTmpVenta = strTmpVenta.Replace(".", ",")

                'MsgBox("Valor de douventa  " & strTmpVenta)
                sp_datosTabla.sp_string("sp_updDetCotizaTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdMoneda & "," & strTmpCompra & "," & strTmpVenta)

            End If
        Next
        '-- si no existe nungun item cargado
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existe item cargados..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            banError = True
            Exit Sub
        End If
    End Sub

    Private Sub guardarCotizacion()
        If (fun_guardarSp("sp_guardarTablaCotizacion", intGl_idConfigPc & "," & intGl_idSucursal & "," & txtIdMoneda.Text & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardaron los registros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            inicializar()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        banGl_tablaCotizacion = True
        Me.Enabled = False
        frmBuscarMoneda.Visible = True
        frmBuscarMoneda.Show()
        frmBuscarMoneda.BringToFront()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If IsNumeric(lblNro.Text) Then
            If dtgCotiza.SelectedCells.Count > 0 Then
                '-- procedimiento para eliminar de la base de datos
                sp_datosTabla.sp_string("sp_deleteDetCotizaTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & CInt(lblIdMoneda.Text))
                '---------------------------------------------------------
                dtgCotiza.Rows.Remove(dtgCotiza.CurrentRow)
                'MsgBox("Paso por el borrado")
                '-- volver a renumerar
                intGl_nroTablaCotizacion = 0
                For i As Integer = 0 To dtgCotiza.Rows.Count - 1
                    If dtgCotiza.Rows(i).Cells(0).Value > 0 Then
                        intGl_nroTablaCotizacion = intGl_nroTablaCotizacion + 1
                        dtgCotiza.Rows(i).Cells(0).Value = intGl_nroTablaCotizacion
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        controlarTablaCotizacion()
        If banError = False Then
            If MessageBox.Show("Desea Guardar la Tabla de Cotizacion..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarCotizacion()
            End If
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------
    '***************'
    '-- LA GRILLA --'
    '***************'
    Private Sub dtgCotiza_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCotiza.CellFormatting
        '-- formato de la compra
        If dtgCotiza.Columns(e.ColumnIndex).Name.Equals("compra") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- formato de la venta
        If dtgCotiza.Columns(e.ColumnIndex).Name.Equals("venta") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            ' MsgBox("El formato")
        End If
        'Me.Refresh()
    End Sub

    Private Sub dtgCotiza_GotFocus(sender As Object, e As System.EventArgs) Handles dtgCotiza.GotFocus
        For i As Integer = 0 To dtgCotiza.Rows.Count - 1
            If dtgCotiza.Rows(i).Cells(0).Value > 0 Then
                dtgCotiza.Rows(i).Cells(3).ReadOnly = False
                dtgCotiza.Rows(i).Cells(4).ReadOnly = False
            Else
                dtgCotiza.Rows(i).Cells(3).ReadOnly = True
                dtgCotiza.Rows(i).Cells(4).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgCotiza_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCotiza.RowEnter
        Dim row As DataGridViewRow = dtgCotiza.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
        '- asignar el idMoneda al objeto
        lblIdMoneda.Text = CStr(row.Cells(1).Value)
    End Sub

    Private Sub dtgCotiza_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgCotiza.SelectionChanged
        For i As Integer = 0 To dtgCotiza.Rows.Count - 1
            '-- solo si es numerico el item ingresado
            If IsNumeric(dtgCotiza.Rows(i).Cells(0).Value) Then
                If IsNumeric(dtgCotiza.Rows(i).Cells(3).Value) Then
                    If dtgCotiza.Rows(i).Cells(3).Value < 0 Then
                        '-- si el usuario coloca una compra no valida
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCotiza.Rows(i).Cells(3).Value = 0
                    Else
                        dtgCotiza.Rows(i).Cells(3).Value = formatoNumerosDecimales(dtgCotiza.Rows(i).Cells(3).Value)
                    End If
                Else
                    dtgCotiza.Rows(i).Cells(3).Value = 0
                End If

                '-- si el usuario coloca una venta no valida
                If IsNumeric(dtgCotiza.Rows(i).Cells(4).Value) Then
                    If dtgCotiza.Rows(i).Cells(4).Value < 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCotiza.Rows(i).Cells(4).Value = 0
                    Else
                        dtgCotiza.Rows(i).Cells(4).Value = formatoNumerosDecimales((dtgCotiza.Rows(i).Cells(4).Value))
                    End If
                Else
                    dtgCotiza.Rows(i).Cells(4).Value = 0
                End If

            End If
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmTablaCotizacion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.finanzaTablaCotizacion.Enabled = True
    End Sub
    '--------------------------------------------------------------------------------------------------------
End Class