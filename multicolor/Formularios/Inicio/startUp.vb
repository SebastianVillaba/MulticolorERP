Public Class startUp
    'Dim info As New info

    'clases a utilizar
    Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.

        InitializeComponent()

        'info.obtenerSerialDisco()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'hayar la cadena de conexion de base de datos
        'MsgBox("Esta hayando la conexion..!", MsgBoxStyle.Information)
        'hayarConexion()
        'verificar si la la entidad esta activa

        Me.Visible = False
        ' frmIngresoNick.Show()
    End Sub
    Private Sub StartUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmIngresoNick.Show()
        frmIngresoNick.BringToFront()
        frmIngresoNick.TopMost = True
        'frmIngresoNick.txtUsuario.Focus()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartUP
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
        Me.SuspendLayout()
        '
        'StartUP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 44)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "StartUP"
        Me.Opacity = 0
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "StartUP"
        Me.ResumeLayout(False)

    End Sub

End Class
