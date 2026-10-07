Public Class frmStockBasico
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim intIdDeposito As Integer = 0
    Dim intIdLote As Integer = 0
    Dim intIdStock As Integer = 0

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '------------------------'
    '-- LOS PROCEDIMIENTOS --'
    '------------------------'
    Private Sub inicializar()
        lvStock.Columns(0).Width = 0
    End Sub

    Public Sub listar_busqueda(ByVal where As String)
        '-- ver si son vendedores de la heladeria
        Dim bolTmpVendedorHeladeria As Boolean = False
        systemClass.SqlToLv_producto_busqueda(lvStock, "select idProducto,codigo,mercaderia,presentacion,referencia,precio,nombreTipo,stock from v_stockBasico where " & where)

        txtSql.Text = "select idProducto,codigo,mercaderia,presentacion,referencia,precio,nombreTipo,stock from v_stockBasico where " & where

    End Sub

    '-- controlar los modulos
    Private Sub controlarModulo()
        If banGl_ordenCoral = True Then
            ordenCoral(txtIdProducto.Text)
        End If
        If banGl_ordenSuvinil = True Then
            ordenSuvinil(txtIdProducto.Text)
        End If
        If banGl_ordenAutomotive = True Then
            ordenAutomotive(txtIdProducto.Text)
        End If
    End Sub

    '-- orden de preparado coral
    Private Sub ordenCoral(ByVal v_idProducto As Integer)
        '-- datos del producto  
        If sp_datosTabla.sp_integer("sp_totalLoteStock", v_idProducto & "," & intGl_idSucursal) = 1 Then
            intIdDeposito = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
            intIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idProducto=" & v_idProducto & " and idDeposito=" & intIdDeposito & " and cantidad <> 0")
            intIdStock = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idProducto & " and idDeposito=" & intIdDeposito & " and idLote=" & intIdLote)
        End If
        frmOrdenPreparadoCoral.txtIdStock.Text = intIdStock
        frmOrdenPreparadoCoral.txtNombreBase.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmOrdenPreparadoCoral.txtTotalBase.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)
        frmOrdenPreparadoCoral.txtTotalBase.Text = Format(CDec(frmOrdenPreparadoCoral.txtTotalBase.Text), "##,###,##0")

        If intIdStock = 0 Then
            MessageBox.Show("Este básico no cuenta con stock...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Close()

    End Sub

    '-- orden de preparado suvinil
    Private Sub ordenSuvinil(ByVal v_idProducto As Integer)
        '-- datos del producto  
        If sp_datosTabla.sp_integer("sp_totalLoteStock", v_idProducto & "," & intGl_idSucursal) = 1 Then
            intIdDeposito = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
            intIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idProducto=" & v_idProducto & " and idDeposito=" & intIdDeposito & " and cantidad <> 0")
            intIdStock = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idProducto & " and idDeposito=" & intIdDeposito & " and idLote=" & intIdLote)
        End If
        frmOrdenPreparadoSuvinil.txtIdStock.Text = intIdStock
        frmOrdenPreparadoSuvinil.txtNombreBase.Text = sp_datosTabla.consulta_valorString("select rtrim(nombreProducto)+','+ltrim(presentacion) from producto where idProducto=" & v_idProducto)
        frmOrdenPreparadoSuvinil.txtTotalBase.Text = sp_datosTabla.consulta_valorDouble("select precio from producto where idProducto=" & v_idProducto)
        frmOrdenPreparadoSuvinil.txtTotalBase.Text = Format(CDec(frmOrdenPreparadoSuvinil.txtTotalBase.Text), "##,###,##0")

        If intIdStock = 0 Then
            MessageBox.Show("Este básico no cuenta con stock...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Close()

    End Sub

    '-- orden de preparado automotive
    Private Sub ordenAutomotive(ByVal v_idProducto As Integer)
        '-- datos del producto  
        If sp_datosTabla.sp_integer("sp_totalLoteStock", v_idProducto & "," & intGl_idSucursal) = 1 Then
            intIdDeposito = sp_datosTabla.un_dato_integer("idDepositoVenta", "configpc", "idConfig", intGl_idConfigPc)
            intIdLote = sp_datosTabla.consulta_valor("select idLote from stock where idProducto=" & v_idProducto & " and idDeposito=" & intIdDeposito)
            intIdStock = sp_datosTabla.consulta_valor("select idstock from stock where idProducto=" & v_idProducto & " and idDeposito=" & intIdDeposito & " and idLote=" & intIdLote)
        End If

        If intIdStock = 0 Then
            MessageBox.Show("Este colorante no cuenta con stock...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            '-- cargar en la tabla temporal
            frmOrdenPreparadoAutomotive.agregarDetalle(intIdStock)
            Me.Close()
        End If
    End Sub
    '----------------------------------------------------------------------------
    '------------------'
    '-- LOS LISTVIEW --'
    '------------------'
    Private Sub lvStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvStock.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            If IsNumeric(txtBuscar.Text) Then
                txtBuscar.Text = ""
            End If
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdProducto.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            controlarModulo()
        End If
    End Sub

    Private Sub lvStock_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStock.SelectedIndexChanged
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvStock.SelectedItems
            intGl_vtaIdProducto = item.SubItems(0).Text
            txtIdProducto.Text = item.SubItems(0).Text
        Next
    End Sub

    Private Sub lvStock_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvStock.GotFocus
        '-- mostrar el stock de las demas sucursales
        For Each item As ListViewItem In lvStock.SelectedItems
            intGl_vtaIdProducto = item.SubItems(0).Text
            txtIdProducto.Text = item.SubItems(0).Text
        Next
    End Sub
    '----------------------------------------------
    '----------------------------------------------
    '-------------'
    '-- LOS TXT --'
    '-------------'
    Private Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        txtIdProducto.Text = 0
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtBuscar.Text.Length > 0 Then
                '- si se ingreso en blanco, volver a cargar el listview y ordenar por nombre
                If txtBuscar.Text.Length > 0 Then
                    '-- controlar la primera letra ingresada
                    If txtBuscar.Text.Substring(0, 1) = "-" Then
                        '-- buscar por codigo de referencia
                        'MsgBox("Valor  " & txtBuscar.Text.Substring(1, (Len(txtBuscar.Text) - 1)))
                        listar_busqueda(" (referencia Like '" & txtBuscar.Text.Substring(1, (Len(txtBuscar.Text) - 1)) & "%')" & " order by 4")
                    Else
                        '-- buscar normalmente
                        If IsNumeric(txtBuscar.Text.Substring(0, 1)) Then
                            '-- controlar la manera de buscar
                            If (Trim(txtBuscar.Text).Length) = 6 Then
                                ' ordenar por el codigo del producto
                                listar_busqueda(" (codigo Like '" & txtBuscar.Text & "%' )" & "order by codigo")
                            Else
                                Dim intTmpIdProducto As Integer
                                intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where codigoBarra='" & Trim(txtBuscar.Text) & "'")
                                'MsgBox("Valor de intTmpIdProducto  " & intTmpIdProducto)
                                If intTmpIdProducto > 0 Then
                                    listar_busqueda(" (codigoBarra Like '" & txtBuscar.Text & "%' Or codigoBarra Like '" & txtBuscar.Text & "%' )" & "order by codigoBarra")
                                Else
                                    '-- codigo de barra interno
                                    '-- solo si el primer digito es igual a 1
                                    If txtBuscar.Text.Substring(0, 1) = 1 Then
                                        'MsgBox("Valor del primer digito  " & txtBuscar.Text.Substring(0, 1))
                                        If Len(Trim(txtBuscar.Text)) = 12 Then
                                            '-- para los de 12 digitos
                                            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where idProducto=" & txtBuscar.Text.Substring(6, 5))

                                            'MsgBox("Valor de intTmpIdProducto " & intTmpIdProducto)
                                        End If
                                        If Len(Trim(txtBuscar.Text)) = 13 Then
                                            '-- para los de 13 digitos
                                            intTmpIdProducto = sp_datosTabla.consulta_valor("select idProducto from v_stock" & intGl_idSucursal & " where idProducto=" & txtBuscar.Text.Substring(7, 5))
                                        End If
                                    End If
                                End If

                            End If
                        Else
                            listar_busqueda(" (mercaderia Like '" & txtBuscar.Text & "%')" & " order by 3")
                        End If
                    End If

                End If
                e.Handled = True
                SendKeys.Send("{tab}")
                'lvStock.Select()
            End If
        End If
    End Sub
    '----------------'
    '-- FORMULARIO --'
    '----------------'  
    Private Sub frmStock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- ver de donde fue llamado el formulario
        e.Cancel = False

        If banGl_ordenCoral = True Then
            banGl_ordenCoral = False

            frmOrdenPreparadoCoral.Enabled = True
            frmOrdenPreparadoCoral.Show()
            frmOrdenPreparadoCoral.BringToFront()
            frmOrdenPreparadoCoral.txtBase.Focus()
        End If
        If banGl_ordenSuvinil = True Then
            banGl_ordenSuvinil = False

            frmOrdenPreparadoSuvinil.Enabled = True
            frmOrdenPreparadoSuvinil.Show()
            frmOrdenPreparadoSuvinil.BringToFront()
            frmOrdenPreparadoSuvinil.txtBase.Focus()
        End If
        If banGl_ordenAutomotive = True Then
            banGl_ordenAutomotive = False

            frmOrdenPreparadoAutomotive.Enabled = True
            frmOrdenPreparadoAutomotive.Show()
            frmOrdenPreparadoAutomotive.BringToFront()
            frmOrdenPreparadoAutomotive.txtAnho.Focus()
        End If
    End Sub
    '---------------------------------------------------------
End Class