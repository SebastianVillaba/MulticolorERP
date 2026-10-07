Public Class frmAbmTimbradoDE
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
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
        systemClass.SqlToLv_Factura(lvFormulario, "Select t.idTimbradoDE, t.nroTimbrado,convert(varchar,t.fechaTimbrado,103) as fecha from timbradoDE t " & where)
        ' dimensionar las columnas
        lvFormulario.Columns(0).Width = 60    'IDTimbrado
        lvFormulario.Columns(1).Width = 90  'timbrado
        lvFormulario.Columns(2).Width = 90  'fecha hasta
        lvFormulario.Scrollable = True
    End Sub

    Private Sub hablitarObjetos()
        '-- el grupo
        grBuscar.Enabled = False
        '-- los txt
        txtFecha.Enabled = True
        txtFecha.BackColor = Color.White
        txtTimbrado.Enabled = True
        txtTimbrado.BackColor = Color.White
        txtFechaNormal.Enabled = True
        txtFechaNormal.BackColor = Color.White
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        btnBuscarFirma.Enabled = True

    End Sub

    Private Sub deshabilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = True
        '-- los txt
        txtFechaNormal.Enabled = False
        txtFechaNormal.BackColor = Color.SkyBlue
        txtFecha.Enabled = False
        txtFecha.BackColor = Color.SkyBlue
        txtTimbrado.Enabled = False
        txtTimbrado.BackColor = Color.SkyBlue
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        btnBuscarFirma.Enabled = False

        listar("")
    End Sub

    Private Sub limpiarObjeto()
        '--txt 
        txtIdTimbrado.Text = 0
        txtFecha.Text = ""
        txtFechaNormal.Text = ""
        txtTimbrado.Text = 0
        txtIdFirma.Text = 0
        txtFirma.Text = ""
    End Sub

    Private Sub guardarFactura()
        '-- controlar si hay errores
        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'
            If (fun_guardarSp("sp_insTimbradoDE", txtIdFirma.Text & "," & txtTimbrado.Text & ",'" & txtFecha.Text & "','" & _
                              txtFechaNormal.Text & "'," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el Timbrado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        Else
            '******************'
            '-- MODIFICACION --'
            '******************'
            If (fun_guardarSp("sp_updTimbradoDE", txtIdTimbrado.Text & "," & txtIdFirma.Text & "," & txtTimbrado.Text & ",'" & _
                              txtFecha.Text & "','" & txtFechaNormal.Text & "'," & intGl_idUsuario, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '-- se guardo los registros
                MessageBox.Show("Se guardo el Timbrado..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                deshabilitarObjetos()
            End If
        End If

    End Sub
    '-------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True

        hablitarObjetos()
        limpiarObjeto()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtIdTimbrado.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        bolTmpNuevo = False
        hablitarObjetos()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardarFactura()
    End Sub

    Private Sub btnBuscarFirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFirma.Click
        Me.Enabled = False

        banGl_abmTimbradoDE = True
        frmBuscarPersonaJur.txtId.Text = 0
        frmBuscarPersonaJur.txtBuscar.Text = ""

        frmBuscarPersonaJur.Show()
        frmBuscarPersonaJur.BringToFront()
        frmBuscarPersonaJur.txtBuscar.Focus()
    End Sub
    '--------------------------------------------------------------------------------------------------
    '***************'
    '-- LISTVIEW --'
    '***************'
    Private Sub lvFormulario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFormulario.SelectedIndexChanged
        Dim intTmpIdTimbrado As Integer
        Dim intTmpIdFirma As Integer
        For Each item As ListViewItem In lvFormulario.SelectedItems
            intTmpIdTimbrado = CInt(item.SubItems(0).Text)
            txtIdTimbrado.Text = intTmpIdTimbrado
            txtTimbrado.Text = item.SubItems(1).Text
            txtFecha.Text = item.SubItems(2).Text
            '-- los demas datos
            txtFechaNormal.Text = sp_datosTabla.un_datoString("fechaNormal", "timbradoDE", "idTimbradoDE", intTmpIdTimbrado)
            '-- la firma digital
            intTmpIdFirma = sp_datosTabla.un_dato_integer("idFirmaDigital", "timbradoDE", "idTimbradoDE", intTmpIdTimbrado)
            txtIdFirma.Text = intTmpIdFirma
            txtFirma.Text = sp_datosTabla.consulta_valorString("select nombre from v_personaJur where idPersonaJur=" & intTmpIdFirma)
        Next
    End Sub

    Private Sub lvFormulario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvFormulario.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
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
                    listar(" where p.nombre Like '" & txtBuscar.Text & "%' Or p.nombre Like '" & txtBuscar.Text & "%' " & "order by p.nombre")
                End If
            End If
            lvFormulario.Focus()
        End If
    End Sub

    Private Sub txtTimbrado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimbrado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFecha.Focus()
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFechaNormal.Focus()
        End If
    End Sub

    Private Sub txtFechaNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaNormal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtFechaNormal.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmTimbradoDE_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.contabilidadAbmTimbradoDE.Enabled = True
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------


End Class