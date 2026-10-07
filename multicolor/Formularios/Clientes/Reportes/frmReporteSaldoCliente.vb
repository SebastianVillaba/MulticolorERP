Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReporteSaldoCliente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdGrupoCliente As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpHastaFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        dtpHastaFecha.CustomFormat = "dd/MM/yyyy"
        '-- valor de los lbl
        lblIdGrupo.Text = 0
        lblNombreGrupo.Text = ""
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub saldoResumidoCliente()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_saldoResumenCliente
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

    Private Sub saldoResumidoGrupoCliente()
        Try
            Dim pvParametros1 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_idGrupoCliente As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_saldoResumenGrupoCliente
            Dim ofrm As New crv()

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            v_idGrupoCliente.Value = CInt(lblIdGrupo.Text)
            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_idGrupoCliente)
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

            rpt.DataDefinition.ParameterFields("@idGrupoCliente").ApplyCurrentValues(pvParametros1)

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

    '-- saldo de mora del cliente
    Private Sub saldoMoraCliente()
        Try
            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            '------------------------------------
            Dim rpt As New rpt_saldoMoraCliente
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

    '-- todos los grupos de clientes
    Private Sub saldoResumidoTodoGrupoCliente()
        Try
            Dim pvParametros1 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()

            Dim v_fecha As New ParameterDiscreteValue()

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_idGrupoCliente As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_saldoResumenGrupoClienteTodo
            Dim ofrm As New crv()

            v_fecha.Value = FormatoFechaSoloDatePicker(dtpHastaFecha)

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc

            ' añadir el parámetro a la colección de parámetros
            pvParametros1.Add(v_fecha)

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@fecha").ApplyCurrentValues(pvParametros1)

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

    '-- saldo por cliente
    Private Sub saldoPorCliente()
        Try

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()


            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_idGrupoCliente As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_saldoPorCliente
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

    '-- cancelacion por recibo de cobro
    Private Sub cancelaCobroCliente()
        Try

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()


            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_idGrupoCliente As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_clienteCancela
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

    '-- reporte de pago por grupo de clientes
    Private Sub pagoGrupoCliente()
        Try

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()


            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()

            Dim v_idGrupoCliente As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_historicoResumenTodos
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
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        '-- debe introducir la sucursal
        'If Not IsNumeric(txtIdSucursal.Text) Then
        '    MessageBox.Show("Debe Introducir la Sucursal..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If
        Me.Enabled = False

        If rdSaldoResumidoCliente.Checked = True Then
            '-------------------------------'
            '-- SALDO RESUMIDO DE CLIENTE --'
            '-------------------------------'
            If (fun_guardarSp("sp_agregarTmpSaldoCliente", intGl_idConfigPc & ",'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                saldoResumidoCliente()
            End If
        End If

        If rdGrupoCliente.Checked = True Then
            '--------------------------'
            '-- POR GRUPO DE CLIENTE --'
            '--------------------------'
            '-- solo si el nro es mayor a cero
            If lblIdGrupo.Text <= 0 Then
                MessageBox.Show("Debe Ingresar el Grupo de Cliente..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            saldoResumidoGrupoCliente()
        End If

        If rdSaldoMora.Checked = True Then
            '-------------------------------'
            '-- SALDO DE MORA DEL CLIENTE --'
            '-------------------------------'
            '-- el procedimiento para la insercion en la tabla temporal
            sp_datosTabla.sp_string("sp_insTmpSaldoMoraCliente", intGl_idConfigPc)

            saldoMoraCliente()

        End If
        If rdTodoGrupo.Checked = True Then
            '--------------------------------------'
            '-- POR TODOS LOS GRUPOS DE CLIENTES --'
            '--------------------------------------'
            saldoResumidoTodoGrupoCliente()
        End If

        If rdPorCliente.Checked = True Then
            '-----------------------'
            '-- SALDO POR CLIENTE --'
            '-----------------------'
            If (fun_guardarSp("sp_agregarTmpSaldoPorCliente", intGl_idConfigPc & "," & lblIdGrupo.Text & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                    "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                saldoPorCliente()
            End If
        End If

        If rdCancelaGrupo.Checked = True Then
            '------------------------------------'
            '-- CACELACION POR RECIBO DE COBRO --'
            '------------------------------------'
            If (fun_guardarSp("sp_cargarTmpClienteCobro", intGl_idConfigPc & "," & lblIdGrupo.Text & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                    "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                cancelaCobroCliente()
            End If
        End If

        If rdPagoGrupoCliente.Checked = True Then
            '--------------------------------------------'
            '-- REPORTE DE PAGO PARA GRUPO DE CLIENTES --'
            '--------------------------------------------'
            If (fun_guardarSp("sp_cargarTmpClienteCobroConSaldo", intGl_idConfigPc & "," & lblIdGrupo.Text & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & _
                                    "," & "'" & FormatoFechaSoloDatePicker(dtpHastaFecha) & "'", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No existen registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- la impresion
                pagoGrupoCliente()
            End If
        End If

        Me.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*****************'
    '-- RADIOBUTTON --'
    '*****************'
    Private Sub rdGrupoCliente_Click(sender As Object, e As System.EventArgs) Handles rdGrupoCliente.Click
        If rdGrupoCliente.Checked = True Then
            banGl_reporteSaldoCliente = True
            Me.Enabled = False

            frmBuscarGrupoCliente.txtBuscar.Text = ""
            frmBuscarGrupoCliente.txtId.Text = 0
            frmBuscarGrupoCliente.txtNombre.Text = ""
            frmBuscarGrupoCliente.Show()
            frmBuscarGrupoCliente.BringToFront()

        End If
    End Sub

    Private Sub rdCancelaGrupo_Click(sender As Object, e As System.EventArgs) Handles rdCancelaGrupo.Click
        If rdCancelaGrupo.Checked = True Then
            banGl_reporteSaldoCliente = True
            Me.Enabled = False

            frmBuscarGrupoCliente.txtBuscar.Text = ""
            frmBuscarGrupoCliente.txtId.Text = 0
            frmBuscarGrupoCliente.txtNombre.Text = ""
            frmBuscarGrupoCliente.Show()
            frmBuscarGrupoCliente.BringToFront()

        End If
    End Sub

    Private Sub rdPagoGrupoCliente_Click(sender As Object, e As System.EventArgs) Handles rdPagoGrupoCliente.Click
        If rdPagoGrupoCliente.Checked = True Then
            banGl_reporteSaldoCliente = True
            Me.Enabled = False

            frmBuscarGrupoCliente.txtBuscar.Text = ""
            frmBuscarGrupoCliente.txtId.Text = 0
            frmBuscarGrupoCliente.txtNombre.Text = ""
            frmBuscarGrupoCliente.Show()
            frmBuscarGrupoCliente.BringToFront()

        End If
    End Sub

    Private Sub rdPorCliente_Click(sender As Object, e As System.EventArgs) Handles rdPorCliente.Click
        If rdPorCliente.Checked = True Then
            banGl_reporteSaldoCliente = True
            Me.Enabled = False

            frmBuscarClienteVenta.txtBuscar.Text = ""
            frmBuscarClienteVenta.txtIdCliente.Text = 0
            frmBuscarClienteVenta.Show()
            frmBuscarClienteVenta.BringToFront()

        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteSaldoCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.clienteReportesSaldoCliente.Enabled = True
    End Sub
    '----------------------------------------------------------------------------------------------------------
End Class