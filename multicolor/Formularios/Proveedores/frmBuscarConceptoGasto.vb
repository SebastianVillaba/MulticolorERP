Public Class frmBuscarConceptoGasto
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim strConcepto As String
    Dim intIdImpuesto As Integer
    Dim douPorcentajeImpuesto As Double
    Dim douFactorImpuesto As Double
    Dim douCosto As Double

    Sub New()
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarConcepto(ByVal v_idGasto As Integer)
        systemClass.SqlToLv_consultaDetalleConceptoGasto(lvConcepto, "select idImpuesto,porcentajeImpuesto,factorImpuesto,concepto,costo " & _
        " from detGasto where idGasto=" & v_idGasto)
        'txtSql.Text = "select idImpuesto,porcentajeImpuesto,factorImpuesto,concepto,costo," & _
        '" from detGasto where idGasto=" & v_idGasto

    End Sub
    '--------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvCompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvConcepto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            '-- solo si se pocisiona sobre un registro
            If txtConcepto.Text.Length = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            '-- procedimiento para cargar la tabla temporal
            If (fun_guardarSp("sp_agregarDetNotaCreditoGastoTmp", intGl_idConfigPc & "," & "'" & strConcepto & "'" & "," & intIdImpuesto & "," & douPorcentajeImpuesto & "," & douFactorImpuesto & "," & douCosto, Me.Name)) = 0 Then
                MessageBox.Show("No se pudo cargar el detalle de la nota de crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                frmNotaCreditoGasto.listarDetalle()
                Me.Close()
            End If


        End If
    End Sub

    Private Sub lvConcepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConcepto.SelectedIndexChanged
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvConcepto.SelectedItems
            intIdImpuesto = item.SubItems(0).Text
            douPorcentajeImpuesto = item.SubItems(1).Text
            douFactorImpuesto = item.SubItems(2).Text
            strConcepto = item.SubItems(3).Text
            douCosto = item.SubItems(4).Text
            txtConcepto.Text = strConcepto
        Next
    End Sub

    Private Sub lvConcepto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConcepto.GotFocus
        '-- mostrar el idCompra de la consulta de la compra
        For Each item As ListViewItem In lvConcepto.SelectedItems
            intIdImpuesto = item.SubItems(0).Text
            douPorcentajeImpuesto = item.SubItems(1).Text
            douFactorImpuesto = item.SubItems(2).Text
            strConcepto = item.SubItems(3).Text
            douCosto = item.SubItems(4).Text
            txtConcepto.Text = strConcepto
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarConceptoGasto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False

        frmNotaCreditoGasto.Enabled = True
        frmNotaCreditoGasto.Show()
        frmNotaCreditoGasto.BringToFront()

    End Sub
    '--------------------------------------------------------------------------------------------------
End Class