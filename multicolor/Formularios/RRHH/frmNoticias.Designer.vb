<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoticias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoticias))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNoticia = New System.Windows.Forms.TextBox()
        Me.btnActualizarFotos = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtRutaXml = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRutaPdf = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIpServidorQR = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNoticia)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(785, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Noticias del Sistema NetJoin"
        '
        'txtNoticia
        '
        Me.txtNoticia.Location = New System.Drawing.Point(8, 36)
        Me.txtNoticia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNoticia.Multiline = True
        Me.txtNoticia.Name = "txtNoticia"
        Me.txtNoticia.Size = New System.Drawing.Size(749, 70)
        Me.txtNoticia.TabIndex = 0
        '
        'btnActualizarFotos
        '
        Me.btnActualizarFotos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualizarFotos.Image = CType(resources.GetObject("btnActualizarFotos.Image"), System.Drawing.Image)
        Me.btnActualizarFotos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizarFotos.Location = New System.Drawing.Point(12, 318)
        Me.btnActualizarFotos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnActualizarFotos.Name = "btnActualizarFotos"
        Me.btnActualizarFotos.Size = New System.Drawing.Size(137, 46)
        Me.btnActualizarFotos.TabIndex = 132
        Me.btnActualizarFotos.Text = "&Actualizar Fotos"
        Me.btnActualizarFotos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizarFotos.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(809, 30)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(92, 46)
        Me.btnGuardar.TabIndex = 133
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtRutaXml
        '
        Me.txtRutaXml.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtRutaXml.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaXml.Location = New System.Drawing.Point(132, 161)
        Me.txtRutaXml.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRutaXml.MaxLength = 100
        Me.txtRutaXml.Name = "txtRutaXml"
        Me.txtRutaXml.Size = New System.Drawing.Size(527, 27)
        Me.txtRutaXml.TabIndex = 195
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 165)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 20)
        Me.Label4.TabIndex = 194
        Me.Label4.Text = "Ruta XML :"
        '
        'txtRutaPdf
        '
        Me.txtRutaPdf.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtRutaPdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaPdf.Location = New System.Drawing.Point(132, 209)
        Me.txtRutaPdf.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRutaPdf.MaxLength = 100
        Me.txtRutaPdf.Name = "txtRutaPdf"
        Me.txtRutaPdf.Size = New System.Drawing.Size(527, 27)
        Me.txtRutaPdf.TabIndex = 197
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 213)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 196
        Me.Label1.Text = "Ruta PDF :"
        '
        'txtIpServidorQR
        '
        Me.txtIpServidorQR.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtIpServidorQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIpServidorQR.Location = New System.Drawing.Point(179, 259)
        Me.txtIpServidorQR.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIpServidorQR.MaxLength = 100
        Me.txtIpServidorQR.Name = "txtIpServidorQR"
        Me.txtIpServidorQR.Size = New System.Drawing.Size(328, 27)
        Me.txtIpServidorQR.TabIndex = 199
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 262)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 20)
        Me.Label2.TabIndex = 198
        Me.Label2.Text = "Ip Servidor QR :"
        '
        'frmNoticias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 377)
        Me.Controls.Add(Me.txtIpServidorQR)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRutaPdf)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRutaXml)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnActualizarFotos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNoticias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar Noticias del NetJoin"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoticia As System.Windows.Forms.TextBox
    Friend WithEvents btnActualizarFotos As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtRutaXml As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRutaPdf As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIpServidorQR As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
