<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCerrarArqueo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCerrarArqueo))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtIdPersonal = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvPersonal = New System.Windows.Forms.ListView()
        Me.lvPersonalCaja = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtIdPersonalCaja = New System.Windows.Forms.TextBox()
        Me.txtMovFin2 = New System.Windows.Forms.TextBox()
        Me.txtMovini2 = New System.Windows.Forms.TextBox()
        Me.txtMoviFin1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMovini1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalArqueo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtIdPersonal)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvPersonal)
        Me.grBuscar.Location = New System.Drawing.Point(12, 12)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(430, 422)
        Me.grBuscar.TabIndex = 1
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtIdPersonal
        '
        Me.txtIdPersonal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdPersonal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPersonal.Enabled = False
        Me.txtIdPersonal.Location = New System.Drawing.Point(220, 30)
        Me.txtIdPersonal.Name = "txtIdPersonal"
        Me.txtIdPersonal.Size = New System.Drawing.Size(57, 20)
        Me.txtIdPersonal.TabIndex = 19
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 30)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lvPersonal
        '
        Me.lvPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvPersonal.FullRowSelect = True
        Me.lvPersonal.GridLines = True
        Me.lvPersonal.HideSelection = False
        Me.lvPersonal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvPersonal.LabelWrap = False
        Me.lvPersonal.Location = New System.Drawing.Point(6, 60)
        Me.lvPersonal.MultiSelect = False
        Me.lvPersonal.Name = "lvPersonal"
        Me.lvPersonal.Size = New System.Drawing.Size(405, 348)
        Me.lvPersonal.TabIndex = 3
        Me.lvPersonal.UseCompatibleStateImageBehavior = False
        Me.lvPersonal.View = System.Windows.Forms.View.Details
        '
        'lvPersonalCaja
        '
        Me.lvPersonalCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvPersonalCaja.FullRowSelect = True
        Me.lvPersonalCaja.GridLines = True
        Me.lvPersonalCaja.HideSelection = False
        Me.lvPersonalCaja.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvPersonalCaja.LabelWrap = False
        Me.lvPersonalCaja.Location = New System.Drawing.Point(448, 23)
        Me.lvPersonalCaja.MultiSelect = False
        Me.lvPersonalCaja.Name = "lvPersonalCaja"
        Me.lvPersonalCaja.Size = New System.Drawing.Size(405, 164)
        Me.lvPersonalCaja.TabIndex = 4
        Me.lvPersonalCaja.UseCompatibleStateImageBehavior = False
        Me.lvPersonalCaja.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Location = New System.Drawing.Point(448, 217)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 56)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(162, 13)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 4
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(87, 13)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(13, 13)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 37)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtIdPersonalCaja
        '
        Me.txtIdPersonalCaja.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdPersonalCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPersonalCaja.Enabled = False
        Me.txtIdPersonalCaja.Location = New System.Drawing.Point(448, 193)
        Me.txtIdPersonalCaja.Name = "txtIdPersonalCaja"
        Me.txtIdPersonalCaja.Size = New System.Drawing.Size(57, 20)
        Me.txtIdPersonalCaja.TabIndex = 20
        '
        'txtMovFin2
        '
        Me.txtMovFin2.BackColor = System.Drawing.Color.LightBlue
        Me.txtMovFin2.Enabled = False
        Me.txtMovFin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovFin2.Location = New System.Drawing.Point(611, 350)
        Me.txtMovFin2.MaxLength = 60
        Me.txtMovFin2.Name = "txtMovFin2"
        Me.txtMovFin2.Size = New System.Drawing.Size(80, 22)
        Me.txtMovFin2.TabIndex = 80
        '
        'txtMovini2
        '
        Me.txtMovini2.BackColor = System.Drawing.Color.LightBlue
        Me.txtMovini2.Enabled = False
        Me.txtMovini2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovini2.Location = New System.Drawing.Point(610, 327)
        Me.txtMovini2.MaxLength = 60
        Me.txtMovini2.Name = "txtMovini2"
        Me.txtMovini2.Size = New System.Drawing.Size(80, 22)
        Me.txtMovini2.TabIndex = 79
        '
        'txtMoviFin1
        '
        Me.txtMoviFin1.BackColor = System.Drawing.Color.LightBlue
        Me.txtMoviFin1.Enabled = False
        Me.txtMoviFin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoviFin1.Location = New System.Drawing.Point(524, 351)
        Me.txtMoviFin1.MaxLength = 60
        Me.txtMoviFin1.Name = "txtMoviFin1"
        Me.txtMoviFin1.Size = New System.Drawing.Size(80, 22)
        Me.txtMoviFin1.TabIndex = 78
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(448, 353)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Mov. Final:"
        '
        'txtMovini1
        '
        Me.txtMovini1.BackColor = System.Drawing.Color.LightBlue
        Me.txtMovini1.Enabled = False
        Me.txtMovini1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovini1.Location = New System.Drawing.Point(524, 328)
        Me.txtMovini1.MaxLength = 60
        Me.txtMovini1.Name = "txtMovini1"
        Me.txtMovini1.Size = New System.Drawing.Size(80, 22)
        Me.txtMovini1.TabIndex = 76
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(446, 330)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 16)
        Me.Label14.TabIndex = 75
        Me.Label14.Text = "Mov. Inicial:"
        '
        'txtTotalArqueo
        '
        Me.txtTotalArqueo.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalArqueo.Enabled = False
        Me.txtTotalArqueo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalArqueo.Location = New System.Drawing.Point(508, 290)
        Me.txtTotalArqueo.MaxLength = 60
        Me.txtTotalArqueo.Name = "txtTotalArqueo"
        Me.txtTotalArqueo.Size = New System.Drawing.Size(119, 22)
        Me.txtTotalArqueo.TabIndex = 74
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(452, 294)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 16)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "TOTAL:"
        '
        'frmCerrarArqueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 437)
        Me.Controls.Add(Me.txtMovFin2)
        Me.Controls.Add(Me.txtMovini2)
        Me.Controls.Add(Me.txtMoviFin1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMovini1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTotalArqueo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtIdPersonalCaja)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lvPersonalCaja)
        Me.Controls.Add(Me.grBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCerrarArqueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardar Arqueo"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvPersonal As System.Windows.Forms.ListView
    Friend WithEvents lvPersonalCaja As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtIdPersonal As System.Windows.Forms.TextBox
    Friend WithEvents txtIdPersonalCaja As System.Windows.Forms.TextBox
    Friend WithEvents txtMovFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMovini2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMoviFin1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMovini1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalArqueo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
