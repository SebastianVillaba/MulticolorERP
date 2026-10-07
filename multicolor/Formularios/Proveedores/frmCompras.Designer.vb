<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompras))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.txtGravada10 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtGravada5 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtTimbrado = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtPorcentajeCosto = New System.Windows.Forms.TextBox()
        Me.txtCotizacion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIDProveedor = New System.Windows.Forms.TextBox()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.maskVence = New System.Windows.Forms.MaskedTextBox()
        Me.lblUltCosto = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblCodigoProducto = New System.Windows.Forms.Label()
        Me.lblNombreProducto = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFraccion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtExenta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBoni = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblDeposito = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtFechaPedido = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCantidadPedido = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtNroPedido = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPedidopor = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLaboratorio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblIdProducto = New System.Windows.Forms.Label()
        Me.lblNro = New System.Windows.Forms.Label()
        Me.txtTotalFactura = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtIVA10 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtIva5 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblControlPedido = New System.Windows.Forms.Label()
        Me.lvCompra = New System.Windows.Forms.ListView()
        Me.detCompra_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_forma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_boni = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_exenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_gravada5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_gravada10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_costoTot = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_porceIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCompra_porce = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnPorcentaje = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnReutilizar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSql)
        Me.GroupBox1.Controls.Add(Me.txtGravada10)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.txtGravada5)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDsuc)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProveedor)
        Me.GroupBox1.Controls.Add(Me.txtDcaja)
        Me.GroupBox1.Controls.Add(Me.txtTimbrado)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.txtPorcentajeCosto)
        Me.GroupBox1.Controls.Add(Me.txtCotizacion)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.txtNota)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIDProveedor)
        Me.GroupBox1.Controls.Add(Me.lblCantidad)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.maskVence)
        Me.GroupBox1.Controls.Add(Me.lblUltCosto)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.lblPrecio)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.lblCodigoProducto)
        Me.GroupBox1.Controls.Add(Me.lblNombreProducto)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtLote)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtFraccion)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtExenta)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cboMoneda)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtBoni)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtResponsable)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(16, -4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1412, 183)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(733, 148)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSql.MaxLength = 50
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(649, 26)
        Me.txtSql.TabIndex = 111
        Me.txtSql.TabStop = False
        Me.txtSql.Visible = False
        '
        'txtGravada10
        '
        Me.txtGravada10.BackColor = System.Drawing.Color.DarkTurquoise
        Me.txtGravada10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGravada10.Location = New System.Drawing.Point(1023, 85)
        Me.txtGravada10.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGravada10.MaxLength = 15
        Me.txtGravada10.Name = "txtGravada10"
        Me.txtGravada10.Size = New System.Drawing.Size(112, 26)
        Me.txtGravada10.TabIndex = 109
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(1023, 64)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(110, 20)
        Me.Label33.TabIndex = 110
        Me.Label33.Text = "Gravada 10%"
        '
        'txtGravada5
        '
        Me.txtGravada5.BackColor = System.Drawing.Color.Pink
        Me.txtGravada5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGravada5.Location = New System.Drawing.Point(877, 86)
        Me.txtGravada5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGravada5.MaxLength = 15
        Me.txtGravada5.Name = "txtGravada5"
        Me.txtGravada5.Size = New System.Drawing.Size(112, 26)
        Me.txtGravada5.TabIndex = 107
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(877, 65)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(101, 20)
        Me.Label32.TabIndex = 108
        Me.Label32.Text = "Gravada 5%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(657, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Factura"
        '
        'txtDsuc
        '
        Me.txtDsuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsuc.Location = New System.Drawing.Point(617, 33)
        Me.txtDsuc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDsuc.MaxLength = 3
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(40, 26)
        Me.txtDsuc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(508, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Timbrado"
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(627, 137)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(92, 46)
        Me.btnAgregar.TabIndex = 106
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarProveedor.Image = CType(resources.GetObject("btnBuscarProveedor.Image"), System.Drawing.Image)
        Me.btnBuscarProveedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(395, 23)
        Me.btnBuscarProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscarProveedor.TabIndex = 105
        Me.btnBuscarProveedor.Text = "&Buscar"
        Me.btnBuscarProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtDcaja
        '
        Me.txtDcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcaja.Location = New System.Drawing.Point(663, 33)
        Me.txtDcaja.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDcaja.MaxLength = 3
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(40, 26)
        Me.txtDcaja.TabIndex = 1
        '
        'txtTimbrado
        '
        Me.txtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimbrado.Location = New System.Drawing.Point(489, 33)
        Me.txtTimbrado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTimbrado.MaxLength = 8
        Me.txtTimbrado.Name = "txtTimbrado"
        Me.txtTimbrado.Size = New System.Drawing.Size(120, 26)
        Me.txtTimbrado.TabIndex = 3
        '
        'txtFactura
        '
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(709, 34)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFactura.MaxLength = 7
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(88, 26)
        Me.txtFactura.TabIndex = 2
        '
        'txtPorcentajeCosto
        '
        Me.txtPorcentajeCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentajeCosto.Location = New System.Drawing.Point(460, 87)
        Me.txtPorcentajeCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPorcentajeCosto.MaxLength = 10
        Me.txtPorcentajeCosto.Name = "txtPorcentajeCosto"
        Me.txtPorcentajeCosto.Size = New System.Drawing.Size(57, 26)
        Me.txtPorcentajeCosto.TabIndex = 9
        '
        'txtCotizacion
        '
        Me.txtCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCotizacion.Location = New System.Drawing.Point(12, 87)
        Me.txtCotizacion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCotizacion.MaxLength = 15
        Me.txtCotizacion.Name = "txtCotizacion"
        Me.txtCotizacion.Size = New System.Drawing.Size(112, 26)
        Me.txtCotizacion.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 66)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 20)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Cotización"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(444, 66)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(84, 20)
        Me.Label30.TabIndex = 74
        Me.Label30.Text = "% S/Cost."
        '
        'txtNota
        '
        Me.txtNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNota.Location = New System.Drawing.Point(567, 151)
        Me.txtNota.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNota.MaxLength = 1
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(43, 26)
        Me.txtNota.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(525, 155)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 20)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Ncr"
        '
        'txtIDProveedor
        '
        Me.txtIDProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtIDProveedor.Enabled = False
        Me.txtIDProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDProveedor.Location = New System.Drawing.Point(309, 34)
        Me.txtIDProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDProveedor.MaxLength = 60
        Me.txtIDProveedor.Name = "txtIDProveedor"
        Me.txtIDProveedor.Size = New System.Drawing.Size(76, 26)
        Me.txtIDProveedor.TabIndex = 69
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.Color.Maroon
        Me.lblCantidad.Location = New System.Drawing.Point(1112, 117)
        Me.lblCantidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(44, 20)
        Me.lblCantidad.TabIndex = 66
        Me.lblCantidad.Text = "Cant"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(1061, 117)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 20)
        Me.Label28.TabIndex = 65
        Me.Label28.Text = "Cant.:"
        '
        'maskVence
        '
        Me.maskVence.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maskVence.Location = New System.Drawing.Point(463, 151)
        Me.maskVence.Margin = New System.Windows.Forms.Padding(4)
        Me.maskVence.Mask = "00/00"
        Me.maskVence.Name = "maskVence"
        Me.maskVence.Size = New System.Drawing.Size(60, 26)
        Me.maskVence.TabIndex = 14
        '
        'lblUltCosto
        '
        Me.lblUltCosto.AutoSize = True
        Me.lblUltCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltCosto.ForeColor = System.Drawing.Color.Maroon
        Me.lblUltCosto.Location = New System.Drawing.Point(968, 117)
        Me.lblUltCosto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltCosto.Name = "lblUltCosto"
        Me.lblUltCosto.Size = New System.Drawing.Size(74, 20)
        Me.lblUltCosto.TabIndex = 64
        Me.lblUltCosto.Text = "UltCosto"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(876, 117)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 20)
        Me.Label27.TabIndex = 63
        Me.Label27.Text = "Ult. Costo:"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.ForeColor = System.Drawing.Color.Maroon
        Me.lblPrecio.Location = New System.Drawing.Point(733, 117)
        Me.lblPrecio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(57, 20)
        Me.lblPrecio.TabIndex = 62
        Me.lblPrecio.Text = "Precio"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(667, 117)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(62, 20)
        Me.Label25.TabIndex = 61
        Me.Label25.Text = "Precio:"
        '
        'lblCodigoProducto
        '
        Me.lblCodigoProducto.AutoSize = True
        Me.lblCodigoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoProducto.ForeColor = System.Drawing.Color.Maroon
        Me.lblCodigoProducto.Location = New System.Drawing.Point(16, 117)
        Me.lblCodigoProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoProducto.Name = "lblCodigoProducto"
        Me.lblCodigoProducto.Size = New System.Drawing.Size(61, 20)
        Me.lblCodigoProducto.TabIndex = 60
        Me.lblCodigoProducto.Text = "Codigo"
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProducto.ForeColor = System.Drawing.Color.Maroon
        Me.lblNombreProducto.Location = New System.Drawing.Point(144, 117)
        Me.lblNombreProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(164, 20)
        Me.lblNombreProducto.TabIndex = 59
        Me.lblNombreProducto.Text = "nombre del Producto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(396, 155)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 20)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Vence"
        '
        'txtLote
        '
        Me.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLote.Location = New System.Drawing.Point(279, 150)
        Me.txtLote.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLote.MaxLength = 15
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(112, 26)
        Me.txtLote.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(232, 153)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 20)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Lote"
        '
        'txtFraccion
        '
        Me.txtFraccion.BackColor = System.Drawing.Color.LightBlue
        Me.txtFraccion.Enabled = False
        Me.txtFraccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFraccion.Location = New System.Drawing.Point(91, 151)
        Me.txtFraccion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFraccion.MaxLength = 15
        Me.txtFraccion.Name = "txtFraccion"
        Me.txtFraccion.Size = New System.Drawing.Size(131, 26)
        Me.txtFraccion.TabIndex = 52
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 154)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 20)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Fracción"
        '
        'txtExenta
        '
        Me.txtExenta.BackColor = System.Drawing.Color.PaleGreen
        Me.txtExenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExenta.Location = New System.Drawing.Point(734, 87)
        Me.txtExenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExenta.MaxLength = 15
        Me.txtExenta.Name = "txtExenta"
        Me.txtExenta.Size = New System.Drawing.Size(112, 26)
        Me.txtExenta.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(755, 66)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 20)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Exenta"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.SystemColors.Window
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(1065, 33)
        Me.cboMoneda.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(185, 28)
        Me.cboMoneda.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1116, 12)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Momeda"
        '
        'txtBoni
        '
        Me.txtBoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoni.Location = New System.Drawing.Point(638, 87)
        Me.txtBoni.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBoni.MaxLength = 10
        Me.txtBoni.Name = "txtBoni"
        Me.txtBoni.Size = New System.Drawing.Size(69, 26)
        Me.txtBoni.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(648, 66)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 20)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Boni"
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(540, 87)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(86, 26)
        Me.txtCantidad.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(560, 66)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 20)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Cant."
        '
        'txtProducto
        '
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(137, 89)
        Me.txtProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProducto.MaxLength = 50
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(309, 26)
        Me.txtProducto.TabIndex = 8
        Me.txtProducto.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(139, 66)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Producto"
        '
        'txtResponsable
        '
        Me.txtResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponsable.Location = New System.Drawing.Point(807, 34)
        Me.txtResponsable.Margin = New System.Windows.Forms.Padding(4)
        Me.txtResponsable.MaxLength = 50
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(255, 26)
        Me.txtResponsable.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(811, 12)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 20)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Responsable"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(7, 34)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProveedor.MaxLength = 60
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(292, 26)
        Me.txtProveedor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 12)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Proveedor"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblDeposito)
        Me.GroupBox2.Controls.Add(Me.txtOrigen)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtTipoProducto)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtFechaPedido)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtCantidadPedido)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtNroPedido)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtPedidopor)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtLaboratorio)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 192)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1061, 103)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lblDeposito
        '
        Me.lblDeposito.AutoSize = True
        Me.lblDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeposito.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDeposito.Location = New System.Drawing.Point(631, 79)
        Me.lblDeposito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeposito.Name = "lblDeposito"
        Me.lblDeposito.Size = New System.Drawing.Size(192, 24)
        Me.lblDeposito.TabIndex = 68
        Me.lblDeposito.Text = "Deposito - Sucursal"
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.Color.LightBlue
        Me.txtOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrigen.Enabled = False
        Me.txtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrigen.Location = New System.Drawing.Point(415, 65)
        Me.txtOrigen.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOrigen.MaxLength = 60
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(39, 26)
        Me.txtOrigen.TabIndex = 74
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(476, 80)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(152, 20)
        Me.Label31.TabIndex = 67
        Me.Label31.Text = "Deposito/Sucursal:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(350, 65)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(64, 20)
        Me.Label29.TabIndex = 73
        Me.Label29.Text = "Origen:"
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.BackColor = System.Drawing.Color.LightBlue
        Me.txtTipoProducto.Enabled = False
        Me.txtTipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoProducto.Location = New System.Drawing.Point(56, 63)
        Me.txtTipoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoProducto.MaxLength = 60
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.Size = New System.Drawing.Size(293, 26)
        Me.txtTipoProducto.TabIndex = 72
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 67)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 20)
        Me.Label26.TabIndex = 71
        Me.Label26.Text = "Tipo:"
        '
        'txtFechaPedido
        '
        Me.txtFechaPedido.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaPedido.Enabled = False
        Me.txtFechaPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaPedido.Location = New System.Drawing.Point(737, 47)
        Me.txtFechaPedido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaPedido.MaxLength = 60
        Me.txtFechaPedido.Name = "txtFechaPedido"
        Me.txtFechaPedido.Size = New System.Drawing.Size(112, 26)
        Me.txtFechaPedido.TabIndex = 70
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(673, 47)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 20)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Fecha:"
        '
        'txtCantidadPedido
        '
        Me.txtCantidadPedido.BackColor = System.Drawing.Color.LightBlue
        Me.txtCantidadPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadPedido.Location = New System.Drawing.Point(931, 16)
        Me.txtCantidadPedido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidadPedido.MaxLength = 60
        Me.txtCantidadPedido.Name = "txtCantidadPedido"
        Me.txtCantidadPedido.ReadOnly = True
        Me.txtCantidadPedido.Size = New System.Drawing.Size(77, 26)
        Me.txtCantidadPedido.TabIndex = 68
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(881, 16)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 20)
        Me.Label19.TabIndex = 67
        Me.Label19.Text = "Cant:"
        '
        'txtNroPedido
        '
        Me.txtNroPedido.BackColor = System.Drawing.Color.LightBlue
        Me.txtNroPedido.Enabled = False
        Me.txtNroPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroPedido.Location = New System.Drawing.Point(552, 47)
        Me.txtNroPedido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroPedido.MaxLength = 60
        Me.txtNroPedido.Name = "txtNroPedido"
        Me.txtNroPedido.Size = New System.Drawing.Size(112, 26)
        Me.txtNroPedido.TabIndex = 66
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(448, 47)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 20)
        Me.Label18.TabIndex = 65
        Me.Label18.Text = "Nro. Pedido:"
        '
        'txtPedidopor
        '
        Me.txtPedidopor.BackColor = System.Drawing.Color.LightBlue
        Me.txtPedidopor.Enabled = False
        Me.txtPedidopor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedidopor.Location = New System.Drawing.Point(552, 16)
        Me.txtPedidopor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPedidopor.MaxLength = 60
        Me.txtPedidopor.Name = "txtPedidopor"
        Me.txtPedidopor.Size = New System.Drawing.Size(320, 26)
        Me.txtPedidopor.TabIndex = 64
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(448, 16)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 20)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "Pedido por:"
        '
        'txtLaboratorio
        '
        Me.txtLaboratorio.BackColor = System.Drawing.Color.LightBlue
        Me.txtLaboratorio.Enabled = False
        Me.txtLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaboratorio.Location = New System.Drawing.Point(121, 16)
        Me.txtLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLaboratorio.MaxLength = 60
        Me.txtLaboratorio.Name = "txtLaboratorio"
        Me.txtLaboratorio.Size = New System.Drawing.Size(320, 26)
        Me.txtLaboratorio.TabIndex = 60
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 20)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 20)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Laboratorio:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblIdProducto)
        Me.GroupBox3.Controls.Add(Me.lblNro)
        Me.GroupBox3.Controls.Add(Me.txtTotalFactura)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtTotalIva)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.txtIVA10)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtIva5)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 292)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1059, 100)
        Me.GroupBox3.TabIndex = 72
        Me.GroupBox3.TabStop = False
        '
        'lblIdProducto
        '
        Me.lblIdProducto.AutoSize = True
        Me.lblIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProducto.ForeColor = System.Drawing.Color.Maroon
        Me.lblIdProducto.Location = New System.Drawing.Point(939, 76)
        Me.lblIdProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdProducto.Name = "lblIdProducto"
        Me.lblIdProducto.Size = New System.Drawing.Size(89, 20)
        Me.lblIdProducto.TabIndex = 79
        Me.lblIdProducto.Text = "IdProducto"
        '
        'lblNro
        '
        Me.lblNro.AutoSize = True
        Me.lblNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNro.ForeColor = System.Drawing.Color.Maroon
        Me.lblNro.Location = New System.Drawing.Point(893, 75)
        Me.lblNro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(36, 20)
        Me.lblNro.TabIndex = 67
        Me.lblNro.Text = "Nro"
        '
        'txtTotalFactura
        '
        Me.txtTotalFactura.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalFactura.Enabled = False
        Me.txtTotalFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFactura.Location = New System.Drawing.Point(723, 64)
        Me.txtTotalFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalFactura.MaxLength = 60
        Me.txtTotalFactura.Name = "txtTotalFactura"
        Me.txtTotalFactura.Size = New System.Drawing.Size(145, 30)
        Me.txtTotalFactura.TabIndex = 78
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(708, 44)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(165, 20)
        Me.Label24.TabIndex = 77
        Me.Label24.Text = "TOTAL FACTURA:"
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackColor = System.Drawing.Color.SpringGreen
        Me.txtTotalIva.Enabled = False
        Me.txtTotalIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.Location = New System.Drawing.Point(785, 14)
        Me.txtTotalIva.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalIva.MaxLength = 60
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.Size = New System.Drawing.Size(145, 30)
        Me.txtTotalIva.TabIndex = 76
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(691, 18)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 20)
        Me.Label23.TabIndex = 75
        Me.Label23.Text = "Tota, IVA:"
        '
        'txtIVA10
        '
        Me.txtIVA10.BackColor = System.Drawing.Color.SpringGreen
        Me.txtIVA10.Enabled = False
        Me.txtIVA10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA10.Location = New System.Drawing.Point(516, 53)
        Me.txtIVA10.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVA10.MaxLength = 60
        Me.txtIVA10.Name = "txtIVA10"
        Me.txtIVA10.Size = New System.Drawing.Size(145, 30)
        Me.txtIVA10.TabIndex = 74
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(436, 58)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 20)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "IVA 10%:"
        '
        'txtIva5
        '
        Me.txtIva5.BackColor = System.Drawing.Color.SpringGreen
        Me.txtIva5.Enabled = False
        Me.txtIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva5.Location = New System.Drawing.Point(516, 14)
        Me.txtIva5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIva5.MaxLength = 60
        Me.txtIva5.Name = "txtIva5"
        Me.txtIva5.Size = New System.Drawing.Size(145, 30)
        Me.txtIva5.TabIndex = 72
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(444, 18)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 20)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "IVA 5%:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(1213, 203)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(203, 163)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 71
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(16, 186)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(717, 11)
        Me.PictureBox2.TabIndex = 75
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'lblControlPedido
        '
        Me.lblControlPedido.AutoSize = True
        Me.lblControlPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControlPedido.Location = New System.Drawing.Point(732, 182)
        Me.lblControlPedido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblControlPedido.Name = "lblControlPedido"
        Me.lblControlPedido.Size = New System.Drawing.Size(207, 20)
        Me.lblControlPedido.TabIndex = 75
        Me.lblControlPedido.Text = "Controlando Pedido............."
        Me.lblControlPedido.Visible = False
        '
        'lvCompra
        '
        Me.lvCompra.AllowColumnReorder = True
        Me.lvCompra.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detCompra_nro, Me.detCompra_codigo, Me.detCompra_mercaderia, Me.detCompra_forma, Me.detCompra_cantidad, Me.detCompra_boni, Me.detCompra_lote, Me.detCompra_vence, Me.detCompra_exenta, Me.detCompra_gravada5, Me.detCompra_gravada10, Me.detCompra_costoTot, Me.detCompra_precio, Me.detCompra_porceIva, Me.detCompra_porce})
        Me.lvCompra.FullRowSelect = True
        Me.lvCompra.GridLines = True
        Me.lvCompra.HideSelection = False
        Me.lvCompra.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCompra.LabelWrap = False
        Me.lvCompra.Location = New System.Drawing.Point(5, 393)
        Me.lvCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.lvCompra.MultiSelect = False
        Me.lvCompra.Name = "lvCompra"
        Me.lvCompra.Size = New System.Drawing.Size(1452, 390)
        Me.lvCompra.TabIndex = 104
        Me.lvCompra.UseCompatibleStateImageBehavior = False
        Me.lvCompra.View = System.Windows.Forms.View.Details
        '
        'detCompra_nro
        '
        Me.detCompra_nro.Text = "Nro."
        Me.detCompra_nro.Width = 40
        '
        'detCompra_codigo
        '
        Me.detCompra_codigo.Text = "Codigo"
        Me.detCompra_codigo.Width = 55
        '
        'detCompra_mercaderia
        '
        Me.detCompra_mercaderia.Text = "Mercaderia"
        Me.detCompra_mercaderia.Width = 330
        '
        'detCompra_forma
        '
        Me.detCompra_forma.Text = "Forma"
        '
        'detCompra_cantidad
        '
        Me.detCompra_cantidad.Text = "Cant."
        Me.detCompra_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detCompra_cantidad.Width = 70
        '
        'detCompra_boni
        '
        Me.detCompra_boni.Text = "Boni."
        Me.detCompra_boni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'detCompra_lote
        '
        Me.detCompra_lote.Text = "Lote"
        '
        'detCompra_vence
        '
        Me.detCompra_vence.Text = "Ven."
        Me.detCompra_vence.Width = 35
        '
        'detCompra_exenta
        '
        Me.detCompra_exenta.Text = "Exenta"
        Me.detCompra_exenta.Width = 65
        '
        'detCompra_gravada5
        '
        Me.detCompra_gravada5.Text = "Grav. 5%"
        Me.detCompra_gravada5.Width = 65
        '
        'detCompra_gravada10
        '
        Me.detCompra_gravada10.Text = "Grav. 10%"
        Me.detCompra_gravada10.Width = 65
        '
        'detCompra_costoTot
        '
        Me.detCompra_costoTot.Text = "Total Costo"
        Me.detCompra_costoTot.Width = 80
        '
        'detCompra_precio
        '
        Me.detCompra_precio.Text = "Precio"
        Me.detCompra_precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detCompra_precio.Width = 65
        '
        'detCompra_porceIva
        '
        Me.detCompra_porceIva.Text = "IVA"
        Me.detCompra_porceIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detCompra_porceIva.Width = 30
        '
        'detCompra_porce
        '
        Me.detCompra_porce.Text = "%"
        Me.detCompra_porce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detCompra_porce.Width = 70
        '
        'btnPorcentaje
        '
        Me.btnPorcentaje.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPorcentaje.Image = CType(resources.GetObject("btnPorcentaje.Image"), System.Drawing.Image)
        Me.btnPorcentaje.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPorcentaje.Location = New System.Drawing.Point(343, 319)
        Me.btnPorcentaje.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPorcentaje.Name = "btnPorcentaje"
        Me.btnPorcentaje.Size = New System.Drawing.Size(92, 46)
        Me.btnPorcentaje.TabIndex = 110
        Me.btnPorcentaje.Text = "&Porcentaje"
        Me.btnPorcentaje.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPorcentaje.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(143, 319)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(92, 46)
        Me.btnEliminar.TabIndex = 108
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnReutilizar
        '
        Me.btnReutilizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReutilizar.Image = CType(resources.GetObject("btnReutilizar.Image"), System.Drawing.Image)
        Me.btnReutilizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReutilizar.Location = New System.Drawing.Point(243, 319)
        Me.btnReutilizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReutilizar.Name = "btnReutilizar"
        Me.btnReutilizar.Size = New System.Drawing.Size(92, 46)
        Me.btnReutilizar.TabIndex = 109
        Me.btnReutilizar.Text = "&Reutilizar"
        Me.btnReutilizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReutilizar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(43, 319)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
        Me.btnGuardar.TabIndex = 107
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1464, 789)
        Me.Controls.Add(Me.btnPorcentaje)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnReutilizar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lvCompra)
        Me.Controls.Add(Me.lblControlPedido)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras de Mercaderías"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBoni As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFraccion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtExenta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNroPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPedidopor As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtFechaPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIva5 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtIVA10 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIva As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoProducto As System.Windows.Forms.Label
    Friend WithEvents lblNombreProducto As System.Windows.Forms.Label
    Friend WithEvents lblUltCosto As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents maskVence As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblNro As System.Windows.Forms.Label
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblIdProducto As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents txtIDProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblControlPedido As System.Windows.Forms.Label
    Friend WithEvents lvCompra As System.Windows.Forms.ListView
    Friend WithEvents detCompra_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_forma As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_boni As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_costoTot As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_porceIva As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_porce As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents btnPorcentaje As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnReutilizar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtGravada10 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtGravada5 As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents detCompra_exenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_gravada5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCompra_gravada10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents lblDeposito As System.Windows.Forms.Label
End Class
