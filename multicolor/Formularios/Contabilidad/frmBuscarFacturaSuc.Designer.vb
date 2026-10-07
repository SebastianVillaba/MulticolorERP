<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarFacturaSuc
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
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.lvBuscar_idFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBuscar_sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBuscar_timbrado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBuscar_dsuc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBuscar_dcaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBuscar_vence = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBuscar_factura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblIdFacturaAnt = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvBuscar
        '
        Me.lvBuscar.AllowColumnReorder = True
        Me.lvBuscar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvBuscar_idFactura, Me.lvBuscar_sucursal, Me.lvBuscar_timbrado, Me.lvBuscar_dsuc, Me.lvBuscar_dcaja, Me.lvBuscar_vence, Me.lvBuscar_factura})
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(12, 42)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(627, 310)
        Me.lvBuscar.TabIndex = 4
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'lvBuscar_idFactura
        '
        Me.lvBuscar_idFactura.Text = "ID"
        Me.lvBuscar_idFactura.Width = 40
        '
        'lvBuscar_sucursal
        '
        Me.lvBuscar_sucursal.Text = "Sucursal"
        Me.lvBuscar_sucursal.Width = 250
        '
        'lvBuscar_timbrado
        '
        Me.lvBuscar_timbrado.Text = "Timbrado"
        Me.lvBuscar_timbrado.Width = 90
        '
        'lvBuscar_dsuc
        '
        Me.lvBuscar_dsuc.Text = "DSuc"
        Me.lvBuscar_dsuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvBuscar_dsuc.Width = 50
        '
        'lvBuscar_dcaja
        '
        Me.lvBuscar_dcaja.Text = "DCaja"
        Me.lvBuscar_dcaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvBuscar_dcaja.Width = 50
        '
        'lvBuscar_vence
        '
        Me.lvBuscar_vence.Text = "Vence"
        Me.lvBuscar_vence.Width = 80
        '
        'lvBuscar_factura
        '
        Me.lvBuscar_factura.Text = "Factura"
        '
        'lblIdFacturaAnt
        '
        Me.lblIdFacturaAnt.AutoSize = True
        Me.lblIdFacturaAnt.BackColor = System.Drawing.Color.SpringGreen
        Me.lblIdFacturaAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdFacturaAnt.Location = New System.Drawing.Point(12, 9)
        Me.lblIdFacturaAnt.Name = "lblIdFacturaAnt"
        Me.lblIdFacturaAnt.Size = New System.Drawing.Size(40, 18)
        Me.lblIdFacturaAnt.TabIndex = 128
        Me.lblIdFacturaAnt.Text = "9999"
        '
        'frmBuscarFacturaSuc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 386)
        Me.Controls.Add(Me.lblIdFacturaAnt)
        Me.Controls.Add(Me.lvBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarFacturaSuc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Facturas de Sucursales"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents lvBuscar_idFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBuscar_sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBuscar_timbrado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBuscar_dsuc As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBuscar_dcaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBuscar_vence As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBuscar_factura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblIdFacturaAnt As System.Windows.Forms.Label
End Class
