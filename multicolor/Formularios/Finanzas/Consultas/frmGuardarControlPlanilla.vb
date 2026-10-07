Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmGuardarControlPlanilla
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intNro As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    Public Sub listarDetalle()
        systemClass.SqlToLv_detalleGastoParticularPlanilla(lvDetalleCaja, "sp_consultaDetalleGastoParTmp", intGl_idConfigPc)
    End Sub


    Public Sub sumarTotales()
        If sp_datosTabla.consulta_valor("select idConfig from detControlCajaGastoParTmp where idConfig=" & intGl_idConfigPc) > 0 Then
            txtTotalGastoPar.Text = sp_datosTabla.consulta_valorDouble("select sum(monto) from detControlCajaGastoParTmp where idConfig=" & intGl_idConfigPc)
        Else
            txtTotalGastoPar.Text = 0
        End If

        txtTotalGastoPar.Text = Format(CDec(txtTotalGastoPar.Text), "##,###,###,##0")
    End Sub

    Private Sub inicializaObjetos()
        '-- los txt
        txtNroDoc.Text = ""
        txtConcepto.Text = ""
        txtMonto.Text = 0
    End Sub

    Private Sub cargarGastoParticular()
        If (fun_guardarSp("sp_agregarDetControlCajaGastoParTmp", intGl_idConfigPc & "," & "'" & txtNroDoc.Text & "'" & "," & "'" & Trim(txtConcepto.Text) & "'" & "," & _
                          CDbl(sacarComa(txtMonto.Text)), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            listarDetalle()
            inicializaObjetos()
            sumarTotales()
            txtNroDoc.Focus()
        End If
    End Sub

    Private Sub guardarControlPlanilla()
        If (fun_guardarSp("sp_guardarPlanillaCaja", intGl_idConfigPc & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar el control de la planilla...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            '-- impresion de la planilla
            Dim intTmpIdControlCaja As Integer

            intTmpIdControlCaja = sp_datosTabla.consulta_valor("select max(idControlCaja) from cabControlCaja")
            Me.Enabled = False
            imprimirPlanilla(intTmpIdControlCaja)
            Me.Enabled = True
            '-- eliminar registros temporales
            sp_datosTabla.consulta_valor("delete from detControlCajaTmp where idConfig=" & intGl_idConfigPc)
            sp_datosTabla.consulta_valor("delete from detControlCajaGuaraniesTmp where idConfig=" & intGl_idConfigPc)
            sp_datosTabla.consulta_valor("delete from detControlCajaMonedaTmp where idConfig=" & intGl_idConfigPc)
            sp_datosTabla.consulta_valor("delete from detControlCajaGastoParTmp where idConfig=" & intGl_idConfigPc)

            frmPlanillaCaja.limpiar()
            Me.Close()
        End If
    End Sub

    Private Sub imprimirPlanilla(ByVal v_codigo As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idPlanilla As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        '-- el reporte del deposito bancario
        Dim rpt As New rpt_planillaCaja
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idPlanilla.Value = v_codigo
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idPlanilla)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idControlCaja").ApplyCurrentValues(pvParametros)
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
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        cargarGastoParticular()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar la planilla de control de cajas..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarControlPlanilla()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from detControlCajaGastoParTmp where idConfig=" & intGl_idConfigPc & " and nro=" & intNro)

        sumarTotales()
        listarDetalle()

    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtNroDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDoc.KeyPress
        'e.Handled = txtNumerico(txtCant50, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            'txtCant50.Text = Format(CDec(txtCant50.Text), "##,##0")
            '-- controlar la cantidad
            'If Len(txtCant50.Text) = 0 Then
            '    txtCant50.Text = 0
            'End If
            'sumarTotales()

            txtConcepto.Focus()
        End If
    End Sub

    Private Sub txtConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        'e.Handled = txtNumerico(txtCant50, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            'txtCant50.Text = Format(CDec(txtCant50.Text), "##,##0")
            '-- controlar la cantidad
            'If Len(txtCant50.Text) = 0 Then
            '    txtCant50.Text = 0
            'End If
            'sumarTotales()

            txtMonto.Focus()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,##0")
            '-- controlar la cantidad
            If Len(txtMonto.Text) = 0 Then
                txtMonto.Text = 0
            End If
            btnCargar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvDetalleCaja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetalleCaja.SelectedIndexChanged
        For Each item As ListViewItem In lvDetalleCaja.SelectedItems
            intNro = CInt(item.SubItems(0).Text)
        Next
    End Sub

    Private Sub lvDetalleCaja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetalleCaja.GotFocus
        For Each item As ListViewItem In lvDetalleCaja.SelectedItems
            intNro = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmGuardarControlPlanilla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        frmPlanillaCaja.Enabled = True
        frmPlanillaCaja.Show()
        frmPlanillaCaja.BringToFront()
        frmPlanillaCaja.btnBuscar.Focus()
    End Sub
    '-------------------------------------------------------------------------------------------------

End Class