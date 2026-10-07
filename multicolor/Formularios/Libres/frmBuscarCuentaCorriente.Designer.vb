<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarCuentaCorriente
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
        Me.txtNombreBanco = New System.Windows.Forms.TextBox()
        Me.txtIdCuenta = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvCuenta = New System.Windows.Forms.ListView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreBanco
        '
        Me.txtNombreBanco.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreBanco.Enabled = False
        Me.txtNombreBanco.Location = New System.Drawing.Point(70, 374)
        Me.txtNombreBanco.Name = "txtNombreBanco"
        Me.txtNombreBanco.Size = New System.Drawing.Size(247, 20)
        Me.txtNombreBanco.TabIndex = 29
        '
        'txtIdCuenta
        '
        Me.txtIdCuenta.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdCuenta.Enabled = False
        Me.txtIdCuenta.Location = New System.Drawing.Point(14, 374)
        Me.txtIdCuenta.Name = "txtIdCuenta"
        Me.txtIdCuenta.Size = New System.Drawing.Size(50, 20)
        Me.txtIdCuenta.TabIndex = 28
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(79, 16)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(254, 20)
        Me.txtBuscar.TabIndex = 26
        '
        'PictureBox1
        '
        'Me.PictureBox1.Image = Global.NetJoin.My.Resources.Resources._16__Print_preview_
        Me.PictureBox1.Location = New System.Drawing.Point(32, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'lvCuenta
        '
        Me.lvCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvCuenta.FullRowSelect = True
        Me.lvCuenta.GridLines = True
        Me.lvCuenta.HideSelection = False
        Me.lvCuenta.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCuenta.LabelWrap = False
        Me.lvCuenta.Location = New System.Drawing.Point(14, 41)
        Me.lvCuenta.MultiSelect = False
        Me.lvCuenta.Name = "lvCuenta"
        Me.lvCuenta.Size = New System.Drawing.Size(433, 318)
        Me.lvCuenta.TabIndex = 27
        Me.lvCuenta.UseCompatibleStateImageBehavior = False
        Me.lvCuenta.View = System.Windows.Forms.View.Details
        '
        'frmBuscarCuentaCorriente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 411)
        Me.Controls.Add(Me.txtNombreBanco)
        Me.Controls.Add(Me.txtIdCuenta)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvCuenta)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarCuentaCorriente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Cuenta Corriente"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvCuenta As System.Windows.Forms.ListView
End Class
