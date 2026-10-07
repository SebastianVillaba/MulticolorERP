<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbmTipoProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbmTipoProducto))
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkHabilitarDecimal = New System.Windows.Forms.CheckBox()
        Me.chkComision = New System.Windows.Forms.CheckBox()
        Me.chkPorcentajeCompra = New System.Windows.Forms.CheckBox()
        Me.chkVence = New System.Windows.Forms.CheckBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvTipoProducto = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdTipoProducto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.grTipo = New System.Windows.Forms.GroupBox()
        Me.txtBuscarTipo = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lvTipo = New System.Windows.Forms.ListView()
        Me.txtIdTipo = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grBuscar.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grTipo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkHabilitarDecimal)
        Me.GroupBox2.Controls.Add(Me.chkComision)
        Me.GroupBox2.Controls.Add(Me.chkPorcentajeCompra)
        Me.GroupBox2.Controls.Add(Me.chkVence)
        Me.GroupBox2.Location = New System.Drawing.Point(322, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 133)
        Me.GroupBox2.TabIndex = 144
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'chkHabilitarDecimal
        '
        Me.chkHabilitarDecimal.AutoSize = True
        Me.chkHabilitarDecimal.BackColor = System.Drawing.SystemColors.Control
        Me.chkHabilitarDecimal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkHabilitarDecimal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkHabilitarDecimal.Enabled = False
        Me.chkHabilitarDecimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHabilitarDecimal.Location = New System.Drawing.Point(6, 104)
        Me.chkHabilitarDecimal.Name = "chkHabilitarDecimal"
        Me.chkHabilitarDecimal.Size = New System.Drawing.Size(130, 20)
        Me.chkHabilitarDecimal.TabIndex = 21
        Me.chkHabilitarDecimal.Text = "Habilitar Decimal"
        Me.chkHabilitarDecimal.UseVisualStyleBackColor = False
        '
        'chkComision
        '
        Me.chkComision.AutoSize = True
        Me.chkComision.BackColor = System.Drawing.SystemColors.Control
        Me.chkComision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkComision.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkComision.Enabled = False
        Me.chkComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkComision.Location = New System.Drawing.Point(6, 78)
        Me.chkComision.Name = "chkComision"
        Me.chkComision.Size = New System.Drawing.Size(110, 20)
        Me.chkComision.TabIndex = 20
        Me.chkComision.Text = "Con Comisión"
        Me.chkComision.UseVisualStyleBackColor = False
        '
        'chkPorcentajeCompra
        '
        Me.chkPorcentajeCompra.AutoSize = True
        Me.chkPorcentajeCompra.BackColor = System.Drawing.SystemColors.Control
        Me.chkPorcentajeCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkPorcentajeCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkPorcentajeCompra.Enabled = False
        Me.chkPorcentajeCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPorcentajeCompra.Location = New System.Drawing.Point(6, 52)
        Me.chkPorcentajeCompra.Name = "chkPorcentajeCompra"
        Me.chkPorcentajeCompra.Size = New System.Drawing.Size(181, 20)
        Me.chkPorcentajeCompra.TabIndex = 19
        Me.chkPorcentajeCompra.Text = "Porcentaje Costo Compra"
        Me.chkPorcentajeCompra.UseVisualStyleBackColor = False
        '
        'chkVence
        '
        Me.chkVence.AutoSize = True
        Me.chkVence.BackColor = System.Drawing.SystemColors.Control
        Me.chkVence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkVence.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVence.Enabled = False
        Me.chkVence.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVence.Location = New System.Drawing.Point(6, 26)
        Me.chkVence.Name = "chkVence"
        Me.chkVence.Size = New System.Drawing.Size(142, 20)
        Me.chkVence.TabIndex = 15
        Me.chkVence.Text = "Anular Vencimiento"
        Me.chkVence.UseVisualStyleBackColor = False
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.SystemColors.Control
        Me.chkActivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkActivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkActivo.Enabled = False
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(790, 36)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 20)
        Me.chkActivo.TabIndex = 20
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombre-Presentacion"
        Me.ColumnHeader3.Width = 250
        '
        'lvTipoProducto
        '
        Me.lvTipoProducto.AllowColumnReorder = True
        Me.lvTipoProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvTipoProducto.FullRowSelect = True
        Me.lvTipoProducto.GridLines = True
        Me.lvTipoProducto.HideSelection = False
        Me.lvTipoProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvTipoProducto.LabelWrap = False
        Me.lvTipoProducto.Location = New System.Drawing.Point(6, 57)
        Me.lvTipoProducto.MultiSelect = False
        Me.lvTipoProducto.Name = "lvTipoProducto"
        Me.lvTipoProducto.Size = New System.Drawing.Size(297, 440)
        Me.lvTipoProducto.TabIndex = 3
        Me.lvTipoProducto.UseCompatibleStateImageBehavior = False
        Me.lvTipoProducto.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Codigo"
        Me.ColumnHeader2.Width = 50
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 28)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(202, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(389, 36)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(373, 22)
        Me.txtNombre.TabIndex = 134
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(330, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Nombre:"
        '
        'txtIdTipoProducto
        '
        Me.txtIdTipoProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdTipoProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdTipoProducto.Enabled = False
        Me.txtIdTipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTipoProducto.Location = New System.Drawing.Point(424, 7)
        Me.txtIdTipoProducto.MaxLength = 10
        Me.txtIdTipoProducto.Name = "txtIdTipoProducto"
        Me.txtIdTipoProducto.Size = New System.Drawing.Size(66, 22)
        Me.txtIdTipoProducto.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(330, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "ID Tipo Prod. :"
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvTipoProducto)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(7, 9)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(309, 512)
        Me.grBuscar.TabIndex = 131
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(647, 449)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 150
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(422, 470)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioMod.TabIndex = 149
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(322, 473)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 13)
        Me.Label19.TabIndex = 148
        Me.Label19.Text = "Último Modificador  :"
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
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(422, 449)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioAlta.TabIndex = 146
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(313, 13)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(336, 452)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 147
        Me.Label20.Text = "Usuario Creador :"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnImprimir)
        Me.GroupBox7.Controls.Add(Me.btnCancelar)
        Me.GroupBox7.Controls.Add(Me.btnGuardar)
        Me.GroupBox7.Controls.Add(Me.btnModificar)
        Me.GroupBox7.Controls.Add(Me.btnNuevo)
        Me.GroupBox7.Location = New System.Drawing.Point(328, 389)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(416, 56)
        Me.GroupBox7.TabIndex = 145
        Me.GroupBox7.TabStop = False
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
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(647, 470)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaMod.TabIndex = 151
        '
        'grTipo
        '
        Me.grTipo.Controls.Add(Me.txtBuscarTipo)
        Me.grTipo.Controls.Add(Me.PictureBox2)
        Me.grTipo.Controls.Add(Me.lvTipo)
        Me.grTipo.Location = New System.Drawing.Point(13, 3)
        Me.grTipo.Name = "grTipo"
        Me.grTipo.Size = New System.Drawing.Size(280, 450)
        Me.grTipo.TabIndex = 154
        Me.grTipo.TabStop = False
        Me.grTipo.Text = "Búsqueda"
        Me.grTipo.Visible = False
        '
        'txtBuscarTipo
        '
        Me.txtBuscarTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarTipo.Location = New System.Drawing.Point(53, 49)
        Me.txtBuscarTipo.Name = "txtBuscarTipo"
        Me.txtBuscarTipo.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscarTipo.TabIndex = 2
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(6, 39)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'lvTipo
        '
        Me.lvTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvTipo.FullRowSelect = True
        Me.lvTipo.GridLines = True
        Me.lvTipo.HideSelection = False
        Me.lvTipo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvTipo.LabelWrap = False
        Me.lvTipo.Location = New System.Drawing.Point(6, 78)
        Me.lvTipo.MultiSelect = False
        Me.lvTipo.Name = "lvTipo"
        Me.lvTipo.Size = New System.Drawing.Size(267, 366)
        Me.lvTipo.TabIndex = 3
        Me.lvTipo.UseCompatibleStateImageBehavior = False
        Me.lvTipo.View = System.Windows.Forms.View.Details
        '
        'txtIdTipo
        '
        Me.txtIdTipo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdTipo.Enabled = False
        Me.txtIdTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTipo.Location = New System.Drawing.Point(505, 7)
        Me.txtIdTipo.MaxLength = 10
        Me.txtIdTipo.Name = "txtIdTipo"
        Me.txtIdTipo.Size = New System.Drawing.Size(55, 22)
        Me.txtIdTipo.TabIndex = 82
        '
        'frmAbmTipoProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 517)
        Me.Controls.Add(Me.txtIdTipo)
        Me.Controls.Add(Me.grTipo)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIdTipoProducto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grBuscar)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.txtFechaMod)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbmTipoProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Tipo Producto"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.grTipo.ResumeLayout(False)
        Me.grTipo.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkComision As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorcentajeCompra As System.Windows.Forms.CheckBox
    Friend WithEvents chkVence As System.Windows.Forms.CheckBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipoProducto As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents grTipo As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdTipo As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscarTipo As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lvTipo As System.Windows.Forms.ListView
    Friend WithEvents chkHabilitarDecimal As System.Windows.Forms.CheckBox
End Class
