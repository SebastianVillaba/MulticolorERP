<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadisticaMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadisticaMercaderia))
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdMercaderiaSinRemision = New System.Windows.Forms.RadioButton()
        Me.rdValoracionStockDeposito = New System.Windows.Forms.RadioButton()
        Me.rdPedidoHeladeria = New System.Windows.Forms.RadioButton()
        Me.rdUsoInterno = New System.Windows.Forms.RadioButton()
        Me.rdRankingCantidad = New System.Windows.Forms.RadioButton()
        Me.rdCostoMenor = New System.Windows.Forms.RadioButton()
        Me.rdCostoMayor = New System.Windows.Forms.RadioButton()
        Me.rdValoracionStock = New System.Windows.Forms.RadioButton()
        Me.grFecha = New System.Windows.Forms.GroupBox()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIdProducto = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblMercaderia = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grDatoMercaderia = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grDeposito = New System.Windows.Forms.GroupBox()
        Me.chkTodoDeposito = New System.Windows.Forms.CheckBox()
        Me.cboDeposito = New System.Windows.Forms.ComboBox()
        Me.grSucursal = New System.Windows.Forms.GroupBox()
        Me.chkTodaSucursal = New System.Windows.Forms.CheckBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.grRanking = New System.Windows.Forms.GroupBox()
        Me.rdRankingEnvio = New System.Windows.Forms.RadioButton()
        Me.rdRankingCompra = New System.Windows.Forms.RadioButton()
        Me.rdRankingVenta = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboTipoProducto = New System.Windows.Forms.ComboBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.grOrdenar.SuspendLayout()
        Me.grFecha.SuspendLayout()
        Me.grDatoMercaderia.SuspendLayout()
        Me.grDeposito.SuspendLayout()
        Me.grSucursal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grRanking.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdMercaderiaSinRemision)
        Me.grOrdenar.Controls.Add(Me.rdValoracionStockDeposito)
        Me.grOrdenar.Controls.Add(Me.rdPedidoHeladeria)
        Me.grOrdenar.Controls.Add(Me.rdUsoInterno)
        Me.grOrdenar.Controls.Add(Me.rdRankingCantidad)
        Me.grOrdenar.Controls.Add(Me.rdCostoMenor)
        Me.grOrdenar.Controls.Add(Me.rdCostoMayor)
        Me.grOrdenar.Controls.Add(Me.rdValoracionStock)
        Me.grOrdenar.Location = New System.Drawing.Point(12, 10)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Size = New System.Drawing.Size(164, 222)
        Me.grOrdenar.TabIndex = 100
        Me.grOrdenar.TabStop = False
        Me.grOrdenar.Text = "Opciones"
        '
        'rdMercaderiaSinRemision
        '
        Me.rdMercaderiaSinRemision.AutoSize = True
        Me.rdMercaderiaSinRemision.Location = New System.Drawing.Point(7, 185)
        Me.rdMercaderiaSinRemision.Name = "rdMercaderiaSinRemision"
        Me.rdMercaderiaSinRemision.Size = New System.Drawing.Size(147, 17)
        Me.rdMercaderiaSinRemision.TabIndex = 24
        Me.rdMercaderiaSinRemision.Text = "Mercaderías sin Remisión"
        Me.rdMercaderiaSinRemision.UseVisualStyleBackColor = True
        '
        'rdValoracionStockDeposito
        '
        Me.rdValoracionStockDeposito.AutoSize = True
        Me.rdValoracionStockDeposito.Location = New System.Drawing.Point(8, 158)
        Me.rdValoracionStockDeposito.Name = "rdValoracionStockDeposito"
        Me.rdValoracionStockDeposito.Size = New System.Drawing.Size(155, 17)
        Me.rdValoracionStockDeposito.TabIndex = 23
        Me.rdValoracionStockDeposito.Text = "Valoración del Stock Depo."
        Me.rdValoracionStockDeposito.UseVisualStyleBackColor = True
        '
        'rdPedidoHeladeria
        '
        Me.rdPedidoHeladeria.AutoSize = True
        Me.rdPedidoHeladeria.Location = New System.Drawing.Point(8, 135)
        Me.rdPedidoHeladeria.Name = "rdPedidoHeladeria"
        Me.rdPedidoHeladeria.Size = New System.Drawing.Size(126, 17)
        Me.rdPedidoHeladeria.TabIndex = 22
        Me.rdPedidoHeladeria.Text = "Pedido de Heladerias"
        Me.rdPedidoHeladeria.UseVisualStyleBackColor = True
        '
        'rdUsoInterno
        '
        Me.rdUsoInterno.AutoSize = True
        Me.rdUsoInterno.Location = New System.Drawing.Point(8, 112)
        Me.rdUsoInterno.Name = "rdUsoInterno"
        Me.rdUsoInterno.Size = New System.Drawing.Size(154, 17)
        Me.rdUsoInterno.TabIndex = 21
        Me.rdUsoInterno.Text = "Facturación de Uso Interno"
        Me.rdUsoInterno.UseVisualStyleBackColor = True
        '
        'rdRankingCantidad
        '
        Me.rdRankingCantidad.AutoSize = True
        Me.rdRankingCantidad.Location = New System.Drawing.Point(8, 89)
        Me.rdRankingCantidad.Name = "rdRankingCantidad"
        Me.rdRankingCantidad.Size = New System.Drawing.Size(125, 17)
        Me.rdRankingCantidad.TabIndex = 20
        Me.rdRankingCantidad.Text = "Ranking de Cantidad"
        Me.rdRankingCantidad.UseVisualStyleBackColor = True
        '
        'rdCostoMenor
        '
        Me.rdCostoMenor.AutoSize = True
        Me.rdCostoMenor.Location = New System.Drawing.Point(8, 66)
        Me.rdCostoMenor.Name = "rdCostoMenor"
        Me.rdCostoMenor.Size = New System.Drawing.Size(102, 17)
        Me.rdCostoMenor.TabIndex = 19
        Me.rdCostoMenor.Text = "Costos Menor a "
        Me.rdCostoMenor.UseVisualStyleBackColor = True
        '
        'rdCostoMayor
        '
        Me.rdCostoMayor.AutoSize = True
        Me.rdCostoMayor.Location = New System.Drawing.Point(8, 43)
        Me.rdCostoMayor.Name = "rdCostoMayor"
        Me.rdCostoMayor.Size = New System.Drawing.Size(101, 17)
        Me.rdCostoMayor.TabIndex = 18
        Me.rdCostoMayor.Text = "Costos Mayor a "
        Me.rdCostoMayor.UseVisualStyleBackColor = True
        '
        'rdValoracionStock
        '
        Me.rdValoracionStock.AutoSize = True
        Me.rdValoracionStock.Location = New System.Drawing.Point(8, 20)
        Me.rdValoracionStock.Name = "rdValoracionStock"
        Me.rdValoracionStock.Size = New System.Drawing.Size(148, 17)
        Me.rdValoracionStock.TabIndex = 17
        Me.rdValoracionStock.Text = "Valoración del Stock Suc."
        Me.rdValoracionStock.UseVisualStyleBackColor = True
        '
        'grFecha
        '
        Me.grFecha.Controls.Add(Me.dtpHastaFecha)
        Me.grFecha.Controls.Add(Me.Label6)
        Me.grFecha.Controls.Add(Me.dtpDesdeFecha)
        Me.grFecha.Controls.Add(Me.Label5)
        Me.grFecha.Location = New System.Drawing.Point(182, 12)
        Me.grFecha.Name = "grFecha"
        Me.grFecha.Size = New System.Drawing.Size(185, 95)
        Me.grFecha.TabIndex = 106
        Me.grFecha.TabStop = False
        Me.grFecha.Text = "Fecha "
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
        'lblIdProducto
        '
        Me.lblIdProducto.AutoSize = True
        Me.lblIdProducto.BackColor = System.Drawing.Color.Gold
        Me.lblIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProducto.Location = New System.Drawing.Point(146, 61)
        Me.lblIdProducto.Name = "lblIdProducto"
        Me.lblIdProducto.Size = New System.Drawing.Size(119, 18)
        Me.lblIdProducto.TabIndex = 109
        Me.lblIdProducto.Text = "IDPRODUCTO"
        Me.lblIdProducto.Visible = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Lime
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(65, 61)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(75, 18)
        Me.lblCodigo.TabIndex = 108
        Me.lblCodigo.Text = "CODIGO"
        Me.lblCodigo.Visible = False
        '
        'lblMercaderia
        '
        Me.lblMercaderia.AutoSize = True
        Me.lblMercaderia.BackColor = System.Drawing.Color.Lime
        Me.lblMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMercaderia.Location = New System.Drawing.Point(86, 30)
        Me.lblMercaderia.Name = "lblMercaderia"
        Me.lblMercaderia.Size = New System.Drawing.Size(116, 18)
        Me.lblMercaderia.TabIndex = 107
        Me.lblMercaderia.Text = "MERCADERIA"
        Me.lblMercaderia.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Mercadería:"
        '
        'grDatoMercaderia
        '
        Me.grDatoMercaderia.Controls.Add(Me.Label2)
        Me.grDatoMercaderia.Controls.Add(Me.lblIdProducto)
        Me.grDatoMercaderia.Controls.Add(Me.Label1)
        Me.grDatoMercaderia.Controls.Add(Me.lblCodigo)
        Me.grDatoMercaderia.Controls.Add(Me.lblMercaderia)
        Me.grDatoMercaderia.Location = New System.Drawing.Point(181, 112)
        Me.grDatoMercaderia.Name = "grDatoMercaderia"
        Me.grDatoMercaderia.Size = New System.Drawing.Size(471, 100)
        Me.grDatoMercaderia.TabIndex = 111
        Me.grDatoMercaderia.TabStop = False
        Me.grDatoMercaderia.Text = "Datos de la Mercadería"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Codigo:"
        '
        'grDeposito
        '
        Me.grDeposito.Controls.Add(Me.chkTodoDeposito)
        Me.grDeposito.Controls.Add(Me.cboDeposito)
        Me.grDeposito.Location = New System.Drawing.Point(178, 219)
        Me.grDeposito.Name = "grDeposito"
        Me.grDeposito.Size = New System.Drawing.Size(353, 71)
        Me.grDeposito.TabIndex = 113
        Me.grDeposito.TabStop = False
        Me.grDeposito.Text = "Deposito"
        '
        'chkTodoDeposito
        '
        Me.chkTodoDeposito.AutoSize = True
        Me.chkTodoDeposito.Location = New System.Drawing.Point(8, 51)
        Me.chkTodoDeposito.Name = "chkTodoDeposito"
        Me.chkTodoDeposito.Size = New System.Drawing.Size(122, 17)
        Me.chkTodoDeposito.TabIndex = 110
        Me.chkTodoDeposito.Text = "Todos los Depositos"
        Me.chkTodoDeposito.UseVisualStyleBackColor = True
        '
        'cboDeposito
        '
        Me.cboDeposito.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDeposito.FormattingEnabled = True
        Me.cboDeposito.Location = New System.Drawing.Point(6, 19)
        Me.cboDeposito.Name = "cboDeposito"
        Me.cboDeposito.Size = New System.Drawing.Size(338, 24)
        Me.cboDeposito.TabIndex = 108
        '
        'grSucursal
        '
        Me.grSucursal.Controls.Add(Me.chkTodaSucursal)
        Me.grSucursal.Controls.Add(Me.cboSucursal)
        Me.grSucursal.Location = New System.Drawing.Point(178, 296)
        Me.grSucursal.Name = "grSucursal"
        Me.grSucursal.Size = New System.Drawing.Size(353, 79)
        Me.grSucursal.TabIndex = 114
        Me.grSucursal.TabStop = False
        Me.grSucursal.Text = "Sucursal"
        '
        'chkTodaSucursal
        '
        Me.chkTodaSucursal.AutoSize = True
        Me.chkTodaSucursal.Location = New System.Drawing.Point(4, 52)
        Me.chkTodaSucursal.Name = "chkTodaSucursal"
        Me.chkTodaSucursal.Size = New System.Drawing.Size(127, 17)
        Me.chkTodaSucursal.TabIndex = 109
        Me.chkTodaSucursal.Text = "Todas las Sucursales"
        Me.chkTodaSucursal.UseVisualStyleBackColor = True
        '
        'cboSucursal
        '
        Me.cboSucursal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(6, 19)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(338, 24)
        Me.cboSucursal.TabIndex = 108
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Location = New System.Drawing.Point(377, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(145, 66)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opcion Mayor o Igual"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(22, 28)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(74, 20)
        Me.txtCantidad.TabIndex = 0
        '
        'grRanking
        '
        Me.grRanking.Controls.Add(Me.rdRankingEnvio)
        Me.grRanking.Controls.Add(Me.rdRankingCompra)
        Me.grRanking.Controls.Add(Me.rdRankingVenta)
        Me.grRanking.Location = New System.Drawing.Point(550, 227)
        Me.grRanking.Name = "grRanking"
        Me.grRanking.Size = New System.Drawing.Size(144, 93)
        Me.grRanking.TabIndex = 101
        Me.grRanking.TabStop = False
        Me.grRanking.Text = "Opciones"
        Me.grRanking.Visible = False
        '
        'rdRankingEnvio
        '
        Me.rdRankingEnvio.AutoSize = True
        Me.rdRankingEnvio.Location = New System.Drawing.Point(8, 66)
        Me.rdRankingEnvio.Name = "rdRankingEnvio"
        Me.rdRankingEnvio.Size = New System.Drawing.Size(92, 17)
        Me.rdRankingEnvio.TabIndex = 19
        Me.rdRankingEnvio.Text = "Mas Enviados"
        Me.rdRankingEnvio.UseVisualStyleBackColor = True
        '
        'rdRankingCompra
        '
        Me.rdRankingCompra.AutoSize = True
        Me.rdRankingCompra.Location = New System.Drawing.Point(8, 43)
        Me.rdRankingCompra.Name = "rdRankingCompra"
        Me.rdRankingCompra.Size = New System.Drawing.Size(101, 17)
        Me.rdRankingCompra.TabIndex = 18
        Me.rdRankingCompra.Text = "Mas Comprados"
        Me.rdRankingCompra.UseVisualStyleBackColor = True
        '
        'rdRankingVenta
        '
        Me.rdRankingVenta.AutoSize = True
        Me.rdRankingVenta.Location = New System.Drawing.Point(8, 20)
        Me.rdRankingVenta.Name = "rdRankingVenta"
        Me.rdRankingVenta.Size = New System.Drawing.Size(92, 17)
        Me.rdRankingVenta.TabIndex = 17
        Me.rdRankingVenta.Text = "Mas Vendidos"
        Me.rdRankingVenta.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboTipoProducto)
        Me.GroupBox2.Location = New System.Drawing.Point(178, 383)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(353, 54)
        Me.GroupBox2.TabIndex = 115
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Productos"
        '
        'cboTipoProducto
        '
        Me.cboTipoProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoProducto.FormattingEnabled = True
        Me.cboTipoProducto.Location = New System.Drawing.Point(6, 19)
        Me.cboTipoProducto.Name = "cboTipoProducto"
        Me.cboTipoProducto.Size = New System.Drawing.Size(338, 24)
        Me.cboTipoProducto.TabIndex = 108
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(539, 27)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(69, 37)
        Me.btnConsultar.TabIndex = 109
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'frmEstadisticaMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 480)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grRanking)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grSucursal)
        Me.Controls.Add(Me.grDeposito)
        Me.Controls.Add(Me.grDatoMercaderia)
        Me.Controls.Add(Me.grFecha)
        Me.Controls.Add(Me.grOrdenar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstadisticaMercaderia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadísticas de Mercaderías"
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.grFecha.ResumeLayout(False)
        Me.grFecha.PerformLayout()
        Me.grDatoMercaderia.ResumeLayout(False)
        Me.grDatoMercaderia.PerformLayout()
        Me.grDeposito.ResumeLayout(False)
        Me.grDeposito.PerformLayout()
        Me.grSucursal.ResumeLayout(False)
        Me.grSucursal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grRanking.ResumeLayout(False)
        Me.grRanking.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdValoracionStock As System.Windows.Forms.RadioButton
    Friend WithEvents grFecha As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIdProducto As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblMercaderia As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grDatoMercaderia As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grDeposito As System.Windows.Forms.GroupBox
    Friend WithEvents cboDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents grSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents chkTodoDeposito As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodaSucursal As System.Windows.Forms.CheckBox
    Friend WithEvents rdCostoMayor As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents rdCostoMenor As System.Windows.Forms.RadioButton
    Friend WithEvents rdRankingCantidad As System.Windows.Forms.RadioButton
    Friend WithEvents grRanking As System.Windows.Forms.GroupBox
    Friend WithEvents rdRankingEnvio As System.Windows.Forms.RadioButton
    Friend WithEvents rdRankingCompra As System.Windows.Forms.RadioButton
    Friend WithEvents rdRankingVenta As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents rdUsoInterno As System.Windows.Forms.RadioButton
    Friend WithEvents rdPedidoHeladeria As System.Windows.Forms.RadioButton
    Friend WithEvents rdValoracionStockDeposito As System.Windows.Forms.RadioButton
    Friend WithEvents rdMercaderiaSinRemision As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
