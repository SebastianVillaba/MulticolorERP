Public Class frmBuscarColorInmo
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'  
    Private Sub inicializar()
        listar("")
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvMoneda, "Select top 20 idColorInmo,codigo,nombre from colorInmo  " & where)
    End Sub

    Private Sub verificarModulo()
        If banGl_ordenAutomotive = True Then
            ordenAutomotive(txtIdMoneda.Text)
        End If
        If banGl_ordenCoral = True Then
            ordenCoral(txtIdMoneda.Text)
        End If
        If banGl_ordenSuvinil = True Then
            ordenSuvinil(txtIdMoneda.Text)
        End If
    End Sub

    Private Sub ordenAutomotive(ByVal v_idColor As Integer)
        frmOrdenPreparadoAutomotive.txtCodigo.Text = Trim(sp_datosTabla.consulta_valorString("select codigo from colorInmo where idColorInmo=" & v_idColor))
        frmOrdenPreparadoAutomotive.txtNombreColor.Text = Trim(sp_datosTabla.consulta_valorString("select nombre from colorInmo where idColorInmo=" & v_idColor))
        Me.Close()
    End Sub

    Private Sub ordenCoral(ByVal v_idColor As Integer)
        frmOrdenPreparadoCoral.txtCodigo.Text = Trim(sp_datosTabla.consulta_valorString("select codigo from colorInmo where idColorInmo=" & v_idColor))
        frmOrdenPreparadoCoral.txtNombreColor.Text = Trim(sp_datosTabla.consulta_valorString("select nombre from colorInmo where idColorInmo=" & v_idColor))
        Me.Close()
    End Sub

    Private Sub ordenSuvinil(ByVal v_idColor As Integer)
        frmOrdenPreparadoSuvinil.txtCodigo.Text = Trim(sp_datosTabla.consulta_valorString("select codigo from colorInmo where idColorInmo=" & v_idColor))
        frmOrdenPreparadoSuvinil.txtNombreColor.Text = Trim(sp_datosTabla.consulta_valorString("select nombre from colorInmo where idColorInmo=" & v_idColor))
        Me.Close()
    End Sub
    '-------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                listar(" Where nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & "order by nombre")
            End If
            lvMoneda.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvMoneda.KeyPress
        If txtIdMoneda.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtIdMoneda.Text) = 0 Then
                    MessageBox.Show("Debe ingresar alguna Moneda..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

    Private Sub lvMoneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMoneda.SelectedIndexChanged
        For Each item As ListViewItem In lvMoneda.SelectedItems
            txtIdMoneda.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarColorImo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_ordenAutomotive = True Then
            banGl_ordenAutomotive = False
            e.Cancel = False
            frmOrdenPreparadoAutomotive.Enabled = True
            frmOrdenPreparadoAutomotive.Show()
            frmOrdenPreparadoAutomotive.BringToFront()
            frmOrdenPreparadoAutomotive.txtNombreColor.Focus()
        End If
        If banGl_ordenCoral = True Then
            banGl_ordenCoral = False
            e.Cancel = False
            frmOrdenPreparadoCoral.Enabled = True
            frmOrdenPreparadoCoral.Show()
            frmOrdenPreparadoCoral.BringToFront()
            frmOrdenPreparadoCoral.btnBuscarBase.Focus()
        End If
        If banGl_ordenSuvinil = True Then
            banGl_ordenSuvinil = False
            e.Cancel = False
            frmOrdenPreparadoSuvinil.Enabled = True
            frmOrdenPreparadoSuvinil.Show()
            frmOrdenPreparadoSuvinil.BringToFront()
            frmOrdenPreparadoSuvinil.btnBuscarBase.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
End Class