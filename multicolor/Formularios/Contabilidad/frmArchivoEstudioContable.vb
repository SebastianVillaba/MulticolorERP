Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Text
Imports System.IO
Imports System.Diagnostics

Public Class frmArchivoEstudioContable
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla

    Dim strNombreArchivo As String = ""

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        '-- generar el archivo txt del detalle
        systemClass.SqlToLv_archivoTxtEstudio(lvDetalle, "sp_reporteVentaContableZayasTxt ", intGl_idConfigPc)
        '-- generar el archi txt
        '-- sumar el total del archivo generado
        lblTotalTxt.Text = sp_datosTabla.consulta_valorDouble("select sum(total) from tmpDetVentaContable_2 where idconfig=" & intGl_idConfigPc & " group by idConfig")
        lblTotalTxt.Text = Format(CDec(lblTotalTxt.Text), "###,###,###,##0")
        lblTotalIva10.Text = sp_datosTabla.consulta_valorDouble("select sum(iva10) from tmpDetVentaContable_2 where idconfig=" & intGl_idConfigPc & " group by idConfig")
        lblTotalIva10.Text = Format(CDec(lblTotalIva10.Text), "###,###,###,##0")
        lblTotalIVA5.Text = sp_datosTabla.consulta_valorDouble("select sum(iva5) from tmpDetVentaContable_2 where idconfig=" & intGl_idConfigPc & " group by idConfig")
        lblTotalIVA5.Text = Format(CDec(lblTotalIVA5.Text), "###,###,###,##0")
        '-- colocar el nombre del archivo
        Dim strTmpMes As String
        Dim strTmpAnho As String

        strTmpMes = frmReporteLibroIVA.dtpDesdeFecha.Text.Substring(3, 2)
        strTmpAnho = frmReporteLibroIVA.dtpHastaFecha.Text.Substring(6, 4)

        'MsgBox("Valor del mes " & strTmpMes)
        'MsgBox("Valor del anho " & strTmpAnho)

        Select Case strTmpMes
            Case "01"
                strTmpMes = "_ENERO_"
            Case "02"
                strTmpMes = "_FEBRERO_"
            Case "03"
                strTmpMes = "_MARZO_"
            Case "04"
                strTmpMes = "_ABRIL_"
            Case "05"
                strTmpMes = "_MAYO_"
            Case "06"
                strTmpMes = "_JUNIO_"
            Case "07"
                strTmpMes = "_JULIO_"
            Case "08"
                strTmpMes = "_AGOSTO_"
            Case "09"
                strTmpMes = "_SETIEMBRE_"
            Case "10"
                strTmpMes = "_OCTUBRE_"
            Case "11"
                strTmpMes = "_NOVIEMBRE_"
            Case "12"
                strTmpMes = "_DICIEMBRE_"
        End Select

        strNombreArchivo = Trim(frmReporteLibroIVA.txtSucursal.Text) & strTmpMes & strTmpAnho

        txtDireccion.Text = "c:\Multicolor\" & Trim(strNombreArchivo) & ".txt"

        Me.Refresh()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '*************'
    '-- BOTONES --'
    '*************'
    Private Sub btnExportarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarDetalle.Click
        '-- exportar el detalle
        Dim filepath As String = txtDireccion.Text
        Using file As New IO.StreamWriter(filepath, False)
            Dim line As String = ""
            Dim intTmpContador As Integer = 0
            For Each item As ListViewItem In lvDetalle.Items
                line = ""
                For Each subitem As ListViewItem.ListViewSubItem In item.SubItems
                    'line = line + (Trim(item.SubItems(0).Text) + ";" + Trim(item.SubItems(1).Text) + ";" + Trim(item.SubItems(2).Text) & _
                    '";" + (Trim(item.SubItems(3).Text)) + ";" + Trim(item.SubItems(4).Text) + ";" + Trim(item.SubItems(5).Text) & _
                    '";" + (Trim(item.SubItems(6).Text)) + ";" + Trim(item.SubItems(7).Text) + ";" + Trim(item.SubItems(8).Text) & _
                    '";" + (Trim(item.SubItems(9).Text)) + ";" + Trim(item.SubItems(10).Text) + ";" + Trim(item.SubItems(11).Text) & _
                    '";" + (Trim(item.SubItems(12).Text)) + ";" + Trim(item.SubItems(13).Text) + ";" + Trim(item.SubItems(14).Text) & _
                    '";" + (Trim(item.SubItems(15).Text)) + ";" + Trim(item.SubItems(16).Text) + ";" + Trim(item.SubItems(17).Text) & _
                    '";" + (Trim(item.SubItems(18).Text)) + ";" + Trim(item.SubItems(19).Text) + ";" + Trim(item.SubItems(20).Text) & _
                    '";" + (Trim(item.SubItems(21).Text)) + ";" + Trim(item.SubItems(22).Text) + ";" + Trim(item.SubItems(23).Text) & _
                    '";" + (Trim(item.SubItems(24).Text)))

                    'MsgBox("Valor " & item.SubItems(24).ToString)
                    'intTmpContador = intTmpContador + 1
                    'If intTmpContador = 1 Then
                    '    line = Trim(subitem.Text) & ";"
                    'Else
                    line = line & Trim(subitem.Text) & ";"
                    'End If
                Next
                file.WriteLine(line)
            Next
            file.Close()
        End Using
        '& Trim(txtSucursal.Text) & Trim((dtpDesdeFecha.Text)) & ".txt"
        Process.Start(filepath)
    End Sub


    '----------------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmReporteLibroIVA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '-- contador de formularios
        '----------------------------------------------------
        e.Cancel = False
        frmReporteLibroIVA.Enabled = True
        frmReporteLibroIVA.Show()
        frmReporteLibroIVA.BringToFront()

    End Sub

End Class