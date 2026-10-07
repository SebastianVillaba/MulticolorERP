<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaStock))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLaboratorio = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lvStockDeposito = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.lvStockSucursal = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lvStock = New System.Windows.Forms.ListView()
        Me.idProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.presentacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grBuscar.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.txtSql)
        Me.grBuscar.Controls.Add(Me.lblOrigen)
        Me.grBuscar.Controls.Add(Me.Label7)
        Me.grBuscar.Controls.Add(Me.Label5)
        Me.grBuscar.Controls.Add(Me.Label3)
        Me.grBuscar.Controls.Add(Me.lblDivision)
        Me.grBuscar.Controls.Add(Me.Label4)
        Me.grBuscar.Controls.Add(Me.lblLaboratorio)
        Me.grBuscar.Controls.Add(Me.Label2)
        Me.grBuscar.Controls.Add(Me.picImagen)
        Me.grBuscar.Controls.Add(Me.Label1)
        Me.grBuscar.Controls.Add(Me.GroupBox1)
        Me.grBuscar.Controls.Add(Me.txtIdProducto)
        Me.grBuscar.Controls.Add(Me.lvStockSucursal)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.lvStock)
        Me.grBuscar.Location = New System.Drawing.Point(8, 1)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(980, 558)
        Me.grBuscar.TabIndex = 2
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(9, 532)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(537, 20)
        Me.txtSql.TabIndex = 121
        Me.txtSql.Visible = False
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.BackColor = System.Drawing.Color.Yellow
        Me.lblOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrigen.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblOrigen.Location = New System.Drawing.Point(771, 33)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(73, 18)
        Me.lblOrigen.TabIndex = 120
        Me.lblOrigen.Text = "ORIGEN"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(714, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Origen:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label5.Location = New System.Drawing.Point(217, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 13)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "Mercaderías  de Uso Controlado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(56, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Mercaderías Fuera de Línea"
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.lblDivision.Location = New System.Drawing.Point(504, 34)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(65, 18)
        Me.lblDivision.TabIndex = 117
        Me.lblDivision.Text = "division"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(444, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Division:"
        '
        'lblLaboratorio
        '
        Me.lblLaboratorio.AutoSize = True
        Me.lblLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaboratorio.ForeColor = System.Drawing.Color.MediumSlateBlue
        Me.lblLaboratorio.Location = New System.Drawing.Point(504, 10)
        Me.lblLaboratorio.Name = "lblLaboratorio"
        Me.lblLaboratorio.Size = New System.Drawing.Size(90, 18)
        Me.lblLaboratorio.TabIndex = 115
        Me.lblLaboratorio.Text = "laboratorio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(425, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Laboratorio:"
        '
        'picImagen
        '
        Me.picImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImagen.Location = New System.Drawing.Point(695, 55)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(264, 243)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 113
        Me.picImagen.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 329)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Sucursales"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lvStockDeposito)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(559, 351)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 188)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cantidad en Depositos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(8, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Deposito de Canje"
        '
        'lvStockDeposito
        '
        Me.lvStockDeposito.AllowColumnReorder = True
        Me.lvStockDeposito.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvStockDeposito.FullRowSelect = True
        Me.lvStockDeposito.GridLines = True
        Me.lvStockDeposito.HideSelection = False
        Me.lvStockDeposito.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvStockDeposito.LabelWrap = False
        Me.lvStockDeposito.Location = New System.Drawing.Point(12, 18)
        Me.lvStockDeposito.MultiSelect = False
        Me.lvStockDeposito.Name = "lvStockDeposito"
        Me.lvStockDeposito.Size = New System.Drawing.Size(401, 151)
        Me.lvStockDeposito.TabIndex = 3
        Me.lvStockDeposito.UseCompatibleStateImageBehavior = False
        Me.lvStockDeposito.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ID"
        Me.ColumnHeader5.Width = 30
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Deposito"
        Me.ColumnHeader9.Width = 170
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Cant,"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Lote"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Vence"
        Me.ColumnHeader7.Width = 50
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Canj"
        Me.ColumnHeader8.Width = 30
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(350, 17)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(50, 20)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Visible = False
        '
        'txtIdProducto
        '
        Me.txtIdProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProducto.Enabled = False
        Me.txtIdProducto.Location = New System.Drawing.Point(354, 19)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(50, 20)
        Me.txtIdProducto.TabIndex = 5
        '
        'lvStockSucursal
        '
        Me.lvStockSucursal.AllowColumnReorder = True
        Me.lvStockSucursal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvStockSucursal.FullRowSelect = True
        Me.lvStockSucursal.GridLines = True
        Me.lvStockSucursal.HideSelection = False
        Me.lvStockSucursal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvStockSucursal.LabelWrap = False
        Me.lvStockSucursal.Location = New System.Drawing.Point(11, 352)
        Me.lvStockSucursal.MultiSelect = False
        Me.lvStockSucursal.Name = "lvStockSucursal"
        Me.lvStockSucursal.Size = New System.Drawing.Size(535, 177)
        Me.lvStockSucursal.TabIndex = 4
        Me.lvStockSucursal.UseCompatibleStateImageBehavior = False
        Me.lvStockSucursal.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IDSucursal"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Sucursal"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Deposito"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Stock"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(56, 16)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(281, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'lvStock
        '
        Me.lvStock.AllowColumnReorder = True
        Me.lvStock.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idProducto, Me.codigo, Me.mercaderia, Me.presentacion, Me.precio, Me.cantidad})
        Me.lvStock.FullRowSelect = True
        Me.lvStock.GridLines = True
        Me.lvStock.HideSelection = False
        Me.lvStock.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvStock.LabelWrap = False
        Me.lvStock.Location = New System.Drawing.Point(6, 55)
        Me.lvStock.MultiSelect = False
        Me.lvStock.Name = "lvStock"
        Me.lvStock.Size = New System.Drawing.Size(670, 271)
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
        '
        'mercaderia
        '
        Me.mercaderia.Text = "Nombre del Producto"
        Me.mercaderia.Width = 300
        '
        'presentacion
        '
        Me.presentacion.Text = "Presentacion"
        Me.presentacion.Width = 150
        '
        'precio
        '
        Me.precio.Text = "Precio"
        Me.precio.Width = 80
        '
        'cantidad
        '
        Me.cantidad.Text = "Stock"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        '
        'frmConsultaStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 565)
        Me.Controls.Add(Me.grBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Stock"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvStockDeposito As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents lvStockSucursal As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lvStock As System.Windows.Forms.ListView
    Friend WithEvents idProducto As System.Windows.Forms.ColumnHeader
    Friend WithEvents codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents presentacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblLaboratorio As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
