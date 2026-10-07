<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchivoCorreoCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArchivoCorreoCliente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.btnExportarDetalle = New System.Windows.Forms.Button()
        Me.lvDetalle = New System.Windows.Forms.ListView()
        Me.det_nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_apellido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_correo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.btnExportarDetalle)
        Me.GroupBox1.Controls.Add(Me.lvDetalle)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 16)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(802, 623)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Archivo para la resolución RG90"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(111, 580)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 20)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Guardar Archivo en:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.PaleGreen
        Me.txtDireccion.Location = New System.Drawing.Point(303, 580)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(317, 22)
        Me.txtDireccion.TabIndex = 104
        '
        'btnExportarDetalle
        '
        Me.btnExportarDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarDetalle.Image = CType(resources.GetObject("btnExportarDetalle.Image"), System.Drawing.Image)
        Me.btnExportarDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportarDetalle.Location = New System.Drawing.Point(12, 568)
        Me.btnExportarDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportarDetalle.Name = "btnExportarDetalle"
        Me.btnExportarDetalle.Size = New System.Drawing.Size(76, 47)
        Me.btnExportarDetalle.TabIndex = 95
        Me.btnExportarDetalle.Text = "Exportar"
        Me.btnExportarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportarDetalle.UseVisualStyleBackColor = True
        '
        'lvDetalle
        '
        Me.lvDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_nombre, Me.det_apellido, Me.det_correo})
        Me.lvDetalle.Location = New System.Drawing.Point(12, 20)
        Me.lvDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.lvDetalle.Name = "lvDetalle"
        Me.lvDetalle.Size = New System.Drawing.Size(782, 511)
        Me.lvDetalle.TabIndex = 4
        Me.lvDetalle.UseCompatibleStateImageBehavior = False
        Me.lvDetalle.View = System.Windows.Forms.View.Details
        '
        'det_nombre
        '
        Me.det_nombre.Text = "Nombre"
        Me.det_nombre.Width = 150
        '
        'det_apellido
        '
        Me.det_apellido.Text = "Apelllido"
        Me.det_apellido.Width = 200
        '
        'det_correo
        '
        Me.det_correo.Text = "Correo"
        Me.det_correo.Width = 300
        '
        'frmArchivoCorreoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 674)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmArchivoCorreoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar archivo de contactos de correos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents btnExportarDetalle As System.Windows.Forms.Button
    Friend WithEvents lvDetalle As System.Windows.Forms.ListView
    Friend WithEvents det_nombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_apellido As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_correo As System.Windows.Forms.ColumnHeader
End Class
