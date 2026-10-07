<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCantidadVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCantidadVenta))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCantidadNueva = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtForma = New System.Windows.Forms.TextBox()
        Me.txtMercaderia = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNro = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.grDescuento = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtContra = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lvPrecio = New System.Windows.Forms.ListView()
        Me.lvPrecio_precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPrecio_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.grDescuento.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCantidadNueva)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.txtForma)
        Me.GroupBox1.Controls.Add(Me.txtMercaderia)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.txtNro)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 179)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(958, 86)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(793, 15)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 17)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Cantidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(706, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Precio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(607, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Forma"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(317, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Mercadería"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(75, 15)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Codigo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 17)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Nro"
        '
        'txtCantidadNueva
        '
        Me.txtCantidadNueva.BackColor = System.Drawing.Color.White
        Me.txtCantidadNueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadNueva.Location = New System.Drawing.Point(874, 33)
        Me.txtCantidadNueva.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCantidadNueva.MaxLength = 60
        Me.txtCantidadNueva.Name = "txtCantidadNueva"
        Me.txtCantidadNueva.Size = New System.Drawing.Size(68, 26)
        Me.txtCantidadNueva.TabIndex = 102
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.Yellow
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(783, 33)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCantidad.MaxLength = 60
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(84, 26)
        Me.txtCantidad.TabIndex = 101
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.MistyRose
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(694, 34)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPrecio.MaxLength = 60
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.Size = New System.Drawing.Size(84, 26)
        Me.txtPrecio.TabIndex = 100
        '
        'txtForma
        '
        Me.txtForma.BackColor = System.Drawing.Color.LightBlue
        Me.txtForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForma.Location = New System.Drawing.Point(581, 34)
        Me.txtForma.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtForma.MaxLength = 60
        Me.txtForma.Name = "txtForma"
        Me.txtForma.ReadOnly = True
        Me.txtForma.Size = New System.Drawing.Size(104, 26)
        Me.txtForma.TabIndex = 98
        '
        'txtMercaderia
        '
        Me.txtMercaderia.BackColor = System.Drawing.Color.LightBlue
        Me.txtMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMercaderia.Location = New System.Drawing.Point(147, 34)
        Me.txtMercaderia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMercaderia.MaxLength = 60
        Me.txtMercaderia.Name = "txtMercaderia"
        Me.txtMercaderia.ReadOnly = True
        Me.txtMercaderia.Size = New System.Drawing.Size(433, 26)
        Me.txtMercaderia.TabIndex = 97
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.LightBlue
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(61, 34)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigo.MaxLength = 60
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(81, 26)
        Me.txtCodigo.TabIndex = 96
        '
        'txtNro
        '
        Me.txtNro.BackColor = System.Drawing.Color.LightBlue
        Me.txtNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNro.Location = New System.Drawing.Point(7, 34)
        Me.txtNro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNro.MaxLength = 60
        Me.txtNro.Name = "txtNro"
        Me.txtNro.ReadOnly = True
        Me.txtNro.Size = New System.Drawing.Size(52, 26)
        Me.txtNro.TabIndex = 95
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(982, 203)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(92, 46)
        Me.btnAgregar.TabIndex = 110
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'grDescuento
        '
        Me.grDescuento.BackColor = System.Drawing.Color.Turquoise
        Me.grDescuento.Controls.Add(Me.lvPrecio)
        Me.grDescuento.Controls.Add(Me.txtContra)
        Me.grDescuento.Controls.Add(Me.Label9)
        Me.grDescuento.Controls.Add(Me.txtUsuario)
        Me.grDescuento.Controls.Add(Me.Label8)
        Me.grDescuento.Location = New System.Drawing.Point(23, 12)
        Me.grDescuento.Name = "grDescuento"
        Me.grDescuento.Size = New System.Drawing.Size(573, 164)
        Me.grDescuento.TabIndex = 111
        Me.grDescuento.TabStop = False
        Me.grDescuento.Text = "DESCUENTO ESPECIAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(63, 42)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 20)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "USUARIO:"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.White
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(162, 41)
        Me.txtUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(160, 26)
        Me.txtUsuario.TabIndex = 111
        '
        'txtContra
        '
        Me.txtContra.BackColor = System.Drawing.Color.White
        Me.txtContra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContra.Location = New System.Drawing.Point(160, 90)
        Me.txtContra.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContra.MaxLength = 20
        Me.txtContra.Name = "txtContra"
        Me.txtContra.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContra.Size = New System.Drawing.Size(160, 26)
        Me.txtContra.TabIndex = 113
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 91)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 20)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "CONTRASEÑA:"
        '
        'lvPrecio
        '
        Me.lvPrecio.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvPrecio_precio, Me.lvPrecio_id})
        Me.lvPrecio.Location = New System.Drawing.Point(397, 16)
        Me.lvPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.lvPrecio.Name = "lvPrecio"
        Me.lvPrecio.Size = New System.Drawing.Size(135, 139)
        Me.lvPrecio.TabIndex = 114
        Me.lvPrecio.UseCompatibleStateImageBehavior = False
        Me.lvPrecio.View = System.Windows.Forms.View.Details
        '
        'lvPrecio_precio
        '
        Me.lvPrecio_precio.Text = "Precio"
        Me.lvPrecio_precio.Width = 90
        '
        'lvPrecio_id
        '
        Me.lvPrecio_id.Text = "IDDet"
        Me.lvPrecio_id.Width = 55
        '
        'frmCantidadVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 275)
        Me.Controls.Add(Me.grDescuento)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCantidadVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Cantidad en Ventas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grDescuento.ResumeLayout(False)
        Me.grDescuento.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadNueva As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtForma As System.Windows.Forms.TextBox
    Friend WithEvents txtMercaderia As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents grDescuento As System.Windows.Forms.GroupBox
    Friend WithEvents txtContra As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lvPrecio As System.Windows.Forms.ListView
    Friend WithEvents lvPrecio_precio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecio_id As System.Windows.Forms.ColumnHeader
End Class
