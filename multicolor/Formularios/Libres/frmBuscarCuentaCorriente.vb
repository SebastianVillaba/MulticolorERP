Public Class frmBuscarCuentaCorriente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdCuenta As Integer
    Dim strNombreCuenta As String


    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo de la cuenta corriente
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvCuenta, "Select c.idCuenta,c.nombreBanco,c.nroCuenta from cuentaCorriente c " & where)
        ' dimensionar las columnas
        lvCuenta.Columns(0).Width = 80
        lvCuenta.Columns(1).Width = 150
        lvCuenta.Columns(2).Width = 150
        lvCuenta.Columns(0).Text = "ID Cuenta"
        lvCuenta.Columns(1).Text = "Nombre del Banco"
        lvCuenta.Columns(2).Text = "Nro cuenta"
        lvCuenta.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_depositoBanco = True Then
            '-- deposito bancario
            depositoBancario()
        End If

        If banGl_reporteSaldoBanco = True Then
            '-- reporte de saldo de banco
            reporteSaldoBanco()
        End If

        If banGl_reporteChequePendiente = True Then
            '-- reporte de cheques pendientes
            reporteChequePendiente()
        End If

        If banGl_OrdenPagoCheque = True Then
            '-- orden de Cheque
            ordenCheque()
        End If
    End Sub

    Private Sub depositoBancario()
        Dim intTmpIdMoneda As Integer
        '-- colocar los datos del proveedor
        frmCargarDepositoBanco.txtNombreCuenta.Text = strNombreCuenta
        frmCargarDepositoBanco.txtIdCuenta.Text = intIdCuenta
        intTmpIdMoneda = sp_datosTabla.un_dato_integer("idMoneda", "cuentaCorriente", "idcuenta", intIdCuenta)
        frmCargarDepositoBanco.txtMoneda.Text = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", intTmpIdMoneda)
        '-- si la moneda es la configurada y utilizada en el sistema
        If (sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad)) = intTmpIdMoneda Then
            '-- moneda configurada y utilizada en el sistema
            frmCargarDepositoBanco.txtCotizacion.Text = 1
        Else
            '-- otra moneda
            frmCargarDepositoBanco.txtCotizacion.Text = sp_datosTabla.un_dato_double("venta", "detCotiza", "idMoneda", intTmpIdMoneda)
        End If
        frmCargarDepositoBanco.txtCotizacion.Text = Format(CDec(frmCargarDepositoBanco.txtCotizacion.Text), "###,###,###.00")
        frmCargarDepositoBanco.inicializarObjetos()

        Me.Close()
        frmCargarDepositoBanco.Enabled = True
        frmCargarDepositoBanco.Show()
        frmCargarDepositoBanco.BringToFront()
        frmCargarDepositoBanco.btnBuscarPersonal.Focus()
    End Sub

    Private Sub reporteSaldoBanco()
        frmReporteSaldoBanco.txtIdCuenta.Text = intIdCuenta
        frmReporteSaldoBanco.txtNombreCuenta.Text = strNombreCuenta
        Me.Close()

    End Sub

    Private Sub reporteChequePendiente()
        frmReporteChequePendientes.txtIdCuenta.Text = intIdCuenta
        frmReporteChequePendientes.txtCuenta.Text = strNombreCuenta
        Me.Close()
    End Sub

    Private Sub ordenCheque()
        Dim intTmpIdMoneda As Integer
        Dim intTmpIdCotiza As Integer
        Dim douTmpCotiza As Double

        frmCargarOrdenPagoCheque.habilitarObjetos()

        frmCargarOrdenPagoCheque.lblIdCuenta.Text = intIdCuenta
        frmCargarOrdenPagoCheque.lblCuenta.Text = strNombreCuenta
        '-- nombre del banco
        frmCargarOrdenPagoCheque.lblBanco.Text = sp_datosTabla.consulta_valorString("select nombreBanco from cuentaCorriente where idCuenta=" & intIdCuenta)
        '-- el nombre de la moneda que corresponde a la cuenta
        intTmpIdMoneda = sp_datosTabla.consulta_valor("select idMoneda from cuentaCorriente where idCuenta=" & intIdCuenta)
        frmCargarOrdenPagoCheque.lblMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIdMoneda)
        '-- la cotizacion de la moneda
        'MsgBox("Valor de idMoneda de la cuenta corriente  " & intTmpIdMoneda)
        'MsgBox("Valor de idMoneda de la configuracion  " & sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad))
        '-- verificar la configuracion de la moneda
        If sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad) = intTmpIdMoneda Then
            frmCargarOrdenPagoCheque.lblCotiza.Text = 1
        Else
            '-- otras monedas de acuerdo a la tabla de cotizaciones
            intTmpIdCotiza = sp_datosTabla.consulta_valor("select idCotiza from cabCotiza where idMoneda=" & sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad))
            douTmpCotiza = sp_datosTabla.consulta_valorDouble("select venta from detCotiza where idCotiza=" & intTmpIdCotiza & " and idMoneda=" & intTmpIdMoneda)
            frmCargarOrdenPagoCheque.lblCotiza.Text = douTmpCotiza
            '-- formato
            frmCargarOrdenPagoCheque.lblCotiza.Text = Format(CDec(frmCargarOrdenPagoCheque.lblCotiza.Text), "###,###.##")
        End If

        Me.Close()
    End Sub
    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idCuenta
                listar(" Where c.idCuenta=" & txtBuscar.Text & " order by c.idCuenta")
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre del banco
                listar(" Where c.nombreBanco Like '" & txtBuscar.Text & "%' Or c.nombreBanco Like '" & txtBuscar.Text & "%' " & " order by c.nombreBanco")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdCuenta.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCuenta.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvCuenta.SelectedItems
            intIdCuenta = item.SubItems(0).Text
            txtIdCuenta.Text = item.SubItems(0).Text
            txtNombreBanco.Text = Trim(item.SubItems(1).Text) & "/" & Trim(item.SubItems(2).Text)
            strNombreCuenta = Trim(item.SubItems(1).Text) & "/" & Trim(item.SubItems(2).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarCuentaCorriente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_depositoBanco = True Then
            '-- deposito bancario
            banGl_depositoBanco = False

            frmCargarDepositoBanco.Enabled = True
            frmCargarDepositoBanco.Show()
            frmCargarDepositoBanco.BringToFront()
            frmCargarDepositoBanco.btnBuscarPersonal.Focus()
        End If

        If banGl_reporteSaldoBanco = True Then
            '-- reporte de saldo de banco
            banGl_reporteSaldoBanco = False

            frmReporteSaldoBanco.Enabled = True
            frmReporteSaldoBanco.Show()
            frmReporteSaldoBanco.BringToFront()
            frmReporteSaldoBanco.dtpDesdeFecha.Focus()
        End If

        If banGl_reporteChequePendiente = True Then
            '-- reporte de cheques pendientes
            banGl_reporteChequePendiente = False

            frmReporteChequePendientes.Enabled = True
            frmReporteChequePendientes.Show()
            frmReporteChequePendientes.BringToFront()
            frmReporteChequePendientes.dtpDesdeFecha.Focus()
        End If

        If banGl_OrdenPagoCheque = True Then
            '-- orden de Cheques
            banGl_OrdenPagoCheque = False

            frmCargarOrdenPagoCheque.Enabled = True
            frmCargarOrdenPagoCheque.Show()
            frmCargarOrdenPagoCheque.BringToFront()
            frmCargarOrdenPagoCheque.btnProveedor.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
End Class