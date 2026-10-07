Public Class frmConsultaStock
    '******************************'
    '-- VARIABLES DE TIPO OBJETO --'
    '******************************'
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '------------------------'
    '-- LOS PROCEDIMIENTOS --'
    '------------------------'
    Private Sub inicializar()
        lvStock.Columns(0).Width = 0
        lblDivision.Text = ""
        lblLaboratorio.Text = ""
    End Sub

    Public Sub listar_busqueda(ByVal where As String)
        If banGl_ventaHeladeria = True Then
            '-- solo para la heladeria
            'MsgBox("Paso 1")
            systemClass.SqlToLv_producto_busqueda(lvStock, "select * from v_stock" & intGl_idSucursal & " where idFamilia<>1 and " & where)
            '  txtSql.Text = "select * from v_stock" & intGl_idSucursal & " where idFamilia<>1 and " & where
        Else
            'MsgBox("Paso 2")
            systemClass.SqlToLv_consultaStockMercaderia(lvStock, "select idProducto,codigo,mercaderia,presentacion,precio,stock,fueraLinea,controlado from v_stock" & intGl_idSucursal & where)
            txtSql.Text = "select idProducto,codigo,mercaderia,presentacion,precio,stock from v_stock" & intGl_idSucursal & where
        End If

    End Sub

    Private Sub listar_stockSucursales(ByVal v_idProducto As Integer)
        systemClass.SqlToLv_stockSucursales(lvStockSucursal, "sp_stockSucursales", intGl_idSucursal & "," & v_idProducto)
    End Sub

    Private Sub listar_busqueda_deposito(ByVal v_idproducto As Integer)
        systemClass.SqlToLv_producto_busqueda_deposito(lvStockDeposito, "sp_stockDeposito", intGl_idSucursal & "," & v_idproducto)
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------
    '------------------'
    '-- LOS LISTVIEW --'
    '------------------'
    Private Sub lvStock_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStock.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvStock.SelectedItems
            txtIdProducto.Text = item.SubItems(0).Text
            '-- listar el stock de las sucursales
            listar_stockSucursales(CInt(txtIdProducto.Text))
            '-- listar el stock de los depositos
            listar_busqueda_deposito(CInt(txtIdProducto.Text))
            '-- la imagen de la mercaderia
            'picImagen.ImageLocation = strGl_rutaImagen & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", CInt(txtIdProducto.Text))
            'picImagen.ImageLocation = "c:\temp\" & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", CInt(txtIdProducto.Text))
            'picImagen.Image = "c:\temp\" & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", CInt(txtIdProducto.Text))
            ' MsgBox("Ruta de imagen  " & "c:\temp\" & sp_datosTabla.un_datoString("fotoProducto", "producto", "idProducto", CInt(txtIdProducto.Text)))
            'picImagen.Image = sp_datosTabla.consulta_valorImagen("select imagen from producto where idProducto=" & CInt(txtIdProducto.Text))
            picImagen.ImageLocation = strGl_rutaImagen + Trim(sp_datosTabla.consulta_valorString("select codigo from producto where idProducto=" & CInt(txtIdProducto.Text))) + ".jpg"

            '-- el laboratorio
            Dim intTmpIdLaboratorio As Integer
            intTmpIdLaboratorio = sp_datosTabla.consulta_valor("select idLaboratorio from producto where idProducto=" & CInt(txtIdProducto.Text))
            lblLaboratorio.Text = sp_datosTabla.consulta_valorString("select nombre from v_laboratorio where idLaboratorio=" & intTmpIdLaboratorio)
            '-- la division
            Dim intTmpIdDivision As Integer
            intTmpIdDivision = sp_datosTabla.consulta_valor("select idDivision from producto where idProducto=" & CInt(txtIdProducto.Text))
            lblDivision.Text = sp_datosTabla.consulta_valorString("select nombre from v_division where idDivision=" & intTmpIdDivision)
            '-- el origen
            lblOrigen.Text = sp_datosTabla.consulta_valorString("select origen from producto where idProducto=" & CInt(txtIdProducto.Text))

            Me.Refresh()
        Next
    End Sub

    Private Sub lvStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvStock.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            If IsNumeric(txtBuscar.Text) Then
                txtBuscar.Text = ""
            End If
            txtBuscar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------
    '-------------'
    '-- LOS TXT --'
    '-------------'
    Private Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        txtIdProducto.Text = 0
        lblDivision.Text = ""
        lblLaboratorio.Text = ""
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                'MsgBox("Valor de la banGl_ventaHeladeria  " & banGl_ventaHeladeria)
                '- si se ingreso en blanco, volver a cargar el listview y ordenar por nombre
                If txtBuscar.Text.Length > 0 Then
                    If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                        '-- ccodigo interno
                        If (Trim(txtBuscar.Text).Length) = 6 Then
                            listar_busqueda(" Where codigo Like '" & txtBuscar.Text & "%' Or codigo Like '" & txtBuscar.Text & "%' " & "order by codigo")
                        Else
                            '-- codigo de barra
                            Dim intTmpIdProducto As Integer
                            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where codigoBarra='" & Trim(txtBuscar.Text) & "'")
                            If intTmpIdProducto > 0 Then
                                listar_busqueda(" Where codigoBarra Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%' " & "order by codigoBarra")
                            Else
                                '-- codigo de barra interno solo si tiene un 1 como primer digito
                                If txtBuscar.Text.Substring(0, 1) = 1 Then
                                    If Len(Trim(txtBuscar.Text)) = 12 Then
                                        '-- para los de 12 digitos
                                        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where idProducto=" & txtBuscar.Text.Substring(6, 5))
                                    End If
                                    If Len(Trim(txtBuscar.Text)) = 13 Then
                                        '-- para los de 13 digitos
                                        intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where idProducto=" & txtBuscar.Text.Substring(7, 5))
                                    End If
                                    listar_busqueda(" where idProducto=" & intTmpIdProducto)
                                End If
                            End If

                        End If
                    Else
                        ' ordenar por nombre del producto
                        listar_busqueda(" Where mercaderia Like '" & txtBuscar.Text & "%' Or mercaderia Like '" & txtBuscar.Text & "%' " & " order by 3")
                        'listar(" Where mercaderia Like '" & txtBuscar.Text & "%' Or mercaderia Like '" & txtBuscar.Text & "%' " & " order by 3")
                    End If
                End If
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
            'lvStock.Select()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------
    '----------------'
    '-- FORMULARIO --'
    '----------------'  
    Private Sub frmConsultaStock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.mercaderiaConsultasStock.Enabled = True
        e.Cancel = False
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------
End Class