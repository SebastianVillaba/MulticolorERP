<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaStockInicial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaStockInicial))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lvProducto = New System.Windows.Forms.ListView()
        Me.nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Forma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.subtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.deposito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCargadoPor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIdStockIni = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnImprimir)
        Me.GroupBox4.Controls.Add(Me.btnBuscar)
        Me.GroupBox4.Controls.Add(Me.btnUltimo)
        Me.GroupBox4.Controls.Add(Me.btnSiguiente)
        Me.GroupBox4.Controls.Add(Me.btnAnterior)
        Me.GroupBox4.Controls.Add(Me.btnPrimero)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 402)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(508, 69)
        Me.GroupBox4.TabIndex = 140
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Controles"
        '
        'lvProducto
        '
        Me.lvProducto.AllowColumnReorder = True
        Me.lvProducto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nro, Me.codigo, Me.mercaderia, Me.Vence, Me.Lote, Me.Forma, Me.Precio, Me.cantidad, Me.subtotal, Me.deposito})
        Me.lvProducto.FullRowSelect = True
        Me.lvProducto.GridLines = True
        Me.lvProducto.HideSelection = False
        Me.lvProducto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvProducto.LabelWrap = False
        Me.lvProducto.Location = New System.Drawing.Point(9, 23)
        Me.lvProducto.MultiSelect = False
        Me.lvProducto.Name = "lvProducto"
        Me.lvProducto.Size = New System.Drawing.Size(932, 173)
        Me.lvProducto.TabIndex = 115
        Me.lvProducto.UseCompatibleStateImageBehavior = False
        Me.lvProducto.View = System.Windows.Forms.View.Details
        '
        'nro
        '
        Me.nro.Text = "Nro."
        Me.nro.Width = 40
        '
        'codigo
        '
        Me.codigo.Text = "Codigo"
        '
        'mercaderia
        '
        Me.mercaderia.Text = "Nombre del Producto"
        Me.mercaderia.Width = 300
        '
        'Vence
        '
        Me.Vence.Text = "Vence"
        Me.Vence.Width = 50
        '
        'Lote
        '
        Me.Lote.Text = "Lote"
        Me.Lote.Width = 80
        '
        'Forma
        '
        Me.Forma.Text = "Forma"
        '
        'Precio
        '
        Me.Precio.Text = "Costo"
        Me.Precio.Width = 70
        '
        'cantidad
        '
        Me.cantidad.Text = "Cant."
        Me.cantidad.Width = 40
        '
        'subtotal
        '
        Me.subtotal.Text = "SubTotal"
        Me.subtotal.Width = 80
        '
        'deposito
        '
        Me.deposito.Text = "Deposito"
        Me.deposito.Width = 150
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lvProducto)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 191)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(949, 213)
        Me.GroupBox3.TabIndex = 139
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del Ajuste"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtPc)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtCargadoPor)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtFechaHora)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtIdStockIni)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 184)
        Me.GroupBox2.TabIndex = 143
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stock Inicial"
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.LightBlue
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(77, 121)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(294, 21)
        Me.txtSucursal.TabIndex = 76
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 15)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Sucursal  :"
        '
        'txtPc
        '
        Me.txtPc.BackColor = System.Drawing.Color.LightBlue
        Me.txtPc.Enabled = False
        Me.txtPc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPc.Location = New System.Drawing.Point(36, 94)
        Me.txtPc.Name = "txtPc"
        Me.txtPc.Size = New System.Drawing.Size(200, 21)
        Me.txtPc.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 15)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Pc :"
        '
        'txtCargadoPor
        '
        Me.txtCargadoPor.BackColor = System.Drawing.Color.LightBlue
        Me.txtCargadoPor.Enabled = False
        Me.txtCargadoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargadoPor.Location = New System.Drawing.Point(87, 67)
        Me.txtCargadoPor.Name = "txtCargadoPor"
        Me.txtCargadoPor.Size = New System.Drawing.Size(329, 21)
        Me.txtCargadoPor.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 15)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Cargado Por:"
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Enabled = False
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(113, 44)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(177, 21)
        Me.txtFechaHora.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 15)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Fecha/Hora Carga:"
        '
        'txtIdStockIni
        '
        Me.txtIdStockIni.BackColor = System.Drawing.Color.Lime
        Me.txtIdStockIni.Enabled = False
        Me.txtIdStockIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdStockIni.Location = New System.Drawing.Point(76, 17)
        Me.txtIdStockIni.Name = "txtIdStockIni"
        Me.txtIdStockIni.Size = New System.Drawing.Size(76, 24)
        Me.txtIdStockIni.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 18)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "ID Stock:"
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(430, 18)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 81
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(354, 18)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 80
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnUltimo
        '
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Image = CType(resources.GetObject("btnUltimo.Image"), System.Drawing.Image)
        Me.btnUltimo.Location = New System.Drawing.Point(237, 17)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(69, 37)
        Me.btnUltimo.TabIndex = 79
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguiente.Enabled = False
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(162, 17)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(69, 37)
        Me.btnSiguiente.TabIndex = 78
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(87, 17)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(69, 37)
        Me.btnAnterior.TabIndex = 77
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(12, 17)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(69, 37)
        Me.btnPrimero.TabIndex = 76
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'frmConsultaStockInicial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 493)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaStockInicial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Stock Inicial"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lvProducto As System.Windows.Forms.ListView
    Friend WithEvents nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents Vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents Lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents Forma As System.Windows.Forms.ColumnHeader
    Friend WithEvents Precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents subtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCargadoPor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtIdStockIni As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents deposito As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
End Class
