<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigEmail))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grUsuarios = New System.Windows.Forms.GroupBox()
        Me.lblIdConfigEmail = New System.Windows.Forms.Label()
        Me.lvDetCorreo = New System.Windows.Forms.ListView()
        Me.detEmal_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detEmail_idConfigEmail = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detEmail_idUsuario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detEmail_Usuario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detEmail_email = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblIdUsuario = New System.Windows.Forms.Label()
        Me.lblNro = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.lblNombreProceso = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblIdTipoProceso = New System.Windows.Forms.Label()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grUsuarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
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
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(651, 445)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 129
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(8, 10)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(282, 390)
        Me.grBuscar.TabIndex = 123
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 31)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 2
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 448)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Usuario Creador :"
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(426, 445)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioAlta.TabIndex = 125
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.btnModificar)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(343, 383)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 56)
        Me.GroupBox2.TabIndex = 124
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
        Me.btnGuardar.TabIndex = 0
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
        'grUsuarios
        '
        Me.grUsuarios.Controls.Add(Me.lblIdConfigEmail)
        Me.grUsuarios.Controls.Add(Me.lvDetCorreo)
        Me.grUsuarios.Controls.Add(Me.lblIdUsuario)
        Me.grUsuarios.Controls.Add(Me.lblNro)
        Me.grUsuarios.Controls.Add(Me.btnEliminar)
        Me.grUsuarios.Controls.Add(Me.btnAgregar)
        Me.grUsuarios.Location = New System.Drawing.Point(299, 9)
        Me.grUsuarios.Name = "grUsuarios"
        Me.grUsuarios.Size = New System.Drawing.Size(712, 365)
        Me.grUsuarios.TabIndex = 143
        Me.grUsuarios.TabStop = False
        Me.grUsuarios.Text = "Usuarios"
        '
        'lblIdConfigEmail
        '
        Me.lblIdConfigEmail.AutoSize = True
        Me.lblIdConfigEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdConfigEmail.ForeColor = System.Drawing.Color.Maroon
        Me.lblIdConfigEmail.Location = New System.Drawing.Point(633, 164)
        Me.lblIdConfigEmail.Name = "lblIdConfigEmail"
        Me.lblIdConfigEmail.Size = New System.Drawing.Size(91, 16)
        Me.lblIdConfigEmail.TabIndex = 71
        Me.lblIdConfigEmail.Text = "idConfigEmail"
        '
        'lvDetCorreo
        '
        Me.lvDetCorreo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detEmal_nro, Me.detEmail_idConfigEmail, Me.detEmail_idUsuario, Me.detEmail_Usuario, Me.detEmail_email})
        Me.lvDetCorreo.Location = New System.Drawing.Point(7, 19)
        Me.lvDetCorreo.Name = "lvDetCorreo"
        Me.lvDetCorreo.Size = New System.Drawing.Size(620, 340)
        Me.lvDetCorreo.TabIndex = 70
        Me.lvDetCorreo.UseCompatibleStateImageBehavior = False
        Me.lvDetCorreo.View = System.Windows.Forms.View.Details
        '
        'detEmal_nro
        '
        Me.detEmal_nro.Text = "Nro"
        Me.detEmal_nro.Width = 40
        '
        'detEmail_idConfigEmail
        '
        Me.detEmail_idConfigEmail.Text = "IdConf."
        Me.detEmail_idConfigEmail.Width = 50
        '
        'detEmail_idUsuario
        '
        Me.detEmail_idUsuario.Text = "idUsu."
        Me.detEmail_idUsuario.Width = 50
        '
        'detEmail_Usuario
        '
        Me.detEmail_Usuario.Text = "Usuario"
        Me.detEmail_Usuario.Width = 250
        '
        'detEmail_email
        '
        Me.detEmail_email.Text = "email"
        Me.detEmail_email.Width = 250
        '
        'lblIdUsuario
        '
        Me.lblIdUsuario.AutoSize = True
        Me.lblIdUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdUsuario.ForeColor = System.Drawing.Color.Maroon
        Me.lblIdUsuario.Location = New System.Drawing.Point(635, 139)
        Me.lblIdUsuario.Name = "lblIdUsuario"
        Me.lblIdUsuario.Size = New System.Drawing.Size(66, 16)
        Me.lblIdUsuario.TabIndex = 69
        Me.lblIdUsuario.Text = "idUsuario"
        '
        'lblNro
        '
        Me.lblNro.AutoSize = True
        Me.lblNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNro.ForeColor = System.Drawing.Color.Maroon
        Me.lblNro.Location = New System.Drawing.Point(635, 119)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(30, 16)
        Me.lblNro.TabIndex = 68
        Me.lblNro.Text = "Nro"
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(634, 62)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 4
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(634, 19)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 37)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(0, 471)
        Me.txtSql.MaxLength = 800
        Me.txtSql.Multiline = True
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(911, 48)
        Me.txtSql.TabIndex = 144
        Me.txtSql.Visible = False
        '
        'lblNombreProceso
        '
        Me.lblNombreProceso.AutoSize = True
        Me.lblNombreProceso.BackColor = System.Drawing.Color.Lime
        Me.lblNombreProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProceso.ForeColor = System.Drawing.Color.Black
        Me.lblNombreProceso.Location = New System.Drawing.Point(113, 434)
        Me.lblNombreProceso.Name = "lblNombreProceso"
        Me.lblNombreProceso.Size = New System.Drawing.Size(105, 16)
        Me.lblNombreProceso.TabIndex = 148
        Me.lblNombreProceso.Text = "nombreProceso"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 434)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Nombre Proc.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 406)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Id Tipo Proc.:"
        '
        'lblIdTipoProceso
        '
        Me.lblIdTipoProceso.AutoSize = True
        Me.lblIdTipoProceso.BackColor = System.Drawing.Color.Lime
        Me.lblIdTipoProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdTipoProceso.ForeColor = System.Drawing.Color.Black
        Me.lblIdTipoProceso.Location = New System.Drawing.Point(113, 406)
        Me.lblIdTipoProceso.Name = "lblIdTipoProceso"
        Me.lblIdTipoProceso.Size = New System.Drawing.Size(98, 16)
        Me.lblIdTipoProceso.TabIndex = 145
        Me.lblIdTipoProceso.Text = "idTipoProceso"
        '
        'frmConfigEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 531)
        Me.Controls.Add(Me.lblNombreProceso)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblIdTipoProceso)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.grUsuarios)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.grBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de Envío de Email"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.grUsuarios.ResumeLayout(False)
        Me.grUsuarios.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblNro As System.Windows.Forms.Label
    Friend WithEvents lblIdUsuario As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents lvDetCorreo As System.Windows.Forms.ListView
    Friend WithEvents detEmail_idConfigEmail As System.Windows.Forms.ColumnHeader
    Friend WithEvents detEmail_idUsuario As System.Windows.Forms.ColumnHeader
    Friend WithEvents detEmail_Usuario As System.Windows.Forms.ColumnHeader
    Friend WithEvents detEmail_email As System.Windows.Forms.ColumnHeader
    Friend WithEvents detEmal_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblIdConfigEmail As System.Windows.Forms.Label
    Friend WithEvents lblNombreProceso As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblIdTipoProceso As System.Windows.Forms.Label
End Class
