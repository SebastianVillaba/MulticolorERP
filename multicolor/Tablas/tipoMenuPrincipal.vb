Public Class tipoMenuPrincipal
    Dim sys As New SystemClass

    'Listar tipo de menu en un ListView
    Public Sub listarTipoMenuPrincipalLv(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idTipoMenu, rtrim(nombreTipoMenu) from tipoMenuPrincipal where idEntidad=" & intGl_idEntidad & " order by nombreTipoMenu")
            'Escondemos la columnna
            lv.Columns(2).Width = 0
            lv.Columns(3).Width = 0
            lv.Columns(4).Width = 0
            lv.Columns(5).Width = 0
            lv.Columns(6).Width = 0
            If lv.Items.Count < 7 Then
                lv.Columns(1).Width = lv.Width
            Else
                lv.Columns(1).Width = lv.Width - 20
            End If

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar el Tipo de Menu en un ComboBox
    Public Sub listarTipoMenuPrincipalCbo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idTipoMenu, rtrim(nombreTipoMenu) from tipoMenuPrincipal where idEntidad=" & intGl_idEntidad & " Order by nombreTipoMenu", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
