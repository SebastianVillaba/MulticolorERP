<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMostrarCaja
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
        Me.txtTotalCheque = New System.Windows.Forms.TextBox()
        Me.txtTotalTarjetaDeb = New System.Windows.Forms.TextBox()
        Me.txtTotalSistema = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalTarjetaCr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalCredito = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalDiferencia = New System.Windows.Forms.TextBox()
        Me.txtTotalDevolucion = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalCaja = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalGasto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFechaFin2 = New System.Windows.Forms.TextBox()
        Me.txtIdMovFin2 = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPersonal = New System.Windows.Forms.ListView()
        Me.txtFechaIni2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalMoneda = New System.Windows.Forms.TextBox()
        Me.txtIdMovIni2 = New System.Windows.Forms.TextBox()
        Me.txtTotalGuarani = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaFin1 = New System.Windows.Forms.TextBox()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIdMovFin1 = New System.Windows.Forms.TextBox()
        Me.txtFechaIni1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIdMovIni1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdCaja = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTotalCheque
        '
        Me.txtTotalCheque.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalCheque.Enabled = False
        Me.txtTotalCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCheque.Location = New System.Drawing.Point(468, 261)
        Me.txtTotalCheque.Name = "txtTotalCheque"
        Me.txtTotalCheque.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalCheque.TabIndex = 34
        '
        'txtTotalTarjetaDeb
        '
        Me.txtTotalTarjetaDeb.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalTarjetaDeb.Enabled = False
        Me.txtTotalTarjetaDeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTarjetaDeb.Location = New System.Drawing.Point(622, 260)
        Me.txtTotalTarjetaDeb.Name = "txtTotalTarjetaDeb"
        Me.txtTotalTarjetaDeb.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalTarjetaDeb.TabIndex = 32
        '
        'txtTotalSistema
        '
        Me.txtTotalSistema.BackColor = System.Drawing.Color.SpringGreen
        Me.txtTotalSistema.Enabled = False
        Me.txtTotalSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSistema.Location = New System.Drawing.Point(495, 149)
        Me.txtTotalSistema.Name = "txtTotalSistema"
        Me.txtTotalSistema.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalSistema.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(492, 240)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 18)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Total Cheques"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(635, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 18)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Total Tarjeta Deb."
        '
        'txtTotalTarjetaCr
        '
        Me.txtTotalTarjetaCr.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalTarjetaCr.Enabled = False
        Me.txtTotalTarjetaCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTarjetaCr.Location = New System.Drawing.Point(14, 309)
        Me.txtTotalTarjetaCr.Name = "txtTotalTarjetaCr"
        Me.txtTotalTarjetaCr.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalTarjetaCr.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(37, 288)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 18)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Total Tarjeta Cr."
        '
        'txtTotalCredito
        '
        Me.txtTotalCredito.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalCredito.Enabled = False
        Me.txtTotalCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredito.Location = New System.Drawing.Point(170, 309)
        Me.txtTotalCredito.Name = "txtTotalCredito"
        Me.txtTotalCredito.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalCredito.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(198, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 18)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Total Creditos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(726, 166)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 18)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "DIFERENCIA"
        '
        'txtTotalDiferencia
        '
        Me.txtTotalDiferencia.BackColor = System.Drawing.Color.MistyRose
        Me.txtTotalDiferencia.Enabled = False
        Me.txtTotalDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDiferencia.ForeColor = System.Drawing.Color.White
        Me.txtTotalDiferencia.Location = New System.Drawing.Point(703, 187)
        Me.txtTotalDiferencia.Name = "txtTotalDiferencia"
        Me.txtTotalDiferencia.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalDiferencia.TabIndex = 13
        '
        'txtTotalDevolucion
        '
        Me.txtTotalDevolucion.BackColor = System.Drawing.Color.Aqua
        Me.txtTotalDevolucion.Enabled = False
        Me.txtTotalDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDevolucion.Location = New System.Drawing.Point(702, 138)
        Me.txtTotalDevolucion.Name = "txtTotalDevolucion"
        Me.txtTotalDevolucion.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalDevolucion.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(719, 117)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 18)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Total Devolución"
        '
        'txtTotalCaja
        '
        Me.txtTotalCaja.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalCaja.Enabled = False
        Me.txtTotalCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCaja.Location = New System.Drawing.Point(495, 122)
        Me.txtTotalCaja.Name = "txtTotalCaja"
        Me.txtTotalCaja.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalCaja.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(415, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 18)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Total Caja:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(393, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 18)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Total Sistema:"
        '
        'txtTotalGasto
        '
        Me.txtTotalGasto.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalGasto.Enabled = False
        Me.txtTotalGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGasto.Location = New System.Drawing.Point(316, 261)
        Me.txtTotalGasto.Name = "txtTotalGasto"
        Me.txtTotalGasto.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalGasto.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(187, 240)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 18)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Total Monedas"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Personal"
        Me.ColumnHeader2.Width = 300
        '
        'txtFechaFin2
        '
        Me.txtFechaFin2.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaFin2.Enabled = False
        Me.txtFechaFin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin2.Location = New System.Drawing.Point(619, 94)
        Me.txtFechaFin2.Name = "txtFechaFin2"
        Me.txtFechaFin2.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaFin2.TabIndex = 21
        '
        'txtIdMovFin2
        '
        Me.txtIdMovFin2.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovFin2.Enabled = False
        Me.txtIdMovFin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovFin2.Location = New System.Drawing.Point(521, 94)
        Me.txtIdMovFin2.Name = "txtIdMovFin2"
        Me.txtIdMovFin2.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovFin2.TabIndex = 20
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.Tomato
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.ForeColor = System.Drawing.Color.White
        Me.txtSucursal.Location = New System.Drawing.Point(75, 45)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(319, 24)
        Me.txtSucursal.TabIndex = 74
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 18)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "Sucursal:"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IdPer."
        '
        'lvPersonal
        '
        Me.lvPersonal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvPersonal.Location = New System.Drawing.Point(9, 75)
        Me.lvPersonal.Name = "lvPersonal"
        Me.lvPersonal.Size = New System.Drawing.Size(366, 153)
        Me.lvPersonal.TabIndex = 70
        Me.lvPersonal.UseCompatibleStateImageBehavior = False
        Me.lvPersonal.View = System.Windows.Forms.View.Details
        '
        'txtFechaIni2
        '
        Me.txtFechaIni2.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaIni2.Enabled = False
        Me.txtFechaIni2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIni2.Location = New System.Drawing.Point(619, 67)
        Me.txtFechaIni2.Name = "txtFechaIni2"
        Me.txtFechaIni2.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaIni2.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(340, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 18)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Total Gastos"
        '
        'txtTotalMoneda
        '
        Me.txtTotalMoneda.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalMoneda.Enabled = False
        Me.txtTotalMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMoneda.Location = New System.Drawing.Point(166, 261)
        Me.txtTotalMoneda.Name = "txtTotalMoneda"
        Me.txtTotalMoneda.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalMoneda.TabIndex = 24
        '
        'txtIdMovIni2
        '
        Me.txtIdMovIni2.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovIni2.Enabled = False
        Me.txtIdMovIni2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovIni2.Location = New System.Drawing.Point(521, 67)
        Me.txtIdMovIni2.Name = "txtIdMovIni2"
        Me.txtIdMovIni2.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovIni2.TabIndex = 18
        '
        'txtTotalGuarani
        '
        Me.txtTotalGuarani.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalGuarani.Enabled = False
        Me.txtTotalGuarani.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGuarani.Location = New System.Drawing.Point(16, 261)
        Me.txtTotalGuarani.Name = "txtTotalGuarani"
        Me.txtTotalGuarani.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalGuarani.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 18)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Total Guaranies"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(441, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "No Impresos:"
        '
        'txtFechaFin1
        '
        Me.txtFechaFin1.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaFin1.Enabled = False
        Me.txtFechaFin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin1.Location = New System.Drawing.Point(619, 40)
        Me.txtFechaFin1.Name = "txtFechaFin1"
        Me.txtFechaFin1.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaFin1.TabIndex = 16
        '
        'txtFechaHora
        '
        Me.txtFechaHora.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaHora.Enabled = False
        Me.txtFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaHora.Location = New System.Drawing.Point(259, 18)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(177, 21)
        Me.txtFechaHora.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalDiferencia)
        Me.GroupBox1.Controls.Add(Me.txtSucursal)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtTotalDevolucion)
        Me.GroupBox1.Controls.Add(Me.lvPersonal)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtFechaFin2)
        Me.GroupBox1.Controls.Add(Me.txtTotalCaja)
        Me.GroupBox1.Controls.Add(Me.txtIdMovFin2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtTotalSistema)
        Me.GroupBox1.Controls.Add(Me.txtFechaIni2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtIdMovIni2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFechaFin1)
        Me.GroupBox1.Controls.Add(Me.txtIdMovFin1)
        Me.GroupBox1.Controls.Add(Me.txtFechaIni1)
        Me.GroupBox1.Controls.Add(Me.txtFechaHora)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtIdMovIni1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtIdCaja)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(878, 233)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'txtIdMovFin1
        '
        Me.txtIdMovFin1.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovFin1.Enabled = False
        Me.txtIdMovFin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovFin1.Location = New System.Drawing.Point(521, 40)
        Me.txtIdMovFin1.Name = "txtIdMovFin1"
        Me.txtIdMovFin1.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovFin1.TabIndex = 15
        '
        'txtFechaIni1
        '
        Me.txtFechaIni1.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaIni1.Enabled = False
        Me.txtFechaIni1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIni1.Location = New System.Drawing.Point(619, 13)
        Me.txtFechaIni1.Name = "txtFechaIni1"
        Me.txtFechaIni1.Size = New System.Drawing.Size(174, 21)
        Me.txtFechaIni1.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(148, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha/Hora Carga:"
        '
        'txtIdMovIni1
        '
        Me.txtIdMovIni1.BackColor = System.Drawing.Color.LightBlue
        Me.txtIdMovIni1.Enabled = False
        Me.txtIdMovIni1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovIni1.Location = New System.Drawing.Point(521, 13)
        Me.txtIdMovIni1.Name = "txtIdMovIni1"
        Me.txtIdMovIni1.Size = New System.Drawing.Size(92, 21)
        Me.txtIdMovIni1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(454, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Impresos:"
        '
        'txtIdCaja
        '
        Me.txtIdCaja.BackColor = System.Drawing.Color.Lime
        Me.txtIdCaja.Enabled = False
        Me.txtIdCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCaja.Location = New System.Drawing.Point(64, 17)
        Me.txtIdCaja.Name = "txtIdCaja"
        Me.txtIdCaja.Size = New System.Drawing.Size(76, 24)
        Me.txtIdCaja.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Caja:"
        '
        'frmMostrarCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 405)
        Me.Controls.Add(Me.txtTotalCheque)
        Me.Controls.Add(Me.txtTotalTarjetaDeb)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTotalTarjetaCr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalCredito)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTotalGasto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotalMoneda)
        Me.Controls.Add(Me.txtTotalGuarani)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMostrarCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mostrar Caja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTotalCheque As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalTarjetaDeb As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSistema As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTarjetaCr As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalGasto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFechaFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPersonal As System.Windows.Forms.ListView
    Friend WithEvents txtFechaIni2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovIni2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalGuarani As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdMovFin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaIni1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIdMovIni1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
