<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaAjusteNegativo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaAjusteNegativo))
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtPc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCargadoPor = New System.Windows.Forms.TextBox()
        Me.motivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIdAjuste = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.lvProducto = New System.Windows.Forms.ListView()
        Me.nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Forma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.subtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblEmpresaContable = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDeposito = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAuditor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaCierre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaApertura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdInventario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtExplica = New System.Windows.Forms.TextBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.LightBlue
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(77, 121)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(294, 21)
        Me.txtSucursal.TabIndex = 76
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 15)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Sucursal  :"
        '
        'cantidad
        '
        Me.cantidad.Text = "Cant."
        Me.cantidad.Width = 40
        '
        'txtPc
        '
        Me.txtPc.BackColor = System.Drawing.Color.LightBlue
        Me.txtPc.Enabled = False
        Me.txtPc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPc.Location = New System.Drawing.Point(36, 94)
        Me.txtPc.Name = "txtPc"
        Me.txtPc.Size = New System.Drawing.Size(200, 21)
        Me.txtPc.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 15)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Pc :"
        '
        'txtCargadoPor
        '
        Me.txtCargadoPor.BackColor = System.Drawing.Color.LightBlue
        Me.txtCargadoPor.Enabled = False
        Me.txtCargadoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargadoPor.Location = New System.Drawing.Point(87, 67)
        Me.txtCargadoPor.Name = "txtCargadoPor"
        Me.txtCargadoPor.Size = New System.Drawing.Size(329, 21)
        Me.txtCargadoPor.TabIndex = 22
        '
        'motivo
        '
        Me.motivo.Text = "Motivo"
        Me.motivo.Width = 200
        '
        'codigo
        '
        Me.codigo.Text = "Codigo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 15)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Cargado Por:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 15)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Fecha/Hora Carga:"
        '
        'txtIdAjuste
        '
        Me.txtIdAjuste.BackColor = System.Drawing.Color.Lime
        Me.txtIdAjuste.Enabled = False
        Me.txtIdAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdAjuste.Location = New System.Drawing.Point(76, 17)
        Me.txtIdAjuste.Name = "txtIdAjuste"
        Me.txtIdAjuste.Size = New System.Drawing.Size(76, 24)
        Me.txtIdAjuste.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 18)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "ID Ajuste:"
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Enabled = False
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(113, 44)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(177, 21)
        Me.txtFechaHora.TabIndex = 13
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(523, 420)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 15)
        Me.Label19.TabIndex = 136
        Me.Label19.Text = "Empresa Contable"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnImprimir)
        Me.GroupBox4.Controls.Add(Me.btnBuscar)
        Me.GroupBox4.Controls.Add(Me.btnUltimo)
        Me.GroupBox4.Controls.Add(Me.btnSiguiente)
        Me.GroupBox4.Controls.Add(Me.btnAnterior)
        Me.GroupBox4.Controls.Add(Me.btnPrimero)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 409)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(508, 69)
        Me.GroupBox4.TabIndex = 135
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Controles"
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(433, 19)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 81
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(361, 17)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 80
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnUltimo
        '
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Image = CType(resources.GetObject("btnUltimo.Image"), System.Drawing.Image)
        Me.btnUltimo.Location = New System.Drawing.Point(241, 15)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(69, 37)
        Me.btnUltimo.TabIndex = 79
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguiente.Enabled = False
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(166, 15)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(69, 37)
        Me.btnSiguiente.TabIndex = 78
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(91, 15)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(69, 37)
        Me.btnAnterior.TabIndex = 77
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(16, 15)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(69, 37)
        Me.btnPrimero.TabIndex = 76
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'lvProducto
        '
        Me.lvProducto.AllowColumnReorder = True
        Me.lvProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nro, Me.codigo, Me.mercaderia, Me.Vence, Me.Lote, Me.Forma, Me.Precio, Me.cantidad, Me.subtotal, Me.motivo})
        Me.lvProducto.FullRowSelect = True
        Me.lvProducto.GridLines = True
        Me.lvProducto.HideSelection = False
        Me.lvProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvProducto.LabelWrap = False
        Me.lvProducto.Location = New System.Drawing.Point(9, 23)
        Me.lvProducto.MultiSelect = False
        Me.lvProducto.Name = "lvProducto"
        Me.lvProducto.Size = New System.Drawing.Size(896, 173)
        Me.lvProducto.TabIndex = 115
        Me.lvProducto.UseCompatibleStateImageBehavior = False
        Me.lvProducto.View = System.Windows.Forms.View.Details
        '
        'nro
        '
        Me.nro.Text = "Nro."
        Me.nro.Width = 40
        '
        'mercaderia
        '
        Me.mercaderia.Text = "Nombre del Producto"
        Me.mercaderia.Width = 300
        '
        'Vence
        '
        Me.Vence.Text = "Vence"
        Me.Vence.Width = 50
        '
        'Lote
        '
        Me.Lote.Text = "Lote"
        Me.Lote.Width = 80
        '
        'Forma
        '
        Me.Forma.Text = "Forma"
        '
        'Precio
        '
        Me.Precio.Text = "Precio"
        Me.Precio.Width = 70
        '
        'subtotal
        '
        Me.subtotal.Text = "SubTotal"
        Me.subtotal.Width = 80
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lvProducto)
        Me.GroupBox3.Location = New System.Drawing.Point(1, 198)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(914, 213)
        Me.GroupBox3.TabIndex = 134
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del Ajuste"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtPc)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtCargadoPor)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtFechaHora)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtIdAjuste)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 184)
        Me.GroupBox2.TabIndex = 138
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ajuste Negativo"
        '
        'lblEmpresaContable
        '
        Me.lblEmpresaContable.AutoSize = True
        Me.lblEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaContable.ForeColor = System.Drawing.Color.Maroon
        Me.lblEmpresaContable.Location = New System.Drawing.Point(514, 441)
        Me.lblEmpresaContable.Name = "lblEmpresaContable"
        Me.lblEmpresaContable.Size = New System.Drawing.Size(250, 25)
        Me.lblEmpresaContable.TabIndex = 137
        Me.lblEmpresaContable.Text = "EMPRESA CONTABLE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDeposito)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAuditor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFechaCierre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFechaApertura)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtIdInventario)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(449, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 117)
        Me.GroupBox1.TabIndex = 139
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Inventario"
        '
        'txtDeposito
        '
        Me.txtDeposito.BackColor = System.Drawing.Color.Thistle
        Me.txtDeposito.Enabled = False
        Me.txtDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeposito.Location = New System.Drawing.Point(77, 94)
        Me.txtDeposito.Name = "txtDeposito"
        Me.txtDeposito.Size = New System.Drawing.Size(294, 21)
        Me.txtDeposito.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Deposito  :"
        '
        'txtAuditor
        '
        Me.txtAuditor.BackColor = System.Drawing.Color.Thistle
        Me.txtAuditor.Enabled = False
        Me.txtAuditor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuditor.Location = New System.Drawing.Point(61, 71)
        Me.txtAuditor.Name = "txtAuditor"
        Me.txtAuditor.Size = New System.Drawing.Size(326, 21)
        Me.txtAuditor.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Auditor :"
        '
        'txtFechaCierre
        '
        Me.txtFechaCierre.BackColor = System.Drawing.Color.Thistle
        Me.txtFechaCierre.Enabled = False
        Me.txtFechaCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCierre.Location = New System.Drawing.Point(117, 47)
        Me.txtFechaCierre.Name = "txtFechaCierre"
        Me.txtFechaCierre.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaCierre.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Fecha/Hora Cierre:"
        '
        'txtFechaApertura
        '
        Me.txtFechaApertura.BackColor = System.Drawing.Color.Thistle
        Me.txtFechaApertura.Enabled = False
        Me.txtFechaApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaApertura.Location = New System.Drawing.Point(308, 17)
        Me.txtFechaApertura.Name = "txtFechaApertura"
        Me.txtFechaApertura.Size = New System.Drawing.Size(177, 21)
        Me.txtFechaApertura.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(182, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Fecha/Hora Apertura:"
        '
        'txtIdInventario
        '
        Me.txtIdInventario.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.txtIdInventario.Enabled = False
        Me.txtIdInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdInventario.Location = New System.Drawing.Point(101, 17)
        Me.txtIdInventario.Name = "txtIdInventario"
        Me.txtIdInventario.Size = New System.Drawing.Size(76, 24)
        Me.txtIdInventario.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ID Inventario:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtExplica)
        Me.GroupBox5.Location = New System.Drawing.Point(449, 127)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(494, 74)
        Me.GroupBox5.TabIndex = 140
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Explicación"
        '
        'txtExplica
        '
        Me.txtExplica.BackColor = System.Drawing.Color.PaleGreen
        Me.txtExplica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExplica.Location = New System.Drawing.Point(9, 16)
        Me.txtExplica.Multiline = True
        Me.txtExplica.Name = "txtExplica"
        Me.txtExplica.ReadOnly = True
        Me.txtExplica.Size = New System.Drawing.Size(476, 52)
        Me.txtExplica.TabIndex = 76
        '
        'frmConsultaAjusteNegativo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 495)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblEmpresaContable)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaAjusteNegativo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Ajuste Negativo"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCargadoPor As System.Windows.Forms.TextBox
    Friend WithEvents motivo As System.Windows.Forms.ColumnHeader
    Friend WithEvents codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtIdAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lvProducto As System.Windows.Forms.ListView
    Friend WithEvents nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents Vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents Lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents Forma As System.Windows.Forms.ColumnHeader
    Friend WithEvents Precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents subtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEmpresaContable As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDeposito As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAuditor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCierre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaApertura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdInventario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtExplica As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
End Class
