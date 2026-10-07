Public Class frmReutilizarCompra
    Dim sp_datosTabla As New sp_datosTabla
    Dim sp_cargarCompra As New sp_cargarCompra
    Dim systemClass As New SystemClass

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '*******************'
    '-- PROCEDIMIENTO --'
    '*******************'
    Private Sub inicializar()
        txtIdCompra.Text = 0
        txtFecha.Text = ""
        txtFechaCarga.Text = ""
        txtProveedor.Text = ""
        txtTotal.Text = 0
        txtCargadopor.Text = ""
        txtFactura.Text = ""
        txtIdCompra.Focus()
    End Sub

    Private Sub datosCompra(ByVal v_idCompra As Integer)
        If rdImp.Checked = True Then
            '-- impresos
            If sp_datosTabla.consulta_valor("select idCompra from cabCompra where idCompra=" & v_idCompra) > 0 Then
                txtFactura.Text = Trim(sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+ltrim(dcaja)+'-'+ltrim(factura) from " & _
                                                                        " cabCompra where idCompra=" & v_idCompra))
                txtFecha.Text = sp_datosTabla.consulta_valorString("select fecha from cabCompra where idCompra=" & v_idCompra)
                txtFechaCarga.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cabCompra where idCompra=" & v_idCompra)
                Dim intTmpIdUsuario As Integer
                intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from cabCompra where idCompra=" & v_idCompra)
                txtCargadopor.Text = sp_datosTabla.consulta_valorString("select rtrim(_vu.nombre)+','+ltrim(_vu.apellido) from " & _
                                                                      " v_usuarioT _vu where idUsuario=" & intTmpIdUsuario)
                txtTotal.Text = sp_datosTabla.consulta_valorDouble("select total from cabCompra where idCompra=" & v_idCompra)
                txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,###.00")
                Dim intTmpIdProveedor As Integer
                intTmpIdProveedor = sp_datosTabla.consulta_valor("select idProveedor from cabCompra  where idCompra=" & v_idCompra)
                txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from v_proveedor where idProveedor=" & intTmpIdProveedor)
                btnAgregar.Enabled = True
            Else
                If sp_datosTabla.consulta_valor("select idCompra from cco where idCompra=" & v_idCompra) > 0 Then
                    txtFactura.Text = Trim(sp_datosTabla.consulta_valorString("select rtrim(dsuc)+'-'+ltrim(dcaja)+'-'+ltrim(factura) from " & _
                                                                            " cco where idCompra=" & v_idCompra))
                    txtFecha.Text = sp_datosTabla.consulta_valorString("select fecha from cco where idCompra=" & v_idCompra)
                    txtFechaCarga.Text = sp_datosTabla.consulta_valorString("select fechaAlta from cco where idCompra=" & v_idCompra)
                    Dim intTmpIdUsuario As Integer
                    intTmpIdUsuario = sp_datosTabla.consulta_valor("select idUsuarioAlta from cco where idCompra=" & v_idCompra)
                    txtCargadopor.Text = sp_datosTabla.consulta_valorString("select rtrim(_vu.nombre)+','+ltrim(_vu.apellido) from " & _
                                                                          " v_usuarioT _vu where idUsuario=" & intTmpIdUsuario)
                    txtTotal.Text = sp_datosTabla.consulta_valorDouble("select total from cco where idCompra=" & v_idCompra)
                    txtTotal.Text = Format(CDec(txtTotal.Text), "###,###,###.00")
                    Dim intTmpIdProveedor As Integer
                    intTmpIdProveedor = sp_datosTabla.consulta_valor("select idProveedor from cco where idCompra=" & v_idCompra)
                    txtProveedor.Text = sp_datosTabla.consulta_valorString("select nombre from v_proveedor where idProveedor=" & intTmpIdProveedor)
                    btnAgregar.Enabled = True
                Else
                    MessageBox.Show("Este Nro. de Movimiento no existe en ninguna Compra..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btnAgregar.Enabled = False
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cargarCompraImpresa(ByVal v_idCompra As Integer)
        Try
            Dim intTmpTipo As Integer

            If rdImp.Checked = True Then
                intTmpTipo = 1
            Else
                intTmpTipo = 2
            End If
            '-- limpiar la grilla
            sp_datosTabla.consulta_valor("delete from detCompraTmp where idConfig=" & intGl_idConfigPc)

            '-- cargar las compras
            If (fun_guardarSp("sp_cargarDetalleCompra", txtIdCompra.Text & "," & intTmpTipo & "," & intGl_idConfigPc, Me.Name)) = 0 Then
                '-- no se guardo los registros
                MessageBox.Show("No se pudo Actualizar los Lotes en el detalle de la Compra...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '--------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtIdCompra_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdCompra.KeyPress
        e.Handled = txtNumerico(txtIdCompra, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            datosCompra(txtIdCompra.Text)
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************' 
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If MessageBox.Show("Desea Reutilizar esta Compra..!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            cargarCompraImpresa(txtIdCompra.Text)
            Me.Close()
            frmCompras.listarCompra()
            frmCompras.sumarTotal()
            frmCompras.Enabled = True
            frmCompras.Show()
            frmCompras.BringToFront()
            frmCompras.txtProducto.Focus()
        End If
    End Sub

    '--------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReutilizarCompra_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmCompras.Enabled = True
        frmCompras.Show()
        frmCompras.BringToFront()
    End Sub
    '--------------------------------------------------

End Class