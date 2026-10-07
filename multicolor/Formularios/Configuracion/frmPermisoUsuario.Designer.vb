<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPermisoUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPermisoUsuario))
        Me.grFormulario = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtBuscarFormulario = New System.Windows.Forms.TextBox()
        Me.lvFormulario = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIdMenu = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreGrupoUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdGrupoUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grGrupoUsuario = New System.Windows.Forms.GroupBox()
        Me.cboTipoMenu = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBuscarGrupoUsuario = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.dtgGrupoUsuario = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.grFormulario.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grGrupoUsuario.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgGrupoUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grFormulario
        '
        Me.grFormulario.Controls.Add(Me.PictureBox2)
        Me.grFormulario.Controls.Add(Me.txtBuscarFormulario)
        Me.grFormulario.Controls.Add(Me.lvFormulario)
        Me.grFormulario.Location = New System.Drawing.Point(16, 0)
        Me.grFormulario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grFormulario.Name = "grFormulario"
        Me.grFormulario.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grFormulario.Size = New System.Drawing.Size(380, 206)
        Me.grFormulario.TabIndex = 0
        Me.grFormulario.TabStop = False
        Me.grFormulario.Text = "Buscar Formularios"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(17, 17)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(43, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'txtBuscarFormulario
        '
        Me.txtBuscarFormulario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarFormulario.Location = New System.Drawing.Point(73, 23)
        Me.txtBuscarFormulario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscarFormulario.Name = "txtBuscarFormulario"
        Me.txtBuscarFormulario.Size = New System.Drawing.Size(220, 22)
        Me.txtBuscarFormulario.TabIndex = 23
        '
        'lvFormulario
        '
        Me.lvFormulario.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvFormulario.Location = New System.Drawing.Point(13, 58)
        Me.lvFormulario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvFormulario.Name = "lvFormulario"
        Me.lvFormulario.Size = New System.Drawing.Size(353, 137)
        Me.lvFormulario.TabIndex = 21
        Me.lvFormulario.UseCompatibleStateImageBehavior = False
        Me.lvFormulario.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IDGrupo"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre de Grupo de Usuario"
        Me.ColumnHeader2.Width = 200
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIdMenu)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNombreGrupoUsuario)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtIdGrupoUsuario)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(404, 6)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(484, 89)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtIdMenu
        '
        Me.txtIdMenu.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdMenu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMenu.Enabled = False
        Me.txtIdMenu.Location = New System.Drawing.Point(85, 44)
        Me.txtIdMenu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdMenu.Name = "txtIdMenu"
        Me.txtIdMenu.Size = New System.Drawing.Size(81, 22)
        Me.txtIdMenu.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Id Menu :"
        '
        'txtNombreGrupoUsuario
        '
        Me.txtNombreGrupoUsuario.BackColor = System.Drawing.Color.SkyBlue
        Me.txtNombreGrupoUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreGrupoUsuario.Enabled = False
        Me.txtNombreGrupoUsuario.Location = New System.Drawing.Point(173, 38)
        Me.txtNombreGrupoUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreGrupoUsuario.Name = "txtNombreGrupoUsuario"
        Me.txtNombreGrupoUsuario.Size = New System.Drawing.Size(299, 22)
        Me.txtNombreGrupoUsuario.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Grupo de Usuario "
        '
        'txtIdGrupoUsuario
        '
        Me.txtIdGrupoUsuario.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdGrupoUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdGrupoUsuario.Enabled = False
        Me.txtIdGrupoUsuario.Location = New System.Drawing.Point(85, 16)
        Me.txtIdGrupoUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdGrupoUsuario.Name = "txtIdGrupoUsuario"
        Me.txtIdGrupoUsuario.Size = New System.Drawing.Size(81, 22)
        Me.txtIdGrupoUsuario.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Id Grupo :"
        '
        'grGrupoUsuario
        '
        Me.grGrupoUsuario.Controls.Add(Me.cboTipoMenu)
        Me.grGrupoUsuario.Controls.Add(Me.Label7)
        Me.grGrupoUsuario.Controls.Add(Me.txtBuscarGrupoUsuario)
        Me.grGrupoUsuario.Controls.Add(Me.PictureBox3)
        Me.grGrupoUsuario.Controls.Add(Me.dtgGrupoUsuario)
        Me.grGrupoUsuario.Location = New System.Drawing.Point(16, 215)
        Me.grGrupoUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grGrupoUsuario.Name = "grGrupoUsuario"
        Me.grGrupoUsuario.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grGrupoUsuario.Size = New System.Drawing.Size(1303, 407)
        Me.grGrupoUsuario.TabIndex = 2
        Me.grGrupoUsuario.TabStop = False
        Me.grGrupoUsuario.Text = "Buscar Grupo de Usuarios"
        '
        'cboTipoMenu
        '
        Me.cboTipoMenu.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoMenu.FormattingEnabled = True
        Me.cboTipoMenu.Location = New System.Drawing.Point(381, 38)
        Me.cboTipoMenu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboTipoMenu.Name = "cboTipoMenu"
        Me.cboTipoMenu.Size = New System.Drawing.Size(367, 28)
        Me.cboTipoMenu.TabIndex = 106
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(380, 15)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 20)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "Tipo de Menu :"
        '
        'txtBuscarGrupoUsuario
        '
        Me.txtBuscarGrupoUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarGrupoUsuario.Location = New System.Drawing.Point(99, 38)
        Me.txtBuscarGrupoUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscarGrupoUsuario.Name = "txtBuscarGrupoUsuario"
        Me.txtBuscarGrupoUsuario.Size = New System.Drawing.Size(253, 22)
        Me.txtBuscarGrupoUsuario.TabIndex = 24
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(44, 31)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(43, 37)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'dtgGrupoUsuario
        '
        Me.dtgGrupoUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgGrupoUsuario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.tipoProducto, Me.Column3, Me.Column2, Me.Column1})
        Me.dtgGrupoUsuario.Location = New System.Drawing.Point(11, 76)
        Me.dtgGrupoUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtgGrupoUsuario.Name = "dtgGrupoUsuario"
        Me.dtgGrupoUsuario.Size = New System.Drawing.Size(1284, 319)
        Me.dtgGrupoUsuario.TabIndex = 22
        '
        'codigo
        '
        Me.codigo.HeaderText = "IdForm."
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 50
        '
        'tipoProducto
        '
        Me.tipoProducto.HeaderText = "Nombre del Menu"
        Me.tipoProducto.Name = "tipoProducto"
        Me.tipoProducto.ReadOnly = True
        Me.tipoProducto.Width = 360
        '
        'Column3
        '
        Me.Column3.HeaderText = "Explica"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 300
        '
        'Column2
        '
        Me.Column2.HeaderText = "Tipo Menu"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column1
        '
        Me.Column1.HeaderText = "hab"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Location = New System.Drawing.Point(404, 102)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(327, 71)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controles"
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(212, 20)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(92, 46)
        Me.btnCancelar.TabIndex = 64
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(108, 20)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
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
        Me.btnAgregar.Location = New System.Drawing.Point(8, 20)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(92, 46)
        Me.btnAgregar.TabIndex = 14
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmPermisoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1327, 630)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grGrupoUsuario)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grFormulario)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPermisoUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permisos de Usuarios"
        Me.grFormulario.ResumeLayout(False)
        Me.grFormulario.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grGrupoUsuario.ResumeLayout(False)
        Me.grGrupoUsuario.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgGrupoUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grFormulario As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscarFormulario As System.Windows.Forms.TextBox
    Friend WithEvents lvFormulario As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdGrupoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreGrupoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grGrupoUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscarGrupoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents dtgGrupoUsuario As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtIdMenu As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoMenu As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
