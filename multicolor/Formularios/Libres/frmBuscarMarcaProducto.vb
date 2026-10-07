Public Class frmBuscarMarcaProducto
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

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
        listar(" Where idMarca=1")
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lv, "Select idMarca,ltrim(nombreMarca) as Nombre from marca  " & where)
        'txtSql.Text = "Select idDivision,ltrim(nombre) as Nombre from v_division  " & where
    End Sub

    Private Sub verificarVentana()
        If banGl_ordenAutomotive = True Then
            frmOrdenPreparadoAutomotive.txtIdEnsambladora.Text = CInt(txtId.Text)
            frmOrdenPreparadoAutomotive.txtEnsambladora.Text = sp_datosTabla.consulta_valorString("select nombreMarca from marca where idMarca=" & CInt(txtId.Text))
            Me.Close()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- TEXTBOX --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                listar(" Where (nombreMarca Like '" & txtBuscar.Text & "%' Or nombreMarca Like '" & txtBuscar.Text & "%') order by nombreMarca")
            Else
                '-- buscar por id
                listar(" Where idMarca=" & txtBuscar.Text)
            End If
            lv.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lv.KeyPress
        If txtId.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtId.Text) = 0 Then
                    MessageBox.Show("Debe ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                verificarVentana()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If

    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged
        For Each item As ListViewItem In lv.SelectedItems
            txtId.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarMarcaProducto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_ordenAutomotive = True Then
            banGl_ordenAutomotive = False

            e.Cancel = False
            frmOrdenPreparadoAutomotive.Enabled = True
            frmOrdenPreparadoAutomotive.Show()
            frmOrdenPreparadoAutomotive.BringToFront()
            frmOrdenPreparadoAutomotive.txtAnho.Focus()
        End If
    End Sub

End Class