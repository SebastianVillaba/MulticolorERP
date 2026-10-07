<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFraccionado
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
        Me.txtRemi = New System.Windows.Forms.TextBox()
        Me.txtIdProducto = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.lvFraccionado = New System.Windows.Forms.ListView()
        Me.FormaFraccionado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cantidadFraccionado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdForma = New System.Windows.Forms.TextBox()
        Me.grBuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.txtIdForma)
        Me.grBuscar.Controls.Add(Me.txtRemi)
        Me.grBuscar.Controls.Add(Me.txtIdProducto)
        Me.grBuscar.Controls.Add(Me.txtProducto)
        Me.grBuscar.Controls.Add(Me.lvFraccionado)
        Me.grBuscar.Location = New System.Drawing.Point(12, 12)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Size = New System.Drawing.Size(423, 171)
        Me.grBuscar.TabIndex = 2
        Me.grBuscar.TabStop = False
        '
        'txtRemi
        '
        Me.txtRemi.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtRemi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemi.Enabled = False
        Me.txtRemi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemi.Location = New System.Drawing.Point(6, 143)
        Me.txtRemi.Name = "txtRemi"
        Me.txtRemi.Size = New System.Drawing.Size(60, 22)
        Me.txtRemi.TabIndex = 5
        Me.txtRemi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIdProducto
        '
        Me.txtIdProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProducto.Enabled = False
        Me.txtIdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProducto.Location = New System.Drawing.Point(6, 17)
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.Size = New System.Drawing.Size(60, 22)
        Me.txtIdProducto.TabIndex = 4
        Me.txtIdProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(72, 19)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(345, 22)
        Me.txtProducto.TabIndex = 2
        Me.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvFraccionado
        '
        Me.lvFraccionado.AllowColumnReorder = True
        Me.lvFraccionado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FormaFraccionado, Me.cantidadFraccionado})
        Me.lvFraccionado.FullRowSelect = True
        Me.lvFraccionado.GridLines = True
        Me.lvFraccionado.HideSelection = False
        Me.lvFraccionado.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvFraccionado.LabelWrap = False
        Me.lvFraccionado.Location = New System.Drawing.Point(50, 47)
        Me.lvFraccionado.MultiSelect = False
        Me.lvFraccionado.Name = "lvFraccionado"
        Me.lvFraccionado.Size = New System.Drawing.Size(264, 78)
        Me.lvFraccionado.TabIndex = 3
        Me.lvFraccionado.UseCompatibleStateImageBehavior = False
        Me.lvFraccionado.View = System.Windows.Forms.View.Details
        '
        'FormaFraccionado
        '
        Me.FormaFraccionado.Text = "Forma"
        Me.FormaFraccionado.Width = 150
        '
        'cantidadFraccionado
        '
        Me.cantidadFraccionado.Text = "Cant."
        '
        'txtIdForma
        '
        Me.txtIdForma.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdForma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdForma.Enabled = False
        Me.txtIdForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdForma.Location = New System.Drawing.Point(72, 143)
        Me.txtIdForma.Name = "txtIdForma"
        Me.txtIdForma.Size = New System.Drawing.Size(60, 22)
        Me.txtIdForma.TabIndex = 6
        Me.txtIdForma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmFraccionado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 195)
        Me.ControlBox = False
        Me.Controls.Add(Me.grBuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFraccionado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producto Fraccionado"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lvFraccionado As System.Windows.Forms.ListView
    Friend WithEvents FormaFraccionado As System.Windows.Forms.ColumnHeader
    Friend WithEvents cantidadFraccionado As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtRemi As System.Windows.Forms.TextBox
    Friend WithEvents txtIdForma As System.Windows.Forms.TextBox
End Class
