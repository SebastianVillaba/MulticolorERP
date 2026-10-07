<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbmProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbmProducto))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.lvProducto = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdCodigo = New System.Windows.Forms.RadioButton()
        Me.rdNombre = New System.Windows.Forms.RadioButton()
        Me.rdIdProducto = New System.Windows.Forms.RadioButton()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnPrecio = New System.Windows.Forms.Button()
        Me.grCostos = New System.Windows.Forms.GroupBox()
        Me.lvCosto = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdLaboratorio = New System.Windows.Forms.TextBox()
        Me.txtIdTipoProducto = New System.Windows.Forms.TextBox()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkEnvase = New System.Windows.Forms.CheckBox()
        Me.chkBasico = New System.Windows.Forms.CheckBox()
        Me.chkUsoInterno = New System.Windows.Forms.CheckBox()
        Me.chkFueraLinea = New System.Windows.Forms.CheckBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboImpuesto = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLaboratorio = New System.Windows.Forms.TextBox()
        Me.btnBuscarLabo = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.btnBuscarTipo = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPresentacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigoBarra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEliminarImagen = New System.Windows.Forms.Button()
        Me.lblImagen = New System.Windows.Forms.Label()
        Me.btnBuscarImagen = New System.Windows.Forms.Button()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.lblNombreImagen = New System.Windows.Forms.Label()
        Me.btnCapturar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grOrdenar.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grCostos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.lvProducto)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(9, 14)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(389, 512)
        Me.grBuscar.TabIndex = 80
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'lvProducto
        '
        Me.lvProducto.AllowColumnReorder = True
        Me.lvProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvProducto.FullRowSelect = True
        Me.lvProducto.GridLines = True
        Me.lvProducto.HideSelection = False
        Me.lvProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvProducto.LabelWrap = False
        Me.lvProducto.Location = New System.Drawing.Point(10, 73)
        Me.lvProducto.MultiSelect = False
        Me.lvProducto.Name = "lvProducto"
        Me.lvProducto.Size = New System.Drawing.Size(374, 416)
        Me.lvProducto.TabIndex = 21
        Me.lvProducto.UseCompatibleStateImageBehavior = False
        Me.lvProducto.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Codigo"
        Me.ColumnHeader2.Width = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombre Mercaderia"
        Me.ColumnHeader3.Width = 300
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Stock"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdCodigo)
        Me.grOrdenar.Controls.Add(Me.rdNombre)
        Me.grOrdenar.Controls.Add(Me.rdIdProducto)
        Me.grOrdenar.Location = New System.Drawing.Point(64, 11)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(203, 34)
        Me.grOrdenar.TabIndex = 18
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdCodigo
        '
        Me.rdCodigo.AutoSize = True
        Me.rdCodigo.Location = New System.Drawing.Point(114, 13)
        Me.rdCodigo.Name = "rdCodigo"
        Me.rdCodigo.Size = New System.Drawing.Size(58, 17)
        Me.rdCodigo.TabIndex = 19
        Me.rdCodigo.Text = "Codigo"
        Me.rdCodigo.UseVisualStyleBackColor = True
        '
        'rdNombre
        '
        Me.rdNombre.AutoSize = True
        Me.rdNombre.Checked = True
        Me.rdNombre.Location = New System.Drawing.Point(49, 13)
        Me.rdNombre.Name = "rdNombre"
        Me.rdNombre.Size = New System.Drawing.Size(62, 17)
        Me.rdNombre.TabIndex = 18
        Me.rdNombre.TabStop = True
        Me.rdNombre.Text = "Nombre"
        Me.rdNombre.UseVisualStyleBackColor = True
        '
        'rdIdProducto
        '
        Me.rdIdProducto.AutoSize = True
        Me.rdIdProducto.Location = New System.Drawing.Point(8, 13)
        Me.rdIdProducto.Name = "rdIdProducto"
        Me.rdIdProducto.Size = New System.Drawing.Size(36, 17)
        Me.rdIdProducto.TabIndex = 17
        Me.rdIdProducto.Text = "ID"
        Me.rdIdProducto.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 49)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnUltimo)
        Me.GroupBox7.Controls.Add(Me.btnSiguiente)
        Me.GroupBox7.Controls.Add(Me.btnAnterior)
        Me.GroupBox7.Controls.Add(Me.btnPrimero)
        Me.GroupBox7.Controls.Add(Me.btnCancelar)
        Me.GroupBox7.Controls.Add(Me.btnGuardar)
        Me.GroupBox7.Controls.Add(Me.btnModificar)
        Me.GroupBox7.Controls.Add(Me.btnNuevo)
        Me.GroupBox7.Controls.Add(Me.btnPrecio)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 536)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(343, 103)
        Me.GroupBox7.TabIndex = 119
        Me.GroupBox7.TabStop = False
        '
        'btnUltimo
        '
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Image = CType(resources.GetObject("btnUltimo.Image"), System.Drawing.Image)
        Me.btnUltimo.Location = New System.Drawing.Point(245, 11)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(69, 37)
        Me.btnUltimo.TabIndex = 85
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguiente.Enabled = False
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(170, 11)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(69, 37)
        Me.btnSiguiente.TabIndex = 84
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(95, 11)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(69, 37)
        Me.btnAnterior.TabIndex = 83
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(20, 11)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(69, 37)
        Me.btnPrimero.TabIndex = 82
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(199, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(64, 37)
        Me.btnCancelar.TabIndex = 81
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
        Me.btnGuardar.Location = New System.Drawing.Point(135, 53)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(64, 37)
        Me.btnGuardar.TabIndex = 80
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(71, 53)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(64, 37)
        Me.btnModificar.TabIndex = 79
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(6, 53)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(64, 37)
        Me.btnNuevo.TabIndex = 78
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnPrecio
        '
        Me.btnPrecio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrecio.Image = CType(resources.GetObject("btnPrecio.Image"), System.Drawing.Image)
        Me.btnPrecio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrecio.Location = New System.Drawing.Point(263, 53)
        Me.btnPrecio.Name = "btnPrecio"
        Me.btnPrecio.Size = New System.Drawing.Size(64, 37)
        Me.btnPrecio.TabIndex = 77
        Me.btnPrecio.Text = "&Precios"
        Me.btnPrecio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrecio.UseVisualStyleBackColor = True
        '
        'grCostos
        '
        Me.grCostos.Controls.Add(Me.lvCosto)
        Me.grCostos.Location = New System.Drawing.Point(407, 222)
        Me.grCostos.Name = "grCostos"
        Me.grCostos.Size = New System.Drawing.Size(202, 213)
        Me.grCostos.TabIndex = 115
        Me.grCostos.TabStop = False
        Me.grCostos.Text = "Costos"
        '
        'lvCosto
        '
        Me.lvCosto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvCosto.Location = New System.Drawing.Point(9, 18)
        Me.lvCosto.Name = "lvCosto"
        Me.lvCosto.Size = New System.Drawing.Size(186, 181)
        Me.lvCosto.TabIndex = 0
        Me.lvCosto.UseCompatibleStateImageBehavior = False
        Me.lvCosto.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Fecha"
        Me.ColumnHeader10.Width = 90
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Costo"
        Me.ColumnHeader11.Width = 70
        '
        'txtIdLaboratorio
        '
        Me.txtIdLaboratorio.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdLaboratorio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdLaboratorio.Enabled = False
        Me.txtIdLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdLaboratorio.Location = New System.Drawing.Point(790, 132)
        Me.txtIdLaboratorio.MaxLength = 60
        Me.txtIdLaboratorio.Name = "txtIdLaboratorio"
        Me.txtIdLaboratorio.Size = New System.Drawing.Size(47, 22)
        Me.txtIdLaboratorio.TabIndex = 128
        '
        'txtIdTipoProducto
        '
        Me.txtIdTipoProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdTipoProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdTipoProducto.Enabled = False
        Me.txtIdTipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTipoProducto.Location = New System.Drawing.Point(443, 132)
        Me.txtIdTipoProducto.MaxLength = 60
        Me.txtIdTipoProducto.Name = "txtIdTipoProducto"
        Me.txtIdTipoProducto.Size = New System.Drawing.Size(47, 22)
        Me.txtIdTipoProducto.TabIndex = 126
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(717, 607)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaMod.TabIndex = 125
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(717, 586)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 124
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(492, 607)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioMod.TabIndex = 123
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(392, 609)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 13)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "Último Modificador  :"
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(492, 586)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioAlta.TabIndex = 120
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(406, 589)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 121
        Me.Label20.Text = "Usuario Creador :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkEnvase)
        Me.GroupBox2.Controls.Add(Me.chkBasico)
        Me.GroupBox2.Controls.Add(Me.chkUsoInterno)
        Me.GroupBox2.Controls.Add(Me.chkFueraLinea)
        Me.GroupBox2.Controls.Add(Me.chkActivo)
        Me.GroupBox2.Location = New System.Drawing.Point(416, 441)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(198, 128)
        Me.GroupBox2.TabIndex = 112
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Activaciones"
        '
        'chkEnvase
        '
        Me.chkEnvase.AutoSize = True
        Me.chkEnvase.BackColor = System.Drawing.SystemColors.Control
        Me.chkEnvase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkEnvase.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkEnvase.Enabled = False
        Me.chkEnvase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnvase.Location = New System.Drawing.Point(9, 100)
        Me.chkEnvase.Name = "chkEnvase"
        Me.chkEnvase.Size = New System.Drawing.Size(73, 20)
        Me.chkEnvase.TabIndex = 22
        Me.chkEnvase.Text = "Envase"
        Me.chkEnvase.UseVisualStyleBackColor = False
        '
        'chkBasico
        '
        Me.chkBasico.AutoSize = True
        Me.chkBasico.BackColor = System.Drawing.SystemColors.Control
        Me.chkBasico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkBasico.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkBasico.Enabled = False
        Me.chkBasico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBasico.Location = New System.Drawing.Point(9, 72)
        Me.chkBasico.Name = "chkBasico"
        Me.chkBasico.Size = New System.Drawing.Size(69, 20)
        Me.chkBasico.TabIndex = 21
        Me.chkBasico.Text = "Basico"
        Me.chkBasico.UseVisualStyleBackColor = False
        '
        'chkUsoInterno
        '
        Me.chkUsoInterno.AutoSize = True
        Me.chkUsoInterno.BackColor = System.Drawing.SystemColors.Control
        Me.chkUsoInterno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkUsoInterno.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkUsoInterno.Enabled = False
        Me.chkUsoInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUsoInterno.Location = New System.Drawing.Point(91, 20)
        Me.chkUsoInterno.Name = "chkUsoInterno"
        Me.chkUsoInterno.Size = New System.Drawing.Size(95, 20)
        Me.chkUsoInterno.TabIndex = 20
        Me.chkUsoInterno.Text = "Uso Interno"
        Me.chkUsoInterno.UseVisualStyleBackColor = False
        '
        'chkFueraLinea
        '
        Me.chkFueraLinea.AutoSize = True
        Me.chkFueraLinea.BackColor = System.Drawing.SystemColors.Control
        Me.chkFueraLinea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkFueraLinea.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkFueraLinea.Enabled = False
        Me.chkFueraLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFueraLinea.Location = New System.Drawing.Point(8, 46)
        Me.chkFueraLinea.Name = "chkFueraLinea"
        Me.chkFueraLinea.Size = New System.Drawing.Size(117, 20)
        Me.chkFueraLinea.TabIndex = 17
        Me.chkFueraLinea.Text = "Fuera de Linea"
        Me.chkFueraLinea.UseVisualStyleBackColor = False
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.SystemColors.Control
        Me.chkActivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkActivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkActivo.Enabled = False
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(8, 20)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 20)
        Me.chkActivo.TabIndex = 14
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtPrecio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecio.Enabled = False
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(591, 47)
        Me.txtPrecio.MaxLength = 20
        Me.txtPrecio.Multiline = True
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(99, 25)
        Me.txtPrecio.TabIndex = 109
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(542, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 16)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "Precio:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(508, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 16)
        Me.Label13.TabIndex = 108
        Me.Label13.Text = "N - I"
        '
        'txtOrigen
        '
        Me.txtOrigen.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrigen.Enabled = False
        Me.txtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrigen.Location = New System.Drawing.Point(478, 47)
        Me.txtOrigen.MaxLength = 1
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(28, 22)
        Me.txtOrigen.TabIndex = 106
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(428, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 16)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Origen:"
        '
        'cboImpuesto
        '
        Me.cboImpuesto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImpuesto.Enabled = False
        Me.cboImpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboImpuesto.FormattingEnabled = True
        Me.cboImpuesto.Location = New System.Drawing.Point(478, 180)
        Me.cboImpuesto.Name = "cboImpuesto"
        Me.cboImpuesto.Size = New System.Drawing.Size(229, 24)
        Me.cboImpuesto.TabIndex = 101
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(411, 182)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Impuesto:"
        '
        'txtLaboratorio
        '
        Me.txtLaboratorio.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtLaboratorio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLaboratorio.Enabled = False
        Me.txtLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaboratorio.Location = New System.Drawing.Point(836, 132)
        Me.txtLaboratorio.MaxLength = 60
        Me.txtLaboratorio.Name = "txtLaboratorio"
        Me.txtLaboratorio.Size = New System.Drawing.Size(194, 22)
        Me.txtLaboratorio.TabIndex = 94
        '
        'btnBuscarLabo
        '
        Me.btnBuscarLabo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarLabo.Enabled = False
        Me.btnBuscarLabo.Location = New System.Drawing.Point(1030, 129)
        Me.btnBuscarLabo.Name = "btnBuscarLabo"
        Me.btnBuscarLabo.Size = New System.Drawing.Size(38, 23)
        Me.btnBuscarLabo.TabIndex = 96
        Me.btnBuscarLabo.Text = ">>"
        Me.btnBuscarLabo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(748, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 16)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Labo.:"
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipo.Enabled = False
        Me.txtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.Location = New System.Drawing.Point(490, 132)
        Me.txtTipo.MaxLength = 60
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(209, 22)
        Me.txtTipo.TabIndex = 91
        '
        'btnBuscarTipo
        '
        Me.btnBuscarTipo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarTipo.Enabled = False
        Me.btnBuscarTipo.Location = New System.Drawing.Point(701, 130)
        Me.btnBuscarTipo.Name = "btnBuscarTipo"
        Me.btnBuscarTipo.Size = New System.Drawing.Size(38, 23)
        Me.btnBuscarTipo.TabIndex = 93
        Me.btnBuscarTipo.Text = ">>"
        Me.btnBuscarTipo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(404, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Tipo:"
        '
        'txtPresentacion
        '
        Me.txtPresentacion.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtPresentacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPresentacion.Enabled = False
        Me.txtPresentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresentacion.Location = New System.Drawing.Point(860, 91)
        Me.txtPresentacion.MaxLength = 60
        Me.txtPresentacion.Name = "txtPresentacion"
        Me.txtPresentacion.Size = New System.Drawing.Size(204, 22)
        Me.txtPresentacion.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(769, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "Presentación:"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(480, 91)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(285, 22)
        Me.txtNombre.TabIndex = 87
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(421, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Nombre:"
        '
        'txtCodigoBarra
        '
        Me.txtCodigoBarra.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtCodigoBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoBarra.Enabled = False
        Me.txtCodigoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarra.Location = New System.Drawing.Point(784, 6)
        Me.txtCodigoBarra.MaxLength = 50
        Me.txtCodigoBarra.Name = "txtCodigoBarra"
        Me.txtCodigoBarra.Size = New System.Drawing.Size(204, 22)
        Me.txtCodigoBarra.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(710, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Cod. Barra:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(634, 6)
        Me.txtCodigo.MaxLength = 6
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(69, 22)
        Me.txtCodigo.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(575, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Codigo :"
        '
        'txtIdProducto
        '
        Me.txtIdProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProducto.Enabled = False
        Me.txtIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProducto.Location = New System.Drawing.Point(503, 6)
        Me.txtIdProducto.MaxLength = 10
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(66, 22)
        Me.txtIdProducto.TabIndex = 81
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(419, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "ID Producto :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(634, 245)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(383, 267)
        Me.TabControl1.TabIndex = 144
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(375, 241)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "OBTENER IMAGEN DE ARCHIVO"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEliminarImagen)
        Me.GroupBox1.Controls.Add(Me.lblImagen)
        Me.GroupBox1.Controls.Add(Me.btnBuscarImagen)
        Me.GroupBox1.Controls.Add(Me.picImagen)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 243)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Imagen"
        '
        'btnEliminarImagen
        '
        Me.btnEliminarImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarImagen.Enabled = False
        Me.btnEliminarImagen.Location = New System.Drawing.Point(280, 48)
        Me.btnEliminarImagen.Name = "btnEliminarImagen"
        Me.btnEliminarImagen.Size = New System.Drawing.Size(51, 23)
        Me.btnEliminarImagen.TabIndex = 81
        Me.btnEliminarImagen.Text = "XX"
        Me.btnEliminarImagen.UseVisualStyleBackColor = True
        '
        'lblImagen
        '
        Me.lblImagen.AutoSize = True
        Me.lblImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImagen.ForeColor = System.Drawing.Color.DarkRed
        Me.lblImagen.Location = New System.Drawing.Point(3, 200)
        Me.lblImagen.Name = "lblImagen"
        Me.lblImagen.Size = New System.Drawing.Size(92, 15)
        Me.lblImagen.TabIndex = 80
        Me.lblImagen.Text = "nombreImagen"
        '
        'btnBuscarImagen
        '
        Me.btnBuscarImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarImagen.Enabled = False
        Me.btnBuscarImagen.Location = New System.Drawing.Point(280, 19)
        Me.btnBuscarImagen.Name = "btnBuscarImagen"
        Me.btnBuscarImagen.Size = New System.Drawing.Size(51, 23)
        Me.btnBuscarImagen.TabIndex = 60
        Me.btnBuscarImagen.Text = ">>"
        Me.btnBuscarImagen.UseVisualStyleBackColor = True
        '
        'picImagen
        '
        Me.picImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImagen.Location = New System.Drawing.Point(10, 16)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(258, 181)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 55
        Me.picImagen.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ComboBox1)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.btnDetener)
        Me.TabPage2.Controls.Add(Me.btnIniciar)
        Me.TabPage2.Controls.Add(Me.GroupBox9)
        Me.TabPage2.Controls.Add(Me.btnCapturar)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(375, 241)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "FOTO DE CAMARA"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(131, 211)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(229, 24)
        Me.ComboBox1.TabIndex = 238
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 213)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(114, 16)
        Me.Label15.TabIndex = 237
        Me.Label15.Text = "Elegir dispositivo:"
        '
        'btnDetener
        '
        Me.btnDetener.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDetener.Enabled = False
        Me.btnDetener.Location = New System.Drawing.Point(279, 66)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(91, 23)
        Me.btnDetener.TabIndex = 236
        Me.btnDetener.Text = "DETENER"
        Me.btnDetener.UseVisualStyleBackColor = True
        '
        'btnIniciar
        '
        Me.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIniciar.Enabled = False
        Me.btnIniciar.Location = New System.Drawing.Point(279, 37)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(91, 23)
        Me.btnIniciar.TabIndex = 235
        Me.btnIniciar.Text = "INICIAR"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lblNombreImagen)
        Me.GroupBox9.Location = New System.Drawing.Point(10, 8)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(242, 198)
        Me.GroupBox9.TabIndex = 226
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Imagen"
        '
        'lblNombreImagen
        '
        Me.lblNombreImagen.AutoSize = True
        Me.lblNombreImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreImagen.ForeColor = System.Drawing.Color.Maroon
        Me.lblNombreImagen.Location = New System.Drawing.Point(116, 216)
        Me.lblNombreImagen.Name = "lblNombreImagen"
        Me.lblNombreImagen.Size = New System.Drawing.Size(99, 16)
        Me.lblNombreImagen.TabIndex = 231
        Me.lblNombreImagen.Text = "nombreImagen"
        '
        'btnCapturar
        '
        Me.btnCapturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCapturar.Enabled = False
        Me.btnCapturar.Location = New System.Drawing.Point(279, 8)
        Me.btnCapturar.Name = "btnCapturar"
        Me.btnCapturar.Size = New System.Drawing.Size(91, 23)
        Me.btnCapturar.TabIndex = 60
        Me.btnCapturar.Text = "CAPTURAR"
        Me.btnCapturar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.DarkGray
        Me.GroupBox3.Controls.Add(Me.txtStock)
        Me.GroupBox3.Location = New System.Drawing.Point(728, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(146, 74)
        Me.GroupBox3.TabIndex = 173
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "STOCK TOTAL"
        '
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.Color.Yellow
        Me.txtStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.Location = New System.Drawing.Point(6, 20)
        Me.txtStock.MaxLength = 20
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(131, 38)
        Me.txtStock.TabIndex = 67
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Proveedor"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Tipo"
        Me.ColumnHeader6.Width = 100
        '
        'frmAbmProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 647)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.grBuscar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.grCostos)
        Me.Controls.Add(Me.txtIdLaboratorio)
        Me.Controls.Add(Me.txtIdTipoProducto)
        Me.Controls.Add(Me.txtFechaMod)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtOrigen)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboImpuesto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtLaboratorio)
        Me.Controls.Add(Me.btnBuscarLabo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.btnBuscarTipo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPresentacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodigoBarra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIdProducto)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAbmProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Producto"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.grCostos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents rdNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rdIdProducto As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents grCostos As System.Windows.Forms.GroupBox
    Friend WithEvents lvCosto As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents txtIdTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFueraLinea As System.Windows.Forms.CheckBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboImpuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLaboratorio As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarLabo As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarTipo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPresentacion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkUsoInterno As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrecio As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminarImagen As System.Windows.Forms.Button
    Friend WithEvents lblImagen As System.Windows.Forms.Label
    Friend WithEvents btnBuscarImagen As System.Windows.Forms.Button
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnDetener As System.Windows.Forms.Button
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreImagen As System.Windows.Forms.Label
    Friend WithEvents btnCapturar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lvProducto As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkEnvase As System.Windows.Forms.CheckBox
    Friend WithEvents chkBasico As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
