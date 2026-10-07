<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPassUsuario))
        Me.txtNick = New System.Windows.Forms.TextBox()
        Me.txtCodigoBarra = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnImprimirCodigoBarra = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCodBar = New System.Windows.Forms.Button()
        Me.btnPass = New System.Windows.Forms.Button()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtPass1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPass2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodigoBarraNro = New System.Windows.Forms.TextBox()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNick
        '
        Me.txtNick.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNick.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNick.Enabled = False
        Me.txtNick.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNick.Location = New System.Drawing.Point(60, 74)
        Me.txtNick.MaxLength = 60
        Me.txtNick.Name = "txtNick"
        Me.txtNick.Size = New System.Drawing.Size(182, 22)
        Me.txtNick.TabIndex = 3
        '
        'txtCodigoBarra
        '
        Me.txtCodigoBarra.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtCodigoBarra.Enabled = False
        Me.txtCodigoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarra.Location = New System.Drawing.Point(337, 74)
        Me.txtCodigoBarra.MaxLength = 1
        Me.txtCodigoBarra.Name = "txtCodigoBarra"
        Me.txtCodigoBarra.Size = New System.Drawing.Size(182, 22)
        Me.txtCodigoBarra.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(248, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 136
        Me.Label12.Text = "CodigoBarra:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 16)
        Me.Label6.TabIndex = 134
        Me.Label6.Text = "Nick:"
        '
        'txtApellido
        '
        Me.txtApellido.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido.Enabled = False
        Me.txtApellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellido.Location = New System.Drawing.Point(429, 46)
        Me.txtApellido.MaxLength = 60
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(245, 22)
        Me.txtApellido.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(365, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Apellido:"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(80, 46)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(285, 22)
        Me.txtNombre.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Nombre:"
        '
        'txtIdUsuario
        '
        Me.txtIdUsuario.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdUsuario.Enabled = False
        Me.txtIdUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdUsuario.Location = New System.Drawing.Point(105, 17)
        Me.txtIdUsuario.MaxLength = 10
        Me.txtIdUsuario.Name = "txtIdUsuario"
        Me.txtIdUsuario.Size = New System.Drawing.Size(66, 22)
        Me.txtIdUsuario.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "ID Usuario :"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnImprimirCodigoBarra)
        Me.GroupBox7.Controls.Add(Me.btnCancelar)
        Me.GroupBox7.Controls.Add(Me.btnGuardar)
        Me.GroupBox7.Controls.Add(Me.btnCodBar)
        Me.GroupBox7.Controls.Add(Me.btnPass)
        Me.GroupBox7.Location = New System.Drawing.Point(147, 152)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(398, 56)
        Me.GroupBox7.TabIndex = 138
        Me.GroupBox7.TabStop = False
        '
        'btnImprimirCodigoBarra
        '
        Me.btnImprimirCodigoBarra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimirCodigoBarra.Image = CType(resources.GetObject("btnImprimirCodigoBarra.Image"), System.Drawing.Image)
        Me.btnImprimirCodigoBarra.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimirCodigoBarra.Location = New System.Drawing.Point(313, 13)
        Me.btnImprimirCodigoBarra.Name = "btnImprimirCodigoBarra"
        Me.btnImprimirCodigoBarra.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimirCodigoBarra.TabIndex = 4
        Me.btnImprimirCodigoBarra.Text = "&Imprimir"
        Me.btnImprimirCodigoBarra.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirCodigoBarra.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(238, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(69, 37)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(163, 13)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCodBar
        '
        Me.btnCodBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCodBar.Image = CType(resources.GetObject("btnCodBar.Image"), System.Drawing.Image)
        Me.btnCodBar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCodBar.Location = New System.Drawing.Point(88, 13)
        Me.btnCodBar.Name = "btnCodBar"
        Me.btnCodBar.Size = New System.Drawing.Size(69, 37)
        Me.btnCodBar.TabIndex = 1
        Me.btnCodBar.Text = "C&od. Barra"
        Me.btnCodBar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCodBar.UseVisualStyleBackColor = True
        '
        'btnPass
        '
        Me.btnPass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPass.Image = CType(resources.GetObject("btnPass.Image"), System.Drawing.Image)
        Me.btnPass.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPass.Location = New System.Drawing.Point(13, 13)
        Me.btnPass.Name = "btnPass"
        Me.btnPass.Size = New System.Drawing.Size(69, 37)
        Me.btnPass.TabIndex = 0
        Me.btnPass.Text = "&Password"
        Me.btnPass.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPass.UseVisualStyleBackColor = True
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(332, 218)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 143
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(107, 239)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioMod.TabIndex = 142
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 242)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 13)
        Me.Label19.TabIndex = 141
        Me.Label19.Text = "Último Modificador  :"
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(107, 218)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioAlta.TabIndex = 139
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(21, 221)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 140
        Me.Label20.Text = "Usuario Creador :"
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(332, 239)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaMod.TabIndex = 144
        '
        'txtPass1
        '
        Me.txtPass1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtPass1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPass1.Enabled = False
        Me.txtPass1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass1.Location = New System.Drawing.Point(100, 102)
        Me.txtPass1.MaxLength = 10
        Me.txtPass1.Name = "txtPass1"
        Me.txtPass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass1.Size = New System.Drawing.Size(182, 22)
        Me.txtPass1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "Contraseña:"
        '
        'txtPass2
        '
        Me.txtPass2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtPass2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPass2.Enabled = False
        Me.txtPass2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass2.Location = New System.Drawing.Point(415, 102)
        Me.txtPass2.MaxLength = 10
        Me.txtPass2.Name = "txtPass2"
        Me.txtPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass2.Size = New System.Drawing.Size(182, 22)
        Me.txtPass2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(289, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 16)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Nueva Contraseña:"
        '
        'txtGrupo
        '
        Me.txtGrupo.BackColor = System.Drawing.Color.MistyRose
        Me.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGrupo.Enabled = False
        Me.txtGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupo.Location = New System.Drawing.Point(251, 16)
        Me.txtGrupo.MaxLength = 60
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(245, 22)
        Me.txtGrupo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(202, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Grupo:"
        '
        'txtCodigoBarraNro
        '
        Me.txtCodigoBarraNro.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtCodigoBarraNro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoBarraNro.Enabled = False
        Me.txtCodigoBarraNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarraNro.Location = New System.Drawing.Point(525, 73)
        Me.txtCodigoBarraNro.MaxLength = 1
        Me.txtCodigoBarraNro.Name = "txtCodigoBarraNro"
        Me.txtCodigoBarraNro.Size = New System.Drawing.Size(182, 22)
        Me.txtCodigoBarraNro.TabIndex = 151
        '
        'frmPassUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 271)
        Me.Controls.Add(Me.txtCodigoBarraNro)
        Me.Controls.Add(Me.txtGrupo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPass2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPass1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtFechaMod)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.txtNick)
        Me.Controls.Add(Me.txtCodigoBarra)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtApellido)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIdUsuario)
        Me.Controls.Add(Me.Label3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPassUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Contraseñas"
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNick As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCodBar As System.Windows.Forms.Button
    Friend WithEvents btnPass As System.Windows.Forms.Button
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtPass1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPass2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirCodigoBarra As System.Windows.Forms.Button
    Friend WithEvents txtCodigoBarraNro As System.Windows.Forms.TextBox
End Class
