Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmEstadisticaClientes
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim sucursal As New Sucursal
    Dim tipoSucursal As New tipoSucursal
    Dim cajaSucursal As New cajaSucursal

    Dim intIdCliente As Integer
    Dim intIdSucursal As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo del deposito y de la sucursal
        sucursal.comboSucursal(cboSucursal)
        tipoSucursal.comboTipoSucursal(cboTipoSucursal)
        cajaSucursal.comboCajaSucursal(cboCajaSucursal, 1)
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss "
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss "

        txtCantidad.Text = 0
        lblIdCliente.Text = 0
        lblCliente.Text = ""
        lblRuc.Text = 0
        lblIdLaboratorio.Text = 0
        lblLaboratorio.Text = ""
        lblIdProd.Text = 0
        lblProducto.Text = ""
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- reporte por hora y sucursal
    Private Sub reporteHoraSucursal()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estClienteHoraSucursal
            Dim ofrm As New crv()

            'MsgBox("Antes de asignar los valores a las variables")

            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_idSucursalCon.Value = cboSucursal.SelectedValue

            'MsgBox("Despues de asignar los valores a las variables")

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros

            pvParametros1.Add(v_idSucursalCon)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            'MsgBox("Despues de añadir los parametros")

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

            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
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

    '-- reporte por dia y sucursal
    Private Sub reporteDiaSucursal()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estClienteDiaSucursal
            Dim ofrm As New crv()

            'MsgBox("Antes de asignar los valores a las variables")

            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_idSucursalCon.Value = cboSucursal.SelectedValue

            'MsgBox("Despues de asignar los valores a las variables")

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros

            pvParametros1.Add(v_idSucursalCon)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            'MsgBox("Despues de añadir los parametros")

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

            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
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

    '-- reporte por hora y todas las sucursales
    Private Sub reporteHoraTodaSucursal()
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
            Dim rpt As New rpt_estClienteHora
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
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte por dia y todas las sucursales
    Private Sub reporteDiaTodaSucursal()
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
            Dim rpt As New rpt_estClienteDia
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
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de ranking de vendedores
    Private Sub reporteRankingVendedorResumen()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()


            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estRankingVendedor
            Dim ofrm As New crv()

            v_idSucursalCon.Value = intIdSucursal
            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idSucursalCon)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@idSucursalcon").ApplyCurrentValues(pvParametros1)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de ranking de clientes
    Private Sub reporteRankingClientesResumen()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()


            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estRankingCliente
            Dim ofrm As New crv()

            v_idSucursalCon.Value = intIdSucursal
            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idSucursalCon)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@idSucursalcon").ApplyCurrentValues(pvParametros1)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de ventas por division
    Private Sub reporteVentaDivision()
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
            Dim rpt As New rpt_estVentaDivision
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

            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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

    '-- reporte de estadisticas de promocion de delivery de amandau
    Private Sub reportePromoDeliveryAmandau()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()


            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estPromoDelivery
            Dim ofrm As New crv()

            v_idSucursalCon.Value = intIdSucursal
            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idSucursalCon)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@idSucursalcon").ApplyCurrentValues(pvParametros1)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de ranking de prodcutos
    Private Sub reporteRankingProductoOtro()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()


            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_ranking As New ParameterDiscreteValue()
            Dim v_idTipoProducto As New ParameterDiscreteValue()
            Dim v_fraccionado As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estRankingMercaderia
            Dim ofrm As New crv()

            v_ranking.Value = CInt(txtCantidad.Text)
            v_idTipoProducto.Value = CInt(lblIdTipoProducto.Text)
            v_fraccionado.Value = chkFraccionado.Checked

            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_ranking)
            pvParametros2.Add(v_idTipoProducto)
            pvParametros3.Add(v_fraccionado)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@ranking").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idTipoProducto").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@fraccionado").ApplyCurrentValues(pvParametros3)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de vendedores por laboratorio
    Private Sub reporteVendedorLaboratorio()
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
            Dim rpt As New rpt_estClienteVendedorLaboratorio
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

            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de recibos de vendedores por laboratorio 
    Private Sub reporteVendedorLaboratorioRecibo()
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
            Dim rpt As New rpt_estClienteVendedorLaboratorioRec
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

            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de ranking de prodcutos
    Private Sub reporteRankingProductoLaboratorio()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()


            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_ranking As New ParameterDiscreteValue()
            Dim v_idLaboratorio As New ParameterDiscreteValue()
            Dim v_fraccionado As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estRankingMercaderiaLabo
            Dim ofrm As New crv()

            v_ranking.Value = CInt(txtCantidad.Text)
            v_idLaboratorio.Value = CInt(lblIdLaboratorio.Text)
            v_fraccionado.Value = chkFraccionado.Checked

            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_ranking)
            pvParametros2.Add(v_idLaboratorio)
            pvParametros3.Add(v_fraccionado)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@ranking").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@fraccionado").ApplyCurrentValues(pvParametros3)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de mercaderias sin movimiento
    Private Sub reporteMercaderiaSinMovimiento()
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
            Dim rpt As New rpt_estClienteSinMovimiento
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

    '-- reporte de recibos de entregas
    Private Sub reporteReciboEntrega()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estReciboEntrega
            Dim ofrm As New crv()

            'MsgBox("Antes de asignar los valores a las variables")

            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_idSucursalCon.Value = cboSucursal.SelectedValue

            'MsgBox("Despues de asignar los valores a las variables")

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros

            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_idSucursalCon)

            'MsgBox("Despues de añadir los parametros")

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

            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de clientes sin fecha de nacimiento
    Private Sub reporteClienteSinFechaNac()
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
            Dim rpt As New rpt_estClienteSinFechaNac
            Dim ofrm As New crv()

            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

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

            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de utilidad en farmacia
    Private Sub reporteUtilidadFarmacia()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()


            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estClienteUtilFarmacia
            Dim ofrm As New crv()

            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de venta por cliente
    Private Sub reporteVentaCliente()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()
            Dim pvParametros5 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_idCliente As New ParameterDiscreteValue()
            Dim v_idTipoSucursal As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estVentaCliente
            Dim ofrm As New crv()

            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            v_idSucursalCon.Value = intIdSucursal
            v_idCliente.Value = lblIdCliente.Text
            v_idTipoSucursal.Value = cboTipoSucursal.SelectedValue
            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_idSucursalCon)
            pvParametros4.Add(v_idCliente)
            pvParametros5.Add(v_idTipoSucursal)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idCliente").ApplyCurrentValues(pvParametros4)
            rpt.DataDefinition.ParameterFields("@idTipoSucursal").ApplyCurrentValues(pvParametros5)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de datos por cliente
    Private Sub reporteDatosCliente()
        Try

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            '-- instaciar el parametro

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estClienteDatos
            Dim ofrm As New crv()

            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            'pvParametros2.Add(v_hasta)

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

            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de precios y costos de sucursales
    Private Sub reportePrecioCostoSucursal()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estClienteCostoPrecio
            Dim ofrm As New crv()

            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte de ranking de productos
    Private Sub reporteRankingProducto()
        Try

            Dim pvParametros1 As New ParameterValues()


            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_ranking As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estRankingMercaderia
            Dim ofrm As New crv()

            v_ranking.Value = CInt(txtCantidad.Text)

            'v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_ranking)
            'pvParametros2.Add(v_hasta)

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

            rpt.DataDefinition.ParameterFields("@ranking").ApplyCurrentValues(pvParametros1)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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

    '-- reporte facturacion automotive
    Private Sub reporteFacturacionAutomoive()
        Try

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_estClienteAutomotive
            Dim ofrm As New crv()

            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

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
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
            'rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
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
        '------------------------------rd

        '-- la variable de la sucursal
        If chkTodaSucursal.Checked = True Then
            '-- todas las sucursales
            intIdSucursal = 0
        Else
            intIdSucursal = cboSucursal.SelectedValue
        End If

        '-- seleccionar la opcion
        If rdHoraVenta.Checked = True Then
            '-- horas de venta
            If chkTodaSucursal.Checked = True Then
                '-- todas las sucursales
                '-- el procedimiento de insercion
                If (fun_guardarSp("sp_insTmpEstadisticaVtaHora", intGl_idConfigPc & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                        "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'" & "," & 0, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                '----------------------------------------------------------------------------------------------------------------
                reporteHoraTodaSucursal()
            Else
                '-- por sucursal
                '-- el procedimiento de insercion
                If (fun_guardarSp("sp_insTmpEstadisticaVtaHora", intGl_idConfigPc & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                        "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'" & "," & cboSucursal.SelectedValue, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                '----------------------------------------------------------------------------------------------------------------
                reporteHoraSucursal()
            End If
        End If

        If rdDiaVenta.Checked = True Then
            '-- dias de venta
            If chkTodaSucursal.Checked = True Then
                '-- todas las sucursales
                '-- el procedimiento de insercion
                If (fun_guardarSp("sp_insTmpEstadisticaVtaDia", intGl_idConfigPc & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                        "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'" & "," & 0, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                '----------------------------------------------------------------------------------------------------------------
                reporteDiaTodaSucursal()
            Else
                '-- por sucursal
                '-- el procedimiento de insercion
                If (fun_guardarSp("sp_insTmpEstadisticaVtaDia", intGl_idConfigPc & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                        "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'" & "," & cboSucursal.SelectedValue, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Guardar la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                '----------------------------------------------------------------------------------------------------------------
                reporteDiaSucursal()
            End If
        End If

        If rdFormaVenta.Checked = True Then
            '-- formas de venta
            If chkTodaSucursal.Checked = True Then
                '-- todas las sucursales

            Else
                '-- por sucursal

            End If
        End If

        If rdRankingVendedor.Checked = True Then
            '-- hacer correr el procedimiento almacenado de la base de datos
            If (fun_guardarSp("sp_agregarTmpRankingVendedor", intGl_idConfigPc & "," & intIdSucursal & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                    "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                reporteRankingVendedorResumen()
            End If
        End If

        If rdClienteLaboratorio.Checked = True Then
            '-- rankin de clientes
            '-- hacer correr el procedimiento almacenado de la base de datos
            If (fun_guardarSp("sp_agregarTmpRankingCliente", intGl_idConfigPc & "," & intIdSucursal & "," & CInt(lblIdLaboratorio.Text) & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                    "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                reporteRankingClientesResumen()
            End If
        End If
        '-------------------------------------------------'
        '-- PRODUCTOS MAS VENDIDOS POR TIPO DE PRODUCTO --'
        '-------------------------------------------------'
        If rdProductoVendido.Checked = True Then
            '-- hacer correr el procedimiento almacenado de la base de datos
            If (fun_guardarSp("sp_agregarTmpRankingProducto", intGl_idConfigPc & "," & cboTipoSucursal.SelectedValue & "," & intIdSucursal & ",'" & _
                              FormatoFechaSoloDatePicker(dtpDesdeFecha) & "','" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                reporteRankingProducto()
            End If
        End If
        '--------------------------------'
        '-- VENDEDORES POR LABORATORIO --'
        '--------------------------------'
        If rdVendedorLaboratorio.Checked = True Then
            '-- hacer correr el procedimiento almacenado de la base de datos
            If (fun_guardarSp("sp_agregarTmpEstadisticaVendedorLaboratorio", intGl_idConfigPc & "," & intIdSucursal & "," & CInt(lblIdLaboratorio.Text) & "," & "'" & _
                              FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'" & "," & txtCantidad.Text, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                reporteVendedorLaboratorio()
                '-- la impreion de los recibos
                reporteVendedorLaboratorioRecibo()
            End If
        End If
        '--------------------------------------------'
        '-- PRODUCTOS MAS VENDIDOS POR LABORATORIO --'
        '--------------------------------------------'
        If rdProductoVendidoLabo.Checked = True Then
            '-- hacer correr el procedimiento almacenado de la base de datos
            If (fun_guardarSp("sp_agregarTmpRankingProducto", intGl_idConfigPc & "," & cboTipoSucursal.SelectedValue & "," & intIdSucursal & ",'" & _
                              FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                reporteRankingProductoLaboratorio()
            End If
        End If

        If rdSinMovimiento.Checked = True Then
            '--------------------'
            '-- SIN MOVIMIENTO --'
            '--------------------'
            '-- el procedimiento de insercion
            If (fun_guardarSp("sp_cargarTmpEstadisticaMercaderiaSinMovimiento", intGl_idConfigPc & "," & "'" & dtpDesdeFecha.Text & "'" & _
                                    "," & "'" & dtpHastaFecha.Text & "'" & "," & intIdSucursal, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                reporteMercaderiaSinMovimiento()
            End If
            '----------------------------------------------------------------------------------------------------------------
        End If
        If rdClienteSinFechaNac.Checked = True Then
            '---------------------------------------'
            '-- CLIENTES SIN FECHA DE NACIMIENTO  --'
            '---------------------------------------'
            reporteClienteSinFechaNac()
        End If

        If rdPorcentajeUtilidadFarmacia.Checked = True Then
            '--------------------------------------------'
            '-- PORCENTYAJE DE UTILIDAD DE LA FARMACIA --'
            '--------------------------------------------'
            reporteUtilidadFarmacia()
        End If

        If rdPorCliente.Checked = True Then
            '-----------------'
            '-- POR CLIENTE --'
            '-----------------'
            If chkTodaSucursal.Checked = True Then
                '-- todas las sucursales
                intIdSucursal = 0
            Else
                intIdSucursal = cboSucursal.SelectedValue
            End If

            reporteVentaCliente()
        End If

        If rdDatosCliente.Checked = True Then
            '-----------------------'
            '-- DATOS DEL CLIENTE --'
            '-----------------------'
            reporteDatosCliente()
        End If

        If rdCostoPrecioTotal.Checked = True Then
            '--------------------------------------'
            '-- PRECIOS Y COSTOS DE SUCURSALES --'
            '--------------------------------------'
            reportePrecioCostoSucursal()
        End If

        If rdRankingProducto.Checked = True Then
            '-- ranking de productos mas vendidos
            If (fun_guardarSp("sp_agregarTmpRankingProducto", intGl_idConfigPc & "," & cboTipoSucursal.SelectedValue & "," & intIdSucursal & "," & _
                              "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'," & _
                              chkFraccionado.Checked, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                reporteRankingProducto()
            End If
        End If

        If rdArchivoCorreo.Checked = True Then
            '-- generar archivo de correo
            '-- mostrar el detalle
            Me.Enabled = False
            '-- colcar el nombre del archivo
            frmArchivoCorreoCliente.Show()
            frmArchivoCorreoCliente.BringToFront()
        End If

        If rdFacturaAutomotive.Checked = True Then
            '-- facturacion de automotive
            Me.Enabled = False
            reporteFacturacionAutomoive()
        End If

        Me.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdHoraVenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdHoraVenta.Click
        grVendedor.Visible = False
    End Sub

    Private Sub rdDiaVenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDiaVenta.Click
        grVendedor.Visible = False
    End Sub

    Private Sub rdFormaVenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdFormaVenta.Click
        grVendedor.Visible = False
    End Sub

    Private Sub rdRankingVendedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdRankingVendedor.Click
        grVendedor.Visible = True
    End Sub

    Private Sub rdClienteLaboratorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdClienteLaboratorio.Click
        grVendedor.Visible = False

        banGl_estadisticaCliente = True
        Me.Enabled = False
        frmBuscarLaboratorio.txtBuscar.Text = ""
        frmBuscarLaboratorio.txtIdLaboratorio.Text = 0
        frmBuscarLaboratorio.Show()
        frmBuscarLaboratorio.BringToFront()
    End Sub

    Private Sub rdClienteMaxipunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' lblIdCliente.Text = 0
        'lblCliente.Text = ""
        'lblRuc.Text = 0
        grVendedor.Visible = False

        banGl_estadisticaCliente = True
        Me.Enabled = False
        frmBuscarClienteVenta.txtBuscar.Text = ""
        frmBuscarClienteVenta.txtIdCliente.Text = 0
        frmBuscarClienteVenta.Show()
        frmBuscarClienteVenta.BringToFront()
    End Sub

    Private Sub rdPorCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPorCliente.Click
        ' lblIdCliente.Text = 0
        'lblCliente.Text = ""
        'lblRuc.Text = 0
        grVendedor.Visible = False

        banGl_estadisticaCliente = True
        Me.Enabled = False
        frmBuscarClienteVenta.txtBuscar.Text = ""
        frmBuscarClienteVenta.txtIdCliente.Text = 0
        frmBuscarClienteVenta.Show()
        frmBuscarClienteVenta.BringToFront()
    End Sub

    Private Sub rdProductoVendido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdProductoVendido.Click
        lblIdTipoProducto.Text = 0
        lblTipoproducto.Text = ""
        grVendedor.Visible = False
        grTipoProducto.Visible = True

        banGl_estadisticaCliente = True
        Me.Enabled = False
        frmBuscarTipoProducto.txtBuscar.Text = ""
        frmBuscarTipoProducto.txtId.Text = 0
        frmBuscarTipoProducto.Show()
        frmBuscarTipoProducto.BringToFront()

    End Sub

    Private Sub rdVendedorlaborarorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVendedorLaboratorio.Click
        grVendedor.Visible = False

        banGl_estadisticaCliente = True
        Me.Enabled = False
        frmBuscarLaboratorio.txtBuscar.Text = ""
        frmBuscarLaboratorio.txtIdLaboratorio.Text = 0
        frmBuscarLaboratorio.Show()
        frmBuscarLaboratorio.BringToFront()
    End Sub

    Private Sub rdProductoVendidoLaboratorio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdProductoVendidoLabo.Click
        lblIdLaboratorio.Text = 0
        lblLaboratorio.Text = ""
        grVendedor.Visible = False
        grTipoProducto.Visible = False
        grLabratorio.Visible = True

        banGl_estadisticaCliente = True
        Me.Enabled = False
        frmBuscarLaboratorio.txtBuscar.Text = ""
        frmBuscarLaboratorio.txtIdLaboratorio.Text = 0
        frmBuscarLaboratorio.Show()
        frmBuscarLaboratorio.BringToFront()

    End Sub

    Private Sub rdDetalleRemision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdDetalleRemision.Click
        grVendedor.Visible = True
    End Sub
    '----------------------------------------------------------------------------------------------------
    '***********'
    '-- COMBO --'
    '***********'
    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        cajaSucursal.comboCajaSucursal(cboCajaSucursal, cboSucursal.SelectedValue)
    End Sub
    '------------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmEstadisticaCientes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.ClienteEstadisticas.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------

End Class