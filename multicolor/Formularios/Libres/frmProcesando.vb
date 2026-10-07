Public Class frmProcesando
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '-- controlar los modulos
    Private Sub controlarModulos()
        If banGl_procesandoPedidoProveedor = True Then
            MsgBox("Procesando")
            '  procesandoPedidoProveedor(intGl_procesandoIdDepositoPedidoProveedor, bolGl_procesandoAgruparSucursalPedidoProveedor, strGl_procesandoFechaDesdePedidoProveedor, strGl_procesandoFechaHastaPedidoProveedor)
            MsgBox("Fin del procesamiento")
        End If
    End Sub

    Private Sub frmProcesando_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        controlarModulos()
    End Sub
End Class