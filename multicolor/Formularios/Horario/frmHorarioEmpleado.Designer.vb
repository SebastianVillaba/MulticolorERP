<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorarioEmpleado
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtHoraMarcada = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPersnal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdSalida = New System.Windows.Forms.RadioButton()
        Me.rdEntrada = New System.Windows.Forms.RadioButton()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHora)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(70, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(539, 130)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha y Hora del Servidor"
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.Bisque
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Location = New System.Drawing.Point(43, 69)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(416, 49)
        Me.txtHora.TabIndex = 1
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblFecha.Location = New System.Drawing.Point(17, 22)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(126, 39)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Label1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPass)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtUsuario)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(73, 140)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 109)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.ForeColor = System.Drawing.Color.Firebrick
        Me.txtPass.Location = New System.Drawing.Point(129, 62)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(210, 31)
        Me.txtPass.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Contraseña:"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.Color.Firebrick
        Me.txtUsuario.Location = New System.Drawing.Point(127, 20)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(212, 31)
        Me.txtUsuario.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtHoraMarcada)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtCargo)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtPersnal)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(82, 255)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(514, 153)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'txtHoraMarcada
        '
        Me.txtHoraMarcada.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.txtHoraMarcada.Enabled = False
        Me.txtHoraMarcada.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraMarcada.ForeColor = System.Drawing.Color.Firebrick
        Me.txtHoraMarcada.Location = New System.Drawing.Point(186, 105)
        Me.txtHoraMarcada.Name = "txtHoraMarcada"
        Me.txtHoraMarcada.Size = New System.Drawing.Size(289, 31)
        Me.txtHoraMarcada.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 24)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Horario Marcado:"
        '
        'txtCargo
        '
        Me.txtCargo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtCargo.Enabled = False
        Me.txtCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargo.ForeColor = System.Drawing.Color.Firebrick
        Me.txtCargo.Location = New System.Drawing.Point(103, 62)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(382, 31)
        Me.txtCargo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cargo:"
        '
        'txtPersnal
        '
        Me.txtPersnal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtPersnal.Enabled = False
        Me.txtPersnal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersnal.ForeColor = System.Drawing.Color.Firebrick
        Me.txtPersnal.Location = New System.Drawing.Point(101, 20)
        Me.txtPersnal.Name = "txtPersnal"
        Me.txtPersnal.Size = New System.Drawing.Size(384, 31)
        Me.txtPersnal.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 24)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Personal:"
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdSalida)
        Me.grOrdenar.Controls.Add(Me.rdEntrada)
        Me.grOrdenar.Location = New System.Drawing.Point(441, 141)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(164, 84)
        Me.grOrdenar.TabIndex = 19
        Me.grOrdenar.TabStop = False
        '
        'rdSalida
        '
        Me.rdSalida.AutoSize = True
        Me.rdSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSalida.Location = New System.Drawing.Point(8, 48)
        Me.rdSalida.Name = "rdSalida"
        Me.rdSalida.Size = New System.Drawing.Size(110, 29)
        Me.rdSalida.TabIndex = 18
        Me.rdSalida.Text = "SALIDA"
        Me.rdSalida.UseVisualStyleBackColor = True
        '
        'rdEntrada
        '
        Me.rdEntrada.AutoSize = True
        Me.rdEntrada.Checked = True
        Me.rdEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdEntrada.Location = New System.Drawing.Point(8, 13)
        Me.rdEntrada.Name = "rdEntrada"
        Me.rdEntrada.Size = New System.Drawing.Size(137, 29)
        Me.rdEntrada.TabIndex = 17
        Me.rdEntrada.TabStop = True
        Me.rdEntrada.Text = "ENTRADA"
        Me.rdEntrada.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Interval = 5000
        '
        'frmHorarioEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 420)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHorarioEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcación del Horario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHoraMarcada As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPersnal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdSalida As System.Windows.Forms.RadioButton
    Friend WithEvents rdEntrada As System.Windows.Forms.RadioButton
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
