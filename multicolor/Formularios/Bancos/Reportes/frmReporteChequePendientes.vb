Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteChequePendientes
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdCuenta As Integer
    Dim intIdProveedor As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub imprimir()
        Try
            intIdCuenta = CInt(txtIdCuenta.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idCuenta As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_pendiente As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_chequePendiente
            Dim ofrm As New crv()

            v_idCuenta.Value = intIdCuenta
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_pendiente.Value = chkPendiente.Checked

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idCuenta)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)
            pvParametros4.Add(v_pendiente)


            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idCuenta").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@pendiente").ApplyCurrentValues(pvParametros4)

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

    '-- imprimir por proveedor
    Private Sub imprimirProveedor()
        Try
            '-- controlar que se introduzca el proveedor
            If Len(lblProveedor.Text) = 0 Then
                MessageBox.Show("Debe Ingresae el Proveedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            intIdCuenta = CInt(txtIdCuenta.Text)
            intIdProveedor = CInt(lblIdProveedor.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idCuenta As New ParameterDiscreteValue()
            Dim v_idProveedor As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_chequePendienteProveedor
            Dim ofrm As New crv()

            v_idCuenta.Value = intIdCuenta
            v_idProveedor.Value = intIdProveedor
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idCuenta)
            pvParametros2.Add(v_idProveedor)
            pvParametros3.Add(v_desde)
            pvParametros4.Add(v_hasta)



            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idCuenta").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idProveedor").ApplyCurrentValues(pvParametros2)
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

    '-- cheques pendientes
    Private Sub imprimirChequePendiente()
        Try
            intIdCuenta = CInt(txtIdCuenta.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idCuenta As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_pendiente As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_chequeSoloPendiente
            Dim ofrm As New crv()

            v_idCuenta.Value = intIdCuenta
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_pendiente.Value = chkPendiente.Checked

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idCuenta)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)
            pvParametros4.Add(v_pendiente)


            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idCuenta").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@pendiente").ApplyCurrentValues(pvParametros4)

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

    '-- cheques pendientes por proveedor
    Private Sub imprimirChequePendienteProveedor()
        Try
            '-- controlar que se introduzca el proveedor
            If Len(lblProveedor.Text) = 0 Then
                MessageBox.Show("Debe Ingresae el Proveedor..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            intIdCuenta = CInt(txtIdCuenta.Text)
            intIdProveedor = CInt(lblIdProveedor.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idCuenta As New ParameterDiscreteValue()
            Dim v_idProveedor As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_chequeSoloPendienteProveedor
            Dim ofrm As New crv()

            v_idCuenta.Value = intIdCuenta
            v_idProveedor.Value = intIdProveedor
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idCuenta)
            pvParametros2.Add(v_idProveedor)
            pvParametros3.Add(v_desde)
            pvParametros4.Add(v_hasta)



            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idCuenta").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idProveedor").ApplyCurrentValues(pvParametros2)
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

    '-- imprimir por facruras 
    Private Sub imprimirFacturaCheque()
        Try
            intIdCuenta = CInt(txtIdCuenta.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idCuenta As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_chequeFactura
            Dim ofrm As New crv()

            v_idCuenta.Value = intIdCuenta
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)


            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idCuenta)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)



            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idCuenta").ApplyCurrentValues(pvParametros1)
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

    '--imprimir anulados
    Private Sub imprimirAnulados()
        Try
            intIdCuenta = CInt(txtIdCuenta.Text)

            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()
            Dim pvParametros3 As New ParameterValues()
            Dim pvParametros4 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idCuenta As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()
            Dim v_pendiente As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_chequeAnulados
            Dim ofrm As New crv()

            v_idCuenta.Value = intIdCuenta
            v_desde.Value = FormatoFechaSoloDatePicker(dtpDesdeFecha)
            v_hasta.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)
            v_pendiente.Value = chkPendiente.Checked

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idCuenta)
            pvParametros2.Add(v_desde)
            pvParametros3.Add(v_hasta)
            pvParametros4.Add(v_pendiente)


            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idCuenta").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@desde").ApplyCurrentValues(pvParametros2)
            rpt.DataDefinition.ParameterFields("@hasta").ApplyCurrentValues(pvParametros3)
            rpt.DataDefinition.ParameterFields("@pendiente").ApplyCurrentValues(pvParametros4)

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
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        '-- debe introducir la sucursal
        If Not IsNumeric(txtIdCuenta.Text) Then
            MessageBox.Show("Debe Introducir la Cuenta Corriente..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtIdCuenta.Text = 0 Then
            MessageBox.Show("Debe Introducir la Cuenta Corriente..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If rdResumen.Checked = True Then
            Me.Enabled = False

            If chkPendiente.Checked = True Then
                '-- solo los pendientes
                imprimirChequePendiente()
            Else
                '-- todos los cheques
                imprimir()
            End If

            Me.Enabled = True
        End If
        If rdDetalle.Checked = True Then
            Me.Enabled = False

            If chkPendiente.Checked = True Then
                '-- solo los pendientes
                imprimirChequePendienteProveedor()
            Else
                '-- todos los cheques
                imprimirProveedor()
            End If

            Me.Enabled = True
        End If

        If rdPorFactura.Checked = True Then
            '-- por factura
            Me.Enabled = False
            imprimirFacturaCheque()
            Me.Enabled = True
        End If


        If rdAnulado.Checked = True Then
            '-- por factura
            Me.Enabled = False
            imprimirAnulados()
            Me.Enabled = True
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Me.Enabled = False
        banGl_reporteChequePendiente = True
        frmBuscarCuentaCorriente.txtIdCuenta.Text = 0
        frmBuscarCuentaCorriente.txtNombreBanco.Text = ""
        frmBuscarCuentaCorriente.txtBuscar.Text = ""
        frmBuscarCuentaCorriente.Show()
        frmBuscarCuentaCorriente.BringToFront()
        frmBuscarCuentaCorriente.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdDetalle_Click(sender As Object, e As System.EventArgs) Handles rdDetalle.Click
        banGl_reporteChequePendiente = True
        Me.Enabled = False

        frmBuscarProveedor.Show()
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.BringToFront()
    End Sub

    Private Sub rdResumen_Click(sender As Object, e As System.EventArgs) Handles rdResumen.Click
        lblProveedor.Visible = False
        lblIdProveedor.Visible = False
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteChequePendientes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.bancoReportesChequePendiente.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
End Class