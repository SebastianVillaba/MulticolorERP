<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarGrupoCliente
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
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(16, 405)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(450, 20)
        Me.txtSql.TabIndex = 36
        Me.txtSql.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(72, 374)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(247, 20)
        Me.txtNombre.TabIndex = 35
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(16, 374)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(50, 20)
        Me.txtId.TabIndex = 34
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(81, 16)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(254, 20)
        Me.txtBuscar.TabIndex = 32
        '
        'lvBuscar
        '
        Me.lvBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(16, 41)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(433, 318)
        Me.lvBuscar.TabIndex = 33
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'PictureBox1
        '
        ' Me.PictureBox1.Image = Global.NetJoin.My.Resources.Resources._16__Print_preview_
        Me.PictureBox1.Location = New System.Drawing.Point(34, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'frmBuscarGrupoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 412)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarGrupoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Grupo de Clientes"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
End Class
