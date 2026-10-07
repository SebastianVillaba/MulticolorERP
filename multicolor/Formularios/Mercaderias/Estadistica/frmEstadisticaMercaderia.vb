Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmEstadisticaMercaderia
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim deposito As New deposito
    Dim sucursal As New Sucursal
    Dim tipoProducto As New tipoProducto

    Dim intIdDeposito As Integer
    Dim intIdProducto As Integer
    Dim intIdSucursal As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo del deposito y de la sucursal
        deposito.comboDeposito(cboDeposito)
        sucursal.comboSucursal(cboSucursal)
        tipoProducto.ListarTipoVenta(cboTipoProducto)
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"

        txtCantidad.Text = 0
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'

    '-- valoracion de stock todas las sucursales
    Private Sub valoracionStockTodaSucursal()
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


            Dim rpt As New rpt_valoracionStockTodaSucursal
            Dim ofrm As New crv()

            '-- los paramentros de entrada

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
            '-- parametros de entrada
            'rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)

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

    '-- valoracion de stock por sucursal
    Private Sub valoracionStockPorSucursal()
        Try
            '-- valor del idDeposito
            intIdSucursal = cboSucursal.SelectedValue
            'MsgBox("Valor primero de intIdSucursal  " & intIdSucursal)

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
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


            Dim rpt As New rpt_valoracionStockSucursal
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idSucursalCon.Value = cboSucursal.SelectedValue

            'MsgBox("Valor de idSucursal  " & v_idSucursalCon.Value)
            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idSucursalCon)

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

    '-- valoracion de stock por deposito
    Private Sub valoracionStockPorDeposito()
        Try
            'MsgBox("Valor primero de intIdSucursal  " & intIdSucursal)

            '-- los paramentros constantes
            ' Dim pvIdDeposito As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            ' Dim v_idDeposito As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_valoracionStockDeposito
            Dim ofrm As New crv()

            'MsgBox("Valor de idSucursal  " & v_idSucursalCon.Value)
            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            'v_idDeposito.Value = cboDeposito.SelectedValue
            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)

            'pvIdDeposito.Add(v_idDeposito)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            ' rpt.DataDefinition.ParameterFields("@idDepositoCon").ApplyCurrentValues(pvIdDeposito)
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

    '-- costos menores
    Private Sub costosMenores()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_costo As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_estCostoMenor
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_costo.Value = CDbl(txtCantidad.Text)

            'MsgBox("Valor de idSucursal  " & v_idSucursalCon.Value)
            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_costo)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@costo").ApplyCurrentValues(pvParametros1)

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

    '-- costos mayores
    Private Sub costosMayores()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_costo As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_estCostoMayor
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_costo.Value = CDbl(txtCantidad.Text)

            'MsgBox("Valor de idSucursal  " & v_idSucursalCon.Value)
            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_costo)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@costo").ApplyCurrentValues(pvParametros1)

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

    '-- ranking de cantidades - todas las sucursales
    Private Sub rankingCantidadTodaSucursal()
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
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_cantidadRanking As New ParameterDiscreteValue()
            Dim v_idtipoProducto As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------

            Dim rpt As New rpt_estMercaderiaRankingCantidadT()
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_cantidadRanking.Value = CInt(txtCantidad.Text)
            v_idtipoProducto.Value = cboTipoProducto.SelectedValue

            'MsgBox("Valor de idSucursal  " & v_idSucursalCon.Value)
            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_cantidadRanking)
            pvParametros4.Add(v_idtipoProducto)

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
            rpt.DataDefinition.ParameterFields("@cantidadRanking").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idTipoProducto").ApplyCurrentValues(pvParametros4)

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

    '-- ranking de cantidades - por sucursal
    Private Sub rankingCantidadSucursal()
        Try
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

            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_cantidadRanking As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_idTipoProducto As New ParameterDiscreteValue()


            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------

            Dim rpt As New rpt_estMercaderiaRankingCantidadS()
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_cantidadRanking.Value = CInt(txtCantidad.Text)
            v_idSucursalCon.Value = cboSucursal.SelectedValue
            v_idTipoProducto.Value = cboTipoProducto.SelectedValue

            'MsgBox("Valor de idSucursal  " & v_idSucursalCon.Value)
            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_cantidadRanking)
            pvParametros4.Add(v_idSucursalCon)
            pvParametros5.Add(v_idTipoProducto)

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
            rpt.DataDefinition.ParameterFields("@cantidadRanking").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros4)
            rpt.DataDefinition.ParameterFields("@idTipoProducto").ApplyCurrentValues(pvParametros5)

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

    '-- reporte facturacion de mercaderias de uso interno
    Private Sub reporteFacturacionMercaderiaUsoInterno()
        Try
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

            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_cantidadRanking As New ParameterDiscreteValue()
            Dim v_idSucursalCon As New ParameterDiscreteValue()
            Dim v_idTipoProducto As New ParameterDiscreteValue()


            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------

            Dim rpt As New rpt_estMercaderiaRankingCantidadS()
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_cantidadRanking.Value = CInt(txtCantidad.Text)
            v_idSucursalCon.Value = cboSucursal.SelectedValue
            v_idTipoProducto.Value = cboTipoProducto.SelectedValue

            'MsgBox("Valor de idSucursal  " & v_idSucursalCon.Value)
            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)
            pvParametros3.Add(v_cantidadRanking)
            pvParametros4.Add(v_idSucursalCon)
            pvParametros5.Add(v_idTipoProducto)

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
            rpt.DataDefinition.ParameterFields("@cantidadRanking").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idSucursalCon").ApplyCurrentValues(pvParametros4)
            rpt.DataDefinition.ParameterFields("@idTipoProducto").ApplyCurrentValues(pvParametros5)

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
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Me.Enabled = False
        '-------------------------------

        '-- seleccionar la opcion
        If rdValoracionStock.Checked = True Then
            '-- valoracion de stock
            If (fun_guardarSp("sp_cargarTmpValoracionStock", intGl_idConfigPc & ",'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "','" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                MessageBox.Show("No existen datos para generar el reporte...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                valoracionStockPorDeposito()
            End If
        End If

        If rdCostoMenor.Checked = True Then
            '-- costos menores
            costosMenores()
        End If

        If rdCostoMayor.Checked = True Then
            '--costos mayores
            costosMayores()
        End If

        If rdRankingCantidad.Checked = True Then
            '- rankin de mercaderias vendidas
            '-- verificar la valides de la cantidad
            If Not IsNumeric(txtCantidad.Text) Then
                MessageBox.Show("La cantidad del Ranking no es válida para la consulta..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- procedimiento para el ranking por cantidad
            If (fun_guardarSp("sp_agregarTmpEstadisticaMercaderiaRanking", intGl_idConfigPc & "," & cboSucursal.SelectedValue & "," & CInt(txtCantidad.Text) & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'", Me.Name)) = 0 Then
                MessageBox.Show("No se pudo Actualizar la Estadística...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If chkTodaSucursal.Checked = True Then
                '-- todas las sucursales
                rankingCantidadTodaSucursal()
            Else
                '-- por sucursal
                rankingCantidadSucursal()
            End If
        End If
        '-- facturacion de mercaderias de uso interno
        If rdUsoInterno.Checked = True Then

        End If

        '-- valoracion de stock por depositos
        If rdValoracionStockDeposito.Checked = True Then
            'If (fun_guardarSp("sp_agregarTmpInventarioDeposito", intGl_idConfigPc & "," & cboDeposito.SelectedValue, Me.Name)) = 0 Then
            '    MessageBox.Show("No existe datos para realizar la consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub
            'Else
            '    valoracionStockPorDeposito()
            'End If
            valoracionStockPorDeposito()
        End If

        '------------------------------
        Me.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdCostoMayor_Click(sender As Object, e As System.EventArgs) Handles rdCostoMayor.Click
        txtCantidad.Text = 0
        txtCantidad.Focus()
    End Sub

    Private Sub rdCostoMenor_Click(sender As Object, e As System.EventArgs) Handles rdCostoMenor.Click
        txtCantidad.Text = 0
        txtCantidad.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = txtNumerico(txtCantidad, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtCantidad.Text = Format(CDec(txtCantidad.Text), "###,###,##0")
            btnConsultar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmEstadisticaMercaderia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.menuMercaderiaEstadisticas.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------

End Class