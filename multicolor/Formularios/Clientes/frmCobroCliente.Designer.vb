<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobroCliente
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCobroCliente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCel2 = New System.Windows.Forms.TextBox()
        Me.txtCel1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grCabPago = New System.Windows.Forms.GroupBox()
        Me.dtgPago = New System.Windows.Forms.DataGridView()
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grDetPago = New System.Windows.Forms.GroupBox()
        Me.lvDetPago = New System.Windows.Forms.ListView()
        Me.detPago_nroCuota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detPago_cuota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detPago_vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detPago_pagado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detPago_pago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detPago_habPago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grMonto = New System.Windows.Forms.GroupBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdPorFactura = New System.Windows.Forms.RadioButton()
        Me.rdPorMonto = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalSaldo = New System.Windows.Forms.TextBox()
        Me.txtTotalMonto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalPagado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtPagado = New System.Windows.Forms.TextBox()
        Me.grPagoPorFactura = New System.Windows.Forms.GroupBox()
        Me.dtgPagoCuota = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nroCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtTotalNotaCr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grCabPago.SuspendLayout()
        CType(Me.dtgPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grDetPago.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grMonto.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grPagoPorFactura.SuspendLayout()
        CType(Me.dtgPagoCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtGrupo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCel2)
        Me.GroupBox1.Controls.Add(Me.txtCel1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.txtIdCliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(884, 91)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'txtGrupo
        '
        Me.txtGrupo.BackColor = System.Drawing.Color.Pink
        Me.txtGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupo.Location = New System.Drawing.Point(54, 64)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.ReadOnly = True
        Me.txtGrupo.Size = New System.Drawing.Size(265, 22)
        Me.txtGrupo.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Grupo:"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.LightBlue
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(520, 40)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(358, 22)
        Me.txtEmail.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(475, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "email:"
        '
        'txtCel2
        '
        Me.txtCel2.BackColor = System.Drawing.Color.LightBlue
        Me.txtCel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCel2.Location = New System.Drawing.Point(664, 16)
        Me.txtCel2.Name = "txtCel2"
        Me.txtCel2.ReadOnly = True
        Me.txtCel2.Size = New System.Drawing.Size(121, 22)
        Me.txtCel2.TabIndex = 7
        '
        'txtCel1
        '
        Me.txtCel1.BackColor = System.Drawing.Color.LightBlue
        Me.txtCel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCel1.Location = New System.Drawing.Point(527, 16)
        Me.txtCel1.Name = "txtCel1"
        Me.txtCel1.ReadOnly = True
        Me.txtCel1.Size = New System.Drawing.Size(121, 22)
        Me.txtCel1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(475, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Celular:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.LightBlue
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(69, 40)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(397, 22)
        Me.txtDireccion.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Dirección:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(139, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(327, 22)
        Me.txtCliente.TabIndex = 2
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.LawnGreen
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(69, 16)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(64, 22)
        Me.txtIdCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id Cliente:"
        '
        'grCabPago
        '
        Me.grCabPago.Controls.Add(Me.dtgPago)
        Me.grCabPago.Location = New System.Drawing.Point(16, 100)
        Me.grCabPago.Name = "grCabPago"
        Me.grCabPago.Size = New System.Drawing.Size(663, 228)
        Me.grCabPago.TabIndex = 2
        Me.grCabPago.TabStop = False
        Me.grCabPago.Text = "Deudas por Factura"
        Me.grCabPago.Visible = False
        '
        'dtgPago
        '
        Me.dtgPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.idMov, Me.Column2, Me.Column3, Me.Column9, Me.pagado, Me.Column6, Me.saldo, Me.Column4})
        Me.dtgPago.Location = New System.Drawing.Point(9, 19)
        Me.dtgPago.Name = "dtgPago"
        Me.dtgPago.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dtgPago.Size = New System.Drawing.Size(633, 194)
        Me.dtgPago.TabIndex = 116
        '
        'Column0
        '
        Me.Column0.Frozen = True
        Me.Column0.HeaderText = "Nro"
        Me.Column0.Name = "Column0"
        Me.Column0.ReadOnly = True
        Me.Column0.Width = 30
        '
        'idMov
        '
        Me.idMov.Frozen = True
        Me.idMov.HeaderText = "IdMov."
        Me.idMov.Name = "idMov"
        Me.idMov.ReadOnly = True
        Me.idMov.Width = 70
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Factura"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 150.0!
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Fecha"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column9
        '
        Me.Column9.Frozen = True
        Me.Column9.HeaderText = "TotalFact."
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 70
        '
        'pagado
        '
        Me.pagado.Frozen = True
        Me.pagado.HeaderText = "Pagado"
        Me.pagado.Name = "pagado"
        Me.pagado.ReadOnly = True
        Me.pagado.Width = 70
        '
        'Column6
        '
        Me.Column6.Frozen = True
        Me.Column6.HeaderText = "TotalPag."
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 70
        '
        'saldo
        '
        Me.saldo.Frozen = True
        Me.saldo.HeaderText = "Saldo"
        Me.saldo.Name = "saldo"
        Me.saldo.ReadOnly = True
        Me.saldo.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Pag."
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 30
        '
        'grDetPago
        '
        Me.grDetPago.Controls.Add(Me.lvDetPago)
        Me.grDetPago.Location = New System.Drawing.Point(14, 334)
        Me.grDetPago.Name = "grDetPago"
        Me.grDetPago.Size = New System.Drawing.Size(378, 185)
        Me.grDetPago.TabIndex = 117
        Me.grDetPago.TabStop = False
        Me.grDetPago.Text = "Detalle de Cuotas"
        Me.grDetPago.Visible = False
        '
        'lvDetPago
        '
        Me.lvDetPago.AllowColumnReorder = True
        Me.lvDetPago.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detPago_nroCuota, Me.detPago_cuota, Me.detPago_vence, Me.detPago_pagado, Me.detPago_pago, Me.detPago_habPago})
        Me.lvDetPago.FullRowSelect = True
        Me.lvDetPago.GridLines = True
        Me.lvDetPago.HideSelection = False
        Me.lvDetPago.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvDetPago.LabelWrap = False
        Me.lvDetPago.Location = New System.Drawing.Point(6, 19)
        Me.lvDetPago.MultiSelect = False
        Me.lvDetPago.Name = "lvDetPago"
        Me.lvDetPago.Size = New System.Drawing.Size(357, 159)
        Me.lvDetPago.TabIndex = 123
        Me.lvDetPago.UseCompatibleStateImageBehavior = False
        Me.lvDetPago.View = System.Windows.Forms.View.Details
        '
        'detPago_nroCuota
        '
        Me.detPago_nroCuota.Text = "Nro"
        Me.detPago_nroCuota.Width = 30
        '
        'detPago_cuota
        '
        Me.detPago_cuota.Text = "Cuota"
        Me.detPago_cuota.Width = 80
        '
        'detPago_vence
        '
        Me.detPago_vence.Text = "Vence"
        Me.detPago_vence.Width = 80
        '
        'detPago_pagado
        '
        Me.detPago_pagado.Text = "Pagado"
        '
        'detPago_pago
        '
        Me.detPago_pago.Text = "Pago"
        '
        'detPago_habPago
        '
        Me.detPago_habPago.Text = "Pag."
        Me.detPago_habPago.Width = 40
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.grMonto)
        Me.GroupBox4.Controls.Add(Me.grOrdenar)
        Me.GroupBox4.Location = New System.Drawing.Point(807, 125)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(172, 163)
        Me.GroupBox4.TabIndex = 124
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Forma de Cobro"
        '
        'grMonto
        '
        Me.grMonto.Controls.Add(Me.txtMonto)
        Me.grMonto.Controls.Add(Me.Label5)
        Me.grMonto.Controls.Add(Me.btnProcesar)
        Me.grMonto.Location = New System.Drawing.Point(6, 85)
        Me.grMonto.Name = "grMonto"
        Me.grMonto.Size = New System.Drawing.Size(159, 69)
        Me.grMonto.TabIndex = 100
        Me.grMonto.TabStop = False
        Me.grMonto.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMonto.Location = New System.Drawing.Point(4, 34)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(90, 22)
        Me.txtMonto.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Monto"
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdPorFactura)
        Me.grOrdenar.Controls.Add(Me.rdPorMonto)
        Me.grOrdenar.Location = New System.Drawing.Point(4, 19)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(93, 67)
        Me.grOrdenar.TabIndex = 99
        Me.grOrdenar.TabStop = False
        '
        'rdPorFactura
        '
        Me.rdPorFactura.AutoSize = True
        Me.rdPorFactura.Checked = True
        Me.rdPorFactura.Location = New System.Drawing.Point(8, 36)
        Me.rdPorFactura.Name = "rdPorFactura"
        Me.rdPorFactura.Size = New System.Drawing.Size(80, 17)
        Me.rdPorFactura.TabIndex = 18
        Me.rdPorFactura.TabStop = True
        Me.rdPorFactura.Text = "Por &Factura"
        Me.rdPorFactura.UseVisualStyleBackColor = True
        '
        'rdPorMonto
        '
        Me.rdPorMonto.AutoSize = True
        Me.rdPorMonto.Location = New System.Drawing.Point(8, 13)
        Me.rdPorMonto.Name = "rdPorMonto"
        Me.rdPorMonto.Size = New System.Drawing.Size(74, 17)
        Me.rdPorMonto.TabIndex = 17
        Me.rdPorMonto.Text = "&Por Monto"
        Me.rdPorMonto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(883, 345)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 16)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Total Monto"
        '
        'txtTotalSaldo
        '
        Me.txtTotalSaldo.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSaldo.Location = New System.Drawing.Point(868, 496)
        Me.txtTotalSaldo.Name = "txtTotalSaldo"
        Me.txtTotalSaldo.ReadOnly = True
        Me.txtTotalSaldo.Size = New System.Drawing.Size(106, 22)
        Me.txtTotalSaldo.TabIndex = 132
        Me.txtTotalSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalMonto
        '
        Me.txtTotalMonto.BackColor = System.Drawing.Color.PaleGreen
        Me.txtTotalMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMonto.Location = New System.Drawing.Point(869, 363)
        Me.txtTotalMonto.Name = "txtTotalMonto"
        Me.txtTotalMonto.ReadOnly = True
        Me.txtTotalMonto.Size = New System.Drawing.Size(105, 22)
        Me.txtTotalMonto.TabIndex = 129
        Me.txtTotalMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(881, 479)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 16)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Total Saldo"
        '
        'txtTotalPagado
        '
        Me.txtTotalPagado.BackColor = System.Drawing.Color.Thistle
        Me.txtTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagado.Location = New System.Drawing.Point(866, 408)
        Me.txtTotalPagado.Name = "txtTotalPagado"
        Me.txtTotalPagado.ReadOnly = True
        Me.txtTotalPagado.Size = New System.Drawing.Size(105, 22)
        Me.txtTotalPagado.TabIndex = 133
        Me.txtTotalPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(873, 390)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 16)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "Total Pagado"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtPagado)
        Me.GroupBox5.Location = New System.Drawing.Point(810, 288)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(172, 55)
        Me.GroupBox5.TabIndex = 134
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Total Pagado"
        '
        'txtPagado
        '
        Me.txtPagado.BackColor = System.Drawing.Color.Aquamarine
        Me.txtPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagado.Location = New System.Drawing.Point(6, 19)
        Me.txtPagado.Name = "txtPagado"
        Me.txtPagado.ReadOnly = True
        Me.txtPagado.Size = New System.Drawing.Size(157, 29)
        Me.txtPagado.TabIndex = 133
        Me.txtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grPagoPorFactura
        '
        Me.grPagoPorFactura.Controls.Add(Me.dtgPagoCuota)
        Me.grPagoPorFactura.Location = New System.Drawing.Point(5, 100)
        Me.grPagoPorFactura.Name = "grPagoPorFactura"
        Me.grPagoPorFactura.Size = New System.Drawing.Size(799, 424)
        Me.grPagoPorFactura.TabIndex = 12
        Me.grPagoPorFactura.TabStop = False
        Me.grPagoPorFactura.Text = "Cobro por Cuota"
        '
        'dtgPagoCuota
        '
        Me.dtgPagoCuota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPagoCuota.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgPagoCuota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPagoCuota.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column1, Me.idCuota, Me.DataGridViewTextBoxColumn2, Me.cotiza, Me.nroCuota, Me.DataGridViewTextBoxColumn4, Me.Column5, Me.Column7, Me.DataGridViewTextBoxColumn5, Me.totalSaldo, Me.DataGridViewCheckBoxColumn1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgPagoCuota.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgPagoCuota.Location = New System.Drawing.Point(2, 25)
        Me.dtgPagoCuota.Name = "dtgPagoCuota"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPagoCuota.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgPagoCuota.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dtgPagoCuota.Size = New System.Drawing.Size(783, 383)
        Me.dtgPagoCuota.TabIndex = 116
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nro"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 30
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "IDMov."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 50
        '
        'idCuota
        '
        Me.idCuota.Frozen = True
        Me.idCuota.HeaderText = "idCuota"
        Me.idCuota.Name = "idCuota"
        Me.idCuota.ReadOnly = True
        Me.idCuota.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Factura"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cotiza
        '
        Me.cotiza.Frozen = True
        Me.cotiza.HeaderText = "Vence"
        Me.cotiza.Name = "cotiza"
        Me.cotiza.ReadOnly = True
        Me.cotiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cotiza.Width = 80
        '
        'nroCuota
        '
        Me.nroCuota.Frozen = True
        Me.nroCuota.HeaderText = "Nro.Cuo."
        Me.nroCuota.Name = "nroCuota"
        Me.nroCuota.ReadOnly = True
        Me.nroCuota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nroCuota.Width = 40
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cuota"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nota Cr."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "Pagado"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Pago"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'totalSaldo
        '
        Me.totalSaldo.HeaderText = "Saldo"
        Me.totalSaldo.Name = "totalSaldo"
        Me.totalSaldo.ReadOnly = True
        Me.totalSaldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.totalSaldo.Width = 70
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Pag."
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 40
        '
        'txtTotalNotaCr
        '
        Me.txtTotalNotaCr.BackColor = System.Drawing.Color.Pink
        Me.txtTotalNotaCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNotaCr.Location = New System.Drawing.Point(866, 450)
        Me.txtTotalNotaCr.Name = "txtTotalNotaCr"
        Me.txtTotalNotaCr.ReadOnly = True
        Me.txtTotalNotaCr.Size = New System.Drawing.Size(106, 22)
        Me.txtTotalNotaCr.TabIndex = 136
        Me.txtTotalNotaCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(873, 433)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 16)
        Me.Label9.TabIndex = 135
        Me.Label9.Text = "Total Nota Cr."
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(912, 86)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(61, 37)
        Me.btnCancelar.TabIndex = 140
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(912, 43)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(61, 37)
        Me.btnGuardar.TabIndex = 139
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(912, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(61, 37)
        Me.btnNuevo.TabIndex = 138
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(99, 19)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(58, 37)
        Me.btnProcesar.TabIndex = 137
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'frmCobroCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 526)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtTotalNotaCr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.grPagoPorFactura)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotalSaldo)
        Me.Controls.Add(Me.txtTotalMonto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotalPagado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grDetPago)
        Me.Controls.Add(Me.grCabPago)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCobroCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobro a Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grCabPago.ResumeLayout(False)
        CType(Me.dtgPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grDetPago.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.grMonto.ResumeLayout(False)
        Me.grMonto.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.grPagoPorFactura.ResumeLayout(False)
        CType(Me.dtgPagoCuota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCel2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grCabPago As System.Windows.Forms.GroupBox
    Friend WithEvents dtgPago As System.Windows.Forms.DataGridView
    Friend WithEvents grDetPago As System.Windows.Forms.GroupBox
    Friend WithEvents lvDetPago As System.Windows.Forms.ListView
    Friend WithEvents detPago_nroCuota As System.Windows.Forms.ColumnHeader
    Friend WithEvents detPago_cuota As System.Windows.Forms.ColumnHeader
    Friend WithEvents detPago_vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents detPago_pagado As System.Windows.Forms.ColumnHeader
    Friend WithEvents detPago_habPago As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grMonto As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdPorFactura As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorMonto As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPagado As System.Windows.Forms.TextBox
    Friend WithEvents Column0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pagado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents detPago_pago As System.Windows.Forms.ColumnHeader
    Friend WithEvents grPagoPorFactura As System.Windows.Forms.GroupBox
    Friend WithEvents dtgPagoCuota As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idCuota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cotiza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nroCuota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtTotalNotaCr As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
End Class
