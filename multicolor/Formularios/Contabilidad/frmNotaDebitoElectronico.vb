Public Class frmNotaDebitoElectronico
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla
    Dim sucursal As New Sucursal

    Dim bolError As Boolean = False

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
        If (fun_guardarSp("sp_cargarTmpNotaDebitoDTE_generada", intGl_idConfigPc & "," & cboSucursal.SelectedValue, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo cargar las notas de créditos...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            listarDetalle(intGl_idConfigPc)
        End If
    End Sub

    Private Sub actualizarVenta()
        If (fun_guardarSp("sp_actualizarTmpNotaDebitoDTE_generada", intGl_idConfigPc & "," & txtDesdeNro.Text & "," & txtHastaNro.Text, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo actualizar las devoluciones..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            listarDetalle(intGl_idConfigPc)
        End If
    End Sub

    Private Sub aprobarDTE()
        If (fun_guardarSp("sp_aprobarNotaDebitoDTE_generada", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo actualizar el estado de Aprobado de las notas de crédito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            cargarVenta()
        End If
    End Sub

    Private Sub guardarGeneraFacturaDTE()
        If (fun_guardarSp("sp_guardarNotaDebitoDTE_generada", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar las facturas generadas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            MessageBox.Show("Se generaron con éxito las facturas electrónicas...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cargarVenta()
        End If
    End Sub

    Private Sub listarDetalle(ByVal v_idConfig As Integer)
        '-- el detalle
        systemClass.SqlToLv_detalleFacturaDTE(lvFactura, "sp_consultaTmpNotaDebitoDTE_generada", v_idConfig)
    End Sub

    Private Sub generarFacturaElectronica()
        If (fun_guardarSp("sp_generarNotaDebitoElectronica", intGl_idConfigPc, Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo agregar los registros para la factura DTE...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bolError = True
        End If
    End Sub

    Private Sub listarLote(ByVal v_tipo As String)
        '-- el detalle
        systemClass.SqlToLv_consultaLoteSIFEN(lvLote, "sp_consultaLoteSifen", "'" & v_tipo & "'")
    End Sub

    Private Sub listarErrorLote(ByVal v_idLote As Integer)
        '-- consulta error de los lotes
        systemClass.SqlToLv_consultaLoteSIFEN(lvError, "sp_consultaErrorLoteSifen", v_idLote)
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        actualizarVenta()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        cargarVenta()
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If MessageBox.Show("Desea Procesar esas Notas de Crédito.!", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            banGl_errorDTE = False
            '--- generar las facturas
            bolError = False
            'sp_datosTabla.consulta_facturacionElectronicaXML("select idVenta,nroFactura from tmpFacturaDTE_generada where seleccion=1 and idConfig=" & intGl_idConfigPc)
            If banGl_errorDTE = False Then
                generarFacturaElectronica()
                If bolError = False Then
                    guardarGeneraFacturaDTE()
                End If

            End If
        End If
    End Sub

    Private Sub btnActualizarLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarLote.Click
        listarLote("NOTA-CREDITO")
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        aprobarDTE()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*********'
    '-- TXT --'
    '*********'
    Private Sub txtDesdeNro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesdeNro.KeyPress
        e.Handled = txtNumerico(txtDesdeNro, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(Trim(txtDesdeNro.Text)) = 0 Or txtDesdeNro.Text > 50 Then
                txtDesdeNro.Text = 0
            End If
            e.Handled = True
            txtHastaNro.Focus()
        End If
    End Sub

    Private Sub txtHastaNro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaNro.KeyPress
        e.Handled = txtNumerico(txtHastaNro, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Len(Trim(txtHastaNro.Text)) = 0 Or txtHastaNro.Text > 30 Then
                txtDesdeNro.Text = 1
            End If
            e.Handled = True
            btnCargar.Focus()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
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
    '----------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmNotaDebitoElectronico_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.contabilidadGenerarNotaCrDTE.Enabled = True

        e.Cancel = False
    End Sub

End Class