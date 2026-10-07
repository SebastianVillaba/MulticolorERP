<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobroClienteNuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCobroClienteNuevo))
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
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalMonto = New System.Windows.Forms.TextBox()
        Me.txtTotalPagado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalNotaCr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalSaldo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvCabPago = New System.Windows.Forms.ListView()
        Me.cab_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_idMov = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_obra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_Nrocuota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_monto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_notaCredito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_retencion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_pagado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_pago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_saldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_pag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cab_tipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtPagado = New System.Windows.Forms.TextBox()
        Me.txtTotalRetencion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIdMov = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMaximaCantidad = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCantidadCobrada = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(13, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1179, 112)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'txtGrupo
        '
        Me.txtGrupo.BackColor = System.Drawing.Color.Pink
        Me.txtGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupo.Location = New System.Drawing.Point(72, 79)
        Me.txtGrupo.Margin = New System.Windows.Forms.Padding(4)
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
        Me.txtEmail.Location = New System.Drawing.Point(693, 49)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(476, 26)
        Me.txtEmail.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(633, 53)
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
        Me.txtCel2.Margin = New System.Windows.Forms.Padding(4)
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
        Me.txtCel1.Margin = New System.Windows.Forms.Padding(4)
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
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(4)
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
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(4)
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
        Me.txtIdCliente.Margin = New System.Windows.Forms.Padding(4)
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
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(1113, 135)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 46)
        Me.btnCancelar.TabIndex = 130
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(1024, 135)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 46)
        Me.btnGuardar.TabIndex = 129
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(935, 135)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(81, 46)
        Me.btnNuevo.TabIndex = 128
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(253, 139)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(77, 46)
        Me.btnProcesar.TabIndex = 103
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMonto.Location = New System.Drawing.Point(124, 159)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(119, 26)
        Me.txtMonto.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(130, 135)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Monto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(49, 631)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 20)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "Total Monto"
        '
        'txtTotalMonto
        '
        Me.txtTotalMonto.BackColor = System.Drawing.Color.PaleGreen
        Me.txtTotalMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMonto.Location = New System.Drawing.Point(31, 653)
        Me.txtTotalMonto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalMonto.Name = "txtTotalMonto"
        Me.txtTotalMonto.ReadOnly = True
        Me.txtTotalMonto.Size = New System.Drawing.Size(139, 26)
        Me.txtTotalMonto.TabIndex = 132
        Me.txtTotalMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalPagado
        '
        Me.txtTotalPagado.BackColor = System.Drawing.Color.Thistle
        Me.txtTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagado.Location = New System.Drawing.Point(178, 653)
        Me.txtTotalPagado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalPagado.Name = "txtTotalPagado"
        Me.txtTotalPagado.ReadOnly = True
        Me.txtTotalPagado.Size = New System.Drawing.Size(139, 26)
        Me.txtTotalPagado.TabIndex = 135
        Me.txtTotalPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(187, 631)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 20)
        Me.Label8.TabIndex = 134
        Me.Label8.Text = "Total Pagado"
        '
        'txtTotalNotaCr
        '
        Me.txtTotalNotaCr.BackColor = System.Drawing.Color.Pink
        Me.txtTotalNotaCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNotaCr.Location = New System.Drawing.Point(475, 656)
        Me.txtTotalNotaCr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalNotaCr.Name = "txtTotalNotaCr"
        Me.txtTotalNotaCr.ReadOnly = True
        Me.txtTotalNotaCr.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalNotaCr.TabIndex = 138
        Me.txtTotalNotaCr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(484, 635)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 20)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Total Nota Cr."
        '
        'txtTotalSaldo
        '
        Me.txtTotalSaldo.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSaldo.Location = New System.Drawing.Point(626, 657)
        Me.txtTotalSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalSaldo.Name = "txtTotalSaldo"
        Me.txtTotalSaldo.ReadOnly = True
        Me.txtTotalSaldo.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalSaldo.TabIndex = 140
        Me.txtTotalSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(644, 637)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 139
        Me.Label7.Text = "Total Saldo"
        '
        'lvCabPago
        '
        Me.lvCabPago.AllowColumnReorder = True
        Me.lvCabPago.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cab_factura, Me.cab_idMov, Me.cab_obra, Me.cab_fecha, Me.cab_Nrocuota, Me.cab_monto, Me.cab_notaCredito, Me.cab_retencion, Me.cab_pagado, Me.cab_pago, Me.cab_saldo, Me.cab_pag, Me.cab_tipo})
        Me.lvCabPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCabPago.FullRowSelect = True
        Me.lvCabPago.GridLines = True
        Me.lvCabPago.HideSelection = False
        Me.lvCabPago.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCabPago.LabelWrap = False
        Me.lvCabPago.Location = New System.Drawing.Point(4, 193)
        Me.lvCabPago.Margin = New System.Windows.Forms.Padding(4)
        Me.lvCabPago.MultiSelect = False
        Me.lvCabPago.Name = "lvCabPago"
        Me.lvCabPago.Size = New System.Drawing.Size(1396, 409)
        Me.lvCabPago.TabIndex = 141
        Me.lvCabPago.UseCompatibleStateImageBehavior = False
        Me.lvCabPago.View = System.Windows.Forms.View.Details
        '
        'cab_factura
        '
        Me.cab_factura.Text = "Factura"
        Me.cab_factura.Width = 120
        '
        'cab_idMov
        '
        Me.cab_idMov.Text = "IdMov"
        Me.cab_idMov.Width = 80
        '
        'cab_obra
        '
        Me.cab_obra.Text = "Obra"
        Me.cab_obra.Width = 150
        '
        'cab_fecha
        '
        Me.cab_fecha.Text = "Fecha"
        Me.cab_fecha.Width = 100
        '
        'cab_Nrocuota
        '
        Me.cab_Nrocuota.Text = "Nro.Cuo."
        Me.cab_Nrocuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cab_monto
        '
        Me.cab_monto.Text = "Cuota"
        Me.cab_monto.Width = 90
        '
        'cab_notaCredito
        '
        Me.cab_notaCredito.Text = "Nota Cr."
        Me.cab_notaCredito.Width = 90
        '
        'cab_retencion
        '
        Me.cab_retencion.Text = "Retencion"
        Me.cab_retencion.Width = 90
        '
        'cab_pagado
        '
        Me.cab_pagado.Text = "Pagado"
        Me.cab_pagado.Width = 90
        '
        'cab_pago
        '
        Me.cab_pago.Text = "Pago"
        Me.cab_pago.Width = 90
        '
        'cab_saldo
        '
        Me.cab_saldo.Text = "Saldo"
        Me.cab_saldo.Width = 90
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtPagado)
        Me.GroupBox5.Location = New System.Drawing.Point(785, 628)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(229, 68)
        Me.GroupBox5.TabIndex = 142
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Total Pagado"
        '
        'txtPagado
        '
        Me.txtPagado.BackColor = System.Drawing.Color.Aquamarine
        Me.txtPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagado.Location = New System.Drawing.Point(8, 23)
        Me.txtPagado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPagado.Name = "txtPagado"
        Me.txtPagado.ReadOnly = True
        Me.txtPagado.Size = New System.Drawing.Size(208, 34)
        Me.txtPagado.TabIndex = 133
        Me.txtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalRetencion
        '
        Me.txtTotalRetencion.BackColor = System.Drawing.Color.White
        Me.txtTotalRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRetencion.Location = New System.Drawing.Point(328, 656)
        Me.txtTotalRetencion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalRetencion.Name = "txtTotalRetencion"
        Me.txtTotalRetencion.ReadOnly = True
        Me.txtTotalRetencion.Size = New System.Drawing.Size(139, 26)
        Me.txtTotalRetencion.TabIndex = 144
        Me.txtTotalRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(333, 634)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 20)
        Me.Label10.TabIndex = 143
        Me.Label10.Text = "Total Retencion"
        '
        'txtIdMov
        '
        Me.txtIdMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMov.ForeColor = System.Drawing.Color.DarkRed
        Me.txtIdMov.Location = New System.Drawing.Point(14, 159)
        Me.txtIdMov.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdMov.Name = "txtIdMov"
        Me.txtIdMov.Size = New System.Drawing.Size(86, 26)
        Me.txtIdMov.TabIndex = 146
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 135)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 20)
        Me.Label12.TabIndex = 145
        Me.Label12.Text = "Id Mov."
        '
        'txtMaximaCantidad
        '
        Me.txtMaximaCantidad.BackColor = System.Drawing.Color.LightBlue
        Me.txtMaximaCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaximaCantidad.Location = New System.Drawing.Point(725, 151)
        Me.txtMaximaCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMaximaCantidad.Name = "txtMaximaCantidad"
        Me.txtMaximaCantidad.ReadOnly = True
        Me.txtMaximaCantidad.Size = New System.Drawing.Size(62, 26)
        Me.txtMaximaCantidad.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(385, 155)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(298, 20)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Cantidad Máxima de Factura a Cobrar:"
        '
        'txtCantidadCobrada
        '
        Me.txtCantidadCobrada.BackColor = System.Drawing.Color.Pink
        Me.txtCantidadCobrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadCobrada.Location = New System.Drawing.Point(804, 152)
        Me.txtCantidadCobrada.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidadCobrada.Name = "txtCantidadCobrada"
        Me.txtCantidadCobrada.ReadOnly = True
        Me.txtCantidadCobrada.Size = New System.Drawing.Size(62, 26)
        Me.txtCantidadCobrada.TabIndex = 147
        '
        'frmCobroClienteNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1413, 709)
        Me.Controls.Add(Me.txtCantidadCobrada)
        Me.Controls.Add(Me.txtMaximaCantidad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtIdMov)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTotalRetencion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.lvCabPago)
        Me.Controls.Add(Me.txtTotalSaldo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotalNotaCr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalPagado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotalMonto)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCobroClienteNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobro a Cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPagado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNotaCr As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lvCabPago As System.Windows.Forms.ListView
    Friend WithEvents cab_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_obra As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_Nrocuota As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_monto As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_notaCredito As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_retencion As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_pago As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_saldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_pag As System.Windows.Forms.ColumnHeader
    Friend WithEvents cab_tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPagado As System.Windows.Forms.TextBox
    Friend WithEvents cab_pagado As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTotalRetencion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtIdMov As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMaximaCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadCobrada As System.Windows.Forms.TextBox
End Class
