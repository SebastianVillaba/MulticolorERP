<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeguimientoStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeguimientoStock))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSaldoStock = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtStockCon = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStockSuc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStockTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMercaderia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVence = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkBuscarDeposito = New System.Windows.Forms.CheckBox()
        Me.txtNombreDeposito = New System.Windows.Forms.TextBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdVence = New System.Windows.Forms.RadioButton()
        Me.rdMercaderia = New System.Windows.Forms.RadioButton()
        Me.lvSeguimiento = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grEsperar = New System.Windows.Forms.GroupBox()
        Me.lblEsperar = New System.Windows.Forms.Label()
        Me.txtTotalSalida = New System.Windows.Forms.TextBox()
        Me.txtTotalEntrada = New System.Windows.Forms.TextBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.txtIdDeposito = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblNombrePlato = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grEsperar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSaldoStock)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtStockCon)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtStockSuc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtStockTotal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMercaderia)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtLote)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtVence)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la Mercadería"
        '
        'txtSaldoStock
        '
        Me.txtSaldoStock.BackColor = System.Drawing.Color.Pink
        Me.txtSaldoStock.Enabled = False
        Me.txtSaldoStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoStock.Location = New System.Drawing.Point(401, 71)
        Me.txtSaldoStock.Name = "txtSaldoStock"
        Me.txtSaldoStock.Size = New System.Drawing.Size(76, 24)
        Me.txtSaldoStock.TabIndex = 97
        Me.txtSaldoStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(407, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "Saldo Inicial"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(271, 72)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(108, 22)
        Me.dtpDesdeFecha.TabIndex = 95
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(287, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Desde Fecha"
        '
        'txtStockCon
        '
        Me.txtStockCon.BackColor = System.Drawing.Color.LawnGreen
        Me.txtStockCon.Enabled = False
        Me.txtStockCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockCon.Location = New System.Drawing.Point(190, 71)
        Me.txtStockCon.Name = "txtStockCon"
        Me.txtStockCon.Size = New System.Drawing.Size(76, 24)
        Me.txtStockCon.TabIndex = 40
        Me.txtStockCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(182, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Stock Consultado"
        '
        'txtStockSuc
        '
        Me.txtStockSuc.BackColor = System.Drawing.Color.Gold
        Me.txtStockSuc.Enabled = False
        Me.txtStockSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockSuc.Location = New System.Drawing.Point(97, 71)
        Me.txtStockSuc.Name = "txtStockSuc"
        Me.txtStockSuc.Size = New System.Drawing.Size(76, 24)
        Me.txtStockSuc.TabIndex = 38
        Me.txtStockSuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(102, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Stock x Suc."
        '
        'txtStockTotal
        '
        Me.txtStockTotal.BackColor = System.Drawing.Color.Gold
        Me.txtStockTotal.Enabled = False
        Me.txtStockTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockTotal.Location = New System.Drawing.Point(14, 71)
        Me.txtStockTotal.Name = "txtStockTotal"
        Me.txtStockTotal.Size = New System.Drawing.Size(76, 24)
        Me.txtStockTotal.TabIndex = 36
        Me.txtStockTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Total Stock"
        '
        'txtMercaderia
        '
        Me.txtMercaderia.BackColor = System.Drawing.Color.LightBlue
        Me.txtMercaderia.Enabled = False
        Me.txtMercaderia.Location = New System.Drawing.Point(271, 30)
        Me.txtMercaderia.Name = "txtMercaderia"
        Me.txtMercaderia.Size = New System.Drawing.Size(288, 20)
        Me.txtMercaderia.TabIndex = 34
        Me.txtMercaderia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(359, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Mercadería"
        '
        'txtLote
        '
        Me.txtLote.BackColor = System.Drawing.Color.LightBlue
        Me.txtLote.Enabled = False
        Me.txtLote.Location = New System.Drawing.Point(185, 30)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(80, 20)
        Me.txtLote.TabIndex = 32
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(208, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Lote"
        '
        'txtVence
        '
        Me.txtVence.BackColor = System.Drawing.Color.LightBlue
        Me.txtVence.Enabled = False
        Me.txtVence.Location = New System.Drawing.Point(96, 30)
        Me.txtVence.Name = "txtVence"
        Me.txtVence.Size = New System.Drawing.Size(80, 20)
        Me.txtVence.TabIndex = 30
        Me.txtVence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Vence"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.LightBlue
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(9, 30)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(80, 20)
        Me.txtCodigo.TabIndex = 28
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(27, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Codigo"
        '
        'chkBuscarDeposito
        '
        Me.chkBuscarDeposito.AutoSize = True
        Me.chkBuscarDeposito.Checked = True
        Me.chkBuscarDeposito.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBuscarDeposito.Location = New System.Drawing.Point(588, 23)
        Me.chkBuscarDeposito.Name = "chkBuscarDeposito"
        Me.chkBuscarDeposito.Size = New System.Drawing.Size(122, 17)
        Me.chkBuscarDeposito.TabIndex = 1
        Me.chkBuscarDeposito.Text = "Buscar por &Depósito"
        Me.chkBuscarDeposito.UseVisualStyleBackColor = True
        '
        'txtNombreDeposito
        '
        Me.txtNombreDeposito.BackColor = System.Drawing.Color.LightBlue
        Me.txtNombreDeposito.Enabled = False
        Me.txtNombreDeposito.Location = New System.Drawing.Point(585, 41)
        Me.txtNombreDeposito.Name = "txtNombreDeposito"
        Me.txtNombreDeposito.Size = New System.Drawing.Size(259, 20)
        Me.txtNombreDeposito.TabIndex = 33
        Me.txtNombreDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdVence)
        Me.grOrdenar.Controls.Add(Me.rdMercaderia)
        Me.grOrdenar.Location = New System.Drawing.Point(585, 67)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(221, 34)
        Me.grOrdenar.TabIndex = 34
        Me.grOrdenar.TabStop = False
        '
        'rdVence
        '
        Me.rdVence.AutoSize = True
        Me.rdVence.Location = New System.Drawing.Point(114, 13)
        Me.rdVence.Name = "rdVence"
        Me.rdVence.Size = New System.Drawing.Size(102, 17)
        Me.rdVence.TabIndex = 18
        Me.rdVence.Text = "Por Vencimiento"
        Me.rdVence.UseVisualStyleBackColor = True
        '
        'rdMercaderia
        '
        Me.rdMercaderia.AutoSize = True
        Me.rdMercaderia.Checked = True
        Me.rdMercaderia.Location = New System.Drawing.Point(8, 13)
        Me.rdMercaderia.Name = "rdMercaderia"
        Me.rdMercaderia.Size = New System.Drawing.Size(99, 17)
        Me.rdMercaderia.TabIndex = 17
        Me.rdMercaderia.TabStop = True
        Me.rdMercaderia.Text = "Por Mercadería"
        Me.rdMercaderia.UseVisualStyleBackColor = True
        '
        'lvSeguimiento
        '
        Me.lvSeguimiento.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader12, Me.ColumnHeader11, Me.ColumnHeader13})
        Me.lvSeguimiento.Location = New System.Drawing.Point(7, 118)
        Me.lvSeguimiento.Name = "lvSeguimiento"
        Me.lvSeguimiento.Size = New System.Drawing.Size(938, 336)
        Me.lvSeguimiento.TabIndex = 35
        Me.lvSeguimiento.UseCompatibleStateImageBehavior = False
        Me.lvSeguimiento.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nro"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nro.Mov."
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha/Hora"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 140
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Entrada"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Salida"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Saldo"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Tipo"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Vence"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Lote"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 90
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "IdAud."
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Deposito"
        Me.ColumnHeader12.Width = 170
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Responsable"
        Me.ColumnHeader11.Width = 300
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "NI"
        Me.ColumnHeader13.Width = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnImprimir)
        Me.GroupBox2.Controls.Add(Me.btnProcesar)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Location = New System.Drawing.Point(551, 455)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 56)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(166, 10)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(91, 10)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(69, 37)
        Me.btnProcesar.TabIndex = 4
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(16, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'grEsperar
        '
        Me.grEsperar.Controls.Add(Me.lblEsperar)
        Me.grEsperar.Location = New System.Drawing.Point(635, 2)
        Me.grEsperar.Name = "grEsperar"
        Me.grEsperar.Size = New System.Drawing.Size(203, 39)
        Me.grEsperar.TabIndex = 35
        Me.grEsperar.TabStop = False
        Me.grEsperar.Visible = False
        '
        'lblEsperar
        '
        Me.lblEsperar.AutoSize = True
        Me.lblEsperar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEsperar.Location = New System.Drawing.Point(5, 13)
        Me.lblEsperar.Name = "lblEsperar"
        Me.lblEsperar.Size = New System.Drawing.Size(189, 20)
        Me.lblEsperar.TabIndex = 38
        Me.lblEsperar.Text = "Por Favor Esperar......."
        '
        'txtTotalSalida
        '
        Me.txtTotalSalida.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtTotalSalida.Enabled = False
        Me.txtTotalSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSalida.Location = New System.Drawing.Point(310, 460)
        Me.txtTotalSalida.Name = "txtTotalSalida"
        Me.txtTotalSalida.Size = New System.Drawing.Size(80, 21)
        Me.txtTotalSalida.TabIndex = 42
        Me.txtTotalSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalEntrada
        '
        Me.txtTotalEntrada.BackColor = System.Drawing.Color.LightGreen
        Me.txtTotalEntrada.Enabled = False
        Me.txtTotalEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEntrada.Location = New System.Drawing.Point(223, 460)
        Me.txtTotalEntrada.Name = "txtTotalEntrada"
        Me.txtTotalEntrada.Size = New System.Drawing.Size(80, 21)
        Me.txtTotalEntrada.TabIndex = 41
        Me.txtTotalEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSql
        '
        Me.txtSql.Location = New System.Drawing.Point(21, 515)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(524, 20)
        Me.txtSql.TabIndex = 43
        Me.txtSql.Visible = False
        '
        'txtIdDeposito
        '
        Me.txtIdDeposito.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdDeposito.Enabled = False
        Me.txtIdDeposito.Location = New System.Drawing.Point(850, 41)
        Me.txtIdDeposito.Name = "txtIdDeposito"
        Me.txtIdDeposito.Size = New System.Drawing.Size(50, 20)
        Me.txtIdDeposito.TabIndex = 44
        Me.txtIdDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 488)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 16)
        Me.Label9.TabIndex = 98
        Me.Label9.Text = "Plato:"
        '
        'lblNombrePlato
        '
        Me.lblNombrePlato.AutoSize = True
        Me.lblNombrePlato.BackColor = System.Drawing.Color.Yellow
        Me.lblNombrePlato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePlato.Location = New System.Drawing.Point(59, 489)
        Me.lblNombrePlato.Name = "lblNombrePlato"
        Me.lblNombrePlato.Size = New System.Drawing.Size(143, 16)
        Me.lblNombrePlato.TabIndex = 99
        Me.lblNombrePlato.Text = "NOMBRE DEL PLATO"
        '
        'frmSeguimientoStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 546)
        Me.Controls.Add(Me.lblNombrePlato)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtIdDeposito)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.txtTotalSalida)
        Me.Controls.Add(Me.grEsperar)
        Me.Controls.Add(Me.txtTotalEntrada)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lvSeguimiento)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.txtNombreDeposito)
        Me.Controls.Add(Me.chkBuscarDeposito)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeguimientoStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguimiento Stock"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grEsperar.ResumeLayout(False)
        Me.grEsperar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMercaderia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLote As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVence As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkBuscarDeposito As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombreDeposito As System.Windows.Forms.TextBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdVence As System.Windows.Forms.RadioButton
    Friend WithEvents rdMercaderia As System.Windows.Forms.RadioButton
    Friend WithEvents lvSeguimiento As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grEsperar As System.Windows.Forms.GroupBox
    Friend WithEvents lblEsperar As System.Windows.Forms.Label
    Friend WithEvents txtStockCon As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStockSuc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStockTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSalida As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalEntrada As System.Windows.Forms.TextBox
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdDeposito As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSaldoStock As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblNombrePlato As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
