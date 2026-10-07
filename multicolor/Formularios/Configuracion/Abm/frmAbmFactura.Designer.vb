<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbmFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbmFactura))
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtIdFactura = New System.Windows.Forms.TextBox()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvFormulario = New System.Windows.Forms.ListView()
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNroFactura = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNroFacturaSgte = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTimbrado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.maskFechaCaduca = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grTipoFactura = New System.Windows.Forms.GroupBox()
        Me.txtCantidadLinea = New System.Windows.Forms.TextBox()
        Me.chkPreImpreso = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grTipoFactura.SuspendLayout()
        Me.SuspendLayout()
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(475, 10)
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
        'txtIdFactura
        '
        Me.txtIdFactura.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdFactura.Enabled = False
        Me.txtIdFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdFactura.Location = New System.Drawing.Point(395, 8)
        Me.txtIdFactura.MaxLength = 30
        Me.txtIdFactura.Name = "txtIdFactura"
        Me.txtIdFactura.Size = New System.Drawing.Size(57, 22)
        Me.txtIdFactura.TabIndex = 0
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(641, 380)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaMod.TabIndex = 112
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(641, 359)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 111
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(416, 380)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioMod.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(316, 383)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Último Modificador  :"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(330, 362)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Usuario Creador :"
        '
        'lvFormulario
        '
        Me.lvFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvFormulario.FullRowSelect = True
        Me.lvFormulario.GridLines = True
        Me.lvFormulario.HideSelection = False
        Me.lvFormulario.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvFormulario.LabelWrap = False
        Me.lvFormulario.Location = New System.Drawing.Point(6, 60)
        Me.lvFormulario.MultiSelect = False
        Me.lvFormulario.Name = "lvFormulario"
        Me.lvFormulario.Size = New System.Drawing.Size(267, 322)
        Me.lvFormulario.TabIndex = 3
        Me.lvFormulario.UseCompatibleStateImageBehavior = False
        Me.lvFormulario.View = System.Windows.Forms.View.Details
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvFormulario)
        Me.grBuscar.Location = New System.Drawing.Point(9, 10)
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
        Me.cboSucursal.Location = New System.Drawing.Point(544, 6)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(284, 24)
        Me.cboSucursal.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(307, 47)
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
        Me.Label5.Location = New System.Drawing.Point(335, 258)
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
        Me.chkActivo.Location = New System.Drawing.Point(310, 138)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 20)
        Me.chkActivo.TabIndex = 116
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'txtDsuc
        '
        Me.txtDsuc.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtDsuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDsuc.Enabled = False
        Me.txtDsuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsuc.Location = New System.Drawing.Point(380, 44)
        Me.txtDsuc.MaxLength = 3
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(58, 22)
        Me.txtDsuc.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(316, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "Dig. Suc.:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(318, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "ID Factura :"
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
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(416, 359)
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
        Me.GroupBox2.Location = New System.Drawing.Point(333, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 56)
        Me.GroupBox2.TabIndex = 106
        Me.GroupBox2.TabStop = False
        '
        'txtDcaja
        '
        Me.txtDcaja.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtDcaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDcaja.Enabled = False
        Me.txtDcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcaja.Location = New System.Drawing.Point(508, 45)
        Me.txtDcaja.MaxLength = 3
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(58, 22)
        Me.txtDcaja.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(443, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "Dig. Caja:"
        '
        'txtNroFactura
        '
        Me.txtNroFactura.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNroFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroFactura.Enabled = False
        Me.txtNroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroFactura.Location = New System.Drawing.Point(699, 47)
        Me.txtNroFactura.MaxLength = 7
        Me.txtNroFactura.Name = "txtNroFactura"
        Me.txtNroFactura.Size = New System.Drawing.Size(94, 22)
        Me.txtNroFactura.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(576, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 16)
        Me.Label9.TabIndex = 124
        Me.Label9.Text = "Nro. Factura Inicial:"
        '
        'txtNroFacturaSgte
        '
        Me.txtNroFacturaSgte.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNroFacturaSgte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroFacturaSgte.Enabled = False
        Me.txtNroFacturaSgte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroFacturaSgte.Location = New System.Drawing.Point(430, 73)
        Me.txtNroFacturaSgte.MaxLength = 7
        Me.txtNroFacturaSgte.Name = "txtNroFacturaSgte"
        Me.txtNroFacturaSgte.Size = New System.Drawing.Size(94, 22)
        Me.txtNroFacturaSgte.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(307, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 16)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "Nro. Factura Sgte.:"
        '
        'txtTimbrado
        '
        Me.txtTimbrado.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtTimbrado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTimbrado.Enabled = False
        Me.txtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimbrado.Location = New System.Drawing.Point(608, 71)
        Me.txtTimbrado.MaxLength = 10
        Me.txtTimbrado.Name = "txtTimbrado"
        Me.txtTimbrado.Size = New System.Drawing.Size(139, 22)
        Me.txtTimbrado.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(536, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 16)
        Me.Label11.TabIndex = 128
        Me.Label11.Text = "Timbrado:"
        '
        'maskFechaCaduca
        '
        Me.maskFechaCaduca.BackColor = System.Drawing.Color.LightSkyBlue
        Me.maskFechaCaduca.Enabled = False
        Me.maskFechaCaduca.Location = New System.Drawing.Point(452, 107)
        Me.maskFechaCaduca.Mask = "00/00/0000"
        Me.maskFechaCaduca.Name = "maskFechaCaduca"
        Me.maskFechaCaduca.Size = New System.Drawing.Size(100, 20)
        Me.maskFechaCaduca.TabIndex = 7
        Me.maskFechaCaduca.ValidatingType = GetType(Date)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(307, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 16)
        Me.Label12.TabIndex = 131
        Me.Label12.Text = "Fecha de Caducidad :"
        '
        'grTipoFactura
        '
        Me.grTipoFactura.Controls.Add(Me.txtCantidadLinea)
        Me.grTipoFactura.Controls.Add(Me.chkPreImpreso)
        Me.grTipoFactura.Controls.Add(Me.Label13)
        Me.grTipoFactura.Location = New System.Drawing.Point(578, 107)
        Me.grTipoFactura.Name = "grTipoFactura"
        Me.grTipoFactura.Size = New System.Drawing.Size(200, 61)
        Me.grTipoFactura.TabIndex = 132
        Me.grTipoFactura.TabStop = False
        '
        'txtCantidadLinea
        '
        Me.txtCantidadLinea.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtCantidadLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadLinea.Enabled = False
        Me.txtCantidadLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadLinea.Location = New System.Drawing.Point(114, 30)
        Me.txtCantidadLinea.MaxLength = 3
        Me.txtCantidadLinea.Name = "txtCantidadLinea"
        Me.txtCantidadLinea.Size = New System.Drawing.Size(58, 22)
        Me.txtCantidadLinea.TabIndex = 134
        '
        'chkPreImpreso
        '
        Me.chkPreImpreso.AutoSize = True
        Me.chkPreImpreso.BackColor = System.Drawing.SystemColors.Control
        Me.chkPreImpreso.Enabled = False
        Me.chkPreImpreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPreImpreso.Location = New System.Drawing.Point(10, -2)
        Me.chkPreImpreso.Name = "chkPreImpreso"
        Me.chkPreImpreso.Size = New System.Drawing.Size(145, 20)
        Me.chkPreImpreso.TabIndex = 0
        Me.chkPreImpreso.Text = "Factura PreImpresa"
        Me.chkPreImpreso.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 16)
        Me.Label13.TabIndex = 133
        Me.Label13.Text = "Cant. de Lineas:"
        '
        'frmAbmFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 420)
        Me.Controls.Add(Me.grTipoFactura)
        Me.Controls.Add(Me.maskFechaCaduca)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTimbrado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtNroFacturaSgte)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNroFactura)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDcaja)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtIdFactura)
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
        Me.Controls.Add(Me.txtDsuc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbmFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Factura"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.grTipoFactura.ResumeLayout(False)
        Me.grTipoFactura.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtIdFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvFormulario As System.Windows.Forms.ListView
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNroFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNroFacturaSgte As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents maskFechaCaduca As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents grTipoFactura As System.Windows.Forms.GroupBox
    Friend WithEvents txtCantidadLinea As System.Windows.Forms.TextBox
    Friend WithEvents chkPreImpreso As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
