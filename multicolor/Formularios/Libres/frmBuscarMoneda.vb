Public Class frmBuscarMoneda
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
        systemClass.SqlToLv(lvMoneda, "Select idMoneda,ltrim(nombreMoneda) as Nombre, abreviatura from moneda  " & where)
        ' txtSql.Text = "Select idMoneda,ltrim(nombreMoneda) as Nombre, abreviatura from moneda  " & where
    End Sub

    Private Sub tablaCotizacion(ByVal v_idMoneda As Integer)
        '-- controlar si ya existe el item seleccionado
        For i As Integer = 0 To frmTablaCotizacion.dtgCotiza.Rows.Count - 1
            If frmTablaCotizacion.dtgCotiza.Rows(i).Cells(0).Value > 0 Then
                If frmTablaCotizacion.dtgCotiza.Rows(i).Cells(1).Value = v_idMoneda Then
                    MessageBox.Show("Esta moneda ya está cargada en la Tabla de Cotización..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        Next
        '-- ver si la moneda seleccionada coincide con la moneda de la configuracion
        If v_idMoneda = sp_datosTabla.un_dato_integer("idMoneda", "configEmpresa", "idEntidad", intGl_idEntidad) Then
            MessageBox.Show("Esta moneda es la que está como configurada com preDeterminada..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        intGl_nroTablaCotizacion = 0
        For i As Integer = 0 To frmTablaCotizacion.dtgCotiza.Rows.Count - 1
            '-- si existen item cargados
            If frmTablaCotizacion.dtgCotiza.Rows(i).Cells(0).Value > 0 Then
                '-- incrementar la variable de nro publica
                intGl_nroTablaCotizacion = intGl_nroTablaCotizacion + 1
                'MsgBox("Valor de la variable publica  " & intGl_nroTablaCotizacion)
            End If
        Next
        '-- incrementar de vuelta la variable global
        intGl_nroTablaCotizacion = intGl_nroTablaCotizacion + 1
        'MsgBox("Valor de la variable publica  " & intGl_nroTablaCotizacion)
        '-- cargar la grilla
        Dim strTmpMoneda As String
        strTmpMoneda = sp_datosTabla.un_datoString("nombreMoneda", "moneda", "idMoneda", v_idMoneda)
        cargarTablaCotizacion(intGl_nroTablaCotizacion, v_idMoneda, strTmpMoneda, 0, 0)
        '-- procedimiento para cargar la tabla temporal
        sp_datosTabla.sp_string("sp_agregarDetCotizaTmp", intGl_idConfigPc & "," & intGl_idSucursal & "," & 0 & "," & v_idMoneda)
        '-- para el formulario de tabla de cotizacion
        banGl_tablaCotizacion = False
        Me.Close()
        frmTablaCotizacion.Enabled = True
        frmTablaCotizacion.Show()
        frmTablaCotizacion.BringToFront()
        frmTablaCotizacion.dtgCotiza.Focus()
    End Sub

    Private Sub verificarModulo()
        If banGl_tablaCotizacion = True Then
            tablaCotizacion(txtIdMoneda.Text)
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
                listar(" Where nombreMoneda Like '" & txtBuscar.Text & "%' Or nombreMoneda Like '" & txtBuscar.Text & "%' " & "order by nombreMoneda")
            Else
                'MsgBox("Paso por el numerico")
                '-- buscar por idLaboratorio
                listar(" Where idMoneda Like '" & txtBuscar.Text & "%' Or idMoneda Like '" & txtBuscar.Text & "%' " & "order by idMoneda")
            End If
            lvMoneda.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvMoneda.KeyPress
        If txtIdMoneda.Text <> "" Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                '-- solo si se ingresó algun nro de id
                If CInt(txtIdMoneda.Text) = 0 Then
                    MessageBox.Show("Debe ingresar alguna Moneda..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            txtIdMoneda.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarLaboratorio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If banGl_tablaCotizacion = True Then
            banGl_tablaCotizacion = False
            e.Cancel = False
            frmTablaCotizacion.Enabled = True
            frmTablaCotizacion.Show()
            frmTablaCotizacion.BringToFront()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------

End Class