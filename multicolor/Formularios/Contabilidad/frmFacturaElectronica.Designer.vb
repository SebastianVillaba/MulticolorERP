<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaElectronica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaElectronica))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDesdeNro = New System.Windows.Forms.TextBox()
        Me.txtHastaNro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.txtCdc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnActualizarLote = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvFactura = New System.Windows.Forms.ListView()
        Me.lvFactura_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_nroFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_tipoVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_idVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_selec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_idMov = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvError = New System.Windows.Forms.ListView()
        Me.lvError_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvError_idLote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvError_idMov = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvError_mensaje = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNroLote = New System.Windows.Forms.TextBox()
        Me.lvLote = New System.Windows.Forms.ListView()
        Me.lvLote_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLote_idLote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLote_tipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLote_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLote_fechaConsulta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLote_lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lvMail = New System.Windows.Forms.ListView()
        Me.lvMail_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMail_nroFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMail_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMail_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMail_email = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMail_idMov = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMail_idTransa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtIdPersona = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnConsultarFactura = New System.Windows.Forms.Button()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIdMov = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIdTransa = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvConsulta = New System.Windows.Forms.ListView()
        Me.lvConsulta_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_fechaHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_idPersona = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_ruc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_tipoVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_idTransa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_idMov = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConsulta_mensaje = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lvAnulado = New System.Windows.Forms.ListView()
        Me.lvAnulado_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_nroFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_tipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_idVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_seleccion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_idMov = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAnulado_idSifen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpFechaConsulta = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnConsultaAnulado = New System.Windows.Forms.Button()
        Me.txtIdSifen = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnGuardarAnulado = New System.Windows.Forms.Button()
        Me.txtIdMov2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.grOrdenar = New System.Windows.Forms.GroupBox()
        Me.rdResto = New System.Windows.Forms.RadioButton()
        Me.rdVenta = New System.Windows.Forms.RadioButton()
        Me.rdHotel = New System.Windows.Forms.RadioButton()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.grOrdenar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboSucursal)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(424, 68)
        Me.GroupBox4.TabIndex = 100
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Sucursal"
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
        Me.cboSucursal.Size = New System.Drawing.Size(400, 28)
        Me.cboSucursal.TabIndex = 50
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(878, 13)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 20)
        Me.Label11.TabIndex = 117
        Me.Label11.Text = "Desde Nro.:"
        '
        'txtDesdeNro
        '
        Me.txtDesdeNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesdeNro.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDesdeNro.Location = New System.Drawing.Point(988, 10)
        Me.txtDesdeNro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDesdeNro.MaxLength = 5
        Me.txtDesdeNro.Name = "txtDesdeNro"
        Me.txtDesdeNro.Size = New System.Drawing.Size(69, 26)
        Me.txtDesdeNro.TabIndex = 147
        '
        'txtHastaNro
        '
        Me.txtHastaNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHastaNro.ForeColor = System.Drawing.Color.DarkRed
        Me.txtHastaNro.Location = New System.Drawing.Point(989, 51)
        Me.txtHastaNro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHastaNro.MaxLength = 5
        Me.txtHastaNro.Name = "txtHastaNro"
        Me.txtHastaNro.Size = New System.Drawing.Size(69, 26)
        Me.txtHastaNro.TabIndex = 149
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(879, 54)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 20)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Hasta Nro.:"
        '
        'btnCargar
        '
        Me.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.Location = New System.Drawing.Point(1072, 15)
        Me.btnCargar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(77, 46)
        Me.btnCargar.TabIndex = 150
        Me.btnCargar.Text = "&Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(1157, 13)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(77, 46)
        Me.btnProcesar.TabIndex = 151
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(625, 7)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 46)
        Me.btnConsultar.TabIndex = 152
        Me.btnConsultar.Text = "Co&nsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtCdc
        '
        Me.txtCdc.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtCdc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCdc.Location = New System.Drawing.Point(83, 694)
        Me.txtCdc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCdc.Name = "txtCdc"
        Me.txtCdc.ReadOnly = True
        Me.txtCdc.Size = New System.Drawing.Size(572, 30)
        Me.txtCdc.TabIndex = 193
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 696)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 25)
        Me.Label4.TabIndex = 192
        Me.Label4.Text = "CDC:"
        '
        'btnActualizarLote
        '
        Me.btnActualizarLote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizarLote.Image = CType(resources.GetObject("btnActualizarLote.Image"), System.Drawing.Image)
        Me.btnActualizarLote.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizarLote.Location = New System.Drawing.Point(1241, 13)
        Me.btnActualizarLote.Margin = New System.Windows.Forms.Padding(4)
        Me.btnActualizarLote.Name = "btnActualizarLote"
        Me.btnActualizarLote.Size = New System.Drawing.Size(115, 46)
        Me.btnActualizarLote.TabIndex = 194
        Me.btnActualizarLote.Text = "Actualizar Lote"
        Me.btnActualizarLote.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizarLote.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(3, 106)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1359, 582)
        Me.TabControl1.TabIndex = 195
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvFactura)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1351, 553)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Facturas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvFactura
        '
        Me.lvFactura.AllowColumnReorder = True
        Me.lvFactura.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvFactura_nro, Me.lvFactura_nroFactura, Me.lvFactura_fecha, Me.lvFactura_cliente, Me.lvFactura_tipoVenta, Me.lvFactura_total, Me.lvFactura_idVenta, Me.lvFactura_selec, Me.lvFactura_idMov})
        Me.lvFactura.FullRowSelect = True
        Me.lvFactura.GridLines = True
        Me.lvFactura.HideSelection = False
        Me.lvFactura.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvFactura.LabelWrap = False
        Me.lvFactura.Location = New System.Drawing.Point(16, 16)
        Me.lvFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.lvFactura.MultiSelect = False
        Me.lvFactura.Name = "lvFactura"
        Me.lvFactura.Size = New System.Drawing.Size(1328, 526)
        Me.lvFactura.TabIndex = 117
        Me.lvFactura.UseCompatibleStateImageBehavior = False
        Me.lvFactura.View = System.Windows.Forms.View.Details
        '
        'lvFactura_nro
        '
        Me.lvFactura_nro.Text = "Nro"
        Me.lvFactura_nro.Width = 50
        '
        'lvFactura_nroFactura
        '
        Me.lvFactura_nroFactura.Text = "Nro. Factura"
        Me.lvFactura_nroFactura.Width = 140
        '
        'lvFactura_fecha
        '
        Me.lvFactura_fecha.Text = "Fecha"
        Me.lvFactura_fecha.Width = 80
        '
        'lvFactura_cliente
        '
        Me.lvFactura_cliente.Text = "Cliente"
        Me.lvFactura_cliente.Width = 250
        '
        'lvFactura_tipoVenta
        '
        Me.lvFactura_tipoVenta.Text = "Tipo"
        Me.lvFactura_tipoVenta.Width = 80
        '
        'lvFactura_total
        '
        Me.lvFactura_total.Text = "Total"
        Me.lvFactura_total.Width = 90
        '
        'lvFactura_idVenta
        '
        Me.lvFactura_idVenta.Text = "idVenta"
        Me.lvFactura_idVenta.Width = 70
        '
        'lvFactura_selec
        '
        Me.lvFactura_selec.Text = "Selec."
        Me.lvFactura_selec.Width = 50
        '
        'lvFactura_idMov
        '
        Me.lvFactura_idMov.Text = "idMov"
        Me.lvFactura_idMov.Width = 80
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.lvError)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtNroLote)
        Me.TabPage2.Controls.Add(Me.lvLote)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1351, 553)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Consulta Lote"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(22, 283)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 20)
        Me.Label3.TabIndex = 196
        Me.Label3.Text = "ERRORES"
        '
        'lvError
        '
        Me.lvError.AllowColumnReorder = True
        Me.lvError.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvError_nro, Me.lvError_idLote, Me.lvError_idMov, Me.lvError_mensaje})
        Me.lvError.FullRowSelect = True
        Me.lvError.GridLines = True
        Me.lvError.HideSelection = False
        Me.lvError.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvError.LabelWrap = False
        Me.lvError.Location = New System.Drawing.Point(26, 307)
        Me.lvError.Margin = New System.Windows.Forms.Padding(4)
        Me.lvError.MultiSelect = False
        Me.lvError.Name = "lvError"
        Me.lvError.Size = New System.Drawing.Size(877, 237)
        Me.lvError.TabIndex = 196
        Me.lvError.UseCompatibleStateImageBehavior = False
        Me.lvError.View = System.Windows.Forms.View.Details
        '
        'lvError_nro
        '
        Me.lvError_nro.Text = "Nro"
        Me.lvError_nro.Width = 50
        '
        'lvError_idLote
        '
        Me.lvError_idLote.Text = "idLote"
        Me.lvError_idLote.Width = 65
        '
        'lvError_idMov
        '
        Me.lvError_idMov.Text = "idMov."
        '
        'lvError_mensaje
        '
        Me.lvError_mensaje.Text = "Mensaje"
        Me.lvError_mensaje.Width = 600
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(715, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 195
        Me.Label2.Text = "Nro. Lote"
        '
        'txtNroLote
        '
        Me.txtNroLote.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNroLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroLote.Location = New System.Drawing.Point(712, 48)
        Me.txtNroLote.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroLote.Name = "txtNroLote"
        Me.txtNroLote.ReadOnly = True
        Me.txtNroLote.Size = New System.Drawing.Size(342, 30)
        Me.txtNroLote.TabIndex = 194
        '
        'lvLote
        '
        Me.lvLote.AllowColumnReorder = True
        Me.lvLote.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvLote_nro, Me.lvLote_idLote, Me.lvLote_tipo, Me.lvLote_fecha, Me.lvLote_fechaConsulta, Me.lvLote_lote})
        Me.lvLote.FullRowSelect = True
        Me.lvLote.GridLines = True
        Me.lvLote.HideSelection = False
        Me.lvLote.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvLote.LabelWrap = False
        Me.lvLote.Location = New System.Drawing.Point(23, 13)
        Me.lvLote.Margin = New System.Windows.Forms.Padding(4)
        Me.lvLote.MultiSelect = False
        Me.lvLote.Name = "lvLote"
        Me.lvLote.Size = New System.Drawing.Size(681, 264)
        Me.lvLote.TabIndex = 118
        Me.lvLote.UseCompatibleStateImageBehavior = False
        Me.lvLote.View = System.Windows.Forms.View.Details
        '
        'lvLote_nro
        '
        Me.lvLote_nro.Text = "Nro"
        Me.lvLote_nro.Width = 50
        '
        'lvLote_idLote
        '
        Me.lvLote_idLote.Text = "idLote"
        Me.lvLote_idLote.Width = 65
        '
        'lvLote_tipo
        '
        Me.lvLote_tipo.Text = "Tipo"
        Me.lvLote_tipo.Width = 140
        '
        'lvLote_fecha
        '
        Me.lvLote_fecha.Text = "Fecha"
        Me.lvLote_fecha.Width = 90
        '
        'lvLote_fechaConsulta
        '
        Me.lvLote_fechaConsulta.Text = "Fecha Cons."
        Me.lvLote_fechaConsulta.Width = 100
        '
        'lvLote_lote
        '
        Me.lvLote_lote.Text = "Nro. Lote"
        Me.lvLote_lote.Width = 200
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lvMail)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1351, 553)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Facturas con Email"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lvMail
        '
        Me.lvMail.AllowColumnReorder = True
        Me.lvMail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvMail_nro, Me.lvMail_nroFactura, Me.lvMail_fecha, Me.lvMail_cliente, Me.lvMail_email, Me.lvMail_idMov, Me.lvMail_idTransa})
        Me.lvMail.FullRowSelect = True
        Me.lvMail.GridLines = True
        Me.lvMail.HideSelection = False
        Me.lvMail.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvMail.LabelWrap = False
        Me.lvMail.Location = New System.Drawing.Point(23, 13)
        Me.lvMail.Margin = New System.Windows.Forms.Padding(4)
        Me.lvMail.MultiSelect = False
        Me.lvMail.Name = "lvMail"
        Me.lvMail.Size = New System.Drawing.Size(1158, 526)
        Me.lvMail.TabIndex = 118
        Me.lvMail.UseCompatibleStateImageBehavior = False
        Me.lvMail.View = System.Windows.Forms.View.Details
        '
        'lvMail_nro
        '
        Me.lvMail_nro.Text = "Nro"
        Me.lvMail_nro.Width = 50
        '
        'lvMail_nroFactura
        '
        Me.lvMail_nroFactura.Text = "Nro. Factura"
        Me.lvMail_nroFactura.Width = 140
        '
        'lvMail_fecha
        '
        Me.lvMail_fecha.Text = "Fecha"
        Me.lvMail_fecha.Width = 80
        '
        'lvMail_cliente
        '
        Me.lvMail_cliente.Text = "Cliente"
        Me.lvMail_cliente.Width = 250
        '
        'lvMail_email
        '
        Me.lvMail_email.Text = "email"
        Me.lvMail_email.Width = 300
        '
        'lvMail_idMov
        '
        Me.lvMail_idMov.Text = "Id Mov"
        Me.lvMail_idMov.Width = 90
        '
        'lvMail_idTransa
        '
        Me.lvMail_idTransa.Text = "Id Transa"
        Me.lvMail_idTransa.Width = 90
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtIdPersona)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.btnConsultarFactura)
        Me.TabPage4.Controls.Add(Me.dtpDesdeFecha)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.txtIdMov)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.txtIdTransa)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.txtMensaje)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.lvConsulta)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1351, 553)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Facturas no enviadas"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtIdPersona
        '
        Me.txtIdPersona.BackColor = System.Drawing.Color.MistyRose
        Me.txtIdPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPersona.Location = New System.Drawing.Point(711, 516)
        Me.txtIdPersona.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdPersona.Name = "txtIdPersona"
        Me.txtIdPersona.ReadOnly = True
        Me.txtIdPersona.Size = New System.Drawing.Size(131, 30)
        Me.txtIdPersona.TabIndex = 204
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(582, 518)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 25)
        Me.Label10.TabIndex = 203
        Me.Label10.Text = "Id Persona:"
        '
        'btnConsultarFactura
        '
        Me.btnConsultarFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultarFactura.Image = CType(resources.GetObject("btnConsultarFactura.Image"), System.Drawing.Image)
        Me.btnConsultarFactura.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultarFactura.Location = New System.Drawing.Point(286, 10)
        Me.btnConsultarFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultarFactura.Name = "btnConsultarFactura"
        Me.btnConsultarFactura.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultarFactura.TabIndex = 202
        Me.btnConsultarFactura.Text = "Consultar"
        Me.btnConsultarFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultarFactura.UseVisualStyleBackColor = True
        '
        'dtpDesdeFecha
        '
        Me.dtpDesdeFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeFecha.Location = New System.Drawing.Point(123, 18)
        Me.dtpDesdeFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDesdeFecha.Name = "dtpDesdeFecha"
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(143, 30)
        Me.dtpDesdeFecha.TabIndex = 201
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 18)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 25)
        Me.Label8.TabIndex = 200
        Me.Label8.Text = "Fecha :"
        '
        'txtIdMov
        '
        Me.txtIdMov.BackColor = System.Drawing.Color.MistyRose
        Me.txtIdMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMov.Location = New System.Drawing.Point(404, 515)
        Me.txtIdMov.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdMov.Name = "txtIdMov"
        Me.txtIdMov.ReadOnly = True
        Me.txtIdMov.Size = New System.Drawing.Size(157, 30)
        Me.txtIdMov.TabIndex = 199
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(306, 517)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 25)
        Me.Label7.TabIndex = 198
        Me.Label7.Text = "Id Mov.:"
        '
        'txtIdTransa
        '
        Me.txtIdTransa.BackColor = System.Drawing.Color.MistyRose
        Me.txtIdTransa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTransa.Location = New System.Drawing.Point(126, 516)
        Me.txtIdTransa.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdTransa.Name = "txtIdTransa"
        Me.txtIdTransa.ReadOnly = True
        Me.txtIdTransa.Size = New System.Drawing.Size(157, 30)
        Me.txtIdTransa.TabIndex = 197
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 518)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 25)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = "Id Transa:"
        '
        'txtMensaje
        '
        Me.txtMensaje.BackColor = System.Drawing.Color.MistyRose
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(126, 474)
        Me.txtMensaje.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ReadOnly = True
        Me.txtMensaje.Size = New System.Drawing.Size(1001, 30)
        Me.txtMensaje.TabIndex = 195
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 476)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 25)
        Me.Label5.TabIndex = 194
        Me.Label5.Text = "Mensaje:"
        '
        'lvConsulta
        '
        Me.lvConsulta.AllowColumnReorder = True
        Me.lvConsulta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvConsulta_nro, Me.lvConsulta_sucursal, Me.lvConsulta_factura, Me.lvConsulta_fechaHora, Me.lvConsulta_idPersona, Me.lvConsulta_cliente, Me.lvConsulta_ruc, Me.lvConsulta_tipoVenta, Me.lvConsulta_total, Me.lvConsulta_idTransa, Me.lvConsulta_idMov, Me.lvConsulta_mensaje})
        Me.lvConsulta.FullRowSelect = True
        Me.lvConsulta.GridLines = True
        Me.lvConsulta.HideSelection = False
        Me.lvConsulta.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvConsulta.LabelWrap = False
        Me.lvConsulta.Location = New System.Drawing.Point(11, 66)
        Me.lvConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.lvConsulta.MultiSelect = False
        Me.lvConsulta.Name = "lvConsulta"
        Me.lvConsulta.Size = New System.Drawing.Size(1328, 400)
        Me.lvConsulta.TabIndex = 118
        Me.lvConsulta.UseCompatibleStateImageBehavior = False
        Me.lvConsulta.View = System.Windows.Forms.View.Details
        '
        'lvConsulta_nro
        '
        Me.lvConsulta_nro.Text = "Nro"
        Me.lvConsulta_nro.Width = 50
        '
        'lvConsulta_sucursal
        '
        Me.lvConsulta_sucursal.Text = "Sucursal"
        Me.lvConsulta_sucursal.Width = 200
        '
        'lvConsulta_factura
        '
        Me.lvConsulta_factura.Text = "Factura"
        Me.lvConsulta_factura.Width = 130
        '
        'lvConsulta_fechaHora
        '
        Me.lvConsulta_fechaHora.Text = "Fecha Hora"
        Me.lvConsulta_fechaHora.Width = 140
        '
        'lvConsulta_idPersona
        '
        Me.lvConsulta_idPersona.Text = "idPersona"
        Me.lvConsulta_idPersona.Width = 80
        '
        'lvConsulta_cliente
        '
        Me.lvConsulta_cliente.Text = "Cliente"
        Me.lvConsulta_cliente.Width = 250
        '
        'lvConsulta_ruc
        '
        Me.lvConsulta_ruc.Text = "RUC"
        Me.lvConsulta_ruc.Width = 100
        '
        'lvConsulta_tipoVenta
        '
        Me.lvConsulta_tipoVenta.Text = "Tipo Ven."
        Me.lvConsulta_tipoVenta.Width = 100
        '
        'lvConsulta_total
        '
        Me.lvConsulta_total.Text = "Total"
        Me.lvConsulta_total.Width = 90
        '
        'lvConsulta_idTransa
        '
        Me.lvConsulta_idTransa.Text = "IdTransa"
        Me.lvConsulta_idTransa.Width = 80
        '
        'lvConsulta_idMov
        '
        Me.lvConsulta_idMov.Text = "IdMov."
        Me.lvConsulta_idMov.Width = 92
        '
        'lvConsulta_mensaje
        '
        Me.lvConsulta_mensaje.Text = "Mensaje"
        Me.lvConsulta_mensaje.Width = 100
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.lvAnulado)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1351, 553)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Facturas Anuladas"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lvAnulado
        '
        Me.lvAnulado.AllowColumnReorder = True
        Me.lvAnulado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvAnulado_nro, Me.lvAnulado_sucursal, Me.lvAnulado_nroFactura, Me.lvAnulado_fecha, Me.lvAnulado_cliente, Me.lvAnulado_tipo, Me.lvAnulado_idVenta, Me.lvAnulado_seleccion, Me.lvAnulado_idMov, Me.lvAnulado_idSifen})
        Me.lvAnulado.FullRowSelect = True
        Me.lvAnulado.GridLines = True
        Me.lvAnulado.HideSelection = False
        Me.lvAnulado.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvAnulado.LabelWrap = False
        Me.lvAnulado.Location = New System.Drawing.Point(11, 12)
        Me.lvAnulado.Margin = New System.Windows.Forms.Padding(4)
        Me.lvAnulado.MultiSelect = False
        Me.lvAnulado.Name = "lvAnulado"
        Me.lvAnulado.Size = New System.Drawing.Size(1328, 526)
        Me.lvAnulado.TabIndex = 118
        Me.lvAnulado.UseCompatibleStateImageBehavior = False
        Me.lvAnulado.View = System.Windows.Forms.View.Details
        '
        'lvAnulado_nro
        '
        Me.lvAnulado_nro.Text = "Nro"
        Me.lvAnulado_nro.Width = 50
        '
        'lvAnulado_sucursal
        '
        Me.lvAnulado_sucursal.Text = "Sucursal"
        Me.lvAnulado_sucursal.Width = 250
        '
        'lvAnulado_nroFactura
        '
        Me.lvAnulado_nroFactura.Text = "Nro. Factura"
        Me.lvAnulado_nroFactura.Width = 100
        '
        'lvAnulado_fecha
        '
        Me.lvAnulado_fecha.Text = "Fecha"
        Me.lvAnulado_fecha.Width = 80
        '
        'lvAnulado_cliente
        '
        Me.lvAnulado_cliente.Text = "Cliente"
        Me.lvAnulado_cliente.Width = 250
        '
        'lvAnulado_tipo
        '
        Me.lvAnulado_tipo.Text = "Tipo"
        Me.lvAnulado_tipo.Width = 80
        '
        'lvAnulado_idVenta
        '
        Me.lvAnulado_idVenta.Text = "idVenta"
        Me.lvAnulado_idVenta.Width = 70
        '
        'lvAnulado_seleccion
        '
        Me.lvAnulado_seleccion.Text = "Selec."
        Me.lvAnulado_seleccion.Width = 50
        '
        'lvAnulado_idMov
        '
        Me.lvAnulado_idMov.Text = "idMov"
        Me.lvAnulado_idMov.Width = 80
        '
        'lvAnulado_idSifen
        '
        Me.lvAnulado_idSifen.Text = "Id Sifen"
        Me.lvAnulado_idSifen.Width = 80
        '
        'dtpFechaConsulta
        '
        Me.dtpFechaConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaConsulta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaConsulta.Location = New System.Drawing.Point(453, 47)
        Me.dtpFechaConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaConsulta.Name = "dtpFechaConsulta"
        Me.dtpFechaConsulta.Size = New System.Drawing.Size(143, 30)
        Me.dtpFechaConsulta.TabIndex = 203
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(453, 15)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 25)
        Me.Label9.TabIndex = 202
        Me.Label9.Text = "Fecha "
        '
        'btnConsultaAnulado
        '
        Me.btnConsultaAnulado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultaAnulado.Image = CType(resources.GetObject("btnConsultaAnulado.Image"), System.Drawing.Image)
        Me.btnConsultaAnulado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultaAnulado.Location = New System.Drawing.Point(624, 56)
        Me.btnConsultaAnulado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultaAnulado.Name = "btnConsultaAnulado"
        Me.btnConsultaAnulado.Size = New System.Drawing.Size(99, 46)
        Me.btnConsultaAnulado.TabIndex = 204
        Me.btnConsultaAnulado.Text = "Anulados"
        Me.btnConsultaAnulado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultaAnulado.UseVisualStyleBackColor = True
        '
        'txtIdSifen
        '
        Me.txtIdSifen.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtIdSifen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSifen.Location = New System.Drawing.Point(769, 691)
        Me.txtIdSifen.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdSifen.Name = "txtIdSifen"
        Me.txtIdSifen.ReadOnly = True
        Me.txtIdSifen.Size = New System.Drawing.Size(124, 30)
        Me.txtIdSifen.TabIndex = 206
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(675, 693)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 25)
        Me.Label12.TabIndex = 205
        Me.Label12.Text = "Id Sifen:"
        '
        'btnGuardarAnulado
        '
        Me.btnGuardarAnulado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardarAnulado.Image = CType(resources.GetObject("btnGuardarAnulado.Image"), System.Drawing.Image)
        Me.btnGuardarAnulado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardarAnulado.Location = New System.Drawing.Point(1072, 69)
        Me.btnGuardarAnulado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardarAnulado.Name = "btnGuardarAnulado"
        Me.btnGuardarAnulado.Size = New System.Drawing.Size(146, 46)
        Me.btnGuardarAnulado.TabIndex = 207
        Me.btnGuardarAnulado.Text = "Guardar Anulado"
        Me.btnGuardarAnulado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarAnulado.UseVisualStyleBackColor = True
        '
        'txtIdMov2
        '
        Me.txtIdMov2.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtIdMov2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMov2.Location = New System.Drawing.Point(1003, 690)
        Me.txtIdMov2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdMov2.Name = "txtIdMov2"
        Me.txtIdMov2.ReadOnly = True
        Me.txtIdMov2.Size = New System.Drawing.Size(124, 30)
        Me.txtIdMov2.TabIndex = 209
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(909, 692)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 25)
        Me.Label13.TabIndex = 208
        Me.Label13.Text = "Id Mov.:"
        '
        'grOrdenar
        '
        Me.grOrdenar.Controls.Add(Me.rdHotel)
        Me.grOrdenar.Controls.Add(Me.rdResto)
        Me.grOrdenar.Controls.Add(Me.rdVenta)
        Me.grOrdenar.Location = New System.Drawing.Point(732, 7)
        Me.grOrdenar.Margin = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Name = "grOrdenar"
        Me.grOrdenar.Padding = New System.Windows.Forms.Padding(4)
        Me.grOrdenar.Size = New System.Drawing.Size(127, 108)
        Me.grOrdenar.TabIndex = 210
        Me.grOrdenar.TabStop = False
        '
        'rdResto
        '
        Me.rdResto.AutoSize = True
        Me.rdResto.Location = New System.Drawing.Point(11, 44)
        Me.rdResto.Margin = New System.Windows.Forms.Padding(4)
        Me.rdResto.Name = "rdResto"
        Me.rdResto.Size = New System.Drawing.Size(66, 21)
        Me.rdResto.TabIndex = 18
        Me.rdResto.Text = "Resto"
        Me.rdResto.UseVisualStyleBackColor = True
        '
        'rdVenta
        '
        Me.rdVenta.AutoSize = True
        Me.rdVenta.Checked = True
        Me.rdVenta.Location = New System.Drawing.Point(11, 16)
        Me.rdVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.rdVenta.Name = "rdVenta"
        Me.rdVenta.Size = New System.Drawing.Size(73, 21)
        Me.rdVenta.TabIndex = 17
        Me.rdVenta.TabStop = True
        Me.rdVenta.Text = "Ventas"
        Me.rdVenta.UseVisualStyleBackColor = True
        '
        'rdHotel
        '
        Me.rdHotel.AutoSize = True
        Me.rdHotel.Location = New System.Drawing.Point(11, 74)
        Me.rdHotel.Margin = New System.Windows.Forms.Padding(4)
        Me.rdHotel.Name = "rdHotel"
        Me.rdHotel.Size = New System.Drawing.Size(62, 21)
        Me.rdHotel.TabIndex = 19
        Me.rdHotel.Text = "Hotel"
        Me.rdHotel.UseVisualStyleBackColor = True
        '
        'frmFacturaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1372, 733)
        Me.Controls.Add(Me.grOrdenar)
        Me.Controls.Add(Me.txtIdMov2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnGuardarAnulado)
        Me.Controls.Add(Me.txtIdSifen)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnConsultaAnulado)
        Me.Controls.Add(Me.dtpFechaConsulta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnActualizarLote)
        Me.Controls.Add(Me.txtCdc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.txtHastaNro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDesdeNro)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFacturaElectronica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Factura Electronica"
        Me.GroupBox4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.grOrdenar.ResumeLayout(False)
        Me.grOrdenar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDesdeNro As System.Windows.Forms.TextBox
    Friend WithEvents txtHastaNro As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents txtCdc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnActualizarLote As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lvFactura As System.Windows.Forms.ListView
    Friend WithEvents lvFactura_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_nroFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_tipoVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_idVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_selec As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNroLote As System.Windows.Forms.TextBox
    Friend WithEvents lvLote As System.Windows.Forms.ListView
    Friend WithEvents lvLote_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_idLote As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_fechaConsulta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvError As System.Windows.Forms.ListView
    Friend WithEvents lvError_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvError_idLote As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvError_mensaje As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvError_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lvMail As System.Windows.Forms.ListView
    Friend WithEvents lvMail_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMail_nroFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMail_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMail_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMail_email As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMail_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMail_idTransa As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txtIdMov As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIdTransa As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvConsulta As System.Windows.Forms.ListView
    Friend WithEvents lvConsulta_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_fechaHora As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_idPersona As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_ruc As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_tipoVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_idTransa As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConsulta_mensaje As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnConsultarFactura As System.Windows.Forms.Button
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaConsulta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIdPersona As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents lvAnulado As System.Windows.Forms.ListView
    Friend WithEvents lvAnulado_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_nroFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_idVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_seleccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnConsultaAnulado As System.Windows.Forms.Button
    Friend WithEvents lvAnulado_idSifen As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAnulado_sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdSifen As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarAnulado As System.Windows.Forms.Button
    Friend WithEvents txtIdMov2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grOrdenar As System.Windows.Forms.GroupBox
    Friend WithEvents rdHotel As System.Windows.Forms.RadioButton
    Friend WithEvents rdResto As System.Windows.Forms.RadioButton
    Friend WithEvents rdVenta As System.Windows.Forms.RadioButton
End Class
