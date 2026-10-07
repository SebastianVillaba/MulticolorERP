<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbmDeposito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbmDeposito))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtIdDeposito = New System.Windows.Forms.TextBox()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtNombreDeposito = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.chkCanje = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTipoDeposito = New System.Windows.Forms.ComboBox()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(498, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 16)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "Sucursal :"
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 31)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'txtIdDeposito
        '
        Me.txtIdDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdDeposito.Enabled = False
        Me.txtIdDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdDeposito.Location = New System.Drawing.Point(402, 8)
        Me.txtIdDeposito.MaxLength = 30
        Me.txtIdDeposito.Name = "txtIdDeposito"
        Me.txtIdDeposito.Size = New System.Drawing.Size(57, 22)
        Me.txtIdDeposito.TabIndex = 119
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(640, 380)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaMod.TabIndex = 112
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(640, 359)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 111
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(415, 380)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioMod.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(315, 383)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Último Modificador  :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(329, 362)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Usuario Creador :"
        '
        'lvBuscar
        '
        Me.lvBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(6, 60)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(267, 322)
        Me.lvBuscar.TabIndex = 3
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(8, 10)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(282, 390)
        Me.grBuscar.TabIndex = 105
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'cboSucursal
        '
        Me.cboSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Enabled = False
        Me.cboSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(566, 6)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(284, 24)
        Me.cboSucursal.TabIndex = 121
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(306, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 16)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(334, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "* Datos Obligatorios"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.SystemColors.Control
        Me.chkActivo.Enabled = False
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(384, 155)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 20)
        Me.chkActivo.TabIndex = 116
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'txtNombreDeposito
        '
        Me.txtNombreDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreDeposito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreDeposito.Enabled = False
        Me.txtNombreDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreDeposito.Location = New System.Drawing.Point(463, 98)
        Me.txtNombreDeposito.MaxLength = 150
        Me.txtNombreDeposito.Name = "txtNombreDeposito"
        Me.txtNombreDeposito.Size = New System.Drawing.Size(357, 22)
        Me.txtNombreDeposito.TabIndex = 115
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(315, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 16)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "Nombre del Deposito :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(317, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "ID Deposito :"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(415, 359)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioAlta.TabIndex = 107
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.btnModificar)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(332, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 56)
        Me.GroupBox2.TabIndex = 106
        Me.GroupBox2.TabStop = False
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
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(88, 13)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(69, 37)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(13, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(69, 37)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'chkCanje
        '
        Me.chkCanje.AutoSize = True
        Me.chkCanje.BackColor = System.Drawing.SystemColors.Control
        Me.chkCanje.Enabled = False
        Me.chkCanje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCanje.Location = New System.Drawing.Point(309, 155)
        Me.chkCanje.Name = "chkCanje"
        Me.chkCanje.Size = New System.Drawing.Size(62, 20)
        Me.chkCanje.TabIndex = 122
        Me.chkCanje.Text = "Canje"
        Me.chkCanje.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(316, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 16)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "Tipo :"
        '
        'cboTipoDeposito
        '
        Me.cboTipoDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDeposito.Enabled = False
        Me.cboTipoDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDeposito.FormattingEnabled = True
        Me.cboTipoDeposito.Location = New System.Drawing.Point(358, 52)
        Me.cboTipoDeposito.Name = "cboTipoDeposito"
        Me.cboTipoDeposito.Size = New System.Drawing.Size(209, 24)
        Me.cboTipoDeposito.TabIndex = 124
        '
        'frmAbmDeposito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 418)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboTipoDeposito)
        Me.Controls.Add(Me.chkCanje)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtIdDeposito)
        Me.Controls.Add(Me.txtFechaMod)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grBuscar)
        Me.Controls.Add(Me.cboSucursal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtNombreDeposito)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbmDeposito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Deposito"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtIdDeposito As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombreDeposito As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCanje As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDeposito As System.Windows.Forms.ComboBox
End Class
