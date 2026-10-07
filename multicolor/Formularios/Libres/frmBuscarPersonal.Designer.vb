<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarPersonalEmpresa
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
        Me.txtNombrePersonal = New System.Windows.Forms.TextBox()
        Me.txtIdPersonal = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lvPersonal = New System.Windows.Forms.ListView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtIdCuenta = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombrePersonal
        '
        Me.txtNombrePersonal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombrePersonal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombrePersonal.Enabled = False
        Me.txtNombrePersonal.Location = New System.Drawing.Point(70, 465)
        Me.txtNombrePersonal.Name = "txtNombrePersonal"
        Me.txtNombrePersonal.Size = New System.Drawing.Size(247, 20)
        Me.txtNombrePersonal.TabIndex = 34
        '
        'txtIdPersonal
        '
        Me.txtIdPersonal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdPersonal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPersonal.Enabled = False
        Me.txtIdPersonal.Location = New System.Drawing.Point(14, 465)
        Me.txtIdPersonal.Name = "txtIdPersonal"
        Me.txtIdPersonal.Size = New System.Drawing.Size(50, 20)
        Me.txtIdPersonal.TabIndex = 33
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(79, 22)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(254, 20)
        Me.txtBuscar.TabIndex = 31
        '
        'lvPersonal
        '
        Me.lvPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvPersonal.FullRowSelect = True
        Me.lvPersonal.GridLines = True
        Me.lvPersonal.HideSelection = False
        Me.lvPersonal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvPersonal.LabelWrap = False
        Me.lvPersonal.Location = New System.Drawing.Point(14, 47)
        Me.lvPersonal.MultiSelect = False
        Me.lvPersonal.Name = "lvPersonal"
        Me.lvPersonal.Size = New System.Drawing.Size(491, 406)
        Me.lvPersonal.TabIndex = 32
        Me.lvPersonal.UseCompatibleStateImageBehavior = False
        Me.lvPersonal.View = System.Windows.Forms.View.Details
        '
        'PictureBox1
        '
        'Me.PictureBox1.Image = Global.NetJoin.My.Resources.Resources._16__Print_preview_
        Me.PictureBox1.Location = New System.Drawing.Point(32, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'txtIdCuenta
        '
        Me.txtIdCuenta.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdCuenta.Enabled = False
        Me.txtIdCuenta.Location = New System.Drawing.Point(14, 465)
        Me.txtIdCuenta.Name = "txtIdCuenta"
        Me.txtIdCuenta.Size = New System.Drawing.Size(50, 20)
        Me.txtIdCuenta.TabIndex = 33
        '
        'frmBuscarPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 495)
        Me.Controls.Add(Me.txtNombrePersonal)
        Me.Controls.Add(Me.txtIdPersonal)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvPersonal)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarPersonal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Personal de la Empresa"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombrePersonal As System.Windows.Forms.TextBox
    Friend WithEvents txtIdPersonal As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvPersonal As System.Windows.Forms.ListView
    Friend WithEvents txtIdCuenta As System.Windows.Forms.TextBox
End Class
