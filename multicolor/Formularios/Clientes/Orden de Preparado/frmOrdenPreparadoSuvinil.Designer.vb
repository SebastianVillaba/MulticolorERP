<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPreparadoSuvinil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenPreparadoSuvinil))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalBase = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboEnvase = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscarBase = New System.Windows.Forms.Button()
        Me.txtIdStock = New System.Windows.Forms.TextBox()
        Me.txtNombreBase = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombreColor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCantidadLata = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lvOrden = New System.Windows.Forms.ListView()
        Me.lvOrden_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_codigoColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_nombreColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_gramo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_pulso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboGrupo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtTotalBase)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cboEnvase)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtBase)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnBuscarBase)
        Me.GroupBox1.Controls.Add(Me.txtIdStock)
        Me.GroupBox1.Controls.Add(Me.txtNombreBase)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNombreColor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(834, 223)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cboGrupo
        '
        Me.cboGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Enabled = False
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(100, 22)
        Me.cboGrupo.Margin = New System.Windows.Forms.Padding(4)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(234, 28)
        Me.cboGrupo.TabIndex = 125
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 20)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Grupo:"
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase.Location = New System.Drawing.Point(647, 177)
        Me.txtTotalBase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalBase.MaxLength = 4
        Me.txtTotalBase.Name = "txtTotalBase"
        Me.txtTotalBase.ReadOnly = True
        Me.txtTotalBase.Size = New System.Drawing.Size(111, 26)
        Me.txtTotalBase.TabIndex = 123
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(534, 180)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 122
        Me.Label15.Text = "Total Base :"
        '
        'cboEnvase
        '
        Me.cboEnvase.BackColor = System.Drawing.SystemColors.Window
        Me.cboEnvase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnvase.Enabled = False
        Me.cboEnvase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEnvase.FormattingEnabled = True
        Me.cboEnvase.Location = New System.Drawing.Point(276, 175)
        Me.cboEnvase.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEnvase.Name = "cboEnvase"
        Me.cboEnvase.Size = New System.Drawing.Size(234, 28)
        Me.cboEnvase.TabIndex = 115
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(195, 180)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 20)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Envase:"
        '
        'txtBase
        '
        Me.txtBase.BackColor = System.Drawing.Color.LightBlue
        Me.txtBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBase.Enabled = False
        Me.txtBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBase.Location = New System.Drawing.Point(83, 177)
        Me.txtBase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBase.MaxLength = 4
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(85, 26)
        Me.txtBase.TabIndex = 110
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 179)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 20)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Base:"
        '
        'btnBuscarBase
        '
        Me.btnBuscarBase.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarBase.Enabled = False
        Me.btnBuscarBase.Image = CType(resources.GetObject("btnBuscarBase.Image"), System.Drawing.Image)
        Me.btnBuscarBase.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarBase.Location = New System.Drawing.Point(579, 114)
        Me.btnBuscarBase.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscarBase.Name = "btnBuscarBase"
        Me.btnBuscarBase.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscarBase.TabIndex = 106
        Me.btnBuscarBase.Text = "&Buscar"
        Me.btnBuscarBase.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarBase.UseVisualStyleBackColor = True
        '
        'txtIdStock
        '
        Me.txtIdStock.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdStock.Enabled = False
        Me.txtIdStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdStock.Location = New System.Drawing.Point(174, 124)
        Me.txtIdStock.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdStock.MaxLength = 60
        Me.txtIdStock.Name = "txtIdStock"
        Me.txtIdStock.Size = New System.Drawing.Size(76, 26)
        Me.txtIdStock.TabIndex = 79
        '
        'txtNombreBase
        '
        Me.txtNombreBase.BackColor = System.Drawing.Color.LightBlue
        Me.txtNombreBase.Enabled = False
        Me.txtNombreBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreBase.Location = New System.Drawing.Point(276, 123)
        Me.txtNombreBase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreBase.MaxLength = 60
        Me.txtNombreBase.Name = "txtNombreBase"
        Me.txtNombreBase.Size = New System.Drawing.Size(292, 26)
        Me.txtNombreBase.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 126)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Nombre de Base:"
        '
        'txtNombreColor
        '
        Me.txtNombreColor.BackColor = System.Drawing.Color.LightBlue
        Me.txtNombreColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreColor.Enabled = False
        Me.txtNombreColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreColor.Location = New System.Drawing.Point(421, 76)
        Me.txtNombreColor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreColor.MaxLength = 30
        Me.txtNombreColor.Name = "txtNombreColor"
        Me.txtNombreColor.Size = New System.Drawing.Size(371, 26)
        Me.txtNombreColor.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(262, 79)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 20)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Nombre de Color:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.LightBlue
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(92, 76)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(135, 26)
        Me.txtCodigo.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Codigo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtCantidadLata)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.lvOrden)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 249)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(940, 310)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COMPONENTES"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Lime
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.Location = New System.Drawing.Point(588, 269)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.MaxLength = 10
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(111, 26)
        Me.txtTotal.TabIndex = 119
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(507, 272)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 20)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "TOTAL :"
        '
        'txtCantidadLata
        '
        Me.txtCantidadLata.BackColor = System.Drawing.Color.LightBlue
        Me.txtCantidadLata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadLata.Enabled = False
        Me.txtCantidadLata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadLata.Location = New System.Drawing.Point(204, 269)
        Me.txtCantidadLata.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidadLata.MaxLength = 4
        Me.txtCantidadLata.Name = "txtCantidadLata"
        Me.txtCantidadLata.Size = New System.Drawing.Size(85, 26)
        Me.txtCantidadLata.TabIndex = 113
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(44, 272)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 20)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Cantidad de Latas:"
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(836, 82)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(92, 46)
        Me.btnEliminar.TabIndex = 108
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
        Me.btnAgregar.Location = New System.Drawing.Point(836, 28)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(92, 46)
        Me.btnAgregar.TabIndex = 107
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lvOrden
        '
        Me.lvOrden.AllowColumnReorder = True
        Me.lvOrden.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvOrden_nro, Me.lvOrden_codigoColor, Me.lvOrden_nombreColor, Me.lvOrden_precio, Me.lvOrden_gramo, Me.lvOrden_pulso})
        Me.lvOrden.FullRowSelect = True
        Me.lvOrden.GridLines = True
        Me.lvOrden.HideSelection = False
        Me.lvOrden.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvOrden.LabelWrap = False
        Me.lvOrden.Location = New System.Drawing.Point(26, 28)
        Me.lvOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.lvOrden.MultiSelect = False
        Me.lvOrden.Name = "lvOrden"
        Me.lvOrden.Size = New System.Drawing.Size(790, 233)
        Me.lvOrden.TabIndex = 105
        Me.lvOrden.UseCompatibleStateImageBehavior = False
        Me.lvOrden.View = System.Windows.Forms.View.Details
        '
        'lvOrden_nro
        '
        Me.lvOrden_nro.Text = "Nro."
        Me.lvOrden_nro.Width = 40
        '
        'lvOrden_codigoColor
        '
        Me.lvOrden_codigoColor.Text = "Codigo"
        Me.lvOrden_codigoColor.Width = 100
        '
        'lvOrden_nombreColor
        '
        Me.lvOrden_nombreColor.Text = "Nombre Color"
        Me.lvOrden_nombreColor.Width = 250
        '
        'lvOrden_precio
        '
        Me.lvOrden_precio.Text = "Precio"
        Me.lvOrden_precio.Width = 80
        '
        'lvOrden_gramo
        '
        Me.lvOrden_gramo.Text = "Gramo"
        '
        'lvOrden_pulso
        '
        Me.lvOrden_pulso.Text = "Pulso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnCancelar)
        Me.GroupBox4.Controls.Add(Me.btnGuardar)
        Me.GroupBox4.Controls.Add(Me.btnNuevo)
        Me.GroupBox4.Location = New System.Drawing.Point(27, 575)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(322, 80)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(213, 22)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(92, 46)
        Me.btnCancelar.TabIndex = 109
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
        Me.btnGuardar.Location = New System.Drawing.Point(113, 22)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
        Me.btnGuardar.TabIndex = 108
        Me.btnGuardar.Text = "&Guadar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(13, 22)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(92, 46)
        Me.btnNuevo.TabIndex = 107
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmOrdenPreparadoSuvinil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(1000, 667)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrdenPreparadoSuvinil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Preparado - Suvinil"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalBase As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboEnvase As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarBase As System.Windows.Forms.Button
    Friend WithEvents txtIdStock As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreBase As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombreColor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadLata As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lvOrden As System.Windows.Forms.ListView
    Friend WithEvents lvOrden_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_codigoColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_nombreColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_gramo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_pulso As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
End Class
