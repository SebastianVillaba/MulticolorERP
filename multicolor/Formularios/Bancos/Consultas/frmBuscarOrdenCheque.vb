Public Class frmBuscarOrdenCheque
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "select co.idOrdenCheque,(RTRIM(_vu.nombre)+','+LTRIM(_vu.apellido)) as responsable," & _
        "co.fechaAlta,cc.nroCuenta from cabOrdenCheque co inner join v_usuarioT _vu on co.idUsuarioAlta=_vu.idUsuario " & _
        " inner join cuentaCorriente cc on cc.idCuenta=co.idCuenta " & where)
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- por nombre del responsable
                listar(" Where _vu.nombre Like '" & txtBuscar.Text & "%' Or _vu.nombre Like '" & txtBuscar.Text & "%' ")
            Else
                '-- buscar por idOrdenCheque
                listar(" Where co.idOrdenCheque=" & txtBuscar.Text)
            End If
            lvBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If IsNumeric(txtIdMov.Text) Then
            If txtIdMov.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    '-- listar el detalle
                    frmConsultaOrdenCheque.listarDetalle(CInt(txtIdMov.Text))
                    '-- los datos
                    frmConsultaOrdenCheque.actualizarCabecera(CInt(txtIdMov.Text))
                    '------------------------------------------------------------
                    Me.Close()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtIdMov.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmBuscarBuscarOrdenCheque_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaOrdenCheque.Enabled = True
        frmConsultaOrdenCheque.Show()
        frmConsultaOrdenCheque.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
End Class