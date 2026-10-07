<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteHistorico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteHistorico))
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdTipo = New System.Windows.Forms.RadioButton()
        Me.rdPorMovimiento = New System.Windows.Forms.RadioButton()
        Me.rdResumenPago = New System.Windows.Forms.RadioButton()
        Me.grFechaHora = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIdCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblIdCuota = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.grOrdenar.SuspendLayout()
        Me.grFechaHora.SuspendLayout()
        Me.SuspendLayout()
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdTipo)
        Me.grOrdenar.Controls.Add(Me.rdPorMovimiento)
        Me.grOrdenar.Controls.Add(Me.rdResumenPago)
        Me.grOrdenar.Location = New System.Drawing.Point(36, 15)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grOrdenar.Size = New System.Drawing.Size(172, 100)
        Me.grOrdenar.TabIndex = 99
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Opciones"
        '
        'rdTipo
        '
        Me.rdTipo.AutoSize = True
        Me.rdTipo.Location = New System.Drawing.Point(11, 73)
        Me.rdTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdTipo.Name = "rdTipo"
        Me.rdTipo.Size = New System.Drawing.Size(83, 21)
        Me.rdTipo.TabIndex = 19
        Me.rdTipo.Text = "Por Tipo"
        Me.rdTipo.UseVisualStyleBackColor = True
        '
        'rdPorMovimiento
        '
        Me.rdPorMovimiento.AutoSize = True
        Me.rdPorMovimiento.Enabled = False
        Me.rdPorMovimiento.Location = New System.Drawing.Point(11, 44)
        Me.rdPorMovimiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdPorMovimiento.Name = "rdPorMovimiento"
        Me.rdPorMovimiento.Size = New System.Drawing.Size(126, 21)
        Me.rdPorMovimiento.TabIndex = 18
        Me.rdPorMovimiento.Text = "Por &Movimiento"
        Me.rdPorMovimiento.UseVisualStyleBackColor = True
        '
        'rdResumenPago
        '
        Me.rdResumenPago.AutoSize = True
        Me.rdResumenPago.Checked = True
        Me.rdResumenPago.Location = New System.Drawing.Point(11, 16)
        Me.rdResumenPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdResumenPago.Name = "rdResumenPago"
        Me.rdResumenPago.Size = New System.Drawing.Size(146, 21)
        Me.rdResumenPago.TabIndex = 17
        Me.rdResumenPago.TabStop = True
        Me.rdResumenPago.Text = "&Resumen de Pago"
        Me.rdResumenPago.UseVisualStyleBackColor = True
        '
        'grFechaHora
        '
        Me.grFechaHora.Controls.Add(Me.dtpHastaFecha)
        Me.grFechaHora.Controls.Add(Me.Label6)
        Me.grFechaHora.Controls.Add(Me.dtpDesdeFecha)
        Me.grFechaHora.Controls.Add(Me.Label5)
        Me.grFechaHora.Location = New System.Drawing.Point(37, 229)
        Me.grFechaHora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grFechaHora.Name = "grFechaHora"
        Me.grFechaHora.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grFechaHora.Size = New System.Drawing.Size(233, 111)
        Me.grFechaHora.TabIndex = 100
        Me.grFechaHora.TabStop = False
        Me.grFechaHora.Text = "Fecha "
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(80, 78)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(128, 22)
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
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(128, 22)
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
        'lblIdCliente
        '
        Me.lblIdCliente.AutoSize = True
        Me.lblIdCliente.BackColor = System.Drawing.Color.PaleGreen
        Me.lblIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCliente.Location = New System.Drawing.Point(252, 198)
        Me.lblIdCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdCliente.Name = "lblIdCliente"
        Me.lblIdCliente.Size = New System.Drawing.Size(64, 18)
        Me.lblIdCliente.TabIndex = 135
        Me.lblIdCliente.Text = "idCliente"
        Me.lblIdCliente.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(168, 197)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 18)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "ID Cliente:"
        Me.Label2.Visible = False
        '
        'lblIdCuota
        '
        Me.lblIdCuota.AutoSize = True
        Me.lblIdCuota.BackColor = System.Drawing.Color.PaleGreen
        Me.lblIdCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCuota.Location = New System.Drawing.Point(96, 196)
        Me.lblIdCuota.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdCuota.Name = "lblIdCuota"
        Me.lblIdCuota.Size = New System.Drawing.Size(59, 18)
        Me.lblIdCuota.TabIndex = 133
        Me.lblIdCuota.Text = "idCuota"
        Me.lblIdCuota.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 194)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 18)
        Me.Label16.TabIndex = 132
        Me.Label16.Text = "ID Cuota:"
        Me.Label16.Visible = False
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(13, 144)
        Me.cboTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(304, 28)
        Me.cboTipo.TabIndex = 137
        Me.cboTipo.Visible = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(12, 121)
        Me.lblTipo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(41, 20)
        Me.lblTipo.TabIndex = 136
        Me.lblTipo.Text = "Tipo"
        Me.lblTipo.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(227, 37)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 138
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'frmReporteHistorico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 367)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.lblIdCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblIdCuota)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.grFechaHora)
        Me.Controls.Add(Me.grOrdenar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteHistorico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte en el Histórico"
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.grFechaHora.ResumeLayout(False)
        Me.grFechaHora.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdPorMovimiento As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumenPago As System.Windows.Forms.RadioButton
    Friend WithEvents grFechaHora As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIdCliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblIdCuota As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents rdTipo As System.Windows.Forms.RadioButton
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
