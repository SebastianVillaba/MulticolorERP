<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteCompraGasto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCompraGasto))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdResumenGasto = New System.Windows.Forms.RadioButton()
        Me.rdResumenCompra = New System.Windows.Forms.RadioButton()
        Me.rdGasto = New System.Windows.Forms.RadioButton()
        Me.rdCompra = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboEmpresaContable = New System.Windows.Forms.ComboBox()
        Me.grGasto = New System.Windows.Forms.GroupBox()
        Me.lblNombreCuenta = New System.Windows.Forms.Label()
        Me.lblIdCuenta = New System.Windows.Forms.Label()
        Me.rdCuenta = New System.Windows.Forms.RadioButton()
        Me.rdNoDeducible = New System.Windows.Forms.RadioButton()
        Me.rdDeducible = New System.Windows.Forms.RadioButton()
        Me.rdTodoGasto = New System.Windows.Forms.RadioButton()
        Me.chkProveedor = New System.Windows.Forms.CheckBox()
        Me.lblNombreProveedor = New System.Windows.Forms.Label()
        Me.lblIdProveedor = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboTipoEmpresa = New System.Windows.Forms.ComboBox()
        Me.chkTipoEmpresa = New System.Windows.Forms.CheckBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grGasto.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkTipoEmpresa)
        Me.GroupBox3.Controls.Add(Me.rdResumenGasto)
        Me.GroupBox3.Controls.Add(Me.rdResumenCompra)
        Me.GroupBox3.Controls.Add(Me.rdGasto)
        Me.GroupBox3.Controls.Add(Me.rdCompra)
        Me.GroupBox3.Location = New System.Drawing.Point(291, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(281, 74)
        Me.GroupBox3.TabIndex = 102
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdResumenGasto
        '
        Me.rdResumenGasto.AutoSize = True
        Me.rdResumenGasto.Location = New System.Drawing.Point(121, 42)
        Me.rdResumenGasto.Name = "rdResumenGasto"
        Me.rdResumenGasto.Size = New System.Drawing.Size(106, 17)
        Me.rdResumenGasto.TabIndex = 21
        Me.rdResumenGasto.Text = "Resumen Gastos"
        Me.rdResumenGasto.UseVisualStyleBackColor = True
        '
        'rdResumenCompra
        '
        Me.rdResumenCompra.AutoSize = True
        Me.rdResumenCompra.Location = New System.Drawing.Point(6, 42)
        Me.rdResumenCompra.Name = "rdResumenCompra"
        Me.rdResumenCompra.Size = New System.Drawing.Size(109, 17)
        Me.rdResumenCompra.TabIndex = 20
        Me.rdResumenCompra.Text = "Resumen Compra"
        Me.rdResumenCompra.UseVisualStyleBackColor = True
        '
        'rdGasto
        '
        Me.rdGasto.AutoSize = True
        Me.rdGasto.Location = New System.Drawing.Point(84, 19)
        Me.rdGasto.Name = "rdGasto"
        Me.rdGasto.Size = New System.Drawing.Size(58, 17)
        Me.rdGasto.TabIndex = 19
        Me.rdGasto.Text = "&Gastos"
        Me.rdGasto.UseVisualStyleBackColor = True
        '
        'rdCompra
        '
        Me.rdCompra.AutoSize = True
        Me.rdCompra.Checked = True
        Me.rdCompra.Location = New System.Drawing.Point(6, 19)
        Me.rdCompra.Name = "rdCompra"
        Me.rdCompra.Size = New System.Drawing.Size(66, 17)
        Me.rdCompra.TabIndex = 18
        Me.rdCompra.TabStop = True
        Me.rdCompra.Text = "C&ompras"
        Me.rdCompra.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 108)
        Me.GroupBox1.TabIndex = 101
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboEmpresaContable)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(354, 62)
        Me.GroupBox4.TabIndex = 103
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Empresa Contable"
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
        'grGasto
        '
        Me.grGasto.Controls.Add(Me.lblNombreCuenta)
        Me.grGasto.Controls.Add(Me.lblIdCuenta)
        Me.grGasto.Controls.Add(Me.rdCuenta)
        Me.grGasto.Controls.Add(Me.rdNoDeducible)
        Me.grGasto.Controls.Add(Me.rdDeducible)
        Me.grGasto.Controls.Add(Me.rdTodoGasto)
        Me.grGasto.Location = New System.Drawing.Point(293, 100)
        Me.grGasto.Name = "grGasto"
        Me.grGasto.Size = New System.Drawing.Size(233, 93)
        Me.grGasto.TabIndex = 103
        Me.grGasto.TabStop = False
        Me.grGasto.Text = "Opciones"
        Me.grGasto.Visible = False
        '
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.AutoSize = True
        Me.lblNombreCuenta.BackColor = System.Drawing.Color.Lime
        Me.lblNombreCuenta.Location = New System.Drawing.Point(43, 62)
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Size = New System.Drawing.Size(76, 13)
        Me.lblNombreCuenta.TabIndex = 23
        Me.lblNombreCuenta.Text = "nombreCuenta"
        '
        'lblIdCuenta
        '
        Me.lblIdCuenta.AutoSize = True
        Me.lblIdCuenta.BackColor = System.Drawing.Color.Lime
        Me.lblIdCuenta.Location = New System.Drawing.Point(6, 62)
        Me.lblIdCuenta.Name = "lblIdCuenta"
        Me.lblIdCuenta.Size = New System.Drawing.Size(31, 13)
        Me.lblIdCuenta.TabIndex = 22
        Me.lblIdCuenta.Text = "idCta"
        '
        'rdCuenta
        '
        Me.rdCuenta.AutoSize = True
        Me.rdCuenta.Location = New System.Drawing.Point(7, 42)
        Me.rdCuenta.Name = "rdCuenta"
        Me.rdCuenta.Size = New System.Drawing.Size(158, 17)
        Me.rdCuenta.TabIndex = 21
        Me.rdCuenta.Text = "Gastos por Cuenta Contable"
        Me.rdCuenta.UseVisualStyleBackColor = True
        '
        'rdNoDeducible
        '
        Me.rdNoDeducible.AutoSize = True
        Me.rdNoDeducible.Location = New System.Drawing.Point(142, 19)
        Me.rdNoDeducible.Name = "rdNoDeducible"
        Me.rdNoDeducible.Size = New System.Drawing.Size(90, 17)
        Me.rdNoDeducible.TabIndex = 20
        Me.rdNoDeducible.Text = "No Deducible"
        Me.rdNoDeducible.UseVisualStyleBackColor = True
        '
        'rdDeducible
        '
        Me.rdDeducible.AutoSize = True
        Me.rdDeducible.Location = New System.Drawing.Point(65, 19)
        Me.rdDeducible.Name = "rdDeducible"
        Me.rdDeducible.Size = New System.Drawing.Size(73, 17)
        Me.rdDeducible.TabIndex = 19
        Me.rdDeducible.Text = "Deducible"
        Me.rdDeducible.UseVisualStyleBackColor = True
        '
        'rdTodoGasto
        '
        Me.rdTodoGasto.AutoSize = True
        Me.rdTodoGasto.Checked = True
        Me.rdTodoGasto.Location = New System.Drawing.Point(6, 19)
        Me.rdTodoGasto.Name = "rdTodoGasto"
        Me.rdTodoGasto.Size = New System.Drawing.Size(55, 17)
        Me.rdTodoGasto.TabIndex = 18
        Me.rdTodoGasto.TabStop = True
        Me.rdTodoGasto.Text = "Todos"
        Me.rdTodoGasto.UseVisualStyleBackColor = True
        '
        'chkProveedor
        '
        Me.chkProveedor.AutoSize = True
        Me.chkProveedor.Location = New System.Drawing.Point(12, 126)
        Me.chkProveedor.Name = "chkProveedor"
        Me.chkProveedor.Size = New System.Drawing.Size(94, 17)
        Me.chkProveedor.TabIndex = 104
        Me.chkProveedor.Text = "Por Proveedor"
        Me.chkProveedor.UseVisualStyleBackColor = True
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.BackColor = System.Drawing.Color.Lime
        Me.lblNombreProveedor.Location = New System.Drawing.Point(49, 148)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(91, 13)
        Me.lblNombreProveedor.TabIndex = 106
        Me.lblNombreProveedor.Text = "nombreProveedor"
        '
        'lblIdProveedor
        '
        Me.lblIdProveedor.AutoSize = True
        Me.lblIdProveedor.BackColor = System.Drawing.Color.Lime
        Me.lblIdProveedor.Location = New System.Drawing.Point(12, 148)
        Me.lblIdProveedor.Name = "lblIdProveedor"
        Me.lblIdProveedor.Size = New System.Drawing.Size(37, 13)
        Me.lblIdProveedor.TabIndex = 105
        Me.lblIdProveedor.Text = "idProv"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboTipoEmpresa)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 263)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(354, 62)
        Me.GroupBox2.TabIndex = 104
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Empresa"
        '
        'cboTipoEmpresa
        '
        Me.cboTipoEmpresa.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoEmpresa.FormattingEnabled = True
        Me.cboTipoEmpresa.Location = New System.Drawing.Point(14, 26)
        Me.cboTipoEmpresa.Name = "cboTipoEmpresa"
        Me.cboTipoEmpresa.Size = New System.Drawing.Size(329, 24)
        Me.cboTipoEmpresa.TabIndex = 50
        '
        'chkTipoEmpresa
        '
        Me.chkTipoEmpresa.AutoSize = True
        Me.chkTipoEmpresa.Location = New System.Drawing.Point(148, 19)
        Me.chkTipoEmpresa.Name = "chkTipoEmpresa"
        Me.chkTipoEmpresa.Size = New System.Drawing.Size(125, 17)
        Me.chkTipoEmpresa.TabIndex = 107
        Me.chkTipoEmpresa.Text = "Por Tipo de Empresa"
        Me.chkTipoEmpresa.UseVisualStyleBackColor = True
        '
        'frmReporteCompraGasto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 335)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblNombreProveedor)
        Me.Controls.Add(Me.lblIdProveedor)
        Me.Controls.Add(Me.chkProveedor)
        Me.Controls.Add(Me.grGasto)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteCompraGasto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras & Gastos"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.grGasto.ResumeLayout(False)
        Me.grGasto.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdGasto As System.Windows.Forms.RadioButton
    Friend WithEvents rdCompra As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboEmpresaContable As System.Windows.Forms.ComboBox
    Friend WithEvents grGasto As System.Windows.Forms.GroupBox
    Friend WithEvents rdNoDeducible As System.Windows.Forms.RadioButton
    Friend WithEvents rdDeducible As System.Windows.Forms.RadioButton
    Friend WithEvents rdTodoGasto As System.Windows.Forms.RadioButton
    Friend WithEvents lblNombreCuenta As System.Windows.Forms.Label
    Friend WithEvents lblIdCuenta As System.Windows.Forms.Label
    Friend WithEvents rdCuenta As System.Windows.Forms.RadioButton
    Friend WithEvents chkProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents lblNombreProveedor As System.Windows.Forms.Label
    Friend WithEvents lblIdProveedor As System.Windows.Forms.Label
    Friend WithEvents rdResumenCompra As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumenGasto As System.Windows.Forms.RadioButton
    Friend WithEvents chkTipoEmpresa As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoEmpresa As System.Windows.Forms.ComboBox
End Class
