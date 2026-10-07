<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteVencimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteVencimiento))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIdDeposito = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtDeposito = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboLaboratorio = New System.Windows.Forms.ComboBox()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdUsoInterno = New System.Windows.Forms.RadioButton()
        Me.rdPorLaboratorio = New System.Windows.Forms.RadioButton()
        Me.rdPorSucursal = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 78)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(174, 21)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(69, 37)
        Me.btnConsultar.TabIndex = 103
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(60, 29)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(108, 20)
        Me.dtpHastaFecha.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Hasta:"
        '
        'txtIdDeposito
        '
        Me.txtIdDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdDeposito.Location = New System.Drawing.Point(13, 59)
        Me.txtIdDeposito.Name = "txtIdDeposito"
        Me.txtIdDeposito.ReadOnly = True
        Me.txtIdDeposito.Size = New System.Drawing.Size(49, 24)
        Me.txtIdDeposito.TabIndex = 96
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.txtIdDeposito)
        Me.GroupBox2.Controls.Add(Me.txtDeposito)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(467, 89)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sucursal"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(392, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 102
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtDeposito
        '
        Me.txtDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeposito.Location = New System.Drawing.Point(11, 30)
        Me.txtDeposito.Name = "txtDeposito"
        Me.txtDeposito.ReadOnly = True
        Me.txtDeposito.Size = New System.Drawing.Size(375, 24)
        Me.txtDeposito.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboLaboratorio)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 210)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(367, 53)
        Me.GroupBox4.TabIndex = 100
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Laboratorio"
        '
        'cboLaboratorio
        '
        Me.cboLaboratorio.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLaboratorio.FormattingEnabled = True
        Me.cboLaboratorio.Location = New System.Drawing.Point(9, 16)
        Me.cboLaboratorio.Name = "cboLaboratorio"
        Me.cboLaboratorio.Size = New System.Drawing.Size(329, 24)
        Me.cboLaboratorio.TabIndex = 50
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdUsoInterno)
        Me.grOrdenar.Controls.Add(Me.rdPorLaboratorio)
        Me.grOrdenar.Controls.Add(Me.rdPorSucursal)
        Me.grOrdenar.Location = New System.Drawing.Point(286, 12)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(169, 82)
        Me.grOrdenar.TabIndex = 101
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdUsoInterno
        '
        Me.rdUsoInterno.AutoSize = True
        Me.rdUsoInterno.Location = New System.Drawing.Point(8, 58)
        Me.rdUsoInterno.Name = "rdUsoInterno"
        Me.rdUsoInterno.Size = New System.Drawing.Size(158, 17)
        Me.rdUsoInterno.TabIndex = 19
        Me.rdUsoInterno.Text = "Mercaderías de Uso Interno"
        Me.rdUsoInterno.UseVisualStyleBackColor = True
        '
        'rdPorLaboratorio
        '
        Me.rdPorLaboratorio.AutoSize = True
        Me.rdPorLaboratorio.Location = New System.Drawing.Point(8, 36)
        Me.rdPorLaboratorio.Name = "rdPorLaboratorio"
        Me.rdPorLaboratorio.Size = New System.Drawing.Size(97, 17)
        Me.rdPorLaboratorio.TabIndex = 18
        Me.rdPorLaboratorio.Text = "Por Laboratorio"
        Me.rdPorLaboratorio.UseVisualStyleBackColor = True
        '
        'rdPorSucursal
        '
        Me.rdPorSucursal.AutoSize = True
        Me.rdPorSucursal.Checked = True
        Me.rdPorSucursal.Location = New System.Drawing.Point(8, 13)
        Me.rdPorSucursal.Name = "rdPorSucursal"
        Me.rdPorSucursal.Size = New System.Drawing.Size(85, 17)
        Me.rdPorSucursal.TabIndex = 17
        Me.rdPorSucursal.TabStop = True
        Me.rdPorSucursal.Text = "Por Sucursal"
        Me.rdPorSucursal.UseVisualStyleBackColor = True
        '
        'frmReporteVencimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 295)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteVencimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Vencimientos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIdDeposito As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDeposito As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLaboratorio As System.Windows.Forms.ComboBox
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdPorLaboratorio As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents rdUsoInterno As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
