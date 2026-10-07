<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormaVenta
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
        Me.grBuscar = New System.Windows.Forms.GroupBox
        Me.txtFormaVenta = New System.Windows.Forms.TextBox
        Me.lvFormaVenta = New System.Windows.Forms.ListView
        Me.IdTipoVenta = New System.Windows.Forms.ColumnHeader
        Me.Nombre = New System.Windows.Forms.ColumnHeader
        Me.Abreviatura = New System.Windows.Forms.ColumnHeader
        Me.grBuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtFormaVenta)
        Me.grBuscar.Controls.Add(Me.lvFormaVenta)
        Me.grBuscar.Location = New System.Drawing.Point(14, 5)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(336, 170)
        Me.grBuscar.TabIndex = 3
        Me.grBuscar.TabStop = False
        '
        'txtFormaVenta
        '
        Me.txtFormaVenta.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtFormaVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormaVenta.Enabled = False
        Me.txtFormaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormaVenta.Location = New System.Drawing.Point(45, 19)
        Me.txtFormaVenta.Name = "txtFormaVenta"
        Me.txtFormaVenta.Size = New System.Drawing.Size(237, 22)
        Me.txtFormaVenta.TabIndex = 2
        Me.txtFormaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvFormaVenta
        '
        Me.lvFormaVenta.AllowColumnReorder = True
        Me.lvFormaVenta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IdTipoVenta, Me.Nombre, Me.Abreviatura})
        Me.lvFormaVenta.FullRowSelect = True
        Me.lvFormaVenta.GridLines = True
        Me.lvFormaVenta.HideSelection = False
        Me.lvFormaVenta.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvFormaVenta.LabelWrap = False
        Me.lvFormaVenta.Location = New System.Drawing.Point(27, 47)
        Me.lvFormaVenta.MultiSelect = False
        Me.lvFormaVenta.Name = "lvFormaVenta"
        Me.lvFormaVenta.Size = New System.Drawing.Size(268, 114)
        Me.lvFormaVenta.TabIndex = 3
        Me.lvFormaVenta.UseCompatibleStateImageBehavior = False
        Me.lvFormaVenta.View = System.Windows.Forms.View.Details
        '
        'IdTipoVenta
        '
        Me.IdTipoVenta.Text = "Id"
        Me.IdTipoVenta.Width = 40
        '
        'Nombre
        '
        Me.Nombre.Text = "Forma de Venta"
        Me.Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Nombre.Width = 160
        '
        'Abreviatura
        '
        Me.Abreviatura.Text = "Abrev."
        Me.Abreviatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmFormaVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 186)
        Me.ControlBox = False
        Me.Controls.Add(Me.grBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFormaVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Forma de Venta"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtFormaVenta As System.Windows.Forms.TextBox
    Friend WithEvents lvFormaVenta As System.Windows.Forms.ListView
    Friend WithEvents IdTipoVenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents Nombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents Abreviatura As System.Windows.Forms.ColumnHeader
End Class
