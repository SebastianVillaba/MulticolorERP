Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Diagnostics
Public Class frmBuscarImagen

    Dim nombreImg As String = ""

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnAbrir_Click(sender As System.Object, e As System.EventArgs) Handles btnAbrir.Click
        Dim strPath As String
        Dim strArchivo As String
        dlgFile = New OpenFileDialog
        dlgFile.Filter = "Imágenes JPG (*.jpg)|*.jpg|JEPG (*.jpeg)|*.jpeg|Mapas de bits (*.bmp)|*.bmp"
        dlgFile.Title = "Abre una imagen JPG o BMP o JPEG"
        If dlgFile.ShowDialog() = DialogResult.OK Then
            nombreImg = dlgFile.FileName
            pbxImg.Image = Image.FromFile(nombreImg)
            pbxImg.SizeMode = PictureBoxSizeMode.StretchImage
            lbImg.Text = nombreImg
            '-- extraer solo el nombre
            Dim i As Integer ' índice de la última aparición de \
            i = lbImg.Text.LastIndexOf("\")
            strPath = lbImg.Text.Remove(i, lbImg.Text.Length - i)
            ' strArchivo = ruta a la carpeta que contiene el archivo a partir de la última aparición de \
            '(es el nombre de archivo sin la ruta)
            strArchivo = lbImg.Text.Substring(i + 1)
            'strArchivo = lbImg.Text
            'MsgBox("Nombre del archivo  " & strArchivo)
            txtArchivo.Text = strArchivo
            '------------------------
            VScrollBar1.Enabled = True
            lbImg2.Text = "Ancho de imagen: " + pbxImg.Image.Width.ToString + _
            " px.  /  Alto de imagen: " + pbxImg.Image.Height.ToString + " px"
        End If
    End Sub
    '----------------------------------------------------------------------------------------
    '****************'
    '-- SCROLL BAR --'
    '****************'
    Private Sub VScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll

        'entero para almacenar el valor de la barra de desplazamiento
        Dim imgZoom As Single = VScrollBar1.Value

        'para que solamente lo haga si hay imagen en la caja de imagen
        If Not pbxImg.Image Is Nothing Then
            'código para que la caja de imagen sea redimensionada
            'manteniendo el modo de colocación de la imagen: centrada o ajustada
            If (pbxImg.SizeMode = PictureBoxSizeMode.StretchImage) Then
                pbxImg.Width = (456 * imgZoom) \ 100
                pbxImg.Height = (304 * imgZoom) \ 100
            End If

            If (pbxImg.SizeMode = PictureBoxSizeMode.Normal) Then
                pbxImg.Width = (456 * imgZoom) / 100
                pbxImg.Height = (304 * imgZoom) / 100
            End If
        End If

        'Recarga la imagen
        pbxImg.Refresh()

    End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If banGl_abmPersona = True Then
            '-- para abm persona
            frmAbmPeronaNuevo.txtFoto.Text = txtArchivo.Text
            frmAbmPeronaNuevo.picImagen.ImageLocation = strGl_rutaImagen & txtArchivo.Text

            Me.Close()
            frmAbmPeronaNuevo.Enabled = True
            frmAbmPeronaNuevo.Show()
            frmAbmPeronaNuevo.BringToFront()
        End If

        If banGl_abmProducto = True Then
            '-- para abm producto
            frmAbmProducto.lblImagen.Text = txtArchivo.Text
            frmAbmProducto.picImagen.ImageLocation = strGl_rutaImagen & txtArchivo.Text

            Me.Close()
            frmAbmProducto.Enabled = True
            frmAbmProducto.Show()
            frmAbmProducto.BringToFront()
        End If

    End Sub
    '----------------------------------------------------------------------------------------
    Private Function fnClipboard() As Object
        'Copiar imagen al portapeles
        'SetDataObject lleva 2 parámetros (objeto, booleano)
        'Si booleano es true, el objeto queda en el portapapeles
        'después de haber cerrado la aplicación
        Clipboard.SetDataObject(pbxImg.Image, True)
        'Variable objClipboard para contener el portapeles
        Dim objClipboard As IDataObject = Clipboard.GetDataObject()
        'devuelve el portapapeles como mapa de bits
        Return objClipboard.GetData(DataFormats.Bitmap)
    End Function

    'Para mostrar la imagen a tamaño real
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmBuscarImagen_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lbImg.Text = "Ninguna imagen cargada"
        lbImg2.Text = ""
    End Sub

    Private Sub frmBuscarImagen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_abmPersona = True Then
            '-- abm persona
            banGl_abmPersona = False

            frmAbmPeronaNuevo.Enabled = True
            frmAbmPeronaNuevo.Show()
            frmAbmPeronaNuevo.BringToFront()
        End If

        If banGl_abmProducto = True Then
            '-- abm producto
            banGl_abmProducto = False

            frmAbmProducto.Enabled = True
            frmAbmProducto.Show()
            frmAbmProducto.BringToFront()
        End If

    End Sub
    '----------------------------------------------------------------------------------------


End Class