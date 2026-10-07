<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteCajaSeleccion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCajaSeleccion))
        Me.dtgCaja = New System.Windows.Forms.DataGridView()
        Me.grFechaHora = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dtgCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grFechaHora.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgCaja
        '
        Me.dtgCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgCaja.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCaja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.Column7, Me.Column1, Me.Column2, Me.Column3, Me.cotiza, Me.Column4})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgCaja.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgCaja.Location = New System.Drawing.Point(10, 80)
        Me.dtgCaja.Name = "dtgCaja"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgCaja.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgCaja.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dtgCaja.Size = New System.Drawing.Size(723, 361)
        Me.dtgCaja.TabIndex = 117
        '
        'grFechaHora
        '
        Me.grFechaHora.Controls.Add(Me.dtpHastaFecha)
        Me.grFechaHora.Controls.Add(Me.Label6)
        Me.grFechaHora.Controls.Add(Me.dtpDesdeFecha)
        Me.grFechaHora.Controls.Add(Me.Label5)
        Me.grFechaHora.Location = New System.Drawing.Point(12, 12)
        Me.grFechaHora.Name = "grFechaHora"
        Me.grFechaHora.Size = New System.Drawing.Size(485, 62)
        Me.grFechaHora.TabIndex = 118
        Me.grFechaHora.TabStop = False
        Me.grFechaHora.Text = "Fecha / Hora"
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(283, 29)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(167, 20)
        Me.dtpHastaFecha.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(233, 29)
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
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(167, 20)
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
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(503, 27)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(69, 37)
        Me.btnConsultar.TabIndex = 127
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(578, 26)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 126
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Column0
        '
        Me.Column0.Frozen = True
        Me.Column0.HeaderText = "Nro"
        Me.Column0.Name = "Column0"
        Me.Column0.ReadOnly = True
        Me.Column0.Width = 30
        '
        'Column7
        '
        Me.Column7.Frozen = True
        Me.Column7.HeaderText = "Sucursal"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 200
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "IDCaja"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Total Caja"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.FillWeight = 110.0!
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Total Sistema"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'cotiza
        '
        Me.cotiza.Frozen = True
        Me.cotiza.HeaderText = "Fecha Hora"
        Me.cotiza.Name = "cotiza"
        Me.cotiza.ReadOnly = True
        Me.cotiza.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "Imp."
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 40
        '
        'frmReporteCajaSeleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 482)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.grFechaHora)
        Me.Controls.Add(Me.dtgCaja)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteCajaSeleccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controlar Imprimir Caja"
        CType(Me.dtgCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grFechaHora.ResumeLayout(False)
        Me.grFechaHora.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgCaja As System.Windows.Forms.DataGridView
    Friend WithEvents grFechaHora As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Column0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cotiza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
