Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteVenta
    Dim intOpcion As Integer

    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim sucursal As New Sucursal
    Dim laboratorio As New laboratorio
    Dim tipoProducto As New tipoProducto
    Dim tipoSucursal As New tipoSucursal

    Dim intIdSucursal As Integer
    Dim intIdLaboratorio As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss "
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss "
        '-- valor para el combo de la sucursal y el laboratorio
        sucursal.comboSucursal(cboSucursal)
        laboratorio.ListarLaboratorio(cboLaboratorio)
        tipoProducto.ListarTipoVenta(cboTipoProducto)
        tipoSucursal.comboTipoSucursal(cboTipoSucursal)
        txtPorcentaje.Text = 0
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- la opcion del resumen por fecha
    Private Sub imprimirVentaResumidoFecha()
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
            v_idSucursalCon.Value = cboSucursal.SelectedValue
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

    '-- la opcion del detallado por fecha
    Private Sub imprimirVentaDetalladoFecha()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            Dim pvIdDeposito As New ParameterValues()

            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            Dim v_idDeposito As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_ventaDetalladoFecha
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            v_idSucursalCon.Value = cboSucursal.SelectedValue

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            v_idDeposito.Value = sp_datosTabla.consulta_valor("select idDepositoVenta from configPc where idConfig=" & intGl_idConfigPc)

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_idSucursalCon)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            pvIdDeposito.Add(v_idDeposito)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros3)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvIdDeposito)

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

    '-- la opcion del detallado por fecha
    Private Sub imprimirVentaDetalladoFechaSinTotal()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            Dim pvIdDeposito As New ParameterValues()

            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            Dim v_idDeposito As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_ventaDetalladoFechaSinTotal
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            v_idSucursalCon.Value = cboSucursal.SelectedValue

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            v_idDeposito.Value = sp_datosTabla.consulta_valor("select idDepositoVenta from configPc where idConfig=" & intGl_idConfigPc)

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_idSucursalCon)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            pvIdDeposito.Add(v_idDeposito)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros3)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvIdDeposito)

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

    '-- la opcion del detallado por fecha
    Private Sub imprimirVentaAnuladoFecha()
        Try
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
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_ventaAnuladoFecha
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            v_idSucursalCon.Value = cboSucursal.SelectedValue

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_idSucursalCon)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- la opcion del resumen por movimiento
    Private Sub imprimirVentaResumidoMovimiento()
        Try
            Me.Enabled = False

            '-- dar valor a la variable de la sucursal
            intIdSucursal = cboSucursal.SelectedValue

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()
            Dim pvParametros5 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            Dim pvIdDeposito As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idmovIni1 As New ParameterDiscreteValue()
            Dim v_idmovFin1 As New ParameterDiscreteValue()
            Dim v_idmovIni2 As New ParameterDiscreteValue()
            Dim v_idmovFin2 As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------

            '-- nombre del reporte
            Dim rpt As New rpt_ventaResumidoMov
            '-------------------------------------
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idmovIni1.Value = txtIdmovIni1.Text
            v_idmovFin1.Value = txtIdmovFin1.Text
            v_idmovIni2.Value = txtIdmovIni2.Text
            v_idmovFin2.Value = txtIdMovFin2.Text
            v_idSucursalCon.Value = intIdSucursal


            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            '-- por movimientos
            pvParametros1.Add(v_idmovIni1)
            pvParametros2.Add(v_idmovFin1)
            pvParametros3.Add(v_idmovIni2)
            pvParametros4.Add(v_idmovFin2)
            pvParametros5.Add(v_idSucursalCon)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            '-- por movimientos
            rpt.DataDefinition.ParameterFields("@idMovIni1").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idMovFin1").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@idMovIni2").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idMovFin2").ApplyCurrentValues(pvParametros4)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros5)

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

    '-- la opcion del detallado por movimiento
    Private Sub imprimirVentaDetalladoMovimiento()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idmovIni1 As New ParameterDiscreteValue()
            Dim v_idmovFin1 As New ParameterDiscreteValue()
            Dim v_idmovIni2 As New ParameterDiscreteValue()
            Dim v_idmovFin2 As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------

            '-- nombre del reporte
            Dim rpt As New rpt_ventaDetalladoMov
            '-------------------------------------
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idmovIni1.Value = txtIdmovIni1.Text
            v_idmovFin1.Value = txtIdmovFin1.Text
            v_idmovIni2.Value = txtIdmovIni2.Text
            v_idmovFin2.Value = txtIdMovFin2.Text


            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            '-- por movimientos
            pvParametros1.Add(v_idmovIni1)
            pvParametros2.Add(v_idmovFin1)
            pvParametros3.Add(v_idmovIni2)
            pvParametros4.Add(v_idmovFin2)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            '-- por movimientos
            rpt.DataDefinition.ParameterFields("@idMovIni1").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idMovFin1").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@idMovIni2").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idMovFin2").ApplyCurrentValues(pvParametros4)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- la opcion del anulado por movimiento
    Private Sub imprimirVentaAnuladoMovimiento()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            Dim pvIdDeposito As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idmovIni1 As New ParameterDiscreteValue()
            Dim v_idmovFin1 As New ParameterDiscreteValue()
            Dim v_idmovIni2 As New ParameterDiscreteValue()
            Dim v_idmovFin2 As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            Dim v_idDeposito As New ParameterDiscreteValue()
            '------------------------------------

            '-- nombre del reporte
            Dim rpt As New rpt_ventaAnuladoMov
            '-------------------------------------
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idmovIni1.Value = txtIdmovIni1.Text
            v_idmovFin1.Value = txtIdmovFin1.Text
            v_idmovIni2.Value = txtIdmovIni2.Text
            v_idmovFin2.Value = txtIdMovFin2.Text


            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            v_idDeposito.Value = sp_datosTabla.consulta_valor("select idDepositoVenta from configPc where idConfig=" & intGl_idConfigPc)

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            '-- por movimientos
            pvParametros1.Add(v_idmovIni1)
            pvParametros2.Add(v_idmovFin1)
            pvParametros3.Add(v_idmovIni2)
            pvParametros4.Add(v_idmovFin2)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            pvIdDeposito.Add(v_idDeposito)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            '-- por movimientos
            rpt.DataDefinition.ParameterFields("@idMovIni1").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idMovFin1").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@idMovIni2").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idMovFin2").ApplyCurrentValues(pvParametros4)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvIdDeposito)

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

    '-- la opcion del detallado por laboratorio
    Private Sub imprimirVentaLaboratorioDetallado()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
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


            Dim rpt As New rpt_ventaDetalladoLabo
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- la opcion del detallado por laboratorio
    Private Sub imprimirVentaLaboratorioDetalladoSinFecha()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
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


            Dim rpt As New rpt_ventaDetalladoLaboSinFecha
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub


    '-- la opcion del detallado por Tipo de Productos
    Private Sub imprimirVentaLaboratorioDetalladoSinTotal()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
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


            Dim rpt As New rpt_ventaDetalladoLaboSinTotal
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- venta de cantidades por tipo de producto por sucursal
    Private Sub imprimirVentaTipoProducto()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
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


            Dim rpt As New rpt_ventaDetalladoTipoProd
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- venta de cantidades por tipo de producto de todas las sucursales
    Private Sub imprimirVentaTipoProductoTodaSucursal()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
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


            Dim rpt As New rpt_ventaDetalladoTipoProdTodo
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros2)

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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- venta de poha roga a la sa
    Private Sub imprimirVentaPohaRoga()
        Try
            '-- los paramentros constantes
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


            Dim rpt As New rpt_facturaDetalle
            Dim ofrm As New crv()


            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- paramentros constantes
            'rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            'rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            'rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            'rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

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

    '-- impresion de ticket de heladeria
    Public Sub imprimirTicketHeladeria(ByVal codigoVenta As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()

        Dim rpt As New rpt_ticket
        Dim ofrm As New crv()
        '-- instanciar el parametro
        Dim v_idVenta As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        'asiganar el valor a los  parametros
        v_idVenta.Value = codigoVenta
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc

        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idVenta)

        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)

        'MsgBox("Valor de idPersonaJur " & v_idPersonaJur.Value)

        rpt.DataDefinition.ParameterFields("@idVenta").ApplyCurrentValues(pvParametros)

        rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- para imprimir directamente
        rpt.PrintToPrinter(1, False, 0, 0)

        '-- mostrar el reporte
        'ofrm.WindowState = FormWindowState.Maximized
        'ofrm.Visible = True
        'ofrm.BringToFront()
        'ofrm.Show()
    End Sub

    '-- ventas de cantidad a laboratorio
    Private Sub imprimirVentaCantidadLaboratorio()
        Try
            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim v_parametro1 As New ParameterValues()
            Dim v_parametro2 As New ParameterValues()
            Dim v_parametro3 As New ParameterValues()
            Dim v_parametro4 As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_idLaboratorio As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_ventaCantidadLabo
            Dim ofrm As New crv()

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            v_idSucursalCon.Value = intIdSucursal
            v_idLaboratorio.Value = cboLaboratorio.SelectedValue

            ' añadir el parámetro a la colección de parámetros

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            v_parametro1.Add(v_desde)
            v_parametro2.Add(v_hasta)
            v_parametro3.Add(v_idSucursalCon)
            v_parametro4.Add(v_idLaboratorio)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(v_parametro1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(v_parametro2)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(v_parametro3)
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(v_parametro4)
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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- ventas de cantidad de productos vendidos
    Private Sub imprimirVentaCantidadProducto()
        Try
            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim v_parametro1 As New ParameterValues()
            Dim v_parametro2 As New ParameterValues()
            Dim v_parametro3 As New ParameterValues()


            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_ventaCantidadProd
            Dim ofrm As New crv()

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            v_idSucursalCon.Value = intIdSucursal

            ' añadir el parámetro a la colección de parámetros

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            v_parametro1.Add(v_desde)
            v_parametro2.Add(v_hasta)
            v_parametro3.Add(v_idSucursalCon)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)

            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(v_parametro1)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(v_parametro2)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(v_parametro3)
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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- venta de mercaderias con fecha corta
    Private Sub imprimirVentaMercaFechaCorta()
        Try
            Me.Enabled = False

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_idLaboratorio As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_ventaMercaFechaCorta
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idSucursalCon.Value = intIdSucursal
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text
            v_idLaboratorio.Value = cboLaboratorio.SelectedValue

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
            pvParametros4.Add(v_idLaboratorio)

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
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros4)

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

    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        '-- seleccionar la opcion
        '---------------'
        '-- por fecha --'
        '---------------'
        If rdPorFecha.Checked = True Then
            If rdResumen.Checked = True Then
                Me.Enabled = False
                '-- resumido por fecha
                imprimirVentaResumidoFecha()
                Me.Enabled = True
            End If
            If rdDetalle.Checked = True Then
                '-- detallado por fecha
                Me.Enabled = False
                imprimirVentaDetalladoFecha()
                Me.Enabled = True
            End If
            If rdDetalleSinTotal.Checked = True Then
                '-- detallado por fecha sin el total
                Me.Enabled = False
                imprimirVentaDetalladoFechaSinTotal()
                Me.Enabled = True
            End If
            If rdAnulado.Checked = True Then
                '-- anualdo por fecha
                Me.Enabled = False
                imprimirVentaAnuladoFecha()
                Me.Enabled = True
            End If
            If rdLaboratorio.Checked = True Then
                'Me.Enabled = False
                If chkTodoSucursal.Checked = True Then
                    intIdSucursal = 0
                Else
                    intIdSucursal = cboSucursal.SelectedValue
                End If
                ' MsgBox("Antes de cargar")
                '-- el procedimiento
                If (fun_guardarSp("sp_agregarTmpVentaLaboratorio", intGl_idConfigPc & "," & intIdSucursal & "," & cboLaboratorio.SelectedValue & "," & "'" & _
                                  FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Enabled = True
                Else
                    'MsgBox("Antes de imprimir")
                    Me.Enabled = True
                    imprimirVentaLaboratorioDetallado()
                    'MsgBox("Despues de imprimir")
                End If
            End If

            If rdLaboratorioSinTotal.Checked = True Then
                Me.Enabled = False
                If chkTodoSucursal.Checked = True Then
                    intIdSucursal = 0
                Else
                    intIdSucursal = cboSucursal.SelectedValue
                End If
                '-- el procedimiento
                If (fun_guardarSp("sp_agregarTmpVentaLaboratorio", intGl_idConfigPc & "," & intIdSucursal & "," & cboLaboratorio.SelectedValue & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'", Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Enabled = True
                Else
                    Me.Enabled = True
                    imprimirVentaLaboratorioDetalladoSinTotal()
                End If
            End If

            If rdLaboratorioSinFecha.Checked = True Then
                '-- laboratorio sin fecha
                If (fun_guardarSp("sp_agregarTmpVentaLaboratorio", intGl_idConfigPc & "," & intIdSucursal & "," & cboLaboratorio.SelectedValue & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'", Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Enabled = True
                Else
                    Me.Enabled = True
                    imprimirVentaLaboratorioDetalladoSinFecha()
                End If
            End If

            If rdCantidadTipoProducto.Checked = True Then
                Me.Enabled = False
                If chkTodoSucursal.Checked = True Then
                    '-- todas las sucursales
                    '-- el procedimiento
                    If (fun_guardarSp("sp_agregarTmpVentaTipoProductoTodo", intGl_idConfigPc & "," & cboSucursal.SelectedValue & "," & cboTipoProducto.SelectedValue & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'", Me.Name)) = 0 Then
                        '-- no se guardo los registros
                        MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Enabled = True
                    Else
                        Me.Enabled = True
                        imprimirVentaTipoProductoTodaSucursal()
                    End If
                Else
                    '-- por sucursal
                    '-- el procedimiento
                    If (fun_guardarSp("sp_agregarTmpVentaTipoProducto", intGl_idConfigPc & "," & cboSucursal.SelectedValue & "," & cboTipoProducto.SelectedValue & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'", Me.Name)) = 0 Then
                        '-- no se guardo los registros
                        MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Enabled = True
                    Else
                        Me.Enabled = True
                        imprimirVentaTipoProducto()
                    End If
                End If
            End If

            If rdCantidadVentaLaboratorio.Checked = True Then
                '-----------------------------------------'
                '--  CANTIDAD DE VENTAS POR LABORATORIO --'
                '-----------------------------------------'
                Me.Enabled = False
                If chkTodoSucursal.Checked = True Then
                    intIdSucursal = 0
                Else
                    intIdSucursal = cboSucursal.SelectedValue
                End If

                imprimirVentaCantidadLaboratorio()
                Me.Enabled = True
            End If

            If rdCantidadProducto.Checked = True Then
                '--------------------------'
                '-- cantidad de producto --'
                '--------------------------'
                Me.Enabled = False

                If (fun_guardarSp("sp_cargarTmpTotalVentaCantidad", intGl_idConfigPc & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'" & "," & cboTipoSucursal.SelectedValue, Me.Name)) = 0 Then
                    '-- no se guardo los registros
                    MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Enabled = True
                Else
                    Me.Enabled = True
                    imprimirVentaCantidadProducto()
                End If
            End If

        End If
        '----------------------------------'
        '-- resumen por tipo de producto --'
        '----------------------------------'
        If rdVentaResumenTipoProducto.Checked = True Then
            '-- el procedimiento
            If (fun_guardarSp("sp_agregarTmpVentaTipoProductoTodo", intGl_idConfigPc & "," & cboSucursal.SelectedValue & "," & cboTipoProducto.SelectedValue & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Agregar los Registros para la Impresión...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Enabled = True
            Else
                Me.Enabled = True
                imprimirVentaTipoProductoTodaSucursal()
            End If
        End If

        '--------------------'
        '-- por movimiento --'
        '--------------------'
        If rdPorMovimiento.Checked = True Then
            If rdResumen.Checked = True Then
                '-- imprimir resumido por movimiento
                Me.Enabled = False
                imprimirVentaResumidoMovimiento()
                Me.Enabled = True
            End If
            If rdDetalle.Checked = True Then
                '-- imprimir detallado por movimiento
                Me.Enabled = False
                imprimirVentaDetalladoMovimiento()
                Me.Enabled = True
            End If
            If rdAnulado.Checked = True Then
                '-- imprimir anulado por movimiento
                Me.Enabled = False
                imprimirVentaAnuladoMovimiento()
                Me.Enabled = True
            End If
        End If
        If rdDatosCliente.Checked = True Then
            '-----------------------'
            '-- DATOS DEL CLIENTE --'
            '-----------------------'
            Me.Enabled = False
            reporteDatosCliente()
            Me.Enabled = True
        End If

    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtIdmovIni1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdmovIni1.KeyPress
        e.Handled = txtNumerico(txtIdmovIni1, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtIdmovIni1.Text = Format(CDec(txtIdmovIni1.Text), "###,###,##0")
        End If
    End Sub

    Private Sub txtIdmovFin1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdmovFin1.KeyPress
        e.Handled = txtNumerico(txtIdmovFin1, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtIdmovFin1.Text = Format(CDec(txtIdmovFin1.Text), "###,###,##0")
        End If
    End Sub

    Private Sub txtIdmovIni2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdmovIni2.KeyPress
        e.Handled = txtNumerico(txtIdmovIni2, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtIdmovIni2.Text = Format(CDec(txtIdmovIni2.Text), "###,###,##0")
        End If
    End Sub

    Private Sub txtIdmovFin2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdMovFin2.KeyPress
        e.Handled = txtNumerico(txtIdMovFin2, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            'e.Handled = True
            'SendKeys.Send("{tab}")
            txtIdMovFin2.Text = Format(CDec(txtIdMovFin2.Text), "###,###,##0")
            btnConsultar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdPorFecha_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdPorFecha.CheckedChanged
        If rdPorFecha.Checked = True Then
            grFechaHora.Enabled = True
            grMovimiento.Enabled = False

            dtpDesdeFecha.Focus()
        End If
    End Sub

    Private Sub rdPorMovimiento_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdPorMovimiento.CheckedChanged
        If rdPorMovimiento.Checked = True Then
            grFechaHora.Enabled = False
            grMovimiento.Enabled = True

            txtIdmovFin1.Text = 0
            txtIdMovFin2.Text = 0
            txtIdmovIni1.Text = 0
            txtIdmovIni2.Text = 0

            txtIdmovIni1.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteVenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.clienteReportesVenta.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------
End Class