Public Class frmBuscarDepositoMercaderia
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub inicializar()
        txtIdDeposito.Text = 0
        listar("")
    End Sub

    Sub listar(ByVal where As String)
        systemClass.SqlToLv(lvDeposito, "Select d.idDeposito,d.nombreDeposito as Deposito,_vs.nombreFantasia as Sucursal from deposito d inner join v_sucursal _vs on d.idSucursal=_vs.idSucursal " & where)
        ' dimensionar las columnas
        lvDeposito.Columns(0).Width = 80
        lvDeposito.Columns(1).Width = 250
        lvDeposito.Columns(2).Width = 250
        lvDeposito.Columns(0).Text = "ID Depo."
        lvDeposito.Columns(1).Text = "Nombre del Deposito"
        lvDeposito.Columns(2).Text = "Nombre de la Sucursal"
        lvDeposito.Scrollable = True
    End Sub

    Private Sub controlarModulo()
        '-- controlar los modulos que son abiertos
        If banGl_seguimientoStock = True Then
            '-- seguimiento de stock
            seguimientoStock()
        End If
        If banGl_ajustePositivoMercaderia = True Then
            '-- ajuste positivo de mercaderia
            ajustePositivoMercaderia()
        End If
        If banGl_ajusteNegativoMercaderia = True Then
            '-- ajuete negativo de mercaderia
            ajusteNegativoMercaderia()
        End If
        If banGl_stockInicial = True Then
            '-- stock inicial
            stockInicial()
        End If
        If banGl_reporteVencimientoMercaderia = True Then
            '-- reporte de vencimiento de mercaderia
            reporteVencimientoMercaderia()
            Me.Close()
            frmReporteVencimiento.dtpHastaFecha.Focus()
        End If
    End Sub

    Private Sub seguimientoStock()
        banGl_seguimientoStock = False
        frmSeguimientoStock.txtNombreDeposito.Text = Trim(txtNombreDeposito.Text) & "/" & Trim(txtNombreSucursal.Text)
        intGl_idDepositoSeguimientoStock = CInt(txtIdDeposito.Text)
        frmSeguimientoStock.txtIdDeposito.Text = intGl_idDepositoSeguimientoStock
        Me.Close()
        frmSeguimientoStock.Enabled = True
        frmSeguimientoStock.Show()
        frmSeguimientoStock.BringToFront()
        frmSeguimientoStock.btnBuscar.Focus()
    End Sub

    Private Sub ajustePositivoMercaderia()
        '-- dar valor a las variables publicas
        banGl_ajustePositivoMercaderia = False
        intGl_ajustePositivoIdDeposito = txtIdDeposito.Text
        intGl_ajustePositivoIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "deposito", "idDeposito", txtIdDeposito.Text)

        frmAjustePositivoMercaderia.txtIdDeposito.Text = txtIdDeposito.Text
        frmAjustePositivoMercaderia.lblDeposito.Text = Trim(txtNombreDeposito.Text) & "/" & Trim(txtNombreSucursal.Text)
        frmAjustePositivoMercaderia.lblIdDeposito.Text = txtIdDeposito.Text
        '-- habilitar los objetos del formulario
        frmAjustePositivoMercaderia.txtProducto.Enabled = True
        frmAjustePositivoMercaderia.txtProducto.BackColor = Color.White
        frmAjustePositivoMercaderia.txtCantidad.Enabled = True
        frmAjustePositivoMercaderia.txtCantidad.BackColor = Color.White
        frmAjustePositivoMercaderia.txtExplica.ReadOnly = False
        frmAjustePositivoMercaderia.txtExplica.BackColor = Color.White
        frmAjustePositivoMercaderia.cboMotivo.Enabled = True
        frmAjustePositivoMercaderia.btnCancelar.Enabled = True
        frmAjustePositivoMercaderia.btnEliminar.Enabled = True
        frmAjustePositivoMercaderia.btnGuardar.Enabled = True
        frmAjustePositivoMercaderia.btnNuevo.Enabled = False
        Me.Close()
        frmAjustePositivoMercaderia.Enabled = True
        frmAjustePositivoMercaderia.Show()
        frmAjustePositivoMercaderia.BringToFront()
        frmAjustePositivoMercaderia.txtExplica.Focus()
    End Sub

    Private Sub ajusteNegativoMercaderia()
        '-- dar valor a las variables publicas
        banGl_ajusteNegativoMercaderia = False
        intGl_ajusteNegativoIdDeposito = txtIdDeposito.Text
        intGl_ajusteNegativoIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "deposito", "idDeposito", txtIdDeposito.Text)

        frmAjusteNegativoMercaderia.txtIdDeposito.Text = txtIdDeposito.Text
        frmAjusteNegativoMercaderia.lblDeposito.Text = Trim(txtNombreDeposito.Text) & "/" & Trim(txtNombreSucursal.Text)
        frmAjusteNegativoMercaderia.lblIdDeposito.Text = txtIdDeposito.Text
        '-- habilitar los objetos del formulario
        frmAjusteNegativoMercaderia.txtProducto.Enabled = True
        frmAjusteNegativoMercaderia.txtProducto.BackColor = Color.White
        frmAjusteNegativoMercaderia.txtCantidad.Enabled = True
        frmAjusteNegativoMercaderia.txtCantidad.BackColor = Color.White
        frmAjusteNegativoMercaderia.txtExplica.ReadOnly = False
        frmAjusteNegativoMercaderia.txtExplica.BackColor = Color.White
        frmAjusteNegativoMercaderia.cboMotivo.Enabled = True
        frmAjusteNegativoMercaderia.btnCancelar.Enabled = True
        frmAjusteNegativoMercaderia.btnEliminar.Enabled = True
        frmAjusteNegativoMercaderia.btnGuardar.Enabled = True
        frmAjusteNegativoMercaderia.btnNuevo.Enabled = False


        Me.Close()
        frmAjusteNegativoMercaderia.Enabled = True
        frmAjusteNegativoMercaderia.Show()
        frmAjusteNegativoMercaderia.BringToFront()
        frmAjusteNegativoMercaderia.txtExplica.Focus()
    End Sub

    Private Sub stockInicial()
        '-- dar valor a las variables publicas
        banGl_stockInicial = False
        'intGl_ajusteNegativoIdDeposito = txtIdDeposito.Text
        'intGl_ajusteNegativoIdSucursal = sp_datosTabla.un_dato_integer("idSucursal", "deposito", "idDeposito", txtIdDeposito.Text)

        frmStockInicial.txtIdDeposito.Text = txtIdDeposito.Text
        frmStockInicial.lblDeposito.Text = Trim(txtNombreDeposito.Text) & "/" & Trim(txtNombreSucursal.Text)
        frmStockInicial.lblIdDeposito.Text = txtIdDeposito.Text
        '-- habilitar los objetos del formulario
        '-- txt
        frmStockInicial.txtProducto.Enabled = True
        frmStockInicial.txtProducto.Text = ""
        frmStockInicial.txtProducto.BackColor = Color.White
        frmStockInicial.txtCantidad.Enabled = True
        frmStockInicial.txtCantidad.Text = 0
        frmStockInicial.txtCantidad.BackColor = Color.White
        frmStockInicial.txtCosto.Enabled = True
        frmStockInicial.txtCosto.Text = 0
        frmStockInicial.txtCosto.BackColor = Color.White
        frmStockInicial.txtLote.Enabled = True
        frmStockInicial.txtLote.BackColor = Color.White
        frmStockInicial.maskVence.Enabled = True
        frmStockInicial.maskVence.BackColor = Color.White
        '-- botones
        frmStockInicial.btnCancelar.Enabled = True
        frmStockInicial.btnEliminar.Enabled = True
        frmStockInicial.btnGuardar.Enabled = True
        frmStockInicial.btnNuevo.Enabled = False
        frmStockInicial.btnAgregar.Enabled = True
        Me.Close()
        frmStockInicial.Enabled = True
        frmStockInicial.Show()
        frmStockInicial.BringToFront()
        frmStockInicial.txtProducto.Focus()
    End Sub

    Private Sub reporteVencimientoMercaderia()
        frmReporteVencimiento.txtIdDeposito.Text = txtIdDeposito.Text
        frmReporteVencimiento.txtDeposito.Text = txtNombreDeposito.Text
    End Sub

    '-----------------------------------------------------------------------------
    '**************'
    '-- LOS TXT --'
    '**************'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(txtBuscar.Text) Then
                ' ordenar por idDeposito
                listar(" Where d.idDeposito=" & txtBuscar.Text)
            End If
            If Not IsNumeric(txtBuscar.Text) Then
                ' ordenar por nombre de la sucursal
                listar(" Where _vs.nombreFantasia Like '" & txtBuscar.Text & "%' Or _vs.nombreFantasia Like '" & txtBuscar.Text & "%' " & "order by _vs.nombreFantasia")
            End If
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
    End Sub

    '-----------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvDeposito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvDeposito.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- solo si se pocisiona sobre un registro
            If txtIdDeposito.Text = 0 Then
                MessageBox.Show("Debe Ingresar algún Item..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            'MsgBox("Valor de la variable  " & banGl_ajustePositivoMercaderia)
            controlarModulo()
        End If
    End Sub

    Private Sub lvDeposito_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvDeposito.SelectedIndexChanged
        '-- mostrar los datos del deposito
        For Each item As ListViewItem In lvDeposito.SelectedItems
            intGl_idDepositoSeguimientoStock = item.SubItems(0).Text
            txtIdDeposito.Text = item.SubItems(0).Text
            txtNombreDeposito.Text = item.SubItems(1).Text
            txtNombreSucursal.Text = item.SubItems(2).Text
        Next
    End Sub
    '-----------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmBuscarDepositoMercaderia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_seguimientoStock = True Then
            '-- seguimiento de stock
            banGl_seguimientoStock = False
            frmSeguimientoStock.chkBuscarDeposito.Checked = False
            frmSeguimientoStock.Enabled = True
            frmSeguimientoStock.WindowState = FormWindowState.Normal
            frmSeguimientoStock.Show()
            frmSeguimientoStock.BringToFront()
        End If
        If banGl_ajusteNegativoMercaderia = True Then
            '-- ajuste negativo del stock
            banGl_ajusteNegativoMercaderia = False

            frmAjusteNegativoMercaderia.Enabled = True
            frmAjusteNegativoMercaderia.WindowState = FormWindowState.Normal
            frmAjusteNegativoMercaderia.Show()
            frmAjusteNegativoMercaderia.BringToFront()
        End If
        If banGl_ajustePositivoMercaderia = True Then
            '-- ajuste positivo del stock
            banGl_ajustePositivoMercaderia = False

            frmAjustePositivoMercaderia.Enabled = True
            frmAjustePositivoMercaderia.WindowState = FormWindowState.Normal
            frmAjustePositivoMercaderia.Show()
            frmAjustePositivoMercaderia.BringToFront()
        End If
        If banGl_stockInicial = True Then
            '-- stock inicial
            banGl_stockInicial = False

            frmStockInicial.Enabled = True
            frmStockInicial.WindowState = FormWindowState.Normal
            frmStockInicial.Show()
            frmStockInicial.BringToFront()
        End If

        If banGl_reporteVencimientoMercaderia = True Then
            '-- reporte de vencimiento de meraderia
            banGl_reporteVencimientoMercaderia = False

            frmReporteVencimiento.Enabled = True
            frmReporteVencimiento.Show()
            frmReporteVencimiento.BringToFront()
        End If
    End Sub
    '-----------------------------------------------------------------------------
End Class