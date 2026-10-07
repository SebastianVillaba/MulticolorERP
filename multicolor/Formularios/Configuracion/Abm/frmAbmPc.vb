Public Class frmAbmPc
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim sucursal As New Sucursal
    Dim empresaContable As New empresaContable
    Dim deposito As New deposito

    Dim banNuevo As Boolean = False
    Dim banError As Boolean = False
    Dim intIdDepositoSucursal As Integer

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
        listar(" Where c.idConfig >=0  Or c.idConfig <=100" & "order by c.idConfig")
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lv, "Select c.idConfig,c.nombrepc,_vs.nombreFantasia as sucursal from configPc c inner join v_sucursal _vs on c.idSucursal=_vs.idSucursal " & where)
        'txtSql.Text = "Select c.idConfig,c.nombrepc,_vs.nombreFantasia as sucursal from configPc c inner join v_sucursal _vs on c.idSucursal=_vs.idSucursal " & where
    End Sub

    Private Sub habilitarObjetos()
        '************'
        ' habilitar '
        '************'
        '-- los txt
        txtNombre.Enabled = True
        txtNombre.BackColor = Color.White
        txtIdPc.Enabled = True
        txtIdPc.BackColor = Color.White
        txtSerialHd.Enabled = True
        txtSerialHd.ReadOnly = False
        txtSerialHd.BackColor = Color.White
        txtNombreImpresora.Enabled = True
        txtNombreImpresora.BackColor = Color.White
        '-- combos
        cboContable.Enabled = True
        cboContable.BackColor = Color.White
        cboSucursal.Enabled = True
        cboSucursal.BackColor = Color.White
        cboDeposito.Enabled = True
        cboDeposito.BackColor = Color.White
        cboDepositoRemision.Enabled = True
        cboDepositoRemision.BackColor = Color.White
        '-- los chk
        chkActivo.Enabled = True
        chkDepositoVenta.Enabled = True
        chkVenta.Enabled = True
        chkHorario.Enabled = True
        chkPrincipal.Enabled = True
        chkDobleImpresion.Enabled = True
        chkQr.Enabled = True
        '-- bonotes
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        '**************'
        ' deshabilitar '
        '**************'
        '-- los txt
        txtIdConfig.Enabled = False
        txtIdConfig.BackColor = Color.LightSkyBlue
        '-- botones
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        btnBuscarFacturaDE.Enabled = True
        btnBuscarNcrDE.Enabled = True
        '-- el grupo
        grBuscar.Enabled = False
        Me.Refresh()

    End Sub

    Private Sub deshabilitarObjeto()
        '************'
        ' deshabilitar '
        '************'
        '-- los txt
        txtNombre.Enabled = False
        txtNombre.BackColor = Color.LightSkyBlue
        txtIdPc.Enabled = False
        txtIdPc.BackColor = Color.LightSkyBlue
        txtSerialHd.Enabled = False
        txtSerialHd.BackColor = Color.LightSkyBlue
        txtNombreImpresora.Enabled = False
        txtNombreImpresora.BackColor = Color.LightSkyBlue
        '-- combos
        cboContable.Enabled = False
        cboContable.BackColor = Color.LightSkyBlue
        cboSucursal.Enabled = False
        cboSucursal.BackColor = Color.LightSkyBlue
        cboDeposito.Enabled = False
        cboDeposito.BackColor = Color.LightSkyBlue
        cboDepositoRemision.Enabled = False
        cboDepositoRemision.BackColor = Color.LightSkyBlue
        '-- los chk
        chkActivo.Enabled = False
        chkDepositoVenta.Enabled = False
        chkVenta.Enabled = False
        chkHorario.Enabled = False
        chkPrincipal.Enabled = False
        chkDobleImpresion.Enabled = False
        chkQr.Enabled = False
        '-- bonotes
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnBuscarFacturaDE.Enabled = False
        btnBuscarNcrDE.Enabled = False
        '**************'
        ' deshabilitar '
        '**************'
        '-- los txt
        txtIdConfig.Enabled = False
        txtIdConfig.BackColor = Color.LightSkyBlue
        '-- botones
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        '-- el grupo
        grBuscar.Enabled = True
    End Sub

    Private Sub vaciarObjetos()
        '-- los txt
        txtIdConfig.Text = 0
        txtIdPc.Text = ""
        txtNombre.Text = ""
        txtSerialHd.Text = ""
        txtUsuarioAlta.Text = ""
        txtUsuarioMod.Text = ""
        txtFechaAlta.Text = ""
        txtFechaMod.Text = ""
        txtIdDetFacturaFac.Text = 0
        txtFacturaFac.Text = ""
        txtIdNcrDE.Text = 0
        txtNcrDE.Text = ""
        '-- los chk
        chkActivo.Checked = False
        chkDepositoVenta.Checked = False
        chkVenta.Checked = False
        chkHorario.Checked = False
        chkDobleImpresion.Checked = False
        chkQr.Checked = False
    End Sub

    Private Sub controlarPC()
        '-- se debe ingresar el nombre de la pc
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe Ingresar el nombre de la PC..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        '-- el id de la pc
        If txtIdPc.Text = "" Then
            MessageBox.Show("Debe Ingresar el ID de la PC..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        '-- el serial del disco duro
        'If txtSerialHd.Text = "" Then
        'MsgBox("Debe Ingresar el Serial del HD..!", MsgBoxStyle.Exclamation)
        'End If

    End Sub

    Private Sub guardarPc()
        '-- si el nro del serial está en blanco
        Dim strTmpserialHd As String
        If Len(txtSerialHd.Text) = 0 Then
            strTmpserialHd = "''"
        Else
            strTmpserialHd = txtSerialHd.Text
        End If
        '-- las variable
        '-- idsucursal
        Dim intTmpIdSucursal As Integer = 0
        intTmpIdSucursal = cboSucursal.SelectedValue
        '-- idPersonaJur
        Dim intTmpIdPersonaJur As Integer = 0
        Dim intTmpIdEmpresaContable As Integer
        intTmpIdEmpresaContable = cboContable.SelectedValue
        intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from v_empresaContable where idEmpresaContable=" & intTmpIdEmpresaContable)
        '-- habilitarVentaDeposito
        Dim bolTmpHabilitarVentaDeposito As Boolean = False
        bolTmpHabilitarVentaDeposito = chkDepositoVenta.Checked
        Dim intTmpIdDepositoVenta As Integer
        If chkDepositoVenta.Checked = True Then
            '-- si existe un deposito
            intTmpIdDepositoVenta = cboDeposito.SelectedValue
        End If
        '-- el deposito de la remision
        Dim intTmpIdDepositoRemision As Integer
        intTmpIdDepositoRemision = cboDepositoRemision.SelectedValue
        '-- habilitar horario
        Dim bolTmpHabilitarHoario As Boolean = False
        bolTmpHabilitarHoario = chkHorario.Checked
        '******************************************'
        ' procedimiento para insertar una nueva pc '
        '******************************************'
        If (fun_guardarSp("sp_insConfigPc", intTmpIdSucursal & "," & intTmpIdPersonaJur & ",'" & txtNombreImpresora.Text & "'" & "," & _
                          "'" & txtNombre.Text & "'" & "," & "'" & txtIdPc.Text & "'" & "," & "'" & strTmpserialHd & "'" & "," & chkVenta.Checked & "," & _
                          bolTmpHabilitarVentaDeposito & "," & intTmpIdDepositoVenta & "," & intTmpIdDepositoRemision & "," & bolTmpHabilitarHoario & "," & _
                          intGl_idUsuario & "," & chkPrincipal.Checked & "," & _
                          chkDobleImpresion.Checked & "," & chkQr.Checked & "," & txtIdDetFacturaFac.Text & "," & txtIdNcrDE.Text, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            '-- se guardo los registros
            MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            deshabilitarObjeto()
            listar(" Where c.idConfig >=0  Or c.idConfig <=100" & "order by c.idConfig")
        End If

    End Sub

    Private Sub modificarPC()
        Try
            '-- si el nro del serial está en blanco
            Dim strTmpserialHd As String
            If Len(txtSerialHd.Text) = 0 Then
                strTmpserialHd = "''"
            Else
                strTmpserialHd = txtSerialHd.Text
            End If
            '-- las variable
            '-- idConfig
            'MsgBox("Paso 1")
            Dim intTmpIdConfig As Integer = 0
            intTmpIdConfig = txtIdConfig.Text
            '-- idsucursal
            Dim intTmpIdSucursal As Integer = 0
            intTmpIdSucursal = cboSucursal.SelectedValue
            'MsgBox("Paso 2")
            '-- idPersonaJur
            Dim intTmpIdPersonaJur As Integer = 0
            Dim intTmpIdEmpresaContable As Integer
            intTmpIdEmpresaContable = cboContable.SelectedValue
            intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from v_empresaContable where idEmpresaContable=" & intTmpIdEmpresaContable)
            'MsgBox("Paso 3")
            '-- habilitarVentaDeposito
            Dim bolTmpHabilitarVentaDeposito As Boolean = False
            bolTmpHabilitarVentaDeposito = chkDepositoVenta.Checked
            Dim intTmpIdDepositoVenta As Integer
            If chkDepositoVenta.Checked = True Then
                '-- si existe un deposito
                intTmpIdDepositoVenta = cboDeposito.SelectedValue
                ' MsgBox("Paso 4")
            End If
            '-- el deposito de la remision
            Dim intTmpIdDepositoRemision As Integer
            intTmpIdDepositoRemision = cboDepositoRemision.SelectedValue
            'MsgBox("Paso 5")
            '-- habilitar horario
            Dim bolTmpHabilitarHorario As Boolean = False
            bolTmpHabilitarHorario = chkHorario.Checked
            'MsgBox("Paso 6")
            '*******************************************'
            ' procedimiento para modificar una nueva pc '
            '*******************************************'
            If (fun_guardarSp("sp_updConfigPc", intTmpIdConfig & "," & intTmpIdSucursal & "," & intTmpIdPersonaJur & ",'" & txtNombreImpresora.Text & _
                              "'" & "," & "'" & txtNombre.Text & "'" & "," & "'" & txtIdPc.Text & "'" & "," & "'" & strTmpserialHd & "'" & "," & chkVenta.Checked & _
                              "," & bolTmpHabilitarVentaDeposito & "," & intTmpIdDepositoVenta & "," & intTmpIdDepositoRemision & "," & bolTmpHabilitarHorario & _
                              "," & chkActivo.Checked & "," & intGl_idUsuario & "," & chkPrincipal.Checked & "," & chkDobleImpresion.Checked & _
                              "," & chkQr.Checked & "," & txtIdDetFacturaFac.Text & "," & txtIdNcrDE.Text, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjeto()
                listar(" Where c.idConfig >=0  Or c.idConfig <=100" & "order by c.idConfig")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmPc_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.configuracionAbmPc.Enabled = True
    End Sub

    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- LOS LISTVIEWS --'
    '*******************'
    Private Sub lv_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lv.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lv_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lv.SelectedIndexChanged
        For Each item As ListViewItem In lv.SelectedItems
            '-- idConfig
            Dim intTmpIdConfig As Integer = 0
            intTmpIdConfig = CInt(item.SubItems(0).Text)
            txtIdConfig.Text = intTmpIdConfig
            '-- nombre de la impresora
            txtNombreImpresora.Text = sp_datosTabla.consulta_valorString("select nombreImpresora from configPc where idConfig=" & intTmpIdConfig)
            '-- el nombre de la pc
            txtNombre.Text = item.SubItems(1).Text
            '-- id de la pc
            txtIdPc.Text = sp_datosTabla.un_datoString("idpc", "configPc", "idConfig", intTmpIdConfig)
            '-- serial del disco
            txtSerialHd.Text = sp_datosTabla.un_datoString("serialHd", "configPc", "idConfig", intTmpIdConfig)
            '-- la sucursal
            Dim intTmpIdSucursal As Integer = 0
            intTmpIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "configPc", "idConfig", intTmpIdConfig)
            sucursal.comboSucursal(cboSucursal)
            cboSucursal.SelectedValue = intTmpIdSucursal
            '-- la empresa contable
            Dim intTmpIdPersonaJur As Integer = 0
            intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from configPc where idConfig=" & intTmpIdConfig)
            Dim intTmpIdEmpresaContable As Integer
            intTmpIdEmpresaContable = sp_datosTabla.consulta_valor("select idEmpresaContable from v_empresaContable where idPersonaJur=" & intTmpIdPersonaJur)
            empresaContable.comboEmpresaContable(cboContable)
            cboContable.SelectedValue = intTmpIdEmpresaContable
            '-- activar en ventas
            chkVenta.Checked = sp_datosTabla.un_dato_boleano("venta", "configPc", "idConfig", intTmpIdConfig)
            '-- el horario
            chkHorario.Checked = sp_datosTabla.un_dato_boleano("habilitarHorario", "configPc", "idConfig", intTmpIdConfig)
            '-- deposito en ventas
            chkDepositoVenta.Checked = sp_datosTabla.un_dato_boleano("habilitarVentaDeposito", "configPc", "idConfig", intTmpIdConfig)
            deposito.comboDeposito(cboDeposito)
            If chkDepositoVenta.Checked = True Then
                'MsgBox("Valor de idDepositoVenta  " & sp_datosTabla.un_dato_integer("idDepositoVenta", "configPc", "idConfig", intTmpIdConfig))
                cboDeposito.SelectedValue = sp_datosTabla.un_dato_integer("idDepositoVenta", "configPc", "idConfig", intTmpIdConfig)
            End If
            '-- el deposito de la remision
            ' MsgBox("Valor de idconfig " & intTmpIdConfig)
            'MsgBox("Valor del idDeposito de remision " & sp_datosTabla.un_dato_integer("idDepositoRemision", "configPc", "idConfig", intTmpIdConfig))
            deposito.comboDeposito(cboDepositoRemision)
            cboDepositoRemision.SelectedValue = sp_datosTabla.un_dato_integer("idDepositoRemision", "configPc", "idConfig", intTmpIdConfig)
            '-- factura electronica
            txtIdDetFacturaFac.Text = sp_datosTabla.consulta_valor("select idDetFacturaFac from configPc where idConfig=" & intTmpIdConfig)
            txtFacturaFac.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(convert(varchar(15),nroFactura+1))" & _
                                                                    " from detFacturaDE where idDetFacturaDE=" & txtIdDetFacturaFac.Text)
            '-- nota de credito electronica
            txtIdNcrDE.Text = sp_datosTabla.consulta_valor("select idDetFacturaNcr from configPc where idConfig=" & intTmpIdConfig)
            txtNcrDE.Text = sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+rtrim(dcaja)+'-'+rtrim(convert(varchar(15),nroFactura+1))" & _
                                                                    " from detFacturaDE where idDetFacturaDE=" & txtIdNcrDE.Text)
            '-- activo
            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "configPc", "idConfig", intTmpIdConfig)
            '-- principal
            chkPrincipal.Checked = sp_datosTabla.un_dato_boleano("principal", "configPc", "idConfig", intTmpIdConfig)
            '-- doble impresion
            chkDobleImpresion.Checked = sp_datosTabla.un_dato_boleano("dobleImpresion", "configPc", "idConfig", intTmpIdConfig)
            '-- codigo QR
            chkQr.Checked = sp_datosTabla.un_dato_boleano("codigoQR", "configPc", "idConfig", intTmpIdConfig)
            '-- usuario creador
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioAlta", "configPc", "idConfig", intTmpIdConfig)))
            '-- fecha alta
            txtFechaAlta.Text = sp_datosTabla.un_datoString("fechaAlta", "configPc", "idConfig", intTmpIdConfig)
            '-- usuario modificador
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", sp_datosTabla.un_dato_integer("idUsuarioMod", "configPc", "idConfig", intTmpIdConfig))
            '-- fecha modificado
            txtFechaMod.Text = sp_datosTabla.un_datoString("fechaMod", "configPc", "idConfig", intTmpIdConfig)

        Next
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- por idConfig
            If rdIdConfig.Checked = True Then
                listar(" Where c.idConfig Like '" & txtBuscar.Text & "%' Or c.idConfig Like '" & txtBuscar.Text & "%' " & "order by c.idConfig")
            End If
            '-- por nombre de la pc
            If rdNombre.Checked = True Then
                listar(" Where _vs.nombreFantasia Like '" & txtBuscar.Text & "%' Or c.nombrePc Like '" & txtBuscar.Text & "%' " & "order by c.nombrePc")
            End If
            lv.Focus()
        End If

    End Sub

    '----------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If txtIdConfig.Text = "" Then
            MessageBox.Show("No existe ningúna PC a Modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '-- solo si hay un producto consultado
        If txtIdConfig.TextLength > 0 Then
            banNuevo = False
            habilitarObjetos()
            txtNombre.Focus()
        Else
            MessageBox.Show("No existe ningúna PC a Modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        banNuevo = True
        habilitarObjetos()
        vaciarObjetos()
        btnModificar.Enabled = False
        chkActivo.Enabled = False
        '-- inicializar los combos con sus respectivos datos
        '-- la sucursal
        sucursal.comboSucursal(cboSucursal)
        '-- empresa contable
        empresaContable.comboEmpresaContable(cboContable)
        '-- el deposito
        deposito.comboDeposito(cboDeposito)
        '-- el deposito de la remision
        deposito.comboDeposito(cboDepositoRemision)
        txtNombre.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjeto()
        inicializar()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        controlarPc()
        If banError = False Then
            If MessageBox.Show("Desea Guardar los nuevos datos de la Mercadería..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If banNuevo = True Then
                    '-- si es un nuevo registro
                    guardarPc()
                Else
                    '-- si se modifica el registro
                    modificarPC()
                End If
            End If
        End If
    End Sub

    Private Sub btnBuscarFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False

        banGl_abmConfigPc = True
        frmBuscarFactura.txtId.Text = 0
        frmBuscarFactura.txtBuscar.Text = ""

        frmBuscarFactura.Show()
        frmBuscarFactura.BringToFront()
        frmBuscarFactura.txtBuscar.Focus()
    End Sub

    Private Sub btnBuscarFacturaDE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFacturaDE.Click
        Me.Enabled = False
        intGl_abmIdSucursalConfig = cboSucursal.SelectedValue

        banGl_abmConfigPc = True
        frmBuscarFacturaDE.txtId.Text = 0
        frmBuscarFacturaDE.txtBuscar.Text = ""

        frmBuscarFacturaDE.Show()
        frmBuscarFacturaDE.BringToFront()
        frmBuscarFacturaDE.txtBuscar.Focus()
    End Sub

    Private Sub btnBuscarNcrDE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarNcrDE.Click
        Me.Enabled = False
        intGl_abmIdSucursalConfig = cboSucursal.SelectedValue

        banGl_abmConfigPc = True
        frmBuscarFacturaNcrDE.txtId.Text = 0
        frmBuscarFacturaNcrDE.txtBuscar.Text = ""

        frmBuscarFacturaNcrDE.Show()
        frmBuscarFacturaNcrDE.BringToFront()
        frmBuscarFacturaNcrDE.txtBuscar.Focus()
    End Sub

    Private Sub btnBuscarPcCocina_Click(sender As System.Object, e As System.EventArgs)
        Me.Enabled = False

        banGl_abmConfigPc = True
        frmBuscarPc.txtIdLaboratorio.Text = 0
        frmBuscarPc.txtBuscar.Text = ""

        frmBuscarPc.Show()
        frmBuscarPc.BringToFront()
        frmBuscarPc.txtBuscar.Focus()
    End Sub
    '----------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS COMBOS --'
    '****************'
    Private Sub cboSucursal_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        '-- traer solamente lod depositos habilitados de esa sucursal
        intIdDepositoSucursal = cboSucursal.SelectedValue
        'MsgBox("Valor de la sucursal  " & cboSucursal.SelectedValue)
        deposito.comboDepositoSucursal(cboDeposito, intIdDepositoSucursal)
        'cboDeposito.SelectedValue = sp_datosTabla.un_dato_integer("idDeposito", "deposito", "idSucursal", intIdDepositoSucursal)
    End Sub

    '----------------------------------------------------------------------------------------------------

End Class