Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmGuardarCompra
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarCompra As New sp_cargarCompra
    Dim tipoSucursal As New tipoSucursal

    Dim intIdCodigoBarra As Integer
    Dim intIdCompra As Integer
    Dim intIdNotaCredito As Integer
    'Dim frmCompras As New frmCompras

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        tipoSucursal.comboTipoSucursal(cboTipoSucursal)
        cboTipoSucursal.SelectedValue = 1
    End Sub

    Private Sub imprimir(ByVal codigoCompra As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idcompra As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_compra()
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idcompra.Value = codigoCompra
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idcompra)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCompra").ApplyCurrentValues(pvParametros)
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
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub

    Private Sub generarCodigoBarra()
        '-- eliminar todos los registros generados
        sp_datosTabla.consulta_valor("delete from tmpImpCodigoBarra where idConfig=" & intGl_idConfigPc)
        '-- eliminar todos los registros generados para la impresion
        sp_datosTabla.consulta_valor("delete from tmpCodigoBarra where idConfig=" & intGl_idConfigPc)
        '-- hacer correr el procedimiento para agregar los productos pendientes de codigo de barras a la tabla temporal
        sp_datosTabla.sp_string("sp_agregarCodigoBarraTmpCompra", intIdCompra & "," & intGl_idConfigPc)

        'Dim intTmpValorRegistros As Integer = 0
        'For i As Integer = 0 To frmCompras.dtgCompra.Rows.Count - 1
        '    If frmCompras.dtgCompra.Rows(i).Cells(0).Value > 0 Then
        '        '----------------------'
        '        '-- sacar el idStock --'
        '        '----------------------'
        '        '-- idlote
        '        Dim intTmpIdLote As Integer
        '        '-- armar la fecha de vencimiento
        '        If frmCompras.dtgCompra.Rows(i).Cells(7).Value = "" Then
        '            intTmpIdLote = 1
        '        Else
        '            Dim strTmpFecha As String
        '            strTmpFecha = "01/" & frmCompras.dtgCompra.Rows(i).Cells(7).Value.ToString.Substring(0, 2) & "/20" & _
        '            frmCompras.dtgCompra.Rows(i).Cells(7).Value.ToString.Substring(3, 2)

        '            intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from lote where lote=" & "'" & _
        '                                                      frmCompras.dtgCompra.Rows(i).Cells(6).Value & _
        '                                                      "' and vencimiento=" & "'" & strTmpFecha & "'")
        '            'MsgBox("Valor de la fecha  " & strTmpFecha)
        '        End If


        '        '-- idproducto
        '        Dim intTmpIdProducto As Integer
        '        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from producto where codigo=" & _
        '                                                      frmCompras.dtgCompra.Rows(i).Cells(1).Value)
        '        '-- idDeposito
        '        Dim intTmpIdDeposito As Integer
        '        intTmpIdDeposito = sp_datosTabla.un_dato_integer("idDepositoCompra", "configEmpresa", "idEntidad", intGl_idEntidad)

        '        '-- idStock
        '        Dim intTmpIdstock As Integer
        '        intTmpIdstock = sp_datosTabla.consulta_valor("select idStock from stock where idLote=" & intTmpIdLote & " and " & _
        '                                                   " idProducto=" & intTmpIdProducto & " and idDeposito=" & intTmpIdDeposito)

        '        '-- actualizar la tabla temporal del codigo de barra por la cantidad introducida
        '        sp_datosTabla.consulta_valor("update tmpCodigoBarra set imprimir=" & CInt(frmCompras.dtgCompra.Rows(i).Cells(4).Value) & " where idCompra=" & intIdCompra & " and codigo=" & frmCompras.dtgCompra.Rows(i).Cells(1).Value)
        '        '-- proceso para insertar los registro en el procedimiento
        '        sp_datosTabla.sp_string("sp_insTmpImpCodigoBarraCompra", intIdCompra & "," & intGl_idConfigPc & "," & _
        '                                frmCompras.dtgCompra.Rows(i).Cells(1).Value & "," & intTmpIdstock)
        '    End If
        'Next
    End Sub

    Private Sub imprimirCodigoBarra()
        '------------------------------------
        Dim rpt As New rpt_codigoBarraMercaderia()
        Dim ofrm As New crv()
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- para imprimir directamente
        rpt.PrintToPrinter(1, False, 0, 0)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub

    Private Sub verificarNotaCredito(ByVal v_idCompra As Integer)
        If sp_datosTabla.consulta_valor("select idNotaCredito from cabNotaCredito where idCompra=" & intIdCompra) > 0 Then
            '-- imprimir la nota de credito
            Dim intTmpIdNotaCredito As Integer
            intTmpIdNotaCredito = sp_datosTabla.consulta_valor("select idNotaCredito from cabNotaCredito where idCompra=" & intIdCompra)
            imprimirNotaCredito(intTmpIdNotaCredito)
        End If
    End Sub

    '-- imprimir la nota de credito
    Private Sub imprimirNotaCredito(ByVal codigoNotaCredito As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idNotaCredito As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_notaCredito
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idNotaCredito.Value = codigoNotaCredito
        v_idPersonaJur.Value = intGl_idPersonaJur
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idNotaCredito)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idnotaCredito").ApplyCurrentValues(pvParametros)
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
        ofrm.Visible = True
        ofrm.BringToFront()
        ofrm.Show()
    End Sub
    '-------------------------------------------------------------------------------------------------------
    '******************'
    '-- LOS BOTONES --'
    '******************'
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        '-- controlar que ingrese alguna fecha
        If Not IsNumeric(maskFecha.Text.Substring(0, 1)) Then
            MessageBox.Show("Debe ingresar la Fecha de la Factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-- si es a credito 
        If chkCredito.Checked = True Then
            If Not IsNumeric(maskVence.Text.Substring(0, 1)) Then
                MessageBox.Show("Debe ingresar la Fecha de Vencimiento de la Factura..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
        '-- controlar que se ingrese una cotizacion valida
        If Len(txtCotizacion.Text) > 0 Then
            If Int(txtCotizacion.Text) <= 0 Then
                MessageBox.Show("Debe ingresar una cotizacion válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            MessageBox.Show("Debe ingresar una cotizacion válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '-----------------------'
        '-- GUARDAR LA COMPRA --'
        '-----------------------'
        '-- el id de la persona juridica
        Dim tmpIntIdPersonaJur As Integer
        tmpIntIdPersonaJur = intGl_idPersonaJur
        '-- el id del pedido
        Dim intTmpIdPedido As Integer = 0
        '-- el id del tipo de compra
        Dim intTmpIdTipoCompra As Integer = 0
        '-- si es a credito 
        Dim strTmpVence As String = ""
        If chkCredito.Checked = True Then
            strTmpVence = maskVence.Text
            intTmpIdTipoCompra = sp_datosTabla.consulta_valor("select idTipoCompra from v_tipoCompra where acreditar=1")
        Else
            strTmpVence = "01/01/1900"
            intTmpIdTipoCompra = sp_datosTabla.consulta_valor("select idTipoCompra from v_tipoCompra where acreditar=0")
        End If
        Dim douTmpCotiza As Double = 0
        'intTmpIdCotiza = sp_datosTabla.un_dato_integer("idCotiza", "cabcotiza", "idMoneda", cboMoneda.SelectedValue)
        douTmpCotiza = txtCotizacion.Text
        'MsgBox("Valor de douTmpCotiza   " & douTmpCotiza)
        '-- si es nulo o cero
        If IsDBNull(douTmpCotiza) Or douTmpCotiza = 0 Then
            douTmpCotiza = 1
        End If
        '-- convertir el total
        Dim strTmpTotal As String
        Dim douTmpTotal As Double
        '-- convertir el total para guardar
        strTmpTotal = CStr(frmCompras.txtTotalFactura.Text)
        douTmpTotal = CDbl(strTmpTotal.Replace(",", ""))
        '-- fis
        Dim bolTmpHabilitarCompra As Boolean
        bolTmpHabilitarCompra = chkCompra.Checked
        'MsgBox("Valor del idProveedor  " & CInt(frmCompras.txtProveedor.Text))
        '--------------------------------------
        'If chkCompra.Checked = False Then

        'End If
        banGl_compra = True
        If (fun_guardarSp("sp_guardarCompra", intGl_idConfigPc & "," & cboTipoSucursal.SelectedValue & "," & intGl_idSucursal & "," & tmpIntIdPersonaJur & "," & _
        CInt(frmCompras.txtIDProveedor.Text) & "," & intTmpIdPedido & "," & intTmpIdTipoCompra & "," & frmCompras.cboMoneda.SelectedValue _
         & "," & "'" & txtDsuc.Text & "'" & "," & "'" & txtDcaja.Text & "'" & "," & "'" & txtFactura.Text & "'" & "," & txtTimbrado.Text & "," & _
        "'" & frmCompras.txtResponsable.Text & "'" & "," & "'" & CDate(maskFecha.Text) & "'" & "," & douTmpCotiza & "," & _
        "'" & CDate(strTmpVence) & "'" & "," & douTmpTotal & "," & bolTmpHabilitarCompra & "," & intGl_idUsuario & "," & chkEfectivo.Checked, Me.Name)) = 0 Then
            MessageBox.Show("No se pudo Actualizar la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
            'sp_datosTabla.sp_string("sp_updDetcompraTmp", intGl_idConfigPc & "," & dtgCompra.Rows(i).Cells(0).Value & "," & intTmpIdProducto & "," & strTmpLote & "," & strTmpFecha & "," & intGl_idUsuario & "," & "''")
        End If
        'sp_cargarCompra.guardarCompra(intGl_idConfigPc, intGl_idSucursal, tmpIntIdPersonaJur, CInt(frmCompras.txtIDProveedor.Text), intTmpIdPedido, intTmpIdTipoCompra, frmCompras.cboMoneda.SelectedValue, txtDsuc.Text, txtDcaja.Text, txtFactura.Text, txtTimbrado.Text, frmCompras.txtResponsable.Text, CDate(maskFecha.Text), douTmpCotiza, CDate(strTmpVence), frmCompras.txtTotalFactura.Text, intGl_idUsuario)
        '-- imprimir la compra
        If bolTmpHabilitarCompra = False Then
            intIdCompra = sp_datosTabla.consulta_valor("select max(idCompra) from cabCompra")
        Else
            intIdCompra = sp_datosTabla.consulta_valor("select max(idCompra) from cco")
        End If

        '---------------------------------------------------------------------------------
        '-- controlar si se puede imprimir codigo de barras
        Dim bolTmpImprimirCodigoBarra As Boolean = False
        If (sp_datosTabla.un_dato_boleano("imprimirCodigoBarra", "configEmpresa", "idEntidad", intGl_idEntidad)) = True Then
            If MessageBox.Show("Desea Generar los Codigos de Barras..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sp_datosTabla.sp_string("sp_insCodigoBarraCompra", intIdCompra & "," & intGl_idUsuario)
                '-- preguntar si desea imprimir el codigo de barras
                If MessageBox.Show("Desea Imprimir los Codigos de Barras..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    bolTmpImprimirCodigoBarra = True
                    intIdCodigoBarra = sp_datosTabla.consulta_valor("select max(idCodigoBarra) from codigoBarra where idCompra=" & intIdCompra)
                Else
                    bolTmpImprimirCodigoBarra = False
                End If
            End If
        End If
        '-- imprimir la factura del proveedor 
        banGl_compra = True
        Me.Enabled = False
        imprimir(intIdCompra)
        '-- imprimir el codigo de barras
        If bolTmpImprimirCodigoBarra = True Then
            '-- generar la impresion
            generarCodigoBarra()
            imprimirCodigoBarra()
        End If
        '-- verificar la nota de credito
        verificarNotaCredito(intIdCompra)

        '--sp_cargarCompra.guardarCompra(intGl_idConfigPc, tmpIntIdPersonaJur, CInt(frmCompras.txtIDProveedor.Text), intTmpIdPedido, intTmpIdTipoCompra, frmCompras.cboMoneda.SelectedValue, txtDsuc.Text, txtDcaja.Text, txtFactura.Text, txtTimbrado.Text, frmCompras.txtResponsable.Text, douTmpCotiza, frmCompras.txtTotalFactura.Text, intGl_idUsuario)
        '--------------------------------------
        '-- limpiar el formulario
        frmCompras.limpiar()
        frmCompras.limpiarProducto()

        Me.Close()
        frmCompras.Enabled = True
        frmCompras.WindowState = FormWindowState.Normal
        frmCompras.Show()

    End Sub
    '------------------------'
    '-- VALIDAR LAS FECHAS --'
    '------------------------'
    Private Sub maskVence_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskVence.KeyDown
        ToolTip1.Hide(maskVence)
    End Sub

    Private Sub maskVence_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles maskVence.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub maskVence_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskVence.TypeValidationCompleted
        Dim strPrueba As String = maskVence.Text
        '-- solo hacer el procedimiento si la primera expresion es numerica
        If IsNumeric(strPrueba.Substring(0, 1)) Then
            If Len(maskVence.Text) > 0 Then

                'strPrueba.su()
                'MsgBox("Valor de la mascara  " & strPrueba, MsgBoxStyle.Information)
                If (Not e.IsValidInput) Then
                    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    ToolTip1.Show("Debe introducir una fecha con formato .", maskVence, 70, -70, 700)
                    e.Cancel = True
                Else
                    Dim userdate As DateTime = CDate(e.ReturnValue)
                    ' controlar que la fecha no sea menor a la fecha del servidor
                    '-- colocar en una variable la fecha devuelta por el servidor
                    Dim datFechaServidor As Date
                    datFechaServidor = sp_datosTabla.sp_string("sp_fechaServer", "")
                    'MsgBox("Fecha del servidor  " & datFechaServidor.ToString)
                    'If (userdate < datFechaServidor) Then
                    '    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    '    ToolTip1.Show("La fecha debe ser mayor a la fecha actual del sistema.", maskVence, 0, -20, 5000)
                    '    e.Cancel = True
                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub maskFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskFecha.KeyDown
        ToolTip1.Hide(maskVence)
    End Sub

    Private Sub maskFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles maskFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub maskFecha_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskFecha.TypeValidationCompleted
        Dim strPrueba As String = maskFecha.Text
        '-- solo hacer el procedimiento si la primera expresion es numerica
        If IsNumeric(strPrueba.Substring(0, 1)) Then
            If Len(maskFecha.Text) > 0 Then
                If (Not e.IsValidInput) Then
                    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    ToolTip1.Show("Debe introducir una fecha con formato .", maskFecha, 70, -70, 700)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------
    '*********'
    '-- CHK --'
    '*********'
    Private Sub chkCredito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCredito.Click
        If chkCredito.Checked = True Then
            maskVence.Enabled = True
            maskVence.BackColor = Color.White
            chkEfectivo.Checked = False
            maskVence.Focus()
        Else
            maskVence.Enabled = False
            maskVence.BackColor = Color.LightBlue
            chkEfectivo.Checked = True
            maskFecha.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    '-- solo numericos para la cotizacion
    Private Sub txtCotizacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCotizacion.KeyPress
        e.Handled = txtSoloNumerico(txtCotizacion, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '----------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmGuardarCompra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmCompras.Enabled = True
        frmCompras.WindowState = FormWindowState.Normal
        frmCompras.Show()
    End Sub

    Private Sub frmGuardarCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- la fecha de la factura
        maskFecha.Mask = "00/00/0000"
        maskVence.ValidatingType = GetType(System.DateTime)
        ToolTip1.IsBalloon = True
        '-- la fecha de vencimiento
        maskVence.Mask = "00/00/0000"
        maskVence.ValidatingType = GetType(System.DateTime)
        ToolTip1.IsBalloon = True
    End Sub
    '----------------------------------------------------------------------------------
End Class