<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductoDevolucionCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductoDevolucionCompra))
        Me.saldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto = New System.Windows.Forms.ListView()
        Me.idStock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdDev = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'saldo
        '
        Me.saldo.Text = "Saldo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 24)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ID Dev.:"
        '
        'cantidad
        '
        Me.cantidad.Text = "Cant."
        '
        'mercaderia
        '
        Me.mercaderia.Text = "Nombre del Producto"
        Me.mercaderia.Width = 300
        '
        'codigo
        '
        Me.codigo.Text = "Codigo"
        '
        'lvProducto
        '
        Me.lvProducto.AllowColumnReorder = True
        Me.lvProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.codigo, Me.mercaderia, Me.cantidad, Me.saldo, Me.idStock})
        Me.lvProducto.FullRowSelect = True
        Me.lvProducto.GridLines = True
        Me.lvProducto.HideSelection = False
        Me.lvProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvProducto.LabelWrap = False
        Me.lvProducto.Location = New System.Drawing.Point(32, 72)
        Me.lvProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.lvProducto.MultiSelect = False
        Me.lvProducto.Name = "lvProducto"
        Me.lvProducto.Size = New System.Drawing.Size(843, 488)
        Me.lvProducto.TabIndex = 12
        Me.lvProducto.UseCompatibleStateImageBehavior = False
        Me.lvProducto.View = System.Windows.Forms.View.Details
        '
        'idStock
        '
        Me.idStock.Text = "IdStock"
        '
        'txtIdDev
        '
        Me.txtIdDev.BackColor = System.Drawing.Color.Lime
        Me.txtIdDev.Enabled = False
        Me.txtIdDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdDev.Location = New System.Drawing.Point(119, 13)
        Me.txtIdDev.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdDev.Name = "txtIdDev"
        Me.txtIdDev.Size = New System.Drawing.Size(100, 29)
        Me.txtIdDev.TabIndex = 11
        '
        'frmProductoDevolucionCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 604)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvProducto)
        Me.Controls.Add(Me.txtIdDev)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProductoDevolucionCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Productos devueltos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents saldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto As System.Windows.Forms.ListView
    Friend WithEvents idStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdDev As System.Windows.Forms.TextBox
End Class
