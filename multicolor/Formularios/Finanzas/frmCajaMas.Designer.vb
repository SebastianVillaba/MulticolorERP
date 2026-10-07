<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaMas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCajaMas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFin2 = New System.Windows.Forms.TextBox()
        Me.txtIdMovFin2 = New System.Windows.Forms.TextBox()
        Me.txtFechaIni2 = New System.Windows.Forms.TextBox()
        Me.txtIdMovIni2 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFin1 = New System.Windows.Forms.TextBox()
        Me.txtIdMovFin1 = New System.Windows.Forms.TextBox()
        Me.txtFechaIni1 = New System.Windows.Forms.TextBox()
        Me.txtIdMovIni1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalDiferencia = New System.Windows.Forms.TextBox()
        Me.txtTotalCaja = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalSistema = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtIdCaja = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIdSucursal = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Black
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 64)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "AUMENTAR CAJA(+)"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnCancelar)
        Me.GroupBox7.Controls.Add(Me.btnGuardar)
        Me.GroupBox7.Controls.Add(Me.btnNuevo)
        Me.GroupBox7.Location = New System.Drawing.Point(324, 10)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(251, 56)
        Me.GroupBox7.TabIndex = 120
        Me.GroupBox7.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(165, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(69, 37)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(90, 13)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(13, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(69, 37)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtTotalDiferencia)
        Me.GroupBox2.Controls.Add(Me.txtTotalCaja)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtTotalSistema)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtIdCaja)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 185)
        Me.GroupBox2.TabIndex = 121
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de la Caja"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtFechaFin2)
        Me.GroupBox4.Controls.Add(Me.txtIdMovFin2)
        Me.GroupBox4.Controls.Add(Me.txtFechaIni2)
        Me.GroupBox4.Controls.Add(Me.txtIdMovIni2)
        Me.GroupBox4.Location = New System.Drawing.Point(301, 95)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(289, 75)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Movimientos N/Imp"
        '
        'txtFechaFin2
        '
        Me.txtFechaFin2.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaFin2.Enabled = False
        Me.txtFechaFin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin2.Location = New System.Drawing.Point(106, 47)
        Me.txtFechaFin2.Name = "txtFechaFin2"
        Me.txtFechaFin2.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaFin2.TabIndex = 25
        '
        'txtIdMovFin2
        '
        Me.txtIdMovFin2.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovFin2.Enabled = False
        Me.txtIdMovFin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovFin2.Location = New System.Drawing.Point(8, 47)
        Me.txtIdMovFin2.Name = "txtIdMovFin2"
        Me.txtIdMovFin2.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovFin2.TabIndex = 24
        '
        'txtFechaIni2
        '
        Me.txtFechaIni2.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaIni2.Enabled = False
        Me.txtFechaIni2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIni2.Location = New System.Drawing.Point(106, 20)
        Me.txtFechaIni2.Name = "txtFechaIni2"
        Me.txtFechaIni2.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaIni2.TabIndex = 23
        '
        'txtIdMovIni2
        '
        Me.txtIdMovIni2.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovIni2.Enabled = False
        Me.txtIdMovIni2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovIni2.Location = New System.Drawing.Point(8, 20)
        Me.txtIdMovIni2.Name = "txtIdMovIni2"
        Me.txtIdMovIni2.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovIni2.TabIndex = 22
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFechaFin1)
        Me.GroupBox3.Controls.Add(Me.txtIdMovFin1)
        Me.GroupBox3.Controls.Add(Me.txtFechaIni1)
        Me.GroupBox3.Controls.Add(Me.txtIdMovIni1)
        Me.GroupBox3.Location = New System.Drawing.Point(301, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(289, 75)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Movimientos Imp"
        '
        'txtFechaFin1
        '
        Me.txtFechaFin1.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaFin1.Enabled = False
        Me.txtFechaFin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin1.Location = New System.Drawing.Point(104, 49)
        Me.txtFechaFin1.Name = "txtFechaFin1"
        Me.txtFechaFin1.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaFin1.TabIndex = 26
        '
        'txtIdMovFin1
        '
        Me.txtIdMovFin1.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovFin1.Enabled = False
        Me.txtIdMovFin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovFin1.Location = New System.Drawing.Point(6, 49)
        Me.txtIdMovFin1.Name = "txtIdMovFin1"
        Me.txtIdMovFin1.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovFin1.TabIndex = 25
        '
        'txtFechaIni1
        '
        Me.txtFechaIni1.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaIni1.Enabled = False
        Me.txtFechaIni1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIni1.Location = New System.Drawing.Point(104, 22)
        Me.txtFechaIni1.Name = "txtFechaIni1"
        Me.txtFechaIni1.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaIni1.TabIndex = 24
        '
        'txtIdMovIni1
        '
        Me.txtIdMovIni1.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovIni1.Enabled = False
        Me.txtIdMovIni1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovIni1.Location = New System.Drawing.Point(6, 22)
        Me.txtIdMovIni1.Name = "txtIdMovIni1"
        Me.txtIdMovIni1.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovIni1.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(79, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(200, 18)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "________________________"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 18)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Diferencia:"
        '
        'txtTotalDiferencia
        '
        Me.txtTotalDiferencia.BackColor = System.Drawing.Color.Pink
        Me.txtTotalDiferencia.Enabled = False
        Me.txtTotalDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDiferencia.ForeColor = System.Drawing.Color.White
        Me.txtTotalDiferencia.Location = New System.Drawing.Point(107, 132)
        Me.txtTotalDiferencia.Name = "txtTotalDiferencia"
        Me.txtTotalDiferencia.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalDiferencia.TabIndex = 14
        '
        'txtTotalCaja
        '
        Me.txtTotalCaja.BackColor = System.Drawing.Color.PeachPuff
        Me.txtTotalCaja.Enabled = False
        Me.txtTotalCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCaja.Location = New System.Drawing.Point(107, 63)
        Me.txtTotalCaja.Name = "txtTotalCaja"
        Me.txtTotalCaja.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalCaja.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(27, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 18)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Total Caja:"
        '
        'txtTotalSistema
        '
        Me.txtTotalSistema.BackColor = System.Drawing.Color.SpringGreen
        Me.txtTotalSistema.Enabled = False
        Me.txtTotalSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSistema.Location = New System.Drawing.Point(107, 90)
        Me.txtTotalSistema.Name = "txtTotalSistema"
        Me.txtTotalSistema.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalSistema.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(5, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 18)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Total Sistema:"
        '
        'txtIdCaja
        '
        Me.txtIdCaja.BackColor = System.Drawing.Color.Yellow
        Me.txtIdCaja.Enabled = False
        Me.txtIdCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCaja.Location = New System.Drawing.Point(110, 27)
        Me.txtIdCaja.Name = "txtIdCaja"
        Me.txtIdCaja.Size = New System.Drawing.Size(94, 24)
        Me.txtIdCaja.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ID Caja:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtMotivo)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtMonto)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Location = New System.Drawing.Point(23, 303)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(604, 120)
        Me.GroupBox5.TabIndex = 122
        Me.GroupBox5.TabStop = False
        '
        'txtMotivo
        '
        Me.txtMotivo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotivo.Enabled = False
        Me.txtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.Location = New System.Drawing.Point(174, 40)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(416, 74)
        Me.txtMotivo.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(171, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 18)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Motivo"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtMonto.Enabled = False
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(8, 40)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(148, 24)
        Me.txtMonto.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 18)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Monto"
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.LightGreen
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(95, 80)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(396, 24)
        Me.txtSucursal.TabIndex = 124
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 18)
        Me.Label7.TabIndex = 123
        Me.Label7.Text = "Sucursal :"
        '
        'txtIdSucursal
        '
        Me.txtIdSucursal.BackColor = System.Drawing.Color.LightGreen
        Me.txtIdSucursal.Enabled = False
        Me.txtIdSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSucursal.Location = New System.Drawing.Point(502, 80)
        Me.txtIdSucursal.Name = "txtIdSucursal"
        Me.txtIdSucursal.Size = New System.Drawing.Size(56, 24)
        Me.txtIdSucursal.TabIndex = 125
        '
        'frmCajaMas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 435)
        Me.Controls.Add(Me.txtIdSucursal)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCajaMas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aumentar Caja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSistema As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovFin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaIni1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovIni1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaIni2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovIni2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIdSucursal As System.Windows.Forms.TextBox
End Class
