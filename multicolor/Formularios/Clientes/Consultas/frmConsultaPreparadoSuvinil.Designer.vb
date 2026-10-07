<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaPreparadoSuvinil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaPreparadoSuvinil))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtExplica = New System.Windows.Forms.TextBox()
        Me.txtFechaAnulado = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAnuladoPor = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCargadoPor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIdOrden = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCantidadLata = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEnvase = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNombreBase = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombreColor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lvOrden = New System.Windows.Forms.ListView()
        Me.lvOrden_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_codigoColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_nombreColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_gramo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrden_pulso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtTotalVenta = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFormaVenta = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtIdVenta = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox7)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtCargadoPor)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtFechaHora)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtIdOrden)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(655, 242)
        Me.GroupBox2.TabIndex = 135
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Orden Preparado"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtExplica)
        Me.GroupBox7.Controls.Add(Me.txtFechaAnulado)
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.txtAnuladoPor)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 121)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Size = New System.Drawing.Size(627, 111)
        Me.GroupBox7.TabIndex = 131
        Me.GroupBox7.TabStop = False
        '
        'txtExplica
        '
        Me.txtExplica.BackColor = System.Drawing.Color.LightCoral
        Me.txtExplica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExplica.Location = New System.Drawing.Point(11, 58)
        Me.txtExplica.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExplica.Multiline = True
        Me.txtExplica.Name = "txtExplica"
        Me.txtExplica.ReadOnly = True
        Me.txtExplica.Size = New System.Drawing.Size(604, 47)
        Me.txtExplica.TabIndex = 85
        '
        'txtFechaAnulado
        '
        Me.txtFechaAnulado.BackColor = System.Drawing.Color.LightCoral
        Me.txtFechaAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaAnulado.Location = New System.Drawing.Point(340, 31)
        Me.txtFechaAnulado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaAnulado.Name = "txtFechaAnulado"
        Me.txtFechaAnulado.ReadOnly = True
        Me.txtFechaAnulado.Size = New System.Drawing.Size(228, 24)
        Me.txtFechaAnulado.TabIndex = 84
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(340, 11)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(152, 18)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Fecha/Hora - Anulado"
        '
        'txtAnuladoPor
        '
        Me.txtAnuladoPor.BackColor = System.Drawing.Color.LightCoral
        Me.txtAnuladoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnuladoPor.Location = New System.Drawing.Point(9, 31)
        Me.txtAnuladoPor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAnuladoPor.Name = "txtAnuladoPor"
        Me.txtAnuladoPor.ReadOnly = True
        Me.txtAnuladoPor.Size = New System.Drawing.Size(323, 24)
        Me.txtAnuladoPor.TabIndex = 82
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(9, 11)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 18)
        Me.Label22.TabIndex = 81
        Me.Label22.Text = "Anulado Por"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Yellow
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(120, 89)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(165, 30)
        Me.txtTotal.TabIndex = 76
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 96)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 18)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "TOTAL Orden:"
        '
        'txtCargadoPor
        '
        Me.txtCargadoPor.BackColor = System.Drawing.Color.LightBlue
        Me.txtCargadoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargadoPor.Location = New System.Drawing.Point(116, 58)
        Me.txtCargadoPor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCargadoPor.Name = "txtCargadoPor"
        Me.txtCargadoPor.ReadOnly = True
        Me.txtCargadoPor.Size = New System.Drawing.Size(357, 24)
        Me.txtCargadoPor.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 58)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 18)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Cargado Por:"
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(359, 23)
        Me.txtFechaHora.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.ReadOnly = True
        Me.txtFechaHora.Size = New System.Drawing.Size(235, 24)
        Me.txtFechaHora.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(211, 23)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 18)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Fecha/Hora Carga:"
        '
        'txtIdOrden
        '
        Me.txtIdOrden.BackColor = System.Drawing.Color.Lime
        Me.txtIdOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdOrden.Location = New System.Drawing.Point(101, 21)
        Me.txtIdOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdOrden.Name = "txtIdOrden"
        Me.txtIdOrden.ReadOnly = True
        Me.txtIdOrden.Size = New System.Drawing.Size(100, 29)
        Me.txtIdOrden.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 20)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 24)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "ID Orden:"
        '
        'txtGrupo
        '
        Me.txtGrupo.BackColor = System.Drawing.Color.LightBlue
        Me.txtGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupo.Location = New System.Drawing.Point(71, 137)
        Me.txtGrupo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.ReadOnly = True
        Me.txtGrupo.Size = New System.Drawing.Size(325, 24)
        Me.txtGrupo.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 139)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 18)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Grupo:"
        '
        'txtCantidadLata
        '
        Me.txtCantidadLata.BackColor = System.Drawing.Color.Pink
        Me.txtCantidadLata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadLata.Location = New System.Drawing.Point(123, 103)
        Me.txtCantidadLata.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidadLata.Name = "txtCantidadLata"
        Me.txtCantidadLata.ReadOnly = True
        Me.txtCantidadLata.Size = New System.Drawing.Size(79, 24)
        Me.txtCantidadLata.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 105)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 18)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Cantidad Lata:"
        '
        'txtEnvase
        '
        Me.txtEnvase.BackColor = System.Drawing.Color.LightGreen
        Me.txtEnvase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEnvase.Location = New System.Drawing.Point(269, 72)
        Me.txtEnvase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEnvase.Name = "txtEnvase"
        Me.txtEnvase.ReadOnly = True
        Me.txtEnvase.Size = New System.Drawing.Size(163, 24)
        Me.txtEnvase.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(200, 74)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 18)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Envase:"
        '
        'txtBase
        '
        Me.txtBase.BackColor = System.Drawing.Color.LightBlue
        Me.txtBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBase.Location = New System.Drawing.Point(79, 71)
        Me.txtBase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.ReadOnly = True
        Me.txtBase.Size = New System.Drawing.Size(95, 24)
        Me.txtBase.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 71)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 18)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Base:"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Maroon
        Me.lblEstado.Location = New System.Drawing.Point(71, 174)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(132, 31)
        Me.lblEstado.TabIndex = 15
        Me.lblEstado.Text = "ESTADO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 181)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 18)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Estado:"
        '
        'txtNombreBase
        '
        Me.txtNombreBase.BackColor = System.Drawing.Color.LightBlue
        Me.txtNombreBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreBase.Location = New System.Drawing.Point(123, 38)
        Me.txtNombreBase.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreBase.Name = "txtNombreBase"
        Me.txtNombreBase.ReadOnly = True
        Me.txtNombreBase.Size = New System.Drawing.Size(302, 24)
        Me.txtNombreBase.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 38)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 18)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Nombre Base:"
        '
        'txtNombreColor
        '
        Me.txtNombreColor.BackColor = System.Drawing.Color.LightBlue
        Me.txtNombreColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreColor.Location = New System.Drawing.Point(321, 6)
        Me.txtNombreColor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreColor.Name = "txtNombreColor"
        Me.txtNombreColor.ReadOnly = True
        Me.txtNombreColor.Size = New System.Drawing.Size(206, 24)
        Me.txtNombreColor.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(211, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nombre Color:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.LightBlue
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(75, 7)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(128, 24)
        Me.txtCodigo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lvOrden)
        Me.GroupBox3.Location = New System.Drawing.Point(205, 263)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(831, 248)
        Me.GroupBox3.TabIndex = 137
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de la Orden"
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
        Me.lvOrden.Location = New System.Drawing.Point(16, 28)
        Me.lvOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.lvOrden.MultiSelect = False
        Me.lvOrden.Name = "lvOrden"
        Me.lvOrden.Size = New System.Drawing.Size(797, 207)
        Me.lvOrden.TabIndex = 106
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
        Me.GroupBox4.Controls.Add(Me.btnAnular)
        Me.GroupBox4.Controls.Add(Me.btnBuscar)
        Me.GroupBox4.Controls.Add(Me.btnUltimo)
        Me.GroupBox4.Controls.Add(Me.btnSiguiente)
        Me.GroupBox4.Controls.Add(Me.btnAnterior)
        Me.GroupBox4.Controls.Add(Me.btnPrimero)
        Me.GroupBox4.Location = New System.Drawing.Point(292, 529)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(657, 85)
        Me.GroupBox4.TabIndex = 138
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Controles"
        '
        'btnAnular
        '
        Me.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnular.Location = New System.Drawing.Point(549, 22)
        Me.btnAnular.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(92, 46)
        Me.btnAnular.TabIndex = 81
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(449, 22)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(92, 46)
        Me.btnBuscar.TabIndex = 80
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnUltimo
        '
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Image = CType(resources.GetObject("btnUltimo.Image"), System.Drawing.Image)
        Me.btnUltimo.Location = New System.Drawing.Point(311, 21)
        Me.btnUltimo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(92, 46)
        Me.btnUltimo.TabIndex = 79
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguiente.Enabled = False
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(211, 21)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(92, 46)
        Me.btnSiguiente.TabIndex = 78
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(111, 21)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(92, 46)
        Me.btnAnterior.TabIndex = 77
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(11, 21)
        Me.btnPrimero.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(92, 46)
        Me.btnPrimero.TabIndex = 76
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(675, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(554, 243)
        Me.TabControl1.TabIndex = 139
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtGrupo)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtCodigo)
        Me.TabPage1.Controls.Add(Me.txtNombreBase)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtBase)
        Me.TabPage1.Controls.Add(Me.txtEnvase)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtCantidadLata)
        Me.TabPage1.Controls.Add(Me.txtNombreColor)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.lblEstado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(546, 214)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Orden"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtTotalVenta)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.txtFormaVenta)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtCliente)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtFactura)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtIdVenta)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(546, 214)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Facturación"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtTotalVenta
        '
        Me.txtTotalVenta.BackColor = System.Drawing.Color.LightBlue
        Me.txtTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVenta.Location = New System.Drawing.Point(118, 152)
        Me.txtTotalVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalVenta.Name = "txtTotalVenta"
        Me.txtTotalVenta.ReadOnly = True
        Me.txtTotalVenta.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalVenta.TabIndex = 43
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(21, 155)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(86, 18)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Total Venta:"
        '
        'txtFormaVenta
        '
        Me.txtFormaVenta.BackColor = System.Drawing.Color.LightBlue
        Me.txtFormaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormaVenta.Location = New System.Drawing.Point(153, 102)
        Me.txtFormaVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFormaVenta.Name = "txtFormaVenta"
        Me.txtFormaVenta.ReadOnly = True
        Me.txtFormaVenta.Size = New System.Drawing.Size(149, 24)
        Me.txtFormaVenta.TabIndex = 41
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 105)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 18)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Forma de Venta:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(93, 62)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(394, 24)
        Me.txtCliente.TabIndex = 39
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 65)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 18)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Cliente:"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.LightBlue
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(280, 16)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(236, 24)
        Me.txtFactura.TabIndex = 37
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(208, 19)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 18)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Factura:"
        '
        'txtIdVenta
        '
        Me.txtIdVenta.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdVenta.Location = New System.Drawing.Point(92, 18)
        Me.txtIdVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdVenta.Name = "txtIdVenta"
        Me.txtIdVenta.ReadOnly = True
        Me.txtIdVenta.Size = New System.Drawing.Size(82, 24)
        Me.txtIdVenta.TabIndex = 35
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 19)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 18)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Id Venta:"
        '
        'frmConsultaPreparadoSuvinil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 630)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaPreparadoSuvinil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Orden de Preparado Suvinil"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtExplica As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAnulado As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAnuladoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCargadoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtIdOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadLata As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEnvase As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNombreBase As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreColor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvOrden As System.Windows.Forms.ListView
    Friend WithEvents lvOrden_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_codigoColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_nombreColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_gramo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrden_pulso As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtTotalVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFormaVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtIdVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
