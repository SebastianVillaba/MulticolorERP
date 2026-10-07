<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteCobros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteCobros))
        Me.grFechaHora = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdEntrega = New System.Windows.Forms.RadioButton()
        Me.rdComision = New System.Windows.Forms.RadioButton()
        Me.rdResumen = New System.Windows.Forms.RadioButton()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIdCobrador = New System.Windows.Forms.Label()
        Me.lblCobrador = New System.Windows.Forms.Label()
        Me.grFechaHora.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grFechaHora
        '
        Me.grFechaHora.Controls.Add(Me.dtpHastaFecha)
        Me.grFechaHora.Controls.Add(Me.Label6)
        Me.grFechaHora.Controls.Add(Me.dtpDesdeFecha)
        Me.grFechaHora.Controls.Add(Me.Label5)
        Me.grFechaHora.Controls.Add(Me.btnConsultar)
        Me.grFechaHora.Location = New System.Drawing.Point(7, 4)
        Me.grFechaHora.Margin = New System.Windows.Forms.Padding(4)
        Me.grFechaHora.Name = "grFechaHora"
        Me.grFechaHora.Padding = New System.Windows.Forms.Padding(4)
        Me.grFechaHora.Size = New System.Drawing.Size(344, 133)
        Me.grFechaHora.TabIndex = 106
        Me.grFechaHora.TabStop = False
        Me.grFechaHora.Text = "Fecha / Hora"
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(80, 78)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(131, 22)
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
        Me.dtpDesdeFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(131, 22)
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdEntrega)
        Me.GroupBox3.Controls.Add(Me.rdComision)
        Me.GroupBox3.Controls.Add(Me.rdResumen)
        Me.GroupBox3.Location = New System.Drawing.Point(360, 6)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(235, 98)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdEntrega
        '
        Me.rdEntrega.AutoSize = True
        Me.rdEntrega.Location = New System.Drawing.Point(10, 58)
        Me.rdEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.rdEntrega.Name = "rdEntrega"
        Me.rdEntrega.Size = New System.Drawing.Size(86, 21)
        Me.rdEntrega.TabIndex = 20
        Me.rdEntrega.Text = "Entregas"
        Me.rdEntrega.UseVisualStyleBackColor = True
        '
        'rdComision
        '
        Me.rdComision.AutoSize = True
        Me.rdComision.Location = New System.Drawing.Point(112, 23)
        Me.rdComision.Margin = New System.Windows.Forms.Padding(4)
        Me.rdComision.Name = "rdComision"
        Me.rdComision.Size = New System.Drawing.Size(86, 21)
        Me.rdComision.TabIndex = 19
        Me.rdComision.Text = "C&omisión"
        Me.rdComision.UseVisualStyleBackColor = True
        '
        'rdResumen
        '
        Me.rdResumen.AutoSize = True
        Me.rdResumen.Checked = True
        Me.rdResumen.Location = New System.Drawing.Point(8, 23)
        Me.rdResumen.Margin = New System.Windows.Forms.Padding(4)
        Me.rdResumen.Name = "rdResumen"
        Me.rdResumen.Size = New System.Drawing.Size(92, 21)
        Me.rdResumen.TabIndex = 18
        Me.rdResumen.TabStop = True
        Me.rdResumen.Text = "&Resumido"
        Me.rdResumen.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(233, 40)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 107
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 155)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 20)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Cobrador:"
        '
        'lblIdCobrador
        '
        Me.lblIdCobrador.AutoSize = True
        Me.lblIdCobrador.BackColor = System.Drawing.Color.Yellow
        Me.lblIdCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCobrador.Location = New System.Drawing.Point(105, 155)
        Me.lblIdCobrador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdCobrador.Name = "lblIdCobrador"
        Me.lblIdCobrador.Size = New System.Drawing.Size(91, 20)
        Me.lblIdCobrador.TabIndex = 112
        Me.lblIdCobrador.Text = "idCobrador"
        '
        'lblCobrador
        '
        Me.lblCobrador.AutoSize = True
        Me.lblCobrador.BackColor = System.Drawing.Color.Yellow
        Me.lblCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrador.Location = New System.Drawing.Point(150, 155)
        Me.lblCobrador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCobrador.Name = "lblCobrador"
        Me.lblCobrador.Size = New System.Drawing.Size(78, 20)
        Me.lblCobrador.TabIndex = 113
        Me.lblCobrador.Text = "Cobrador"
        '
        'frmReporteCobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 230)
        Me.Controls.Add(Me.lblCobrador)
        Me.Controls.Add(Me.lblIdCobrador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grFechaHora)
        Me.Controls.Add(Me.GroupBox3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteCobros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Cobros"
        Me.grFechaHora.ResumeLayout(False)
        Me.grFechaHora.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grFechaHora As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdComision As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumen As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIdCobrador As System.Windows.Forms.Label
    Friend WithEvents lblCobrador As System.Windows.Forms.Label
    Friend WithEvents rdEntrega As System.Windows.Forms.RadioButton
End Class
