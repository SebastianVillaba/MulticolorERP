<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregarVueltoDelivery
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
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.lv = New System.Windows.Forms.ListView()
        Me.detVuelto_idVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVuelto_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVuelto_cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVuelto_totalVenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVuelto_vuelto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVuelto_fechaHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVuelto_repartidor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.detVuelto_vendedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grBuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.lblSucursal)
        Me.grBuscar.Controls.Add(Me.Label1)
        Me.grBuscar.Controls.Add(Me.txtId)
        Me.grBuscar.Controls.Add(Me.lv)
        Me.grBuscar.Location = New System.Drawing.Point(10, 9)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(946, 336)
        Me.grBuscar.TabIndex = 5
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.BackColor = System.Drawing.Color.Yellow
        Me.lblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.Location = New System.Drawing.Point(168, 19)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(80, 18)
        Me.lblSucursal.TabIndex = 6
        Me.lblSucursal.Text = "lblSucursal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Sucursal:"
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.SkyBlue
        Me.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(6, 19)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(58, 20)
        Me.txtId.TabIndex = 4
        '
        'lv
        '
        Me.lv.AllowColumnReorder = True
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.detVuelto_idVenta, Me.detVuelto_factura, Me.detVuelto_cliente, Me.detVuelto_totalVenta, Me.detVuelto_vuelto, Me.detVuelto_fechaHora, Me.detVuelto_repartidor, Me.detVuelto_vendedor})
        Me.lv.FullRowSelect = True
        Me.lv.GridLines = True
        Me.lv.HideSelection = False
        Me.lv.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lv.LabelWrap = False
        Me.lv.Location = New System.Drawing.Point(6, 45)
        Me.lv.MultiSelect = False
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(934, 274)
        Me.lv.TabIndex = 3
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'detVuelto_idVenta
        '
        Me.detVuelto_idVenta.Text = "IDVenta"
        '
        'detVuelto_factura
        '
        Me.detVuelto_factura.Text = "Factura"
        Me.detVuelto_factura.Width = 120
        '
        'detVuelto_cliente
        '
        Me.detVuelto_cliente.Text = "Cliente"
        Me.detVuelto_cliente.Width = 200
        '
        'detVuelto_totalVenta
        '
        Me.detVuelto_totalVenta.Text = "Total Venta"
        Me.detVuelto_totalVenta.Width = 80
        '
        'detVuelto_vuelto
        '
        Me.detVuelto_vuelto.Text = "Total. Rep."
        Me.detVuelto_vuelto.Width = 80
        '
        'detVuelto_fechaHora
        '
        Me.detVuelto_fechaHora.Text = "Fecha Hora"
        Me.detVuelto_fechaHora.Width = 130
        '
        'detVuelto_repartidor
        '
        Me.detVuelto_repartidor.Text = "Repartidor"
        Me.detVuelto_repartidor.Width = 150
        '
        'detVuelto_vendedor
        '
        Me.detVuelto_vendedor.Text = "Vendedor"
        Me.detVuelto_vendedor.Width = 150
        '
        'frmEntregarVueltoDelivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 382)
        Me.Controls.Add(Me.grBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEntregarVueltoDelivery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entregar Vuelto - Delivery"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents detVuelto_idVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVuelto_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVuelto_cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVuelto_totalVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVuelto_vuelto As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVuelto_fechaHora As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVuelto_repartidor As System.Windows.Forms.ColumnHeader
    Friend WithEvents detVuelto_vendedor As System.Windows.Forms.ColumnHeader
End Class
