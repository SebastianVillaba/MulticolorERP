Public Class frmAbmFactura
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim sucursal As New Sucursal

    Dim bolTmpNuevo As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv_Factura(lvFormulario, "Select f.idFactura, f.timbrado,_vs.nombreFantasia as Sucursal,f.fechaCaduca from factura f inner join v_sucursal _vs on f.idSucursal=_vs.idSucursal" & where)
        ' dimensionar las columnas
        lvFormulario.Columns(0).Width = 60    'IDFactura
        lvFormulario.Columns(1).Width = 80  'timbrado
        lvFormulario.Columns(2).Width = 200  'sucursal
        lvFormulario.Columns(3).Width = 80  'fechaCaduca
        lvFormulario.Scrollable = True
    End Sub

    Private Sub hablitarObjetos()
        '-- el grupo
        grBuscar.Enabled = False
        '-- los txt
        txtDsuc.Enabled = True
        txtDsuc.BackColor = Color.White
        txtDcaja.Enabled = True
        txtDcaja.BackColor = Color.White
        txtNroFactura.Enabled = True
        txtNroFactura.BackColor = Color.White
        txtNroFacturaSgte.Enabled = True
        txtNroFacturaSgte.BackColor = Color.White
        txtTimbrado.Enabled = True
        txtTimbrado.BackColor = Color.White
        maskFechaCaduca.Enabled = True
        maskFechaCaduca.BackColor = Color.White
        '-- dar valor
        txtCantidadLinea.Text = 0
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        '-- el chk
        chkActivo.Enabled = True
        chkPreImpreso.Enabled = True
        '-- el combo
        cboSucursal.Enabled = True

    End Sub

    Private Sub deshabilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = True
        '-- los txt
        txtDcaja.Enabled = False
        txtDcaja.BackColor = Color.SkyBlue
        txtDsuc.Enabled = False
        txtDsuc.BackColor = Color.SkyBlue
        txtNroFactura.Enabled = False
        txtNroFactura.BackColor = Color.SkyBlue
        txtNroFacturaSgte.Enabled = False
        txtNroFacturaSgte.BackColor = Color.SkyBlue
        txtTimbrado.Enabled = False
        txtTimbrado.BackColor = Color.SkyBlue
        txtCantidadLinea.Enabled = False
        txtCantidadLinea.BackColor = Color.SkyBlue
        maskFechaCaduca.Enabled = False
        maskFechaCaduca.BackColor = Color.SkyBlue
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        '-- el chk
        chkActivo.Enabled = False
        chkPreImpreso.Enabled = False
        '-- el combo
        cboSucursal.Enabled = False

        listar("")
    End Sub

    Private Sub limpiarObjeto()
        '--txt 
        txtIdFactura.Text = 0
        txtDcaja.Text = ""
        txtDsuc.Text = ""
        txtNroFactura.Text = 0
        txtNroFacturaSgte.Text = 0
        txtTimbrado.Text = 0
        txtCantidadLinea.Text = 0
        maskFechaCaduca.Text = ""
    End Sub

    Private Sub guardarFactura()
        '-- variables para los parametros
        Dim intTmpIdFactura As Integer
        Dim intTmpNroFactura As Integer
        Dim intTmpNroFacturaSgte As Integer
        Dim intTmpIdSucursal As Integer
        Dim intTmpCantidadLinea As Integer

        Dim strTmpDsuc As String
        Dim strTmpDcaja As String
        Dim strTmpTimbrado As String
        Dim strTmpFechaCaduca As String

        Dim bolTmpActivo As Boolean
        Dim bolTmpPreImpreso As Boolean

        '-- controlar si hay errores
        If Not IsNumeric(maskFechaCaduca.Text.Substring(0, 1)) Then
            MessageBox.Show("Debe ingresar una fecha de Caducidad Válida..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            strTmpFechaCaduca = maskFechaCaduca.Text()
        End If
        '-- dar valor a las variables
        intTmpIdFactura = CInt(txtIdFactura.Text)
        bolTmpActivo = chkActivo.Checked
        bolTmpPreImpreso = chkPreImpreso.Checked
        intTmpIdSucursal = CInt(cboSucursal.SelectedValue)
        'MsgBox("Valor de la sucursal  " & intTmpIdSucursal)
        strTmpDcaja = txtDcaja.Text
        strTmpDsuc = txtDsuc.Text
        strTmpTimbrado = txtTimbrado.Text
        intTmpNroFactura = txtNroFactura.Text
        intTmpNroFacturaSgte = txtNroFacturaSgte.Text
        intTmpCantidadLinea = txtCantidadLinea.Text
        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'

            If (fun_guardarSp("sp_insFactura", intTmpIdSucursal & "," & "'" & strTmpDsuc & "'" & "," & "'" & strTmpDcaja & "'" & "," & intTmpNroFactura & "," & intTmpNroFacturaSgte & "," & "'" & strTmpTimbrado & "'" & "," & "'" & strTmpFechaCaduca & "'" & "," & bolTmpPreImpreso & "," & intTmpCantidadLinea & "," & intGl_idUsuario & "," & "''", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo los registros..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        Else
            '******************'
            '-- MODIFICACION --'
            '******************'
            If (fun_guardarSp("sp_updFactura", intTmpIdFactura & "," & intTmpIdSucursal & "," & "'" & strTmpDsuc & "'" & "," & "'" & strTmpDcaja & "'" & "," & intTmpNroFactura & "," & intTmpNroFacturaSgte & "," & "'" & strTmpTimbrado & "'" & "," & "'" & strTmpFechaCaduca & "'" & "," & bolTmpPreImpreso & "," & intTmpCantidadLinea & "," & intGl_idUsuario & "," & bolTmpActivo & "," & "''", Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el registro..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        End If

    End Sub
    '-------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True
        hablitarObjetos()
        limpiarObjeto()
        chkActivo.Checked = True
        chkActivo.Enabled = False
        sucursal.comboSucursal(cboSucursal)
        cboSucursal.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtDsuc.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        bolTmpNuevo = False
        hablitarObjetos()
        cboSucursal.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        guardarFactura()
    End Sub

    '--------------------------------------------------------------------------------------------------
    '***************'
    '-- LISTVIEW --'
    '***************'
    Private Sub lvFormulario_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvFormulario.SelectedIndexChanged
        Dim intTmpIdFactura As Integer
        Dim intTmpIdSucursal As Integer
        For Each item As ListViewItem In lvFormulario.SelectedItems
            intTmpIdFactura = CInt(item.SubItems(0).Text)
            txtIdFactura.Text = intTmpIdFactura
            txtTimbrado.Text = item.SubItems(1).Text
            maskFechaCaduca.Text = item.SubItems(3).Text
            '-- los demas datos
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "factura", "idFactura", intTmpIdFactura)
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "factura", "idFactura", intTmpIdFactura)
            txtNroFactura.Text = sp_datosTabla.un_dato_integer("nroFactura", "factura", "idFactura", intTmpIdFactura)
            txtNroFacturaSgte.Text = sp_datosTabla.un_dato_integer("nroFacturaSgte", "factura", "idFactura", intTmpIdFactura)
            txtCantidadLinea.Text = sp_datosTabla.un_dato_integer("cantidadLinea", "factura", "idFactura", intTmpIdFactura)

            chkActivo.Checked = sp_datosTabla.un_dato_boleano("activo", "factura", "idFactura", intTmpIdFactura)
            chkPreImpreso.Checked = sp_datosTabla.un_dato_boleano("preImpreso", "factura", "idFactura", intTmpIdFactura)

            '-- la sucursal
            sucursal.comboSucursal(cboSucursal)
            intTmpIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "factura", "idFactura", intTmpIdFactura)
            cboSucursal.SelectedValue = intTmpIdSucursal
        Next
    End Sub

    Private Sub lvFormulario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvFormulario.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- si solo se presiono enter
            If Len(txtBuscar.Text) = 0 Then
                '-- listar todo
                listar("")
            Else
                If IsNumeric(txtBuscar.Text) Then
                    '-- buscar por timbrado
                    listar(" where f.timbrado Like '" & txtBuscar.Text & "%' Or f.timbrado Like '" & txtBuscar.Text & "%' " & "order by f.timbrado")
                Else
                    '-- buscar por sucursal
                    listar(" where _vs.nombreFantasia Like '" & txtBuscar.Text & "%' Or _vs.nombreFantasia Like '" & txtBuscar.Text & "%' " & "order by _vs.nombreFantasia")
                End If
            End If
            lvFormulario.Focus()
        End If
    End Sub

    Private Sub chkPreImpreso_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPreImpreso.CheckedChanged
        If chkPreImpreso.Checked = True Then
            txtCantidadLinea.Enabled = True
            txtCantidadLinea.BackColor = Color.White
            txtCantidadLinea.Focus()
        Else
            txtCantidadLinea.Enabled = False
            txtCantidadLinea.BackColor = Color.SkyBlue
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '******************'
    '-- LAS MASKARAS --'
    '******************'
    Private Sub maskFechaCaduca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskFechaCaduca.KeyDown
        ToolTip1.Hide(maskFechaCaduca)
    End Sub

    Private Sub maskFechaCaduca_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskFechaCaduca.TypeValidationCompleted
        Dim strPrueba As String = maskFechaCaduca.Text
        '-- solo hacer el procedimiento si la primera expresion es numerica
        If IsNumeric(strPrueba.Substring(0, 1)) Then
            If Len(maskFechaCaduca.Text) > 0 Then
                'strPrueba.su()
                'MsgBox("Valor de la mascara  " & strPrueba, MsgBoxStyle.Information)
                If (Not e.IsValidInput) Then
                    ToolTip1.ToolTipTitle = "Fecha no es Válida"
                    ToolTip1.Show("Debe introducir una fecha con formato .", maskFechaCaduca, 70, -70, 700)
                    e.Cancel = True
                Else
                    Dim userdate As DateTime = CDate(e.ReturnValue)
                    ' controlar que la fecha no sea inferior a la fecha actual
                    If (userdate <= DateTime.Now) Then
                        ToolTip1.ToolTipTitle = "Fecha no es Válida"
                        ToolTip1.Show("La fecha debe ser mayor a la fecha actual del sistema.", maskFechaCaduca, 0, -20, 5000)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmFactura_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.configuracionRegistrarFacturas.Enabled = True
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------
End Class