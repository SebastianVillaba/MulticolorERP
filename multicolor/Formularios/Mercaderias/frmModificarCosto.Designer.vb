<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificarCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificarCosto))
        Me.dtgCosto = New System.Windows.Forms.DataGridView()
        Me.dtg_nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg_idStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreMercaderia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg_lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg_vence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg_precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg_costoAct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtg_costoNue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblNro = New System.Windows.Forms.Label()
        CType(Me.dtgCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgCosto
        '
        Me.dtgCosto.AllowUserToDeleteRows = False
        Me.dtgCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCosto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtg_nro, Me.dtg_idStock, Me.codigo, Me.nombreMercaderia, Me.dtg_lote, Me.dtg_vence, Me.dtg_precio, Me.dtg_costoAct, Me.dtg_costoNue})
        Me.dtgCosto.Location = New System.Drawing.Point(12, 12)
        Me.dtgCosto.Name = "dtgCosto"
        Me.dtgCosto.Size = New System.Drawing.Size(763, 381)
        Me.dtgCosto.TabIndex = 68
        '
        'dtg_nro
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtg_nro.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_nro.HeaderText = "Nro"
        Me.dtg_nro.Name = "dtg_nro"
        Me.dtg_nro.ReadOnly = True
        Me.dtg_nro.Width = 40
        '
        'dtg_idStock
        '
        Me.dtg_idStock.HeaderText = "idStock"
        Me.dtg_idStock.Name = "dtg_idStock"
        Me.dtg_idStock.ReadOnly = True
        Me.dtg_idStock.Width = 50
        '
        'codigo
        '
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 50
        '
        'nombreMercaderia
        '
        Me.nombreMercaderia.HeaderText = "Mercadería"
        Me.nombreMercaderia.Name = "nombreMercaderia"
        Me.nombreMercaderia.ReadOnly = True
        Me.nombreMercaderia.Width = 250
        '
        'dtg_lote
        '
        Me.dtg_lote.HeaderText = "Lote"
        Me.dtg_lote.Name = "dtg_lote"
        Me.dtg_lote.ReadOnly = True
        Me.dtg_lote.Width = 70
        '
        'dtg_vence
        '
        Me.dtg_vence.HeaderText = "Vence"
        Me.dtg_vence.Name = "dtg_vence"
        Me.dtg_vence.ReadOnly = True
        Me.dtg_vence.Width = 50
        '
        'dtg_precio
        '
        Me.dtg_precio.HeaderText = "Precio"
        Me.dtg_precio.Name = "dtg_precio"
        Me.dtg_precio.ReadOnly = True
        Me.dtg_precio.Width = 70
        '
        'dtg_costoAct
        '
        Me.dtg_costoAct.HeaderText = "Costo Actual"
        Me.dtg_costoAct.Name = "dtg_costoAct"
        Me.dtg_costoAct.Width = 70
        '
        'dtg_costoNue
        '
        Me.dtg_costoNue.HeaderText = "Costo Nuevo"
        Me.dtg_costoNue.Name = "dtg_costoNue"
        Me.dtg_costoNue.ReadOnly = True
        Me.dtg_costoNue.Width = 70
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Location = New System.Drawing.Point(782, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(83, 188)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controles"
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(6, 145)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 65
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(6, 105)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(69, 37)
        Me.btnCancelar.TabIndex = 64
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(6, 62)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 62
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(6, 19)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 37)
        Me.btnAgregar.TabIndex = 14
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lblNro
        '
        Me.lblNro.AutoSize = True
        Me.lblNro.Location = New System.Drawing.Point(788, 200)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(22, 13)
        Me.lblNro.TabIndex = 70
        Me.lblNro.Text = "nro"
        '
        'frmModificarCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 405)
        Me.Controls.Add(Me.lblNro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgCosto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModificarCosto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de Costos"
        CType(Me.dtgCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgCosto As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg_idStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombreMercaderia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg_lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg_vence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg_precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg_costoAct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtg_costoNue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblNro As System.Windows.Forms.Label
End Class
