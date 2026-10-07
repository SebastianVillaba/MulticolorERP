<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteSaldoCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteSaldoCliente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdPagoGrupoCliente = New System.Windows.Forms.RadioButton()
        Me.rdCancelaGrupo = New System.Windows.Forms.RadioButton()
        Me.rdPorCliente = New System.Windows.Forms.RadioButton()
        Me.rdTodoGrupo = New System.Windows.Forms.RadioButton()
        Me.rdSaldoMora = New System.Windows.Forms.RadioButton()
        Me.rdGrupoCliente = New System.Windows.Forms.RadioButton()
        Me.rdSaldoResumidoCliente = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdGrupo = New System.Windows.Forms.Label()
        Me.lblNombreGrupo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(393, 133)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha "
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(247, 44)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 97
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(80, 78)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(143, 22)
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
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(143, 22)
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
        Me.GroupBox3.Controls.Add(Me.rdPagoGrupoCliente)
        Me.GroupBox3.Controls.Add(Me.rdCancelaGrupo)
        Me.GroupBox3.Controls.Add(Me.rdPorCliente)
        Me.GroupBox3.Controls.Add(Me.rdTodoGrupo)
        Me.GroupBox3.Controls.Add(Me.rdSaldoMora)
        Me.GroupBox3.Controls.Add(Me.rdGrupoCliente)
        Me.GroupBox3.Controls.Add(Me.rdSaldoResumidoCliente)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 155)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(277, 230)
        Me.GroupBox3.TabIndex = 101
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdPagoGrupoCliente
        '
        Me.rdPagoGrupoCliente.AutoSize = True
        Me.rdPagoGrupoCliente.Location = New System.Drawing.Point(8, 192)
        Me.rdPagoGrupoCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdPagoGrupoCliente.Name = "rdPagoGrupoCliente"
        Me.rdPagoGrupoCliente.Size = New System.Drawing.Size(198, 21)
        Me.rdPagoGrupoCliente.TabIndex = 24
        Me.rdPagoGrupoCliente.Text = "Pago por Grupo de Cliente"
        Me.rdPagoGrupoCliente.UseVisualStyleBackColor = True
        '
        'rdCancelaGrupo
        '
        Me.rdCancelaGrupo.AutoSize = True
        Me.rdCancelaGrupo.Location = New System.Drawing.Point(8, 164)
        Me.rdCancelaGrupo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdCancelaGrupo.Name = "rdCancelaGrupo"
        Me.rdCancelaGrupo.Size = New System.Drawing.Size(175, 21)
        Me.rdCancelaGrupo.TabIndex = 23
        Me.rdCancelaGrupo.Text = "Cancelación por Grupo"
        Me.rdCancelaGrupo.UseVisualStyleBackColor = True
        '
        'rdPorCliente
        '
        Me.rdPorCliente.AutoSize = True
        Me.rdPorCliente.Location = New System.Drawing.Point(8, 135)
        Me.rdPorCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdPorCliente.Name = "rdPorCliente"
        Me.rdPorCliente.Size = New System.Drawing.Size(98, 21)
        Me.rdPorCliente.TabIndex = 22
        Me.rdPorCliente.Text = "Por Cliente"
        Me.rdPorCliente.UseVisualStyleBackColor = True
        '
        'rdTodoGrupo
        '
        Me.rdTodoGrupo.AutoSize = True
        Me.rdTodoGrupo.Location = New System.Drawing.Point(8, 107)
        Me.rdTodoGrupo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdTodoGrupo.Name = "rdTodoGrupo"
        Me.rdTodoGrupo.Size = New System.Drawing.Size(212, 21)
        Me.rdTodoGrupo.TabIndex = 21
        Me.rdTodoGrupo.Text = "Todos los Grupos a la Fecha"
        Me.rdTodoGrupo.UseVisualStyleBackColor = True
        '
        'rdSaldoMora
        '
        Me.rdSaldoMora.AutoSize = True
        Me.rdSaldoMora.Location = New System.Drawing.Point(8, 80)
        Me.rdSaldoMora.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdSaldoMora.Name = "rdSaldoMora"
        Me.rdSaldoMora.Size = New System.Drawing.Size(121, 21)
        Me.rdSaldoMora.TabIndex = 20
        Me.rdSaldoMora.Text = "Saldo de Mora"
        Me.rdSaldoMora.UseVisualStyleBackColor = True
        '
        'rdGrupoCliente
        '
        Me.rdGrupoCliente.AutoSize = True
        Me.rdGrupoCliente.Location = New System.Drawing.Point(8, 52)
        Me.rdGrupoCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdGrupoCliente.Name = "rdGrupoCliente"
        Me.rdGrupoCliente.Size = New System.Drawing.Size(136, 21)
        Me.rdGrupoCliente.TabIndex = 19
        Me.rdGrupoCliente.Text = "Grupo de Cliente"
        Me.rdGrupoCliente.UseVisualStyleBackColor = True
        '
        'rdSaldoResumidoCliente
        '
        Me.rdSaldoResumidoCliente.AutoSize = True
        Me.rdSaldoResumidoCliente.Checked = True
        Me.rdSaldoResumidoCliente.Location = New System.Drawing.Point(8, 23)
        Me.rdSaldoResumidoCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdSaldoResumidoCliente.Name = "rdSaldoResumidoCliente"
        Me.rdSaldoResumidoCliente.Size = New System.Drawing.Size(206, 21)
        Me.rdSaldoResumidoCliente.TabIndex = 18
        Me.rdSaldoResumidoCliente.TabStop = True
        Me.rdSaldoResumidoCliente.Text = "Saldo Resumido de Clientes"
        Me.rdSaldoResumidoCliente.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(315, 166)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "idGrupo:"
        '
        'lblIdGrupo
        '
        Me.lblIdGrupo.AutoSize = True
        Me.lblIdGrupo.BackColor = System.Drawing.Color.Lime
        Me.lblIdGrupo.Location = New System.Drawing.Point(383, 167)
        Me.lblIdGrupo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdGrupo.Name = "lblIdGrupo"
        Me.lblIdGrupo.Size = New System.Drawing.Size(59, 17)
        Me.lblIdGrupo.TabIndex = 103
        Me.lblIdGrupo.Text = "idGrupo"
        '
        'lblNombreGrupo
        '
        Me.lblNombreGrupo.AutoSize = True
        Me.lblNombreGrupo.BackColor = System.Drawing.Color.Lime
        Me.lblNombreGrupo.Location = New System.Drawing.Point(383, 188)
        Me.lblNombreGrupo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreGrupo.Name = "lblNombreGrupo"
        Me.lblNombreGrupo.Size = New System.Drawing.Size(96, 17)
        Me.lblNombreGrupo.TabIndex = 105
        Me.lblNombreGrupo.Text = "nombreGrupo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(313, 187)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Nombre:"
        '
        'frmReporteSaldoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 434)
        Me.Controls.Add(Me.lblNombreGrupo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblIdGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteSaldoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Saldo de Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdGrupoCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rdSaldoResumidoCliente As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIdGrupo As System.Windows.Forms.Label
    Friend WithEvents lblNombreGrupo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdSaldoMora As System.Windows.Forms.RadioButton
    Friend WithEvents rdTodoGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rdCancelaGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents rdPagoGrupoCliente As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
