Public Class frmBuscarSucursal
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select _vs.idSucursal,_vs.nombreFantasia from v_Sucursal _vs " & where)
        'txtSql.Text = "Select _vs.idSucursal,_vs.nombreFantasia from v_Sucursal _vs " & where
        ' dimensionar las columnas
        If sp_datosTabla.consulta_valor("Select _vs.idSucursal from v_Sucursal _vs " & where) > 0 Then
            lvBuscar.Columns(0).Width = 80
            lvBuscar.Columns(1).Width = 250
            lvBuscar.Columns(0).Text = "ID Suc."
            lvBuscar.Columns(1).Text = "Nombre de la Sucursal"
            lvBuscar.Scrollable = True
        End If

    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_reporteLibroIva = True Then
            '-- reporte de libro iva
            reporteLibroIva()
        End If
        If banGl_reporteArqueoCaja = True Then
            '-- reporte del aqueo de caja
            reporteAqueoCaja()
        End If
        If banGl_reporteHorarioPersonal = True Then
            '-- reporte de horario del personal
            reporteHorarioPersonal()
        End If
    End Sub

    Private Sub reporteLibroIva()
        frmReporteLibroIVA.txtSucursal.Text = txtNombre.Text
        frmReporteLibroIVA.txtIdSucursal.Text = CInt(txtId.Text)

        Me.Close()
    End Sub

    Private Sub reporteAqueoCaja()
        frmReporteArqueo.txtSucursal.Text = txtNombre.Text
        frmReporteArqueo.txtIdSucursal.Text = CInt(txtId.Text)

        Me.Close()
    End Sub

    Private Sub reporteHorarioPersonal()
        frmReporteHorario.txtSucursal.Text = txtNombre.Text
        frmReporteHorario.txtIdSucursal.Text = CInt(txtId.Text)

        Me.Close()
    End Sub
    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idproveedor
                listar(" Where _vs.idSucursal=" & txtBuscar.Text & " order by _vs.idSucursal")
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre del proveedor
                listar(" Where nombreFantasia Like '" & txtBuscar.Text & "%' Or nombreFantasia Like '" & txtBuscar.Text & "%' " & " order by nombreFantasia")
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
    Private Sub frmBuscarSucursal_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_reporteLibroIva = True Then
            banGl_reporteLibroIva = False

            frmReporteLibroIVA.Enabled = True
            frmReporteLibroIVA.Show()
            frmReporteLibroIVA.BringToFront()
            frmReporteLibroIVA.btnConsultar.Focus()
        End If
        If banGl_reporteArqueoCaja = True Then
            banGl_reporteArqueoCaja = False

            frmReporteArqueo.Enabled = True
            frmReporteArqueo.Show()
            frmReporteArqueo.BringToFront()
            frmReporteArqueo.btnConsultar.Focus()
        End If

        If banGl_reporteHorarioPersonal = True Then
            banGl_reporteHorarioPersonal = False

            frmReporteHorario.Enabled = True
            frmReporteHorario.Show()
            frmReporteHorario.BringToFront()
            frmReporteHorario.btnConsultar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
End Class

