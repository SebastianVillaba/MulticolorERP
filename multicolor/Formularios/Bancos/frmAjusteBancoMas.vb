Public Class frmAjusteBancoMas
    Dim sp_datosTabla As New sp_datosTabla
    Dim cuentaCorriente As New cuentaCorriente
    Dim systemClass As New SystemClass

    Dim intIdCotiza As Integer

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        '-- cargar el combo de la cuenta corriente
        cuentaCorriente.cuentaCorrienteCombo(cboCuenta)
        '-- cargar la cotizacion de la moneda configurada
        Dim intTmpIdCuenta As Integer
        intTmpIdCuenta = sp_datosTabla.consulta_valor("select idCuenta from cuentaCorriente where idMoneda=" & sp_datosTabla.consulta_valor _
                                                    ("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad))
        cboCuenta.SelectedValue = intTmpIdCuenta
        '-- la cotizacion y el nombre de la moneda
        intIdCotiza = sp_datosTabla.consulta_valor("select idCotiza from cabCotiza where idMoneda=" & sp_datosTabla.consulta_valor _
                                                    ("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad))
        txtCotizacion.Text = 1
        txtMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & sp_datosTabla.consulta_valor _
                                                    ("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad))
    End Sub

    Private Sub limpiarObjetos()
        '-- txt
        txtMoneda.Text = ""
        txtMonto.Text = 0
        txtMotivo.Text = ""

    End Sub

    '-- guardar los cheques
    Private Sub guardarAjuste()
        '-- variables para cargar
        Dim intTmpIdCuenta As Integer
        Dim douTmpCotizacion As Double
        Dim datTmpFecha As Date
        Dim douTmpMonto As Double
        Dim strTmpMotivo As String
        '-- dar valor a las variables
        intTmpIdCuenta = cboCuenta.SelectedValue
        douTmpCotizacion = txtCotizacion.Text
        datTmpFecha = systemClass.formatofecha(dtpFecha)
        douTmpMonto = txtMonto.Text
        strTmpMotivo = txtMotivo.Text

        '--- cargar los datos en la tabla temporal
        If (fun_guardarSp("sp_insAjusteMasCuentaCorriente", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdCuenta & "," & douTmpCotizacion & "," & "'" & datTmpFecha & "'" & "," & douTmpMonto & "," & "'" & strTmpMotivo & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            inicializar()
            limpiarObjetos()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub

    Private Sub txtMotivo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar los Ajustes..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarAjuste()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- COMBOBOX --'
    '**************'
    Private Sub cboCuenta_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCuenta.SelectedIndexChanged
        Dim intTmpIdCuenta As Integer
        intTmpIdCuenta = cboCuenta.SelectedValue
        Dim intTmpIDMoneda As Integer
        intTmpIDMoneda = sp_datosTabla.consulta_valor("select idmoneda from cuentaCorriente where idCuenta=" & intTmpIdCuenta)
        txtMoneda.Text = sp_datosTabla.consulta_valorString("select nombreMoneda from moneda where idMoneda=" & intTmpIDMoneda)
        If intTmpIDMoneda = sp_datosTabla.consulta_valor("select idMoneda from configEmpresa where idEntidad=" & intGl_idEntidad) Then
            txtCotizacion.Text = 1
        Else
            txtCotizacion.Text = sp_datosTabla.consulta_valorDouble("select venta from detCotiza where idCotiza=" & intIdCotiza & " and idmoneda=" & intTmpIDMoneda)
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmAjusteBancoMas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoAumentarCuenta.Enabled = True
        e.Cancel = False
    End Sub

    '----------------------------------------------------------------------------------------------------
End Class