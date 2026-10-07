<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarClienteVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarClienteVenta))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdApellido = New System.Windows.Forms.RadioButton()
        Me.rdNombre = New System.Windows.Forms.RadioButton()
        Me.rdIdCliente = New System.Windows.Forms.RadioButton()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lvCliente = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.Label1)
        Me.grBuscar.Controls.Add(Me.txtIdCliente)
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.lvCliente)
        Me.grBuscar.Location = New System.Drawing.Point(33, 15)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grBuscar.Size = New System.Drawing.Size(1001, 588)
        Me.grBuscar.TabIndex = 2
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 43)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(521, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(291, 18)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Clientes que no están Habilitados a Crédito"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdCliente.Enabled = False
        Me.txtIdCliente.Location = New System.Drawing.Point(417, 60)
        Me.txtIdCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(68, 22)
        Me.txtIdCliente.TabIndex = 19
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdApellido)
        Me.grOrdenar.Controls.Add(Me.rdNombre)
        Me.grOrdenar.Controls.Add(Me.rdIdCliente)
        Me.grOrdenar.Location = New System.Drawing.Point(85, 14)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Size = New System.Drawing.Size(345, 42)
        Me.grOrdenar.TabIndex = 18
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdApellido
        '
        Me.rdApellido.AutoSize = True
        Me.rdApellido.Location = New System.Drawing.Point(189, 16)
        Me.rdApellido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdApellido.Name = "rdApellido"
        Me.rdApellido.Size = New System.Drawing.Size(112, 21)
        Me.rdApellido.TabIndex = 19
        Me.rdApellido.Text = "Apellido/RUC"
        Me.rdApellido.UseVisualStyleBackColor = True
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
        'rdIdCliente
        '
        Me.rdIdCliente.AutoSize = True
        Me.rdIdCliente.Location = New System.Drawing.Point(11, 16)
        Me.rdIdCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdIdCliente.Name = "rdIdCliente"
        Me.rdIdCliente.Size = New System.Drawing.Size(42, 21)
        Me.rdIdCliente.TabIndex = 17
        Me.rdIdCliente.Text = "ID"
        Me.rdIdCliente.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(71, 60)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(323, 22)
        Me.txtBuscar.TabIndex = 2
        '
        'lvCliente
        '
        Me.lvCliente.AllowColumnReorder = True
        Me.lvCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvCliente.FullRowSelect = True
        Me.lvCliente.GridLines = True
        Me.lvCliente.HideSelection = False
        Me.lvCliente.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCliente.LabelWrap = False
        Me.lvCliente.Location = New System.Drawing.Point(15, 100)
        Me.lvCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvCliente.MultiSelect = False
        Me.lvCliente.Name = "lvCliente"
        Me.lvCliente.Size = New System.Drawing.Size(968, 482)
        Me.lvCliente.TabIndex = 3
        Me.lvCliente.UseCompatibleStateImageBehavior = False
        Me.lvCliente.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "RUC"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombre"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Apellido"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Grupo"
        Me.ColumnHeader5.Width = 200
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Acre."
        Me.ColumnHeader6.Width = 20
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(16, 610)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(1048, 22)
        Me.txtSql.TabIndex = 21
        Me.txtSql.Visible = False
        '
        'frmBuscarClienteVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 644)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarClienteVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Clientes en Ventas"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdApellido As System.Windows.Forms.RadioButton
    Friend WithEvents rdNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rdIdCliente As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lvCliente As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
