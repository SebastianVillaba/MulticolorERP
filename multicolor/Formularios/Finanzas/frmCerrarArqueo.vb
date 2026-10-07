Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmCerrarArqueo
    '******************************'
    '-- VARIABLES DE TIPO OBJETO --'
    '******************************'
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClas As New SystemClass
    Dim systemClass As New SystemClass
    '*************************'
    '-- VARIABLES ESCALARES --'
    '*************************'
    Dim bolTmpError As Boolean = False

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
        '-- eliminar todos los personales de la tabla temporal
        sp_datosTabla.consulta_valor("delete from detCajaPersonalTmp where idSucursal=" & intGl_idSucursal)
        listarPersonal("")
    End Sub

    Sub listarPersonal(ByVal where As String)
        systemClass.SqlToLv(lvPersonal, "Select _vp.idPersonal,_vp.nombre,_vp.apellido from v_personal _vp" & where)
        ' dimensionar las columnas
        lvPersonal.Columns(0).Width = 60
        lvPersonal.Columns(1).Width = 200
        lvPersonal.Columns(2).Width = 200
        lvPersonal.Columns(0).Text = "ID Per."
        lvPersonal.Columns(1).Text = "Nombre"
        lvPersonal.Columns(2).Text = "Apellido"
        lvPersonal.Scrollable = True
    End Sub

    Private Sub listarPersonalCaja()
        systemClass.SqlToLv(lvPersonalCaja, "Select dcp.idPersonal,_vp.nombre,_vp.apellido from detCajaPersonalTmp dcp inner join v_personal _vp on dcp.idPersonal=_vp.idPersonal where dcp.idSucursal=" & intGl_idSucursal)
        ' dimensionar las columnas
        lvPersonalCaja.Columns(0).Width = 60
        lvPersonalCaja.Columns(1).Width = 200
        lvPersonalCaja.Columns(2).Width = 200
        lvPersonalCaja.Columns(0).Text = "ID Per."
        lvPersonalCaja.Columns(1).Text = "Nombre"
        lvPersonalCaja.Columns(2).Text = "Apellido"
        lvPersonalCaja.Scrollable = True
    End Sub

    '-- procedimiento para guardar la caja
    Private Sub guardarArqueo()
        Me.Enabled = False

        '-- los idmovimientos
        Dim intTmpIdMovIni1 As Integer
        Dim intTmpIdMovIni2 As Integer
        Dim intTmpIdMovFin1 As Integer
        Dim intTmpIdMovFin2 As Integer
        '-- el total
        Dim douTmpTotalCaja As Double

        intTmpIdMovIni1 = CInt(systemClas.convertirNumeroSeparado(txtMovini1.Text))
        intTmpIdMovIni2 = CInt(systemClas.convertirNumeroSeparado(txtMovini2.Text))
        intTmpIdMovFin1 = CInt(systemClas.convertirNumeroSeparado(txtMoviFin1.Text))
        intTmpIdMovFin2 = CInt(systemClas.convertirNumeroSeparado(txtMovFin2.Text))
        'MsgBox("Valor de intTmpIdMovIni1  " & intTmpIdMovIni1)
        'MsgBox("Valor de intTmpIdMovFin1  " & intTmpIdMovFin1)
        'MsgBox("Valor de intTmpIdMovIni2  " & intTmpIdMovIni2)
        'MsgBox("Valor de intTmpIdMovFin2  " & intTmpIdMovFin2)

        douTmpTotalCaja = CDec(txtTotalArqueo.Text)

        If (fun_guardarSp("sp_guardarArqueo", intGl_idConfigPc & "," & intGl_idSucursal & "," & intTmpIdMovIni1 & "," & intTmpIdMovFin1 & "," & intTmpIdMovIni2 & "," & intTmpIdMovFin2 & "," & douTmpTotalCaja & "," & intGl_idUsuario, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardaron los registros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '-- imprimir la caja
            Dim intTmpIdCaja As Integer
            intTmpIdCaja = sp_datosTabla.consulta_valor("select max(idCaja) from cabCaja where idSucursal=" & intGl_idSucursal)
            Me.Enabled = False
            '---------------------------------------------------------'
            '-- verificar si esta configurado para imprimir la caja --'
            '---------------------------------------------------------'
            If sp_datosTabla.consulta_valorBoolean("select imprimirCaja from sucursal where idSucursal=" & intGl_idSucursal) = True Then
                '-- verificar el tipo de impresion de la sucursal
                If (sp_datosTabla.consulta_valor("select imprimirVtaHeladeria from sucursal where hoteleria=0 and idSucursal=" & intGl_idSucursal)) = True Then
                    imprimirCajaTicket(intTmpIdCaja)
                Else
                    imprimirCaja(intTmpIdCaja)
                End If
                '---------------------------------------------------------------------------------
                Me.Close()
                frmArqueoCaja.Enabled = True
                frmArqueoCaja.Show()
                frmArqueoCaja.BringToFront()
                frmArqueoCaja.limpiar()
            Else
                intGl_idCaja = sp_datosTabla.consulta_valor("select max(idCaja) from cabCaja where idSucursal=" & intGl_idSucursal)

                frmMostrarCaja.Show()
                frmMostrarCaja.BringToFront()
                frmArqueoCaja.limpiar()
                frmArqueoCaja.Close()
                Me.Close()
            End If
        End If
    End Sub

    '-- impresion de la caja
    Private Sub imprimirCaja(ByVal codigoCaja As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idCaja As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_arqueo()
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idCaja.Value = codigoCaja
        v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idCaja)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCaja").ApplyCurrentValues(pvParametros)
        rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Show()
    End Sub

    '-- impresion de la caja en el ticket
    Private Sub imprimirCajaTicket(ByVal codigoCaja As Integer)
        Dim pvParametros As New ParameterValues()
        Dim pvIdPersonaJur As New ParameterValues()
        Dim pvIdSucursal As New ParameterValues()
        Dim pvIdUsuario As New ParameterValues()
        Dim pvIdConfig As New ParameterValues()
        '-- instaciar el parametro
        Dim v_idCaja As New ParameterDiscreteValue()
        Dim v_idPersonaJur As New ParameterDiscreteValue()
        Dim v_idSucursal As New ParameterDiscreteValue()
        Dim v_idUsuario As New ParameterDiscreteValue()
        Dim v_idConfig As New ParameterDiscreteValue()
        '------------------------------------
        Dim rpt As New rpt_arqueoTicket
        Dim ofrm As New crv()
        'asiganar el valor a los  parametros
        v_idCaja.Value = codigoCaja
        v_idPersonaJur.Value = sp_datosTabla.un_dato_integer("idPersonaJur", "configpc", "idConfig", intGl_idConfigPc)
        v_idSucursal.Value = intGl_idSucursal
        v_idUsuario.Value = intGl_idUsuario
        v_idConfig.Value = intGl_idConfigPc
        ' añadir el parámetro a la colección de parámetros
        pvParametros.Add(v_idCaja)
        pvIdPersonaJur.Add(v_idPersonaJur)
        pvIdSucursal.Add(v_idSucursal)
        pvIdUsuario.Add(v_idUsuario)
        pvIdConfig.Add(v_idConfig)
        ' tomar del informe, el parámetro que necesitemos,
        ' a través de su colección de campos de parámetros,
        ' y aplicar a dicho parámetro los valores de los parámetros que están en la colección (en este caso sólo uno)
        rpt.DataDefinition.ParameterFields("@idCaja").ApplyCurrentValues(pvParametros)
        rpt.DataDefinition.ParameterFields("@idPersonaJur").ApplyCurrentValues(pvIdPersonaJur)
        rpt.DataDefinition.ParameterFields("@idSucursal").ApplyCurrentValues(pvIdSucursal)
        rpt.DataDefinition.ParameterFields("@idUsuario").ApplyCurrentValues(pvIdUsuario)
        rpt.DataDefinition.ParameterFields("@idConfig").ApplyCurrentValues(pvIdConfig)
        '-- asignar los valores al objeto del reporte
        ofrm.CrystalReportViewer1.ReportSource = rpt
        '-- procedimiento para evitar el usuario y contraseña de la base de datos
        evitarPassDatabase(rpt)
        '-- mostrar el reporte
        ofrm.WindowState = FormWindowState.Maximized
        ofrm.Show()
    End Sub

    '-- controlar si existe error antes de guardar la caja
    Private Sub controlarError()
        Dim bolTmpNoExiste As Boolean = False
        If (sp_datosTabla.consulta_valor("select idConfig,idSucursal from detCajaPersonalTmp where idSucursal=" & intGl_idSucursal)) > 0 Then
            bolTmpNoExiste = True
        Else
            bolTmpNoExiste = False
        End If
        If bolTmpNoExiste = False Then
            MessageBox.Show("No existe personales cargados para realizar el cierre del Arqueo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bolTmpError = True
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------
    '*******************'
    '-- LOS LISTVIEW --'
    '*******************'
    Private Sub lvPersonal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvPersonal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si es seleccionado algun item
            If Len(txtIdPersonal.Text) = 0 Then
                MessageBox.Show("Debe introducir un Personal Responsable para anexar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- agregar a la tabla temporal
            sp_datosTabla.sp_string("sp_agregarPersonalCaja", intGl_idConfigPc & "," & intGl_idSucursal & "," & CInt(txtIdPersonal.Text))
            listarPersonalCaja()
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvPersonal_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvPersonal.SelectedIndexChanged
        For Each item As ListViewItem In lvPersonal.SelectedItems
            txtIdPersonal.Text = item.SubItems(0).Text
        Next
    End Sub

    Private Sub lvPersonalCaja_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvPersonalCaja.SelectedIndexChanged
        For Each item As ListViewItem In lvPersonalCaja.SelectedItems
            txtIdPersonalCaja.Text = item.SubItems(0).Text
        Next
    End Sub
    '---------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idcargo
                listarPersonal(" Where _vp.idPersonal Like '" & txtBuscar.Text & "%' Or _vp.idPersonal Like '" & txtBuscar.Text & "%' " & "order by _vp.idPersonal")
            Else
                ' ordenar por nombre de cargo
                listarPersonal(" Where _vp.nombre Like '" & txtBuscar.Text & "%' Or _vp.nombre Like '" & txtBuscar.Text & "%' " & " order by _vp.nombre")
            End If
            lvPersonal.Focus()
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        '-- solo si es seleccionado algun item
        If Len(txtIdPersonal.Text) = 0 Then
            MessageBox.Show("Debe introducir un Personal Responsable para anexar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- agregar a la tabla temporal
        sp_datosTabla.sp_string("sp_agregarPersonalCaja", intGl_idConfigPc & "," & intGl_idSucursal & "," & CInt(txtIdPersonal.Text))
        listarPersonalCaja()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If Len(txtIdPersonalCaja.Text) = 0 Then
            MessageBox.Show("Debe introducir un Personal Responsable para Eliminar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        sp_datosTabla.consulta_valor("delete from detCajaPersonalTmp where idPersonal=" & CInt(txtIdPersonalCaja.Text) & " and idSucursal=" & intGl_idSucursal)
        listarPersonalCaja()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        bolTmpError = False
        Me.Enabled = False

        controlarError()
        If bolTmpError = False Then
            If MessageBox.Show("Desea Cerrar La Caja..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                guardarArqueo()
            End If
        End If

        Me.Enabled = True
    End Sub
    '---------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmCerrarArqueo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmArqueoCaja.btnGuardar.Enabled = True
        frmArqueoCaja.btnParar.Enabled = True
        frmArqueoCaja.Enabled = True
        frmArqueoCaja.Show()
        frmArqueoCaja.BringToFront()
        frmArqueoCaja.Refresh()
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------


End Class