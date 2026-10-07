Public Class frmBuscarPc
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub inicializar()
        listar(" Where nombrePc Like '" & "A" & "%' Or nombrePc Like '" & "A" & "%' " & "order by nombrePc")
        'valorde del combo
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub verificarModulo()
        If banGl_abmConfigPc = True Then
            '-- para el formulario de abm pc
            'frmAbmPc.txtIdPcCocina.Text = CInt(txtIdLaboratorio.Text)
            'frmAbmPc.txtPcCocina.Text = sp_datosTabla.un_datoString("nombrePc", "configPc", "idConfig", CInt(txtIdLaboratorio.Text))
            Me.Close()
        End If
    End Sub

    '-- listar
    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvLaboratorio, "Select idConfig,ltrim(nombrePC) as Nombre from configPc  " & where)
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- TEXTBOX --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                listar(" Where nombrePc Like '" & txtBuscar.Text & "%' Or nombrePC Like '" & txtBuscar.Text & "%' " & "order by nombrePc")
            Else
                '-- buscar por idConfig
                listar(" Where idConfig=" & txtBuscar.Text)
            End If
            lvLaboratorio.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvLaboratorio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvLaboratorio.KeyPress
        If txtIdLaboratorio.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtIdLaboratorio.Text) = 0 Then
                    MessageBox.Show("Debe ingresar algún Laboratorio..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                verificarModulo()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvLaboratorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLaboratorio.SelectedIndexChanged
        For Each item As ListViewItem In lvLaboratorio.SelectedItems
            txtIdLaboratorio.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarPc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_abmConfigPc = True Then
            e.Cancel = False
            frmAbmPc.Enabled = True
            frmAbmPc.Show()
            frmAbmPc.BringToFront()
            'frmAbmPc.btnBuscarDiv.Focus()
        End If

    End Sub
    '--------------------------------------------------------------------------------------------------------------------------
End Class