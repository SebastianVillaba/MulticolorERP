<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadisticaProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadisticaProveedor))
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdCantidadTodosLaboratorios = New System.Windows.Forms.RadioButton()
        Me.rdCantidadCompraLabo = New System.Windows.Forms.RadioButton()
        Me.rdPorcentajeBajoUtilidad = New System.Windows.Forms.RadioButton()
        Me.rdporcentajeCostoTodos = New System.Windows.Forms.RadioButton()
        Me.rdBaldeHelado = New System.Windows.Forms.RadioButton()
        Me.rdPorcentajeDivision = New System.Windows.Forms.RadioButton()
        Me.rdPorcentajeProductoProveedor = New System.Windows.Forms.RadioButton()
        Me.rdPorcentajeProducto = New System.Windows.Forms.RadioButton()
        Me.grFecha = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grDatoMercaderia = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblIdProveedor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIdLaboratorio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLaboratorio = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblIdProducto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.grOrdenar.SuspendLayout()
        Me.grFecha.SuspendLayout()
        Me.grDatoMercaderia.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdCantidadTodosLaboratorios)
        Me.grOrdenar.Controls.Add(Me.rdCantidadCompraLabo)
        Me.grOrdenar.Controls.Add(Me.rdPorcentajeBajoUtilidad)
        Me.grOrdenar.Controls.Add(Me.rdporcentajeCostoTodos)
        Me.grOrdenar.Controls.Add(Me.rdBaldeHelado)
        Me.grOrdenar.Controls.Add(Me.rdPorcentajeDivision)
        Me.grOrdenar.Controls.Add(Me.rdPorcentajeProductoProveedor)
        Me.grOrdenar.Controls.Add(Me.rdPorcentajeProducto)
        Me.grOrdenar.Location = New System.Drawing.Point(12, 12)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(420, 138)
        Me.grOrdenar.TabIndex = 101
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Opciones"
        '
        'rdCantidadTodosLaboratorios
        '
        Me.rdCantidadTodosLaboratorios.AutoSize = True
        Me.rdCantidadTodosLaboratorios.Location = New System.Drawing.Point(233, 62)
        Me.rdCantidadTodosLaboratorios.Name = "rdCantidadTodosLaboratorios"
        Me.rdCantidadTodosLaboratorios.Size = New System.Drawing.Size(185, 17)
        Me.rdCantidadTodosLaboratorios.TabIndex = 24
        Me.rdCantidadTodosLaboratorios.Text = "Cantidad x Todos los Laboratorios"
        Me.rdCantidadTodosLaboratorios.UseVisualStyleBackColor = True
        '
        'rdCantidadCompraLabo
        '
        Me.rdCantidadCompraLabo.AutoSize = True
        Me.rdCantidadCompraLabo.Location = New System.Drawing.Point(233, 41)
        Me.rdCantidadCompraLabo.Name = "rdCantidadCompraLabo"
        Me.rdCantidadCompraLabo.Size = New System.Drawing.Size(131, 17)
        Me.rdCantidadCompraLabo.TabIndex = 23
        Me.rdCantidadCompraLabo.Text = "Cantidad x Laboratorio"
        Me.rdCantidadCompraLabo.UseVisualStyleBackColor = True
        '
        'rdPorcentajeBajoUtilidad
        '
        Me.rdPorcentajeBajoUtilidad.AutoSize = True
        Me.rdPorcentajeBajoUtilidad.Location = New System.Drawing.Point(233, 20)
        Me.rdPorcentajeBajoUtilidad.Name = "rdPorcentajeBajoUtilidad"
        Me.rdPorcentajeBajoUtilidad.Size = New System.Drawing.Size(157, 17)
        Me.rdPorcentajeBajoUtilidad.TabIndex = 22
        Me.rdPorcentajeBajoUtilidad.Text = "Porcentaje bajos en Utilidad"
        Me.rdPorcentajeBajoUtilidad.UseVisualStyleBackColor = True
        '
        'rdporcentajeCostoTodos
        '
        Me.rdporcentajeCostoTodos.AutoSize = True
        Me.rdporcentajeCostoTodos.Location = New System.Drawing.Point(8, 108)
        Me.rdporcentajeCostoTodos.Name = "rdporcentajeCostoTodos"
        Me.rdporcentajeCostoTodos.Size = New System.Drawing.Size(191, 17)
        Me.rdporcentajeCostoTodos.TabIndex = 21
        Me.rdporcentajeCostoTodos.Text = "Porcetanje de Costo del Stock Gral"
        Me.rdporcentajeCostoTodos.UseVisualStyleBackColor = True
        '
        'rdBaldeHelado
        '
        Me.rdBaldeHelado.AutoSize = True
        Me.rdBaldeHelado.Location = New System.Drawing.Point(8, 86)
        Me.rdBaldeHelado.Name = "rdBaldeHelado"
        Me.rdBaldeHelado.Size = New System.Drawing.Size(169, 17)
        Me.rdBaldeHelado.TabIndex = 20
        Me.rdBaldeHelado.Text = "Cantidad de Balde de Helados"
        Me.rdBaldeHelado.UseVisualStyleBackColor = True
        '
        'rdPorcentajeDivision
        '
        Me.rdPorcentajeDivision.AutoSize = True
        Me.rdPorcentajeDivision.Location = New System.Drawing.Point(8, 63)
        Me.rdPorcentajeDivision.Name = "rdPorcentajeDivision"
        Me.rdPorcentajeDivision.Size = New System.Drawing.Size(142, 17)
        Me.rdPorcentajeDivision.TabIndex = 19
        Me.rdPorcentajeDivision.Text = "Porcentaje de Divisiones"
        Me.rdPorcentajeDivision.UseVisualStyleBackColor = True
        '
        'rdPorcentajeProductoProveedor
        '
        Me.rdPorcentajeProductoProveedor.AutoSize = True
        Me.rdPorcentajeProductoProveedor.Location = New System.Drawing.Point(8, 41)
        Me.rdPorcentajeProductoProveedor.Name = "rdPorcentajeProductoProveedor"
        Me.rdPorcentajeProductoProveedor.Size = New System.Drawing.Size(218, 17)
        Me.rdPorcentajeProductoProveedor.TabIndex = 18
        Me.rdPorcentajeProductoProveedor.Text = "Porcentaje de Producto por Proveedores"
        Me.rdPorcentajeProductoProveedor.UseVisualStyleBackColor = True
        '
        'rdPorcentajeProducto
        '
        Me.rdPorcentajeProducto.AutoSize = True
        Me.rdPorcentajeProducto.Location = New System.Drawing.Point(8, 20)
        Me.rdPorcentajeProducto.Name = "rdPorcentajeProducto"
        Me.rdPorcentajeProducto.Size = New System.Drawing.Size(184, 17)
        Me.rdPorcentajeProducto.TabIndex = 17
        Me.rdPorcentajeProducto.Text = "Porcentaje de Compra x Producto"
        Me.rdPorcentajeProducto.UseVisualStyleBackColor = True
        '
        'grFecha
        '
        Me.grFecha.Controls.Add(Me.dtpHastaFecha)
        Me.grFecha.Controls.Add(Me.Label6)
        Me.grFecha.Controls.Add(Me.dtpDesdeFecha)
        Me.grFecha.Controls.Add(Me.Label5)
        Me.grFecha.Location = New System.Drawing.Point(443, 12)
        Me.grFecha.Name = "grFecha"
        Me.grFecha.Size = New System.Drawing.Size(185, 95)
        Me.grFecha.TabIndex = 107
        Me.grFecha.TabStop = False
        Me.grFecha.Text = "Fecha "
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(60, 63)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(108, 20)
        Me.dtpHastaFecha.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Hasta:"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(60, 29)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(108, 20)
        Me.dtpDesdeFecha.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Desde:"
        '
        'grDatoMercaderia
        '
        Me.grDatoMercaderia.Controls.Add(Me.Label2)
        Me.grDatoMercaderia.Controls.Add(Me.lblIdProveedor)
        Me.grDatoMercaderia.Controls.Add(Me.Label1)
        Me.grDatoMercaderia.Controls.Add(Me.lblProveedor)
        Me.grDatoMercaderia.Location = New System.Drawing.Point(10, 155)
        Me.grDatoMercaderia.Name = "grDatoMercaderia"
        Me.grDatoMercaderia.Size = New System.Drawing.Size(435, 100)
        Me.grDatoMercaderia.TabIndex = 112
        Me.grDatoMercaderia.TabStop = False
        Me.grDatoMercaderia.Text = "Datos del Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Codigo:"
        '
        'lblIdProveedor
        '
        Me.lblIdProveedor.AutoSize = True
        Me.lblIdProveedor.BackColor = System.Drawing.Color.Gold
        Me.lblIdProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProveedor.Location = New System.Drawing.Point(60, 61)
        Me.lblIdProveedor.Name = "lblIdProveedor"
        Me.lblIdProveedor.Size = New System.Drawing.Size(129, 18)
        Me.lblIdProveedor.TabIndex = 109
        Me.lblIdProveedor.Text = "IDPROVEEDOR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Proveedor:"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.BackColor = System.Drawing.Color.Lime
        Me.lblProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProveedor.Location = New System.Drawing.Point(86, 30)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(113, 18)
        Me.lblProveedor.TabIndex = 107
        Me.lblProveedor.Text = "PROVEEDOR"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(639, 20)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(69, 37)
        Me.btnConsultar.TabIndex = 113
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblIdLaboratorio)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblLaboratorio)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 262)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 100)
        Me.GroupBox1.TabIndex = 113
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Laboratorio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Codigo:"
        '
        'lblIdLaboratorio
        '
        Me.lblIdLaboratorio.AutoSize = True
        Me.lblIdLaboratorio.BackColor = System.Drawing.Color.Gold
        Me.lblIdLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdLaboratorio.Location = New System.Drawing.Point(60, 61)
        Me.lblIdLaboratorio.Name = "lblIdLaboratorio"
        Me.lblIdLaboratorio.Size = New System.Drawing.Size(141, 18)
        Me.lblIdLaboratorio.TabIndex = 109
        Me.lblIdLaboratorio.Text = "IDLABORATORIO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Laboratorio:"
        '
        'lblLaboratorio
        '
        Me.lblLaboratorio.AutoSize = True
        Me.lblLaboratorio.BackColor = System.Drawing.Color.Lime
        Me.lblLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaboratorio.Location = New System.Drawing.Point(86, 30)
        Me.lblLaboratorio.Name = "lblLaboratorio"
        Me.lblLaboratorio.Size = New System.Drawing.Size(125, 18)
        Me.lblLaboratorio.TabIndex = 107
        Me.lblLaboratorio.Text = "LABORATORIO"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblIdProducto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblCodigo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblProducto)
        Me.GroupBox2.Location = New System.Drawing.Point(451, 155)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(435, 100)
        Me.GroupBox2.TabIndex = 113
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Producto"
        '
        'lblIdProducto
        '
        Me.lblIdProducto.AutoSize = True
        Me.lblIdProducto.BackColor = System.Drawing.Color.Gold
        Me.lblIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProducto.Location = New System.Drawing.Point(141, 61)
        Me.lblIdProducto.Name = "lblIdProducto"
        Me.lblIdProducto.Size = New System.Drawing.Size(119, 18)
        Me.lblIdProducto.TabIndex = 112
        Me.lblIdProducto.Text = "IDPRODUCTO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Codigo:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Gold
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(60, 61)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(75, 18)
        Me.lblCodigo.TabIndex = 109
        Me.lblCodigo.Text = "CODIGO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 16)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Producto:"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.Color.Lime
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(72, 30)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(103, 18)
        Me.lblProducto.TabIndex = 107
        Me.lblProducto.Text = "PRODUCTO"
        '
        'frmEstadisticaProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 374)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.grDatoMercaderia)
        Me.Controls.Add(Me.grFecha)
        Me.Controls.Add(Me.grOrdenar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstadisticaProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadísticas de Proveedores"
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.grFecha.ResumeLayout(False)
        Me.grFecha.PerformLayout()
        Me.grDatoMercaderia.ResumeLayout(False)
        Me.grDatoMercaderia.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdPorcentajeProducto As System.Windows.Forms.RadioButton
    Friend WithEvents grFecha As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grDatoMercaderia As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblIdProveedor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents rdPorcentajeDivision As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorcentajeProductoProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIdLaboratorio As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblLaboratorio As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblIdProducto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents rdBaldeHelado As System.Windows.Forms.RadioButton
    Friend WithEvents rdporcentajeCostoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorcentajeBajoUtilidad As System.Windows.Forms.RadioButton
    Friend WithEvents rdCantidadCompraLabo As System.Windows.Forms.RadioButton
    Friend WithEvents rdCantidadTodosLaboratorios As System.Windows.Forms.RadioButton
End Class
