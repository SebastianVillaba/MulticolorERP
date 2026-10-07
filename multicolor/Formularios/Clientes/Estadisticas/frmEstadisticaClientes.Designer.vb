<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadisticaClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadisticaClientes))
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdArchivoCorreo = New System.Windows.Forms.RadioButton()
        Me.rdRankingProducto = New System.Windows.Forms.RadioButton()
        Me.rdCostoPrecioTotal = New System.Windows.Forms.RadioButton()
        Me.rdVentaPorPuesto = New System.Windows.Forms.RadioButton()
        Me.rdDatosCliente = New System.Windows.Forms.RadioButton()
        Me.rdPorCliente = New System.Windows.Forms.RadioButton()
        Me.rdPorcentajeUtilidadFarmacia = New System.Windows.Forms.RadioButton()
        Me.rdClienteSinFechaNac = New System.Windows.Forms.RadioButton()
        Me.rdDetalleRemision = New System.Windows.Forms.RadioButton()
        Me.rdSinMovimiento = New System.Windows.Forms.RadioButton()
        Me.rdProductoVendidoLabo = New System.Windows.Forms.RadioButton()
        Me.rdVendedorLaboratorio = New System.Windows.Forms.RadioButton()
        Me.rdProductoVendido = New System.Windows.Forms.RadioButton()
        Me.rdClienteLaboratorio = New System.Windows.Forms.RadioButton()
        Me.rdRankingVendedor = New System.Windows.Forms.RadioButton()
        Me.rdFormaVenta = New System.Windows.Forms.RadioButton()
        Me.rdDiaVenta = New System.Windows.Forms.RadioButton()
        Me.rdHoraVenta = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.chkFraccionado = New System.Windows.Forms.CheckBox()
        Me.grFecha = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grDatoMercaderia = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRuc = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdCliente = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.grSucursal = New System.Windows.Forms.GroupBox()
        Me.chkTodaSucursal = New System.Windows.Forms.CheckBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.rdCostoMenor = New System.Windows.Forms.RadioButton()
        Me.grVendedor = New System.Windows.Forms.GroupBox()
        Me.rdTipoProductoVendedor = New System.Windows.Forms.RadioButton()
        Me.rdLaboratorioVendedor = New System.Windows.Forms.RadioButton()
        Me.rdDetalleVendedor = New System.Windows.Forms.RadioButton()
        Me.rdResumenVendedor = New System.Windows.Forms.RadioButton()
        Me.grLabratorio = New System.Windows.Forms.GroupBox()
        Me.lblLaboratorio = New System.Windows.Forms.Label()
        Me.lblIdLaboratorio = New System.Windows.Forms.Label()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.grTipoProducto = New System.Windows.Forms.GroupBox()
        Me.lblTipoproducto = New System.Windows.Forms.Label()
        Me.lblIdTipoProducto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblIdProd = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboTipoSucursal = New System.Windows.Forms.ComboBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboCajaSucursal = New System.Windows.Forms.ComboBox()
        Me.rdFacturaAutomotive = New System.Windows.Forms.RadioButton()
        Me.grOrdenar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grFecha.SuspendLayout()
        Me.grDatoMercaderia.SuspendLayout()
        Me.grSucursal.SuspendLayout()
        Me.grVendedor.SuspendLayout()
        Me.grLabratorio.SuspendLayout()
        Me.grTipoProducto.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdFacturaAutomotive)
        Me.grOrdenar.Controls.Add(Me.rdArchivoCorreo)
        Me.grOrdenar.Controls.Add(Me.rdRankingProducto)
        Me.grOrdenar.Controls.Add(Me.rdCostoPrecioTotal)
        Me.grOrdenar.Controls.Add(Me.rdVentaPorPuesto)
        Me.grOrdenar.Controls.Add(Me.rdDatosCliente)
        Me.grOrdenar.Controls.Add(Me.rdPorCliente)
        Me.grOrdenar.Controls.Add(Me.rdPorcentajeUtilidadFarmacia)
        Me.grOrdenar.Controls.Add(Me.rdClienteSinFechaNac)
        Me.grOrdenar.Controls.Add(Me.rdDetalleRemision)
        Me.grOrdenar.Controls.Add(Me.rdSinMovimiento)
        Me.grOrdenar.Controls.Add(Me.rdProductoVendidoLabo)
        Me.grOrdenar.Controls.Add(Me.rdVendedorLaboratorio)
        Me.grOrdenar.Controls.Add(Me.rdProductoVendido)
        Me.grOrdenar.Controls.Add(Me.rdClienteLaboratorio)
        Me.grOrdenar.Controls.Add(Me.rdRankingVendedor)
        Me.grOrdenar.Controls.Add(Me.rdFormaVenta)
        Me.grOrdenar.Controls.Add(Me.rdDiaVenta)
        Me.grOrdenar.Controls.Add(Me.rdHoraVenta)
        Me.grOrdenar.Location = New System.Drawing.Point(12, 302)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(646, 296)
        Me.grOrdenar.TabIndex = 101
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Opciones"
        '
        'rdArchivoCorreo
        '
        Me.rdArchivoCorreo.AutoSize = True
        Me.rdArchivoCorreo.Location = New System.Drawing.Point(454, 51)
        Me.rdArchivoCorreo.Name = "rdArchivoCorreo"
        Me.rdArchivoCorreo.Size = New System.Drawing.Size(156, 17)
        Me.rdArchivoCorreo.TabIndex = 66
        Me.rdArchivoCorreo.Text = "Generar Archivo de Correos"
        Me.rdArchivoCorreo.UseVisualStyleBackColor = True
        '
        'rdRankingProducto
        '
        Me.rdRankingProducto.AutoSize = True
        Me.rdRankingProducto.Location = New System.Drawing.Point(258, 247)
        Me.rdRankingProducto.Name = "rdRankingProducto"
        Me.rdRankingProducto.Size = New System.Drawing.Size(145, 17)
        Me.rdRankingProducto.TabIndex = 65
        Me.rdRankingProducto.Text = "Productos mas Vendidos "
        Me.rdRankingProducto.UseVisualStyleBackColor = True
        '
        'rdCostoPrecioTotal
        '
        Me.rdCostoPrecioTotal.AutoSize = True
        Me.rdCostoPrecioTotal.Location = New System.Drawing.Point(258, 20)
        Me.rdCostoPrecioTotal.Name = "rdCostoPrecioTotal"
        Me.rdCostoPrecioTotal.Size = New System.Drawing.Size(141, 17)
        Me.rdCostoPrecioTotal.TabIndex = 63
        Me.rdCostoPrecioTotal.Text = "Precios y Costos Totales"
        Me.rdCostoPrecioTotal.UseVisualStyleBackColor = True
        '
        'rdVentaPorPuesto
        '
        Me.rdVentaPorPuesto.AutoSize = True
        Me.rdVentaPorPuesto.Location = New System.Drawing.Point(8, 141)
        Me.rdVentaPorPuesto.Name = "rdVentaPorPuesto"
        Me.rdVentaPorPuesto.Size = New System.Drawing.Size(107, 17)
        Me.rdVentaPorPuesto.TabIndex = 62
        Me.rdVentaPorPuesto.Text = "Venta por Puesto"
        Me.rdVentaPorPuesto.UseVisualStyleBackColor = True
        '
        'rdDatosCliente
        '
        Me.rdDatosCliente.AutoSize = True
        Me.rdDatosCliente.Location = New System.Drawing.Point(258, 209)
        Me.rdDatosCliente.Name = "rdDatosCliente"
        Me.rdDatosCliente.Size = New System.Drawing.Size(124, 17)
        Me.rdDatosCliente.TabIndex = 59
        Me.rdDatosCliente.Text = "Datos de los Clientes"
        Me.rdDatosCliente.UseVisualStyleBackColor = True
        '
        'rdPorCliente
        '
        Me.rdPorCliente.AutoSize = True
        Me.rdPorCliente.Location = New System.Drawing.Point(9, 247)
        Me.rdPorCliente.Name = "rdPorCliente"
        Me.rdPorCliente.Size = New System.Drawing.Size(76, 17)
        Me.rdPorCliente.TabIndex = 58
        Me.rdPorCliente.Text = "Por Cliente"
        Me.rdPorCliente.UseVisualStyleBackColor = True
        '
        'rdPorcentajeUtilidadFarmacia
        '
        Me.rdPorcentajeUtilidadFarmacia.AutoSize = True
        Me.rdPorcentajeUtilidadFarmacia.Location = New System.Drawing.Point(258, 178)
        Me.rdPorcentajeUtilidadFarmacia.Name = "rdPorcentajeUtilidadFarmacia"
        Me.rdPorcentajeUtilidadFarmacia.Size = New System.Drawing.Size(129, 17)
        Me.rdPorcentajeUtilidadFarmacia.TabIndex = 54
        Me.rdPorcentajeUtilidadFarmacia.Text = "Porcentaje de Utilidad"
        Me.rdPorcentajeUtilidadFarmacia.UseVisualStyleBackColor = True
        '
        'rdClienteSinFechaNac
        '
        Me.rdClienteSinFechaNac.AutoSize = True
        Me.rdClienteSinFechaNac.Location = New System.Drawing.Point(9, 209)
        Me.rdClienteSinFechaNac.Name = "rdClienteSinFechaNac"
        Me.rdClienteSinFechaNac.Size = New System.Drawing.Size(177, 17)
        Me.rdClienteSinFechaNac.TabIndex = 53
        Me.rdClienteSinFechaNac.Text = "Clientes sin fecha de nacimiento"
        Me.rdClienteSinFechaNac.UseVisualStyleBackColor = True
        '
        'rdDetalleRemision
        '
        Me.rdDetalleRemision.AutoSize = True
        Me.rdDetalleRemision.Location = New System.Drawing.Point(258, 141)
        Me.rdDetalleRemision.Name = "rdDetalleRemision"
        Me.rdDetalleRemision.Size = New System.Drawing.Size(111, 17)
        Me.rdDetalleRemision.TabIndex = 49
        Me.rdDetalleRemision.Text = "Remisión p/ costo"
        Me.rdDetalleRemision.UseVisualStyleBackColor = True
        '
        'rdSinMovimiento
        '
        Me.rdSinMovimiento.AutoSize = True
        Me.rdSinMovimiento.Location = New System.Drawing.Point(258, 82)
        Me.rdSinMovimiento.Name = "rdSinMovimiento"
        Me.rdSinMovimiento.Size = New System.Drawing.Size(146, 17)
        Me.rdSinMovimiento.TabIndex = 32
        Me.rdSinMovimiento.Text = "Productos sin Movimiento"
        Me.rdSinMovimiento.UseVisualStyleBackColor = True
        '
        'rdProductoVendidoLabo
        '
        Me.rdProductoVendidoLabo.AutoSize = True
        Me.rdProductoVendidoLabo.Location = New System.Drawing.Point(8, 110)
        Me.rdProductoVendidoLabo.Name = "rdProductoVendidoLabo"
        Me.rdProductoVendidoLabo.Size = New System.Drawing.Size(180, 17)
        Me.rdProductoVendidoLabo.TabIndex = 30
        Me.rdProductoVendidoLabo.Text = "Productos mas Vendidos x Labo."
        Me.rdProductoVendidoLabo.UseVisualStyleBackColor = True
        '
        'rdVendedorLaboratorio
        '
        Me.rdVendedorLaboratorio.AutoSize = True
        Me.rdVendedorLaboratorio.Location = New System.Drawing.Point(454, 20)
        Me.rdVendedorLaboratorio.Name = "rdVendedorLaboratorio"
        Me.rdVendedorLaboratorio.Size = New System.Drawing.Size(156, 17)
        Me.rdVendedorLaboratorio.TabIndex = 29
        Me.rdVendedorLaboratorio.Text = "Vendedores por Laboratorio"
        Me.rdVendedorLaboratorio.UseVisualStyleBackColor = True
        '
        'rdProductoVendido
        '
        Me.rdProductoVendido.AutoSize = True
        Me.rdProductoVendido.Location = New System.Drawing.Point(8, 82)
        Me.rdProductoVendido.Name = "rdProductoVendido"
        Me.rdProductoVendido.Size = New System.Drawing.Size(202, 17)
        Me.rdProductoVendido.TabIndex = 28
        Me.rdProductoVendido.Text = "Productos mas Vendidos x Tipo Prod."
        Me.rdProductoVendido.UseVisualStyleBackColor = True
        '
        'rdClienteLaboratorio
        '
        Me.rdClienteLaboratorio.AutoSize = True
        Me.rdClienteLaboratorio.Location = New System.Drawing.Point(258, 110)
        Me.rdClienteLaboratorio.Name = "rdClienteLaboratorio"
        Me.rdClienteLaboratorio.Size = New System.Drawing.Size(131, 17)
        Me.rdClienteLaboratorio.TabIndex = 22
        Me.rdClienteLaboratorio.Text = "Cliente por Laboratorio"
        Me.rdClienteLaboratorio.UseVisualStyleBackColor = True
        '
        'rdRankingVendedor
        '
        Me.rdRankingVendedor.AutoSize = True
        Me.rdRankingVendedor.Location = New System.Drawing.Point(258, 51)
        Me.rdRankingVendedor.Name = "rdRankingVendedor"
        Me.rdRankingVendedor.Size = New System.Drawing.Size(140, 17)
        Me.rdRankingVendedor.TabIndex = 20
        Me.rdRankingVendedor.Text = "Ranking de Vendedores"
        Me.rdRankingVendedor.UseVisualStyleBackColor = True
        '
        'rdFormaVenta
        '
        Me.rdFormaVenta.AutoSize = True
        Me.rdFormaVenta.Location = New System.Drawing.Point(8, 178)
        Me.rdFormaVenta.Name = "rdFormaVenta"
        Me.rdFormaVenta.Size = New System.Drawing.Size(105, 17)
        Me.rdFormaVenta.TabIndex = 19
        Me.rdFormaVenta.Text = "Formas de Venta"
        Me.rdFormaVenta.UseVisualStyleBackColor = True
        '
        'rdDiaVenta
        '
        Me.rdDiaVenta.AutoSize = True
        Me.rdDiaVenta.Location = New System.Drawing.Point(8, 51)
        Me.rdDiaVenta.Name = "rdDiaVenta"
        Me.rdDiaVenta.Size = New System.Drawing.Size(92, 17)
        Me.rdDiaVenta.TabIndex = 18
        Me.rdDiaVenta.Text = "Dias de Venta"
        Me.rdDiaVenta.UseVisualStyleBackColor = True
        '
        'rdHoraVenta
        '
        Me.rdHoraVenta.AutoSize = True
        Me.rdHoraVenta.Location = New System.Drawing.Point(8, 20)
        Me.rdHoraVenta.Name = "rdHoraVenta"
        Me.rdHoraVenta.Size = New System.Drawing.Size(99, 17)
        Me.rdHoraVenta.TabIndex = 17
        Me.rdHoraVenta.Text = "Horas de Venta"
        Me.rdHoraVenta.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.chkFraccionado)
        Me.GroupBox1.Location = New System.Drawing.Point(361, 188)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(261, 58)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opcion Mayor o Igual"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(22, 28)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(74, 20)
        Me.txtCantidad.TabIndex = 0
        '
        'chkFraccionado
        '
        Me.chkFraccionado.AutoSize = True
        Me.chkFraccionado.Location = New System.Drawing.Point(104, 30)
        Me.chkFraccionado.Name = "chkFraccionado"
        Me.chkFraccionado.Size = New System.Drawing.Size(141, 17)
        Me.chkFraccionado.TabIndex = 121
        Me.chkFraccionado.Text = "Mercaderia Fraccionada"
        Me.chkFraccionado.UseVisualStyleBackColor = True
        '
        'grFecha
        '
        Me.grFecha.BackColor = System.Drawing.Color.PaleGreen
        Me.grFecha.Controls.Add(Me.dtpHastaFecha)
        Me.grFecha.Controls.Add(Me.Label6)
        Me.grFecha.Controls.Add(Me.dtpDesdeFecha)
        Me.grFecha.Controls.Add(Me.Label5)
        Me.grFecha.Location = New System.Drawing.Point(18, 12)
        Me.grFecha.Name = "grFecha"
        Me.grFecha.Size = New System.Drawing.Size(424, 65)
        Me.grFecha.TabIndex = 116
        Me.grFecha.TabStop = False
        Me.grFecha.Text = "Fecha "
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(261, 31)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(154, 20)
        Me.dtpHastaFecha.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(217, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Hasta:"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(60, 29)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(154, 20)
        Me.dtpDesdeFecha.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Desde:"
        '
        'grDatoMercaderia
        '
        Me.grDatoMercaderia.Controls.Add(Me.Label2)
        Me.grDatoMercaderia.Controls.Add(Me.lblRuc)
        Me.grDatoMercaderia.Controls.Add(Me.Label1)
        Me.grDatoMercaderia.Controls.Add(Me.lblIdCliente)
        Me.grDatoMercaderia.Controls.Add(Me.lblCliente)
        Me.grDatoMercaderia.Location = New System.Drawing.Point(12, 97)
        Me.grDatoMercaderia.Name = "grDatoMercaderia"
        Me.grDatoMercaderia.Size = New System.Drawing.Size(385, 78)
        Me.grDatoMercaderia.TabIndex = 118
        Me.grDatoMercaderia.TabStop = False
        Me.grDatoMercaderia.Text = "Datos del Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Codigo:"
        '
        'lblRuc
        '
        Me.lblRuc.AutoSize = True
        Me.lblRuc.BackColor = System.Drawing.Color.Gold
        Me.lblRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuc.Location = New System.Drawing.Point(142, 47)
        Me.lblRuc.Name = "lblRuc"
        Me.lblRuc.Size = New System.Drawing.Size(55, 18)
        Me.lblRuc.TabIndex = 109
        Me.lblRuc.Text = "lblRuc"
        Me.lblRuc.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Cliente:"
        '
        'lblIdCliente
        '
        Me.lblIdCliente.AutoSize = True
        Me.lblIdCliente.BackColor = System.Drawing.Color.Lime
        Me.lblIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCliente.Location = New System.Drawing.Point(61, 47)
        Me.lblIdCliente.Name = "lblIdCliente"
        Me.lblIdCliente.Size = New System.Drawing.Size(90, 18)
        Me.lblIdCliente.TabIndex = 108
        Me.lblIdCliente.Text = "lblIdCliente"
        Me.lblIdCliente.Visible = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.Color.Lime
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(59, 19)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(77, 18)
        Me.lblCliente.TabIndex = 107
        Me.lblCliente.Text = "lblCliente"
        Me.lblCliente.Visible = False
        '
        'grSucursal
        '
        Me.grSucursal.Controls.Add(Me.chkTodaSucursal)
        Me.grSucursal.Controls.Add(Me.cboSucursal)
        Me.grSucursal.Location = New System.Drawing.Point(403, 97)
        Me.grSucursal.Name = "grSucursal"
        Me.grSucursal.Size = New System.Drawing.Size(353, 79)
        Me.grSucursal.TabIndex = 119
        Me.grSucursal.TabStop = False
        Me.grSucursal.Text = "Sucursal"
        '
        'chkTodaSucursal
        '
        Me.chkTodaSucursal.AutoSize = True
        Me.chkTodaSucursal.Checked = True
        Me.chkTodaSucursal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodaSucursal.Location = New System.Drawing.Point(4, 52)
        Me.chkTodaSucursal.Name = "chkTodaSucursal"
        Me.chkTodaSucursal.Size = New System.Drawing.Size(127, 17)
        Me.chkTodaSucursal.TabIndex = 109
        Me.chkTodaSucursal.Text = "Todas las Sucursales"
        Me.chkTodaSucursal.UseVisualStyleBackColor = True
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
        'rdCostoMenor
        '
        Me.rdCostoMenor.AutoSize = True
        Me.rdCostoMenor.Location = New System.Drawing.Point(8, 66)
        Me.rdCostoMenor.Name = "rdCostoMenor"
        Me.rdCostoMenor.Size = New System.Drawing.Size(105, 17)
        Me.rdCostoMenor.TabIndex = 19
        Me.rdCostoMenor.Text = "Formas de Venta"
        Me.rdCostoMenor.UseVisualStyleBackColor = True
        '
        'grVendedor
        '
        Me.grVendedor.Controls.Add(Me.rdTipoProductoVendedor)
        Me.grVendedor.Controls.Add(Me.rdLaboratorioVendedor)
        Me.grVendedor.Controls.Add(Me.rdDetalleVendedor)
        Me.grVendedor.Controls.Add(Me.rdResumenVendedor)
        Me.grVendedor.Location = New System.Drawing.Point(541, 24)
        Me.grVendedor.Name = "grVendedor"
        Me.grVendedor.Size = New System.Drawing.Size(357, 46)
        Me.grVendedor.TabIndex = 102
        Me.grVendedor.TabStop = False
        Me.grVendedor.Text = "Opciones"
        '
        'rdTipoProductoVendedor
        '
        Me.rdTipoProductoVendedor.AutoSize = True
        Me.rdTipoProductoVendedor.Location = New System.Drawing.Point(225, 20)
        Me.rdTipoProductoVendedor.Name = "rdTipoProductoVendedor"
        Me.rdTipoProductoVendedor.Size = New System.Drawing.Size(126, 17)
        Me.rdTipoProductoVendedor.TabIndex = 20
        Me.rdTipoProductoVendedor.Text = "Por Tipo de Producto"
        Me.rdTipoProductoVendedor.UseVisualStyleBackColor = True
        '
        'rdLaboratorioVendedor
        '
        Me.rdLaboratorioVendedor.AutoSize = True
        Me.rdLaboratorioVendedor.Location = New System.Drawing.Point(132, 20)
        Me.rdLaboratorioVendedor.Name = "rdLaboratorioVendedor"
        Me.rdLaboratorioVendedor.Size = New System.Drawing.Size(97, 17)
        Me.rdLaboratorioVendedor.TabIndex = 19
        Me.rdLaboratorioVendedor.Text = "Por Laboratorio"
        Me.rdLaboratorioVendedor.UseVisualStyleBackColor = True
        '
        'rdDetalleVendedor
        '
        Me.rdDetalleVendedor.AutoSize = True
        Me.rdDetalleVendedor.Location = New System.Drawing.Point(74, 20)
        Me.rdDetalleVendedor.Name = "rdDetalleVendedor"
        Me.rdDetalleVendedor.Size = New System.Drawing.Size(58, 17)
        Me.rdDetalleVendedor.TabIndex = 18
        Me.rdDetalleVendedor.Text = "Detalle"
        Me.rdDetalleVendedor.UseVisualStyleBackColor = True
        '
        'rdResumenVendedor
        '
        Me.rdResumenVendedor.AutoSize = True
        Me.rdResumenVendedor.Checked = True
        Me.rdResumenVendedor.Location = New System.Drawing.Point(8, 20)
        Me.rdResumenVendedor.Name = "rdResumenVendedor"
        Me.rdResumenVendedor.Size = New System.Drawing.Size(70, 17)
        Me.rdResumenVendedor.TabIndex = 17
        Me.rdResumenVendedor.TabStop = True
        Me.rdResumenVendedor.Text = "Resumen"
        Me.rdResumenVendedor.UseVisualStyleBackColor = True
        '
        'grLabratorio
        '
        Me.grLabratorio.Controls.Add(Me.lblLaboratorio)
        Me.grLabratorio.Controls.Add(Me.lblIdLaboratorio)
        Me.grLabratorio.Location = New System.Drawing.Point(12, 190)
        Me.grLabratorio.Name = "grLabratorio"
        Me.grLabratorio.Size = New System.Drawing.Size(343, 49)
        Me.grLabratorio.TabIndex = 118
        Me.grLabratorio.TabStop = False
        Me.grLabratorio.Text = "Laboratorio"
        '
        'lblLaboratorio
        '
        Me.lblLaboratorio.AutoSize = True
        Me.lblLaboratorio.BackColor = System.Drawing.Color.Lime
        Me.lblLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaboratorio.Location = New System.Drawing.Point(39, 22)
        Me.lblLaboratorio.Name = "lblLaboratorio"
        Me.lblLaboratorio.Size = New System.Drawing.Size(112, 18)
        Me.lblLaboratorio.TabIndex = 111
        Me.lblLaboratorio.Text = "lblLaboratorio"
        '
        'lblIdLaboratorio
        '
        Me.lblIdLaboratorio.AutoSize = True
        Me.lblIdLaboratorio.BackColor = System.Drawing.Color.Gold
        Me.lblIdLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdLaboratorio.Location = New System.Drawing.Point(6, 22)
        Me.lblIdLaboratorio.Name = "lblIdLaboratorio"
        Me.lblIdLaboratorio.Size = New System.Drawing.Size(65, 18)
        Me.lblIdLaboratorio.TabIndex = 110
        Me.lblIdLaboratorio.Text = "lblIdLab"
        '
        'txtSql
        '
        Me.txtSql.Location = New System.Drawing.Point(12, 604)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(927, 20)
        Me.txtSql.TabIndex = 120
        Me.txtSql.Visible = False
        Me.txtSql.WordWrap = False
        '
        'grTipoProducto
        '
        Me.grTipoProducto.Controls.Add(Me.lblTipoproducto)
        Me.grTipoProducto.Controls.Add(Me.lblIdTipoProducto)
        Me.grTipoProducto.Controls.Add(Me.Label8)
        Me.grTipoProducto.Location = New System.Drawing.Point(13, 245)
        Me.grTipoProducto.Name = "grTipoProducto"
        Me.grTipoProducto.Size = New System.Drawing.Size(338, 52)
        Me.grTipoProducto.TabIndex = 120
        Me.grTipoProducto.TabStop = False
        Me.grTipoProducto.Text = "Datos del Tipo de Producto"
        Me.grTipoProducto.Visible = False
        '
        'lblTipoproducto
        '
        Me.lblTipoproducto.AutoSize = True
        Me.lblTipoproducto.BackColor = System.Drawing.Color.Lime
        Me.lblTipoproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoproducto.Location = New System.Drawing.Point(123, 22)
        Me.lblTipoproducto.Name = "lblTipoproducto"
        Me.lblTipoproducto.Size = New System.Drawing.Size(125, 18)
        Me.lblTipoproducto.TabIndex = 107
        Me.lblTipoproducto.Text = "lblTipoproducto"
        '
        'lblIdTipoProducto
        '
        Me.lblIdTipoProducto.AutoSize = True
        Me.lblIdTipoProducto.BackColor = System.Drawing.Color.Gold
        Me.lblIdTipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdTipoProducto.Location = New System.Drawing.Point(99, 22)
        Me.lblIdTipoProducto.Name = "lblIdTipoProducto"
        Me.lblIdTipoProducto.Size = New System.Drawing.Size(94, 18)
        Me.lblIdTipoProducto.TabIndex = 109
        Me.lblIdTipoProducto.Text = "lblTipoProd"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "Tipo Produc.:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblProducto)
        Me.GroupBox2.Controls.Add(Me.lblIdProd)
        Me.GroupBox2.Location = New System.Drawing.Point(628, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(343, 49)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Por Producto"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.Color.Lime
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(39, 22)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(77, 18)
        Me.lblProducto.TabIndex = 111
        Me.lblProducto.Text = "Producto"
        '
        'lblIdProd
        '
        Me.lblIdProd.AutoSize = True
        Me.lblIdProd.BackColor = System.Drawing.Color.Gold
        Me.lblIdProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProd.Location = New System.Drawing.Point(6, 22)
        Me.lblIdProd.Name = "lblIdProd"
        Me.lblIdProd.Size = New System.Drawing.Size(57, 18)
        Me.lblIdProd.TabIndex = 110
        Me.lblIdProd.Text = "idProd"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboTipoSucursal)
        Me.GroupBox3.Location = New System.Drawing.Point(762, 97)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 64)
        Me.GroupBox3.TabIndex = 123
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Sucursal"
        '
        'cboTipoSucursal
        '
        Me.cboTipoSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoSucursal.FormattingEnabled = True
        Me.cboTipoSucursal.Location = New System.Drawing.Point(14, 26)
        Me.cboTipoSucursal.Name = "cboTipoSucursal"
        Me.cboTipoSucursal.Size = New System.Drawing.Size(205, 24)
        Me.cboTipoSucursal.TabIndex = 50
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(452, 26)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(69, 37)
        Me.btnConsultar.TabIndex = 95
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboCajaSucursal)
        Me.GroupBox4.Location = New System.Drawing.Point(708, 242)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(119, 58)
        Me.GroupBox4.TabIndex = 124
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Caja de Sucursal"
        '
        'cboCajaSucursal
        '
        Me.cboCajaSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboCajaSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCajaSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCajaSucursal.FormattingEnabled = True
        Me.cboCajaSucursal.Location = New System.Drawing.Point(14, 26)
        Me.cboCajaSucursal.Name = "cboCajaSucursal"
        Me.cboCajaSucursal.Size = New System.Drawing.Size(92, 24)
        Me.cboCajaSucursal.TabIndex = 50
        '
        'rdFacturaAutomotive
        '
        Me.rdFacturaAutomotive.AutoSize = True
        Me.rdFacturaAutomotive.Location = New System.Drawing.Point(454, 82)
        Me.rdFacturaAutomotive.Name = "rdFacturaAutomotive"
        Me.rdFacturaAutomotive.Size = New System.Drawing.Size(137, 17)
        Me.rdFacturaAutomotive.TabIndex = 67
        Me.rdFacturaAutomotive.Text = "Facturación Automotive"
        Me.rdFacturaAutomotive.UseVisualStyleBackColor = True
        '
        'frmEstadisticaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 609)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.grTipoProducto)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.grLabratorio)
        Me.Controls.Add(Me.grVendedor)
        Me.Controls.Add(Me.grSucursal)
        Me.Controls.Add(Me.grDatoMercaderia)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grFecha)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstadisticaClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadísticas de Clientes"
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grFecha.ResumeLayout(False)
        Me.grFecha.PerformLayout()
        Me.grDatoMercaderia.ResumeLayout(False)
        Me.grDatoMercaderia.PerformLayout()
        Me.grSucursal.ResumeLayout(False)
        Me.grSucursal.PerformLayout()
        Me.grVendedor.ResumeLayout(False)
        Me.grVendedor.PerformLayout()
        Me.grLabratorio.ResumeLayout(False)
        Me.grLabratorio.PerformLayout()
        Me.grTipoProducto.ResumeLayout(False)
        Me.grTipoProducto.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdFormaVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rdDiaVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rdHoraVenta As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents grFecha As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grDatoMercaderia As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRuc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIdCliente As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents grSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodaSucursal As System.Windows.Forms.CheckBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents rdCostoMenor As System.Windows.Forms.RadioButton
    Friend WithEvents rdRankingVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents grVendedor As System.Windows.Forms.GroupBox
    Friend WithEvents rdTipoProductoVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents rdLaboratorioVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents rdDetalleVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumenVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents rdClienteLaboratorio As System.Windows.Forms.RadioButton
    Friend WithEvents grLabratorio As System.Windows.Forms.GroupBox
    Friend WithEvents lblLaboratorio As System.Windows.Forms.Label
    Friend WithEvents lblIdLaboratorio As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents rdProductoVendido As System.Windows.Forms.RadioButton
    Friend WithEvents grTipoProducto As System.Windows.Forms.GroupBox
    Friend WithEvents lblTipoproducto As System.Windows.Forms.Label
    Friend WithEvents lblIdTipoProducto As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkFraccionado As System.Windows.Forms.CheckBox
    Friend WithEvents rdVendedorLaboratorio As System.Windows.Forms.RadioButton
    Friend WithEvents rdProductoVendidoLabo As System.Windows.Forms.RadioButton
    Friend WithEvents rdSinMovimiento As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblIdProd As System.Windows.Forms.Label
    Friend WithEvents rdDetalleRemision As System.Windows.Forms.RadioButton
    Friend WithEvents rdClienteSinFechaNac As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorcentajeUtilidadFarmacia As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorCliente As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents rdDatosCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rdVentaPorPuesto As System.Windows.Forms.RadioButton
    Friend WithEvents rdCostoPrecioTotal As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents rdRankingProducto As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCajaSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents rdArchivoCorreo As System.Windows.Forms.RadioButton
    Friend WithEvents rdFacturaAutomotive As System.Windows.Forms.RadioButton
End Class
