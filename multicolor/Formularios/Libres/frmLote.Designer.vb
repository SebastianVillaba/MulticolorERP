<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLote
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
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.lvStockSucursal = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grLote = New System.Windows.Forms.GroupBox()
        Me.lvVenceSucursal = New System.Windows.Forms.ListView()
        Me.detVence_deposito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVence_lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVence_vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVence_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVence_comision = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVence_canje = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        Me.grLote.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtCantidad)
        Me.grBuscar.Controls.Add(Me.lvStockSucursal)
        Me.grBuscar.Controls.Add(Me.txtProducto)
        Me.grBuscar.Location = New System.Drawing.Point(5, 43)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(653, 238)
        Me.grBuscar.TabIndex = 3
        Me.grBuscar.TabStop = False
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Enabled = False
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(11, 18)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(48, 22)
        Me.txtCantidad.TabIndex = 6
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvStockSucursal
        '
        Me.lvStockSucursal.AllowColumnReorder = True
        Me.lvStockSucursal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader7, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvStockSucursal.FullRowSelect = True
        Me.lvStockSucursal.GridLines = True
        Me.lvStockSucursal.HideSelection = False
        Me.lvStockSucursal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvStockSucursal.LabelWrap = False
        Me.lvStockSucursal.Location = New System.Drawing.Point(5, 47)
        Me.lvStockSucursal.MultiSelect = False
        Me.lvStockSucursal.Name = "lvStockSucursal"
        Me.lvStockSucursal.Size = New System.Drawing.Size(619, 176)
        Me.lvStockSucursal.TabIndex = 5
        Me.lvStockSucursal.UseCompatibleStateImageBehavior = False
        Me.lvStockSucursal.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Lote"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Vence"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Stock"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Deposito"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Premio"
        Me.ColumnHeader7.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "IdStock"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "IdDeposito"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(75, 19)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(440, 22)
        Me.txtProducto.TabIndex = 2
        Me.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(7, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(282, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Mercaderías  con Premio en Canje"
        '
        'grLote
        '
        Me.grLote.Controls.Add(Me.lvVenceSucursal)
        Me.grLote.Controls.Add(Me.TextBox2)
        Me.grLote.Location = New System.Drawing.Point(8, 286)
        Me.grLote.Name = "grLote"
        Me.grLote.Size = New System.Drawing.Size(415, 190)
        Me.grLote.TabIndex = 14
        Me.grLote.TabStop = False
        Me.grLote.Text = "Vencimientos de Sucursales"
        '
        'lvVenceSucursal
        '
        Me.lvVenceSucursal.AllowColumnReorder = True
        Me.lvVenceSucursal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detVence_deposito, Me.detVence_lote, Me.detVence_vence, Me.detVence_cantidad, Me.detVence_comision, Me.detVence_canje})
        Me.lvVenceSucursal.FullRowSelect = True
        Me.lvVenceSucursal.GridLines = True
        Me.lvVenceSucursal.HideSelection = False
        Me.lvVenceSucursal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvVenceSucursal.LabelWrap = False
        Me.lvVenceSucursal.Location = New System.Drawing.Point(7, 18)
        Me.lvVenceSucursal.MultiSelect = False
        Me.lvVenceSucursal.Name = "lvVenceSucursal"
        Me.lvVenceSucursal.Size = New System.Drawing.Size(397, 164)
        Me.lvVenceSucursal.TabIndex = 3
        Me.lvVenceSucursal.UseCompatibleStateImageBehavior = False
        Me.lvVenceSucursal.View = System.Windows.Forms.View.Details
        '
        'detVence_deposito
        '
        Me.detVence_deposito.Text = "Deposito"
        Me.detVence_deposito.Width = 180
        '
        'detVence_lote
        '
        Me.detVence_lote.Text = "lote"
        '
        'detVence_vence
        '
        Me.detVence_vence.Text = "Vence"
        Me.detVence_vence.Width = 50
        '
        'detVence_cantidad
        '
        Me.detVence_cantidad.Text = "Cant."
        Me.detVence_cantidad.Width = 40
        '
        'detVence_comision
        '
        Me.detVence_comision.Text = "Premio"
        '
        'detVence_canje
        '
        Me.detVence_canje.Text = "Canj"
        Me.detVence_canje.Width = 30
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(323, 77)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(50, 20)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Visible = False
        '
        'frmLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 485)
        Me.Controls.Add(Me.grLote)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grBuscar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Lote"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.grLote.ResumeLayout(False)
        Me.grLote.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lvStockSucursal As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grLote As System.Windows.Forms.GroupBox
    Friend WithEvents lvVenceSucursal As System.Windows.Forms.ListView
    Friend WithEvents detVence_deposito As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVence_lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVence_vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVence_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVence_comision As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVence_canje As System.Windows.Forms.ColumnHeader
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
