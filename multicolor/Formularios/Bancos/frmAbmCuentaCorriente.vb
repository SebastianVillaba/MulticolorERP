Public Class frmAbmCuentaCorriente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim moneda As New moneda

    Dim bolTmpNuevo As Boolean

    Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        listar("")
    End Sub

    '*********************'
    '-- PROCEDIMIENTOS --'
    '*********************'
    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select c.idCuenta,c.nombreBanco,c.nroCuenta,m.nombreMoneda from cuentaCorriente c inner join moneda m on c.idMoneda=m.idMoneda " & where)
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 50 'idcuentaCorriente
        lvBuscar.Columns(1).Width = 130 'nombre del banco
        lvBuscar.Columns(2).Width = 100 'nro de cuenta
        lvBuscar.Columns(3).Width = 80 'descripcion de la moneda
        lvBuscar.Scrollable = True
    End Sub

    Private Sub habilitarObjetos()
        grBuscar.Enabled = False
        '-- los txt
        txtBanco.Enabled = True
        txtBanco.BackColor = Color.White
        txtCuenta.Enabled = True
        txtCuenta.BackColor = Color.White
        '-- los combos
        cboMoneda.Enabled = True
        '-- los chk
        chkActivo.Enabled = True
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
    End Sub

    Private Sub deshabilitarObjetos()
        grBuscar.Enabled = True
        '-- los txt
        txtBanco.Enabled = False
        txtBanco.BackColor = Color.SkyBlue
        txtCuenta.Enabled = False
        txtCuenta.BackColor = Color.SkyBlue
        '-- los combos
        cboMoneda.Enabled = False
        '-- los chk
        chkActivo.Enabled = False
        '-- los botones
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        listar("")
    End Sub

    Private Sub limpiarObjetos()
        '-- los txt
        txtIdCuenta.Text = 0
        txtBanco.Text = ""
        txtCuenta.Text = ""
        '-- los chk
        chkActivo.Checked = False
    End Sub

    Private Sub guardarCuentaCorriente()
        '-- variables para los parametros
        Dim intTmpIdCuenta As Integer
        Dim intTmpIdMoneda As Integer
        Dim strTmpBanco As String
        Dim strTmpNroCuenta As String
        Dim bolTmpActivo As Boolean

        '-- dar valor a las variables de parametro
        strTmpBanco = txtBanco.Text
        strTmpNroCuenta = txtCuenta.Text
        intTmpIdCuenta = txtIdCuenta.Text
        intTmpIdMoneda = cboMoneda.SelectedValue
        bolTmpActivo = chkActivo.Checked
        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insCuentaCorriente", "'" & strTmpBanco & "'" & "," & "'" & strTmpNroCuenta & "'" & "," & intTmpIdMoneda & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        Else
            '******************'
            '-- MODIFICACION --'
            '******************'
            '-- si es una actualizacion
            If (fun_guardarSp("sp_updCuentaCorriente", intTmpIdCuenta & "," & "'" & strTmpBanco & "'" & "," & "'" & strTmpNroCuenta & "'" & "," & intTmpIdMoneda & "," & bolTmpActivo & "," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por banco
                listar(" Where c.nombreBanco Like '" & txtBuscar.Text & "%' Or c.nombreBanco Like '" & txtBuscar.Text & "%' " & "order by c.nombreBanco")
            Else
                '-- buscar por idCuenta
                listar(" Where c.idCuenta=" & txtBuscar.Text & " order by c.idCuenta")
            End If
            lvBuscar.Focus()
        End If
    End Sub

    Private Sub txtBanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBanco.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtCuenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True

        listar("")

        habilitarObjetos()
        limpiarObjetos()
        moneda.listarMonedaCombo(cboMoneda)
        chkActivo.Enabled = False
        chkActivo.Checked = True
        txtBanco.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtIdCuenta.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        habilitarObjetos()
        grBuscar.Visible = True
        grBuscar.Enabled = False
        txtBanco.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        grBuscar.Enabled = True
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarCuentaCorriente()
    End Sub
    '-----------------------------------------------------------------------------------------------
    '******************'
    '-- EL LISTVIEW --'
    '******************'
    Private Sub lvBuscar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        Dim intTmpIdCuenta As Integer
        Dim intTmpIdMoneda As Integer
        For Each item As ListViewItem In lvBuscar.SelectedItems
            '-- colocar en una variable el idUsuario
            intTmpIdCuenta = CInt(item.SubItems(0).Text)
            txtIdCuenta.Text = intTmpIdCuenta
            txtBanco.Text = item.SubItems(1).Text
            txtCuenta.Text = item.SubItems(2).Text
            intTmpIdMoneda = sp_datosTabla.un_dato_integer("idMoneda", "cuentaCorriente", "idCuenta", intTmpIdCuenta)
            '-- el grupo de usuario
            moneda.listarMonedaCombo(cboMoneda)
            cboMoneda.SelectedValue = intTmpIdMoneda
            '-- los chk
            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "cuentaCorriente", "idCuenta", intTmpIdCuenta)
            '-- datos de la auditoria del usuario
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioAlta", "cuentaCorriente", "idCuenta", intTmpIdCuenta)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioMod", "cuentaCorriente", "idCuenta", intTmpIdCuenta)))
            txtFechaAlta.Text = sp_datosTabla.un_datoString("fechaAlta", "cuentaCorriente", "idCuenta", intTmpIdCuenta)
            txtFechaMod.Text = sp_datosTabla.un_datoString("fechaMod", "cuentaCorriente", "idCuenta", intTmpIdCuenta)
        Next
    End Sub

    Private Sub lvBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmCuentaCorriente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoAbmCuentaCorriente.Enabled = True
        e.Cancel = False
    End Sub
    '-----------------------------------------------------------------------------------------------


  
End Class