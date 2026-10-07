<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteDelivery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteDelivery))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpHastaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesdeFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblIdRepartidor = New System.Windows.Forms.Label()
        Me.lblRepartidor = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdDeliveryExterno = New System.Windows.Forms.RadioButton()
        Me.rdRecepcionAgrupadoSucursal = New System.Windows.Forms.RadioButton()
        Me.rdRemisionesSucursal = New System.Windows.Forms.RadioButton()
        Me.rdRemisionVentaDelivery = New System.Windows.Forms.RadioButton()
        Me.rdDetalleTotalRepartidor = New System.Windows.Forms.RadioButton()
        Me.rdRemisionVenta = New System.Windows.Forms.RadioButton()
        Me.rdRepartidorSucursal = New System.Windows.Forms.RadioButton()
        Me.rdDetallePorSucursal = New System.Windows.Forms.RadioButton()
        Me.rdTotalRepartidor = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkTodoSucursal = New System.Windows.Forms.CheckBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.rdDeliveryEnvio = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpHastaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpDesdeFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(365, 133)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(236, 47)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(92, 46)
        Me.btnConsultar.TabIndex = 97
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpHastaFecha
        '
        Me.dtpHastaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaFecha.Location = New System.Drawing.Point(80, 78)
        Me.dtpHastaFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpHastaFecha.Name = "dtpHastaFecha"
        Me.dtpHastaFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpHastaFecha.Size = New System.Drawing.Size(129, 22)
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
        Me.dtpDesdeFecha.Size = New System.Drawing.Size(129, 22)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblIdRepartidor)
        Me.GroupBox2.Controls.Add(Me.lblRepartidor)
        Me.GroupBox2.Location = New System.Drawing.Point(385, 16)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(509, 110)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Repartidor"
        '
        'lblIdRepartidor
        '
        Me.lblIdRepartidor.AutoSize = True
        Me.lblIdRepartidor.BackColor = System.Drawing.Color.Lime
        Me.lblIdRepartidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdRepartidor.Location = New System.Drawing.Point(24, 70)
        Me.lblIdRepartidor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdRepartidor.Name = "lblIdRepartidor"
        Me.lblIdRepartidor.Size = New System.Drawing.Size(148, 24)
        Me.lblIdRepartidor.TabIndex = 1
        Me.lblIdRepartidor.Text = "IDREPARTIDOR"
        '
        'lblRepartidor
        '
        Me.lblRepartidor.AutoSize = True
        Me.lblRepartidor.BackColor = System.Drawing.Color.Lime
        Me.lblRepartidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepartidor.Location = New System.Drawing.Point(24, 36)
        Me.lblRepartidor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRepartidor.Name = "lblRepartidor"
        Me.lblRepartidor.Size = New System.Drawing.Size(131, 24)
        Me.lblRepartidor.TabIndex = 0
        Me.lblRepartidor.Text = "REPARTIDOR"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdDeliveryEnvio)
        Me.GroupBox3.Controls.Add(Me.rdDeliveryExterno)
        Me.GroupBox3.Controls.Add(Me.rdRecepcionAgrupadoSucursal)
        Me.GroupBox3.Controls.Add(Me.rdRemisionesSucursal)
        Me.GroupBox3.Controls.Add(Me.rdRemisionVentaDelivery)
        Me.GroupBox3.Controls.Add(Me.rdDetalleTotalRepartidor)
        Me.GroupBox3.Controls.Add(Me.rdRemisionVenta)
        Me.GroupBox3.Controls.Add(Me.rdRepartidorSucursal)
        Me.GroupBox3.Controls.Add(Me.rdDetallePorSucursal)
        Me.GroupBox3.Controls.Add(Me.rdTotalRepartidor)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 161)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(277, 338)
        Me.GroupBox3.TabIndex = 102
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'rdDeliveryExterno
        '
        Me.rdDeliveryExterno.AutoSize = True
        Me.rdDeliveryExterno.Location = New System.Drawing.Point(5, 251)
        Me.rdDeliveryExterno.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDeliveryExterno.Name = "rdDeliveryExterno"
        Me.rdDeliveryExterno.Size = New System.Drawing.Size(132, 21)
        Me.rdDeliveryExterno.TabIndex = 26
        Me.rdDeliveryExterno.Text = "Delivery Externo"
        Me.rdDeliveryExterno.UseVisualStyleBackColor = True
        '
        'rdRecepcionAgrupadoSucursal
        '
        Me.rdRecepcionAgrupadoSucursal.AutoSize = True
        Me.rdRecepcionAgrupadoSucursal.Location = New System.Drawing.Point(5, 222)
        Me.rdRecepcionAgrupadoSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.rdRecepcionAgrupadoSucursal.Name = "rdRecepcionAgrupadoSucursal"
        Me.rdRecepcionAgrupadoSucursal.Size = New System.Drawing.Size(246, 21)
        Me.rdRecepcionAgrupadoSucursal.TabIndex = 25
        Me.rdRecepcionAgrupadoSucursal.Text = "Recepción Agrupado por Sucursal"
        Me.rdRecepcionAgrupadoSucursal.UseVisualStyleBackColor = True
        '
        'rdRemisionesSucursal
        '
        Me.rdRemisionesSucursal.AutoSize = True
        Me.rdRemisionesSucursal.Location = New System.Drawing.Point(5, 191)
        Me.rdRemisionesSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.rdRemisionesSucursal.Name = "rdRemisionesSucursal"
        Me.rdRemisionesSucursal.Size = New System.Drawing.Size(252, 21)
        Me.rdRemisionesSucursal.TabIndex = 24
        Me.rdRemisionesSucursal.Text = "Remisiones Agrupado por Sucursal"
        Me.rdRemisionesSucursal.UseVisualStyleBackColor = True
        '
        'rdRemisionVentaDelivery
        '
        Me.rdRemisionVentaDelivery.AutoSize = True
        Me.rdRemisionVentaDelivery.Location = New System.Drawing.Point(5, 162)
        Me.rdRemisionVentaDelivery.Margin = New System.Windows.Forms.Padding(4)
        Me.rdRemisionVentaDelivery.Name = "rdRemisionVentaDelivery"
        Me.rdRemisionVentaDelivery.Size = New System.Drawing.Size(241, 21)
        Me.rdRemisionVentaDelivery.TabIndex = 23
        Me.rdRemisionVentaDelivery.Text = "Remisiones p/ Ventas en Delivery"
        Me.rdRemisionVentaDelivery.UseVisualStyleBackColor = True
        '
        'rdDetalleTotalRepartidor
        '
        Me.rdDetalleTotalRepartidor.AutoSize = True
        Me.rdDetalleTotalRepartidor.Location = New System.Drawing.Point(5, 134)
        Me.rdDetalleTotalRepartidor.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDetalleTotalRepartidor.Name = "rdDetalleTotalRepartidor"
        Me.rdDetalleTotalRepartidor.Size = New System.Drawing.Size(205, 21)
        Me.rdDetalleTotalRepartidor.TabIndex = 22
        Me.rdDetalleTotalRepartidor.Text = "Detalle Total por Repartidor"
        Me.rdDetalleTotalRepartidor.UseVisualStyleBackColor = True
        '
        'rdRemisionVenta
        '
        Me.rdRemisionVenta.AutoSize = True
        Me.rdRemisionVenta.Location = New System.Drawing.Point(5, 108)
        Me.rdRemisionVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.rdRemisionVenta.Name = "rdRemisionVenta"
        Me.rdRemisionVenta.Size = New System.Drawing.Size(183, 21)
        Me.rdRemisionVenta.TabIndex = 21
        Me.rdRemisionVenta.Text = "Remisiones para Ventas"
        Me.rdRemisionVenta.UseVisualStyleBackColor = True
        '
        'rdRepartidorSucursal
        '
        Me.rdRepartidorSucursal.AutoSize = True
        Me.rdRepartidorSucursal.Location = New System.Drawing.Point(5, 80)
        Me.rdRepartidorSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.rdRepartidorSucursal.Name = "rdRepartidorSucursal"
        Me.rdRepartidorSucursal.Size = New System.Drawing.Size(212, 21)
        Me.rdRepartidorSucursal.TabIndex = 20
        Me.rdRepartidorSucursal.Text = "Detalle por Repartidor y Suc."
        Me.rdRepartidorSucursal.UseVisualStyleBackColor = True
        '
        'rdDetallePorSucursal
        '
        Me.rdDetallePorSucursal.AutoSize = True
        Me.rdDetallePorSucursal.Location = New System.Drawing.Point(8, 52)
        Me.rdDetallePorSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDetallePorSucursal.Name = "rdDetallePorSucursal"
        Me.rdDetallePorSucursal.Size = New System.Drawing.Size(157, 21)
        Me.rdDetallePorSucursal.TabIndex = 19
        Me.rdDetallePorSucursal.Text = "Detalle por Sucursal"
        Me.rdDetallePorSucursal.UseVisualStyleBackColor = True
        '
        'rdTotalRepartidor
        '
        Me.rdTotalRepartidor.AutoSize = True
        Me.rdTotalRepartidor.Checked = True
        Me.rdTotalRepartidor.Location = New System.Drawing.Point(8, 23)
        Me.rdTotalRepartidor.Margin = New System.Windows.Forms.Padding(4)
        Me.rdTotalRepartidor.Name = "rdTotalRepartidor"
        Me.rdTotalRepartidor.Size = New System.Drawing.Size(157, 21)
        Me.rdTotalRepartidor.TabIndex = 18
        Me.rdTotalRepartidor.TabStop = True
        Me.rdTotalRepartidor.Text = "Total por Repartidor"
        Me.rdTotalRepartidor.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkTodoSucursal)
        Me.GroupBox4.Controls.Add(Me.cboSucursal)
        Me.GroupBox4.Location = New System.Drawing.Point(323, 161)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(489, 79)
        Me.GroupBox4.TabIndex = 103
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Sucursal"
        '
        'chkTodoSucursal
        '
        Me.chkTodoSucursal.AutoSize = True
        Me.chkTodoSucursal.Checked = True
        Me.chkTodoSucursal.CheckState = System.Windows.Forms.CheckState.Checked
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
        'rdDeliveryEnvio
        '
        Me.rdDeliveryEnvio.AutoSize = True
        Me.rdDeliveryEnvio.Location = New System.Drawing.Point(5, 280)
        Me.rdDeliveryEnvio.Margin = New System.Windows.Forms.Padding(4)
        Me.rdDeliveryEnvio.Name = "rdDeliveryEnvio"
        Me.rdDeliveryEnvio.Size = New System.Drawing.Size(203, 21)
        Me.rdDeliveryEnvio.TabIndex = 27
        Me.rdDeliveryEnvio.Text = "Delivery en Envios p/ Venta"
        Me.rdDeliveryEnvio.UseVisualStyleBackColor = True
        '
        'frmReporteDelivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 532)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteDelivery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Delivery"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHastaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdeFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdDetallePorSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents rdTotalRepartidor As System.Windows.Forms.RadioButton
    Friend WithEvents lblIdRepartidor As System.Windows.Forms.Label
    Friend WithEvents lblRepartidor As System.Windows.Forms.Label
    Friend WithEvents rdRepartidorSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodoSucursal As System.Windows.Forms.CheckBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents rdRemisionVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rdDetalleTotalRepartidor As System.Windows.Forms.RadioButton
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents rdRemisionVentaDelivery As System.Windows.Forms.RadioButton
    Friend WithEvents rdRemisionesSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents rdRecepcionAgrupadoSucursal As System.Windows.Forms.RadioButton
    Friend WithEvents rdDeliveryExterno As System.Windows.Forms.RadioButton
    Friend WithEvents rdDeliveryEnvio As System.Windows.Forms.RadioButton
End Class
