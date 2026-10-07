<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteLibroIVA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteLibroIVA))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIdSucursal = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdArchivoCompra = New System.Windows.Forms.RadioButton()
        Me.rdNotaCredito = New System.Windows.Forms.RadioButton()
        Me.rdTimbrados = New System.Windows.Forms.RadioButton()
        Me.rdArchivoEstudio = New System.Windows.Forms.RadioButton()
        Me.rdSaldoProveedorCompra = New System.Windows.Forms.RadioButton()
        Me.rdGenerarArchivoInventario = New System.Windows.Forms.RadioButton()
        Me.rdInventario = New System.Windows.Forms.RadioButton()
        Me.rdArchivoVentaTxt = New System.Windows.Forms.RadioButton()
        Me.rdRg90 = New System.Windows.Forms.RadioButton()
        Me.rdVenta = New System.Windows.Forms.RadioButton()
        Me.rdCompra = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdDetalle = New System.Windows.Forms.RadioButton()
        Me.rdResumen = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboEmpresaContable = New System.Windows.Forms.ComboBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lvCabecera = New System.Windows.Forms.ListView()
        Me.lvCab_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_periodo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_original = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_formulario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_obligacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_rucEmpresa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_dvEmpresa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_empresa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_rucRepre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_dvRepre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_repre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_cantReg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCab_totalVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnExportarCabecera = New System.Windows.Forms.Button()
        Me.lblIva5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblGra5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblIva10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblGra10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalTxt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExportarDetalle = New System.Windows.Forms.Button()
        Me.lvArchivo = New System.Windows.Forms.ListView()
        Me.det_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_rucCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_dvCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_nombreCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_tipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_gra10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_iva10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_gra5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_iva5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_exenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_archivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.chkSoloExcel = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(364, 133)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha "
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(236, 48)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 102
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(80, 78)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(143, 22)
        Me.dtpHastaFecha.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 78)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 20)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Hasta:"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(80, 36)
        Me.dtpDesdeFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(143, 22)
        Me.dtpDesdeFecha.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 20)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Desde:"
        '
        'txtIdSucursal
        '
        Me.txtIdSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSucursal.Location = New System.Drawing.Point(17, 73)
        Me.txtIdSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdSucursal.Name = "txtIdSucursal"
        Me.txtIdSucursal.ReadOnly = True
        Me.txtIdSucursal.Size = New System.Drawing.Size(64, 29)
        Me.txtIdSucursal.TabIndex = 96
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIdSucursal)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Location = New System.Drawing.Point(612, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(509, 110)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sucursal"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(408, 25)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscar.TabIndex = 103
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(15, 37)
        Me.txtSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(384, 29)
        Me.txtSucursal.TabIndex = 0
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdArchivoCompra)
        Me.grOrdenar.Controls.Add(Me.rdNotaCredito)
        Me.grOrdenar.Controls.Add(Me.rdTimbrados)
        Me.grOrdenar.Controls.Add(Me.rdArchivoEstudio)
        Me.grOrdenar.Controls.Add(Me.rdSaldoProveedorCompra)
        Me.grOrdenar.Controls.Add(Me.rdGenerarArchivoInventario)
        Me.grOrdenar.Controls.Add(Me.rdInventario)
        Me.grOrdenar.Controls.Add(Me.rdArchivoVentaTxt)
        Me.grOrdenar.Controls.Add(Me.rdRg90)
        Me.grOrdenar.Controls.Add(Me.rdVenta)
        Me.grOrdenar.Controls.Add(Me.rdCompra)
        Me.grOrdenar.Location = New System.Drawing.Point(16, 155)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Size = New System.Drawing.Size(608, 135)
        Me.grOrdenar.TabIndex = 99
        Me.grOrdenar.TabStop = False
        '
        'rdArchivoCompra
        '
        Me.rdArchivoCompra.AutoSize = True
        Me.rdArchivoCompra.Location = New System.Drawing.Point(163, 100)
        Me.rdArchivoCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.rdArchivoCompra.Name = "rdArchivoCompra"
        Me.rdArchivoCompra.Size = New System.Drawing.Size(213, 21)
        Me.rdArchivoCompra.TabIndex = 27
        Me.rdArchivoCompra.Text = "Generar Archivo de Compras"
        Me.rdArchivoCompra.UseVisualStyleBackColor = True
        '
        'rdNotaCredito
        '
        Me.rdNotaCredito.AutoSize = True
        Me.rdNotaCredito.Location = New System.Drawing.Point(11, 100)
        Me.rdNotaCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.rdNotaCredito.Name = "rdNotaCredito"
        Me.rdNotaCredito.Size = New System.Drawing.Size(135, 21)
        Me.rdNotaCredito.TabIndex = 26
        Me.rdNotaCredito.Text = "Nota de Creditos"
        Me.rdNotaCredito.UseVisualStyleBackColor = True
        '
        'rdTimbrados
        '
        Me.rdTimbrados.AutoSize = True
        Me.rdTimbrados.Location = New System.Drawing.Point(380, 71)
        Me.rdTimbrados.Margin = New System.Windows.Forms.Padding(4)
        Me.rdTimbrados.Name = "rdTimbrados"
        Me.rdTimbrados.Size = New System.Drawing.Size(171, 21)
        Me.rdTimbrados.TabIndex = 25
        Me.rdTimbrados.Text = "Reporte de Timbrados"
        Me.rdTimbrados.UseVisualStyleBackColor = True
        '
        'rdArchivoEstudio
        '
        Me.rdArchivoEstudio.AutoSize = True
        Me.rdArchivoEstudio.Location = New System.Drawing.Point(380, 44)
        Me.rdArchivoEstudio.Margin = New System.Windows.Forms.Padding(4)
        Me.rdArchivoEstudio.Name = "rdArchivoEstudio"
        Me.rdArchivoEstudio.Size = New System.Drawing.Size(217, 21)
        Me.rdArchivoEstudio.TabIndex = 24
        Me.rdArchivoEstudio.Text = "Generar Archivo Estudio Con."
        Me.rdArchivoEstudio.UseVisualStyleBackColor = True
        '
        'rdSaldoProveedorCompra
        '
        Me.rdSaldoProveedorCompra.AutoSize = True
        Me.rdSaldoProveedorCompra.Location = New System.Drawing.Point(380, 16)
        Me.rdSaldoProveedorCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.rdSaldoProveedorCompra.Name = "rdSaldoProveedorCompra"
        Me.rdSaldoProveedorCompra.Size = New System.Drawing.Size(197, 21)
        Me.rdSaldoProveedorCompra.TabIndex = 23
        Me.rdSaldoProveedorCompra.Text = "Saldo Proveedor - Compra"
        Me.rdSaldoProveedorCompra.UseVisualStyleBackColor = True
        '
        'rdGenerarArchivoInventario
        '
        Me.rdGenerarArchivoInventario.AutoSize = True
        Me.rdGenerarArchivoInventario.Location = New System.Drawing.Point(163, 71)
        Me.rdGenerarArchivoInventario.Margin = New System.Windows.Forms.Padding(4)
        Me.rdGenerarArchivoInventario.Name = "rdGenerarArchivoInventario"
        Me.rdGenerarArchivoInventario.Size = New System.Drawing.Size(199, 21)
        Me.rdGenerarArchivoInventario.TabIndex = 22
        Me.rdGenerarArchivoInventario.Text = "Generar Archivo Inventario"
        Me.rdGenerarArchivoInventario.UseVisualStyleBackColor = True
        '
        'rdInventario
        '
        Me.rdInventario.AutoSize = True
        Me.rdInventario.Location = New System.Drawing.Point(163, 44)
        Me.rdInventario.Margin = New System.Windows.Forms.Padding(4)
        Me.rdInventario.Name = "rdInventario"
        Me.rdInventario.Size = New System.Drawing.Size(91, 21)
        Me.rdInventario.TabIndex = 21
        Me.rdInventario.Text = "Inventario"
        Me.rdInventario.UseVisualStyleBackColor = True
        '
        'rdArchivoVentaTxt
        '
        Me.rdArchivoVentaTxt.AutoSize = True
        Me.rdArchivoVentaTxt.Location = New System.Drawing.Point(163, 16)
        Me.rdArchivoVentaTxt.Margin = New System.Windows.Forms.Padding(4)
        Me.rdArchivoVentaTxt.Name = "rdArchivoVentaTxt"
        Me.rdArchivoVentaTxt.Size = New System.Drawing.Size(174, 21)
        Me.rdArchivoVentaTxt.TabIndex = 20
        Me.rdArchivoVentaTxt.Text = "Generar Archivo Venta"
        Me.rdArchivoVentaTxt.UseVisualStyleBackColor = True
        '
        'rdRg90
        '
        Me.rdRg90.AutoSize = True
        Me.rdRg90.Location = New System.Drawing.Point(11, 71)
        Me.rdRg90.Margin = New System.Windows.Forms.Padding(4)
        Me.rdRg90.Name = "rdRg90"
        Me.rdRg90.Size = New System.Drawing.Size(70, 21)
        Me.rdRg90.TabIndex = 19
        Me.rdRg90.Text = "RG 90"
        Me.rdRg90.UseVisualStyleBackColor = True
        '
        'rdVenta
        '
        Me.rdVenta.AutoSize = True
        Me.rdVenta.Location = New System.Drawing.Point(11, 44)
        Me.rdVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.rdVenta.Name = "rdVenta"
        Me.rdVenta.Size = New System.Drawing.Size(66, 21)
        Me.rdVenta.TabIndex = 18
        Me.rdVenta.Text = "&Venta"
        Me.rdVenta.UseVisualStyleBackColor = True
        '
        'rdCompra
        '
        Me.rdCompra.AutoSize = True
        Me.rdCompra.Checked = True
        Me.rdCompra.Location = New System.Drawing.Point(11, 16)
        Me.rdCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCompra.Name = "rdCompra"
        Me.rdCompra.Size = New System.Drawing.Size(78, 21)
        Me.rdCompra.TabIndex = 17
        Me.rdCompra.TabStop = True
        Me.rdCompra.Text = "C&ompra"
        Me.rdCompra.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdDetalle)
        Me.GroupBox3.Controls.Add(Me.rdResumen)
        Me.GroupBox3.Location = New System.Drawing.Point(391, 16)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(213, 59)
        Me.GroupBox3.TabIndex = 100
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdDetalle
        '
        Me.rdDetalle.AutoSize = True
        Me.rdDetalle.Location = New System.Drawing.Point(112, 23)
        Me.rdDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDetalle.Name = "rdDetalle"
        Me.rdDetalle.Size = New System.Drawing.Size(89, 21)
        Me.rdDetalle.TabIndex = 19
        Me.rdDetalle.Text = "&Detallado"
        Me.rdDetalle.UseVisualStyleBackColor = True
        '
        'rdResumen
        '
        Me.rdResumen.AutoSize = True
        Me.rdResumen.Checked = True
        Me.rdResumen.Location = New System.Drawing.Point(8, 23)
        Me.rdResumen.Margin = New System.Windows.Forms.Padding(4)
        Me.rdResumen.Name = "rdResumen"
        Me.rdResumen.Size = New System.Drawing.Size(92, 21)
        Me.rdResumen.TabIndex = 18
        Me.rdResumen.TabStop = True
        Me.rdResumen.Text = "&Resumido"
        Me.rdResumen.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboEmpresaContable)
        Me.GroupBox4.Location = New System.Drawing.Point(681, 132)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(472, 76)
        Me.GroupBox4.TabIndex = 97
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Empresa Contable"
        '
        'cboEmpresaContable
        '
        Me.cboEmpresaContable.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboEmpresaContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresaContable.FormattingEnabled = True
        Me.cboEmpresaContable.Location = New System.Drawing.Point(19, 32)
        Me.cboEmpresaContable.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEmpresaContable.Name = "cboEmpresaContable"
        Me.cboEmpresaContable.Size = New System.Drawing.Size(437, 28)
        Me.cboEmpresaContable.TabIndex = 50
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(11, 688)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(1200, 24)
        Me.txtSql.TabIndex = 97
        Me.txtSql.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lvCabecera)
        Me.GroupBox5.Controls.Add(Me.btnExportarCabecera)
        Me.GroupBox5.Controls.Add(Me.lblIva5)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.lblGra5)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.lblIva10)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.lblGra10)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.lblTotalTxt)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.btnExportarDetalle)
        Me.GroupBox5.Controls.Add(Me.lvArchivo)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 297)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(1211, 462)
        Me.GroupBox5.TabIndex = 101
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Archivo de Venta TXT"
        '
        'lvCabecera
        '
        Me.lvCabecera.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCab_nro, Me.lvCab_periodo, Me.lvCab_original, Me.lvCab_formulario, Me.lvCab_obligacion, Me.lvCab_rucEmpresa, Me.lvCab_dvEmpresa, Me.lvCab_empresa, Me.lvCab_rucRepre, Me.lvCab_dvRepre, Me.lvCab_repre, Me.lvCab_cantReg, Me.lvCab_totalVenta})
        Me.lvCabecera.Location = New System.Drawing.Point(8, 23)
        Me.lvCabecera.Margin = New System.Windows.Forms.Padding(4)
        Me.lvCabecera.Name = "lvCabecera"
        Me.lvCabecera.Size = New System.Drawing.Size(1188, 93)
        Me.lvCabecera.TabIndex = 115
        Me.lvCabecera.UseCompatibleStateImageBehavior = False
        Me.lvCabecera.View = System.Windows.Forms.View.Details
        '
        'lvCab_nro
        '
        Me.lvCab_nro.Text = "Nro."
        Me.lvCab_nro.Width = 50
        '
        'lvCab_periodo
        '
        Me.lvCab_periodo.Text = "Periodo"
        '
        'lvCab_original
        '
        Me.lvCab_original.Text = "Or."
        Me.lvCab_original.Width = 30
        '
        'lvCab_formulario
        '
        Me.lvCab_formulario.Text = "For."
        Me.lvCab_formulario.Width = 40
        '
        'lvCab_obligacion
        '
        Me.lvCab_obligacion.Text = "Obl"
        Me.lvCab_obligacion.Width = 40
        '
        'lvCab_rucEmpresa
        '
        Me.lvCab_rucEmpresa.Text = "RUC Emp."
        Me.lvCab_rucEmpresa.Width = 70
        '
        'lvCab_dvEmpresa
        '
        Me.lvCab_dvEmpresa.Text = "DV E."
        Me.lvCab_dvEmpresa.Width = 40
        '
        'lvCab_empresa
        '
        Me.lvCab_empresa.Text = "Empresa"
        Me.lvCab_empresa.Width = 200
        '
        'lvCab_rucRepre
        '
        Me.lvCab_rucRepre.Text = "RUC Rep"
        Me.lvCab_rucRepre.Width = 80
        '
        'lvCab_dvRepre
        '
        Me.lvCab_dvRepre.Text = "DV Re."
        Me.lvCab_dvRepre.Width = 50
        '
        'lvCab_repre
        '
        Me.lvCab_repre.Text = "Representante"
        Me.lvCab_repre.Width = 180
        '
        'lvCab_cantReg
        '
        Me.lvCab_cantReg.Text = "Reg."
        Me.lvCab_cantReg.Width = 70
        '
        'lvCab_totalVenta
        '
        Me.lvCab_totalVenta.Text = "Total Gral"
        Me.lvCab_totalVenta.Width = 90
        '
        'btnExportarCabecera
        '
        Me.btnExportarCabecera.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarCabecera.Image = CType(resources.GetObject("btnExportarCabecera.Image"), System.Drawing.Image)
        Me.btnExportarCabecera.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportarCabecera.Location = New System.Drawing.Point(916, 385)
        Me.btnExportarCabecera.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportarCabecera.Name = "btnExportarCabecera"
        Me.btnExportarCabecera.Size = New System.Drawing.Size(124, 46)
        Me.btnExportarCabecera.TabIndex = 114
        Me.btnExportarCabecera.Text = "Exp. Cabecera"
        Me.btnExportarCabecera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportarCabecera.UseVisualStyleBackColor = True
        '
        'lblIva5
        '
        Me.lblIva5.AutoSize = True
        Me.lblIva5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lblIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva5.Location = New System.Drawing.Point(716, 425)
        Me.lblIva5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIva5.Name = "lblIva5"
        Me.lblIva5.Size = New System.Drawing.Size(63, 20)
        Me.lblIva5.TabIndex = 113
        Me.lblIva5.Text = "lblIva5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(623, 425)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "IVA 5% :"
        '
        'lblGra5
        '
        Me.lblGra5.AutoSize = True
        Me.lblGra5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lblGra5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGra5.Location = New System.Drawing.Point(713, 385)
        Me.lblGra5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGra5.Name = "lblGra5"
        Me.lblGra5.Size = New System.Drawing.Size(70, 20)
        Me.lblGra5.TabIndex = 111
        Me.lblGra5.Text = "lblGra5"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(577, 385)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 20)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Gravada 5% :"
        '
        'lblIva10
        '
        Me.lblIva10.AutoSize = True
        Me.lblIva10.BackColor = System.Drawing.Color.LawnGreen
        Me.lblIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva10.Location = New System.Drawing.Point(403, 425)
        Me.lblIva10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIva10.Name = "lblIva10"
        Me.lblIva10.Size = New System.Drawing.Size(73, 20)
        Me.lblIva10.TabIndex = 109
        Me.lblIva10.Text = "lblIva10"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(301, 425)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "IVA 10% :"
        '
        'lblGra10
        '
        Me.lblGra10.AutoSize = True
        Me.lblGra10.BackColor = System.Drawing.Color.LawnGreen
        Me.lblGra10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGra10.Location = New System.Drawing.Point(403, 385)
        Me.lblGra10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGra10.Name = "lblGra10"
        Me.lblGra10.Size = New System.Drawing.Size(80, 20)
        Me.lblGra10.TabIndex = 107
        Me.lblGra10.Text = "lblGra10"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 385)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 20)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Gravada 10% :"
        '
        'lblTotalTxt
        '
        Me.lblTotalTxt.AutoSize = True
        Me.lblTotalTxt.BackColor = System.Drawing.Color.Yellow
        Me.lblTotalTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTxt.Location = New System.Drawing.Point(96, 398)
        Me.lblTotalTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalTxt.Name = "lblTotalTxt"
        Me.lblTotalTxt.Size = New System.Drawing.Size(97, 20)
        Me.lblTotalTxt.TabIndex = 97
        Me.lblTotalTxt.Text = "lblTotalTxt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 398)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 20)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Total :"
        '
        'btnExportarDetalle
        '
        Me.btnExportarDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarDetalle.Image = CType(resources.GetObject("btnExportarDetalle.Image"), System.Drawing.Image)
        Me.btnExportarDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportarDetalle.Location = New System.Drawing.Point(1048, 385)
        Me.btnExportarDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportarDetalle.Name = "btnExportarDetalle"
        Me.btnExportarDetalle.Size = New System.Drawing.Size(124, 46)
        Me.btnExportarDetalle.TabIndex = 95
        Me.btnExportarDetalle.Text = "Exp. Detalle"
        Me.btnExportarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportarDetalle.UseVisualStyleBackColor = True
        '
        'lvArchivo
        '
        Me.lvArchivo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_nro, Me.det_rucCliente, Me.det_dvCliente, Me.det_nombreCliente, Me.det_tipoDoc, Me.det_factura, Me.det_fecha, Me.det_gra10, Me.det_iva10, Me.det_gra5, Me.det_iva5, Me.det_exenta, Me.det_total, Me.det_archivo})
        Me.lvArchivo.Location = New System.Drawing.Point(12, 132)
        Me.lvArchivo.Margin = New System.Windows.Forms.Padding(4)
        Me.lvArchivo.Name = "lvArchivo"
        Me.lvArchivo.Size = New System.Drawing.Size(1188, 245)
        Me.lvArchivo.TabIndex = 4
        Me.lvArchivo.UseCompatibleStateImageBehavior = False
        Me.lvArchivo.View = System.Windows.Forms.View.Details
        '
        'det_nro
        '
        Me.det_nro.Text = "Nro."
        Me.det_nro.Width = 50
        '
        'det_rucCliente
        '
        Me.det_rucCliente.Text = "Ruc"
        '
        'det_dvCliente
        '
        Me.det_dvCliente.Text = "DV"
        Me.det_dvCliente.Width = 30
        '
        'det_nombreCliente
        '
        Me.det_nombreCliente.Text = "Cliente"
        Me.det_nombreCliente.Width = 200
        '
        'det_tipoDoc
        '
        Me.det_tipoDoc.Text = "TipoD."
        Me.det_tipoDoc.Width = 45
        '
        'det_factura
        '
        Me.det_factura.Text = "Factura"
        Me.det_factura.Width = 130
        '
        'det_fecha
        '
        Me.det_fecha.Text = "Fecha"
        Me.det_fecha.Width = 80
        '
        'det_gra10
        '
        Me.det_gra10.Text = "Grav.10"
        Me.det_gra10.Width = 70
        '
        'det_iva10
        '
        Me.det_iva10.Text = "IVA10"
        Me.det_iva10.Width = 70
        '
        'det_gra5
        '
        Me.det_gra5.Text = "Grav.5"
        Me.det_gra5.Width = 70
        '
        'det_iva5
        '
        Me.det_iva5.Text = "IVA5"
        Me.det_iva5.Width = 70
        '
        'det_exenta
        '
        Me.det_exenta.Text = "Exenta"
        Me.det_exenta.Width = 70
        '
        'det_total
        '
        Me.det_total.Text = "Total"
        Me.det_total.Width = 70
        '
        'det_archivo
        '
        Me.det_archivo.Text = "archivo"
        Me.det_archivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.det_archivo.Width = 100
        '
        'btnActualizar
        '
        Me.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizar.Location = New System.Drawing.Point(632, 209)
        Me.btnActualizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(92, 46)
        Me.btnActualizar.TabIndex = 97
        Me.btnActualizar.Text = "&Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'chkSoloExcel
        '
        Me.chkSoloExcel.AutoSize = True
        Me.chkSoloExcel.BackColor = System.Drawing.SystemColors.Control
        Me.chkSoloExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkSoloExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkSoloExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoloExcel.Location = New System.Drawing.Point(399, 101)
        Me.chkSoloExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSoloExcel.Name = "chkSoloExcel"
        Me.chkSoloExcel.Size = New System.Drawing.Size(110, 24)
        Me.chkSoloExcel.TabIndex = 102
        Me.chkSoloExcel.Text = "Solo Excel"
        Me.chkSoloExcel.UseVisualStyleBackColor = False
        '
        'frmReporteLibroIVA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 772)
        Me.Controls.Add(Me.chkSoloExcel)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteLibroIVA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Libro IVA "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIdSucursal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rdCompra As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumen As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboEmpresaContable As System.Windows.Forms.ComboBox
    Friend WithEvents rdRg90 As System.Windows.Forms.RadioButton
    Friend WithEvents rdArchivoVentaTxt As System.Windows.Forms.RadioButton
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lvArchivo As System.Windows.Forms.ListView
    Friend WithEvents det_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_rucCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnExportarDetalle As System.Windows.Forms.Button
    Friend WithEvents lblTotalTxt As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdInventario As System.Windows.Forms.RadioButton
    Friend WithEvents rdGenerarArchivoInventario As System.Windows.Forms.RadioButton
    Friend WithEvents rdSaldoProveedorCompra As System.Windows.Forms.RadioButton
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents lblIva5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblGra5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblIva10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblGra10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExportarCabecera As System.Windows.Forms.Button
    Friend WithEvents lvCabecera As System.Windows.Forms.ListView
    Friend WithEvents lvCab_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_periodo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_original As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_formulario As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_obligacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_rucEmpresa As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_dvEmpresa As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_empresa As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_rucRepre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_dvRepre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_repre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_cantReg As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCab_totalVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_dvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_nombreCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_gra10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_iva10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_gra5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_iva5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_exenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_archivo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_tipoDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents rdArchivoEstudio As System.Windows.Forms.RadioButton
    Friend WithEvents rdTimbrados As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents rdNotaCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rdArchivoCompra As System.Windows.Forms.RadioButton
    Friend WithEvents chkSoloExcel As System.Windows.Forms.CheckBox
End Class
