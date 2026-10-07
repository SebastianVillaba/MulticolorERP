<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbmPc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbmPc))
        Me.txtIdConfig = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.rdNombre = New System.Windows.Forms.RadioButton()
        Me.rdIdConfig = New System.Windows.Forms.RadioButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lv = New System.Windows.Forms.ListView()
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboContable = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIdPc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkVenta = New System.Windows.Forms.CheckBox()
        Me.chkDepositoVenta = New System.Windows.Forms.CheckBox()
        Me.cboDeposito = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.chkHorario = New System.Windows.Forms.CheckBox()
        Me.cboDepositoRemision = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSerialHd = New System.Windows.Forms.TextBox()
        Me.txtNombreImpresora = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkPrincipal = New System.Windows.Forms.CheckBox()
        Me.chkDobleImpresion = New System.Windows.Forms.CheckBox()
        Me.chkQr = New System.Windows.Forms.CheckBox()
        Me.btnBuscarFacturaDE = New System.Windows.Forms.Button()
        Me.txtIdDetFacturaFac = New System.Windows.Forms.TextBox()
        Me.txtFacturaFac = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnBuscarNcrDE = New System.Windows.Forms.Button()
        Me.txtIdNcrDE = New System.Windows.Forms.TextBox()
        Me.txtNcrDE = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIdConfig
        '
        Me.txtIdConfig.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdConfig.Enabled = False
        Me.txtIdConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdConfig.Location = New System.Drawing.Point(512, 9)
        Me.txtIdConfig.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdConfig.MaxLength = 30
        Me.txtIdConfig.Name = "txtIdConfig"
        Me.txtIdConfig.Size = New System.Drawing.Size(75, 26)
        Me.txtIdConfig.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(597, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 20)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(892, 562)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "* Datos Obligatorios"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.SystemColors.Control
        Me.chkActivo.Enabled = False
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(972, 167)
        Me.chkActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(77, 24)
        Me.chkActivo.TabIndex = 28
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(775, 11)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombre.MaxLength = 30
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(265, 26)
        Me.txtNombre.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(609, 12)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Nombre de la PC :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(421, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "ID Config :"
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(552, 604)
        Me.txtUsuarioAlta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(293, 22)
        Me.txtUsuarioAlta.TabIndex = 19
        '
        'rdNombre
        '
        Me.rdNombre.AutoSize = True
        Me.rdNombre.Checked = True
        Me.rdNombre.Location = New System.Drawing.Point(108, 16)
        Me.rdNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.rdNombre.Name = "rdNombre"
        Me.rdNombre.Size = New System.Drawing.Size(79, 21)
        Me.rdNombre.TabIndex = 18
        Me.rdNombre.TabStop = True
        Me.rdNombre.Text = "Nombre"
        Me.rdNombre.UseVisualStyleBackColor = True
        '
        'rdIdConfig
        '
        Me.rdIdConfig.AutoSize = True
        Me.rdIdConfig.Location = New System.Drawing.Point(19, 16)
        Me.rdIdConfig.Margin = New System.Windows.Forms.Padding(4)
        Me.rdIdConfig.Name = "rdIdConfig"
        Me.rdIdConfig.Size = New System.Drawing.Size(82, 21)
        Me.rdIdConfig.TabIndex = 17
        Me.rdIdConfig.Text = "IDConfig"
        Me.rdIdConfig.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.btnModificar)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(441, 524)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(443, 69)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(325, 16)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnGuardar.Location = New System.Drawing.Point(225, 16)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
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
        Me.btnModificar.Location = New System.Drawing.Point(125, 16)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnNuevo.Location = New System.Drawing.Point(25, 16)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(92, 46)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdNombre)
        Me.grOrdenar.Controls.Add(Me.rdIdConfig)
        Me.grOrdenar.Location = New System.Drawing.Point(93, 14)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Size = New System.Drawing.Size(204, 42)
        Me.grOrdenar.TabIndex = 18
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(852, 630)
        Me.txtFechaMod.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(188, 22)
        Me.txtFechaMod.TabIndex = 24
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(852, 604)
        Me.txtFechaAlta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(188, 22)
        Me.txtFechaAlta.TabIndex = 23
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(79, 60)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(213, 22)
        Me.txtBuscar.TabIndex = 2
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(552, 630)
        Me.txtUsuarioMod.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(293, 22)
        Me.txtUsuarioMod.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(419, 634)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Último Modificador  :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(437, 608)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Usuario Creador :"
        '
        'lv
        '
        Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lv.FullRowSelect = True
        Me.lv.GridLines = True
        Me.lv.HideSelection = False
        Me.lv.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lv.LabelWrap = False
        Me.lv.Location = New System.Drawing.Point(16, 96)
        Me.lv.Margin = New System.Windows.Forms.Padding(4)
        Me.lv.MultiSelect = False
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(355, 502)
        Me.lv.TabIndex = 3
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lv)
        Me.grBuscar.Location = New System.Drawing.Point(9, 15)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Size = New System.Drawing.Size(384, 606)
        Me.grBuscar.TabIndex = 17
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 48)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 37)
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
        Me.cboSucursal.Location = New System.Drawing.Point(511, 48)
        Me.cboSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(304, 28)
        Me.cboSucursal.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(421, 50)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Sucursal:"
        '
        'cboContable
        '
        Me.cboContable.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContable.Enabled = False
        Me.cboContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboContable.FormattingEnabled = True
        Me.cboContable.Location = New System.Drawing.Point(972, 50)
        Me.cboContable.Margin = New System.Windows.Forms.Padding(4)
        Me.cboContable.Name = "cboContable"
        Me.cboContable.Size = New System.Drawing.Size(304, 28)
        Me.cboContable.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(836, 53)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 20)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Emp. Contable:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(425, 131)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 20)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "*"
        '
        'txtIdPc
        '
        Me.txtIdPc.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdPc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPc.Enabled = False
        Me.txtIdPc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPc.Location = New System.Drawing.Point(499, 128)
        Me.txtIdPc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdPc.MaxLength = 30
        Me.txtIdPc.Name = "txtIdPc"
        Me.txtIdPc.Size = New System.Drawing.Size(400, 26)
        Me.txtIdPc.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(437, 129)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 20)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "ID Pc :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(425, 168)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 20)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(437, 166)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 20)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Serial HD :"
        '
        'chkVenta
        '
        Me.chkVenta.AutoSize = True
        Me.chkVenta.BackColor = System.Drawing.SystemColors.Control
        Me.chkVenta.Enabled = False
        Me.chkVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVenta.Location = New System.Drawing.Point(441, 203)
        Me.chkVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.chkVenta.Name = "chkVenta"
        Me.chkVenta.Size = New System.Drawing.Size(140, 24)
        Me.chkVenta.TabIndex = 58
        Me.chkVenta.Text = "Activar Ventas"
        Me.chkVenta.UseVisualStyleBackColor = False
        '
        'chkDepositoVenta
        '
        Me.chkDepositoVenta.AutoSize = True
        Me.chkDepositoVenta.BackColor = System.Drawing.SystemColors.Control
        Me.chkDepositoVenta.Enabled = False
        Me.chkDepositoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDepositoVenta.Location = New System.Drawing.Point(441, 235)
        Me.chkDepositoVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDepositoVenta.Name = "chkDepositoVenta"
        Me.chkDepositoVenta.Size = New System.Drawing.Size(235, 24)
        Me.chkDepositoVenta.TabIndex = 59
        Me.chkDepositoVenta.Text = "Activar Deposito en Ventas"
        Me.chkDepositoVenta.UseVisualStyleBackColor = False
        '
        'cboDeposito
        '
        Me.cboDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeposito.Enabled = False
        Me.cboDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDeposito.FormattingEnabled = True
        Me.cboDeposito.Location = New System.Drawing.Point(804, 233)
        Me.cboDeposito.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDeposito.Name = "cboDeposito"
        Me.cboDeposito.Size = New System.Drawing.Size(304, 28)
        Me.cboDeposito.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(715, 237)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 20)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "Deposito:"
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(25, 634)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSql.MaxLength = 30
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(1092, 26)
        Me.txtSql.TabIndex = 62
        Me.txtSql.Visible = False
        '
        'chkHorario
        '
        Me.chkHorario.AutoSize = True
        Me.chkHorario.BackColor = System.Drawing.SystemColors.Control
        Me.chkHorario.Enabled = False
        Me.chkHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHorario.Location = New System.Drawing.Point(600, 203)
        Me.chkHorario.Margin = New System.Windows.Forms.Padding(4)
        Me.chkHorario.Name = "chkHorario"
        Me.chkHorario.Size = New System.Drawing.Size(144, 24)
        Me.chkHorario.TabIndex = 63
        Me.chkHorario.Text = "Activar Horario"
        Me.chkHorario.UseVisualStyleBackColor = False
        '
        'cboDepositoRemision
        '
        Me.cboDepositoRemision.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboDepositoRemision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepositoRemision.Enabled = False
        Me.cboDepositoRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepositoRemision.FormattingEnabled = True
        Me.cboDepositoRemision.Location = New System.Drawing.Point(657, 275)
        Me.cboDepositoRemision.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDepositoRemision.Name = "cboDepositoRemision"
        Me.cboDepositoRemision.Size = New System.Drawing.Size(304, 28)
        Me.cboDepositoRemision.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(437, 279)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(197, 20)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "Deposito de la Remision:"
        '
        'txtSerialHd
        '
        Me.txtSerialHd.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtSerialHd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialHd.Enabled = False
        Me.txtSerialHd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialHd.Location = New System.Drawing.Point(541, 162)
        Me.txtSerialHd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSerialHd.MaxLength = 100
        Me.txtSerialHd.Name = "txtSerialHd"
        Me.txtSerialHd.Size = New System.Drawing.Size(400, 26)
        Me.txtSerialHd.TabIndex = 6
        '
        'txtNombreImpresora
        '
        Me.txtNombreImpresora.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreImpresora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreImpresora.Enabled = False
        Me.txtNombreImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreImpresora.Location = New System.Drawing.Point(607, 88)
        Me.txtNombreImpresora.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreImpresora.MaxLength = 30
        Me.txtNombreImpresora.Name = "txtNombreImpresora"
        Me.txtNombreImpresora.Size = New System.Drawing.Size(465, 26)
        Me.txtNombreImpresora.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(435, 89)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(158, 20)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "Nombre Impresora :"
        '
        'chkPrincipal
        '
        Me.chkPrincipal.AutoSize = True
        Me.chkPrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.chkPrincipal.Enabled = False
        Me.chkPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrincipal.Location = New System.Drawing.Point(768, 201)
        Me.chkPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPrincipal.Name = "chkPrincipal"
        Me.chkPrincipal.Size = New System.Drawing.Size(96, 24)
        Me.chkPrincipal.TabIndex = 72
        Me.chkPrincipal.Text = "Principal"
        Me.chkPrincipal.UseVisualStyleBackColor = False
        '
        'chkDobleImpresion
        '
        Me.chkDobleImpresion.AutoSize = True
        Me.chkDobleImpresion.BackColor = System.Drawing.SystemColors.Control
        Me.chkDobleImpresion.Enabled = False
        Me.chkDobleImpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDobleImpresion.Location = New System.Drawing.Point(896, 201)
        Me.chkDobleImpresion.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDobleImpresion.Name = "chkDobleImpresion"
        Me.chkDobleImpresion.Size = New System.Drawing.Size(153, 24)
        Me.chkDobleImpresion.TabIndex = 79
        Me.chkDobleImpresion.Text = "Doble Impresión"
        Me.chkDobleImpresion.UseVisualStyleBackColor = False
        '
        'chkQr
        '
        Me.chkQr.AutoSize = True
        Me.chkQr.BackColor = System.Drawing.SystemColors.Control
        Me.chkQr.Enabled = False
        Me.chkQr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkQr.Location = New System.Drawing.Point(1068, 167)
        Me.chkQr.Margin = New System.Windows.Forms.Padding(4)
        Me.chkQr.Name = "chkQr"
        Me.chkQr.Size = New System.Drawing.Size(208, 24)
        Me.chkQr.TabIndex = 80
        Me.chkQr.Text = "Imprimir con codigo QR"
        Me.chkQr.UseVisualStyleBackColor = False
        '
        'btnBuscarFacturaDE
        '
        Me.btnBuscarFacturaDE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarFacturaDE.Enabled = False
        Me.btnBuscarFacturaDE.Image = CType(resources.GetObject("btnBuscarFacturaDE.Image"), System.Drawing.Image)
        Me.btnBuscarFacturaDE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarFacturaDE.Location = New System.Drawing.Point(1058, 314)
        Me.btnBuscarFacturaDE.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscarFacturaDE.Name = "btnBuscarFacturaDE"
        Me.btnBuscarFacturaDE.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscarFacturaDE.TabIndex = 81
        Me.btnBuscarFacturaDE.Text = "&Buscar"
        Me.btnBuscarFacturaDE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarFacturaDE.UseVisualStyleBackColor = True
        '
        'txtIdDetFacturaFac
        '
        Me.txtIdDetFacturaFac.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdDetFacturaFac.Enabled = False
        Me.txtIdDetFacturaFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdDetFacturaFac.Location = New System.Drawing.Point(546, 330)
        Me.txtIdDetFacturaFac.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdDetFacturaFac.MaxLength = 30
        Me.txtIdDetFacturaFac.Name = "txtIdDetFacturaFac"
        Me.txtIdDetFacturaFac.Size = New System.Drawing.Size(75, 26)
        Me.txtIdDetFacturaFac.TabIndex = 84
        '
        'txtFacturaFac
        '
        Me.txtFacturaFac.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtFacturaFac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFacturaFac.Enabled = False
        Me.txtFacturaFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacturaFac.Location = New System.Drawing.Point(634, 330)
        Me.txtFacturaFac.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacturaFac.MaxLength = 30
        Me.txtFacturaFac.Name = "txtFacturaFac"
        Me.txtFacturaFac.Size = New System.Drawing.Size(417, 26)
        Me.txtFacturaFac.TabIndex = 82
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(428, 333)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Factura DE:"
        '
        'btnBuscarNcrDE
        '
        Me.btnBuscarNcrDE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarNcrDE.Enabled = False
        Me.btnBuscarNcrDE.Image = CType(resources.GetObject("btnBuscarNcrDE.Image"), System.Drawing.Image)
        Me.btnBuscarNcrDE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarNcrDE.Location = New System.Drawing.Point(1086, 369)
        Me.btnBuscarNcrDE.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscarNcrDE.Name = "btnBuscarNcrDE"
        Me.btnBuscarNcrDE.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscarNcrDE.TabIndex = 85
        Me.btnBuscarNcrDE.Text = "&Buscar"
        Me.btnBuscarNcrDE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarNcrDE.UseVisualStyleBackColor = True
        '
        'txtIdNcrDE
        '
        Me.txtIdNcrDE.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdNcrDE.Enabled = False
        Me.txtIdNcrDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdNcrDE.Location = New System.Drawing.Point(574, 385)
        Me.txtIdNcrDE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdNcrDE.MaxLength = 30
        Me.txtIdNcrDE.Name = "txtIdNcrDE"
        Me.txtIdNcrDE.Size = New System.Drawing.Size(75, 26)
        Me.txtIdNcrDE.TabIndex = 88
        '
        'txtNcrDE
        '
        Me.txtNcrDE.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNcrDE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNcrDE.Enabled = False
        Me.txtNcrDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNcrDE.Location = New System.Drawing.Point(662, 385)
        Me.txtNcrDE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNcrDE.MaxLength = 30
        Me.txtNcrDE.Name = "txtNcrDE"
        Me.txtNcrDE.Size = New System.Drawing.Size(417, 26)
        Me.txtNcrDE.TabIndex = 86
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(428, 388)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(123, 20)
        Me.Label19.TabIndex = 87
        Me.Label19.Text = "Nota Cred. DE:"
        '
        'frmAbmPc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1296, 679)
        Me.Controls.Add(Me.btnBuscarNcrDE)
        Me.Controls.Add(Me.txtIdNcrDE)
        Me.Controls.Add(Me.txtNcrDE)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.btnBuscarFacturaDE)
        Me.Controls.Add(Me.txtIdDetFacturaFac)
        Me.Controls.Add(Me.txtFacturaFac)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.chkQr)
        Me.Controls.Add(Me.chkDobleImpresion)
        Me.Controls.Add(Me.chkPrincipal)
        Me.Controls.Add(Me.txtNombreImpresora)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSerialHd)
        Me.Controls.Add(Me.cboDepositoRemision)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.chkHorario)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.cboDeposito)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chkDepositoVenta)
        Me.Controls.Add(Me.chkVenta)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtIdPc)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboContable)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboSucursal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtIdConfig)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtFechaMod)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbmPc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Pc"
        Me.GroupBox2.ResumeLayout(False)
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdConfig As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents rdNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rdIdConfig As System.Windows.Forms.RadioButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboContable As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIdPc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkVenta As System.Windows.Forms.CheckBox
    Friend WithEvents chkDepositoVenta As System.Windows.Forms.CheckBox
    Friend WithEvents cboDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents chkHorario As System.Windows.Forms.CheckBox
    Friend WithEvents cboDepositoRemision As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSerialHd As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreImpresora As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkPrincipal As System.Windows.Forms.CheckBox
    Friend WithEvents chkDobleImpresion As System.Windows.Forms.CheckBox
    Friend WithEvents chkQr As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarFacturaDE As System.Windows.Forms.Button
    Friend WithEvents txtIdDetFacturaFac As System.Windows.Forms.TextBox
    Friend WithEvents txtFacturaFac As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarNcrDE As System.Windows.Forms.Button
    Friend WithEvents txtIdNcrDE As System.Windows.Forms.TextBox
    Friend WithEvents txtNcrDE As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
