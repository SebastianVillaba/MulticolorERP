<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaRemisionProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaRemisionProveedor))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvCargo = New System.Windows.Forms.ListView()
        Me.lvProducto = New System.Windows.Forms.ListView()
        Me.lvProducto_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_saldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkPendiente = New System.Windows.Forms.CheckBox()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvCargo)
        Me.grBuscar.Location = New System.Drawing.Point(19, 22)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Size = New System.Drawing.Size(376, 466)
        Me.grBuscar.TabIndex = 38
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(71, 34)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(213, 22)
        Me.txtBuscar.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 22)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lvCargo
        '
        Me.lvCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvCargo.FullRowSelect = True
        Me.lvCargo.GridLines = True
        Me.lvCargo.HideSelection = False
        Me.lvCargo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCargo.LabelWrap = False
        Me.lvCargo.Location = New System.Drawing.Point(8, 70)
        Me.lvCargo.Margin = New System.Windows.Forms.Padding(4)
        Me.lvCargo.MultiSelect = False
        Me.lvCargo.Name = "lvCargo"
        Me.lvCargo.Size = New System.Drawing.Size(355, 376)
        Me.lvCargo.TabIndex = 3
        Me.lvCargo.UseCompatibleStateImageBehavior = False
        Me.lvCargo.View = System.Windows.Forms.View.Details
        '
        'lvProducto
        '
        Me.lvProducto.AllowColumnReorder = True
        Me.lvProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvProducto_nro, Me.lvProducto_codigo, Me.lvProducto_mercaderia, Me.lvProducto_cantidad, Me.lvProducto_saldo})
        Me.lvProducto.FullRowSelect = True
        Me.lvProducto.GridLines = True
        Me.lvProducto.HideSelection = False
        Me.lvProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvProducto.LabelWrap = False
        Me.lvProducto.Location = New System.Drawing.Point(422, 44)
        Me.lvProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.lvProducto.MultiSelect = False
        Me.lvProducto.Name = "lvProducto"
        Me.lvProducto.Size = New System.Drawing.Size(685, 620)
        Me.lvProducto.TabIndex = 116
        Me.lvProducto.UseCompatibleStateImageBehavior = False
        Me.lvProducto.View = System.Windows.Forms.View.Details
        '
        'lvProducto_nro
        '
        Me.lvProducto_nro.Text = "Nro."
        Me.lvProducto_nro.Width = 40
        '
        'lvProducto_codigo
        '
        Me.lvProducto_codigo.Text = "Codigo"
        '
        'lvProducto_mercaderia
        '
        Me.lvProducto_mercaderia.Text = "Nombre del Producto"
        Me.lvProducto_mercaderia.Width = 300
        '
        'lvProducto_cantidad
        '
        Me.lvProducto_cantidad.Text = "Cant."
        '
        'lvProducto_saldo
        '
        Me.lvProducto_saldo.Text = "Saldo"
        '
        'chkPendiente
        '
        Me.chkPendiente.AutoSize = True
        Me.chkPendiente.BackColor = System.Drawing.SystemColors.Control
        Me.chkPendiente.Enabled = False
        Me.chkPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPendiente.Location = New System.Drawing.Point(422, 10)
        Me.chkPendiente.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPendiente.Name = "chkPendiente"
        Me.chkPendiente.Size = New System.Drawing.Size(105, 24)
        Me.chkPendiente.TabIndex = 117
        Me.chkPendiente.Text = "Pendiente"
        Me.chkPendiente.UseVisualStyleBackColor = False
        '
        'frmConsultaRemisionProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1160, 677)
        Me.Controls.Add(Me.chkPendiente)
        Me.Controls.Add(Me.lvProducto)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaRemisionProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Remisiones de Proveedores"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvCargo As System.Windows.Forms.ListView
    Friend WithEvents lvProducto As System.Windows.Forms.ListView
    Friend WithEvents lvProducto_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_saldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkPendiente As System.Windows.Forms.CheckBox
End Class
