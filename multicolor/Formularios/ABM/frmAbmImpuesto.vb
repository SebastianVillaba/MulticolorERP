Public Class frmAbmImpuesto
    Private sp_impuesto As New sp_impuesto
    Private sp_obtenerDatosUsuario As New sp_obtenerDatosUsuario
    Private impuesto As impuesto
    Dim intIdusuarioAlta As Integer
    Dim intIdcargo As Integer
    Dim blNuevo As Boolean
    Dim systemClass As New SystemClass
    Dim strDatosOriginales As String
    Sub New()
        'el formato para el text box de porcentajes decimales
        'txtPorcentajeImpuesto.Text = Format("00.00")
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub inicializar()
        'formato de los decimales para los cuadros de texto
        listar("")
    End Sub
    Sub deshabilitarObjetos() 'colocar como está originalmente
        txtIdImpuesto.Enabled = False
        txtIdImpuesto.BackColor = Color.LightSkyBlue
        txtNombreImpuesto.Enabled = False
        txtNombreImpuesto.BackColor = Color.LightSkyBlue
        txtPorcentajeImpuesto.Enabled = False
        txtPorcentajeImpuesto.BackColor = Color.LightSkyBlue
        txtFactor.Enabled = False
        txtFactor.BackColor = Color.LightSkyBlue
        chkActivo.Enabled = False

        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnModificar.Enabled = True
        btnNuevo.Enabled = True

        '-- la seccion de busqueda
        grBuscar.Enabled = True
        'txtBuscar.Enabled = True
        txtBuscar.BackColor = Color.White
        'grOrdenar.Enabled = True

        'lvCargo.Enabled = True

    End Sub
    Sub habilitarObjetos() 'colocar como para agregar datos
        txtNombreImpuesto.Enabled = True
        txtNombreImpuesto.BackColor = Color.White
        txtFactor.Enabled = True
        txtFactor.BackColor = Color.White
        txtPorcentajeImpuesto.Enabled = True
        txtPorcentajeImpuesto.BackColor = Color.White
        chkActivo.Enabled = True

        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        btnNuevo.Enabled = False

        '-- la seccion de busqueda
        txtBuscar.BackColor = Color.LightSkyBlue
        grBuscar.Enabled = False
    End Sub
    'listar
    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvImpuesto, "Select i.idImpuesto, i.nombreImpuesto,i.porcentajeImpuesto,i.factorImpuesto,i.activo,i.fechaAlta,i.fechaMod,rtrim(_vu.nombre)+','+rtrim(_vu.apellido),rtrim(_vu2.nombre)+','+rtrim(_vu2.apellido) from impuesto i inner join v_usuario _vu on i.idUsuarioAlta=_vu.idUsuario  inner join v_usuario _vu2 on _vu2.idUsuario=i.idUsuarioMod" & where)
        'formato
        Dim I As Integer = 0
        For I = 8 To lvImpuesto.Columns.Count - 1
            lvImpuesto.Columns(I).Width = 0
        Next
        ' dimensionar las columnas
        lvImpuesto.Columns(0).Width = 80
        lvImpuesto.Columns(1).Width = 250
        lvImpuesto.Columns(0).Text = "ID Impuesto"
        lvImpuesto.Columns(1).Text = "Nombre del Impuesto"
        'no mostrar ciertas columnas
        lvImpuesto.Columns(2).Width = 0
        lvImpuesto.Columns(3).Width = 0
        lvImpuesto.Columns(4).Width = 0
        lvImpuesto.Columns(5).Width = 0
        lvImpuesto.Columns(6).Width = 0
        lvImpuesto.Columns(7).Width = 0
        lvImpuesto.Columns(8).Width = 0
        'lvImpuesto.Columns(9).Width = 0
        'lvCargo.ListViewItemSorter = lvCargo.Columns(1)
    End Sub
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If rdIdImpuesto.Checked = True Then
                ' ordenar por idcargo
                listar(" Where i.idImpuesto Like '" & txtBuscar.Text & "%' Or i.idImpuesto Like '" & txtBuscar.Text & "%' " & "order by i.idImpuesto")
            End If
            If rdNombreImpuesto.Checked = True Then
                ' ordenar por nombre de cargo
                listar(" Where i.nombreImpuesto Like '" & txtBuscar.Text & "%' Or i.nombreImpuesto Like '" & txtBuscar.Text & "%' " & "order by i.nombreImpuesto")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvCargo.Select()
            'lvCargo.Focus()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If rdIdImpuesto.Checked = True Then
            ' ordenar por idcargo
            listar(" Where i.idImpuesto Like '" & txtBuscar.Text & "%' Or i.idImpuesto Like '" & txtBuscar.Text & "%' " & "order by i.idImpuesto")
        End If
        If rdNombreImpuesto.Checked = True Then
            ' ordenar por nombre de cargo
            listar(" Where i.nombreImpuesto Like '" & txtBuscar.Text & "%' Or i.nombreImpuesto Like '" & txtBuscar.Text & "%' " & " order by i.nombreImpuesto")
        End If
    End Sub
    Private Sub lvImpuesto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvImpuesto.SelectedIndexChanged
        'For Each item As listviewite
        For Each item As ListViewItem In lvImpuesto.SelectedItems
            txtIdImpuesto.Text = item.SubItems(0).Text
            txtNombreImpuesto.Text = item.SubItems(1).Text
            txtPorcentajeImpuesto.Text = item.SubItems(2).Text
            txtFactor.Text = item.SubItems(3).Text
            chkActivo.Checked = item.SubItems(4).Text
            txtFechaAlta.Text = item.SubItems(5).Text
            txtFechaMod.Text = item.SubItems(6).Text
            txtUsuarioAlta.Text = item.SubItems(7).Text
            txtUsuarioMod.Text = item.SubItems(8).Text
        Next
        ' txtUsuarioAlta.Text = sp_obtenerDatosUsuario.nombreUsuario(intIdusuarioAlta)
        'strNombreUsuario = sp_obtenerDatosUsuario.nombreUsuario(4)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        blNuevo = True
        habilitarObjetos()
        txtIdImpuesto.Text = 0
        chkActivo.Checked = True
        txtFactor.Text = 0
        txtPorcentajeImpuesto.Text = 0
        txtNombreImpuesto.Text = ""
        txtNombreImpuesto.Focus()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Dim intPorcentajeImpuesto As Int16
        'Dim intFactor As Int16
        ' valor asignado al porcentaje
        'If Not IsNumeric(maskPorcentaje.Text.Substring(0, 1)) Then
        ' intPorcentajeImpuesto = 0
        ' Else
        ' intPorcentajeImpuesto = maskPorcentaje.Text
        ' End If
        ' valor asignado al factor
        'If Not IsNumeric(maskFactor.Text.Substring(0, 1)) Then
        ' intFactor = 0
        'Else
        'intFactor = maskFactor.Text
        'End If
        'controlar si existe algun error
        If txtNombreImpuesto.Text = "" Then
            MessageBox.Show("Debe ingresar algún Nombre para el Impuesto..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If blNuevo = True Then
            ' si es nuevo
            sp_impuesto.insImpuesto(txtNombreImpuesto.Text.Trim, txtPorcentajeImpuesto.Text, txtFactor.Text, intGl_idUsuario)
        Else
            'si es una modificacion
            sp_impuesto.UpdImpuesto(Convert.ToInt32(txtIdImpuesto.Text), txtNombreImpuesto.Text.Trim, txtPorcentajeImpuesto.Text, txtFactor.Text, chkActivo.Checked, strDatosOriginales)
        End If
        deshabilitarObjetos()
        inicializar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        deshabilitarObjetos()
        txtIdImpuesto.Text = 0
        txtNombreImpuesto.Text = ""
        txtFechaAlta.Text = ""
        txtFechaMod.Text = ""
        txtUsuarioAlta.Text = ""
        txtUsuarioMod.Text = ""
        txtFactor.Text = ""
        txtPorcentajeImpuesto.Text = ""
        lvImpuesto.Focus()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If txtNombreImpuesto.Text = "" Then
            MessageBox.Show("Se debe mostrar el dato a modificar..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        ' cargar en la variable los datos originales
        strDatosOriginales = Trim(txtNombreImpuesto.Text) & "," & txtPorcentajeImpuesto.Text & "," & txtFactor.Text & "," & Trim(chkActivo.Checked.ToString) & "," & Trim(intGl_idUsuario.ToString)
        blNuevo = False
        habilitarObjetos()
        txtNombreImpuesto.Focus()
    End Sub

    Private Sub txtPorcentajeImpuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentajeImpuesto.KeyPress
        e.Handled = txtNumerico(txtPorcentajeImpuesto, e.KeyChar, True)
    End Sub

    Private Sub txtFactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactor.KeyPress
        e.Handled = txtNumerico(txtFactor, e.KeyChar, True)
    End Sub


    Private Sub frmAbmImpuesto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        e.Cancel = False
    End Sub
End Class