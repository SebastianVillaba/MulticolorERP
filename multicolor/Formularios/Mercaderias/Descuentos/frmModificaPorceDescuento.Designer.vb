<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificaPorceDescuento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificaPorceDescuento))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCredito = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdDet = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContado = New System.Windows.Forms.TextBox()
        Me.txtLaboratorio = New System.Windows.Forms.TextBox()
        Me.txtIdLab = New System.Windows.Forms.TextBox()
        Me.txtNro = New System.Windows.Forms.TextBox()
        Me.txtChequeDife = New System.Windows.Forms.TextBox()
        Me.txtDebito = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtChequeDife)
        Me.GroupBox1.Controls.Add(Me.txtDebito)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTarjeta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCredito)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtIdDet)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtContado)
        Me.GroupBox1.Controls.Add(Me.txtLaboratorio)
        Me.GroupBox1.Controls.Add(Me.txtIdLab)
        Me.GroupBox1.Controls.Add(Me.txtNro)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(721, 147)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(190, 80)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 17)
        Me.Label7.TabIndex = 268
        Me.Label7.Text = "Tarjeta"
        '
        'txtTarjeta
        '
        Me.txtTarjeta.BackColor = System.Drawing.Color.Yellow
        Me.txtTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjeta.Location = New System.Drawing.Point(179, 102)
        Me.txtTarjeta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTarjeta.MaxLength = 60
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Size = New System.Drawing.Size(73, 26)
        Me.txtTarjeta.TabIndex = 267
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 80)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 264
        Me.Label2.Text = "Credito"
        '
        'txtCredito
        '
        Me.txtCredito.BackColor = System.Drawing.Color.LightPink
        Me.txtCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCredito.Location = New System.Drawing.Point(88, 102)
        Me.txtCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCredito.MaxLength = 60
        Me.txtCredito.Name = "txtCredito"
        Me.txtCredito.Size = New System.Drawing.Size(73, 26)
        Me.txtCredito.TabIndex = 263
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(75, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Id Det"
        '
        'txtIdDet
        '
        Me.txtIdDet.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdDet.Location = New System.Drawing.Point(67, 35)
        Me.txtIdDet.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdDet.MaxLength = 60
        Me.txtIdDet.Name = "txtIdDet"
        Me.txtIdDet.ReadOnly = True
        Me.txtIdDet.Size = New System.Drawing.Size(76, 26)
        Me.txtIdDet.TabIndex = 261
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(466, 85)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(88, 46)
        Me.btnAgregar.TabIndex = 21
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 79)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 17)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "Contado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(386, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "Laboratorio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 17)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Id Lab."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 17)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Nro"
        '
        'txtContado
        '
        Me.txtContado.BackColor = System.Drawing.Color.Lime
        Me.txtContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContado.Location = New System.Drawing.Point(9, 101)
        Me.txtContado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContado.MaxLength = 60
        Me.txtContado.Name = "txtContado"
        Me.txtContado.Size = New System.Drawing.Size(64, 26)
        Me.txtContado.TabIndex = 102
        '
        'txtLaboratorio
        '
        Me.txtLaboratorio.BackColor = System.Drawing.Color.LightBlue
        Me.txtLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaboratorio.Location = New System.Drawing.Point(247, 34)
        Me.txtLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLaboratorio.MaxLength = 60
        Me.txtLaboratorio.Name = "txtLaboratorio"
        Me.txtLaboratorio.ReadOnly = True
        Me.txtLaboratorio.Size = New System.Drawing.Size(374, 26)
        Me.txtLaboratorio.TabIndex = 99
        '
        'txtIdLab
        '
        Me.txtIdLab.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdLab.Location = New System.Drawing.Point(157, 34)
        Me.txtIdLab.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdLab.MaxLength = 60
        Me.txtIdLab.Name = "txtIdLab"
        Me.txtIdLab.ReadOnly = True
        Me.txtIdLab.Size = New System.Drawing.Size(72, 26)
        Me.txtIdLab.TabIndex = 97
        '
        'txtNro
        '
        Me.txtNro.BackColor = System.Drawing.Color.LightBlue
        Me.txtNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNro.Location = New System.Drawing.Point(7, 34)
        Me.txtNro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNro.MaxLength = 60
        Me.txtNro.Name = "txtNro"
        Me.txtNro.ReadOnly = True
        Me.txtNro.Size = New System.Drawing.Size(52, 26)
        Me.txtNro.TabIndex = 95
        '
        'txtChequeDife
        '
        Me.txtChequeDife.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.txtChequeDife.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChequeDife.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeDife.Location = New System.Drawing.Point(365, 104)
        Me.txtChequeDife.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChequeDife.Name = "txtChequeDife"
        Me.txtChequeDife.Size = New System.Drawing.Size(65, 27)
        Me.txtChequeDife.TabIndex = 270
        '
        'txtDebito
        '
        Me.txtDebito.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtDebito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebito.Location = New System.Drawing.Point(272, 101)
        Me.txtDebito.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDebito.Name = "txtDebito"
        Me.txtDebito.Size = New System.Drawing.Size(65, 27)
        Me.txtDebito.TabIndex = 269
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(283, 79)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Debito"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(351, 81)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 17)
        Me.Label9.TabIndex = 272
        Me.Label9.Text = "Cheq. Deb."
        '
        'frmModificaPorceDescuento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 190)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModificaPorceDescuento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Porcentaje"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdDet As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContado As System.Windows.Forms.TextBox
    Friend WithEvents txtLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents txtIdLab As System.Windows.Forms.TextBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChequeDife As System.Windows.Forms.TextBox
    Friend WithEvents txtDebito As System.Windows.Forms.TextBox
End Class
