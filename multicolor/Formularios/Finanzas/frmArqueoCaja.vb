Public Class frmArqueoCaja
    '******************************'
    '-- VARIABLES DE TIPO OBJETO --'
    '******************************'
    Dim moneda As New moneda
    Dim systemClas As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_IngresoSistema As New sp_IngresoSistema
    '*************************'
    '-- VARIABLES ESCALARES --'
    '*************************'
    Dim ban_error As Boolean
    Dim intTmpExisteVenta As Boolean

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub inicializar()
        'limpiar()
        '-- colocar los datos iniciales
        controlarVentaSucursal()
    End Sub

    Public Sub limpiar()
        '-- limpiar los txt
        txtAbierto.Text = ""
        txtDeposito.Text = ""
        txtFechaFinal.Text = ""
        txtFechaIncial.Text = ""
        txtIdSucursal.Text = 0
        txtSucursal.Text = ""
        txtTotalCheque.Text = 0
        txtTotalCredito.Text = 0
        txtTotalGasto.Text = 0
        txtTotalGuaranies.Text = 0
        txtTotalMoneda.Text = 0
        txtTotalTarjetaCredito.Text = 0
        txtTotalTarjetaDebito.Text = 0
        txtTotalWeb.Text = 0
        txtMovini1.Text = 0
        txtMovFin2.Text = 0
        txtMoviFin1.Text = 0
        txtMovini2.Text = 0
        '-- los txt de nro
        txtNroCheque.Text = 0
        txtNroCredito.Text = 0
        txtNroGasto.Text = 0
        txtNroGuaranies.Text = 0
        txtNroMoneda.Text = 0
        txtNroTarjetaCredito.Text = 0
        txtNroTarjetaDebito.Text = 0
        txtNroWeb.Text = 0
        '-- limpiar las grillas
        dtgCheque.Rows.Clear()
        dtgCredito.Rows.Clear()
        dtgGasto.Rows.Clear()
        dtgGuaranies.Rows.Clear()
        dtgMoneda.Rows.Clear()
        dtgTarjetaCredito.Rows.Clear()
        dtgTarjetaDebito.Rows.Clear()
        dtgWeb.Rows.Clear()
        '-- los datos de la sucursal
        txtSucursal.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_sucursal", "idSucursal", intGl_idSucursal)
        txtIdSucursal.Text = intGl_idSucursal
        '-- los datos del deposito
        txtDeposito.Text = sp_datosTabla.un_datoString("nombreDeposito", "deposito", "idSucursal", intGl_idSucursal)
        txtIdDeposito.Text = sp_datosTabla.un_dato_integer("idDeposito", "deposito", "idSucursal", intGl_idSucursal)
        '-- datos del usuario que abrió la caja
        txtAbierto.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", intGl_idUsuario)
        '-- datos de la fecha y hora del servidor que se abrió el arqueo
        sp_IngresoSistema.fechaHoraServer()
        txtFechaIncial.Text = Trim(strGl_fechaHoraServer)
        '-- datos de los movimientos iniciales
        txtMovini1.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 0)
        txtMovini2.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 1)
        '-- los formatos
        txtMovini1.Text = Format(CDec(txtMovini1.Text), "#,###,###")
        txtMovini2.Text = Format(CDec(txtMovini2.Text), "#,###,###")

        txtMovFin2.Text = 0
        txtMoviFin1.Text = 0
    End Sub

    '-- procedimiento para controlar y agregar todos los registros de las cajas
    Private Sub controlarArqueo()
        If IsNumeric(txtTotalArqueo.Text) Then
            '-- ver si no existe un total a ingresar
            If CInt(txtTotalArqueo.Text) <= 0 Then
                MessageBox.Show("No existe ningún total para guardar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'btnGuardar.Enabled = False
                ban_error = True
            Else
                btnGuardar.Enabled = True
            End If

            '-- controlar los montos
            sp_datosTabla.consulta_valor("delete from detCajaMontoTmp where idSucursal=" & intGl_idSucursal)
            Dim intTmpIdMonto As Integer
            Dim strTmpMonto As String
            Dim intTmpCantidad As Integer
            For i As Integer = 0 To dtgGuaranies.Rows.Count - 1
                If dtgGuaranies.Rows(i).Cells(4).Value > 0 Then
                    '-- canvertir a moneda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgGuaranies.Rows(i).Cells(2).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '-----------------------------------
                    intTmpIdMonto = sp_datosTabla.un_dato_integer("idMonto", "monto", "monto", dtgGuaranies.Rows(i).Cells(2).Value)
                    intTmpCantidad = dtgGuaranies.Rows(i).Cells(0).Value
                    sp_datosTabla.sp_string("sp_guardarArqueoMonto", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdMonto & "," & intTmpCantidad)
                End If
            Next
            '-------------------------------------------------
            '-- controlar las monedas
            sp_datosTabla.consulta_valor("delete from detCajaMonedaTmp where idSucursal=" & intGl_idSucursal)
            Dim intTmpIdMoneda As Integer
            Dim strTmpCotiza As String
            For i As Integer = 0 To dtgMoneda.Rows.Count - 1
                If dtgMoneda.Rows(i).Cells(3).Value > 0 Then
                    intTmpIdMoneda = CInt(sp_datosTabla.un_datoString("idMoneda", "moneda", "nombreMoneda", Trim(dtgMoneda.Rows(i).Cells(1).Value.ToString)))
                    '-- convertir a moenda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgMoneda.Rows(i).Cells(0).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '-- convertir a moneda la cotizacion
                    strTmpCotiza = CStr(convertirNumeroDecimal(dtgMoneda.Rows(i).Cells(4).Value.ToString))
                    strTmpCotiza = strTmpCotiza.Replace(",", ".")
                    '----------------------------
                    sp_datosTabla.sp_string("sp_guardarArqueoMoneda", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdMoneda & "," & strTmpMonto & "," & strTmpCotiza)
                End If
            Next
            '---------------------------------------------------
            '-- controlar los gastos
            sp_datosTabla.consulta_valor("delete from detCajaGastoTmp where idSucursal=" & intGl_idSucursal)
            Dim intTmpFactura As Integer
            Dim strTmpConcepto As String
            For i As Integer = 0 To dtgGasto.Rows.Count - 1
                If dtgGasto.Rows(i).Cells(3).Value > 0 Then
                    intTmpFactura = dtgGasto.Rows(i).Cells(0).Value
                    strTmpConcepto = dtgGasto.Rows(i).Cells(2).Value
                    '-- convertir a moneda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgGasto.Rows(i).Cells(1).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '--------------------------------
                    sp_datosTabla.sp_string("sp_guardarArqueoGasto", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpFactura & "," & strTmpMonto & "," & "'" & Trim(strTmpConcepto.ToString) & "'")
                End If
            Next
            '-----------------------------------------------------
            '-- controlar los creditos
            sp_datosTabla.consulta_valor("delete from detCajaCreditoTmp where idSucursal=" & intGl_idSucursal)
            For i As Integer = 0 To dtgCredito.Rows.Count - 1
                If dtgCredito.Rows(i).Cells(2).Value > 0 Then
                    intTmpFactura = dtgCredito.Rows(i).Cells(0).Value
                    '-- convertir a moneda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgCredito.Rows(i).Cells(1).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '--------------------------------------------------
                    sp_datosTabla.sp_string("sp_guardarArqueoCredito", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpFactura & "," & strTmpMonto)
                End If
            Next
            '-----------------------------------------------------
            '-- controlar los cheques
            sp_datosTabla.consulta_valor("delete from detCajaChequeTmp where idSucursal=" & intGl_idSucursal)
            Dim intTmpNroCheque As Integer
            Dim strTmpFechaCheque As String
            For i As Integer = 0 To dtgCheque.Rows.Count - 1
                If dtgCheque.Rows(i).Cells(3).Value > 0 Then
                    intTmpNroCheque = dtgCheque.Rows(i).Cells(0).Value
                    '-- convertir a moneda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgCheque.Rows(i).Cells(1).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '---------------------------------------------
                    strTmpFechaCheque = dtgCheque.Rows(i).Cells(2).Value
                    If (fun_guardarSp("sp_guardarArqueoCheque", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpNroCheque & "," & "'" & strTmpFechaCheque & "'" & "," & strTmpMonto, Me.Name)) = 0 Then
                        '-- no se guardo los registros
                        MessageBox.Show("No se pudo Agregar los cheques...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ban_error = True
                        Exit Sub
                    End If
                End If
            Next
            '-------------------------------------------------------
            '-- controlar la tarjeta de credito
            sp_datosTabla.consulta_valor("delete from detCajaTarjetaCreditoTmp where idSucursal=" & intGl_idSucursal)
            Dim intTmpIdTarjeta As Integer
            For i As Integer = 0 To dtgTarjetaCredito.Rows.Count - 1
                If dtgTarjetaCredito.Rows(i).Cells(2).Value > 0 Then
                    intTmpIdTarjeta = CInt(sp_datosTabla.un_datoString("idTarjeta", "tarjeta", "nombreTarjeta", Trim(dtgTarjetaCredito.Rows(i).Cells(0).Value.ToString)))
                    '-- convertir a moneda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgTarjetaCredito.Rows(i).Cells(1).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '----------------------------------------------
                    sp_datosTabla.sp_string("sp_guardarArqueoTarjetaCredito", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdTarjeta & "," & strTmpMonto)
                End If
            Next
            '--------------------------------------------------------
            '-- controlar la tarjeta de debito
            sp_datosTabla.consulta_valor("delete from detCajaTarjetaDebitoTmp where idSucursal=" & intGl_idSucursal)
            Dim intTmpIdTarjetaDe As Integer
            For i As Integer = 0 To dtgTarjetaDebito.Rows.Count - 1
                If dtgTarjetaDebito.Rows(i).Cells(2).Value > 0 Then
                    intTmpIdTarjetaDe = CInt(sp_datosTabla.un_datoString("idTarjetaDe", "tarjetaDebito", "nombreTarjetaDebito", Trim(dtgTarjetaDebito.Rows(i).Cells(0).Value.ToString)))
                    '-- convertir a moneda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgTarjetaDebito.Rows(i).Cells(1).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '---------------------------------------------------------------
                    sp_datosTabla.sp_string("sp_guardarArqueoTarjetaDebito", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdTarjetaDe & "," & strTmpMonto)

                End If
            Next
            '-------------------------------------------------------
            '-- controlar la compra via web
            sp_datosTabla.consulta_valor("delete from detCajaWebTmp where idSucursal=" & intGl_idSucursal)
            Dim intTmpNroAutoriza As Integer
            For i As Integer = 0 To dtgWeb.Rows.Count - 1
                If dtgWeb.Rows(i).Cells(2).Value > 0 Then
                    intTmpNroAutoriza = CInt(convertirNumeroDecimal(dtgWeb.Rows(i).Cells(0).Value.ToString))
                    '-- convertir a moneda el monto
                    strTmpMonto = CStr(convertirNumeroDecimal(dtgWeb.Rows(i).Cells(1).Value.ToString))
                    strTmpMonto = strTmpMonto.Replace(",", ".")
                    '----------------------------------------------
                    sp_datosTabla.sp_string("sp_guardarArqueoWeb", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpNroAutoriza & "," & strTmpMonto)
                End If
            Next
            '--------------------------------------------'
            '-- CONTROLAR SI HAY MAXIPUNTOS PENDIENTES --'
            '--------------------------------------------'
            If sp_datosTabla.consulta_valor("select idConfig from tmpMenuRestoMaxiPunto where idConfig=" & intGl_idConfigPc) > 0 Then
                MessageBox.Show("Existen maxipuntos pendientes a facturar. No puede cerrar su caja..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ban_error = True
            End If

        Else
            MessageBox.Show("No existe ningún total para guardar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    '-- controlar si existe movimientos para esta sucursal
    Private Sub controlarVentaSucursal()

        intTmpExisteVenta = sp_datosTabla.sp_traerValor("sp_controlarCaja", intGl_idSucursal, 0)
        If intTmpExisteVenta = False Then
            MessageBox.Show("No existe ninguna Venta para realizar el arqueo de caja..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnGuardar.Enabled = False
            btnParar.Enabled = False
        Else
            btnGuardar.Enabled = True
            btnParar.Enabled = True
            '-- traer los primeros id de las ventas
            txtMovini1.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 0)
            txtMovini2.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 1)
            '-- los formatos
            txtMovini1.Text = Format(CInt(txtMovini1.Text), "#,###,##0")
            txtMovini2.Text = Format(CInt(txtMovini2.Text), "#,###,##0")
        End If
    End Sub

    '-- sumar los totales
    Private Sub totalArqueo()
        '-- el total de guaranies
        Dim douTmpTotalGuaranies As Double
        For i As Integer = 0 To dtgGuaranies.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If dtgGuaranies.Rows(i).Cells(4).Value > 0 Then
                douTmpTotalGuaranies = douTmpTotalGuaranies + dtgGuaranies.Rows(i).Cells(3).Value
            End If
        Next
        '-----------------------------------------
        '-- el total de monedas
        Dim douTmpTotalMoneda As Double
        For i As Integer = 0 To dtgMoneda.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If dtgMoneda.Rows(i).Cells(3).Value > 0 Then
                douTmpTotalMoneda = douTmpTotalMoneda + dtgMoneda.Rows(i).Cells(2).Value
            End If
        Next
        '-----------------------------------------
        '-- el total de gastos
        Dim douTmpTotalGasto As Double
        For i As Integer = 0 To dtgGasto.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If Len(dtgGasto.Rows(i).Cells(3).Value) > 0 Then
                douTmpTotalGasto = douTmpTotalGasto + dtgGasto.Rows(i).Cells(1).Value
            End If
        Next
        '-----------------------------------------
        '-- el total de creditos
        Dim douTmpTotalCredito As Double
        For i As Integer = 0 To dtgCredito.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If Len(dtgCredito.Rows(i).Cells(2).Value) > 0 Then
                douTmpTotalCredito = douTmpTotalCredito + dtgCredito.Rows(i).Cells(1).Value
            End If
        Next
        '-----------------------------------------
        '-- el total de cheques
        Dim douTmpTotalCheque As Double
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If Len(dtgCheque.Rows(i).Cells(3).Value) > 0 Then
                douTmpTotalCheque = douTmpTotalCheque + dtgCheque.Rows(i).Cells(1).Value
            End If
        Next
        '----------------------------------------
        '-- el total de tarjeta de credito
        Dim douTmpTotalTarjetaCredito As Double
        For i As Integer = 0 To dtgTarjetaCredito.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If Len(dtgTarjetaCredito.Rows(i).Cells(2).Value) > 0 Then
                douTmpTotalTarjetaCredito = douTmpTotalTarjetaCredito + dtgTarjetaCredito.Rows(i).Cells(1).Value
            End If
        Next
        '---------------------------------------
        '-- el total de tarjeta de debito
        Dim douTmpTotalTarjetaDebito As Double
        For i As Integer = 0 To dtgTarjetaDebito.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If Len(dtgTarjetaDebito.Rows(i).Cells(2).Value) > 0 Then
                douTmpTotalTarjetaDebito = douTmpTotalTarjetaDebito + dtgTarjetaDebito.Rows(i).Cells(1).Value
            End If
        Next
        '---------------------------------------
        '-- el total de compra via web
        Dim douTmpTotalWeb As Double
        For i As Integer = 0 To dtgWeb.Rows.Count - 1
            '-- realizar los calculos solo si existem items cargados
            If Len(dtgWeb.Rows(i).Cells(2).Value) > 0 Then
                douTmpTotalWeb = douTmpTotalWeb + dtgWeb.Rows(i).Cells(1).Value
            End If
        Next
        '-------------------------------------
        '-- los totales
        '- cheque
        txtTotalCheque.Text = douTmpTotalCheque
        txtTotalCheque.Text = Format(CDec(txtTotalCheque.Text), "#,###,##0")
        '- credito
        txtTotalCredito.Text = douTmpTotalCredito
        txtTotalCredito.Text = Format(CDec(txtTotalCredito.Text), "#,###,##0")
        '- gastos
        txtTotalGasto.Text = douTmpTotalGasto
        txtTotalGasto.Text = Format(CDec(txtTotalGasto.Text), "#,###,##0")
        '- guaranies
        txtTotalGuaranies.Text = douTmpTotalGuaranies
        txtTotalGuaranies.Text = Format(CDec(txtTotalGuaranies.Text), "#,###,##0")
        '- monedas
        txtTotalMoneda.Text = douTmpTotalMoneda
        txtTotalMoneda.Text = Format(CDec(txtTotalMoneda.Text), "#,###,##0.##")
        '- tarjeta de credito
        txtTotalTarjetaCredito.Text = douTmpTotalTarjetaCredito
        txtTotalTarjetaCredito.Text = Format(CDec(txtTotalTarjetaCredito.Text), "#,###,##0")
        '- tarjeta de debito
        txtTotalTarjetaDebito.Text = douTmpTotalTarjetaDebito
        txtTotalTarjetaDebito.Text = Format(CDec(txtTotalTarjetaDebito.Text), "#,###,##0")
        '- compra via web
        txtTotalWeb.Text = douTmpTotalWeb
        txtTotalWeb.Text = Format(CDec(txtTotalWeb.Text), "#,###,##0")

        '-- el total general
        txtTotalArqueo.Text = douTmpTotalCheque + douTmpTotalCredito + douTmpTotalGasto + douTmpTotalGuaranies + douTmpTotalMoneda + douTmpTotalTarjetaCredito + douTmpTotalTarjetaDebito + douTmpTotalWeb
        txtTotalArqueo.Text = Format(CDec(txtTotalArqueo.Text), "###,###,##0")
    End Sub
    '------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnParar_Click(sender As System.Object, e As System.EventArgs) Handles btnParar.Click
        If MessageBox.Show("Desea Parar los movimientos de Facturación de esta caja..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            btnParar.Enabled = False
            controlarVentaSucursal()
            If intTmpExisteVenta = True Then
                '-- realizar los nros de movimiento
                txtMovini1.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 0)
                txtMoviFin1.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 2)
                txtMovini2.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 1)
                txtMovFin2.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 3)
                '-- los formatos
                txtMovini1.Text = Format(CInt(txtMovini1.Text), "#,###,##0")
                txtMoviFin1.Text = Format(CInt(txtMoviFin1.Text), "#,###,##0")
                txtMovini2.Text = Format(CInt(txtMovini2.Text), "#,###,##0")
                txtMovFin2.Text = Format(CInt(txtMovFin2.Text), "#,###,##0")
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        '- controlar los datos
        controlarArqueo()
        If ban_error = False Then
            If MessageBox.Show("Desea Guardar La Caja..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                btnGuardar.Enabled = False
                btnParar.Enabled = False
                controlarVentaSucursal()
                If intTmpExisteVenta = True Then
                    '-- realizar los nros de movimiento
                    '-- realizar los nros de movimiento
                    txtMovini1.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 0)
                    txtMoviFin1.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 2)
                    txtMovini2.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 1)
                    txtMovFin2.Text = sp_datosTabla.sp_traerValor("sp_traerMovimientoDeVenta", intGl_idSucursal, 3)
                    '-- los formatos
                    txtMovini1.Text = Format(CInt(txtMovini1.Text), "#,###,##0")
                    txtMoviFin1.Text = Format(CInt(txtMoviFin1.Text), "#,###,##0")
                    txtMovini2.Text = Format(CInt(txtMovini2.Text), "#,###,##0")
                    txtMovFin2.Text = Format(CInt(txtMovFin2.Text), "#,###,##0")
                End If
                '-- el formulario de los personales
                Me.Enabled = False
                '-- eliminar los registros pendientes de la tabla temporal
                sp_datosTabla.consulta_valor("delete from detCajaPersonalTmp where idConfig=" & intGl_idConfigPc)

                '-- colocar los valores al formulario
                frmCerrarArqueo.txtMovini1.Text = txtMovini1.Text
                frmCerrarArqueo.txtMovini2.Text = txtMovini2.Text
                frmCerrarArqueo.txtMoviFin1.Text = txtMoviFin1.Text
                frmCerrarArqueo.txtMovFin2.Text = txtMovFin2.Text
                frmCerrarArqueo.txtTotalArqueo.Text = txtTotalArqueo.Text

                frmCerrarArqueo.Visible = True
                frmCerrarArqueo.Show()
                frmCerrarArqueo.BringToFront()
                '-- procedimiento para guardar el arqueo
                'guardarArqueo()
            End If
        End If

    End Sub
    '------------------------------------------------------------------------------------------------------
    '******************'
    ' GRILLA GUARANIES '
    '******************'
    Private Sub dtgGuaranies_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgGuaranies.CellFormatting
        '-- el formato del monto
        If dtgGuaranies.Columns(e.ColumnIndex).Name.Equals("Column1") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("###,###")
        End If
        '-- el formato del total
        If dtgGuaranies.Columns(e.ColumnIndex).Name.Equals("Column2") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("##,###,###")
        End If
    End Sub

    Private Sub dtgGuaranies_GotFocus(sender As Object, e As System.EventArgs) Handles dtgGuaranies.GotFocus
        For i As Integer = 0 To dtgGuaranies.Rows.Count - 1
            If dtgGuaranies.Rows(i).Cells(4).Value > 0 Then
                dtgGuaranies.Rows(i).Cells(0).ReadOnly = False
            Else
                dtgGuaranies.Rows(i).Cells(0).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgGuaranies_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgGuaranies.RowEnter
        Dim row As DataGridViewRow = dtgGuaranies.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroGuaranies.Text = CInt(row.Cells(4).Value)
    End Sub

    Private Sub dtgGuaranies_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgGuaranies.SelectionChanged
        For i As Integer = 0 To dtgGuaranies.Rows.Count - 1
            '-- solo si es numerico el item ingresado
            If IsNumeric(dtgGuaranies.Rows(i).Cells(0).Value) Then
                If dtgGuaranies.Rows(i).Cells(2).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgGuaranies.Rows(i).Cells(0).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgGuaranies.Rows(i).Cells(0).Value = 1
                    End If
                    '-- multiplicar los valores para el valor
                    dtgGuaranies.Rows(i).Cells(3).Value = dtgGuaranies.Rows(i).Cells(0).Value * dtgGuaranies.Rows(i).Cells(2).Value
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                dtgGuaranies.Rows(i).Cells(0).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If
        Next
    End Sub

    Private Sub btnCargarGuaranies_Click(sender As System.Object, e As System.EventArgs) Handles btnCargarGuaranies.Click
        Me.Enabled = False
        frmMonto.Visible = True
        frmMonto.Show()
        frmMonto.BringToFront()
    End Sub

    Private Sub btnEliminarGuaranies_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarGuaranies.Click
        If txtNroGuaranies.Text.Length > 0 Then
            If CInt(txtNroGuaranies.Text) > 0 Then
                If dtgGuaranies.SelectedCells.Count > 0 Then
                    dtgGuaranies.Rows.Remove(dtgGuaranies.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoGuaranies = intGl_nroArqueoGuaranies - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If

    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------------------
    '****************'
    ' GRILLA MONEDAS '
    '****************'
    Private Sub dtgMoneda_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgMoneda.CellFormatting
        '-- el formato del monto
        If dtgMoneda.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn1") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("###,###.##")
        End If
        '-- el formato del total
        If dtgMoneda.Columns(e.ColumnIndex).Name.Equals("Column4") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.Format = ("##,###,###.##")
        End If
    End Sub

    Private Sub dtgMoneda_GotFocus(sender As Object, e As System.EventArgs) Handles dtgMoneda.GotFocus
        For i As Integer = 0 To dtgMoneda.Rows.Count - 1
            If dtgMoneda.Rows(i).Cells(3).Value > 0 Then
                dtgMoneda.Rows(i).Cells(0).ReadOnly = False
            Else
                dtgMoneda.Rows(i).Cells(0).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgMoneda_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMoneda.RowEnter
        Dim row As DataGridViewRow = dtgMoneda.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroMoneda.Text = CInt(row.Cells(3).Value)
    End Sub

    Private Sub dtgMoneda_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgMoneda.SelectionChanged
        For i As Integer = 0 To dtgMoneda.Rows.Count - 1
            If IsNumeric(dtgMoneda.Rows(i).Cells(0).Value) Then
                If dtgMoneda.Rows(i).Cells(0).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgMoneda.Rows(i).Cells(0).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgMoneda.Rows(i).Cells(0).Value = 1
                    End If
                    '-- multiplicar los valores para el valor
                    dtgMoneda.Rows(i).Cells(2).Value = formatoNumerosDecimales(dtgMoneda.Rows(i).Cells(0).Value * dtgMoneda.Rows(i).Cells(4).Value)
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                dtgMoneda.Rows(i).Cells(0).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If
        Next
    End Sub

    Private Sub btnAgregarMoneda_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarMoneda.Click
        Me.Enabled = False
        frmMoneda.Visible = True
        frmMoneda.Show()
        frmMoneda.BringToFront()
    End Sub

    Private Sub btnEliminarMoneda_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarMoneda.Click
        If txtNroMoneda.Text.Length > 0 Then
            If CInt(txtNroMoneda.Text) > 0 Then
                If dtgMoneda.SelectedCells.Count > 0 Then
                    dtgMoneda.Rows.Remove(dtgMoneda.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoMoneda = intGl_nroArqueoMoneda - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If
    End Sub

    '********************************************************************************************************************************
    '***************'
    ' GRILLA GASTOS '
    '***************'
    Private Sub dtgGasto_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgGasto.CellFormatting
        '-- el formato de la factura
        If dtgGasto.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn2") Then
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- el formato del concepto
        If dtgGasto.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn4") Then
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgGasto_GotFocus(sender As Object, e As System.EventArgs) Handles dtgGasto.GotFocus
        For i As Integer = 0 To dtgGasto.Rows.Count - 1
            If dtgGasto.Rows(i).Cells(3).Value > 0 Then
                dtgGasto.Rows(i).Cells(1).ReadOnly = False
                dtgGasto.Rows(i).Cells(0).ReadOnly = False
                dtgGasto.Rows(i).Cells(2).ReadOnly = False
            Else
                dtgGasto.Rows(i).Cells(1).ReadOnly = True
                dtgGasto.Rows(i).Cells(0).ReadOnly = True
                dtgGasto.Rows(i).Cells(2).ReadOnly = True
            End If
        Next

    End Sub

    Private Sub dtgGasto_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgGasto.RowEnter
        Dim row As DataGridViewRow = dtgGasto.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroGasto.Text = CInt(row.Cells(3).Value)
    End Sub

    Private Sub dtgGasto_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgGasto.SelectionChanged

        For i As Integer = 0 To dtgGasto.Rows.Count - 1
            '-- si no es numerico no dejar introducir
            If IsNumeric(dtgGasto.Rows(i).Cells(0).Value) Then
                If dtgGasto.Rows(i).Cells(0).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgGasto.Rows(i).Cells(0).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgGasto.Rows(i).Cells(0).Value = 1
                    End If
                    '-- dar formato al numero ingresado
                    dtgGasto.Rows(i).Cells(1).Value = formatoNumerosDecimales(dtgGasto.Rows(i).Cells(1).Value)
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                'dtgGasto.Rows(i).Cells(0).Value = 1
                'dtgGasto.Rows(i).Cells(1).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If
            '-- evitar agregar mas filas
            'dtgGasto.AllowUserToAddRows = False
        Next
    End Sub

    Private Sub btnAgregarGasto_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarGasto.Click
        dtgGasto.AllowUserToAddRows = True
        intGl_nroArqueoGasto = intGl_nroArqueoGasto + 1
        cargarArqueoGasto(intGl_nroArqueoGasto, 1, 1, "")
        dtgGasto.Focus()
    End Sub

    Private Sub btnEliminarGasto_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarGasto.Click
        If txtNroGasto.Text.Length > 0 Then
            If CInt(txtNroGasto.Text) > 0 Then
                If dtgGasto.SelectedCells.Count > 0 Then
                    dtgGasto.Rows.Remove(dtgGasto.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoGasto = intGl_nroArqueoGasto - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If
    End Sub

    '************************************************************************************************************************************
    '*****************'
    ' GRILLA CREDITOS '
    '*****************'
    Private Sub dtgCredito_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCredito.CellFormatting
        '-- el formato del monto
        If dtgCredito.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn10") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgCredito_GotFocus(sender As Object, e As System.EventArgs) Handles dtgCredito.GotFocus
        For i As Integer = 0 To dtgCredito.Rows.Count - 1
            If dtgCredito.Rows(i).Cells(2).Value > 0 Then
                dtgCredito.Rows(i).Cells(1).ReadOnly = False
                dtgCredito.Rows(i).Cells(0).ReadOnly = False
            Else
                dtgCredito.Rows(i).Cells(1).ReadOnly = True
                dtgCredito.Rows(i).Cells(0).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgCredito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCredito.RowEnter
        Dim row As DataGridViewRow = dtgCredito.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroCredito.Text = CInt(row.Cells(2).Value)
    End Sub

    Private Sub dtgCredito_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgCredito.SelectionChanged
        For i As Integer = 0 To dtgCredito.Rows.Count - 1
            If IsNumeric(dtgCredito.Rows(i).Cells(1).Value) Then
                If dtgCredito.Rows(i).Cells(1).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgCredito.Rows(i).Cells(1).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCredito.Rows(i).Cells(1).Value = 1
                    End If
                    '-- el formato del monto
                    dtgCredito.Rows(i).Cells(1).Value = formatoNumerosDecimales(dtgCredito.Rows(i).Cells(1).Value)
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                dtgCredito.Rows(i).Cells(1).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If
        Next
    End Sub

    Private Sub btnAgregarCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarCredito.Click
        intGl_nroArqueoCredito = intGl_nroArqueoCredito + 1
        cargarArqueoCredito(intGl_nroArqueoCredito, 1, 1)
        dtgCredito.Focus()
    End Sub

    Private Sub btnEliminarCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCredito.Click
        If txtNroCredito.Text.Length > 0 Then
            If CInt(txtNroCredito.Text) > 0 Then
                If dtgCredito.SelectedCells.Count > 0 Then
                    dtgCredito.Rows.Remove(dtgCredito.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoCredito = intGl_nroArqueoCredito - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If
    End Sub

    '************************************************************************************************************************************
    '****************'
    ' GRILLA CHEQUES '
    '****************'
    Private Sub dtgCheque_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgCheque.CellFormatting
        '-- el formato del nro del cheque
        If dtgCheque.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn11") Then
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- el formato del monto
        If dtgCheque.Columns(e.ColumnIndex).Name.Equals("Column5") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
        '-- el formato de la fecha
        If dtgCheque.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn12") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgCheque_GotFocus(sender As Object, e As System.EventArgs) Handles dtgCheque.GotFocus
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            If dtgCheque.Rows(i).Cells(3).Value > 0 Then
                dtgCheque.Rows(i).Cells(0).ReadOnly = False
                dtgCheque.Rows(i).Cells(1).ReadOnly = False
                dtgCheque.Rows(i).Cells(2).ReadOnly = False
            Else
                dtgCheque.Rows(i).Cells(0).ReadOnly = True
                dtgCheque.Rows(i).Cells(1).ReadOnly = True
                dtgCheque.Rows(i).Cells(2).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgCheque_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgCheque.RowEnter
        Dim row As DataGridViewRow = dtgCheque.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroCheque.Text = CInt(row.Cells(3).Value)
    End Sub

    Private Sub dtgCheque_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgCheque.SelectionChanged
        For i As Integer = 0 To dtgCheque.Rows.Count - 1
            If IsNumeric(dtgCheque.Rows(i).Cells(0).Value) And IsNumeric(dtgCheque.Rows(i).Cells(1).Value) Then
                If dtgCheque.Rows(i).Cells(1).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgCheque.Rows(i).Cells(1).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgCheque.Rows(i).Cells(1).Value = 1
                    End If
                    '-- el formato del monto
                    dtgCheque.Rows(i).Cells(1).Value = formatoNumerosDecimales(dtgCheque.Rows(i).Cells(1).Value)
                    If Len(dtgCheque.Rows(i).Cells(2).Value) > 0 Then
                        Dim intTmpTotalFecha As Integer = 0
                        intTmpTotalFecha = CInt(CStr(dtgCheque.Rows(i).Cells(2).Value).Substring(0, 1)) + CInt(CStr(dtgCheque.Rows(i).Cells(2).Value).Substring(1, 1))
                        If intTmpTotalFecha > 0 Then
                            '-- dar formato a la fecha ingresada
                            dtgCheque.Rows(i).Cells(2).Value = formatoFecha_ochoLugares(dtgCheque.Rows(i).Cells(2).Value)
                            '-- controlar la fecha ingresada
                            If controlarFecha_ochoLugares(dtgCheque.Rows(i).Cells(2).Value) = False Then
                                dtgCheque.Rows(i).Cells(2).Value = ""
                            End If
                        End If
                    End If
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                dtgCheque.Rows(i).Cells(0).Value = 1
                dtgCheque.Rows(i).Cells(1).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If
        Next
    End Sub

    Private Sub btnAgregarCheque_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarCheque.Click
        intGl_nroArqueoCheque = intGl_nroArqueoCheque + 1
        cargarArqueoCheque(intGl_nroArqueoCheque, 1, 1, "")
        dtgCheque.Focus()
    End Sub

    Private Sub btnEliminarCheque_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCheque.Click
        If txtNroCheque.Text.Length > 0 Then
            If CInt(txtNroCheque.Text) > 0 Then
                If dtgCheque.SelectedCells.Count > 0 Then
                    dtgCheque.Rows.Remove(dtgCheque.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoCheque = intGl_nroArqueoCheque - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If
    End Sub

    '*************************************************************************************************************************************
    '***************************'
    ' GRILLA TARJETA DE CREDITO '
    '***************************'
    Private Sub dtgTarjetaCredito_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgTarjetaCredito.CellFormatting
        '-- el formato del monto
        If dtgTarjetaCredito.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn8") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgTarjetaCredito_GotFocus(sender As Object, e As System.EventArgs) Handles dtgTarjetaCredito.GotFocus
        For i As Integer = 0 To dtgTarjetaCredito.Rows.Count - 1
            If dtgTarjetaCredito.Rows(i).Cells(2).Value > 0 Then
                dtgTarjetaCredito.Rows(i).Cells(1).ReadOnly = False
            Else
                dtgTarjetaCredito.Rows(i).Cells(1).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgTarjetaCredito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTarjetaCredito.RowEnter
        Dim row As DataGridViewRow = dtgTarjetaCredito.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroTarjetaCredito.Text = CInt(row.Cells(2).Value)
    End Sub

    Private Sub dtgTarjetaCredito_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgTarjetaCredito.SelectionChanged
        For i As Integer = 0 To dtgTarjetaCredito.Rows.Count - 1
            If IsNumeric(dtgTarjetaCredito.Rows(i).Cells(1).Value) Then
                If dtgTarjetaCredito.Rows(i).Cells(1).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgTarjetaCredito.Rows(i).Cells(1).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgTarjetaCredito.Rows(i).Cells(1).Value = 1
                    End If
                    '-- el formato del monto
                    dtgTarjetaCredito.Rows(i).Cells(1).Value = formatoNumerosDecimales(dtgTarjetaCredito.Rows(i).Cells(1).Value)
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                dtgTarjetaCredito.Rows(i).Cells(1).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If
        Next
    End Sub

    Private Sub btnAgregarTarjetaCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTarjetaCredito.Click
        Me.Enabled = False
        frmTarjetaCreditoCaja.Visible = True
        frmTarjetaCreditoCaja.Show()
        frmTarjetaCreditoCaja.BringToFront()
    End Sub

    Private Sub btnEliminarTarjetaCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarTarjetaCredito.Click
        If txtNroTarjetaCredito.Text.Length > 0 Then
            If CInt(txtNroTarjetaCredito.Text) > 0 Then
                If dtgTarjetaCredito.SelectedCells.Count > 0 Then
                    dtgTarjetaCredito.Rows.Remove(dtgTarjetaCredito.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoTarjetaCredito = intGl_nroArqueoTarjetaCredito - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If
    End Sub

    '**************************************************************************************************************************************
    '**************************'
    ' GRILLA TARJETA DE DEBITO '
    '**************************'
    Private Sub dtgTarjetaDebito_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgTarjetaDebito.CellFormatting
        '-- el formato del monto
        If dtgTarjetaDebito.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn6") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
            ' e.CellStyle.Format = ("##,###,###")
        End If
    End Sub

    Private Sub dtgTarjetaDebito_GotFocus(sender As Object, e As System.EventArgs) Handles dtgTarjetaDebito.GotFocus
        For i As Integer = 0 To dtgTarjetaDebito.Rows.Count - 1
            If dtgTarjetaDebito.Rows(i).Cells(2).Value > 0 Then
                dtgTarjetaDebito.Rows(i).Cells(1).ReadOnly = False
            Else
                dtgTarjetaDebito.Rows(i).Cells(1).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgTarjetaDebito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgTarjetaDebito.RowEnter
        Dim row As DataGridViewRow = dtgTarjetaDebito.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroTarjetaDebito.Text = CInt(row.Cells(2).Value)
    End Sub

    Private Sub dtgTarjetaDebito_SelectionChanged(sender As Object, e As System.EventArgs) Handles dtgTarjetaDebito.SelectionChanged
        For i As Integer = 0 To dtgTarjetaDebito.Rows.Count - 1
            If IsNumeric(dtgTarjetaDebito.Rows(i).Cells(1).Value) Then
                If dtgTarjetaDebito.Rows(i).Cells(1).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgTarjetaDebito.Rows(i).Cells(1).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgTarjetaDebito.Rows(i).Cells(1).Value = 1
                    End If
                    '-- el formato del monto
                    dtgTarjetaDebito.Rows(i).Cells(1).Value = formatoNumerosDecimales(dtgTarjetaDebito.Rows(i).Cells(1).Value)
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                dtgTarjetaDebito.Rows(i).Cells(1).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If

        Next
    End Sub

    Private Sub btnAgregarTarjetaDebito_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarTarjetaDebito.Click
        Me.Enabled = False
        frmTarjetaDebitoCaja.Visible = True
        frmTarjetaDebitoCaja.Show()
        frmTarjetaDebitoCaja.BringToFront()
    End Sub

    Private Sub btnEliminarTarjetaDebito_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarTarjetaDebito.Click
        If txtNroTarjetaDebito.Text.Length > 0 Then
            If CInt(txtNroTarjetaDebito.Text) > 0 Then
                If dtgTarjetaDebito.SelectedCells.Count > 0 Then
                    dtgTarjetaDebito.Rows.Remove(dtgTarjetaDebito.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoTarjetaDebito = intGl_nroArqueoTarjetaDebito - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If
    End Sub

    '************************************************************************************************************************************
    '********************'
    ' GRILLA COMPRAS WEB '
    '********************'
    Private Sub dtgWeb_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgWeb.CellFormatting
        '-- el formato del monto
        If dtgWeb.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn13") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
        If dtgWeb.Columns(e.ColumnIndex).Name.Equals("DataGridViewTextBoxColumn14") Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            e.CellStyle.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub dtgWeb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgWeb.GotFocus
        For i As Integer = 0 To dtgWeb.Rows.Count - 1
            If dtgWeb.Rows(i).Cells(2).Value > 0 Then
                dtgWeb.Rows(i).Cells(1).ReadOnly = False
                dtgWeb.Rows(i).Cells(0).ReadOnly = False
            Else
                dtgWeb.Rows(i).Cells(1).ReadOnly = True
                dtgWeb.Rows(i).Cells(0).ReadOnly = True
            End If
        Next
    End Sub

    Private Sub dtgWeb_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgWeb.RowEnter
        Dim row As DataGridViewRow = dtgWeb.Rows(e.RowIndex)
        '- asignar el nro de registro al objeto txt
        txtNroWeb.Text = CInt(row.Cells(2).Value)
    End Sub

    Private Sub dtgWeb_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgWeb.SelectionChanged
        For i As Integer = 0 To dtgWeb.Rows.Count - 1
            If IsNumeric(dtgWeb.Rows(i).Cells(1).Value) Then
                If dtgWeb.Rows(i).Cells(1).Value > 0 Then
                    '-- si el usuario coloca una cantidad no valida
                    If dtgWeb.Rows(i).Cells(1).Value <= 0 Then
                        MessageBox.Show("El valor ingresado no es Válido ", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dtgWeb.Rows(i).Cells(1).Value = 1
                    End If
                    '-- el formato del monto
                    dtgWeb.Rows(i).Cells(1).Value = formatoNumerosDecimales(dtgWeb.Rows(i).Cells(1).Value)
                    '-- sumar los totales
                    totalArqueo()
                End If
            Else
                dtgWeb.Rows(i).Cells(1).Value = 1
                '-- sumar los totales
                totalArqueo()
            End If
        Next
    End Sub

    Private Sub btnAgregarWeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarWeb.Click
        intGl_nroArqueoWeb = intGl_nroArqueoWeb + 1
        cargarArqueoWeb(intGl_nroArqueoWeb, 1, 1)
        dtgWeb.Focus()
    End Sub

    Private Sub btnEliminarWeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarWeb.Click
        If txtNroWeb.Text.Length > 0 Then
            If CInt(txtNroWeb.Text) > 0 Then
                If dtgWeb.SelectedCells.Count > 0 Then
                    dtgWeb.Rows.Remove(dtgWeb.CurrentRow)
                    '-- restar la variable publica de nro de item
                    intGl_nroArqueoWeb = intGl_nroArqueoWeb - 1
                End If
                '-- volver a sumar los totales
                totalArqueo()
            End If
        End If
    End Sub
    '**************************************************************************************************************************************
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmArqueoCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        limpiar()
        frmMenuPrincipal.finanzaArqueCaja.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------------------------

End Class