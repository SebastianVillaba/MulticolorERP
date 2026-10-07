Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmEstadisticaProveedor
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdProveedor As Integer
    Dim intIdLaboratorio As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo del deposito y de la sucursal
        'deposito.comboDeposito(cboDeposito)
        'sucursal.comboSucursal(cboSucursal)
        'tipoProducto.ListarTipoVenta(cboTipoProducto)
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"

        lblProveedor.Text = ""
        lblIdProveedor.Text = 0
        lblLaboratorio.Text = ""
        lblIdLaboratorio.Text = 0
        lblProducto.Text = ""
        lblCodigo.Text = 0
        lblIdProducto.Text = 0

    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'

    '-- valoracion de stock todas las sucursales
    Private Sub porcentajeProveedorProducto()
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
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            '------------------------------------
            '-- instaciar el parametro
            Dim v_idProveedor As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()


            Dim rpt As New rpt_estProveedorPorcentajeProducto
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idProveedor.Value = CDbl(lblIdProveedor.Text)
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

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
            '-- paramentros de entrada
            pvParametros1.Add(v_idProveedor)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idProveedor").ApplyCurrentValues(pvParametros1)
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

    '-- porcentaje por producto
    Private Sub porcentajePorProducto()
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
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            '------------------------------------
            '-- instaciar el parametro
            Dim v_idProducto As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()


            Dim rpt As New rpt_estProveedorProducto
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idProducto.Value = CDbl(lblIdProducto.Text)
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

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
            '-- paramentros de entrada
            pvParametros1.Add(v_idProducto)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idProducto").ApplyCurrentValues(pvParametros1)
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

    '-- porcentaje de costos de todos los productos por laboratorio
    Private Sub porcentajeCostoLaboratorio()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

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
            '-- instaciar el parametro
            Dim v_idLaboratorio As New ParameterDiscreteValue()

            Dim rpt As New rpt_estProveedorPorcentajeCosto
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idLaboratorio.Value = CDbl(lblIdLaboratorio.Text)

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
            '-- paramentros de entrada
            pvParametros1.Add(v_idLaboratorio)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros1)

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

    '-- porcentaje bajos de los productos por laboratorio
    Private Sub porcentajeBajoCostoProducto()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

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
            '-- instaciar el parametro
            Dim v_idLaboratorio As New ParameterDiscreteValue()

            Dim rpt As New rpt_estProveedorPorcentajeMenor
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idLaboratorio.Value = CDbl(lblIdLaboratorio.Text)

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
            '-- paramentros de entrada
            pvParametros1.Add(v_idLaboratorio)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros1)

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

    '-- cantidad de compras por laboratorio
    Private Sub cantidadCompraLabo()
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
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            '------------------------------------
            '-- instaciar el parametro
            Dim v_idLaboratorio As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim rpt As New rpt_estProveedorCantidadLabo
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idLaboratorio.Value = CDbl(lblIdLaboratorio.Text)
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

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
            '-- paramentros de entrada
            pvParametros1.Add(v_idLaboratorio)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)

            '-- paramentros constantes
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros1)

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

    '-- cantidad de compras de todos los productos de todos los laboratorios
    Private Sub cantidadCompraTodosLab()
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
            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            '------------------------------------
            '-- instaciar el parametro
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim rpt As New rpt_estProveedorCantidadLaboTodos
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

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
            '-- paramentros de entrada
            pvParametros1.Add(v_desde)
            pvParametros2.Add(v_hasta)

            '-- paramentros constantes
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
        Me.Enabled = False
        '-------------------------------
        '-- seleccionar la opcion
        If rdPorcentajeProducto.Checked = True Then
            '-- el procedimiento
            porcentajeProveedorProducto()

        End If
        If rdPorcentajeProductoProveedor.Checked = True Then
            '-- el procedimiento
            porcentajePorProducto()
        End If

        If rdporcentajeCostoTodos.Checked = True Then
            '-- porcentaje de costos por laboratorio
            porcentajeCostoLaboratorio()
        End If

        If rdPorcentajeBajoUtilidad.Checked = True Then
            '-- porcentaje bajo de los productos 
            porcentajeBajoCostoProducto()
        End If

        If rdCantidadCompraLabo.Checked = True Then
            '-- cantidad compradada por laboratorio
            cantidadCompraLabo()
        End If

        If rdCantidadTodosLaboratorios.Checked = True Then
            '-- cantidad comprada de todos los productos de todos los laboratorios
            cantidadCompraTodosLab()
        End If

        '------------------------------
        Me.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdPorcentajeProducto_Click(sender As Object, e As System.EventArgs) Handles rdPorcentajeProducto.Click
        banGl_estadisticaProveedor = True

        Me.Enabled = False

        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.Show()
        frmBuscarProveedor.BringToFront()
        frmBuscarProveedor.txtBuscar.Focus()

    End Sub

    Private Sub rdPorcentajeDivision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPorcentajeDivision.Click
        banGl_estadisticaProveedor = True

        Me.Enabled = False

        frmBuscarLaboratorio.txtIdLaboratorio.Text = 0
        frmBuscarLaboratorio.txtBuscar.Text = ""
        frmBuscarLaboratorio.Show()
        frmBuscarLaboratorio.BringToFront()
        frmBuscarLaboratorio.txtBuscar.Focus()

    End Sub

    Private Sub rdporcentajeCostoTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdporcentajeCostoTodos.Click
        banGl_estadisticaProveedor = True

        Me.Enabled = False

        frmBuscarLaboratorio.txtIdLaboratorio.Text = 0
        frmBuscarLaboratorio.txtBuscar.Text = ""
        frmBuscarLaboratorio.Show()
        frmBuscarLaboratorio.BringToFront()
        frmBuscarLaboratorio.txtBuscar.Focus()

    End Sub

    Private Sub rdPorcentajeBajoUtilidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPorcentajeBajoUtilidad.Click
        banGl_estadisticaProveedor = True

        Me.Enabled = False

        frmBuscarLaboratorio.txtIdLaboratorio.Text = 0
        frmBuscarLaboratorio.txtBuscar.Text = ""
        frmBuscarLaboratorio.Show()
        frmBuscarLaboratorio.BringToFront()
        frmBuscarLaboratorio.txtBuscar.Focus()

    End Sub

    Private Sub rdPorcentajeProductoProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPorcentajeProductoProveedor.Click
        banGl_estadisticaProveedor = True

        Me.Enabled = False

        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = 0
        frmStock.Show()
        frmStock.BringToFront()
        frmStock.lvStock.Focus()

    End Sub

    Private Sub rdCantidadCompraLabo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdCantidadCompraLabo.Click
        banGl_estadisticaProveedor = True

        Me.Enabled = False

        frmBuscarLaboratorio.txtIdLaboratorio.Text = 0
        frmBuscarLaboratorio.txtBuscar.Text = ""
        frmBuscarLaboratorio.Show()
        frmBuscarLaboratorio.BringToFront()
        frmBuscarLaboratorio.txtBuscar.Focus()

    End Sub

    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmEstadisticaProveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.proveedorEstadistica.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------
End Class