Public Class frmCantidadAutomotive
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actualizarDetalle()
        If (fun_guardarSp("sp_actualizarDetOrdenAutomotiveTmp", intGl_idConfigPc & "," & txtNro.Text & "," & sacarComa(txtGramo.Text), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Actualizar al Detalle...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            frmOrdenPreparadoAutomotive.listarDetalle()
            frmOrdenPreparadoAutomotive.sumarTotal()
            frmOrdenPreparadoAutomotive.lvOrden.Focus()
            Me.Close()
        End If
    End Sub
    '-----------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtGramo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGramo.KeyPress
        e.Handled = txtNumerico(txtGramo, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- colocar en cero si es espacio en blanco
            e.Handled = True
            'SendKeys.Send("{tab}")
            txtGramo.Text = Format(CDec(txtGramo.Text), "##,##0.##")
            btnAgregar.Focus()
        End If
    End Sub

    '-----------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        actualizarDetalle()
    End Sub
    '-----------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmCantidadAutomotive_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmOrdenPreparadoAutomotive.Enabled = True
        frmOrdenPreparadoAutomotive.Show()
        frmOrdenPreparadoAutomotive.BringToFront()
        frmOrdenPreparadoAutomotive.lvOrden.Focus()
    End Sub
End Class