<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarAjusteMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarAjusteMercaderia))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.idAjuste = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.responsable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fechaa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdMov = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.txtSql)
        Me.grBuscar.Controls.Add(Me.lvBuscar)
        Me.grBuscar.Controls.Add(Me.txtIdMov)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(14, 3)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(691, 472)
        Me.grBuscar.TabIndex = 6
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(336, 50)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(336, 20)
        Me.txtSql.TabIndex = 6
        Me.txtSql.Visible = False
        '
        'lvBuscar
        '
        Me.lvBuscar.AllowColumnReorder = True
        Me.lvBuscar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idAjuste, Me.sucursal, Me.responsable, Me.fechaa})
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(6, 76)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(666, 378)
        Me.lvBuscar.TabIndex = 5
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'idAjuste
        '
        Me.idAjuste.Text = "IdAjuste"
        '
        'sucursal
        '
        Me.sucursal.Text = "Sucursal"
        Me.sucursal.Width = 200
        '
        'responsable
        '
        Me.responsable.Text = "Responsable"
        Me.responsable.Width = 250
        '
        'fechaa
        '
        Me.fechaa.Text = "Fecha/Hora"
        Me.fechaa.Width = 150
        '
        'txtIdMov
        '
        Me.txtIdMov.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMov.Enabled = False
        Me.txtIdMov.Location = New System.Drawing.Point(272, 34)
        Me.txtIdMov.Name = "txtIdMov"
        Me.txtIdMov.Size = New System.Drawing.Size(58, 20)
        Me.txtIdMov.TabIndex = 4
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 34)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(212, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'frmBuscarAjusteMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 487)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarAjusteMercaderia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Ajuste de Mercaderías"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents idAjuste As System.Windows.Forms.ColumnHeader
    Friend WithEvents sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents responsable As System.Windows.Forms.ColumnHeader
    Friend WithEvents fechaa As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdMov As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
