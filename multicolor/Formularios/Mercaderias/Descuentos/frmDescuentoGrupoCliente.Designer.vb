<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDescuentoGrupoCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDescuentoGrupoCliente))
        Me.grGrupoCliente = New System.Windows.Forms.GroupBox()
        Me.lvGrupo = New System.Windows.Forms.ListView()
        Me.lvGrupo_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvGrupo_idGrupo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvGrupo_nombreGrupo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvGrupo_activo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblLaboratorio = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCredito = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lvLaboratorio = New System.Windows.Forms.ListView()
        Me.lvGrupoCli_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_idLab = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_contado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_credito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_tarjeta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_debito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLab_chequeDife = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDebito = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtChequeDife = New System.Windows.Forms.TextBox()
        Me.grGrupoCliente.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grGrupoCliente
        '
        Me.grGrupoCliente.Controls.Add(Me.lvGrupo)
        Me.grGrupoCliente.Location = New System.Drawing.Point(13, 13)
        Me.grGrupoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.grGrupoCliente.Name = "grGrupoCliente"
        Me.grGrupoCliente.Padding = New System.Windows.Forms.Padding(4)
        Me.grGrupoCliente.Size = New System.Drawing.Size(435, 550)
        Me.grGrupoCliente.TabIndex = 10
        Me.grGrupoCliente.TabStop = False
        Me.grGrupoCliente.Text = "Grupo de Cliente"
        '
        'lvGrupo
        '
        Me.lvGrupo.AllowColumnReorder = True
        Me.lvGrupo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvGrupo_nro, Me.lvGrupo_idGrupo, Me.lvGrupo_nombreGrupo, Me.lvGrupo_activo})
        Me.lvGrupo.FullRowSelect = True
        Me.lvGrupo.GridLines = True
        Me.lvGrupo.HideSelection = False
        Me.lvGrupo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvGrupo.LabelWrap = False
        Me.lvGrupo.Location = New System.Drawing.Point(8, 42)
        Me.lvGrupo.Margin = New System.Windows.Forms.Padding(4)
        Me.lvGrupo.MultiSelect = False
        Me.lvGrupo.Name = "lvGrupo"
        Me.lvGrupo.Size = New System.Drawing.Size(410, 486)
        Me.lvGrupo.TabIndex = 3
        Me.lvGrupo.UseCompatibleStateImageBehavior = False
        Me.lvGrupo.View = System.Windows.Forms.View.Details
        '
        'lvGrupo_nro
        '
        Me.lvGrupo_nro.Text = "Nro."
        Me.lvGrupo_nro.Width = 40
        '
        'lvGrupo_idGrupo
        '
        Me.lvGrupo_idGrupo.Text = "Id.Grupo"
        Me.lvGrupo_idGrupo.Width = 50
        '
        'lvGrupo_nombreGrupo
        '
        Me.lvGrupo_nombreGrupo.Text = "Nombre Grupo"
        Me.lvGrupo_nombreGrupo.Width = 200
        '
        'lvGrupo_activo
        '
        Me.lvGrupo_activo.Text = "Act."
        Me.lvGrupo_activo.Width = 30
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(111, 574)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 46)
        Me.btnCancelar.TabIndex = 124
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(20, 575)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(83, 46)
        Me.btnModificar.TabIndex = 123
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(202, 575)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(83, 46)
        Me.btnGuardar.TabIndex = 122
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtChequeDife)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtDebito)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.lblLaboratorio)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTarjeta)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCredito)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtContado)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.lvLaboratorio)
        Me.GroupBox1.Location = New System.Drawing.Point(462, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 598)
        Me.GroupBox1.TabIndex = 123
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Elaborador"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, 29)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(55, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        '
        'lblLaboratorio
        '
        Me.lblLaboratorio.AutoSize = True
        Me.lblLaboratorio.BackColor = System.Drawing.Color.Aqua
        Me.lblLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaboratorio.ForeColor = System.Drawing.Color.Black
        Me.lblLaboratorio.Location = New System.Drawing.Point(125, 560)
        Me.lblLaboratorio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLaboratorio.Name = "lblLaboratorio"
        Me.lblLaboratorio.Size = New System.Drawing.Size(105, 20)
        Me.lblLaboratorio.TabIndex = 69
        Me.lblLaboratorio.Text = "lblLaboatorio"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(21, 561)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 20)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Elaborador:"
        '
        'btnAplicar
        '
        Me.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAplicar.Enabled = False
        Me.btnAplicar.Location = New System.Drawing.Point(827, 16)
        Me.btnAplicar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(83, 31)
        Me.btnAplicar.TabIndex = 67
        Me.btnAplicar.Text = "&Aplicar"
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(600, 14)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "%"
        '
        'txtTarjeta
        '
        Me.txtTarjeta.BackColor = System.Drawing.Color.Yellow
        Me.txtTarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTarjeta.Location = New System.Drawing.Point(553, 11)
        Me.txtTarjeta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Size = New System.Drawing.Size(35, 22)
        Me.txtTarjeta.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(504, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "%"
        '
        'txtCredito
        '
        Me.txtCredito.BackColor = System.Drawing.Color.LightPink
        Me.txtCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCredito.Location = New System.Drawing.Point(449, 12)
        Me.txtCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCredito.Name = "txtCredito"
        Me.txtCredito.Size = New System.Drawing.Size(43, 22)
        Me.txtCredito.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "%"
        '
        'txtContado
        '
        Me.txtContado.BackColor = System.Drawing.Color.Lime
        Me.txtContado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContado.Location = New System.Drawing.Point(331, 12)
        Me.txtContado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContado.Name = "txtContado"
        Me.txtContado.Size = New System.Drawing.Size(45, 22)
        Me.txtContado.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Yellow
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(510, 41)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "TARJETA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightPink
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(417, 42)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "CREDITO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Lime
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(315, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "CONTADO"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(66, 35)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(202, 22)
        Me.TextBox1.TabIndex = 7
        '
        'lvLaboratorio
        '
        Me.lvLaboratorio.AllowColumnReorder = True
        Me.lvLaboratorio.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvGrupoCli_nro, Me.lvLab_id, Me.lvLab_idLab, Me.lvLab_nombre, Me.lvLab_contado, Me.lvLab_credito, Me.lvLab_tarjeta, Me.lvLab_debito, Me.lvLab_chequeDife})
        Me.lvLaboratorio.FullRowSelect = True
        Me.lvLaboratorio.GridLines = True
        Me.lvLaboratorio.HideSelection = False
        Me.lvLaboratorio.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvLaboratorio.LabelWrap = False
        Me.lvLaboratorio.Location = New System.Drawing.Point(9, 73)
        Me.lvLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.lvLaboratorio.MultiSelect = False
        Me.lvLaboratorio.Name = "lvLaboratorio"
        Me.lvLaboratorio.Size = New System.Drawing.Size(980, 468)
        Me.lvLaboratorio.TabIndex = 3
        Me.lvLaboratorio.UseCompatibleStateImageBehavior = False
        Me.lvLaboratorio.View = System.Windows.Forms.View.Details
        '
        'lvGrupoCli_nro
        '
        Me.lvGrupoCli_nro.Text = "Nro"
        Me.lvGrupoCli_nro.Width = 40
        '
        'lvLab_id
        '
        Me.lvLab_id.Text = "Id"
        Me.lvLab_id.Width = 45
        '
        'lvLab_idLab
        '
        Me.lvLab_idLab.Text = "ID Lab."
        Me.lvLab_idLab.Width = 50
        '
        'lvLab_nombre
        '
        Me.lvLab_nombre.Text = "Nombre Elaborador"
        Me.lvLab_nombre.Width = 200
        '
        'lvLab_contado
        '
        Me.lvLab_contado.Text = "Cont."
        Me.lvLab_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvLab_credito
        '
        Me.lvLab_credito.Text = "Cred."
        Me.lvLab_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvLab_credito.Width = 50
        '
        'lvLab_tarjeta
        '
        Me.lvLab_tarjeta.Text = "Tarj."
        Me.lvLab_tarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvLab_tarjeta.Width = 55
        '
        'lvLab_debito
        '
        Me.lvLab_debito.Text = "Deb."
        Me.lvLab_debito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvLab_debito.Width = 55
        '
        'lvLab_chequeDife
        '
        Me.lvLab_chequeDife.Text = "Cheq.Di."
        Me.lvLab_chequeDife.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(602, 41)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 20)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "DEBITO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(680, 41)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 20)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "CHEQUE DIF."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(686, 14)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 17)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "%"
        '
        'txtDebito
        '
        Me.txtDebito.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtDebito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebito.Location = New System.Drawing.Point(632, 11)
        Me.txtDebito.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDebito.Name = "txtDebito"
        Me.txtDebito.Size = New System.Drawing.Size(35, 22)
        Me.txtDebito.TabIndex = 72
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(775, 15)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 17)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "%"
        '
        'txtChequeDife
        '
        Me.txtChequeDife.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.txtChequeDife.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChequeDife.Location = New System.Drawing.Point(721, 12)
        Me.txtChequeDife.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChequeDife.Name = "txtChequeDife"
        Me.txtChequeDife.Size = New System.Drawing.Size(35, 22)
        Me.txtChequeDife.TabIndex = 74
        '
        'frmDescuentoGrupoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1475, 642)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.grGrupoCliente)
        Me.Controls.Add(Me.btnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDescuentoGrupoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descuento por Grupo de Cliente"
        Me.grGrupoCliente.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grGrupoCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lvGrupo As System.Windows.Forms.ListView
    Friend WithEvents lvGrupo_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvGrupo_idGrupo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvGrupo_nombreGrupo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvGrupo_activo As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLaboratorio As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lvLaboratorio As System.Windows.Forms.ListView
    Friend WithEvents lvGrupoCli_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLab_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLab_idLab As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLab_nombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLab_contado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLab_credito As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLab_tarjeta As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lvLab_debito As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLab_chequeDife As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtChequeDife As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDebito As System.Windows.Forms.TextBox
End Class
