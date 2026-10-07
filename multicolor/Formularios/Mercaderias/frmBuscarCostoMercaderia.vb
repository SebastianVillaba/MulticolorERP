Public Class frmBuscarCostoMercaderia
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listar(ByVal where As String)
        '-- ajuste positivo de mercaderia
        systemClass.SqlToLv(lvBuscar, "select s.idStock,p.codigo,rtrim(p.nombreProducto)+','+ltrim(p.presentacion) as Mercaderia," & _
                                        " l.lote,l.vencimiento,s.costo " & _
                                        " from stock s inner join producto p on s.idProducto=p.idProducto " & _
                                        " inner join lote l on l.idlote=s.idlote " & where)
    End Sub

    Private Sub controlarModulo()
        modificarCosto()
    End Sub

    Private Sub modificarCosto()
        '-- inicializar las variables
        Dim intTmpIdStock As Integer
        Dim intTmpIdProducto As Integer
        Dim intTmpIdLote As Integer
        Dim strTmpCodigo As String
        Dim strTmpMercaderia As String
        Dim strTmpLote As String
        Dim strTmpVence As String
        Dim douTmpPrecio As Double
        Dim douTmpCosto As Double

        '-- dar valor a las variables
        intTmpIdStock = CInt(txtIdMov.Text)
        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from stock where idStock=" & intTmpIdStock)
        intTmpIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idStock=" & intTmpIdStock)
        strTmpCodigo = sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & intTmpIdProducto)
        strTmpMercaderia = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & intTmpIdProducto)
        strTmpLote = sp_datosTabla.consulta_valorString("select lote from lote where idLote=" & intTmpIdLote)
        strTmpVence = sp_datosTabla.consulta_valorString("select vencimiento from lote where idLote=" & intTmpIdLote)
        douTmpPrecio = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & intTmpIdProducto)
        douTmpCosto = sp_datosTabla.consulta_valorDouble("select costo from stock where idStock=" & intTmpIdStock)
        '-- si ya está cargado el mismo producto
        For i As Integer = 0 To frmModificarCosto.dtgCosto.Rows.Count - 1
            If frmModificarCosto.dtgCosto.Rows(i).Cells(0).Value > 0 Then
                If CInt(txtIdMov.Text) = CInt(frmModificarCosto.dtgCosto.Rows(i).Cells(1).Value) Then
                    MessageBox.Show("Esta mercadería ya está cargada..!. Elimine lo cargado y vuelva a intentarlo", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        Next
        '-- sumar la variable global
        intGl_nroModificaCosto = intGl_nroModificaCosto + 1
        '------------------------
        cargarModificacionCosto(intGl_nroModificaCosto, intTmpIdStock, strTmpCodigo, strTmpMercaderia, strTmpLote, strTmpVence, douTmpPrecio, douTmpCosto)

        Me.Close()
        '-- foco en la columna de costo actual
        frmModificarCosto.dtgCosto.CurrentCell = frmModificarCosto.dtgCosto.Rows(intGl_nroModificaCosto - 1).Cells(8)
        frmModificarCosto.dtgCosto.Focus()

    End Sub
    '------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre de la mercaderia
                listar(" Where p.nombreProducto Like '" & txtBuscar.Text & "%' Or p.nombreProducto Like '" & txtBuscar.Text & "%' " & " order by p.nombreProducto")
            Else
                '-- buscar por idStock
                listar(" Where p.codigo='" & txtBuscar.Text & "'")
            End If
            lvBuscar.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If IsNumeric(txtIdMov.Text) Then
            If txtIdMov.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    controlarModulo()
                End If
            Else
                MessageBox.Show("Debe ingresar algun Ajuste..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtIdMov.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmBuscarCostoMercaderia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmModificarCosto.Enabled = True
        frmModificarCosto.Show()
        frmModificarCosto.BringToFront()

    End Sub

End Class