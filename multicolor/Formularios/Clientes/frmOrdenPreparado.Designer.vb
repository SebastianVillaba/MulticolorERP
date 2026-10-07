<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPreparado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenPreparado))
        Me.txtIdMov = New System.Windows.Forms.TextBox()
        Me.lvBuscar = New System.Windows.Forms.ListView()
        Me.IdOrden = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grBuscar = New System.Windows.Forms.GroupBox()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grBuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIdMov
        '
        Me.txtIdMov.BackColor = System.Drawing.Color.SkyBlue
        Me.txtIdMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMov.Enabled = False
        Me.txtIdMov.Location = New System.Drawing.Point(12, 23)
        Me.txtIdMov.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdMov.Name = "txtIdMov"
        Me.txtIdMov.Size = New System.Drawing.Size(76, 22)
        Me.txtIdMov.TabIndex = 4
        '
        'lvBuscar
        '
        Me.lvBuscar.AllowColumnReorder = True
        Me.lvBuscar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IdOrden, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader2, Me.ColumnHeader1})
        Me.lvBuscar.FullRowSelect = True
        Me.lvBuscar.GridLines = True
        Me.lvBuscar.HideSelection = False
        Me.lvBuscar.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBuscar.LabelWrap = False
        Me.lvBuscar.Location = New System.Drawing.Point(12, 63)
        Me.lvBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.lvBuscar.MultiSelect = False
        Me.lvBuscar.Name = "lvBuscar"
        Me.lvBuscar.Size = New System.Drawing.Size(1067, 502)
        Me.lvBuscar.TabIndex = 5
        Me.lvBuscar.UseCompatibleStateImageBehavior = False
        Me.lvBuscar.View = System.Windows.Forms.View.Details
        '
        'IdOrden
        '
        Me.IdOrden.Text = "ID Orden"
        Me.IdOrden.Width = 70
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Nombre Orden"
        Me.ColumnHeader8.Width = 400
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Tipo"
        Me.ColumnHeader9.Width = 130
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Fecha Hora"
        Me.ColumnHeader11.Width = 130
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Total"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width = 45
        '
        'grBuscar
        '
        Me.grBuscar.Controls.Add(Me.lvBuscar)
        Me.grBuscar.Controls.Add(Me.txtIdMov)
        Me.grBuscar.Location = New System.Drawing.Point(18, 22)
        Me.grBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Name = "grBuscar"
        Me.grBuscar.Padding = New System.Windows.Forms.Padding(4)
        Me.grBuscar.Size = New System.Drawing.Size(1109, 581)
        Me.grBuscar.TabIndex = 10
        Me.grBuscar.TabStop = False
        Me.grBuscar.Text = "Búsqueda"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Cant."
        '
        'frmOrdenPreparado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 622)
        Me.Controls.Add(Me.grBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrdenPreparado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Orden Preparado"
        Me.grBuscar.ResumeLayout(False)
        Me.grBuscar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtIdMov As System.Windows.Forms.TextBox
    Friend WithEvents lvBuscar As System.Windows.Forms.ListView
    Friend WithEvents IdOrden As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class
