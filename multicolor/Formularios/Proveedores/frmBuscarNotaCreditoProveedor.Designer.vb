<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarNotaCreditoProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarNotaCreditoProveedor))
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtDcaja = New System.Windows.Forms.TextBox()
        Me.txtDsuc = New System.Windows.Forms.TextBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdFactura = New System.Windows.Forms.RadioButton()
        Me.rdIdNota = New System.Windows.Forms.RadioButton()
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.idVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdMov = New System.Windows.Forms.TextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grBuscar.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Proveedor"
        Me.ColumnHeader11.Width = 250
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.PictureBox1)
        Me.grBuscar.Controls.Add(Me.txtFactura)
        Me.grBuscar.Controls.Add(Me.txtDcaja)
        Me.grBuscar.Controls.Add(Me.txtDsuc)
        Me.grBuscar.Controls.Add(Me.grOrdenar)
        Me.grBuscar.Controls.Add(Me.lvBuscar)
        Me.grBuscar.Controls.Add(Me.txtIdMov)
        Me.grBuscar.Controls.Add(Me.txtBuscar)
        Me.grBuscar.Location = New System.Drawing.Point(11, 2)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(773, 452)
        Me.grBuscar.TabIndex = 24
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'txtFactura
        '
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Location = New System.Drawing.Point(141, 35)
        Me.txtFactura.MaxLength = 7
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(98, 20)
        Me.txtFactura.TabIndex = 22
        Me.txtFactura.Visible = False
        '
        'txtDcaja
        '
        Me.txtDcaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDcaja.Location = New System.Drawing.Point(97, 35)
        Me.txtDcaja.MaxLength = 3
        Me.txtDcaja.Name = "txtDcaja"
        Me.txtDcaja.Size = New System.Drawing.Size(38, 20)
        Me.txtDcaja.TabIndex = 21
        Me.txtDcaja.Visible = False
        '
        'txtDsuc
        '
        Me.txtDsuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDsuc.Location = New System.Drawing.Point(53, 35)
        Me.txtDsuc.MaxLength = 3
        Me.txtDsuc.Name = "txtDsuc"
        Me.txtDsuc.Size = New System.Drawing.Size(38, 20)
        Me.txtDsuc.TabIndex = 20
        Me.txtDsuc.Visible = False
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdFactura)
        Me.grOrdenar.Controls.Add(Me.rdIdNota)
        Me.grOrdenar.Location = New System.Drawing.Point(271, 24)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(153, 34)
        Me.grOrdenar.TabIndex = 19
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Busqueda"
        '
        'rdFactura
        '
        Me.rdFactura.AutoSize = True
        Me.rdFactura.Location = New System.Drawing.Point(75, 13)
        Me.rdFactura.Name = "rdFactura"
        Me.rdFactura.Size = New System.Drawing.Size(61, 17)
        Me.rdFactura.TabIndex = 18
        Me.rdFactura.Text = "Factura"
        Me.rdFactura.UseVisualStyleBackColor = True
        '
        'rdIdNota
        '
        Me.rdIdNota.AutoSize = True
        Me.rdIdNota.Checked = True
        Me.rdIdNota.Location = New System.Drawing.Point(8, 13)
        Me.rdIdNota.Name = "rdIdNota"
        Me.rdIdNota.Size = New System.Drawing.Size(57, 17)
        Me.rdIdNota.TabIndex = 17
        Me.rdIdNota.TabStop = True
        Me.rdIdNota.Text = "IdNota"
        Me.rdIdNota.UseVisualStyleBackColor = True
        '
        'lvBuscar
        '
        Me.lvBuscar.AllowColumnReorder = True
        Me.lvBuscar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idVenta, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader1})
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(9, 70)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(748, 362)
        Me.lvBuscar.TabIndex = 5
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'idVenta
        '
        Me.idVenta.Text = "ID Nota"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "DSuc."
        Me.ColumnHeader8.Width = 50
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "DCaja."
        Me.ColumnHeader9.Width = 50
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Factura"
        Me.ColumnHeader10.Width = 80
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Total"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fecha/Hora"
        Me.ColumnHeader1.Width = 150
        '
        'txtIdMov
        '
        Me.txtIdMov.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMov.Enabled = False
        Me.txtIdMov.Location = New System.Drawing.Point(441, 34)
        Me.txtIdMov.Name = "txtIdMov"
        Me.txtIdMov.Size = New System.Drawing.Size(58, 20)
        Me.txtIdMov.TabIndex = 4
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(53, 37)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(212, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'txtSql
        '
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(11, 468)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(778, 20)
        Me.txtSql.TabIndex = 25
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'frmBuscarNotaCreditoProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 504)
        Me.Controls.Add(Me.grBuscar)
        Me.Controls.Add(Me.txtSql)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarNotaCreditoProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Nota de Crédito "
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtDcaja As System.Windows.Forms.TextBox
    Friend WithEvents txtDsuc As System.Windows.Forms.TextBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdFactura As System.Windows.Forms.RadioButton
    Friend WithEvents rdIdNota As System.Windows.Forms.RadioButton
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents idVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdMov As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
