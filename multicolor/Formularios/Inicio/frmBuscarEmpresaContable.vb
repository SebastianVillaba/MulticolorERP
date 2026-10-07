Public Class frmBuscarEmpresaContable
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '************************'
    '-- LOS PROCEDIMIENTOS --'
    '************************'
    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub inicializar()
        '- colocar las columnas que seran visibles
        listar_empresaContable()
    End Sub
    Sub listar_empresaContable()
        '-- la variable de idEmpresaContable y la empresa que está configurado en la pc por defecto
        txtIdPersonaJur.Text = sp_datosTabla.un_dato_integer("idPersonaJur", "configPc", "idConfig", intGl_idConfigPc)
        txtEmpresaContable.Text = sp_datosTabla.un_datoString("nombreFantasia", "v_empresaContable", "idPersonaJur", CInt(txtIdPersonaJur.Text))
        '-- colocar el ID de la Empresa contable que se coloca por defecto
        intGl_idPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configPc", "idConfig", intGl_idConfigPc)
        strGl_empresaContable = sp_datosTabla.un_datoString("nombreFantasia", "v_empresaContable", "idPersonaJur", CInt(txtIdPersonaJur.Text))
        ' MsgBox("nombre de la empresa contable  " & strGl_empresaContable)
        systemClass.SqlToLv(lvEmpresaContable, "select idPersonaJur as ID,nombreFantasia as Nombre from v_empresaContable")
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarEmpresaContable_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvEmpresaContable_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvEmpresaContable.SelectedIndexChanged
        For Each item As ListViewItem In lvEmpresaContable.SelectedItems
            txtIdPersonaJur.Text = item.SubItems(0).Text
            txtEmpresaContable.Text = item.SubItems(1).Text
            '-- valor a las variables publicas
            intGl_idPersonaJur = item.SubItems(0).Text
            strGl_empresaContable = item.SubItems(1).Text
        Next
    End Sub

    Private Sub lvEmpresaContable_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvEmpresaContable.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If sp_datosTabla.consulta_valorBoolean("select desarrollador from usuario where idusuario=" & intGl_idUsuario) Then
                'MsgBox("Valor de idPersonaJur  " & intGl_idPersonaJur)
                'MsgBox("Valor de nombre de Empresa contable  " & strGl_empresaContable)
                Me.Visible = False
                frmBuscarBD.BringToFront()
                frmBuscarBD.WindowState = FormWindowState.Normal
                frmBuscarBD.Show()
            Else
                Me.Visible = False
                'MsgBox("Entro al procedimiento")
                parametrosIngreso()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
End Class