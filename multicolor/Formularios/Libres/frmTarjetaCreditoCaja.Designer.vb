<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarjetaCreditoCaja
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
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.lvTarjeta = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nombreTarjeta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'txtTarjeta
        '
        Me.txtTarjeta.BackColor = System.Drawing.Color.LightBlue
        Me.txtTarjeta.Enabled = False
        Me.txtTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjeta.Location = New System.Drawing.Point(21, 7)
        Me.txtTarjeta.MaxLength = 60
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Size = New System.Drawing.Size(125, 22)
        Me.txtTarjeta.TabIndex = 112
        '
        'lvTarjeta
        '
        Me.lvTarjeta.AllowColumnReorder = True
        Me.lvTarjeta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.nombreTarjeta})
        Me.lvTarjeta.FullRowSelect = True
        Me.lvTarjeta.GridLines = True
        Me.lvTarjeta.HideSelection = False
        Me.lvTarjeta.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvTarjeta.LabelWrap = False
        Me.lvTarjeta.Location = New System.Drawing.Point(20, 35)
        Me.lvTarjeta.MultiSelect = False
        Me.lvTarjeta.Name = "lvTarjeta"
        Me.lvTarjeta.Size = New System.Drawing.Size(167, 220)
        Me.lvTarjeta.TabIndex = 111
        Me.lvTarjeta.UseCompatibleStateImageBehavior = False
        Me.lvTarjeta.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 40
        '
        'nombreTarjeta
        '
        Me.nombreTarjeta.Text = "Tarjeta"
        Me.nombreTarjeta.Width = 120
        '
        'frmTarjetaCreditoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(204, 262)
        Me.Controls.Add(Me.txtTarjeta)
        Me.Controls.Add(Me.lvTarjeta)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarjetaCreditoCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarjeta de Crédito"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents lvTarjeta As System.Windows.Forms.ListView
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombreTarjeta As System.Windows.Forms.ColumnHeader
End Class
