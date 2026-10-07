<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoNick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoNick))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btIngresar = New System.Windows.Forms.Button()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.lblIp = New System.Windows.Forms.Label()
        Me.lblSerialHd = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdMiPc = New System.Windows.Forms.RadioButton()
        Me.rdInternet = New System.Windows.Forms.RadioButton()
        Me.rdVpn = New System.Windows.Forms.RadioButton()
        Me.rdLan = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(437, 76)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 41)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "&Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btIngresar
        '
        Me.btIngresar.BackColor = System.Drawing.Color.Gainsboro
        Me.btIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btIngresar.Image = CType(resources.GetObject("btIngresar.Image"), System.Drawing.Image)
        Me.btIngresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btIngresar.Location = New System.Drawing.Point(443, 16)
        Me.btIngresar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btIngresar.Name = "btIngresar"
        Me.btIngresar.Size = New System.Drawing.Size(101, 41)
        Me.btIngresar.TabIndex = 4
        Me.btIngresar.Text = "&Ingresar"
        Me.btIngresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btIngresar.UseVisualStyleBackColor = True
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.BackColor = System.Drawing.Color.Transparent
        Me.lblHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHost.ForeColor = System.Drawing.Color.Lime
        Me.lblHost.Location = New System.Drawing.Point(5, 5)
        Me.lblHost.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(86, 29)
        Me.lblHost.TabIndex = 6
        Me.lblHost.Text = "Label3"
        '
        'lblIp
        '
        Me.lblIp.AutoSize = True
        Me.lblIp.BackColor = System.Drawing.Color.Transparent
        Me.lblIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIp.ForeColor = System.Drawing.Color.Lime
        Me.lblIp.Location = New System.Drawing.Point(3, 4)
        Me.lblIp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIp.Name = "lblIp"
        Me.lblIp.Size = New System.Drawing.Size(86, 29)
        Me.lblIp.TabIndex = 7
        Me.lblIp.Text = "Label3"
        Me.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSerialHd
        '
        Me.lblSerialHd.AutoSize = True
        Me.lblSerialHd.BackColor = System.Drawing.Color.Transparent
        Me.lblSerialHd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialHd.ForeColor = System.Drawing.Color.Lime
        Me.lblSerialHd.Location = New System.Drawing.Point(7, 9)
        Me.lblSerialHd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSerialHd.Name = "lblSerialHd"
        Me.lblSerialHd.Size = New System.Drawing.Size(59, 20)
        Me.lblSerialHd.TabIndex = 8
        Me.lblSerialHd.Text = "Label3"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.GroupBox3.Controls.Add(Me.rdMiPc)
        Me.GroupBox3.Controls.Add(Me.rdInternet)
        Me.GroupBox3.Controls.Add(Me.rdVpn)
        Me.GroupBox3.Controls.Add(Me.rdLan)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox3.Location = New System.Drawing.Point(488, 156)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(439, 58)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Forma de Ingresar"
        '
        'rdMiPc
        '
        Me.rdMiPc.AutoSize = True
        Me.rdMiPc.ForeColor = System.Drawing.Color.Blue
        Me.rdMiPc.Location = New System.Drawing.Point(11, 21)
        Me.rdMiPc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdMiPc.Name = "rdMiPc"
        Me.rdMiPc.Size = New System.Drawing.Size(82, 29)
        Me.rdMiPc.TabIndex = 20
        Me.rdMiPc.Text = "Mi Pc"
        Me.rdMiPc.UseVisualStyleBackColor = True
        '
        'rdInternet
        '
        Me.rdInternet.AutoSize = True
        Me.rdInternet.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.rdInternet.ForeColor = System.Drawing.Color.Blue
        Me.rdInternet.Location = New System.Drawing.Point(308, 22)
        Me.rdInternet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdInternet.Name = "rdInternet"
        Me.rdInternet.Size = New System.Drawing.Size(98, 29)
        Me.rdInternet.TabIndex = 19
        Me.rdInternet.Text = "Internet"
        Me.rdInternet.UseVisualStyleBackColor = False
        '
        'rdVpn
        '
        Me.rdVpn.AutoSize = True
        Me.rdVpn.Checked = True
        Me.rdVpn.ForeColor = System.Drawing.Color.Blue
        Me.rdVpn.Location = New System.Drawing.Point(213, 21)
        Me.rdVpn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdVpn.Name = "rdVpn"
        Me.rdVpn.Size = New System.Drawing.Size(74, 29)
        Me.rdVpn.TabIndex = 18
        Me.rdVpn.TabStop = True
        Me.rdVpn.Text = "VPN"
        Me.rdVpn.UseVisualStyleBackColor = True
        '
        'rdLan
        '
        Me.rdLan.AutoSize = True
        Me.rdLan.ForeColor = System.Drawing.Color.Blue
        Me.rdLan.Location = New System.Drawing.Point(117, 21)
        Me.rdLan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdLan.Name = "rdLan"
        Me.rdLan.Size = New System.Drawing.Size(72, 29)
        Me.rdLan.TabIndex = 17
        Me.rdLan.Text = "LAN"
        Me.rdLan.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btIngresar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPass)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Location = New System.Drawing.Point(487, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(552, 134)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 27)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Contraseña :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 27)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Nick :"
        '
        'txtPass
        '
        Me.txtPass.BackColor = System.Drawing.Color.White
        Me.txtPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.ForeColor = System.Drawing.Color.Black
        Me.txtPass.Location = New System.Drawing.Point(171, 76)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(88)
        Me.txtPass.Size = New System.Drawing.Size(240, 34)
        Me.txtPass.TabIndex = 23
        '
        'txtUsuario
        '
        Me.txtUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtUsuario.BackColor = System.Drawing.Color.White
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.Black
        Me.txtUsuario.Location = New System.Drawing.Point(172, 21)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(240, 34)
        Me.txtUsuario.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(16, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Nombre PC"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblHost)
        Me.Panel1.Location = New System.Drawing.Point(15, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(464, 37)
        Me.Panel1.TabIndex = 26
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblIp)
        Me.Panel2.Location = New System.Drawing.Point(17, 95)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(461, 38)
        Me.Panel2.TabIndex = 27
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblSerialHd)
        Me.Panel3.Location = New System.Drawing.Point(17, 161)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(461, 36)
        Me.Panel3.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(20, 71)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 24)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "ID PC"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(17, 137)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 24)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Serial HD"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 220)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(355, 173)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 16)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(324, 149)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(391, 224)
        Me.PictureBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(620, 201)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 33
        Me.PictureBox7.TabStop = False
        '
        'frmIngresoNick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1063, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresoNick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btIngresar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents lblIp As System.Windows.Forms.Label
    Friend WithEvents lblSerialHd As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdInternet As System.Windows.Forms.RadioButton
    Friend WithEvents rdVpn As System.Windows.Forms.RadioButton
    Friend WithEvents rdLan As System.Windows.Forms.RadioButton
    Friend WithEvents rdMiPc As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox

End Class
