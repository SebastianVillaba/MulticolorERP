Public Class frmMasLoteReferencia
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim deposito As New deposito

    '-- variables para el ajuste del formulario
    Dim ancho As Integer
    Dim alto As Integer
    'Variable para la primera ejecución y que no utilice el resize 
    Dim primero As Boolean

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        deposito.comboDeposito(cboDeposito)
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalleProducto(ByVal v_idMov As Integer)
        systemClass.SqlToLv_detalleProductoReferenciaMasLote(lvProducto, "sp_consultaDetalleProductoReferenciaLoteMas", v_idMov & "," & cboDeposito.SelectedValue)
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        banGl_masLoteReferencia = True

        Me.Enabled = False
        frmStock.txtBuscar.Text = ""
        frmStock.txtIdProducto.Text = "0"
        frmStock.Visible = True
        frmStock.WindowState = FormWindowState.Normal
        frmStock.Show()
        frmStock.txtBuscar.Focus()
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        listarDetalleProducto(CInt(txtIdRef.Text))
    End Sub
    '-------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmMasLoteReferencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Inicializamos valor a las variables globales. 
        ancho = Me.Width
        alto = Me.Height
    End Sub

    Private Sub frmMasLoteReferencia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        'frmMenuPrincipal.clienteMasLoteReferencia.Enabled = True
        e.Cancel = False
    End Sub

    Private Sub frm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Por si ocurre algun error inesperado 
        On Error Resume Next
        'Variables para los porcentajes 
        Dim porcancho As Integer
        Dim porcalto As Integer
        ' Aquí evitamos lo innecesario de ajustar cuando la ventana se minimiza 
        If WindowState = FormWindowState.Minimized Then
            'Simplemente salimos del procedimiento. 
            Exit Sub
        End If
        'Si es la primera ejecución... 
        If primero = False Then
            'Damos valor verdadero a la variable para la próxima 
            primero = True
            'Salimos 
            Exit Sub
        End If
        'Obtenemos los porcentaje de ancho y alto 
        porcancho = FormatNumber((Me.Width * 100) / ancho, 2)
        porcalto = FormatNumber((Me.Height * 100) / alto, 2)
        'recorremos absolutamente todos los controles. 
        For Each CControl As Control In Me.Controls
            'Asignamos la nueva posición y dimensión. 
            CControl.Top = (CControl.Top * porcalto) / 100
            CControl.Left = (CControl.Left * porcancho) / 100
            CControl.Width = (CControl.Width * porcancho) / 100
            CControl.Height = (CControl.Height * porcalto) / 100
        Next

        'A las variables globales a nivel del formulario 
        'Le asignamos el actual valor. 
        ancho = Me.Width
        alto = Me.Height
    End Sub
    '-------------------------------------------------------------------------------------------------------------

End Class