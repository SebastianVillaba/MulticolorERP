<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarImagen
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
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.pbxImg = New System.Windows.Forms.PictureBox()
        Me.dlgFile = New System.Windows.Forms.OpenFileDialog()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.lbImg = New System.Windows.Forms.Label()
        Me.lbImg2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pbxImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAbrir
        '
        Me.btnAbrir.Cursor = System.Windows.Forms.Cursors.Hand
        ' Me.btnAbrir.Image = Global.NetJoin.My.Resources.Resources._16__Cabinet_
        Me.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAbrir.Location = New System.Drawing.Point(11, 19)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(75, 40)
        Me.btnAbrir.TabIndex = 0
        Me.btnAbrir.Text = "&Abrir"
        Me.btnAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Enabled = False
        Me.VScrollBar1.Location = New System.Drawing.Point(32, 12)
        Me.VScrollBar1.Maximum = 107
        Me.VScrollBar1.Minimum = 10
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(20, 304)
        Me.VScrollBar1.TabIndex = 12
        Me.VScrollBar1.Value = 100
        '
        'pbxImg
        '
        Me.pbxImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbxImg.Location = New System.Drawing.Point(63, 12)
        Me.pbxImg.Name = "pbxImg"
        Me.pbxImg.Size = New System.Drawing.Size(456, 304)
        Me.pbxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxImg.TabIndex = 11
        Me.pbxImg.TabStop = False
        '
        'dlgSave
        '
        Me.dlgSave.FileName = "doc1"
        '
        'lbImg
        '
        Me.lbImg.BackColor = System.Drawing.Color.Gainsboro
        Me.lbImg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbImg.Location = New System.Drawing.Point(40, 324)
        Me.lbImg.Name = "lbImg"
        Me.lbImg.Size = New System.Drawing.Size(472, 16)
        Me.lbImg.TabIndex = 13
        Me.lbImg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbImg2
        '
        Me.lbImg2.BackColor = System.Drawing.Color.Gainsboro
        Me.lbImg2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbImg2.Location = New System.Drawing.Point(39, 347)
        Me.lbImg2.Name = "lbImg2"
        Me.lbImg2.Size = New System.Drawing.Size(472, 16)
        Me.lbImg2.TabIndex = 14
        Me.lbImg2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnAbrir)
        Me.GroupBox1.Location = New System.Drawing.Point(340, 368)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(179, 69)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        ' Me.btnAceptar.Image = Global.NetJoin.My.Resources.Resources._16__Card_mark_
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(92, 19)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 40)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.Color.SkyBlue
        Me.txtArchivo.Enabled = False
        Me.txtArchivo.Location = New System.Drawing.Point(142, 376)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(151, 20)
        Me.txtArchivo.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 378)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Nombre del Archivo:"
        '
        'frmBuscarImagen
        '
        Me.ClientSize = New System.Drawing.Size(529, 443)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbImg2)
        Me.Controls.Add(Me.lbImg)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.pbxImg)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarImagen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecionar Imagen"
        CType(Me.pbxImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents pbxImg As System.Windows.Forms.PictureBox
    Friend WithEvents dlgFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbImg As System.Windows.Forms.Label
    Friend WithEvents lbImg2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
