<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteArqueo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteArqueo))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdCajaSucursal = New System.Windows.Forms.RadioButton()
        Me.rdResumenCajaSucursal = New System.Windows.Forms.RadioButton()
        Me.rdDetalle = New System.Windows.Forms.RadioButton()
        Me.rdResumen = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIdCaja = New System.Windows.Forms.TextBox()
        Me.lblNroCaja = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIdSucursal = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdCajaSucursal)
        Me.GroupBox3.Controls.Add(Me.rdResumenCajaSucursal)
        Me.GroupBox3.Controls.Add(Me.rdDetalle)
        Me.GroupBox3.Controls.Add(Me.rdResumen)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(428, 48)
        Me.GroupBox3.TabIndex = 104
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdCajaSucursal
        '
        Me.rdCajaSucursal.AutoSize = True
        Me.rdCajaSucursal.Location = New System.Drawing.Point(307, 19)
        Me.rdCajaSucursal.Name = "rdCajaSucursal"
        Me.rdCajaSucursal.Size = New System.Drawing.Size(108, 17)
        Me.rdCajaSucursal.TabIndex = 21
        Me.rdCajaSucursal.Text = "Caja por Sucursal"
        Me.rdCajaSucursal.UseVisualStyleBackColor = True
        '
        'rdResumenCajaSucursal
        '
        Me.rdResumenCajaSucursal.AutoSize = True
        Me.rdResumenCajaSucursal.Location = New System.Drawing.Point(156, 19)
        Me.rdResumenCajaSucursal.Name = "rdResumenCajaSucursal"
        Me.rdResumenCajaSucursal.Size = New System.Drawing.Size(149, 17)
        Me.rdResumenCajaSucursal.TabIndex = 20
        Me.rdResumenCajaSucursal.Text = "Resumen de Caja en Suc."
        Me.rdResumenCajaSucursal.UseVisualStyleBackColor = True
        '
        'rdDetalle
        '
        Me.rdDetalle.AutoSize = True
        Me.rdDetalle.Location = New System.Drawing.Point(84, 19)
        Me.rdDetalle.Name = "rdDetalle"
        Me.rdDetalle.Size = New System.Drawing.Size(70, 17)
        Me.rdDetalle.TabIndex = 19
        Me.rdDetalle.Text = "&Detallado"
        Me.rdDetalle.UseVisualStyleBackColor = True
        '
        'rdResumen
        '
        Me.rdResumen.AutoSize = True
        Me.rdResumen.Checked = True
        Me.rdResumen.Location = New System.Drawing.Point(6, 19)
        Me.rdResumen.Name = "rdResumen"
        Me.rdResumen.Size = New System.Drawing.Size(72, 17)
        Me.rdResumen.TabIndex = 18
        Me.rdResumen.TabStop = True
        Me.rdResumen.Text = "&Resumido"
        Me.rdResumen.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtIdCaja)
        Me.GroupBox1.Controls.Add(Me.lblNroCaja)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.lblHasta)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.lblDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(77, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 108)
        Me.GroupBox1.TabIndex = 101
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha "
        '
        'txtIdCaja
        '
        Me.txtIdCaja.BackColor = System.Drawing.Color.White
        Me.txtIdCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCaja.Location = New System.Drawing.Point(73, 43)
        Me.txtIdCaja.Name = "txtIdCaja"
        Me.txtIdCaja.Size = New System.Drawing.Size(91, 24)
        Me.txtIdCaja.TabIndex = 97
        Me.txtIdCaja.Visible = False
        '
        'lblNroCaja
        '
        Me.lblNroCaja.AutoSize = True
        Me.lblNroCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroCaja.Location = New System.Drawing.Point(10, 45)
        Me.lblNroCaja.Name = "lblNroCaja"
        Me.lblNroCaja.Size = New System.Drawing.Size(64, 16)
        Me.lblNroCaja.TabIndex = 97
        Me.lblNroCaja.Text = "Nro Caja:"
        Me.lblNroCaja.Visible = False
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
        Me.dtpHastaFecha.Location = New System.Drawing.Point(60, 71)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(108, 20)
        Me.dtpHastaFecha.TabIndex = 96
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasta.Location = New System.Drawing.Point(10, 71)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(47, 16)
        Me.lblHasta.TabIndex = 95
        Me.lblHasta.Text = "Hasta:"
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(60, 21)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(108, 20)
        Me.dtpDesdeFecha.TabIndex = 94
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesde.Location = New System.Drawing.Point(10, 21)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(52, 16)
        Me.lblDesde.TabIndex = 93
        Me.lblDesde.Text = "Desde:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIdSucursal)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 176)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(382, 89)
        Me.GroupBox2.TabIndex = 102
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sucursal"
        '
        'txtIdSucursal
        '
        Me.txtIdSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSucursal.Location = New System.Drawing.Point(13, 59)
        Me.txtIdSucursal.Name = "txtIdSucursal"
        Me.txtIdSucursal.ReadOnly = True
        Me.txtIdSucursal.Size = New System.Drawing.Size(49, 24)
        Me.txtIdSucursal.TabIndex = 96
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(306, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 95
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(11, 30)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(289, 24)
        Me.txtSucursal.TabIndex = 0
        '
        'frmReporteArqueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 282)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteArqueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte del Arqueo de Caja"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumen As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblHasta As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDesde As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdSucursal As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents rdResumenCajaSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents lblNroCaja As System.Windows.Forms.Label
    Friend WithEvents txtIdCaja As System.Windows.Forms.TextBox
    Friend WithEvents rdCajaSucursal As System.Windows.Forms.RadioButton
End Class
