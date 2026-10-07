Public Class cuentaCorriente
    Dim sys As New SystemClass
    'Listar en un listview
    Public Sub cuentaCorrienteListView(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select c.idCuenta, c.nombreBanco,c.nroCuenta,rtrim(m.nombreMoneda) as moneda from cuentaCorriente c inner join moneda m on c.idMoneda=m.idMoneda Order by c.idCuenta")

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar en ComboBox
    Public Sub cuentaCorrienteCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select c.idCuenta, rtrim(c.nombreBanco)+' / '+ltrim(c.nroCuenta),rtrim(m.nombreMoneda) as moneda from cuentaCorriente c inner join moneda m on c.idMoneda=m.idMoneda where c.activo=1 Order by c.nombreBanco", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
