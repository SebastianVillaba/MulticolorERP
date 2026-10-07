Public Class impuesto
    Dim sys As New SystemClass

    'Listar Cargos en ComboBox
    Public Sub ListarImpuesto(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idImpuesto, rtrim(nombreImpuesto) from impuesto order by nombreImpuesto")
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

    'Listar Cargos en ComboBox
    Public Sub ListarImpuesto(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idImpuesto, rtrim(nombreImpuesto) from Impuesto  Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class

