<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarTipoProceso
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
        Me.txtIdMoneda = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtIdMoneda)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(12, 12)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(361, 305)
        Me.grBuscar.TabIndex = 4
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtIdMoneda
        '
        Me.txtIdMoneda.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMoneda.Enabled = False
        Me.txtIdMoneda.Location = New System.Drawing.Point(272, 34)
        Me.txtIdMoneda.Name = "txtIdMoneda"
        Me.txtIdMoneda.Size = New System.Drawing.Size(58, 20)
        Me.txtIdMoneda.TabIndex = 4
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 34)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(212, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'PictureBox1
        '
        ' Me.PictureBox1.Image = Global.NetJoin.My.Resources.Resources._16__Print_preview_
        Me.PictureBox1.Location = New System.Drawing.Point(6, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lvBuscar
        '
        Me.lvBuscar.AllowColumnReorder = True
        Me.lvBuscar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3})
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(6, 76)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(286, 217)
        Me.lvBuscar.TabIndex = 3
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombre"
        Me.ColumnHeader3.Width = 350
        '
        'frmBuscarTipoProceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 332)
        Me.Controls.Add(Me.grBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarTipoProceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Tipo de Proceso"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
End Class
