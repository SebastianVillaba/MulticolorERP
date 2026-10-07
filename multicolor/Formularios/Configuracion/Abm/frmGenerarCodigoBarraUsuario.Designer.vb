<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarCodigoBarraUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerarCodigoBarraUsuario))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdNombre = New System.Windows.Forms.RadioButton()
        Me.rdNick = New System.Windows.Forms.RadioButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtgUsuario = New System.Windows.Forms.DataGridView()
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.grOrdenar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdNombre)
        Me.grOrdenar.Controls.Add(Me.rdNick)
        Me.grOrdenar.Location = New System.Drawing.Point(70, 2)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(129, 34)
        Me.grOrdenar.TabIndex = 133
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdNombre
        '
        Me.rdNombre.AutoSize = True
        Me.rdNombre.Checked = True
        Me.rdNombre.Location = New System.Drawing.Point(58, 13)
        Me.rdNombre.Name = "rdNombre"
        Me.rdNombre.Size = New System.Drawing.Size(62, 17)
        Me.rdNombre.TabIndex = 18
        Me.rdNombre.TabStop = True
        Me.rdNombre.Text = "Nombre"
        Me.rdNombre.UseVisualStyleBackColor = True
        '
        'rdNick
        '
        Me.rdNick.AutoSize = True
        Me.rdNick.Location = New System.Drawing.Point(8, 13)
        Me.rdNick.Name = "rdNick"
        Me.rdNick.Size = New System.Drawing.Size(47, 17)
        Me.rdNick.TabIndex = 17
        Me.rdNick.Text = "Nick"
        Me.rdNick.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(281, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 136
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGenerar.Location = New System.Drawing.Point(356, 24)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(69, 37)
        Me.btnGenerar.TabIndex = 134
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(59, 40)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 128
        '
        'PictureBox1
        '
        '  Me.PictureBox1.Image = Global.NetJoin.My.Resources.Resources._16__Print_preview_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 129
        Me.PictureBox1.TabStop = False
        '
        'dtgUsuario
        '
        Me.dtgUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgUsuario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgUsuario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.Column7, Me.Column1, Me.Column2, Me.Column3, Me.cotiza, Me.Column4})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgUsuario.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgUsuario.Location = New System.Drawing.Point(9, 72)
        Me.dtgUsuario.Name = "dtgUsuario"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgUsuario.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgUsuario.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dtgUsuario.Size = New System.Drawing.Size(733, 394)
        Me.dtgUsuario.TabIndex = 127
        '
        'Column0
        '
        Me.Column0.Frozen = True
        Me.Column0.HeaderText = "Nro"
        Me.Column0.Name = "Column0"
        Me.Column0.ReadOnly = True
        Me.Column0.Width = 30
        '
        'Column7
        '
        Me.Column7.Frozen = True
        Me.Column7.HeaderText = "idUsu."
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 60
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Nick"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 130
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Nombre"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.FillWeight = 150.0!
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Apellido"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'cotiza
        '
        Me.cotiza.Frozen = True
        Me.cotiza.HeaderText = "Grupo"
        Me.cotiza.Name = "cotiza"
        Me.cotiza.ReadOnly = True
        Me.cotiza.Width = 130
        '
        'Column4
        '
        Me.Column4.HeaderText = "Imp."
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 40
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(9, 472)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(733, 20)
        Me.txtSql.TabIndex = 137
        Me.txtSql.Visible = False
        '
        'frmGenerarCodigoBarraUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 504)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dtgUsuario)
        Me.Controls.Add(Me.txtSql)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerarCodigoBarraUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar e Imprimir Codigos de Barra de Usuarios"
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rdNick As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtgUsuario As System.Windows.Forms.DataGridView
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents Column0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cotiza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
