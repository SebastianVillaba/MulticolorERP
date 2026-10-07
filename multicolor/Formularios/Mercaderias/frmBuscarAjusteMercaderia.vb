Public Class frmBuscarAjusteMercaderia
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
        If banGl_consultaAjustePositivoMercaderia = True Then
            '-- ajuste positivo de mercaderia
            systemClass.SqlToLv(lvBuscar, "select ca.idAjustepo,_vs.nombreFantasia as Sucursal," & _
                                            "([dbo].[funTraerUsuario](ca.idUsuarioAlta)) as responsables,ca.fechaAlta " & _
                                            "from cabAjustepo ca inner join v_sucursalT _vs on ca.idSucursal=_vs.idSucursal" & where)
            txtSql.Text = "select ca.idAjustepo,_vs.nombreFantasia as Sucursal," & _
                                            "([dbo].[funTraerUsuario](ca.idUsuarioAlta)) as responsables,ca.fechaAlta " & _
                                            "from cabAjustepo ca inner join v_sucursalT _vs on ca.idSucursal=_vs.idSucursal" & where
        End If
        If banGl_consultaAjusteNegativoMercaderia = True Then
            '-- ajuste negativo de mercaderia
            systemClass.SqlToLv(lvBuscar, "select ca.idAjustene,_vs.nombreFantasia as Sucursal," & _
                                            "([dbo].[funTraerUsuario](ca.idUsuarioAlta)) as responsables,ca.fechaAlta " & _
                                            "from cabAjustene ca inner join v_sucursalT _vs on ca.idSucursal=_vs.idSucursal" & where)

            txtSql.Text = "select ca.idAjustene,_vs.nombreFantasia as Sucursal," & _
                                            "([dbo].[funTraerUsuario](ca.idUsuarioAlta)) as responsables,ca.fechaAlta " & _
                                            "from cabAjustene ca inner join v_sucursalT _vs on ca.idSucursal=_vs.idSucursal" & where
        End If
    End Sub

    Private Sub controlarModulo()
        If banGl_consultaAjusteNegativoMercaderia = True Then
            '-- ajuste negativo

            '-- listar el detalle
            frmConsultaAjusteNegativo.listarDetalle(CInt(txtIdMov.Text))
            '-- los datos
            frmConsultaAjusteNegativo.actualizarCabecera(CInt(txtIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If

        If banGl_consultaAjustePositivoMercaderia = True Then
            '-- ajuste positivo

            '-- listar el detalle
            frmConsultaAjustePositivo.listarDetalle(CInt(txtIdMov.Text))
            '-- los datos
            frmConsultaAjustePositivo.actualizarCabecera(CInt(txtIdMov.Text))
            '------------------------------------------------------------
            Me.Close()
        End If
    End Sub
    '------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre del responsable
                listar("")
            Else
                '-- buscar por idAjuste
                If banGl_consultaAjustePositivoMercaderia = True Then
                    '-- ajuste positivo
                    listar(" Where ca.idAjustepo=" & txtBuscar.Text & " order by ca.idAjustepo")
                End If
                If banGl_consultaAjusteNegativoMercaderia = True Then
                    '-- ajuste negativo
                    listar(" Where ca.idAjustene=" & txtBuscar.Text & " order by ca.idAjustene")
                End If
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
                    controlarModulo()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Ajuste..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
    Private Sub frmBuscarBuscarPedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_consultaAjusteNegativoMercaderia = True Then
            '-- ajuste negativo
            banGl_consultaAjusteNegativoMercaderia = False

            frmConsultaAjusteNegativo.Enabled = True
            frmConsultaAjusteNegativo.Show()
            frmConsultaAjusteNegativo.BringToFront()
        End If

        If banGl_consultaAjustePositivoMercaderia = True Then
            '-- ajuste positivo
            banGl_consultaAjustePositivoMercaderia = False

            frmConsultaAjustePositivo.Enabled = True
            frmConsultaAjustePositivo.Show()
            frmConsultaAjustePositivo.BringToFront()
        End If

    End Sub
End Class