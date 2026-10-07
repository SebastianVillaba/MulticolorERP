<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCompra))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtExplica = New System.Windows.Forms.TextBox()
        Me.txtFechaAnulado = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAnuladoPor = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
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
        Me.txtIdCompra = New System.Windows.Forms.TextBox()
        Me.txtTotalDescuento = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalFactura = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTipoCompra = New System.Windows.Forms.Label()
        Me.lblPagado = New System.Windows.Forms.Label()
        Me.lblCotiza = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.lblTipoEmpresa = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grCanje = New System.Windows.Forms.GroupBox()
        Me.lvCompra = New System.Windows.Forms.ListView()
        Me.detCompra_idCanjeProveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_usuario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_fechaa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIva10 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIva5 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New System.Windows.Forms.TextBox()
        Me.lblEmpresaContable = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkNoImpreso = New System.Windows.Forms.CheckBox()
        Me.lblNoImpreso = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lvDetalleCompra = New System.Windows.Forms.ListView()
        Me.detCompra_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_producto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_forma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_porceIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_porcentaCompro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_costo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_boni = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_subTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_exenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_gravada5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_gravada10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtTimbrado = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grCanje.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTimbrado)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.txtFechaHora)
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
        Me.GroupBox1.Controls.Add(Me.txtIdCompra)
        Me.GroupBox1.Controls.Add(Me.txtTotalDescuento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtTotalFactura)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 22)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(683, 257)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtExplica)
        Me.GroupBox7.Controls.Add(Me.txtFechaAnulado)
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.txtAnuladoPor)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 146)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Size = New System.Drawing.Size(627, 111)
        Me.GroupBox7.TabIndex = 131
        Me.GroupBox7.TabStop = False
        '
        'txtExplica
        '
        Me.txtExplica.BackColor = System.Drawing.Color.LightCoral
        Me.txtExplica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExplica.Location = New System.Drawing.Point(11, 58)
        Me.txtExplica.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExplica.Multiline = True
        Me.txtExplica.Name = "txtExplica"
        Me.txtExplica.ReadOnly = True
        Me.txtExplica.Size = New System.Drawing.Size(604, 47)
        Me.txtExplica.TabIndex = 85
        '
        'txtFechaAnulado
        '
        Me.txtFechaAnulado.BackColor = System.Drawing.Color.LightCoral
        Me.txtFechaAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaAnulado.Location = New System.Drawing.Point(340, 31)
        Me.txtFechaAnulado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaAnulado.Name = "txtFechaAnulado"
        Me.txtFechaAnulado.ReadOnly = True
        Me.txtFechaAnulado.Size = New System.Drawing.Size(228, 24)
        Me.txtFechaAnulado.TabIndex = 84
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(340, 11)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(152, 18)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Fecha/Hora - Anulado"
        '
        'txtAnuladoPor
        '
        Me.txtAnuladoPor.BackColor = System.Drawing.Color.LightCoral
        Me.txtAnuladoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnuladoPor.Location = New System.Drawing.Point(9, 31)
        Me.txtAnuladoPor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAnuladoPor.Name = "txtAnuladoPor"
        Me.txtAnuladoPor.ReadOnly = True
        Me.txtAnuladoPor.Size = New System.Drawing.Size(323, 24)
        Me.txtAnuladoPor.TabIndex = 82
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(9, 11)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 18)
        Me.Label22.TabIndex = 81
        Me.Label22.Text = "Anulado Por"
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Enabled = False
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(433, 87)
        Me.txtFechaHora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(235, 24)
        Me.txtFechaHora.TabIndex = 13
        '
        'txtResponsableCarga
        '
        Me.txtResponsableCarga.BackColor = System.Drawing.Color.LightBlue
        Me.txtResponsableCarga.Enabled = False
        Me.txtResponsableCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponsableCarga.Location = New System.Drawing.Point(116, 87)
        Me.txtResponsableCarga.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtResponsableCarga.Name = "txtResponsableCarga"
        Me.txtResponsableCarga.Size = New System.Drawing.Size(308, 24)
        Me.txtResponsableCarga.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 87)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 18)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Resp. Carga:"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFactura.Location = New System.Drawing.Point(578, 54)
        Me.txtFechaFactura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.Size = New System.Drawing.Size(99, 24)
        Me.txtFechaFactura.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(469, 55)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha Factura:"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.LightBlue
        Me.txtFactura.Enabled = False
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(338, 52)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(96, 24)
        Me.txtFactura.TabIndex = 7
        '
        'txtDcaja
        '
        Me.txtDcaja.BackColor = System.Drawing.Color.LightBlue
        Me.txtDcaja.Enabled = False
        Me.txtDcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcaja.Location = New System.Drawing.Point(284, 52)
        Me.txtDcaja.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(48, 24)
        Me.txtDcaja.TabIndex = 6
        '
        'txtDsuc
        '
        Me.txtDsuc.BackColor = System.Drawing.Color.LightBlue
        Me.txtDsuc.Enabled = False
        Me.txtDsuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsuc.Location = New System.Drawing.Point(230, 52)
        Me.txtDsuc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(48, 24)
        Me.txtDsuc.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nro. Factura:"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(315, 21)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(305, 24)
        Me.txtProveedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(225, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proveedor:"
        '
        'txtIdCompra
        '
        Me.txtIdCompra.BackColor = System.Drawing.Color.Lime
        Me.txtIdCompra.Enabled = False
        Me.txtIdCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCompra.Location = New System.Drawing.Point(120, 17)
        Me.txtIdCompra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdCompra.Name = "txtIdCompra"
        Me.txtIdCompra.Size = New System.Drawing.Size(100, 29)
        Me.txtIdCompra.TabIndex = 1
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalDescuento.Enabled = False
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.Location = New System.Drawing.Point(441, 117)
        Me.txtTotalDescuento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.Size = New System.Drawing.Size(168, 29)
        Me.txtTotalDescuento.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Compra:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(309, 121)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 18)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Total Descuento:"
        '
        'txtTotalFactura
        '
        Me.txtTotalFactura.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalFactura.Enabled = False
        Me.txtTotalFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFactura.Location = New System.Drawing.Point(133, 121)
        Me.txtTotalFactura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalFactura.Name = "txtTotalFactura"
        Me.txtTotalFactura.Size = New System.Drawing.Size(168, 29)
        Me.txtTotalFactura.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 124)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total Compra:"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Maroon
        Me.lblEstado.Location = New System.Drawing.Point(89, 244)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(132, 31)
        Me.lblEstado.TabIndex = 15
        Me.lblEstado.Text = "ESTADO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 249)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 18)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Estado:"
        '
        'lblTipoCompra
        '
        Me.lblTipoCompra.AutoSize = True
        Me.lblTipoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCompra.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblTipoCompra.Location = New System.Drawing.Point(800, 631)
        Me.lblTipoCompra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoCompra.Name = "lblTipoCompra"
        Me.lblTipoCompra.Size = New System.Drawing.Size(207, 31)
        Me.lblTipoCompra.TabIndex = 23
        Me.lblTipoCompra.Text = "TIPOCOMPRA"
        '
        'lblPagado
        '
        Me.lblPagado.AutoSize = True
        Me.lblPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagado.ForeColor = System.Drawing.Color.Green
        Me.lblPagado.Location = New System.Drawing.Point(1024, 630)
        Me.lblPagado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(136, 31)
        Me.lblPagado.TabIndex = 16
        Me.lblPagado.Text = "PAGADO"
        '
        'lblCotiza
        '
        Me.lblCotiza.AutoSize = True
        Me.lblCotiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotiza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCotiza.Location = New System.Drawing.Point(376, 217)
        Me.lblCotiza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCotiza.Name = "lblCotiza"
        Me.lblCotiza.Size = New System.Drawing.Size(67, 24)
        Me.lblCotiza.TabIndex = 22
        Me.lblCotiza.Text = "Cotiza"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(280, 218)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 18)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Cotización:"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMoneda.Location = New System.Drawing.Point(101, 215)
        Me.lblMoneda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(86, 24)
        Me.lblMoneda.TabIndex = 20
        Me.lblMoneda.Text = "Moneda"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 217)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 18)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Moneda:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUltimo)
        Me.GroupBox2.Controls.Add(Me.btnSiguiente)
        Me.GroupBox2.Controls.Add(Me.btnAnterior)
        Me.GroupBox2.Controls.Add(Me.btnPrimero)
        Me.GroupBox2.Controls.Add(Me.lblTipoEmpresa)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.grCanje)
        Me.GroupBox2.Controls.Add(Me.lblCotiza)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblEstado)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblMoneda)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(701, 4)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(617, 277)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnUltimo
        '
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Image = CType(resources.GetObject("btnUltimo.Image"), System.Drawing.Image)
        Me.btnUltimo.Location = New System.Drawing.Point(396, 176)
        Me.btnUltimo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(92, 33)
        Me.btnUltimo.TabIndex = 107
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguiente.Enabled = False
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(296, 176)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(92, 33)
        Me.btnSiguiente.TabIndex = 106
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(196, 176)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(92, 33)
        Me.btnAnterior.TabIndex = 105
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(96, 176)
        Me.btnPrimero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(92, 33)
        Me.btnPrimero.TabIndex = 104
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'lblTipoEmpresa
        '
        Me.lblTipoEmpresa.AutoSize = True
        Me.lblTipoEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoEmpresa.ForeColor = System.Drawing.Color.Crimson
        Me.lblTipoEmpresa.Location = New System.Drawing.Point(392, 249)
        Me.lblTipoEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoEmpresa.Name = "lblTipoEmpresa"
        Me.lblTipoEmpresa.Size = New System.Drawing.Size(162, 24)
        Me.lblTipoEmpresa.TabIndex = 103
        Me.lblTipoEmpresa.Text = "TIPO EMPRESA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(280, 249)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 18)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Tipo Empresa:"
        '
        'grCanje
        '
        Me.grCanje.Controls.Add(Me.lvCompra)
        Me.grCanje.Location = New System.Drawing.Point(64, 11)
        Me.grCanje.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grCanje.Name = "grCanje"
        Me.grCanje.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grCanje.Size = New System.Drawing.Size(489, 158)
        Me.grCanje.TabIndex = 101
        Me.grCanje.TabStop = False
        Me.grCanje.Text = "Detalle de Nota de Crédito de Canjes"
        '
        'lvCompra
        '
        Me.lvCompra.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detCompra_idCanjeProveedor, Me.detCompra_factura, Me.detCompra_total, Me.detCompra_fecha, Me.detCompra_usuario, Me.detCompra_fechaa})
        Me.lvCompra.Location = New System.Drawing.Point(8, 21)
        Me.lvCompra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvCompra.Name = "lvCompra"
        Me.lvCompra.Size = New System.Drawing.Size(464, 126)
        Me.lvCompra.TabIndex = 1
        Me.lvCompra.UseCompatibleStateImageBehavior = False
        Me.lvCompra.View = System.Windows.Forms.View.Details
        '
        'detCompra_idCanjeProveedor
        '
        Me.detCompra_idCanjeProveedor.Text = "IdCanje"
        '
        'detCompra_factura
        '
        Me.detCompra_factura.Text = "Factura"
        Me.detCompra_factura.Width = 110
        '
        'detCompra_total
        '
        Me.detCompra_total.Text = "Total"
        Me.detCompra_total.Width = 90
        '
        'detCompra_fecha
        '
        Me.detCompra_fecha.Text = "Fecha"
        Me.detCompra_fecha.Width = 80
        '
        'detCompra_usuario
        '
        Me.detCompra_usuario.Text = "Responsable"
        Me.detCompra_usuario.Width = 200
        '
        'detCompra_fechaa
        '
        Me.detCompra_fechaa.Text = "Fecha/Hora"
        Me.detCompra_fechaa.Width = 90
        '
        'txtIva10
        '
        Me.txtIva10.BackColor = System.Drawing.Color.Moccasin
        Me.txtIva10.Enabled = False
        Me.txtIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva10.Location = New System.Drawing.Point(140, 596)
        Me.txtIva10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIva10.Name = "txtIva10"
        Me.txtIva10.Size = New System.Drawing.Size(168, 29)
        Me.txtIva10.TabIndex = 70
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 599)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 18)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Total IVA 10%:"
        '
        'txtIva5
        '
        Me.txtIva5.BackColor = System.Drawing.Color.Moccasin
        Me.txtIva5.Enabled = False
        Me.txtIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva5.Location = New System.Drawing.Point(139, 630)
        Me.txtIva5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIva5.Name = "txtIva5"
        Me.txtIva5.Size = New System.Drawing.Size(168, 29)
        Me.txtIva5.TabIndex = 72
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 634)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 18)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Total IVA 5%:"
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackColor = System.Drawing.Color.PaleGreen
        Me.txtTotalIva.Enabled = False
        Me.txtTotalIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.Location = New System.Drawing.Point(316, 614)
        Me.txtTotalIva.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.Size = New System.Drawing.Size(168, 29)
        Me.txtTotalIva.TabIndex = 73
        '
        'lblEmpresaContable
        '
        Me.lblEmpresaContable.AutoSize = True
        Me.lblEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaContable.ForeColor = System.Drawing.Color.Maroon
        Me.lblEmpresaContable.Location = New System.Drawing.Point(645, 588)
        Me.lblEmpresaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmpresaContable.Name = "lblEmpresaContable"
        Me.lblEmpresaContable.Size = New System.Drawing.Size(316, 31)
        Me.lblEmpresaContable.TabIndex = 17
        Me.lblEmpresaContable.Text = "EMPRESA CONTABLE"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(491, 591)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 18)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Empresa Contable:"
        '
        'chkNoImpreso
        '
        Me.chkNoImpreso.AutoSize = True
        Me.chkNoImpreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoImpreso.Location = New System.Drawing.Point(172, -1)
        Me.chkNoImpreso.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkNoImpreso.Name = "chkNoImpreso"
        Me.chkNoImpreso.Size = New System.Drawing.Size(96, 29)
        Me.chkNoImpreso.TabIndex = 134
        Me.chkNoImpreso.Text = "N/ Imp."
        Me.chkNoImpreso.UseVisualStyleBackColor = True
        '
        'lblNoImpreso
        '
        Me.lblNoImpreso.AutoSize = True
        Me.lblNoImpreso.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoImpreso.ForeColor = System.Drawing.Color.Crimson
        Me.lblNoImpreso.Location = New System.Drawing.Point(60, 0)
        Me.lblNoImpreso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNoImpreso.Name = "lblNoImpreso"
        Me.lblNoImpreso.Size = New System.Drawing.Size(86, 28)
        Me.lblNoImpreso.TabIndex = 133
        Me.lblNoImpreso.Text = "N/ IMP."
        Me.lblNoImpreso.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lvDetalleCompra)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 282)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(1492, 305)
        Me.GroupBox3.TabIndex = 138
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de la Compra"
        '
        'lvDetalleCompra
        '
        Me.lvDetalleCompra.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detCompra_codigo, Me.detCompra_producto, Me.detCompra_forma, Me.detCompra_porceIva, Me.detCompra_porcentaCompro, Me.detCompra_lote, Me.detCompra_vence, Me.detCompra_precio, Me.detCompra_costo, Me.detCompra_cantidad, Me.detCompra_boni, Me.detCompra_subTotal, Me.detCompra_exenta, Me.detCompra_gravada5, Me.detCompra_gravada10})
        Me.lvDetalleCompra.Location = New System.Drawing.Point(8, 31)
        Me.lvDetalleCompra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvDetalleCompra.Name = "lvDetalleCompra"
        Me.lvDetalleCompra.Size = New System.Drawing.Size(1451, 270)
        Me.lvDetalleCompra.TabIndex = 0
        Me.lvDetalleCompra.UseCompatibleStateImageBehavior = False
        Me.lvDetalleCompra.View = System.Windows.Forms.View.Details
        '
        'detCompra_codigo
        '
        Me.detCompra_codigo.Text = "Codigo"
        '
        'detCompra_producto
        '
        Me.detCompra_producto.Text = "Producto"
        Me.detCompra_producto.Width = 300
        '
        'detCompra_forma
        '
        Me.detCompra_forma.Text = "Forma"
        Me.detCompra_forma.Width = 80
        '
        'detCompra_porceIva
        '
        Me.detCompra_porceIva.Text = "%IVA"
        Me.detCompra_porceIva.Width = 40
        '
        'detCompra_porcentaCompro
        '
        Me.detCompra_porcentaCompro.Text = "%"
        Me.detCompra_porcentaCompro.Width = 50
        '
        'detCompra_lote
        '
        Me.detCompra_lote.Text = "Lote"
        Me.detCompra_lote.Width = 55
        '
        'detCompra_vence
        '
        Me.detCompra_vence.Text = "Ven."
        Me.detCompra_vence.Width = 40
        '
        'detCompra_precio
        '
        Me.detCompra_precio.Text = "Precio"
        '
        'detCompra_costo
        '
        Me.detCompra_costo.Text = "Costo"
        '
        'detCompra_cantidad
        '
        Me.detCompra_cantidad.Text = "Cant."
        Me.detCompra_cantidad.Width = 40
        '
        'detCompra_boni
        '
        Me.detCompra_boni.Text = "Boni"
        Me.detCompra_boni.Width = 40
        '
        'detCompra_subTotal
        '
        Me.detCompra_subTotal.Text = "SubTotal"
        Me.detCompra_subTotal.Width = 70
        '
        'detCompra_exenta
        '
        Me.detCompra_exenta.Text = "Exenta"
        '
        'detCompra_gravada5
        '
        Me.detCompra_gravada5.Text = "Grav. 5%"
        '
        'detCompra_gravada10
        '
        Me.detCompra_gravada10.Text = "Grav. 10%"
        Me.detCompra_gravada10.Width = 65
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(709, 618)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(92, 46)
        Me.btnImprimir.TabIndex = 71
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnular.Location = New System.Drawing.Point(609, 618)
        Me.btnAnular.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(92, 46)
        Me.btnAnular.TabIndex = 70
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(509, 618)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscar.TabIndex = 69
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtTimbrado
        '
        Me.txtTimbrado.BackColor = System.Drawing.Color.LightBlue
        Me.txtTimbrado.Enabled = False
        Me.txtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimbrado.Location = New System.Drawing.Point(106, 53)
        Me.txtTimbrado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTimbrado.Name = "txtTimbrado"
        Me.txtTimbrado.Size = New System.Drawing.Size(106, 24)
        Me.txtTimbrado.TabIndex = 132
        '
        'frmConsultaCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1505, 673)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.chkNoImpreso)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblEmpresaContable)
        Me.Controls.Add(Me.lblNoImpreso)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblTipoCompra)
        Me.Controls.Add(Me.txtTotalIva)
        Me.Controls.Add(Me.txtIva5)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblPagado)
        Me.Controls.Add(Me.txtIva10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Factura de Compra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grCanje.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents txtResponsableCarga As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents lblCotiza As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTipoCompra As System.Windows.Forms.Label
    Friend WithEvents txtIva10 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIva5 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIva As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpresaContable As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkNoImpreso As System.Windows.Forms.CheckBox
    Friend WithEvents lblNoImpreso As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtExplica As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAnulado As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAnuladoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents grCanje As System.Windows.Forms.GroupBox
    Friend WithEvents lvCompra As System.Windows.Forms.ListView
    Friend WithEvents detCompra_idCanjeProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_usuario As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_fechaa As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvDetalleCompra As System.Windows.Forms.ListView
    Friend WithEvents detCompra_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_producto As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_forma As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_porceIva As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_porcentaCompro As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_costo As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_boni As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_subTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTipoEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents detCompra_exenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_gravada5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_gravada10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTimbrado As System.Windows.Forms.TextBox
End Class
