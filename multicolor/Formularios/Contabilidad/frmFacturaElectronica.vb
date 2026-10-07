
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmFacturaElectronica
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim sucursal As New Sucursal

    Dim intIdMov As Integer = 0
    Dim banAnulado As Boolean = False

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        limpiarObjetos()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub limpiarObjetos()
        '-- los txt
        txtDesdeNro.Text = 0
        txtHastaNro.Text = 0
        '-- el combobox
        sucursal.comboSucursalDTE(cboSucursal)
        listarDetalle(0)
    End Sub

    Private Sub cargarVenta()
        Me.Enabled = False
        If (fun_guardarSp("sp_cargarTmpFacturaDTE_generada", intGl_idConfigPc & "," & cboSucursal.SelectedValue & ",'" & dtpFechaConsulta.Text & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo cargar las ventas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        Else
            listarDetalle(intGl_idConfigPc)
        End If
        Me.Enabled = True
    End Sub

    Private Sub cargarVentaResto()
        Me.Enabled = False
        If (fun_guardarSp("sp_cargarTmpFacturaDTE_generada_resto", intGl_idConfigPc & "," & cboSucursal.SelectedValue & ",'" & dtpFechaConsulta.Text & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo cargar las ventas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        Else
            listarDetalle(intGl_idConfigPc)
        End If
        Me.Enabled = True
    End Sub

    Private Sub cargarVentaHotel()
        Me.Enabled = False
        If (fun_guardarSp("sp_cargarTmpFacturaDTE_generada_hotel", intGl_idConfigPc & "," & cboSucursal.SelectedValue & ",'" & dtpFechaConsulta.Text & "'", Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo cargar las ventas del hotel...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        Else
            listarDetalle(intGl_idConfigPc)
        End If
        Me.Enabled = True
    End Sub

    Private Sub cargarVentaAnulada()
        Me.Enabled = False
        If (fun_guardarSp("sp_cargarTmpFacturaDTE_generadaAnulada", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo cargar las ventas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        Else
            listarDetalleAnulado(intGl_idConfigPc)
        End If
        Me.Enabled = True
    End Sub

    Private Sub actualizarVenta()
        If (fun_guardarSp("sp_actuaizarTmpFacturaDTE_generada", intGl_idConfigPc & "," & txtDesdeNro.Text & "," & txtHastaNro.Text, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo actualizar las ventas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            listarDetalle(intGl_idConfigPc)
            listarDetalleAnulado(intGl_idConfigPc)
        End If
    End Sub

    Private Sub guardarGeneraFacturaDTE()
        Me.Enabled = False
        If (fun_guardarSp("sp_guardarFacturaDTE_generada", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar las facturas generadas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        Else
            MessageBox.Show("Se generaron con éxito las facturas electrónicas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            If banAnulado = False Then
                cargarVenta()
            Else
                cargarVentaAnulada()
            End If

        End If
    End Sub

    Private Sub guardarGeneraFacturaDTEResto()
        Me.Enabled = False
        If (fun_guardarSp("sp_guardarFacturaDTE_generada_resto", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar las facturas generadas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        Else
            MessageBox.Show("Se generaron con éxito las facturas electrónicas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            If banAnulado = False Then
                cargarVentaResto()
            Else
                cargarVentaAnulada()
            End If

        End If
    End Sub


    Private Sub guardarGeneraFacturaDTEHotel()
        Me.Enabled = False
        If (fun_guardarSp("sp_guardarFacturaDTE_generada_hotel", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar las facturas generadas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        Else
            MessageBox.Show("Se generaron con éxito las facturas electrónicas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            If banAnulado = False Then
                cargarVentaHotel()
            Else
                cargarVentaAnulada()
            End If

        End If
    End Sub

    Private Sub listarDetalle(ByVal v_idConfig As Integer)
        '-- el detalle
        systemClass.SqlToLv_detalleFacturaDTE(lvFactura, "sp_consultaTmpFacturaDTE_generada", v_idConfig)
    End Sub

    Private Sub listarDetalleAnulado(ByVal v_idConfig As Integer)
        '-- el detalle
        systemClass.SqlToLv_detalleFacturaDTEAnulada(lvAnulado, "sp_consultaTmpFacturaDTE_generadaAnulada", v_idConfig)
    End Sub

    Private Sub generarFacturaElectronica()
        Me.Enabled = False
        If (fun_guardarSp("sp_generarFacturaElectronica", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo agregar los registros para la factura DTE...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        End If
        Me.Enabled = True
    End Sub

    Private Sub generarFacturaElectronicaResto()
        Me.Enabled = False
        If (fun_guardarSp("sp_generarFacturaElectronica_resto", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo agregar los registros para la factura DTE...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        End If
        Me.Enabled = True
    End Sub

    Private Sub generarFacturaElectronicaHotel()
        Me.Enabled = False
        If (fun_guardarSp("sp_generarFacturaElectronica_hotel", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo agregar los registros para la factura DTE...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        End If
        Me.Enabled = True
    End Sub

    Private Sub listarLote(ByVal v_tipo As String)
        '-- el detalle
        systemClass.SqlToLv_consultaLoteSIFEN(lvLote, "sp_consultaLoteSifen", v_tipo)
    End Sub

    Private Sub listarErrorLote(ByVal v_idLote As Integer)
        '-- consulta error de los lotes
        systemClass.SqlToLv_consultaLoteSIFEN(lvError, "sp_consultaErrorLoteSifen", v_idLote)
    End Sub

    Private Sub listarEmailProcesado()
        systemClass.SqlToLv_detalleConsultaEmailFactura(lvMail, "sp_consultaEmailFacturaDTE", intGl_idConfigPc)
    End Sub

    Private Sub listarConsultaFacturas()
        '-- el detalle
        systemClass.SqlToLv_detalleConsultaFacturaNoEnviada(lvConsulta, "sp_consultaFacturaNoEnviadaSifen", "'" & dtpDesdeFecha.Text & "'")
    End Sub

    Private Sub guardarAnulado()
        If (fun_guardarSp("sp_guardarFacturaAnuladaSifen", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los anulados...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Enabled = True
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Me.Enabled = False
        banGl_generaFE = False
        banAnulado = False
        actualizarVenta()
        Me.Enabled = True
        'listarEmailProcesado()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Me.Enabled = False
        If rdVenta.Checked = True Then
            cargarVenta()
        End If
        If rdResto.Checked = True Then
            cargarVentaResto()
        End If
        If rdHotel.Checked = True Then
            cargarVentaHotel()
        End If
        Me.Enabled = True
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If MessageBox.Show("Desea Procesar esas Facturas.!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            banGl_errorDTE = False
            '--- generar las facturas

            'sp_datosTabla.consulta_facturacionElectronicaXML("select idVenta,nroFactura from tmpFacturaDTE_generada where seleccion=1 and idConfig=" & intGl_idConfigPc)
            If banGl_errorDTE = False Then
                If rdVenta.Checked = True Then
                    generarFacturaElectronica()
                    guardarGeneraFacturaDTE()
                End If

                If rdResto.Checked = True Then
                    generarFacturaElectronicaResto()
                    guardarGeneraFacturaDTEResto()
                End If

                If rdHotel.Checked = True Then
                    generarFacturaElectronicaHotel()
                    guardarGeneraFacturaDTEHotel()
                End If

                'banGl_generaFE = True
                'listarEmailProcesado()
            End If
        End If
    End Sub

    Private Sub btnActualizarLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarLote.Click
        listarLote("FACTURA")
    End Sub

    Private Sub btnConsultarFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarFactura.Click
        Me.Enabled = False
        listarConsultaFacturas()
        Me.Enabled = True
    End Sub

    Private Sub btnConsultaAnulado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaAnulado.Click
        banAnulado = True
        Me.Enabled = False
        cargarVentaAnulada()
        Me.Enabled = True
    End Sub

    Private Sub btnGuardarAnulado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarAnulado.Click
        If MessageBox.Show("Quiere guardar los anulados.?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Enabled = False
            guardarAnulado()
            cargarVentaAnulada()
            'listarDetalleAnulado(intGl_idConfigPc)
            Me.Enabled = True
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtDesdeNro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeNro.KeyPress
        e.Handled = txtNumerico(txtDesdeNro, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(Trim(txtDesdeNro.Text)) = 0 Then
                txtDesdeNro.Text = 0
            End If
            e.Handled = True
            txtHastaNro.Focus()
        End If
    End Sub

    Private Sub txtHastaNro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaNro.KeyPress
        e.Handled = txtNumerico(txtHastaNro, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(Trim(txtHastaNro.Text)) = 0 Then
                txtDesdeNro.Text = 1
            End If
            e.Handled = True
            btnCargar.Focus()
        End If
    End Sub
    '--------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFactura.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvFactura.SelectedItems
            txtCdc.Text = sp_datosTabla.consulta_valorString("select cdc from detVentaDTE where idVenta=" & CInt(item.SubItems(6).Text))
        Next
    End Sub

    Private Sub lvLote_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvLote.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvLote.SelectedItems
            txtNroLote.Text = item.SubItems(5).Text
            '-- listar el error del lote
            listarErrorLote(CInt(item.SubItems(1).Text))
        Next
    End Sub

    '-- el listview de las facturas con error
    Private Sub lvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConsulta.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvConsulta.SelectedItems
            txtMensaje.Text = item.SubItems(11).Text
            txtIdTransa.Text = item.SubItems(9).Text
            txtIdMov.Text = item.SubItems(10).Text
            txtIdPersona.Text = item.SubItems(4).Text
            txtCdc.Text = sp_datosTabla.consulta_valorString("select cdc from detVentaDTE where idVenta=" & CInt(item.SubItems(9).Text))
        Next
    End Sub

    '-- el listview de las facturas anuladas
    Private Sub lvAnulado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAnulado.SelectedIndexChanged
        '-- mostrar los datos del proveedor
        For Each item As ListViewItem In lvAnulado.SelectedItems
            txtCdc.Text = sp_datosTabla.consulta_valorString("select cdc from detVentaDTE where idVenta=" & CInt(item.SubItems(6).Text))
            txtIdSifen.Text = item.SubItems(9).Text
            txtIdMov2.Text = item.SubItems(8).Text
        Next
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmFacturaElectronica_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.contabilidadGenerarFacturaDTE.Enabled = True

        e.Cancel = False
    End Sub

End Class