<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarDepositoMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarDepositoMercaderia))
        Me.txtNombreDeposito = New System.Windows.Forms.TextBox()
        Me.txtIdDeposito = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lvDeposito = New System.Windows.Forms.ListView()
        Me.txtNombreSucursal = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreDeposito
        '
        Me.txtNombreDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreDeposito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreDeposito.Enabled = False
        Me.txtNombreDeposito.Location = New System.Drawing.Point(88, 459)
        Me.txtNombreDeposito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreDeposito.Name = "txtNombreDeposito"
        Me.txtNombreDeposito.Size = New System.Drawing.Size(303, 22)
        Me.txtNombreDeposito.TabIndex = 29
        '
        'txtIdDeposito
        '
        Me.txtIdDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdDeposito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdDeposito.Enabled = False
        Me.txtIdDeposito.Location = New System.Drawing.Point(13, 459)
        Me.txtIdDeposito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdDeposito.Name = "txtIdDeposito"
        Me.txtIdDeposito.Size = New System.Drawing.Size(65, 22)
        Me.txtIdDeposito.TabIndex = 28
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(100, 18)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(337, 22)
        Me.txtBuscar.TabIndex = 26
        '
        'lvDeposito
        '
        Me.lvDeposito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvDeposito.FullRowSelect = True
        Me.lvDeposito.GridLines = True
        Me.lvDeposito.HideSelection = False
        Me.lvDeposito.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvDeposito.LabelWrap = False
        Me.lvDeposito.Location = New System.Drawing.Point(13, 49)
        Me.lvDeposito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvDeposito.MultiSelect = False
        Me.lvDeposito.Name = "lvDeposito"
        Me.lvDeposito.Size = New System.Drawing.Size(690, 391)
        Me.lvDeposito.TabIndex = 27
        Me.lvDeposito.UseCompatibleStateImageBehavior = False
        Me.lvDeposito.View = System.Windows.Forms.View.Details
        '
        'txtNombreSucursal
        '
        Me.txtNombreSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreSucursal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreSucursal.Enabled = False
        Me.txtNombreSucursal.Location = New System.Drawing.Point(400, 459)
        Me.txtNombreSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreSucursal.Name = "txtNombreSucursal"
        Me.txtNombreSucursal.Size = New System.Drawing.Size(303, 22)
        Me.txtNombreSucursal.TabIndex = 30
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(25, 5)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'frmBuscarDepositoMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 503)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtNombreSucursal)
        Me.Controls.Add(Me.txtNombreDeposito)
        Me.Controls.Add(Me.txtIdDeposito)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.lvDeposito)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarDepositoMercaderia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Deposito Sucursal"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreDeposito As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDeposito As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lvDeposito As System.Windows.Forms.ListView
    Friend WithEvents txtNombreSucursal As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
