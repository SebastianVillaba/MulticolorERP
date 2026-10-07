<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarBD
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
        Me.txtIdBd = New System.Windows.Forms.TextBox()
        Me.lvBD = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtNombreBaseDatos = New System.Windows.Forms.TextBox()
        Me.txtIdPersonaJur = New System.Windows.Forms.TextBox()
        ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'txtIdBd
        '
        Me.txtIdBd.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdBd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdBd.Enabled = False
        Me.txtIdBd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdBd.Location = New System.Drawing.Point(7, 6)
        Me.txtIdBd.Name = "txtIdBd"
        Me.txtIdBd.Size = New System.Drawing.Size(48, 22)
        Me.txtIdBd.TabIndex = 22
        Me.txtIdBd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvBD
        '
        Me.lvBD.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, ColumnHeader1})
        Me.lvBD.FullRowSelect = True
        Me.lvBD.GridLines = True
        Me.lvBD.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvBD.HideSelection = False
        Me.lvBD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvBD.LabelWrap = False
        Me.lvBD.Location = New System.Drawing.Point(8, 28)
        Me.lvBD.MultiSelect = False
        Me.lvBD.Name = "lvBD"
        Me.lvBD.Size = New System.Drawing.Size(396, 216)
        Me.lvBD.TabIndex = 21
        Me.lvBD.UseCompatibleStateImageBehavior = False
        Me.lvBD.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID"
        Me.ColumnHeader2.Width = 40
        '
        'ColumnHeader1
        '
        ColumnHeader1.Text = "Nombre de Base de Datos"
        ColumnHeader1.Width = 350
        '
        'txtNombreBaseDatos
        '
        Me.txtNombreBaseDatos.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtNombreBaseDatos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreBaseDatos.Enabled = False
        Me.txtNombreBaseDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreBaseDatos.Location = New System.Drawing.Point(61, 6)
        Me.txtNombreBaseDatos.Name = "txtNombreBaseDatos"
        Me.txtNombreBaseDatos.Size = New System.Drawing.Size(336, 22)
        Me.txtNombreBaseDatos.TabIndex = 23
        Me.txtNombreBaseDatos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIdPersonaJur
        '
        Me.txtIdPersonaJur.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtIdPersonaJur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPersonaJur.Enabled = False
        Me.txtIdPersonaJur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPersonaJur.Location = New System.Drawing.Point(7, 6)
        Me.txtIdPersonaJur.Name = "txtIdPersonaJur"
        Me.txtIdPersonaJur.Size = New System.Drawing.Size(48, 22)
        Me.txtIdPersonaJur.TabIndex = 22
        Me.txtIdPersonaJur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmBuscarBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 254)
        Me.Controls.Add(Me.txtIdBd)
        Me.Controls.Add(Me.lvBD)
        Me.Controls.Add(Me.txtNombreBaseDatos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarBD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Base de Datos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdBd As System.Windows.Forms.TextBox
    Friend WithEvents lvBD As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtNombreBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents txtIdPersonaJur As System.Windows.Forms.TextBox
End Class
