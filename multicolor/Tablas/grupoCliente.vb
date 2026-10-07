Public Class grupoCliente
    Dim sys As New SystemClass

    'Listar Cargos en ComboBox
    Public Sub ListarGrupoCliente(ByVal lv As ListView, ByVal nombreGrupoCliente As String, ByVal tipoOrden As Integer)
        Try
            'ordenar por idCargo
            If tipoOrden = 1 Then
                sys.SqlToLv(lv, "Select g.idGrupoCliente, g.nombreGrupoCliente,g.activo,g.fechaAlta,g.fechaMod,rtrim(_vu.nombre)+','+rtrim(_vu.apellido),rtrim(_vu2.nombre)+','+rtrim(_vu2.apellido) from grupoCliente g inner join v_usuario _vu on g.idUsuarioAlta=_vu.idUsuario  inner join v_usuario _vu2 on _vu2.idUsuario=c.idUsuarioMod Order by 1")
                'MsgBox("paso por orden 1", MsgBoxStyle.Information)
            End If
            'ordenar por nombre de cargo
            If tipoOrden = 2 Then
                sys.SqlToLv(lv, "Select g.idGrupoCliente, g.nombreGrupoCliente,g.activo,g.fechaAlta,g.fechaMod,rtrim(_vu.nombre)+','+rtrim(_vu.apellido),rtrim(_vu2.nombre)+','+rtrim(_vu2.apellido) from grupoCliente g inner join v_usuario _vu on g.idUsuarioAlta=_vu.idUsuario  inner join v_usuario _vu2 on _vu2.idUsuario=c.idUsuarioMod Order by 2")
            End If
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
    Public Sub ListarGrupoCliente(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select g.idGrupoCliente, g.nombreGrupoCliente from grupoCliente g Order by nombreGrupoCliente", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Listar Cargos en ComboBox
    Public Sub grupoClienteCombo(ByVal cb As ComboBox)
        Try
            sys.SqlToCombo("Select idGrupoCliente,nombreGrupoCliente from grupoCliente where activo=1   Order by nombreGrupoCliente", cb)

        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class

