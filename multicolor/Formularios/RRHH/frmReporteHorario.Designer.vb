<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteHorario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteHorario))
        Me.lblIdPersonal = New System.Windows.Forms.Label()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdTodoPersonal = New System.Windows.Forms.RadioButton()
        Me.rdDetalle = New System.Windows.Forms.RadioButton()
        Me.rdResumen = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.txtIdSucursal = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblIdPersonal
        '
        Me.lblIdPersonal.AutoSize = True
        Me.lblIdPersonal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblIdPersonal.Location = New System.Drawing.Point(224, 160)
        Me.lblIdPersonal.Name = "lblIdPersonal"
        Me.lblIdPersonal.Size = New System.Drawing.Size(56, 13)
        Me.lblIdPersonal.TabIndex = 108
        Me.lblIdPersonal.Text = "idPersonal"
        Me.lblIdPersonal.Visible = False
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPersonal.Location = New System.Drawing.Point(224, 144)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(65, 13)
        Me.lblPersonal.TabIndex = 107
        Me.lblPersonal.Text = "PERSONAL"
        Me.lblPersonal.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdTodoPersonal)
        Me.GroupBox3.Controls.Add(Me.rdDetalle)
        Me.GroupBox3.Controls.Add(Me.rdResumen)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 122)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 60)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdTodoPersonal
        '
        Me.rdTodoPersonal.AutoSize = True
        Me.rdTodoPersonal.Location = New System.Drawing.Point(93, 16)
        Me.rdTodoPersonal.Name = "rdTodoPersonal"
        Me.rdTodoPersonal.Size = New System.Drawing.Size(105, 17)
        Me.rdTodoPersonal.TabIndex = 20
        Me.rdTodoPersonal.Text = "Todo el Personal"
        Me.rdTodoPersonal.UseVisualStyleBackColor = True
        '
        'rdDetalle
        '
        Me.rdDetalle.AutoSize = True
        Me.rdDetalle.Location = New System.Drawing.Point(6, 40)
        Me.rdDetalle.Name = "rdDetalle"
        Me.rdDetalle.Size = New System.Drawing.Size(85, 17)
        Me.rdDetalle.TabIndex = 19
        Me.rdDetalle.Text = "Por &Personal"
        Me.rdDetalle.UseVisualStyleBackColor = True
        '
        'rdResumen
        '
        Me.rdResumen.AutoSize = True
        Me.rdResumen.Checked = True
        Me.rdResumen.Location = New System.Drawing.Point(6, 16)
        Me.rdResumen.Name = "rdResumen"
        Me.rdResumen.Size = New System.Drawing.Size(72, 17)
        Me.rdResumen.TabIndex = 18
        Me.rdResumen.TabStop = True
        Me.rdResumen.Text = "&Resumido"
        Me.rdResumen.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.chkTodos)
        Me.GroupBox2.Controls.Add(Me.txtIdSucursal)
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(382, 89)
        Me.GroupBox2.TabIndex = 105
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sucursal"
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Checked = True
        Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodos.Location = New System.Drawing.Point(90, 61)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(170, 22)
        Me.chkTodos.TabIndex = 97
        Me.chkTodos.Text = "Todas las Sucursales"
        Me.chkTodos.UseVisualStyleBackColor = True
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 108)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha "
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
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(306, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 111
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(174, 29)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(69, 37)
        Me.btnConsultar.TabIndex = 112
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'frmReporteHorario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 303)
        Me.Controls.Add(Me.lblIdPersonal)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteHorario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Horario del Personal"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdPersonal As System.Windows.Forms.Label
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumen As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents txtIdSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdTodoPersonal As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
