Public Class frmCambiarFactura
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdFactura As Integer
    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        txtSucursal.Text = Trim(sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursal _vs inner join configPc c on _vs.idSucursal=c.idSucursal where c.idConfig=" & intGl_idConfigPc))
        intIdFactura = sp_datosTabla.consulta_valor("select idFactura from configPc where idConfig=" & intGl_idConfigPc)
        txtTimbrado.Text = sp_datosTabla.consulta_valorString("select timbrado from factura where idFactura=" & intIdFactura)
        txtDsuc.Text = sp_datosTabla.consulta_valorString("select dsuc from factura where idFactura=" & intIdFactura)
        txtDcaja.Text = sp_datosTabla.consulta_valorString("select dcaja from factura where idFactura=" & intIdFactura)
        txtFactura.Text = sp_datosTabla.consulta_valor("select nroFacturaSgte+1 from factura where idFactura=" & intIdFactura)
    End Sub
    '-------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        sp_datosTabla.consulta_valor("update factura set nroFacturaSgte=" & txtFactura.Text - 1 & " where idFactura=" & intIdFactura)
        inicializar()
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        e.Handled = txtNumerico(txtFactura, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCambiarFactura_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtFactura.Focus()
    End Sub

    Private Sub frmCambiarFactura_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        'frmMenuPrincipal.configuracionCambiarFactura.Enabled = True
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------
End Class