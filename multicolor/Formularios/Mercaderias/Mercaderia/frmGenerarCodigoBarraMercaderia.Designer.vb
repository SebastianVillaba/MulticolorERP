<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarCodigoBarraMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerarCodigoBarraMercaderia))
        Me.dtgCodigoBarra = New System.Windows.Forms.DataGridView()
        Me.Nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mercaderia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deposito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnCompra = New System.Windows.Forms.Button()
        Me.txtNro = New System.Windows.Forms.TextBox()
        CType(Me.dtgCodigoBarra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgCodigoBarra
        '
        Me.dtgCodigoBarra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCodigoBarra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nro, Me.Column1, Me.codigo, Me.mercaderia, Me.deposito, Me.lote, Me.vence, Me.cantidad, Me.idStock})
        Me.dtgCodigoBarra.Location = New System.Drawing.Point(10, 12)
        Me.dtgCodigoBarra.Name = "dtgCodigoBarra"
        Me.dtgCodigoBarra.Size = New System.Drawing.Size(923, 375)
        Me.dtgCodigoBarra.TabIndex = 26
        '
        'Nro
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Nro.DefaultCellStyle = DataGridViewCellStyle1
        Me.Nro.HeaderText = "Nro"
        Me.Nro.Name = "Nro"
        Me.Nro.ReadOnly = True
        Me.Nro.Width = 40
        '
        'Column1
        '
        Me.Column1.HeaderText = "idProd"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 70
        '
        'mercaderia
        '
        Me.mercaderia.HeaderText = "Mercadería "
        Me.mercaderia.Name = "mercaderia"
        Me.mercaderia.ReadOnly = True
        Me.mercaderia.Width = 280
        '
        'deposito
        '
        Me.deposito.HeaderText = "Deposito"
        Me.deposito.Name = "deposito"
        Me.deposito.ReadOnly = True
        Me.deposito.Width = 200
        '
        'lote
        '
        Me.lote.HeaderText = "lote"
        Me.lote.Name = "lote"
        Me.lote.ReadOnly = True
        Me.lote.Width = 70
        '
        'vence
        '
        Me.vence.HeaderText = "Vence"
        Me.vence.Name = "vence"
        Me.vence.ReadOnly = True
        Me.vence.Width = 60
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cant."
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Width = 40
        '
        'idStock
        '
        Me.idStock.HeaderText = "idStock"
        Me.idStock.Name = "idStock"
        Me.idStock.ReadOnly = True
        Me.idStock.Width = 60
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnGenerar)
        Me.GroupBox1.Controls.Add(Me.btnCompra)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 401)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(388, 64)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controles"
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(10, 19)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 37)
        Me.btnAgregar.TabIndex = 71
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(310, 19)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(69, 37)
        Me.btnLimpiar.TabIndex = 70
        Me.btnLimpiar.Text = "&Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(235, 19)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 69
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerar.Location = New System.Drawing.Point(160, 19)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(69, 37)
        Me.btnGenerar.TabIndex = 68
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnCompra
        '
        Me.btnCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCompra.Image = CType(resources.GetObject("btnCompra.Image"), System.Drawing.Image)
        Me.btnCompra.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCompra.Location = New System.Drawing.Point(85, 19)
        Me.btnCompra.Name = "btnCompra"
        Me.btnCompra.Size = New System.Drawing.Size(69, 37)
        Me.btnCompra.TabIndex = 67
        Me.btnCompra.Text = "&Compra"
        Me.btnCompra.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCompra.UseVisualStyleBackColor = True
        '
        'txtNro
        '
        Me.txtNro.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNro.Enabled = False
        Me.txtNro.Location = New System.Drawing.Point(406, 445)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(54, 20)
        Me.txtNro.TabIndex = 33
        '
        'frmGenerarCodigoBarraMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 477)
        Me.Controls.Add(Me.txtNro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgCodigoBarra)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerarCodigoBarraMercaderia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGenerarCodigoBarraMercaderia"
        CType(Me.dtgCodigoBarra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgCodigoBarra As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mercaderia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deposito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnCompra As System.Windows.Forms.Button
End Class
