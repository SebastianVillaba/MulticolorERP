Public Class frmActualizarRuc
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub actializarRuc0()
        'MsgBox("Antes de borrar")
        If (fun_guardarSp("sp_eliminarRucSet", intGl_idConfigPc, Me.Name)) = 0 Then

        End If
        'MsgBox("Paso 1")
        If (fun_guardarSp("sp_actualizarRUCSET00", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 0...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc1()
        If (fun_guardarSp("sp_actualizarRUCSET01", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 1...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc2()
        If (fun_guardarSp("sp_actualizarRUCSET02", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 2...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc3()
        If (fun_guardarSp("sp_actualizarRUCSET03", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 3...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc4()
        If (fun_guardarSp("sp_actualizarRUCSET04", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 4...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc5()
        If (fun_guardarSp("sp_actualizarRUCSET05", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 5...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc6()
        If (fun_guardarSp("sp_actualizarRUCSET06", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 6...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc7()
        If (fun_guardarSp("sp_actualizarRUCSET07", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 7...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc8()
        If (fun_guardarSp("sp_actualizarRUCSET08", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 8...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub actializarRuc9()
        If (fun_guardarSp("sp_actualizarRUCSET09", "", Me.Name)) = 0 Then
            Me.Enabled = True
            MessageBox.Show("No existe registros para esta consulta...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Me.Enabled = True
            MessageBox.Show("Actualizado con éxito la terminación 9...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- RADIOBUTON --'
    '****************'
    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click

        Me.Enabled = False

        If rdRuc0.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc0.txt") Then
                ' El archivo Existe!
                actializarRuc0()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc1.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc1.txt") Then
                ' El archivo Existe!
                actializarRuc1()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If

        End If
        If rdRuc2.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc2.txt") Then
                ' El archivo Existe!
                actializarRuc2()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc3.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc3.txt") Then
                ' El archivo Existe!
                actializarRuc3()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc4.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc4.txt") Then
                ' El archivo Existe!
                actializarRuc4()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc5.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc5.txt") Then
                ' El archivo Existe!
                actializarRuc5()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc6.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc6.txt") Then
                ' El archivo Existe!
                actializarRuc6()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc7.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc7.txt") Then
                ' El archivo Existe!
                actializarRuc7()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc8.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc8.txt") Then
                ' El archivo Existe!
                actializarRuc8()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
        If rdRuc9.Checked = True Then
            If System.IO.File.Exists("c:\Multicolor\ruc9.txt") Then
                ' El archivo Existe!
                actializarRuc9()
            Else
                MessageBox.Show("El archivo no existe...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Enabled = True
            End If
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmActualizarRuc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.contabilidadActualizarRuc.Enabled = True
        e.Cancel = False
    End Sub
End Class