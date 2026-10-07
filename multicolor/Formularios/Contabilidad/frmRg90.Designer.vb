<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRg90
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRg90))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.lblTotalIva10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalIVA5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalTxt = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExportarDetalle = New System.Windows.Forms.Button()
        Me.lvDetalle = New System.Windows.Forms.ListView()
        Me.det_codigoRegistro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_codigoTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_docuento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_codigoComprobante = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_timbrado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_iva10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_iva5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_exenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_CodigoVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_operacionMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_imputaIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_imputable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_imputaIrp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_facturaNcr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_timbradoNcr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_archivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.lblTotalIva10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblTotalIVA5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblTotalTxt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnExportarDetalle)
        Me.GroupBox1.Controls.Add(Me.lvDetalle)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1240, 411)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Archivo para la resolución RG90"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 379)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 20)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Guardar Archivo en:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.PaleGreen
        Me.txtDireccion.Location = New System.Drawing.Point(320, 379)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(896, 22)
        Me.txtDireccion.TabIndex = 104
        '
        'lblTotalIva10
        '
        Me.lblTotalIva10.AutoSize = True
        Me.lblTotalIva10.BackColor = System.Drawing.Color.Lime
        Me.lblTotalIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIva10.Location = New System.Drawing.Point(240, 342)
        Me.lblTotalIva10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIva10.Name = "lblTotalIva10"
        Me.lblTotalIva10.Size = New System.Drawing.Size(115, 20)
        Me.lblTotalIva10.TabIndex = 101
        Me.lblTotalIva10.Text = "lblTotalIva10"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(115, 342)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 20)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Total IVA 10:"
        '
        'lblTotalIVA5
        '
        Me.lblTotalIVA5.AutoSize = True
        Me.lblTotalIVA5.BackColor = System.Drawing.Color.Lime
        Me.lblTotalIVA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIVA5.Location = New System.Drawing.Point(233, 314)
        Me.lblTotalIVA5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIVA5.Name = "lblTotalIVA5"
        Me.lblTotalIVA5.Size = New System.Drawing.Size(105, 20)
        Me.lblTotalIVA5.TabIndex = 99
        Me.lblTotalIVA5.Text = "lblTotalIva5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(115, 314)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Total IVA 5:"
        '
        'lblTotalTxt
        '
        Me.lblTotalTxt.AutoSize = True
        Me.lblTotalTxt.BackColor = System.Drawing.Color.Yellow
        Me.lblTotalTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTxt.Location = New System.Drawing.Point(515, 303)
        Me.lblTotalTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalTxt.Name = "lblTotalTxt"
        Me.lblTotalTxt.Size = New System.Drawing.Size(97, 20)
        Me.lblTotalTxt.TabIndex = 97
        Me.lblTotalTxt.Text = "lblTotalTxt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(448, 303)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 20)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Total :"
        '
        'btnExportarDetalle
        '
        Me.btnExportarDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarDetalle.Image = CType(resources.GetObject("btnExportarDetalle.Image"), System.Drawing.Image)
        Me.btnExportarDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportarDetalle.Location = New System.Drawing.Point(12, 303)
        Me.btnExportarDetalle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExportarDetalle.Name = "btnExportarDetalle"
        Me.btnExportarDetalle.Size = New System.Drawing.Size(95, 63)
        Me.btnExportarDetalle.TabIndex = 95
        Me.btnExportarDetalle.Text = "Exportar Detalle"
        Me.btnExportarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportarDetalle.UseVisualStyleBackColor = True
        '
        'lvDetalle
        '
        Me.lvDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_codigoRegistro, Me.det_codigoTipo, Me.det_docuento, Me.det_cliente, Me.det_codigoComprobante, Me.det_fecha, Me.det_timbrado, Me.det_factura, Me.det_iva10, Me.det_iva5, Me.det_exenta, Me.det_total, Me.det_CodigoVenta, Me.det_operacionMoneda, Me.det_imputaIva, Me.det_imputable, Me.det_imputaIrp, Me.det_facturaNcr, Me.det_timbradoNcr, Me.det_archivo})
        Me.lvDetalle.Location = New System.Drawing.Point(12, 20)
        Me.lvDetalle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvDetalle.Name = "lvDetalle"
        Me.lvDetalle.Size = New System.Drawing.Size(1215, 275)
        Me.lvDetalle.TabIndex = 4
        Me.lvDetalle.UseCompatibleStateImageBehavior = False
        Me.lvDetalle.View = System.Windows.Forms.View.Details
        '
        'det_codigoRegistro
        '
        Me.det_codigoRegistro.Text = "Cod. Reg."
        '
        'det_codigoTipo
        '
        Me.det_codigoTipo.Text = "Cod.Tipo"
        '
        'det_docuento
        '
        Me.det_docuento.Text = "Documento"
        Me.det_docuento.Width = 80
        '
        'det_cliente
        '
        Me.det_cliente.Text = "Cliente"
        Me.det_cliente.Width = 250
        '
        'det_codigoComprobante
        '
        Me.det_codigoComprobante.Text = "Cod.Com."
        Me.det_codigoComprobante.Width = 50
        '
        'det_fecha
        '
        Me.det_fecha.Text = "Fecha"
        Me.det_fecha.Width = 70
        '
        'det_timbrado
        '
        Me.det_timbrado.Text = "Timbrado"
        Me.det_timbrado.Width = 80
        '
        'det_factura
        '
        Me.det_factura.Text = "Factura"
        Me.det_factura.Width = 120
        '
        'det_iva10
        '
        Me.det_iva10.Text = "IVA10"
        Me.det_iva10.Width = 70
        '
        'det_iva5
        '
        Me.det_iva5.Text = "IVA5"
        Me.det_iva5.Width = 70
        '
        'det_exenta
        '
        Me.det_exenta.Text = "Exenta"
        Me.det_exenta.Width = 70
        '
        'det_total
        '
        Me.det_total.Text = "Total"
        Me.det_total.Width = 70
        '
        'det_CodigoVenta
        '
        Me.det_CodigoVenta.Text = "Cod.Vta."
        Me.det_CodigoVenta.Width = 45
        '
        'det_operacionMoneda
        '
        Me.det_operacionMoneda.Text = "OPM"
        Me.det_operacionMoneda.Width = 45
        '
        'det_imputaIva
        '
        Me.det_imputaIva.Text = "ImIva"
        Me.det_imputaIva.Width = 40
        '
        'det_imputable
        '
        Me.det_imputable.Text = "Imp."
        Me.det_imputable.Width = 45
        '
        'det_imputaIrp
        '
        Me.det_imputaIrp.Text = "impIrp"
        Me.det_imputaIrp.Width = 40
        '
        'det_facturaNcr
        '
        Me.det_facturaNcr.Text = "FacturaNcr"
        Me.det_facturaNcr.Width = 110
        '
        'det_timbradoNcr
        '
        Me.det_timbradoNcr.Text = "Timbrado Ncr."
        Me.det_timbradoNcr.Width = 90
        '
        'det_archivo
        '
        Me.det_archivo.Text = "archivo"
        '
        'frmRg90
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1273, 454)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRg90"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RG-90"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalIva10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIVA5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalTxt As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExportarDetalle As System.Windows.Forms.Button
    Friend WithEvents lvDetalle As System.Windows.Forms.ListView
    Friend WithEvents det_codigoRegistro As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_codigoTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_docuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_codigoComprobante As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_iva10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_iva5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_exenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_CodigoVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_operacionMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_imputaIva As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_imputable As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_timbrado As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_archivo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_imputaIrp As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_facturaNcr As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_timbradoNcr As System.Windows.Forms.ColumnHeader
End Class
