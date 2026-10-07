<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaArqueo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaArqueo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lvPersonal = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.txtFechaFin2 = New System.Windows.Forms.TextBox()
        Me.txtIdMovFin2 = New System.Windows.Forms.TextBox()
        Me.txtFechaIni2 = New System.Windows.Forms.TextBox()
        Me.txtIdMovIni2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaFin1 = New System.Windows.Forms.TextBox()
        Me.txtIdMovFin1 = New System.Windows.Forms.TextBox()
        Me.txtFechaIni1 = New System.Windows.Forms.TextBox()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtIdMovIni1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdCaja = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalGuarani = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalMoneda = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalGasto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalCredito = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalTarjetaCr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalTarjetaDeb = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalCheque = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grCajaMas = New System.Windows.Forms.GroupBox()
        Me.txtMotivoPositivo = New System.Windows.Forms.TextBox()
        Me.txtFechaPositivo = New System.Windows.Forms.TextBox()
        Me.txtRespoPositivo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMotivoNegativo = New System.Windows.Forms.TextBox()
        Me.txtFechaNegativo = New System.Windows.Forms.TextBox()
        Me.txtRespoNegativo = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTotalDiferencia = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalDevolucion = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalCajaPositivo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalCajaNegativo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotalCaja = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalSistema = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalHotel = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.grCajaMas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSucursal)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.lvPersonal)
        Me.GroupBox1.Controls.Add(Me.btnUltimo)
        Me.GroupBox1.Controls.Add(Me.btnSiguiente)
        Me.GroupBox1.Controls.Add(Me.btnAnterior)
        Me.GroupBox1.Controls.Add(Me.btnPrimero)
        Me.GroupBox1.Controls.Add(Me.txtFechaFin2)
        Me.GroupBox1.Controls.Add(Me.txtIdMovFin2)
        Me.GroupBox1.Controls.Add(Me.txtFechaIni2)
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
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(878, 233)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
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
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(649, 162)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(69, 37)
        Me.btnImprimir.TabIndex = 72
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(574, 164)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 71
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
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
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IdPer."
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Personal"
        Me.ColumnHeader2.Width = 300
        '
        'btnUltimo
        '
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Image = CType(resources.GetObject("btnUltimo.Image"), System.Drawing.Image)
        Me.btnUltimo.Location = New System.Drawing.Point(724, 121)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(69, 37)
        Me.btnUltimo.TabIndex = 69
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSiguiente.Enabled = False
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(649, 121)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(69, 37)
        Me.btnSiguiente.TabIndex = 68
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(574, 121)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(69, 37)
        Me.btnAnterior.TabIndex = 67
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(499, 121)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(69, 37)
        Me.btnPrimero.TabIndex = 66
        Me.btnPrimero.UseVisualStyleBackColor = True
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
        'txtTotalGuarani
        '
        Me.txtTotalGuarani.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalGuarani.Enabled = False
        Me.txtTotalGuarani.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGuarani.Location = New System.Drawing.Point(12, 264)
        Me.txtTotalGuarani.Name = "txtTotalGuarani"
        Me.txtTotalGuarani.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalGuarani.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 243)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Total Guaranies"
        '
        'txtTotalMoneda
        '
        Me.txtTotalMoneda.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalMoneda.Enabled = False
        Me.txtTotalMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMoneda.Location = New System.Drawing.Point(162, 264)
        Me.txtTotalMoneda.Name = "txtTotalMoneda"
        Me.txtTotalMoneda.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalMoneda.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(183, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Total Monedas"
        '
        'txtTotalGasto
        '
        Me.txtTotalGasto.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalGasto.Enabled = False
        Me.txtTotalGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGasto.Location = New System.Drawing.Point(312, 264)
        Me.txtTotalGasto.Name = "txtTotalGasto"
        Me.txtTotalGasto.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalGasto.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Total Gastos"
        '
        'txtTotalCredito
        '
        Me.txtTotalCredito.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalCredito.Enabled = False
        Me.txtTotalCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredito.Location = New System.Drawing.Point(314, 309)
        Me.txtTotalCredito.Name = "txtTotalCredito"
        Me.txtTotalCredito.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalCredito.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(342, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 18)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Total Creditos"
        '
        'txtTotalTarjetaCr
        '
        Me.txtTotalTarjetaCr.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalTarjetaCr.Enabled = False
        Me.txtTotalTarjetaCr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTarjetaCr.Location = New System.Drawing.Point(13, 355)
        Me.txtTotalTarjetaCr.Name = "txtTotalTarjetaCr"
        Me.txtTotalTarjetaCr.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalTarjetaCr.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 334)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 18)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Total Tarjeta Cr."
        '
        'txtTotalTarjetaDeb
        '
        Me.txtTotalTarjetaDeb.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalTarjetaDeb.Enabled = False
        Me.txtTotalTarjetaDeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTarjetaDeb.Location = New System.Drawing.Point(163, 309)
        Me.txtTotalTarjetaDeb.Name = "txtTotalTarjetaDeb"
        Me.txtTotalTarjetaDeb.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalTarjetaDeb.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(176, 288)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 18)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Total Tarjeta Deb."
        '
        'txtTotalCheque
        '
        Me.txtTotalCheque.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalCheque.Enabled = False
        Me.txtTotalCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCheque.Location = New System.Drawing.Point(12, 309)
        Me.txtTotalCheque.Name = "txtTotalCheque"
        Me.txtTotalCheque.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalCheque.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(36, 288)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 18)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Total Cheques"
        '
        'grCajaMas
        '
        Me.grCajaMas.BackColor = System.Drawing.Color.Moccasin
        Me.grCajaMas.Controls.Add(Me.txtMotivoPositivo)
        Me.grCajaMas.Controls.Add(Me.txtFechaPositivo)
        Me.grCajaMas.Controls.Add(Me.txtRespoPositivo)
        Me.grCajaMas.Location = New System.Drawing.Point(43, 384)
        Me.grCajaMas.Name = "grCajaMas"
        Me.grCajaMas.Size = New System.Drawing.Size(400, 152)
        Me.grCajaMas.TabIndex = 16
        Me.grCajaMas.TabStop = False
        Me.grCajaMas.Text = "Ajuste de Caja Positivo"
        '
        'txtMotivoPositivo
        '
        Me.txtMotivoPositivo.BackColor = System.Drawing.Color.LightBlue
        Me.txtMotivoPositivo.Enabled = False
        Me.txtMotivoPositivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivoPositivo.Location = New System.Drawing.Point(11, 47)
        Me.txtMotivoPositivo.Multiline = True
        Me.txtMotivoPositivo.Name = "txtMotivoPositivo"
        Me.txtMotivoPositivo.Size = New System.Drawing.Size(370, 100)
        Me.txtMotivoPositivo.TabIndex = 17
        '
        'txtFechaPositivo
        '
        Me.txtFechaPositivo.BackColor = System.Drawing.Color.LightBlue
        Me.txtFechaPositivo.Enabled = False
        Me.txtFechaPositivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaPositivo.Location = New System.Drawing.Point(237, 20)
        Me.txtFechaPositivo.Name = "txtFechaPositivo"
        Me.txtFechaPositivo.Size = New System.Drawing.Size(144, 21)
        Me.txtFechaPositivo.TabIndex = 16
        '
        'txtRespoPositivo
        '
        Me.txtRespoPositivo.BackColor = System.Drawing.Color.LightBlue
        Me.txtRespoPositivo.Enabled = False
        Me.txtRespoPositivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRespoPositivo.Location = New System.Drawing.Point(11, 20)
        Me.txtRespoPositivo.Name = "txtRespoPositivo"
        Me.txtRespoPositivo.Size = New System.Drawing.Size(220, 21)
        Me.txtRespoPositivo.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.GroupBox2.Controls.Add(Me.txtMotivoNegativo)
        Me.GroupBox2.Controls.Add(Me.txtFechaNegativo)
        Me.GroupBox2.Controls.Add(Me.txtRespoNegativo)
        Me.GroupBox2.Location = New System.Drawing.Point(453, 384)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 152)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ajuste de Caja Negativo"
        '
        'txtMotivoNegativo
        '
        Me.txtMotivoNegativo.BackColor = System.Drawing.Color.Azure
        Me.txtMotivoNegativo.Enabled = False
        Me.txtMotivoNegativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivoNegativo.Location = New System.Drawing.Point(11, 47)
        Me.txtMotivoNegativo.Multiline = True
        Me.txtMotivoNegativo.Name = "txtMotivoNegativo"
        Me.txtMotivoNegativo.Size = New System.Drawing.Size(370, 100)
        Me.txtMotivoNegativo.TabIndex = 18
        '
        'txtFechaNegativo
        '
        Me.txtFechaNegativo.BackColor = System.Drawing.Color.Azure
        Me.txtFechaNegativo.Enabled = False
        Me.txtFechaNegativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaNegativo.Location = New System.Drawing.Point(237, 20)
        Me.txtFechaNegativo.Name = "txtFechaNegativo"
        Me.txtFechaNegativo.Size = New System.Drawing.Size(144, 21)
        Me.txtFechaNegativo.TabIndex = 16
        '
        'txtRespoNegativo
        '
        Me.txtRespoNegativo.BackColor = System.Drawing.Color.Azure
        Me.txtRespoNegativo.Enabled = False
        Me.txtRespoNegativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRespoNegativo.Location = New System.Drawing.Point(11, 20)
        Me.txtRespoNegativo.Name = "txtRespoNegativo"
        Me.txtRespoNegativo.Size = New System.Drawing.Size(220, 21)
        Me.txtRespoNegativo.TabIndex = 15
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTotalDiferencia)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtTotalDevolucion)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.txtTotalCajaPositivo)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtTotalCajaNegativo)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtTotalCaja)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtTotalSistema)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(465, 237)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(425, 140)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        '
        'txtTotalDiferencia
        '
        Me.txtTotalDiferencia.BackColor = System.Drawing.Color.MistyRose
        Me.txtTotalDiferencia.Enabled = False
        Me.txtTotalDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDiferencia.ForeColor = System.Drawing.Color.White
        Me.txtTotalDiferencia.Location = New System.Drawing.Point(272, 94)
        Me.txtTotalDiferencia.Name = "txtTotalDiferencia"
        Me.txtTotalDiferencia.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalDiferencia.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(295, 73)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 18)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "DIFERENCIA"
        '
        'txtTotalDevolucion
        '
        Me.txtTotalDevolucion.BackColor = System.Drawing.Color.Aqua
        Me.txtTotalDevolucion.Enabled = False
        Me.txtTotalDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDevolucion.Location = New System.Drawing.Point(271, 45)
        Me.txtTotalDevolucion.Name = "txtTotalDevolucion"
        Me.txtTotalDevolucion.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalDevolucion.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(288, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 18)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Total Devolución"
        '
        'txtTotalCajaPositivo
        '
        Me.txtTotalCajaPositivo.BackColor = System.Drawing.Color.Moccasin
        Me.txtTotalCajaPositivo.Enabled = False
        Me.txtTotalCajaPositivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCajaPositivo.Location = New System.Drawing.Point(110, 76)
        Me.txtTotalCajaPositivo.Name = "txtTotalCajaPositivo"
        Me.txtTotalCajaPositivo.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalCajaPositivo.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 18)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Caja Positivo:"
        '
        'txtTotalCajaNegativo
        '
        Me.txtTotalCajaNegativo.BackColor = System.Drawing.Color.PaleTurquoise
        Me.txtTotalCajaNegativo.Enabled = False
        Me.txtTotalCajaNegativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCajaNegativo.Location = New System.Drawing.Point(110, 103)
        Me.txtTotalCajaNegativo.Name = "txtTotalCajaNegativo"
        Me.txtTotalCajaNegativo.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalCajaNegativo.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 105)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 18)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Caja Negativo:"
        '
        'txtTotalCaja
        '
        Me.txtTotalCaja.BackColor = System.Drawing.Color.Yellow
        Me.txtTotalCaja.Enabled = False
        Me.txtTotalCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCaja.Location = New System.Drawing.Point(108, 22)
        Me.txtTotalCaja.Name = "txtTotalCaja"
        Me.txtTotalCaja.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalCaja.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(28, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 18)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Total Caja:"
        '
        'txtTotalSistema
        '
        Me.txtTotalSistema.BackColor = System.Drawing.Color.SpringGreen
        Me.txtTotalSistema.Enabled = False
        Me.txtTotalSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSistema.Location = New System.Drawing.Point(108, 49)
        Me.txtTotalSistema.Name = "txtTotalSistema"
        Me.txtTotalSistema.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalSistema.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 18)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Total Sistema:"
        '
        'txtTotalHotel
        '
        Me.txtTotalHotel.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtTotalHotel.Enabled = False
        Me.txtTotalHotel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHotel.Location = New System.Drawing.Point(182, 355)
        Me.txtTotalHotel.Name = "txtTotalHotel"
        Me.txtTotalHotel.Size = New System.Drawing.Size(149, 24)
        Me.txtTotalHotel.TabIndex = 21
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(176, 334)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(162, 18)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Total Facturación Hotel"
        '
        'frmConsultaArqueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 561)
        Me.Controls.Add(Me.txtTotalHotel)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grCajaMas)
        Me.Controls.Add(Me.txtTotalCheque)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTotalTarjetaDeb)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTotalTarjetaCr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalCredito)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTotalGasto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotalMoneda)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTotalGuarani)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaArqueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Arqueo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grCajaMas.ResumeLayout(False)
        Me.grCajaMas.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaIni2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovIni2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdMovFin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaIni1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIdMovIni1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents lvPersonal As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtTotalGuarani As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalGasto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTarjetaCr As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTarjetaDeb As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grCajaMas As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaPositivo As System.Windows.Forms.TextBox
    Friend WithEvents txtRespoPositivo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaNegativo As System.Windows.Forms.TextBox
    Friend WithEvents txtRespoNegativo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCajaPositivo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCajaNegativo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSistema As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMotivoPositivo As System.Windows.Forms.TextBox
    Friend WithEvents txtMotivoNegativo As System.Windows.Forms.TextBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotalHotel As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
