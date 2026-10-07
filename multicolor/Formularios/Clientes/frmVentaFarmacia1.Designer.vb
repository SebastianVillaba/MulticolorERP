<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaFarmacia1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaFarmacia1))
        Me.grDatosCliente = New System.Windows.Forms.GroupBox()
        Me.txtFechaUltimaCompraCliente = New System.Windows.Forms.TextBox()
        Me.txtUltimaCompraCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTelefonoCliente = New System.Windows.Forms.TextBox()
        Me.txtGrupoCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRucCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtTotalDescuento = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalVenta = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picImagenMercaderia = New System.Windows.Forms.PictureBox()
        Me.lblFormaVenta = New System.Windows.Forms.Label()
        Me.lblIdTipoVenta = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvMoneda = New System.Windows.Forms.ListView()
        Me.moneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cotiza = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.subTotalMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.descuentoMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCantfrac = New System.Windows.Forms.Label()
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.lblIdProducto = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtIdStock = New System.Windows.Forms.TextBox()
        Me.lblIdStock = New System.Windows.Forms.Label()
        Me.lblMercaderia = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblForma = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtStockProducto = New System.Windows.Forms.TextBox()
        Me.txtConta = New System.Windows.Forms.TextBox()
        Me.txtLaboratorioProducto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnTotalizar = New System.Windows.Forms.Button()
        Me.btnFormaVenta = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnReutilizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnUtilPresu = New System.Windows.Forms.Button()
        Me.btnPresupuesto = New System.Windows.Forms.Button()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.lvVenta = New System.Windows.Forms.ListView()
        Me.detVenta_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_porceDes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_descuento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_porcentajeIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_precioDescuento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_subtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_idStock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVenta_orden = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblUltimoVendedor = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblUltimoTipoVenta = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblUltimaFormaVenta = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblUltimaFecha = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblUltimoMonto = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblUltimoCliente = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lvUltimoProducto = New System.Windows.Forms.ListView()
        Me.detUlt_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detUlt_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detUlt_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detUlt_subtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.txtNroFacturaSgte = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTipoventaNombre = New System.Windows.Forms.TextBox()
        Me.txtIdTipoventa = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotalIva = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtIva10 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtIva5 = New System.Windows.Forms.TextBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.btnPreparado = New System.Windows.Forms.Button()
        Me.grDatosCliente.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.picImagenMercaderia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grDatosCliente
        '
        Me.grDatosCliente.Controls.Add(Me.txtFechaUltimaCompraCliente)
        Me.grDatosCliente.Controls.Add(Me.txtUltimaCompraCliente)
        Me.grDatosCliente.Controls.Add(Me.Label4)
        Me.grDatosCliente.Controls.Add(Me.txtTelefonoCliente)
        Me.grDatosCliente.Controls.Add(Me.txtGrupoCliente)
        Me.grDatosCliente.Controls.Add(Me.Label3)
        Me.grDatosCliente.Controls.Add(Me.txtRucCliente)
        Me.grDatosCliente.Controls.Add(Me.Label2)
        Me.grDatosCliente.Controls.Add(Me.txtCliente)
        Me.grDatosCliente.Controls.Add(Me.txtIdCliente)
        Me.grDatosCliente.Controls.Add(Me.Label1)
        Me.grDatosCliente.Controls.Add(Me.txtDireccion)
        Me.grDatosCliente.Location = New System.Drawing.Point(7, -1)
        Me.grDatosCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.grDatosCliente.Name = "grDatosCliente"
        Me.grDatosCliente.Padding = New System.Windows.Forms.Padding(4)
        Me.grDatosCliente.Size = New System.Drawing.Size(687, 106)
        Me.grDatosCliente.TabIndex = 105
        Me.grDatosCliente.TabStop = False
        Me.grDatosCliente.Text = "Datos del Cliente"
        '
        'txtFechaUltimaCompraCliente
        '
        Me.txtFechaUltimaCompraCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaUltimaCompraCliente.Location = New System.Drawing.Point(491, 42)
        Me.txtFechaUltimaCompraCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaUltimaCompraCliente.Name = "txtFechaUltimaCompraCliente"
        Me.txtFechaUltimaCompraCliente.ReadOnly = True
        Me.txtFechaUltimaCompraCliente.Size = New System.Drawing.Size(195, 22)
        Me.txtFechaUltimaCompraCliente.TabIndex = 9
        '
        'txtUltimaCompraCliente
        '
        Me.txtUltimaCompraCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtUltimaCompraCliente.Location = New System.Drawing.Point(363, 42)
        Me.txtUltimaCompraCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUltimaCompraCliente.Name = "txtUltimaCompraCliente"
        Me.txtUltimaCompraCliente.ReadOnly = True
        Me.txtUltimaCompraCliente.Size = New System.Drawing.Size(125, 22)
        Me.txtUltimaCompraCliente.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(235, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha Ult.Compra:"
        '
        'txtTelefonoCliente
        '
        Me.txtTelefonoCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtTelefonoCliente.Location = New System.Drawing.Point(71, 42)
        Me.txtTelefonoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelefonoCliente.Name = "txtTelefonoCliente"
        Me.txtTelefonoCliente.ReadOnly = True
        Me.txtTelefonoCliente.Size = New System.Drawing.Size(155, 22)
        Me.txtTelefonoCliente.TabIndex = 6
        '
        'txtGrupoCliente
        '
        Me.txtGrupoCliente.BackColor = System.Drawing.Color.DodgerBlue
        Me.txtGrupoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupoCliente.ForeColor = System.Drawing.Color.Yellow
        Me.txtGrupoCliente.Location = New System.Drawing.Point(9, 65)
        Me.txtGrupoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGrupoCliente.Name = "txtGrupoCliente"
        Me.txtGrupoCliente.ReadOnly = True
        Me.txtGrupoCliente.Size = New System.Drawing.Size(237, 26)
        Me.txtGrupoCliente.TabIndex = 107
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Telefono:"
        '
        'txtRucCliente
        '
        Me.txtRucCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtRucCliente.Location = New System.Drawing.Point(537, 16)
        Me.txtRucCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRucCliente.Name = "txtRucCliente"
        Me.txtRucCliente.ReadOnly = True
        Me.txtRucCliente.Size = New System.Drawing.Size(139, 22)
        Me.txtRucCliente.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(492, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "RUC:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtCliente.Location = New System.Drawing.Point(152, 16)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(336, 22)
        Me.txtCliente.TabIndex = 2
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdCliente.Location = New System.Drawing.Point(71, 16)
        Me.txtIdCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(79, 22)
        Me.txtIdCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-1, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Cliente:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.LightBlue
        Me.txtDireccion.Location = New System.Drawing.Point(253, 68)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(427, 22)
        Me.txtDireccion.TabIndex = 112
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.txtTotalDescuento)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtTotalVenta)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.picImagenMercaderia)
        Me.Panel3.Location = New System.Drawing.Point(707, 7)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(639, 138)
        Me.Panel3.TabIndex = 110
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.Wheat
        Me.txtTotalDescuento.Enabled = False
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.Location = New System.Drawing.Point(348, 86)
        Me.txtTotalDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.Size = New System.Drawing.Size(229, 46)
        Me.txtTotalDescuento.TabIndex = 12
        Me.txtTotalDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(350, 69)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "DESCUENTO"
        '
        'txtTotalVenta
        '
        Me.txtTotalVenta.BackColor = System.Drawing.Color.Gold
        Me.txtTotalVenta.Enabled = False
        Me.txtTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVenta.Location = New System.Drawing.Point(342, 18)
        Me.txtTotalVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalVenta.Name = "txtTotalVenta"
        Me.txtTotalVenta.Size = New System.Drawing.Size(239, 46)
        Me.txtTotalVenta.TabIndex = 10
        Me.txtTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(343, 1)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "TOTAL"
        '
        'picImagenMercaderia
        '
        Me.picImagenMercaderia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImagenMercaderia.Location = New System.Drawing.Point(1, 1)
        Me.picImagenMercaderia.Margin = New System.Windows.Forms.Padding(4)
        Me.picImagenMercaderia.Name = "picImagenMercaderia"
        Me.picImagenMercaderia.Size = New System.Drawing.Size(173, 128)
        Me.picImagenMercaderia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagenMercaderia.TabIndex = 109
        Me.picImagenMercaderia.TabStop = False
        '
        'lblFormaVenta
        '
        Me.lblFormaVenta.AutoSize = True
        Me.lblFormaVenta.BackColor = System.Drawing.Color.Chartreuse
        Me.lblFormaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormaVenta.Location = New System.Drawing.Point(617, 60)
        Me.lblFormaVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFormaVenta.Name = "lblFormaVenta"
        Me.lblFormaVenta.Size = New System.Drawing.Size(203, 25)
        Me.lblFormaVenta.TabIndex = 42
        Me.lblFormaVenta.Text = "FORMA DE VENTA"
        '
        'lblIdTipoVenta
        '
        Me.lblIdTipoVenta.AutoSize = True
        Me.lblIdTipoVenta.BackColor = System.Drawing.Color.Chartreuse
        Me.lblIdTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdTipoVenta.Location = New System.Drawing.Point(617, 35)
        Me.lblIdTipoVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdTipoVenta.Name = "lblIdTipoVenta"
        Me.lblIdTipoVenta.Size = New System.Drawing.Size(152, 25)
        Me.lblIdTipoVenta.TabIndex = 43
        Me.lblIdTipoVenta.Text = "lblIdTipoVenta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(619, 9)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(152, 25)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Forma de Venta"
        '
        'lvMoneda
        '
        Me.lvMoneda.AllowColumnReorder = True
        Me.lvMoneda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.moneda, Me.cotiza, Me.subTotalMoneda, Me.descuentoMoneda, Me.totalMoneda})
        Me.lvMoneda.FullRowSelect = True
        Me.lvMoneda.GridLines = True
        Me.lvMoneda.HideSelection = False
        Me.lvMoneda.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvMoneda.LabelWrap = False
        Me.lvMoneda.Location = New System.Drawing.Point(16, 228)
        Me.lvMoneda.Margin = New System.Windows.Forms.Padding(4)
        Me.lvMoneda.MultiSelect = False
        Me.lvMoneda.Name = "lvMoneda"
        Me.lvMoneda.Size = New System.Drawing.Size(485, 118)
        Me.lvMoneda.TabIndex = 111
        Me.lvMoneda.UseCompatibleStateImageBehavior = False
        Me.lvMoneda.View = System.Windows.Forms.View.Details
        '
        'moneda
        '
        Me.moneda.Text = "Moneda"
        Me.moneda.Width = 90
        '
        'cotiza
        '
        Me.cotiza.Text = "Cotiza"
        '
        'subTotalMoneda
        '
        Me.subTotalMoneda.Text = "SubTotal"
        Me.subTotalMoneda.Width = 70
        '
        'descuentoMoneda
        '
        Me.descuentoMoneda.Text = "Descuento"
        Me.descuentoMoneda.Width = 70
        '
        'totalMoneda
        '
        Me.totalMoneda.Text = "Total"
        Me.totalMoneda.Width = 70
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.txtObra)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.lblCantfrac)
        Me.Panel4.Controls.Add(Me.lblFormaVenta)
        Me.Panel4.Controls.Add(Me.txtIdProducto)
        Me.Panel4.Controls.Add(Me.lblIdTipoVenta)
        Me.Panel4.Controls.Add(Me.lblIdProducto)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Controls.Add(Me.txtIdStock)
        Me.Panel4.Controls.Add(Me.lblIdStock)
        Me.Panel4.Controls.Add(Me.lblMercaderia)
        Me.Panel4.Controls.Add(Me.Label29)
        Me.Panel4.Controls.Add(Me.lblCodigo)
        Me.Panel4.Controls.Add(Me.lblForma)
        Me.Panel4.Controls.Add(Me.txtCantidad)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.txtBuscar)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.txtStockProducto)
        Me.Panel4.Controls.Add(Me.txtConta)
        Me.Panel4.Controls.Add(Me.txtLaboratorioProducto)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.txtTipoProducto)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Location = New System.Drawing.Point(503, 146)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(836, 196)
        Me.Panel4.TabIndex = 113
        '
        'txtObra
        '
        Me.txtObra.BackColor = System.Drawing.Color.LightCyan
        Me.txtObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObra.Location = New System.Drawing.Point(80, 80)
        Me.txtObra.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObra.MaxLength = 50
        Me.txtObra.Name = "txtObra"
        Me.txtObra.Size = New System.Drawing.Size(403, 27)
        Me.txtObra.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 84)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 20)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "OBRA:"
        '
        'lblCantfrac
        '
        Me.lblCantfrac.AutoSize = True
        Me.lblCantfrac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantfrac.ForeColor = System.Drawing.Color.Firebrick
        Me.lblCantfrac.Location = New System.Drawing.Point(642, 108)
        Me.lblCantfrac.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantfrac.Name = "lblCantfrac"
        Me.lblCantfrac.Size = New System.Drawing.Size(101, 20)
        Me.lblCantfrac.TabIndex = 53
        Me.lblCantfrac.Text = "lblCantfrac"
        '
        'txtIdProducto
        '
        Me.txtIdProducto.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProducto.Location = New System.Drawing.Point(487, 10)
        Me.txtIdProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.ReadOnly = True
        Me.txtIdProducto.Size = New System.Drawing.Size(97, 26)
        Me.txtIdProducto.TabIndex = 50
        Me.txtIdProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblIdProducto
        '
        Me.lblIdProducto.AutoSize = True
        Me.lblIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProducto.ForeColor = System.Drawing.Color.Firebrick
        Me.lblIdProducto.Location = New System.Drawing.Point(506, 108)
        Me.lblIdProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdProducto.Name = "lblIdProducto"
        Me.lblIdProducto.Size = New System.Drawing.Size(119, 20)
        Me.lblIdProducto.TabIndex = 48
        Me.lblIdProducto.Text = "lblIdProducto"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(436, 14)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 17)
        Me.Label28.TabIndex = 49
        Me.Label28.Text = "IdProd:"
        '
        'txtIdStock
        '
        Me.txtIdStock.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdStock.Location = New System.Drawing.Point(342, 9)
        Me.txtIdStock.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdStock.Name = "txtIdStock"
        Me.txtIdStock.ReadOnly = True
        Me.txtIdStock.Size = New System.Drawing.Size(85, 26)
        Me.txtIdStock.TabIndex = 52
        Me.txtIdStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblIdStock
        '
        Me.lblIdStock.AutoSize = True
        Me.lblIdStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdStock.ForeColor = System.Drawing.Color.Firebrick
        Me.lblIdStock.Location = New System.Drawing.Point(713, 148)
        Me.lblIdStock.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdStock.Name = "lblIdStock"
        Me.lblIdStock.Size = New System.Drawing.Size(91, 20)
        Me.lblIdStock.TabIndex = 47
        Me.lblIdStock.Text = "lblIdStock"
        '
        'lblMercaderia
        '
        Me.lblMercaderia.AutoSize = True
        Me.lblMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercaderia.ForeColor = System.Drawing.Color.Firebrick
        Me.lblMercaderia.Location = New System.Drawing.Point(12, 171)
        Me.lblMercaderia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMercaderia.Name = "lblMercaderia"
        Me.lblMercaderia.Size = New System.Drawing.Size(123, 20)
        Me.lblMercaderia.TabIndex = 45
        Me.lblMercaderia.Text = "lblMercaderia"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(286, 13)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 17)
        Me.Label29.TabIndex = 51
        Me.Label29.Text = "IdStock:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Firebrick
        Me.lblCodigo.Location = New System.Drawing.Point(618, 148)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 20)
        Me.lblCodigo.TabIndex = 44
        Me.lblCodigo.Text = "lblCodigo"
        '
        'lblForma
        '
        Me.lblForma.AutoSize = True
        Me.lblForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForma.ForeColor = System.Drawing.Color.Firebrick
        Me.lblForma.Location = New System.Drawing.Point(519, 148)
        Me.lblForma.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblForma.Name = "lblForma"
        Me.lblForma.Size = New System.Drawing.Size(82, 20)
        Me.lblForma.TabIndex = 46
        Me.lblForma.Text = "lblForma"
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.SkyBlue
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Lime
        Me.txtCantidad.Location = New System.Drawing.Point(428, 134)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(55, 34)
        Me.txtCantidad.TabIndex = 2
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(362, 139)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 25)
        Me.Label27.TabIndex = 42
        Me.Label27.Text = "Cant.:"
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.DarkSlateGray
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.ForeColor = System.Drawing.Color.Lime
        Me.txtBuscar.Location = New System.Drawing.Point(10, 131)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(351, 34)
        Me.txtBuscar.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(399, 48)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 20)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Stock:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(11, 107)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 25)
        Me.Label21.TabIndex = 40
        Me.Label21.Text = "Buscar"
        '
        'txtStockProducto
        '
        Me.txtStockProducto.BackColor = System.Drawing.Color.Cyan
        Me.txtStockProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockProducto.Location = New System.Drawing.Point(464, 44)
        Me.txtStockProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStockProducto.Name = "txtStockProducto"
        Me.txtStockProducto.ReadOnly = True
        Me.txtStockProducto.Size = New System.Drawing.Size(61, 26)
        Me.txtStockProducto.TabIndex = 33
        Me.txtStockProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtConta
        '
        Me.txtConta.BackColor = System.Drawing.Color.LightBlue
        Me.txtConta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConta.Location = New System.Drawing.Point(526, 44)
        Me.txtConta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConta.Name = "txtConta"
        Me.txtConta.ReadOnly = True
        Me.txtConta.Size = New System.Drawing.Size(61, 26)
        Me.txtConta.TabIndex = 36
        Me.txtConta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLaboratorioProducto
        '
        Me.txtLaboratorioProducto.BackColor = System.Drawing.Color.LightBlue
        Me.txtLaboratorioProducto.Location = New System.Drawing.Point(95, 44)
        Me.txtLaboratorioProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLaboratorioProducto.Name = "txtLaboratorioProducto"
        Me.txtLaboratorioProducto.ReadOnly = True
        Me.txtLaboratorioProducto.Size = New System.Drawing.Size(253, 22)
        Me.txtLaboratorioProducto.TabIndex = 26
        Me.txtLaboratorioProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 48)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 17)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Elaborador:"
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.BackColor = System.Drawing.Color.LightBlue
        Me.txtTipoProducto.Location = New System.Drawing.Point(48, 10)
        Me.txtTipoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ReadOnly = True
        Me.txtTipoProducto.Size = New System.Drawing.Size(228, 22)
        Me.txtTipoProducto.TabIndex = 24
        Me.txtTipoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 14)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 17)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Tipo:"
        '
        'btnTotalizar
        '
        Me.btnTotalizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTotalizar.Image = CType(resources.GetObject("btnTotalizar.Image"), System.Drawing.Image)
        Me.btnTotalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTotalizar.Location = New System.Drawing.Point(195, 165)
        Me.btnTotalizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTotalizar.Name = "btnTotalizar"
        Me.btnTotalizar.Size = New System.Drawing.Size(84, 42)
        Me.btnTotalizar.TabIndex = 119
        Me.btnTotalizar.Text = "&Totalizar"
        Me.btnTotalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTotalizar.UseVisualStyleBackColor = True
        '
        'btnFormaVenta
        '
        Me.btnFormaVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFormaVenta.Image = CType(resources.GetObject("btnFormaVenta.Image"), System.Drawing.Image)
        Me.btnFormaVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFormaVenta.Location = New System.Drawing.Point(287, 165)
        Me.btnFormaVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFormaVenta.Name = "btnFormaVenta"
        Me.btnFormaVenta.Size = New System.Drawing.Size(84, 42)
        Me.btnFormaVenta.TabIndex = 118
        Me.btnFormaVenta.Text = "&FormaVta."
        Me.btnFormaVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFormaVenta.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(103, 165)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(84, 42)
        Me.btnLimpiar.TabIndex = 117
        Me.btnLimpiar.Text = "&Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(11, 165)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(84, 42)
        Me.btnAgregar.TabIndex = 116
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnReutilizar
        '
        Me.btnReutilizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReutilizar.Image = CType(resources.GetObject("btnReutilizar.Image"), System.Drawing.Image)
        Me.btnReutilizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReutilizar.Location = New System.Drawing.Point(375, 115)
        Me.btnReutilizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReutilizar.Name = "btnReutilizar"
        Me.btnReutilizar.Size = New System.Drawing.Size(84, 42)
        Me.btnReutilizar.TabIndex = 115
        Me.btnReutilizar.Text = "&Reutilizar"
        Me.btnReutilizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReutilizar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(283, 115)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 42)
        Me.btnEliminar.TabIndex = 114
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnUtilPresu
        '
        Me.btnUtilPresu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUtilPresu.Image = CType(resources.GetObject("btnUtilPresu.Image"), System.Drawing.Image)
        Me.btnUtilPresu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUtilPresu.Location = New System.Drawing.Point(195, 115)
        Me.btnUtilPresu.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUtilPresu.Name = "btnUtilPresu"
        Me.btnUtilPresu.Size = New System.Drawing.Size(84, 42)
        Me.btnUtilPresu.TabIndex = 113
        Me.btnUtilPresu.Text = "&Util.Presu."
        Me.btnUtilPresu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUtilPresu.UseVisualStyleBackColor = True
        '
        'btnPresupuesto
        '
        Me.btnPresupuesto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPresupuesto.Image = CType(resources.GetObject("btnPresupuesto.Image"), System.Drawing.Image)
        Me.btnPresupuesto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPresupuesto.Location = New System.Drawing.Point(103, 115)
        Me.btnPresupuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPresupuesto.Name = "btnPresupuesto"
        Me.btnPresupuesto.Size = New System.Drawing.Size(84, 42)
        Me.btnPresupuesto.TabIndex = 112
        Me.btnPresupuesto.Text = "&Presu."
        Me.btnPresupuesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPresupuesto.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCliente.Location = New System.Drawing.Point(11, 115)
        Me.btnCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(84, 42)
        Me.btnCliente.TabIndex = 111
        Me.btnCliente.Text = "&Cliente"
        Me.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'lvVenta
        '
        Me.lvVenta.AllowColumnReorder = True
        Me.lvVenta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detVenta_nro, Me.detVenta_codigo, Me.detVenta_mercaderia, Me.detVenta_porceDes, Me.detVenta_descuento, Me.detVenta_porcentajeIva, Me.detVenta_cantidad, Me.detVenta_precio, Me.detVenta_precioDescuento, Me.detVenta_subtotal, Me.detVenta_idStock, Me.detVenta_orden})
        Me.lvVenta.FullRowSelect = True
        Me.lvVenta.GridLines = True
        Me.lvVenta.HideSelection = False
        Me.lvVenta.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvVenta.LabelWrap = False
        Me.lvVenta.Location = New System.Drawing.Point(5, 351)
        Me.lvVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.lvVenta.MultiSelect = False
        Me.lvVenta.Name = "lvVenta"
        Me.lvVenta.Size = New System.Drawing.Size(1308, 264)
        Me.lvVenta.TabIndex = 114
        Me.lvVenta.UseCompatibleStateImageBehavior = False
        Me.lvVenta.View = System.Windows.Forms.View.Details
        '
        'detVenta_nro
        '
        Me.detVenta_nro.Text = "Nro."
        Me.detVenta_nro.Width = 40
        '
        'detVenta_codigo
        '
        Me.detVenta_codigo.Text = "Codigo"
        Me.detVenta_codigo.Width = 55
        '
        'detVenta_mercaderia
        '
        Me.detVenta_mercaderia.Text = "Mercaderia"
        Me.detVenta_mercaderia.Width = 320
        '
        'detVenta_porceDes
        '
        Me.detVenta_porceDes.Text = "%Desc."
        Me.detVenta_porceDes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detVenta_porceDes.Width = 40
        '
        'detVenta_descuento
        '
        Me.detVenta_descuento.Text = "Descuento"
        Me.detVenta_descuento.Width = 70
        '
        'detVenta_porcentajeIva
        '
        Me.detVenta_porcentajeIva.Text = "%IVa"
        Me.detVenta_porcentajeIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detVenta_porcentajeIva.Width = 65
        '
        'detVenta_cantidad
        '
        Me.detVenta_cantidad.Text = "Cant."
        Me.detVenta_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detVenta_cantidad.Width = 65
        '
        'detVenta_precio
        '
        Me.detVenta_precio.Text = "Precio"
        Me.detVenta_precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detVenta_precio.Width = 90
        '
        'detVenta_precioDescuento
        '
        Me.detVenta_precioDescuento.Text = "Precio Desc."
        Me.detVenta_precioDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detVenta_precioDescuento.Width = 90
        '
        'detVenta_subtotal
        '
        Me.detVenta_subtotal.Text = "SubTotal"
        Me.detVenta_subtotal.Width = 90
        '
        'detVenta_idStock
        '
        Me.detVenta_idStock.Text = "IdStock"
        Me.detVenta_idStock.Width = 50
        '
        'detVenta_orden
        '
        Me.detVenta_orden.Text = "Orden"
        Me.detVenta_orden.Width = 45
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.PapayaWhip
        Me.GroupBox1.Controls.Add(Me.lblUltimoVendedor)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.lblUltimoTipoVenta)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.lblUltimaFormaVenta)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.lblUltimaFecha)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.lblUltimoMonto)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.lblUltimoCliente)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 617)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(419, 146)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        '
        'lblUltimoVendedor
        '
        Me.lblUltimoVendedor.AutoSize = True
        Me.lblUltimoVendedor.BackColor = System.Drawing.Color.Moccasin
        Me.lblUltimoVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimoVendedor.Location = New System.Drawing.Point(125, 123)
        Me.lblUltimoVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltimoVendedor.Name = "lblUltimoVendedor"
        Me.lblUltimoVendedor.Size = New System.Drawing.Size(125, 20)
        Me.lblUltimoVendedor.TabIndex = 136
        Me.lblUltimoVendedor.Text = "ultimoVendedor"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(5, 122)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(115, 20)
        Me.Label26.TabIndex = 135
        Me.Label26.Text = "Ult. Vendedor:"
        '
        'lblUltimoTipoVenta
        '
        Me.lblUltimoTipoVenta.AutoSize = True
        Me.lblUltimoTipoVenta.BackColor = System.Drawing.Color.Moccasin
        Me.lblUltimoTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimoTipoVenta.Location = New System.Drawing.Point(137, 101)
        Me.lblUltimoTipoVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltimoTipoVenta.Name = "lblUltimoTipoVenta"
        Me.lblUltimoTipoVenta.Size = New System.Drawing.Size(129, 20)
        Me.lblUltimoTipoVenta.TabIndex = 134
        Me.lblUltimoTipoVenta.Text = "ultimoTipoVenta"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 100)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 20)
        Me.Label25.TabIndex = 133
        Me.Label25.Text = "Ult. Tipo Venta:"
        '
        'lblUltimaFormaVenta
        '
        Me.lblUltimaFormaVenta.AutoSize = True
        Me.lblUltimaFormaVenta.BackColor = System.Drawing.Color.Moccasin
        Me.lblUltimaFormaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaFormaVenta.Location = New System.Drawing.Point(151, 79)
        Me.lblUltimaFormaVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltimaFormaVenta.Name = "lblUltimaFormaVenta"
        Me.lblUltimaFormaVenta.Size = New System.Drawing.Size(145, 20)
        Me.lblUltimaFormaVenta.TabIndex = 132
        Me.lblUltimaFormaVenta.Text = "ultimaFormaVenta"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(5, 78)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(140, 20)
        Me.Label23.TabIndex = 131
        Me.Label23.Text = "Ult. Forma Venta:"
        '
        'lblUltimaFecha
        '
        Me.lblUltimaFecha.AutoSize = True
        Me.lblUltimaFecha.BackColor = System.Drawing.Color.Moccasin
        Me.lblUltimaFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaFecha.Location = New System.Drawing.Point(100, 34)
        Me.lblUltimaFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltimaFecha.Name = "lblUltimaFecha"
        Me.lblUltimaFecha.Size = New System.Drawing.Size(100, 20)
        Me.lblUltimaFecha.TabIndex = 130
        Me.lblUltimaFecha.Text = "ultimaFecha"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 33)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(90, 20)
        Me.Label24.TabIndex = 129
        Me.Label24.Text = "Ult. Fecha:"
        '
        'lblUltimoMonto
        '
        Me.lblUltimoMonto.AutoSize = True
        Me.lblUltimoMonto.BackColor = System.Drawing.Color.Moccasin
        Me.lblUltimoMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimoMonto.Location = New System.Drawing.Point(101, 57)
        Me.lblUltimoMonto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltimoMonto.Name = "lblUltimoMonto"
        Me.lblUltimoMonto.Size = New System.Drawing.Size(100, 20)
        Me.lblUltimoMonto.TabIndex = 128
        Me.lblUltimoMonto.Text = "ultimoMonto"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(5, 55)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 20)
        Me.Label22.TabIndex = 127
        Me.Label22.Text = "Ult. Monto:"
        '
        'lblUltimoCliente
        '
        Me.lblUltimoCliente.AutoSize = True
        Me.lblUltimoCliente.BackColor = System.Drawing.Color.Moccasin
        Me.lblUltimoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimoCliente.Location = New System.Drawing.Point(100, 12)
        Me.lblUltimoCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltimoCliente.Name = "lblUltimoCliente"
        Me.lblUltimoCliente.Size = New System.Drawing.Size(106, 20)
        Me.lblUltimoCliente.TabIndex = 126
        Me.lblUltimoCliente.Text = "ultimoCliente"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 11)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 20)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "Ult. Cliente:"
        '
        'lvUltimoProducto
        '
        Me.lvUltimoProducto.AllowColumnReorder = True
        Me.lvUltimoProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detUlt_nro, Me.detUlt_mercaderia, Me.detUlt_cantidad, Me.detUlt_subtotal})
        Me.lvUltimoProducto.FullRowSelect = True
        Me.lvUltimoProducto.GridLines = True
        Me.lvUltimoProducto.HideSelection = False
        Me.lvUltimoProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvUltimoProducto.LabelWrap = False
        Me.lvUltimoProducto.Location = New System.Drawing.Point(433, 626)
        Me.lvUltimoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.lvUltimoProducto.MultiSelect = False
        Me.lvUltimoProducto.Name = "lvUltimoProducto"
        Me.lvUltimoProducto.Size = New System.Drawing.Size(464, 131)
        Me.lvUltimoProducto.TabIndex = 116
        Me.lvUltimoProducto.UseCompatibleStateImageBehavior = False
        Me.lvUltimoProducto.View = System.Windows.Forms.View.Details
        '
        'detUlt_nro
        '
        Me.detUlt_nro.Text = "Nro."
        Me.detUlt_nro.Width = 40
        '
        'detUlt_mercaderia
        '
        Me.detUlt_mercaderia.Text = "Ultima Mercadería Vendida"
        Me.detUlt_mercaderia.Width = 250
        '
        'detUlt_cantidad
        '
        Me.detUlt_cantidad.Text = "Cant."
        Me.detUlt_cantidad.Width = 40
        '
        'detUlt_subtotal
        '
        Me.detUlt_subtotal.Text = "SubTotal"
        Me.detUlt_subtotal.Width = 70
        '
        'txtDcaja
        '
        Me.txtDcaja.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDcaja.Enabled = False
        Me.txtDcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcaja.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtDcaja.Location = New System.Drawing.Point(957, 646)
        Me.txtDcaja.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(39, 26)
        Me.txtDcaja.TabIndex = 135
        '
        'txtDsuc
        '
        Me.txtDsuc.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDsuc.Enabled = False
        Me.txtDsuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsuc.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtDsuc.Location = New System.Drawing.Point(912, 646)
        Me.txtDsuc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(39, 26)
        Me.txtDsuc.TabIndex = 134
        '
        'txtNroFacturaSgte
        '
        Me.txtNroFacturaSgte.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNroFacturaSgte.Enabled = False
        Me.txtNroFacturaSgte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroFacturaSgte.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtNroFacturaSgte.Location = New System.Drawing.Point(1000, 646)
        Me.txtNroFacturaSgte.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroFacturaSgte.Name = "txtNroFacturaSgte"
        Me.txtNroFacturaSgte.Size = New System.Drawing.Size(107, 26)
        Me.txtNroFacturaSgte.TabIndex = 133
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(915, 623)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(145, 20)
        Me.Label18.TabIndex = 132
        Me.Label18.Text = "Nro. Factura Sgte."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(919, 684)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 20)
        Me.Label20.TabIndex = 131
        Me.Label20.Text = "Total IVA 5%"
        '
        'txtTipoventaNombre
        '
        Me.txtTipoventaNombre.BackColor = System.Drawing.Color.DodgerBlue
        Me.txtTipoventaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoventaNombre.ForeColor = System.Drawing.Color.Yellow
        Me.txtTipoventaNombre.Location = New System.Drawing.Point(1151, 647)
        Me.txtTipoventaNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoventaNombre.Name = "txtTipoventaNombre"
        Me.txtTipoventaNombre.ReadOnly = True
        Me.txtTipoventaNombre.Size = New System.Drawing.Size(183, 26)
        Me.txtTipoventaNombre.TabIndex = 130
        Me.txtTipoventaNombre.Text = "VENTA NORMAL"
        Me.txtTipoventaNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIdTipoventa
        '
        Me.txtIdTipoventa.BackColor = System.Drawing.Color.DodgerBlue
        Me.txtIdTipoventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTipoventa.ForeColor = System.Drawing.Color.Yellow
        Me.txtIdTipoventa.Location = New System.Drawing.Point(1112, 647)
        Me.txtIdTipoventa.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdTipoventa.Name = "txtIdTipoventa"
        Me.txtIdTipoventa.ReadOnly = True
        Me.txtIdTipoventa.Size = New System.Drawing.Size(36, 26)
        Me.txtIdTipoventa.TabIndex = 129
        Me.txtIdTipoventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(1147, 624)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 20)
        Me.Label19.TabIndex = 128
        Me.Label19.Text = "Tipo de Venta"
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.txtTotalIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.Location = New System.Drawing.Point(1184, 706)
        Me.txtTotalIva.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.ReadOnly = True
        Me.txtTotalIva.Size = New System.Drawing.Size(155, 26)
        Me.txtTotalIva.TabIndex = 127
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1195, 684)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 20)
        Me.Label17.TabIndex = 126
        Me.Label17.Text = "Total Impuesto:"
        '
        'txtIva10
        '
        Me.txtIva10.BackColor = System.Drawing.Color.LightBlue
        Me.txtIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva10.Location = New System.Drawing.Point(1044, 706)
        Me.txtIva10.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIva10.Name = "txtIva10"
        Me.txtIva10.ReadOnly = True
        Me.txtIva10.Size = New System.Drawing.Size(131, 26)
        Me.txtIva10.TabIndex = 125
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(1049, 684)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 20)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "Total IVA 10%"
        '
        'txtIva5
        '
        Me.txtIva5.BackColor = System.Drawing.Color.LightBlue
        Me.txtIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva5.Location = New System.Drawing.Point(912, 706)
        Me.txtIva5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIva5.Name = "txtIva5"
        Me.txtIva5.ReadOnly = True
        Me.txtIva5.Size = New System.Drawing.Size(121, 26)
        Me.txtIva5.TabIndex = 123
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.AliceBlue
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.ForeColor = System.Drawing.Color.Black
        Me.txtSql.Location = New System.Drawing.Point(5, 767)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(1215, 26)
        Me.txtSql.TabIndex = 136
        Me.txtSql.Visible = False
        '
        'btnPreparado
        '
        Me.btnPreparado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPreparado.Image = CType(resources.GetObject("btnPreparado.Image"), System.Drawing.Image)
        Me.btnPreparado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPreparado.Location = New System.Drawing.Point(375, 165)
        Me.btnPreparado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPreparado.Name = "btnPreparado"
        Me.btnPreparado.Size = New System.Drawing.Size(84, 42)
        Me.btnPreparado.TabIndex = 137
        Me.btnPreparado.Text = "&Orden"
        Me.btnPreparado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPreparado.UseVisualStyleBackColor = True
        '
        'frmVentaFarmacia1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 796)
        Me.Controls.Add(Me.btnPreparado)
        Me.Controls.Add(Me.btnFormaVenta)
        Me.Controls.Add(Me.btnTotalizar)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.txtDcaja)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtDsuc)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtNroFacturaSgte)
        Me.Controls.Add(Me.btnReutilizar)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btnUtilPresu)
        Me.Controls.Add(Me.txtTipoventaNombre)
        Me.Controls.Add(Me.btnPresupuesto)
        Me.Controls.Add(Me.txtIdTipoventa)
        Me.Controls.Add(Me.btnCliente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtTotalIva)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtIva10)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtIva5)
        Me.Controls.Add(Me.lvUltimoProducto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvVenta)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lvMoneda)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grDatosCliente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmVentaFarmacia1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FACTURACION"
        Me.grDatosCliente.ResumeLayout(False)
        Me.grDatosCliente.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.picImagenMercaderia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grDatosCliente As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaUltimaCompraCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimaCompraCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTelefonoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtGrupoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRucCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblFormaVenta As System.Windows.Forms.Label
    Friend WithEvents lblIdTipoVenta As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picImagenMercaderia As System.Windows.Forms.PictureBox
    Friend WithEvents lvMoneda As System.Windows.Forms.ListView
    Friend WithEvents moneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents cotiza As System.Windows.Forms.ColumnHeader
    Friend WithEvents subTotalMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents descuentoMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblCantfrac As System.Windows.Forms.Label
    Friend WithEvents txtIdStock As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblIdProducto As System.Windows.Forms.Label
    Friend WithEvents lblIdStock As System.Windows.Forms.Label
    Friend WithEvents lblForma As System.Windows.Forms.Label
    Friend WithEvents lblMercaderia As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtConta As System.Windows.Forms.TextBox
    Friend WithEvents txtStockProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLaboratorioProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lvVenta As System.Windows.Forms.ListView
    Friend WithEvents detVenta_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_descuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_porcentajeIva As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_precioDescuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_subtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVenta_idStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUltimoVendedor As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblUltimoTipoVenta As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblUltimaFormaVenta As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblUltimaFecha As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblUltimoMonto As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblUltimoCliente As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lvUltimoProducto As System.Windows.Forms.ListView
    Friend WithEvents detUlt_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents detUlt_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents detUlt_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents detUlt_subtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents txtNroFacturaSgte As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTipoventaNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtIdTipoventa As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIva As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtIva10 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtIva5 As System.Windows.Forms.TextBox
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents detVenta_porceDes As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnTotalizar As System.Windows.Forms.Button
    Friend WithEvents btnFormaVenta As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnReutilizar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnUtilPresu As System.Windows.Forms.Button
    Friend WithEvents btnPresupuesto As System.Windows.Forms.Button
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents txtObra As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPreparado As System.Windows.Forms.Button
    Friend WithEvents detVenta_orden As System.Windows.Forms.ColumnHeader
End Class
