Public Class frmCajaMenos
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub limpiar()
        '-- los txt
        txtSucursal.Text = ""
        txtIdSucursal.Text = 0
        txtTotalCaja.Text = 0
        txtTotalDiferencia.Text = 0
        txtTotalSistema.Text = 0
        txtIdCaja.Text = 0
        '-- movimientos 
        txtIdMovFin1.Text = 0
        txtIdMovFin2.Text = 0
        txtIdMovIni1.Text = 0
        txtIdMovIni2.Text = 0
        '-- fechas
        txtFechaFin1.Text = ""
        txtFechaFin2.Text = ""
        txtFechaIni1.Text = ""
        txtFechaIni2.Text = ""
        '-- montos
        txtMonto.Text = 0
        txtMonto.Enabled = False
        txtMonto.BackColor = Color.LightSkyBlue
        '-- motivo
        txtMotivo.Text = ""
        txtMotivo.Enabled = False
        txtMotivo.BackColor = Color.LightSkyBlue
        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
    End Sub

    Private Sub guardarAjusteCaja()
        '-- variables para guardar
        Dim intTmpIdCaja As Integer
        Dim intTmpIdSucursal As Integer
        Dim douTmpMonto As Double
        Dim strTmpObservacion As String
        '-- dar valores a las variables
        intTmpIdCaja = CInt(txtIdCaja.Text)
        intTmpIdSucursal = CInt(txtIdSucursal.Text)
        douTmpMonto = CDbl(txtMonto.Text)
        strTmpObservacion = txtMotivo.Text

        '--- cargar los datos en la tabla temporal
        If (fun_guardarSp("sp_guardarCajaMenos", intTmpIdCaja & "," & intGl_idConfigPc & "," & intGl_idSucursal & "," & douTmpMonto & "," & "'" & strTmpObservacion & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            MessageBox.Show("Se guardaron los registros con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        banGl_cajaMenos = True
        Me.Enabled = False
        frmBuscarArqueo.txtBuscar.Text = ""
        frmBuscarArqueo.txtIdCaja.Text = ""
        frmBuscarArqueo.Visible = True
        frmBuscarArqueo.Show()
        frmBuscarArqueo.BringToFront()

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar el Ajuste de Caja...!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarAjusteCaja()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        e.Handled = txtNumerico(txtMonto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtMonto.Text = Format(CDec(txtMonto.Text), "###,###,###.00")
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCajaMenos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.finanzaAjustarCajaMenos.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------
End Class