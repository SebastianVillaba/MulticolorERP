Public Class frmBuscarTipoProceso
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdTipoProceso As Integer

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
        'valorde del combo
    End Sub

    Public Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select idTipoProceso,ltrim(nombreProceso) as Nombre from tipoProceso  " & where)
        ' txtSql.Text = "Select idMoneda,ltrim(nombreMoneda) as Nombre, abreviatura from moneda  " & where
    End Sub

    Private Sub configuracionEmail(ByVal v_idTipoProceso As Integer)
        '-- controlar si ya existe el item como configuracion
        If sp_datosTabla.consulta_valor("select idTipoProceso from cabConfigEmail where idTipoProceso=" & v_idTipoProceso) Then
            MessageBox.Show("Este Tipo de Proceso ya está cargado en la configuración del email..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'MsgBox("Valor de idTipoProceso  " & intIdTipoProceso)
        frmConfigEmail.lblNombreProceso.Text = sp_datosTabla.consulta_valorString("select nombreProceso from tipoProceso where idTipoProceso=" & intIdTipoProceso)
        frmConfigEmail.lblIdTipoProceso.Text = intIdTipoProceso
        frmConfigEmail.listarDetalle()
        '---------------------------
        frmConfigEmail.habilitarObjetos()
        Me.Close()
        frmConfigEmail.Enabled = True
        frmConfigEmail.Show()
        frmConfigEmail.BringToFront()
        frmConfigEmail.btnAgregar.Focus()
    End Sub

    Private Sub verificarModulo()
        If banGl_configEmail = True Then
            configuracionEmail(intIdTipoProceso)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*************'
    '-- LOS TXT --'
    '*************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'MsgBox("Se presiono enter")
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                listar(" Where nombreProceso Like '" & txtBuscar.Text & "%' Or nombreProceso Like '" & txtBuscar.Text & "%' " & "order by nombreProceso")
            Else
                'MsgBox("Paso por el numerico")
                '-- buscar por idLaboratorio
                listar(" Where idTipoProceso Like '" & txtBuscar.Text & "%' Or idTipoProceso Like '" & txtBuscar.Text & "%' " & "order by idTipoProceso")
            End If
            lvBuscar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If txtIdMoneda.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtIdMoneda.Text) = 0 Then
                    MessageBox.Show("Debe ingresar algún ítem..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                '-- verificar desde que ventana fue llamado
                verificarModulo()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtIdMoneda.Text = CInt(item.SubItems(0).Text)
            intIdTipoProceso = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarTipoProceso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_configEmail = True Then
            banGl_configEmail = False
            e.Cancel = False
            frmConfigEmail.Enabled = True
            frmConfigEmail.Show()
            frmConfigEmail.BringToFront()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
End Class