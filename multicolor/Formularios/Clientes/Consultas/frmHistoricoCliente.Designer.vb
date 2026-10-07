<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistoricoCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistoricoCliente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCel2 = New System.Windows.Forms.TextBox()
        Me.txtCel1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblIdCuota = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lvDetalleFactura = New System.Windows.Forms.ListView()
        Me.detProd_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detProd_cant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detProd_subtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lvCabPago = New System.Windows.Forms.ListView()
        Me.cab_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_monto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_notaCredito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_pago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_saldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_cuota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_pag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_tipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_idMov = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.chkPendiente = New System.Windows.Forms.CheckBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalSaldo = New System.Windows.Forms.TextBox()
        Me.txtTotalPagado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lvDetPago = New System.Windows.Forms.ListView()
        Me.det_nrocuota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_cuota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_pagado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_saldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_nrorecibo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_fechapago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_dia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_cobrador = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtTotalNotaCredito = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtGrupo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCel2)
        Me.GroupBox1.Controls.Add(Me.txtCel1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.txtIdCliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, -1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1179, 112)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'txtGrupo
        '
        Me.txtGrupo.BackColor = System.Drawing.Color.Pink
        Me.txtGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupo.Location = New System.Drawing.Point(72, 79)
        Me.txtGrupo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.ReadOnly = True
        Me.txtGrupo.Size = New System.Drawing.Size(352, 26)
        Me.txtGrupo.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 82)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Grupo:"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.LightBlue
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(693, 46)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(476, 26)
        Me.txtEmail.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(633, 49)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "email:"
        '
        'txtCel2
        '
        Me.txtCel2.BackColor = System.Drawing.Color.LightBlue
        Me.txtCel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCel2.Location = New System.Drawing.Point(885, 20)
        Me.txtCel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCel2.Name = "txtCel2"
        Me.txtCel2.ReadOnly = True
        Me.txtCel2.Size = New System.Drawing.Size(160, 26)
        Me.txtCel2.TabIndex = 7
        '
        'txtCel1
        '
        Me.txtCel1.BackColor = System.Drawing.Color.LightBlue
        Me.txtCel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCel1.Location = New System.Drawing.Point(703, 20)
        Me.txtCel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCel1.Name = "txtCel1"
        Me.txtCel1.ReadOnly = True
        Me.txtCel1.Size = New System.Drawing.Size(160, 26)
        Me.txtCel1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(633, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Celular:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.LightBlue
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(92, 49)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(528, 26)
        Me.txtDireccion.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Dirección:"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.LightBlue
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(185, 20)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(435, 26)
        Me.txtCliente.TabIndex = 2
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.Color.LawnGreen
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(92, 20)
        Me.txtIdCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(84, 26)
        Me.txtIdCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id Cliente:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblIdCuota)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.lvDetalleFactura)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.lvCabPago)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 174)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(1291, 273)
        Me.GroupBox3.TabIndex = 90
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de Movimientos"
        '
        'lblIdCuota
        '
        Me.lblIdCuota.AutoSize = True
        Me.lblIdCuota.BackColor = System.Drawing.Color.PaleGreen
        Me.lblIdCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCuota.Location = New System.Drawing.Point(485, 246)
        Me.lblIdCuota.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdCuota.Name = "lblIdCuota"
        Me.lblIdCuota.Size = New System.Drawing.Size(59, 18)
        Me.lblIdCuota.TabIndex = 131
        Me.lblIdCuota.Text = "idCuota"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(411, 245)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 18)
        Me.Label16.TabIndex = 130
        Me.Label16.Text = "ID Cuota:"
        '
        'lvDetalleFactura
        '
        Me.lvDetalleFactura.AllowColumnReorder = True
        Me.lvDetalleFactura.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detProd_mercaderia, Me.detProd_cant, Me.detProd_subtotal})
        Me.lvDetalleFactura.FullRowSelect = True
        Me.lvDetalleFactura.GridLines = True
        Me.lvDetalleFactura.HideSelection = False
        Me.lvDetalleFactura.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvDetalleFactura.LabelWrap = False
        Me.lvDetalleFactura.Location = New System.Drawing.Point(803, 28)
        Me.lvDetalleFactura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvDetalleFactura.MultiSelect = False
        Me.lvDetalleFactura.Name = "lvDetalleFactura"
        Me.lvDetalleFactura.Size = New System.Drawing.Size(475, 212)
        Me.lvDetalleFactura.TabIndex = 122
        Me.lvDetalleFactura.UseCompatibleStateImageBehavior = False
        Me.lvDetalleFactura.View = System.Windows.Forms.View.Details
        '
        'detProd_mercaderia
        '
        Me.detProd_mercaderia.Text = "Mercaderia"
        Me.detProd_mercaderia.Width = 250
        '
        'detProd_cant
        '
        Me.detProd_cant.Text = "Cant."
        Me.detProd_cant.Width = 40
        '
        'detProd_subtotal
        '
        Me.detProd_subtotal.Text = "SubTotal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 245)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(336, 18)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Tipo= 1 Ventas - 2 Ventas Sucursales - 3 Creditos"
        '
        'lvCabPago
        '
        Me.lvCabPago.AllowColumnReorder = True
        Me.lvCabPago.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cab_factura, Me.cab_sucursal, Me.cab_fecha, Me.cab_monto, Me.cab_notaCredito, Me.cab_pago, Me.cab_saldo, Me.cab_cuota, Me.cab_pag, Me.cab_tipo, Me.cab_idMov})
        Me.lvCabPago.FullRowSelect = True
        Me.lvCabPago.GridLines = True
        Me.lvCabPago.HideSelection = False
        Me.lvCabPago.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCabPago.LabelWrap = False
        Me.lvCabPago.Location = New System.Drawing.Point(11, 28)
        Me.lvCabPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvCabPago.MultiSelect = False
        Me.lvCabPago.Name = "lvCabPago"
        Me.lvCabPago.Size = New System.Drawing.Size(783, 212)
        Me.lvCabPago.TabIndex = 115
        Me.lvCabPago.UseCompatibleStateImageBehavior = False
        Me.lvCabPago.View = System.Windows.Forms.View.Details
        '
        'cab_factura
        '
        Me.cab_factura.Text = "Factura"
        Me.cab_factura.Width = 90
        '
        'cab_sucursal
        '
        Me.cab_sucursal.Text = "Sucursal"
        Me.cab_sucursal.Width = 150
        '
        'cab_fecha
        '
        Me.cab_fecha.Text = "Fecha"
        Me.cab_fecha.Width = 70
        '
        'cab_monto
        '
        Me.cab_monto.Text = "Monto"
        Me.cab_monto.Width = 70
        '
        'cab_notaCredito
        '
        Me.cab_notaCredito.Text = "Nota Cr."
        Me.cab_notaCredito.Width = 70
        '
        'cab_pago
        '
        Me.cab_pago.Text = "Pagado"
        Me.cab_pago.Width = 70
        '
        'cab_saldo
        '
        Me.cab_saldo.Text = "Saldo"
        Me.cab_saldo.Width = 70
        '
        'cab_cuota
        '
        Me.cab_cuota.Text = "Cuota"
        Me.cab_cuota.Width = 40
        '
        'cab_pag
        '
        Me.cab_pag.Text = "Pag."
        Me.cab_pag.Width = 40
        '
        'cab_tipo
        '
        Me.cab_tipo.Text = "Tipo"
        Me.cab_tipo.Width = 40
        '
        'cab_idMov
        '
        Me.cab_idMov.Text = "IdMov"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnConsultar)
        Me.GroupBox2.Controls.Add(Me.chkPendiente)
        Me.GroupBox2.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(671, 112)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(447, 68)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtro"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(360, 17)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(79, 46)
        Me.btnConsultar.TabIndex = 126
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chkPendiente
        '
        Me.chkPendiente.AutoSize = True
        Me.chkPendiente.Location = New System.Drawing.Point(12, 43)
        Me.chkPendiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkPendiente.Name = "chkPendiente"
        Me.chkPendiente.Size = New System.Drawing.Size(155, 21)
        Me.chkPendiente.TabIndex = 103
        Me.chkPendiente.Text = "Solo los Pendientes"
        Me.chkPendiente.UseVisualStyleBackColor = True
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(231, 16)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(119, 22)
        Me.dtpHastaFecha.TabIndex = 101
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(180, 18)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Hasta:"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(65, 17)
        Me.dtpDesdeFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(108, 22)
        Me.dtpDesdeFecha.TabIndex = 99
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 21)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Desde:"
        '
        'txtTotalSaldo
        '
        Me.txtTotalSaldo.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSaldo.Location = New System.Drawing.Point(313, 137)
        Me.txtTotalSaldo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalSaldo.Name = "txtTotalSaldo"
        Me.txtTotalSaldo.ReadOnly = True
        Me.txtTotalSaldo.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalSaldo.TabIndex = 119
        Me.txtTotalSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalPagado
        '
        Me.txtTotalPagado.BackColor = System.Drawing.Color.Thistle
        Me.txtTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagado.Location = New System.Drawing.Point(168, 137)
        Me.txtTotalPagado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalPagado.Name = "txtTotalPagado"
        Me.txtTotalPagado.ReadOnly = True
        Me.txtTotalPagado.Size = New System.Drawing.Size(139, 26)
        Me.txtTotalPagado.TabIndex = 119
        Me.txtTotalPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(329, 114)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "Total Saldo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(177, 114)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 20)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Total Pagado"
        '
        'txtTotalMonto
        '
        Me.txtTotalMonto.BackColor = System.Drawing.Color.PaleGreen
        Me.txtTotalMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMonto.Location = New System.Drawing.Point(23, 137)
        Me.txtTotalMonto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalMonto.Name = "txtTotalMonto"
        Me.txtTotalMonto.ReadOnly = True
        Me.txtTotalMonto.Size = New System.Drawing.Size(139, 26)
        Me.txtTotalMonto.TabIndex = 117
        Me.txtTotalMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 114)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 20)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Total Monto"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.lvDetPago)
        Me.GroupBox4.Location = New System.Drawing.Point(97, 449)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(1119, 306)
        Me.GroupBox4.TabIndex = 91
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle de las Cuotas"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(12, 283)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 18)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Cuotas Vencidas"
        '
        'lvDetPago
        '
        Me.lvDetPago.AllowColumnReorder = True
        Me.lvDetPago.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_nrocuota, Me.det_cuota, Me.det_pagado, Me.det_saldo, Me.det_nrorecibo, Me.det_fechapago, Me.det_vence, Me.det_dia, Me.det_cobrador})
        Me.lvDetPago.FullRowSelect = True
        Me.lvDetPago.GridLines = True
        Me.lvDetPago.HideSelection = False
        Me.lvDetPago.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvDetPago.LabelWrap = False
        Me.lvDetPago.Location = New System.Drawing.Point(12, 23)
        Me.lvDetPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvDetPago.MultiSelect = False
        Me.lvDetPago.Name = "lvDetPago"
        Me.lvDetPago.Size = New System.Drawing.Size(1087, 254)
        Me.lvDetPago.TabIndex = 116
        Me.lvDetPago.UseCompatibleStateImageBehavior = False
        Me.lvDetPago.View = System.Windows.Forms.View.Details
        '
        'det_nrocuota
        '
        Me.det_nrocuota.Text = "Nro. Cuo."
        '
        'det_cuota
        '
        Me.det_cuota.Text = "Cuota"
        Me.det_cuota.Width = 70
        '
        'det_pagado
        '
        Me.det_pagado.Text = "Pagado"
        Me.det_pagado.Width = 80
        '
        'det_saldo
        '
        Me.det_saldo.Text = "Saldo"
        Me.det_saldo.Width = 80
        '
        'det_nrorecibo
        '
        Me.det_nrorecibo.Text = "Nro.Rec."
        Me.det_nrorecibo.Width = 70
        '
        'det_fechapago
        '
        Me.det_fechapago.Text = "FechaPag."
        Me.det_fechapago.Width = 80
        '
        'det_vence
        '
        Me.det_vence.Text = "Vence"
        Me.det_vence.Width = 80
        '
        'det_dia
        '
        Me.det_dia.Text = "Dia"
        Me.det_dia.Width = 90
        '
        'det_cobrador
        '
        Me.det_cobrador.Text = "Cobrador"
        Me.det_cobrador.Width = 200
        '
        'txtTotalNotaCredito
        '
        Me.txtTotalNotaCredito.BackColor = System.Drawing.Color.LightCoral
        Me.txtTotalNotaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNotaCredito.Location = New System.Drawing.Point(460, 137)
        Me.txtTotalNotaCredito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalNotaCredito.Name = "txtTotalNotaCredito"
        Me.txtTotalNotaCredito.ReadOnly = True
        Me.txtTotalNotaCredito.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalNotaCredito.TabIndex = 125
        Me.txtTotalNotaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(476, 114)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 20)
        Me.Label13.TabIndex = 124
        Me.Label13.Text = "Total NotaCr."
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(1212, 126)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(81, 46)
        Me.btnImprimir.TabIndex = 128
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(1127, 126)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(81, 46)
        Me.btnBuscar.TabIndex = 127
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmHistoricoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1313, 767)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txtTotalNotaCredito)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtTotalSaldo)
        Me.Controls.Add(Me.txtTotalMonto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotalPagado)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHistoricoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial del Cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCel2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvCabPago As System.Windows.Forms.ListView
    Friend WithEvents cab_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_monto As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_pago As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_saldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_cuota As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_pag As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPagado As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lvDetPago As System.Windows.Forms.ListView
    Friend WithEvents det_nrocuota As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_cuota As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_pagado As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_saldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_nrorecibo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_fechapago As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_dia As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_cobrador As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDetalleFactura As System.Windows.Forms.ListView
    Friend WithEvents detProd_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents detProd_cant As System.Windows.Forms.ColumnHeader
    Friend WithEvents detProd_subtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cab_notaCredito As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTotalNotaCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblIdCuota As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
