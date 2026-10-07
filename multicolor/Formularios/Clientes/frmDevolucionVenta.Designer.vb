<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevolucionVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevolucionVenta))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtIdDetFacturaDE = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtTimbrado = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtFacturaN = New System.Windows.Forms.TextBox()
        Me.txtDcajaN = New System.Windows.Forms.TextBox()
        Me.txtDsucN = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalNotaCredito = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIva10 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIva5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblEmpresaContable = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCotiza = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalDescuento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalFactura = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTipoVenta = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.lblNro = New System.Windows.Forms.Label()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdVenta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtGra10Det = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtGra5Det = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtExentaDet = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkDescuento = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblForma = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMercaderia = New System.Windows.Forms.Label()
        Me.lblCantfrac = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblIdStock = New System.Windows.Forms.Label()
        Me.lvNota = New System.Windows.Forms.ListView()
        Me.detNota_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_forma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_porceIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_subtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detNota_idStock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hojaImpresionSinQR = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboTipoSucursal = New System.Windows.Forms.ComboBox()
        Me.grSucursal = New System.Windows.Forms.GroupBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grSucursal.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtIdDetFacturaDE)
        Me.GroupBox3.Controls.Add(Me.dtpFecha)
        Me.GroupBox3.Controls.Add(Me.txtTimbrado)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtFacturaN)
        Me.GroupBox3.Controls.Add(Me.txtDcajaN)
        Me.GroupBox3.Controls.Add(Me.txtDsucN)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtTotalNotaCredito)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtTotalIva)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtIva10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtIva5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 519)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(958, 80)
        Me.GroupBox3.TabIndex = 111
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Total Nota de Crédito"
        '
        'txtIdDetFacturaDE
        '
        Me.txtIdDetFacturaDE.BackColor = System.Drawing.Color.SpringGreen
        Me.txtIdDetFacturaDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdDetFacturaDE.Location = New System.Drawing.Point(721, 16)
        Me.txtIdDetFacturaDE.MaxLength = 3
        Me.txtIdDetFacturaDE.Name = "txtIdDetFacturaDE"
        Me.txtIdDetFacturaDE.ReadOnly = True
        Me.txtIdDetFacturaDE.Size = New System.Drawing.Size(43, 21)
        Me.txtIdDetFacturaDE.TabIndex = 96
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(833, 37)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 23)
        Me.dtpFecha.TabIndex = 95
        '
        'txtTimbrado
        '
        Me.txtTimbrado.BackColor = System.Drawing.Color.Cyan
        Me.txtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimbrado.Location = New System.Drawing.Point(589, 16)
        Me.txtTimbrado.MaxLength = 9
        Me.txtTimbrado.Name = "txtTimbrado"
        Me.txtTimbrado.ReadOnly = True
        Me.txtTimbrado.Size = New System.Drawing.Size(126, 21)
        Me.txtTimbrado.TabIndex = 82
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(490, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 15)
        Me.Label19.TabIndex = 83
        Me.Label19.Text = "Nro. Timbrado:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(784, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 15)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Fecha:"
        '
        'txtFacturaN
        '
        Me.txtFacturaN.BackColor = System.Drawing.Color.Cyan
        Me.txtFacturaN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacturaN.Location = New System.Drawing.Point(687, 44)
        Me.txtFacturaN.MaxLength = 7
        Me.txtFacturaN.Name = "txtFacturaN"
        Me.txtFacturaN.ReadOnly = True
        Me.txtFacturaN.Size = New System.Drawing.Size(86, 21)
        Me.txtFacturaN.TabIndex = 3
        '
        'txtDcajaN
        '
        Me.txtDcajaN.BackColor = System.Drawing.Color.Cyan
        Me.txtDcajaN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcajaN.Location = New System.Drawing.Point(638, 44)
        Me.txtDcajaN.MaxLength = 3
        Me.txtDcajaN.Name = "txtDcajaN"
        Me.txtDcajaN.ReadOnly = True
        Me.txtDcajaN.Size = New System.Drawing.Size(43, 21)
        Me.txtDcajaN.TabIndex = 2
        '
        'txtDsucN
        '
        Me.txtDsucN.BackColor = System.Drawing.Color.Cyan
        Me.txtDsucN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsucN.Location = New System.Drawing.Point(589, 44)
        Me.txtDsucN.MaxLength = 3
        Me.txtDsucN.Name = "txtDsucN"
        Me.txtDsucN.ReadOnly = True
        Me.txtDsucN.Size = New System.Drawing.Size(43, 21)
        Me.txtDsucN.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(489, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 15)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "Nota de Crédito:"
        '
        'txtTotalNotaCredito
        '
        Me.txtTotalNotaCredito.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalNotaCredito.Enabled = False
        Me.txtTotalNotaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNotaCredito.Location = New System.Drawing.Point(352, 34)
        Me.txtTotalNotaCredito.Name = "txtTotalNotaCredito"
        Me.txtTotalNotaCredito.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalNotaCredito.TabIndex = 77
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(361, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 15)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Total Nota Cred."
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackColor = System.Drawing.Color.PaleGreen
        Me.txtTotalIva.Enabled = False
        Me.txtTotalIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.Location = New System.Drawing.Point(214, 34)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalIva.TabIndex = 75
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(242, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 15)
        Me.Label13.TabIndex = 74
        Me.Label13.Text = "Total IVA"
        '
        'txtIva10
        '
        Me.txtIva10.BackColor = System.Drawing.Color.PaleGreen
        Me.txtIva10.Enabled = False
        Me.txtIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva10.Location = New System.Drawing.Point(66, 48)
        Me.txtIva10.Name = "txtIva10"
        Me.txtIva10.Size = New System.Drawing.Size(127, 24)
        Me.txtIva10.TabIndex = 73
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 15)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "IVA 10%:"
        '
        'txtIva5
        '
        Me.txtIva5.BackColor = System.Drawing.Color.PaleGreen
        Me.txtIva5.Enabled = False
        Me.txtIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva5.Location = New System.Drawing.Point(65, 20)
        Me.txtIva5.Name = "txtIva5"
        Me.txtIva5.Size = New System.Drawing.Size(127, 24)
        Me.txtIva5.TabIndex = 71
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 15)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "IVA 5%:"
        '
        'lblEmpresaContable
        '
        Me.lblEmpresaContable.AutoSize = True
        Me.lblEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaContable.ForeColor = System.Drawing.Color.Maroon
        Me.lblEmpresaContable.Location = New System.Drawing.Point(668, 231)
        Me.lblEmpresaContable.Name = "lblEmpresaContable"
        Me.lblEmpresaContable.Size = New System.Drawing.Size(250, 25)
        Me.lblEmpresaContable.TabIndex = 79
        Me.lblEmpresaContable.Text = "EMPRESA CONTABLE"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(666, 213)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 15)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "Empresa Contable"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.lblCotiza)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblMoneda)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtTotalDescuento)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtTotalFactura)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(535, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(401, 132)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(91, 77)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 24
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(311, 77)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(69, 37)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(166, 77)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 37)
        Me.btnAgregar.TabIndex = 25
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(15, 77)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(69, 37)
        Me.btnNuevo.TabIndex = 23
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(238, 77)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCotiza
        '
        Me.lblCotiza.AutoSize = True
        Me.lblCotiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotiza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCotiza.Location = New System.Drawing.Point(307, 43)
        Me.lblCotiza.Name = "lblCotiza"
        Me.lblCotiza.Size = New System.Drawing.Size(57, 18)
        Me.lblCotiza.TabIndex = 22
        Me.lblCotiza.Text = "Cotiza"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(235, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Cotización:"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMoneda.Location = New System.Drawing.Point(289, 17)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(68, 18)
        Me.lblMoneda.TabIndex = 20
        Me.lblMoneda.Text = "Moneda"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(233, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Moneda:"
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalDescuento.Enabled = False
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.Location = New System.Drawing.Point(102, 42)
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalDescuento.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Total Descuento:"
        '
        'txtTotalFactura
        '
        Me.txtTotalFactura.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalFactura.Enabled = False
        Me.txtTotalFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFactura.Location = New System.Drawing.Point(100, 13)
        Me.txtTotalFactura.Name = "txtTotalFactura"
        Me.txtTotalFactura.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalFactura.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total Venta:"
        '
        'lblTipoVenta
        '
        Me.lblTipoVenta.AutoSize = True
        Me.lblTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoVenta.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblTipoVenta.Location = New System.Drawing.Point(305, 96)
        Me.lblTipoVenta.Name = "lblTipoVenta"
        Me.lblTipoVenta.Size = New System.Drawing.Size(139, 25)
        Me.lblTipoVenta.TabIndex = 23
        Me.lblTipoVenta.Text = "TIPOVENTA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRuc)
        Me.GroupBox1.Controls.Add(Me.lblNro)
        Me.GroupBox1.Controls.Add(Me.txtFechaHora)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtVendedor)
        Me.GroupBox1.Controls.Add(Me.lblTipoVenta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFechaFactura)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.txtDcaja)
        Me.GroupBox1.Controls.Add(Me.txtDsuc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIdVenta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(495, 132)
        Me.GroupBox1.TabIndex = 109
        Me.GroupBox1.TabStop = False
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.LightBlue
        Me.txtRuc.Enabled = False
        Me.txtRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuc.Location = New System.Drawing.Point(392, 19)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(85, 21)
        Me.txtRuc.TabIndex = 71
        '
        'lblNro
        '
        Me.lblNro.AutoSize = True
        Me.lblNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNro.ForeColor = System.Drawing.Color.Maroon
        Me.lblNro.Location = New System.Drawing.Point(361, 77)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(30, 16)
        Me.lblNro.TabIndex = 70
        Me.lblNro.Text = "Nro"
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Enabled = False
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(112, 99)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(177, 21)
        Me.txtFechaHora.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha/Hora Carga:"
        '
        'txtVendedor
        '
        Me.txtVendedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendedor.Location = New System.Drawing.Point(69, 72)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(283, 21)
        Me.txtVendedor.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Vendedor:"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFactura.Location = New System.Drawing.Point(362, 47)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.Size = New System.Drawing.Size(92, 21)
        Me.txtFechaFactura.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(278, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha Factura:"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.LightBlue
        Me.txtFactura.Enabled = False
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(188, 45)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(86, 21)
        Me.txtFactura.TabIndex = 7
        '
        'txtDcaja
        '
        Me.txtDcaja.BackColor = System.Drawing.Color.LightBlue
        Me.txtDcaja.Enabled = False
        Me.txtDcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcaja.Location = New System.Drawing.Point(139, 45)
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(43, 21)
        Me.txtDcaja.TabIndex = 6
        '
        'txtDsuc
        '
        Me.txtDsuc.BackColor = System.Drawing.Color.LightBlue
        Me.txtDsuc.Enabled = False
        Me.txtDsuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsuc.Location = New System.Drawing.Point(90, 45)
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(43, 21)
        Me.txtDsuc.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nro. Factura:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(192, 20)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(199, 21)
        Me.txtCliente.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(146, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente:"
        '
        'txtIdVenta
        '
        Me.txtIdVenta.BackColor = System.Drawing.Color.Lime
        Me.txtIdVenta.Enabled = False
        Me.txtIdVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdVenta.Location = New System.Drawing.Point(69, 17)
        Me.txtIdVenta.Name = "txtIdVenta"
        Me.txtIdVenta.Size = New System.Drawing.Size(74, 24)
        Me.txtIdVenta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Venta:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.DarkGray
        Me.GroupBox4.Controls.Add(Me.txtGra10Det)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.txtGra5Det)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.txtExentaDet)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.chkDescuento)
        Me.GroupBox4.Controls.Add(Me.Panel2)
        Me.GroupBox4.Controls.Add(Me.Panel1)
        Me.GroupBox4.Controls.Add(Me.lblCantfrac)
        Me.GroupBox4.Controls.Add(Me.btnCargar)
        Me.GroupBox4.Controls.Add(Me.txtCantidad)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.lblCodigo)
        Me.GroupBox4.Controls.Add(Me.lblIdStock)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 204)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(649, 101)
        Me.GroupBox4.TabIndex = 112
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mercaderías"
        '
        'txtGra10Det
        '
        Me.txtGra10Det.BackColor = System.Drawing.Color.LightBlue
        Me.txtGra10Det.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGra10Det.Location = New System.Drawing.Point(457, 70)
        Me.txtGra10Det.Name = "txtGra10Det"
        Me.txtGra10Det.ReadOnly = True
        Me.txtGra10Det.Size = New System.Drawing.Size(97, 21)
        Me.txtGra10Det.TabIndex = 147
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(480, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 15)
        Me.Label22.TabIndex = 146
        Me.Label22.Text = "Grav.10%"
        '
        'txtGra5Det
        '
        Me.txtGra5Det.BackColor = System.Drawing.Color.LightBlue
        Me.txtGra5Det.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGra5Det.Location = New System.Drawing.Point(350, 70)
        Me.txtGra5Det.Name = "txtGra5Det"
        Me.txtGra5Det.ReadOnly = True
        Me.txtGra5Det.Size = New System.Drawing.Size(97, 21)
        Me.txtGra5Det.TabIndex = 145
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(373, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 15)
        Me.Label21.TabIndex = 144
        Me.Label21.Text = "Grav.5%"
        '
        'txtExentaDet
        '
        Me.txtExentaDet.BackColor = System.Drawing.Color.LightBlue
        Me.txtExentaDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExentaDet.Location = New System.Drawing.Point(246, 70)
        Me.txtExentaDet.Name = "txtExentaDet"
        Me.txtExentaDet.ReadOnly = True
        Me.txtExentaDet.Size = New System.Drawing.Size(97, 21)
        Me.txtExentaDet.TabIndex = 143
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(269, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 15)
        Me.Label20.TabIndex = 142
        Me.Label20.Text = "Exenta"
        '
        'chkDescuento
        '
        Me.chkDescuento.AutoSize = True
        Me.chkDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDescuento.Location = New System.Drawing.Point(3, 67)
        Me.chkDescuento.Name = "chkDescuento"
        Me.chkDescuento.Size = New System.Drawing.Size(158, 24)
        Me.chkDescuento.TabIndex = 141
        Me.chkDescuento.Text = "Aplicar Descuento"
        Me.chkDescuento.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblForma)
        Me.Panel2.Location = New System.Drawing.Point(484, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(75, 20)
        Me.Panel2.TabIndex = 12
        '
        'lblForma
        '
        Me.lblForma.AutoSize = True
        Me.lblForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForma.ForeColor = System.Drawing.Color.Blue
        Me.lblForma.Location = New System.Drawing.Point(4, 3)
        Me.lblForma.Name = "lblForma"
        Me.lblForma.Size = New System.Drawing.Size(42, 16)
        Me.lblForma.TabIndex = 8
        Me.lblForma.Text = "forma"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblMercaderia)
        Me.Panel1.Location = New System.Drawing.Point(115, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(265, 19)
        Me.Panel1.TabIndex = 11
        '
        'lblMercaderia
        '
        Me.lblMercaderia.AutoSize = True
        Me.lblMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercaderia.ForeColor = System.Drawing.Color.Blue
        Me.lblMercaderia.Location = New System.Drawing.Point(4, 1)
        Me.lblMercaderia.Name = "lblMercaderia"
        Me.lblMercaderia.Size = New System.Drawing.Size(77, 16)
        Me.lblMercaderia.TabIndex = 4
        Me.lblMercaderia.Text = "mercaderia"
        '
        'lblCantfrac
        '
        Me.lblCantfrac.AutoSize = True
        Me.lblCantfrac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantfrac.ForeColor = System.Drawing.Color.Blue
        Me.lblCantfrac.Location = New System.Drawing.Point(4, 37)
        Me.lblCantfrac.Name = "lblCantfrac"
        Me.lblCantfrac.Size = New System.Drawing.Size(60, 16)
        Me.lblCantfrac.TabIndex = 10
        Me.lblCantfrac.Text = "cantFrac"
        '
        'btnCargar
        '
        Me.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargar.Enabled = False
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.Location = New System.Drawing.Point(565, 13)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(69, 37)
        Me.btnCargar.TabIndex = 9
        Me.btnCargar.Text = "Ca&rgar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.LightBlue
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(439, 20)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(40, 21)
        Me.txtCantidad.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(381, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 15)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Cantidad:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Blue
        Me.lblCodigo.Location = New System.Drawing.Point(62, 19)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(50, 16)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "codigo"
        '
        'lblIdStock
        '
        Me.lblIdStock.AutoSize = True
        Me.lblIdStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdStock.ForeColor = System.Drawing.Color.Blue
        Me.lblIdStock.Location = New System.Drawing.Point(6, 19)
        Me.lblIdStock.Name = "lblIdStock"
        Me.lblIdStock.Size = New System.Drawing.Size(53, 16)
        Me.lblIdStock.TabIndex = 1
        Me.lblIdStock.Text = "idStock"
        '
        'lvNota
        '
        Me.lvNota.AllowColumnReorder = True
        Me.lvNota.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detNota_nro, Me.detNota_codigo, Me.detNota_mercaderia, Me.detNota_forma, Me.detNota_cantidad, Me.detNota_lote, Me.detNota_vence, Me.detNota_porceIva, Me.detNota_precio, Me.detNota_subtotal, Me.detNota_idStock})
        Me.lvNota.FullRowSelect = True
        Me.lvNota.GridLines = True
        Me.lvNota.HideSelection = False
        Me.lvNota.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvNota.LabelWrap = False
        Me.lvNota.Location = New System.Drawing.Point(40, 311)
        Me.lvNota.MultiSelect = False
        Me.lvNota.Name = "lvNota"
        Me.lvNota.Size = New System.Drawing.Size(891, 194)
        Me.lvNota.TabIndex = 113
        Me.lvNota.UseCompatibleStateImageBehavior = False
        Me.lvNota.View = System.Windows.Forms.View.Details
        '
        'detNota_nro
        '
        Me.detNota_nro.Text = "Nro."
        Me.detNota_nro.Width = 40
        '
        'detNota_codigo
        '
        Me.detNota_codigo.Text = "Codigo"
        '
        'detNota_mercaderia
        '
        Me.detNota_mercaderia.Text = "Mercaderia"
        Me.detNota_mercaderia.Width = 330
        '
        'detNota_forma
        '
        Me.detNota_forma.Text = "Forma"
        Me.detNota_forma.Width = 70
        '
        'detNota_cantidad
        '
        Me.detNota_cantidad.Text = "Cant."
        Me.detNota_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detNota_cantidad.Width = 40
        '
        'detNota_lote
        '
        Me.detNota_lote.Text = "Lote"
        Me.detNota_lote.Width = 75
        '
        'detNota_vence
        '
        Me.detNota_vence.Text = "Vence"
        Me.detNota_vence.Width = 50
        '
        'detNota_porceIva
        '
        Me.detNota_porceIva.Text = "%IVA"
        Me.detNota_porceIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detNota_porceIva.Width = 40
        '
        'detNota_precio
        '
        Me.detNota_precio.Text = "Precio"
        Me.detNota_precio.Width = 70
        '
        'detNota_subtotal
        '
        Me.detNota_subtotal.Text = "SubTotal"
        Me.detNota_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detNota_subtotal.Width = 70
        '
        'detNota_idStock
        '
        Me.detNota_idStock.Text = "idStock"
        Me.detNota_idStock.Width = 50
        '
        'hojaImpresionSinQR
        '
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboTipoSucursal)
        Me.GroupBox5.Location = New System.Drawing.Point(34, 141)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(240, 53)
        Me.GroupBox5.TabIndex = 124
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Tipo de Sucursal"
        '
        'cboTipoSucursal
        '
        Me.cboTipoSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoSucursal.FormattingEnabled = True
        Me.cboTipoSucursal.Location = New System.Drawing.Point(14, 20)
        Me.cboTipoSucursal.Name = "cboTipoSucursal"
        Me.cboTipoSucursal.Size = New System.Drawing.Size(205, 24)
        Me.cboTipoSucursal.TabIndex = 50
        '
        'grSucursal
        '
        Me.grSucursal.Controls.Add(Me.cboSucursal)
        Me.grSucursal.Location = New System.Drawing.Point(293, 142)
        Me.grSucursal.Name = "grSucursal"
        Me.grSucursal.Size = New System.Drawing.Size(353, 51)
        Me.grSucursal.TabIndex = 125
        Me.grSucursal.TabStop = False
        Me.grSucursal.Text = "Sucursal"
        '
        'cboSucursal
        '
        Me.cboSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(6, 19)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(338, 24)
        Me.cboSucursal.TabIndex = 108
        '
        'frmDevolucionVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 605)
        Me.Controls.Add(Me.grSucursal)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.lvNota)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblEmpresaContable)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDevolucionVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolución de Venta"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.grSucursal.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFacturaN As System.Windows.Forms.TextBox
    Friend WithEvents txtDcajaN As System.Windows.Forms.TextBox
    Friend WithEvents txtDsucN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresaContable As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNotaCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIva As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtIva10 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIva5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblTipoVenta As System.Windows.Forms.Label
    Friend WithEvents lblCotiza As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNro As System.Windows.Forms.Label
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents lblForma As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblIdStock As System.Windows.Forms.Label
    Friend WithEvents lvNota As System.Windows.Forms.ListView
    Friend WithEvents detNota_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_forma As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_porceIva As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_subtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents detNota_idStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCantfrac As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMercaderia As System.Windows.Forms.Label
    Friend WithEvents txtTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents hojaImpresionSinQR As System.Drawing.Printing.PrintDocument
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents grSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtIdDetFacturaDE As System.Windows.Forms.TextBox
    Friend WithEvents txtGra10Det As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtGra5Det As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtExentaDet As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkDescuento As System.Windows.Forms.CheckBox
End Class
