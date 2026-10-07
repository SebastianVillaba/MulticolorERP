Public Class frmModificarCosto
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim bolError As Boolean = False

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        lblNro.Text = 0
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- renumerar de vuelta la grilla de costos
    Private Sub renumerarPedido()
        intGl_nroModificaCosto = 0
        '-- volver a renumerar
        For i As Integer = 0 To dtgCosto.Rows.Count - 1
            If dtgCosto.Rows(i).Cells(1).Value > 0 Then
                intGl_nroModificaCosto = intGl_nroModificaCosto + 1
                dtgCosto.Rows(i).Cells(0).Value = intGl_nroModificaCosto
            End If
        Next
    End Sub

    '-- controlar para guardar las modificaciones de costo
    Private Sub controlarGuardar()
        '-- inicializar las variables
        Dim intTmpIdStock As Integer
        Dim douTmpPrecio As Double
        Dim douTmpCostoAnterior As Double
        Dim douTmpCostoActual As Double

        '-- pitar todos los registros en negro
        For i As Integer = 0 To dtgCosto.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If dtgCosto.Rows(i).Cells(0).Value > 0 Then
                dtgCosto.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Next

        '-- eliminar todos los datos anteriores en la table anterior
        sp_datosTabla.consulta_valor("delete from detModiCostoTmp where idConfig=" & intGl_idConfigPc)

        '-- colocar en la tabla temporal todos los datos
        For i As Integer = 0 To dtgCosto.Rows.Count - 1
            If dtgCosto.Rows(i).Cells(0).Value > 0 Then
                intTmpIdStock = CInt(dtgCosto.Rows(i).Cells(1).Value)
                douTmpPrecio = CDbl(dtgCosto.Rows(i).Cells(6).Value)
                douTmpCostoAnterior = CDbl(dtgCosto.Rows(i).Cells(7).Value)
                douTmpCostoActual = CDbl(dtgCosto.Rows(i).Cells(8).Value)

                '-- procedimiento para agregar a la tabla temporal los datos cargados
                If (fun_guardarSp("sp_agregarDetModiCostoTmp", intGl_idConfigPc & "," & intTmpIdStock & "," & douTmpPrecio & "," & douTmpCostoAnterior & "," & douTmpCostoActual, Me.Name)) = 0 Then
                    dtgCosto.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    bolError = True
                End If
            End If
        Next

    End Sub

    Private Sub guardarModificacionCosto()

        If (fun_guardarSp("sp_guardarModificacionCosto", intGl_idConfigPc & "," & intGl_idSucursal & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se guardó con Exito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            dtgCosto.Rows.Clear()
            '-- colocar en 0 la variable publica
            intGl_nroModificaCosto = 0

            lblNro.Text = 0
        End If
    End Sub
    '--------------------------------------------------------------------------------------------'
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    '-- eliminar de la grilla de pedido
    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text.Length > 0 Then
            If CInt(lblNro.Text) > 0 Then
                If dtgCosto.SelectedCells.Count > 0 Then
                    dtgCosto.Rows.Remove(dtgCosto.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroModificaCosto = intGl_nroModificaCosto - 1
                End If
            End If
            '-- procedimiento para renumerar la grilla
            renumerarPedido()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("Desea Eliminar todos los Costos de La Mercaderias..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'sp_datosTabla.consulta_valor("delete from detPedidoTmp where idSucursal=" & intGl_idSucursal & " and idConfig=" & intGl_idConfigPc)
            'listarMercaderiaPedida()
            dtgCosto.Rows.Clear()
            '-- colocar en 0 la variable publica
            intGl_nroModificaCosto = 0

            lblNro.Text = 0
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolError = False
        controlarGuardar()
        If bolError = False Then
            If MessageBox.Show("Desea Guardar Las Modificaciones de Costos..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarModificacionCosto()
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Me.Enabled = False
        frmBuscarCostoMercaderia.txtBuscar.Text = ""
        frmBuscarCostoMercaderia.txtIdMov.Text = 0

        frmBuscarCostoMercaderia.Show()
        frmBuscarCostoMercaderia.BringToFront()
        frmBuscarCostoMercaderia.txtBuscar.Focus()
    End Sub
    '--------------------------------------------------------------------------------------------
    '*****************'
    '-- LAS GRILLAS --'
    '*****************'
    Private Sub dtgCosto_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCosto.CellFormatting

        '-- formato del precio
        If dtgCosto.Columns(e.ColumnIndex).Name.Equals("dtg_precio") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("#,###,###")
        End If
        '-- formato del costo Anterior
        If dtgCosto.Columns(e.ColumnIndex).Name.Equals("dtg_costoAct") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("#,###,###")
        End If
        '-- formato del costo actual
        If dtgCosto.Columns(e.ColumnIndex).Name.Equals("dtg_costoNue") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.Format = ("#,###,###")
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgCosto_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgCosto.SelectionChanged
        Dim douSubtotal As Double = 0
        For i As Integer = 0 To dtgCosto.Rows.Count - 1
            '-- verificar si es numerico
            '-- solo si hay valores
            If dtgCosto.Rows(i).Cells(0).Value > 0 Then
                If IsNumeric(dtgCosto.Rows(i).Cells(8).Value) Then
                    '-- si es numerico
                    '-- colocar una cantidad validad si es que el operador introduce 0 o menos que 0 en el nuevo costo
                    If dtgCosto.Rows(i).Cells(8).Value < 0 And dtgCosto.Rows(i).Cells(0).Value > 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCosto.Rows(i).Cells(8).Value = 0
                    End If
                Else
                    '-- si no es numerico
                    MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtgCosto.Rows(i).Cells(8).Value = 0
                End If
                '-- dar formato al numero ingresado
                dtgCosto.Rows(i).Cells(8).Value = formatoNumerosDecimales(dtgCosto.Rows(i).Cells(8).Value)
            End If
        Next
    End Sub

    Private Sub dtgCosto_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCosto.RowEnter
        Dim row As DataGridViewRow = dtgCosto.Rows(e.RowIndex)
        lblNro.Text = CStr(row.Cells(0).Value)
    End Sub

    Private Sub dtgCosto_GotFocus(sender As Object, e As System.EventArgs) Handles dtgCosto.GotFocus
        For i As Integer = 0 To dtgCosto.Rows.Count - 1
            If dtgCosto.Rows(i).Cells(0).Value > 0 Then
                dtgCosto.Rows(i).Cells(8).ReadOnly = False
            Else
                dtgCosto.Rows(i).Cells(8).ReadOnly = True
            End If
        Next
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmModificarCosto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.MercaderiaModificarCosto.Enabled = True

        e.Cancel = False
    End Sub
    '--------------------------------------------------------------------------------------------
End Class