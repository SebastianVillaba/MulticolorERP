Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteCajaSeleccion
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss "
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss "
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listarCaja()
        '-- limpiar la grilla
        dtgCaja.Rows.Clear()

        systemClass.SqlToDg_imprimirCaja(dtgCaja, "select nro,sucursal,idCaja,totalCaja," & _
        "totalSistema,fechaAlta,imprimir from tmpImprimirCaja ")
    End Sub

    Private Sub imprimirCajaSeleccionada()
        '-- actualizar las cajas seleccionadas
        For i As Integer = 0 To dtgCaja.Rows.Count - 1
            If CBool(dtgCaja.Rows(i).Cells(6).Value()) = True Then
                '-- actualizar la tabla temporal
                sp_datosTabla.consulta_valor("update tmpImprimirCaja set imprimir=1 where idCaja=" & CInt(dtgCaja.Rows(i).Cells(2).Value()) & " and idConfig=" & intGl_idConfigPc)
            End If
        Next
        '------------------'
        '-- la impresion --'
        '------------------'
        Try
            Me.Enabled = False

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_ventaResumidoFecha
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            ' v_idSucursalCon.Value = cboSucursal.SelectedValue
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idSucursalCon)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            '-- asignar los valores al objeto del reporte
            ofrm.CrystalReportViewer1.ReportSource = rpt
            '-- procedimiento para evitar el usuario y contraseña de la base de datos
            evitarPassDatabase(rpt)
            '-- mostrar el reporte
            ofrm.WindowState = FormWindowState.Maximized
            ofrm.Show()

            Me.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try


    End Sub

    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        '-- el procedimiento
        If (fun_guardarSp("sp_agregarTmpImprimirCaja", intGl_idConfigPc & "," & dtpDesdeFecha.Text & "," & dtpHastaFecha.Text, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Enabled = True
        Else
            Me.Enabled = True
            listarCaja()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS DATAGRID --'
    '******************'
    '-- el formato de las celdas
    Private Sub dtgCaja_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCaja.CellFormatting
        '-- formato total caja
        If dtgCaja.Columns(e.ColumnIndex).Name.Equals("Column2") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.Yellow
        End If
        '-- formato total sistema
        If dtgCaja.Columns(e.ColumnIndex).Name.Equals("Column3") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgCaja_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCaja.CellContentClick
        If e.ColumnIndex = 6 Then
            If dtgCaja.Rows(e.RowIndex).Cells(0).Value > 0 Then
                If (Convert.ToBoolean(dtgCaja.Rows(e.RowIndex).Cells(6).Value)) Then

                    dtgCaja.Rows(e.RowIndex).Cells(6).Value = False
                    'dtgPago.Rows(e.RowIndex).Cells(8).Value = 0
                Else
                    dtgCaja.Rows(e.RowIndex).Cells(6).Value = True
                End If
            End If
        End If
    End Sub

    Private Sub dtgCaja_GotFocus(sender As Object, e As System.EventArgs) Handles dtgCaja.GotFocus
        For i As Integer = 0 To dtgCaja.Rows.Count - 1
            If dtgCaja.Rows(i).Cells(0).Value > 0 Then
                dtgCaja.Rows(i).Cells(6).ReadOnly = False
            Else
                dtgCaja.Rows(i).Cells(6).ReadOnly = True
            End If
        Next
    End Sub

    '-- colocar los puntos separadores
    Private Sub dtgCaja_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgCaja.SelectionChanged
        For i As Integer = 0 To dtgCaja.Rows.Count - 1
            '-- el total de la venta
            dtgCaja.Rows(i).Cells(3).Value = formatoNumerosDecimales(dtgCaja.Rows(i).Cells(3).Value)
            dtgCaja.Rows(i).Cells(4).Value = formatoNumerosDecimales(dtgCaja.Rows(i).Cells(4).Value)

        Next
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteCajaSeleccion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        'frmMenuPrincipal.clienteControlarFactura.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------
End Class