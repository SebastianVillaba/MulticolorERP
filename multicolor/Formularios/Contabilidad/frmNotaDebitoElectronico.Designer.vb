<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaDebitoElectronico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaDebitoElectronico))
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtHastaNro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDesdeNro = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lvFactura = New System.Windows.Forms.ListView()
        Me.lvFactura_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_nroFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_tipoVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_idNotaDebito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFactura_selec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
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
        Me.txtCdc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnActualizarLote = New System.Windows.Forms.Button()
        Me.btnAprobar = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(509, 36)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 46)
        Me.btnConsultar.TabIndex = 161
        Me.btnConsultar.Text = "Co&nsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(906, 24)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(77, 46)
        Me.btnProcesar.TabIndex = 160
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.Location = New System.Drawing.Point(821, 24)
        Me.btnCargar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(77, 46)
        Me.btnCargar.TabIndex = 159
        Me.btnCargar.Text = "&Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtHastaNro
        '
        Me.txtHastaNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHastaNro.ForeColor = System.Drawing.Color.DarkRed
        Me.txtHastaNro.Location = New System.Drawing.Point(730, 56)
        Me.txtHastaNro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHastaNro.MaxLength = 2
        Me.txtHastaNro.Name = "txtHastaNro"
        Me.txtHastaNro.Size = New System.Drawing.Size(69, 26)
        Me.txtHastaNro.TabIndex = 158
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(620, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 20)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Hasta Nro.:"
        '
        'txtDesdeNro
        '
        Me.txtDesdeNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesdeNro.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDesdeNro.Location = New System.Drawing.Point(729, 15)
        Me.txtDesdeNro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDesdeNro.MaxLength = 2
        Me.txtDesdeNro.Name = "txtDesdeNro"
        Me.txtDesdeNro.Size = New System.Drawing.Size(69, 26)
        Me.txtDesdeNro.TabIndex = 156
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(619, 18)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 20)
        Me.Label11.TabIndex = 155
        Me.Label11.Text = "Desde Nro.:"
        '
        'lvFactura
        '
        Me.lvFactura.AllowColumnReorder = True
        Me.lvFactura.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvFactura_nro, Me.lvFactura_nroFactura, Me.lvFactura_fecha, Me.lvFactura_cliente, Me.lvFactura_tipoVenta, Me.lvFactura_total, Me.lvFactura_idNotaDebito, Me.lvFactura_selec})
        Me.lvFactura.FullRowSelect = True
        Me.lvFactura.GridLines = True
        Me.lvFactura.HideSelection = False
        Me.lvFactura.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvFactura.LabelWrap = False
        Me.lvFactura.Location = New System.Drawing.Point(13, 17)
        Me.lvFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.lvFactura.MultiSelect = False
        Me.lvFactura.Name = "lvFactura"
        Me.lvFactura.Size = New System.Drawing.Size(1160, 526)
        Me.lvFactura.TabIndex = 154
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
        'lvFactura_idNotaDebito
        '
        Me.lvFactura_idNotaDebito.Text = "idNotaDeb."
        Me.lvFactura_idNotaDebito.Width = 70
        '
        'lvFactura_selec
        '
        Me.lvFactura_selec.Text = "Selec."
        Me.lvFactura_selec.Width = 50
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboSucursal)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 22)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(476, 68)
        Me.GroupBox4.TabIndex = 153
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
        Me.cboSucursal.Size = New System.Drawing.Size(437, 28)
        Me.cboSucursal.TabIndex = 50
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 104)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1208, 577)
        Me.TabControl1.TabIndex = 162
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvFactura)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1200, 548)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nota de Crédito"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvError)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtNroLote)
        Me.TabPage2.Controls.Add(Me.lvLote)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1200, 548)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Consulta Lote"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.lvError.Location = New System.Drawing.Point(18, 301)
        Me.lvError.Margin = New System.Windows.Forms.Padding(4)
        Me.lvError.MultiSelect = False
        Me.lvError.Name = "lvError"
        Me.lvError.Size = New System.Drawing.Size(877, 237)
        Me.lvError.TabIndex = 200
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
        Me.Label2.Location = New System.Drawing.Point(707, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Nro. Lote"
        '
        'txtNroLote
        '
        Me.txtNroLote.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNroLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroLote.Location = New System.Drawing.Point(704, 47)
        Me.txtNroLote.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroLote.Name = "txtNroLote"
        Me.txtNroLote.ReadOnly = True
        Me.txtNroLote.Size = New System.Drawing.Size(342, 30)
        Me.txtNroLote.TabIndex = 198
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
        Me.lvLote.Location = New System.Drawing.Point(15, 12)
        Me.lvLote.Margin = New System.Windows.Forms.Padding(4)
        Me.lvLote.MultiSelect = False
        Me.lvLote.Name = "lvLote"
        Me.lvLote.Size = New System.Drawing.Size(681, 264)
        Me.lvLote.TabIndex = 197
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
        'txtCdc
        '
        Me.txtCdc.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtCdc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCdc.Location = New System.Drawing.Point(88, 696)
        Me.txtCdc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCdc.Name = "txtCdc"
        Me.txtCdc.ReadOnly = True
        Me.txtCdc.Size = New System.Drawing.Size(572, 30)
        Me.txtCdc.TabIndex = 195
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 698)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 25)
        Me.Label4.TabIndex = 194
        Me.Label4.Text = "CDC:"
        '
        'btnActualizarLote
        '
        Me.btnActualizarLote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizarLote.Image = CType(resources.GetObject("btnActualizarLote.Image"), System.Drawing.Image)
        Me.btnActualizarLote.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizarLote.Location = New System.Drawing.Point(991, 24)
        Me.btnActualizarLote.Margin = New System.Windows.Forms.Padding(4)
        Me.btnActualizarLote.Name = "btnActualizarLote"
        Me.btnActualizarLote.Size = New System.Drawing.Size(115, 46)
        Me.btnActualizarLote.TabIndex = 196
        Me.btnActualizarLote.Text = "Actualizar Lote"
        Me.btnActualizarLote.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizarLote.UseVisualStyleBackColor = True
        '
        'btnAprobar
        '
        Me.btnAprobar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAprobar.Image = CType(resources.GetObject("btnAprobar.Image"), System.Drawing.Image)
        Me.btnAprobar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAprobar.Location = New System.Drawing.Point(1114, 24)
        Me.btnAprobar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(77, 46)
        Me.btnAprobar.TabIndex = 197
        Me.btnAprobar.Text = "&Aprobar"
        Me.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'frmNotaDebitoElectronico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.ClientSize = New System.Drawing.Size(1232, 737)
        Me.Controls.Add(Me.btnAprobar)
        Me.Controls.Add(Me.btnActualizarLote)
        Me.Controls.Add(Me.txtCdc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.txtHastaNro)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDesdeNro)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNotaDebitoElectronico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota de Crédito - Electrónico"
        Me.GroupBox4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents txtHastaNro As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDesdeNro As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lvFactura As System.Windows.Forms.ListView
    Friend WithEvents lvFactura_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_nroFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_tipoVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_idNotaDebito As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura_selec As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtCdc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lvError As System.Windows.Forms.ListView
    Friend WithEvents lvError_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvError_idLote As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvError_idMov As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvError_mensaje As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNroLote As System.Windows.Forms.TextBox
    Friend WithEvents lvLote As System.Windows.Forms.ListView
    Friend WithEvents lvLote_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_idLote As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_tipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_fecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_fechaConsulta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvLote_lote As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnActualizarLote As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
End Class
