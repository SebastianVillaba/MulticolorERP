<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoneda
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
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.lvMoneda = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cotizacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nombreMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.abreviatura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.LightBlue
        Me.txtMoneda.Enabled = False
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(15, 7)
        Me.txtMoneda.MaxLength = 60
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(125, 22)
        Me.txtMoneda.TabIndex = 110
        '
        'lvMoneda
        '
        Me.lvMoneda.AllowColumnReorder = True
        Me.lvMoneda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.cotizacion, Me.nombreMoneda, Me.abreviatura})
        Me.lvMoneda.FullRowSelect = True
        Me.lvMoneda.GridLines = True
        Me.lvMoneda.HideSelection = False
        Me.lvMoneda.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvMoneda.LabelWrap = False
        Me.lvMoneda.Location = New System.Drawing.Point(14, 35)
        Me.lvMoneda.MultiSelect = False
        Me.lvMoneda.Name = "lvMoneda"
        Me.lvMoneda.Size = New System.Drawing.Size(237, 220)
        Me.lvMoneda.TabIndex = 109
        Me.lvMoneda.UseCompatibleStateImageBehavior = False
        Me.lvMoneda.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 40
        '
        'cotizacion
        '
        Me.cotizacion.Text = "Cotización"
        Me.cotizacion.Width = 70
        '
        'nombreMoneda
        '
        Me.nombreMoneda.Text = "Moneda"
        Me.nombreMoneda.Width = 70
        '
        'abreviatura
        '
        Me.abreviatura.Text = "Abrev."
        Me.abreviatura.Width = 50
        '
        'frmMoneda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 262)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.lvMoneda)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMoneda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monedas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents lvMoneda As System.Windows.Forms.ListView
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents cotizacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombreMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents abreviatura As System.Windows.Forms.ColumnHeader
End Class
