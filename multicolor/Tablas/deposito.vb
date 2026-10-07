Public Class deposito
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarDeposito(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idDeposito,idSucursal, rtrim(nombreDeposito) from deposito where activo=1 order by nombreDeposito ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar depositos en ComboBox
    Public Sub comboDeposito(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idDeposito,rtrim(nombreDeposito),idSucursal from deposito where activo=1 Order by nombreDeposito", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'Listar depositos en ComboBox pero por una parámetro enviado de idSucursal
    Public Sub comboDepositoSucursal(ByVal cb As ComboBox, ByVal v_idsucursal As Integer)
        Try
            sys.SqlToCombo("Select idDeposito,rtrim(nombreDeposito),idSucursal from deposito where activo=1 and idSucursal=" & v_idsucursal & " Order by nombreDeposito", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar depositos en ComboBox que son de farmacia
    Public Sub comboDepositoFarmacia(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select d.idDeposito,rtrim(d.nombreDeposito),d.idSucursal from deposito d inner join v_sucursal _vs on d.idSucursal=_vs.idSucursal where d.activo=1 " & _
                           " and _vs.idTipoSucursal=1 Order by nombreDeposito", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub comboDepositoHotel(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select d.idDeposito,rtrim(d.nombreDeposito)+'-'+ltrim(_vs.nombreFantasia) from deposito d inner join v_sucursal _vs " & _
                           " on d.idSucursal=_vs.idSucursal where d.activo=1 and d.idTipoDeposito=3 Order by _vs.nombreFantasia", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
