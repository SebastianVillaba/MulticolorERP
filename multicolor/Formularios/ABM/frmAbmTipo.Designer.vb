<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbmTipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbmTipo))
        Me.chkContado = New System.Windows.Forms.CheckBox()
        Me.chkTarjetaDebito = New System.Windows.Forms.CheckBox()
        Me.chkVenta = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.grTipoVenta = New System.Windows.Forms.GroupBox()
        Me.chkCheque = New System.Windows.Forms.CheckBox()
        Me.chkImprimir = New System.Windows.Forms.CheckBox()
        Me.chkTarjetaCredito = New System.Windows.Forms.CheckBox()
        Me.chkPrimero = New System.Windows.Forms.CheckBox()
        Me.chkAcreditar = New System.Windows.Forms.CheckBox()
        Me.chkSinDescuento = New System.Windows.Forms.CheckBox()
        Me.chkTipoVenta = New System.Windows.Forms.CheckBox()
        Me.txtIdTipo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.chkNoComi = New System.Windows.Forms.CheckBox()
        Me.chkTipoProducto = New System.Windows.Forms.CheckBox()
        Me.grTipoProducto = New System.Windows.Forms.GroupBox()
        Me.chkVence = New System.Windows.Forms.CheckBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdNombre = New System.Windows.Forms.RadioButton()
        Me.rdIdTipo = New System.Windows.Forms.RadioButton()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvTipo = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.grTipoVenta.SuspendLayout()
        Me.grTipoProducto.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grBuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkContado
        '
        Me.chkContado.AutoSize = True
        Me.chkContado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkContado.Enabled = False
        Me.chkContado.Location = New System.Drawing.Point(226, 58)
        Me.chkContado.Name = "chkContado"
        Me.chkContado.Size = New System.Drawing.Size(66, 17)
        Me.chkContado.TabIndex = 55
        Me.chkContado.Text = "Contado"
        Me.chkContado.UseVisualStyleBackColor = True
        '
        'chkTarjetaDebito
        '
        Me.chkTarjetaDebito.AutoSize = True
        Me.chkTarjetaDebito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTarjetaDebito.Enabled = False
        Me.chkTarjetaDebito.Location = New System.Drawing.Point(226, 35)
        Me.chkTarjetaDebito.Name = "chkTarjetaDebito"
        Me.chkTarjetaDebito.Size = New System.Drawing.Size(108, 17)
        Me.chkTarjetaDebito.TabIndex = 54
        Me.chkTarjetaDebito.Text = "Tarjeta de Debito"
        Me.chkTarjetaDebito.UseVisualStyleBackColor = True
        '
        'chkVenta
        '
        Me.chkVenta.AutoSize = True
        Me.chkVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVenta.Enabled = False
        Me.chkVenta.Location = New System.Drawing.Point(226, 12)
        Me.chkVenta.Name = "chkVenta"
        Me.chkVenta.Size = New System.Drawing.Size(59, 17)
        Me.chkVenta.TabIndex = 53
        Me.chkVenta.Text = "Ventas"
        Me.chkVenta.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(485, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(13, 16)
        Me.Label25.TabIndex = 68
        Me.Label25.Text = "*"
        '
        'grTipoVenta
        '
        Me.grTipoVenta.Controls.Add(Me.chkContado)
        Me.grTipoVenta.Controls.Add(Me.chkTarjetaDebito)
        Me.grTipoVenta.Controls.Add(Me.chkVenta)
        Me.grTipoVenta.Controls.Add(Me.chkCheque)
        Me.grTipoVenta.Controls.Add(Me.chkImprimir)
        Me.grTipoVenta.Controls.Add(Me.chkTarjetaCredito)
        Me.grTipoVenta.Controls.Add(Me.chkPrimero)
        Me.grTipoVenta.Controls.Add(Me.chkAcreditar)
        Me.grTipoVenta.Controls.Add(Me.chkSinDescuento)
        Me.grTipoVenta.Location = New System.Drawing.Point(572, 89)
        Me.grTipoVenta.Name = "grTipoVenta"
        Me.grTipoVenta.Size = New System.Drawing.Size(340, 91)
        Me.grTipoVenta.TabIndex = 65
        Me.grTipoVenta.TabStop = False
        '
        'chkCheque
        '
        Me.chkCheque.AutoSize = True
        Me.chkCheque.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkCheque.Enabled = False
        Me.chkCheque.Location = New System.Drawing.Point(110, 57)
        Me.chkCheque.Name = "chkCheque"
        Me.chkCheque.Size = New System.Drawing.Size(63, 17)
        Me.chkCheque.TabIndex = 52
        Me.chkCheque.Text = "Cheque"
        Me.chkCheque.UseVisualStyleBackColor = True
        '
        'chkImprimir
        '
        Me.chkImprimir.AutoSize = True
        Me.chkImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkImprimir.Enabled = False
        Me.chkImprimir.Location = New System.Drawing.Point(8, 57)
        Me.chkImprimir.Name = "chkImprimir"
        Me.chkImprimir.Size = New System.Drawing.Size(61, 17)
        Me.chkImprimir.TabIndex = 51
        Me.chkImprimir.Text = "Imprimir"
        Me.chkImprimir.UseVisualStyleBackColor = True
        '
        'chkTarjetaCredito
        '
        Me.chkTarjetaCredito.AutoSize = True
        Me.chkTarjetaCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTarjetaCredito.Enabled = False
        Me.chkTarjetaCredito.Location = New System.Drawing.Point(110, 33)
        Me.chkTarjetaCredito.Name = "chkTarjetaCredito"
        Me.chkTarjetaCredito.Size = New System.Drawing.Size(110, 17)
        Me.chkTarjetaCredito.TabIndex = 50
        Me.chkTarjetaCredito.Text = "Tarjeta de Credito"
        Me.chkTarjetaCredito.UseVisualStyleBackColor = True
        '
        'chkPrimero
        '
        Me.chkPrimero.AutoSize = True
        Me.chkPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkPrimero.Enabled = False
        Me.chkPrimero.Location = New System.Drawing.Point(110, 11)
        Me.chkPrimero.Name = "chkPrimero"
        Me.chkPrimero.Size = New System.Drawing.Size(112, 17)
        Me.chkPrimero.TabIndex = 49
        Me.chkPrimero.Text = "Primero en Ventas"
        Me.chkPrimero.UseVisualStyleBackColor = True
        '
        'chkAcreditar
        '
        Me.chkAcreditar.AutoSize = True
        Me.chkAcreditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkAcreditar.Enabled = False
        Me.chkAcreditar.Location = New System.Drawing.Point(8, 34)
        Me.chkAcreditar.Name = "chkAcreditar"
        Me.chkAcreditar.Size = New System.Drawing.Size(69, 17)
        Me.chkAcreditar.TabIndex = 48
        Me.chkAcreditar.Text = "A Credito"
        Me.chkAcreditar.UseVisualStyleBackColor = True
        '
        'chkSinDescuento
        '
        Me.chkSinDescuento.AutoSize = True
        Me.chkSinDescuento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkSinDescuento.Enabled = False
        Me.chkSinDescuento.Location = New System.Drawing.Point(8, 11)
        Me.chkSinDescuento.Name = "chkSinDescuento"
        Me.chkSinDescuento.Size = New System.Drawing.Size(96, 17)
        Me.chkSinDescuento.TabIndex = 47
        Me.chkSinDescuento.Text = "Sin Descuento"
        Me.chkSinDescuento.UseVisualStyleBackColor = True
        '
        'chkTipoVenta
        '
        Me.chkTipoVenta.AutoSize = True
        Me.chkTipoVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTipoVenta.Enabled = False
        Me.chkTipoVenta.Location = New System.Drawing.Point(576, 74)
        Me.chkTipoVenta.Name = "chkTipoVenta"
        Me.chkTipoVenta.Size = New System.Drawing.Size(78, 17)
        Me.chkTipoVenta.TabIndex = 64
        Me.chkTipoVenta.Text = "Tipo Venta"
        Me.chkTipoVenta.UseVisualStyleBackColor = True
        '
        'txtIdTipo
        '
        Me.txtIdTipo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdTipo.Enabled = False
        Me.txtIdTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTipo.Location = New System.Drawing.Point(377, 8)
        Me.txtIdTipo.MaxLength = 10
        Me.txtIdTipo.Name = "txtIdTipo"
        Me.txtIdTipo.Size = New System.Drawing.Size(63, 22)
        Me.txtIdTipo.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(734, 374)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "* Datos Obligatorios"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.BackColor = System.Drawing.SystemColors.Control
        Me.chkActivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.chkActivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkActivo.Enabled = False
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(320, 46)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(64, 20)
        Me.chkActivo.TabIndex = 62
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = False
        '
        'chkNoComi
        '
        Me.chkNoComi.AutoSize = True
        Me.chkNoComi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkNoComi.Enabled = False
        Me.chkNoComi.Location = New System.Drawing.Point(6, 37)
        Me.chkNoComi.Name = "chkNoComi"
        Me.chkNoComi.Size = New System.Drawing.Size(86, 17)
        Me.chkNoComi.TabIndex = 48
        Me.chkNoComi.Text = "Sin Comisión"
        Me.chkNoComi.UseVisualStyleBackColor = True
        '
        'chkTipoProducto
        '
        Me.chkTipoProducto.AutoSize = True
        Me.chkTipoProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkTipoProducto.Enabled = False
        Me.chkTipoProducto.Location = New System.Drawing.Point(323, 74)
        Me.chkTipoProducto.Name = "chkTipoProducto"
        Me.chkTipoProducto.Size = New System.Drawing.Size(108, 17)
        Me.chkTipoProducto.TabIndex = 66
        Me.chkTipoProducto.Text = "Tipo de Producto"
        Me.chkTipoProducto.UseVisualStyleBackColor = True
        '
        'grTipoProducto
        '
        Me.grTipoProducto.Controls.Add(Me.chkNoComi)
        Me.grTipoProducto.Controls.Add(Me.chkVence)
        Me.grTipoProducto.Location = New System.Drawing.Point(320, 90)
        Me.grTipoProducto.Name = "grTipoProducto"
        Me.grTipoProducto.Size = New System.Drawing.Size(246, 90)
        Me.grTipoProducto.TabIndex = 67
        Me.grTipoProducto.TabStop = False
        '
        'chkVence
        '
        Me.chkVence.AutoSize = True
        Me.chkVence.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVence.Enabled = False
        Me.chkVence.Location = New System.Drawing.Point(6, 14)
        Me.chkVence.Name = "chkVence"
        Me.chkVence.Size = New System.Drawing.Size(57, 17)
        Me.chkVence.TabIndex = 47
        Me.chkVence.Text = "Vence"
        Me.chkVence.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(559, 8)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(328, 22)
        Me.txtNombre.TabIndex = 56
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(495, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Nombre :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Controls.Add(Me.btnModificar)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(334, 365)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 56)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
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
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdNombre)
        Me.grOrdenar.Controls.Add(Me.rdIdTipo)
        Me.grOrdenar.Location = New System.Drawing.Point(64, 11)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(170, 34)
        Me.grOrdenar.TabIndex = 18
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdNombre
        '
        Me.rdNombre.AutoSize = True
        Me.rdNombre.Checked = True
        Me.rdNombre.Location = New System.Drawing.Point(82, 13)
        Me.rdNombre.Name = "rdNombre"
        Me.rdNombre.Size = New System.Drawing.Size(62, 17)
        Me.rdNombre.TabIndex = 18
        Me.rdNombre.TabStop = True
        Me.rdNombre.Text = "Nombre"
        Me.rdNombre.UseVisualStyleBackColor = True
        '
        'rdIdTipo
        '
        Me.rdIdTipo.AutoSize = True
        Me.rdIdTipo.Location = New System.Drawing.Point(8, 13)
        Me.rdIdTipo.Name = "rdIdTipo"
        Me.rdIdTipo.Size = New System.Drawing.Size(57, 17)
        Me.rdIdTipo.TabIndex = 17
        Me.rdIdTipo.Text = "IDTipo"
        Me.rdIdTipo.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 49)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lvTipo
        '
        Me.lvTipo.AllowColumnReorder = True
        Me.lvTipo.FullRowSelect = True
        Me.lvTipo.GridLines = True
        Me.lvTipo.HideSelection = False
        Me.lvTipo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvTipo.LabelWrap = False
        Me.lvTipo.Location = New System.Drawing.Point(6, 81)
        Me.lvTipo.MultiSelect = False
        Me.lvTipo.Name = "lvTipo"
        Me.lvTipo.Size = New System.Drawing.Size(267, 357)
        Me.lvTipo.TabIndex = 3
        Me.lvTipo.UseCompatibleStateImageBehavior = False
        Me.lvTipo.View = System.Windows.Forms.View.Details
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(319, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "ID Tipo :"
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(642, 447)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaMod.TabIndex = 59
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(642, 426)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 58
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(417, 447)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioMod.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(317, 450)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Último Modificador  :"
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(417, 426)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioAlta.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(331, 429)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Usuario Creador :"
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvTipo)
        Me.grBuscar.Location = New System.Drawing.Point(10, 11)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(282, 447)
        Me.grBuscar.TabIndex = 50
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'frmAbmTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 492)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.grTipoVenta)
        Me.Controls.Add(Me.chkTipoVenta)
        Me.Controls.Add(Me.txtIdTipo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.chkTipoProducto)
        Me.Controls.Add(Me.grTipoProducto)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFechaMod)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grBuscar)
        Me.Name = "frmAbmTipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Tipo"
        Me.grTipoVenta.ResumeLayout(False)
        Me.grTipoVenta.PerformLayout()
        Me.grTipoProducto.ResumeLayout(False)
        Me.grTipoProducto.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkContado As System.Windows.Forms.CheckBox
    Friend WithEvents chkTarjetaDebito As System.Windows.Forms.CheckBox
    Friend WithEvents chkVenta As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents grTipoVenta As System.Windows.Forms.GroupBox
    Friend WithEvents chkCheque As System.Windows.Forms.CheckBox
    Friend WithEvents chkImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents chkTarjetaCredito As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrimero As System.Windows.Forms.CheckBox
    Friend WithEvents chkAcreditar As System.Windows.Forms.CheckBox
    Friend WithEvents chkSinDescuento As System.Windows.Forms.CheckBox
    Friend WithEvents chkTipoVenta As System.Windows.Forms.CheckBox
    Friend WithEvents txtIdTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoComi As System.Windows.Forms.CheckBox
    Friend WithEvents chkTipoProducto As System.Windows.Forms.CheckBox
    Friend WithEvents grTipoProducto As System.Windows.Forms.GroupBox
    Friend WithEvents chkVence As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdNombre As System.Windows.Forms.RadioButton
    Friend WithEvents rdIdTipo As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvTipo As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
End Class
