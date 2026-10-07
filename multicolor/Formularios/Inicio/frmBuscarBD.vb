Public Class frmBuscarBD
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
        listar_BD()
    End Sub

    Sub listar_BD()
        '-- por defecto la primera base de datos
        txtIdBd.Text = sp_datosTabla.un_dato_integer("idBaseDatos", "baseDatos", "idBaseDatos", 1)
        txtNombreBaseDatos.Text = sp_datosTabla.un_datoString("nombreBaseDatos", "baseDatos", "idBaseDatos", 1)
        '-- colocar el ID de la Empresa contable que se coloca por defecto
        strGl_nombreBaseDatos = sp_datosTabla.un_datoString("nombreBaseDatos", "baseDatos", "idBaseDatos", 1)

        systemClass.SqlToLv(lvBD, "select idBaseDatos,nombreBaseDatos as Nombre from baseDatos")
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarEmpresaContable_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs)
        End
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBD_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvBD.SelectedIndexChanged
        For Each item As ListViewItem In lvBD.SelectedItems
            txtIdBd.Text = item.SubItems(0).Text
            txtNombreBaseDatos.Text = item.SubItems(1).Text
            '-- valor a las variables publicas
            strGl_nombreBaseDatos = item.SubItems(1).Text
        Next
    End Sub

    Private Sub lvEmpresaContable_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvBD.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- la conexion
            hayarConexion()
            '-- datos de la empresa contable
            'intGl_idPersonaJur = sp_datosTabla.un_dato_integer("idPersonaJur", "configPc", "idConfig", intGl_idConfigPc)
            'strGl_empresaContable = sp_datosTabla.un_datoString("nombreFantasia", "v_empresaContable", "idPersonaJur", intGl_idPersonaJur)
            Me.Visible = False
            'MsgBox("Paso 11")
            parametrosIngreso()
            'MsgBox("Paso 21")
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------------
End Class