Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteArqueo
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim empresaContable As New empresaContable

    Dim intIdSucursal As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"

        txtIdCaja.Text = 0
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub imprimirResumenArqueo()
        Try
            intIdSucursal = CInt(txtIdSucursal.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

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
            Dim rpt As New rpt_resumenArqueo
            Dim ofrm As New crv()

            v_idSucursalCon.Value = intIdSucursal
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idSucursalCon)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    Private Sub imprimirDetalleArqueo()

    End Sub

    Private Sub imprimirResumenArqueoSucursal()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_resumenCajaSucursales
            Dim ofrm As New crv()

            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- reporte detallado de la caja
    Private Sub imprimirDetalleCaja()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idCaja As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_cajaDetallado
            Dim ofrm As New crv()

            v_idCaja.Value = CInt(txtIdCaja.Text)
            v_idSucursalCon.Value = 1


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idCaja)
            pvParametros2.Add(v_idSucursalCon)

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idCaja").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- reporte de diferentes cajas por sucursal
    Private Sub imprimirResumenDiferentesCajasSucursal()
        Try
            intIdSucursal = CInt(txtIdSucursal.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

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
            Dim rpt As New rpt_resumenArqueoPorCaja
            Dim ofrm As New crv()

            v_idSucursalCon.Value = intIdSucursal
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idSucursalCon)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)

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
        Me.Enabled = False

        If rdDetalle.Checked = True Then
            '-- detalle del arqueo
            imprimirDetalleCaja()
        End If
        If rdResumen.Checked = True Then
            '-- debe introducir la sucursal
            If Not IsNumeric(txtIdSucursal.Text) Then
                MessageBox.Show("Debe Introducir la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Enabled = True
                Exit Sub
            End If
            If txtIdSucursal.Text = 0 Then
                MessageBox.Show("Debe Introducir la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Enabled = True
                Exit Sub
            End If
            '-- resumen del arquo
            imprimirResumenArqueo()
        End If
        If rdResumenCajaSucursal.Checked = True Then
            '-- resumen de caja de todas las sucursales
            imprimirResumenArqueoSucursal()
        End If
        If rdCajaSucursal.Checked = True Then
            '-- resumen de diferentes cajas por sucursal
            If Not IsNumeric(txtIdSucursal.Text) Then
                MessageBox.Show("Debe Introducir la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Enabled = True
                Exit Sub
            End If
            If txtIdSucursal.Text = 0 Then
                MessageBox.Show("Debe Introducir la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Enabled = True
                Exit Sub
            End If
            '-- resumen del arquo
            imprimirResumenDiferentesCajasSucursal()
        End If
        '---------------------------------------------------------
        Me.Enabled = True
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Me.Enabled = False
        banGl_reporteArqueoCaja = True
        frmBuscarSucursal.txtId.Text = 0
        frmBuscarSucursal.txtNombre.Text = ""
        frmBuscarSucursal.txtBuscar.Text = ""
        frmBuscarSucursal.Show()
        frmBuscarSucursal.BringToFront()
        frmBuscarSucursal.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtIdCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdCaja.KeyPress
        e.Handled = txtNumerico(txtIdCaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnConsultar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdResumne_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdResumen.Click
        lblDesde.Visible = True
        lblHasta.Visible = True
        lblNroCaja.Visible = False

        txtIdCaja.Visible = False
        dtpDesdeFecha.Visible = True
        dtpHastaFecha.Visible = True

    End Sub

    Private Sub rdResumenCajaSucursal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdResumenCajaSucursal.Click
        lblDesde.Visible = True
        lblHasta.Visible = True
        lblNroCaja.Visible = False

        txtIdCaja.Visible = False
        dtpDesdeFecha.Visible = True
        dtpHastaFecha.Visible = True

    End Sub

    Private Sub rdDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDetalle.Click
        lblDesde.Visible = False
        lblHasta.Visible = False
        lblNroCaja.Visible = True

        txtIdCaja.Visible = True
        dtpDesdeFecha.Visible = False
        dtpHastaFecha.Visible = False

        txtIdCaja.Text = 0
        txtIdCaja.Focus()
    End Sub
    '------------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteArqueo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.finanzaReportesArqueo.Enabled = True
    End Sub
End Class