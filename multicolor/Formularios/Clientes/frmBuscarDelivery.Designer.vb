<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarDelivery
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
        Me.lvDelivery = New System.Windows.Forms.ListView()
        Me.det_idDelivery = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_zona = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.det_monto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvDelivery
        '
        Me.lvDelivery.AllowColumnReorder = True
        Me.lvDelivery.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.det_idDelivery, Me.det_zona, Me.det_monto})
        Me.lvDelivery.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDelivery.FullRowSelect = True
        Me.lvDelivery.GridLines = True
        Me.lvDelivery.HideSelection = False
        Me.lvDelivery.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvDelivery.LabelWrap = False
        Me.lvDelivery.Location = New System.Drawing.Point(13, 22)
        Me.lvDelivery.Margin = New System.Windows.Forms.Padding(4)
        Me.lvDelivery.MultiSelect = False
        Me.lvDelivery.Name = "lvDelivery"
        Me.lvDelivery.Size = New System.Drawing.Size(447, 184)
        Me.lvDelivery.TabIndex = 116
        Me.lvDelivery.UseCompatibleStateImageBehavior = False
        Me.lvDelivery.View = System.Windows.Forms.View.Details
        '
        'det_idDelivery
        '
        Me.det_idDelivery.Text = "Id Del."
        '
        'det_zona
        '
        Me.det_zona.Text = "Zona"
        Me.det_zona.Width = 150
        '
        'det_monto
        '
        Me.det_monto.Text = "Monto"
        Me.det_monto.Width = 90
        '
        'frmBuscarDelivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 252)
        Me.Controls.Add(Me.lvDelivery)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarDelivery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Delivery"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvDelivery As System.Windows.Forms.ListView
    Friend WithEvents det_idDelivery As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_zona As System.Windows.Forms.ColumnHeader
    Friend WithEvents det_monto As System.Windows.Forms.ColumnHeader
End Class
