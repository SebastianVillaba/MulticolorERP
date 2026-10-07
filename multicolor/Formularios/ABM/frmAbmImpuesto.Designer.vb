<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbmImpuesto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbmImpuesto))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdNombreImpuesto = New System.Windows.Forms.RadioButton()
        Me.rdIdImpuesto = New System.Windows.Forms.RadioButton()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvImpuesto = New System.Windows.Forms.ListView()
        Me.txtIdImpuesto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtNombreImpuesto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPorcentajeImpuesto = New System.Windows.Forms.TextBox()
        Me.txtFactor = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvImpuesto)
        Me.grBuscar.Location = New System.Drawing.Point(16, 10)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grBuscar.Size = New System.Drawing.Size(376, 478)
        Me.grBuscar.TabIndex = 1
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdNombreImpuesto)
        Me.grOrdenar.Controls.Add(Me.rdIdImpuesto)
        Me.grOrdenar.Location = New System.Drawing.Point(85, 14)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Size = New System.Drawing.Size(204, 42)
        Me.grOrdenar.TabIndex = 18
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdNombreImpuesto
        '
        Me.rdNombreImpuesto.AutoSize = True
        Me.rdNombreImpuesto.Checked = True
        Me.rdNombreImpuesto.Location = New System.Drawing.Point(125, 16)
        Me.rdNombreImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdNombreImpuesto.Name = "rdNombreImpuesto"
        Me.rdNombreImpuesto.Size = New System.Drawing.Size(79, 21)
        Me.rdNombreImpuesto.TabIndex = 18
        Me.rdNombreImpuesto.TabStop = True
        Me.rdNombreImpuesto.Text = "Nombre"
        Me.rdNombreImpuesto.UseVisualStyleBackColor = True
        '
        'rdIdImpuesto
        '
        Me.rdIdImpuesto.AutoSize = True
        Me.rdIdImpuesto.Location = New System.Drawing.Point(11, 16)
        Me.rdIdImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdIdImpuesto.Name = "rdIdImpuesto"
        Me.rdIdImpuesto.Size = New System.Drawing.Size(99, 21)
        Me.rdIdImpuesto.TabIndex = 17
        Me.rdIdImpuesto.Text = "IDImpuesto"
        Me.rdIdImpuesto.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(71, 60)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(213, 22)
        Me.txtBuscar.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 48)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lvImpuesto
        '
        Me.lvImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvImpuesto.FullRowSelect = True
        Me.lvImpuesto.GridLines = True
        Me.lvImpuesto.HideSelection = False
        Me.lvImpuesto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvImpuesto.LabelWrap = False
        Me.lvImpuesto.Location = New System.Drawing.Point(8, 96)
        Me.lvImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvImpuesto.MultiSelect = False
        Me.lvImpuesto.Name = "lvImpuesto"
        Me.lvImpuesto.Size = New System.Drawing.Size(355, 376)
        Me.lvImpuesto.TabIndex = 3
        Me.lvImpuesto.UseCompatibleStateImageBehavior = False
        Me.lvImpuesto.View = System.Windows.Forms.View.Details
        '
        'txtIdImpuesto
        '
        Me.txtIdImpuesto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdImpuesto.Enabled = False
        Me.txtIdImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdImpuesto.Location = New System.Drawing.Point(563, 10)
        Me.txtIdImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdImpuesto.MaxLength = 30
        Me.txtIdImpuesto.Name = "txtIdImpuesto"
        Me.txtIdImpuesto.Size = New System.Drawing.Size(75, 26)
        Me.txtIdImpuesto.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(435, 60)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "*"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.SystemColors.Control
        Me.chkActivo.Enabled = False
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(439, 175)
        Me.chkActivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(77, 24)
        Me.chkActivo.TabIndex = 22
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'txtNombreImpuesto
        '
        Me.txtNombreImpuesto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreImpuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreImpuesto.Enabled = False
        Me.txtNombreImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreImpuesto.Location = New System.Drawing.Point(637, 57)
        Me.txtNombreImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombreImpuesto.MaxLength = 30
        Me.txtNombreImpuesto.Name = "txtNombreImpuesto"
        Me.txtNombreImpuesto.Size = New System.Drawing.Size(343, 26)
        Me.txtNombreImpuesto.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(447, 58)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Nombre del Impuesto :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(447, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 20)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "ID Impuesto :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(447, 106)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Porcentaje :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(648, 107)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Factor :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(435, 329)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "* Datos Obligatorios"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSalir)
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.btnModificar)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(515, 373)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(525, 69)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(417, 16)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(92, 46)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(317, 16)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(92, 46)
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
        Me.btnGuardar.Location = New System.Drawing.Point(217, 16)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
        Me.btnGuardar.TabIndex = 23
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(117, 16)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(92, 46)
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
        Me.btnNuevo.Location = New System.Drawing.Point(17, 16)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(92, 46)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(867, 480)
        Me.txtFechaMod.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(188, 22)
        Me.txtFechaMod.TabIndex = 34
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(867, 454)
        Me.txtFechaAlta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(188, 22)
        Me.txtFechaAlta.TabIndex = 33
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(567, 480)
        Me.txtUsuarioMod.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(293, 22)
        Me.txtUsuarioMod.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(433, 484)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 17)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Último Modificador  :"
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(567, 454)
        Me.txtUsuarioAlta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(293, 22)
        Me.txtUsuarioAlta.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(452, 458)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Usuario Creador :"
        '
        'txtPorcentajeImpuesto
        '
        Me.txtPorcentajeImpuesto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtPorcentajeImpuesto.Enabled = False
        Me.txtPorcentajeImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentajeImpuesto.Location = New System.Drawing.Point(556, 102)
        Me.txtPorcentajeImpuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPorcentajeImpuesto.MaxLength = 30
        Me.txtPorcentajeImpuesto.Name = "txtPorcentajeImpuesto"
        Me.txtPorcentajeImpuesto.Size = New System.Drawing.Size(75, 26)
        Me.txtPorcentajeImpuesto.TabIndex = 20
        '
        'txtFactor
        '
        Me.txtFactor.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtFactor.Enabled = False
        Me.txtFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactor.Location = New System.Drawing.Point(720, 102)
        Me.txtFactor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFactor.MaxLength = 30
        Me.txtFactor.Name = "txtFactor"
        Me.txtFactor.Size = New System.Drawing.Size(79, 26)
        Me.txtFactor.TabIndex = 21
        '
        'frmAbmImpuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 516)
        Me.Controls.Add(Me.txtFactor)
        Me.Controls.Add(Me.txtPorcentajeImpuesto)
        Me.Controls.Add(Me.txtFechaMod)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIdImpuesto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtNombreImpuesto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmAbmImpuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Impuesto"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdNombreImpuesto As System.Windows.Forms.RadioButton
    Friend WithEvents rdIdImpuesto As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvImpuesto As System.Windows.Forms.ListView
    Friend WithEvents txtIdImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombreImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtFactor As System.Windows.Forms.TextBox
End Class
