<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetencionProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRetencionProveedor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.lblIdCompra = New System.Windows.Forms.Label()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTipoCompra = New System.Windows.Forms.Label()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdCompra = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtTotalFactura = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblEmpresaContable = New System.Windows.Forms.Label()
        Me.lvRetencion = New System.Windows.Forms.ListView()
        Me.detRete_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detRete_idCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detRete_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detRete_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detRete_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detRete_sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detRete_retencion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTotalRetencion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIva10 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIva5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTimbrado = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtFacturaN = New System.Windows.Forms.TextBox()
        Me.txtDcajaN = New System.Windows.Forms.TextBox()
        Me.txtDsucN = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRuc)
        Me.GroupBox1.Controls.Add(Me.lblIdCompra)
        Me.GroupBox1.Controls.Add(Me.txtFechaHora)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblTipoCompra)
        Me.GroupBox1.Controls.Add(Me.txtFechaFactura)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.txtDcaja)
        Me.GroupBox1.Controls.Add(Me.txtDsuc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIdCompra)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 132)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.LightBlue
        Me.txtRuc.Enabled = False
        Me.txtRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuc.Location = New System.Drawing.Point(430, 19)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(78, 21)
        Me.txtRuc.TabIndex = 71
        '
        'lblIdCompra
        '
        Me.lblIdCompra.AutoSize = True
        Me.lblIdCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCompra.ForeColor = System.Drawing.Color.Maroon
        Me.lblIdCompra.Location = New System.Drawing.Point(361, 77)
        Me.lblIdCompra.Name = "lblIdCompra"
        Me.lblIdCompra.Size = New System.Drawing.Size(81, 16)
        Me.lblIdCompra.TabIndex = 70
        Me.lblIdCompra.Text = "lblIdCompra"
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
        'lblTipoCompra
        '
        Me.lblTipoCompra.AutoSize = True
        Me.lblTipoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCompra.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblTipoCompra.Location = New System.Drawing.Point(305, 96)
        Me.lblTipoCompra.Name = "lblTipoCompra"
        Me.lblTipoCompra.Size = New System.Drawing.Size(162, 25)
        Me.lblTipoCompra.TabIndex = 23
        Me.lblTipoCompra.Text = "TIPOCOMPRA"
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
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(229, 20)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(199, 21)
        Me.txtProveedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(163, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proveedor:"
        '
        'txtIdCompra
        '
        Me.txtIdCompra.BackColor = System.Drawing.Color.Lime
        Me.txtIdCompra.Enabled = False
        Me.txtIdCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCompra.Location = New System.Drawing.Point(85, 17)
        Me.txtIdCompra.Name = "txtIdCompra"
        Me.txtIdCompra.Size = New System.Drawing.Size(74, 24)
        Me.txtIdCompra.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Compra:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtTotalFactura)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.btnCargar)
        Me.GroupBox4.Controls.Add(Me.txtPorcentaje)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Location = New System.Drawing.Point(534, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(429, 71)
        Me.GroupBox4.TabIndex = 113
        Me.GroupBox4.TabStop = False
        '
        'txtTotalFactura
        '
        Me.txtTotalFactura.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalFactura.Enabled = False
        Me.txtTotalFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFactura.Location = New System.Drawing.Point(289, 27)
        Me.txtTotalFactura.Name = "txtTotalFactura"
        Me.txtTotalFactura.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalFactura.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(199, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Total Venta:"
        '
        'btnCargar
        '
        Me.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargar.Enabled = False
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.Location = New System.Drawing.Point(96, 13)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(69, 37)
        Me.btnCargar.TabIndex = 9
        Me.btnCargar.Text = "Ca&rgar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BackColor = System.Drawing.Color.LightBlue
        Me.txtPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.Location = New System.Drawing.Point(31, 26)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.ReadOnly = True
        Me.txtPorcentaje.Size = New System.Drawing.Size(40, 21)
        Me.txtPorcentaje.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(21, 15)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "%:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(524, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 15)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "Empresa Contable"
        '
        'lblEmpresaContable
        '
        Me.lblEmpresaContable.AutoSize = True
        Me.lblEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaContable.ForeColor = System.Drawing.Color.Maroon
        Me.lblEmpresaContable.Location = New System.Drawing.Point(526, 96)
        Me.lblEmpresaContable.Name = "lblEmpresaContable"
        Me.lblEmpresaContable.Size = New System.Drawing.Size(250, 25)
        Me.lblEmpresaContable.TabIndex = 115
        Me.lblEmpresaContable.Text = "EMPRESA CONTABLE"
        '
        'lvRetencion
        '
        Me.lvRetencion.AllowColumnReorder = True
        Me.lvRetencion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detRete_nro, Me.detRete_idCompra, Me.detRete_factura, Me.detRete_total, Me.detRete_fecha, Me.detRete_sucursal, Me.detRete_retencion})
        Me.lvRetencion.FullRowSelect = True
        Me.lvRetencion.GridLines = True
        Me.lvRetencion.HideSelection = False
        Me.lvRetencion.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvRetencion.LabelWrap = False
        Me.lvRetencion.Location = New System.Drawing.Point(8, 144)
        Me.lvRetencion.MultiSelect = False
        Me.lvRetencion.Name = "lvRetencion"
        Me.lvRetencion.Size = New System.Drawing.Size(666, 199)
        Me.lvRetencion.TabIndex = 116
        Me.lvRetencion.UseCompatibleStateImageBehavior = False
        Me.lvRetencion.View = System.Windows.Forms.View.Details
        '
        'detRete_nro
        '
        Me.detRete_nro.Text = "Nro."
        Me.detRete_nro.Width = 40
        '
        'detRete_idCompra
        '
        Me.detRete_idCompra.Text = "idCompra"
        '
        'detRete_factura
        '
        Me.detRete_factura.Text = "Factura"
        Me.detRete_factura.Width = 110
        '
        'detRete_total
        '
        Me.detRete_total.Text = "Total"
        Me.detRete_total.Width = 80
        '
        'detRete_fecha
        '
        Me.detRete_fecha.Text = "Fecha"
        Me.detRete_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detRete_fecha.Width = 90
        '
        'detRete_sucursal
        '
        Me.detRete_sucursal.Text = "Sucursal"
        Me.detRete_sucursal.Width = 200
        '
        'detRete_retencion
        '
        Me.detRete_retencion.Text = "Retencion"
        Me.detRete_retencion.Width = 80
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTotalRetencion)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtTotalIva)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtIva10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtIva5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 349)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(495, 73)
        Me.GroupBox3.TabIndex = 117
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Total Retención"
        '
        'txtTotalRetencion
        '
        Me.txtTotalRetencion.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalRetencion.Enabled = False
        Me.txtTotalRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRetencion.Location = New System.Drawing.Point(352, 34)
        Me.txtTotalRetencion.Name = "txtTotalRetencion"
        Me.txtTotalRetencion.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalRetencion.TabIndex = 77
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(361, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 15)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Total Retención"
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
        'txtTimbrado
        '
        Me.txtTimbrado.BackColor = System.Drawing.Color.White
        Me.txtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimbrado.Location = New System.Drawing.Point(105, 29)
        Me.txtTimbrado.MaxLength = 9
        Me.txtTimbrado.Name = "txtTimbrado"
        Me.txtTimbrado.Size = New System.Drawing.Size(126, 21)
        Me.txtTimbrado.TabIndex = 82
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(11, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 15)
        Me.Label19.TabIndex = 83
        Me.Label19.Text = "Nro. Timbrado:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(56, 114)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 15)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Fecha:"
        '
        'txtFacturaN
        '
        Me.txtFacturaN.BackColor = System.Drawing.Color.White
        Me.txtFacturaN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacturaN.Location = New System.Drawing.Point(163, 83)
        Me.txtFacturaN.MaxLength = 7
        Me.txtFacturaN.Name = "txtFacturaN"
        Me.txtFacturaN.Size = New System.Drawing.Size(86, 21)
        Me.txtFacturaN.TabIndex = 3
        '
        'txtDcajaN
        '
        Me.txtDcajaN.BackColor = System.Drawing.Color.White
        Me.txtDcajaN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcajaN.Location = New System.Drawing.Point(114, 83)
        Me.txtDcajaN.MaxLength = 3
        Me.txtDcajaN.Name = "txtDcajaN"
        Me.txtDcajaN.Size = New System.Drawing.Size(43, 21)
        Me.txtDcajaN.TabIndex = 2
        '
        'txtDsucN
        '
        Me.txtDsucN.BackColor = System.Drawing.Color.White
        Me.txtDsucN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsucN.Location = New System.Drawing.Point(65, 83)
        Me.txtDsucN.MaxLength = 3
        Me.txtDsucN.Name = "txtDsucN"
        Me.txtDsucN.Size = New System.Drawing.Size(43, 21)
        Me.txtDsucN.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(92, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 15)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "Nro. de Comprobante"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtTimbrado)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtDsucN)
        Me.GroupBox2.Controls.Add(Me.txtDcajaN)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtFacturaN)
        Me.GroupBox2.Location = New System.Drawing.Point(695, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(295, 142)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de la Retención"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(102, 113)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(108, 20)
        Me.dtpDesdeFecha.TabIndex = 95
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(587, 353)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 120
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
        Me.btnCancelar.Location = New System.Drawing.Point(812, 353)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(69, 37)
        Me.btnCancelar.TabIndex = 123
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(737, 353)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 122
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(662, 353)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 37)
        Me.btnAgregar.TabIndex = 121
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(511, 353)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(69, 37)
        Me.btnNuevo.TabIndex = 119
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmRetencionProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 437)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lvRetencion)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblEmpresaContable)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimizeBox = False
        Me.Name = "frmRetencionProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retención - IVA Compra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents lblIdCompra As System.Windows.Forms.Label
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTipoCompra As System.Windows.Forms.Label
    Friend WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresaContable As System.Windows.Forms.Label
    Friend WithEvents lvRetencion As System.Windows.Forms.ListView
    Friend WithEvents detRete_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents detRete_idCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents detRete_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents detRete_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents detRete_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents detRete_sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents detRete_retencion As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalRetencion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIva As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtIva10 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIva5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFacturaN As System.Windows.Forms.TextBox
    Friend WithEvents txtDcajaN As System.Windows.Forms.TextBox
    Friend WithEvents txtDsucN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
End Class
