Public Class frmBuscarStockInicial
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
        systemClass.SqlToLv(lvBuscar, "select cs.idStockIni,_vs.nombreFantasia as Sucursal," & _
                                        "([maxifarmasa].[dbo].[funTraerUsuario](cs.idUsuarioAlta)) as Responsables,cs.fechaAlta " & _
                                        "from cabStockIni cs inner join v_sucursalT _vs " & _
                                        "on cs.idSucursal=_vs.idSucursal " & where)
        'txtSql.Text = "select cs.idStockIni,_vs.nombreFantasia as Sucursal," & _
        '"([maxifarmasa].[dbo].[funTraerUsuario](cp.idUsuarioAlta)) as Responsables,cp.fechaAlta " & _
        '"from cabStockIni cs inner join v_sucursalT _vs " & _
        '"on cs.idSucursal=_vs.idSucursal " & where
    End Sub
    '------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre de la sucursal
                listar(" Where _vs.nombreFantasia Like '" & txtBuscar.Text & "%' Or _vs.nombreFantasia Like '" & txtBuscar.Text & "%' " & "order by _vs.nombreFantasia")
            Else
                '-- buscar por idStockIni
                listar(" Where cs.idStockIni=" & txtBuscar.Text & " order by cs.idStockIni")
            End If
            lvBuscar.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If IsNumeric(txtIdMov.Text) Then
            If txtIdMov.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    banGl_buscarStockInicial = True
                    '-- listar el detalle
                    frmConsultaStockInicial.listarDetalle(CInt(txtIdMov.Text))
                    '-- los datos
                    frmConsultaStockInicial.actualizarCabecera(CInt(txtIdMov.Text))
                    '------------------------------------------------------------
                    Me.Close()
                    frmConsultaStockInicial.Enabled = True
                    frmConsultaStockInicial.Show()
                    frmConsultaStockInicial.BringToFront()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
    '------------------------------------------------------------------------------------

    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmBuscarBuscarStockInicial_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmConsultaStockInicial.Enabled = True
        frmConsultaStockInicial.Show()
        frmConsultaStockInicial.BringToFront()
    End Sub
End Class