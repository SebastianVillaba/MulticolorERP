Public Class frmPermisoUsuario
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim tipoMenuPrincipal As New tipoMenuPrincipal

    Dim bolTmpAgregarPermiso As Boolean = False

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listarGrupoUsuario("")
        tipoMenuPrincipal.listarTipoMenuPrincipalCbo(cboTipoMenu)
    End Sub

    Private Sub listarGrupoUsuario(ByVal v_sentencia As String)
        '-- listar el grupo de cliente en el descuento
        systemClass.SqlToLv(lvFormulario, "select idGrupoUsuario,nombreGrupoUsuario from grupoUsuario where activo=1 " & v_sentencia)
    End Sub

    Private Sub detalleGrupoUsuario(ByVal v_idFormulario As Integer)
        '-- ejecutar el procedimiento para listar el detalle del menu principal
        listarDetalleMenu("", 0)
    End Sub

    Private Sub listarDetalleMenu(ByVal v_sentencia As String, ByVal v_idGrupoUsuario As Integer)
        '-- eliminar los registros de la tabla temporal del detalle de grupo de usuarios
        sp_datosTabla.consulta_valor("delete from detMenuPrincipalTmp where idConfig=" & intGl_idConfigPc)
        '-- limpiar el datagrid
        dtgGrupoUsuario.Rows.Clear()
        '-- agregar los detalles a la tabla temporal de descuentos
        'MsgBox("Valor de v_idGripoUsuario   " & v_idGrupoUsuario)
        sp_datosTabla.sp_string("sp_agregarDetMenuPrincipalTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & v_idGrupoUsuario)
        '-- desplegar en la grilla el resultado del detalle del menu principal
        systemClass.SqlToDg_detalleMenuPrincipal(dtgGrupoUsuario, "select idFormulario,nombreFormulario,explicaForm,nombreTipoMenu,habilitado from detMenuPrincipalTmp " & v_sentencia & " order by nombreFormulario ")
    End Sub

    Private Sub guardarPermiso()
        '--- actualizar el datagrid de acuerdo a la seleccion realizada
        Dim bolTmpHabilitado As Boolean
        Dim intTmpIdFormulario As Integer
        For i As Integer = 0 To dtgGrupoUsuario.Rows.Count - 1
            If dtgGrupoUsuario.Rows(i).Cells(0).Value > 0 Then
                bolTmpHabilitado = CBool(dtgGrupoUsuario.Rows(i).Cells(4).Value)
                intTmpIdFormulario = dtgGrupoUsuario.Rows(i).Cells(0).Value
                'MsgBox("Valor de la columna  " & bolTmpHabilitado)
                If bolTmpHabilitado = True Then
                    sp_datosTabla.consulta_valor("update detMenuPrincipalTmp set habilitado=" & 1 & " where idFormulario=" & intTmpIdFormulario)
                    'MsgBox("El Valor del update  " & "update detMenuPrincipalTmp set habilitado=" & 1)
                Else
                    sp_datosTabla.consulta_valor("update detMenuPrincipalTmp set habilitado=" & 0 & " where idFormulario=" & intTmpIdFormulario)
                End If
                'sp_datosTabla.consulta_valor("update detMenuPrincipalTmp set habilitado=" & bolTmpHabilitado)
            End If
        Next
        '--------------------------------------------------------------
        Dim intTmpIdGrupoUsuario As Integer
        intTmpIdGrupoUsuario = CInt(txtIdGrupoUsuario.Text)
        If (fun_guardarSp("sp_guardarPermisoUsuario", intGl_idConfigPc & "," & intTmpIdGrupoUsuario & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo los registros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            bolTmpAgregarPermiso = False
            grFormulario.Enabled = True
            btnAgregar.Enabled = True
            btnCancelar.Enabled = False
            btnGuardar.Enabled = False
            '-- habilitar la grilla de los permisos
            For i As Integer = 0 To dtgGrupoUsuario.Rows.Count - 1
                dtgGrupoUsuario.Rows(i).Cells(4).ReadOnly = True
            Next
            Me.Refresh()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvFormulario_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvFormulario.SelectedIndexChanged
        For Each item As ListViewItem In lvFormulario.SelectedItems
            Dim intTmpIdMenu As Integer
            '-- valor al idMenu
            intTmpIdMenu = sp_datosTabla.un_dato_integer("idMenu", "cabMenuPrincipal", "idGrupoUsuario", CInt(item.SubItems(0).Text))
            '-- dar valor al id del descuento
            txtIdGrupoUsuario.Text = item.SubItems(0).Text
            txtNombreGrupoUsuario.Text = item.SubItems(1).Text
            txtIdMenu.Text = intTmpIdMenu
            '-- el detalle de los permisos
            listarDetalleMenu(" where idConfig=" & intGl_idConfigPc, CInt(txtIdGrupoUsuario.Text))
        Next
    End Sub

    Private Sub lvFormulario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvFormulario.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscarFormulario.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL DATAGRID --'
    '*****************'
    Private Sub dtgGrupoUsuario_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgGrupoUsuario.CellFormatting
        '-- formato de la habilitacion
        If bolTmpAgregarPermiso = False Then
            If dtgGrupoUsuario.Columns(e.ColumnIndex).Name.Equals("Column1") Then
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                e.CellStyle.BackColor = Color.White
            End If
        Else
            If dtgGrupoUsuario.Columns(e.ColumnIndex).Name.Equals("Column1") Then
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                e.CellStyle.BackColor = Color.MistyRose
            End If
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    '-- buscar el grupo de usuario
    Private Sub txtBuscarFormulario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarFormulario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- si solo se presiono enter
            If Len(txtBuscarFormulario.Text) = 0 Then
                '-- listar todo
                listarGrupoUsuario("")
            Else
                If IsNumeric(txtBuscarFormulario.Text) Then
                    '-- buscar por IdUsuario
                    listarGrupoUsuario(" and  idGrupoUsuario Like '" & txtBuscarFormulario.Text & "%' Or idGrupoUsuario Like '" & txtBuscarFormulario.Text & "%' " & "order by idGrupoUsuario")
                Else
                    '-- buscar por nick
                    listarGrupoUsuario(" and  nombreGrupoUsuario Like '" & txtBuscarFormulario.Text & "%' Or nombreGrupoUsuario Like '" & txtBuscarFormulario.Text & "%' " & "order by nombreGrupoUsuario")
                End If
            End If
            lvFormulario.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If Len(txtNombreGrupoUsuario.Text) = 0 Then
            MessageBox.Show("Debe consultar algún Grupo de Usuario para realizar esta operación..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        bolTmpAgregarPermiso = True
        btnAgregar.Enabled = False
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        grFormulario.Enabled = False
        '-- habilitar la grilla de los permisos
        For i As Integer = 0 To dtgGrupoUsuario.Rows.Count - 1
            dtgGrupoUsuario.Rows(i).Cells(4).ReadOnly = False
        Next
        Me.Refresh()
        dtgGrupoUsuario.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar los Cambios Realizados...!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarPermiso()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        bolTmpAgregarPermiso = False
        grFormulario.Enabled = True
        btnAgregar.Enabled = True
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        '-- habilitar la grilla de los permisos
        For i As Integer = 0 To dtgGrupoUsuario.Rows.Count - 1
            dtgGrupoUsuario.Rows(i).Cells(3).ReadOnly = True
        Next
    End Sub
    '------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS COMBOS --'
    '****************'
    Private Sub cboTipoMenu_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoMenu.SelectedIndexChanged
        If Len(txtIdMenu.Text) > 0 Then
            '-- el detalle de los permisos
            listarDetalleMenu(" where idTipoMenu=" & cboTipoMenu.SelectedValue & " and idconfig=" & intGl_idConfigPc, CInt(txtIdGrupoUsuario.Text))
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmPermisoUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.configuracionPermisoUsuario.Enabled = True
    End Sub
    '-----------------------------------------------------------------------------------------------------

   
End Class