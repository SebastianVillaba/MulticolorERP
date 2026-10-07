Public Class laboratorio
    Dim sys As New SystemClass
    'Listar Cargos en ComboBox
    Public Sub ListarLaboratorio(ByVal lv As ListView, ByVal nombre As String, ByVal tipoOrden As Integer)
        Try
            'ordenar por idCargo
            'If tipoOrden = 1 Then
            'ys.SqlToLv(lv, "Select _vl.idLaboratorio, _vl.nombre,_vlc.activo,c.fechaAlta,c.fechaMod,rtrim(_vu.nombre)+','+rtrim(_vu.apellido),rtrim(_vu2.nombre)+','+rtrim(_vu2.apellido) from Cargo c inner join v_usuario _vu on c.idUsuarioAlta=_vu.idUsuario  inner join v_usuario _vu2 on _vu2.idUsuario=c.idUsuarioMod Order by 1")
            'MsgBox("paso por orden 1", MsgBoxStyle.Information)
            'End If
            'ordenar por nombre de cargo
            'If tipoOrden = 2 Then
            ' sys.SqlToLv(lv, "Select c.idCargo, c.nombreCargo,c.activo,c.fechaAlta,c.fechaMod,rtrim(_vu.nombre)+','+rtrim(_vu.apellido),rtrim(_vu2.nombre)+','+rtrim(_vu2.apellido) from Cargo c inner join v_usuario _vu on c.idUsuarioAlta=_vu.idUsuario  inner join v_usuario _vu2 on _vu2.idUsuario=c.idUsuarioMod Order by 2")
            ' End If
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

    'Listar laboratorio en ComboBox
    Public Sub ListarLaboratorio(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select _vl.idLaboratorio, _vl.nombre from v_Laboratorio  _vl Order by 2", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class

