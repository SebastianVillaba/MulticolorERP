<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchivoEstudioContable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArchivoEstudioContable))
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
        Me.det_Nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_formaPago = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_ruc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_tipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_moneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_cotiza = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_texenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_gra5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_gra10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_nroCuenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_mercaderia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_exenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_gravada = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_incluido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_nroDetalle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_porIVA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_iva5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_iva10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_ivaMonto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_timbrado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_archivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.det_nota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_cuotas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_centroCosto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_estado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_formulario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_formularioReferencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_codigoImpuesto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(930, 334)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Archivo para el Estudio Contable"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 308)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Guardar Archivo en:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.PaleGreen
        Me.txtDireccion.Location = New System.Drawing.Point(240, 308)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(673, 20)
        Me.txtDireccion.TabIndex = 104
        '
        'lblTotalIva10
        '
        Me.lblTotalIva10.AutoSize = True
        Me.lblTotalIva10.BackColor = System.Drawing.Color.Lime
        Me.lblTotalIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIva10.Location = New System.Drawing.Point(180, 278)
        Me.lblTotalIva10.Name = "lblTotalIva10"
        Me.lblTotalIva10.Size = New System.Drawing.Size(98, 16)
        Me.lblTotalIva10.TabIndex = 101
        Me.lblTotalIva10.Text = "lblTotalIva10"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(86, 278)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Total IVA 10:"
        '
        'lblTotalIVA5
        '
        Me.lblTotalIVA5.AutoSize = True
        Me.lblTotalIVA5.BackColor = System.Drawing.Color.Lime
        Me.lblTotalIVA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIVA5.Location = New System.Drawing.Point(175, 255)
        Me.lblTotalIVA5.Name = "lblTotalIVA5"
        Me.lblTotalIVA5.Size = New System.Drawing.Size(90, 16)
        Me.lblTotalIVA5.TabIndex = 99
        Me.lblTotalIVA5.Text = "lblTotalIva5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Total IVA 5:"
        '
        'lblTotalTxt
        '
        Me.lblTotalTxt.AutoSize = True
        Me.lblTotalTxt.BackColor = System.Drawing.Color.Yellow
        Me.lblTotalTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTxt.Location = New System.Drawing.Point(386, 246)
        Me.lblTotalTxt.Name = "lblTotalTxt"
        Me.lblTotalTxt.Size = New System.Drawing.Size(82, 16)
        Me.lblTotalTxt.TabIndex = 97
        Me.lblTotalTxt.Text = "lblTotalTxt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(336, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Total :"
        '
        'btnExportarDetalle
        '
        Me.btnExportarDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportarDetalle.Image = CType(resources.GetObject("btnExportarDetalle.Image"), System.Drawing.Image)
        Me.btnExportarDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportarDetalle.Location = New System.Drawing.Point(9, 246)
        Me.btnExportarDetalle.Name = "btnExportarDetalle"
        Me.btnExportarDetalle.Size = New System.Drawing.Size(71, 51)
        Me.btnExportarDetalle.TabIndex = 95
        Me.btnExportarDetalle.Text = "Exportar Detalle"
        Me.btnExportarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportarDetalle.UseVisualStyleBackColor = True
        '
        'lvDetalle
        '
        Me.lvDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_Nro, Me.det_codigo, Me.det_fecha, Me.det_formaPago, Me.det_ruc, Me.det_tipo, Me.det_factura, Me.det_moneda, Me.det_cotiza, Me.det_texenta, Me.det_gra5, Me.det_gra10, Me.det_total, Me.det_nroCuenta, Me.det_mercaderia, Me.det_exenta, Me.det_gravada, Me.det_incluido, Me.det_nroDetalle, Me.det_porIVA, Me.det_iva5, Me.det_iva10, Me.det_ivaMonto, Me.det_cliente, Me.det_timbrado, Me.det_nota, Me.det_cuotas, Me.det_centroCosto, Me.det_estado, Me.det_formulario, Me.det_formularioReferencia, Me.det_codigoImpuesto, Me.det_archivo})
        Me.lvDetalle.Location = New System.Drawing.Point(9, 16)
        Me.lvDetalle.Name = "lvDetalle"
        Me.lvDetalle.Size = New System.Drawing.Size(912, 224)
        Me.lvDetalle.TabIndex = 4
        Me.lvDetalle.UseCompatibleStateImageBehavior = False
        Me.lvDetalle.View = System.Windows.Forms.View.Details
        '
        'det_Nro
        '
        Me.det_Nro.Text = "TipoDet."
        '
        'det_codigo
        '
        Me.det_codigo.Text = "Codigo"
        '
        'det_fecha
        '
        Me.det_fecha.Text = "Fecha"
        Me.det_fecha.Width = 80
        '
        'det_formaPago
        '
        Me.det_formaPago.Text = "FP"
        Me.det_formaPago.Width = 40
        '
        'det_ruc
        '
        Me.det_ruc.Text = "Ruc"
        Me.det_ruc.Width = 90
        '
        'det_tipo
        '
        Me.det_tipo.Text = "Tipo"
        Me.det_tipo.Width = 40
        '
        'det_factura
        '
        Me.det_factura.Text = "Factura"
        Me.det_factura.Width = 130
        '
        'det_moneda
        '
        Me.det_moneda.Text = "Moneda"
        '
        'det_cotiza
        '
        Me.det_cotiza.Text = "Cotiza"
        Me.det_cotiza.Width = 50
        '
        'det_texenta
        '
        Me.det_texenta.Text = "Texenta"
        Me.det_texenta.Width = 70
        '
        'det_gra5
        '
        Me.det_gra5.Text = "Gra.5"
        Me.det_gra5.Width = 70
        '
        'det_gra10
        '
        Me.det_gra10.Text = "Gra.10"
        Me.det_gra10.Width = 70
        '
        'det_total
        '
        Me.det_total.Text = "Total"
        Me.det_total.Width = 70
        '
        'det_nroCuenta
        '
        Me.det_nroCuenta.Text = "Nro.Cta."
        Me.det_nroCuenta.Width = 100
        '
        'det_mercaderia
        '
        Me.det_mercaderia.Text = "Mercaderia"
        Me.det_mercaderia.Width = 150
        '
        'det_exenta
        '
        Me.det_exenta.Text = "Exenta"
        Me.det_exenta.Width = 70
        '
        'det_gravada
        '
        Me.det_gravada.Text = "Gravadas"
        Me.det_gravada.Width = 70
        '
        'det_incluido
        '
        Me.det_incluido.Text = "Inc."
        Me.det_incluido.Width = 40
        '
        'det_nroDetalle
        '
        Me.det_nroDetalle.Text = "NroDe"
        Me.det_nroDetalle.Width = 50
        '
        'det_porIVA
        '
        Me.det_porIVA.Text = "%IVA"
        '
        'det_iva5
        '
        Me.det_iva5.Text = "IVA5"
        Me.det_iva5.Width = 70
        '
        'det_iva10
        '
        Me.det_iva10.Text = "IVA10"
        Me.det_iva10.Width = 70
        '
        'det_ivaMonto
        '
        Me.det_ivaMonto.Text = "IVA"
        Me.det_ivaMonto.Width = 70
        '
        'det_cliente
        '
        Me.det_cliente.Text = "Cliente"
        Me.det_cliente.Width = 100
        '
        'det_timbrado
        '
        Me.det_timbrado.Text = "Timbrado"
        Me.det_timbrado.Width = 80
        '
        'det_archivo
        '
        Me.det_archivo.Text = "archivo"
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.Location = New System.Drawing.Point(21, 370)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(921, 20)
        Me.txtSql.TabIndex = 106
        Me.txtSql.Visible = False
        '
        'det_nota
        '
        Me.det_nota.Text = "Nota"
        Me.det_nota.Width = 50
        '
        'det_cuotas
        '
        Me.det_cuotas.Text = "Cuotas"
        Me.det_cuotas.Width = 50
        '
        'det_centroCosto
        '
        Me.det_centroCosto.Text = "C.Costo"
        '
        'det_estado
        '
        Me.det_estado.Text = "Estado"
        '
        'det_formulario
        '
        Me.det_formulario.Text = "Formulario"
        '
        'det_formularioReferencia
        '
        Me.det_formularioReferencia.Text = "Form.Ref."
        '
        'det_codigoImpuesto
        '
        Me.det_codigoImpuesto.Text = "Cod.Imp."
        '
        'frmArchivoEstudioContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 393)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmArchivoEstudioContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Archivo para el Estudio Contable"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalTxt As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExportarDetalle As System.Windows.Forms.Button
    Friend WithEvents lvDetalle As System.Windows.Forms.ListView
    Friend WithEvents det_Nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_ruc As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_moneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_cotiza As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_texenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_gra5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_gra10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_nroCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_mercaderia As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_exenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_gravada As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_incluido As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_nroDetalle As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_porIVA As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_iva5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_iva10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_ivaMonto As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_timbrado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTotalIVA5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIva10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents det_formaPago As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents det_archivo As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_nota As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_cuotas As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_centroCosto As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_estado As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_formulario As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_formularioReferencia As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_codigoImpuesto As System.Windows.Forms.ColumnHeader
End Class
