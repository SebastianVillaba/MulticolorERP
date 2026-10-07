Public Class frmModificarCheque
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- inicializar las fechas
        dtpFechaCheque.Format = DateTimePickerFormat.Custom
        dtpFechaCheque.CustomFormat = "dd/MM/yyyy"
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub guardarModificacion()
        If (fun_guardarSp("sp_guardarModificaCheque", txtNroCheque1.Text & "," & txtIdProveedor2.Text & "," & "'" & dtpFechaCheque.Text & "'" & "," & CDbl(sacarComa(txtMontoCheque.Text)) & _
                          "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar las modificaciones...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            frmConsultaCheque.mostrarDatosCheque(txtIdCheque.Text, txtIdChequera.Text, txtIdProveedor2.Text)
            Me.Close()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub dtpFechaCheque_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaCheque.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtMontoCheque.Focus()
        End If
    End Sub

    Private Sub txtMontoCheque_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoCheque.KeyPress
        e.Handled = txtNumerico(txtMontoCheque, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtMontoCheque.Text = Format(CDec(txtMontoCheque.Text), "###,###,##0.##")
            btnGuardar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        banGl_modificacionCheque = True
        Me.Enabled = False

        frmBuscarProveedor.txtIdProveedor.Text = 0
        frmBuscarProveedor.txtNombreProveedor.Text = ""
        frmBuscarProveedor.txtBuscar.Text = ""
        frmBuscarProveedor.Visible = True
        frmBuscarProveedor.WindowState = FormWindowState.Normal
        frmBuscarProveedor.Show()
        frmBuscarProveedor.txtBuscar.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar las modificaciones del Cheque..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarModificacion()
        End If
    End Sub

    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarProveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaCheque.Enabled = True
        frmConsultaCheque.Show()
        frmConsultaCheque.BringToFront()
    End Sub
End Class