<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarRetencionProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarRetencionProveedor))
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtIdRetencion = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdFactura = New System.Windows.Forms.RadioButton()
        Me.rdCliente = New System.Windows.Forms.RadioButton()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvVenta = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtIdRetencion)
        Me.grBuscar.Controls.Add(Me.txtFactura)
        Me.grBuscar.Controls.Add(Me.txtDcaja)
        Me.grBuscar.Controls.Add(Me.txtDsuc)
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.lvVenta)
        Me.grBuscar.Location = New System.Drawing.Point(12, 0)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(1038, 447)
        Me.grBuscar.TabIndex = 4
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtIdRetencion
        '
        Me.txtIdRetencion.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdRetencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdRetencion.Enabled = False
        Me.txtIdRetencion.Location = New System.Drawing.Point(276, 12)
        Me.txtIdRetencion.MaxLength = 3
        Me.txtIdRetencion.Name = "txtIdRetencion"
        Me.txtIdRetencion.Size = New System.Drawing.Size(55, 20)
        Me.txtIdRetencion.TabIndex = 22
        '
        'txtFactura
        '
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Location = New System.Drawing.Point(147, 49)
        Me.txtFactura.MaxLength = 7
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(78, 20)
        Me.txtFactura.TabIndex = 3
        '
        'txtDcaja
        '
        Me.txtDcaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDcaja.Location = New System.Drawing.Point(100, 49)
        Me.txtDcaja.MaxLength = 3
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(41, 20)
        Me.txtDcaja.TabIndex = 2
        '
        'txtDsuc
        '
        Me.txtDsuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDsuc.Location = New System.Drawing.Point(53, 49)
        Me.txtDsuc.MaxLength = 3
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(41, 20)
        Me.txtDsuc.TabIndex = 1
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdFactura)
        Me.grOrdenar.Controls.Add(Me.rdCliente)
        Me.grOrdenar.Location = New System.Drawing.Point(64, 11)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(194, 34)
        Me.grOrdenar.TabIndex = 18
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdFactura
        '
        Me.rdFactura.AutoSize = True
        Me.rdFactura.Checked = True
        Me.rdFactura.Location = New System.Drawing.Point(128, 13)
        Me.rdFactura.Name = "rdFactura"
        Me.rdFactura.Size = New System.Drawing.Size(61, 17)
        Me.rdFactura.TabIndex = 18
        Me.rdFactura.TabStop = True
        Me.rdFactura.Text = "Factura"
        Me.rdFactura.UseVisualStyleBackColor = True
        '
        'rdCliente
        '
        Me.rdCliente.AutoSize = True
        Me.rdCliente.Location = New System.Drawing.Point(8, 13)
        Me.rdCliente.Name = "rdCliente"
        Me.rdCliente.Size = New System.Drawing.Size(112, 17)
        Me.rdCliente.TabIndex = 17
        Me.rdCliente.Text = "Cliente e IDReten."
        Me.rdCliente.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 49)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(161, 20)
        Me.txtBuscar.TabIndex = 0
        Me.txtBuscar.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lvVenta
        '
        Me.lvVenta.AllowColumnReorder = True
        Me.lvVenta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvVenta.FullRowSelect = True
        Me.lvVenta.GridLines = True
        Me.lvVenta.HideSelection = False
        Me.lvVenta.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvVenta.LabelWrap = False
        Me.lvVenta.Location = New System.Drawing.Point(6, 81)
        Me.lvVenta.MultiSelect = False
        Me.lvVenta.Name = "lvVenta"
        Me.lvVenta.Size = New System.Drawing.Size(1020, 357)
        Me.lvVenta.TabIndex = 4
        Me.lvVenta.UseCompatibleStateImageBehavior = False
        Me.lvVenta.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IDReten."
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DSuc."
        Me.ColumnHeader2.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DCaja"
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Factura"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Timbrado"
        Me.ColumnHeader10.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cliente"
        Me.ColumnHeader5.Width = 300
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Total"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fecha"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Sucursal"
        Me.ColumnHeader8.Width = 200
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(12, 458)
        Me.txtSql.MaxLength = 500
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(979, 20)
        Me.txtSql.TabIndex = 24
        Me.txtSql.Visible = False
        '
        'frmBuscarRetencionProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 490)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.grBuscar)
        Me.MaximizeBox = False
        Me.Name = "frmBuscarRetencionProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Retención de Ventas"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdRetencion As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdFactura As System.Windows.Forms.RadioButton
    Friend WithEvents rdCliente As System.Windows.Forms.RadioButton
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvVenta As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
End Class
