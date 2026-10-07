Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmImpCodigoBarraMercaderia
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim banError As Boolean = False
    Dim intNroCodigoBarra As Integer

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()

        '-- colocar a cero el nro 
        txtNro.Text = 0
    End Sub

    '*********************'
    '-- PROCEDIMIENTOS  --'
    '*********************'
    Private Sub inicializar()
        actualizarCodigoBarra()
        listarCodigoBarra("")
    End Sub

    '--listar las tablas temporales del codigo de barras
    Private Sub listarCodigoBarra(ByVal where As String)
        '-- colocar en la grilla el resultado de la tabla temporal del codigo de barra
        If Len(where) > 0 Then

        Else
            systemClass.SqlToDg_codigoBarraPendiente(dtgCodigoBarra, "select  nro,idCodigoBarra,codigo,mercaderia,nombreDeposito,idCompra,lote,vencimiento,cantidad,bonificacion,imprimir from tmpCodigoBarra")
        End If
    End Sub

    '-- actualizar la grilla de las mercaderias pendientes de impresion de codigo de barras
    Private Sub actualizarCodigoBarra()
        dtgCodigoBarra.Rows.Clear()
        '-- hacer correr el procedimiento para agregar los productos pendientes de codigo de barras a la tabla temporal
        sp_datosTabla.sp_string("sp_consultarCodigoBarraTmp", intGl_idConfigPc)
    End Sub

    '-- procedimiento que genera los registros de cada item a imprmir
    Private Sub generarImpresionCodigoBarra()
        '-- eliminar todos los registros generados
        sp_datosTabla.consulta_valor("delete from tmpImpCodigoBarra where idConfig=" & intGl_idConfigPc)

        Dim intTmpValorRegistros As Integer = 0
        For i As Integer = 0 To dtgCodigoBarra.Rows.Count - 1
            If dtgCodigoBarra.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
                '-- actualizar la tabla temporal del codigo de barra por la cantidad introducida
                sp_datosTabla.consulta_valor("update tmpCodigoBarra set imprimir=" & CInt(dtgCodigoBarra.Rows(i).Cells(10).Value) & " where idCodigoBarra=" & dtgCodigoBarra.Rows(i).Cells(1).Value)
                '-- proceso para insertar los registro en el procedimiento
                sp_datosTabla.sp_string("sp_insTmpImpCodigoBarra", dtgCodigoBarra.Rows(i).Cells(1).Value & "," & intGl_idConfigPc)
            End If
        Next
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existem items cargados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            banError = True
            Exit Sub
        End If
    End Sub

    Private Sub imprimirCodigoBarra()
        Dim pvParametros As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_codigoBarraMercaderia
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvParametros)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Show()
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '***************'
    '-- LA GRILLA --'
    '***************'
    Private Sub dtgCodigoBarra_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCodigoBarra.CellFormatting
        '-- formato de la cantidad a imprimir
        If dtgCodigoBarra.Columns(e.ColumnIndex).Name.Equals("imprimir") Then
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
                If IsNumeric(dtgCodigoBarra.Rows(i).Cells(9).Value) Then
                    '-- si es numerico
                    '-- colocar una cantidad validad si es que el operador introduce menos que 0 en la cantidad y avisar al mismo
                    If dtgCodigoBarra.Rows(i).Cells(9).Value < 0 And dtgCodigoBarra.Rows(i).Cells(0).Value > 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCodigoBarra.Rows(i).Cells(9).Value = 0
                    End If
                Else
                    '-- si no es numerico
                    MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtgCodigoBarra.Rows(i).Cells(9).Value = 0
                End If
                '-- actualizar la cantidad
                sp_datosTabla.sp_string("sp_updCodigoBarraTmp", intGl_idConfigPc & "," & dtgCodigoBarra.Rows(i).Cells(0).Value & "," & dtgCodigoBarra.Rows(i).Cells(9).Value)

            End If
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        actualizarCodigoBarra()
        listarCodigoBarra("")
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If Len(txtNro.Text) > 0 Then
            If dtgCodigoBarra.SelectedCells.Count > 0 Then
                '-- procedimiento que elimina de la base de datos el registro seleccionado
                sp_datosTabla.sp_string("sp_deleteCodigoBarraTmp", intGl_idConfigPc & "," & txtNro.Text)
                '-- eliminar de la grilla
                dtgCodigoBarra.Rows.Remove(dtgCodigoBarra.CurrentRow)
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        If MessageBox.Show("Desea limpiar todos los items cargados..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            sp_datosTabla.sp_string("sp_limpiarCodigoBarra", intGl_idConfigPc)
            '-- limpiar la grilla
            dtgCodigoBarra.Rows.Clear()
            txtNro.Text = 0

            actualizarCodigoBarra()
            listarCodigoBarra("")
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        banError = False
        generarImpresionCodigoBarra()
        If banError = False Then
            '-- solo si no hay errores se imprime los codigos de barras
            imprimirCodigoBarra()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmImpCodigoBarraMercaderia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.mercaderiaMercaderiasImprimirCodigoBarra.Enabled = True
    End Sub
    '-------------------------------------------------------------------------------------------------------------
End Class