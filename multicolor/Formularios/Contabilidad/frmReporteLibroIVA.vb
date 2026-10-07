Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.IO

Public Class frmReporteLibroIVA
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim empresaContable As New empresaContable

    Dim intIdSucursal As Integer
    Dim intIdEmpresaContable As Integer

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
        txtIdSucursal.Text = 0
        lblTotalTxt.Text = 0
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub imprimirResumenVenta()
        Try
            intIdSucursal = CInt(txtIdSucursal.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idEmpresaCon As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_libroVentaResumido
            Dim ofrm As New crv()

            v_idEmpresaCon.Value = cboEmpresaContable.SelectedValue
            v_idSucursalCon.Value = intIdSucursal
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            'v_hasta.Value = CDate(dtpHastaFecha.Text)
            'MsgBox("Valor idEmpresaCon  " & v_idEmpresaCon.Value)
            'MsgBox("Valor de idSucursalCon  " & v_idSucursalCon.Value)
            'MsgBox("Valor desde  " & v_desde.Value)
            'MsgBox("Valor hasta  " & v_hasta.Value)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idEmpresaCon)
            pvParametros2.Add(v_idSucursalCon)
            pvParametros3.Add(v_desde)
            pvParametros4.Add(v_hasta)



            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros4)

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

    Private Sub imprimirDetalleVenta()
        Try
            intIdSucursal = CInt(txtIdSucursal.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idEmpresaCon As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_libroVentaDetallado
            Dim ofrm As New crv()

            v_idEmpresaCon.Value = cboEmpresaContable.SelectedValue
            v_idSucursalCon.Value = intIdSucursal
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            'v_hasta.Value = CDate(dtpHastaFecha.Text)
            'MsgBox("Valor idEmpresaCon  " & v_idEmpresaCon.Value)
            'MsgBox("Valor de idSucursalCon  " & v_idSucursalCon.Value)
            'MsgBox("Valor desde  " & v_desde.Value)
            'MsgBox("Valor hasta  " & v_hasta.Value)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idEmpresaCon)
            pvParametros2.Add(v_idSucursalCon)
            pvParametros3.Add(v_desde)
            pvParametros4.Add(v_hasta)



            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros4)

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

    Private Sub imprimirDetalleVentaExcel()
        Try
            intIdSucursal = CInt(txtIdSucursal.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idEmpresaCon As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_libroVentaDetalladoExcel
            Dim ofrm As New crv()

            v_idEmpresaCon.Value = cboEmpresaContable.SelectedValue
            v_idSucursalCon.Value = intIdSucursal
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            'v_hasta.Value = CDate(dtpHastaFecha.Text)
            'MsgBox("Valor idEmpresaCon  " & v_idEmpresaCon.Value)
            'MsgBox("Valor de idSucursalCon  " & v_idSucursalCon.Value)
            'MsgBox("Valor desde  " & v_desde.Value)
            'MsgBox("Valor hasta  " & v_hasta.Value)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idEmpresaCon)
            pvParametros2.Add(v_idSucursalCon)
            pvParametros3.Add(v_desde)
            pvParametros4.Add(v_hasta)



            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros4)

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

    Private Sub imprimirLibroCompraTodo()
        Try
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idEmpresaCon As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_libroCompra
            Dim ofrm As New crv()

            v_idEmpresaCon.Value = cboEmpresaContable.SelectedValue
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            'v_hasta.Value = CDate(dtpHastaFecha.Text)
            'MsgBox("Valor idEmpresaCon  " & v_idEmpresaCon.Value)
            'MsgBox("Valor de idSucursalCon  " & v_idSucursalCon.Value)
            'MsgBox("Valor desde  " & v_desde.Value)
            'MsgBox("Valor hasta  " & v_hasta.Value)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idEmpresaCon)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)



            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idEmpresaCon").ApplyCurrentValues(pvParametros1)
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

    Private Sub imprimirResumenPohaRoga()
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
            Dim rpt As New rpt_libroVentaResumidoPoha
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

    Private Sub imprimirArchivoVentaTxt()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_generarVentaTxt
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

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

    '-- reporte resumido de saldo del proveedor
    Private Sub imprimirSaldoProveedorResumen()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_saldoProveedorResumen
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
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

    '-- reporte de nota de credito
    Private Sub imprimirNotaCredito()
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
            Dim rpt As New rpt_reporteNotaCreditoProveedor
            Dim ofrm As New crv()

            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            'v_hasta.Value = CDate(dtpHastaFecha.Text)
            'MsgBox("Valor idEmpresaCon  " & v_idEmpresaCon.Value)
            'MsgBox("Valor de idSucursalCon  " & v_idSucursalCon.Value)
            'MsgBox("Valor desde  " & v_desde.Value)
            'MsgBox("Valor hasta  " & v_hasta.Value)


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
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click

        If rdCompra.Checked = True Then
            Me.Enabled = False
            '-------------'
            '-- compras --'
            '-------------'
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

            imprimirLibroCompraTodo()
            Me.Enabled = True
        End If

        If rdVenta.Checked = True Then
            '-- debe introducir la sucursal
            If Not IsNumeric(txtIdSucursal.Text) Then
                MessageBox.Show("Debe Introducir la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtIdSucursal.Text = 0 Then
                MessageBox.Show("Debe Introducir la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            '--- cargar en la tabla temporal
            If (fun_guardarSp("sp_cargarTmpLibroIva", intGl_idConfigPc & "," & cboEmpresaContable.SelectedValue & "," & CInt(txtIdSucursal.Text) & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Enabled = True
            End If

            '------------'
            '-- ventas --'
            '------------'
            If rdDetalle.Checked = True Then
                '-- detalle
                If chkSoloExcel.Checked = False Then
                    imprimirDetalleVenta()
                Else
                    '-- solo para excel
                    imprimirDetalleVentaExcel()
                End If

            End If
            If rdResumen.Checked = True Then
                '-- resumen
                imprimirResumenVenta()
            End If
        End If

        If rdArchivoEstudio.Checked = True Then
            Me.Enabled = False

            Dim c As Cursor = Me.Cursor
            Try
                Dim intTmpIdPersonaJur As Integer
                intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from v_empresaContable where idEmpresacontable=" & cboEmpresaContable.SelectedValue)
                '-- generar el archivo de venta para convertir a txt
                If (fun_guardarSp("sp_agregarTmpVentaContableZayas", intGl_idConfigPc & "," & intTmpIdPersonaJur & "," & CInt(txtIdSucursal.Text) & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar los Registros a la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Enabled = True
                Else
                    '-- mostrar el detalle
                    Me.Enabled = False
                    '-- colcar el nombre del archivo
                    frmArchivoEstudioContable.Show()
                    frmArchivoEstudioContable.BringToFront()
                End If
            Catch ex As Exception
                Me.Cursor = c
            Finally
                Me.Cursor = c
            End Try

        End If

        If rdSaldoProveedorCompra.Checked = True Then
            '--- saldo de proveedor en compras
            Me.Enabled = False
            If (fun_guardarSp("sp_agregarTmpReporteSaldoProveedorCompra", intGl_idConfigPc & "," & cboEmpresaContable.SelectedValue & "," & "'" & dtpHastaFecha.Text & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Agregar los Registros a la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                imprimirSaldoProveedorResumen()
            End If
            Me.Enabled = True

        End If
        If rdTimbrados.Checked = True Then
            '-- timbrados de sucursales
            Me.Enabled = False
            frmTimbrado.listarDetalle("")
            frmTimbrado.actualizarTimbradoSucursal("")
            frmTimbrado.Show()
            frmTimbrado.BringToFront()
            frmTimbrado.txtBuscar.Focus()
        End If
        If rdRg90.Checked = True Then
            Me.Enabled = False

            Dim c As Cursor = Me.Cursor
            Try
                Dim intTmpIdPersonaJur As Integer
                intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from v_empresaContable where idEmpresacontable=" & cboEmpresaContable.SelectedValue)
                '-- generar el archivo de venta para convertir a txt
                If (fun_guardarSp("sp_agregarTmpRg90", intGl_idConfigPc & "," & CInt(txtIdSucursal.Text) & "," & cboEmpresaContable.SelectedValue & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar los Registros a la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Enabled = True
                Else
                    '-- mostrar el detalle
                    Me.Enabled = False
                    '-- colcar el nombre del archivo
                    frmRg90.Show()
                    frmRg90.BringToFront()
                End If
            Catch ex As Exception
                Me.Cursor = c
            Finally
                Me.Cursor = c
            End Try

        End If

        If rdNotaCredito.Checked = True Then
            Me.Enabled = False
            '-- imprimir nota de credito
            imprimirNotaCredito()
            Me.Enabled = True
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Me.Enabled = False
        banGl_reporteLibroIva = True
        frmBuscarSucursal.txtId.Text = 0
        frmBuscarSucursal.txtNombre.Text = ""
        frmBuscarSucursal.txtBuscar.Text = ""
        frmBuscarSucursal.Show()
        frmBuscarSucursal.BringToFront()
        frmBuscarSucursal.txtBuscar.Focus()
    End Sub

    Private Sub btnExportarCabecera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarCabecera.Click
        Dim filepath As String = "c:\Multicolor\cabeceraTxt.txt"
        Using file As New IO.StreamWriter(filepath, False)
            Dim line As String = ""
            Dim intTmpContador As Integer = 0
            For Each item As ListViewItem In lvCabecera.Items
                line = ""
                For Each subitem As ListViewItem.ListViewSubItem In item.SubItems
                    'line = line + (Trim(item.SubItems(0).Text) + ";" + Trim(item.SubItems(1).Text) + ";" + Trim(item.SubItems(2).Text) & _
                    '";" + (Trim(item.SubItems(3).Text)) + ";" + Trim(item.SubItems(4).Text) + ";" + Trim(item.SubItems(5).Text) & _
                    '";" + (Trim(item.SubItems(6).Text)) + ";" + Trim(item.SubItems(7).Text) + ";" + Trim(item.SubItems(8).Text) & _
                    '";" + (Trim(item.SubItems(9).Text)) + ";" + Trim(item.SubItems(10).Text) + ";" + Trim(item.SubItems(11).Text) & _
                    '";" + (Trim(item.SubItems(12).Text)) + ";" + Trim(item.SubItems(13).Text) + ";" + Trim(item.SubItems(14).Text) & _
                    '";" + (Trim(item.SubItems(15).Text)) + ";" + Trim(item.SubItems(16).Text) + ";" + Trim(item.SubItems(17).Text) & _
                    '";" + (Trim(item.SubItems(18).Text)) + ";" + Trim(item.SubItems(19).Text) + ";" + Trim(item.SubItems(20).Text) & _
                    '";" + (Trim(item.SubItems(21).Text)) + ";" + Trim(item.SubItems(22).Text) + ";" + Trim(item.SubItems(23).Text) & _
                    '";" + (Trim(item.SubItems(24).Text)))

                    'MsgBox("Valor " & item.SubItems(24).ToString)
                    'intTmpContador = intTmpContador + 1
                    'If intTmpContador = 1 Then
                    '    line = Trim(subitem.Text) & ";"
                    'Else
                    line = line & Trim(subitem.Text) & ";"
                    'End If
                Next
                file.WriteLine(line)
            Next
            file.Close()
        End Using
        Process.Start(filepath)
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarDetalle.Click
        Dim filepath As String = "c:\Multicolor\detalleTxt.txt"
        Using file As New IO.StreamWriter(filepath, False)
            Dim line As String = ""
            Dim intTmpContador As Integer = 0
            For Each item As ListViewItem In lvArchivo.Items
                line = ""
                For Each subitem As ListViewItem.ListViewSubItem In item.SubItems
                    'line = line + (Trim(item.SubItems(0).Text) + ";" + Trim(item.SubItems(1).Text) + ";" + Trim(item.SubItems(2).Text) & _
                    '";" + (Trim(item.SubItems(3).Text)) + ";" + Trim(item.SubItems(4).Text) + ";" + Trim(item.SubItems(5).Text) & _
                    '";" + (Trim(item.SubItems(6).Text)) + ";" + Trim(item.SubItems(7).Text) + ";" + Trim(item.SubItems(8).Text) & _
                    '";" + (Trim(item.SubItems(9).Text)) + ";" + Trim(item.SubItems(10).Text) + ";" + Trim(item.SubItems(11).Text) & _
                    '";" + (Trim(item.SubItems(12).Text)) + ";" + Trim(item.SubItems(13).Text) + ";" + Trim(item.SubItems(14).Text) & _
                    '";" + (Trim(item.SubItems(15).Text)) + ";" + Trim(item.SubItems(16).Text) + ";" + Trim(item.SubItems(17).Text) & _
                    '";" + (Trim(item.SubItems(18).Text)) + ";" + Trim(item.SubItems(19).Text) + ";" + Trim(item.SubItems(20).Text) & _
                    '";" + (Trim(item.SubItems(21).Text)) + ";" + Trim(item.SubItems(22).Text) + ";" + Trim(item.SubItems(23).Text) & _
                    '";" + (Trim(item.SubItems(24).Text)))

                    'MsgBox("Valor " & item.SubItems(24).ToString)
                    'intTmpContador = intTmpContador + 1
                    'If intTmpContador = 1 Then
                    '    line = Trim(subitem.Text) & ";"
                    'Else
                    line = line & Trim(subitem.Text) & ";"
                    'End If
                Next
                file.WriteLine(line)
            Next
            file.Close()
        End Using
        Process.Start(filepath)
        'MessageBox.Show("Fin de la Exportación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
            '-- generar los archivos txt del inventario
        frmArchivoEstudioContable.txtDireccion.Text = "c:\Multicolor\Archivos_TXT_Ventas_Estudio\2013\Septiembre\" & Trim(txtSucursal.Text) & Trim(FormatoFechaSoloDatePicker(dtpDesdeFecha)) & ".txt"
        Me.Enabled = False
        systemClass.SqlToLv_detalleArchivoTxt(frmArchivoEstudioContable.lvDetalle, "sp_reporteVentaContableZayasTxtTodos ", intGl_idConfigPc & "," & CInt(txtIdSucursal.Text) & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'")
        frmArchivoEstudioContable.Show()
        frmArchivoEstudioContable.BringToFront()
        frmArchivoEstudioContable.Refresh()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteLibroIVA_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.contabilidadReportesLibroIva.Enabled = True
    End Sub

    Private Sub frmReporteLibroIVA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class