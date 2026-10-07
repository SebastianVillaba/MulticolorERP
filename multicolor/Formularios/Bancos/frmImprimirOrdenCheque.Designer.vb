<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImprimirOrdenCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImprimirOrdenCheque))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grCheque = New System.Windows.Forms.GroupBox()
        Me.rdAlaVista = New System.Windows.Forms.RadioButton()
        Me.rdDirerido = New System.Windows.Forms.RadioButton()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblCotiza = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblIdOrden = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblNombreBanco = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNroCuenta = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblChequeFinal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblChequeInicial = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblIdChequera = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNroCheque = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvOrdenCheque = New System.Windows.Forms.ListView()
        Me.detOrden_idOrden = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detOrden_nroCuenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detOrden_banco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detOrden_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lvCheque = New System.Windows.Forms.ListView()
        Me.detCheque_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCheque_idProveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCheque_proveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCheque_nombreFantasia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCheque_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detCheque_monto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hojaImpresion = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        Me.grCheque.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.grCheque)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.lblCotiza)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblIdOrden)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblMoneda)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblNombreBanco)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblNroCuenta)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblChequeFinal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblChequeInicial)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblIdChequera)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNroCheque)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(601, 292)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(484, 23)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
        Me.btnGuardar.TabIndex = 78
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'grCheque
        '
        Me.grCheque.Controls.Add(Me.rdAlaVista)
        Me.grCheque.Controls.Add(Me.rdDirerido)
        Me.grCheque.Location = New System.Drawing.Point(387, 106)
        Me.grCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grCheque.Name = "grCheque"
        Me.grCheque.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grCheque.Size = New System.Drawing.Size(156, 82)
        Me.grCheque.TabIndex = 99
        Me.grCheque.TabStop = False
        Me.grCheque.Text = "Tipo de Chequera"
        '
        'rdAlaVista
        '
        Me.rdAlaVista.AutoSize = True
        Me.rdAlaVista.Location = New System.Drawing.Point(11, 44)
        Me.rdAlaVista.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdAlaVista.Name = "rdAlaVista"
        Me.rdAlaVista.Size = New System.Drawing.Size(88, 21)
        Me.rdAlaVista.TabIndex = 18
        Me.rdAlaVista.Text = "&A la Vista"
        Me.rdAlaVista.UseVisualStyleBackColor = True
        '
        'rdDirerido
        '
        Me.rdDirerido.AutoSize = True
        Me.rdDirerido.Checked = True
        Me.rdDirerido.Location = New System.Drawing.Point(11, 16)
        Me.rdDirerido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rdDirerido.Name = "rdDirerido"
        Me.rdDirerido.Size = New System.Drawing.Size(78, 21)
        Me.rdDirerido.TabIndex = 17
        Me.rdDirerido.TabStop = True
        Me.rdDirerido.Text = "&Diferido"
        Me.rdDirerido.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(369, 23)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(92, 46)
        Me.btnImprimir.TabIndex = 77
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblCotiza
        '
        Me.lblCotiza.AutoSize = True
        Me.lblCotiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotiza.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblCotiza.Location = New System.Drawing.Point(468, 260)
        Me.lblCotiza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCotiza.Name = "lblCotiza"
        Me.lblCotiza.Size = New System.Drawing.Size(80, 24)
        Me.lblCotiza.TabIndex = 78
        Me.lblCotiza.Text = "lblCotiza"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(345, 258)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 24)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "Cotizacion :"
        '
        'lblIdOrden
        '
        Me.lblIdOrden.AutoSize = True
        Me.lblIdOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdOrden.ForeColor = System.Drawing.Color.Blue
        Me.lblIdOrden.Location = New System.Drawing.Point(119, 76)
        Me.lblIdOrden.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdOrden.Name = "lblIdOrden"
        Me.lblIdOrden.Size = New System.Drawing.Size(108, 24)
        Me.lblIdOrden.TabIndex = 75
        Me.lblIdOrden.Text = "lblIdOrden"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 75)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 24)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Id Orden :"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblMoneda.Location = New System.Drawing.Point(160, 260)
        Me.lblMoneda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(99, 24)
        Me.lblMoneda.TabIndex = 73
        Me.lblMoneda.Text = "lblMoneda"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(61, 258)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 24)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Moneda :"
        '
        'lblNombreBanco
        '
        Me.lblNombreBanco.AutoSize = True
        Me.lblNombreBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreBanco.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblNombreBanco.Location = New System.Drawing.Point(159, 233)
        Me.lblNombreBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreBanco.Name = "lblNombreBanco"
        Me.lblNombreBanco.Size = New System.Drawing.Size(152, 24)
        Me.lblNombreBanco.TabIndex = 11
        Me.lblNombreBanco.Text = "lblNombreBanco"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 231)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 24)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Nombre Banco :"
        '
        'lblNroCuenta
        '
        Me.lblNroCuenta.AutoSize = True
        Me.lblNroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroCuenta.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblNroCuenta.Location = New System.Drawing.Point(161, 203)
        Me.lblNroCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNroCuenta.Name = "lblNroCuenta"
        Me.lblNroCuenta.Size = New System.Drawing.Size(120, 24)
        Me.lblNroCuenta.TabIndex = 9
        Me.lblNroCuenta.Text = "lblNroCuenta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 202)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 24)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Nro. Cuenta :"
        '
        'lblChequeFinal
        '
        Me.lblChequeFinal.AutoSize = True
        Me.lblChequeFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChequeFinal.ForeColor = System.Drawing.Color.Firebrick
        Me.lblChequeFinal.Location = New System.Drawing.Point(161, 174)
        Me.lblChequeFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChequeFinal.Name = "lblChequeFinal"
        Me.lblChequeFinal.Size = New System.Drawing.Size(138, 24)
        Me.lblChequeFinal.TabIndex = 7
        Me.lblChequeFinal.Text = "lblChequeFinal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 172)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 24)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Cheque Final :"
        '
        'lblChequeInicial
        '
        Me.lblChequeInicial.AutoSize = True
        Me.lblChequeInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChequeInicial.ForeColor = System.Drawing.Color.Firebrick
        Me.lblChequeInicial.Location = New System.Drawing.Point(161, 146)
        Me.lblChequeInicial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChequeInicial.Name = "lblChequeInicial"
        Me.lblChequeInicial.Size = New System.Drawing.Size(144, 24)
        Me.lblChequeInicial.TabIndex = 5
        Me.lblChequeInicial.Text = "lblChequeInicial"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 145)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 24)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cheque Inicial :"
        '
        'lblIdChequera
        '
        Me.lblIdChequera.AutoSize = True
        Me.lblIdChequera.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdChequera.ForeColor = System.Drawing.Color.Firebrick
        Me.lblIdChequera.Location = New System.Drawing.Point(167, 118)
        Me.lblIdChequera.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdChequera.Name = "lblIdChequera"
        Me.lblIdChequera.Size = New System.Drawing.Size(128, 24)
        Me.lblIdChequera.TabIndex = 3
        Me.lblIdChequera.Text = "lblIdChequera"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 117)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Id Chequera :"
        '
        'txtNroCheque
        '
        Me.txtNroCheque.BackColor = System.Drawing.Color.Pink
        Me.txtNroCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroCheque.ForeColor = System.Drawing.Color.Black
        Me.txtNroCheque.Location = New System.Drawing.Point(209, 25)
        Me.txtNroCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNroCheque.Name = "txtNroCheque"
        Me.txtNroCheque.Size = New System.Drawing.Size(139, 29)
        Me.txtNroCheque.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nro. Cheque Inicial :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lvOrdenCheque)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 319)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(615, 249)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Orden de Cheque"
        '
        'lvOrdenCheque
        '
        Me.lvOrdenCheque.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detOrden_idOrden, Me.detOrden_nroCuenta, Me.detOrden_banco, Me.detOrden_fecha})
        Me.lvOrdenCheque.Location = New System.Drawing.Point(9, 23)
        Me.lvOrdenCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvOrdenCheque.Name = "lvOrdenCheque"
        Me.lvOrdenCheque.Size = New System.Drawing.Size(588, 210)
        Me.lvOrdenCheque.TabIndex = 3
        Me.lvOrdenCheque.UseCompatibleStateImageBehavior = False
        Me.lvOrdenCheque.View = System.Windows.Forms.View.Details
        '
        'detOrden_idOrden
        '
        Me.detOrden_idOrden.Text = "IdOrden"
        Me.detOrden_idOrden.Width = 50
        '
        'detOrden_nroCuenta
        '
        Me.detOrden_nroCuenta.Text = "Nro.Cuenta"
        Me.detOrden_nroCuenta.Width = 200
        '
        'detOrden_banco
        '
        Me.detOrden_banco.Text = "Banco"
        Me.detOrden_banco.Width = 120
        '
        'detOrden_fecha
        '
        Me.detOrden_fecha.Text = "Fecha"
        Me.detOrden_fecha.Width = 120
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lvCheque)
        Me.GroupBox3.Location = New System.Drawing.Point(627, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(696, 556)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Proveedores Con Orden de Cheques"
        '
        'lvCheque
        '
        Me.lvCheque.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detCheque_nro, Me.detCheque_idProveedor, Me.detCheque_proveedor, Me.detCheque_nombreFantasia, Me.detCheque_fecha, Me.detCheque_monto})
        Me.lvCheque.Location = New System.Drawing.Point(9, 22)
        Me.lvCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvCheque.Name = "lvCheque"
        Me.lvCheque.Size = New System.Drawing.Size(677, 530)
        Me.lvCheque.TabIndex = 3
        Me.lvCheque.UseCompatibleStateImageBehavior = False
        Me.lvCheque.View = System.Windows.Forms.View.Details
        '
        'detCheque_nro
        '
        Me.detCheque_nro.Text = "Nro."
        Me.detCheque_nro.Width = 40
        '
        'detCheque_idProveedor
        '
        Me.detCheque_idProveedor.Text = "IdProv."
        Me.detCheque_idProveedor.Width = 40
        '
        'detCheque_proveedor
        '
        Me.detCheque_proveedor.Text = "Proveedor"
        Me.detCheque_proveedor.Width = 150
        '
        'detCheque_nombreFantasia
        '
        Me.detCheque_nombreFantasia.Text = "Nombre Fantasia"
        Me.detCheque_nombreFantasia.Width = 180
        '
        'detCheque_fecha
        '
        Me.detCheque_fecha.Text = "Fecha"
        '
        'detCheque_monto
        '
        Me.detCheque_monto.Text = "Monto"
        Me.detCheque_monto.Width = 70
        '
        'frmImprimirOrdenCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1335, 581)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImprimirOrdenCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de Orden de Cheques"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grCheque.ResumeLayout(False)
        Me.grCheque.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreBanco As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNroCuenta As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblChequeFinal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblChequeInicial As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblIdChequera As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNroCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvOrdenCheque As System.Windows.Forms.ListView
    Friend WithEvents detOrden_idOrden As System.Windows.Forms.ColumnHeader
    Friend WithEvents detOrden_nroCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents detOrden_banco As System.Windows.Forms.ColumnHeader
    Friend WithEvents detOrden_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblIdOrden As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvCheque As System.Windows.Forms.ListView
    Friend WithEvents detCheque_idProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCheque_proveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCheque_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCheque_monto As System.Windows.Forms.ColumnHeader
    Friend WithEvents detCheque_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCotiza As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents detCheque_nombreFantasia As System.Windows.Forms.ColumnHeader
    Friend WithEvents grCheque As System.Windows.Forms.GroupBox
    Friend WithEvents rdAlaVista As System.Windows.Forms.RadioButton
    Friend WithEvents rdDirerido As System.Windows.Forms.RadioButton
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents hojaImpresion As System.Drawing.Printing.PrintDocument
End Class
