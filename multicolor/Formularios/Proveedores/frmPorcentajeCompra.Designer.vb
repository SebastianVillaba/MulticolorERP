<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPorcentajeCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPorcentajeCompra))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdMonto = New System.Windows.Forms.RadioButton()
        Me.rdPorcentaje = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 65)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(309, 87)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(133, 34)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(147, 29)
        Me.txtMonto.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Porcentaje:"
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdMonto)
        Me.grOrdenar.Controls.Add(Me.rdPorcentaje)
        Me.grOrdenar.Location = New System.Drawing.Point(16, 16)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Size = New System.Drawing.Size(217, 42)
        Me.grOrdenar.TabIndex = 19
        Me.grOrdenar.TabStop = False
        '
        'rdMonto
        '
        Me.rdMonto.AutoSize = True
        Me.rdMonto.Location = New System.Drawing.Point(123, 16)
        Me.rdMonto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdMonto.Name = "rdMonto"
        Me.rdMonto.Size = New System.Drawing.Size(68, 21)
        Me.rdMonto.TabIndex = 18
        Me.rdMonto.Text = "Monto"
        Me.rdMonto.UseVisualStyleBackColor = True
        '
        'rdPorcentaje
        '
        Me.rdPorcentaje.AutoSize = True
        Me.rdPorcentaje.Checked = True
        Me.rdPorcentaje.Location = New System.Drawing.Point(11, 16)
        Me.rdPorcentaje.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdPorcentaje.Name = "rdPorcentaje"
        Me.rdPorcentaje.Size = New System.Drawing.Size(97, 21)
        Me.rdPorcentaje.TabIndex = 17
        Me.rdPorcentaje.TabStop = True
        Me.rdPorcentaje.Text = "Porcentaje"
        Me.rdPorcentaje.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(333, 100)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(92, 46)
        Me.btnAceptar.TabIndex = 19
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmPorcentajeCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 177)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPorcentajeCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Porcentaje - Monto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdMonto As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
