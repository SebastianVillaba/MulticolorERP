<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimbrado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTimbrado))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvTimbrado = New System.Windows.Forms.ListView()
        Me.lvTimbrado_timbrado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvTimbrado_fechaCa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvSuc = New System.Windows.Forms.ListView()
        Me.det_nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_idSuc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_dsuc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_dcaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_desde = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_hasta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grSincronizando = New System.Windows.Forms.GroupBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grSincronizando.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnProcesar)
        Me.GroupBox3.Controls.Add(Me.txtBuscar)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Controls.Add(Me.lvTimbrado)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 438)
        Me.GroupBox3.TabIndex = 121
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar Timbrados"
        '
        'btnProcesar
        '
        Me.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(228, 19)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(58, 37)
        Me.btnProcesar.TabIndex = 120
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(55, 25)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(164, 20)
        Me.txtBuscar.TabIndex = 119
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 118
        Me.PictureBox1.TabStop = False
        '
        'lvTimbrado
        '
        Me.lvTimbrado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvTimbrado_timbrado, Me.lvTimbrado_fechaCa})
        Me.lvTimbrado.Location = New System.Drawing.Point(22, 53)
        Me.lvTimbrado.Name = "lvTimbrado"
        Me.lvTimbrado.Size = New System.Drawing.Size(202, 379)
        Me.lvTimbrado.TabIndex = 117
        Me.lvTimbrado.UseCompatibleStateImageBehavior = False
        Me.lvTimbrado.View = System.Windows.Forms.View.Details
        '
        'lvTimbrado_timbrado
        '
        Me.lvTimbrado_timbrado.Text = "Timbrado"
        Me.lvTimbrado_timbrado.Width = 90
        '
        'lvTimbrado_fechaCa
        '
        Me.lvTimbrado_fechaCa.Text = "Hasta Fecha"
        Me.lvTimbrado_fechaCa.Width = 100
        '
        'lvSuc
        '
        Me.lvSuc.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_nro, Me.det_idSuc, Me.det_sucursal, Me.det_dsuc, Me.det_dcaja, Me.det_desde, Me.det_hasta, Me.det_total})
        Me.lvSuc.Location = New System.Drawing.Point(324, 12)
        Me.lvSuc.Name = "lvSuc"
        Me.lvSuc.Size = New System.Drawing.Size(602, 510)
        Me.lvSuc.TabIndex = 125
        Me.lvSuc.UseCompatibleStateImageBehavior = False
        Me.lvSuc.View = System.Windows.Forms.View.Details
        '
        'det_nro
        '
        Me.det_nro.Text = "Nro."
        Me.det_nro.Width = 50
        '
        'det_idSuc
        '
        Me.det_idSuc.Text = "ID Suc."
        Me.det_idSuc.Width = 50
        '
        'det_sucursal
        '
        Me.det_sucursal.Text = "Sucursal"
        Me.det_sucursal.Width = 200
        '
        'det_dsuc
        '
        Me.det_dsuc.Text = "Dsuc."
        Me.det_dsuc.Width = 40
        '
        'det_dcaja
        '
        Me.det_dcaja.Text = "DCaja"
        Me.det_dcaja.Width = 45
        '
        'det_desde
        '
        Me.det_desde.Text = "Desde"
        Me.det_desde.Width = 70
        '
        'det_hasta
        '
        Me.det_hasta.Text = "Hasta"
        Me.det_hasta.Width = 70
        '
        'det_total
        '
        Me.det_total.Text = "Total"
        Me.det_total.Width = 70
        '
        'grSincronizando
        '
        Me.grSincronizando.Controls.Add(Me.Label52)
        Me.grSincronizando.Controls.Add(Me.PictureBox2)
        Me.grSincronizando.Location = New System.Drawing.Point(285, 99)
        Me.grSincronizando.Name = "grSincronizando"
        Me.grSincronizando.Size = New System.Drawing.Size(366, 282)
        Me.grSincronizando.TabIndex = 227
        Me.grSincronizando.TabStop = False
        Me.grSincronizando.Visible = False
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Broadway", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(19, 19)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(219, 24)
        Me.Label52.TabIndex = 3
        Me.Label52.Text = "PROCESANDO......."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 62)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(351, 166)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(240, 485)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(58, 37)
        Me.btnImprimir.TabIndex = 121
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'frmTimbrado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 534)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.grSincronizando)
        Me.Controls.Add(Me.lvSuc)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimbrado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Timbrados"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grSincronizando.ResumeLayout(False)
        Me.grSincronizando.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvTimbrado As System.Windows.Forms.ListView
    Friend WithEvents lvTimbrado_timbrado As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvTimbrado_fechaCa As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSuc As System.Windows.Forms.ListView
    Friend WithEvents det_nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_idSuc As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_dsuc As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_dcaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_desde As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_hasta As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_total As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents grSincronizando As System.Windows.Forms.GroupBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
