Imports System.IO
Public Class frmArchivoCorreoCliente
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim strNombreArchivo As String = ""

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- generar el archivo txt del detalle
        systemClass.SqlToLv_archivoTxtEstudio(lvDetalle, "sp_consultaCorreoClientes ", intGl_idConfigPc)
        '-- generar el archi txt
        strNombreArchivo = "contactosClientesMulticolor"

        txtDireccion.Text = "c:\Multicolor\" & Trim(strNombreArchivo) & ".csv"

        Me.Refresh()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnExportarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarDetalle.Click
        Dim tmpIntContador As Integer = 0
        Dim tmpIntContadorOtro As Integer = 0
        '-- exportar el detalle
        Dim filepath As String = txtDireccion.Text
        Using file As New IO.StreamWriter(filepath, False)
            Dim line As String = ""
            Dim intTmpContador As Integer = 0
            For Each item As ListViewItem In lvDetalle.Items
                tmpIntContadorOtro = tmpIntContadorOtro + 1
                If tmpIntContadorOtro = 1 Then
                    line = "Name,Additional Name,E-mail 1 - Value"
                    file.WriteLine(line)
                Else
                    line = ""
                End If

                For Each subitem As ListViewItem.ListViewSubItem In item.SubItems
                    tmpIntContador = tmpIntContador + 1
                    If tmpIntContador < 4 Then
                        If tmpIntContadorOtro > 1 Then
                            If tmpIntContador = 3 Then
                                line = line & Trim(subitem.Text)
                            Else
                                line = line & Trim(subitem.Text) & ","
                            End If
                        End If
                    End If

                    'End If
                Next
                tmpIntContador = 0
                If tmpIntContadorOtro > 1 Then
                    file.WriteLine(line)
                End If

            Next
            file.Close()
        End Using
        '& Trim(txtSucursal.Text) & Trim((dtpDesdeFecha.Text)) & ".txt"
        Process.Start(filepath)
        ' MessageBox.Show("Archivo realizado con éxito...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmArchivoCorreoCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        '----------------------------------------------------
        e.Cancel = False
        frmEstadisticaClientes.Enabled = True
        frmEstadisticaClientes.Show()
        frmEstadisticaClientes.BringToFront()

    End Sub
End Class