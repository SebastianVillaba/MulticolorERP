<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuardarCompra
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuardarCompra))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTipoSucursal = New System.Windows.Forms.ComboBox()
        Me.chkEfectivo = New System.Windows.Forms.CheckBox()
        Me.chkCompra = New System.Windows.Forms.CheckBox()
        Me.txtCotizacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDeposito = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.maskFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.maskVence = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkCredito = New System.Windows.Forms.CheckBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTimbrado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboTipoSucursal)
        Me.GroupBox1.Controls.Add(Me.chkEfectivo)
        Me.GroupBox1.Controls.Add(Me.chkCompra)
        Me.GroupBox1.Controls.Add(Me.txtCotizacion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtMoneda)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblDeposito)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.maskFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.maskVence)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chkCredito)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtTimbrado)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.txtDcaja)
        Me.GroupBox1.Controls.Add(Me.txtDsuc)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 27)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(984, 224)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(600, 140)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 25)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = "Tipo Empresa:"
        '
        'cboTipoSucursal
        '
        Me.cboTipoSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.cboTipoSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoSucursal.FormattingEnabled = True
        Me.cboTipoSucursal.Location = New System.Drawing.Point(749, 138)
        Me.cboTipoSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboTipoSucursal.Name = "cboTipoSucursal"
        Me.cboTipoSucursal.Size = New System.Drawing.Size(228, 28)
        Me.cboTipoSucursal.TabIndex = 131
        '
        'chkEfectivo
        '
        Me.chkEfectivo.AutoSize = True
        Me.chkEfectivo.Checked = True
        Me.chkEfectivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEfectivo.Location = New System.Drawing.Point(645, 102)
        Me.chkEfectivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkEfectivo.Name = "chkEfectivo"
        Me.chkEfectivo.Size = New System.Drawing.Size(181, 29)
        Me.chkEfectivo.TabIndex = 130
        Me.chkEfectivo.Text = "Pago en Efectivo"
        Me.chkEfectivo.UseVisualStyleBackColor = True
        '
        'chkCompra
        '
        Me.chkCompra.AutoSize = True
        Me.chkCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCompra.Location = New System.Drawing.Point(645, 65)
        Me.chkCompra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkCompra.Name = "chkCompra"
        Me.chkCompra.Size = New System.Drawing.Size(179, 29)
        Me.chkCompra.TabIndex = 74
        Me.chkCompra.Text = "Habilitar Compra"
        Me.chkCompra.UseVisualStyleBackColor = True
        '
        'txtCotizacion
        '
        Me.txtCotizacion.BackColor = System.Drawing.Color.LightBlue
        Me.txtCotizacion.Enabled = False
        Me.txtCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCotizacion.Location = New System.Drawing.Point(409, 138)
        Me.txtCotizacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCotizacion.MaxLength = 7
        Me.txtCotizacion.Name = "txtCotizacion"
        Me.txtCotizacion.Size = New System.Drawing.Size(181, 26)
        Me.txtCotizacion.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(292, 137)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 25)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Cotización:"
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.LightBlue
        Me.txtMoneda.Enabled = False
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(101, 138)
        Me.txtMoneda.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMoneda.MaxLength = 7
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(181, 26)
        Me.txtMoneda.TabIndex = 72
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 137)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 25)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Moneda:"
        '
        'lblDeposito
        '
        Me.lblDeposito.AutoSize = True
        Me.lblDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeposito.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDeposito.Location = New System.Drawing.Point(199, 188)
        Me.lblDeposito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeposito.Name = "lblDeposito"
        Me.lblDeposito.Size = New System.Drawing.Size(192, 24)
        Me.lblDeposito.TabIndex = 69
        Me.lblDeposito.Text = "Deposito - Sucursal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 187)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(177, 25)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Deposito Sucursal:"
        '
        'maskFecha
        '
        Me.maskFecha.BackColor = System.Drawing.SystemColors.Window
        Me.maskFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maskFecha.Location = New System.Drawing.Point(500, 81)
        Me.maskFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.maskFecha.Mask = "00/00/0000"
        Me.maskFecha.Name = "maskFecha"
        Me.maskFecha.Size = New System.Drawing.Size(99, 26)
        Me.maskFecha.TabIndex = 2
        Me.maskFecha.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(420, 84)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 25)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Fecha:"
        '
        'maskVence
        '
        Me.maskVence.BackColor = System.Drawing.Color.LightBlue
        Me.maskVence.Enabled = False
        Me.maskVence.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maskVence.Location = New System.Drawing.Point(309, 81)
        Me.maskVence.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.maskVence.Mask = "00/00/0000"
        Me.maskVence.Name = "maskVence"
        Me.maskVence.Size = New System.Drawing.Size(99, 26)
        Me.maskVence.TabIndex = 1
        Me.maskVence.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(223, 84)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 25)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Vence:"
        '
        'chkCredito
        '
        Me.chkCredito.AutoSize = True
        Me.chkCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCredito.Location = New System.Drawing.Point(13, 82)
        Me.chkCredito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkCredito.Name = "chkCredito"
        Me.chkCredito.Size = New System.Drawing.Size(184, 29)
        Me.chkCredito.TabIndex = 0
        Me.chkCredito.Text = "Factura a Crédito"
        Me.chkCredito.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.LightBlue
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(645, 32)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProveedor.MaxLength = 60
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(292, 26)
        Me.txtProveedor.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(524, 32)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 25)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Proveedor:"
        '
        'txtTimbrado
        '
        Me.txtTimbrado.BackColor = System.Drawing.Color.LightBlue
        Me.txtTimbrado.Enabled = False
        Me.txtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimbrado.Location = New System.Drawing.Point(395, 32)
        Me.txtTimbrado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTimbrado.MaxLength = 7
        Me.txtTimbrado.Name = "txtTimbrado"
        Me.txtTimbrado.Size = New System.Drawing.Size(120, 26)
        Me.txtTimbrado.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(289, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Timbrado:"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.LightBlue
        Me.txtFactura.Enabled = False
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(192, 32)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFactura.MaxLength = 7
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(88, 26)
        Me.txtFactura.TabIndex = 5
        '
        'txtDcaja
        '
        Me.txtDcaja.BackColor = System.Drawing.Color.LightBlue
        Me.txtDcaja.Enabled = False
        Me.txtDcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDcaja.Location = New System.Drawing.Point(145, 31)
        Me.txtDcaja.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDcaja.MaxLength = 3
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(40, 26)
        Me.txtDcaja.TabIndex = 4
        '
        'txtDsuc
        '
        Me.txtDsuc.BackColor = System.Drawing.Color.LightBlue
        Me.txtDsuc.Enabled = False
        Me.txtDsuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsuc.Location = New System.Drawing.Point(100, 31)
        Me.txtDsuc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDsuc.MaxLength = 3
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(40, 26)
        Me.txtDsuc.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Factura:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Location = New System.Drawing.Point(353, 265)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(147, 80)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controles"
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(28, 17)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
        Me.btnGuardar.TabIndex = 60
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSql.Location = New System.Drawing.Point(16, 363)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSql.MaxLength = 60
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(963, 26)
        Me.txtSql.TabIndex = 74
        Me.txtSql.Visible = False
        '
        'frmGuardarCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 394)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuardarCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardar Compra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents txtTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkCredito As System.Windows.Forms.CheckBox
    Friend WithEvents maskVence As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDeposito As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents chkCompra As System.Windows.Forms.CheckBox
    Friend WithEvents chkEfectivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboTipoSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
