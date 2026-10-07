<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteVenta))
        Me.grFechaHora = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grMovimiento = New System.Windows.Forms.GroupBox()
        Me.txtIdMovFin2 = New System.Windows.Forms.TextBox()
        Me.txtIdmovIni2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdmovFin1 = New System.Windows.Forms.TextBox()
        Me.txtIdmovIni1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdDatosCliente = New System.Windows.Forms.RadioButton()
        Me.rdCantidadProducto = New System.Windows.Forms.RadioButton()
        Me.rdCantidadVentaLaboratorio = New System.Windows.Forms.RadioButton()
        Me.rdDetalleCanjeLab = New System.Windows.Forms.RadioButton()
        Me.rdLaboratorioSinFecha = New System.Windows.Forms.RadioButton()
        Me.rdDetalleSinTotal = New System.Windows.Forms.RadioButton()
        Me.rdVentaResumenTipoProducto = New System.Windows.Forms.RadioButton()
        Me.rdCantidadTipoProducto = New System.Windows.Forms.RadioButton()
        Me.rdLaboratorioSinTotal = New System.Windows.Forms.RadioButton()
        Me.rdLaboratorio = New System.Windows.Forms.RadioButton()
        Me.rdAnulado = New System.Windows.Forms.RadioButton()
        Me.rdDetalle = New System.Windows.Forms.RadioButton()
        Me.rdResumen = New System.Windows.Forms.RadioButton()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdPorMovimiento = New System.Windows.Forms.RadioButton()
        Me.rdPorFecha = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkTodoSucursal = New System.Windows.Forms.CheckBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboLaboratorio = New System.Windows.Forms.ComboBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.grTipoProducto = New System.Windows.Forms.GroupBox()
        Me.cboTipoProducto = New System.Windows.Forms.ComboBox()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grReimpresion = New System.Windows.Forms.GroupBox()
        Me.txtFacturaFin = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFacturaIni = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboTipoSucursal = New System.Windows.Forms.ComboBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.grFechaHora.SuspendLayout()
        Me.grMovimiento.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grTipoProducto.SuspendLayout()
        Me.grReimpresion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grFechaHora
        '
        Me.grFechaHora.Controls.Add(Me.dtpHastaFecha)
        Me.grFechaHora.Controls.Add(Me.Label6)
        Me.grFechaHora.Controls.Add(Me.dtpDesdeFecha)
        Me.grFechaHora.Controls.Add(Me.Label5)
        Me.grFechaHora.Location = New System.Drawing.Point(32, 15)
        Me.grFechaHora.Margin = New System.Windows.Forms.Padding(4)
        Me.grFechaHora.Name = "grFechaHora"
        Me.grFechaHora.Padding = New System.Windows.Forms.Padding(4)
        Me.grFechaHora.Size = New System.Drawing.Size(344, 133)
        Me.grFechaHora.TabIndex = 1
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
        Me.dtpHastaFecha.Size = New System.Drawing.Size(221, 22)
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
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(221, 22)
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
        'grMovimiento
        '
        Me.grMovimiento.Controls.Add(Me.txtIdMovFin2)
        Me.grMovimiento.Controls.Add(Me.txtIdmovIni2)
        Me.grMovimiento.Controls.Add(Me.Label3)
        Me.grMovimiento.Controls.Add(Me.Label4)
        Me.grMovimiento.Controls.Add(Me.txtIdmovFin1)
        Me.grMovimiento.Controls.Add(Me.txtIdmovIni1)
        Me.grMovimiento.Controls.Add(Me.Label1)
        Me.grMovimiento.Controls.Add(Me.Label2)
        Me.grMovimiento.Enabled = False
        Me.grMovimiento.Location = New System.Drawing.Point(32, 155)
        Me.grMovimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.grMovimiento.Name = "grMovimiento"
        Me.grMovimiento.Padding = New System.Windows.Forms.Padding(4)
        Me.grMovimiento.Size = New System.Drawing.Size(303, 201)
        Me.grMovimiento.TabIndex = 97
        Me.grMovimiento.TabStop = False
        Me.grMovimiento.Text = "Nro de Movimientos"
        '
        'txtIdMovFin2
        '
        Me.txtIdMovFin2.ForeColor = System.Drawing.Color.Red
        Me.txtIdMovFin2.Location = New System.Drawing.Point(140, 142)
        Me.txtIdMovFin2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdMovFin2.Name = "txtIdMovFin2"
        Me.txtIdMovFin2.Size = New System.Drawing.Size(132, 22)
        Me.txtIdMovFin2.TabIndex = 101
        '
        'txtIdmovIni2
        '
        Me.txtIdmovIni2.ForeColor = System.Drawing.Color.Red
        Me.txtIdmovIni2.Location = New System.Drawing.Point(139, 110)
        Me.txtIdmovIni2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdmovIni2.Name = "txtIdmovIni2"
        Me.txtIdmovIni2.Size = New System.Drawing.Size(132, 22)
        Me.txtIdmovIni2.TabIndex = 100
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(16, 144)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Final No Imp.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(11, 110)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 20)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Inicial No Imp.:"
        '
        'txtIdmovFin1
        '
        Me.txtIdmovFin1.Location = New System.Drawing.Point(116, 68)
        Me.txtIdmovFin1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdmovFin1.Name = "txtIdmovFin1"
        Me.txtIdmovFin1.Size = New System.Drawing.Size(132, 22)
        Me.txtIdmovFin1.TabIndex = 97
        '
        'txtIdmovIni1
        '
        Me.txtIdmovIni1.Location = New System.Drawing.Point(115, 36)
        Me.txtIdmovIni1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdmovIni1.Name = "txtIdmovIni1"
        Me.txtIdmovIni1.Size = New System.Drawing.Size(132, 22)
        Me.txtIdmovIni1.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Final Imp.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 36)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Inicial Imp.:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdDatosCliente)
        Me.GroupBox3.Controls.Add(Me.rdCantidadProducto)
        Me.GroupBox3.Controls.Add(Me.rdCantidadVentaLaboratorio)
        Me.GroupBox3.Controls.Add(Me.rdDetalleCanjeLab)
        Me.GroupBox3.Controls.Add(Me.rdLaboratorioSinFecha)
        Me.GroupBox3.Controls.Add(Me.rdDetalleSinTotal)
        Me.GroupBox3.Controls.Add(Me.rdVentaResumenTipoProducto)
        Me.GroupBox3.Controls.Add(Me.rdCantidadTipoProducto)
        Me.GroupBox3.Controls.Add(Me.rdLaboratorioSinTotal)
        Me.GroupBox3.Controls.Add(Me.rdLaboratorio)
        Me.GroupBox3.Controls.Add(Me.rdAnulado)
        Me.GroupBox3.Controls.Add(Me.rdDetalle)
        Me.GroupBox3.Controls.Add(Me.rdResumen)
        Me.GroupBox3.Location = New System.Drawing.Point(343, 156)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(706, 190)
        Me.GroupBox3.TabIndex = 97
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdDatosCliente
        '
        Me.rdDatosCliente.AutoSize = True
        Me.rdDatosCliente.Location = New System.Drawing.Point(8, 136)
        Me.rdDatosCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDatosCliente.Name = "rdDatosCliente"
        Me.rdDatosCliente.Size = New System.Drawing.Size(162, 21)
        Me.rdDatosCliente.TabIndex = 60
        Me.rdDatosCliente.Text = "Datos de los Clientes"
        Me.rdDatosCliente.UseVisualStyleBackColor = True
        '
        'rdCantidadProducto
        '
        Me.rdCantidadProducto.AutoSize = True
        Me.rdCantidadProducto.Location = New System.Drawing.Point(492, 81)
        Me.rdCantidadProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCantidadProducto.Name = "rdCantidadProducto"
        Me.rdCantidadProducto.Size = New System.Drawing.Size(171, 21)
        Me.rdCantidadProducto.TabIndex = 33
        Me.rdCantidadProducto.Text = "Cantidad por Producto"
        Me.rdCantidadProducto.UseVisualStyleBackColor = True
        '
        'rdCantidadVentaLaboratorio
        '
        Me.rdCantidadVentaLaboratorio.AutoSize = True
        Me.rdCantidadVentaLaboratorio.Location = New System.Drawing.Point(237, 133)
        Me.rdCantidadVentaLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCantidadVentaLaboratorio.Name = "rdCantidadVentaLaboratorio"
        Me.rdCantidadVentaLaboratorio.Size = New System.Drawing.Size(187, 21)
        Me.rdCantidadVentaLaboratorio.TabIndex = 32
        Me.rdCantidadVentaLaboratorio.Text = "Cantidad por Laboratorio"
        Me.rdCantidadVentaLaboratorio.UseVisualStyleBackColor = True
        '
        'rdDetalleCanjeLab
        '
        Me.rdDetalleCanjeLab.AutoSize = True
        Me.rdDetalleCanjeLab.Location = New System.Drawing.Point(237, 107)
        Me.rdDetalleCanjeLab.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDetalleCanjeLab.Name = "rdDetalleCanjeLab"
        Me.rdDetalleCanjeLab.Size = New System.Drawing.Size(190, 21)
        Me.rdDetalleCanjeLab.TabIndex = 31
        Me.rdDetalleCanjeLab.Text = "Detalle de Canje por Lab."
        Me.rdDetalleCanjeLab.UseVisualStyleBackColor = True
        '
        'rdLaboratorioSinFecha
        '
        Me.rdLaboratorioSinFecha.AutoSize = True
        Me.rdLaboratorioSinFecha.Location = New System.Drawing.Point(237, 80)
        Me.rdLaboratorioSinFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.rdLaboratorioSinFecha.Name = "rdLaboratorioSinFecha"
        Me.rdLaboratorioSinFecha.Size = New System.Drawing.Size(145, 21)
        Me.rdLaboratorioSinFecha.TabIndex = 29
        Me.rdLaboratorioSinFecha.Text = "Laboratorio Fecha"
        Me.rdLaboratorioSinFecha.UseVisualStyleBackColor = True
        '
        'rdDetalleSinTotal
        '
        Me.rdDetalleSinTotal.AutoSize = True
        Me.rdDetalleSinTotal.Location = New System.Drawing.Point(491, 23)
        Me.rdDetalleSinTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDetalleSinTotal.Name = "rdDetalleSinTotal"
        Me.rdDetalleSinTotal.Size = New System.Drawing.Size(147, 21)
        Me.rdDetalleSinTotal.TabIndex = 26
        Me.rdDetalleSinTotal.Text = "Detallado sin Total"
        Me.rdDetalleSinTotal.UseVisualStyleBackColor = True
        '
        'rdVentaResumenTipoProducto
        '
        Me.rdVentaResumenTipoProducto.AutoSize = True
        Me.rdVentaResumenTipoProducto.Location = New System.Drawing.Point(237, 52)
        Me.rdVentaResumenTipoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.rdVentaResumenTipoProducto.Name = "rdVentaResumenTipoProducto"
        Me.rdVentaResumenTipoProducto.Size = New System.Drawing.Size(227, 21)
        Me.rdVentaResumenTipoProducto.TabIndex = 25
        Me.rdVentaResumenTipoProducto.Text = "Resumen por Tipo de Producto"
        Me.rdVentaResumenTipoProducto.UseVisualStyleBackColor = True
        '
        'rdCantidadTipoProducto
        '
        Me.rdCantidadTipoProducto.AutoSize = True
        Me.rdCantidadTipoProducto.Location = New System.Drawing.Point(8, 107)
        Me.rdCantidadTipoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCantidadTipoProducto.Name = "rdCantidadTipoProducto"
        Me.rdCantidadTipoProducto.Size = New System.Drawing.Size(223, 21)
        Me.rdCantidadTipoProducto.TabIndex = 23
        Me.rdCantidadTipoProducto.Text = "Cantidad por Tipo de Producto"
        Me.rdCantidadTipoProducto.UseVisualStyleBackColor = True
        '
        'rdLaboratorioSinTotal
        '
        Me.rdLaboratorioSinTotal.AutoSize = True
        Me.rdLaboratorioSinTotal.Location = New System.Drawing.Point(8, 80)
        Me.rdLaboratorioSinTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.rdLaboratorioSinTotal.Name = "rdLaboratorioSinTotal"
        Me.rdLaboratorioSinTotal.Size = New System.Drawing.Size(217, 21)
        Me.rdLaboratorioSinTotal.TabIndex = 22
        Me.rdLaboratorioSinTotal.Text = "Laboratorio detallado S/ Total"
        Me.rdLaboratorioSinTotal.UseVisualStyleBackColor = True
        '
        'rdLaboratorio
        '
        Me.rdLaboratorio.AutoSize = True
        Me.rdLaboratorio.Location = New System.Drawing.Point(8, 52)
        Me.rdLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.rdLaboratorio.Name = "rdLaboratorio"
        Me.rdLaboratorio.Size = New System.Drawing.Size(164, 21)
        Me.rdLaboratorio.TabIndex = 21
        Me.rdLaboratorio.Text = "&Laboratorio detallado"
        Me.rdLaboratorio.UseVisualStyleBackColor = True
        '
        'rdAnulado
        '
        Me.rdAnulado.AutoSize = True
        Me.rdAnulado.Location = New System.Drawing.Point(492, 52)
        Me.rdAnulado.Margin = New System.Windows.Forms.Padding(4)
        Me.rdAnulado.Name = "rdAnulado"
        Me.rdAnulado.Size = New System.Drawing.Size(81, 21)
        Me.rdAnulado.TabIndex = 20
        Me.rdAnulado.Text = "&Anulado"
        Me.rdAnulado.UseVisualStyleBackColor = True
        '
        'rdDetalle
        '
        Me.rdDetalle.AutoSize = True
        Me.rdDetalle.Location = New System.Drawing.Point(237, 23)
        Me.rdDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDetalle.Name = "rdDetalle"
        Me.rdDetalle.Size = New System.Drawing.Size(89, 21)
        Me.rdDetalle.TabIndex = 19
        Me.rdDetalle.Text = "&Detallado"
        Me.rdDetalle.UseVisualStyleBackColor = True
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
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdPorMovimiento)
        Me.grOrdenar.Controls.Add(Me.rdPorFecha)
        Me.grOrdenar.Location = New System.Drawing.Point(384, 14)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Size = New System.Drawing.Size(156, 82)
        Me.grOrdenar.TabIndex = 98
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Ordenar"
        '
        'rdPorMovimiento
        '
        Me.rdPorMovimiento.AutoSize = True
        Me.rdPorMovimiento.Location = New System.Drawing.Point(11, 44)
        Me.rdPorMovimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.rdPorMovimiento.Name = "rdPorMovimiento"
        Me.rdPorMovimiento.Size = New System.Drawing.Size(126, 21)
        Me.rdPorMovimiento.TabIndex = 18
        Me.rdPorMovimiento.Text = "Por &Movimiento"
        Me.rdPorMovimiento.UseVisualStyleBackColor = True
        '
        'rdPorFecha
        '
        Me.rdPorFecha.AutoSize = True
        Me.rdPorFecha.Checked = True
        Me.rdPorFecha.Location = New System.Drawing.Point(11, 16)
        Me.rdPorFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.rdPorFecha.Name = "rdPorFecha"
        Me.rdPorFecha.Size = New System.Drawing.Size(94, 21)
        Me.rdPorFecha.TabIndex = 17
        Me.rdPorFecha.TabStop = True
        Me.rdPorFecha.Text = "&Por Fecha"
        Me.rdPorFecha.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkTodoSucursal)
        Me.GroupBox4.Controls.Add(Me.cboSucursal)
        Me.GroupBox4.Location = New System.Drawing.Point(31, 359)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(489, 79)
        Me.GroupBox4.TabIndex = 99
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Sucursal"
        '
        'chkTodoSucursal
        '
        Me.chkTodoSucursal.AutoSize = True
        Me.chkTodoSucursal.Location = New System.Drawing.Point(13, 54)
        Me.chkTodoSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTodoSucursal.Name = "chkTodoSucursal"
        Me.chkTodoSucursal.Size = New System.Drawing.Size(166, 21)
        Me.chkTodoSucursal.TabIndex = 51
        Me.chkTodoSucursal.Text = "Todas las Sucursales"
        Me.chkTodoSucursal.UseVisualStyleBackColor = True
        '
        'cboSucursal
        '
        Me.cboSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(12, 20)
        Me.cboSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(437, 28)
        Me.cboSucursal.TabIndex = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboLaboratorio)
        Me.GroupBox1.Location = New System.Drawing.Point(528, 446)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(489, 79)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Laboratorio"
        '
        'cboLaboratorio
        '
        Me.cboLaboratorio.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLaboratorio.FormattingEnabled = True
        Me.cboLaboratorio.Location = New System.Drawing.Point(19, 32)
        Me.cboLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLaboratorio.Name = "cboLaboratorio"
        Me.cboLaboratorio.Size = New System.Drawing.Size(437, 28)
        Me.cboLaboratorio.TabIndex = 50
        '
        'txtSql
        '
        Me.txtSql.Location = New System.Drawing.Point(16, 532)
        Me.txtSql.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(935, 22)
        Me.txtSql.TabIndex = 102
        Me.txtSql.Visible = False
        '
        'grTipoProducto
        '
        Me.grTipoProducto.Controls.Add(Me.cboTipoProducto)
        Me.grTipoProducto.Location = New System.Drawing.Point(28, 446)
        Me.grTipoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.grTipoProducto.Name = "grTipoProducto"
        Me.grTipoProducto.Padding = New System.Windows.Forms.Padding(4)
        Me.grTipoProducto.Size = New System.Drawing.Size(489, 79)
        Me.grTipoProducto.TabIndex = 100
        Me.grTipoProducto.TabStop = False
        Me.grTipoProducto.Text = "Tipo de Productos"
        '
        'cboTipoProducto
        '
        Me.cboTipoProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoProducto.FormattingEnabled = True
        Me.cboTipoProducto.Location = New System.Drawing.Point(19, 32)
        Me.cboTipoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoProducto.Name = "cboTipoProducto"
        Me.cboTipoProducto.Size = New System.Drawing.Size(437, 28)
        Me.cboTipoProducto.TabIndex = 50
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(804, 36)
        Me.txtPorcentaje.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(84, 22)
        Me.txtPorcentaje.TabIndex = 103
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(703, 37)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 20)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Porcentaje:"
        '
        'grReimpresion
        '
        Me.grReimpresion.Controls.Add(Me.txtFacturaFin)
        Me.grReimpresion.Controls.Add(Me.Label9)
        Me.grReimpresion.Controls.Add(Me.txtFacturaIni)
        Me.grReimpresion.Controls.Add(Me.Label8)
        Me.grReimpresion.Location = New System.Drawing.Point(668, 87)
        Me.grReimpresion.Margin = New System.Windows.Forms.Padding(4)
        Me.grReimpresion.Name = "grReimpresion"
        Me.grReimpresion.Padding = New System.Windows.Forms.Padding(4)
        Me.grReimpresion.Size = New System.Drawing.Size(235, 68)
        Me.grReimpresion.TabIndex = 104
        Me.grReimpresion.TabStop = False
        Me.grReimpresion.Visible = False
        '
        'txtFacturaFin
        '
        Me.txtFacturaFin.Location = New System.Drawing.Point(132, 37)
        Me.txtFacturaFin.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacturaFin.Name = "txtFacturaFin"
        Me.txtFacturaFin.Size = New System.Drawing.Size(84, 22)
        Me.txtFacturaFin.TabIndex = 106
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(135, 16)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "Fac. Fin."
        '
        'txtFacturaIni
        '
        Me.txtFacturaIni.Location = New System.Drawing.Point(8, 37)
        Me.txtFacturaIni.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacturaIni.Name = "txtFacturaIni"
        Me.txtFacturaIni.Size = New System.Drawing.Size(84, 22)
        Me.txtFacturaIni.TabIndex = 104
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 16)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 20)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Fac. Ini."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboTipoSucursal)
        Me.GroupBox2.Location = New System.Drawing.Point(525, 359)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(489, 79)
        Me.GroupBox2.TabIndex = 105
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Sucursal"
        '
        'cboTipoSucursal
        '
        Me.cboTipoSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoSucursal.FormattingEnabled = True
        Me.cboTipoSucursal.Location = New System.Drawing.Point(19, 32)
        Me.cboTipoSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoSucursal.Name = "cboTipoSucursal"
        Me.cboTipoSucursal.Size = New System.Drawing.Size(437, 28)
        Me.cboTipoSucursal.TabIndex = 50
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(556, 36)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 95
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'frmReporteVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 566)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grReimpresion)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.grTipoProducto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grMovimiento)
        Me.Controls.Add(Me.grFechaHora)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas"
        Me.grFechaHora.ResumeLayout(False)
        Me.grFechaHora.PerformLayout()
        Me.grMovimiento.ResumeLayout(False)
        Me.grMovimiento.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.grTipoProducto.ResumeLayout(False)
        Me.grReimpresion.ResumeLayout(False)
        Me.grReimpresion.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grFechaHora As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grMovimiento As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdMovFin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdmovIni2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdmovFin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdmovIni1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdAnulado As System.Windows.Forms.RadioButton
    Friend WithEvents rdDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rdResumen As System.Windows.Forms.RadioButton
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdPorMovimiento As System.Windows.Forms.RadioButton
    Friend WithEvents rdPorFecha As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents rdLaboratorio As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLaboratorio As System.Windows.Forms.ComboBox
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
    Friend WithEvents rdLaboratorioSinTotal As System.Windows.Forms.RadioButton
    Friend WithEvents rdCantidadTipoProducto As System.Windows.Forms.RadioButton
    Friend WithEvents grTipoProducto As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents chkTodoSucursal As System.Windows.Forms.CheckBox
    Friend WithEvents rdVentaResumenTipoProducto As System.Windows.Forms.RadioButton
    Friend WithEvents rdDetalleSinTotal As System.Windows.Forms.RadioButton
    Friend WithEvents rdLaboratorioSinFecha As System.Windows.Forms.RadioButton
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grReimpresion As System.Windows.Forms.GroupBox
    Friend WithEvents txtFacturaFin As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFacturaIni As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdDetalleCanjeLab As System.Windows.Forms.RadioButton
    Friend WithEvents rdCantidadVentaLaboratorio As System.Windows.Forms.RadioButton
    Friend WithEvents rdCantidadProducto As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents rdDatosCliente As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
