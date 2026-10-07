<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarFacturaVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarFacturaVenta))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdNoImpreso = New System.Windows.Forms.RadioButton()
        Me.rdImpreso = New System.Windows.Forms.RadioButton()
        Me.txtIdVenta = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdFactura = New System.Windows.Forms.RadioButton()
        Me.rdCliente = New System.Windows.Forms.RadioButton()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lvVenta = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rdObra = New System.Windows.Forms.RadioButton()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.txtSql)
        Me.grBuscar.Controls.Add(Me.GroupBox1)
        Me.grBuscar.Controls.Add(Me.txtIdVenta)
        Me.grBuscar.Controls.Add(Me.txtFactura)
        Me.grBuscar.Controls.Add(Me.txtDcaja)
        Me.grBuscar.Controls.Add(Me.txtDsuc)
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.lvVenta)
        Me.grBuscar.Location = New System.Drawing.Point(13, 11)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Size = New System.Drawing.Size(1284, 571)
        Me.grBuscar.TabIndex = 2
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 68)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(743, 43)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSql.MaxLength = 7
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(524, 22)
        Me.txtSql.TabIndex = 23
        Me.txtSql.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdNoImpreso)
        Me.GroupBox1.Controls.Add(Me.rdImpreso)
        Me.GroupBox1.Location = New System.Drawing.Point(498, 31)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(236, 42)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'rdNoImpreso
        '
        Me.rdNoImpreso.AutoSize = True
        Me.rdNoImpreso.Location = New System.Drawing.Point(112, 16)
        Me.rdNoImpreso.Margin = New System.Windows.Forms.Padding(4)
        Me.rdNoImpreso.Name = "rdNoImpreso"
        Me.rdNoImpreso.Size = New System.Drawing.Size(101, 21)
        Me.rdNoImpreso.TabIndex = 18
        Me.rdNoImpreso.Text = "No Impreso"
        Me.rdNoImpreso.UseVisualStyleBackColor = True
        '
        'rdImpreso
        '
        Me.rdImpreso.AutoSize = True
        Me.rdImpreso.Checked = True
        Me.rdImpreso.Location = New System.Drawing.Point(11, 16)
        Me.rdImpreso.Margin = New System.Windows.Forms.Padding(4)
        Me.rdImpreso.Name = "rdImpreso"
        Me.rdImpreso.Size = New System.Drawing.Size(79, 21)
        Me.rdImpreso.TabIndex = 17
        Me.rdImpreso.TabStop = True
        Me.rdImpreso.Text = "Impreso"
        Me.rdImpreso.UseVisualStyleBackColor = True
        '
        'txtIdVenta
        '
        Me.txtIdVenta.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdVenta.Enabled = False
        Me.txtIdVenta.Location = New System.Drawing.Point(734, 14)
        Me.txtIdVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdVenta.MaxLength = 3
        Me.txtIdVenta.Name = "txtIdVenta"
        Me.txtIdVenta.Size = New System.Drawing.Size(72, 22)
        Me.txtIdVenta.TabIndex = 22
        '
        'txtFactura
        '
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Location = New System.Drawing.Point(196, 80)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFactura.MaxLength = 7
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(103, 22)
        Me.txtFactura.TabIndex = 3
        '
        'txtDcaja
        '
        Me.txtDcaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDcaja.Location = New System.Drawing.Point(133, 80)
        Me.txtDcaja.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDcaja.MaxLength = 3
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(53, 22)
        Me.txtDcaja.TabIndex = 2
        '
        'txtDsuc
        '
        Me.txtDsuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDsuc.Location = New System.Drawing.Point(71, 80)
        Me.txtDsuc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDsuc.MaxLength = 3
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(53, 22)
        Me.txtDsuc.TabIndex = 1
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdObra)
        Me.grOrdenar.Controls.Add(Me.rdFactura)
        Me.grOrdenar.Controls.Add(Me.rdCliente)
        Me.grOrdenar.Location = New System.Drawing.Point(85, 14)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Size = New System.Drawing.Size(391, 55)
        Me.grOrdenar.TabIndex = 18
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdFactura
        '
        Me.rdFactura.AutoSize = True
        Me.rdFactura.Checked = True
        Me.rdFactura.Location = New System.Drawing.Point(171, 21)
        Me.rdFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.rdFactura.Name = "rdFactura"
        Me.rdFactura.Size = New System.Drawing.Size(77, 21)
        Me.rdFactura.TabIndex = 18
        Me.rdFactura.Text = "Factura"
        Me.rdFactura.UseVisualStyleBackColor = True
        '
        'rdCliente
        '
        Me.rdCliente.AutoSize = True
        Me.rdCliente.Location = New System.Drawing.Point(11, 21)
        Me.rdCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCliente.Name = "rdCliente"
        Me.rdCliente.Size = New System.Drawing.Size(138, 21)
        Me.rdCliente.TabIndex = 17
        Me.rdCliente.Text = "Cliente e IDVenta"
        Me.rdCliente.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(71, 80)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(213, 22)
        Me.txtBuscar.TabIndex = 0
        Me.txtBuscar.Visible = False
        '
        'lvVenta
        '
        Me.lvVenta.AllowColumnReorder = True
        Me.lvVenta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvVenta.FullRowSelect = True
        Me.lvVenta.GridLines = True
        Me.lvVenta.HideSelection = False
        Me.lvVenta.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvVenta.LabelWrap = False
        Me.lvVenta.Location = New System.Drawing.Point(8, 121)
        Me.lvVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.lvVenta.MultiSelect = False
        Me.lvVenta.Name = "lvVenta"
        Me.lvVenta.Size = New System.Drawing.Size(1259, 438)
        Me.lvVenta.TabIndex = 4
        Me.lvVenta.UseCompatibleStateImageBehavior = False
        Me.lvVenta.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IDCompra"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DSuc."
        Me.ColumnHeader2.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DCaja"
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Factura"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cliente"
        Me.ColumnHeader5.Width = 300
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Total"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fecha"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Sucursal"
        Me.ColumnHeader8.Width = 200
        '
        'rdObra
        '
        Me.rdObra.AutoSize = True
        Me.rdObra.Location = New System.Drawing.Point(256, 21)
        Me.rdObra.Margin = New System.Windows.Forms.Padding(4)
        Me.rdObra.Name = "rdObra"
        Me.rdObra.Size = New System.Drawing.Size(77, 21)
        Me.rdObra.TabIndex = 19
        Me.rdObra.Text = "Factura"
        Me.rdObra.UseVisualStyleBackColor = True
        '
        'frmBuscarFacturaVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1307, 592)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarFacturaVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Facturas de Venta"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdFactura As System.Windows.Forms.RadioButton
    Friend WithEvents rdCliente As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lvVenta As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdNoImpreso As System.Windows.Forms.RadioButton
    Friend WithEvents rdImpreso As System.Windows.Forms.RadioButton
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rdObra As System.Windows.Forms.RadioButton
End Class
