Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmAbmGrupoCliente
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdusuarioAlta As Integer
    Dim intIdcargo As Integer
    Dim blNuevo As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub deshabilitarObjetos() 'colocar como está originalmente
        txtNombreGrupo.Enabled = False
        txtNombreGrupo.BackColor = Color.LightSkyBlue
        chkActivo.Enabled = False

        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True

        '-- la seccion de busqueda
        grBuscar.Enabled = True
        'txtBuscar.Enabled = True
        txtBuscar.BackColor = Color.White
        'grOrdenar.Enabled = True

        'lvCargo.Enabled = True

    End Sub

    Sub habilitarObjetos() 'colocar como para agregar datos
        txtNombreGrupo.Enabled = True
        txtNombreGrupo.BackColor = Color.White
        chkActivo.Enabled = True

        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False

        '-- la seccion de busqueda
        'txtBuscar.Enabled = False
        txtBuscar.BackColor = Color.LightSkyBlue
        'grOrdenar.Enabled = False
        grBuscar.Enabled = False
        'lvCargo.Enabled = False
    End Sub

    'listar
    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvCargo, "Select idGrupoCliente,nombreGrupoCliente from grupoCliente" & where)
        ' dimensionar las columnas
        lvCargo.Columns(0).Width = 80
        lvCargo.Columns(1).Width = 250
        lvCargo.Columns(0).Text = "ID Grupo"
        lvCargo.Columns(1).Text = "Nombre del Grupo"
        lvCargo.Scrollable = True
    End Sub

    Private Sub imprimirGrupoCliente()
        '-- reporte por hora y sucursal
        Try

            Dim pvParametros1 As New ParameterValues()

            Dim pvIdPersonaJur As New ParameterValues()
            Dim pvIdSucursal As New ParameterValues()
            Dim pvIdUsuario As New ParameterValues()
            Dim pvIdConfig As New ParameterValues()
            '-- instaciar el parametro
            Dim v_idGrupoCli As New ParameterDiscreteValue

            Dim v_idPersonaJur As New ParameterDiscreteValue()
            Dim v_idSucursal As New ParameterDiscreteValue()
            Dim v_idUsuario As New ParameterDiscreteValue()
            Dim v_idConfig As New ParameterDiscreteValue()
            '------------------------------------
            Dim rpt As New rpt_datosGrupoCli
            Dim ofrm As New crv()

            'MsgBox("Antes de asignar los valores a las variables")

            v_idGrupoCli.Value = CInt(txtIdGrupo.Text)

            'MsgBox("Despues de asignar los valores a las variables")

            v_idPersonaJur.Value = intGl_idPersonaJur
            v_idSucursal.Value = intGl_idSucursal
            v_idUsuario.Value = intGl_idUsuario
            v_idConfig.Value = intGl_idConfigPc
            ' añadir el parámetro a la colección de parámetros

            pvParametros1.Add(v_idGrupoCli)

            'MsgBox("Despues de añadir los parametros")

            pvIdPersonaJur.Add(v_idPersonaJur)
            pvIdSucursal.Add(v_idSucursal)
            pvIdUsuario.Add(v_idUsuario)
            pvIdConfig.Add(v_idConfig)
            ' tomar del informe, el parámetro que necesitemos,
            ' a través de su colección de campos de parámetros,
            ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
            rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
            rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
            rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
            rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)

            rpt.DataDefinition.ParameterFields("@idGrupoCliente").ApplyCurrentValues(pvParametros1)
            '-- asignar los valores al objeto del reporte
            ofrm.CrystalReportViewer1.ReportSource = rpt
            '-- procedimiento para evitar el usuario y contraseña de la base de datos
            evitarPassDatabase(rpt)
            '-- mostrar el reporte
            ofrm.WindowState = FormWindowState.Maximized
            ofrm.Show()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        txtIdGrupo.Text = 0
        chkActivo.Checked = True
        txtNombreGrupo.Text = ""
        txtNombreGrupo.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtNombreGrupo.Text = ""
        chkActivo.Checked = False
        lvCargo.Focus()
    End Sub

    'Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
    '    Me.Close()
    'End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'controlar si existe algun error
        If txtNombreGrupo.Text = "" Then
            MessageBox.Show("Debe ingresar algún Nombre para el Cargo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If blNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insGrupoCliente", "'" & txtNombreGrupo.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
                inicializar()
            End If
        Else
            '******************'
            '-- MODIFICACION --'
            '******************'
            If (fun_guardarSp("sp_updGrupoCliente", CInt(txtIdGrupo.Text) & "," & "'" & txtNombreGrupo.Text & "'" & "," & chkActivo.Checked & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
                inicializar()
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        blNuevo = False
        habilitarObjetos()
        txtNombreGrupo.Focus()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Me.Enabled = False
        imprimirGrupoCliente()
        Me.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCargo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCargo.KeyPress, lvCargo.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCargo.SelectedIndexChanged
        For Each item As ListViewItem In lvCargo.SelectedItems
            txtIdGrupo.Text = item.SubItems(0).Text
            txtNombreGrupo.Text = item.SubItems(1).Text
            chkActivo.Checked = sp_datosTabla.un_dato("activo", "grupoCliente", "idGrupoCliente", CInt(item.SubItems(0).Text))
            txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "grupoCliente", "idGrupoCliente", CInt(item.SubItems(0).Text))
            txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "grupoCliente", "idGrupoCliente", CInt(item.SubItems(0).Text))
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioAlta", "grupoCliente", "idGrupoCliente", CInt(item.SubItems(0).Text)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuario", "idUsuario", sp_datosTabla.un_dato("idUsuarioMod", "grupoCliente", "idGrupoCliente", CInt(item.SubItems(0).Text)))
        Next
        ' txtUsuarioAlta.Text = sp_obtenerDatosUsuario.nombreUsuario(intIdusuarioAlta)
        'strNombreUsuario = sp_obtenerDatosUsuario.nombreUsuario(4)
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idGrupo
                listar(" Where idGrupoCliente=" & txtBuscar.Text)
            Else
                ' ordenar por nombre del grupo
                listar(" Where nombreGrupoCliente Like '" & txtBuscar.Text & "%' Or nombreGrupoCliente Like '" & txtBuscar.Text & "%' " & "order by nombreGrupoCliente")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvCargo.Select()
            'lvCargo.Focus()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmAbmGrupoCliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.abmGrupoCliente.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------------------------

End Class