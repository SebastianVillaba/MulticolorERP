<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarEmpresaContable
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
        Dim ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Me.lvEmpresaContable = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIdPersonaJur = New System.Windows.Forms.TextBox()
        Me.txtEmpresaContable = New System.Windows.Forms.TextBox()
        ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvEmpresaContable
        '
        Me.lvEmpresaContable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, ColumnHeader1})
        Me.lvEmpresaContable.FullRowSelect = True
        Me.lvEmpresaContable.GridLines = True
        Me.lvEmpresaContable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvEmpresaContable.HideSelection = False
        Me.lvEmpresaContable.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvEmpresaContable.LabelWrap = False
        Me.lvEmpresaContable.Location = New System.Drawing.Point(4, 23)
        Me.lvEmpresaContable.MultiSelect = False
        Me.lvEmpresaContable.Name = "lvEmpresaContable"
        Me.lvEmpresaContable.Size = New System.Drawing.Size(396, 216)
        Me.lvEmpresaContable.TabIndex = 18
        Me.lvEmpresaContable.UseCompatibleStateImageBehavior = False
        Me.lvEmpresaContable.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        ColumnHeader1.Text = "Nombre de la Empresa"
        ColumnHeader1.Width = 350
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID"
        Me.ColumnHeader2.Width = 40
        '
        'txtIdPersonaJur
        '
        Me.txtIdPersonaJur.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdPersonaJur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPersonaJur.Enabled = False
        Me.txtIdPersonaJur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPersonaJur.Location = New System.Drawing.Point(3, 1)
        Me.txtIdPersonaJur.Name = "txtIdPersonaJur"
        Me.txtIdPersonaJur.Size = New System.Drawing.Size(48, 22)
        Me.txtIdPersonaJur.TabIndex = 19
        Me.txtIdPersonaJur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEmpresaContable
        '
        Me.txtEmpresaContable.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtEmpresaContable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpresaContable.Enabled = False
        Me.txtEmpresaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresaContable.Location = New System.Drawing.Point(57, 1)
        Me.txtEmpresaContable.Name = "txtEmpresaContable"
        Me.txtEmpresaContable.Size = New System.Drawing.Size(336, 22)
        Me.txtEmpresaContable.TabIndex = 20
        Me.txtEmpresaContable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmBuscarEmpresaContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 241)
        Me.Controls.Add(Me.txtEmpresaContable)
        Me.Controls.Add(Me.txtIdPersonaJur)
        Me.Controls.Add(Me.lvEmpresaContable)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarEmpresaContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elegir la Empresa Contable"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvEmpresaContable As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdPersonaJur As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresaContable As System.Windows.Forms.TextBox
End Class
