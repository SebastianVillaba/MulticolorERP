Public Class frmBuscarForma
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

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
        listar("")
        'valorde del combo
    End Sub

    Private Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvMoneda, "Select idForma,ltrim(nombreForma) as Nombre from cabForma  " & where)
        ' txtSql.Text = "Select idMoneda,ltrim(nombreMoneda) as Nombre, abreviatura from moneda  " & where
    End Sub

    Private Sub mercaderiaFraccionada(ByVal v_idForma As Integer)
        frmFraccionarMercaderia.lblidForma.Text = v_idForma
        frmFraccionarMercaderia.lblForma.Text = sp_datosTabla.consulta_valorString("select nombreForma from cabForma where idForma=" & v_idForma)
        frmFraccionarMercaderia.habilitarObjetos()
        Me.Close()

    End Sub

    Private Sub verificarModulo()
        If banGl_fraccionarMercaderia = True Then
            mercaderiaFraccionada(txtId.Text)
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
                'MsgBox("PAso por el alfanumerico")
                '-- buscar por nombre
                listar(" Where nombreForma Like '" & txtBuscar.Text & "%' Or nombreForma Like '" & txtBuscar.Text & "%' " & "order by nombreForma")
            Else
                'MsgBox("Paso por el numerico")
                '-- buscar por idForma
                listar(" Where idForma=" & txtBuscar.Text)
            End If
            lvMoneda.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvMoneda.KeyPress
        If txtId.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtId.Text) = 0 Then
                    MessageBox.Show("Debe ingresar alguna forma..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

    Private Sub lvMoneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMoneda.SelectedIndexChanged
        For Each item As ListViewItem In lvMoneda.SelectedItems
            txtId.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarForma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_fraccionarMercaderia = True Then
            banGl_fraccionarMercaderia = False
            e.Cancel = False
            frmFraccionarMercaderia.Enabled = True
            frmFraccionarMercaderia.Show()
            frmFraccionarMercaderia.BringToFront()
            frmFraccionarMercaderia.btnAgregar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
End Class