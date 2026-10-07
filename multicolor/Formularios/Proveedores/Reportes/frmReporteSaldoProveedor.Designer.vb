<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteSaldoProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteSaldoProveedor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdDetalle = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdSaldoResumidoProveedor = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdProveedor = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkContable = New System.Windows.Forms.CheckBox()
        Me.cboEmpresaContable = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 108)
        Me.GroupBox1.TabIndex = 102
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha "
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(194, 38)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(69, 37)
        Me.btnConsultar.TabIndex = 94
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        'rdDetalle
        '
        Me.rdDetalle.AutoSize = True
        Me.rdDetalle.Location = New System.Drawing.Point(6, 42)
        Me.rdDetalle.Name = "rdDetalle"
        Me.rdDetalle.Size = New System.Drawing.Size(70, 17)
        Me.rdDetalle.TabIndex = 19
        Me.rdDetalle.Text = "&Detallado"
        Me.rdDetalle.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdDetalle)
        Me.GroupBox3.Controls.Add(Me.rdSaldoResumidoProveedor)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 204)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(208, 91)
        Me.GroupBox3.TabIndex = 103
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdSaldoResumidoProveedor
        '
        Me.rdSaldoResumidoProveedor.AutoSize = True
        Me.rdSaldoResumidoProveedor.Checked = True
        Me.rdSaldoResumidoProveedor.Location = New System.Drawing.Point(6, 19)
        Me.rdSaldoResumidoProveedor.Name = "rdSaldoResumidoProveedor"
        Me.rdSaldoResumidoProveedor.Size = New System.Drawing.Size(180, 17)
        Me.rdSaldoResumidoProveedor.TabIndex = 18
        Me.rdSaldoResumidoProveedor.TabStop = True
        Me.rdSaldoResumidoProveedor.Text = "Saldo Resumido de Proveedores"
        Me.rdSaldoResumidoProveedor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 308)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Proveedor:"
        '
        'lblIdProveedor
        '
        Me.lblIdProveedor.AutoSize = True
        Me.lblIdProveedor.BackColor = System.Drawing.Color.Yellow
        Me.lblIdProveedor.Location = New System.Drawing.Point(82, 308)
        Me.lblIdProveedor.Name = "lblIdProveedor"
        Me.lblIdProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblIdProveedor.TabIndex = 105
        Me.lblIdProveedor.Text = "idProv."
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.BackColor = System.Drawing.Color.Yellow
        Me.lblProveedor.Location = New System.Drawing.Point(128, 308)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 106
        Me.lblProveedor.Text = "Proveedor"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkContable)
        Me.GroupBox4.Controls.Add(Me.cboEmpresaContable)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 118)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(354, 85)
        Me.GroupBox4.TabIndex = 107
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Empresa Contable"
        '
        'chkContable
        '
        Me.chkContable.AutoSize = True
        Me.chkContable.Location = New System.Drawing.Point(14, 56)
        Me.chkContable.Name = "chkContable"
        Me.chkContable.Size = New System.Drawing.Size(56, 17)
        Me.chkContable.TabIndex = 52
        Me.chkContable.Text = "Todos"
        Me.chkContable.UseVisualStyleBackColor = True
        '
        'cboEmpresaContable
        '
        Me.cboEmpresaContable.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboEmpresaContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresaContable.FormattingEnabled = True
        Me.cboEmpresaContable.Location = New System.Drawing.Point(14, 26)
        Me.cboEmpresaContable.Name = "cboEmpresaContable"
        Me.cboEmpresaContable.Size = New System.Drawing.Size(329, 24)
        Me.cboEmpresaContable.TabIndex = 50
        '
        'frmReporteSaldoProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 342)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lblProveedor)
        Me.Controls.Add(Me.lblIdProveedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteSaldoProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Saldo de Proveedores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdSaldoResumidoProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIdProveedor As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkContable As System.Windows.Forms.CheckBox
    Friend WithEvents cboEmpresaContable As System.Windows.Forms.ComboBox
End Class
