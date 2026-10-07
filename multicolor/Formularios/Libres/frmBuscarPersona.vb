Public Class frmBuscarPersona
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select p.idPersona,p.nombre,pf.apellido,p.ruc from persona p inner join personaFis pf on p.idPersona=pf.idPersona" & where)
        'txtSql.Text = "Select _vs.idSucursal,_vs.nombreFantasia from v_Sucursal _vs " & where
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80
        lvBuscar.Columns(1).Width = 250
        lvBuscar.Columns(2).Width = 250
        lvBuscar.Columns(3).Width = 90
        lvBuscar.Columns(0).Text = "ID Per."
        lvBuscar.Columns(1).Text = "Nombre"
        lvBuscar.Columns(2).Text = "Apellido"
        lvBuscar.Columns(3).Text = "RUC"

        lvBuscar.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_hotelCheckIn = True Then
            '-- check in en el hotel
            '    checkInHotel(CInt(txtId.Text))
        End If
    End Sub

    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' buscar por ruc
                listar(" Where p.ruc='" & txtBuscar.Text & "'")
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                If rdNombre.Checked = True Then
                    ' buscar por nombre 
                    listar(" Where p.nombre Like '" & txtBuscar.Text & "%' Or p.nombre Like '" & txtBuscar.Text & "%' " & " order by p.nombre")
                End If
                If rdApellido.Checked = True Then
                    ' buscar por apellido
                    listar(" Where pf.apellido Like '" & txtBuscar.Text & "%' Or pf.apellido Like '" & txtBuscar.Text & "%' " & " order by pf.apellido")
                End If

            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtId.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtId.Text = item.SubItems(0).Text
            txtNombre.Text = item.SubItems(1).Text
        Next
    End Sub
    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarPersona_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_hotelCheckIn = True Then
            '-- check in en el hotel
            banGl_hotelCheckIn = False
        End If
    End Sub
    '--------------------------------------------------------------------------------------
End Class