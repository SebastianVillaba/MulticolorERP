<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificarVence
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificarVence))
        Me.lblNro = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.lblDeposito = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.maskVence2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLote2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdStock1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIdDeposito = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdDeposito = New System.Windows.Forms.TextBox()
        Me.maskVence1 = New System.Windows.Forms.MaskedTextBox()
        Me.lblCodigoProducto = New System.Windows.Forms.Label()
        Me.lblNombreProducto = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLote1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDeposito = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtDivision = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLaboratorio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvModiVence = New System.Windows.Forms.ListView()
        Me.det_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_lote1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_vence1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_idStock1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_stock1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_lote2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_vence2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_idStock2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNro
        '
        Me.lblNro.AutoSize = True
        Me.lblNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNro.ForeColor = System.Drawing.Color.Maroon
        Me.lblNro.Location = New System.Drawing.Point(530, 46)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(30, 16)
        Me.lblNro.TabIndex = 67
        Me.lblNro.Text = "Nro"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSql)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.lblDeposito)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProveedor)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.maskVence2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtLote2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtStock)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblIdStock1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblIdDeposito)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIdDeposito)
        Me.GroupBox1.Controls.Add(Me.maskVence1)
        Me.GroupBox1.Controls.Add(Me.lblCodigoProducto)
        Me.GroupBox1.Controls.Add(Me.lblNombreProducto)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtLote1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDeposito)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(809, 119)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(310, 91)
        Me.txtSql.MaxLength = 50
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(492, 22)
        Me.txtSql.TabIndex = 88
        Me.txtSql.TabStop = False
        Me.txtSql.Visible = False
        '
        'lblDeposito
        '
        Me.lblDeposito.AutoSize = True
        Me.lblDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeposito.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDeposito.Location = New System.Drawing.Point(519, 76)
        Me.lblDeposito.Name = "lblDeposito"
        Me.lblDeposito.Size = New System.Drawing.Size(158, 18)
        Me.lblDeposito.TabIndex = 68
        Me.lblDeposito.Text = "Deposito - Sucursal"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(531, 60)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(119, 16)
        Me.Label31.TabIndex = 67
        Me.Label31.Text = "Deposito/Sucursal"
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.LightBlue
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(157, 70)
        Me.txtCantidad.MaxLength = 15
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(62, 22)
        Me.txtCantidad.TabIndex = 86
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(160, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Cantidad"
        '
        'maskVence2
        '
        Me.maskVence2.BackColor = System.Drawing.Color.LightBlue
        Me.maskVence2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maskVence2.Location = New System.Drawing.Point(100, 70)
        Me.maskVence2.Mask = "00/00"
        Me.maskVence2.Name = "maskVence2"
        Me.maskVence2.ReadOnly = True
        Me.maskVence2.Size = New System.Drawing.Size(46, 22)
        Me.maskVence2.TabIndex = 83
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(102, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Vence"
        '
        'txtLote2
        '
        Me.txtLote2.BackColor = System.Drawing.Color.LightBlue
        Me.txtLote2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLote2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote2.Location = New System.Drawing.Point(11, 70)
        Me.txtLote2.MaxLength = 15
        Me.txtLote2.Name = "txtLote2"
        Me.txtLote2.ReadOnly = True
        Me.txtLote2.Size = New System.Drawing.Size(85, 22)
        Me.txtLote2.TabIndex = 82
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 16)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Lote"
        '
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.Color.LightBlue
        Me.txtStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.Location = New System.Drawing.Point(744, 27)
        Me.txtStock.MaxLength = 15
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(55, 22)
        Me.txtStock.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(743, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Stock"
        '
        'lblIdStock1
        '
        Me.lblIdStock1.AutoSize = True
        Me.lblIdStock1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdStock1.ForeColor = System.Drawing.Color.Maroon
        Me.lblIdStock1.Location = New System.Drawing.Point(361, 73)
        Me.lblIdStock1.Name = "lblIdStock1"
        Me.lblIdStock1.Size = New System.Drawing.Size(60, 16)
        Me.lblIdStock1.TabIndex = 79
        Me.lblIdStock1.Text = "IdStock1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(310, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "IdStock:"
        '
        'lblIdDeposito
        '
        Me.lblIdDeposito.AutoSize = True
        Me.lblIdDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdDeposito.ForeColor = System.Drawing.Color.Maroon
        Me.lblIdDeposito.Location = New System.Drawing.Point(380, 53)
        Me.lblIdDeposito.Name = "lblIdDeposito"
        Me.lblIdDeposito.Size = New System.Drawing.Size(74, 16)
        Me.lblIdDeposito.TabIndex = 77
        Me.lblIdDeposito.Text = "IdDeposito"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(307, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "IdDeposito:"
        '
        'txtIdDeposito
        '
        Me.txtIdDeposito.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdDeposito.Location = New System.Drawing.Point(235, 28)
        Me.txtIdDeposito.MaxLength = 60
        Me.txtIdDeposito.Name = "txtIdDeposito"
        Me.txtIdDeposito.ReadOnly = True
        Me.txtIdDeposito.Size = New System.Drawing.Size(58, 22)
        Me.txtIdDeposito.TabIndex = 69
        '
        'maskVence1
        '
        Me.maskVence1.BackColor = System.Drawing.Color.LightBlue
        Me.maskVence1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maskVence1.Location = New System.Drawing.Point(659, 27)
        Me.maskVence1.Mask = "00/00/0000"
        Me.maskVence1.Name = "maskVence1"
        Me.maskVence1.ReadOnly = True
        Me.maskVence1.Size = New System.Drawing.Size(81, 22)
        Me.maskVence1.TabIndex = 14
        Me.maskVence1.ValidatingType = GetType(Date)
        '
        'lblCodigoProducto
        '
        Me.lblCodigoProducto.AutoSize = True
        Me.lblCodigoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoProducto.ForeColor = System.Drawing.Color.Maroon
        Me.lblCodigoProducto.Location = New System.Drawing.Point(12, 100)
        Me.lblCodigoProducto.Name = "lblCodigoProducto"
        Me.lblCodigoProducto.Size = New System.Drawing.Size(52, 16)
        Me.lblCodigoProducto.TabIndex = 60
        Me.lblCodigoProducto.Text = "Codigo"
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProducto.ForeColor = System.Drawing.Color.Maroon
        Me.lblNombreProducto.Location = New System.Drawing.Point(110, 100)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(133, 16)
        Me.lblNombreProducto.TabIndex = 59
        Me.lblNombreProducto.Text = "nombre del Producto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(677, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 16)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Vence"
        '
        'txtLote1
        '
        Me.txtLote1.BackColor = System.Drawing.Color.LightBlue
        Me.txtLote1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLote1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote1.Location = New System.Drawing.Point(579, 27)
        Me.txtLote1.MaxLength = 15
        Me.txtLote1.Name = "txtLote1"
        Me.txtLote1.ReadOnly = True
        Me.txtLote1.Size = New System.Drawing.Size(72, 22)
        Me.txtLote1.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(582, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 16)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Lote"
        '
        'txtProducto
        '
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(380, 28)
        Me.txtProducto.MaxLength = 50
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(194, 22)
        Me.txtProducto.TabIndex = 8
        Me.txtProducto.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(381, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Producto"
        '
        'txtDeposito
        '
        Me.txtDeposito.BackColor = System.Drawing.Color.LightBlue
        Me.txtDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeposito.Location = New System.Drawing.Point(8, 28)
        Me.txtDeposito.MaxLength = 60
        Me.txtDeposito.Name = "txtDeposito"
        Me.txtDeposito.ReadOnly = True
        Me.txtDeposito.Size = New System.Drawing.Size(220, 22)
        Me.txtDeposito.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Deposito"
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.Color.LightBlue
        Me.txtOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrigen.Location = New System.Drawing.Point(309, 40)
        Me.txtOrigen.MaxLength = 60
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(30, 22)
        Me.txtOrigen.TabIndex = 74
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.lblNro)
        Me.GroupBox2.Controls.Add(Me.txtOrigen)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtTipoProducto)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtDivision)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtLaboratorio)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(808, 89)
        Me.GroupBox2.TabIndex = 106
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Mercadería"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(260, 40)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(51, 16)
        Me.Label29.TabIndex = 73
        Me.Label29.Text = "Origen:"
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.BackColor = System.Drawing.Color.LightBlue
        Me.txtTipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoProducto.Location = New System.Drawing.Point(40, 38)
        Me.txtTipoProducto.MaxLength = 60
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ReadOnly = True
        Me.txtTipoProducto.Size = New System.Drawing.Size(221, 22)
        Me.txtTipoProducto.TabIndex = 72
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(2, 41)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(39, 16)
        Me.Label26.TabIndex = 71
        Me.Label26.Text = "Tipo:"
        '
        'txtDivision
        '
        Me.txtDivision.BackColor = System.Drawing.Color.LightBlue
        Me.txtDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDivision.Location = New System.Drawing.Point(400, 13)
        Me.txtDivision.MaxLength = 60
        Me.txtDivision.Name = "txtDivision"
        Me.txtDivision.ReadOnly = True
        Me.txtDivision.Size = New System.Drawing.Size(221, 22)
        Me.txtDivision.TabIndex = 62
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(343, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 16)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "Division:"
        '
        'txtLaboratorio
        '
        Me.txtLaboratorio.BackColor = System.Drawing.Color.LightBlue
        Me.txtLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaboratorio.Location = New System.Drawing.Point(91, 13)
        Me.txtLaboratorio.MaxLength = 60
        Me.txtLaboratorio.Name = "txtLaboratorio"
        Me.txtLaboratorio.ReadOnly = True
        Me.txtLaboratorio.Size = New System.Drawing.Size(241, 22)
        Me.txtLaboratorio.TabIndex = 60
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 16)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Laboratorio:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(821, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(153, 133)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'lvModiVence
        '
        Me.lvModiVence.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_nro, Me.det_codigo, Me.det_mercaderia, Me.det_lote1, Me.det_vence1, Me.det_idStock1, Me.det_stock1, Me.det_lote2, Me.det_vence2, Me.det_idStock2, Me.det_cantidad})
        Me.lvModiVence.Location = New System.Drawing.Point(64, 222)
        Me.lvModiVence.Name = "lvModiVence"
        Me.lvModiVence.Size = New System.Drawing.Size(852, 282)
        Me.lvModiVence.TabIndex = 108
        Me.lvModiVence.UseCompatibleStateImageBehavior = False
        Me.lvModiVence.View = System.Windows.Forms.View.Details
        '
        'det_nro
        '
        Me.det_nro.Text = "Nro."
        Me.det_nro.Width = 40
        '
        'det_codigo
        '
        Me.det_codigo.Text = "Codigo"
        '
        'det_mercaderia
        '
        Me.det_mercaderia.Text = "Mercaderia"
        Me.det_mercaderia.Width = 300
        '
        'det_lote1
        '
        Me.det_lote1.Text = "Lote1"
        '
        'det_vence1
        '
        Me.det_vence1.Text = "Vence1"
        Me.det_vence1.Width = 50
        '
        'det_idStock1
        '
        Me.det_idStock1.Text = "idStock1"
        '
        'det_stock1
        '
        Me.det_stock1.Text = "Stock1"
        '
        'det_lote2
        '
        Me.det_lote2.Text = "Lote2"
        '
        'det_vence2
        '
        Me.det_vence2.Text = "Vence2"
        Me.det_vence2.Width = 50
        '
        'det_idStock2
        '
        Me.det_idStock2.Text = "idStock2"
        Me.det_idStock2.Width = 55
        '
        'det_cantidad
        '
        Me.det_cantidad.Text = "Cant."
        Me.det_cantidad.Width = 50
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(363, 41)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 111
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(228, 57)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 37)
        Me.btnAgregar.TabIndex = 110
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarProveedor.Image = CType(resources.GetObject("btnBuscarProveedor.Image"), System.Drawing.Image)
        Me.btnBuscarProveedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(299, 13)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscarProveedor.TabIndex = 109
        Me.btnBuscarProveedor.Text = "&Buscar"
        Me.btnBuscarProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(438, 41)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 112
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'frmModificarVence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 514)
        Me.Controls.Add(Me.lvModiVence)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModificarVence"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de Lotes y Vencimientos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNro As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDeposito As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents maskVence2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLote2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIdStock1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIdDeposito As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdDeposito As System.Windows.Forms.TextBox
    Friend WithEvents maskVence1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCodigoProducto As System.Windows.Forms.Label
    Friend WithEvents lblNombreProducto As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLote1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDeposito As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtDivision As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvModiVence As System.Windows.Forms.ListView
    Friend WithEvents det_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_lote1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_vence1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_idStock1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_stock1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_lote2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_vence2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_idStock2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
End Class
