<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuardarPagoProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuardarPagoProveedor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTotalPagado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalPagar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdProveedor = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblNro = New System.Windows.Forms.Label()
        Me.grEfectivo = New System.Windows.Forms.GroupBox()
        Me.btnCargarEfectivo = New System.Windows.Forms.Button()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdCheque = New System.Windows.Forms.RadioButton()
        Me.rdEfectivo = New System.Windows.Forms.RadioButton()
        Me.dtgPago = New System.Windows.Forms.DataGridView()
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNroRecibo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblCheque = New System.Windows.Forms.Label()
        Me.lblIdChequera = New System.Windows.Forms.Label()
        Me.lvCheque = New System.Windows.Forms.ListView()
        Me.nroCheque = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cuenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.banco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.monto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.idChequera = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grEfectivo.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        CType(Me.dtgPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalPagado)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTotalPagar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIdProveedor)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, -2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(671, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtTotalPagado
        '
        Me.txtTotalPagado.BackColor = System.Drawing.Color.Plum
        Me.txtTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagado.Location = New System.Drawing.Point(483, 58)
        Me.txtTotalPagado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalPagado.Name = "txtTotalPagado"
        Me.txtTotalPagado.ReadOnly = True
        Me.txtTotalPagado.Size = New System.Drawing.Size(173, 30)
        Me.txtTotalPagado.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(352, 63)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 24)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Total Pagado:"
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackColor = System.Drawing.Color.PaleGreen
        Me.txtTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.Location = New System.Drawing.Point(153, 58)
        Me.txtTotalPagar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.Size = New System.Drawing.Size(173, 30)
        Me.txtTotalPagar.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total a Pagar:"
        '
        'txtIdProveedor
        '
        Me.txtIdProveedor.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProveedor.Location = New System.Drawing.Point(561, 20)
        Me.txtIdProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdProveedor.Name = "txtIdProveedor"
        Me.txtIdProveedor.ReadOnly = True
        Me.txtIdProveedor.Size = New System.Drawing.Size(100, 30)
        Me.txtIdProveedor.TabIndex = 2
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(124, 21)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(428, 30)
        Me.txtProveedor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Proveedor:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpFecha)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblNro)
        Me.GroupBox2.Controls.Add(Me.grEfectivo)
        Me.GroupBox2.Controls.Add(Me.grOrdenar)
        Me.GroupBox2.Controls.Add(Me.dtgPago)
        Me.GroupBox2.Controls.Add(Me.txtNroRecibo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 105)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1139, 347)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Pago"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(132, 58)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(124, 29)
        Me.dtpFecha.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(56, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 24)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "Fecha:"
        '
        'lblNro
        '
        Me.lblNro.AutoSize = True
        Me.lblNro.ForeColor = System.Drawing.Color.Maroon
        Me.lblNro.Location = New System.Drawing.Point(1085, 20)
        Me.lblNro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(29, 17)
        Me.lblNro.TabIndex = 7
        Me.lblNro.Text = "nro"
        '
        'grEfectivo
        '
        Me.grEfectivo.Controls.Add(Me.btnCargarEfectivo)
        Me.grEfectivo.Controls.Add(Me.txtMonto)
        Me.grEfectivo.Controls.Add(Me.Label5)
        Me.grEfectivo.Location = New System.Drawing.Point(545, 10)
        Me.grEfectivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grEfectivo.Name = "grEfectivo"
        Me.grEfectivo.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grEfectivo.Size = New System.Drawing.Size(423, 59)
        Me.grEfectivo.TabIndex = 118
        Me.grEfectivo.TabStop = False
        Me.grEfectivo.Visible = False
        '
        'btnCargarEfectivo
        '
        Me.btnCargarEfectivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargarEfectivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargarEfectivo.Location = New System.Drawing.Point(335, 15)
        Me.btnCargarEfectivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCargarEfectivo.Name = "btnCargarEfectivo"
        Me.btnCargarEfectivo.Size = New System.Drawing.Size(84, 36)
        Me.btnCargarEfectivo.TabIndex = 92
        Me.btnCargarEfectivo.Text = "Cargar >>"
        Me.btnCargarEfectivo.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.Color.White
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtMonto.Location = New System.Drawing.Point(152, 17)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(173, 30)
        Me.txtMonto.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 21)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 24)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Ingrese Monto:"
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdCheque)
        Me.grOrdenar.Controls.Add(Me.rdEfectivo)
        Me.grOrdenar.Location = New System.Drawing.Point(332, 12)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Size = New System.Drawing.Size(204, 42)
        Me.grOrdenar.TabIndex = 117
        Me.grOrdenar.TabStop = False
        '
        'rdCheque
        '
        Me.rdCheque.AutoSize = True
        Me.rdCheque.Checked = True
        Me.rdCheque.Location = New System.Drawing.Point(100, 16)
        Me.rdCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdCheque.Name = "rdCheque"
        Me.rdCheque.Size = New System.Drawing.Size(78, 21)
        Me.rdCheque.TabIndex = 18
        Me.rdCheque.TabStop = True
        Me.rdCheque.Text = "Cheque"
        Me.rdCheque.UseVisualStyleBackColor = True
        '
        'rdEfectivo
        '
        Me.rdEfectivo.AutoSize = True
        Me.rdEfectivo.Location = New System.Drawing.Point(11, 16)
        Me.rdEfectivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdEfectivo.Name = "rdEfectivo"
        Me.rdEfectivo.Size = New System.Drawing.Size(79, 21)
        Me.rdEfectivo.TabIndex = 17
        Me.rdEfectivo.Text = "Efectivo"
        Me.rdEfectivo.UseVisualStyleBackColor = True
        '
        'dtgPago
        '
        Me.dtgPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPago.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.Column1, Me.Column2, Me.Column3, Me.cotiza, Me.Column9, Me.Column6, Me.Column4, Me.Column5, Me.Column7})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgPago.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgPago.Location = New System.Drawing.Point(16, 92)
        Me.dtgPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtgPago.Name = "dtgPago"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPago.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgPago.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dtgPago.Size = New System.Drawing.Size(1115, 245)
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
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Cuenta"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 120
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Banco"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.FillWeight = 150.0!
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Nro. Cheque"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'cotiza
        '
        Me.cotiza.Frozen = True
        Me.cotiza.HeaderText = "Vence"
        Me.cotiza.Name = "cotiza"
        Me.cotiza.ReadOnly = True
        Me.cotiza.Width = 80
        '
        'Column9
        '
        Me.Column9.Frozen = True
        Me.Column9.HeaderText = "Importe"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 80
        '
        'Column6
        '
        Me.Column6.Frozen = True
        Me.Column6.HeaderText = "Fecha"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'Column4
        '
        Me.Column4.HeaderText = "Efec."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 40
        '
        'Column5
        '
        Me.Column5.HeaderText = "IdChequera"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 60
        '
        'Column7
        '
        Me.Column7.HeaderText = "idcheque"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 60
        '
        'txtNroRecibo
        '
        Me.txtNroRecibo.BackColor = System.Drawing.Color.White
        Me.txtNroRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroRecibo.ForeColor = System.Drawing.Color.Red
        Me.txtNroRecibo.Location = New System.Drawing.Point(133, 21)
        Me.txtNroRecibo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNroRecibo.Name = "txtNroRecibo"
        Me.txtNroRecibo.Size = New System.Drawing.Size(173, 30)
        Me.txtNroRecibo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nro. Recibo:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnGuardar)
        Me.GroupBox3.Controls.Add(Me.btnCancelar)
        Me.GroupBox3.Controls.Add(Me.btnEliminar)
        Me.GroupBox3.Location = New System.Drawing.Point(691, 6)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(309, 76)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(209, 17)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
        Me.btnGuardar.TabIndex = 94
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(109, 17)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(92, 46)
        Me.btnCancelar.TabIndex = 93
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(9, 18)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(92, 46)
        Me.btnEliminar.TabIndex = 92
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblCheque)
        Me.GroupBox4.Controls.Add(Me.lblIdChequera)
        Me.GroupBox4.Controls.Add(Me.lvCheque)
        Me.GroupBox4.Location = New System.Drawing.Point(25, 463)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(963, 193)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle de Cheques"
        '
        'lblCheque
        '
        Me.lblCheque.AutoSize = True
        Me.lblCheque.ForeColor = System.Drawing.Color.Maroon
        Me.lblCheque.Location = New System.Drawing.Point(857, 57)
        Me.lblCheque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCheque.Name = "lblCheque"
        Me.lblCheque.Size = New System.Drawing.Size(78, 17)
        Me.lblCheque.TabIndex = 6
        Me.lblCheque.Text = "nroCheque"
        '
        'lblIdChequera
        '
        Me.lblIdChequera.AutoSize = True
        Me.lblIdChequera.ForeColor = System.Drawing.Color.Maroon
        Me.lblIdChequera.Location = New System.Drawing.Point(857, 21)
        Me.lblIdChequera.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdChequera.Name = "lblIdChequera"
        Me.lblIdChequera.Size = New System.Drawing.Size(81, 17)
        Me.lblIdChequera.TabIndex = 5
        Me.lblIdChequera.Text = "idChequera"
        '
        'lvCheque
        '
        Me.lvCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvCheque.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nroCheque, Me.cuenta, Me.banco, Me.vence, Me.monto, Me.idChequera})
        Me.lvCheque.FullRowSelect = True
        Me.lvCheque.GridLines = True
        Me.lvCheque.HideSelection = False
        Me.lvCheque.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCheque.LabelWrap = False
        Me.lvCheque.Location = New System.Drawing.Point(13, 21)
        Me.lvCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvCheque.MultiSelect = False
        Me.lvCheque.Name = "lvCheque"
        Me.lvCheque.Size = New System.Drawing.Size(819, 160)
        Me.lvCheque.TabIndex = 4
        Me.lvCheque.UseCompatibleStateImageBehavior = False
        Me.lvCheque.View = System.Windows.Forms.View.Details
        '
        'nroCheque
        '
        Me.nroCheque.Text = "Nro. Cheque"
        Me.nroCheque.Width = 100
        '
        'cuenta
        '
        Me.cuenta.Text = "Cuenta"
        Me.cuenta.Width = 140
        '
        'banco
        '
        Me.banco.Text = "Banco"
        Me.banco.Width = 150
        '
        'vence
        '
        Me.vence.Text = "vence"
        Me.vence.Width = 80
        '
        'monto
        '
        Me.monto.Text = "Monto"
        Me.monto.Width = 80
        '
        'idChequera
        '
        Me.idChequera.Text = "IdCheq."
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.ForeColor = System.Drawing.Color.Black
        Me.txtSql.Location = New System.Drawing.Point(12, 642)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(952, 26)
        Me.txtSql.TabIndex = 119
        Me.txtSql.Visible = False
        '
        'frmGuardarPagoProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 682)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuardarPagoProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardar Pago a Proveedores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grEfectivo.ResumeLayout(False)
        Me.grEfectivo.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        CType(Me.dtgPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalPagar As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNroRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtgPago As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lvCheque As System.Windows.Forms.ListView
    Friend WithEvents nroCheque As System.Windows.Forms.ColumnHeader
    Friend WithEvents cuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents banco As System.Windows.Forms.ColumnHeader
    Friend WithEvents vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents monto As System.Windows.Forms.ColumnHeader
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rdEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblCheque As System.Windows.Forms.Label
    Friend WithEvents lblIdChequera As System.Windows.Forms.Label
    Friend WithEvents idChequera As System.Windows.Forms.ColumnHeader
    Friend WithEvents grEfectivo As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents btnCargarEfectivo As System.Windows.Forms.Button
    Friend WithEvents lblNro As System.Windows.Forms.Label
    Friend WithEvents Column0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cotiza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
End Class
