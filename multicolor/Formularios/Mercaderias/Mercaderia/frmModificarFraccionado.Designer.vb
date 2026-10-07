<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificarFraccionado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificarFraccionado))
        Me.lvFraccionado = New System.Windows.Forms.ListView()
        Me.detFraccionado_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detFraccionado_Forma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detFraccionado_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detFraccionado_cantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detFraccionado_idForma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblForma = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMercaderia = New System.Windows.Forms.Label()
        Me.lblidForma = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblIdProducto = New System.Windows.Forms.Label()
        Me.txtFechaMod = New System.Windows.Forms.TextBox()
        Me.txtFechaAlta = New System.Windows.Forms.TextBox()
        Me.txtUsuarioMod = New System.Windows.Forms.TextBox()
        Me.txtUsuarioAlta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvFraccionado
        '
        Me.lvFraccionado.AllowColumnReorder = True
        Me.lvFraccionado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detFraccionado_nro, Me.detFraccionado_Forma, Me.detFraccionado_precio, Me.detFraccionado_cantidad, Me.detFraccionado_idForma})
        Me.lvFraccionado.FullRowSelect = True
        Me.lvFraccionado.GridLines = True
        Me.lvFraccionado.HideSelection = False
        Me.lvFraccionado.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvFraccionado.LabelWrap = False
        Me.lvFraccionado.Location = New System.Drawing.Point(9, 132)
        Me.lvFraccionado.MultiSelect = False
        Me.lvFraccionado.Name = "lvFraccionado"
        Me.lvFraccionado.Size = New System.Drawing.Size(277, 95)
        Me.lvFraccionado.TabIndex = 122
        Me.lvFraccionado.UseCompatibleStateImageBehavior = False
        Me.lvFraccionado.View = System.Windows.Forms.View.Details
        '
        'detFraccionado_nro
        '
        Me.detFraccionado_nro.Text = "Nro."
        Me.detFraccionado_nro.Width = 40
        '
        'detFraccionado_Forma
        '
        Me.detFraccionado_Forma.Text = "Forma"
        Me.detFraccionado_Forma.Width = 100
        '
        'detFraccionado_precio
        '
        Me.detFraccionado_precio.Text = "Precio"
        Me.detFraccionado_precio.Width = 80
        '
        'detFraccionado_cantidad
        '
        Me.detFraccionado_cantidad.Text = "Cant."
        Me.detFraccionado_cantidad.Width = 50
        '
        'detFraccionado_idForma
        '
        Me.detFraccionado_idForma.Text = "IdForma"
        Me.detFraccionado_idForma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.detFraccionado_idForma.Width = 70
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblPrecio)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtPrecio)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Panel2)
        Me.GroupBox4.Controls.Add(Me.Panel1)
        Me.GroupBox4.Controls.Add(Me.lblidForma)
        Me.GroupBox4.Controls.Add(Me.btnCargar)
        Me.GroupBox4.Controls.Add(Me.txtCantidad)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.lblCodigo)
        Me.GroupBox4.Controls.Add(Me.lblIdProducto)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(550, 114)
        Me.GroupBox4.TabIndex = 121
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mercaderías"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.BackColor = System.Drawing.Color.Yellow
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.ForeColor = System.Drawing.Color.Blue
        Me.lblPrecio.Location = New System.Drawing.Point(310, 86)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(46, 16)
        Me.lblPrecio.TabIndex = 17
        Me.lblPrecio.Text = "precio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(213, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Precio Fraccion:"
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.LightBlue
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(313, 52)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.Size = New System.Drawing.Size(82, 21)
        Me.txtPrecio.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Precio del Entero:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblForma)
        Me.Panel2.Location = New System.Drawing.Point(119, 51)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(75, 20)
        Me.Panel2.TabIndex = 13
        '
        'lblForma
        '
        Me.lblForma.AutoSize = True
        Me.lblForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForma.ForeColor = System.Drawing.Color.Blue
        Me.lblForma.Location = New System.Drawing.Point(4, 3)
        Me.lblForma.Name = "lblForma"
        Me.lblForma.Size = New System.Drawing.Size(42, 16)
        Me.lblForma.TabIndex = 8
        Me.lblForma.Text = "forma"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblMercaderia)
        Me.Panel1.Location = New System.Drawing.Point(115, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(265, 19)
        Me.Panel1.TabIndex = 11
        '
        'lblMercaderia
        '
        Me.lblMercaderia.AutoSize = True
        Me.lblMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercaderia.ForeColor = System.Drawing.Color.Blue
        Me.lblMercaderia.Location = New System.Drawing.Point(4, 1)
        Me.lblMercaderia.Name = "lblMercaderia"
        Me.lblMercaderia.Size = New System.Drawing.Size(77, 16)
        Me.lblMercaderia.TabIndex = 4
        Me.lblMercaderia.Text = "mercaderia"
        '
        'lblidForma
        '
        Me.lblidForma.AutoSize = True
        Me.lblidForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidForma.ForeColor = System.Drawing.Color.Blue
        Me.lblidForma.Location = New System.Drawing.Point(393, 23)
        Me.lblidForma.Name = "lblidForma"
        Me.lblidForma.Size = New System.Drawing.Size(58, 16)
        Me.lblidForma.TabIndex = 10
        Me.lblidForma.Text = "idForma"
        '
        'btnCargar
        '
        Me.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.Location = New System.Drawing.Point(410, 45)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(69, 37)
        Me.btnCargar.TabIndex = 9
        Me.btnCargar.Text = "Ca&rgar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.LightBlue
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(72, 52)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(40, 21)
        Me.txtCantidad.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 15)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Cantidad:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Blue
        Me.lblCodigo.Location = New System.Drawing.Point(62, 19)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(50, 16)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "codigo"
        '
        'lblIdProducto
        '
        Me.lblIdProducto.AutoSize = True
        Me.lblIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProducto.ForeColor = System.Drawing.Color.Blue
        Me.lblIdProducto.Location = New System.Drawing.Point(6, 19)
        Me.lblIdProducto.Name = "lblIdProducto"
        Me.lblIdProducto.Size = New System.Drawing.Size(48, 16)
        Me.lblIdProducto.TabIndex = 1
        Me.lblIdProducto.Text = "idProd"
        '
        'txtFechaMod
        '
        Me.txtFechaMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaMod.Enabled = False
        Me.txtFechaMod.Location = New System.Drawing.Point(334, 267)
        Me.txtFechaMod.Name = "txtFechaMod"
        Me.txtFechaMod.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaMod.TabIndex = 120
        '
        'txtFechaAlta
        '
        Me.txtFechaAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtFechaAlta.Enabled = False
        Me.txtFechaAlta.Location = New System.Drawing.Point(334, 246)
        Me.txtFechaAlta.Name = "txtFechaAlta"
        Me.txtFechaAlta.Size = New System.Drawing.Size(142, 20)
        Me.txtFechaAlta.TabIndex = 119
        '
        'txtUsuarioMod
        '
        Me.txtUsuarioMod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioMod.Enabled = False
        Me.txtUsuarioMod.Location = New System.Drawing.Point(109, 267)
        Me.txtUsuarioMod.Name = "txtUsuarioMod"
        Me.txtUsuarioMod.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioMod.TabIndex = 118
        '
        'txtUsuarioAlta
        '
        Me.txtUsuarioAlta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtUsuarioAlta.Enabled = False
        Me.txtUsuarioAlta.Location = New System.Drawing.Point(109, 246)
        Me.txtUsuarioAlta.Name = "txtUsuarioAlta"
        Me.txtUsuarioAlta.Size = New System.Drawing.Size(221, 20)
        Me.txtUsuarioAlta.TabIndex = 116
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 249)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Usuario Creador :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Location = New System.Drawing.Point(317, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 71)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controles"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(13, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 63
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(86, 19)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 62
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmModificarFraccionado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 316)
        Me.Controls.Add(Me.lvFraccionado)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.txtFechaMod)
        Me.Controls.Add(Me.txtFechaAlta)
        Me.Controls.Add(Me.txtUsuarioMod)
        Me.Controls.Add(Me.txtUsuarioAlta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmModificarFraccionado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Cantidad en Fraccionados"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvFraccionado As System.Windows.Forms.ListView
    Friend WithEvents detFraccionado_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents detFraccionado_Forma As System.Windows.Forms.ColumnHeader
    Friend WithEvents detFraccionado_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents detFraccionado_cantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents detFraccionado_idForma As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblForma As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMercaderia As System.Windows.Forms.Label
    Friend WithEvents lblidForma As System.Windows.Forms.Label
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblIdProducto As System.Windows.Forms.Label
    Friend WithEvents txtFechaMod As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAlta As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioMod As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioAlta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
