<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaGasto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaGasto))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTipoEmpresa = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtResponsableCarga = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdGasto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblControlado = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblTipoCompra = New System.Windows.Forms.Label()
        Me.lvDetalleCompra = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblPagado = New System.Windows.Forms.Label()
        Me.lblCotiza = New System.Windows.Forms.Label()
        Me.chkNoImpreso = New System.Windows.Forms.CheckBox()
        Me.lblEmpresaContable = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New System.Windows.Forms.TextBox()
        Me.txtIva5 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIva10 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTotalFactura = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblNoImpreso = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtExplica = New System.Windows.Forms.TextBox()
        Me.txtFechaAnulado = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAnuladoPor = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTipoEmpresa)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFechaHora)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtResponsableCarga)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFechaFactura)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.txtDcaja)
        Me.GroupBox1.Controls.Add(Me.txtDsuc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIdGasto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 206)
        Me.GroupBox1.TabIndex = 135
        Me.GroupBox1.TabStop = False
        '
        'lblTipoEmpresa
        '
        Me.lblTipoEmpresa.AutoSize = True
        Me.lblTipoEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoEmpresa.ForeColor = System.Drawing.Color.Crimson
        Me.lblTipoEmpresa.Location = New System.Drawing.Point(267, 25)
        Me.lblTipoEmpresa.Name = "lblTipoEmpresa"
        Me.lblTipoEmpresa.Size = New System.Drawing.Size(131, 18)
        Me.lblTipoEmpresa.TabIndex = 105
        Me.lblTipoEmpresa.Text = "TIPO EMPRESA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(183, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 15)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "Tipo Empresa:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(265, 103)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(89, 21)
        Me.TextBox1.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(186, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 15)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Vencimiento:"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Maroon
        Me.lblEstado.Location = New System.Drawing.Point(54, 178)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(104, 25)
        Me.lblEstado.TabIndex = 15
        Me.lblEstado.Text = "ESTADO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Estado:"
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Enabled = False
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(113, 157)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(177, 21)
        Me.txtFechaHora.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(2, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha/Hora Carga:"
        '
        'txtResponsableCarga
        '
        Me.txtResponsableCarga.BackColor = System.Drawing.Color.LightBlue
        Me.txtResponsableCarga.Enabled = False
        Me.txtResponsableCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponsableCarga.Location = New System.Drawing.Point(90, 130)
        Me.txtResponsableCarga.Name = "txtResponsableCarga"
        Me.txtResponsableCarga.Size = New System.Drawing.Size(342, 21)
        Me.txtResponsableCarga.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Resp. Carga:"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFactura.Location = New System.Drawing.Point(90, 103)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.Size = New System.Drawing.Size(92, 21)
        Me.txtFechaFactura.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 103)
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
        Me.txtFactura.Location = New System.Drawing.Point(188, 77)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(86, 21)
        Me.txtFactura.TabIndex = 7
        '
        'txtDcaja
        '
        Me.txtDcaja.BackColor = System.Drawing.Color.LightBlue
        Me.txtDcaja.Enabled = False
        Me.txtDcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcaja.Location = New System.Drawing.Point(139, 77)
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(43, 21)
        Me.txtDcaja.TabIndex = 6
        '
        'txtDsuc
        '
        Me.txtDsuc.BackColor = System.Drawing.Color.LightBlue
        Me.txtDsuc.Enabled = False
        Me.txtDsuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsuc.Location = New System.Drawing.Point(90, 77)
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(43, 21)
        Me.txtDsuc.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 77)
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
        Me.txtProveedor.Location = New System.Drawing.Point(90, 50)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(342, 21)
        Me.txtProveedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proveedor:"
        '
        'txtIdGasto
        '
        Me.txtIdGasto.BackColor = System.Drawing.Color.Lime
        Me.txtIdGasto.Enabled = False
        Me.txtIdGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdGasto.Location = New System.Drawing.Point(90, 23)
        Me.txtIdGasto.Name = "txtIdGasto"
        Me.txtIdGasto.Size = New System.Drawing.Size(76, 24)
        Me.txtIdGasto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Gasto:"
        '
        'lblControlado
        '
        Me.lblControlado.AutoSize = True
        Me.lblControlado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControlado.ForeColor = System.Drawing.Color.Indigo
        Me.lblControlado.Location = New System.Drawing.Point(6, 98)
        Me.lblControlado.Name = "lblControlado"
        Me.lblControlado.Size = New System.Drawing.Size(169, 25)
        Me.lblControlado.TabIndex = 24
        Me.lblControlado.Text = "CONTROLADO"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Concepto"
        Me.ColumnHeader1.Width = 350
        '
        'lblTipoCompra
        '
        Me.lblTipoCompra.AutoSize = True
        Me.lblTipoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCompra.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblTipoCompra.Location = New System.Drawing.Point(147, 72)
        Me.lblTipoCompra.Name = "lblTipoCompra"
        Me.lblTipoCompra.Size = New System.Drawing.Size(162, 25)
        Me.lblTipoCompra.TabIndex = 23
        Me.lblTipoCompra.Text = "TIPOCOMPRA"
        '
        'lvDetalleCompra
        '
        Me.lvDetalleCompra.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader7})
        Me.lvDetalleCompra.Location = New System.Drawing.Point(6, 25)
        Me.lvDetalleCompra.Name = "lvDetalleCompra"
        Me.lvDetalleCompra.Size = New System.Drawing.Size(477, 175)
        Me.lvDetalleCompra.TabIndex = 0
        Me.lvDetalleCompra.UseCompatibleStateImageBehavior = False
        Me.lvDetalleCompra.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "%IVA"
        Me.ColumnHeader4.Width = 40
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Costo"
        Me.ColumnHeader7.Width = 80
        '
        'lblPagado
        '
        Me.lblPagado.AutoSize = True
        Me.lblPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagado.ForeColor = System.Drawing.Color.Green
        Me.lblPagado.Location = New System.Drawing.Point(8, 73)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(107, 25)
        Me.lblPagado.TabIndex = 16
        Me.lblPagado.Text = "PAGADO"
        '
        'lblCotiza
        '
        Me.lblCotiza.AutoSize = True
        Me.lblCotiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotiza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCotiza.Location = New System.Drawing.Point(318, 49)
        Me.lblCotiza.Name = "lblCotiza"
        Me.lblCotiza.Size = New System.Drawing.Size(57, 18)
        Me.lblCotiza.TabIndex = 22
        Me.lblCotiza.Text = "Cotiza"
        '
        'chkNoImpreso
        '
        Me.chkNoImpreso.AutoSize = True
        Me.chkNoImpreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoImpreso.Location = New System.Drawing.Point(86, 2)
        Me.chkNoImpreso.Name = "chkNoImpreso"
        Me.chkNoImpreso.Size = New System.Drawing.Size(78, 24)
        Me.chkNoImpreso.TabIndex = 146
        Me.chkNoImpreso.Text = "N/ Imp."
        Me.chkNoImpreso.UseVisualStyleBackColor = True
        '
        'lblEmpresaContable
        '
        Me.lblEmpresaContable.AutoSize = True
        Me.lblEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaContable.ForeColor = System.Drawing.Color.Maroon
        Me.lblEmpresaContable.Location = New System.Drawing.Point(121, 458)
        Me.lblEmpresaContable.Name = "lblEmpresaContable"
        Me.lblEmpresaContable.Size = New System.Drawing.Size(250, 25)
        Me.lblEmpresaContable.TabIndex = 139
        Me.lblEmpresaContable.Text = "EMPRESA CONTABLE"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 460)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 15)
        Me.Label15.TabIndex = 138
        Me.Label15.Text = "Empresa Contable:"
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackColor = System.Drawing.Color.PaleGreen
        Me.txtTotalIva.Enabled = False
        Me.txtTotalIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.Location = New System.Drawing.Point(758, 260)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.Size = New System.Drawing.Size(127, 24)
        Me.txtTotalIva.TabIndex = 144
        '
        'txtIva5
        '
        Me.txtIva5.BackColor = System.Drawing.Color.Moccasin
        Me.txtIva5.Enabled = False
        Me.txtIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva5.Location = New System.Drawing.Point(625, 273)
        Me.txtIva5.Name = "txtIva5"
        Me.txtIva5.Size = New System.Drawing.Size(127, 24)
        Me.txtIva5.TabIndex = 143
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(532, 276)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 142
        Me.Label13.Text = "Total IVA 5%:"
        '
        'txtIva10
        '
        Me.txtIva10.BackColor = System.Drawing.Color.Moccasin
        Me.txtIva10.Enabled = False
        Me.txtIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva10.Location = New System.Drawing.Point(626, 245)
        Me.txtIva10.Name = "txtIva10"
        Me.txtIva10.Size = New System.Drawing.Size(127, 24)
        Me.txtIva10.TabIndex = 141
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(533, 248)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 15)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "Total IVA 10%:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lvDetalleCompra)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 235)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(505, 209)
        Me.GroupBox3.TabIndex = 137
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de la Compra"
        '
        'txtTotalFactura
        '
        Me.txtTotalFactura.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFactura.Location = New System.Drawing.Point(121, 36)
        Me.txtTotalFactura.Name = "txtTotalFactura"
        Me.txtTotalFactura.ReadOnly = True
        Me.txtTotalFactura.Size = New System.Drawing.Size(127, 26)
        Me.txtTotalFactura.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(251, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Cotización:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnImprimir)
        Me.GroupBox2.Controls.Add(Me.btnAnular)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.btnUltimo)
        Me.GroupBox2.Controls.Add(Me.btnSiguiente)
        Me.GroupBox2.Controls.Add(Me.btnAnterior)
        Me.GroupBox2.Controls.Add(Me.btnPrimero)
        Me.GroupBox2.Controls.Add(Me.lblControlado)
        Me.GroupBox2.Controls.Add(Me.lblTipoCompra)
        Me.GroupBox2.Controls.Add(Me.lblPagado)
        Me.GroupBox2.Controls.Add(Me.lblCotiza)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblMoneda)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtTotalFactura)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(493, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 225)
        Me.GroupBox2.TabIndex = 136
        Me.GroupBox2.TabStop = False
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMoneda.Location = New System.Drawing.Point(300, 23)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(68, 18)
        Me.lblMoneda.TabIndex = 20
        Me.lblMoneda.Text = "Moneda"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(247, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Moneda:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 18)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total Gasto:"
        '
        'lblNoImpreso
        '
        Me.lblNoImpreso.AutoSize = True
        Me.lblNoImpreso.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoImpreso.ForeColor = System.Drawing.Color.Crimson
        Me.lblNoImpreso.Location = New System.Drawing.Point(13, 1)
        Me.lblNoImpreso.Name = "lblNoImpreso"
        Me.lblNoImpreso.Size = New System.Drawing.Size(70, 23)
        Me.lblNoImpreso.TabIndex = 145
        Me.lblNoImpreso.Text = "N/ IMP."
        Me.lblNoImpreso.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtExplica)
        Me.GroupBox7.Controls.Add(Me.txtFechaAnulado)
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.txtAnuladoPor)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Location = New System.Drawing.Point(518, 301)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(470, 93)
        Me.GroupBox7.TabIndex = 148
        Me.GroupBox7.TabStop = False
        '
        'txtExplica
        '
        Me.txtExplica.BackColor = System.Drawing.Color.LightCoral
        Me.txtExplica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExplica.Location = New System.Drawing.Point(8, 47)
        Me.txtExplica.Multiline = True
        Me.txtExplica.Name = "txtExplica"
        Me.txtExplica.ReadOnly = True
        Me.txtExplica.Size = New System.Drawing.Size(454, 39)
        Me.txtExplica.TabIndex = 85
        '
        'txtFechaAnulado
        '
        Me.txtFechaAnulado.BackColor = System.Drawing.Color.LightCoral
        Me.txtFechaAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaAnulado.Location = New System.Drawing.Point(255, 25)
        Me.txtFechaAnulado.Name = "txtFechaAnulado"
        Me.txtFechaAnulado.ReadOnly = True
        Me.txtFechaAnulado.Size = New System.Drawing.Size(172, 21)
        Me.txtFechaAnulado.TabIndex = 84
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(255, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 15)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Fecha/Hora - Anulado"
        '
        'txtAnuladoPor
        '
        Me.txtAnuladoPor.BackColor = System.Drawing.Color.LightCoral
        Me.txtAnuladoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnuladoPor.Location = New System.Drawing.Point(7, 25)
        Me.txtAnuladoPor.Name = "txtAnuladoPor"
        Me.txtAnuladoPor.ReadOnly = True
        Me.txtAnuladoPor.Size = New System.Drawing.Size(243, 21)
        Me.txtAnuladoPor.TabIndex = 82
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 15)
        Me.Label22.TabIndex = 81
        Me.Label22.Text = "Anulado Por"
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(252, 173)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 75
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnular.Location = New System.Drawing.Point(177, 173)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(69, 37)
        Me.btnAnular.TabIndex = 74
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(102, 173)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 73
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnUltimo
        '
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Image = CType(resources.GetObject("btnUltimo.Image"), System.Drawing.Image)
        Me.btnUltimo.Location = New System.Drawing.Point(293, 129)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(69, 37)
        Me.btnUltimo.TabIndex = 72
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguiente.Enabled = False
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(218, 129)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(69, 37)
        Me.btnSiguiente.TabIndex = 71
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(143, 129)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(69, 37)
        Me.btnAnterior.TabIndex = 70
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(68, 129)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(69, 37)
        Me.btnPrimero.TabIndex = 69
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'frmConsultaGasto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 493)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkNoImpreso)
        Me.Controls.Add(Me.lblEmpresaContable)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtTotalIva)
        Me.Controls.Add(Me.txtIva5)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtIva10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblNoImpreso)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaGasto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Gastos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtResponsableCarga As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdGasto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblControlado As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTipoCompra As System.Windows.Forms.Label
    Friend WithEvents lvDetalleCompra As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents lblCotiza As System.Windows.Forms.Label
    Friend WithEvents chkNoImpreso As System.Windows.Forms.CheckBox
    Friend WithEvents lblEmpresaContable As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIva As System.Windows.Forms.TextBox
    Friend WithEvents txtIva5 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtIva10 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNoImpreso As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtExplica As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAnulado As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAnuladoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblTipoEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
End Class
