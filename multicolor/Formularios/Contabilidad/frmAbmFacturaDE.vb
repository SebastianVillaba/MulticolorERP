Public Class frmAbmFacturaDE
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass
    Dim sucursal As New Sucursal
    Dim tipoFactura As New tipoFactura
    Dim timbradoDE As New timbradoDE

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
        sucursal.comboSucursal(cboSucursal)
        tipoFactura.comboTipoFactura(cboTipoFactura)
        timbradoDE.comboTimbradoDE(cboTimbrado)
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv_Factura(lvFormulario, "Select df.idDetFacturaDE,t.nroTimbrado,_vs.nombreFantasia as Sucursal from cabFacturaDE cf inner join " & _
                                    " detFacturaDE df on cf.idFacturaDE=df.idFacturaDE inner join detFacturaDETimbrado dft on dft.idFacturaDE=cf.idFacturaDE " & _
                                    " inner join v_sucursal _vs on df.idSucursal=_vs.idSucursal " & _
                                    " inner join timbradoDE t on t.idTimbradoDE=dft.idTimbradoDE " & where)
        ' dimensionar las columnas
        lvFormulario.Columns(0).Width = 60    'IDFactura
        lvFormulario.Columns(1).Width = 80  'timbrado
        lvFormulario.Columns(2).Width = 200  'sucursal
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
        txtNroFacturaIni.Enabled = True
        txtNroFacturaIni.BackColor = Color.White
        txtNroFacturaFin.Enabled = True
        txtNroFacturaFin.BackColor = Color.White
        txtNroFacturaSgte.Enabled = True
        txtNroFacturaSgte.BackColor = Color.White
        txtSerial.Enabled = True
        txtSerial.BackColor = Color.White
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False
        '-- el combo
        cboSucursal.Enabled = True
        cboTimbrado.Enabled = True
        cboTipoFactura.Enabled = True
    End Sub

    Private Sub deshabilitarObjetos()
        '-- el grupo
        grBuscar.Enabled = True
        '-- los txt
        txtDcaja.Enabled = False
        txtDcaja.BackColor = Color.SkyBlue
        txtDsuc.Enabled = False
        txtDsuc.BackColor = Color.SkyBlue
        txtNroFacturaIni.Enabled = False
        txtNroFacturaIni.BackColor = Color.SkyBlue
        txtNroFacturaFin.Enabled = False
        txtNroFacturaFin.BackColor = Color.SkyBlue
        txtNroFacturaSgte.Enabled = False
        txtNroFacturaSgte.BackColor = Color.SkyBlue
        txtSerial.Enabled = False
        txtSerial.BackColor = Color.SkyBlue
        '-- los botones
        btnCancelar.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True
        '-- el combo
        cboSucursal.Enabled = False
        cboTimbrado.Enabled = False
        cboTipoFactura.Enabled = False

        listar("")
    End Sub

    Private Sub limpiarObjeto()
        '--txt 
        txtIdFactura.Text = 0
        txtDcaja.Text = ""
        txtDsuc.Text = ""
        txtNroFacturaIni.Text = 0
        txtNroFacturaSgte.Text = 0
        txtNroFacturaFin.Text = 0
        txtSerial.Text = ""
        txtFechaVence.Text = ""
    End Sub

    Private Sub guardarFactura()
        '-- variables para los parametros
        Dim intTmpIdFactura As Integer
        Dim intIdDetFactura As Integer

        '-- dar valor a las variables
        intTmpIdFactura = cboTipoFactura.SelectedValue
        intIdDetFactura = txtIdFactura.Text

        If bolTmpNuevo = True Then
            '***********'
            '-- NUEVO --'
            '***********'

            If (fun_guardarSp("sp_insFacturaDTE", intTmpIdFactura & "," & cboSucursal.SelectedValue & "," & cboTimbrado.SelectedValue & ",'" & _
                              txtDsuc.Text & "','" & txtDcaja.Text & "'," & txtNroFacturaIni.Text & "," & txtNroFacturaFin.Text & "," & _
                              txtNroFacturaSgte.Text & ",'" & txtSerial.Text & "'", Me.Name)) = 0 Then
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
            If (fun_guardarSp("sp_updFacturaDTE", intIdDetFactura & "," & intTmpIdFactura & "," & cboSucursal.SelectedValue & "," & cboTimbrado.SelectedValue & ",'" & _
                              txtDsuc.Text & "','" & txtDcaja.Text & "'," & txtNroFacturaIni.Text & "," & txtNroFacturaFin.Text & "," & _
                              txtNroFacturaSgte.Text & ",'" & txtSerial.Text & "'", Me.Name)) = 0 Then
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
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        bolTmpNuevo = True
        hablitarObjetos()
        limpiarObjeto()
        cboSucursal.Focus()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        '-- controlar que exista un registro seleccionado
        If Len(txtDsuc.Text) = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificarlo...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        bolTmpNuevo = False
        hablitarObjetos()
        cboSucursal.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardarFactura()
    End Sub

    '--------------------------------------------------------------------------------------------------
    '***************'
    '-- LISTVIEW --'
    '***************'
    Private Sub lvFormulario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFormulario.SelectedIndexChanged
        Dim intTmpIdFactura As Integer
        Dim intTmpIdFac As Integer
        For Each item As ListViewItem In lvFormulario.SelectedItems
            intTmpIdFactura = CInt(item.SubItems(0).Text)
            txtIdFactura.Text = intTmpIdFactura
            '-- los demas datos
            txtDsuc.Text = sp_datosTabla.un_datoString("dsuc", "detFacturaDE", "idDetFacturaDE", intTmpIdFactura)
            txtDcaja.Text = sp_datosTabla.un_datoString("dcaja", "detFacturaDE", "idDetFacturaDE", intTmpIdFactura)
            txtNroFacturaIni.Text = sp_datosTabla.un_dato_integer("facturaInicial", "detFacturaDE", "idDetFacturaDE", intTmpIdFactura)
            txtNroFacturaFin.Text = sp_datosTabla.un_dato_integer("facturaFinal", "detFacturaDE", "idDetFacturaDE", intTmpIdFactura)
            txtNroFacturaSgte.Text = sp_datosTabla.un_dato_integer("nroFactura", "detFacturaDE", "idDetFacturaDE", intTmpIdFactura)
            txtSerial.Text = sp_datosTabla.consulta_valorString("select serial from detFacturaDE where idDetFacturaDE=" & intTmpIdFactura)
            intTmpIdFac = sp_datosTabla.consulta_valor("select idFacturaDE from detFacturaDE where idDetFacturaDE=" & intTmpIdFactura)
            txtFechaVence.Text = sp_datosTabla.consulta_valorString("select convert(varchar,t.fechaNormal),103 from timbradoDE t inner join " & _
                                                                    " detFacturaDETimbrado dft on t.idTimbradoDE=dft.idTimbradoDE " & _
                                                                    " where dft.idFacturaDE=" & intTmpIdFac)
            '-- la sucursal
            cboSucursal.SelectedValue = sp_datosTabla.consulta_valor("select idSucursal from detFacturaDE where idDetFacturaDE=" & intTmpIdFactura)
            '-- tipo de factura
            cboTipoFactura.SelectedValue = intTmpIdFac
            '-- el timbrado
            cboTimbrado.SelectedValue = sp_datosTabla.consulta_valor("select idTimbradoDE from detFacturaDETimbrado where idFacturaDE=" & intTmpIdFac)
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
                    listar(" where _vs.nombreFantasia Like '" & txtBuscar.Text & "%' Or _vs.nombreFantasia Like '" & txtBuscar.Text & "%' " & "order by _vs.nombreFantasia")
                End If
            End If
            lvFormulario.Focus()
        End If
    End Sub

    Private Sub txtDsuc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDsuc.KeyPress
        e.Handled = txtNumerico(txtDsuc, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtDcaja.Focus()
        End If
    End Sub

    Private Sub txtDcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDcaja.KeyPress
        e.Handled = txtNumerico(txtDcaja, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNroFacturaIni.Focus()
        End If
    End Sub

    Private Sub txtNroFacturaIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroFacturaIni.KeyPress
        e.Handled = txtNumerico(txtNroFacturaIni, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNroFacturaFin.Focus()
        End If
    End Sub

    Private Sub txtNroFacturaFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroFacturaFin.KeyPress
        e.Handled = txtNumerico(txtNroFacturaIni, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtSerial.Focus()
        End If
    End Sub

    Private Sub txtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerial.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtNroFacturaSgte.Focus()
        End If
    End Sub

    Private Sub txtNroFacturaSgte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroFacturaSgte.KeyPress
        e.Handled = txtNumerico(txtNroFacturaSgte, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmAbmFactura_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.contabilidadAbmFacturaElectronica.Enabled = True
        e.Cancel = False
    End Sub
    '---------------------------------------------------------------------------------------------------
End Class