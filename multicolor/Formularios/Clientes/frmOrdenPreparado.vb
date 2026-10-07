Public Class frmOrdenPreparado
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdOrden As Integer = 0
    Dim intTipo As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "select idOrden,nombre,tipo,fechaAlta,total,cantidad,tipoOrden" & _
                            " from v_ordenPreparado " & where)
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If IsNumeric(txtIdMov.Text) Then
            If txtIdMov.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    '-- cargar orden de preparado
                    If (fun_guardarSp("sp_agregarDetVentaTmpOrden", intGl_idUsuario & "," & intGl_idConfigPc & "," & _
                    intIdOrden & "," & intTipo, "frmVenta")) = 0 Then
                        '-- no se guardo los registros
                        MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        frmVentaFarmacia1.actualizarDetVenta()
                        frmVentaFarmacia1.sumarTotales()
                        Me.Close()
                    End If

                End If
            Else
                MessageBox.Show("Debe ingresar algun Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtIdMov.Text = CInt(item.SubItems(0).Text)
            intIdOrden = CInt(item.SubItems(0).Text)
            intTipo = CInt(item.SubItems(6).Text)
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmOrdenPreparado_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmVentaFarmacia1.Enabled = True
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
        frmVentaFarmacia1.txtBuscar.Focus()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
End Class