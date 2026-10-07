<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteMercaderiaGral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteMercaderiaGral))
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdMercaderiaConCaje = New System.Windows.Forms.RadioButton()
        Me.rdMercaderiaSinCanje = New System.Windows.Forms.RadioButton()
        Me.rdCostoPrecio = New System.Windows.Forms.RadioButton()
        Me.rdFueraLinea = New System.Windows.Forms.RadioButton()
        Me.rdMotivoAjuste = New System.Windows.Forms.RadioButton()
        Me.rdStockControladoTodasSuc = New System.Windows.Forms.RadioButton()
        Me.rdStockControladoSucursal = New System.Windows.Forms.RadioButton()
        Me.rdModificacionPrecios = New System.Windows.Forms.RadioButton()
        Me.rdDescuentoMaximo = New System.Windows.Forms.RadioButton()
        Me.rdUsoInterno = New System.Windows.Forms.RadioButton()
        Me.rdMercaderiaPendienteControlado = New System.Windows.Forms.RadioButton()
        Me.rdMercaderiaPendiente = New System.Windows.Forms.RadioButton()
        Me.rdBlackFriday = New System.Windows.Forms.RadioButton()
        Me.rdStockLaboratorio = New System.Windows.Forms.RadioButton()
        Me.rdStockControlado = New System.Windows.Forms.RadioButton()
        Me.rdMercaderiaSinFoto = New System.Windows.Forms.RadioButton()
        Me.rdMercaderiaEnviada = New System.Windows.Forms.RadioButton()
        Me.rdStockMenorCero = New System.Windows.Forms.RadioButton()
        Me.rdStockIgualCero = New System.Windows.Forms.RadioButton()
        Me.rdStockMayorCero = New System.Windows.Forms.RadioButton()
        Me.grDeposito = New System.Windows.Forms.GroupBox()
        Me.chkDeposito = New System.Windows.Forms.CheckBox()
        Me.cboDeposito = New System.Windows.Forms.ComboBox()
        Me.lblMercaderia = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblIdProducto = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grSucursal = New System.Windows.Forms.GroupBox()
        Me.chkTodoLaboratorio = New System.Windows.Forms.CheckBox()
        Me.cboLaoratorio = New System.Windows.Forms.ComboBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.txtContador = New System.Windows.Forms.TextBox()
        Me.rdCostoRefe = New System.Windows.Forms.RadioButton()
        Me.grOrdenar.SuspendLayout()
        Me.grDeposito.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grSucursal.SuspendLayout()
        Me.SuspendLayout()
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdCostoRefe)
        Me.grOrdenar.Controls.Add(Me.rdMercaderiaConCaje)
        Me.grOrdenar.Controls.Add(Me.rdMercaderiaSinCanje)
        Me.grOrdenar.Controls.Add(Me.rdCostoPrecio)
        Me.grOrdenar.Controls.Add(Me.rdFueraLinea)
        Me.grOrdenar.Controls.Add(Me.rdMotivoAjuste)
        Me.grOrdenar.Controls.Add(Me.rdStockControladoTodasSuc)
        Me.grOrdenar.Controls.Add(Me.rdStockControladoSucursal)
        Me.grOrdenar.Controls.Add(Me.rdModificacionPrecios)
        Me.grOrdenar.Controls.Add(Me.rdDescuentoMaximo)
        Me.grOrdenar.Controls.Add(Me.rdUsoInterno)
        Me.grOrdenar.Controls.Add(Me.rdMercaderiaPendienteControlado)
        Me.grOrdenar.Controls.Add(Me.rdMercaderiaPendiente)
        Me.grOrdenar.Controls.Add(Me.rdBlackFriday)
        Me.grOrdenar.Controls.Add(Me.rdStockLaboratorio)
        Me.grOrdenar.Controls.Add(Me.rdStockControlado)
        Me.grOrdenar.Controls.Add(Me.rdMercaderiaSinFoto)
        Me.grOrdenar.Controls.Add(Me.rdMercaderiaEnviada)
        Me.grOrdenar.Controls.Add(Me.rdStockMenorCero)
        Me.grOrdenar.Controls.Add(Me.rdStockIgualCero)
        Me.grOrdenar.Controls.Add(Me.rdStockMayorCero)
        Me.grOrdenar.Location = New System.Drawing.Point(5, 15)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Size = New System.Drawing.Size(336, 625)
        Me.grOrdenar.TabIndex = 99
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Opciones"
        '
        'rdMercaderiaConCaje
        '
        Me.rdMercaderiaConCaje.AutoSize = True
        Me.rdMercaderiaConCaje.Location = New System.Drawing.Point(11, 552)
        Me.rdMercaderiaConCaje.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMercaderiaConCaje.Name = "rdMercaderiaConCaje"
        Me.rdMercaderiaConCaje.Size = New System.Drawing.Size(174, 21)
        Me.rdMercaderiaConCaje.TabIndex = 36
        Me.rdMercaderiaConCaje.Text = "Mercaderías con Canje"
        Me.rdMercaderiaConCaje.UseVisualStyleBackColor = True
        '
        'rdMercaderiaSinCanje
        '
        Me.rdMercaderiaSinCanje.AutoSize = True
        Me.rdMercaderiaSinCanje.Location = New System.Drawing.Point(11, 523)
        Me.rdMercaderiaSinCanje.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMercaderiaSinCanje.Name = "rdMercaderiaSinCanje"
        Me.rdMercaderiaSinCanje.Size = New System.Drawing.Size(169, 21)
        Me.rdMercaderiaSinCanje.TabIndex = 35
        Me.rdMercaderiaSinCanje.Text = "Mercaderías sin Canje"
        Me.rdMercaderiaSinCanje.UseVisualStyleBackColor = True
        '
        'rdCostoPrecio
        '
        Me.rdCostoPrecio.AutoSize = True
        Me.rdCostoPrecio.Location = New System.Drawing.Point(11, 494)
        Me.rdCostoPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCostoPrecio.Name = "rdCostoPrecio"
        Me.rdCostoPrecio.Size = New System.Drawing.Size(133, 21)
        Me.rdCostoPrecio.TabIndex = 34
        Me.rdCostoPrecio.Text = "Costos y precios"
        Me.rdCostoPrecio.UseVisualStyleBackColor = True
        '
        'rdFueraLinea
        '
        Me.rdFueraLinea.AutoSize = True
        Me.rdFueraLinea.Location = New System.Drawing.Point(9, 465)
        Me.rdFueraLinea.Margin = New System.Windows.Forms.Padding(4)
        Me.rdFueraLinea.Name = "rdFueraLinea"
        Me.rdFueraLinea.Size = New System.Drawing.Size(198, 21)
        Me.rdFueraLinea.TabIndex = 33
        Me.rdFueraLinea.Text = "Mercaderias fuera de linea"
        Me.rdFueraLinea.UseVisualStyleBackColor = True
        '
        'rdMotivoAjuste
        '
        Me.rdMotivoAjuste.AutoSize = True
        Me.rdMotivoAjuste.Location = New System.Drawing.Point(11, 437)
        Me.rdMotivoAjuste.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMotivoAjuste.Name = "rdMotivoAjuste"
        Me.rdMotivoAjuste.Size = New System.Drawing.Size(133, 21)
        Me.rdMotivoAjuste.TabIndex = 32
        Me.rdMotivoAjuste.Text = "Motivo de Ajuste"
        Me.rdMotivoAjuste.UseVisualStyleBackColor = True
        '
        'rdStockControladoTodasSuc
        '
        Me.rdStockControladoTodasSuc.AutoSize = True
        Me.rdStockControladoTodasSuc.Location = New System.Drawing.Point(11, 409)
        Me.rdStockControladoTodasSuc.Margin = New System.Windows.Forms.Padding(4)
        Me.rdStockControladoTodasSuc.Name = "rdStockControladoTodasSuc"
        Me.rdStockControladoTodasSuc.Size = New System.Drawing.Size(257, 21)
        Me.rdStockControladoTodasSuc.TabIndex = 31
        Me.rdStockControladoTodasSuc.Text = "Stock de Controlados todas las Suc."
        Me.rdStockControladoTodasSuc.UseVisualStyleBackColor = True
        '
        'rdStockControladoSucursal
        '
        Me.rdStockControladoSucursal.AutoSize = True
        Me.rdStockControladoSucursal.Location = New System.Drawing.Point(11, 379)
        Me.rdStockControladoSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.rdStockControladoSucursal.Name = "rdStockControladoSucursal"
        Me.rdStockControladoSucursal.Size = New System.Drawing.Size(248, 21)
        Me.rdStockControladoSucursal.TabIndex = 30
        Me.rdStockControladoSucursal.Text = "Stock de Controlados por Sucursal"
        Me.rdStockControladoSucursal.UseVisualStyleBackColor = True
        '
        'rdModificacionPrecios
        '
        Me.rdModificacionPrecios.AutoSize = True
        Me.rdModificacionPrecios.Location = New System.Drawing.Point(11, 351)
        Me.rdModificacionPrecios.Margin = New System.Windows.Forms.Padding(4)
        Me.rdModificacionPrecios.Name = "rdModificacionPrecios"
        Me.rdModificacionPrecios.Size = New System.Drawing.Size(251, 21)
        Me.rdModificacionPrecios.TabIndex = 29
        Me.rdModificacionPrecios.Text = "Modificación de Precios de Enteros"
        Me.rdModificacionPrecios.UseVisualStyleBackColor = True
        '
        'rdDescuentoMaximo
        '
        Me.rdDescuentoMaximo.AutoSize = True
        Me.rdDescuentoMaximo.Location = New System.Drawing.Point(9, 322)
        Me.rdDescuentoMaximo.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDescuentoMaximo.Name = "rdDescuentoMaximo"
        Me.rdDescuentoMaximo.Size = New System.Drawing.Size(257, 21)
        Me.rdDescuentoMaximo.TabIndex = 28
        Me.rdDescuentoMaximo.Text = "Mercaderías con Descuento Máximo"
        Me.rdDescuentoMaximo.UseVisualStyleBackColor = True
        '
        'rdUsoInterno
        '
        Me.rdUsoInterno.AutoSize = True
        Me.rdUsoInterno.Location = New System.Drawing.Point(9, 295)
        Me.rdUsoInterno.Margin = New System.Windows.Forms.Padding(4)
        Me.rdUsoInterno.Name = "rdUsoInterno"
        Me.rdUsoInterno.Size = New System.Drawing.Size(204, 21)
        Me.rdUsoInterno.TabIndex = 27
        Me.rdUsoInterno.Text = "Mercaderías de Uso Interno"
        Me.rdUsoInterno.UseVisualStyleBackColor = True
        '
        'rdMercaderiaPendienteControlado
        '
        Me.rdMercaderiaPendienteControlado.AutoSize = True
        Me.rdMercaderiaPendienteControlado.Location = New System.Drawing.Point(11, 267)
        Me.rdMercaderiaPendienteControlado.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMercaderiaPendienteControlado.Name = "rdMercaderiaPendienteControlado"
        Me.rdMercaderiaPendienteControlado.Size = New System.Drawing.Size(262, 21)
        Me.rdMercaderiaPendienteControlado.TabIndex = 26
        Me.rdMercaderiaPendienteControlado.Text = "Mercaderías Pendientes Controlados"
        Me.rdMercaderiaPendienteControlado.UseVisualStyleBackColor = True
        '
        'rdMercaderiaPendiente
        '
        Me.rdMercaderiaPendiente.AutoSize = True
        Me.rdMercaderiaPendiente.Location = New System.Drawing.Point(11, 239)
        Me.rdMercaderiaPendiente.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMercaderiaPendiente.Name = "rdMercaderiaPendiente"
        Me.rdMercaderiaPendiente.Size = New System.Drawing.Size(238, 21)
        Me.rdMercaderiaPendiente.TabIndex = 25
        Me.rdMercaderiaPendiente.Text = "Mercaderías Pendientes a Enviar"
        Me.rdMercaderiaPendiente.UseVisualStyleBackColor = True
        '
        'rdBlackFriday
        '
        Me.rdBlackFriday.AutoSize = True
        Me.rdBlackFriday.Location = New System.Drawing.Point(11, 210)
        Me.rdBlackFriday.Margin = New System.Windows.Forms.Padding(4)
        Me.rdBlackFriday.Name = "rdBlackFriday"
        Me.rdBlackFriday.Size = New System.Drawing.Size(201, 21)
        Me.rdBlackFriday.TabIndex = 24
        Me.rdBlackFriday.Text = "Descuentos de BlackFriday"
        Me.rdBlackFriday.UseVisualStyleBackColor = True
        '
        'rdStockLaboratorio
        '
        Me.rdStockLaboratorio.AutoSize = True
        Me.rdStockLaboratorio.Location = New System.Drawing.Point(9, 182)
        Me.rdStockLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.rdStockLaboratorio.Name = "rdStockLaboratorio"
        Me.rdStockLaboratorio.Size = New System.Drawing.Size(166, 21)
        Me.rdStockLaboratorio.TabIndex = 23
        Me.rdStockLaboratorio.Text = "Stock por Laboratorio"
        Me.rdStockLaboratorio.UseVisualStyleBackColor = True
        '
        'rdStockControlado
        '
        Me.rdStockControlado.AutoSize = True
        Me.rdStockControlado.Location = New System.Drawing.Point(9, 154)
        Me.rdStockControlado.Margin = New System.Windows.Forms.Padding(4)
        Me.rdStockControlado.Name = "rdStockControlado"
        Me.rdStockControlado.Size = New System.Drawing.Size(164, 21)
        Me.rdStockControlado.TabIndex = 22
        Me.rdStockControlado.Text = "Stock de Controlados"
        Me.rdStockControlado.UseVisualStyleBackColor = True
        '
        'rdMercaderiaSinFoto
        '
        Me.rdMercaderiaSinFoto.AutoSize = True
        Me.rdMercaderiaSinFoto.Location = New System.Drawing.Point(9, 126)
        Me.rdMercaderiaSinFoto.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMercaderiaSinFoto.Name = "rdMercaderiaSinFoto"
        Me.rdMercaderiaSinFoto.Size = New System.Drawing.Size(174, 21)
        Me.rdMercaderiaSinFoto.TabIndex = 21
        Me.rdMercaderiaSinFoto.Text = "Mercadería Sin Imagen"
        Me.rdMercaderiaSinFoto.UseVisualStyleBackColor = True
        '
        'rdMercaderiaEnviada
        '
        Me.rdMercaderiaEnviada.AutoSize = True
        Me.rdMercaderiaEnviada.Location = New System.Drawing.Point(9, 98)
        Me.rdMercaderiaEnviada.Margin = New System.Windows.Forms.Padding(4)
        Me.rdMercaderiaEnviada.Name = "rdMercaderiaEnviada"
        Me.rdMercaderiaEnviada.Size = New System.Drawing.Size(155, 21)
        Me.rdMercaderiaEnviada.TabIndex = 20
        Me.rdMercaderiaEnviada.Text = "Mercadería Enviada"
        Me.rdMercaderiaEnviada.UseVisualStyleBackColor = True
        '
        'rdStockMenorCero
        '
        Me.rdStockMenorCero.AutoSize = True
        Me.rdStockMenorCero.Location = New System.Drawing.Point(11, 73)
        Me.rdStockMenorCero.Margin = New System.Windows.Forms.Padding(4)
        Me.rdStockMenorCero.Name = "rdStockMenorCero"
        Me.rdStockMenorCero.Size = New System.Drawing.Size(152, 21)
        Me.rdStockMenorCero.TabIndex = 19
        Me.rdStockMenorCero.Text = "Stock menor a cero"
        Me.rdStockMenorCero.UseVisualStyleBackColor = True
        '
        'rdStockIgualCero
        '
        Me.rdStockIgualCero.AutoSize = True
        Me.rdStockIgualCero.Location = New System.Drawing.Point(11, 44)
        Me.rdStockIgualCero.Margin = New System.Windows.Forms.Padding(4)
        Me.rdStockIgualCero.Name = "rdStockIgualCero"
        Me.rdStockIgualCero.Size = New System.Drawing.Size(142, 21)
        Me.rdStockIgualCero.TabIndex = 18
        Me.rdStockIgualCero.Text = "Stock igual a cero"
        Me.rdStockIgualCero.UseVisualStyleBackColor = True
        '
        'rdStockMayorCero
        '
        Me.rdStockMayorCero.AutoSize = True
        Me.rdStockMayorCero.Location = New System.Drawing.Point(11, 16)
        Me.rdStockMayorCero.Margin = New System.Windows.Forms.Padding(4)
        Me.rdStockMayorCero.Name = "rdStockMayorCero"
        Me.rdStockMayorCero.Size = New System.Drawing.Size(151, 21)
        Me.rdStockMayorCero.TabIndex = 17
        Me.rdStockMayorCero.Text = "Stock mayor a cero"
        Me.rdStockMayorCero.UseVisualStyleBackColor = True
        '
        'grDeposito
        '
        Me.grDeposito.Controls.Add(Me.chkDeposito)
        Me.grDeposito.Controls.Add(Me.cboDeposito)
        Me.grDeposito.Location = New System.Drawing.Point(352, 15)
        Me.grDeposito.Margin = New System.Windows.Forms.Padding(4)
        Me.grDeposito.Name = "grDeposito"
        Me.grDeposito.Padding = New System.Windows.Forms.Padding(4)
        Me.grDeposito.Size = New System.Drawing.Size(471, 94)
        Me.grDeposito.TabIndex = 101
        Me.grDeposito.TabStop = False
        Me.grDeposito.Text = "Deposito"
        '
        'chkDeposito
        '
        Me.chkDeposito.AutoSize = True
        Me.chkDeposito.Location = New System.Drawing.Point(12, 64)
        Me.chkDeposito.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDeposito.Name = "chkDeposito"
        Me.chkDeposito.Size = New System.Drawing.Size(159, 21)
        Me.chkDeposito.TabIndex = 109
        Me.chkDeposito.Text = "Todos los Depositos"
        Me.chkDeposito.UseVisualStyleBackColor = True
        '
        'cboDeposito
        '
        Me.cboDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDeposito.FormattingEnabled = True
        Me.cboDeposito.Location = New System.Drawing.Point(8, 23)
        Me.cboDeposito.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDeposito.Name = "cboDeposito"
        Me.cboDeposito.Size = New System.Drawing.Size(449, 28)
        Me.cboDeposito.TabIndex = 108
        '
        'lblMercaderia
        '
        Me.lblMercaderia.AutoSize = True
        Me.lblMercaderia.BackColor = System.Drawing.Color.Lime
        Me.lblMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercaderia.Location = New System.Drawing.Point(355, 236)
        Me.lblMercaderia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMercaderia.Name = "lblMercaderia"
        Me.lblMercaderia.Size = New System.Drawing.Size(144, 24)
        Me.lblMercaderia.TabIndex = 102
        Me.lblMercaderia.Text = "MERCADERIA"
        Me.lblMercaderia.Visible = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Lime
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(355, 260)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(90, 24)
        Me.lblCodigo.TabIndex = 103
        Me.lblCodigo.Text = "CODIGO"
        Me.lblCodigo.Visible = False
        '
        'lblIdProducto
        '
        Me.lblIdProducto.AutoSize = True
        Me.lblIdProducto.BackColor = System.Drawing.Color.Gold
        Me.lblIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProducto.Location = New System.Drawing.Point(497, 260)
        Me.lblIdProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdProducto.Name = "lblIdProducto"
        Me.lblIdProducto.Size = New System.Drawing.Size(143, 24)
        Me.lblIdProducto.TabIndex = 104
        Me.lblIdProducto.Text = "IDPRODUCTO"
        Me.lblIdProducto.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(352, 116)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(247, 117)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha "
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(80, 78)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4)
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
        Me.dtpDesdeFecha.Margin = New System.Windows.Forms.Padding(4)
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
        'grSucursal
        '
        Me.grSucursal.Controls.Add(Me.chkTodoLaboratorio)
        Me.grSucursal.Controls.Add(Me.cboLaoratorio)
        Me.grSucursal.Location = New System.Drawing.Point(356, 298)
        Me.grSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.grSucursal.Name = "grSucursal"
        Me.grSucursal.Padding = New System.Windows.Forms.Padding(4)
        Me.grSucursal.Size = New System.Drawing.Size(471, 113)
        Me.grSucursal.TabIndex = 115
        Me.grSucursal.TabStop = False
        Me.grSucursal.Text = "Laboratorio"
        '
        'chkTodoLaboratorio
        '
        Me.chkTodoLaboratorio.AutoSize = True
        Me.chkTodoLaboratorio.Location = New System.Drawing.Point(13, 68)
        Me.chkTodoLaboratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTodoLaboratorio.Name = "chkTodoLaboratorio"
        Me.chkTodoLaboratorio.Size = New System.Drawing.Size(176, 21)
        Me.chkTodoLaboratorio.TabIndex = 110
        Me.chkTodoLaboratorio.Text = "Todos los Laboratorios"
        Me.chkTodoLaboratorio.UseVisualStyleBackColor = True
        '
        'cboLaoratorio
        '
        Me.cboLaoratorio.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboLaoratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLaoratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLaoratorio.FormattingEnabled = True
        Me.cboLaoratorio.Location = New System.Drawing.Point(8, 23)
        Me.cboLaoratorio.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLaoratorio.Name = "cboLaoratorio"
        Me.cboLaoratorio.Size = New System.Drawing.Size(449, 28)
        Me.cboLaoratorio.TabIndex = 108
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(643, 130)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 111
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtContador
        '
        Me.txtContador.BackColor = System.Drawing.Color.Chartreuse
        Me.txtContador.Enabled = False
        Me.txtContador.Location = New System.Drawing.Point(454, 460)
        Me.txtContador.Name = "txtContador"
        Me.txtContador.Size = New System.Drawing.Size(100, 22)
        Me.txtContador.TabIndex = 116
        '
        'rdCostoRefe
        '
        Me.rdCostoRefe.AutoSize = True
        Me.rdCostoRefe.Location = New System.Drawing.Point(11, 581)
        Me.rdCostoRefe.Margin = New System.Windows.Forms.Padding(4)
        Me.rdCostoRefe.Name = "rdCostoRefe"
        Me.rdCostoRefe.Size = New System.Drawing.Size(261, 21)
        Me.rdCostoRefe.TabIndex = 37
        Me.rdCostoRefe.Text = "Costos de Agregados Referenciados"
        Me.rdCostoRefe.UseVisualStyleBackColor = True
        '
        'frmReporteMercaderiaGral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 672)
        Me.Controls.Add(Me.txtContador)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.grSucursal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblIdProducto)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.lblMercaderia)
        Me.Controls.Add(Me.grDeposito)
        Me.Controls.Add(Me.grOrdenar)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteMercaderiaGral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Mercaderías en Gral."
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.grDeposito.ResumeLayout(False)
        Me.grDeposito.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grSucursal.ResumeLayout(False)
        Me.grSucursal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdStockIgualCero As System.Windows.Forms.RadioButton
    Friend WithEvents rdStockMayorCero As System.Windows.Forms.RadioButton
    Friend WithEvents rdStockMenorCero As System.Windows.Forms.RadioButton
    Friend WithEvents grDeposito As System.Windows.Forms.GroupBox
    Friend WithEvents cboDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents rdMercaderiaEnviada As System.Windows.Forms.RadioButton
    Friend WithEvents lblMercaderia As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblIdProducto As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdMercaderiaSinFoto As System.Windows.Forms.RadioButton
    Friend WithEvents rdStockControlado As System.Windows.Forms.RadioButton
    Friend WithEvents rdStockLaboratorio As System.Windows.Forms.RadioButton
    Friend WithEvents grSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents cboLaoratorio As System.Windows.Forms.ComboBox
    Friend WithEvents rdBlackFriday As System.Windows.Forms.RadioButton
    Friend WithEvents rdMercaderiaPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents rdMercaderiaPendienteControlado As System.Windows.Forms.RadioButton
    Friend WithEvents rdUsoInterno As System.Windows.Forms.RadioButton
    Friend WithEvents chkDeposito As System.Windows.Forms.CheckBox
    Friend WithEvents rdDescuentoMaximo As System.Windows.Forms.RadioButton
    Friend WithEvents rdModificacionPrecios As System.Windows.Forms.RadioButton
    Friend WithEvents chkTodoLaboratorio As System.Windows.Forms.CheckBox
    Friend WithEvents rdStockControladoSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents rdStockControladoTodasSuc As System.Windows.Forms.RadioButton
    Friend WithEvents rdMotivoAjuste As System.Windows.Forms.RadioButton
    Friend WithEvents rdFueraLinea As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents rdCostoPrecio As System.Windows.Forms.RadioButton
    Friend WithEvents txtContador As System.Windows.Forms.TextBox
    Friend WithEvents rdMercaderiaSinCanje As System.Windows.Forms.RadioButton
    Friend WithEvents rdMercaderiaConCaje As System.Windows.Forms.RadioButton
    Friend WithEvents rdCostoRefe As System.Windows.Forms.RadioButton
End Class
