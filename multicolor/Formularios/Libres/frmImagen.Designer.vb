<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImagen
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
        Me.picImagenMercaderia = New System.Windows.Forms.PictureBox()
        CType(Me.picImagenMercaderia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picImagenMercaderia
        '
        Me.picImagenMercaderia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImagenMercaderia.Location = New System.Drawing.Point(29, 12)
        Me.picImagenMercaderia.Name = "picImagenMercaderia"
        Me.picImagenMercaderia.Size = New System.Drawing.Size(494, 459)
        Me.picImagenMercaderia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagenMercaderia.TabIndex = 110
        Me.picImagenMercaderia.TabStop = False
        '
        'frmImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 490)
        Me.Controls.Add(Me.picImagenMercaderia)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImagen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imagen"
        CType(Me.picImagenMercaderia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picImagenMercaderia As System.Windows.Forms.PictureBox
End Class
