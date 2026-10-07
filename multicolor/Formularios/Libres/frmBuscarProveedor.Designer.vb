<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarProveedor))
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvProveedor = New System.Windows.Forms.ListView()
        Me.txtIdProveedor = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdFantasia = New System.Windows.Forms.RadioButton()
        Me.rdNombre = New System.Windows.Forms.RadioButton()
        Me.rdId = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(103, 30)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(296, 22)
        Me.txtBuscar.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(40, 17)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'lvProveedor
        '
        Me.lvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvProveedor.FullRowSelect = True
        Me.lvProveedor.GridLines = True
        Me.lvProveedor.HideSelection = False
        Me.lvProveedor.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvProveedor.LabelWrap = False
        Me.lvProveedor.Location = New System.Drawing.Point(29, 60)
        Me.lvProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvProveedor.MultiSelect = False
        Me.lvProveedor.Name = "lvProveedor"
        Me.lvProveedor.Size = New System.Drawing.Size(745, 391)
        Me.lvProveedor.TabIndex = 21
        Me.lvProveedor.UseCompatibleStateImageBehavior = False
        Me.lvProveedor.View = System.Windows.Forms.View.Details
        '
        'txtIdProveedor
        '
        Me.txtIdProveedor.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProveedor.Enabled = False
        Me.txtIdProveedor.Location = New System.Drawing.Point(16, 470)
        Me.txtIdProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdProveedor.Name = "txtIdProveedor"
        Me.txtIdProveedor.Size = New System.Drawing.Size(65, 22)
        Me.txtIdProveedor.TabIndex = 23
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreProveedor.Enabled = False
        Me.txtNombreProveedor.Location = New System.Drawing.Point(91, 470)
        Me.txtNombreProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.Size = New System.Drawing.Size(328, 22)
        Me.txtNombreProveedor.TabIndex = 24
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdFantasia)
        Me.grOrdenar.Controls.Add(Me.rdNombre)
        Me.grOrdenar.Controls.Add(Me.rdId)
        Me.grOrdenar.Location = New System.Drawing.Point(413, 9)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Size = New System.Drawing.Size(372, 42)
        Me.grOrdenar.TabIndex = 25
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Buscar Por"
        '
        'rdFantasia
        '
        Me.rdFantasia.AutoSize = True
        Me.rdFantasia.Location = New System.Drawing.Point(189, 16)
        Me.rdFantasia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdFantasia.Name = "rdFantasia"
        Me.rdFantasia.Size = New System.Drawing.Size(170, 21)
        Me.rdFantasia.TabIndex = 19
        Me.rdFantasia.Text = "Nombre Fantasia/RUC"
        Me.rdFantasia.UseVisualStyleBackColor = True
        '
        'rdNombre
        '
        Me.rdNombre.AutoSize = True
        Me.rdNombre.Checked = True
        Me.rdNombre.Location = New System.Drawing.Point(65, 16)
        Me.rdNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdNombre.Name = "rdNombre"
        Me.rdNombre.Size = New System.Drawing.Size(112, 21)
        Me.rdNombre.TabIndex = 18
        Me.rdNombre.TabStop = True
        Me.rdNombre.Text = "Nombre/RUC"
        Me.rdNombre.UseVisualStyleBackColor = True
        '
        'rdId
        '
        Me.rdId.AutoSize = True
        Me.rdId.Location = New System.Drawing.Point(11, 16)
        Me.rdId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdId.Name = "rdId"
        Me.rdId.Size = New System.Drawing.Size(42, 21)
        Me.rdId.TabIndex = 17
        Me.rdId.Text = "ID"
        Me.rdId.UseVisualStyleBackColor = True
        '
        'frmBuscarProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 513)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.txtNombreProveedor)
        Me.Controls.Add(Me.txtIdProveedor)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvProveedor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Proveedor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvProveedor As System.Windows.Forms.ListView
    Friend WithEvents txtIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdFantasia As System.Windows.Forms.RadioButton
    Friend WithEvents rdNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rdId As System.Windows.Forms.RadioButton
End Class
