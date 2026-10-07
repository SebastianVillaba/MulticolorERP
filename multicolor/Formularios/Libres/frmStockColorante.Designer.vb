<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockColorante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockColorante))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.lvStock = New System.Windows.Forms.ListView()
        Me.idProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.presentacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.referencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nombreTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.lvStock)
        Me.grBuscar.Controls.Add(Me.txtIdProducto)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Location = New System.Drawing.Point(15, 15)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Size = New System.Drawing.Size(1263, 668)
        Me.grBuscar.TabIndex = 3
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'lvStock
        '
        Me.lvStock.AllowColumnReorder = True
        Me.lvStock.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idProducto, Me.codigo, Me.mercaderia, Me.presentacion, Me.referencia, Me.precio, Me.nombreTipo, Me.cantidad})
        Me.lvStock.FullRowSelect = True
        Me.lvStock.GridLines = True
        Me.lvStock.HideSelection = False
        Me.lvStock.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvStock.LabelWrap = False
        Me.lvStock.Location = New System.Drawing.Point(8, 101)
        Me.lvStock.Margin = New System.Windows.Forms.Padding(4)
        Me.lvStock.MultiSelect = False
        Me.lvStock.Name = "lvStock"
        Me.lvStock.Size = New System.Drawing.Size(1229, 540)
        Me.lvStock.TabIndex = 3
        Me.lvStock.UseCompatibleStateImageBehavior = False
        Me.lvStock.View = System.Windows.Forms.View.Details
        '
        'idProducto
        '
        Me.idProducto.Text = "IdProducto"
        Me.idProducto.Width = 70
        '
        'codigo
        '
        Me.codigo.Text = "Codigo"
        Me.codigo.Width = 75
        '
        'mercaderia
        '
        Me.mercaderia.Text = "Nombre del Producto"
        Me.mercaderia.Width = 300
        '
        'presentacion
        '
        Me.presentacion.Text = "Presentacion"
        Me.presentacion.Width = 115
        '
        'referencia
        '
        Me.referencia.Text = "Cod. Ref."
        Me.referencia.Width = 100
        '
        'precio
        '
        Me.precio.Text = "Precio"
        Me.precio.Width = 70
        '
        'nombreTipo
        '
        Me.nombreTipo.Text = "Tipo"
        Me.nombreTipo.Width = 150
        '
        'cantidad
        '
        Me.cantidad.Text = "Stock"
        Me.cantidad.Width = 90
        '
        'txtIdProducto
        '
        Me.txtIdProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProducto.Enabled = False
        Me.txtIdProducto.Location = New System.Drawing.Point(434, 41)
        Me.txtIdProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(65, 22)
        Me.txtIdProducto.TabIndex = 5
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(89, 42)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(336, 22)
        Me.txtBuscar.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(26, 37)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'frmStockColorante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1301, 708)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStockColorante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock - Colorantes"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents lvStock As System.Windows.Forms.ListView
    Friend WithEvents idProducto As System.Windows.Forms.ColumnHeader
    Friend WithEvents codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents presentacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents referencia As System.Windows.Forms.ColumnHeader
    Friend WithEvents precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombreTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
