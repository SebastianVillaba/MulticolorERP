<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarOrdenSuvinil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarOrdenSuvinil))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdBase = New System.Windows.Forms.RadioButton()
        Me.rdCliente = New System.Windows.Forms.RadioButton()
        Me.rdNombreColor = New System.Windows.Forms.RadioButton()
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.IdOrden = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdMov = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.lvBuscar)
        Me.grBuscar.Controls.Add(Me.txtIdMov)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(20, 15)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Size = New System.Drawing.Size(1109, 581)
        Me.grBuscar.TabIndex = 10
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 34)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdBase)
        Me.grOrdenar.Controls.Add(Me.rdCliente)
        Me.grOrdenar.Controls.Add(Me.rdNombreColor)
        Me.grOrdenar.Location = New System.Drawing.Point(365, 24)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Size = New System.Drawing.Size(284, 51)
        Me.grOrdenar.TabIndex = 19
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Busqueda"
        '
        'rdBase
        '
        Me.rdBase.AutoSize = True
        Me.rdBase.Location = New System.Drawing.Point(194, 22)
        Me.rdBase.Margin = New System.Windows.Forms.Padding(4)
        Me.rdBase.Name = "rdBase"
        Me.rdBase.Size = New System.Drawing.Size(61, 21)
        Me.rdBase.TabIndex = 19
        Me.rdBase.Text = "Base"
        Me.rdBase.UseVisualStyleBackColor = True
        '
        'rdCliente
        '
        Me.rdCliente.AutoSize = True
        Me.rdCliente.Location = New System.Drawing.Point(95, 22)
        Me.rdCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCliente.Name = "rdCliente"
        Me.rdCliente.Size = New System.Drawing.Size(72, 21)
        Me.rdCliente.TabIndex = 18
        Me.rdCliente.Text = "Cliente"
        Me.rdCliente.UseVisualStyleBackColor = True
        '
        'rdNombreColor
        '
        Me.rdNombreColor.AutoSize = True
        Me.rdNombreColor.Checked = True
        Me.rdNombreColor.Location = New System.Drawing.Point(15, 22)
        Me.rdNombreColor.Margin = New System.Windows.Forms.Padding(4)
        Me.rdNombreColor.Name = "rdNombreColor"
        Me.rdNombreColor.Size = New System.Drawing.Size(62, 21)
        Me.rdNombreColor.TabIndex = 17
        Me.rdNombreColor.TabStop = True
        Me.rdNombreColor.Text = "Color"
        Me.rdNombreColor.UseVisualStyleBackColor = True
        '
        'lvBuscar
        '
        Me.lvBuscar.AllowColumnReorder = True
        Me.lvBuscar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IdOrden, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader1})
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(12, 86)
        Me.lvBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(1067, 464)
        Me.lvBuscar.TabIndex = 5
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'IdOrden
        '
        Me.IdOrden.Text = "ID Orden"
        Me.IdOrden.Width = 70
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Nombre Color"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Cliente"
        Me.ColumnHeader9.Width = 250
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Nombre Base"
        Me.ColumnHeader11.Width = 300
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Total"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fecha"
        Me.ColumnHeader1.Width = 120
        '
        'txtIdMov
        '
        Me.txtIdMov.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMov.Enabled = False
        Me.txtIdMov.Location = New System.Drawing.Point(695, 45)
        Me.txtIdMov.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdMov.Name = "txtIdMov"
        Me.txtIdMov.Size = New System.Drawing.Size(76, 22)
        Me.txtIdMov.TabIndex = 4
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(71, 42)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(281, 22)
        Me.txtBuscar.TabIndex = 2
        '
        'frmBuscarOrdenSuvinil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1148, 620)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBuscarOrdenSuvinil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Orden Suvinil"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdBase As System.Windows.Forms.RadioButton
    Friend WithEvents rdCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rdNombreColor As System.Windows.Forms.RadioButton
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents IdOrden As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdMov As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
End Class
