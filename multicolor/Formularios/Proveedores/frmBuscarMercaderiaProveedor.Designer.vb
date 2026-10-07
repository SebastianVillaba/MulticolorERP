<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarMercaderiaProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarMercaderiaProveedor))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.lvProducto = New System.Windows.Forms.ListView()
        Me.lvProducto_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_costo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_idCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_nroFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProducto_idStock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdProveedor = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 47)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 113
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Proveedor:"
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(62, 57)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(281, 20)
        Me.txtBuscar.TabIndex = 114
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(139, 9)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(342, 21)
        Me.txtProveedor.TabIndex = 112
        '
        'lvProducto
        '
        Me.lvProducto.AllowColumnReorder = True
        Me.lvProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvProducto_codigo, Me.lvProducto_mercaderia, Me.lvProducto_costo, Me.lvProducto_idCompra, Me.lvProducto_nroFactura, Me.lvProducto_fecha, Me.lvProducto_idStock})
        Me.lvProducto.FullRowSelect = True
        Me.lvProducto.GridLines = True
        Me.lvProducto.HideSelection = False
        Me.lvProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvProducto.LabelWrap = False
        Me.lvProducto.Location = New System.Drawing.Point(8, 92)
        Me.lvProducto.MultiSelect = False
        Me.lvProducto.Name = "lvProducto"
        Me.lvProducto.Size = New System.Drawing.Size(798, 340)
        Me.lvProducto.TabIndex = 115
        Me.lvProducto.UseCompatibleStateImageBehavior = False
        Me.lvProducto.View = System.Windows.Forms.View.Details
        '
        'lvProducto_codigo
        '
        Me.lvProducto_codigo.Text = "Codigo"
        '
        'lvProducto_mercaderia
        '
        Me.lvProducto_mercaderia.Text = "Mercaderia"
        Me.lvProducto_mercaderia.Width = 350
        '
        'lvProducto_costo
        '
        Me.lvProducto_costo.Text = "Costo"
        Me.lvProducto_costo.Width = 80
        '
        'lvProducto_idCompra
        '
        Me.lvProducto_idCompra.Text = "Nro.Mov."
        '
        'lvProducto_nroFactura
        '
        Me.lvProducto_nroFactura.Text = "Factura"
        Me.lvProducto_nroFactura.Width = 100
        '
        'lvProducto_fecha
        '
        Me.lvProducto_fecha.Text = "Fecha"
        Me.lvProducto_fecha.Width = 80
        '
        'lvProducto_idStock
        '
        Me.lvProducto_idStock.Text = "IdStock"
        '
        'txtIdProveedor
        '
        Me.txtIdProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdProveedor.Enabled = False
        Me.txtIdProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProveedor.Location = New System.Drawing.Point(81, 9)
        Me.txtIdProveedor.Name = "txtIdProveedor"
        Me.txtIdProveedor.Size = New System.Drawing.Size(52, 21)
        Me.txtIdProveedor.TabIndex = 116
        '
        'frmBuscarMercaderiaProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 470)
        Me.Controls.Add(Me.txtIdProveedor)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.lvProducto)
        Me.Name = "frmBuscarMercaderiaProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Mercadería del Proveedor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lvProducto As System.Windows.Forms.ListView
    Friend WithEvents lvProducto_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_costo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_idStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lvProducto_idCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_nroFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducto_fecha As System.Windows.Forms.ColumnHeader
End Class
