Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmGenerarCodigoBarraUsuario
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        actualizarUsuario()
        listarUsuario(" where idConfig=" & intGl_idConfigPc)
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarUsuario()
        '-- cargar la tabla temporal
        If (fun_guardarSp("sp_agregarTmpCodigoBarraUsuario", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Cargar la Tabla temporal de los controles de facturas|...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub listarUsuario(ByVal v_where As String)
        '-- limpiar la grilla
        dtgUsuario.Rows.Clear()

        systemClass.SqlToDg_codigoBarraUsuario(dtgUsuario, "select row_number() over(order by nombre),idUsuario,nick,nombre,apellido," & _
        "cargo,imprimir from tmpCodigoBarraUsuario " & v_where)

        txtSql.Text = "select row_number() over(order by nombre),idUsuario,nombre,apellido," & _
        "cargo,imprimir from tmpCodigoBarraUsuario " & v_where

    End Sub

    Private Sub guardarCodigoBarraUsuario()
        '-- recorrer la forma de venta
        For i As Integer = 0 To dtgUsuario.Rows.Count - 1
            If CBool(dtgUsuario.Rows(i).Cells(6).Value()) = True Then
                '-- actualizar el porcentaje adicional
                sp_datosTabla.consulta_valor("update tmpCodigoBarraUsuario set imprimir=1 where idUsuario=" & CInt(dtgUsuario.Rows(i).Cells(1).Value()) & " and idConfig=" & intGl_idConfigPc)
            End If
        Next
        '-- procedimiento para guardar los controles
        If (fun_guardarSp("sp_guardarCodigoBarraUsuario", intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los controles de la Factura...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- imprimir las targetas generadas
            Me.Enabled = False
            imprimirCodigoBarra()
            Me.Enabled = True
            '----------------------------------------
            'actualizarUsuario()
            'listarUsuario(" where idConfig=" & intGl_idConfigPc)
        End If
    End Sub

    '-- imprimir el codigo de barras
    Private Sub imprimirCodigoBarra()
        Dim pvParametros As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_codigoBarraUsuario
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
    '--------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        If rdNick.Checked = True Then
            If Len(txtBuscar.Text) > 0 Then
                '-- buscar por nick
                If IsNumeric(txtBuscar.Text) Then
                    '-- por idUsuario
                    listarUsuario(" where idConfig=" & intGl_idConfigPc & " and idUsuario=" & txtBuscar.Text)
                Else
                    '-- por nick
                    listarUsuario(" Where (nick Like '" & txtBuscar.Text & "%' Or nick Like '" & txtBuscar.Text & "%') and idConfig=" & intGl_idConfigPc)
                End If
            Else
                '-- actualizar
                actualizarUsuario()
                '-- listar todo
                listarUsuario(" where idConfig=" & intGl_idConfigPc)
            End If
        End If
        If rdNombre.Checked Then
            '-- buscar por nombre
            If Len(txtBuscar.Text) > 0 Then
                listarUsuario(" Where (nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%') and idConfig=" & intGl_idConfigPc)
            Else
                '-- listar todo
                listarUsuario(" where idConfig=" & intGl_idConfigPc)
            End If
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        If MessageBox.Show("Desea Generar los Cosigos de Barra de los Usuarios Seleccionados..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarCodigoBarraUsuario()
        End If
    End Sub
    '--------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdCliente_CheckedChanged(sender As System.Object, e As System.EventArgs)
        txtBuscar.Focus()
    End Sub

    Private Sub rdFactura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdNombre.CheckedChanged
        txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgUsuario_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgUsuario.CellFormatting
        '-- formato de la impresion
        If dtgUsuario.Columns(e.ColumnIndex).Name.Equals("Column4") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub dtgUsuario_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgUsuario.CellContentClick
        If e.ColumnIndex = 12 Then
            If dtgUsuario.Rows(e.RowIndex).Cells(0).Value > 0 Then
                If (Convert.ToBoolean(dtgUsuario.Rows(e.RowIndex).Cells(6).Value)) Then

                    dtgUsuario.Rows(e.RowIndex).Cells(6).Value = False
                    'dtgPago.Rows(e.RowIndex).Cells(8).Value = 0
                Else
                    dtgUsuario.Rows(e.RowIndex).Cells(6).Value = True
                End If
            End If
        End If
    End Sub

    Private Sub dtgUsuario_GotFocus(sender As Object, e As System.EventArgs) Handles dtgUsuario.GotFocus
        For i As Integer = 0 To dtgUsuario.Rows.Count - 1
            If dtgUsuario.Rows(i).Cells(0).Value > 0 Then
                dtgUsuario.Rows(i).Cells(6).ReadOnly = False
            Else
                dtgUsuario.Rows(i).Cells(6).ReadOnly = True
            End If
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnBuscar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmGenerarCodigoBarraUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.configuracionGenerarCodigoBarraUsuario.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------
End Class