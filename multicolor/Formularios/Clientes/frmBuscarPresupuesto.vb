Public Class frmBuscarPresupuesto
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvBuscar, "Select cp.idPresupuesto,_vs.nombreFantasia,_vc.soloruc,rtrim(_vc.nombre)+','+(_vc.apellido) from cabPresupuesto cp inner join v_Sucursal _vs  on " & _
                            " cp.idSucursal=_vs.idSucursal inner join v_cliente _vc on _vc.idCliente=cp.idCliente " & where)
        txtSql.Text = "Select cp.idPresupuesto,_vs.nombreFantasia,_vc.soloruc,rtrim(_vc.nombre)+','+(_vc.apellido) from cabPresupuesto cp inner join v_Sucursal _vs  on " & _
                            " cp.idSucursal=_vs.idSucursal inner join v_cliente _vc on _vc.idCliente=cp.idCliente " & where

        ' dimensionar las columnas
        lvBuscar.Columns(0).Width = 80
        lvBuscar.Columns(1).Width = 250
        lvBuscar.Columns(2).Width = 80
        lvBuscar.Columns(3).Width = 250
        lvBuscar.Columns(0).Text = "ID Pre."
        lvBuscar.Columns(1).Text = "Nombre de la Sucursal"
        lvBuscar.Columns(2).Text = "RUC"
        lvBuscar.Columns(3).Text = "Nombre del Cliente"
        lvBuscar.Scrollable = True
    End Sub

    Private Sub cargarPresupuestoVenta(ByVal v_idPresu As Integer)
        Dim intTmpIdCliente As Integer
        Dim intTmpIdPersona As Integer
        Dim intTmpIdGrupoCliente As Integer
        '-- cargar las variables
        intTmpIdCliente = sp_datosTabla.consulta_valor("select idCliente from cabPresupuesto where idPresupuesto=" & v_idPresu)

        If (fun_guardarSp("sp_cargarDetalleVentaPresupuesto", intGl_idConfigPc & "," & v_idPresu, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            '-- datos del cliente
            intGl_vtaIdCliente = intTmpIdCliente
            intTmpIdPersona = sp_datosTabla.consulta_valor("select idPersona from v_cliente where idcliente=" & intTmpIdCliente)
            frmVentaFarmacia1.txtCliente.Text = Trim(txtNombre.Text)
            frmVentaFarmacia1.txtIdCliente.Text = intGl_vtaIdCliente
            intTmpIdGrupoCliente = sp_datosTabla.consulta_valor("select idGrupoCliente from Cliente where idCliente=" & intTmpIdCliente)
            frmVentaFarmacia1.txtGrupoCliente.Text = sp_datosTabla.consulta_valorString("select nombreGrupoCliente from grupoCliente where idGrupoCliente=" & intTmpIdGrupoCliente)
            frmVentaFarmacia1.txtTelefonoCliente.Text = sp_datosTabla.consulta_valorString("select [dbo].[funTraerTelefono](" & intTmpIdPersona & " )")
            frmVentaFarmacia1.txtRucCliente.Text = sp_datosTabla.consulta_valorString("select ruc from v_cliente where idCliente=" & intTmpIdCliente)
            frmVentaFarmacia1.txtDireccion.Text = sp_datosTabla.consulta_valorString("select direccion from v_cliente where idCliente=" & intTmpIdCliente)

            '-- actualizar el detalle de la venta temporal
            If (fun_guardarSp("sp_updDetVentaFarmaciaTmpDelivery", intGl_idEntidad & "," & intGl_idConfigPc & "," & intGl_vtaIdCliente & "," & _
                              CInt(frmVentaFarmacia1.lblIdTipoVenta.Text) & "," & CInt(frmVentaFarmacia1.txtIdTipoventa.Text), Me.Name)) = 0 Then
                '-- no se guardo los registros
                'MessageBox.Show("No se pudo Agregar al Detalle de la Venta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            '--------------------------------------------
            frmVentaFarmacia1.actualizarDetVenta()
            frmVentaFarmacia1.sumarTotales()
            Me.Close()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por soloruc
                listar(" Where cp.idPresupuesto=" & txtBuscar.Text)
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre del cliente
                listar(" Where _vc.nombre Like '" & txtBuscar.Text & "%' Or _vc.nombre Like '" & txtBuscar.Text & "%' " & " order by _vc.nombre")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtId.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '--- la accion
            cargarPresupuestoVenta(CInt(txtId.Text))
            '---------------------
        End If
    End Sub

    Private Sub lvBuscar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBuscar.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvBuscar.SelectedItems
            txtId.Text = item.SubItems(0).Text
            txtNombre.Text = item.SubItems(3).Text
        Next
    End Sub
    '--------------------------------------------------------------------------------------
    '********************'
    '-- EL FORMULARIO --'
    '********************'
    Private Sub frmBuscarSucursal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        frmVentaFarmacia1.Enabled = True
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
        frmVentaFarmacia1.txtBuscar.Focus()

    End Sub
    '--------------------------------------------------------------------------------------
End Class