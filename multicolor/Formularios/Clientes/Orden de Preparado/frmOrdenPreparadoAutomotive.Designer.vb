<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPreparadoAutomotive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenPreparadoAutomotive))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtValueShade = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRegion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAnho = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCalidad = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscarEnsambladora = New System.Windows.Forms.Button()
        Me.txtIdEnsambladora = New System.Windows.Forms.TextBox()
        Me.txtEnsambladora = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAlternativa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboLinea = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombreColor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTotalDescuento = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalCosto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalLitro = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalGramo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCantidadLata = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboDescuento = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdOtro = New System.Windows.Forms.RadioButton()
        Me.rdTresLitros = New System.Windows.Forms.RadioButton()
        Me.rdDosLitros = New System.Windows.Forms.RadioButton()
        Me.rdUnLitro = New System.Windows.Forms.RadioButton()
        Me.rdMedioLitro = New System.Windows.Forms.RadioButton()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lvOrden = New System.Windows.Forms.ListView()
        Me.lvOrden_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_componentes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_gramo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_acumulado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_precioOrden = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValueShade)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtRegion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtAnho)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboCalidad)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnBuscarEnsambladora)
        Me.GroupBox1.Controls.Add(Me.txtIdEnsambladora)
        Me.GroupBox1.Controls.Add(Me.txtEnsambladora)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtAlternativa)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboLinea)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNombreColor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1201, 166)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtValueShade
        '
        Me.txtValueShade.BackColor = System.Drawing.Color.LightBlue
        Me.txtValueShade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValueShade.Enabled = False
        Me.txtValueShade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValueShade.Location = New System.Drawing.Point(876, 113)
        Me.txtValueShade.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValueShade.MaxLength = 30
        Me.txtValueShade.Name = "txtValueShade"
        Me.txtValueShade.Size = New System.Drawing.Size(186, 26)
        Me.txtValueShade.TabIndex = 114
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(757, 116)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 20)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Value Shade:"
        '
        'txtRegion
        '
        Me.txtRegion.BackColor = System.Drawing.Color.LightBlue
        Me.txtRegion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRegion.Enabled = False
        Me.txtRegion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegion.Location = New System.Drawing.Point(633, 113)
        Me.txtRegion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRegion.MaxLength = 4
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Size = New System.Drawing.Size(85, 26)
        Me.txtRegion.TabIndex = 112
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(551, 116)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 20)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Región:"
        '
        'txtAnho
        '
        Me.txtAnho.BackColor = System.Drawing.Color.LightBlue
        Me.txtAnho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAnho.Enabled = False
        Me.txtAnho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnho.Location = New System.Drawing.Point(443, 113)
        Me.txtAnho.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAnho.MaxLength = 4
        Me.txtAnho.Name = "txtAnho"
        Me.txtAnho.Size = New System.Drawing.Size(85, 26)
        Me.txtAnho.TabIndex = 110
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(379, 116)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 20)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Año:"
        '
        'cboCalidad
        '
        Me.cboCalidad.BackColor = System.Drawing.SystemColors.Window
        Me.cboCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalidad.Enabled = False
        Me.cboCalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCalidad.FormattingEnabled = True
        Me.cboCalidad.Location = New System.Drawing.Point(88, 113)
        Me.cboCalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCalidad.Name = "cboCalidad"
        Me.cboCalidad.Size = New System.Drawing.Size(234, 28)
        Me.cboCalidad.TabIndex = 108
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 116)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 20)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Calidad:"
        '
        'btnBuscarEnsambladora
        '
        Me.btnBuscarEnsambladora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarEnsambladora.Enabled = False
        Me.btnBuscarEnsambladora.Image = CType(resources.GetObject("btnBuscarEnsambladora.Image"), System.Drawing.Image)
        Me.btnBuscarEnsambladora.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarEnsambladora.Location = New System.Drawing.Point(1092, 42)
        Me.btnBuscarEnsambladora.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscarEnsambladora.Name = "btnBuscarEnsambladora"
        Me.btnBuscarEnsambladora.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscarEnsambladora.TabIndex = 106
        Me.btnBuscarEnsambladora.Text = "&Buscar"
        Me.btnBuscarEnsambladora.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarEnsambladora.UseVisualStyleBackColor = True
        '
        'txtIdEnsambladora
        '
        Me.txtIdEnsambladora.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdEnsambladora.Enabled = False
        Me.txtIdEnsambladora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdEnsambladora.Location = New System.Drawing.Point(690, 61)
        Me.txtIdEnsambladora.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdEnsambladora.MaxLength = 60
        Me.txtIdEnsambladora.Name = "txtIdEnsambladora"
        Me.txtIdEnsambladora.Size = New System.Drawing.Size(76, 26)
        Me.txtIdEnsambladora.TabIndex = 79
        '
        'txtEnsambladora
        '
        Me.txtEnsambladora.BackColor = System.Drawing.Color.LightBlue
        Me.txtEnsambladora.Enabled = False
        Me.txtEnsambladora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnsambladora.Location = New System.Drawing.Point(792, 60)
        Me.txtEnsambladora.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEnsambladora.MaxLength = 60
        Me.txtEnsambladora.Name = "txtEnsambladora"
        Me.txtEnsambladora.Size = New System.Drawing.Size(292, 26)
        Me.txtEnsambladora.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(551, 63)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Ensambladora:"
        '
        'txtAlternativa
        '
        Me.txtAlternativa.BackColor = System.Drawing.Color.LightBlue
        Me.txtAlternativa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlternativa.Enabled = False
        Me.txtAlternativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlternativa.Location = New System.Drawing.Point(444, 60)
        Me.txtAlternativa.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAlternativa.MaxLength = 4
        Me.txtAlternativa.Name = "txtAlternativa"
        Me.txtAlternativa.Size = New System.Drawing.Size(85, 26)
        Me.txtAlternativa.TabIndex = 76
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(337, 63)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Alternativa:"
        '
        'cboLinea
        '
        Me.cboLinea.BackColor = System.Drawing.SystemColors.Window
        Me.cboLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinea.Enabled = False
        Me.cboLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLinea.FormattingEnabled = True
        Me.cboLinea.Location = New System.Drawing.Point(88, 60)
        Me.cboLinea.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLinea.Name = "cboLinea"
        Me.cboLinea.Size = New System.Drawing.Size(234, 28)
        Me.cboLinea.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 63)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 20)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Linea:"
        '
        'txtNombreColor
        '
        Me.txtNombreColor.BackColor = System.Drawing.Color.LightBlue
        Me.txtNombreColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreColor.Enabled = False
        Me.txtNombreColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreColor.Location = New System.Drawing.Point(421, 15)
        Me.txtNombreColor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreColor.MaxLength = 50
        Me.txtNombreColor.Name = "txtNombreColor"
        Me.txtNombreColor.Size = New System.Drawing.Size(371, 26)
        Me.txtNombreColor.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(262, 18)
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
        Me.txtCodigo.Location = New System.Drawing.Point(92, 15)
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
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Codigo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTotalDescuento)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtTotalCosto)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTotalLitro)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtTotalGramo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtCantidadLata)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cboDescuento)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.lvOrden)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1231, 344)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COMPONENTES"
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.Cyan
        Me.txtTotalDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDescuento.Location = New System.Drawing.Point(926, 311)
        Me.txtTotalDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalDescuento.MaxLength = 4
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(111, 26)
        Me.txtTotalDescuento.TabIndex = 123
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(774, 314)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(142, 20)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Total Descuento :"
        '
        'txtTotalCosto
        '
        Me.txtTotalCosto.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCosto.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCosto.Location = New System.Drawing.Point(588, 311)
        Me.txtTotalCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalCosto.MaxLength = 4
        Me.txtTotalCosto.Name = "txtTotalCosto"
        Me.txtTotalCosto.ReadOnly = True
        Me.txtTotalCosto.Size = New System.Drawing.Size(111, 26)
        Me.txtTotalCosto.TabIndex = 121
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(475, 314)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 20)
        Me.Label15.TabIndex = 120
        Me.Label15.Text = "Total Costo :"
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
        'txtTotalLitro
        '
        Me.txtTotalLitro.BackColor = System.Drawing.Color.Red
        Me.txtTotalLitro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalLitro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLitro.ForeColor = System.Drawing.Color.Yellow
        Me.txtTotalLitro.Location = New System.Drawing.Point(373, 311)
        Me.txtTotalLitro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalLitro.MaxLength = 4
        Me.txtTotalLitro.Name = "txtTotalLitro"
        Me.txtTotalLitro.ReadOnly = True
        Me.txtTotalLitro.Size = New System.Drawing.Size(85, 26)
        Me.txtTotalLitro.TabIndex = 117
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(283, 314)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 20)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "Total Lt.:"
        '
        'txtTotalGramo
        '
        Me.txtTotalGramo.BackColor = System.Drawing.Color.Red
        Me.txtTotalGramo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalGramo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGramo.ForeColor = System.Drawing.Color.Yellow
        Me.txtTotalGramo.Location = New System.Drawing.Point(373, 270)
        Me.txtTotalGramo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalGramo.MaxLength = 4
        Me.txtTotalGramo.Name = "txtTotalGramo"
        Me.txtTotalGramo.ReadOnly = True
        Me.txtTotalGramo.Size = New System.Drawing.Size(85, 26)
        Me.txtTotalGramo.TabIndex = 115
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(283, 273)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 20)
        Me.Label12.TabIndex = 114
        Me.Label12.Text = "Total Gr.:"
        '
        'txtCantidadLata
        '
        Me.txtCantidadLata.BackColor = System.Drawing.Color.LightBlue
        Me.txtCantidadLata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadLata.Enabled = False
        Me.txtCantidadLata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadLata.Location = New System.Drawing.Point(1020, 273)
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
        Me.Label11.Location = New System.Drawing.Point(860, 276)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 20)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Cantidad de Latas:"
        '
        'cboDescuento
        '
        Me.cboDescuento.BackColor = System.Drawing.SystemColors.Window
        Me.cboDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDescuento.Enabled = False
        Me.cboDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDescuento.FormattingEnabled = True
        Me.cboDescuento.Location = New System.Drawing.Point(1022, 233)
        Me.cboDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDescuento.Name = "cboDescuento"
        Me.cboDescuento.Size = New System.Drawing.Size(110, 28)
        Me.cboDescuento.TabIndex = 111
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(916, 236)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Descuento:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdOtro)
        Me.GroupBox3.Controls.Add(Me.rdTresLitros)
        Me.GroupBox3.Controls.Add(Me.rdDosLitros)
        Me.GroupBox3.Controls.Add(Me.rdUnLitro)
        Me.GroupBox3.Controls.Add(Me.rdMedioLitro)
        Me.GroupBox3.Location = New System.Drawing.Point(918, 99)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(299, 108)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Recipientes"
        '
        'rdOtro
        '
        Me.rdOtro.AutoSize = True
        Me.rdOtro.Location = New System.Drawing.Point(118, 66)
        Me.rdOtro.Margin = New System.Windows.Forms.Padding(4)
        Me.rdOtro.Name = "rdOtro"
        Me.rdOtro.Size = New System.Drawing.Size(57, 21)
        Me.rdOtro.TabIndex = 22
        Me.rdOtro.Text = "Otro"
        Me.rdOtro.UseVisualStyleBackColor = True
        '
        'rdTresLitros
        '
        Me.rdTresLitros.AutoSize = True
        Me.rdTresLitros.Location = New System.Drawing.Point(14, 66)
        Me.rdTresLitros.Margin = New System.Windows.Forms.Padding(4)
        Me.rdTresLitros.Name = "rdTresLitros"
        Me.rdTresLitros.Size = New System.Drawing.Size(88, 21)
        Me.rdTresLitros.TabIndex = 21
        Me.rdTresLitros.Text = "3,6 Litros"
        Me.rdTresLitros.UseVisualStyleBackColor = True
        '
        'rdDosLitros
        '
        Me.rdDosLitros.AutoSize = True
        Me.rdDosLitros.Location = New System.Drawing.Point(211, 27)
        Me.rdDosLitros.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDosLitros.Name = "rdDosLitros"
        Me.rdDosLitros.Size = New System.Drawing.Size(76, 21)
        Me.rdDosLitros.TabIndex = 20
        Me.rdDosLitros.Text = "2 Litros"
        Me.rdDosLitros.UseVisualStyleBackColor = True
        '
        'rdUnLitro
        '
        Me.rdUnLitro.AutoSize = True
        Me.rdUnLitro.Location = New System.Drawing.Point(118, 27)
        Me.rdUnLitro.Margin = New System.Windows.Forms.Padding(4)
        Me.rdUnLitro.Name = "rdUnLitro"
        Me.rdUnLitro.Size = New System.Drawing.Size(69, 21)
        Me.rdUnLitro.TabIndex = 19
        Me.rdUnLitro.Text = "1 Litro"
        Me.rdUnLitro.UseVisualStyleBackColor = True
        '
        'rdMedioLitro
        '
        Me.rdMedioLitro.AutoSize = True
        Me.rdMedioLitro.Location = New System.Drawing.Point(14, 27)
        Me.rdMedioLitro.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMedioLitro.Name = "rdMedioLitro"
        Me.rdMedioLitro.Size = New System.Drawing.Size(81, 21)
        Me.rdMedioLitro.TabIndex = 18
        Me.rdMedioLitro.Text = "1/2 Litro"
        Me.rdMedioLitro.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(1021, 28)
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
        Me.btnAgregar.Location = New System.Drawing.Point(918, 28)
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
        Me.lvOrden.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvOrden_nro, Me.lvOrden_componentes, Me.lvOrden_gramo, Me.lvOrden_acumulado, Me.lvOrden_precioOrden, Me.lvOrden_precio})
        Me.lvOrden.FullRowSelect = True
        Me.lvOrden.GridLines = True
        Me.lvOrden.HideSelection = False
        Me.lvOrden.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvOrden.LabelWrap = False
        Me.lvOrden.Location = New System.Drawing.Point(26, 28)
        Me.lvOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.lvOrden.MultiSelect = False
        Me.lvOrden.Name = "lvOrden"
        Me.lvOrden.Size = New System.Drawing.Size(870, 233)
        Me.lvOrden.TabIndex = 105
        Me.lvOrden.UseCompatibleStateImageBehavior = False
        Me.lvOrden.View = System.Windows.Forms.View.Details
        '
        'lvOrden_nro
        '
        Me.lvOrden_nro.Text = "Nro."
        Me.lvOrden_nro.Width = 40
        '
        'lvOrden_componentes
        '
        Me.lvOrden_componentes.Text = "Componentes"
        Me.lvOrden_componentes.Width = 300
        '
        'lvOrden_gramo
        '
        Me.lvOrden_gramo.Text = "Gramo."
        Me.lvOrden_gramo.Width = 65
        '
        'lvOrden_acumulado
        '
        Me.lvOrden_acumulado.Text = "Acumulado"
        Me.lvOrden_acumulado.Width = 80
        '
        'lvOrden_precioOrden
        '
        Me.lvOrden_precioOrden.Text = "Precio Or."
        Me.lvOrden_precioOrden.Width = 80
        '
        'lvOrden_precio
        '
        Me.lvOrden_precio.Text = "Precio"
        Me.lvOrden_precio.Width = 90
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnCancelar)
        Me.GroupBox4.Controls.Add(Me.btnGuardar)
        Me.GroupBox4.Controls.Add(Me.btnNuevo)
        Me.GroupBox4.Location = New System.Drawing.Point(28, 548)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(322, 80)
        Me.GroupBox4.TabIndex = 2
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
        'frmOrdenPreparadoAutomotive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1254, 646)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrdenPreparadoAutomotive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Preparado - Automotive"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreColor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAlternativa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboLinea As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIdEnsambladora As System.Windows.Forms.TextBox
    Friend WithEvents txtEnsambladora As System.Windows.Forms.TextBox
    Friend WithEvents txtAnho As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarEnsambladora As System.Windows.Forms.Button
    Friend WithEvents txtValueShade As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRegion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lvOrden As System.Windows.Forms.ListView
    Friend WithEvents lvOrden_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_componentes As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_gramo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_acumulado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_precioOrden As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTotalGramo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadLata As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboDescuento As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdOtro As System.Windows.Forms.RadioButton
    Friend WithEvents rdTresLitros As System.Windows.Forms.RadioButton
    Friend WithEvents rdDosLitros As System.Windows.Forms.RadioButton
    Friend WithEvents rdUnLitro As System.Windows.Forms.RadioButton
    Friend WithEvents rdMedioLitro As System.Windows.Forms.RadioButton
    Friend WithEvents txtTotalDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalLitro As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
