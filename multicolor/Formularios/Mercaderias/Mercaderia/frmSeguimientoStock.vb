Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmSeguimientoStock
    '****************************'
    '--  VARIABLES TIPO OBJETO --'
    '****************************'
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- colocar por defecto el deposito de la pc
        intGl_idDepositoSeguimientoStock = sp_datosTabla.consulta_valor("select idDepositoVenta from configPC where idConfig=" & intGl_idConfigPc)
        txtIdDeposito.Text = intGl_idDepositoSeguimientoStock
        txtNombreDeposito.Text = sp_datosTabla.consulta_valorString("select nombreDeposito from deposito where idDeposito=" & intGl_idDepositoSeguimientoStock)
        chkBuscarDeposito.Checked = True
        'Me.Enabled = False
        dtpDesdeFecha.Format = DateTimePickerFormat.Custom
        dtpDesdeFecha.CustomFormat = "dd/MM/yyyy"
        lblNombrePlato.Text = ""
    End Sub

    '-- procesar el seguimiento de stock
    Private Sub procesarSeguimientoStock()
        Try
            'grEsperar.Visible = True
            Me.Enabled = False

            '-------------------------------------------------------------------'
            '-- procedimiento para insertar el saldo inicial de la mercaderia --'
            '-------------------------------------------------------------------'
            'MsgBox("Paso  3")
            'If (fun_guardarSp("sp_agregarTmpSaldoseguimientoStock", intGl_idConfigPc & "," & intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & CInt(txtIdDeposito.Text), Me.Name)) = 0 Then
            '    '-- no se guardo los registros
            '    'MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'End If

            'Me.UseWaitCursor.
            If chkBuscarDeposito.Checked = True Then
                ' MsgBox("Paso  2")
                '-- si es por deposito
                '-- colocar el idSucursal seleccionado
                'MsgBox("Valor de iddeposito  " & intGl_idDepositoSeguimientoStock)
                Dim intTmpIdSucursal As Integer
                intTmpIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "deposito", "idDeposito", intGl_idDepositoSeguimientoStock)
                If rdMercaderia.Checked = True Then
                    '-- por mercaderia
                    'MsgBox("antes de realizar la insersion")
                    'MsgBox("Paso  4")

                    'sp_datosTabla.sp_string("sp_insSeguimientoStock", intGl_idConfigPc & "," & intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & CInt(txtIdDeposito.Text))
                    If (fun_guardarSp("sp_insSeguimientoStock", intGl_idConfigPc & "," & intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & CInt(txtIdDeposito.Text), Me.Name)) = 0 Then
                        '-- no se guardo los registros
                        MessageBox.Show("No se pudo actualizar el cursor...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'MsgBox("Paso  5")
                    'MsgBox("despues de realizar la insersion")
                    '-- el stock consultado
                    txtStockCon.Text = sp_datosTabla.consulta_valorDouble("Select sum(s.cantidad) from stock s inner join deposito d " & _
                    " on s.idDeposito=d.idDeposito where idProducto=" & intGl_idProductoSeguimientoStock & " and d.idDeposito=" & _
                    intGl_idDepositoSeguimientoStock & " group by idProducto")

                    'MsgBox("Paso  6")
                    'listarSeguimientoStock(" where idDeposito=" & CInt(txtIdDeposito.Text) & " and idConfig=" & intGl_idConfigPc)

                    listarSeguimientoStock()

                    'MsgBox("Paso  7")
                End If

                If rdVence.Checked = True Then
                    '-- por vencimiento
                    '-- idLote y el idStock
                    Dim intTmpidStock As Integer
                    Dim intTmpIdLote As Integer
                    intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from lote where lote='" & txtLote.Text & "' and vencimiento=" _
                                                              & "'" & txtVence.Text & "'")

                    intTmpidStock = sp_datosTabla.consulta_valor("Select idStock from stock where idProducto=" & intGl_idProductoSeguimientoStock _
                                                               & " and idDeposito=" & txtIdDeposito.Text & " and idLote=" & intTmpIdLote)

                    '-- por mercaderia
                    sp_datosTabla.sp_string("sp_insSeguimientoStock", intGl_idConfigPc & "," & intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & CInt(txtIdDeposito.Text))
                    '-- el stock consultado
                    txtStockCon.Text = sp_datosTabla.consulta_valorDouble("Select cantidad from stock where idStock=" & intTmpidStock)

                    ' listarSeguimientoStock(" where idStock=" & intTmpidStock & " and idConfig=" & intGl_idConfigPc)

                End If

            Else
                '-- por el deposito de la sucursal configurado
                If rdMercaderia.Checked = True Then
                    '-- por mercaderia
                    sp_datosTabla.sp_string("sp_insSeguimientoStock", intGl_idConfigPc & "," & intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & CInt(txtIdDeposito.Text))
                    '-- el stock consultado
                    txtStockCon.Text = sp_datosTabla.consulta_valorDouble("Select sum(s.cantidad) from stock s inner join deposito d " & _
                    " on s.idDeposito=d.idDeposito where idProducto=" & intGl_idProductoSeguimientoStock & " group by idProducto")
                    txtStockCon.Text = FormatNumber(txtStockCon.Text, "000,000.00")
                End If
                ' listarSeguimientoStock(" where idConfig=" & intGl_idConfigPc)

            End If

            '-- las variables
            Dim intTmpIdProducto As Integer
            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & txtCodigo.Text)
            '-- el total de stock
            txtStockTotal.Text = sp_datosTabla.consulta_valorDouble("select sum(cantidad) from stock where idProducto=" & intTmpIdProducto & " group by idProducto")
            txtStockTotal.Text = FormatNumber(txtStockTotal.Text, "000,000.00")
            '-- el stock de la sucursal deonde opera
            txtStockSuc.Text = sp_datosTabla.consulta_valorDouble("Select sum(s.cantidad) from stock s inner join deposito d " & _
            " on s.idDeposito=d.idDeposito where s.idProducto=" & intGl_idProductoSeguimientoStock & _
            " and d.idSucursal=" & intGl_idSucursal & " group by idProducto")
            txtStockSuc.Text = FormatNumber(txtStockSuc.Text, "000,000.00")

            '-- procedimiento para listar el seguimiento
            Me.Enabled = True
            'MessageBox.Show("Fin del Procesamiento del Seguimiento de Stock..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'pnEsperar.Visible = False
            lvSeguimiento.Focus()
            'Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '-- listar el seguimiento de stock
    Public Sub listarSeguimientoStock()
        Try
            If chkBuscarDeposito.Checked = True Then
                '-- por deposito
                'txtSql.Text = "select nro,idmov,fechaAlta,entrada,salida,saldo,tipo,vencimiento" & _
                '",lote,idAuditoria,nombreDeposito,responsable,noimp from tmpSeguimientoStock where idDeposito=" & _
                'intGl_idDepositoSeguimientoStock & v_parametro & " order by fechaAlta"
                'MsgBox("Paso previo")
                systemClass.SqlToLv_detalleConsultaSeguimientoStock(lvSeguimiento, "sp_consultaSeguimientoStock_nuevo", intGl_idConfigPc & "," & intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(dtpDesdeFecha) & "'" & "," & CInt(txtIdDeposito.Text))
                ' MsgBox("Paso despues")
                'systemClass.SqlToLv_seguimientoStock(lvSeguimiento, "select nro,idmov,fechaAlta,entrada,salida,saldo,tipo,vencimiento" & _
                '",lote,idAuditoria,nombreDeposito,responsable,noimp from tmpSeguimientoStock " & v_parametro & " order by fechaAlta")

                'txtSql.Text = "select nro,idmov,fechaAlta,entrada,salida,saldo,tipo,vencimiento,lote,idAuditoria,responsable from tmpSeguimientoStock where idDeposito=" & intGl_idDepositoSeguimientoStock & " order by fechaAlta"
            Else
                '-- todos los depositos configurado para la sucursal actual
                'txtSql.Text = "select nro,idmov,fechaAlta,entrada,salida,saldo,tipo,vencimiento" & _
                '",lote,idAuditoria,nombreDeposito,responsable,noimp from tmpSeguimientoStock " & v_parametro & " order by fechaAlta"

                ' systemClass.SqlToLv_seguimientoStock(lvSeguimiento, "select nro,idmov,fechaAlta,entrada,salida,saldo,tipo,vencimiento" & _
                ' ",lote,idAuditoria,nombreDeposito,responsable,noimp from tmpSeguimientoStock " & v_parametro & " order by fechaAlta")
            End If
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '----------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        banGl_seguimientoStock = True
        Me.Enabled = False

        '-- verificar el tipo de busqueda
        '- por producto
        If rdMercaderia.Checked = True Then
            bolGl_busquedaVenceSeguimientoStock = False
        End If
        '- por vencimiento
        If rdVence.Checked = True Then
            bolGl_busquedaVenceSeguimientoStock = True
        End If
        '-----------------------------
        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = "0"
        frmStock.Visible = True
        frmStock.WindowState = FormWindowState.Normal
        frmStock.Show()
        frmStock.txtBuscar.Focus()
    End Sub

    Private Sub btnProcesar_Click(sender As System.Object, e As System.EventArgs) Handles btnProcesar.Click
        procesarSeguimientoStock()
        'pnEsperar.Visible = True
        'BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False

        Dim pvParametros As New ParameterValues()
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
        Dim rpt As New rpt_seguimientoStock
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idDeposito.Value = CInt(txtIdDeposito.Text)
        v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idDeposito)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idDeposito").ApplyCurrentValues(pvParametros)
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
    End Sub
    '----------------------------------------------------------------------------------------
    '*************'
    '-- LOS CHK --'
    '*************'
    Private Sub chkBuscarDeposito_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBuscarDeposito.Click
        If chkBuscarDeposito.Checked = True Then
            banGl_seguimientoStock = True
            Me.Enabled = False
            frmBuscarDepositoMercaderia.txtIdDeposito.Text = 0
            frmBuscarDepositoMercaderia.txtNombreDeposito.Text = ""
            frmBuscarDepositoMercaderia.txtNombreSucursal.Text = ""
            frmBuscarDepositoMercaderia.txtBuscar.Text = ""
            frmBuscarDepositoMercaderia.Visible = True
            frmBuscarDepositoMercaderia.Show()
            frmBuscarDepositoMercaderia.WindowState = FormWindowState.Normal
            frmBuscarDepositoMercaderia.BringToFront()
            frmBuscarDepositoMercaderia.txtBuscar.Focus()
        Else
            txtNombreDeposito.Text = ""
            txtIdDeposito.Text = 0
        End If
    End Sub
    '----------------------------------------------------------------------------------------
    '******************'
    '-- LOS LISTVIEW --'
    '******************'

    '----------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmSeguimientoStock_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiaMercaderiasSeguimientoStock.Enabled = True

        e.Cancel = False
    End Sub
    '----------------------------------------------------------------------------------------
End Class