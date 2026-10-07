Public Class frmNoticias
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- colocar la noticias
        cargarNoticiaActual()

    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub cargarNoticiaActual()
        txtNoticia.Text = sp_datosTabla.consulta_valorString("select mensajeMenuPrincipal from configEmpresa")
        txtRutaXml.Text = sp_datosTabla.consulta_valorString("select rutaXML from configEmpresa")
        txtRutaPdf.Text = sp_datosTabla.consulta_valorString("select rutaPDF from configEmpresa")
        txtIpServidorQR.Text = sp_datosTabla.consulta_valorString("select ipServerQR from configEmpresa")
    End Sub

    Private Sub guardarNoticia()
        Try
            '-- guardar la venta en si la venta de la sucursal
            If (fun_guardarSp("sp_guardarNoticiaSistema", "'" & Trim(txtNoticia.Text) & "','" & Trim(txtRutaXml.Text) & "','" & Trim(txtRutaPdf.Text) & "','" & _
                              Trim(txtIpServidorQR.Text) & "'", Me.Name)) = 0 Then
                MessageBox.Show("No se pudo Actualizar la Noticia del Sistema...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                cargarNoticiaActual()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub guardarFotoMercaderia()
        Try
            '-- guardar la venta en si la venta de la sucursal
            If (fun_guardarSp("sp_guardarFotoMercaderia", intGl_idConfigPc, Me.Name)) = 0 Then
                MessageBox.Show("No se pudo Actualizar la Noticia del Sistema...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                MessageBox.Show("Se guardo el Registro con Exito..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'cargarNoticiaActual()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("Desea Guardar la Noticia..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarNoticia()
        End If
    End Sub

    Private Sub btnActualizarFotos_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizarFotos.Click
        If MessageBox.Show("Desea Actualiar las Fotos de las mercaderias..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            guardarFotoMercaderia()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmNoticias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        frmMenuPrincipal.rrhhActualizarNoticia.Enabled = True

        e.Cancel = False
    End Sub
    '------------------------------------------------------------------------------

End Class