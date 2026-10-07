Public Class frmReferenciarMercaderias
    Dim sp_datosTabla As New sp_datosTabla
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
        '-- eliminar todo de la tabla temporal
        sp_datosTabla.consulta_valor("delete detProductoRefTmp where idConfigPc=" & intGl_idConfigPc)
        'listar_busqueda("")
        intGl_nroReferenciarMercaderia = 0
        'valorde del combo
    End Sub

    Private Sub controlarReferencia()
        '-- ver que se ingresó un producto como cabecera
        If txtIdProducto.Text = "" Then
            MessageBox.Show("Debe ingresar el Producto a referenciar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            banError = True
            Exit Sub
        End If
        '-- ver si hay error dentro de la grilla
        Dim intTmpValorRegistros As Integer = 0
        Dim intTmpIdProducto As Integer = 0
        For i As Integer = 0 To dtgReferencia.Rows.Count - 1
            '-- si existen item cargados
            If dtgReferencia.Rows(i).Cells(0).Value > 0 Then
                intTmpValorRegistros = intTmpValorRegistros + 1
                '-- si la cantidad no es válida
                If dtgReferencia.Rows(i).Cells(3).Value <= 0 Then
                    MessageBox.Show("Existen cantidades que no son válidas..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    banError = True
                    Exit Sub
                End If
                '-- actualizar la cantidad del detalle
                intTmpIdProducto = sp_datosTabla.un_dato_integer("idProducto", "producto", "codigo", dtgReferencia.Rows(i).Cells(1).Value)
                sp_datosTabla.sp_string("sp_updDetProductoRefTmp", intGl_idConfigPc & "," & intTmpIdProducto & "," & dtgReferencia.Rows(i).Cells(3).Value & "," & CBool(dtgReferencia.Rows(i).Cells(4).Value))
            End If
        Next
        '-- si no existe nungun item cargado
        If intTmpValorRegistros = 0 Then
            MessageBox.Show("No existe item cargados..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            banError = True
            Exit Sub
        End If

    End Sub

    Private Sub guardarReferencia()
        If (fun_guardarSp("sp_guardarProductoRef", CInt(txtIdProducto.Text) & "," & intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            MessageBox.Show("Se guardaron con Exito los cambios..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Sub
    '-----------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        bolGl_refMercaderias = True
        Me.Enabled = False
        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = "0"
        frmStock.Visible = True
        frmStock.WindowState = FormWindowState.Normal
        frmStock.Show()
        frmStock.txtBuscar.Focus()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        bolGl_refMercaderiasDetalle = True
        Me.Enabled = False
        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = "0"
        frmStock.Visible = True
        frmStock.WindowState = FormWindowState.Normal
        frmStock.Show()
        frmStock.txtBuscar.Focus()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lblNro.Text <> "" Then
            If dtgReferencia.SelectedCells.Count > 0 Then
                '-- procedimiento para eliminar de la base de datos
                sp_datosTabla.sp_string("sp_deleteDetProductoRefTmp", intGl_idConfigPc & "," & CInt(lblIdProducto.Text))
                '---------------------------------------------------------
                dtgReferencia.Rows.Remove(dtgReferencia.CurrentRow)
                '-- volver a renumerar
                intGl_nroReferenciarMercaderia = 0
                For i As Integer = 0 To dtgReferencia.Rows.Count - 1
                    If dtgReferencia.Rows(i).Cells(0).Value > 0 Then
                        intGl_nroReferenciarMercaderia = intGl_nroReferenciarMercaderia + 1
                        dtgReferencia.Rows(i).Cells(0).Value = intGl_nroReferenciarMercaderia
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        '-- inicializar la variable global general
        intGl_nroReferenciarMercaderia = 0
        '-- limpiar la tabla temporal de la base de datos
        sp_datosTabla.consulta_valor("delete detProductoRefTmp where idConfigPc=" & intGl_idConfigPc)
        '-- limpiar la grilla
        dtgReferencia.Rows.Clear()
        '-- los botones
        btnAgregar.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
        '-- los txt
        txtCodigo.Text = ""
        txtIdProducto.Text = 0
        txtNombreProducto.Text = ""
        lblIdProducto.Text = 0
        lblNro.Text = 0

        btnNuevo.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        controlarReferencia()
        If banError = False Then
            If MessageBox.Show("Desea Guardar la Referencia..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarReferencia()
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------
    '***************'
    '-- LA GRILLA --'
    '***************'
    Private Sub dtgReferencia_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgReferencia.CellFormatting
        '-- formato de cantidad
        If dtgReferencia.Columns(e.ColumnIndex).Name.Equals("Column3") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("#,###.##")
        End If

    End Sub

    Private Sub dtgReferencia_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgReferencia.RowEnter
        Dim row As DataGridViewRow = dtgReferencia.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto label
        lblNro.Text = CStr(row.Cells(0).Value)
        '- asignar el id de producto al objeto
        lblIdProducto.Text = sp_datosTabla.un_dato_integer("idProducto", "producto", "codigo", row.Cells(1).Value)
    End Sub
    '-----------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmReferenciarMercaderias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        '-- limpiar la tabla temporal de la base de datos
        sp_datosTabla.consulta_valor("delete detProductoRefTmp where idConfigPc=" & intGl_idConfigPc)

        frmMenuPrincipal.mercaderiaReferenciarMercaderia.Enabled = True
        e.Cancel = False
    End Sub
    '-----------------------------------------------------------------------------------------------

End Class