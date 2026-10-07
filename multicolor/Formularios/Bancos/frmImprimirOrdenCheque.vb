Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class frmImprimirOrdenCheque
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim bolImprimir As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiarObjetos()
        listarOrdenCheque()

        bolImprimir = False
        lvOrdenCheque.Focus()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiarObjetos()
        '-- txt
        txtNroCheque.Text = 0
        '-- los lbl
        lblIdOrden.Text = 0
        lblIdChequera.Text = 0
        lblChequeInicial.Text = 0
        lblChequeFinal.Text = 0
        lblNroCuenta.Text = ""
        lblNombreBanco.Text = ""
        lblMoneda.Text = ""
        lblCotiza.Text = 0
        '-- botones
        btnGuardar.Enabled = False
    End Sub

    Private Sub listarOrdenCheque()
        systemClass.SqlToLv_detalleInventarioDeposito(lvOrdenCheque, "sp_consultaOrdenChequeImprimir", "")
    End Sub

    Private Sub listarChequeProveedor(ByVal v_idOrden As Integer)
        systemClass.SqlToLv_detalleOrdenChequeImprimir(lvCheque, "sp_consultaChequeOrdenProveedor", v_idOrden)
    End Sub

    Private Sub datosChequera(ByVal v_cheque As Integer)
        Dim intTmpIdChequera As Integer
        Dim intTmpIdCuenta As Integer
        Dim intTmpIdMoneda As Integer
        Dim intTmpIdCotiza As Integer
        Dim douTmpCotiza As Double

        intTmpIdChequera = sp_datosTabla.consulta_valor("select idChequera from chequera where " & v_cheque & " >= chequeInicial and " & v_cheque & " <= chequeFinal")
        If intTmpIdChequera = 0 Then
            MessageBox.Show("El Nro. de Cheque Ingresado no se encuentra en ninguna Chequera cargada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        lblIdChequera.Text = intTmpIdChequera
        lblChequeInicial.Text = sp_datosTabla.consulta_valor("select chequeInicial from chequera where idChequera=" & intTmpIdChequera)
        lblChequeFinal.Text = sp_datosTabla.consulta_valor("select chequeFinal from chequera where idChequera=" & intTmpIdChequera)

        intTmpIdCuenta = sp_datosTabla.consulta_valor("select idCuenta from chequera where idChequera=" & intTmpIdChequera)

        lblNroCuenta.Text = sp_datosTabla.consulta_valorString("select nroCuenta from cuentaCorriente where idCuenta=" & intTmpIdCuenta)
        lblNombreBanco.Text = sp_datosTabla.consulta_valorString("select nombreBanco from cuentaCorriente where idCuenta=" & intTmpIdCuenta)

        intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cuentaCorriente where idCuenta=" & intTmpIdCuenta)

        lblMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIdMoneda)
        '-- la cotizacion
        If sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad) = intTmpIdMoneda Then
            lblCotiza.Text = 1
        Else
            '-- otras monedas de acuerdo a la tabla de cotizaciones
            intTmpIdCotiza = sp_datosTabla.consulta_valor("select idCotiza from cabCotiza where idMoneda=" & sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad))
            douTmpCotiza = sp_datosTabla.consulta_valorDouble("select venta from detCotiza where idCotiza=" & intTmpIdCotiza & " and idMoneda=" & intTmpIdMoneda)
            lblCotiza.Text = douTmpCotiza
            '-- formato
            lblCotiza.Text = Format(CDec(lblCotiza.Text), "###,###.##")
        End If

    End Sub

    Private Sub cargarChequeTmp()
        '-- inicializar las variables
        Dim intTmpChequeInicial As Integer
        Dim intTmpIdChequera As Integer
        Dim intTmpIdOrdenCheque As Integer
        Dim douTmpCotiza As Double
        Dim intTmpIdCuenta As Integer

        '-- obtner el idCuentaCorriente
        intTmpIdCuenta = sp_datosTabla.consulta_valor("select idCuenta from chequera where idChequera=" & lblIdChequera.Text)

        If MessageBox.Show("Desea Imprimir los Cheques..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            bolImprimir = True

            '-- dar valor a las variables
            intTmpChequeInicial = CInt(txtNroCheque.Text)
            intTmpIdChequera = CInt(lblIdChequera.Text)
            intTmpIdOrdenCheque = CInt(lblIdOrden.Text)
            douTmpCotiza = CDbl(sacarComa(lblCotiza.Text))

            If (fun_guardarSp("sp_insTmpOrdenCheque", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpChequeInicial & "," & intTmpIdChequera & "," & intTmpIdOrdenCheque & "," & douTmpCotiza, Me.Name)) = 0 Then
                Me.Enabled = True
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Insertar los Cheques en la Tabla Temporal...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                btnGuardar.Enabled = True
                '--- impresion de los cheques
                Me.Enabled = False

                If rdAlaVista.Checked = True Then

                End If

                If rdDirerido.Checked = True Then

                End If


                Me.Enabled = True

            End If
        End If
    End Sub

    Private Sub guardarCheque()
        '--- cargar los datos en la tabla temporal
        If (fun_guardarSp("sp_guardarOrdenChequeImpreso", intGl_idConfigPc & "," & CInt(lblIdOrden.Text) & "," & intGl_idSucursal & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            bolImprimir = False

            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiarObjetos()
            '-- la grilla
            listarOrdenCheque()
            listarChequeProveedor(0)
        End If
    End Sub

    '-- imprimir directamente en el puerto de la imnpresora
    Private Sub hojaImpresion_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles hojaImpresion.PrintPage

        Try
            '-- la fuente a usar
            Dim prFont As New Font("MS Reference Sans Serif", 12, FontStyle.Bold)
            Dim prFont1 As New Font("MS Reference Sans Serif", 7, FontStyle.Bold)
            Dim prFont2 As New Font("MS Reference Sans Serif", 10, FontStyle.Bold)


            '----------------'
            '-- EL DETALLE --'
            '----------------'
            limpiarDataset()
            'Dim cmd1 As New SqlConnection
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "select nroCheque,fechaEmision1,fechaPago1,concepto,diaEmision,mesEmision," & _
                "SUBSTRING(CONVERT(varchar,fechaEmision1),4,2) as nroMesEmi,SUBSTRING(CONVERT(varchar,fechaEmision1),9	,2) as nroAnhoEmi," & _
                "SUBSTRING(CONVERT(varchar,anhoEmision),3,2) as nroAnho,anhoEmision,diaPago," & _
                "SUBSTRING(CONVERT(varchar,anhoPago),3,2) as nroAnhoReal,SUBSTRING(CONVERT(varchar,fechaPago1),4,2) as nroMes,mesPago," & _
                "anhoPago,monto,SUBSTRING(nombreProveedor,1,15) prov1,SUBSTRING(nombreProveedor,15,15) prov2,nombreFantasia,letraMonto1,letraMonto2 " & _
                " from tmpOrdenCheque where idConfig=" & intGl_idConfigPc & " Order by nroCheque "
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            Dim tmpIntContador As Integer = 5

            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                reader = cmd.ExecuteReader()

                Using reader
                    While reader.Read
                        '-- monto del cheque
                        e.Graphics.DrawString(Trim(reader.GetValue(15).ToString), prFont, Brushes.Black, 650, tmpIntContador)
                        tmpIntContador = tmpIntContador + 25
                        '-- fecha de vencimiento
                        e.Graphics.DrawString(reader.GetValue(2).ToString, prFont1, Brushes.Black, 40, tmpIntContador)
                        tmpIntContador = tmpIntContador + 17
                        '--fecha de pago
                        e.Graphics.DrawString(reader.GetValue(1).ToString, prFont1, Brushes.Black, 30, tmpIntContador)
                        '-- fecha de emision y pago
                        'tmpIntContador = tmpIntContador + 5
                        e.Graphics.DrawString(reader.GetValue(4).ToString + "  " + reader.GetValue(6).ToString + "        " + reader.GetValue(7).ToString + "             " + reader.GetValue(10).ToString + "  " + reader.GetValue(12).ToString + "      " + reader.GetValue(11).ToString, prFont, Brushes.Black, 470, tmpIntContador)
                        tmpIntContador = tmpIntContador + 10
                        '-- pago a la orden de
                        e.Graphics.DrawString(reader.GetValue(16).ToString, prFont1, Brushes.Black, 12, tmpIntContador)
                        tmpIntContador = tmpIntContador + 10
                        e.Graphics.DrawString(reader.GetValue(17).ToString, prFont1, Brushes.Black, 12, tmpIntContador)
                        '-- concepto
                        tmpIntContador = tmpIntContador + 20
                        e.Graphics.DrawString(reader.GetValue(3).ToString, prFont1, Brushes.Black, 30, tmpIntContador)
                        '-- paguese a :
                        'tmpIntContador = tmpIntContador + 20
                        e.Graphics.DrawString(reader.GetValue(18).ToString, prFont2, Brushes.Black, 300, tmpIntContador)
                        '-- la suma de 1
                        e.Graphics.DrawString(reader.GetValue(19).ToString, prFont2, Brushes.Black, 250, tmpIntContador)
                        '-- la suma de 2
                        tmpIntContador = tmpIntContador + 20
                        e.Graphics.DrawString(reader.GetValue(20).ToString, prFont2, Brushes.Black, 200, tmpIntContador)
                        '-- monto del cheque en el talon
                        tmpIntContador = tmpIntContador + 70
                        e.Graphics.DrawString(reader.GetValue(15).ToString, prFont1, Brushes.Black, 15, tmpIntContador)
                        '-- nro del cheque
                        tmpIntContador = tmpIntContador + 20
                        e.Graphics.DrawString(reader.GetValue(0).ToString, prFont1, Brushes.Black, 35, tmpIntContador)


                        ' MsgBox("Valor del cheque " + reader.GetValue(0).ToString)
                        e.HasMorePages = False
                        '--- una vez que llegue al final del 1er registro
                        'tmpIntContador = tmpIntContador + 75
                    End While
                End Using

            Catch ex As Exception

                MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                strGl_mensajeError = "Error: " & ex.Message & Me.ToString
                errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
            Finally

                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If

            End Try

            'e.HasMorePages = False

            Me.BringToFront()
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "sp_traerValor", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '-------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        cargarChequeTmp()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarCheque()
    End Sub
    '-------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtNroCheque_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCheque.KeyPress
        e.Handled = txtNumerico(txtNroCheque, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtNroCheque.Text) Then
                '-- cargar el detalle de los productos inventariados
                datosChequera(txtNroCheque.Text)
                e.Handled = True
                SendKeys.Send("{tab}")
            Else
                MessageBox.Show("Debe Ingresar un Número de Cheque válido..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvOrdenCheque_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOrdenCheque.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvOrdenCheque.SelectedItems
            lblIdOrden.Text = item.SubItems(0).Text
            '-- consultar los datos de los cheques de los proveedores
            listarChequeProveedor(item.SubItems(0).Text)
        Next

    End Sub
    '-------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmImprimirOrdenCheque_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bolImprimir = True Then
            If MessageBox.Show("Desea Salir del Módulo? Imprimió Cheques y no guardó..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '-- contador de formularios
                intGl_contadorFormularios = intGl_contadorFormularios - 1
                '----------------------------------------------------
                frmMenuPrincipal.bancoImprimirOrdenCheque.Enabled = True
                e.Cancel = False
            Else
                frmMenuPrincipal.bancoImprimirOrdenCheque.Enabled = True
                e.Cancel = False
            End If
        Else
            '-- contador de formularios
            intGl_contadorFormularios = intGl_contadorFormularios - 1
            '----------------------------------------------------
            frmMenuPrincipal.bancoImprimirOrdenCheque.Enabled = True
            e.Cancel = False
        End If

    End Sub
    '-------------------------------------------------------------------------------------------------------
End Class