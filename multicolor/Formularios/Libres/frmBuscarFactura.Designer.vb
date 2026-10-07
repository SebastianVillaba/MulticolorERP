<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarFactura))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdIdSucursal = New System.Windows.Forms.RadioButton()
        Me.rdSuc = New System.Windows.Forms.RadioButton()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvMoneda = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.GroupBox3)
        Me.grBuscar.Controls.Add(Me.txtId)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvMoneda)
        Me.grBuscar.Location = New System.Drawing.Point(31, 15)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grBuscar.Size = New System.Drawing.Size(741, 482)
        Me.grBuscar.TabIndex = 4
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdIdSucursal)
        Me.GroupBox3.Controls.Add(Me.rdSuc)
        Me.GroupBox3.Location = New System.Drawing.Point(361, 11)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(129, 75)
        Me.GroupBox3.TabIndex = 103
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdIdSucursal
        '
        Me.rdIdSucursal.AutoSize = True
        Me.rdIdSucursal.Location = New System.Drawing.Point(8, 52)
        Me.rdIdSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdIdSucursal.Name = "rdIdSucursal"
        Me.rdIdSucursal.Size = New System.Drawing.Size(99, 21)
        Me.rdIdSucursal.TabIndex = 19
        Me.rdIdSucursal.Text = "id Sucursal"
        Me.rdIdSucursal.UseVisualStyleBackColor = True
        '
        'rdSuc
        '
        Me.rdSuc.AutoSize = True
        Me.rdSuc.Checked = True
        Me.rdSuc.Location = New System.Drawing.Point(8, 23)
        Me.rdSuc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdSuc.Name = "rdSuc"
        Me.rdSuc.Size = New System.Drawing.Size(57, 21)
        Me.rdSuc.TabIndex = 18
        Me.rdSuc.TabStop = True
        Me.rdSuc.Text = "SUC"
        Me.rdSuc.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.SkyBlue
        Me.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(517, 42)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(76, 22)
        Me.txtId.TabIndex = 4
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(71, 42)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(281, 22)
        Me.txtBuscar.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 30)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(57, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lvMoneda
        '
        Me.lvMoneda.AllowColumnReorder = True
        Me.lvMoneda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3})
        Me.lvMoneda.FullRowSelect = True
        Me.lvMoneda.GridLines = True
        Me.lvMoneda.HideSelection = False
        Me.lvMoneda.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvMoneda.LabelWrap = False
        Me.lvMoneda.Location = New System.Drawing.Point(8, 94)
        Me.lvMoneda.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvMoneda.MultiSelect = False
        Me.lvMoneda.Name = "lvMoneda"
        Me.lvMoneda.Size = New System.Drawing.Size(707, 381)
        Me.lvMoneda.TabIndex = 3
        Me.lvMoneda.UseCompatibleStateImageBehavior = False
        Me.lvMoneda.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombre"
        Me.ColumnHeader3.Width = 300
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(39, 519)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(732, 22)
        Me.txtSql.TabIndex = 104
        Me.txtSql.Visible = False
        '
        'frmBuscarFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 535)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.grBuscar)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmBuscarFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Facturas de Venta"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvMoneda As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdIdSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents rdSuc As System.Windows.Forms.RadioButton
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
End Class
