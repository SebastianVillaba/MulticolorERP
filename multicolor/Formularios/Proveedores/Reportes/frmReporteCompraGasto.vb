Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteCompraGasto
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim empresaContable As New empresaContable
    Dim tipoSucursal As New tipoSucursal

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"
        '-- valor para el combo de la empresa contable
        empresaContable.comboEmpresaContable(cboEmpresaContable)
        tipoSucursal.comboTipoSucursal(cboTipoEmpresa)

        lblIdCuenta.Text = 0
        lblNombreCuenta.Text = ""
        lblIdProveedor.Text = 0
        lblNombreProveedor.Text = ""
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- impresion de compras
    Private Sub imprimirCompra()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdEmpresaContable As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdEmpresaContable As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteCompraProveedor
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdEmpresaContable.Value = cboEmpresaContable.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdEmpresaContable.Add(v_IdEmpresaContable)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvIdEmpresaContable)
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

    '-- impresion de compras por tipo de empresa
    Private Sub imprimirCompraEmpresa()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdEmpresaContable As New ParameterValues()
            Dim pvIdTipoSuc As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdEmpresaContable As New ParameterDiscreteValue()
            Dim v_IdTipoSuc As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteCompraProveedorEmpresa
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdEmpresaContable.Value = cboEmpresaContable.SelectedValue
            v_IdTipoSuc.Value = cboTipoEmpresa.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdEmpresaContable.Add(v_IdEmpresaContable)
            pvIdTipoSuc.Add(v_IdTipoSuc)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@idTipoSucursal").ApplyCurrentValues(pvIdTipoSuc)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvIdEmpresaContable)
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

    '-- impresion de Gastos
    Private Sub imprimirGasto()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdEmpresaContable As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdEmpresaContable As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteGastoProveedor
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdEmpresaContable.Value = cboEmpresaContable.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdEmpresaContable.Add(v_IdEmpresaContable)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvIdEmpresaContable)
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

    '-- impresion de Gastos por tipo de empresa
    Private Sub imprimirGastoEmp()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdEmpresaContable As New ParameterValues()
            Dim pvIdTipoSuc As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdEmpresaContable As New ParameterDiscreteValue()
            Dim v_IdTipoSuc As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteGastoProveedorEmp
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdEmpresaContable.Value = cboEmpresaContable.SelectedValue
            v_IdTipoSuc.Value = cboTipoEmpresa.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdEmpresaContable.Add(v_IdEmpresaContable)
            pvIdTipoSuc.Add(v_IdTipoSuc)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvIdEmpresaContable)
            rpt.DataDefinition.ParameterFields("@idTipoSucursal").ApplyCurrentValues(pvIdTipoSuc)
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

    '-- impresion de Gastos deducibles
    Private Sub imprimirGastoDeducible()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdEmpresaContable As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdEmpresaContable As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteGastoProveedorDeducible
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdEmpresaContable.Value = cboEmpresaContable.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdEmpresaContable.Add(v_IdEmpresaContable)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvIdEmpresaContable)
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

    '-- impresion de Gastos no deducibles
    Private Sub imprimirGastoNoDeducible()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdEmpresaContable As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdEmpresaContable As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteGastoProveedorNoDeducible
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdEmpresaContable.Value = cboEmpresaContable.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdEmpresaContable.Add(v_IdEmpresaContable)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvIdEmpresaContable)
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

    '-- impresion de Gastos por cuenta contables
    Private Sub imprimirGastoCuentaContable()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdCuenta As New ParameterValues()
            Dim pvIdEmpresaContable As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_idCuenta As New ParameterDiscreteValue()
            Dim v_IdEmpresaContable As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteGastoProveedorCuenta
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_idCuenta.Value = CInt(lblIdCuenta.Text)
            v_IdEmpresaContable.Value = cboEmpresaContable.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdCuenta.Add(v_idCuenta)
            pvIdEmpresaContable.Add(v_IdEmpresaContable)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idPlanCuenta").ApplyCurrentValues(pvIdCuenta)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvIdEmpresaContable)
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

    '-- impresion de compras
    Private Sub imprimirCompraPorProveedor()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdProveedor As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdProveedor As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteCompraPorProveedor
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdProveedor.Value = lblIdProveedor.Text

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdProveedor.Add(v_IdProveedor)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@idProveedor").ApplyCurrentValues(pvIdProveedor)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
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

    '-- impresion de compras por tipo de empresa
    Private Sub imprimirCompraPorProveedorEmpresa()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdProveedor As New ParameterValues()
            Dim pvIdTipoSuc As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_IdProveedor As New ParameterDiscreteValue()
            Dim v_IdTipoSuc As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteCompraPorProveedor
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_IdProveedor.Value = lblIdProveedor.Text
            v_IdTipoSuc.Value = cboTipoEmpresa.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdProveedor.Add(v_IdProveedor)
            pvIdTipoSuc.Add(v_IdTipoSuc)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@idProveedor").ApplyCurrentValues(pvIdProveedor)
            rpt.DataDefinition.ParameterFields("@idTipoSucursal").ApplyCurrentValues(pvIdTipoSuc)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
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


    '-- impresion resumen total de compras
    Private Sub imprimirResumenTotalCompra()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteCompraResumen
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
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

    '-- impresion resumen total de compras por tipo de empresa
    Private Sub imprimirResumenTotalCompraEmp()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdTipoSuc As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_idTipoSuc As New ParameterDiscreteValue()

            '------------------------------------
            Dim rpt As New rpt_reporteCompraResumenEmp
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_idTipoSuc.Value = cboTipoEmpresa.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdTipoSuc.Add(v_idTipoSuc)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idTipoSucursal").ApplyCurrentValues(pvIdTipoSuc)
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

    '-- impresion resumen total de gastos
    Private Sub imprimirResumenTotalGasto()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteGastoResumen
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
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

    '-- impresion resumen total de gastos por tipo de empresa
    Private Sub imprimirResumenTotalGastoEmp()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim pvDesde As New ParameterValues()
            Dim pvHasta As New ParameterValues()
            Dim pvIdTipoSuc As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_Desde As New ParameterDiscreteValue()
            Dim v_Hasta As New ParameterDiscreteValue()
            Dim v_idTipoSuc As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_reporteGastoResumenEmp
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_Desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_Hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_idTipoSuc.Value = cboTipoEmpresa.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            pvDesde.Add(v_Desde)
            pvHasta.Add(v_Hasta)
            pvIdTipoSuc.Add(v_idTipoSuc)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvDesde)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvHasta)
            rpt.DataDefinition.ParameterFields("@idTipoSucursal").ApplyCurrentValues(pvIdTipoSuc)
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
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.Enabled = False

        If rdCompra.Checked = True Then
            '--------------------------'
            '-- IMPRESION DE COMPRAS --'
            '--------------------------'
            If chkTipoEmpresa.Checked = True Then
                '--- POR TIPO DE EMPRESA
                If chkProveedor.Checked = True Then
                    '-- por proveedor
                    imprimirCompraPorProveedorEmpresa()
                Else
                    '-- todos los proveedores
                    imprimirCompraEmpresa()
                End If
            Else
                '-- TODAS LOS TIPOS DE EMPRESA
                If chkProveedor.Checked = True Then
                    '-- por proveedor
                    imprimirCompraPorProveedor()
                Else
                    '-- todos los proveedores
                    imprimirCompra()
                End If
            End If

        End If
        If rdGasto.Checked = True Then
            '-------------------------'
            '-- IMPRESION DE GASTOS --'
            '-------------------------'
            If rdTodoGasto.Checked = True Then
                '-- todos los gastos
                If chkTipoEmpresa.Checked = True Then
                    '-- por tipo de empresa
                    imprimirGastoEmp()
                Else
                    '-- todos los tipos de empresa
                    imprimirGasto()
                End If

            End If
            If rdDeducible.Checked = True Then
                '-- los gastos deducibles
                imprimirGastoDeducible()
            End If
            If rdNoDeducible.Checked = True Then
                '-- los gastos no deducibles
                imprimirGastoNoDeducible()
            End If
            If rdCuenta.Checked = True Then
                '-- reporte de gastos por cuenta contable
                imprimirGastoCuentaContable()
            End If
        End If
        If rdResumenCompra.Checked = True Then
            '------------------------------'
            '-- RESUMEN TOTAL DE COMPRAS --'
            '------------------------------'
            If chkTipoEmpresa.Checked = True Then
                '-- por tipo de empresa
                imprimirResumenTotalCompraEmp()
            Else
                '-- todos los tipos de empresa
                imprimirResumenTotalCompra()
            End If

        End If
        If rdResumenGasto.Checked = True Then
            '-----------------------------'
            '-- RESUMEN TOTAL DE GASTOS --'
            '-----------------------------'
            If chkTipoEmpresa.Checked = True Then
                '-- por tipo de empresa
                imprimirResumenTotalGastoEmp()
            Else
                '-- todos los tipos de empresa
                imprimirResumenTotalGasto()
            End If

        End If
        Me.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdCostoMayor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdGasto.Click
        grGasto.Visible = True
    End Sub

    Private Sub rdCompra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdCompra.Click
        grGasto.Visible = False
    End Sub

    '----------------------------------------------------------------------------------------------------------
    '**************'
    '-- CHECKBOX --'
    '**************'
    Private Sub chkProveedor_Click(sender As Object, e As System.EventArgs) Handles chkProveedor.Click
        If chkProveedor.Checked = True Then
            banGl_reporteCompraGasto = True

            Me.Enabled = False

            frmBuscarProveedor.txtIdProveedor.Text = 0
            frmBuscarProveedor.txtNombreProveedor.Text = ""
            frmBuscarProveedor.txtBuscar.Text = ""
            frmBuscarProveedor.Visible = True
            frmBuscarProveedor.WindowState = FormWindowState.Normal
            frmBuscarProveedor.Show()
            frmBuscarProveedor.txtBuscar.Focus()
        Else
            lblIdProveedor.Text = 0
            lblNombreProveedor.Text = ""
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteCompraGasto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.proveedorReporteCompraGasto.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------


End Class