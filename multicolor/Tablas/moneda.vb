Public Class moneda
    Dim sys As New SystemClass
    'Listar Monedas en listView
    Public Sub ListarMoneda(ByVal lv As ListView)
        Try
            '-- listar la consulta de la moneda
            sys.SqlToLv(lv, "Select idMoneda,nombreMoneda from moneda where activo=1")
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

    'Listar Monedas en ComboBox
    Public Sub listarMonedaCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idMoneda,rtrim(nombreMoneda) from moneda where activo=1", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' listar monedas en combobox dentro de un datagridview 
    Public Sub listarMonedaComboDataGridView(ByVal cb As DataGridViewComboBoxColumn)
        Try
            sys.SqlToComboDataGridView("Select idMoneda,rtrim(nombreMoneda) from moneda where activo=1", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
