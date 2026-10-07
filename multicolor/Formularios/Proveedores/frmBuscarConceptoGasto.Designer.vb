<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarConceptoGasto
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
        Me.lvConcepto = New System.Windows.Forms.ListView()
        Me.lv_idImpuesto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_PorcentajeImpuesto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_factorImpuesto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_concepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_costo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lvConcepto
        '
        Me.lvConcepto.AllowColumnReorder = True
        Me.lvConcepto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lv_idImpuesto, Me.lv_PorcentajeImpuesto, Me.lv_factorImpuesto, Me.lv_concepto, Me.lv_costo})
        Me.lvConcepto.FullRowSelect = True
        Me.lvConcepto.GridLines = True
        Me.lvConcepto.HideSelection = False
        Me.lvConcepto.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvConcepto.LabelWrap = False
        Me.lvConcepto.Location = New System.Drawing.Point(12, 34)
        Me.lvConcepto.MultiSelect = False
        Me.lvConcepto.Name = "lvConcepto"
        Me.lvConcepto.Size = New System.Drawing.Size(428, 177)
        Me.lvConcepto.TabIndex = 5
        Me.lvConcepto.UseCompatibleStateImageBehavior = False
        Me.lvConcepto.View = System.Windows.Forms.View.Details
        '
        'lv_idImpuesto
        '
        Me.lv_idImpuesto.Text = "idImp"
        Me.lv_idImpuesto.Width = 50
        '
        'lv_PorcentajeImpuesto
        '
        Me.lv_PorcentajeImpuesto.Text = "%IVA"
        Me.lv_PorcentajeImpuesto.Width = 50
        '
        'lv_factorImpuesto
        '
        Me.lv_factorImpuesto.Text = "Factor"
        Me.lv_factorImpuesto.Width = 50
        '
        'lv_concepto
        '
        Me.lv_concepto.Text = "Concepto"
        Me.lv_concepto.Width = 200
        '
        'lv_costo
        '
        Me.lv_costo.Text = "Costo"
        Me.lv_costo.Width = 70
        '
        'txtConcepto
        '
        Me.txtConcepto.BackColor = System.Drawing.Color.LightBlue
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Enabled = False
        Me.txtConcepto.Location = New System.Drawing.Point(12, 217)
        Me.txtConcepto.MaxLength = 3
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(316, 20)
        Me.txtConcepto.TabIndex = 23
        '
        'txtSql
        '
        Me.txtSql.BackColor = System.Drawing.Color.White
        Me.txtSql.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSql.Location = New System.Drawing.Point(12, 249)
        Me.txtSql.MaxLength = 3
        Me.txtSql.Name = "txtSql"
        Me.txtSql.Size = New System.Drawing.Size(439, 20)
        Me.txtSql.TabIndex = 24
        Me.txtSql.Visible = False
        '
        'frmBuscarConceptoGasto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 267)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.lvConcepto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarConceptoGasto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Conceptos en Detalles de Gastos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvConcepto As System.Windows.Forms.ListView
    Friend WithEvents lv_idImpuesto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lv_PorcentajeImpuesto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lv_factorImpuesto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lv_concepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lv_costo As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents txtSql As System.Windows.Forms.TextBox
End Class
