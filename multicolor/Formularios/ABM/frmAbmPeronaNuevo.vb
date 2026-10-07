Imports System.IO
Public Class frmAbmPeronaNuevo
    '****************************'
    '-- VARIABLES TIPO OBJETO --'
    '****************************'
    Private sp_persona As New sp_persona
    Private sp_datosTabla As New sp_datosTabla
    Private sp_obtenerDatosUsuario As New sp_obtenerDatosUsuario
    Private persona As New persona
    Dim systemClass As New SystemClass
    Dim laboratorio As New laboratorio
    Dim pais As New pais
    Dim cargo As New cargo
    Dim grupoCliente As New grupoCliente
    Dim departamento As New departamento
    Dim distrito As New distrito
    Dim ciudad As New ciudad
    Dim tipoDocu As New tipoDocu

    '*************************'
    '-- VARIABLES ESCALARES --'
    '*************************'
    Dim blNuevo As Boolean
    Dim strDatosOriginales As String
    Dim intIdcargo As Integer

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()

        pais.listarPaisCombo(cboPais)
        cargo.ListarCargoCb(cboCargo)
        grupoCliente.grupoClienteCombo(cboGrupoCliente)
        laboratorio.ListarLaboratorio(cboLaboratorio)
        departamento.comboDepartamento(cboDepartamento)
        distrito.comboDistrito(cboDistrito)
        ciudad.comboCiudad(cboCiudad)
        tipoDocu.comboTipoDocu(cboTipoDocu)

        '-- por defecto a cedula paraguaya
        cboTipoDocu.SelectedValue = 1

        txtLimite.Text = 0
        txtTotalCompra.Text = 0
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        'listar("")
        'valorde del combo
    End Sub

    Sub deshabilitarObjetos() 'colocar como está originalmente
        '-- los txt
        txtNombre.Enabled = False
        txtNombre.BackColor = Drawing.Color.LightSkyBlue
        txtBarrio.Enabled = False
        txtBarrio.BackColor = Drawing.Color.LightSkyBlue
        txtCiudad.Enabled = False
        txtCiudad.BackColor = Drawing.Color.LightSkyBlue
        txtCelular1.Enabled = False
        txtCelular1.BackColor = Drawing.Color.LightSkyBlue
        txtCelular2.Enabled = False
        txtCelular2.BackColor = Drawing.Color.LightSkyBlue
        txtDireccion.Enabled = False
        txtDireccion.BackColor = Drawing.Color.LightSkyBlue
        txtEmail1.Enabled = False
        txtEmail1.BackColor = Drawing.Color.LightSkyBlue
        txtEmail2.Enabled = False
        txtEmail2.BackColor = Drawing.Color.LightSkyBlue
        maskFechaAni.Enabled = False
        maskFechaAni.BackColor = Drawing.Color.LightSkyBlue
        txtRuc.Enabled = False
        txtRuc.BackColor = Drawing.Color.LightSkyBlue
        txtDv.Enabled = False
        txtDv.BackColor = Drawing.Color.LightSkyBlue
        txtTele1.Enabled = False
        txtTele1.BackColor = Drawing.Color.LightSkyBlue
        txtTele2.Enabled = False
        txtTele2.BackColor = Drawing.Color.LightSkyBlue
        txtNombreFantasia.BackColor = Drawing.Color.LightSkyBlue
        txtApellido.BackColor = Drawing.Color.LightSkyBlue
        txtWeb.Enabled = False
        txtWeb.BackColor = Drawing.Color.LightSkyBlue
        txtNroCasa.Enabled = False
        txtNroCasa.BackColor = Drawing.Color.LightSkyBlue
        '--perona fisica
        txtApellido.Enabled = False
        txtApellido.BackColor = Drawing.Color.LightSkyBlue
        '-- persona juridica
        txtNombreFantasia.Enabled = False
        txtNombreFantasia.BackColor = Color.LightSkyBlue
        txtMesesCanje.Enabled = False
        txtMesesCanje.BackColor = Color.LightSkyBlue

        '-- cliente
        txtLimite.Enabled = False
        txtLimite.BackColor = Color.LightSkyBlue

        '-- chk
        chkActivo.Enabled = False
        chkCliente.Enabled = False
        chkCliente.BackColor = Drawing.Color.Pink
        chkPersonaFis.Enabled = False
        chkPersonaFis.BackColor = Drawing.Color.Pink
        chkPersonaJur.Enabled = False
        chkPersonaJur.BackColor = Drawing.Color.Pink
        '-- combos
        cboPais.Enabled = False
        cboCargo.Enabled = False
        cboGrupoCliente.Enabled = False
        cboCiudad.Enabled = False
        cboDistrito.Enabled = False
        cboDepartamento.Enabled = False
        cboTipoDocu.Enabled = False

        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        'btnBuscar.Enabled = False

        '-- la seccion de busqueda
        grBuscar.Enabled = True
        txtBuscar.BackColor = Drawing.Color.White

    End Sub

    Sub habilitarObjetos() 'colocar como para agregar datos
        '-- los txt
        txtNombre.Enabled = True
        txtNombre.BackColor = Drawing.Color.White
        txtBarrio.Enabled = True
        txtBarrio.BackColor = Drawing.Color.White
        txtBarrio.Text = Trim(txtBarrio.Text) + Space(40 - Len(txtBarrio.Text))
        txtCiudad.Enabled = True
        txtCiudad.BackColor = Drawing.Color.White
        txtCiudad.Text = Trim(txtCiudad.Text) + Space(50 - Len(txtCiudad.Text))
        txtCelular1.Enabled = True
        txtCelular1.Text = Trim(txtCelular1.Text) + Space(20 - Len(txtCelular1.Text))
        txtCelular1.BackColor = Drawing.Color.White
        txtCelular2.Enabled = True
        txtCelular2.BackColor = Drawing.Color.White
        txtCelular2.Text = Trim(txtCelular2.Text) + Space(20 - Len(txtCelular2.Text))
        txtDireccion.Enabled = True
        txtDireccion.BackColor = Drawing.Color.White
        txtEmail1.Enabled = True
        txtEmail1.BackColor = Drawing.Color.White
        txtEmail1.Text = Trim(txtEmail1.Text) + Space(50 - Len(txtEmail1.Text))
        txtEmail2.Enabled = True
        txtEmail2.BackColor = Drawing.Color.White
        txtEmail2.Text = Trim(txtEmail2.Text) + Space(50 - Len(txtEmail2.Text))
        maskFechaAni.Enabled = True
        maskFechaAni.BackColor = Drawing.Color.White
        txtRuc.Enabled = True
        txtRuc.BackColor = Drawing.Color.White
        txtDv.Enabled = True
        txtDv.BackColor = Drawing.Color.White
        txtTele1.Enabled = True
        txtTele1.BackColor = Drawing.Color.White
        txtTele1.Text = Trim(txtTele1.Text) + Space(20 - Len(txtTele1.Text))
        txtTele2.Enabled = True
        txtTele2.BackColor = Drawing.Color.White
        txtTele2.Text = Trim(txtTele2.Text) + Space(20 - Len(txtTele2.Text))
        txtWeb.Enabled = True
        txtWeb.BackColor = Drawing.Color.White
        txtNroCasa.Enabled = True
        txtNroCasa.BackColor = Drawing.Color.White
        '-- chk
        chkActivo.Enabled = True
        chkCliente.Enabled = True
        chkPersonaFis.Enabled = True
        chkPersonaJur.Enabled = True
        '-- combos
        cboPais.Enabled = True
        cboCiudad.Enabled = True
        cboDepartamento.Enabled = True
        cboDistrito.Enabled = True
        cboTipoDocu.Enabled = True
        'cboZona.Enabled = False
        'cboCargo.Enabled = False
        'cboGrupoCliente.Enabled = False
        'cboVendedor.Enabled = False
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        'btnBuscar.Enabled = True
        '-- la seccion de busqueda
        grBuscar.Enabled = False
        txtBuscar.BackColor = Drawing.Color.LightSkyBlue



        '-- la imagen
        picImagen.ImageLocation = ""

    End Sub

    Sub listar(ByVal where As String)
        If rdApellido.Checked = True Then
            '-- busqueda por apellido a persona fisica
            systemClass.SqlToLv(lvPersona, "Select p.idPersona,p.nombre,p.apellido,p.ruc from v_personaFis p " & where)
        Else
            systemClass.SqlToLv(lvPersona, "Select p.idPersona,p.nombre,'',p.ruc from persona p " & where)
        End If


        ' dimensionar las columnas
        lvPersona.Columns(0).Width = 50 'idpersona
        lvPersona.Columns(1).Width = 160 'nombre
        lvPersona.Columns(2).Width = 160 'apellido
        lvPersona.Columns(3).Width = 90 'ruc
        lvPersona.Scrollable = True
    End Sub

    '------------------------------------------'
    '-- habilitar objetos en la modificacion --'
    '------------------------------------------'
    Private Sub habilitarObjetoPersonaFisica()
        txtApellido.Enabled = True
        txtApellido.BackColor = Drawing.Color.White

        chkEmpleado.Enabled = True
        chkCocinero.Enabled = True
        cboCargo.Enabled = True
        chkVendedor.Enabled = True
        chkCobrador.Enabled = True
        chkRepartidor.Enabled = True
    End Sub

    Private Sub habilitarObjetoPersonaJuridica()
        txtNombreFantasia.Enabled = True
        txtNombreFantasia.BackColor = Drawing.Color.White
        txtPorcentajeImportado.Enabled = True
        txtPorcentajeNacional.Enabled = True
        txtPorcentajeImportado.BackColor = Color.White
        txtPorcentajeNacional.BackColor = Color.White
        txtMesesCanje.Enabled = True
        txtMesesCanje.BackColor = Color.White
        txtTotalCompra.Enabled = True
        txtTotalCompra.BackColor = Color.White

        cboLaboratorio.Enabled = True
        chkProveedor.Enabled = True
        chkLaboratorio.Enabled = True
        chkSucursal.Enabled = True
        chkEmpresaContable.Enabled = True
        chkDivision.Enabled = True
        cboLaboratorio.Enabled = True
    End Sub

    Private Sub habilitarObjetoCliente()
        cboGrupoCliente.Enabled = True

        chkAcreditar.Enabled = True
        chkLimite.Enabled = True
        chkUsoInterno.Enabled = True
        chkUsoInterno.BackColor = Drawing.Color.White
        txtLimite.Enabled = True
        txtLimite.BackColor = Drawing.Color.White
    End Sub

    '--------------- fin de la modificacion de objetos --------------------------------------
    Private Sub objetoPersonaFisica()
        If chkPersonaFis.Checked = True Then
            '-- activar
            habilitarPersonaFisica()
        Else
            '-- desactivar
            deshabilitarPersonaFisica()
        End If
    End Sub

    Private Sub objetoPersonaJuridica()
        If chkPersonaJur.Checked = True Then
            '-- activar
            habilitarPersonaJuridica()
        Else
            '-- desactivar
            deshabilitarPersonaJuridica()
        End If
    End Sub

    Private Sub objetoPersonaCliente()
        If chkCliente.Checked = True Then
            '-- activar
            habilitarCliente()
        Else
            '-- desactivar
            deshabilitarCliente()
        End If
    End Sub

    Private Sub habilitarPersonaFisica()
        txtApellido.Enabled = True
        txtApellido.BackColor = Drawing.Color.White

        chkEmpleado.Enabled = True
        chkEmpleado.BackColor = Drawing.Color.Lime
        chkCocinero.Enabled = True
        chkCocinero.BackColor = Drawing.Color.Lime

        cboCargo.Enabled = True
        cboCargo.BackColor = Drawing.Color.Lime
        chkVendedor.Enabled = True
        chkVendedor.BackColor = Drawing.Color.Lime
        chkCobrador.Enabled = True
        chkCobrador.BackColor = Drawing.Color.Lime
        chkRepartidor.Enabled = True
        chkRepartidor.BackColor = Drawing.Color.Lime
    End Sub

    Private Sub deshabilitarPersonaFisica()
        txtApellido.Enabled = False
        txtApellido.BackColor = Drawing.Color.LightSkyBlue
        txtApellido.Text = ""

        chkEmpleado.Enabled = False
        chkEmpleado.BackColor = Drawing.Color.Pink
        chkEmpleado.Checked = False
        chkCocinero.Enabled = False
        chkCocinero.BackColor = Drawing.Color.Pink
        chkCocinero.Checked = False

        cboCargo.Enabled = False
        cboCargo.BackColor = Drawing.Color.Pink
        chkVendedor.Enabled = False
        chkVendedor.BackColor = Drawing.Color.Pink
        chkVendedor.Checked = False
        chkCobrador.Enabled = False
        chkCobrador.BackColor = Drawing.Color.Pink
        chkCobrador.Checked = False
        chkRepartidor.BackColor = Drawing.Color.Pink
        chkRepartidor.Checked = False
    End Sub

    Private Sub habilitarPersonaJuridica()
        txtNombreFantasia.Enabled = True
        txtNombreFantasia.BackColor = Drawing.Color.White
        txtMesesCanje.Enabled = True
        txtMesesCanje.BackColor = Color.White
        txtTotalCompra.Enabled = True
        txtTotalCompra.BackColor = Color.White

        chkProveedor.Enabled = True
        chkProveedor.BackColor = Drawing.Color.Lime
        chkLaboratorio.Enabled = True
        chkLaboratorio.BackColor = Drawing.Color.Lime
        chkSucursal.Enabled = True
        chkSucursal.BackColor = Drawing.Color.Lime
        chkEmpresaContable.Enabled = True
        chkEmpresaContable.BackColor = Drawing.Color.Lime
        chkDivision.Enabled = True
        chkDivision.BackColor = Drawing.Color.Lime
        cboLaboratorio.Enabled = False
    End Sub

    Private Sub deshabilitarPersonaJuridica()
        txtNombreFantasia.Enabled = False
        txtNombreFantasia.BackColor = Drawing.Color.LightSkyBlue
        txtNombreFantasia.Text = ""
        txtMesesCanje.BackColor = Color.LightSkyBlue
        txtMesesCanje.Text = 0


        txtPorcentajeImportado.Enabled = False
        txtPorcentajeNacional.Enabled = False
        txtPorcentajeImportado.BackColor = Color.LightSkyBlue
        txtPorcentajeNacional.BackColor = Color.LightSkyBlue

        txtTotalCompra.Enabled = False
        txtTotalCompra.BackColor = Color.LightSkyBlue

        chkProveedor.Enabled = False
        chkProveedor.BackColor = Drawing.Color.Pink
        chkProveedor.Checked = False
        chkLaboratorio.Enabled = False
        chkLaboratorio.BackColor = Drawing.Color.Pink
        chkLaboratorio.Checked = False
        chkSucursal.Enabled = False
        chkSucursal.BackColor = Drawing.Color.Pink
        chkSucursal.Checked = False
        chkEmpresaContable.Enabled = False
        chkEmpresaContable.BackColor = Drawing.Color.Pink
        chkEmpresaContable.Checked = False
        chkDivision.BackColor = Drawing.Color.Pink
        chkDivision.Checked = False
        cboLaboratorio.Enabled = False
    End Sub

    Private Sub habilitarCliente()
        txtLimite.Enabled = True
        txtLimite.BackColor = Drawing.Color.White

        chkAcreditar.Enabled = True
        chkAcreditar.BackColor = Drawing.Color.Lime
        chkLimite.Enabled = True
        chkLimite.BackColor = Drawing.Color.Lime
        chkUsoInterno.Enabled = True
        chkUsoInterno.BackColor = Drawing.Color.Lime

        cboGrupoCliente.Enabled = True
    End Sub

    Private Sub deshabilitarCliente()
        txtLimite.Enabled = False
        txtLimite.BackColor = Drawing.Color.LightSkyBlue
        txtLimite.Text = 0

        chkAcreditar.Enabled = False
        chkAcreditar.Checked = False
        chkAcreditar.BackColor = Drawing.Color.Pink
        chkLimite.Enabled = False
        chkLimite.Checked = False
        chkLimite.BackColor = Drawing.Color.Pink
        chkUsoInterno.Checked = False
        chkUsoInterno.BackColor = Drawing.Color.Pink

        cboGrupoCliente.Enabled = False
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()

        '-- colocar por defecto el pais de Paraguay
        cboGrupoCliente.SelectedValue = 1

        chkActivo.Checked = True
        chkActivo.Enabled = False
        chkPersonaFis.Checked = False
        chkPersonaJur.Checked = False
        chkCliente.Checked = False
        'balnquear los objetos
        txtIdPersona.Text = 0
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtBarrio.Text = ""
        txtCelular1.Text = ""
        txtCelular2.Text = ""
        txtDireccion.Text = ""
        txtDv.Text = ""
        txtEmail1.Text = ""
        txtEmail2.Text = ""
        txtFechaAlta.Text = ""
        maskFechaAni.Text = ""
        txtFechaMod.Text = ""
        txtFoto.Text = ""
        txtNombreFantasia.Text = ""
        txtRuc.Text = ""
        txtTele1.Text = ""
        txtTele2.Text = ""
        txtUsuarioAlta.Text = ""
        grupoCliente.grupoClienteCombo(cboGrupoCliente)
        txtLimite.Text = 0
        txtPorcentajeImportado.Text = 0
        txtPorcentajeNacional.Text = 0
        txtNroCasa.Text = 0

        deshabilitarCliente()
        deshabilitarPersonaFisica()
        deshabilitarPersonaJuridica()

        chkPersonaFis.BackColor = Drawing.Color.Pink
        chkPersonaJur.BackColor = Drawing.Color.Pink
        chkCliente.BackColor = Drawing.Color.Pink

        '-- por defecto colocar pais= paraguay departamento=itapua y ciudad= encarnacion
        cboPais.SelectedValue = 1
        cboTipoDocu.SelectedValue = 1
        '-- llevar la zona a uno

        txtNombre.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtIdPersona.Text = 0
        txtNombre.Text = ""
        txtBarrio.Text = ""
        txtCelular1.Text = ""
        txtCelular2.Text = ""
        txtDireccion.Text = ""
        txtDv.Text = ""
        txtEmail1.Text = ""
        txtEmail2.Text = ""
        txtFechaAlta.Text = ""
        maskFechaAni.Text = ""
        txtFechaMod.Text = ""
        txtFoto.Text = ""
        txtNombreFantasia.Text = ""
        txtRuc.Text = ""
        txtTele1.Text = ""
        txtTele2.Text = ""
        txtUsuarioAlta.Text = ""
        txtUsuarioMod.Text = ""
        chkActivo.Checked = False
        txtTotalCompra.Text = 0
        txtNroCasa.Text = 0

        deshabilitarPersonaFisica()
        deshabilitarPersonaJuridica()
        deshabilitarCliente()

        lvPersona.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'controlar si existe algun error
        'controlar el nombre
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar algún Nombre para el Cargo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '------------------
        'si es un cliente
        '-----------------
        If chkCliente.Checked = 1 Then
            If cboGrupoCliente.Text = "" Then
                MessageBox.Show("Si la Persona es Asignada como Cliente, Asignarle el Grupo..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
        Dim strFechaAni As String
        If Not IsNumeric(maskFechaAni.Text.Substring(0, 1)) Then
            strFechaAni = ""
        Else
            strFechaAni = maskFechaAni.Text
        End If

        'MsgBox("Paso por aca", MsgBoxStyle.Information)
        'MsgBox("Valor de la mascara  " & strFechaAni, MsgBoxStyle.Information)
        If blNuevo = True Then
            ' si es nuevo
            If (fun_guardarSp("sp_insPersonaNuevo_nuevo", intGl_idEntidad & "," & "'" & Trim(txtNombre.Text) & "'" & "," & "'" & Trim(txtRuc.Text) & "'" & _
                "," & "'" & txtDv.Text & "'" & "," & "'" & Trim(txtDireccion.Text) & "'" & "," & cboPais.SelectedValue & "," & "'" & Trim(txtCiudad.Text) & "'" & _
                "," & "'" & Trim(txtBarrio.Text) & "'" & "," & "'" & maskFechaAni.Text & "'" & "," & "'" & Trim(txtTele1.Text) & "'" & "," & "'" & Trim(txtTele2.Text) & "'" & _
                "," & "'" & Trim(txtCelular1.Text) & "'" & "," & "'" & Trim(txtCelular2.Text) & "'" & "," & "'" & Trim(txtEmail1.Text) & "'" & _
                "," & "'" & Trim(txtEmail2.Text) & "'" & "," & "'" & Trim(txtWeb.Text) & "'" & "," & "'" & Trim(txtFoto.Text) & "'" & "," & intGl_idUsuario & "," & _
                chkPersonaFis.Checked & "," & "'" & Trim(txtApellido.Text) & "'" & "," & chkEmpleado.Checked & "," & cboCargo.SelectedValue & "," & chkVendedor.Checked & _
                "," & chkCobrador.Checked & "," & chkPersonaJur.Checked & "," & "'" & Trim(txtNombreFantasia.Text) & "'" & "," & _
                chkProveedor.Checked & "," & chkLaboratorio.Checked & "," & chkSucursal.Checked & "," & chkEmpresaContable.Checked & "," & chkCliente.Checked & "," & _
                cboGrupoCliente.SelectedValue & "," & chkAcreditar.Checked & "," & chkLimite.Checked & "," & chkUsoInterno.Checked & "," & _
                CDbl(sacarComa(txtLimite.Text)) & "," & chkDivision.Checked & "," & cboLaboratorio.SelectedValue & "," & chkCocinero.Checked & _
                "," & chkRepartidor.Checked & "," & CDbl(sacarComa(txtPorcentajeNacional.Text)) & "," & CDbl(sacarComa(txtPorcentajeImportado.Text)) & "," & CInt(txtMesesCanje.Text) & _
                "," & sacarComa(CDbl(txtTotalCompra.Text)) & "," & txtNroCasa.Text & "," & cboTipoDocu.SelectedValue & "," & cboDepartamento.SelectedValue & "," & _
                cboDistrito.SelectedValue & "," & cboCiudad.SelectedValue, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
                inicializar()
            End If
            'sp_persona.insPersona(intGl_idEntidad, txtNombre.Text, txtRuc.Text, txtDv.Text, txtDireccion.Text, txtBarrio.Text, txtCiudad.Text, strFechaAni, txtTele1.Text, txtTele2.Text, txtCelular1.Text, txtCelular2.Text, txtEmail1.Text, txtEmail2.Text, txtWeb.Text, txtFoto.Text, intGl_idUsuario, chkPersonaJur.Checked, txtNombreFantasia.Text, chkPersonaFis.Checked, txtApellido.Text, chkCliente.Checked, cboGrupoCliente.SelectedValue, chkAcreditar.Checked, chkProveedor.Checked, txtResponsable.Text, txtTimbrado.Text)
        Else

            If (fun_guardarSp("sp_updPersonaNuevo_nuevo", sacarComa(txtIdPersona.Text) & "," & intGl_idEntidad & "," & "'" & Trim(txtNombre.Text) & "'" & "," & "'" & Trim(txtRuc.Text) & "'" & _
                "," & "'" & txtDv.Text & "'" & "," & "'" & Trim(txtDireccion.Text) & "'" & "," & cboPais.SelectedValue & "," & "'" & Trim(txtCiudad.Text) & "'" & _
                "," & "'" & Trim(txtBarrio.Text) & "'" & "," & "'" & maskFechaAni.Text & "'" & "," & "'" & Trim(txtTele1.Text) & "'" & "," & "'" & Trim(txtTele2.Text) & "'" & _
                "," & "'" & Trim(txtCelular1.Text) & "'" & "," & "'" & Trim(txtCelular2.Text) & "'" & "," & "'" & Trim(txtEmail1.Text) & "'" & _
                "," & "'" & Trim(txtEmail2.Text) & "'" & "," & "'" & Trim(txtWeb.Text) & "'" & "," & "'" & Trim(txtFoto.Text) & "'" & "," & chkActivo.Checked & "," & intGl_idUsuario & "," & _
                chkPersonaFis.Checked & "," & "'" & Trim(txtApellido.Text) & "'" & "," & chkEmpleado.Checked & "," & cboCargo.SelectedValue & "," & chkVendedor.Checked & _
                "," & chkCobrador.Checked & "," & chkPersonaJur.Checked & "," & "'" & Trim(txtNombreFantasia.Text) & "'" & "," & _
                chkProveedor.Checked & "," & chkLaboratorio.Checked & "," & chkSucursal.Checked & "," & chkEmpresaContable.Checked & "," & cboLaboratorio.SelectedValue & "," & chkCliente.Checked & "," & _
                cboGrupoCliente.SelectedValue & "," & chkAcreditar.Checked & "," & chkLimite.Checked & "," & chkUsoInterno.Checked & "," & _
                CDbl(sacarComa(txtLimite.Text)) & "," & chkDivision.Checked & "," & chkCocinero.Checked & "," & chkRepartidor.Checked & "," & CDbl(sacarComa(txtPorcentajeNacional.Text)) & _
                "," & CDbl(sacarComa(txtPorcentajeImportado.Text)) & "," & CInt(txtMesesCanje.Text) & "," & sacarComa(CDbl(txtTotalCompra.Text)) & _
                "," & txtNroCasa.Text & "," & cboTipoDocu.SelectedValue & "," & cboDepartamento.SelectedValue & "," & cboDistrito.SelectedValue & "," & _
                cboCiudad.SelectedValue, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar el Registro...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
                inicializar()
            End If
        End If

    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Se debe mostrar el dato a modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ' cargar en la variable los datos originales
        'strDatosOriginales = Trim(txtNombre.Text) & "," & Trim(txtRuc.Text) & "," & Trim(txtDv.Text) & "," & Trim(txtDireccion.Text) & "," & Trim(txtBarrio.Text) & "," & Trim(txtCiudad.Text) & "," & Trim(maskFechaAni.Text) & "," & Trim(txtTele1.Text) & "," & Trim(txtTele2.Text) & "," & Trim(txtCelular1.Text) & "," & Trim(txtCelular2.Text) & "," & Trim(txtEmail1.Text) & "," & Trim(txtEmail2.Text) & "," & Trim(txtWeb.Text) & "," & Trim(txtFoto.Text) & "," & Trim(chkActivo.Checked.ToString) & "," & Trim(intGl_idUsuario.ToString)
        blNuevo = False
        habilitarObjetos()

        habilitarObjetoPersonaFisica()
        habilitarObjetoPersonaJuridica()
        habilitarObjetoCliente()

        txtNombre.Focus()
    End Sub

    'Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
    '    banGl_abmPersona = True
    '    Me.Enabled = False
    '    frmBuscarImagen.Visible = True
    '    frmBuscarImagen.Show()
    '    frmBuscarImagen.BringToFront()
    'End Sub
    '-----------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPersona.SelectedIndexChanged
        Try
            Dim intTmpIdPersonaFis As Integer
            Dim intTmpIdPersonaJur As Integer
            Dim intTmpIdCliente As Integer
            Dim intTmpIdPersonal As Integer
            Dim intTmpIdVendedor As Integer
            Dim intTmpIdCobrador As Integer
            Dim intTmpIdCocinero As Integer
            Dim intTmpIdRepartidor As Integer
            Dim intTmpIdProveedor As Integer
            Dim intTmpIdFabricante As Integer
            Dim intTmpIdEmpresaContable As Integer
            Dim intTmpIdSucursal As Integer
            Dim intTmpIdDivision As Integer

            For Each item As ListViewItem In lvPersona.SelectedItems
                chkCocinero.BackColor = Color.Pink
                chkCocinero.Checked = False

                txtIdPersona.Text = item.SubItems(0).Text
                txtNombre.Text = item.SubItems(1).Text
                txtRuc.Text = sp_datosTabla.un_dato("ruc", "persona", "idpersona", CInt(item.SubItems(0).Text))
                '-- controlar si no tiene nulo el dv
                'If (sp_datosTabla.un_dato_boleano("dv", "persona", "idpersona", CInt(item.SubItems(0).Text))) = True Then
                'txtDv.Text = ""
                'Else
                txtDv.Text = sp_datosTabla.un_dato("dv", "persona", "idpersona", CInt(item.SubItems(0).Text))
                'End If
                ' MsgBox("Realizo la consulta del dv", MsgBoxStyle.Information)
                txtDireccion.Text = sp_datosTabla.un_dato("direccion", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtBarrio.Text = sp_datosTabla.un_dato("barrio", "persona", "idpersona", CInt(item.SubItems(0).Text))
                maskFechaAni.Text = sp_datosTabla.un_dato("fechaani", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtTele1.Text = sp_datosTabla.un_dato("tele1", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtTele2.Text = sp_datosTabla.un_dato("tele2", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtCelular1.Text = sp_datosTabla.un_dato("celular1", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtCelular2.Text = sp_datosTabla.un_dato("celular2", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtEmail1.Text = sp_datosTabla.un_dato("email1", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtEmail2.Text = sp_datosTabla.un_dato("email2", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtFoto.Text = sp_datosTabla.consulta_valorString("select fotoPersona from persona where idPersona=" & CInt(item.SubItems(0).Text))
                txtNroCasa.Text = sp_datosTabla.consulta_valor("select numeroCasa from persona where idPersona=" & CInt(item.SubItems(0).Text))
                cboTipoDocu.SelectedValue = sp_datosTabla.consulta_valor("select idTipoDocumento from persona where idPersona=" & CInt(item.SubItems(0).Text))
                cboDepartamento.SelectedValue = sp_datosTabla.consulta_valor("select idDepartamento from persona where idPersona=" & CInt(item.SubItems(0).Text))
                cboDistrito.SelectedValue = sp_datosTabla.consulta_valor("select idDistrito from persona where idPersona=" & CInt(item.SubItems(0).Text))
                cboCiudad.SelectedValue = sp_datosTabla.consulta_valor("select idCiudad from persona where idPersona=" & CInt(item.SubItems(0).Text))

                'departamentoPais.listarDepartamentoPaisCombo(cboDepartamento, 1)
                'ciudad.listarCiudadDepartamentoCombo(cboCiudad, cboDepartamento.SelectedValue)

                '-- el pais
                cboPais.SelectedValue = sp_datosTabla.consulta_valor("select idPais from persona where idPersona=" & CInt(item.SubItems(0).Text))
                '-- la ciudad
                txtCiudad.Text = sp_datosTabla.consulta_valorString("select ciudad from persona where idPersona=" & CInt(item.SubItems(0).Text))

                '-- la imagen de la persona
                picImagen.ImageLocation = strGl_rutaImagen & sp_datosTabla.consulta_valorString("select fotoPersona from persona where idPersona=" & CInt(item.SubItems(0).Text))

                chkActivo.Checked = sp_datosTabla.un_dato("activo", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtFechaAlta.Text = sp_datosTabla.un_dato("fechaAlta", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtFechaMod.Text = sp_datosTabla.un_dato("fechaMod", "persona", "idpersona", CInt(item.SubItems(0).Text))
                txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", sp_datosTabla.un_dato("idUsuarioAlta", "persona", "idpersona", CInt(item.SubItems(0).Text)))
                txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", sp_datosTabla.un_dato("idUsuarioMod", "persona", "idpersona", CInt(item.SubItems(0).Text)))

                txtPorcentajeImportado.Text = 0
                txtPorcentajeNacional.Text = 0
                '--------------------'
                '-- PERSONA FISICA --'
                '--------------------'
                If sp_datosTabla.consulta_valor("select idPersona from personaFis where activo=1 and idPersona=" & CInt(item.SubItems(0).Text)) > 0 Then
                    intTmpIdPersonaFis = sp_datosTabla.consulta_valor("select idPersonaFis from personaFis where activo=1 and idPersona=" & CInt(item.SubItems(0).Text))

                    ' MsgBox("Persona fisica")
                    chkPersonaFis.Checked = True
                    'MsgBox("Paso 2")
                    chkPersonaFis.BackColor = Drawing.Color.Lime

                    'MsgBox("Paso 3")
                    '-- apellido
                    txtApellido.Text = sp_datosTabla.consulta_valorString("select apellido from personaFis where idPersonaFis=" & intTmpIdPersonaFis)

                    intTmpIdPersonal = sp_datosTabla.consulta_valor("select idPersonal from personal where activo=1 and idPersonaFis=" & intTmpIdPersonaFis)
                    txtMesesCanje.Text = 0

                    If intTmpIdPersonal > 0 Then
                        '--------------'
                        '-- EMPLEADO --'
                        '--------------'
                        chkEmpleado.Checked = True
                        chkEmpleado.BackColor = Drawing.Color.Lime
                        '-- el cargo
                        cboCargo.SelectedValue = sp_datosTabla.consulta_valor("select idCargo from personal where idPersonal=" & intTmpIdPersonal)

                        intTmpIdVendedor = sp_datosTabla.consulta_valor("select idVendedor from vendedor where activo=1 and idPersonal=" & intTmpIdPersonal)
                        If intTmpIdVendedor > 0 Then
                            '--------------'
                            '-- VENDEDOR --'
                            '--------------'
                            chkVendedor.Checked = True
                            chkVendedor.BackColor = Drawing.Color.Lime
                        Else
                            '-- no existe como vendedor
                            chkVendedor.Checked = False
                            chkVendedor.BackColor = Drawing.Color.Pink
                        End If

                        intTmpIdCobrador = sp_datosTabla.consulta_valor("select idCobrador from cobrador where activo=1 and idPersonal=" & intTmpIdPersonal)
                        If intTmpIdCobrador > 0 Then
                            '--------------'
                            '-- COBRADOR --'
                            '--------------'
                            chkCobrador.Checked = True
                            chkCobrador.BackColor = Drawing.Color.Lime
                        Else
                            '-- no existe como cobrador
                            chkCobrador.Checked = False
                            chkCobrador.BackColor = Drawing.Color.Pink
                        End If

                        intTmpIdCocinero = sp_datosTabla.consulta_valor("select idPersonal from personal where cocinero=1 and idPersonal=" & intTmpIdPersonal)
                        If intTmpIdCocinero > 0 Then
                            '--------------'
                            '-- COCINERO --'
                            '--------------'
                            chkCocinero.Checked = True
                            chkCocinero.BackColor = Drawing.Color.Lime
                        Else
                            '-- no existe como cocinero
                            chkCocinero.Checked = False
                            chkCocinero.BackColor = Drawing.Color.Pink
                        End If

                        intTmpIdRepartidor = sp_datosTabla.consulta_valor("select idPersonal from repartidor where activo=1 and idPersonal=" & intTmpIdPersonal)
                        If intTmpIdRepartidor > 0 Then
                            '----------------'
                            '-- REPARTIDOR --'
                            '----------------'
                            chkRepartidor.Checked = True
                            chkRepartidor.BackColor = Drawing.Color.Lime
                        Else
                            '-- no existe como repartidor
                            chkRepartidor.Checked = False
                            chkRepartidor.BackColor = Drawing.Color.Pink
                        End If
                    Else
                        '-- no existe como empleado
                        chkEmpleado.BackColor = Drawing.Color.Pink
                        chkEmpleado.Checked = False
                        chkVendedor.BackColor = Drawing.Color.Pink
                        chkVendedor.Checked = False
                        chkCobrador.BackColor = Drawing.Color.Pink
                        chkCobrador.Checked = False
                        chkCocinero.BackColor = Drawing.Color.Pink
                        chkCocinero.Checked = False
                        chkRepartidor.BackColor = Drawing.Color.Pink
                        chkRepartidor.Checked = False
                    End If
                    txtPorcentajeImportado.Text = 0
                    txtPorcentajeNacional.Text = 0
                Else
                    '--- no existe como persona fisica
                    chkPersonaFis.Checked = False
                    chkPersonaFis.BackColor = Drawing.Color.Pink
                    '-- no existe como empleado
                    chkEmpleado.BackColor = Drawing.Color.Pink
                    chkEmpleado.Checked = False
                    chkVendedor.BackColor = Drawing.Color.Pink
                    chkVendedor.Checked = False
                    chkCobrador.BackColor = Drawing.Color.Pink
                    chkCobrador.Checked = False
                    chkRepartidor.BackColor = Drawing.Color.Pink
                    chkRepartidor.Checked = False

                    txtPorcentajeImportado.Text = 0
                    txtPorcentajeNacional.Text = 0
                End If

                '----------------------'
                '-- PERSONA JURIDICA --'
                '----------------------'
                intTmpIdPersonaJur = sp_datosTabla.consulta_valor("select idPersonaJur from personaJur where activo=1 and idPersona=" & CInt(item.SubItems(0).Text))
                If intTmpIdPersonaJur > 0 Then
                    txtPorcentajeImportado.Text = 0
                    txtPorcentajeNacional.Text = 0

                    chkPersonaJur.Checked = True
                    chkPersonaJur.BackColor = Drawing.Color.Lime
                    txtNombreFantasia.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from personaJur where idPersona=" & CInt(item.SubItems(0).Text))

                    intTmpIdProveedor = sp_datosTabla.consulta_valor("select idProveedor from proveedor where activo=1 and idPersonaJur=" & intTmpIdPersonaJur)
                    If intTmpIdProveedor > 0 Then
                        '---------------'
                        '-- PROVEEDOR --'
                        '---------------'
                        chkProveedor.Checked = True
                        chkProveedor.BackColor = Drawing.Color.Lime
                        '-- porcentajes comprometidos
                        txtPorcentajeImportado.Text = sp_datosTabla.consulta_valorDouble("select porcentajeImportado from proveedor where idProveedor=" & intTmpIdProveedor)
                        txtPorcentajeImportado.Text = Format(CDec(txtPorcentajeImportado.Text), "##0.##")
                        txtPorcentajeNacional.Text = sp_datosTabla.consulta_valorDouble("select porcentajeNacional from proveedor where idProveedor=" & intTmpIdProveedor)
                        txtPorcentajeNacional.Text = Format(CDec(txtPorcentajeNacional.Text), "##0.##")
                        txtTotalCompra.Text = sp_datosTabla.consulta_valorDouble("select limite from proveedor where idProveedor=" & intTmpIdProveedor)
                        txtTotalCompra.Text = Format(CDec(txtTotalCompra.Text), "##,###,###,##0.##")
                    Else
                        '-- no existe como proveedor
                        chkProveedor.Checked = False
                        chkProveedor.BackColor = Drawing.Color.Pink
                        txtTotalCompra.Text = 0
                    End If

                    intTmpIdFabricante = sp_datosTabla.consulta_valor("select idLaboratorio from laboratorio where activo=1 and idPersonaJur=" & intTmpIdPersonaJur)
                    If intTmpIdFabricante > 0 Then
                        '-----------------'
                        '-- LABORATORIO --'
                        '-----------------'
                        chkLaboratorio.Checked = True
                        chkLaboratorio.BackColor = Drawing.Color.Lime
                        txtMesesCanje.Text = sp_datosTabla.consulta_valor("select cantidadMes from laboratorio where idLaboratorio=" & intTmpIdFabricante)
                    Else
                        '-- no existe como laboratorio
                        chkLaboratorio.Checked = False
                        chkLaboratorio.BackColor = Drawing.Color.Pink
                        txtMesesCanje.Text = 0
                        'MsgBox("Paso por aca")
                    End If

                    'intTmpIdDivision = sp_datosTabla.consulta_valor("select idDivision from division where idPersonaJur=" & intTmpIdPersonaJur & " and idLaboratorio=" & intTmpIdFabricante)
                    intTmpIdDivision = sp_datosTabla.consulta_valor("select idDivision from division where idPersonaJur=" & intTmpIdPersonaJur)
                    If intTmpIdDivision > 0 Then
                        '--------------'
                        '-- DIVISION --'
                        '--------------'
                        chkDivision.Checked = True
                        chkDivision.BackColor = Drawing.Color.Lime
                        cboLaboratorio.SelectedValue = sp_datosTabla.consulta_valor("select idLaboratorio from division where idDivision=" & intTmpIdDivision)
                    Else
                        chkDivision.Checked = False
                        chkDivision.BackColor = Drawing.Color.Pink
                    End If

                    intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from sucursal where activo=1 and idPersonaJur=" & intTmpIdPersonaJur)
                    If intTmpIdSucursal > 0 Then
                        '--------------'
                        '-- SUCURSAL --'
                        '--------------'
                        chkSucursal.Checked = True
                        chkSucursal.BackColor = Drawing.Color.Lime
                    Else
                        '-- no existe como sucursal
                        chkSucursal.Checked = False
                        chkSucursal.BackColor = Drawing.Color.Pink
                    End If

                    intTmpIdEmpresaContable = sp_datosTabla.consulta_valor("select idEmpresaContable from empresaContable where activo=1 and idPersonaJur=" & intTmpIdPersonaJur)
                    If intTmpIdEmpresaContable > 0 Then
                        '----------------------'
                        '-- EMPRESA CONTABLE --'
                        '----------------------'
                        chkEmpresaContable.Checked = True
                        chkEmpresaContable.BackColor = Drawing.Color.Lime
                    Else
                        '-- no existe como sucursal
                        chkEmpresaContable.Checked = False
                        chkEmpresaContable.BackColor = Drawing.Color.Pink
                    End If
                Else
                    chkPersonaJur.Checked = False
                    chkPersonaJur.BackColor = Drawing.Color.Pink
                    chkProveedor.Checked = False
                    chkProveedor.BackColor = Drawing.Color.Pink
                    chkLaboratorio.Checked = False
                    chkLaboratorio.BackColor = Drawing.Color.Pink
                    chkSucursal.Checked = False
                    chkSucursal.BackColor = Drawing.Color.Pink
                    chkEmpresaContable.Checked = False
                    chkEmpresaContable.BackColor = Drawing.Color.Pink
                    chkDivision.Checked = False
                    chkDivision.BackColor = Drawing.Color.Pink
                    txtTotalCompra.Text = 0
                End If

                '---------------------'
                '-- PERSONA CLIENTE --'
                '---------------------'
                intTmpIdCliente = sp_datosTabla.consulta_valor("select idCliente from cliente where activo=1 and idPersona=" & CInt(item.SubItems(0).Text))
                If intTmpIdCliente > 0 Then
                    chkCliente.Checked = True
                    chkCliente.BackColor = Drawing.Color.Lime
                    '-- el grupo
                    grupoCliente.grupoClienteCombo(cboGrupoCliente)
                    cboGrupoCliente.SelectedValue = sp_datosTabla.consulta_valor("select idGrupoCliente from cliente where idCliente=" & intTmpIdCliente)
                    If sp_datosTabla.consulta_valor("select idCliente from cliente where acreditar=1 and idCliente=" & intTmpIdCliente) > 0 Then
                        chkAcreditar.Checked = True
                        chkAcreditar.BackColor = Drawing.Color.Lime
                    Else
                        chkAcreditar.Checked = False
                        chkAcreditar.BackColor = Drawing.Color.Pink
                    End If
                    '-- el limite
                    If sp_datosTabla.consulta_valor("select idCliente from cliente where habilitarLimite=1 and idCliente=" & intTmpIdCliente) > 0 Then
                        chkLimite.Checked = True
                        chkLimite.BackColor = Drawing.Color.Lime
                        txtLimite.Text = sp_datosTabla.consulta_valorDouble("select limiteCredito from cliente where idCliente=" & intTmpIdCliente)
                        txtLimite.Text = Format(CDec(txtLimite.Text), "###,###,##0")
                    Else
                        chkLimite.Checked = False
                        chkLimite.BackColor = Drawing.Color.Pink
                        txtLimite.Text = 0
                    End If
                    '--- uso interno
                    chkUsoInterno.Checked = sp_datosTabla.consulta_valorBoolean("select usoInterno from cliente where idCliente=" & intTmpIdCliente)
                Else
                    '-- no existe como cliente
                    chkCliente.Checked = False
                    chkCliente.BackColor = Drawing.Color.Pink
                    txtLimite.Text = 0
                    chkUsoInterno.Checked = False
                    chkUsoInterno.BackColor = Drawing.Color.Pink
                End If

            Next
            ' txtUsuarioAlta.Text = sp_obtenerDatosUsuario.nombreUsuario(intIdusuarioAlta)
            'strNombreUsuario = sp_obtenerDatosUsuario.nombreUsuario(4)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub lvCargo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPersona.KeyPress, lvPersona.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtRuc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc.KeyPress
        'e.Handled = txtNumerico(txtRuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDv.Focus()
            'SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDv_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDv.KeyPress
        e.Handled = txtNumerico(txtDv, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDireccion.Focus()
            'SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtBarrio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarrio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCiudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiudad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNroCasa.Focus()
        End If
    End Sub

    Private Sub txtNroCasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCasa.KeyPress
        e.Handled = txtNumerico(txtNroCasa, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            maskFechaAni.Focus()
        End If
    End Sub

    Private Sub txtTele1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTele1.KeyPress
        e.Handled = txtNumerico(txtTele1, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTele2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTele2.KeyPress
        e.Handled = txtNumerico(txtTele2, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCelular1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelular1.KeyPress
        e.Handled = txtNumerico(txtCelular1, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCelular2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelular2.KeyPress
        e.Handled = txtNumerico(txtCelular2, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtLimite_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLimite.KeyPress
        e.Handled = txtNumerico(txtLimite, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
            txtLimite.Text = Format(CDec(txtLimite.Text), "###,###,##0.##")
        End If
    End Sub

    Private Sub txtEmail1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtEmail2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtWeb_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWeb.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If rdIdPersona.Checked = True Then
                ' ordenar por idcargo
                listar(" Where p.idPersona=" & txtBuscar.Text)
            End If
            If rdNombre.Checked = True Then
                ' ordenar por nombre 
                listar(" Where p.nombre Like '" & txtBuscar.Text & "%'" & " order by p.nombre")
            End If
            If rdApellido.Checked = True Then
                ' ordenar por apellido
                listar(" Where p.apellido Like '" & txtBuscar.Text & "%'" & " order by p.nombre")
            End If
            If rdRuc.Checked = True Then
                ' ordenar por ruc
                listar(" Where p.ruc='" & txtBuscar.Text & "'")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvCargo.Select()
            'lvCargo.Focus()
        End If
    End Sub

    Private Sub txtRuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRuc.LostFocus
        txtDv.Text = getDV(txtRuc.Text)
    End Sub

    Private Sub txtMesesCanje_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesesCanje.KeyPress
        e.Handled = txtNumerico(txtMesesCanje, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtTotalCompra.Focus()
            'SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTotalCompra_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalCompra.KeyPress
        e.Handled = txtNumerico(txtTotalCompra, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtTotalCompra.Text = Format(CDec(txtTotalCompra.Text), "###,###,##0.##")
            btnGuardar.Focus()
            'SendKeys.Send("{tab}")
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '*****************'
    '-- RADIO BUTON --'
    '*****************'
    Private Sub rdIdPersona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIdPersona.Click
        'listar(" Where p.nombre <> '' " & " order by p.idPersona")
        txtBuscar.Focus()
    End Sub

    Private Sub rdNombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNombre.Click
        'listar(" Where p.nombre <> '' " & " order by p.nombre")
        txtBuscar.Focus()
    End Sub

    Private Sub rdRuc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdRuc.Click
        txtBuscar.Focus()
    End Sub

    Private Sub rdApellido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdApellido.Click
        txtBuscar.Focus()
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '***************'
    '-- CHECK BOX --'
    '***************'
    Private Sub chkPersonaFis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPersonaFis.Click
        objetoPersonaFisica()
        If chkPersonaFis.Checked = True Then
            chkPersonaFis.BackColor = Drawing.Color.Lime
        Else
            chkPersonaFis.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkPersonaJur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPersonaJur.Click
        objetoPersonaJuridica()
        If chkPersonaJur.Checked = True Then
            chkPersonaJur.BackColor = Drawing.Color.Lime
        Else
            chkPersonaJur.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.Click
        objetoPersonaCliente()
        If chkCliente.Checked = True Then
            chkCliente.BackColor = Drawing.Color.Lime
        Else
            chkCliente.BackColor = Drawing.Color.Pink
        End If
    End Sub

    '-- persona fisica
    Private Sub chkEmpleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmpleado.Click
        If chkEmpleado.Checked = True Then
            chkEmpleado.BackColor = Drawing.Color.Lime
            chkCocinero.Enabled = True
            chkRepartidor.Enabled = True

        Else
            chkEmpleado.BackColor = Drawing.Color.Pink
            chkCocinero.Enabled = False
            chkCocinero.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVendedor.Click
        If chkVendedor.Checked = True Then
            chkVendedor.BackColor = Drawing.Color.Lime
        Else
            chkVendedor.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCobrador.Click
        If chkCobrador.Checked = True Then
            chkCobrador.BackColor = Drawing.Color.Lime
        Else
            chkCobrador.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkRepartidor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRepartidor.Click
        If chkRepartidor.Checked = True Then
            chkRepartidor.BackColor = Drawing.Color.Lime
        Else
            chkRepartidor.BackColor = Drawing.Color.Pink
        End If
    End Sub

    '-- persona juridica
    Private Sub chkProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProveedor.Click
        If chkProveedor.Checked = True Then
            chkProveedor.BackColor = Drawing.Color.Lime
            txtPorcentajeImportado.Enabled = True
            txtPorcentajeImportado.BackColor = Color.White
            txtPorcentajeNacional.Enabled = True
            txtPorcentajeNacional.BackColor = Color.White
            txtTotalCompra.Enabled = True
            txtTotalCompra.BackColor = Color.White
        Else
            chkProveedor.BackColor = Drawing.Color.Pink
            txtPorcentajeImportado.Enabled = False
            txtPorcentajeImportado.BackColor = Color.LightSkyBlue
            txtPorcentajeNacional.Enabled = False
            txtPorcentajeNacional.BackColor = Color.LightSkyBlue
            txtTotalCompra.Enabled = False
            txtTotalCompra.BackColor = Color.LightSkyBlue
        End If
    End Sub

    Private Sub chkFabricante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLaboratorio.Click
        If chkLaboratorio.Checked = True Then
            chkLaboratorio.BackColor = Drawing.Color.Lime
        Else
            chkLaboratorio.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkSucursal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSucursal.Click
        If chkSucursal.Checked = True Then
            chkSucursal.BackColor = Drawing.Color.Lime
        Else
            chkSucursal.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkEmpresaContable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmpresaContable.Click
        If chkEmpresaContable.Checked = True Then
            chkEmpresaContable.BackColor = Drawing.Color.Lime
        Else
            chkEmpresaContable.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkDivision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDivision.Click
        If chkDivision.Checked = True Then
            chkDivision.BackColor = Drawing.Color.Lime
            cboLaboratorio.Enabled = True
        Else
            chkDivision.BackColor = Drawing.Color.Pink
            cboLaboratorio.Enabled = False
        End If
    End Sub
    '-- cliente
    Private Sub chkAcreditar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAcreditar.Click
        If chkAcreditar.Checked = True Then
            chkAcreditar.BackColor = Drawing.Color.Lime
        Else
            chkAcreditar.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkLimite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLimite.Click
        If chkLimite.Checked = True Then
            chkLimite.BackColor = Drawing.Color.Lime
        Else
            chkLimite.BackColor = Drawing.Color.Pink
        End If
    End Sub

    Private Sub chkCocinero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCocinero.Click
        If chkCocinero.Checked = True Then
            chkCocinero.BackColor = Drawing.Color.Lime
        Else
            chkCocinero.BackColor = Drawing.Color.Pink
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '**************'
    '-- COMBOBOX --'
    '**************'
    '-- pais
    Private Sub cboPais_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboPais.KeyPress
        txtCiudad.Focus()
    End Sub

    'Private Sub cboPais_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPais.SelectedIndexChanged
    '    departamentoPais.listarDepartamentoPaisCombo(cboDepartamento, cboPais.SelectedValue)
    'End Sub

    '-----------------------------------------------------------------------------------------------------
    '******************'
    '-- LAS MASKARAS --'
    '******************'
    Private Sub maskFechaAni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskFechaAni.KeyDown
        ToolTip1.Hide(maskFechaAni)
    End Sub

    Private Sub maskFechaAni_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskFechaAni.TypeValidationCompleted
        Dim strPrueba As String = maskFechaAni.Text
        '-- solo hacer el procedimiento si la primera expresion es numerica
        If IsNumeric(strPrueba.Substring(0, 1)) Then
            If Len(maskFechaAni.Text) > 0 Then

                'strPrueba.su()
                'MsgBox("Valor de la mascara  " & strPrueba, MsgBoxStyle.Information)
                If (Not e.IsValidInput) Then
                    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    ToolTip1.Show("Debe introducir una fecha con formato .", maskFechaAni, 70, -70, 700)
                    e.Cancel = True
                Else
                    Dim userdate As DateTime = CDate(e.ReturnValue)
                    ' controlar que la fecha no sea superior a la fecha actual
                    If (userdate > DateTime.Now) Then
                        ToolTip1.ToolTipTitle = "Fecha no es Válida"
                        ToolTip1.Show("La fecha debe ser menor a la fecha actual del sistema.", maskFechaAni, 0, -20, 5000)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub maskFechaAni_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles maskFechaAni.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '******************'
    '-- EL FORMULARIO --'
    '******************'
    Private Sub frmAbmPersonaNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'validar el la maskara de tipo fecha
        maskFechaAni.Mask = "00/00/0000"
        maskFechaAni.ValidatingType = GetType(System.DateTime)
        ToolTip1.IsBalloon = True
    End Sub

    Private Sub frmAbmPersonaNuevo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
        frmMenuPrincipal.abmPersonaEntidad.Enabled = True
    End Sub
    '-----------------------------------------------------------------------------------------------------

End Class