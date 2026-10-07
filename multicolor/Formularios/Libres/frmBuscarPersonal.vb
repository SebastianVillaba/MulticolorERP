Public Class frmBuscarPersonalEmpresa
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdPersonal As Integer
    Dim strNombrePersonal As String

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- cargar el combo de la cuenta corriente
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLvPersonalCompleto(lvPersonal, "Select idPersonal,nombre,apellido,nombreCargo,activo from v_personalT " & where)
        'txtSql.Text = "Select _vp.idPersonal,_vp.nombre,_vp.apellido,c.nombreCargo from v_personal _vp inner join cargo c on _vp.idCargo=c.idCargo " & where
        ' dimensionar las columnas
        lvPersonal.Columns(0).Width = 80
        lvPersonal.Columns(1).Width = 150
        lvPersonal.Columns(2).Width = 150
        lvPersonal.Columns(3).Width = 90
        lvPersonal.Columns(3).Width = 45
        lvPersonal.Columns(0).Text = "ID Personal"
        lvPersonal.Columns(1).Text = "Nombre"
        lvPersonal.Columns(2).Text = "Apellido"
        lvPersonal.Columns(3).Text = "Cargo"
        lvPersonal.Columns(4).Text = "activo"
        lvPersonal.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        ' MsgBox("Valor de bandera de modulo  " & banGl_depositoBanco)
        '-- controlar los modulos que son abiertos
        If banGl_depositoBanco = True Then
            '-- deposito bancario
            depositoBancario()
        End If
        If banGl_reporteHorarioPersonal = True Then
            '-- reporte de horario del personal
            reporteHorarioPersonal()
        End If
    End Sub

    Private Sub depositoBancario()
        '-- colocar los datos del proveedor
        frmCargarDepositoBanco.txtPersonal.Text = strNombrePersonal
        frmCargarDepositoBanco.txtIdPersonal.Text = intIdPersonal

        Me.Close()
        banGl_depositoBanco = False

        frmCargarDepositoBanco.Enabled = True
        frmCargarDepositoBanco.Show()
        frmCargarDepositoBanco.BringToFront()
        frmCargarDepositoBanco.txtNroDoc.Focus()
    End Sub

    Private Sub reporteHorarioPersonal()
        '-- colocar los datos del personal
        frmReporteHorario.lblPersonal.Text = strNombrePersonal
        frmReporteHorario.lblIdPersonal.Text = sp_datosTabla.consulta_valor("select idUsuario from v_usuarioT where idPersonal=" & intIdPersonal)

        Me.Close()
        banGl_reporteHorarioPersonal = False

        frmReporteHorario.Enabled = True
        frmReporteHorario.Show()
        frmReporteHorario.BringToFront()
        frmReporteHorario.btnConsultar.Focus()
    End Sub

    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idPersonal
                listar(" Where idPersonal=" & txtBuscar.Text)
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre del personal
                listar(" Where nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & " order by nombre")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvPersonal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPersonal.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdPersonal.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvPersonal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPersonal.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvPersonal.SelectedItems
            intIdPersonal = item.SubItems(0).Text
            txtIdPersonal.Text = item.SubItems(0).Text
            txtNombrePersonal.Text = Trim(item.SubItems(1).Text) & "," & Trim(item.SubItems(2).Text)
            strNombrePersonal = Trim(item.SubItems(1).Text) & "," & Trim(item.SubItems(2).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------
End Class