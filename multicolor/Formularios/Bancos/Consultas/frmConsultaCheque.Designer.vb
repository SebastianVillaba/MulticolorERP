<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCheque))
        Me.lblEmpresaContable = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboCuentaCorriente = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNroCheque = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.txtTotalCheque = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtFechaHoraPago = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCargadoPor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFechaPago = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNroRecibo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIdPago = New System.Windows.Forms.TextBox()
        Me.lvDetalleMov = New System.Windows.Forms.ListView()
        Me.nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalNcr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalCanje = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalPagar = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFechaCheque = New System.Windows.Forms.TextBox()
        Me.btnAnular = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtIdCheque = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNroCheque1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdChequera = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtNroCheaque1 = New System.Windows.Forms.TextBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEmpresaContable
        '
        Me.lblEmpresaContable.AutoSize = True
        Me.lblEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresaContable.ForeColor = System.Drawing.Color.Maroon
        Me.lblEmpresaContable.Location = New System.Drawing.Point(351, 128)
        Me.lblEmpresaContable.Name = "lblEmpresaContable"
        Me.lblEmpresaContable.Size = New System.Drawing.Size(250, 25)
        Me.lblEmpresaContable.TabIndex = 82
        Me.lblEmpresaContable.Text = "EMPRESA CONTABLE"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(356, 110)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 15)
        Me.Label19.TabIndex = 81
        Me.Label19.Text = "Empresa Contable"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.cboCuentaCorriente)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtNroCheque)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(630, 71)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(9, 11)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(104, 25)
        Me.lblEstado.TabIndex = 85
        Me.lblEstado.Text = "ESTADO"
        '
        'cboCuentaCorriente
        '
        Me.cboCuentaCorriente.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboCuentaCorriente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuentaCorriente.FormattingEnabled = True
        Me.cboCuentaCorriente.Location = New System.Drawing.Point(6, 37)
        Me.cboCuentaCorriente.Name = "cboCuentaCorriente"
        Me.cboCuentaCorriente.Size = New System.Drawing.Size(464, 24)
        Me.cboCuentaCorriente.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(164, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(130, 20)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Cuenta Corriente"
        '
        'txtNroCheque
        '
        Me.txtNroCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroCheque.ForeColor = System.Drawing.Color.Teal
        Me.txtNroCheque.Location = New System.Drawing.Point(484, 37)
        Me.txtNroCheque.MaxLength = 10
        Me.txtNroCheque.Name = "txtNroCheque"
        Me.txtNroCheque.Size = New System.Drawing.Size(100, 26)
        Me.txtNroCheque.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(474, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nro. de Cheque"
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.Plum
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(73, 119)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(264, 21)
        Me.txtSucursal.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Sucursal:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(502, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 15)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Fecha/Hora:"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.LightBlue
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(260, 87)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(234, 21)
        Me.txtUsuario.TabIndex = 23
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Enabled = False
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(577, 86)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(188, 21)
        Me.txtFechaHora.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(183, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 15)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Cargado por:"
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.LightBlue
        Me.txtMoneda.Enabled = False
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(69, 87)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(108, 21)
        Me.txtMoneda.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Moneda:"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.LightBlue
        Me.txtCuenta.Enabled = False
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(273, 55)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(251, 21)
        Me.txtCuenta.TabIndex = 25
        '
        'txtTotalCheque
        '
        Me.txtTotalCheque.BackColor = System.Drawing.Color.Gold
        Me.txtTotalCheque.Enabled = False
        Me.txtTotalCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCheque.Location = New System.Drawing.Point(588, 53)
        Me.txtTotalCheque.Name = "txtTotalCheque"
        Me.txtTotalCheque.Size = New System.Drawing.Size(133, 26)
        Me.txtTotalCheque.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(224, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Cuenta:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(534, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 20)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Total:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtFechaHoraPago)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.txtCargadoPor)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.txtFechaPago)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtNroRecibo)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.txtIdPago)
        Me.GroupBox4.Controls.Add(Me.lvDetalleMov)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(89, 240)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(634, 267)
        Me.GroupBox4.TabIndex = 84
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle del Pago"
        '
        'txtFechaHoraPago
        '
        Me.txtFechaHoraPago.BackColor = System.Drawing.Color.Pink
        Me.txtFechaHoraPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHoraPago.Location = New System.Drawing.Point(120, 53)
        Me.txtFechaHoraPago.Name = "txtFechaHoraPago"
        Me.txtFechaHoraPago.ReadOnly = True
        Me.txtFechaHoraPago.Size = New System.Drawing.Size(160, 21)
        Me.txtFechaHoraPago.TabIndex = 124
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 15)
        Me.Label16.TabIndex = 123
        Me.Label16.Text = "Fecha/Hora Pago:"
        '
        'txtCargadoPor
        '
        Me.txtCargadoPor.BackColor = System.Drawing.Color.Pink
        Me.txtCargadoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargadoPor.Location = New System.Drawing.Point(370, 53)
        Me.txtCargadoPor.Name = "txtCargadoPor"
        Me.txtCargadoPor.ReadOnly = True
        Me.txtCargadoPor.Size = New System.Drawing.Size(230, 21)
        Me.txtCargadoPor.TabIndex = 122
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(288, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 15)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "Cargado por:"
        '
        'txtFechaPago
        '
        Me.txtFechaPago.BackColor = System.Drawing.Color.Pink
        Me.txtFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaPago.Location = New System.Drawing.Point(349, 26)
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.ReadOnly = True
        Me.txtFechaPago.Size = New System.Drawing.Size(81, 21)
        Me.txtFechaPago.TabIndex = 120
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(302, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 15)
        Me.Label14.TabIndex = 119
        Me.Label14.Text = "Fecha:"
        '
        'txtNroRecibo
        '
        Me.txtNroRecibo.BackColor = System.Drawing.Color.Pink
        Me.txtNroRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroRecibo.Location = New System.Drawing.Point(226, 26)
        Me.txtNroRecibo.Name = "txtNroRecibo"
        Me.txtNroRecibo.ReadOnly = True
        Me.txtNroRecibo.Size = New System.Drawing.Size(70, 21)
        Me.txtNroRecibo.TabIndex = 118
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(147, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Nro. Recibo:"
        '
        'txtIdPago
        '
        Me.txtIdPago.BackColor = System.Drawing.Color.Pink
        Me.txtIdPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPago.Location = New System.Drawing.Point(66, 26)
        Me.txtIdPago.Name = "txtIdPago"
        Me.txtIdPago.ReadOnly = True
        Me.txtIdPago.Size = New System.Drawing.Size(70, 21)
        Me.txtIdPago.TabIndex = 85
        '
        'lvDetalleMov
        '
        Me.lvDetalleMov.AllowColumnReorder = True
        Me.lvDetalleMov.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nro, Me.factura, Me.tipo, Me.totalCompra, Me.totalNcr, Me.totalCanje, Me.totalPagar})
        Me.lvDetalleMov.FullRowSelect = True
        Me.lvDetalleMov.GridLines = True
        Me.lvDetalleMov.HideSelection = False
        Me.lvDetalleMov.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvDetalleMov.LabelWrap = False
        Me.lvDetalleMov.Location = New System.Drawing.Point(13, 88)
        Me.lvDetalleMov.MultiSelect = False
        Me.lvDetalleMov.Name = "lvDetalleMov"
        Me.lvDetalleMov.Size = New System.Drawing.Size(587, 173)
        Me.lvDetalleMov.TabIndex = 116
        Me.lvDetalleMov.UseCompatibleStateImageBehavior = False
        Me.lvDetalleMov.View = System.Windows.Forms.View.Details
        '
        'nro
        '
        Me.nro.Text = "Nro."
        Me.nro.Width = 40
        '
        'factura
        '
        Me.factura.Text = "Factura"
        Me.factura.Width = 110
        '
        'tipo
        '
        Me.tipo.Text = "Tipo"
        Me.tipo.Width = 80
        '
        'totalCompra
        '
        Me.totalCompra.Text = "Total Fact."
        Me.totalCompra.Width = 90
        '
        'totalNcr
        '
        Me.totalNcr.Text = "Total Ncr."
        Me.totalNcr.Width = 80
        '
        'totalCanje
        '
        Me.totalCanje.Text = "Total Canje"
        Me.totalCanje.Width = 90
        '
        'totalPagar
        '
        Me.totalPagar.Text = "Total a Pag."
        Me.totalPagar.Width = 90
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 15)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "Id Pago:"
        '
        'txtFechaCheque
        '
        Me.txtFechaCheque.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaCheque.Enabled = False
        Me.txtFechaCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCheque.Location = New System.Drawing.Point(124, 55)
        Me.txtFechaCheque.Name = "txtFechaCheque"
        Me.txtFechaCheque.Size = New System.Drawing.Size(92, 21)
        Me.txtFechaCheque.TabIndex = 21
        '
        'btnAnular
        '
        Me.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnular.Location = New System.Drawing.Point(84, 15)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(69, 37)
        Me.btnAnular.TabIndex = 75
        Me.btnAnular.Text = "&Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(9, 15)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(69, 37)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnModificar)
        Me.GroupBox2.Controls.Add(Me.btnAnular)
        Me.GroupBox2.Controls.Add(Me.btnAceptar)
        Me.GroupBox2.Location = New System.Drawing.Point(639, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 61)
        Me.GroupBox2.TabIndex = 82
        Me.GroupBox2.TabStop = False
        '
        'btnModificar
        '
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Enabled = False
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(159, 15)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(69, 37)
        Me.btnModificar.TabIndex = 76
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtIdCheque)
        Me.GroupBox3.Controls.Add(Me.lblEmpresaContable)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtSucursal)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtFechaHora)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtUsuario)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtMoneda)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtCuenta)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtTotalCheque)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtFechaCheque)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtNroCheque1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtProveedor)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtIdChequera)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 156)
        Me.GroupBox3.TabIndex = 83
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos del Cheque"
        '
        'txtIdCheque
        '
        Me.txtIdCheque.BackColor = System.Drawing.Color.Lime
        Me.txtIdCheque.Enabled = False
        Me.txtIdCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCheque.Location = New System.Drawing.Point(186, 19)
        Me.txtIdCheque.Name = "txtIdCheque"
        Me.txtIdCheque.Size = New System.Drawing.Size(76, 24)
        Me.txtIdCheque.TabIndex = 83
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Fecha del Cheque:"
        '
        'txtNroCheque1
        '
        Me.txtNroCheque1.BackColor = System.Drawing.Color.LightBlue
        Me.txtNroCheque1.Enabled = False
        Me.txtNroCheque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroCheque1.Location = New System.Drawing.Point(677, 22)
        Me.txtNroCheque1.Name = "txtNroCheque1"
        Me.txtNroCheque1.Size = New System.Drawing.Size(93, 21)
        Me.txtNroCheque1.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(596, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Nro. Cheque:"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(334, 21)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(257, 21)
        Me.txtProveedor.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(267, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Proveedor:"
        '
        'txtIdChequera
        '
        Me.txtIdChequera.BackColor = System.Drawing.Color.Lime
        Me.txtIdChequera.Enabled = False
        Me.txtIdChequera.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdChequera.Location = New System.Drawing.Point(107, 20)
        Me.txtIdChequera.Name = "txtIdChequera"
        Me.txtIdChequera.Size = New System.Drawing.Size(76, 24)
        Me.txtIdChequera.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 18)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "ID Chequera:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(334, 21)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(257, 21)
        Me.txtCliente.TabIndex = 15
        '
        'txtNroCheaque1
        '
        Me.txtNroCheaque1.BackColor = System.Drawing.Color.LightBlue
        Me.txtNroCheaque1.Enabled = False
        Me.txtNroCheaque1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroCheaque1.Location = New System.Drawing.Point(677, 22)
        Me.txtNroCheaque1.Name = "txtNroCheaque1"
        Me.txtNroCheaque1.Size = New System.Drawing.Size(93, 21)
        Me.txtNroCheaque1.TabIndex = 19
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(3, 513)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(747, 21)
        Me.txtSql.TabIndex = 84
        '
        'frmConsultaCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 542)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Cheque"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEmpresaContable As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNroCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaCheque As System.Windows.Forms.TextBox
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNroCheque1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdChequera As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIdCheque As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaPago As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNroRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtIdPago As System.Windows.Forms.TextBox
    Friend WithEvents lvDetalleMov As System.Windows.Forms.ListView
    Friend WithEvents nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalNcr As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalCanje As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalPagar As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtCargadoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHoraPago As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNroCheaque1 As System.Windows.Forms.TextBox
    Friend WithEvents cboCuentaCorriente As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents btnModificar As System.Windows.Forms.Button
End Class
