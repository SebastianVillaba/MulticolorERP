Public Class frmAbmChequera
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim cuentaCorriente As New cuentaCorriente

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
        systemClass.SqlToLv(lvBuscar, "Select ch.idChequera,ch.chequeInicial,ch.chequeFinal,c.nombreBanco,c.nroCuenta from chequera ch inner join cuentaCorriente c on ch.idCuenta=c.idCuenta " & where)
        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 50 'IdChequeta
        lvBuscar.Columns(1).Width = 60 'cheque inicial
        lvBuscar.Columns(2).Width = 60 'cheque final
        lvBuscar.Columns(3).Width = 120 'nombre del banco
        lvBuscar.Columns(4).Width = 80 'nro de cuenta

        lvBuscar.Scrollable = True
    End Sub

    Private Sub habilitarObjetos()
        grBuscar.Enabled = False
        '-- los txt
        txtChequeIni.Enabled = True
        txtChequeIni.BackColor = Color.White
        txtChequeFinal.Enabled = True
        txtChequeFinal.BackColor = Color.White
        txtSerial.Enabled = True
        txtSerial.BackColor = Color.White
        '-- los combos
        cboCuentaCorriente.Enabled = True
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
        txtChequeIni.Enabled = False
        txtChequeIni.BackColor = Color.SkyBlue
        txtChequeFinal.Enabled = False
        txtChequeFinal.BackColor = Color.SkyBlue
        txtSerial.Enabled = False
        txtSerial.BackColor = Color.SkyBlue
        '-- los combos
        cboCuentaCorriente.Enabled = False
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
        txtIdChequera.Text = 0
        txtChequeIni.Text = 0
        txtChequeFinal.Text = 0
        txtSerial.Text = ""
        '-- los chk
        chkActivo.Checked = False
    End Sub

    Private Sub guardarChequera()
        '-- variables para los parametros
        Dim intTmpIdChequera
        Dim intTmpIdCuenta As Integer
        Dim intTmpChqueInicial As Integer
        Dim intTmpChequeFinal As Integer
        Dim bolTmpActivo As Boolean

        '-- dar valor a las variables de parametro
        intTmpIdChequera = txtIdChequera.Text
        intTmpChqueInicial = txtChequeIni.Text
        intTmpChequeFinal = txtChequeFinal.Text
        intTmpIdCuenta = cboCuentaCorriente.SelectedValue
        bolTmpActivo = chkActivo.Checked
        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insChequera", intTmpChqueInicial & "," & intTmpChequeFinal & "," & intTmpIdCuenta & "," & "'" & txtSerial.Text & "'" & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
            If (fun_guardarSp("sp_updChequera", intTmpIdChequera & "," & intTmpChqueInicial & "," & intTmpChequeFinal & "," & intTmpIdCuenta & "," & "'" & txtSerial.Text & "'" & "," & bolTmpActivo & "," & intGl_idUsuario, Me.Name)) = 0 Then
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
                '-- buscar por idChequera
                listar(" Where ch.idChequera=" & txtBuscar.Text & " order by ch.idChequera")
            End If
            lvBuscar.Focus()
        End If
    End Sub

    Private Sub txtChequeIni_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtChequeIni.KeyPress
        e.Handled = txtNumerico(txtChequeIni, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtChequeFinal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtChequeFinal.KeyPress
        e.Handled = txtNumerico(txtChequeFinal, e.KeyChar, True)
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
        cuentaCorriente.cuentaCorrienteCombo(cboCuentaCorriente)
        chkActivo.Enabled = False
        chkActivo.Checked = True
        txtChequeIni.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtIdChequera.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        bolTmpNuevo = False
        habilitarObjetos()
        grBuscar.Visible = True
        grBuscar.Enabled = False
        txtChequeIni.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        grBuscar.Enabled = True
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarChequera()
    End Sub
    '-----------------------------------------------------------------------------------------------
    '******************'
    '-- EL LISTVIEW --'
    '******************'
    Private Sub lvBuscar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        Dim intTmpIdCuenta As Integer
        Dim intTmpIdChequera As Integer
        For Each item As ListViewItem In lvBuscar.SelectedItems
            '-- colocar en una variable el idUsuario
            intTmpIdChequera = CInt(item.SubItems(0).Text)
            txtIdChequera.Text = intTmpIdChequera
            txtChequeIni.Text = item.SubItems(1).Text
            txtChequeFinal.Text = item.SubItems(2).Text
            intTmpIdCuenta = sp_datosTabla.un_dato_integer("idCuenta", "chequera", "idChequera", intTmpIdChequera)
            '-- la cuenta corriente
            cuentaCorriente.cuentaCorrienteCombo(cboCuentaCorriente)
            cboCuentaCorriente.SelectedValue = intTmpIdCuenta
            txtSerial.Text = sp_datosTabla.consulta_valorString("select serial from chequera where idChequera=" & intTmpIdChequera)
            '-- los chk
            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "chequera", "idChequera", intTmpIdChequera)
            '-- datos de la auditoria del usuario
            txtUsuarioAlta.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioAlta", "chequera", "idChequera", intTmpIdChequera)))
            txtUsuarioMod.Text = sp_datosTabla.dos_datos("nombre,apellido", "v_usuarioT", "idUsuario", CInt(sp_datosTabla.un_dato_integer("idUsuarioMod", "chequera", "idChequera", intTmpIdChequera)))
            txtFechaAlta.Text = sp_datosTabla.un_datoString("fechaAlta", "chequera", "idChequera", intTmpIdChequera)
            txtFechaMod.Text = sp_datosTabla.un_datoString("fechaMod", "chequera", "idChequera", intTmpIdChequera)
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
    Private Sub frmAbmChequera_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.bancoAbmChequera.Enabled = True
        e.Cancel = False
    End Sub
    '-----------------------------------------------------------------------------------------------
End Class