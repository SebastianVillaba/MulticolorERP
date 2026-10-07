<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpCodigoBarraMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpCodigoBarraMercaderia))
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dtgCodigoBarra = New System.Windows.Forms.DataGridView()
        Me.Nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mercaderia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deposito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bonificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.imprimir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNro = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.dtgCodigoBarra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(299, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(102, 20)
        Me.CheckBox1.TabIndex = 28
        Me.CheckBox1.Text = "Listar Todos"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(90, 20)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(191, 20)
        Me.txtBuscar.TabIndex = 27
        '
        'dtgCodigoBarra
        '
        Me.dtgCodigoBarra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCodigoBarra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nro, Me.Column1, Me.codigo, Me.mercaderia, Me.deposito, Me.idCompra, Me.lote, Me.vence, Me.cantidad, Me.bonificacion, Me.imprimir})
        Me.dtgCodigoBarra.Location = New System.Drawing.Point(6, 46)
        Me.dtgCodigoBarra.Name = "dtgCodigoBarra"
        Me.dtgCodigoBarra.Size = New System.Drawing.Size(905, 346)
        Me.dtgCodigoBarra.TabIndex = 25
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
        Me.Column1.HeaderText = "idCod"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 50
        '
        'mercaderia
        '
        Me.mercaderia.HeaderText = "Mercadería "
        Me.mercaderia.Name = "mercaderia"
        Me.mercaderia.ReadOnly = True
        Me.mercaderia.Width = 250
        '
        'deposito
        '
        Me.deposito.HeaderText = "Deposito"
        Me.deposito.Name = "deposito"
        Me.deposito.ReadOnly = True
        Me.deposito.Width = 150
        '
        'idCompra
        '
        Me.idCompra.HeaderText = "ID Compra"
        Me.idCompra.Name = "idCompra"
        Me.idCompra.ReadOnly = True
        Me.idCompra.Width = 60
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
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 40
        '
        'bonificacion
        '
        Me.bonificacion.HeaderText = "Boni"
        Me.bonificacion.Name = "bonificacion"
        Me.bonificacion.ReadOnly = True
        Me.bonificacion.Width = 40
        '
        'imprimir
        '
        Me.imprimir.HeaderText = "Imp."
        Me.imprimir.Name = "imprimir"
        Me.imprimir.Width = 40
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnActualizar)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 402)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 64)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controles"
        '
        'txtNro
        '
        Me.txtNro.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNro.Enabled = False
        Me.txtNro.Location = New System.Drawing.Point(407, 20)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(54, 20)
        Me.txtNro.TabIndex = 32
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(237, 17)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(69, 37)
        Me.btnLimpiar.TabIndex = 69
        Me.btnLimpiar.Text = "&Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(162, 17)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 68
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizar.Location = New System.Drawing.Point(87, 17)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(69, 37)
        Me.btnActualizar.TabIndex = 67
        Me.btnActualizar.Text = "&Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(12, 17)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 66
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(52, 10)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 33
        Me.PictureBox3.TabStop = False
        '
        'frmImpCodigoBarraMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 472)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.txtNro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.dtgCodigoBarra)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImpCodigoBarraMercaderia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Codigo de Barra a Mercaderías"
        CType(Me.dtgCodigoBarra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents dtgCodigoBarra As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mercaderia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deposito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bonificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imprimir As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
