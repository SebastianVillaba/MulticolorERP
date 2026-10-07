<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteClienteProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteClienteProducto))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblIdMov = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdProductoCliente = New System.Windows.Forms.RadioButton()
        Me.rdClienteProducto = New System.Windows.Forms.RadioButton()
        Me.grSucursal = New System.Windows.Forms.GroupBox()
        Me.chkTodaSucursal = New System.Windows.Forms.CheckBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grSucursal.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(365, 133)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(233, 41)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 97
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(80, 78)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(129, 22)
        Me.dtpHastaFecha.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 78)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 20)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Hasta:"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(80, 36)
        Me.dtpDesdeFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(129, 22)
        Me.dtpDesdeFecha.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 20)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Desde:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblIdMov)
        Me.GroupBox2.Controls.Add(Me.lblNombre)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 238)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(543, 110)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'lblIdMov
        '
        Me.lblIdMov.AutoSize = True
        Me.lblIdMov.BackColor = System.Drawing.Color.Lime
        Me.lblIdMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdMov.Location = New System.Drawing.Point(24, 70)
        Me.lblIdMov.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdMov.Name = "lblIdMov"
        Me.lblIdMov.Size = New System.Drawing.Size(61, 24)
        Me.lblIdMov.TabIndex = 1
        Me.lblIdMov.Text = "idMov"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.BackColor = System.Drawing.Color.Lime
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(24, 36)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(93, 24)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "NOMBRE"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdProductoCliente)
        Me.GroupBox3.Controls.Add(Me.rdClienteProducto)
        Me.GroupBox3.Location = New System.Drawing.Point(392, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(209, 84)
        Me.GroupBox3.TabIndex = 103
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdProductoCliente
        '
        Me.rdProductoCliente.AutoSize = True
        Me.rdProductoCliente.Location = New System.Drawing.Point(8, 52)
        Me.rdProductoCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdProductoCliente.Name = "rdProductoCliente"
        Me.rdProductoCliente.Size = New System.Drawing.Size(158, 21)
        Me.rdProductoCliente.TabIndex = 19
        Me.rdProductoCliente.Text = "&Producto por Cliente"
        Me.rdProductoCliente.UseVisualStyleBackColor = True
        '
        'rdClienteProducto
        '
        Me.rdClienteProducto.AutoSize = True
        Me.rdClienteProducto.Location = New System.Drawing.Point(8, 23)
        Me.rdClienteProducto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdClienteProducto.Name = "rdClienteProducto"
        Me.rdClienteProducto.Size = New System.Drawing.Size(158, 21)
        Me.rdClienteProducto.TabIndex = 18
        Me.rdClienteProducto.Text = "Cli&ente por Producto"
        Me.rdClienteProducto.UseVisualStyleBackColor = True
        '
        'grSucursal
        '
        Me.grSucursal.Controls.Add(Me.chkTodaSucursal)
        Me.grSucursal.Controls.Add(Me.cboSucursal)
        Me.grSucursal.Location = New System.Drawing.Point(19, 135)
        Me.grSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grSucursal.Name = "grSucursal"
        Me.grSucursal.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grSucursal.Size = New System.Drawing.Size(471, 97)
        Me.grSucursal.TabIndex = 115
        Me.grSucursal.TabStop = False
        Me.grSucursal.Text = "Sucursal"
        '
        'chkTodaSucursal
        '
        Me.chkTodaSucursal.AutoSize = True
        Me.chkTodaSucursal.Checked = True
        Me.chkTodaSucursal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodaSucursal.Location = New System.Drawing.Point(5, 64)
        Me.chkTodaSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkTodaSucursal.Name = "chkTodaSucursal"
        Me.chkTodaSucursal.Size = New System.Drawing.Size(166, 21)
        Me.chkTodaSucursal.TabIndex = 109
        Me.chkTodaSucursal.Text = "Todas las Sucursales"
        Me.chkTodaSucursal.UseVisualStyleBackColor = True
        '
        'cboSucursal
        '
        Me.cboSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(8, 23)
        Me.cboSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(449, 28)
        Me.cboSucursal.TabIndex = 108
        '
        'frmReporteClienteProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 374)
        Me.Controls.Add(Me.grSucursal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteClienteProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Cliente por Producto y Producto por Cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grSucursal.ResumeLayout(False)
        Me.grSucursal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblIdMov As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdProductoCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rdClienteProducto As System.Windows.Forms.RadioButton
    Friend WithEvents grSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodaSucursal As System.Windows.Forms.CheckBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
