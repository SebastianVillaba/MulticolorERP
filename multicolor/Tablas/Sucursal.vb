Public Class Sucursal
    Dim sys As New SystemClass

    'Listar linea en un listview
    Public Sub listarSucursal(ByVal lv As ListView)
        Try
            sys.SqlToLv(lv, "Select idSucursal, rtrim(nombreFantasia) from v_sucursal where activo=1 order by nombreFantasia ")
            'Escondemos la columnna

            sys.PintarLv(lv)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub comboSucursal(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idSucursal, rtrim(nombreFantasia) from v_sucursal Order by nombreFantasia", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub comboSucursalTipo(ByVal cb As ComboBox, ByVal v_tipoSucursal As Integer)
        Try
            sys.SqlToCombo("Select idSucursal, rtrim(nombreFantasia) from v_sucursal where idTipoSucursal=" & v_tipoSucursal & " Order by nombreFantasia", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar sucursales dentro de la facturacion electronica
    Public Sub comboSucursalDTE(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select _vs.idSucursal, rtrim(_vs.nombreFantasia) from v_sucursal _vs inner join v_empresaContable _ve " & _
                           " on _vs.idPersona=_ve.idPersona where _vs.FE=1 Order by _vs.nombreFantasia", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
