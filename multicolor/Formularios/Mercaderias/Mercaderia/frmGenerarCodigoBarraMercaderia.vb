Public Class frmGenerarCodigoBarraMercaderia
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim banError As Boolean = False
    Dim intNroCodigoBarra As Integer

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- colocar a cero el nro 
        txtNro.Text = 0
        '-- inicializar la variable global de nro
        intGl_nroGenerarCodigoBarraMercaderia = 0
    End Sub

    '*********************'
    '-- PROCEDIMIENTOS  --'
    '*********************'
    Private Sub limpiar()
        txtNro.Text = 0
        dtgCodigoBarra.Rows.Clear()
    End Sub

    '-- generar el archivo
    Private Sub generarCodigoBarra()
        '-- eliminar todos los registros generados
        sp_datosTabla.consulta_valor("delete from tmpCodigoBarra where idConfig=" & intGl_idConfigPc)

        '-- pitar todos los registros en negro
        For i As Integer = 0 To dtgCodigoBarra.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If dtgCodigoBarra.Rows(i).Cells(0).Value > 0 Then
                dtgCodigoBarra.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

        '-- recorrer la grilla
        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgCodigoBarra.Rows.Count - 1
            If dtgCodigoBarra.Rows(i).Cells(0).Value > 0 Then
                '----------------------'
                '-- sacar el idStock --'
                '----------------------'
                '-- idlote
                Dim intTmpIdLote As Integer
                intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idStock=" & dtgCodigoBarra.Rows(i).Cells(8).Value)
                '-- idproducto
                Dim intTmpIdProducto As Integer
                intTmpIdProducto = dtgCodigoBarra.Rows(i).Cells(1).Value
                '-- idDeposito
                Dim intTmpIdDeposito As Integer
                intTmpIdDeposito = sp_datosTabla.consulta_valor("select idDeposito from stock where idStock=" & dtgCodigoBarra.Rows(i).Cells(8).Value)
                '-- idStock
                Dim intTmpIdstock As Integer
                intTmpIdstock = dtgCodigoBarra.Rows(i).Cells(8).Value

                '-- la cantidad
                Dim douTmpCantidad As Double
                douTmpCantidad = dtgCodigoBarra.Rows(i).Cells(7).Value

                '-- procedimiento para agregar el codigo de barra
                If (fun_guardarSp("sp_agregarCodigoBarraTmp", intGl_idConfigPc & "," & intTmpIdstock & "," & douTmpCantidad, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Generar un registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dtgCodigoBarra.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    banError = True
                    Exit Sub
                End If

            End If

        Next
    End Sub

    '-- guardar el codigo de barra generado
    Private Sub guardar()
        If banError = False Then
            If MessageBox.Show("Desea Generar los Codigos de Barras..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If (fun_guardarSp("sp_insCodigoBarra", intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar laGeneración de Codigo de Barras...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Se ha Guardado con Éxito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    limpiar()
                End If
            End If
        End If
    End Sub

    '-------------------------------------------------------------------------------------------------------------
    '***************'
    '-- LA GRILLA --'
    '***************'
    Private Sub dtgCodigoBarra_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCodigoBarra.CellFormatting
        '-- formato de la cantidad a generar
        If dtgCodigoBarra.Columns(e.ColumnIndex).Name.Equals("cantidad") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("#,###")
        End If
    End Sub

    Private Sub dtgCodigoBarra_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCodigoBarra.RowEnter
        Dim row As DataGridViewRow = dtgCodigoBarra.Rows(e.RowIndex)
        '- buscar el id del producto
        If Len(row.Cells(0).Value) > 0 Then
            intNroCodigoBarra = Int(row.Cells(0).Value)
            txtNro.Text = intNroCodigoBarra
        End If
    End Sub

    Private Sub dtgCodigoBarra_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgCodigoBarra.SelectionChanged
        For i As Integer = 0 To dtgCodigoBarra.Rows.Count - 1
            '-- verificar si es numerico
            '-- solo si hay valores
            If dtgCodigoBarra.Rows(i).Cells(0).Value > 0 Then
                If IsNumeric(dtgCodigoBarra.Rows(i).Cells(7).Value) Then
                    '-- si es numerico
                    '-- colocar una cantidad validad si es que el operador introduce menos que 0 en la cantidad y avisar al mismo
                    If dtgCodigoBarra.Rows(i).Cells(7).Value < 0 And dtgCodigoBarra.Rows(i).Cells(0).Value > 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCodigoBarra.Rows(i).Cells(7).Value = 1
                    End If
                Else
                    '-- si no es numerico
                    MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtgCodigoBarra.Rows(i).Cells(7).Value = 1
                End If
                '-- actualizar la cantidad
                'sp_datosTabla.sp_string("sp_updCodigoBarraTmp", intGl_idConfigPc & "," & dtgCodigoBarra.Rows(i).Cells(0).Value & "," & dtgCodigoBarra.Rows(i).Cells(9).Value)

            End If
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        banGl_generarCodigoBarraMercaderia = True

        frmStock.Show()
        frmStock.BringToFront()

    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        banError = False
        generarCodigoBarra()
        guardar()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If Len(txtNro.Text) > 0 Then
            If dtgCodigoBarra.SelectedCells.Count > 0 Then
                '-- procedimiento que elimina de la base de datos el registro seleccionado
                sp_datosTabla.sp_string("sp_deleteCodigoBarraTmp", intGl_idConfigPc & "," & txtNro.Text)
                '-- eliminar de la grilla
                dtgCodigoBarra.Rows.Remove(dtgCodigoBarra.CurrentRow)
                '-- restar el nro publico
                intGl_nroGenerarCodigoBarraMercaderia = intGl_nroGenerarCodigoBarraMercaderia - 1
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        If MessageBox.Show("Desea limpiar todos los items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo) = DialogResult.Yes Then
            sp_datosTabla.sp_string("sp_limpiarCodigoBarra", intGl_idConfigPc)
            '-- limpiar la grilla
            dtgCodigoBarra.Rows.Clear()
            txtNro.Text = 0
        End If

    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmGenerarCodigoBarraMercaderia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.mercaderiaMercaderiasGenerarCodigoBarra.Enabled = True
    End Sub
    '-------------------------------------------------------------------------------------------------------------

    Private Sub btnCompra_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnCompra_Click_1(sender As System.Object, e As System.EventArgs) Handles btnCompra.Click

    End Sub
End Class