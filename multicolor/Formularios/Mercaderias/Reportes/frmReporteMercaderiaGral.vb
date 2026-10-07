Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteMercaderiaGral
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim deposito As New deposito
    Dim laboratorio As New laboratorio

    Dim intIdDeposito As Integer
    Dim intIdProducto As Integer
    Dim intIdLaboratorio As Integer
    Dim intIdBlackFriday As Integer
    Dim intIdMotivoAjuste As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo del deposito
        deposito.comboDeposito(cboDeposito)
        '-- cargar el combo del laboratorio
        laboratorio.ListarLaboratorio(cboLaoratorio)

        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"
    End Sub

    '-- la opcion del resumen por fecha
    Private Sub imprimirStockMercaderia(ByVal v_opcion As Integer)
        Try
            '-- valor del idDeposito
            intIdDeposito = cboDeposito.SelectedValue

            'MsgBox("Valor de idDeposito  " & intIdDeposito)
            'MsgBox("Valor de v_opcion  " & v_opcion)

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idDepositoCon As New ParameterDiscreteValue()
            Dim v_varOpcion As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_mercaderiaStockMayor
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idDepositoCon.Value = intIdDeposito
            v_varOpcion.Value = v_opcion

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idDepositoCon)
            pvParametros2.Add(v_varOpcion)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@opcion").ApplyCurrentValues(pvParametros2)

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

    '-- mercaderias sin Foto
    Private Sub mercaderiaSinFoto()
        Try
            '-- valor del idDeposito
            intIdDeposito = cboDeposito.SelectedValue

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idDepositoA As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_mercaderiaSinFoto
            Dim ofrm As New crv()

            '-- los paramentros de entrada

            v_idDepositoA.Value = intIdDeposito

            '-- pasar los parametros
            'txtSql.Text = intIdDeposito & "," & intIdProducto & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'"

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idDepositoA)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)

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

    '-- la opcion del stock de mercaderias controladas
    Private Sub imprimirStockMercaderiaControlada()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idLaboratorio As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_mercaderiaStockControl
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idLaboratorio.Value = intIdLaboratorio

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idLaboratorio)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros1)

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

    '-- la opcion del stock de mercaderias controladas por sucursal
    Private Sub imprimirStockMercaderiaControladaPorDeposito()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idDeposito As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_mercaderiaStockControlSuc
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idDeposito.Value = cboDeposito.SelectedValue

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idDeposito)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)

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

    '-- la opcion del stock de mercaderias controladas
    Private Sub imprimirStockLaboratorioDeposito()
        Try
            '-- valor del idDeposito
            'intIdDeposito = cboDeposito.SelectedValue
            intIdLaboratorio = cboLaoratorio.SelectedValue

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idDepositoCon As New ParameterDiscreteValue()
            Dim v_idLaboratorioCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_stockLaboratorioDep
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idDepositoCon.Value = intIdDeposito
            v_idLaboratorioCon.Value = intIdLaboratorio

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idDepositoCon)
            pvParametros2.Add(v_idLaboratorioCon)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros2)

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

    '-- la opcion del stock de mercaderias por deposito y laboratorio
    Private Sub imprimirStockLaboratorioDepositoTodos()
        Try
            '-- valor del idDeposito
            'intIdDeposito = cboDeposito.SelectedValue
            intIdLaboratorio = cboLaoratorio.SelectedValue

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()
            Dim pvParametros2 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idDepositoCon As New ParameterDiscreteValue()
            Dim v_idLaboratorioCon As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_stockLaboratorioDepTodos
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idDepositoCon.Value = intIdDeposito
            v_idLaboratorioCon.Value = intIdLaboratorio

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idDepositoCon)
            pvParametros2.Add(v_idLaboratorioCon)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)
            rpt.DataDefinition.ParameterFields("@idLaboratorio").ApplyCurrentValues(pvParametros2)

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

    '-- modificacion de precios de productos enteros
    Private Sub modificaPrecioProductoEntero()
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


            Dim rpt As New rpt_mercaderiaModiPrecioEntero
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text

            '-- pasar los parametros
            'txtSql.Text = intIdDeposito & "," & intIdProducto & "," & "'" & dtpDesdeFecha.Text & "'" & "," & "'" & dtpHastaFecha.Text & "'"

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

    '-- la opcion del stock de mercaderias controladas para todas las sucursales
    Private Sub imprimirStockMercaderiaControladaTodosSuc()
        Try
            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idDeposito As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_mercaderiaStockControlTodosSuc
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idDeposito.Value = cboDeposito.SelectedValue


            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idDeposito)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros1)

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

    '-- la opcion de motivo de ajuste
    Private Sub imprimirMotivoAjuste()
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
            Dim v_idMotivo As New ParameterDiscreteValue()
            Dim v_desde As New ParameterDiscreteValue()
            Dim v_hasta As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_mercaderiaMotivoAjuste
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idMotivo.Value = intIdMotivoAjuste
            v_desde.Value = dtpDesdeFecha.Text
            v_hasta.Value = dtpHastaFecha.Text


            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idMotivo)
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
            rpt.DataDefinition.ParameterFields("@idMotivoAjuste").ApplyCurrentValues(pvParametros1)
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
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- mercaderias con precios y costos
    Private Sub imprimirMercaderiaPrecioCosto()
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


            Dim rpt As New rpt_mercaderiaPrecioCosto
            Dim ofrm As New crv()


            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada

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

    '-- mercaderias sin canje
    Private Sub imprimirMercaderiaSinCanje()
        Try
            '-- valor del idDeposito
            If chkTodoLaboratorio.Checked = True Then
                intIdLaboratorio = 0
            Else
                intIdLaboratorio = cboLaoratorio.SelectedValue
            End If

            '-- los parametros de entrada
            Dim pvParametros1 As New ParameterValues()

            '-- los paramentros constantes
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            '-- instaciar el parametro
            Dim v_idLaboratorio As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------


            Dim rpt As New rpt_mercaderiaSinCanje
            Dim ofrm As New crv()

            '-- los paramentros de entrada
            v_idLaboratorio.Value = intIdLaboratorio

            '-- los paramentros constantes
            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            '-- paramentros de entrada
            pvParametros1.Add(v_idLaboratorio)

            '-- parametros constantes
            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            '-- parametros de entrada
            rpt.DataDefinition.ParameterFields("@idLaboratorioCon").ApplyCurrentValues(pvParametros1)
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
    '-----------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Me.Enabled = False

        '-- seleccionar la opcion
        If rdStockIgualCero.Checked = True Then
            '-- stock igual a cero
            '---------------'
            '-- el stock --'
            '---------------'
            imprimirStockMercaderia(2)
        End If
        If rdStockMayorCero.Checked = True Then
            '-- stock mayor a cero
            '---------------'
            '-- el stock --'
            '---------------'
            imprimirStockMercaderia(1)
        End If
        If rdStockMenorCero.Checked = True Then
            '-- stock menor a cero
            '---------------'
            '-- el stock --'
            '---------------'
            imprimirStockMercaderia(3)
        End If
        If rdMercaderiaSinFoto.Checked = True Then
            '-- mercaderias son fotos
            If (fun_guardarSp("sp_actualizarProductoSinImagen", intGl_idConfigPc, Me.Name)) = 0 Then

            End If

            mercaderiaSinFoto()
        End If
        If rdStockControlado.Checked = True Then
            '-- mercaderias con stock de uso controlado
            If chkTodoLaboratorio.Checked = True Then
                intIdLaboratorio = 0
            Else
                intIdLaboratorio = cboLaoratorio.SelectedValue
            End If

            imprimirStockMercaderiaControlada()
        End If
        If rdStockControladoSucursal.Checked = True Then
            '-- mercaderias con stock de uso controlado por deposito
            imprimirStockMercaderiaControladaPorDeposito()
        End If
        If rdStockLaboratorio.Checked = True Then
            '-- stock de mercaderias por laboratorio y deposito
            If chkDeposito.Checked = True Then
                intIdDeposito = 0
                imprimirStockLaboratorioDepositoTodos()
            Else
                intIdDeposito = cboDeposito.SelectedValue
                imprimirStockLaboratorioDeposito()
            End If

        End If
        If rdModificacionPrecios.Checked = True Then
            '-- modificacion de precios de productos enteros
            modificaPrecioProductoEntero()
        End If
        If rdStockControladoTodasSuc.Checked = True Then
            '-- stock de controlados de todas las sucursales
            imprimirStockMercaderiaControladaTodosSuc()
        End If
        If rdMotivoAjuste.Checked = True Then
            '-- motivo de ajuste
            intIdMotivoAjuste = lblIdProducto.Text
            imprimirMotivoAjuste()
        End If
        If rdCostoPrecio.Checked = True Then
            '-- mercaderias con precios y costos
            imprimirMercaderiaPrecioCosto()
        End If

        If rdMercaderiaSinCanje.Checked = True Then
            '-- mercaderia sin canje
            imprimirMercaderiaSinCanje()
        End If

        Me.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub rdStockMayorCero_Click(sender As System.Object, e As System.EventArgs) Handles rdStockMayorCero.Click
        lblMercaderia.Visible = False
        lblCodigo.Visible = False
        lblIdProducto.Visible = False
    End Sub

    Private Sub rdStockIgualCero_Click(sender As System.Object, e As System.EventArgs) Handles rdStockIgualCero.Click
        lblMercaderia.Visible = False
        lblCodigo.Visible = False
        lblIdProducto.Visible = False
    End Sub

    Private Sub rdStockMenorCero_Click(sender As System.Object, e As System.EventArgs) Handles rdStockMenorCero.Click
        lblMercaderia.Visible = False
        lblCodigo.Visible = False
        lblIdProducto.Visible = False
    End Sub

    Private Sub rdMercaderiaSinFoto_Click(sender As System.Object, e As System.EventArgs) Handles rdMercaderiaSinFoto.Click
        lblMercaderia.Visible = False
        lblCodigo.Visible = False
        lblIdProducto.Visible = False
    End Sub

    Private Sub rdMercaderiaEnviada_Click(sender As System.Object, e As System.EventArgs) Handles rdMercaderiaEnviada.Click
        '-- activar la consulta de stock
        banGl_reporteMercaderiaGral = True

        Me.Enabled = False
        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = "0"
        frmStock.Visible = True
        frmStock.WindowState = FormWindowState.Normal
        frmStock.Show()
        frmStock.txtBuscar.Focus()
        lblMercaderia.Visible = True
    End Sub

    Private Sub rdMotivoAjuste_Click(sender As System.Object, e As System.EventArgs) Handles rdMotivoAjuste.Click
        '-- los motivos de ajuste
        banGl_reporteMercaderiaGral = True

        Me.Enabled = False
        frmBuscarMotivo.Visible = True
        frmBuscarMotivo.WindowState = FormWindowState.Normal
        frmBuscarMotivo.Show()
        frmBuscarMotivo.txtBuscar.Focus()
        lblMercaderia.Visible = True
        lblIdProducto.Visible = True
    End Sub

    Private Sub rdStockControlado_Click(sender As System.Object, e As System.EventArgs) Handles rdStockControlado.Click
        lblMercaderia.Visible = False
        lblCodigo.Visible = False
        lblIdProducto.Visible = False
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteMercaderiaGral_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiasReportesMercaderiaGral.Enabled = True
        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------------------------
    
End Class